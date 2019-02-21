using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class ValidarMasterAdmin
    {
        public string validarSession(string nombre, string clave, string rol)
        {
            if (nombre == null || clave == null || rol == null)
            {
                return ("../Login-Rec/NuevoLogin.aspx");
            }

            return nombre;
        }
    }
}
