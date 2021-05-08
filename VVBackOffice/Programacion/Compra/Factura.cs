namespace ValleVerde.Vistas.Compras
{
    class Factura
    {
        //Propiedades
        public string cam1 { get; set; }
        public string cam2 { get; set; }
        public string cam3 { get; set; }
        public string cam4 { get; set; }
        public string cam5 { get; set; }
        public bool cam6 { get; set; }
        //Asignar el constructor por
        //defecto para que no genere error
        //de argumentos
        public Factura()
        {
        }
        //Constructor que recibe parámetro de la misma clase
        public Factura(Factura Add)
        {
            cam1 = Add.cam1;
            cam2 = Add.cam2;
            cam3 = Add.cam3;
            cam4 = Add.cam4;
            cam5 = Add.cam5;
            cam6 = Add.cam6;
        }
    }
}
