using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Vistas.Inventario
{
    public class Precios
    {
        TextBox txtCosto;
        TableLayoutPanel panelDePrecios;
        bool paraVerificador;
        int altura = 156, ancho1 = 170, ancho2 = 70, tabIndex = 0;
        bool cambiandoUtilidad, cambiandoPrecio;

        public void ConfigurarPanelPrecios(ref TableLayoutPanel panelDePrecios,ref TextBox txtCosto, ref Array[] arrayTextBoxPrecios, bool paraVerificador)
        {
            this.panelDePrecios = panelDePrecios;
            this.txtCosto = txtCosto;
            this.tabIndex = this.txtCosto.TabIndex+1;
            this.paraVerificador = paraVerificador;
            this.altura = panelDePrecios.Size.Height;

            //// TableLayoutPanel Initialization
            this.panelDePrecios.ColumnCount = 3;
            this.panelDePrecios.RowCount = 0;
            this.panelDePrecios.RowStyles.Clear();
            //this.panelDePrecios.Size = new System.Drawing.Size(this.panelDePrecios.Size.Width, 206);
            
            //Generando los 3 precios por defecto
            AgregarRenglonPrecios(ref arrayTextBoxPrecios, true, paraVerificador);
            AgregarRenglonPrecios(ref arrayTextBoxPrecios, false, paraVerificador);
            AgregarRenglonPrecios(ref arrayTextBoxPrecios, false, paraVerificador);
        }

        public void AgregarRenglonPrecios(ref Array[] arrayTextBoxPrecios, bool EsElPrimero, bool paraVerificador)
        {

            Label l1 = new Label();
            float tamFuente = 14f;
            float tamLabel = 14f;
            float tamRenglon = 40f;
            if (paraVerificador)
            {
                tamFuente = 27f;
                tamLabel = 24f;
                tamRenglon = 61f;
            }
            l1.Font = new Font("Microsoft Sans Serif", tamLabel, FontStyle.Bold);
            l1.AutoSize = true;
            if (paraVerificador)
                l1.Text = "Cant.:";
            else
                l1.Text = "Precio " + (panelDePrecios.RowCount + 1) + ":";
           

            Label l2 = new Label();
            l2.Font = new Font("Microsoft Sans Serif", tamLabel, FontStyle.Bold);
            l2.AutoSize = true;
            if (paraVerificador)
                l2.Text = "Precio:";
            else 
                l2.Text = "Utilidad:";

            Label l3 = null;
            if (!EsElPrimero)
            {
                l3 = new Label();
                l3.AutoSize = true;
                l3.Font = new Font("Microsoft Sans Serif", tamLabel, FontStyle.Bold);
                if (paraVerificador)
                    l3.Text = "Total:";
                else
                    l3.Text = "Cantidad:";
            } else
            {
                if (paraVerificador)
                {
                    l3 = new Label();
                    l3.AutoSize = true;
                    l3.Font = new Font("Microsoft Sans Serif", tamLabel, FontStyle.Bold);
                    l3.Text = "Total:";
                }

            }

            TextBox tb1 = new TextBox();
            tb1.Font = new Font("Microsoft Sans Serif", tamFuente);
            if (paraVerificador)
            {
                tb1.Width = ancho2;
                tb1.Enabled = true;
                tb1.ReadOnly = true;
                tb1.BackColor = SystemColors.GradientActiveCaption;
            }
            else
            {
                tb1.Width = ancho1;
                tb1.Enabled = false;
            }
            tb1.TextAlign = HorizontalAlignment.Right;
            
            //if (paraVerificador)
            //{
            //    tb1.BackColor = Color.FromKnownColor(KnownColor.Control);
            //    tb1.BorderStyle = BorderStyle.None;
            //}

            TextBox tb2 = new TextBox();
            tb2.Font = new Font("Microsoft Sans Serif", tamFuente);
            if (paraVerificador)
            {
                tb2.Width = ancho1;
                tb2.Enabled = true;
                tb2.ReadOnly = true;
                tb2.BackColor = SystemColors.GradientActiveCaption;
            }
            else
            {
                tb2.Width = ancho2;
                tb2.Enabled = false;
            }
            tb2.TextAlign = HorizontalAlignment.Right;
            if(!paraVerificador)
            {
                tb1.TextChanged += (sender2, e2) => txtPrecio_TextChanged(txtCosto, sender2, e2, tb2, panelDePrecios);
                tb1.Click += new EventHandler(ClicEnCantidad);
                tb1.LostFocus += new EventHandler(FormatoPrecio);
                tb1.TabIndex = tabIndex+500;
                tb1.TabStop = false;
                tb2.TextChanged += (sender2, e2) => txtUtilidad_TextChanged(txtCosto, sender2, e2, tb1, panelDePrecios);
                tb2.Click += new EventHandler(ClicEnCantidad);
                tb2.KeyDown += new KeyEventHandler(this.TabSiguienteControl);
                tb2.TabIndex = tabIndex++;
                tb2.TabStop = true;
            }
               


            TextBox tb3 = null;
            if (!EsElPrimero)
            {
                tb3 = new TextBox();
                tb3.Font = new Font("Microsoft Sans Serif", tamFuente);
                if (paraVerificador)
                {
                    tb3.Width = ancho1;
                    tb3.Enabled = true;
                    tb3.ReadOnly = true;
                    tb3.BackColor = SystemColors.GradientActiveCaption;
                }
                else
                {
                    tb3.Width = ancho2;
                    tb3.Enabled = false;
                }
                tb3.TextAlign = HorizontalAlignment.Right;
                if (!paraVerificador)
                {
                    tb3.TextChanged += (sender2, e2) => txtCantidad_TextChanged(tb3);
                    tb3.Click += new EventHandler(ClicEnCantidad);
                    tb3.KeyDown += new KeyEventHandler(this.TabSiguienteControl);
                    tb3.TabIndex = tabIndex++;
                    tb3.TabStop = true;
                }
               
            }
            else
            {
                if (paraVerificador)
                {
                    tb3 = new TextBox();
                    tb3.Font = new Font("Microsoft Sans Serif", tamFuente);
                    tb3.Width = ancho1;
                    tb3.TextAlign = HorizontalAlignment.Right;
                    tb3.Enabled = true;
                    tb3.ReadOnly = true;
                    tb3.BackColor = SystemColors.GradientActiveCaption;
                }
            }

            FlowLayoutPanel p1 = new FlowLayoutPanel();
            p1.Dock = DockStyle.Fill;
            p1.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            p1.Controls.Add(l1);
            p1.Controls.Add(tb1);

            FlowLayoutPanel p2 = new FlowLayoutPanel();
            p2.Dock = DockStyle.Fill;
            p2.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            p2.Controls.Add(l2);
            p2.Controls.Add(tb2);

            FlowLayoutPanel p3 = null;
            if (!EsElPrimero)
            {
                p3 = new FlowLayoutPanel();
                p3.Dock = DockStyle.Fill;
                p3.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
                p3.Controls.Add(l3);
                p3.Controls.Add(tb3);
            } else
            {
                if (paraVerificador)
                {
                    p3 = new FlowLayoutPanel();
                    p3.Dock = DockStyle.Fill;
                    p3.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
                    p3.Controls.Add(l3);
                    p3.Controls.Add(tb3);
                }
            }

            if (arrayTextBoxPrecios == null)
                arrayTextBoxPrecios = new Array[1];
            else
                Array.Resize(ref arrayTextBoxPrecios, arrayTextBoxPrecios.Length + 1);

            TextBox[] t = new TextBox[3];
            t[0] = tb1;
            t[1] = tb2;
            if (!EsElPrimero)
            {
                t[2] = tb3;
            } else
            {
                if (paraVerificador)
                {
                    t[2] = tb3;
                }
            }
            arrayTextBoxPrecios[arrayTextBoxPrecios.Length - 1] = t;

            panelDePrecios.RowCount = panelDePrecios.RowCount + 1;
            panelDePrecios.RowStyles.Add(new RowStyle(SizeType.Absolute, tamRenglon));
            //panelDePrecios.Size = new System.Drawing.Size(panelDePrecios.Size.Width, altura);
            
            panelDePrecios.Controls.Add(p1, 0, panelDePrecios.RowCount - 1);
            panelDePrecios.Controls.Add(p2, 1, panelDePrecios.RowCount - 1);
            if (!EsElPrimero)
            {
                panelDePrecios.Controls.Add(p3, 2, panelDePrecios.RowCount - 1);
            }
            else
            {
                if(paraVerificador)
                    panelDePrecios.Controls.Add(p3, 2, panelDePrecios.RowCount - 1);
            }

        }

        private void ClicEnCantidad(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void FormatoPrecio(object sender, EventArgs e)
        {
            try
            {
                decimal precio = Convert.ToDecimal(((TextBox)sender).Text);
                ((TextBox)sender).Text = string.Format("{0:C}", precio);
            }
            catch { }
           
        }

        private void TabSiguienteControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        protected void txtPrecio_TextChanged(TextBox txtCosto, object precio, EventArgs e, object utilidad, TableLayoutPanel panelPrecios)
        {
            if (!cambiandoUtilidad)
            {
                cambiandoPrecio = true;
                // Your code here
                try
                {
                    decimal pre = Convert.ToDecimal(((TextBox)precio).Text);
                    decimal cost = Convert.ToDecimal(txtCosto.Text);
                    decimal ut = pre * 100 / cost - 100;

                    //if (ut >= 0)
                        ((TextBox)utilidad).Text = ut + "";



                }
                catch
                {
                    string uti = ((TextBox)utilidad).Text;
                    ((TextBox)utilidad).Text = "0";
                    ((TextBox)utilidad).Text = uti;
                }
                cambiandoPrecio = false;
            }


        }

        protected void txtUtilidad_TextChanged(TextBox txtCosto, object utilidad, EventArgs e, object precio, TableLayoutPanel panelPrecios)
        {
            
            if (!cambiandoPrecio)
            {
                cambiandoUtilidad = true;
                // Your code here
                try
                {
                    decimal ut = Convert.ToDecimal(((TextBox)utilidad).Text);
                    decimal cost = Convert.ToDecimal(txtCosto.Text);
                    ((TextBox)precio).Text = string.Format("{0:C}", 0.01m * Math.Round(100 * ((ut / 100 + 1) * cost)));
                    ((TextBox)precio).Tag = 0.01m * Math.Round(100 * ((ut / 100 + 1) * cost));

                    //Encontrar en que renglon de precios estoy
                    int renglonActual = -1;

                    for (int x = 0; x < panelPrecios.RowCount; x++)
                    {
                        FlowLayoutPanel panel = panelPrecios.GetControlFromPosition(1, x) as FlowLayoutPanel;
                        TextBox txtUtilidadActual = (panel.Controls[1] as TextBox);
                        if (txtUtilidadActual == ((TextBox)utilidad))
                        {
                            renglonActual = x;
                            break;
                        }
                    }

                    //Habilitar siguiente renglon, solo si la cantidad tambien fue llenada
                    bool puedeHabilitarSiguiente = false;

                    if (renglonActual == 0)
                        puedeHabilitarSiguiente = true;
                    else
                    {
                        FlowLayoutPanel panel = panelPrecios.GetControlFromPosition(2, renglonActual) as FlowLayoutPanel;
                        TextBox txtCantidadActual = (panel.Controls[1] as TextBox);
                        if (txtCantidadActual.Text != "")
                            puedeHabilitarSiguiente = true;
                        else
                            puedeHabilitarSiguiente = false;
                    }

                    if (renglonActual < panelPrecios.RowCount && puedeHabilitarSiguiente)
                    {
                        FlowLayoutPanel panel = panelPrecios.GetControlFromPosition(1, renglonActual + 1) as FlowLayoutPanel;
                        TextBox txtUtilidadSiguiente = (panel.Controls[1] as TextBox);

                        panel = panelPrecios.GetControlFromPosition(2, renglonActual + 1) as FlowLayoutPanel;
                        TextBox txtCantidadSiguiente = (panel.Controls[1] as TextBox);

                        panel = panelPrecios.GetControlFromPosition(0, renglonActual + 1) as FlowLayoutPanel;
                        TextBox txtPrecioSiguiente = (panel.Controls[1] as TextBox);

                        txtPrecioSiguiente.Enabled = true;
                        txtUtilidadSiguiente.Enabled = true;
                        txtCantidadSiguiente.Enabled = true;
                    }
                }
                catch
                {
                }

                cambiandoUtilidad = false;
            }
        }

        protected void txtCantidad_TextChanged(TextBox cantidad)
        {

            //Encontrar en que renglon de precios estoy
            int renglonActual = -1;

            for (int x = 1; x < panelDePrecios.RowCount; x++)
            {
                FlowLayoutPanel panel2 = panelDePrecios.GetControlFromPosition(2, x) as FlowLayoutPanel;
                TextBox txtCantidadActual = (panel2.Controls[1] as TextBox);
                if (txtCantidadActual == cantidad)
                {
                    renglonActual = x;
                    break;
                }
            }

            //Habilitar siguiente renglon, solo si la utilidad tambien fue llenada
            bool puedeHabilitarSiguiente = false;


            FlowLayoutPanel panel = panelDePrecios.GetControlFromPosition(1, renglonActual) as FlowLayoutPanel;
            TextBox txtUtilidadActual = (panel.Controls[1] as TextBox);
            if (txtUtilidadActual.Text != "")
                puedeHabilitarSiguiente = true;
            else
                puedeHabilitarSiguiente = false;


            if (renglonActual < panelDePrecios.RowCount - 1 && puedeHabilitarSiguiente)
            {
                panel = panelDePrecios.GetControlFromPosition(1, renglonActual + 1) as FlowLayoutPanel;
                TextBox txtUtilidadSiguiente = (panel.Controls[1] as TextBox);

                panel = panelDePrecios.GetControlFromPosition(2, renglonActual + 1) as FlowLayoutPanel;
                TextBox txtCantidadSiguiente = (panel.Controls[1] as TextBox);

                panel = panelDePrecios.GetControlFromPosition(0, renglonActual + 1) as FlowLayoutPanel;
                TextBox txtPrecioSiguiente = (panel.Controls[1] as TextBox);

                txtPrecioSiguiente.Enabled = true;
                txtUtilidadSiguiente.Enabled = true;
                txtCantidadSiguiente.Enabled = true;
            }

        }


        public void RegistrarPrecios(Programacion.Producto ob, string codBarras, string idHistorialCosto)
        {
            if (txtCosto.Text != "")
            {
                for (int r = 0; r < panelDePrecios.RowCount; r++)
                {
                    FlowLayoutPanel panel = panelDePrecios.GetControlFromPosition(0, r) as FlowLayoutPanel;
                    string precio = (panel.Controls[1] as TextBox).Text;

                    panel = panelDePrecios.GetControlFromPosition(1, r) as FlowLayoutPanel;
                    string utilidad = (panel.Controls[1] as TextBox).Text;



                    panel = panelDePrecios.GetControlFromPosition(2, r) as FlowLayoutPanel;
                    string cantidad;
                    if (r == 0)
                    {
                        try
                        {
                            FlowLayoutPanel panel2 = panelDePrecios.GetControlFromPosition(2, 1) as FlowLayoutPanel;
                            if ((panel2.Controls[1] as TextBox).Text == "1")
                                cantidad = "0";
                            else
                                cantidad = "1";
                        }
                        catch { cantidad = "1"; }
                    }
                    else
                    {
                        cantidad = (panel.Controls[1] as TextBox).Text;
                    }

                    if (precio != "" && utilidad != "" && cantidad != "")
                    {
                        // MessageBox.Show("Precio: " + precio + " Utilidad: " + utilidad + " Cantidad: " + cantidad);
                        idHistorialCosto = ob.AgregarPrecioProducto(codBarras, utilidad, cantidad, idHistorialCosto)+"";
                        if (int.Parse(idHistorialCosto) < 0)
                        {
                            MessageBox.Show("Ocurrio un error en precios: " + idHistorialCosto);
                            break;
                        }
                    }
                }
            }
        }

        public void CargarPreciosCosto(string codigoRecibido, ref Array[] arrayTextBoxPrecios)
        {
            Programacion.Precios ob = new Programacion.Precios();

            int cant = ob.ObtenerCantidadPreciosProducto(codigoRecibido);

            //Cargar el costo
            if (txtCosto != null)
                txtCosto.Text = ob.ObtenerCostoProducto(codigoRecibido) + "";

            // MessageBox.Show("El producto tiene " + cant + " precios");
            if (cant > 0)
            {
               

                //Cargar cada uno de los precios, pero primero verificar si necesitamos mas renglones

                if (cant > panelDePrecios.RowCount)
                {
                    //Necesito agregar los renglones necesarios
                    int r = cant - panelDePrecios.RowCount;
                    while (r > 0)
                    {
                        AgregarRenglonPrecios(ref arrayTextBoxPrecios, false,paraVerificador);
                        r--;
                    }
                }

                //cargar las utilidades y cantidades en los renglones
                List<decimal[]> preciosProducto;
               preciosProducto= ob.ObtenerPreciosCostoProducto(codigoRecibido);
                
               

                for (int r = 0; r < panelDePrecios.RowCount; r++)
                {
                    if (r == cant)
                        break;
                    FlowLayoutPanel panel = panelDePrecios.GetControlFromPosition(0, r) as FlowLayoutPanel;


                    panel = panelDePrecios.GetControlFromPosition(1, r) as FlowLayoutPanel;
                    //Utilidad
                    (panel.Controls[1] as TextBox).Text = preciosProducto[r][0] + "";

                    panel = panelDePrecios.GetControlFromPosition(2, r) as FlowLayoutPanel;

                    //cantidad;
                    if (r != 0)
                    {
                        (panel.Controls[1] as TextBox).Text = preciosProducto[r][1] + "";
                    }


                }
            }
        }

        public void CargarPreciosPublico(string codigoRecibido, ref Array[] arrayTextBoxPrecios)
        {
            Programacion.Precios ob = new Programacion.Precios();

            int cant = ob.ObtenerCantidadPreciosProducto(codigoRecibido);

            if (cant > 0)
            {
                //Cargar cada uno de los precios, pero primero verificar si necesitamos mas renglones

                if (cant > panelDePrecios.RowCount)
                {
                    //Necesito agregar los renglones necesarios
                    int r = cant - panelDePrecios.RowCount;
                    while (r > 0)
                    {
                        AgregarRenglonPrecios(ref arrayTextBoxPrecios, false, paraVerificador);
                        r--;
                    }
                }

                //Cargar los precios uno por uno
                List<decimal[]> preciosProducto;
                preciosProducto = ob.ObtenerPreciosCostoProducto(codigoRecibido);
                


                for (int r = 0; r < panelDePrecios.RowCount; r++)
                {
                    if (r == cant)
                        break;
                    FlowLayoutPanel panel = panelDePrecios.GetControlFromPosition(0, r) as FlowLayoutPanel;

                    panel = panelDePrecios.GetControlFromPosition(0, r) as FlowLayoutPanel;
                    //Cantidad
                    (panel.Controls[1] as TextBox).Text = preciosProducto[r][1] + "";


                    panel = panelDePrecios.GetControlFromPosition(1, r) as FlowLayoutPanel;
                    //Precio
                    decimal precio = ob.ObtenerPrecioProducto(codigoRecibido, int.Parse(preciosProducto[r][1] + " "),-1,-1,false);
                    (panel.Controls[1] as TextBox).Text = string.Format("{0:C}", (precio));

                    //Total
                    panel = panelDePrecios.GetControlFromPosition(2, r) as FlowLayoutPanel;
                    (panel.Controls[1] as TextBox).Text = string.Format("{0:C}", precio * preciosProducto[r][1]);
                    


                }
            }
        }
   
        public int VerificarPrecios()
        {

            if (txtCosto.Text != "")
            {
                try
                {
                    decimal.Parse(txtCosto.Text);
                }
                catch
                {
                    return -1;
                }
                //Las utilidades deben de ser positivas y consecutivas de mayor a menor
                //mientras que las cantidades deben der positivas y consecutivas de menor a mayor

                //Verificando utilidades
                decimal utilidadAnterior = 0;
                decimal cantidadAnterior = 0;

                for (int r = 0; r < panelDePrecios.RowCount; r++)
                {
                    decimal utilidad = 0;
                    decimal cantidad = 0;

                    FlowLayoutPanel panel = panelDePrecios.GetControlFromPosition(1, r) as FlowLayoutPanel;
                    string ut = (panel.Controls[1] as TextBox).Text;

                    FlowLayoutPanel panel2 = panelDePrecios.GetControlFromPosition(2, r) as FlowLayoutPanel;
                    string cant = "";
                    
                    if(r > 0)
                        cant = (panel2.Controls[1] as TextBox).Text;

                    //Si no hay utilidad ni cantidad entonces todo esta bien, solo no tiene precio en este renglon

                    if ((ut != "" && cant != "") || (ut != "" && r == 0))
                    {


                        try
                        {
                            utilidad = decimal.Parse((panel.Controls[1] as TextBox).Text);

                        }
                        catch
                        {
                            (panel.Controls[1] as TextBox).Focus();
                            (panel.Controls[1] as TextBox).SelectAll();
                            return -2;
                        }

                        try
                        {
                            cantidad = decimal.Parse(cant);
                        }
                        catch
                        {
                            if (r > 0)
                            {
                                (panel2.Controls[1] as TextBox).Focus();
                                (panel2.Controls[1] as TextBox).SelectAll();
                                return -3;
                            }
                        }


                        if (utilidad < 0)
                        {
                            (panel.Controls[1] as TextBox).Focus();
                            (panel.Controls[1] as TextBox).SelectAll();
                            return -2;
                        }

                        if (r == 0)
                            utilidadAnterior = utilidad;

                        if (utilidadAnterior >= utilidad)
                            utilidadAnterior = utilidad;
                        else
                        {
                            (panel.Controls[1] as TextBox).Focus();
                            (panel.Controls[1] as TextBox).SelectAll();
                            return -2;
                        }

                        panel = panelDePrecios.GetControlFromPosition(2, r) as FlowLayoutPanel;


                        if (r > 0)
                        {
                            cantidadAnterior = cantidad;

                            if (cantidadAnterior <= cantidad)
                                cantidadAnterior = cantidad;
                            else
                            {
                                (panel2.Controls[1] as TextBox).Focus();
                                (panel2.Controls[1] as TextBox).SelectAll();
                                return -3;
                            }

                            if (cantidad < 0)
                            {
                                (panel2.Controls[1] as TextBox).Focus();
                                (panel2.Controls[1] as TextBox).SelectAll();
                                return -3;
                            }
                        }

                    }
                    else
                    {
                        //Solo falto si no es el renglon 0 o si tiene utilidad pero no cantidad o viceversa
                        if (r > 0)
                        {
                            if ((ut != "" && cant == "") || (ut == "" && cant != ""))
                            {
                                //Falto utilidad o costo en este reglon, hacer la prueba para arrojar error correcto
                                try
                                {
                                    utilidad = decimal.Parse(ut);

                                }
                                catch
                                {
                                    (panel.Controls[1] as TextBox).Focus();
                                    (panel.Controls[1] as TextBox).SelectAll();
                                    return -2;
                                }

                                try
                                {
                                    cantidad = decimal.Parse(cant);
                                }
                                catch
                                {
                                    (panel2.Controls[1] as TextBox).Focus();
                                    (panel2.Controls[1] as TextBox).SelectAll();
                                    return -3;
                                }
                            }
                        }
                    }  
                   
                }
               
            }
            else
            {
                //El costo solo esta bien vacio si no tiene precios

                //Verificando utilidades y cantidades

                for (int r = 1; r < panelDePrecios.RowCount; r++)
                {
                    FlowLayoutPanel panel = panelDePrecios.GetControlFromPosition(2, r) as FlowLayoutPanel;

                    if ((panel.Controls[1] as TextBox).Text != "")
                        return -1;

                    panel = panelDePrecios.GetControlFromPosition(1, r) as FlowLayoutPanel;
                    if ((panel.Controls[1] as TextBox).Text != "")
                        return -1;
                }
            }
            return 1;
        }
    }
}
