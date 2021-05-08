namespace ValleVerde.Vistas.Compras
{
    class Costo
    {
        bool cosIncImp;

        public Costo(bool cosIncImp)
        {
            this.cosIncImp = cosIncImp;
        }

        public decimal ObtenerCosto(decimal cos, string lisImp)
        {
            if (cosIncImp)
                return cos;
            else
                return RestarImpuestosCosto(cos, lisImp);
        }

        public decimal RestarImpuestosCosto(decimal cos, string lisImp)
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

        public decimal SumarImpuestosCosto(decimal cos, string lisImp)
        {
            byte ind;
            // idImp:1,descrProd:IVA,val:16;idImp:4,descrProd:IEPS,val:26.5
            if (lisImp.Contains("IVA"))
            {
                ind = (byte)(lisImp.IndexOf("IVA") + 8);
                cos = cos * ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1);
                //MessageBox.Show(lisImp.Substring(ind, lisImp.IndexOf(';') - ind));
                lisImp = lisImp.Substring(lisImp.IndexOf(';') + 1);
            }

            if (lisImp.Contains("IEPS"))
            {
                ind = (byte)(lisImp.IndexOf("IEPS") + 9);
                while (lisImp.Length > 0)
                {
                    cos = cos * ((decimal.Parse(lisImp.Substring(ind, lisImp.IndexOf(';') - ind)) / 100) + 1);
                    //MessageBox.Show(lisImp.Substring(ind, lisImp.IndexOf(';') - ind));
                    lisImp = lisImp.Substring(lisImp.IndexOf(';') + 1);
                }
            }

            return cos;
        }
    }
}
