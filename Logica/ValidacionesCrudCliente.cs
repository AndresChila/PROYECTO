using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class ValidacionesCrudCliente
    {

        DAOUsuario dao = new DAOUsuario();
        Cliente cliente = new Cliente();
        DataTable cli = new DataTable();

        string nombre, cedula, apellido, direccion, telefono, sexo;
        string nombree, cedulae, apellidoe, direccione, telefonoe, sexoe;
        string mensaje = "todo ok";
        string accion;
        bool resultadoNombre, resultadoApellido;
        public ValidacionesCrudCliente(string nombrea, string cedulaa, string apellidoa, string direcciona, string telefonoa, string sexoa,
            string nombree, string cedulae, string apellidoe, string direccione, string telefonoe, string sexoe, string accion, bool resultadoNombre, bool resultadoApellido)
        {
            this.nombre = nombrea;
            this.cedula = cedulaa;
            this.direccion = direcciona;
            this.telefono = telefonoa;
            this.apellido = apellidoa;
            this.sexo = sexoa;
            this.nombree = nombree;
            this.cedulae = cedulae;
            this.direccione = direccione;
            this.telefonoe = telefonoe;
            this.apellidoe = apellidoe;
            this.sexoe = sexoe;
            this.accion = accion;
            this.resultadoNombre = resultadoNombre;
            this.resultadoApellido = resultadoApellido;

            if (accion == "guardar")
            {
                mensaje = hacertodoagregar();
            }
            if (accion == "editar")
            {
                mensaje = hacertodoeditar();
            }
        }

        bool validarLlenoEditar()
        {
            if (cedulae == "" || nombree == "" || apellidoe == "" || direccione == "" || telefonoe == "")
            {
                mensaje = "debe llenar campos en la session editar";
                return false;
            }
            else
            {
                return true;
            }
        }

        bool validarLlenoAgregar(string cedula, string nombre, string apellido, string direccion, string telefono)
        {
            if (cedula == "" || nombre == "" || apellido == "" || direccion == "" || telefono == "")
            {
                mensaje = "No puede dejar espacios en blanco";
                return false;
            }
            else
            {
                return true;
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

        public string hacertodoagregar()
        {
            if (validarLlenoAgregar(cedula, nombre, apellido, direccion, telefono) == true)
            {
                if (validarNumeros(cedula) == true)
                {
                    if (resultadoNombre == true)
                    {
                        if (resultadoApellido == true)
                        {
                            if (validarNumeros(telefono) == true)
                            {
                                cliente.Cedula = Convert.ToInt32(cedula);
                                cliente.Nombre = nombre;
                                cliente.Apellido = apellido;
                                cliente.Direccion = direccion;
                                cliente.Telefono = Convert.ToInt64(telefono);
                                cliente.Sexo = sexo;
                                if (cliente.Cedula <= 0 || cliente.Telefono <= 0)
                                {
                                    mensaje = "Ingrese los datos del teléfono correctamente.";
                                    return mensaje;
                                }
                                dao.CrearCliente(cliente);
                                mensaje = "Cliente registrado exitosamente.";

                                cedula = "";
                                nombre = "";
                                apellido = "";
                                direccion = "";
                                telefono = "";

                            }
                            else
                            {
                                mensaje = "Ingrese el telefono del Cliente correctamente";
                                return mensaje;
                            }
                        }
                        else
                        {
                            mensaje = "Ingrese el apellido del Cliente correctamente.";
                            return mensaje;
                        }
                    }
                    else
                    {
                        mensaje = "Ingrese el nombre del Cliente correctamente.";
                        return mensaje;
                    }
                }
                else
                {
                    mensaje = "Ingrese la cedula del Cliente correctamente.";
                    return mensaje;
                }
            }
            else
            {
                mensaje = "Ingrese todos los datos.";
                return mensaje;
            }
            return mensaje;
        }

        public string devuelvemensaje()
        {
            return mensaje;
        }

        public string hacertodoeditar()
        {
            if (validarLlenoEditar() == true)
            {
                if (validarNumeros(cedulae) == true)
                {
                    if (resultadoNombre == true)
                    {
                        if (resultadoApellido == true)
                        {
                            if (validarNumeros(telefonoe) == true)
                            {
                                Cliente cliente2 = new Cliente();

                                cliente2.Cedula = int.Parse(cedulae);

                                cliente2.Nombre = nombree;
                                cliente2.Apellido = apellidoe;
                                cliente2.Direccion = direccione;
                                cliente2.Telefono = Convert.ToInt64(telefonoe);
                                cliente2.Sexo = sexoe;
                                if (cliente.Cedula <= 0 || cliente.Telefono <= 0)
                                {
                                    mensaje = "Ingrese los datos correctamente.";
                                    return mensaje;
                                }
                                dao.actualizarCliente(cliente2);

                                cedulae = "";
                                nombree = "";
                                apellidoe = "";
                                direccione = "";
                                telefonoe = "";
                            }
                            else
                            {
                               mensaje = "Ingrese el telefono del Cliente correctamente.";
                                return mensaje;
                            }
                        }
                        else
                        {
                            mensaje = "Ingrese el apellido del Cliente correctamente.";
                            return mensaje;
                        }
                    }
                    else
                    {
                        mensaje = "Ingrese el nombre del Cliente correctamente.";
                        return mensaje;
                    }
                }
                else
                {
                    mensaje = "Ingrese la cedula del Cliente correctamente.";
                    return mensaje;
                }
            }
            else
            {
                mensaje = "Ingrese todos los datos.";
                return mensaje;
            }
            return mensaje;
        }

        }
}
