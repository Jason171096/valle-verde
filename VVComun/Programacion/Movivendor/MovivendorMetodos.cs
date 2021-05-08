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

namespace ValleVerdeComun.Programacion.Movivendor
{
    public class MovivendorMetodos
    {
        string URL_Servicio = "";//"https://desarrollo.movivendor.com/services/srv/sale/";
        string urlDatosAccesoRecargas = "";//Estos se cargaran de configuracion
        string urlDatosAccesoServicios = "";//Estos se cargaran de configuracion
        List<ProductoMovivendor> productos;
        List<ProductoMovivendor> productosRecargas;
        List<ProductoMovivendor> productosServicios;
        //int timeout = 1000;

        public MovivendorMetodos(InterfazPrincipal form1)
        {
            DatosConfiguracionGlobal configuracion = new ConfiguracionGlobal().ObtenerConfiguracionGlobal();

            URL_Servicio = configuracion.url_servicio;
            urlDatosAccesoRecargas = "?idcanal=" + configuracion.movivendor_idcanal_recargas +"&ident=" + configuracion.movivendor_ident_recargas + "&pwd=" + configuracion.movivendor_pwd_recargas;
            urlDatosAccesoServicios = "?idcanal=" + configuracion.movivendor_idcanal_servicios + "&ident=" + configuracion.movivendor_ident_servicios + "&pwd=" + configuracion.movivendor_pwd_servicios;

            bool c = true;

            do
            {
                try
                {
                    form1.Invoke(form1.ObtenerResultadosCargarMovivendor, new object[] { this });
                    c = false;
                }
                catch
                {
                    c = true;
                }
            }
            while (c);

            CargarProductosAsignados();
            
        }

        public void CargarProductosAsignados()
        {
            productos = ObtenerProductosAsignados();

        }
        private List<ProductoMovivendor> ObtenerProductosAsignados()
        {
            //string URL = "";


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL_Servicio + "prodAsignados");
            //client.Timeout = new TimeSpan(timeout);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            //Cargando los productos del canal de recargas
            // List data response.
            List<ProductoMovivendor> prod = null;

            HttpResponseMessage response;

            try
            {
                response = client.GetAsync(urlDatosAccesoRecargas).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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
                    JObject json = (JObject)JsonConvert.DeserializeObject(data);
                    if (json["prodsAsignadosResp"]["codResp"].ToString() == "0")
                    {
                        var pArray = json["prodsAsignadosResp"]["productos"].Value<JArray>();
                        productosRecargas = pArray.ToObject<List<ProductoMovivendor>>();
                    }
                }
                catch
                {
                    productosRecargas = null;
                }


            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                productosRecargas = null;
            }
            prod = new List<ProductoMovivendor>();
            if(productosRecargas!=null)
                prod.AddRange(productosRecargas);
            //Cargando los productos del canal de servicios y pines
            // List data response.
            if (urlDatosAccesoRecargas != urlDatosAccesoServicios)
            {
                try
                {
                    response = client.GetAsync(urlDatosAccesoServicios).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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
                        JObject json = (JObject)JsonConvert.DeserializeObject(data);
                        if (json["prodsAsignadosResp"]["codResp"].ToString() == "0")
                        {
                            var pArray = json["prodsAsignadosResp"]["productos"].Value<JArray>();
                            productosServicios = pArray.ToObject<List<ProductoMovivendor>>();
                        }
                    }
                    catch
                    {
                        productosServicios = null;
                    }


                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    productosServicios = null;
                }

                //Mezclar los dos en un solo array


                if (prod != null)
                {
                    if (productosServicios != null)
                    {
                        //Mezclar ambos
                        prod.AddRange(productosServicios);
                    }
                }
                else
                    if (productosServicios != null)
                    prod = productosServicios;
            }
            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            if(prod != null)
                prod.Sort();
            return prod;
        }

        public List<string> ObtenerGrupos()
        {
            List<string> grupos = new List<string>();

            if (productos == null)
                productos = ObtenerProductosAsignados();

            foreach (var producto in productos)
            {
                if (!grupos.Contains(producto.grupo))
                    grupos.Add(producto.grupo);
            }

            return grupos;
        }

        public List<ProductoMovivendor> ObtenerListaProductosRecargas()
        {
            if(productos == null)
                productos = ObtenerProductosAsignados();

            List<ProductoMovivendor> listarProductosRecagas = new List<ProductoMovivendor>();
            if (productos != null)
            {
                foreach (var producto in productos)
                {
                    if (producto.grupo == "Tiempo Aire")
                        listarProductosRecagas.Add(producto);
                }

            }


            return listarProductosRecagas;
        }

        public List<ProductoMovivendor> ObtenerListaProductosSecundariosRecargas(ProductoMovivendor productoTiempoAire)
        {
            if (productos == null)
                productos = ObtenerProductosAsignados();

            List<ProductoMovivendor> listarProductosSecundariosRecagas = new List<ProductoMovivendor>();


            foreach (var producto in productos)
            {
                //Los secundarios tienen en el nombre del grupo el nombre de un producto de tiempo aire
                if (producto.grupo != null)
                {
                    if (producto.grupo.Contains(productoTiempoAire.nombre))
                        listarProductosSecundariosRecagas.Add(producto);
                }
                
            }

            return listarProductosSecundariosRecagas;
        }

        public List<ProductoMovivendor> ObtenerListaProductosServicios()
        {
            if (productos == null)
                productos = ObtenerProductosAsignados();

            List<ProductoMovivendor> listarProductosServicios = new List<ProductoMovivendor>();

            if (productos != null)
            {
                foreach (var producto in productos)
                {
                    if (producto.grupo == "Pago de Servicios" || producto.grupo == "Servicios")
                        listarProductosServicios.Add(producto);
                }
            }
            return listarProductosServicios;
        }

        public List<ProductoMovivendor> ObtenerListaProductosPines()
        {
            List<ProductoMovivendor> listarProductosPines = new List<ProductoMovivendor>();

            if (productos == null)
                productos = ObtenerProductosAsignados();

            if (productos != null)
            {
                foreach (var producto in productos)
                {
                    if (producto.grupo == "Pines")
                        listarProductosPines.Add(producto);
                }
            }
            return listarProductosPines;
        }

        public List<ProductoMovivendor> ObtenerListaProductosPeajes()
        {
            List<ProductoMovivendor> listarProductosPeajes = new List<ProductoMovivendor>();

            if (productos == null)
                productos = ObtenerProductosAsignados();

            if (productos != null)
            {
                foreach (var producto in productos)
                {
                    if (producto.grupo == "Peajes")
                        listarProductosPeajes.Add(producto);
                }
            }
            return listarProductosPeajes;
        }

        public RespuestaVenta CobrarRecargaservicio(string idtrans,string terminal, string sku, string destino, decimal monto,string extra)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL_Servicio + "venta");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("User-Agent", "Apache-HttpClient/4.1.1 (java 1.5)");
            client.Timeout = System.TimeSpan.FromSeconds(40);

            StringContent contenido = new StringContent("");
            contenido.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            contenido.Headers.ContentLength = 0;

            //NOTA: movivendor requiere  que idtrans sea de 12 digitos exactamente
            idtrans = string.Format("{0:D12}", int.Parse(idtrans));

            string datosPost = "";
            if(extra == "")
               datosPost = "&idtrans="+ idtrans + "&terminal=" + terminal + "&sku=" + sku + "&destino=" + destino + "&monto=" + monto ;
            else
                datosPost = "&idtrans=" + idtrans + "&terminal=" + terminal + "&sku=" + sku + "&destino=" + destino + "&monto=" + monto + "&extra=" + extra;

            RespuestaVenta resultado = null;
            // List data response.
            HttpResponseMessage response;
            bool esRecarga = ObtenerSiEsRecarga(sku);
            try
            {
                if(esRecarga)
                    response = client.PostAsync(urlDatosAccesoRecargas + datosPost, contenido).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                else
                    response = client.PostAsync(urlDatosAccesoServicios + datosPost, contenido).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            }
            catch (TimeoutException)
            {
                //Checar estatus de venta, si fue exitosa regresar el estatus de la venta,de lo contrario revertirla
                resultado = ChecarStatusVenta(idtrans, terminal, sku, destino, monto, extra,1,true);
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (AggregateException)
            {
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }

            
            if (response.IsSuccessStatusCode)
            {
                
                try
                {
                    if (resultado == null)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        resultado = new RespuestaVenta(data);
                    }

                    //Checar el codigo de resultado y acutar segun corresponda
                    if (resultado.rcode != "00")
                    {
                        if(resultado.rcode == "88" || resultado.rcode == "89") 
                        { 
                                //Operación en progreso/Operación no encontrada esperar respuesta
                                resultado = ChecarStatusVenta(idtrans, terminal, sku, destino, monto, extra,1,true);
                                
                        }
                        else
                        {
                            switch (resultado.rcode)
                            {
                                case "01":
                                    resultado.msgResp = "Usuario no está registrado.";
                                    break;
                                case "03":
                                    resultado.msgResp = "Usuario destino no está registrado.";
                                    break;
                                case "05":
                                    resultado.msgResp = "Saldo insuficiente, intente por un monto menor.";
                                    break;
                                case "04":
                                    resultado.msgResp = "Monto inválido.";
                                    break;
                                case "06":
                                    resultado.msgResp = "Usuario desconocido.";
                                    break;
                                case "11":
                                    resultado.msgResp = "No se permite la venta a sí mismo.";
                                    break;
                                case "12":
                                    resultado.msgResp = "No se permite la transferencia a sí mismo.";
                                    break;
                                case "13":
                                    resultado.msgResp = "No se puede realizar la recarga.";
                                    break;
                                case "15":
                                    resultado.msgResp = "Usuario está bloqueado.";
                                    break;
                                case "16":
                                    resultado.msgResp = "Limite de transferencia excedido.";
                                    break;
                                case "20":
                                    resultado.msgResp = "El servidor de prepago no responde.";
                                    break;
                                case "21":
                                    resultado.msgResp = "El servidor de prepago no está disponible.";
                                    break;
                                case "22":
                                    resultado.msgResp = "Destino no es un teléfono de prepago.";
                                    break;
                                case "23":
                                    resultado.msgResp = "Teléfono en uso.";
                                    break;
                                case "24":
                                    resultado.msgResp = "Teléfono destino en uso.";
                                    break;
                                case "25":
                                    resultado.msgResp = "El usuario destino está bloqueado.";
                                    break;
                                case "26":
                                    resultado.msgResp = "Venta reciente de este punto a ese destino.";
                                    break;
                                case "27":
                                    resultado.msgResp = "El máximo de compras diarias ha sido realizado.";
                                    break;
                                case "28":
                                    resultado.msgResp = "Límite de crédito excedido.";
                                    break;
                                case "29":
                                    resultado.msgResp = "El producto solicitado está agotado.";
                                    break;
                                case "30":
                                    resultado.msgResp = "Transacción fuera de horario.";
                                    break;
                                case "31":
                                    resultado.msgResp = "Código de proveedor inválido.";
                                    break;
                                case "34":
                                    resultado.msgResp = "Producto temporalmente no disponible.";
                                    break;
                                case "35":
                                    resultado.msgResp = "Servicio no disponible.";
                                    break;
                                case "36":
                                    resultado.msgResp = "Comisión inválida para el producto seleccionado, contacte al distribuidor.";
                                    break;
                                case "37":
                                    resultado.msgResp = "Producto seleccionado no tiene comision, contacte al distribuidor.";
                                    break;
                                case "40":
                                    resultado.msgResp = "Tiene una suscripción vigente, espere 24h.";
                                    break;
                                case "50":
                                    resultado.msgResp = "Error interno. Favor de notificar al operador.";
                                    break;
                                case "51":
                                    resultado.msgResp = "Base de datos no disponible.";
                                    break;
                                case "52":
                                    resultado.msgResp = "No ha pasado el periodo mínimo de activacion.";
                                    break;
                                case "53":
                                    resultado.msgResp = "El destino no ha pasado el periodo mínimo de activación.";
                                    break;
                                case "55":
                                    resultado.msgResp = "Producto no disponible por el momento.";
                                    break;
                                case "56":
                                    resultado.msgResp = "El cliente tiene compras demasiado recientes.";
                                    break;
                                case "60":
                                    resultado.msgResp = "Retener tarjeta del cliente.";
                                    break;
                                case "61":
                                    resultado.msgResp = "Por favor llamar a la emisora de la tarjeta.";
                                    break;
                                case "87":
                                    resultado.msgResp = "Operación no fue procesada.";
                                    break;
                                case "94":
                                    resultado.msgResp = "Por favor intente de nuevo en 5 minutos.";
                                    break;
                                case "95":
                                    resultado.msgResp = "Cuenta con una suscripción vigente, espere 24 hrs.";
                                    break;
                                case "103":
                                    resultado.msgResp = "Su saldo ha expirado.";
                                    break;
                                case "104":
                                    resultado.msgResp = "Datos no coinciden con lo indicado en la petición.";
                                    break;
                                case "105":
                                    resultado.msgResp = "La pérdida ya ha sido reportada.";
                                    break;
                            }
                        }

                       
                    }
                }
                catch 
                {
                    resultado = new RespuestaVenta("-2", "Contenido de respuesta invalido");
                }


            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                resultado = new RespuestaVenta("-1", "Error al hacer la solicitud, verifique su conexion a internet");
            }
            

            client.Dispose();
            return resultado;
        }

        public RespuestaVenta ReversoRecargaservicio(string idtrans, string terminal, string sku, string destino, decimal monto, string extra)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL_Servicio + "reverso");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("User-Agent", "Apache-HttpClient/4.1.1 (java 1.5)");
            client.Timeout = System.TimeSpan.FromSeconds(40);

            StringContent contenido = new StringContent("");
            contenido.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            contenido.Headers.ContentLength = 0;

            //NOTA: movivendor requiere  que idtrans sea de 12 digitos exactamente
            idtrans = string.Format("{0:D12}", int.Parse(idtrans));

            string datosPost = "";
            if (extra == "")
                datosPost = "&idtrans=" + idtrans + "&terminal=" + terminal + "&sku=" + sku + "&destino=" + destino + "&monto=" + monto;
            else
                datosPost = "&idtrans=" + idtrans + "&terminal=" + terminal + "&sku=" + sku + "&destino=" + destino + "&monto=" + monto + "&extra=" + extra;

            RespuestaVenta resultado = null;
            // List data response.
            HttpResponseMessage response;

            bool esRecarga = ObtenerSiEsRecarga(sku);

            try
            {
                if(esRecarga)
                    response = client.PostAsync(urlDatosAccesoRecargas + datosPost, contenido).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                else 
                    response = client.PostAsync(urlDatosAccesoServicios + datosPost, contenido).Result;
            }
            catch (TimeoutException)
            {
                //Checar estatus de venta, si fue exitosa regresar el estatus de la venta,de lo contrario revertirla
                resultado = ChecarStatusVenta(idtrans, terminal, sku, destino, monto, extra, 1, true);
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (AggregateException)
            {
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }


            if (response.IsSuccessStatusCode)
            {

                try
                {
                    if (resultado == null)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        resultado = new RespuestaVenta(data);
                    }

                    //Checar el codigo de resultado y acutar segun corresponda
                    if (resultado.rcode != "00")
                    {
                        if (resultado.rcode == "88" || resultado.rcode == "89")
                        {
                            //Operación en progreso/Operación no encontrada esperar respuesta
                            resultado = ChecarStatusVenta(idtrans, terminal, sku, destino, monto, extra, 1, true);

                        }
                        else
                        {
                            switch (resultado.rcode)
                            {
                                case "01":
                                    resultado.msgResp = "Usuario no está registrado.";
                                    break;
                                case "03":
                                    resultado.msgResp = "Usuario destino no está registrado.";
                                    break;
                                case "05":
                                    resultado.msgResp = "Saldo insuficiente, intente por un monto menor.";
                                    break;
                                case "04":
                                    resultado.msgResp = "Monto inválido.";
                                    break;
                                case "06":
                                    resultado.msgResp = "Usuario desconocido.";
                                    break;
                                case "11":
                                    resultado.msgResp = "No se permite la venta a sí mismo.";
                                    break;
                                case "12":
                                    resultado.msgResp = "No se permite la transferencia a sí mismo.";
                                    break;
                                case "13":
                                    resultado.msgResp = "No se puede realizar la recarga.";
                                    break;
                                case "15":
                                    resultado.msgResp = "Usuario está bloqueado.";
                                    break;
                                case "16":
                                    resultado.msgResp = "Limite de transferencia excedido.";
                                    break;
                                case "20":
                                    resultado.msgResp = "El servidor de prepago no responde.";
                                    break;
                                case "21":
                                    resultado.msgResp = "El servidor de prepago no está disponible.";
                                    break;
                                case "22":
                                    resultado.msgResp = "Destino no es un teléfono de prepago.";
                                    break;
                                case "23":
                                    resultado.msgResp = "Teléfono en uso.";
                                    break;
                                case "24":
                                    resultado.msgResp = "Teléfono destino en uso.";
                                    break;
                                case "25":
                                    resultado.msgResp = "El usuario destino está bloqueado.";
                                    break;
                                case "26":
                                    resultado.msgResp = "Venta reciente de este punto a ese destino.";
                                    break;
                                case "27":
                                    resultado.msgResp = "El máximo de compras diarias ha sido realizado.";
                                    break;
                                case "28":
                                    resultado.msgResp = "Límite de crédito excedido.";
                                    break;
                                case "29":
                                    resultado.msgResp = "El producto solicitado está agotado.";
                                    break;
                                case "30":
                                    resultado.msgResp = "Transacción fuera de horario.";
                                    break;
                                case "31":
                                    resultado.msgResp = "Código de proveedor inválido.";
                                    break;
                                case "34":
                                    resultado.msgResp = "Producto temporalmente no disponible.";
                                    break;
                                case "35":
                                    resultado.msgResp = "Servicio no disponible.";
                                    break;
                                case "36":
                                    resultado.msgResp = "Comisión inválida para el producto seleccionado, contacte al distribuidor.";
                                    break;
                                case "37":
                                    resultado.msgResp = "Producto seleccionado no tiene comision, contacte al distribuidor.";
                                    break;
                                case "40":
                                    resultado.msgResp = "Tiene una suscripción vigente, espere 24h.";
                                    break;
                                case "50":
                                    resultado.msgResp = "Error interno. Favor de notificar al operador.";
                                    break;
                                case "51":
                                    resultado.msgResp = "Base de datos no disponible.";
                                    break;
                                case "52":
                                    resultado.msgResp = "No ha pasado el periodo mínimo de activacion.";
                                    break;
                                case "53":
                                    resultado.msgResp = "El destino no ha pasado el periodo mínimo de activación.";
                                    break;
                                case "55":
                                    resultado.msgResp = "Producto no disponible por el momento.";
                                    break;
                                case "56":
                                    resultado.msgResp = "El cliente tiene compras demasiado recientes.";
                                    break;
                                case "60":
                                    resultado.msgResp = "Retener tarjeta del cliente.";
                                    break;
                                case "61":
                                    resultado.msgResp = "Por favor llamar a la emisora de la tarjeta.";
                                    break;
                                case "87":
                                    resultado.msgResp = "Operación no fue procesada.";
                                    break;
                                case "94":
                                    resultado.msgResp = "Por favor intente de nuevo en 5 minutos.";
                                    break;
                                case "95":
                                    resultado.msgResp = "Cuenta con una suscripción vigente, espere 24 hrs.";
                                    break;
                                case "103":
                                    resultado.msgResp = "Su saldo ha expirado.";
                                    break;
                                case "104":
                                    resultado.msgResp = "Datos no coinciden con lo indicado en la petición.";
                                    break;
                                case "105":
                                    resultado.msgResp = "La pérdida ya ha sido reportada.";
                                    break;
                            }
                        }


                    }
                }
                catch
                {
                    resultado = new RespuestaVenta("-2", "Contenido de respuesta invalido");
                }


            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                resultado = new RespuestaVenta("-1", "Error al hacer la solicitud, verifique su conexion a internet");
            }


            client.Dispose();
            return resultado;
        }

        public RespuestaVenta ChecarStatusVenta(string idtrans, string terminal, string sku, string destino, decimal monto, string extra, int noIntento,bool esVenta)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL_Servicio + "statusVenta");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("User-Agent", "Apache-HttpClient/4.1.1 (java 1.5)");
            client.Timeout = System.TimeSpan.FromSeconds(40);

            string datosPost;
            
            if(extra == "")
                datosPost = "&idtrans=" + idtrans + "&terminal=" + terminal + "&sku=" + sku + "&destino=" + destino + "&monto=" + monto;
            else 
                datosPost = "&idtrans=" + idtrans + "&terminal=" + terminal + "&sku=" + sku + "&destino=" + destino + "&monto=" + monto + "&extra=" + extra;

            RespuestaVenta resultado = null;
            // List data response.
            HttpResponseMessage response;

            bool esRecarga = ObtenerSiEsRecarga(sku);

            try
            {
                if(esRecarga)
                    response = client.GetAsync(urlDatosAccesoRecargas + datosPost).Result;
                else
                    response = client.GetAsync(urlDatosAccesoServicios + datosPost).Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
            }
            catch (TimeoutException)
            {
                //Se acabo el timepo de espera y no recibi respuesta, volveer a intentar solo 5 veces
                if (noIntento <= 5)
                {
                    Thread.Sleep(1000);
                    resultado = ChecarStatusVenta(idtrans, terminal, sku, destino, monto, extra, noIntento + 1, esVenta);
                    response = new HttpResponseMessage();
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response = new HttpResponseMessage();
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch (AggregateException)
            {
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }


            if (response.IsSuccessStatusCode)
            {
               
                try
                {
                    if (resultado == null)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        resultado = new RespuestaVenta(data);
                        if (resultado.rcode != "00")
                        {
                            if (esVenta && (resultado.rcode == "88" || resultado.rcode == "89"))
                            {
                                //Operación en progreso/Operación no encontrada esperar respuesta
                                resultado = ChecarStatusVenta(idtrans, terminal, sku, destino, monto, extra, noIntento+1, esVenta);

                            }


                        }

                    }

                }
                catch 
                {
                    resultado = new RespuestaVenta("-2", "Contenido de respuesta invalido");
                }


            }
            else
            {
               
                resultado = new RespuestaVenta("-1001", "No se puede verificar el estatus de la venta, verifique su conexion a internet e intente nuevamente");
            }

            client.Dispose();
            return resultado;
        }

        public decimal ObtenerSaldoDisponible(bool esRecarga)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL_Servicio + "saldoCliente");
            //client.Timeout = new TimeSpan(300);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            decimal resultado = 0m;
            // List data response.
            HttpResponseMessage response;

            try
            {
                if(esRecarga)
                    response = client.GetAsync(urlDatosAccesoRecargas).Result;
                else
                    response = client.GetAsync(urlDatosAccesoServicios).Result;// Blocking call! Program will wait here until a response is received or a timeout occurs.
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
                    JObject json = (JObject)JsonConvert.DeserializeObject(data);
                    if (json["saldoClienteResp"]["codResp"].ToString() == "0")
                    {
                        resultado = decimal.Parse(json["saldoClienteResp"]["saldo"].ToString());
                    }
                    else
                    {
                        resultado = -1m;
                    }
                }
                catch 
                {
                    resultado = -1m;
                }


            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                resultado = -1m;
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return -resultado;
        }

        private bool ObtenerSiEsRecarga(string sku)
        {
            bool res = false;

            if(productosRecargas!=null)
                foreach(ProductoMovivendor producto in productosRecargas)
                {
                    if(producto.sku == sku)
                    {
                        res = true;
                        break;
                    }
                }

            return res;
        }

       
    }
}
