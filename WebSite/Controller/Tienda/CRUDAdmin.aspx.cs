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

public partial class View_Tienda_CRUDAdmin : System.Web.UI.Page
{
    DAOUsuario dao = new DAOUsuario();
    Usuario usuario = new Usuario();
    DataTable usu = new DataTable();
    DataTable sedess = new DataTable();
    DataTable admins = new DataTable();
    string accion;

    protected void Page_Load(object sender, EventArgs e)
    {        
        usu = dao.traerUsuariosAdmin();
        GV_Productos.DataSource = usu;
        GV_Productos.DataBind();
        sedess = dao.traerSedes();
        admins = dao.traerUsuariosAdmin();

        if (!IsPostBack)
        {
            for (int i = 0; i < sedess.Rows.Count; i++)
            {
                D_Sedes.Items.Add(sedess.Rows[i]["nombresede"].ToString() + "-" + sedess.Rows[i]["ciudad"].ToString());
                D_Sedes0.Items.Add(sedess.Rows[i]["nombresede"].ToString() + "-" + sedess.Rows[i]["ciudad"].ToString());
            }
        }     
    }

    protected void B_Agregar_Click(object sender, EventArgs e)
    {

        accion = "guardar";
        ValidacionesCrudAdmin val = new ValidacionesCrudAdmin(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Correo.Text.ToString(), TB_Direccion.Text.ToString(),
                                                                  TB_Telefono.Text.ToString(), D_Sedes.SelectedValue.ToString(), D_Sexo.SelectedValue.ToString(), TB_Clave.Text.ToString(),
                                                                  TB_Nombre0.ToString(), TB_Cedula0.ToString(), TB_Correo0.ToString(), TB_Direccion0.ToString(),
                                                                  TB_Telefono0.ToString(), D_Sedes0.SelectedValue, D_Sexo0.SelectedValue, TB_Clave0.Text.ToString(), accion);
        Response.Write("<script>window.alert('" + val.devuelvemensaje() + "';</script>");
        this.limpiar();
        this.llenarGV_Usuarios();

        //dao.agregarUsuarioNuevamente(TB_Cedula.Text);
        usu = dao.traerUsuariosAdmin();
        GV_Productos.DataSource = usu;
        GV_Productos.DataBind();

    }
    
    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        accion = "editar";
        ValidacionesCrudAdmin val = new ValidacionesCrudAdmin(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Correo.Text.ToString(), TB_Direccion.Text.ToString(),
                                                              TB_Telefono.Text.ToString(), D_Sedes.SelectedValue.ToString(), D_Sexo.SelectedValue.ToString(), TB_Clave.Text.ToString(),
                                                              TB_Nombre0.Text.ToString(), TB_Cedula0.Text.ToString(), TB_Correo0.Text.ToString(), TB_Direccion0.Text.ToString(),
                                                              TB_Telefono0.Text.ToString(), D_Sedes0.SelectedValue, D_Sexo0.SelectedValue, TB_Clave0.Text.ToString(), accion);
        Response.Write("<script>window.alert('" + val.devuelvemensaje() + "';</script>");
        
        this.llenarGV_Usuarios();
        this.limpiarEditar();
    }

    void estadoEditar(bool x)
    {
        TB_Cedula0.Enabled = x;
        TB_Nombre0.Enabled = x;
        TB_Clave0.Enabled = x;
        TB_Direccion0.Enabled = x;
        TB_Telefono0.Enabled = x;
        TB_Correo0.Enabled = x;
        D_Sexo0.Enabled = x;
        D_Sedes0.Enabled = x;
        B_Actualizar.Enabled = x;
        B_Cancelar.Enabled = x;
    }
     
    void limpiarEditar()
    {
        TB_Cedula0.Text = "";
        TB_Nombre0.Text = "";
        TB_Clave0.Text = "";
        TB_Direccion0.Text = "";
        TB_Telefono0.Text = "";
        TB_Correo0.Text = "";
    }

    void limpiar()
    {
        TB_Cedula.Text = "";
        TB_Nombre.Text = "";
        TB_Clave.Text = "";
        TB_Direccion.Text = "";
        TB_Telefono.Text = "";
        TB_Correo.Text = "";
    }

    protected void GV_Productos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Productos.PageIndex = e.NewPageIndex;
        this.llenarGV_Usuarios();
    }
    
    protected void GV_Productos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ValidacionesCrudAdmin val = new ValidacionesCrudAdmin(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Correo.Text.ToString(), TB_Direccion.Text.ToString(),
                                                             TB_Telefono.Text.ToString(), D_Sedes.SelectedValue.ToString(), D_Sexo.SelectedValue.ToString(), TB_Clave.Text.ToString(),
                                                             TB_Nombre0.Text.ToString(), TB_Cedula0.Text.ToString(), TB_Correo0.Text.ToString(), TB_Direccion0.Text.ToString(),
                                                             TB_Telefono0.Text.ToString(), D_Sedes0.SelectedValue, D_Sexo0.SelectedValue, TB_Clave0.Text.ToString(), accion);
            Usuario u = new Usuario();
            u = val.paracomandogrid(e.CommandName, e.CommandArgument.ToString());
            traerEditar(u);
            this.estadoEditar(true);
            this.llenarGV_Usuarios();
    }

    void llenarGV_Usuarios()
    {
        usu = dao.traerUsuariosAdmin();
        GV_Productos.DataSource = usu;
        GV_Productos.DataBind();
        
    }

    protected void B_Cancelar_Click(object sender, EventArgs e)
    {
        this.limpiarEditar();
        this.estadoEditar(false);
    }

    protected void B_Cancelar1_Click(object sender, EventArgs e)
    {
        this.limpiarEditar();
    }

    public void traerEditar(Usuario u)
    {
        TB_Cedula0.Text = u.Cedula.ToString();
        TB_Nombre0.Text = u.Nombre;
        TB_Clave0.Text = u.Clave;
        TB_Direccion0.Text = u.Direccion;
        TB_Telefono0.Text = u.Telefono.ToString();
        TB_Correo0.Text = u.Correo;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////-------------------$$$$$$$$$$$$$$$$$$
}