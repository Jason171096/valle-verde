using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Programacion.RecursosHumanos
{
    class Cliente
    {
        private string idcliente;
        ValleVerdeComun.ConexionBD ob = new ValleVerdeComun.ConexionBD();
        public string AltaCliente(string nombres, string apellidos, string direccion, string numext,
            string numint, string cp, string colonia, string localidad, string ciudad, string estado,
            string pais, string telefono, string rfc, string utilidad, string descuento,
            bool credito, bool personafisica)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ClienteDarAlta", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.NVarChar).Value = nombres;
            cmd.Parameters.AddWithValue("@apellidos", SqlDbType.NVarChar).Value = apellidos;
            cmd.Parameters.AddWithValue("@direccion", SqlDbType.NVarChar).Value = direccion;

            cmd.Parameters.AddWithValue("@numext", SqlDbType.NVarChar).Value = numext;
            cmd.Parameters.AddWithValue("@numint", SqlDbType.NVarChar).Value = numint;
            cmd.Parameters.AddWithValue("@cp", SqlDbType.NVarChar).Value = cp;

            cmd.Parameters.AddWithValue("@colonia", SqlDbType.NVarChar).Value = colonia;
            cmd.Parameters.AddWithValue("@localidad", SqlDbType.NVarChar).Value = localidad;
            cmd.Parameters.AddWithValue("@ciudad", SqlDbType.NVarChar).Value = ciudad;

            cmd.Parameters.AddWithValue("@estado", SqlDbType.NVarChar).Value = estado;
            cmd.Parameters.AddWithValue("@pais", SqlDbType.NVarChar).Value = pais;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.NVarChar).Value = telefono;

            cmd.Parameters.AddWithValue("@rfc", SqlDbType.NVarChar).Value = rfc;
            cmd.Parameters.AddWithValue("@utilidad", SqlDbType.Decimal).Value = utilidad;
            cmd.Parameters.AddWithValue("@descuento", SqlDbType.Decimal).Value = descuento;

            cmd.Parameters.AddWithValue("@credito", SqlDbType.Bit).Value = credito;
            cmd.Parameters.AddWithValue("@perfis", SqlDbType.Bit).Value = personafisica;

            idcliente = cmd.ExecuteScalar().ToString();
            MessageBox.Show("Cliente añadido", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
            return idcliente;
        }


        public void AltaCredito(string diascredito, string limitecredito)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ClienteDarCredito", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcliente", SqlDbType.BigInt).Value = idcliente;
            cmd.Parameters.AddWithValue("@diascredito", SqlDbType.Int).Value = diascredito;
            cmd.Parameters.AddWithValue("@limitecredito", SqlDbType.Money).Value = limitecredito;
            cmd.Parameters.AddWithValue("@saldo", SqlDbType.Money).Value = 0;
            cmd.Parameters.AddWithValue("@firma", SqlDbType.Bit).Value = 1;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cliente con Credito disponible", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }

        public void ModificarCliente(string idcliente, string nombres, string apellidos, string direccion, string numext,
            string numint, string cp, string colonia, string localidad, string ciudad, string estado,
            string pais, string telefono, string rfc, string utilidad, string descuento,
            bool credito, bool personafisica, string diascredito, string limitecredito, bool activo)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ClienteModificar", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcliente", SqlDbType.BigInt).Value = Convert.ToInt32(idcliente);
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.NVarChar).Value = nombres;
            cmd.Parameters.AddWithValue("@apellidos", SqlDbType.NVarChar).Value = apellidos;

            cmd.Parameters.AddWithValue("@direccion", SqlDbType.NVarChar).Value = direccion;
            cmd.Parameters.AddWithValue("@numext", SqlDbType.NVarChar).Value = numext;
            cmd.Parameters.AddWithValue("@numint", SqlDbType.NVarChar).Value = numint;
            cmd.Parameters.AddWithValue("@cp", SqlDbType.NVarChar).Value = cp;

            cmd.Parameters.AddWithValue("@colonia", SqlDbType.NVarChar).Value = colonia;
            cmd.Parameters.AddWithValue("@localidad", SqlDbType.NVarChar).Value = localidad;
            cmd.Parameters.AddWithValue("@ciudad", SqlDbType.NVarChar).Value = ciudad;

            cmd.Parameters.AddWithValue("@estado", SqlDbType.NVarChar).Value = estado;
            cmd.Parameters.AddWithValue("@pais", SqlDbType.NVarChar).Value = pais;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.NVarChar).Value = telefono;

            cmd.Parameters.AddWithValue("@rfc", SqlDbType.NVarChar).Value = rfc;
            cmd.Parameters.AddWithValue("@utilidad", SqlDbType.Decimal).Value = utilidad;
            cmd.Parameters.AddWithValue("@descuento", SqlDbType.Decimal).Value = descuento;

            cmd.Parameters.AddWithValue("@credito", SqlDbType.Bit).Value = credito;
            cmd.Parameters.AddWithValue("@personafisica", SqlDbType.Bit).Value = personafisica;

            cmd.Parameters.AddWithValue("@diascredito", SqlDbType.Int).Value = diascredito;
            cmd.Parameters.AddWithValue("@limitecredito", SqlDbType.Money).Value = limitecredito;

            cmd.Parameters.AddWithValue("@activo", SqlDbType.Money).Value = activo;


            cmd.ExecuteNonQuery();
            MessageBox.Show("Cliente modificado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }

        public void BajaCliente(string nombres)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ClienteDarBaja", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcliente", SqlDbType.NVarChar).Value = idcliente;
            cmd.Parameters.AddWithValue("@nombres", SqlDbType.NVarChar).Value = nombres;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Cliente eliminado", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ob.CerrarConexionBD();
        }
        public void AltaClienteCorreo(string idcliente, string correo)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ClienteDarAltaCorreo", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcliente", SqlDbType.BigInt).Value = idcliente;
            cmd.Parameters.AddWithValue("@correo", SqlDbType.NVarChar).Value = correo;
            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }

        public void BajaClienteCorreo(string idcorreo)
        {
            ob.AbrirConexionBD();
            SqlCommand cmd = new SqlCommand("ClienteDarBajaCorreo", ob.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idcorreocliente", SqlDbType.BigInt).Value = idcorreo;
            cmd.ExecuteNonQuery();
            ob.CerrarConexionBD();
        }

        public void ModificarClienteCorreo(string idcorreo, string idcliente, string correo)
        {
            if (String.IsNullOrEmpty(idcorreo))
                AltaClienteCorreo(idcliente, correo);
            else
            {
                ob.AbrirConexionBD();
                SqlCommand cmd = new SqlCommand("ClienteModificarCorreo", ob.ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcorreocliente", SqlDbType.BigInt).Value = idcorreo;
                cmd.Parameters.AddWithValue("@idcliente", SqlDbType.BigInt).Value = idcliente;
                cmd.Parameters.AddWithValue("@correo", SqlDbType.NVarChar).Value = correo;
                cmd.ExecuteNonQuery();
                ob.CerrarConexionBD();
            }
        }
    }
}