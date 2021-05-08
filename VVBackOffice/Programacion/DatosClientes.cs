namespace ValleVerde.Programacion
{
    public class DatosClientes
    {
        public int idcliente;
        public string nombres;
        public string apellidos;
        public string direccion;
        public string numeroexterior;
        public string numerointerior;
        public string CP;
        public string colonia;
        public string localidad;
        public string ciudad;
        public string estado;
        public string pais;
        public string telefono;
        public string RFC;
        public decimal utilidadcosto;
        public decimal descuentogeneral;
        public bool credito;
        public bool personafisica;
        public string facturama;
        public string CFDI;
        public int diascredito;
        public decimal limitecredito;
        public bool activo;

        public DatosClientes(int pidcliente, string pnombres, string papellidos,
            string pdireccion, string pnumext, string pnumint, string pcp,
            string pcolonia, string plocalidad, string pciudad, string pestado,
            string ppais, string ptelefono, string prfc,
            decimal putilidadcosto, decimal pdescuentogeneral, bool pcredito,
            bool pperfis, 
            int pdiascredito, decimal plimitecredito, bool pactivo)
        {
            idcliente = pidcliente;
            nombres = pnombres;
            apellidos = papellidos;
            direccion = pdireccion;
            numeroexterior = pnumext;
            numerointerior = pnumint;
            CP = pcp;
            colonia = pcolonia;
            localidad = plocalidad;
            ciudad = pciudad;
            estado = pestado;
            pais = ppais;
            telefono = ptelefono;
            RFC = prfc;
            utilidadcosto = putilidadcosto;
            descuentogeneral = pdescuentogeneral;
            credito = pcredito;
            personafisica = pperfis;
            diascredito = pdiascredito;
            limitecredito = plimitecredito;
            activo = pactivo;
        }
    }
}