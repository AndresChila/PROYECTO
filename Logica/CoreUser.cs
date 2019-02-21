using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using System.Data;

namespace Logica
{
    public class CoreUser
    {
        public UUsuario autenticar(UUsuario user)
        {
            DataTable data = new Datos.DAOUsuario().loggin(user);
            DAOUsuario guardarUsuario = new DAOUsuario();

            if (int.Parse(data.Rows[0]["cedula"].ToString()) > 0)
            {
                user.Clave = data.Rows[0]["clave"].ToString();
                user.Usuario = data.Rows[0]["cedula"].ToString();
                user.Nombre_rol = data.Rows[0]["rol_name"].ToString();
                user.Rol_id = int.Parse(data.Rows[0]["rol_id"].ToString());
                user.Nombre = data.Rows[0]["nombre"].ToString();
                user.Sede = data.Rows[0]["sede"].ToString();

                
                guardarUsuario.guardadoSession(user);

                user.Mensaje = "Bienvenido :)";

            }
            else
            {
                user.Mensaje = "Usuario no está registrado o no esta activo. Consulte con el administrador";
            }
            return user;
        }

    }
}
