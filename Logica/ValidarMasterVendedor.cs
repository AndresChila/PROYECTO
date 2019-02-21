using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ValidarMasterVendedor
    {
        public ValidarMasterVendedor()
        {

        }
        public string validarSessionNombreClaveRol(string nombre, string clave, string rol)
        {
            if(nombre == null || clave== null || rol == null)
            {
                return ("../Login-Rec/NuevoLogin.aspx");
            }
            return "CRUDCliente.aspx";
        }
    }
}
