using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class Controller_Tienda_Conflictos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_Reasignar_Click(object sender, EventArgs e)
    {
        int cantBodega, cont = 0;
        foreach(GridViewRow row in GV_Pedidos.Rows)
        {
            cont++;
            DateTime fechaHoy = DateTime.Now;
            Asignacion a = new Asignacion();
            DAOUsuario d = new DAOUsuario();
            a.Referencia = Convert.ToString(((Label)row.Cells[0].FindControl("L_Referencia")).Text);
            a.Talla = Convert.ToDouble(((Label)row.Cells[1].FindControl("L_Talla")).Text);
            a.Cantidad = Convert.ToInt32(((Label)row.Cells[2].FindControl("L_Cantidad")).Text);
            a.Fecha = fechaHoy.ToString("d");
            a.Estado = false;
            a.Sede = Convert.ToString(Session["asig"]);
            
            DataTable r = d.validarAsignacion(a.Referencia, a.Talla);
            if (r.Rows.Count == 1)
            {
                if (cont == 1)
                {
                    d.crearAsignacion(a);
                }
                foreach (DataRow fi in r.Rows)
                {
                    Producto producto = new Producto();
                    cantBodega = Convert.ToInt32(fi["cantidad"]);
                    producto.Entregado = Convert.ToInt32(fi["entregado"]);
                    producto.Idproducto = Convert.ToInt32(fi["idproducto"]);
                    cantBodega = cantBodega - producto.Entregado;
                    
                    if (a.Cantidad < cantBodega)
                    {
                        this.idpedido2();
                        d.crearAsignaciones(a, Convert.ToInt32(Session["idpedidod"]));
                        d.editarCantidad(Convert.ToInt32(Session["idproducto2"]), (a.Cantidad + producto.Entregado));
                        d.actualizarPedido(false, Convert.ToInt32(Session["idPed2"]));
                    }
                    else
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos suficientes de la referencia "+a.Referencia+" y Talla "+a.Talla+". Hay "+cantBodega+" producto(s) en bodega.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                        return;
                    }
                }
                
            }
        }
        GV_Pedido.DataBind();
        GV_Pedidos.DataBind();
    }

    protected void GV_Pedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            DAOUsuario dao = new DAOUsuario();
            DataTable data = new DataTable();
            DataTable datat = new DataTable();
            datat = dao.verPedido(Convert.ToInt32(e.CommandArgument));
            data = dao.verPedidos(Convert.ToInt32(e.CommandArgument));
            TB_Observacion.Text = dao.traerObservacion(Convert.ToInt32(e.CommandArgument));
            Session["idPed2"] = e.CommandArgument;
            Session["asig"] = datat.Rows[0]["sede"];
            GV_Pedidos.DataSource = data;
            GV_Pedidos.DataBind();
        }
    }

    void idpedido2()
    {
        DAOUsuario d = new DAOUsuario();
        DataTable id = new DataTable();
        id = d.verUltimoId2();
        if (id.Rows.Count > 0)
        {
            foreach (DataRow ff in id.Rows)
            {
                Session["idpedidod"] = Convert.ToInt32(ff["f_verultimoid2"]);
            }
        }
    }

    protected void GV_Pedido_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}