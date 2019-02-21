using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Validaciones
    {
        public Validaciones()
        {

        }
        public bool validarNumeros(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool validarNull(string a)
        {
            if (a == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string validarRol(int rol)
        {
            if (rol == 1)
            {
                return("~/View/Tienda/AgregarSede.aspx");
            }

            if (rol == 2)
            {
                return ("~/View/Tienda/CRUDVendedor.aspx");
            }

            if (rol == 3)
            {
                return ("~/View/Tienda/CRUDCliente.aspx");
            }
            return "~/View/Login-Rec/NuevoLogin.aspx";
        }
    }
}
