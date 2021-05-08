using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleVerdeComun.Programacion
{
    public class Usuario
    {
        public string idUsuario;
        public string nombres;
        public string apellidos;
        public string direccion;
        public string colonia;
        public string ciudad;
        public string municipio;
        public string sexo;
        public string celular;
        public string telefono;
        public string email;
        public string contactoEmergencia;
        public string numerosEmergencia;
        public DateTime fechaAlta;
        public string rol;
        public string salarioImss;
        public string salarioContrato;
        public string imss;
        public string curp;
        public string rfc;
        public string beneficiarioNomina;
        public string parentescoBeneficiario;
        public DateTime fechaNacBeneficiario;
        public string lugarNacimiento;
        public DateTime fechaNacimiento;
        public string estadoCivil;
        public string tipoSangre;
        public string nivelAcademico;
        public string casaPropia;
        public string observaciones;
        public bool activo;
        public string usuario;
        public string contrasena;
        public string tallaFaja;
        public string tallaPlayera;
        public string tallaSueter;
        public string numeroPlumero;
        public bool esAdministrador;
        public bool cEmpresa;
        public bool cPuesto;
        public bool cCapacitacion;
        public bool cRecepcionUni;
        public bool cRecepcionFaj;


        public Image foto;

        public Usuario()
        {

        }

        public Usuario(string pidusuario, string pnombres, string papellidos, string pdireccion, string pcolonia,
            string pciudad, string pmunicipio, string psexo, string pcelular, string ptelefono, string pemail,
            string pcontactoemergencia, string pnumerosenemergencia, DateTime pfechaalta, string psalarioimss,
            string psalariocontrato, string pimss, string pcurp, string prfc, string pbeneficiarionomina, string pparentescobeneficiario,
            DateTime pfechanacbeneficiario, string plugarnacimiento, DateTime pfechanacimiento, string pestadocivil,
            string ptiposangre, string pnivelacademico, string pcasapropia, string pobservaciones,
            bool pactivo, string pusuario, string pcontrasena, string ptallafaja, string ptallaplayera, string ptallasueter,
            string pnumeroplumero, bool pesadministrador, bool pcempresa, bool pcpuesto, bool pccapacitacion,
            bool pcrecepcionuni, bool pcrecepcionfaj)
        {
            idUsuario = pidusuario;
            nombres = pnombres;
            apellidos = papellidos;
            direccion = pdireccion;
            colonia = pcolonia;
            ciudad = pciudad;
            municipio = pmunicipio;
            sexo = psexo;
            celular = pcelular;
            telefono = ptelefono;
            email = pemail;
            contactoEmergencia = pcontactoemergencia;
            numerosEmergencia = pnumerosenemergencia;
            fechaAlta = pfechaalta;
            salarioImss = psalarioimss;
            salarioContrato = psalariocontrato;
            imss = pimss;
            curp = pcurp;
            rfc = prfc;
            beneficiarioNomina = pbeneficiarionomina;
            parentescoBeneficiario = pparentescobeneficiario;
            fechaNacBeneficiario = pfechanacbeneficiario;
            lugarNacimiento = plugarnacimiento;
            fechaNacimiento = pfechanacimiento;
            estadoCivil = pestadocivil;
            tipoSangre = ptiposangre;
            nivelAcademico = pnivelacademico;
            casaPropia = pcasapropia;
            observaciones = pobservaciones;
            activo = pactivo;
            usuario = pusuario;
            contrasena = pcontrasena;
            tallaFaja = ptallafaja;
            tallaPlayera = ptallaplayera;
            tallaSueter = ptallasueter;
            numeroPlumero = pnumeroplumero;
            esAdministrador = pesadministrador;
            cEmpresa = pcempresa;
            cPuesto = pcpuesto;
            cCapacitacion = pccapacitacion;
            cRecepcionUni = pcrecepcionuni;
            cRecepcionFaj = pcrecepcionfaj;

        }

        public Usuario(Image pfoto)
        {
            foto = pfoto;
        }
    }
}
