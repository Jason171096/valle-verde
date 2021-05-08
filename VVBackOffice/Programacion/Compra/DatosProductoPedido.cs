namespace ValleVerde.Vistas.Compras
{
    public class DatosProductoPedido
    {
        public long? idProdPed, idFac, idPed;
        public string idProd, idClaAdi, descrUni, descrProd, lisImp, motDev;
        public decimal? uniPorCaj, canEsp, canRec, cosEsp, cosRec, canDescu, cosNue, cosAct, cosDif, canDev, descuExt, canImp, cosMin, impo;
        public bool? prodPed;

        public DatosProductoPedido(
            long? idProdPed,
            long? idFac,
            long? idPed,
            string idProd,
            string idClaAdi,
            string descrUni,
            string descrProd,
            string lisImp,
            decimal? uniPorCaj,
            decimal? canEsp,
            decimal? canRec,
            decimal? cosEsp,
            decimal? cosRec,
            decimal? canDescu,
            decimal? canImp,
            decimal? cosNue,
            decimal? cosAct,
            decimal? cosDif,
            decimal? canDev,
            bool? prodPed,
            string motDev,
            decimal? descuExt,
            decimal? cosMin,
            decimal? impo

            //string idFac,
            //string idPed,
            //string idProd,
            //string idClaAdi,
            //string descrUni,
            //string descrProd,
            //string lisImp,
            //string uniPorCaj,
            //string canEsp, 
            //string canRec,
            //string cosEsp,
            //string cosRec,
            //string canDescu,
            //string canImp,
            //string cosNue,
            //string cosAct,
            //string cosDif,
            //string canDev,
            //string prodPed,
            //string motDev,
            //string descuExt,
            //string cosMin
            )
        {
            this.idProdPed = idProdPed;
            this.idFac = idFac;
            this.idPed = idPed;
            this.idProd = idProd;
            this.idClaAdi = idClaAdi;
            this.descrUni = descrUni;
            this.descrProd = descrProd;
            this.lisImp = lisImp;
            this.uniPorCaj = uniPorCaj;
            this.canEsp = canEsp;
            this.canRec = canRec;
            this.cosEsp = cosEsp;
            this.cosRec = cosRec;
            this.canDescu = canDescu;
            this.canImp = canImp;
            this.cosNue = cosNue;
            this.cosAct = cosAct;
            this.cosDif = cosDif;
            this.canDev = canDev;
            this.prodPed = prodPed;
            this.motDev = motDev;
            this.descuExt = descuExt;
            this.cosMin = cosMin;
            this.impo = impo;

            //try { this.idFac = long.Parse(idFac); } catch { this.idFac = -1; };
            //try { this.idPed = long.Parse(idPed); } catch { this.idPed = -1; };
            //this.idProd = idProd;
            //this.idClaAdi = idClaAdi;
            //this.descrUni = descrUni;
            //this.descrProd = descrProd;
            //this.lisImp = lisImp;
            //try { this.uniPorCaj = decimal.Parse(uniPorCaj); } catch { this.uniPorCaj = -1; };
            //try { this.canEsp = decimal.Parse(canEsp); } catch { this.canEsp = -1; };
            //try { this.canRec = decimal.Parse(canRec); } catch { this.canRec = -1; };
            //try { this.cosEsp = decimal.Parse(cosEsp); } catch { this.cosEsp = -1; };
            //try { this.cosRec = decimal.Parse(cosRec); } catch { this.cosRec = -1; };
            //try { this.canDescu = decimal.Parse(canDescu); } catch { this.canDescu = -1; };
            //try { this.canImp = decimal.Parse(canImp); } catch { this.canImp = -1; };
            //try { this.cosNue = decimal.Parse(cosNue); } catch { this.cosNue = -1; };
            //try { this.cosAct = decimal.Parse(cosAct); } catch { this.cosAct = -1; };
            //try { this.cosDif = decimal.Parse(cosDif); } catch { this.cosDif = -1; };
            //try { this.canDev = decimal.Parse(canDev); } catch { this.canDev = -1; };
            //try { this.prodPed = bool.Parse(prodPed); } catch { this.prodPed = false; };
            //this.motDev = motDev;
            //try { this.descuExt = decimal.Parse(descuExt); } catch { this.descuExt = -1; };
            //try { this.cosMin = decimal.Parse(cosMin); } catch { this.cosMin = -1; };
        }
    }
}
