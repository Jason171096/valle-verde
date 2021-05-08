using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ValleVerdeComun.Programacion
{
    public class Usuarios
    {
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        Usuario datosUsuario;
        Usuario datosUsuarioFoto;
        private string idUsuario;

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> res = null;

            if (ob.AbrirConexionBD())
            {

                SqlCommand cmd = new SqlCommand("ObtenerUsuarios", ob.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                res = new List<Usuario>();

                while (rdr.Read())
                    res.Add(new Usuario(rdr["IDUsuario"] + "",
                        rdr["Nombres"] + "",
                        rdr["Apellidos"] + "",
                        rdr["Direccion"] + "",
                        rdr["Colonia"] + "",
                        rdr["Ciudad"] + "",
                        rdr["Municipio"] + "",
                        rdr["Sexo"] + "",
                        rdr["Celular"] + "",
                        rdr["Telefono"] + "",
                        rdr["Email"] + "",
                        rdr["ContactoEmergencia"] + "",
                        rdr["NumerosEmergencia"] + "",
                        Convert.ToDateTime(rdr["FechaAlta"] + ""),
                        rdr["SalarioIMSS"] + "",
                        rdr["SalarioContrato"] + "",
                        rdr["IMSS"] + "",
                        rdr["CURP"] + "",
                        rdr["RFC"] + "",
                        rdr["BeneficiarioNomina"] + "",
                        rdr["ParentescoBeneficiario"] + "",
                        Convert.ToDateTime(rdr["FechaNacBeneficiario"] + ""),
                        rdr["LugarNacimiento"] + "",
                        Convert.ToDateTime(rdr["FechaNacimiento"] + ""),
                        rdr["EstadoCivil"] + "",
                        rdr["TipoSangre"] + "",
                        rdr["NivelAcademico"] + "",
                        rdr["CasaPropia"] + "",
                        rdr["Observaciones"] + "",
                        Convert.ToBoolean(rdr["Activo"] + ""),
                        rdr["Usuario"] + "",
                        rdr["Contrasena"] + "",
                        rdr["TallaFaja"] + "",
                        rdr["TallaPlayera"] + "",
                        rdr["TallaSueter"] + "",
                        rdr["NumeroPlumero"] + "",
                        Convert.ToBoolean(rdr["EsAdministrador"] + ""),
                        Convert.ToBoolean(rdr["Cempresa"] + ""),
                        Convert.ToBoolean(rdr["Cpuesto"] + ""),
                        Convert.ToBoolean(rdr["Ccapacitacion"] + ""),
                        Convert.ToBoolean(rdr["CrecepcionUni"] + ""),
                        Convert.ToBoolean(rdr["CrecepcionFaja"] + "")
                        ));

                ob.CerrarConexionBD();
            }

            return res;
        }

        public PermisosUsuario ObtenerPermisosUsuario(string idUsuario)
        {
            ob.AbrirConexionBD();


            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerPermisosUsuario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@idusuario", idUsuario));

            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                PermisosUsuario permisos = null;
                while (rdr.Read())
                {
                    if(rdr[0] + "" != "-1")
                        permisos = new PermisosUsuario(
                            Boolean.Parse(rdr["IniciarSesionBackOffice"] + ""),
                            Boolean.Parse(rdr["CotizacionCompras"] + ""),
                            Boolean.Parse(rdr["RecibirCotizacion"] + ""),
                            Boolean.Parse(rdr["GenerarPedidoCompras"] + ""),
                            Boolean.Parse(rdr["RecibirPedidoCompras"] + ""),
                            Boolean.Parse(rdr["HistorialCompras"] + ""),
                            Boolean.Parse(rdr["AdministrarProveedores"] + ""),
                            Boolean.Parse(rdr["EliminarProveedor"] + ""),
                            Boolean.Parse(rdr["VerDevolucionesCompras"] + ""),
                            Boolean.Parse(rdr["HacerDevolucionesCompras"] + ""),
                            Boolean.Parse(rdr["VerComprasCredito"] + ""),

                            Boolean.Parse(rdr["VerFacturas"] + ""),
                            Boolean.Parse(rdr["GenerarFacturas"] + ""),
                            Boolean.Parse(rdr["VerCreditosVentas"] + ""),
                            Boolean.Parse(rdr["Promociones"] + ""),

                            Boolean.Parse(rdr["AltaProducto"] + ""),
                            Boolean.Parse(rdr["PrecapturarProducto"] + ""),
                            Boolean.Parse(rdr["ModificarProducto"] + ""),
                            Boolean.Parse(rdr["EliminarProducto"] + ""),
                            Boolean.Parse(rdr["ActualizarUbicacion"] + ""),
                            Boolean.Parse(rdr["AjustarPrecio"] + ""),
                            Boolean.Parse(rdr["ReporteExistencias"] + ""),
                            Boolean.Parse(rdr["TraspasarMercancia"] + ""),
                            Boolean.Parse(rdr["AdministrarEntradasSalidas"] + ""),
                            Boolean.Parse(rdr["RegistrarEntrada"] + ""),
                            Boolean.Parse(rdr["RegistrarSalida"] + ""),
                            Boolean.Parse(rdr["AdministrarFabricantes"] + ""),
                            Boolean.Parse(rdr["AdministrarMarcas"] + ""),
                            Boolean.Parse(rdr["AdministrarLineas"] + ""),
                            Boolean.Parse(rdr["AdministrarAlmacenes"] + ""),
                            Boolean.Parse(rdr["AdministrarUnidades"] + ""),
                            Boolean.Parse(rdr["AdministrarInmobiliario"] + ""),

                            Boolean.Parse(rdr["AltaEmpleado"] + ""),
                            Boolean.Parse(rdr["ModificarEmpleado"] + ""),
                            Boolean.Parse(rdr["BajaEmpleado"] + ""),
                            Boolean.Parse(rdr["VerExEmpleados"] + ""),
                            Boolean.Parse(rdr["AdministrarHorarios"] + ""),
                            Boolean.Parse(rdr["AdministrarBonosPenalizaciones"] + ""),
                            Boolean.Parse(rdr["AdministrarPermisosRoles"] + ""),
                            Boolean.Parse(rdr["AltaCliente"] + ""),
                            Boolean.Parse(rdr["ModificarCliente"] + ""),
                            Boolean.Parse(rdr["BajaCliente"] + ""),

                            Boolean.Parse(rdr["ReporteVentas"] + ""),
                            Boolean.Parse(rdr["ReporteCompras"] + ""),
                            Boolean.Parse(rdr["ReporteEmpleados"] + ""),
                            Boolean.Parse(rdr["ReporteFinanzas"] + ""),
                            Boolean.Parse(rdr["ReporteChecador"] + ""),
                            Boolean.Parse(rdr["ImportarProductosExcel"] + ""),
                            Boolean.Parse(rdr["Presupuestos"] + ""),
                            Boolean.Parse(rdr["VerificarInventario"] + ""),
                            Boolean.Parse(rdr["Gastos"] + ""),
                            Boolean.Parse(rdr["Gafete"] + ""),
                            Boolean.Parse(rdr["ConfiguracionBackOffice"] + ""),


                            Boolean.Parse(rdr["IniciarSesionPuntoVenta"] + ""),

                            Boolean.Parse(rdr["PedidoClienteAcceder"] + ""),
                            Boolean.Parse(rdr["DevolucionesVentasAcceder"] + ""),
                            Boolean.Parse(rdr["EtiquetasPendientesPegarAcceder"] + ""),
                            Boolean.Parse(rdr["PreescanearEtiquetas"] + ""),
                            
                            Boolean.Parse(rdr["KardexAcceder"] + ""),
                            Boolean.Parse(rdr["DevolucionesComprasAcceder"] + ""),
                            Boolean.Parse(rdr["ProductosPendientesComprasAcceder"] + ""),
                           
                            Boolean.Parse(rdr["ClavesAdicionalesAcceder"] + ""),
                            
                            
                            Boolean.Parse(rdr["DesbloquearCaja"] + ""),
                            Boolean.Parse(rdr["HacerCorte"] + ""),
                            Boolean.Parse(rdr["HacerDevolucion"] + ""),
                           
                            Boolean.Parse(rdr["HacerCotizacionVenta"] + ""),
                            Boolean.Parse(rdr["VerVentas"] + "")
                            
                           );

                }
                ob.CerrarConexionBD();

                return permisos;
            }




        }

        public Usuario ObtenerUsuario(string idUsuario, bool activo)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerUsuario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idusuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@activo", activo));

            // execute the command
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                datosUsuario = new Usuario(
                    reader["IDUsuario"].ToString(),
                    reader["Nombres"].ToString(),
                    reader["Apellidos"].ToString(),
                    reader["Direccion"].ToString(),
                    reader["Colonia"].ToString(),
                    reader["Ciudad"].ToString(),
                    reader["Municipio"].ToString(),
                    reader["Sexo"].ToString(),
                    reader["Celular"].ToString(),
                    reader["Telefono"].ToString(),
                    reader["Email"].ToString(),
                    reader["ContactoEmergencia"].ToString(),
                    reader["NumerosEmergencia"].ToString(),
                    Convert.ToDateTime(reader[13].ToString()),
                    reader["SalarioIMSS"].ToString(),
                    reader["SalarioContrato"].ToString(),
                    reader["IMSS"].ToString(),
                    reader["CURP"].ToString(),
                    reader["RFC"].ToString(),
                    reader["BeneficiarioNomina"].ToString(),
                    reader["ParentescoBeneficiario"].ToString(),
                    Convert.ToDateTime(reader[21].ToString()),
                    reader["LugarNacimiento"].ToString(),
                    Convert.ToDateTime(reader[23].ToString()),
                    reader["Estadocivil"].ToString(),
                    reader["TipoSangre"].ToString(),
                    reader["NivelAcademico"].ToString(),
                    reader["CasaPropia"].ToString(),
                    reader["Observaciones"].ToString(),
                    Convert.ToBoolean(reader[29].ToString()),
                    reader["Usuario"].ToString(),
                    reader["Contrasena"].ToString(),
                    reader["TallaFaja"].ToString(),
                    reader["TallaPlayera"].ToString(),
                    reader["TallaSueter"].ToString(),
                    reader["NumeroPlumero"].ToString(),
                    Convert.ToBoolean(reader[36].ToString()),
                    Convert.ToBoolean(reader[37].ToString()),
                    Convert.ToBoolean(reader[38].ToString()),
                    Convert.ToBoolean(reader[39].ToString()),
                    Convert.ToBoolean(reader[40].ToString()),
                    Convert.ToBoolean(reader[41].ToString()));
            }
            ob.CerrarConexionBD();
            return datosUsuario;
        }

        public Usuario ObtenerUsuarioFoto(string idUsuario)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerUsuarioFoto", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idusuario", idUsuario));

            // execute the command
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    datosUsuarioFoto = new Usuario(Image.FromStream(new MemoryStream((byte[])reader[0])));
                }
            }
            catch 
            {
                datosUsuarioFoto = null;
            }
            ob.CerrarConexionBD();
            return datosUsuarioFoto;

        }

        public List<string[]> ObtenerUsuarioHijos(string idUsuario)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("ObtenerUsuarioHijos", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idusuario", idUsuario));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0].ToString(), rdr[1].ToString(), DateTime.Parse(rdr[2].ToString()).ToShortDateString() });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<String[]> ObtenerHuellas(string idUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerHuellasUsuario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idusuario", idUsuario));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0] + "", rdr[1] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }

        public List<String[]> ObtenerRolUsuario(string idUsuario)
        {
            ob.AbrirConexionBD();

            // 1.  create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("ObtenerRolUsuario", ob.ObtenerConexion());

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idusuario", idUsuario));

            // execute the command
            SqlDataReader rdr = cmd.ExecuteReader();

            //Pasar datos a vector para regresarlos
            List<String[]> resultado = new List<String[]>();

            while (rdr.Read())
            {
                resultado.Add(new String[] { rdr[0] + "", rdr[1] + "" });
            }

            ob.CerrarConexionBD();

            return resultado;
        }


        public string AltaUsuario(string nombres, string apellidos, string direccion, string colonia,
            string ciudad, string municipio, string sexo, string celular, string telefono, string email, string contactoemergencia,
            string numerosemergencia, DateTime fechaalta, string puesto, string salarioimss, string salariocontrato,
            string nss, string curp, string rfc, string beneficiarionomina, string parentescobeneficiario, DateTime fechanacbeneficiario,
            string lugarnacimiento, DateTime fechanacimineto,
            string estadocivil, string tiposangre, string nivelacademico, string casapropia, string observaciones, bool activo,
            string usuario, string contrasena, bool checkadmin,
            string tallafaja, string tallaplayera, string tallasueter, string numeroplumero,
            bool cempresa, bool cpuesto, bool ccapacitacion, bool crecepcionuni, bool crecepcionfaj)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("UsuarioDarAlta", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.NVarChar).Value = nombres;
            cmd.Parameters.AddWithValue("@apellidos", SqlDbType.NVarChar).Value = apellidos;
            cmd.Parameters.AddWithValue("@direccion", SqlDbType.NVarChar).Value = direccion;
            cmd.Parameters.AddWithValue("@colonia", SqlDbType.NVarChar).Value = colonia;
            cmd.Parameters.AddWithValue("@ciudad", SqlDbType.NVarChar).Value = ciudad;
            cmd.Parameters.AddWithValue("@municipio", SqlDbType.NVarChar).Value = municipio;
            cmd.Parameters.AddWithValue("@sexo", SqlDbType.NVarChar).Value = sexo;
            cmd.Parameters.AddWithValue("@celular", SqlDbType.NVarChar).Value = celular;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.NVarChar).Value = telefono;
            cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.AddWithValue("@contactoEmergencia", SqlDbType.NVarChar).Value = contactoemergencia;
            cmd.Parameters.AddWithValue("@numerosEmergencia", SqlDbType.NVarChar).Value = numerosemergencia;

            cmd.Parameters.AddWithValue("@fechaAlta", SqlDbType.NVarChar).Value = fechaalta;
            cmd.Parameters.AddWithValue("@salarioImss", SqlDbType.NVarChar).Value = salarioimss;
            cmd.Parameters.AddWithValue("@salarioContrato", SqlDbType.NVarChar).Value = salariocontrato;
            cmd.Parameters.AddWithValue("@imss", SqlDbType.NVarChar).Value = nss;
            cmd.Parameters.AddWithValue("@curp", SqlDbType.NVarChar).Value = curp;
            cmd.Parameters.AddWithValue("@rfc", SqlDbType.NVarChar).Value = rfc;
            cmd.Parameters.AddWithValue("@beneficiarioNomina", SqlDbType.NVarChar).Value = beneficiarionomina;
            cmd.Parameters.AddWithValue("@parentescoBeneficiario", SqlDbType.NVarChar).Value = parentescobeneficiario;
            cmd.Parameters.AddWithValue("@fechaNacBeneficiario", SqlDbType.NVarChar).Value = fechanacbeneficiario;

            cmd.Parameters.AddWithValue("@lugarNacimiento", SqlDbType.NVarChar).Value = lugarnacimiento;
            cmd.Parameters.AddWithValue("@fechaNacimiento", SqlDbType.DateTime).Value = fechanacimineto;
            cmd.Parameters.AddWithValue("@estadoCivil", SqlDbType.NVarChar).Value = estadocivil;
            cmd.Parameters.AddWithValue("@tipoSangre", SqlDbType.NVarChar).Value = tiposangre;
            cmd.Parameters.AddWithValue("@nivelAcademico", SqlDbType.NVarChar).Value = nivelacademico;
            cmd.Parameters.AddWithValue("@casaPropia", SqlDbType.NVarChar).Value = casapropia;
            cmd.Parameters.AddWithValue("@observaciones", SqlDbType.NVarChar).Value = observaciones;

            cmd.Parameters.AddWithValue("@activo", SqlDbType.Bit).Value = activo;
            cmd.Parameters.AddWithValue("@usuario", SqlDbType.Bit).Value = usuario;
            cmd.Parameters.AddWithValue("@contrasena", SqlDbType.Bit).Value = contrasena;
            cmd.Parameters.AddWithValue("@esadmin", SqlDbType.Bit).Value = checkadmin;

            cmd.Parameters.AddWithValue("@tallaFaja", SqlDbType.NVarChar).Value = tallafaja;
            cmd.Parameters.AddWithValue("@tallaPlayera", SqlDbType.NVarChar).Value = tallaplayera;
            cmd.Parameters.AddWithValue("@tallaSueter", SqlDbType.NVarChar).Value = tallasueter;
            cmd.Parameters.AddWithValue("@numeroPlumero", SqlDbType.NVarChar).Value = numeroplumero;

            cmd.Parameters.AddWithValue("@cEmpresa", SqlDbType.Bit).Value = cempresa;
            cmd.Parameters.AddWithValue("@cPuesto", SqlDbType.Bit).Value = cpuesto;
            cmd.Parameters.AddWithValue("@cCapacitacion", SqlDbType.Bit).Value = ccapacitacion;
            cmd.Parameters.AddWithValue("@cRecepcionUni", SqlDbType.Bit).Value = crecepcionuni;
            cmd.Parameters.AddWithValue("@cRecepcionFaj", SqlDbType.Bit).Value = crecepcionfaj;

            idUsuario = cmd.ExecuteScalar().ToString();
            System.Windows.Forms.MessageBox.Show("Empleado añadido", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
            return idUsuario;
        }

        public void AltaUsuarioFoto(string id, Image foto)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("UsuarioDarAltaFoto", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = id;
            if (ImageByte(foto) != null)
                cmd.Parameters.AddWithValue("@foto", SqlDbType.VarBinary).Value = ImageByte(foto);
            else
                cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = DBNull.Value;

            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }

        public void AltaUsuarioHijos(string id, string nombre, string fecha)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("UsuarioDarAltaHijos", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = id;
            cmd.Parameters.AddWithValue("@nombrehijo", SqlDbType.NVarChar).Value = nombre;
            cmd.Parameters.AddWithValue("@fecha", SqlDbType.Date).Value = DateTime.Parse(fecha);
            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }

        public void ModificarUsuario(string id, string nombres, string apellidos, string direccion, string colonia,
            string ciudad, string municipio, string sexo, string celular, string telefono, string email, string contactoemergencia,
            string numerosemergencia, DateTime fechaalta, string puesto, string salarioimss, string salariocontrato,
            string imss, string curp, string rfc, string beneficiarionomina, DateTime fechanacbeneficiario, string parentescobeneficiario,
            string lugarnacimiento, DateTime fechanacimineto,
            string estadocivil, string tiposangre, string nivelacademico, string casapropia, string observaciones,
            string usuario, string contrasena, bool checkadmin,
            string tallafaja, string tallaplayera, string tallasueter, string numeroplumero,
            bool cempresa, bool cpuesto, bool ccapacitacion, bool crecepcionuni, bool crecepcionfaj)
        {
            ob.AbrirConexionBD();

            SqlCommand cmd = new SqlCommand("UsuarioModificar", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", SqlDbType.BigInt).Value = id;

            cmd.Parameters.AddWithValue("@nombres", SqlDbType.NVarChar).Value = nombres;
            cmd.Parameters.AddWithValue("@apellidos", SqlDbType.NVarChar).Value = apellidos;
            cmd.Parameters.AddWithValue("@direccion", SqlDbType.NVarChar).Value = direccion;
            cmd.Parameters.AddWithValue("@colonia", SqlDbType.NVarChar).Value = colonia;
            cmd.Parameters.AddWithValue("@ciudad", SqlDbType.NVarChar).Value = ciudad;
            cmd.Parameters.AddWithValue("@municipio", SqlDbType.NVarChar).Value = municipio;
            cmd.Parameters.AddWithValue("@sexo", SqlDbType.NVarChar).Value = sexo;
            cmd.Parameters.AddWithValue("@celular", SqlDbType.NVarChar).Value = celular;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.NVarChar).Value = telefono;
            cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.AddWithValue("@contactoEmergencia", SqlDbType.NVarChar).Value = contactoemergencia;
            cmd.Parameters.AddWithValue("@numerosEmergencia", SqlDbType.NVarChar).Value = numerosemergencia;

            cmd.Parameters.AddWithValue("@fechaAlta", SqlDbType.NVarChar).Value = fechaalta;
            cmd.Parameters.AddWithValue("@salarioImss", SqlDbType.NVarChar).Value = salarioimss;
            cmd.Parameters.AddWithValue("@salarioContrato", SqlDbType.NVarChar).Value = salariocontrato;
            cmd.Parameters.AddWithValue("@imss", SqlDbType.NVarChar).Value = imss;
            cmd.Parameters.AddWithValue("@curp", SqlDbType.NVarChar).Value = curp;
            cmd.Parameters.AddWithValue("@rfc", SqlDbType.NVarChar).Value = rfc;
            cmd.Parameters.AddWithValue("@beneficiarioNomina", SqlDbType.NVarChar).Value = beneficiarionomina;
            cmd.Parameters.AddWithValue("@parentescoBeneficiario", SqlDbType.NVarChar).Value = parentescobeneficiario;
            cmd.Parameters.AddWithValue("@fechaNacBeneficiario", SqlDbType.NVarChar).Value = fechanacbeneficiario;

            cmd.Parameters.AddWithValue("@lugarNacimiento", SqlDbType.NVarChar).Value = lugarnacimiento;
            cmd.Parameters.AddWithValue("@fechaNacimiento", SqlDbType.DateTime).Value = fechanacimineto;
            cmd.Parameters.AddWithValue("@estadoCivil", SqlDbType.NVarChar).Value = estadocivil;
            cmd.Parameters.AddWithValue("@tipoSangre", SqlDbType.NVarChar).Value = tiposangre;
            cmd.Parameters.AddWithValue("@nivelAcademico", SqlDbType.NVarChar).Value = nivelacademico;
            cmd.Parameters.AddWithValue("@casaPropia", SqlDbType.NVarChar).Value = casapropia;
            cmd.Parameters.AddWithValue("@observaciones", SqlDbType.NVarChar).Value = observaciones;

            cmd.Parameters.AddWithValue("@usuario", SqlDbType.Bit).Value = usuario;
            cmd.Parameters.AddWithValue("@contrasena", SqlDbType.Bit).Value = contrasena;
            cmd.Parameters.AddWithValue("@esadmin", SqlDbType.Bit).Value = checkadmin;

            cmd.Parameters.AddWithValue("@tallaFaja", SqlDbType.NVarChar).Value = tallafaja;
            cmd.Parameters.AddWithValue("@tallaPlayera", SqlDbType.NVarChar).Value = tallaplayera;
            cmd.Parameters.AddWithValue("@tallaSueter", SqlDbType.NVarChar).Value = tallasueter;
            cmd.Parameters.AddWithValue("@numeroPlumero", SqlDbType.NVarChar).Value = numeroplumero;

            cmd.Parameters.AddWithValue("@cEmpresa", SqlDbType.Bit).Value = cempresa;
            cmd.Parameters.AddWithValue("@cPuesto", SqlDbType.Bit).Value = cpuesto;
            cmd.Parameters.AddWithValue("@cCapacitacion", SqlDbType.Bit).Value = ccapacitacion;
            cmd.Parameters.AddWithValue("@cRecepcionUni", SqlDbType.Bit).Value = crecepcionuni;
            cmd.Parameters.AddWithValue("@cRecepcionFaj", SqlDbType.Bit).Value = crecepcionfaj;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Empleado modificado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }

        public void ModificarUsuarioFoto(string id, Image foto)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("UsuarioModificarFoto", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = id;
            if (ImageByte(foto) != null)
                cmd.Parameters.AddWithValue("@foto", SqlDbType.VarBinary).Value = ImageByte(foto);
            else
                cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = DBNull.Value;

            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }

        public void ModificarUsuarioHijos(string idHijo, string idUsuario, string nombre, string fecha)
        {
            if (String.IsNullOrWhiteSpace(nombre))
            {
                BajaUsuarioHijos(idHijo);
            }
            else
            {
                ob.AbrirConexionBD();
                SqlCommand cmd = new SqlCommand("UsuarioModificarHijos", ob.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idhijo", SqlDbType.BigInt).Value = idHijo;
                cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = idUsuario;
                cmd.Parameters.AddWithValue("@nombrehijo", SqlDbType.NVarChar).Value = nombre;
                cmd.Parameters.AddWithValue("@fecha", SqlDbType.Date).Value = DateTime.Parse(fecha);
                cmd.ExecuteNonQuery();
                ob.CerrarConexionBD();
            }
        }
        public void BajaUsuarioHijos(string idhijo)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("UsuarioDarBajaHijos", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idhijo", SqlDbType.BigInt).Value = idhijo;
            cmd.ExecuteNonQuery();
        }
        private byte[] ImageByte(Image ImageByte)
        {
            if (ImageByte != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageByte.Save(ms, ImageByte.RawFormat);
                    return ms.ToArray();
                }
            }
            return null;

        }
        public void AltaModificaUsuarioRol(string id, string rol)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("UsuarioDarAltaModificaRol", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", SqlDbType.BigInt).Value = id;
            cmd.Parameters.AddWithValue("@idrol", SqlDbType.BigInt).Value = rol;
            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }

        public void AltaModificaUsuarioPermisos(string id, string idrol, List<bool[]> permisos)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("UsuarioDarAltaModificaPermisos", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            int i = 0;
            cmd.Parameters.AddWithValue($"@IDUsuario", SqlDbType.BigInt).Value = id;
            cmd.Parameters.AddWithValue($"@IDRol", SqlDbType.BigInt).Value = idrol;
            foreach (bool[] permiso in permisos)
            {
                foreach (bool permi in permiso)
                {
                    cmd.Parameters.AddWithValue($"@permiso{i}", SqlDbType.Bit).Value = permi;
                    i++;
                }
            }

            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }
    }
}
