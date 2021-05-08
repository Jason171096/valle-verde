using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using ValleVerdeComun.Programacion.Movivendor;

namespace ValleVerdeComun.Programacion
{
    public delegate void DelegateObtenerResultadosCargarObjetoMovivendor(Movivendor.MovivendorMetodos obMovivendor);

    interface IPrincipal
    {
        DelegateObtenerResultadosCargarObjetoMovivendor ObtenerResultadosCargarMovivendor
        {
            get;
            set;
        }

        ConfiguracionPV configuracionPV
        {
            get;
            set;
        }

        ConfiguracionBO configuracionBO
        {
            get;
            set;
        }

        DatosConfiguracionGlobal configuracionGlobal
        {
            get;
            set;
        }

        PrintDocument impresoraTickets
        {
            get;
            set;
        }

        GenerarTicket generarTicket
        {
            get;
            set;
        }

        MovivendorMetodos obMovivendor
        {
            get;
            set;
        }

        void HabilitarEscaner();
        void BloquearCaja();
        int BloquearCaja(Form parent,string mensajeMotivoBloqueo, bool requiereAutorizacionParaDesbloquear, string mensajeBotonAutorizacion, bool desbloquearEscaner);
        void GenerarTicketDevolucion(string folio, decimal total, int noArticulos, DataGridView dgvProductosDevolver, Cliente cliente);
    }
    public class InterfazPrincipal : Form, IPrincipal
    {

        private DelegateObtenerResultadosCargarObjetoMovivendor _ObtenerResultadosCargarMovivendor;
          
        public DelegateObtenerResultadosCargarObjetoMovivendor ObtenerResultadosCargarMovivendor
        {
            get { return this._ObtenerResultadosCargarMovivendor; }
            set { this._ObtenerResultadosCargarMovivendor = value; }
        }

        private ConfiguracionPV _configuracionPV;
        public ConfiguracionPV configuracionPV
        {
            get { return this._configuracionPV; }
            set { this._configuracionPV = value; }
        }

        private ConfiguracionBO _configuracionBO;
        public ConfiguracionBO configuracionBO
        {
            get { return this._configuracionBO; }
            set { this._configuracionBO = value; }
        }

        private DatosConfiguracionGlobal _configuracionGlobal;
        public DatosConfiguracionGlobal configuracionGlobal
        {
            get { return this._configuracionGlobal; }
            set { this._configuracionGlobal = value; }
        }

        private PrintDocument _impresoraTickets;
        public PrintDocument impresoraTickets
        {
            get { return this._impresoraTickets; }
            set { this._impresoraTickets = value; }
        }
        
        private GenerarTicket _generarTicket;
        public GenerarTicket generarTicket
        {
            get { return this._generarTicket; }
            set { this._generarTicket = value; }
        }

        private MovivendorMetodos _obMovivendor;
        public MovivendorMetodos obMovivendor
        {
            get { return this._obMovivendor; }
            set { this._obMovivendor = value; }
        }


        public virtual void BloquearCaja()
        {
            throw new NotImplementedException();
        }

        public virtual int BloquearCaja(Form parent, string mensajeMotivoBloqueo, bool requiereAutorizacionParaDesbloquear, string mensajeBotonAutorizacion, bool desbloquearEscaner)
        {
            throw new NotImplementedException();
        }

        public virtual void HabilitarEscaner()
        {
            throw new NotImplementedException();
        }

        public virtual void GenerarTicketDevolucion(string folio, decimal total, int noArticulos, DataGridView dgvProductosDevolver, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InterfazPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "InterfazPrincipal";
            this.Load += new System.EventHandler(this.InterfazPrincipal_Load);
            this.ResumeLayout(false);

        }

        private void InterfazPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
