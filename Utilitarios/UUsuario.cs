using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UUsuario
    {
        private string usuario;
        private string clave;
        private string nombre_rol;
        private int rol_id;
        private string nombre;
        private string sede;
        private string ip;
        private string mac;
        private string mensaje;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Nombre_rol { get => nombre_rol; set => nombre_rol = value; }
        public int Rol_id { get => rol_id; set => rol_id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sede { get => sede; set => sede = value; }
        public string Ip { get => ip; set => ip = value; }
        public string Mac { get => mac; set => mac = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
