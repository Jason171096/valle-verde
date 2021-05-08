using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class AjustarCostos : Form
    {
        Programacion.Compra.Compras objCom = new Programacion.Compra.Compras();
        QuitarCadenas objQuiCad = new QuitarCadenas();
        List<DatosProductoPedido> prodAjuMan = new List<DatosProductoPedido>();
        List<DatosProductoPedido> prodAjuAut = new List<DatosProductoPedido>();
        List<object[]> prodAju = new List<object[]>();
        List<Producto> lisTodProd = new List<Producto>();
        List<Producto> lisResProd = new List<Producto>();
        object[] datCom;
        object[,] datFac, prodPdf;
        TabControl fac;
        DataGridView prod;
        long idPed, idAlm;
        bool habilitadoCellValueChanged = true, recPed;
        public bool usuarioContinuo = false;
        decimal cosAct, cosNue, canTol, dif;
        byte indIdProdA, indIdClaAdiA, indDescrA, indCosActA, indPreActA, indNueCosA, indNuePreA, indCosMinA, indIdProdPedA, indInd, indIdProd, indIdClaAdi, indUniPorCaj, indCanEsp, indCanRec, indDescrUni, indDescrProd, indCosActEspSinImpu, indCosActEsp, indCosRecSinImpu, indCosRec, indIdProdPed, indDescuPorRen, indLisImp, indNueCos, indIvaPesos, indIepsPesos, indCanDev, indMotDev, indDescuExt, indProdRep, indImpoSinImpu, indImpo, indProdPed, indUti, i = 0;
        Color verde = Color.FromName("LightGreen");
        Color azul = Color.FromName("LightBlue");
        Color amarillo = Color.FromName("Yellow");
        Color rojo = Color.FromName("Salmon");

        public AjustarCostos(long idPed, long idAlm, TabControl fac, DataGridView prod, bool recPed, object[] datCom, object[,] datFac, byte indInd, byte indIdProd, byte indIdClaAdi, byte indUniPorCaj, byte indCanEsp, byte indCanRec, byte indDescrUni, byte indDescrProd, byte indCosActEspSinImpu, byte indCosActEsp, byte indCosRecSinImpu, byte indCosRec, byte indIdProdPed, byte indDescuPorRen, byte indLisImp, byte indNueCos, byte indIvaPesos, byte indIepsPesos, byte indCanDev, byte indMotDev, byte indDescuExt, byte indProdRep, byte indImpoSinImpu, byte indImpo, byte indProdPed, byte indUti)
        {
            InitializeComponent();
            this.fac = fac;
            this.prod = prod;
            this.idPed = idPed;
            this.idAlm = idAlm;
            this.recPed = recPed;

            this.indInd = indInd;
            this.indIdProd = indIdProd;
            this.indIdClaAdi = indIdClaAdi;
            this.indUniPorCaj = indUniPorCaj;
            this.indCanEsp = indCanEsp;
            this.indCanRec = indCanRec;
            this.indDescrUni = indDescrUni;
            this.indDescrProd = indDescrProd;
            this.indCosActEspSinImpu = indCosActEspSinImpu;
            this.indCosActEsp = indCosActEsp;
            this.indCosRecSinImpu = indCosRecSinImpu;
            this.indCosRec = indCosRec;
            this.indIdProdPed = indIdProdPed;
            this.indDescuPorRen = indDescuPorRen;
            this.indLisImp = indLisImp;
            this.indNueCos = indNueCos;
            this.indIvaPesos = indIvaPesos;
            this.indIepsPesos = indIepsPesos;
            this.indCanDev = indCanDev;
            this.indMotDev = indMotDev;
            this.indDescuExt = indDescuExt;
            this.indProdRep = indProdRep;
            this.indImpoSinImpu = indImpoSinImpu;
            this.indImpo = indImpo;
            this.indProdPed = indProdPed;
            this.indUti = indUti;

            this.datCom = datCom;
            this.datFac = datFac;

            indIdProdA = 0;
            indIdClaAdiA = 1;
            indDescrA = 2;
            indCosActA = 3;
            indPreActA = 4;
            indNueCosA = 5;
            indNuePreA = 6;
            indCosMinA = 7;
            indIdProdPedA = 8;

            //indIdProdA = 0;
            //indIdClaAdiA = 1;
            //indDescrA = 2;
            //indCosActA = 3;
            //indNueCosA = 4;
            //indCosMinA = 5;
        }

        private void AjustarCostos_Load(object sender, EventArgs e)
        {
            new ValleVerdeComun.Vistas.DarFormatoBasicoTabla(dgv, false, false, 15, 15);
            dgv.Columns[indNueCosA].ReadOnly = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Columns[indCosMinA].ReadOnly = false;
            dgv.Columns[indCosActA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[indNueCosA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colVer.BackColor = verde;
            colRoj.BackColor = rojo;

            decimal uti, uniPorCaj, descu, subEspProd, impEspProd, totEspProd, subEspFac, impEspFac, totEspFac, canRec, cosRec, cosNue, cosAsiPorUsu, cosMin, canUni, cosFin, canProdRep, cosProdRep;
            string cosRecStr, idProd, idProdRep;
            string[] charsToRemove = new string[] { "$", "," };
            bool prodRep;
            int prodCon;
            int i = 0, j = 0, indRen;
            List<object[]> prodPdfRep = new List<object[]>();

            //Primero guardamos todos los productos del pedido en la lista "lisPre"
            foreach (TabPage factura in fac.TabPages)
            {
                subEspFac = 0;
                impEspFac = 0;
                totEspFac = 0;
                foreach (DataGridViewRow renglon in (factura.Controls[0] as DataGridView).Rows)
                {
                    //try { uniPorCaj = decimal.Parse(renglon.Cells[2].Value.ToString()); } catch(Exception ex) { uniPorCaj = -1; }
                    //try { descu = decimal.Parse(renglon.Cells[indDescu].Tag.ToString()); } catch (Exception ex) { descu = -1; }
                    //try { cosNue = (decimal)renglon.Cells[indNueCos].Value; } catch (Exception ex) { cosNue = -1; }

                    //lisPre.Add(new Producto() { renglon.Cells[0].Value, renglon.Cells[1].Value, renglon.Cells[2].Value, renglon.Cells[3].Value, renglon.Cells[4].Value, renglon.Cells[indCanRec].Value, renglon.Cells[6].Value, renglon.Cells[7].Value, renglon.Cells[indCosEspAct].Value, renglon.Cells[indCosRec].Tag, renglon.Cells[10].Value, renglon.Cells[indDescu].Value, renglon.Cells[indImp].Value, renglon.Cells[indNueCos].Value, renglon.Cells[indCanImp].Value });
                    lisTodProd.Add(new Producto() { IDFactura = (long)(factura.Tag as object[])[0], IDProducto = renglon.Cells[indIdProd].Value.ToString(), IDClaveAdicional = renglon.Cells[indIdClaAdi].Value.ToString(), DescripcionProducto = renglon.Cells[indDescrProd].Value.ToString(), CostoRecibido = (decimal)renglon.Cells[indCosRec].Tag, CantidadRecibida = decimal.Parse(renglon.Cells[indCanRec].Value.ToString()), ListaImpuestos = renglon.Cells[indLisImp].Value.ToString(), IDProductoPedido = long.Parse(renglon.Cells[indIdProdPed].Value.ToString()) });

                    idProd = renglon.Cells[indIdProd].Value.ToString();
                    canRec = decimal.Parse(renglon.Cells[indCanRec].Value.ToString());
                    cosAct = objCom.ObtenerCostoProducto(idProd);

                    cosRec = (decimal)renglon.Cells[indCosRec].Tag;
                    //cosRecStr = renglon.Cells[indCosRec].Value.ToString();
                    //foreach (var c in charsToRemove)
                    //{
                    //    cosRecStr = cosRecStr.Replace(c, string.Empty);
                    //}
                    //cosRec = decimal.Parse(cosRecStr);

                    // Obtenemos cuanto nos está costando realmente cada unidad
                    cosFin = cosRec;

                    if ((renglon.Cells[indUniPorCaj].Value + "").Equals(""))
                        cosMin = objCom.CostoPromedioProductoMasCantidadRecibir(idProd, canRec, cosRec); // , (decimal)renglon.Cells[indCosRec].Tag
                    else
                    {
                        canUni = canRec * decimal.Parse(renglon.Cells[indUniPorCaj].Value + "");
                        cosMin = objCom.CostoPromedioProductoMasCantidadRecibir(idProd, canUni, cosFin);
                    }

                    //Tolerancia del 5%
                    canTol = (cosAct / 100) * 5;
                    dif = cosFin - cosAct;
                    if (dif > 0)
                    {//Llegó más caro
                        if ((renglon.Cells[indNueCos].Value + "").Equals(""))
                            cosAsiPorUsu = cosFin;
                        else
                            cosAsiPorUsu = (decimal)renglon.Cells[indNueCos].Value;
                    }
                    else
                    {//Llegó igual o más barato
                        if ((renglon.Cells[indNueCos].Value + "").Equals(""))
                            cosAsiPorUsu = cosMin;
                        else
                            cosAsiPorUsu = (decimal)renglon.Cells[indNueCos].Value;
                    }

                    if (Math.Abs(dif) > canTol)
                    {
                        //La diferencia de ambos costos sobrepasa la tolerancia, estos precios los ajustará el usuario
                        //prodAjuMan.Add(new DatosProductoPedido("", "", renglon.Cells[0].Value.ToString(), renglon.Cells[1].Value.ToString(), "", renglon.Cells[indDescrProd].Value.ToString(), "", "", "", "", "", renglon.Cells[indCosRec].Value.ToString().Substring(1, renglon.Cells[indCosRec].Value.ToString().Length - 1), "", "", cosPro.ToString(), cosAct.ToString(), "", "", "", "", "", cosMin.ToString()));
                        prodAju.Add(new object[] { true, (factura.Tag as object[])[0], idProd, renglon.Cells[indUniPorCaj].Value, renglon.Cells[indDescrProd].Value, cosRec, cosAct, canRec, renglon.Cells[indIdProd].Value, cosMin, cosAsiPorUsu, renglon.Cells[indUti].Value, renglon.Cells[indIdProdPed].Value });
                    }
                    else
                    {
                        //La diferencia de ambos costos esta dentro la tolerancia, estos precios los ajustará el sistema
                        //prodAjuAut.Add(new DatosProductoPedido("", "", renglon.Cells[0].Value.ToString(), renglon.Cells[1].Value.ToString(), "", renglon.Cells[indDescrProd].Value.ToString(), "", "", "", renglon.Cells[indCanRec].Value.ToString(), "", renglon.Cells[indCosRec].Value.ToString().Substring(1, renglon.Cells[indCosRec].Value.ToString().Length - 1), "", "", cosFin.ToString(), cosAct.ToString(), dif.ToString(), "", "", "", "", ""));
                        prodAju.Add(new object[] { false, (factura.Tag as object[])[0], idProd, renglon.Cells[indUniPorCaj].Value, renglon.Cells[indDescrProd].Value, cosRec, cosAct, canRec, renglon.Cells[indIdProd].Value, cosAsiPorUsu, dif, renglon.Cells[indUti].Value, renglon.Cells[indIdProdPed].Value });
                    }
                    if (recPed)
                    {
                        totEspProd = decimal.Parse(renglon.Cells[indCanEsp].Value.ToString()) * (decimal)renglon.Cells[indCosActEsp].Tag;
                        subEspProd = RestarImpuestosCosto(totEspProd, renglon.Cells[indLisImp].Value.ToString());
                        impEspProd = totEspProd - subEspProd;

                        subEspFac += subEspProd;
                        impEspFac += impEspProd;
                        totEspFac += totEspProd;
                    }
                }

                if (recPed)
                {
                    datFac[i, 2] = subEspFac;
                    datFac[i, 3] = impEspFac;
                    datFac[i, 4] = totEspFac;
                }
                i++;
            }
            //Ordenamos el codigo
            lisTodProd.Sort();

            //Pasamos todos los productos a otra lista, pero ahora de forma comprimida.Es decir, si hay 3 productos repetidos en la primer lista, en la segunda se pasa uno solo, con la suma de las cantidades y un promedio del costo(en base a las cantidades) del producto
            for (i = 0; i < lisTodProd.Count; i++)
            {
                idProdRep = lisTodProd[i].IDProducto;
                canProdRep = 0;
                cosProdRep = 0;
                prodCon = 0;
                for (j = i; j < lisTodProd.Count; j++)
                {
                    if (lisTodProd[j].IDProducto.Equals(idProdRep))
                    {   //Es el mismo producto, sumamos la cantidad y el costo
                        canProdRep += decimal.Parse(lisTodProd[j].IDProducto.ToString());
                        cosProdRep += decimal.Parse(lisTodProd[j].IDProducto.ToString());
                        prodCon++;
                    }
                    else
                    {   //Ya es otro producto, agregamos el producto anterior a la lista resumida
                        if (prodCon > 1)
                        {
                            //Si el producto esta duplicado en la primer lista, sacamos el promedio del costo
                            cosProdRep /= canProdRep;
                            lisTodProd[j - 1].CantidadRecibida = canProdRep;
                            lisTodProd[j - 1].CostoRecibido = cosProdRep;
                        }
                        
                        lisResProd.Add(lisTodProd[j - 1]);

                        i--;
                        break;
                    }
                    j++;
                }
                i++;
            }

            prodPdf = new object[prodAjuMan.Count + prodAjuAut.Count, 12];

            for (i = 0; i < prodAju.Count; i++)
            {
                prodRep = false;
                if ((bool)prodAju[i][0])
                {
                    for (j = 0; j < dgv.Rows.Count; j++)
                    {
                        if (prodAju[i][2].Equals(dgv.Rows[j].Cells[indIdProdA].Value))
                        {
                            prodRep = true;
                            prodPdfRep.Add(prodAju[i]);
                            break;
                        }
                    }
                    if (!prodRep)
                    {
                        //dgv.Rows.Add(new object[] { prodAju[i][2], prodAju[i][3], prodAju[i][4], prodAju[i][6], prodAju[i][10], prodAju[i][9] });
                        habilitadoCellValueChanged = false;
                        dgv.Rows.Add();
                        indRen = dgv.Rows.Count - 1;
                        dgv.Rows[indRen].Cells[indIdProdA].Value = prodAju[i][2];
                        dgv.Rows[indRen].Cells[indIdClaAdiA].Value = prodAju[i][3];
                        dgv.Rows[indRen].Cells[indDescrA].Value = prodAju[i][4];
                        dgv.Rows[indRen].Cells[indCosActA].Value = prodAju[i][6];
                        dgv.Rows[indRen].Cells[indNueCosA].Value = prodAju[i][10];
                        dgv.Rows[indRen].Cells[indCosMinA].Value = prodAju[i][9];
                        dgv.Rows[indRen].Cells[indIdProdPedA].Value = prodAju[i][12];

                        if ((decimal)prodAju[i][11] >= 0)
                        {
                            uti = ((decimal)prodAju[i][11] / 100) + 1;
                            dgv.Rows[indRen].Cells[indPreActA].Value = string.Format("{0:c}", (decimal)prodAju[i][6] * uti);
                            dgv.Rows[indRen].Cells[indNuePreA].Value = string.Format("{0:c}", (decimal)prodAju[i][10] * uti);
                        }
                        
                        dgv.Rows[indRen].Cells[indCosActA].Tag = prodAju[i][6];
                        dgv.Rows[indRen].Cells[indNueCosA].Tag = prodAju[i][10];
                        dgv.Rows[indRen].Cells[indCosMinA].Tag = prodAju[i][9];

                        dgv.Rows[indRen].Cells[indCosActA].Value = string.Format("{0:c}", prodAju[i][6]);
                        dgv.Rows[indRen].Cells[indNueCosA].Value = string.Format("{0:c}", prodAju[i][10]);

                        RevisarProducto(dgv.Rows.Count - 1);
                        habilitadoCellValueChanged = true;
                    }
                }
            }
            prodPdfRep.OrderBy(o => o[2]).ToList();
            for (i = 0; i < prodPdfRep.Count; i++)
            {
                idProdRep = prodPdfRep[i][2].ToString();
                canProdRep = 0;
                cosProdRep = 0;
                for (j = i; j < prodPdfRep.Count; j++)
                {
                    if (prodPdfRep[j][2].Equals(idProdRep))
                    {
                        canProdRep += (decimal)prodPdfRep[j][7];
                        cosProdRep += (decimal)prodPdfRep[j][5];
                    }
                    else
                    {
                        dgv.Rows.Add(new object[] { prodPdfRep[i][2], prodPdfRep[i][3], prodPdfRep[i][4], prodPdfRep[i][6], prodPdfRep[i][10], prodPdfRep[i][9] });
                        dgv.Rows[dgv.Rows.Count - 1].Cells[indCosActA].Tag = prodAju[i][6];
                        dgv.Rows[dgv.Rows.Count - 1].Cells[indNueCosA].Tag = prodAju[i][10];
                        dgv.Rows[dgv.Rows.Count - 1].Cells[indCosMinA].Tag = prodAju[i][9];

                        dgv.Rows[dgv.Rows.Count - 1].Cells[indCosActA].Value = string.Format("{0:c}", prodAju[i][6]);
                        dgv.Rows[dgv.Rows.Count - 1].Cells[indNueCosA].Value = string.Format("{0:c}", prodAju[i][10]);

                        RevisarProducto(dgv.Rows.Count - 1);
                    }
                }
            }






            //foreach (DatosProductoPedido producto in prodAjuMan)
            //{
            //    dgv.Rows.Add(new object[] { producto.idProd, producto.idClaAdi, producto.descrProd, producto.cosAct, producto.cosNue, producto.cosMin });
            //    dgv.Rows[dgv.Rows.Count - 1].Cells[3].Tag = producto.cosAct;
            //    dgv.Rows[dgv.Rows.Count - 1].Cells[4].Tag = producto.cosNue;
            //    dgv.Rows[dgv.Rows.Count - 1].Cells[5].Tag = producto.cosMin;

            //    dgv.Rows[dgv.Rows.Count - 1].Cells[3].Value = string.Format("{0:c}", producto.cosAct);
            //    dgv.Rows[dgv.Rows.Count - 1].Cells[4].Value = string.Format("{0:c}", producto.cosNue);

            //    RevisarProducto(dgv.Rows.Count - 1);

            //    prodPdf[con, 0] = producto.idFac;
            //    prodPdf[con, 1] = con;
            //    prodPdf[con, 2] = producto.idProd;
            //    prodPdf[con, 3] = producto.descrProd;
            //    prodPdf[con, 4] = producto.canRec;
            //    prodPdf[con, 5] = producto.cosAct;
            //    prodPdf[con, 6] = producto.cosNue / (decimal)1.16;
            //    prodPdf[con, 7] = producto.cosNue;
            //    prodPdf[con, 8] = producto.canRec * (decimal)prodPdf[con, 5];
            //    prodPdf[con, 9] = 16;
            //    prodPdf[con, 10] = 8;
            //    prodPdf[con, 11] = producto.canRec * producto.cosNue;

            //    con++;
            //}

            //con = 0;
            //foreach(DatosProductoPedido producto in prodAjuAut)
            //{
            //    prodPdf[con, 0] = producto.idFac;
            //    prodPdf[con, 1] = con + prodAjuMan.Count;
            //    prodPdf[con, 2] = producto.idProd;
            //    prodPdf[con, 3] = producto.descrProd;
            //    prodPdf[con, 4] = producto.canRec;
            //    prodPdf[con, 5] = producto.cosAct;
            //    prodPdf[con, 6] = producto.cosNue / (decimal)1.16;
            //    prodPdf[con, 7] = producto.cosNue;
            //    prodPdf[con, 8] = producto.canRec * (decimal)prodPdf[con, 5];
            //    prodPdf[con, 9] = 16;
            //    prodPdf[con, 10] = 8;
            //    prodPdf[con, 11] = producto.canRec * producto.cosNue;
            //}

            //Ordenamos
            //for (int i = 0; i < prodPdf.GetLength(0); i++)
            //{
            //    for(int j = 0; j < prodPdf.GetLength(1); j++)
            //    {
            //        Console.WriteLine("[ " + i + ", " + j + "]: " + prodPdf[i, j]);
            //    }
            //    Console.WriteLine("\n");
            //}

            if (datFac.GetLength(0) == 1)
                chVerPdfDiv.Checked = false;
            dgv.ClearSelection();
            dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);
            dgv.CellValueChanged += new DataGridViewCellEventHandler(dgv_CellValueChanged);
            FormClosing += new FormClosingEventHandler(CerrandoVentana);
        }

        private decimal RestarImpuestosCosto(decimal cos, string lisImp)
        {
            byte ind;
            // idImp:1,descrProd:IVA,val:16;idImp:4,descrProd:IEPS,val:26.5
            if (lisImp.Contains("IVA"))
            {
                ind = (byte)(lisImp.IndexOf("IVA") + 8);
                cos = cos / ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1);
                //MessageBox.Show(lisImp.Substring(ind, lisImp.IndexOf(';') - ind));
                lisImp = lisImp.Substring(lisImp.IndexOf(';') + 1);
            }

            if (lisImp.Contains("IEPS"))
            {
                ind = (byte)(lisImp.IndexOf("IEPS") + 9);
                while (lisImp.Length > 0)
                {
                    cos = cos / ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1);
                    //MessageBox.Show(lisImp.Substring(ind, lisImp.IndexOf(';') - ind));
                    lisImp = lisImp.Substring(lisImp.IndexOf(';') + 1);
                }
            }

            return cos;
        }

        private void CerrandoVentana(object sender, FormClosingEventArgs e)
        {
            //usuarioContinuo = false;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            dgv.ClearSelection();
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(habilitadoCellValueChanged)
            {
                habilitadoCellValueChanged = false;

                decimal nuevoValor = decimal.Parse(dgv.Rows[e.RowIndex].Cells[indNueCosA].Value.ToString());

                if (nuevoValor < (decimal)dgv.Rows[e.RowIndex].Cells[indCosMinA].Tag)
                    nuevoValor = (decimal)dgv.Rows[e.RowIndex].Cells[indCosMinA].Tag;

                dgv.Rows[e.RowIndex].Cells[indNueCosA].Tag = nuevoValor;
                dgv.Rows[e.RowIndex].Cells[indNueCosA].Value = string.Format("{0:c}", nuevoValor);
                objCom.ActualizarNuevoCosto((long)dgv.Rows[e.RowIndex].Cells[indIdProdPedA].Value, nuevoValor);
                RevisarProducto(e.RowIndex);

                habilitadoCellValueChanged = true;
            }
        }

        private void RevisarProducto(int ren)
        {
            if(dgv.Rows[ren].Cells[indCosActA].Tag == dgv.Rows[ren].Cells[indNueCosA].Tag)
                dgv.Rows[ren].Cells[indNueCosA].Style.BackColor = Color.White;
            else
                if ((decimal)dgv.Rows[ren].Cells[indCosActA].Tag < (decimal)dgv.Rows[ren].Cells[indNueCosA].Tag)
                    dgv.Rows[ren].Cells[indNueCosA].Style.BackColor = rojo;
                else
                    dgv.Rows[ren].Cells[indNueCosA].Style.BackColor = verde;
        }

        private void con_Click(object sender, EventArgs e)
        {
            //Captura los ajustes que hizo el usuario
            prodPdf = new object[prodAju.Count, 13];
            decimal subAjuProd, impAjuProd, totAjuProd,
                subAjuCom = 0, impAjuCom = 0, totAjuCom = 0;
            Impuesto[] imp = new Impuesto[]
            {
                new Impuesto("IVA", 16),
                new Impuesto("IEPS", 26.5)
            };
            byte ind;
            string lisImp, idProd;
            int i = 0, j = 0;

            //Por cada producto que se va a ajustar manualmente
            for (; i < dgv.Rows.Count; i++)
            {
                idProd = dgv.Rows[i].Cells[indIdProdA].Value.ToString();
                while (j < prodAju.Count)
                {
                    if (prodAju[j][2].ToString().Equals(idProd))
                    {
                        break;
                    }
                    j++;
                }
                
                prodPdf[j, 0] = prodAju[j][1]; //idFac
                prodPdf[j, 1] = j; //ind
                prodPdf[j, 2] = prodAju[j][2]; //idProd
                prodPdf[j, 3] = prodAju[j][4]; //descProd
                prodPdf[j, 4] = prodAju[j][7]; //canRec
                prodPdf[j, 5] = prodAju[j][6]; //cosAct
                //Producto ajustado por el usuario
                prodPdf[j, 7] = dgv.Rows[i].Cells[indNueCosA].Tag; //Nuevo costo
                lisImp = prodAju[j][8].ToString();
                if (lisImp.Contains("IVA"))
                {
                    ind = (byte)(lisImp.IndexOf("IVA") + 8);
                    prodPdf[j, 9] = decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)); //IVA
                    prodPdf[j, 6] = (decimal)prodPdf[j, 7] / ((decimal)prodPdf[j, 9] / 100 + 1); //Nuevo precio s/i
                    prodPdf[j, 8] = (decimal)prodAju[j][7] * (decimal)prodPdf[j, 6]; //Importe s/i
                }
                if (lisImp.Contains("IEPS"))
                {
                    ind = (byte)(lisImp.IndexOf("IEPS") + 9);
                    prodPdf[j, 10] = decimal.Parse(lisImp.Substring(ind, lisImp.LastIndexOf(';') - ind)); //IEPS
                    prodPdf[j, 6] = (decimal)prodPdf[j, 6] / (decimal)prodPdf[j, 10] / 100 + 1;
                    prodPdf[j, 8] = (decimal)prodAju[j][7] * (decimal)prodPdf[j, 6]; //Importe s/i
                }
                prodPdf[j, 11] = (decimal)prodAju[j][7] * (decimal)prodAju[j][10]; //Importe
                prodPdf[j, 12] = prodAju[j][8]; 
                totAjuProd = (decimal)prodPdf[j, 11];
                subAjuProd = RestarImpuestosCosto(totAjuProd, prodPdf[j, 12].ToString());
                impAjuProd = totAjuProd - subAjuProd;

                totAjuCom += totAjuProd;
                subAjuCom += subAjuProd;
                impAjuCom += impAjuProd;
            }

            //Por cada producto que se va a ajustar automáticamente
            for (i = 0; i < prodAju.Count; i++)
            {
                if(prodPdf[i, 0] == null)
                {
                    prodPdf[i, 0] = prodAju[i][1]; //idFac
                    prodPdf[i, 1] = i; //ind
                    prodPdf[i, 2] = prodAju[i][2]; //idProd
                    prodPdf[i, 3] = prodAju[i][4]; //descProd
                    prodPdf[i, 4] = prodAju[i][7]; //canRec
                    prodPdf[i, 5] = prodAju[i][6]; //cosAct
                    
                    //Producto ajustado por el sistema
                    prodPdf[i, 7] = prodAju[i][9]; //Nuevo precio
                    lisImp = prodAju[i][8].ToString();
                    if (lisImp.Contains("IVA"))
                    {
                        ind = (byte)(lisImp.IndexOf("IVA") + 8);
                        prodPdf[i, 9] = decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)); //IVA
                        prodPdf[i, 6] = (decimal)prodPdf[i, 7] / ((decimal)prodPdf[i, 9] / 100 + 1); //Nuevo precio s/i
                        prodPdf[i, 8] = (decimal)prodAju[i][7] * (decimal)prodPdf[i, 6]; //Importe s/i
                    }
                    if (lisImp.Contains("IEPS"))
                    {
                        ind = (byte)(lisImp.IndexOf("IEPS") + 9);
                        prodPdf[i, 10] = lisImp.Substring(ind, lisImp.IndexOf(';') - ind); //IEPS
                        prodPdf[i, 6] = (decimal)prodPdf[i, 6] / (decimal)prodPdf[i, 10] / 100 + 1;
                        prodPdf[i, 8] = (decimal)prodAju[i][7] * (decimal)prodPdf[i, 6]; //Importe s/i
                    }
                    prodPdf[i, 11] = (decimal)prodAju[i][7] * (decimal)prodAju[i][9]; //Importe
                    
                    prodPdf[i, 12] = prodAju[i][8];
                    totAjuProd = (decimal)prodPdf[i, 11];
                    subAjuProd = RestarImpuestosCosto(totAjuProd, prodPdf[i, 12].ToString());
                    impAjuProd = totAjuProd - subAjuProd;

                    totAjuCom += totAjuProd;
                    subAjuCom += subAjuProd;
                    impAjuCom += impAjuProd;
                }
            }

            datCom[13] = subAjuCom;
            datCom[14] = impAjuCom;
            datCom[15] = totAjuCom;
            datCom[16] = datCom[10];
            datCom[17] = datCom[11];
            datCom[18] = totAjuCom - (decimal)datCom[10] - (decimal)datCom[11];
            //for (int i = 0; i < prodPdf.GetLength(0); i++)
            //{
            //    if (!(bool)prodPdf[i, 0])
            //    {
            //        if ((decimal)prodPdf[i, 9] < 0)
            //        {
            //            //Llegó más barato, entonces saca un costo promedio en base al inventario
            //            if (prodPdf[i, 2] == null)
            //                canUni = (decimal)prodPdf[i, 6];
            //            else
            //                canUni = (decimal)prodPdf[i, 6] * 2;
            //            cosPro = objCom.CostoPromedioProductoMasCantidadRecibir(prodPdf[i, 1].ToString(), canUni, (decimal)prodPdf[i, 8]);
            //        }
            //        else
            //            //Llegó más caro, el costo será este que acaba de llegar
            //            cosPro = (decimal)prodPdf[i, 8];
            //        objCom.ActualizarCostoProducto(prodPdf[i, 1].ToString(), prodPdf[i, 2].ToString(), cosPro);
            //    }
            //}

            VistaPreviaCompra vpc = new VistaPreviaCompra(datCom, datFac, prodPdf, chVerPdfDiv.Checked);
            vpc.ShowDialog();

            if (vpc.usuCon)
            {
                decimal cosPro, canUni;

                usuarioContinuo = true;

                //for(int i = 0; i < prodPdf.GetLength(0); i++)
                //{
                //    if(!(bool)prodPdf[i, 0])
                //    {
                //        if ((decimal)prodPdf[i, 9] < 0)
                //        {
                //            //Llegó más barato, entonces saca un costo promedio en base al inventario
                //            if(prodPdf[i, 2] == null)
                //                canUni = (decimal)prodPdf[i, 6];
                //            else
                //                canUni = (decimal)prodPdf[i, 6] * 2;
                //            cosPro = objCom.CostoPromedioProductoMasCantidadRecibir(prodPdf[i, 1].ToString(), canUni, (decimal)prodPdf[i, 8]);
                //        }
                //        else
                //            //Llegó más caro, el costo será este que acaba de llegar
                //            cosPro = (decimal)prodPdf[i, 8];
                //        objCom.ActualizarCostoProducto(prodPdf[i, 1].ToString(), prodPdf[i, 2].ToString(), cosPro);
                //    }
                //}
                //foreach (DataGridViewRow producto in dgv.Rows)
                //    objCom.ActualizarCostoProducto(producto.Cells[0].Value.ToString(), producto.Cells[1].Value.ToString(), (decimal)producto.Cells[4].Tag);
                
                //Antes de generar la compra, guardamos en base de datos el nuevo costo que cada producto tendrá, sin embargo, no se guarda en la tabla Producto sino en la tabla Producto_Pedido
                foreach(DataGridViewRow renglon in dgv.Rows)
                {
                    objCom.ActualizarNuevoCosto((long)renglon.Cells[indIdProdPedA].Value, (decimal)renglon.Cells[indNueCosA].Tag);
                }

                for(i = 0; i < prodAju.Count; i++)
                {
                    objCom.ActualizarNuevoCosto((long)prodAju[i][12], (decimal)prodAju[i][10]);
                }

                object[] res = objCom.GenerarCompra(idPed, idAlm);
                datCom[0] = res[0];
                datCom[1] = res[1];

                PDFCompra pdf = new PDFCompra(true, false, datCom, datFac, prodPdf);
                Process.Start(pdf.filename);
                
                Close();
            }
        }
    }

    public class Producto : IEquatable<Producto>, IComparable<Producto>
    {
        public bool AjusteManual { get; set; }
        public long IDFactura { get; set; }
        public string IDProducto { get; set; }
        public string IDClaveAdicional { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal CostoRecibido { get; set; }
        public decimal CostoActual { get; set; }
        public decimal CantidadRecibida { get; set; }
        public string ListaImpuestos { get; set; }
        public decimal CostoMinimo { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal CostoFinal { get; set; }
        public decimal Diferencia { get; set; }
        public long IDProductoPedido { get; set; }

        public override string ToString()
        {
            return "Ajuste manual: " + AjusteManual + "   ID de factura: " + IDFactura + "   ID de Producto: " + IDProducto + "   ID de clave adicional: " + IDClaveAdicional + "   Descripcion: " + DescripcionProducto + "   Costo recibido: " + CostoRecibido + "   Costo actual: " + CostoActual + "   Cantidad recibida: " + CantidadRecibida + "   Lista impuestos: " + ListaImpuestos + "   Costo minimo: " + CostoMinimo + "   Costo promedio: " + CostoPromedio + "   Costo final: " + CostoFinal + "   Diferencia: " + Diferencia;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Producto objAsProducto = obj as Producto;
            if (objAsProducto == null) return false;
            else return Equals(objAsProducto);
        }
        public int SortByNameAscending(string name1, string name2)
        {

            return name1.CompareTo(name2);
        }

        // Default comparer for Producto type.
        public int CompareTo(Producto compareProducto)
        {
            // A null value means that this object is greater.
            if (compareProducto == null)
                return 1;

            else
                return this.IDProducto.CompareTo(compareProducto.IDProducto);
        }
        public override int GetHashCode()
        {
            return int.Parse(IDProducto);
        }
        public bool Equals(Producto other)
        {
            if (other == null) return false;
            return (this.IDProducto.Equals(other.IDProducto));
        }
        // Should also override == and != operators.
    }
}
