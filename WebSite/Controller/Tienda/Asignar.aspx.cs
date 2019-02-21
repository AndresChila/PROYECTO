using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_Asignar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DAOUsuario dAO = new DAOUsuario();
        DataTable cantidadPendiente = new DataTable();
        cantidadPendiente = dAO.verPedido();
        L_CantidadPendientes.Text = Convert.ToString(cantidadPendiente.Rows.Count);
        
    }

    String compara
    {
        get { return Session["compara"] as String; }
        set { Session["compara"] = value; }
    }
    String idPed
    {
        get { return Session["idPed"] as String; }
        set { Session["idPed"] = value; }
    }
    List<Asignacion> listaAsignacion
    {
        get { return Session["asignacionl"] as List<Asignacion>; }
        set { Session["asignacionl"] = value; }
    }
    List<Asignacion> listaAsignacion2
    {
        get { return Session["asignacion2"] as List<Asignacion>; }
        set { Session["asignacion2"] = value; }
    }

    protected void B_Asignar_Click(object sender, EventArgs e)
    {
        //VALLIDAR

        DAOUsuario d = new DAOUsuario();
        Asignacion asignacion = new Asignacion();
        List<Producto> productos = new List<Producto>();
        Producto producto = new Producto();
        Pedido pedido = new Pedido();
        int cont = 0;
        int cantBodega = 0;
        //id = Convert.ToInt32(DL_ReferenciaProducto.SelectedValue);
        productos = d.Productos();
        //Session["compara"] = Convert.ToString(id);

        foreach (GridViewRow fila in GV_AsignarSinPedido.Rows)
        {
            string aa = ((TextBox)fila.Cells[2].FindControl("TB_Cantidad")).Text;
            if (validarNumeros(aa.ToString()) == true)
            {

                asignacion.Referencia = Convert.ToString(((Label)fila.Cells[0].FindControl("L_Referencia")).Text);
                asignacion.Talla = Convert.ToDouble(((Label)fila.Cells[1].FindControl("L_Talla")).Text);

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
                    cont++;

                    DataTable r = d.validarAsignacion(asignacion.Referencia, asignacion.Talla);
                    if (r.Rows.Count == 1)
                    {
                        foreach (DataRow row in r.Rows)
                        {
                            cantBodega = Convert.ToInt32(row["cantidad"]);
                            producto.Entregado = Convert.ToInt32(row["entregado"]);
                            producto.Idproducto = Convert.ToInt32(row["idproducto"]);
                            cantBodega = cantBodega - producto.Entregado;
                        }
                        if (asignacion.Cantidad < cantBodega)
                        {

                            Response.Write("esto da" + (cantBodega - asignacion.Cantidad));
                            if ((cantBodega - asignacion.Cantidad) >= 5)
                            {
                                DateTime fechaHoy = DateTime.Now;
                                asignacion.Fecha = fechaHoy.ToString("d");
                                asignacion.Estado = false;
                                asignacion.Sede = DL_Sedes.SelectedValue;
                                if (cont == 1)
                                {
                                    d.crearAsignacion(asignacion);
                                }

                                DataTable id = new DataTable();
                                id = d.verUltimoId2();
                                if (id.Rows.Count > 0)
                                {
                                    foreach (DataRow ff in id.Rows)
                                    {
                                        pedido.Idpedido = Convert.ToInt32(ff["f_verultimoid2"]);
                                    }
                                    d.crearAsignaciones(asignacion, pedido.Idpedido);
                                    d.editarCantidad(producto.Idproducto, (asignacion.Cantidad + producto.Entregado));



#pragma warning disable CS0618 // Type or member is obsolete
                                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Asignación completada.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                                }



                            }
                            else
                            {
#pragma warning disable CS0618 // Type or member is obsolete
                                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('En la sede principal deben quedar al menos 5 productos.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                                return;
                            }
                        }
                        else
                        {
#pragma warning disable CS0618 // Type or member is obsolete
                            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('La cantidad de productos a asignar debe ser menor a la que esta e bodega. ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete


                        }
                    }
                    else
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos con esta descripción en la bodega validar. ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                        return;
                    }
                }
                GV_ProductosBodega.DataBind();

            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Solo se pueden ingresar numeros. ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
            }


        }
    
    }

    protected void GV_Asignaciones_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    
    protected void GV_Pedido_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Pedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            DAOUsuario dAO = new DAOUsuario();
            DataTable detalle = new DataTable();
            DataTable ped = new DataTable();
            ped = dAO.verPedido(Convert.ToInt32(e.CommandArgument));
            detalle = dAO.verPedidos(Convert.ToInt32(e.CommandArgument));
            Session["idPed"] = Convert.ToString(e.CommandArgument);
            string sed = Convert.ToString(ped.Rows[0]["sede"]);
            Session["sedePedido"] = ped.Rows[0]["sede"];
            GV_Pedidos.DataSource = detalle;
            GV_Pedidos.DataBind();
            
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
        DAOUsuario d = new DAOUsuario();
        Producto producto = new Producto();
        Pedido pedido = new Pedido();
        
        Session["asignacion2"] = null;
        int cantBodega = 0;
        int idPedi = Convert.ToInt32(Session["idPed"]);
        int cont = 0;
        if (GV_Pedidos.Rows.Count > 0)
        {
            foreach (GridViewRow row in GV_Pedidos.Rows)
            {
                Asignacion asignacion = new Asignacion();
                cont++;
                asignacion.Referencia = Convert.ToString(((Label)row.Cells[0].FindControl("L_Referencia")).Text);
                asignacion.Talla = Convert.ToDouble(((Label)row.Cells[1].FindControl("L_Talla")).Text);
                asignacion.Cantidad = Convert.ToInt32(((Label)row.Cells[2].FindControl("L_Cantidad")).Text);

                DataTable r = d.validarAsignacion(asignacion.Referencia, asignacion.Talla);

                if (r.Rows.Count == 1)
                {
                    foreach (DataRow ro in r.Rows)
                    {
                        cantBodega = Convert.ToInt32(ro["cantidad"]);
                        producto.Entregado = Convert.ToInt32(ro["entregado"]);
                        Session["entregado"] = producto.Entregado;
                        producto.Idproducto = Convert.ToInt32(ro["idproducto"]);
                        Session["idproducto"] = producto.Idproducto;
                        cantBodega = cantBodega - producto.Entregado;
                    }
                    if (asignacion.Cantidad < cantBodega)
                    {
                        Response.Write("esto da" + (cantBodega - asignacion.Cantidad));
                        if ((cantBodega - asignacion.Cantidad) >= 5)
                        {
                            DateTime fechaHoy = DateTime.Now;
                            asignacion.Fecha = fechaHoy.ToString("d");
                            asignacion.Estado = false;
                            asignacion.Sede = Convert.ToString(Session["sedePedido"]);

                            if (Session["asignacion2"] == null)
                            {
                                listaAsignacion2 = new List<Asignacion>();
                                listaAsignacion2.Add(asignacion);
                                Session["asignacion2"] = listaAsignacion2;
                            }
                            else
                            {
                                listaAsignacion2 = (Session["asignacion2"] as List<Asignacion>);
                                listaAsignacion2.Add(asignacion);
                                Session["asignacion2"] = listaAsignacion2;
                            }
                        }
                        else
                        {
#pragma warning disable CS0618 // Type or member is obsolete

                            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('En la sede principal deben quedar al menos 5 productos. Revise el producto Referencia:"+asignacion.Referencia+" y talla "+asignacion.Talla+"');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                            return;
                        }
                    }
                    else
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('La cantidad de productos a asignar debe ser menor a la que esta en bodega. ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                        return;
                    }
                }

                else
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos con esta descripción en la bodega validar. ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                    return;
                }
            }
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El pedido esta listo para ser enviado.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        if (Session["asignacion2"].Equals(null) == false)
        {
            Button2.Enabled = true;
            Button3.Enabled = false;
        }
            
            GV_Pedido.DataBind();
            GV_Pedidos.DataBind();
            GV_ProductosBodega.DataBind();
    }

    
  
    

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        if(Session["asignacion2"].Equals(null) == false)
        {
            this.ingresarBD();
        }
        else
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('La variable de sesión esta nula.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }

    }
    void ingresarBD()
    {
        DAOUsuario d = new DAOUsuario();
        listaAsignacion2 = (Session["asignacion2"] as List<Asignacion>);
        
        int cont = 0;
        if (listaAsignacion2.Count > 0)
        {
            foreach (Asignacion a in listaAsignacion2)
            {
                cont++;
                if (cont == 1)
                {
                    d.crearAsignacion(a);
                }
                DataTable id = new DataTable();
                id = d.verUltimoId2();
                if (id.Rows.Count > 0)
                {
                    foreach (DataRow ff in id.Rows)
                    {
                        Session["idpedido"] = Convert.ToInt32(ff["f_verultimoid2"]);
                    }
                    
                    d.crearAsignaciones(a, Convert.ToInt32(Session["idpedido"]));
                    d.editarCantidad(Convert.ToInt32(Session["idproducto"]), (a.Cantidad + Convert.ToInt32(Session["entregado"])));
                    d.actualizarPedido(true, Convert.ToInt32(Session["idPed"]));
#pragma warning disable CS0618 // Type or member is obsolete
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Base de Datos actualizada. Asignación completada.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                }
            }
            GV_Pedido.DataBind();
            GV_Pedidos.DataBind();
            GV_ProductosBodega.DataBind();
        }
        else
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay una lista llena para enviar.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
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
}