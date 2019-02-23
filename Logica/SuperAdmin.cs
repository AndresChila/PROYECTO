using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class SuperAdmin
    {
        public SuperAdmin()
        {

        }
        public string validarSession(string user, string clave, int rol_id)
        {
            if (user == null || clave == null || rol_id != 1)
            {
                return "../Login-Rec/NuevoLogin.aspx";
            }
            else
            {
                return "../Tienda/AgregarSede.aspx";
            }
        }
    }
}
