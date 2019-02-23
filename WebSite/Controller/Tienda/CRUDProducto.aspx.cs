    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

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
        Session["idproducto"] = null;
    }

    protected void B_AgregarProducto_Click(object sender, EventArgs e)
    {
        ValidacionesCRUDProducto val = new ValidacionesCRUDProducto();
        val.AgregarProducto(TB_ReferenciaProducto.Text, TB_Precio.Text, TB_Cantidad.Text, DL_Tallas.SelectedValue);
        Response.Write("<script>window.alert('" + val.devuelvemensaje() + "';</script>");
        GV_Productos.DataBind();
        this.reiniciar();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Productos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ValidacionesCRUDProducto validaciones = new ValidacionesCRUDProducto();
        validaciones.RowCommand(e.CommandName, e.CommandArgument.ToString());
        Session["idproducto"] = Convert.ToString(e.CommandArgument);
        

    }

    void Seleccionar_Producto(int r)
    {
        DAOUsuario dAO = new DAOUsuario();
        Producto producto = new Producto();
        int refe = r;
        DataTable productos = dAO.verProductosEditar(refe);
        if(productos != null)
        { 
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

    void reiniciar()
    {
        TB_ReferenciaProducto.Text = "";
        TB_Precio.Text = "";
        TB_Cantidad.Text = "";
        DL_Tallas.SelectedIndex = 0;
    }

    protected void TB_EditarPrecio_TextChanged(object sender, EventArgs e)
    {

    }
}