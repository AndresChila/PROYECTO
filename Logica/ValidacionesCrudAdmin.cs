using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logica
{

    public class ValidacionesCrudAdmin
    {
        DAOUsuario dao = new DAOUsuario();
        Usuario usuario = new Usuario();
        DataTable usu = new DataTable();

        string nombre, cedula, clave, direccion, telefono, correo, dseleccionado, dsexo;
        string nombree, cedulae, clavee, direccione, telefonoe, correoe, dseleccionadoe, dsexoe;
        string mensaje = "todo ok";
        string accion;
        public ValidacionesCrudAdmin(string nombrea, string cedulaa, string correoa, string direcciona, string telefonoa, string dseleccionadoa, string dsexoa, string clave,
            string nombree, string cedulae, string correoe, string direccione, string telefonoe, string dseleccionadoe, string dsexoe, string clavee, string accion)
        {
            this.nombre = nombrea;
            this.cedula = cedulaa;
            this.direccion = direcciona;
            this.telefono = telefonoa;
            this.correo = correoa;
            this.dseleccionado = dseleccionadoa;
            this.dsexo = dsexoa;
            this.clave = clave;
            this.nombree = nombree;
            this.cedulae = cedulae;
            this.direccione = direccione;
            this.telefonoe = telefonoe;
            this.correoe = correoe;
            this.dseleccionadoe = dseleccionadoe;
            this.dsexoe = dsexoe;
            this.clavee = clavee;
            this.accion = accion;

            usu = dao.traerUsuariosAdmin();
            if (accion == "guardar")
            {
                mensaje = hacertodoagregar();
            }
            if (accion == "editar")
            {
                mensaje = hacertodoeditar();
            }

        }
        
        public bool validarLlenoAgregar(string cedula, string nombre, string clave, string direccion, string telefono, string correo)
        {
            if (cedula == "" || nombre == "" || clave == "" || direccion == "" || telefono == "" || correo == "")
            {
                mensaje = "No puede dejar espacios en blanco";
                return false;
            }
            else
            {

                return true;
            }
        }

        public bool validarCaractNombre(string nombre)
        {
            bool resultadoNombre = Regex.IsMatch(nombre, @"^[a-zA-Z]+$");
            if (resultadoNombre == true || nombre.Contains(" "))
            {
                return true;
            }
            else
            {
                mensaje = "nombre solo puede tener letras";
                return false;
            }
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
                mensaje = "cedula y telefono solo puede tener numeros";
                return false;
            }
        }

        public bool validarCedula(string cedulallega)
        {
            DataTable cedula = new DataTable();

            cedula = dao.traerUsuariosAdmin();
            for (int i = 0; i < cedula.Rows.Count; i++)
            {
                if (cedula.Rows[i]["cedula"].ToString() == cedulallega)
                {
                    mensaje = "cedula no valida";
                    return false;
                }
            }

            return true;

        }

        public bool validarAdmin(string sedeSeleccionada)
        {
            DataTable sede = new DataTable();

            sede = dao.traerUsuariosAdmin();

            for (int i = 0; i < sede.Rows.Count; i++)
            {
                if (sede.Rows[i]["sede"].ToString() == sedeSeleccionada && sede.Rows[i]["rol_id"].ToString() == "2")
                {
                    mensaje = "Ya existe un usuario para esta sede.";
                    return false;
                }
            }
            return true;
        }

        public bool validaralgocedula()
        {
            if (usuario.Cedula <= 0)
            {
                mensaje = "Ingrese los datos de la cédula correctamente.";
                return false;
            }
            return true;
        }

        public string hacertodoagregar()
        {
            if (validarLlenoAgregar(cedula, nombre, clave, direccion, telefono, correo))
            {
                if (validarCaractNombre(nombre))
                {
                    if (validarNumeros(telefono))
                    {
                        if (validarNumeros(cedula))
                        {
                            if (validarCedula(cedula))
                            {
                                if (validarAdmin(dseleccionado))
                                {
                                    usuario.Cedula = Convert.ToInt64(cedula);
                                    if (validaralgocedula())
                                    {
                                        usuario.Nombre = nombre;
                                        usuario.Clave = clave;
                                        usuario.Direccion = direccion;
                                        usuario.Telefono = long.Parse(telefono);
                                        if (usuario.Telefono <= 0)
                                        {
                                            mensaje = "Ingrese los datos del teléfono correctamente.";
                                            return mensaje;
                                        }
                                        usuario.Sexo = dsexo;
                                        usuario.Sede = dseleccionado;
                                        usuario.Correo = correo;
                                        usuario.Estado = 1;
                                        usuario.Session = "hola";
                                        usuario.RolId = 2;
                                        usuario.LastModified = DateTime.Now;

                                        dao.CrearUsuario(usuario);
                                    }
                                    else
                                    {

                                    }

                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                dao.agregarUsuarioNuevamente(cedula);
                                usu = dao.traerUsuariosAdmin();
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
            }
            return mensaje;
        }

        public string devuelvemensaje()
        {
            return mensaje;
        }

        bool validarLlenoEditar()
        {
            if (cedulae == "" || nombree == "" || clavee == "" || direccione == "" || telefonoe == "" || correoe == "")
            {
                mensaje = "debe llenar campos en la session editar";
                return false;
            }
            else
            {
                return true;
            }
        }
        public string hacertodoeditar()
        {
            if (validarLlenoEditar())
            {
                if (validarCaractNombre(nombree))
                {
                    if (validarNumeros(telefonoe))
                    {
                        Usuario usuario2 = new Usuario();

                        usuario2.Cedula = int.Parse(cedulae);
                        usuario2.Nombre = nombree;
                        usuario2.Clave = clavee;
                        usuario2.Direccion = direccione;
                        usuario2.Telefono = Convert.ToInt64(telefonoe);
                        usuario2.Sexo = dsexoe;
                        usuario2.Sede = dseleccionadoe;
                        usuario2.Correo = correoe;
                        usuario2.Estado = 1;
                        usuario2.Session = "";
                        usuario2.RolId = 2;
                        usuario2.LastModified = DateTime.Now;

                        dao.actualizarUsuario(usuario2);


                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
            }
            return mensaje;
        }
        public Usuario paracomandogrid(string comando, string argumento) 
        {
            Usuario iusuari = new Usuario();
            if(comando == "Editar")
            {
                iusuari = traerEditar(Convert.ToInt32(argumento));
                return iusuari;
            }
            if(comando == "Eliminar")
            {
                eliminarUsuario(argumento);
            }
            return iusuari;
        }
        public Usuario traerEditar(int a)
        {
            Usuario usuar = new Usuario();
            for (int i = 0; i < usu.Rows.Count; i++)
            {
                if (a == Convert.ToInt32(usu.Rows[i]["cedula"]))
                {
                    usuar.Cedula = long.Parse(usu.Rows[i]["cedula"].ToString());
                    usuar.Nombre = usu.Rows[i]["nombre"].ToString();
                    usuar.Clave = usu.Rows[i]["clave"].ToString();
                    usuar.Direccion = usu.Rows[i]["direccion"].ToString();
                    usuar.Telefono = long.Parse(usu.Rows[i]["telefono"].ToString());
                    usuar.Correo = usu.Rows[i]["correo"].ToString();
                }
            }
            return usuar;
        }
        void eliminarUsuario(string a)
        {
            dao.eliminarUsuario(a);
        }
    }
}
