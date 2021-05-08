using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturama;
using Facturama.Models;
using Facturama.Models.Request;
using Facturama.Models.Response.Catalogs.Cfdi;
using System.Xml;
using System.IO;

namespace ValleVerdeComun.Programacion.Facturama
{
    public class FacturamaMetodos
    {
        string usuario = "";//"valleverde", 
        string contrasena = "";//"Ccontrasena5";
        string url_base = "";//"https://api.facturama.mx/Catalogs/";
        //string url_base = "https://apisandbox.facturama.mx/Catalogs/";
        string url_usosCFDI = "CfdiUses";
        string url_formasPago = "PaymentForms";
        string url_impuestos = "FederalTaxes";
        string url_tiposCFDI = "CfdiTypes";
        FacturamaApi facturama;
        DatosFactura datosFactura;

        List<String>  productos;
        //int timeout = 1000;

        public FacturamaMetodos(InterfazPrincipal form1)
        {
            DatosConfiguracionGlobal configuracion = new ConfiguracionGlobal().ObtenerConfiguracionGlobal();
            url_base = configuracion.url_base_facturacion;
            usuario = configuracion.usuarioFacturacion;
            contrasena = configuracion.contrasenaFacturacion;

            bool isDevelopment = true;
            if (url_base == "https://api.facturama.mx/Catalogs/")
                isDevelopment = false;

            facturama = new FacturamaApi(usuario, contrasena, isDevelopment);

        }
        public string[] CrearFactura(Client cliente, string usoCFDI, string idCliente, List<Product> Productos, Dictionary<string,decimal> cantidades, Dictionary<string, decimal> descuentos, Dictionary<string, string> idsFacturama, string formaPago)
        {
            //Si el cliente no existe en facturama entonces darlo de alta, si ya existe actualiza sus datos
            int r = CrearCliente(ref cliente, idCliente);
            string[] resultados = new string[] { "-1" ,"Error"};

            if (r == 1)
            {

                //var products = facturama.Products.List().Where(p => p.Taxes.Any()).ToList();

                var nameId = facturama.Catalogs.NameIds.ElementAt(0); //Nombre en el pdf: "Factura"
                var currency = facturama.Catalogs.Currencies.First(m => m.Value == "MXN");
                //var paymentMethod = facturama.Catalogs.PaymentMethods.First(p => p.Name == "Pago en una sola exhibición");
                //var paymentForm = facturama.Catalogs.PaymentForms.First(p => p.Name == "Efectivo");
                //var cliente = facturama.Clients.List().First(c => c.Rfc == "XAXX010101000");

                var branchOffice = facturama.BranchOffices.List().First();
                var decimals = (int)currency.Decimals;
                
                var cfdi = new Cfdi
                {
                    NameId = nameId.Value,
                    CfdiType = CfdiType.Ingreso,
                    PaymentForm = formaPago,//paymentForm.Value,
                    PaymentMethod = "PUE",// paymentMethod.Value,
                    Currency = currency.Value,
                    Date = DateTime.Now,
                    ExpeditionPlace = branchOffice.Address.ZipCode,
                    Items = new List<Item>(),
                    Receiver = new Receiver
                    {
                        CfdiUse = cliente.CfdiUse,
                        Name = cliente.Name,
                        Rfc = cliente.Rfc
                    }
                };

                bool errorProductos = false;
                foreach (Product producto in Productos)
                {
                    string idProducto = producto.Id;
                    var product = producto;
                    var quantity = cantidades[product.Id];//random.Next(1, 5); //Una cantidad aleatoria
                    var discount = descuentos[product.Id]; //Un descuento aleatorio
                    product.Id = idsFacturama[product.Id];
                    var subtotal = Math.Round(product.Price * quantity, decimals);

                    //Darlo de alta en facturama si es nuevo o solo actualizar su informacion
                    int  res  = CrearProducto(ref product, idProducto);

                    if(res == -1)
                    {
                        errorProductos = true;
                        break;
                    }
                    var item = new Item
                    {
                        ProductId = product.Id,
                        ProductCode = product.CodeProdServ,
                        UnitCode = product.UnitCode,
                        Unit = product.Unit,
                        Description = string.IsNullOrEmpty(product.Description) ? "Producto sin descripcion" : product.Description,
                        IdentificationNumber = idProducto,
                        Quantity = quantity,
                        Discount = Math.Round(discount, decimals),
                        UnitPrice = Math.Round(product.Price, decimals),
                        Subtotal = Math.Round(subtotal, decimals),
                        Taxes = product.Taxes != null ? product.Taxes.ToList() : null
                    };
                    var retenciones = item.Taxes?.Where(t => t.IsRetention).Sum(t => t.Total) ?? 0;
                    var traslados = item.Taxes?.Where(t => !t.IsRetention).Sum(t => t.Total) ?? 0;
                    item.Total = item.Subtotal - item.Discount + traslados - retenciones;
                    item.Total = Math.Round(item.Total, decimals);

                   

                    cfdi.Items.Add(item);

                    
                }

                if (!errorProductos)
                {
                    try
                    {
                        var cfdiCreated = facturama.Cfdis.Create(cfdi);

                        resultados[0] = cfdiCreated.Id;

                        Console.WriteLine($"Se creó exitosamente el cfdi con el folio fiscal: {cfdiCreated.Complement.TaxStamp.Uuid}");

                        //Obtener el xml para sacar la cadena de complemento original
                        string rutaXml = "cadenaComplemento.xml";
                        facturama.Cfdis.SaveXml(rutaXml, cfdiCreated.Id);
                        datosFactura = new DatosFactura(cfdiCreated.Complement.TaxStamp.Uuid,
                                                    cfdiCreated.Issuer.Rfc,
                                                    cfdiCreated.Receiver.Rfc,
                                                    cfdiCreated.Receiver.Name,
                                                    cfdiCreated.Total,
                                                    cfdiCreated.Complement.TaxStamp.CfdiSign,
                                                    cfdiCreated.Complement.TaxStamp.SatSign,
                                                    cfdiCreated.Complement.TaxStamp.Date,
                                                    cfdiCreated.Date, ObtenerCadenaComplemnento(rutaXml),
                                                    usoCFDI,
                                                    ObtenerNoCertificadoDigitalEmisor(rutaXml),
                                                    cfdiCreated.Complement.TaxStamp.SatCertNumber);


                        //facturama.Cfdis.SavePdf($"factura{cfdiCreated.Complement.TaxStamp.Uuid}.pdf", cfdiCreated.Id);
                        //facturama.Cfdis.SaveXml($"factura{cfdiCreated.Complement.TaxStamp.Uuid}.xml", cfdiCreated.Id);

                        //var list = facturama.Cfdis.List(cliente.Name);
                        //Console.WriteLine($"Se encontraron: {list.Length} elementos en la busqueda");

                        // list = facturama.Cfdis.List(rfc: "ESO1202108R2"); //Atributo en especifico
                        // Console.WriteLine($"Se encontraron: {list.Length} elementos en la busqueda");

                        //if (facturama.Cfdis.SendByMail(cfdiCreated.Id, cliente.Email))
                        //{
                        //    Console.WriteLine("Se envió correctamente el CFDI");
                        //}


                        //var cancelationStatus = facturama.Cfdis.Cancel(cfdiCreated.Id);
                        //if (cancelationStatus.Status == "canceled")
                        //{
                        //    Console.WriteLine($"Se canceló exitosamente el CFDI con el folio fiscal: {cfdiCreated.Complement.TaxStamp.Uuid}");
                        //}
                        //else if (cancelationStatus.Status == "pending")
                        //{
                        //    Console.WriteLine($"El CFDI está en proceso de cancelacion, require aprobacion por parte del receptor UUID: {cfdiCreated.Complement.TaxStamp.Uuid}");
                        //}
                        //else if (cancelationStatus.Status == "active")
                        //{
                        //    Console.WriteLine($"El CFDI no pudo ser cancelado, se deben revisar docuementos relacionados on cancelar directo en el SAT UUID: {cfdiCreated.Complement.TaxStamp.Uuid}");
                        //}
                        //else
                        //{
                        //    Console.WriteLine($"Estado de cancelacin del CFDI desconocido UUID: {cfdiCreated.Complement.TaxStamp.Uuid}");
                        //}

                    }
                    catch (FacturamaException ex)
                    {
                        Console.WriteLine(ex.Message);

                        if (ex.Model.Details != null)
                        {
                            foreach (var messageDetail in ex.Model.Details)
                            {
                                Console.WriteLine($"{messageDetail.Key}: {string.Join(",", messageDetail.Value)}");
                                resultados[0] = "-1";
                                resultados[1] = "Error: " + messageDetail.Value[0];
                                datosFactura = null;
                            }
                        }
                        else
                        {
                            resultados[0] = "-1";
                            resultados[1] = "Error: " + ex.Message;
                            datosFactura = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inesperado: ", ex.Message);
                        resultados[0] = "-1";
                        resultados[1] = "Error: " + ex.Message;
                        datosFactura = null;
                    }
                }
                else
                {
                    resultados[0] = "-1";
                    resultados[1] = "Error: Verificar los datosa de los productos en el ticket.";
                }
            }
            else
            {
                //Verificar datos cliente
                resultados[0] = "-1";
                resultados[1] = "Verificar datos del cliente.";
                datosFactura = null;
            }
           
            return resultados;
        }

        public void EnviarFacturaPorCorreo(string idFactura, string correo)
        {
            if (facturama.Cfdis.SendByMail(idFactura, correo))
            {
                Console.WriteLine("Se envió correctamente el CFDI");
            }
        }

        private string ObtenerCadenaComplemnento(string ruta)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(File.ReadAllText(ruta)); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.GetElementsByTagName("tfd:TimbreFiscalDigital");

            string cadena = "||"+xnList[0].Attributes["Version"].InnerText+ "|"+ xnList[0].Attributes["UUID"].InnerText+"|"+xnList[0].Attributes["FechaTimbrado"].InnerText + "|" + xnList[0].Attributes["RfcProvCertif"].InnerText + "|" + xnList[0].Attributes["SelloCFD"].InnerText + "|" + xnList[0].Attributes["NoCertificadoSAT"].InnerText+"||";

            return cadena;
        }

        private string ObtenerNoCertificadoDigitalEmisor(string ruta)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(File.ReadAllText(ruta)); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.GetElementsByTagName("cfdi:Comprobante");

            string cadena = xnList[0].Attributes["NoCertificado"].InnerText;

            return cadena;
        }

        private string ObtenerUsoCfdi(string ruta)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(File.ReadAllText(ruta)); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.GetElementsByTagName("cfdi:Receptor");

            string cadena = xnList[0].Attributes["UsoCFDI"].InnerText;

            return cadena;
        }
        private int CrearCliente(ref Client cliente, string idCliente)
        {
            //var clientes = facturama.Clients.List();
            int res = 1;

            if (cliente.Id == "-1")
            {
                //Crearlo en facturama
                try
                {
                    Client clienteCreado = null;
                    //Crear el cliente con direccion solo si esta es valida
                    if (cliente.Address.Country != "" && cliente.Address.ExteriorNumber != "" &&
                        cliente.Address.Locality != "" && cliente.Address.Municipality != "" &&
                        cliente.Address.Neighborhood != "" && cliente.Address.State != "" &&
                        cliente.Address.Street != "" &&
                        cliente.Address.ZipCode != "")
                    {
                        clienteCreado = facturama.Clients.Create(new Client
                        {
                            Address = new Address
                            {
                                Country = cliente.Address.Country,
                                ExteriorNumber = cliente.Address.ExteriorNumber,
                                InteriorNumber = cliente.Address.InteriorNumber,
                                Locality = cliente.Address.Locality,
                                Municipality = cliente.Address.Municipality,
                                Neighborhood = cliente.Address.Neighborhood,
                                State = cliente.Address.State,
                                Street = cliente.Address.Street,
                                ZipCode = cliente.Address.ZipCode
                            },
                            CfdiUse = cliente.CfdiUse,
                            Email = cliente.Email,
                            Rfc = cliente.Rfc,
                            Name = cliente.Name
                        });
                    }
                    else
                    {
                        clienteCreado = facturama.Clients.Create(new Client
                        {
                            CfdiUse = cliente.CfdiUse,
                            Email = cliente.Email,
                            Rfc = cliente.Rfc,
                            Name = cliente.Name
                        });
                    }
                    cliente = clienteCreado;
                    

                    //Actualizar el id en mi BD
                    new Clientes().AsignarIDFacturama(idCliente, clienteCreado.Id);
                }
                catch(Exception e) 
                {
                    res = -1;
                }
                
            }
            else
            {
                Client c = facturama.Clients.Retrieve(cliente.Id);
                if (c != null)
                {
                    //Actualizar el cliente con direccion solo si esta es valida
                    if (!(cliente.Address.Country != "" && cliente.Address.ExteriorNumber != "" &&
                        cliente.Address.Locality != "" && cliente.Address.Municipality != "" &&
                        cliente.Address.Neighborhood != "" && cliente.Address.State != "" &&
                        cliente.Address.Street != "" &&
                        cliente.Address.ZipCode != ""))
                        cliente.Address = null;

                    //Actualizar su informacion en Facturama
                    facturama.Clients.Update(cliente, cliente.Id);
                }
                else
                {
                    //Algo esta mal y no esta dado de alta, corregirlo
                    cliente.Id = "-1";
                    CrearCliente(ref cliente, idCliente);
                }
            }

            return res;
        }

        private int CrearProducto(ref Product producto, string idProducto)
        {
            //var clientes = facturama.Clients.List();
            int res = 1;

            if (producto.Id == "-1")
            {
                //Crearlo en facturama
                try
                {
                    var productoCreado = facturama.Products.Create(producto);

                    producto.Id = productoCreado.Id;
                    //Actualizar el id en mi BD
                    new Producto().AsignarIDFacturama(idProducto, productoCreado.Id);
                }
                catch (Exception e)
                {
                    res = -1;
                }

            }
            else
            {
                Product p = facturama.Products.Retrieve(producto.Id);
                if(p!= null)
                    //Actualizar su informacion en Facturama
                    facturama.Products.Update(producto, producto.Id);
                else
                {
                    //Algo esta mal y no esta dado de alta, corregirlo
                    producto.Id = "-1";
                    CrearProducto(ref producto, idProducto);
                }
            }

            return res;
        }

        private void AgregarProducto()
        {
            ////string URL = ';


            //HttpClient client = new HttpClient();
            ////client.Timeout = new TimeSpan(timeout);
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));
            //var byteArray = Encoding.ASCII.GetBytes("jorgea380:Ccontrasena5");
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            //HttpResponseMessage response;
            
            //string data = @"{
            //  'Unit': 'Servicio',
            //  'UnitCode': 'E48',
            //  'IdentificationNumber': 'WEB003',
            //  'Name': 'Sitio Web CMS',
            //  'Description': 'Desarrollo e implementación de sitio web empleando un CMS',
            //  'Price': 6500.0,
            //  'CodeProdServ': '43232408',
            //  'CuentaPredial': '123',
            //  'Taxes': [
            //    {
            //                'Name': 'IVA',
            //      'Rate': 0.16,
            //      'IsRetention': false,
            //      'IsFederalTax': true
            //    },
            //    {
            //                'Name': 'ISR',
            //      'IsRetention': true,
            //      'IsFederalTax': true,
            //      'Total': 0.1
            //    },
            //    {
            //                'Name': 'IVA',
            //      'IsRetention': true,
            //      'IsFederalTax': true,
            //      'Total': 0.106667
            //    }
            //  ]
            //}";

            //JObject json = (JObject)JsonConvert.DeserializeObject(data);

            //StringContent contenido = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            //try
            //{
            //    response = client.PostAsync(URL_Servicio, contenido).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            //}
            //catch (AggregateException)
            //{
            //    response = new HttpResponseMessage();
            //    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            //}



            //if (response.IsSuccessStatusCode)
            //{
            //    var data1 = response.Content.ReadAsStringAsync().Result;
            //    try
            //    {
            //        JObject json1 = (JObject)JsonConvert.DeserializeObject(data1);
            //        if (json1["prodsAsignadosResp"]["codResp"].ToString() == "0")
            //        {
            //            var pArray = json1["prodsAsignadosResp"]["productos"].Value<JArray>();
            //            //productosRecargas = pArray.ToObject<List<ProductoMovivendor>>();
            //        }
            //    }
            //    catch
            //    {
            //       // productosRecargas = null;
            //    }


            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //    //productosRecargas = null;
            //}
            ////prod = new List<ProductoMovivendor>();
            ////if(productosRecargas!=null)
            // //   prod.AddRange(productosRecargas);
           

            ////Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            //client.Dispose();
           
        }

        public List<string[]> ObtenerUsosCFDI(string RFC)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url_base+url_usosCFDI);
            //client.Timeout = new TimeSpan(300);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes(usuario+":"+contrasena);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));


            List<string[]> resultado = new List<string[]>();
            // List data response.
            HttpResponseMessage response;

            try
            {
                response = client.GetAsync("?keyword="+RFC).Result;// Blocking call! Program will wait here until a response is received or a timeout occurs.
            }
            catch (AggregateException)
            {
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }



            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                try
                {
                    if (data != "null")
                    {
                        JArray json = (JArray)JsonConvert.DeserializeObject(data);
                        foreach (JToken uso in json)
                        {
                            resultado.Add(new string[] { uso["Natural"].ToString(), uso["Moral"].ToString(), uso["Name"].ToString(), uso["Value"].ToString() });
                        }
                    }
                }
                catch(Exception e)
                {
                   // resultado = -1m;
                }


            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
               // resultado = -1m;
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return resultado;
        }

        public List<string[]> ObtenerFormasPago()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url_base + url_formasPago);
            //client.Timeout = new TimeSpan(300);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes(usuario + ":" + contrasena);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));


            List<string[]> resultado = new List<string[]>();
            // List data response.
            HttpResponseMessage response;

            try
            {
                response = client.GetAsync("").Result;// Blocking call! Program will wait here until a response is received or a timeout occurs.
            }
            catch (AggregateException)
            {
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }



            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                try
                {

                    JArray json = (JArray)JsonConvert.DeserializeObject(data);
                    foreach (JToken uso in json)
                    {
                        resultado.Add(new string[] { uso["Name"].ToString(), uso["Value"].ToString() });
                    }
                }
                catch (Exception e)
                {
                    // resultado = -1m;
                }


            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                // resultado = -1m;
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return resultado;
        }

        public List<string[]> ObtenerCatalogoImpuestos()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url_base + url_impuestos);
            //client.Timeout = new TimeSpan(300);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes(usuario + ":" + contrasena);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));


            List<string[]> resultado = new List<string[]>();
            // List data response.
            HttpResponseMessage response;

            try
            {
                response = client.GetAsync("").Result;// Blocking call! Program will wait here until a response is received or a timeout occurs.
            }
            catch (AggregateException)
            {
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }



            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                try
                {

                    JArray json = (JArray)JsonConvert.DeserializeObject(data);
                    foreach (JToken uso in json)
                    {
                        resultado.Add(new string[] { uso["Name"].ToString(), uso["Value"].ToString() });
                    }
                }
                catch (Exception e)
                {
                    // resultado = -1m;
                }


            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                // resultado = -1m;
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return resultado;
        }

        public List<string[]> ObtenerCatalogoTipsCFDI()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url_base + url_tiposCFDI);
            //client.Timeout = new TimeSpan(300);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes(usuario + ":" + contrasena);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));


            List<string[]> resultado = new List<string[]>();
            // List data response.
            HttpResponseMessage response;

            try
            {
                response = client.GetAsync("").Result;// Blocking call! Program will wait here until a response is received or a timeout occurs.
            }
            catch (AggregateException)
            {
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }



            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                try
                {

                    JArray json = (JArray)JsonConvert.DeserializeObject(data);
                    foreach (JToken uso in json)
                    {
                        resultado.Add(new string[] { uso["Name"].ToString(), uso["Value"].ToString() });
                    }
                }
                catch (Exception e)
                {
                    // resultado = -1m;
                }


            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                // resultado = -1m;
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return resultado;
        }

        public DatosFactura ObtenerDatosFactura()
        {

            return datosFactura;
        }

        public DatosFactura ObtenerDatosFactura(string idFactura)
        {
            var cfdiCreated = facturama.Cfdis.Retrieve(idFactura);

            //Obtener el xml para sacar la cadena de complemento original
            string rutaXml = "cadenaComplemento.xml";
            facturama.Cfdis.SaveXml(rutaXml, cfdiCreated.Id);
            datosFactura = new DatosFactura(cfdiCreated.Complement.TaxStamp.Uuid,
                                        cfdiCreated.Issuer.Rfc,
                                        cfdiCreated.Receiver.Rfc,
                                        cfdiCreated.Receiver.Name,
                                        cfdiCreated.Total,
                                        cfdiCreated.Complement.TaxStamp.CfdiSign,
                                        cfdiCreated.Complement.TaxStamp.SatSign,
                                        cfdiCreated.Complement.TaxStamp.Date,
                                        cfdiCreated.Date, ObtenerCadenaComplemnento(rutaXml),
                                        ObtenerUsoCfdi(rutaXml),
                                        ObtenerNoCertificadoDigitalEmisor(rutaXml),
                                        cfdiCreated.Complement.TaxStamp.SatCertNumber);
            
            return datosFactura;
        }

    }
}
