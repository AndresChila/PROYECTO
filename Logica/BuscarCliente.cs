using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class BuscarCliente
    {
        DataTable cliente = new DataTable();
        DAOUsuario dao = new DAOUsuario();

        public BuscarCliente()
        {

        }
        public string buscarVacio(string cedula)
        {
            if (cedula == "")
            {
                return "Debe ingresar un número de cédula.";
            }
            else
            {
                try
                {
                    cliente = dao.buscarCliente(Convert.ToInt32(cedula));
                }
                catch (Exception exc)
                {
                    
                }
                if (cliente.Rows.Count > 0)
                {
                    return "Cliente Encontrado";
                }
            }
            return "Cliente No Encontrado";
        }
        public Cliente BuscarDatosCliente(string cedula, int filas)
        {
            if (filas > 0)
            {
                DataTable datos = new DataTable();
                datos = dao.buscarCliente(Convert.ToInt32(cedula));
                Cliente clien = new Cliente();
                clien.Nombre = datos.Rows[0]["nombre"].ToString();
                clien.Apellido = datos.Rows[0]["apellido"].ToString();
                clien.Cedula = int.Parse(cedula);
                return clien;
            }
            else
            {
                Cliente clien = new Cliente();
                clien.Nombre = "No se";
                clien.Apellido = "encontró";
                clien.Cedula = int.Parse(cedula);
                return clien;
            }
        }
    }
}
