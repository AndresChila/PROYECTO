
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_RecibirPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["paginar"] = null;
            Session["paginar2"] = null;
            this.actualizarAsignaciones();
        }
    }

    String idAsig
    {
        get { return Session["idAsig"] as String; }
        set { Session["idAsig"] = value; }
    }

    DataTable compara
    {
        get { return Session["paginar"] as DataTable; }
        set { Session["paginar"] = value; }
    }
    DataTable compara2
    {
        get { return Session["paginar2"] as DataTable; }
        set { Session["paginar2"] = value; }
    }

    protected void actualizarAsignaciones()
    {
        DAOUsuario dAO = new DAOUsuario();
        DataTable datosAsignacion = new DataTable();
        Session["paginar"] = null;
        datosAsignacion = dAO.verAsignacion(Convert.ToString(Session["sede"]));
        if (datosAsignacion.Rows.Count == 0)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos pendientes para asignar al inventario.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else
        {


            GV_Asignacion.DataSource = datosAsignacion;
            GV_Asignacion.DataBind();
            if (Session["paginar"] == null)
            {
                compara = new DataTable();
                compara = datosAsignacion;
                Session["paginar"] = compara;
            }
        }
    }



    protected void GV_Asignacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            DAOUsuario dAO = new DAOUsuario();
            Session["paginar2"] = null;
            Session["idAsig"] = null;
            DataTable datosAsignaciones = dAO.verAsignaciones(Convert.ToInt32(e.CommandArgument));
            GV_Asignaciones.DataSource = datosAsignaciones;
            GV_Asignaciones.DataBind();
            if (Session["paginar2"] == null)
            {
                compara2 = new DataTable();
                compara2 = datosAsignaciones;
                Session["paginar2"] = compara2;
            }
            if (Session["idAsig"] == null)
            {
                idAsig = Convert.ToString(e.CommandArgument);
                Session["idAsig"] = idAsig;
            }



        }
    }

    protected void GV_Asignacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Asignacion.PageIndex = e.NewPageIndex;
        GV_Asignacion.DataSource = (DataTable)Session["paginar"];
        GV_Asignacion.DataBind();
    }

    protected void GV_Asignaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Asignaciones.PageIndex = e.NewPageIndex;
        GV_Asignaciones.DataSource = (DataTable)Session["paginar2"];
        GV_Asignaciones.DataBind();
    }


    protected void B_AgregarInventario_Click(object sender, EventArgs e)
    {
        //this.mensaje();
        Session["listaDev"] = null;
        DAOUsuario da = new DAOUsuario();
        int idAsignacion = Convert.ToInt32(Session["idAsig"]);

        da.actualizarAsignacion(true, idAsignacion);
        if (GV_Asignaciones.Rows.Count == 0)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos pendientes para asignar al inventario.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else
        {
            List<Inventario> listaDevolucion;
            foreach (GridViewRow fila in GV_Asignaciones.Rows)
            {
                Inventario inventario = new Inventario();
                bool dev;
                inventario.Referencia = Convert.ToString(((Label)fila.Cells[1].FindControl("L_Referencia")).Text);
                inventario.Talla = Convert.ToDouble(((Label)fila.Cells[2].FindControl("L_Talla")).Text);
                inventario.Cantidad = Convert.ToInt32(((Label)fila.Cells[3].FindControl("L_Cantidad")).Text);
                dev = Convert.ToBoolean(((CheckBox)fila.Cells[4].FindControl("CB_Recibido")).Checked);
                if (inventario.Referencia != null)
                {
                    inventario.Sede = Convert.ToString(Session["sede"]);
                    if(dev == true)
                    {
                        da.crearInventario(inventario);
                    }
                    else if(dev == false)
                    {
                        if(Session["listaDev"] == null)
                        {
                            listaDevolucion = new List<Inventario>();
                            listaDevolucion.Add(inventario);
                            Session["listaDev"] = listaDevolucion;
                        }
                        else
                        {
                            listaDevolucion = (Session["listaDev"] as List<Inventario>);
                            listaDevolucion.Add(inventario);
                            Session["listaDev"] = listaDevolucion;
                        }                        
                    }                    
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Se han añadido los productos al inventario.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                }
                else
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos pendientes para agregar al inventario de la sede.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                }

            }
            llenarGV_Devoluciones();
            GV_Asignacion.DataBind();
            GV_Asignaciones.DataBind();
        }
    }

    protected void GV_Asignacion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
     void llenarGV_Devoluciones()
    {
        List<Inventario> inventarios;
        if(Session["listaDev"] == null)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos con conflictos para enviar.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else
        {
            inventarios = (Session["listaDev"] as List<Inventario>);
            GV_Devolver.DataSource = inventarios;
            GV_Devolver.DataBind();
        }        
    }
    

    void imprimir2()
    {
        Response.Write("Cancel");
    }

    [WebMethod]
    public string OkClick(object sender, EventArgs e)
    {
        
        return "Ok";
    }

    [WebMethod]
    public static string CancalClick(object sender, EventArgs e)
    {
        return "Cancel";
    }

    protected void B_Conflicto_Click(object sender, EventArgs e)
    {
        DAOUsuario dAO = new DAOUsuario();
        Pedido devolver = new Pedido();
        DateTime fechaHoy = DateTime.Now;
        devolver.Sede = Convert.ToString(Session["sede"]);
        devolver.Fecha = fechaHoy.ToString("d");
        devolver.Estado = false;
        dAO.crearPedido(devolver, TB_Observación.Text);
        DataTable id = new DataTable();
        id = dAO.verUltimoId();
        if (id.Rows.Count > 0)
        {
            foreach (DataRow rowe in id.Rows)
            {
                devolver.Idpedido = Convert.ToInt32(rowe["f_verultimoid"]);
            }
            
            foreach (GridViewRow row in GV_Devolver.Rows)
            {
                Asignacion temp =  new Asignacion();
                temp.Referencia = Convert.ToString(((Label)row.Cells[0].FindControl("L_Referencia")).Text);
                temp.Talla = Convert.ToDouble(((Label)row.Cells[1].FindControl("L_Talla")).Text);
                temp.Cantidad = Convert.ToInt32(((Label)row.Cells[1].FindControl("L_Cantidad")).Text);
                dAO.crearPedidos(temp, devolver.Idpedido);
            }
        }
        TB_Observación.Text = "";
        GV_Devolver.DataSource = null;
        GV_Devolver.DataBind();
        
    }
}

    
