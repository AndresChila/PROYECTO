using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_PedirProductos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["pedidos"] = null;
        }
    }

    private List<Asignacion> pedidos
    {
        get { return Session["pedidos"] as List<Asignacion>; }
        set { Session["pedidos"] = value; }
    }


    protected void B_Agregar_Click(object sender, EventArgs e)
    {
        
        foreach (GridViewRow fila in GV_Pedidos.Rows)
        {
            string aa = ((TextBox)fila.Cells[2].FindControl("TB_Cantidad")).Text;
            if (validarNumeros(aa.ToString()) == true)
            {
                Asignacion asignacion = new Asignacion
                {
                    Referencia = Convert.ToString(((Label)fila.Cells[0].FindControl("L_Referencia")).Text),
                    Talla = Convert.ToDouble(((Label)fila.Cells[1].FindControl("L_Talla")).Text)
                };
                try
                {
                    int a = Convert.ToInt32(((TextBox)fila.Cells[2].FindControl("TB_Cantidad")).Text);
                }
                catch (Exception ex)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Revise los datos." + ex + " ');</script>");
                    return;
#pragma warning restore CS0618 // Type or member is obsolete
                }
                if (((TextBox)fila.Cells[2].FindControl("TB_Cantidad")).Text == "")
                {
                    asignacion.Cantidad = 0;
                }
                else
                {
                    asignacion.Cantidad = Convert.ToInt32(((TextBox)fila.Cells[2].FindControl("TB_Cantidad")).Text);
                }
                if (asignacion.Cantidad > 0)
                {
                    if (Session["pedidos"] == null)
                    {
                        pedidos = new List<Asignacion>();
                        pedidos.Add(asignacion);
                        Session["pedidos"] = pedidos;
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Productos agregados al pedido" + asignacion.Cantidad + asignacion.Referencia + asignacion.Talla + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                    }
                    else
                    {
                        if (pedidos.Contains(asignacion))
                        {
#pragma warning disable CS0618 // Type or member is obsolete
                            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No puede agregar dos veces el mismo producto al pedido');</script>");
                            return;
#pragma warning restore CS0618 // Type or member is obsolete
                        }
                        else
                        {

                            pedidos = (Session["pedidos"] as List<Asignacion>);
                            pedidos.Add(asignacion);
#pragma warning disable CS0618 // Type or member is obsolete
                            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Productos agregados al pedido" + asignacion.Cantidad + asignacion.Referencia + asignacion.Talla + "');</script>");

#pragma warning restore CS0618 // Type or member is obsolete
                        }
                    }
                }


            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Debe ingresar solo numeros.');</script>");

#pragma warning restore CS0618 // Type or member is obsolete
            }
        }
        GV_Ped.DataSource = Session["pedidos"];
        GV_Ped.DataBind();
        


        //}
    }

    protected void GV_Pedir_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void B_Pedir_Click1(object sender, EventArgs e)
    {
        Pedido pedido = new Pedido();
        DAOUsuario dao = new DAOUsuario();
        DateTime fechaHoy = DateTime.Now;
        pedidos = (List<Asignacion>) Session["pedidos"];
        
        
        if(Session["pedidos"] != null)
        { 
            pedido.Sede = Convert.ToString(Session["sede"]);
            pedido.Fecha = fechaHoy.ToString("d");
            pedido.Estado = false;
            dao.crearPedido(pedido);
            DataTable id = new DataTable();
            id = dao.verUltimoId();

            if(id.Rows.Count > 0)
            {
                
                foreach (DataRow row in id.Rows)
                {
                    pedido.Idpedido = Convert.ToInt32(row["f_verultimoid"]);
                }
                
                foreach(Asignacion pedid in pedidos)
                {
                    Asignacion temp = (Asignacion)pedid;
                    dao.crearPedidos(temp, pedido.Idpedido);
                }
                
            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
            }
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Pedido agregado. Número: "+pedido.Idpedido+" ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete

            
        }
        else
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Agregue productos al pedido. ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }

        Session["pedidos"] = null;
        GV_Ped.DataBind();
    }

    protected void GV_Ped_SelectedIndexChanged(object sender, EventArgs e)
    {

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
}