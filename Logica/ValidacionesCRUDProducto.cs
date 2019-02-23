using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ValidacionesCRUDProducto
    {
        public ValidacionesCRUDProducto()
        {

        }
        string mensaje = "Datos correctos. Puede ingresar";
        bool validarLlenoAgregar(string refp, string precio, string cantidad)
        {
            if (refp == "" || precio == "" || cantidad == "")
            {
                mensaje = "Por favor llene todos los campos";
                return false;
            }
            else
            {
                return true;
            }
        }
        bool validarLlenoEditar(string refp, string precio, string cantidad)
        {
            if (refp == "" || precio == "" || cantidad == "")
            {
                return false;
            }
            else
            {
                mensaje = "Por favor llene todos los campos.";
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
                mensaje = "Ingrese un dato númerico válido";
                return false;
            }
        }

        public void AgregarProducto(string refp, string precio, string cantidad, string talla)
        {
            if (validarLlenoAgregar(refp, precio, cantidad) == true)
            {
                if (validarNumeros(cantidad) == true)
                {
                    if (validarNumeros(precio) == true)
                    {
                        DAOUsuario dAO = new DAOUsuario();
                        Producto producto = new Producto();
                        Producto producto2 = new Producto();
                        producto.Referencia = refp;
                        producto.Cantidad = Convert.ToInt64(cantidad);
                        producto.Precio = Convert.ToDouble(precio);
                        producto.Talla = Convert.ToDouble(talla);
                        if (producto.Precio <= 0 || producto.Cantidad <= 0)
                        {
                            mensaje = "Ingrese un valo mayor a 0.";
                            return;
                        }
                        producto2.Referencia = refp;
                        producto2.Precio = Convert.ToDouble(precio);
                        producto2.Talla = Convert.ToDouble(talla);
                        List<string> referencias = dAO.ReferenciasProducto();
                        List<Producto> referencias2 = new List<Producto>();
                        referencias2 = dAO.pruebaaa();
                        if (referencias2.Contains(producto2))
                        {
                            mensaje = "Este producto ya esta registrado. Si desea añadir mas elementos de este producto, dirijase a la seccion de actualizar un producto.";
                        }
                        else
                        {                           
                            dAO.crearProducto(producto);
                            mensaje = "Producto ingresado exitosamente";
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

        public string devuelvemensaje()
        {
            return mensaje;
        }

        public Producto RowCommand(string name, string argument)
        {
            DAOUsuario dAO = new DAOUsuario();
                        
            if(name.Equals("Delete"))
            {
                int id = Convert.ToInt32(argument);
                dAO.eliminarProducto(id);
            }
            if (name.Equals("Editar"))
            {
                this.Seleccionar_Producto(Convert.ToInt32(argument));
            }

        }

        public Producto Seleccionar_Producto(int r)
        {
            DAOUsuario dAO = new DAOUsuario();
            Producto producto = new Producto();
            int refe = r;
            DataTable productos = dAO.verProductosEditar(refe);
            if (productos != null)
            {
                foreach (DataRow row in productos.Rows)
                {
                    producto.Referencia = Convert.ToString(row["referenciaproducto"]);
                    producto.Cantidad = Convert.ToInt64(row["cantidad"]);
                    producto.Talla = Convert.ToDouble(row["talla"]);
                    producto.Precio = Convert.ToDouble(row["precio"]);
                }
            }
            Session["compara"] = Convert.ToString(producto.Cantidad);
            TB_EditarReferencia.Text = producto.Referencia;
            TB_EditarCantidad.Text = Convert.ToString(producto.Cantidad);
            TB_EditarPrecio.Text = Convert.ToString(producto.Precio);
            DL_EditarTallas.SelectedValue = Convert.ToString(producto.Talla);
            B_EditarProducto.Enabled = true;
            B_Cancelar.Enabled = true;

        }

    }
}
