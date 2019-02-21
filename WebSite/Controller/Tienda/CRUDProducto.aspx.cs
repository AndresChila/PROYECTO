    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_CRUDProducto : System.Web.UI.Page
{
    String compara
    {
        get { return Session["compara"] as String ; }
        set { Session["compara"] = value;  }
    }
    String id
    {
        get { return Session["idproducto"] as String; }
        set { Session["idproducto"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_AgregarProducto_Click(object sender, EventArgs e)
    {
        if (validarLlenoAgregar() == true)
        {
            if (validarNumeros(TB_Cantidad.Text) == true)
            {
                if (validarNumeros(TB_Precio.Text) == true)
                {
                    DAOUsuario dAO = new DAOUsuario();
                    Producto producto = new Producto();
                    Producto producto2 = new Producto();
                    producto.Referencia = TB_ReferenciaProducto.Text;
                    producto.Cantidad = Convert.ToInt64(TB_Cantidad.Text);
                    producto.Precio = Convert.ToDouble(TB_Precio.Text);
                    producto.Talla = Convert.ToDouble(DL_Tallas.SelectedValue);
                    if(producto.Precio <= 0 || producto.Cantidad <= 0)
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese un valor mayor a cero.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                        return;
                    }

                    producto2.Referencia = TB_ReferenciaProducto.Text;
                    producto2.Precio = Convert.ToDouble(TB_Precio.Text);
                    producto2.Talla = Convert.ToDouble(DL_Tallas.SelectedValue);
                    List<string> referencias = dAO.ReferenciasProducto();
                    List<Producto> referencias2 = new List<Producto>();
                    referencias2 = dAO.pruebaaa();

                    if (referencias2.Contains(producto2))
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Este producto ya esta registrado. Si desea añadir mas elementos de este producto, dirijase a la seccion de actualizar un producto.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                    }
                    else
                    {
                        //-------------------VALIDACIONES AQUI ANTES DE ENVIARLO------------------------//
                        //if (referencias.Contains(producto.ReferenciaProducto))
                        //{
                        dAO.crearProducto(producto);
                        
                        GV_Productos.DataBind();
                        TB_ReferenciaProducto.Text = "";
                        TB_Precio.Text = "";
                        TB_Cantidad.Text = "";
                        DL_Tallas.SelectedIndex = 0;
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Producto registrado exitosamente.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete

                        //}

                    }
                }
                else
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el precio del producto correctamente.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                }
            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese la cantidad del producto correctamente.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }
        else
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese todos los datos.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Productos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session["idproducto"] = null;
        if (e.CommandName.Equals("Delete"))
        {
            DAOUsuario dAO = new DAOUsuario();
            int id = Convert.ToInt32(e.CommandArgument);
            dAO.eliminarProducto(id);
        }
        if (e.CommandName.Equals("Editar"))
        {
            Seleccionar_Producto(Convert.ToInt32(e.CommandArgument));
            Session["idproducto"] = Convert.ToString(e.CommandArgument);
        }

    }

    void Seleccionar_Producto(int r)
    {
        DAOUsuario dAO = new DAOUsuario();
        Producto producto = new Producto();
        int refe = r;
        DataTable productos = dAO.verProductosEditar(refe);
        if(productos != null) { 
        foreach(DataRow row in productos.Rows)
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


    protected void B_EditarProducto_Click(object sender, EventArgs e)
    {
        if (validarLlenoEditar() == true)
        {
            if (validarNumeros(TB_EditarCantidad.Text) == true)
            {
                if (validarNumeros(TB_EditarPrecio.Text) == true)
                {
                    DAOUsuario dAO = new DAOUsuario();
                    Producto producto = new Producto();
                    string comp;
                    producto.Idproducto = Convert.ToInt32(Session["idproducto"]);
                    producto.Referencia = TB_EditarReferencia.Text;
                    producto.Cantidad = Convert.ToInt64(TB_EditarCantidad.Text);
                    producto.Precio = Convert.ToDouble(TB_EditarPrecio.Text);
                    producto.Talla = Convert.ToDouble(DL_EditarTallas.SelectedValue);
                    if (producto.Precio <= 0 || producto.Cantidad <= 0)
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese un valor mayor a cero.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                        return;
                    }
                    comp = Convert.ToString(Session["compara"]);
                    if (Convert.ToInt32(producto.Cantidad) < Convert.ToInt32(comp))
                    {
            #pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El numero de elementos de esta referencia debe ser mayor o igual a los ya existente.');</script>");
            #pragma warning restore CS0618 // Type or member is obsolete
                    }
                    else
                    {
                        dAO.editarProducto(producto);
            #pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Producto editado exitosamente.');</script>");
            #pragma warning restore CS0618 // Type or member is obsolete
                        
                        GV_Productos.DataBind();
                        TB_EditarReferencia.Text = "";
                        TB_EditarCantidad.Text = "";
                        TB_EditarPrecio.Text = "";
                        DL_EditarTallas.SelectedIndex = 0;
                        B_EditarProducto.Enabled = false;
                        B_Cancelar.Enabled = false;
                        Session["compara"] = null;
                    }
                }
                else
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el precio del producto correctamente.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                }
            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese la cantidad del producto correctamente.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }
        else
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese todos los datos.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

    protected void B_Cancelar_Click(object sender, EventArgs e)
    {
        TB_EditarReferencia.Text = "";
        TB_EditarReferencia.Text = "";
        TB_EditarPrecio.Text = "";
        DL_EditarTallas.SelectedIndex = 0;
        B_EditarProducto.Enabled = false;
        B_Cancelar.Enabled = false;
    }

    protected void DL_ReferenciaProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        B_EditarProducto.Enabled = false;
        B_Cancelar.Enabled = false;
    }

    bool validarLlenoAgregar()
    {
        if (TB_ReferenciaProducto.Text == "" || TB_Precio.Text == "" || TB_Cantidad.Text == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool validarLlenoEditar()
    {
        if (TB_EditarReferencia.Text == "" || TB_EditarPrecio.Text == "" || TB_EditarCantidad.Text == "")
        {
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
            return false;
        }
    }

    protected void TB_EditarPrecio_TextChanged(object sender, EventArgs e)
    {

    }
}