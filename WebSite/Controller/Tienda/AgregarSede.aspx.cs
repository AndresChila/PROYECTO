using System;
using System.Collections.Generic;
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

public partial class View_Tienda_AgregarSede : System.Web.UI.Page
{
    string accion;
    DAOUsuario dao = new DAOUsuario();
    Sede sedes = new Sede();
    DataTable sd = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        llenarGV_Sedes();
    }

    protected void B_AgregarSede_Click(object sender, EventArgs e)
    {
        accion = "agregar";
        bool resultadoSede = Regex.IsMatch(TB_NombreSede.Text, @"^[a-zA-Z]+$");
        bool resultadoCiudad = Regex.IsMatch(TB_Ciudad.Text, @"^[a-zA-Z]+$");

        AgregarSede0 agr = new AgregarSede0(resultadoSede, resultadoCiudad, TB_NombreSede.Text.ToString(), TB_Ciudad.Text.ToString(),
            TB_Direccion.Text.ToString(), accion);
        this.llenarGV_Sedes();
        string a = agr.traerMensaje();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('"+a+"');</script>");
#pragma warning restore CS0618 // Type or member is obsolete

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*GridView1.PageIndex = e.NewPageIndex;
        this.llenarGV_Sedes();*/
    }


    void llenarGV_Sedes()
    {
        sd = dao.traerSedes();
        GridView1.DataSource = sd;
        GridView1.DataBind();

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AgregarSede0 elimi = new AgregarSede0(false, false, null, null, null, null);
        elimi.eliminarSede(e.CommandName, int.Parse(e.CommandArgument.ToString()));
        llenarGV_Sedes();
    }





    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}