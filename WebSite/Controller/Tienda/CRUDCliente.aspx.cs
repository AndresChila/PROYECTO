using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;


public partial class View_Tienda_CRUDCliente : System.Web.UI.Page
{
    DAOUsuario dao = new DAOUsuario();
    Cliente cliente = new Cliente();
    DataTable cli = new DataTable();
    string accion;

    protected void Page_Load(object sender, EventArgs e)
    {
        cli = dao.traerClientes();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();

        if (!IsPostBack)
        {
            for (int i = 0; i < cli.Rows.Count; i++)
            {
                DropDownList1.Items.Add(cli.Rows[i]["cedula"].ToString());
            }
        }
    }

    protected void B_Agregar_Click(object sender, EventArgs e)
    {
        bool resultadoNombre = Regex.IsMatch(TB_Nombre.Text, @"^[a-zA-Z]+$");
        bool resultadoApellido = Regex.IsMatch(TB_Apellido.Text, @"^[a-zA-Z]+$");
        accion = "guardar";
        ValidacionesCrudCliente val = new ValidacionesCrudCliente(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Apellido.Text.ToString(), TB_Direccion.Text.ToString(),
                                                                  TB_Telefono.Text.ToString(), D_Sexo.SelectedValue.ToString(), TB_Nombre0.ToString(), TB_Cedula0.ToString(),
                                                                  TB_Apellido0.ToString(), TB_Direccion0.ToString(), TB_Telefono0.ToString(),D_Sexo0.SelectedValue.ToString(), 
                                                                  accion, resultadoNombre, resultadoApellido);
        Response.Write("<script>window.alert('" + val.devuelvemensaje() + "';</script>");
        cli = dao.traerClientes();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
        DropDownList1.Items.Add(TB_Cedula.Text);
        DropDownList1.DataBind();
       
    }

    protected void B_Seleccionar_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < cli.Rows.Count; i++)
        {
            if (DropDownList1.SelectedItem.ToString() == cli.Rows[i]["cedula"].ToString())
            {
                TB_Cedula0.Text = cli.Rows[i]["cedula"].ToString();
                TB_Nombre0.Text = cli.Rows[i]["nombre"].ToString();
                TB_Apellido0.Text = cli.Rows[i]["apellido"].ToString();
                TB_Direccion0.Text = cli.Rows[i]["direccion"].ToString();
                TB_Telefono0.Text = cli.Rows[i]["telefono"].ToString();
            }
        }
    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        accion = "editar";
        bool resultadoNombre = Regex.IsMatch(TB_Nombre0.Text, @"^[a-zA-Z]+$");
        bool resultadoApellido = Regex.IsMatch(TB_Apellido0.Text, @"^[a-zA-Z]+$");
        ValidacionesCrudCliente val = new ValidacionesCrudCliente(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Apellido.Text.ToString(), TB_Direccion.Text.ToString(),
                                                                  TB_Telefono.Text.ToString(), D_Sexo.SelectedValue.ToString(), TB_Nombre0.ToString(), TB_Cedula0.ToString(),
                                                                  TB_Apellido0.ToString(), TB_Direccion0.ToString(), TB_Telefono0.ToString(), D_Sexo0.SelectedValue.ToString(),
                                                                  accion, resultadoNombre, resultadoApellido);
        Response.Write("<script>window.alert('" + val.devuelvemensaje() + "';</script>");

        cli = dao.traerClientes();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
        DropDownList1.Items.Add(TB_Cedula0.Text);
    }
    
    protected void B_Eliminar_Click(object sender, EventArgs e)
    {
        Cliente cliente3 = new Cliente();
        cliente3.Cedula = int.Parse(DropDownList1.SelectedItem.ToString());
        dao.eliminarCliente(cliente3);

        cli = dao.traerClientes();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
        DropDownList1.Items.Remove(DropDownList1.SelectedItem.ToString());
    }
    
    protected void GV_Clientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Clientes.PageIndex = e.NewPageIndex;
        cli = dao.traerClientes();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
    }
}