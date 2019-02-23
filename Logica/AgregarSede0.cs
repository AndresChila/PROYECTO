using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class AgregarSede0
    {
        DAOUsuario dao = new DAOUsuario();
        Sede sedes = new Sede();
        DataTable sd = new DataTable();

        string nombresede, ciudad, direccion, accion, mensaje;
        bool resultadoSede, resultadoCiudad;

        public AgregarSede0(bool resultadoSede, bool resultadoCiudad, string nombresede, string ciudad, string direccion, string accion)
        {
            this.nombresede = nombresede;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.resultadoCiudad = resultadoCiudad;
            this.resultadoSede = resultadoSede;
            this.accion = accion;

            sd = dao.traerSedes();
            if (accion == "agregar")
            {
                mensaje = hacertodoagregar();
            }
        }

        public string hacertodoagregar() { 
            if (validarLlenoSede() == true)
            {
                if (resultadoSede == true)
                {
                    if (resultadoCiudad == true)
                    {
                        Sede sede = new Sede();
                        DAOUsuario dAO = new DAOUsuario();

                        sede.NombreSede = nombresede;
                        sede.Ciudad = ciudad;
                        sede.Direccion = direccion;

                        if (dAO.crearSede(sede) == true)
                        {
                           mensaje = "Sede creada exitosamente.";
                        }
                        else
                        {
                            dAO.editarAgregarSedeNuevamente(sede.NombreSede, sede.Ciudad);
                            mensaje = "Ya hay una sede en esta ciudad.";
                            return mensaje;
                        };

                        ciudad = "";
                        nombresede = "";
                        direccion = "";
                        //GridView1.DataBind();
                    }
                    else
                    {
                       mensaje ="Ingrese solo letras en la ciudad de la sede.";
                    }
                }
                else
                {
                    mensaje = "Ingrese solo letras en el nombre de la sede.";
                }
            }
            else
            {
                mensaje = "Ingrese todos los datos. ";
            }
            return mensaje;
        }

        bool validarLlenoSede()
        {
            if (nombresede == "" || ciudad == "" || direccion == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string traerMensaje()
        {
            return mensaje;
        }
        public void eliminarSede(string comandName, int comandArgument)
        {
            if (comandName==("Delete"))
            {
                DAOUsuario dAO = new DAOUsuario();
                int id = Convert.ToInt32(comandArgument);
                dAO.eliminarSede(id);
            }
        }
    }
}
