using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;

public partial class View_Tienda_NuevaVenta : System.Web.UI.Page
{

    Cliente cliente = new Cliente();
    DataTable cli = new DataTable();
    Producto producto = new Producto();
    DataTable cli2 = new DataTable();
    DataTable cli3 = new DataTable();
    bool pbNV;



    private List<Producto> listaVenta
    {
        get { return Session["l"] as List<Producto>; }
        set { Session["l"] = value; }
    }

    private string valorVenta
    {
        get { return Session["valorVenta"] as string; }
        set { Session["valorVenta"] = value; }
    }

    private string idCliente
    {
        get { return Session["idCliente"] as string; }
        set { Session["idCliente"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarGridView();
            Session["lis"] = null;
        }


    }
    /////////////////////////////////////////////////////////////////////////////////////////arreglado
    public void llenarGridView()
    {
        LlenarGridViews llenara = new LlenarGridViews();
        
        GV_VentaPedido.DataSource = llenara.llenarGridViewVenta(Session["sede"].ToString(), pbNV); 
        GV_VentaPedido.DataBind();
    }
    

    protected void GV_Productos_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {

    }
    

    protected void B_BuscarCliente_Click(object sender, EventArgs e)
    {
        DAOUsuario dao = new DAOUsuario();
        DataTable cliente = new DataTable();
        BuscarCliente clnte = new BuscarCliente();
        Cliente datosCliente = new Cliente();
        
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('"+ clnte.buscarVacio(TB_BuscarCliente.Text) + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete

        cliente = dao.buscarCliente(int.Parse(TB_BuscarCliente.Text));
        datosCliente = clnte.BuscarDatosCliente(TB_BuscarCliente.Text, cliente.Rows.Count);

            
        TB_Nombre.Text = datosCliente.Nombre;
        TB_Apellido.Text = datosCliente.Apellido;
        B_Seleccionar.Enabled = true;
            
        Session["idCliente"] = TB_BuscarCliente.Text;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {


    }



    protected void B_Seleccionar_Click(object sender, EventArgs e)
    {
        //Session["l"] = null;
        AgregarProductos agregar = new AgregarProductos();
        foreach (GridViewRow row in GV_VentaPedido.Rows)
        {            
            llenarVenta(agregar.AnalizarGridView(Convert.ToString(((TextBox)row.Cells[2].FindControl("TB_Cantidad")).Text), Convert.ToDouble(((Label)row.Cells[1].FindControl("L_Talla")).Text), Convert.ToString(((Label)row.Cells[0].FindControl("L_Referencia")).Text), Session["sede"].ToString(), (List<Producto>) Session["lis"]));
            string msg = agregar.get_mensaje();
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + msg + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        actualizarGV_Venta();
    }

    void llenarVenta(List<Producto> listaVV)
    {
        Session["lis"] = listaVV;
//#pragma warning disable CS0618 // Type or member is obsolete
  //      RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Entra a llenar venta.');</script>");
//#pragma warning restore CS0618 // Type or member is obsolete
        //Session["l"   ] = null;
        /*if (Session["l"] == null)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos para añadir a la venta.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else
        {*/
            double precioTotal = 0;
            List<Producto> listaV = new List<Producto>();
            listaV = (Session["lis"] as List<Producto>);
            foreach (Producto p in listaV)
            {
                precioTotal = precioTotal + p.ValorTotal;
            }
            Response.Write("<script>window.alert('El valor de esta venta es de:" + precioTotal+"';</script>"); 
            Session["valorVenta"] = Convert.ToString(precioTotal);

        //}


    }



    void actualizarGV_Venta()
    {
        List<Producto> listaV = new List<Producto>();
        listaV = (Session["lis"] as List<Producto>);
        GV_Venta.DataSource = listaV;
        GV_Venta.DataBind();
        AgregarProductos p = new AgregarProductos();
        ((TextBox)GV_Venta.FooterRow.FindControl("TB_TotalVenta")).Text = p.valorVenta(Session["valorVenta"].ToString());          
    }

    void irAFactura()
    {
        Session["lis"] = null;
        Response.Redirect("../Tienda/VistaFactura.aspx");
    }
     void irAFactura2()
    {
        Session["lis"] = null;
        Response.Redirect("../Tienda/VistaAbono.aspx");
    }

    protected void B_Facturar_Click(object sender, EventArgs e)
    {

        Venta venta = new Venta();
        DateTime fechaHoy = DateTime.Now;
        venta.Idcliente = int.Parse(Session["idCliente"].ToString());
                venta.Idvendedor = int.Parse(Session["user_id"].ToString());
                venta.Producto = (Session["lis"] as List<Producto>);
                venta.Fecha = fechaHoy;
                venta.Precio = double.Parse(Session["valorVenta"].ToString());
                venta.Sede = Session["sede"].ToString();
                AgregarProductos fact = new AgregarProductos();
                fact.actualizarVenta(venta);
                actualizarInventario();
                reiniciar();
                this.irAFactura();                  
    }
    


    void actualizarInventario()
    {
        List<Producto> refresh = new List<Producto>();
        AgregarProductos actInvt = new AgregarProductos();
        refresh = (Session["lis"] as List<Producto>);
        foreach(Producto p in refresh)
        {
            actInvt.actualizarInvent(Session["sede"].ToString(), p);
        }

    }

     protected void GV_Productos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_VentaPedido.PageIndex = e.NewPageIndex;
        this.llenarGridView();
    }
    

    protected void GV_Venta_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        List<Producto> pventa = new List<Producto>();
        pventa = (Session["lis"] as List<Producto>);
        AgregarProductos borr = new AgregarProductos();
        Session["lis"] = borr.BorrarDelGrid(e.CommandName.ToString(), pventa, e.CommandArgument.ToString());
        actualizarGV_Venta();
                   
    }

    protected void GV_Venta_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Venta_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    void reiniciar()
    {
        Session["lis"] = null;
        llenarGridView();
        actualizarGV_Venta();
        TB_Nombre.Text = "";
        TB_Apellido.Text = "";
        L_InfoCliente.Text = "";
        TB_BuscarCliente.Text = "";
    }

    protected void B_Abono_Click(object sender, EventArgs e)
    {
        AgregarProductos abono = new AgregarProductos();
        Abono venta = new Abono();
        DateTime fechaHoy = DateTime.Now;
        venta.Idcliente = Convert.ToInt32(Session["idCliente"]);
        venta.Idvendedor = Convert.ToInt32(Session["user_id"]);
        venta.Producto = (Session["lis"] as List<Producto>);
        venta.Fecha = fechaHoy.ToString("d");
        venta.Precio = Convert.ToDouble(Session["valorVenta"]);
        venta.Sede = Convert.ToString(Session["sede"]);
        string msj2 = abono.crearAbono(Convert.ToInt32(Session["idCliente"]), venta);
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + msj2 + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        actualizarInventario();
        reiniciar();
        this.irAFactura2();
    }

    protected void B_BuscarProducto_Click(object sender, EventArgs e)
    {
        AgregarProductos boton = new AgregarProductos();        
        GV_VentaPedido.DataSource = boton.actualizar(((TextBox)GV_VentaPedido.HeaderRow.FindControl("TB_BuscarReferencia")).Text, ((TextBox)GV_VentaPedido.HeaderRow.FindControl("TB_BuscarTalla")).Text, Convert.ToString(Session["sede"]), pbNV); ;
        GV_VentaPedido.DataBind();        
    }

    protected void GV_VentaPedido_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void B_Cancelar_Click(object sender, EventArgs e)
    {
        this.reiniciar();
    }
    /////////////////////////////////////////////////////////////////////////////////////////ARREGLAR FACTURAR Y ABONO ERROR DE BASE DE DATOS !!!!!!!
}