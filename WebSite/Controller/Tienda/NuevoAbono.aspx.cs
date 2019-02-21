using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_NuevoAbono : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        llenarGV_Abonos();
    }

    private List<Producto> listaVenta
    {
        get { return Session["refresh"] as List<Producto>; }
        set { Session["refesh"] = value; }
    }

    private DataTable datosAbono
    {
        get { return Session["venta"] as DataTable; }
        set { Session["venta"] = value; }
    }

    protected void GV_AbonosPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            DAOUsuario dAO = new DAOUsuario();
            TB_PrecioDeuda.Text = Convert.ToString(dAO.traePrecioAbono(Convert.ToInt32(e.CommandArgument)));
            Session["idAbono"] = Convert.ToString(e.CommandArgument);
        }
    }
    void llenarGV_Abonos()  
    {
        DAOUsuario dAO = new DAOUsuario();
        DataTable abo = new DataTable();
        abo = dAO.traerAbonos(Convert.ToString(Session["sede"]));
        string aa = Convert.ToString(Session["sede"]);
        Session["venta"] = abo;
        GV_AbonosPendientes.DataSource = abo;
        GV_AbonosPendientes.DataBind();
    }
    void nuevaVenta()
    {
        if(Session["venta"] != null)
        {
            Producto individual = new Producto();
            datosAbono = new DataTable();
            datosAbono = (Session["venta"] as DataTable);
            
            foreach(DataRow row in datosAbono.Rows)
            {
                Venta venta = new Venta();
                venta.Idcliente = Convert.ToInt32(row["idcliente"]);
                venta.Producto = JsonConvert.DeserializeObject<List<Producto>>(Convert.ToString(row["descripcion"]));
                Session["refresh"] = venta.Producto;
                venta.Idvendedor = Convert.ToInt32(row["idvendedor"]);
                venta.Fecha = Convert.ToDateTime(row["fecha"]);
                venta.Precio = Convert.ToDouble(row["precio"]);
                venta.Sede = Convert.ToString(row["sede"]);
                DAOUsuario dAO = new DAOUsuario();
                dAO.crearVenta(venta, JsonConvert.SerializeObject(venta.Producto));
                
#pragma warning disable CS0618 // Type or member is obsolete
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Se ha convertido en venta.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                this.actualizarInventario();
            }
            
            Response.Redirect("../Tienda/VistaFactura.aspx");
        }
    }
    void actualizarInventario()
    {
        listaVenta = new List<Producto>();
        DAOUsuario dAO = new DAOUsuario();

        listaVenta = (Session["refresh"] as List<Producto>);
        foreach (Producto p in listaVenta)
        {
            dAO.actualizarInventario(p, Convert.ToString(Session["sede"]));
        }


    }

    protected void B_AgregarProducto_Click(object sender, EventArgs e)
    {
        if (validarLlenoAbono() == true)
        {
            double a, b;
            a = Convert.ToDouble(TB_PrecioDeuda.Text);
            b = Convert.ToDouble(TB_PagoActual.Text);
            if (Session["idAbono"] == null)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Seleccione un abono para actualzar.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
            }
            else
            {
                if (a < b)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El precio a pagar supera la deuda actual.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                }
                else if (b <= a)
                {
                    DAOUsuario dAO = new DAOUsuario();
                    dAO.actualizarAbono(Convert.ToInt32(Session["idAbono"]), a - b);
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Abono actualizado. Nueva deuda" + (a - b) + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                    this.llenarGV_Abonos();
                    if ((a - b) == 0)
                    {
                        this.nuevaVenta();
                    }
                    TB_PagoActual.Text = "";
                    TB_PrecioDeuda.Text = "";
                    Session["idAbono"] = null;
                }
            }
        }
        else
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese datos.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

    protected void GV_AbonosPendientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_AbonosPendientes.PageIndex = e.NewPageIndex;
        this.llenarGV_Abonos();
    }

    bool validarLlenoAbono()
    {
        if(TB_PrecioDeuda.Text == "" || TB_PagoActual.Text == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}