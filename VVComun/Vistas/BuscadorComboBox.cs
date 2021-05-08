using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerdeComun.Vistas
{
    public class BuscadorComboBox
    {
        ListBox resultados = new ListBox();
        ComboBox combo;
        bool fueElUsuario = true;

        public BuscadorComboBox(Form parent, ComboBox combo)
        {
            this.combo = combo;
            this.combo.DropDownStyle = ComboBoxStyle.DropDown;
            this.combo.DropDownWidth = 550;
            this.combo.TextChanged += new EventHandler(CambioTextoCombo);
            this.combo.KeyDown += new KeyEventHandler(Evento_Teclas);

            resultados.Visible = false;

            parent.Controls.Add(resultados);
        }
        private void CambioTextoCombo(object sender, EventArgs e)
        {

            combo = (sender as ComboBox);

            combo.LostFocus += new EventHandler(PerdioFocoCombo);

            resultados.Width = combo.DropDownWidth;
            resultados.IntegralHeight = true;
            //resultados.MinimumSize = new System.Drawing.Size(0, 500);
            resultados.Font = combo.Font;
            resultados.SelectedIndexChanged -= new EventHandler(SeleccionoResultado);

            System.Drawing.Point locationOnForm = combo.FindForm().PointToClient(combo.Parent.PointToScreen(combo.Location));
            resultados.Location = new System.Drawing.Point(locationOnForm.X, locationOnForm.Y + combo.Height);


            resultados.Visible = false; // hide the listbox, see below for why doing that

            // get the keyword to search
            string textToSearch = combo.Text.ToLower();
            string ss = combo.GetItemText(combo.SelectedItem).ToString().ToLower();
            if (textToSearch != ss)
            {
               
                if (String.IsNullOrEmpty(textToSearch))
                    return; // return with listbox hidden if the keyword is empty
                            //search
                            //string[] result = (from i in combo.Items
                            //                   where i..ToLower().Contains(textToSearch)
                            //                   select i).ToArray();

                string[] result = new string[] { };

                resultados.DataSource = null;

                resultados.DisplayMember = "Text";
                resultados.ValueMember = "Value";

                List<Object> items = new List<Object>();

                for (int i = 0; i < combo.Items.Count; i++)
                {
                    string s = combo.GetItemText(combo.Items[i]);
                    if (s.ToLower().Contains(textToSearch))
                    {
                        //string[] r = new string[result.Length + 1];
                        //result.CopyTo(r, 0);
                        //result = r;
                        //result[result.Length - 1] = s;

                        items.Add(new { Text = combo.GetItemText(combo.Items[i]), Value = i });
                    }
                }

                if (items.Count == 0)
                    return; // return with listbox hidden if nothing found

                resultados.DataSource = items;
                //resultados.Items.AddRange(result);
                resultados.Visible = true; // show the listbox again
                resultados.BringToFront();
                if (resultados.PreferredHeight < 500)
                    resultados.Height = resultados.PreferredHeight;
                else
                    resultados.Height = 500;
                resultados.SelectedIndexChanged += new EventHandler(SeleccionoResultado);
            }


        }
        private void SeleccionoResultado(object sender, EventArgs e)
        {
            if (combo != null && resultados.SelectedValue != null && fueElUsuario == true)
            {
                combo.Text = "";
                combo.SelectedIndex = int.Parse(resultados.SelectedValue.ToString());
                resultados.Visible = false;
            }
            else
            {
                fueElUsuario = true;
            }
        }

        private void PerdioFocoCombo(object sender, EventArgs e)
        {
            if (!resultados.Focused)
                resultados.Visible = false;
        }

        private void Evento_Teclas(object sender, KeyEventArgs e)
        {
            if (resultados.Visible == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        if (resultados.Items.Count > 0)
                        {
                            if (resultados.SelectedIndex + 1 < resultados.Items.Count)
                            {
                                fueElUsuario = false;
                                resultados.SelectedIndex = resultados.SelectedIndex + 1;
                            }
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;

                    case Keys.Up:
                        if (resultados.Items.Count > 0)
                        {
                            if (resultados.SelectedIndex - 1 >= 0)
                            {
                                fueElUsuario = false;
                                resultados.SelectedIndex = resultados.SelectedIndex - 1;
                            }
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Enter:
                        if (resultados.Items.Count > 0)
                        {
                            
                            int x = resultados.SelectedIndex;
                            if (x != 0)
                            {
                                fueElUsuario = false;
                                resultados.SelectedIndex = 0;
                                fueElUsuario = true;
                                resultados.SelectedIndex = x;
                            }
                            else
                            {
                                SeleccionoResultado(null, null);
                            }

                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Escape:
                        resultados.Visible = false;
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                }
            }
        }
    }
}
