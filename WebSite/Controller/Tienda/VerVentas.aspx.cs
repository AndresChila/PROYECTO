using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class Controller_Tienda_VerVentas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_Ir_Click(object sender, EventArgs e)
    {
        if(DL_Filtrar.SelectedValue == "1")
        {
            this.ponerIn();
            DAOUsuario dAO = new DAOUsuario();
            DataTable data = new DataTable();
            data = dAO.verVentas(Convert.ToInt32(Session["user_id"]), 1, "", "");
            Session["data"] = data;
            this.llenarGV_Ventas();

        }
        if(DL_Filtrar.SelectedValue == "2")
        {
            
            Label6.Visible = true;
            Label7.Visible = true;
            TB_Fecha1.Visible = true;
            TB_Fecha2.Visible = true;
            B_Buscar.Visible = true;

            B_Ir.Enabled = false;

        }
        if(DL_Filtrar.SelectedValue == "3")
        {
            this.ponerIn();
            DAOUsuario dAO = new DAOUsuario();
            DataTable data = new DataTable();
            data = dAO.verVentas(Convert.ToInt32(Session["user_id"]), 3, "", "");
            Session["data"] = data;
            this.llenarGV_Ventas();
        }
    }

    void ponerIn()
    {
        Label6.Visible = false;
        Label7.Visible = false;
        TB_Fecha1.Visible = false;
        TB_Fecha2.Visible = false;
        B_Buscar.Visible = false;
    }

    void llenarGV_Ventas()
    {
        DataTable data = (Session["data"] as DataTable);
        GV_Ventas.DataSource = data;
        GV_Ventas.DataBind();
    }

    protected void B_Buscar_Click(object sender, EventArgs e)
    {
        if (validarLlenadoFechas() == true)
        {
            DAOUsuario dAO = new DAOUsuario();
            DataTable data = new DataTable();
            data = dAO.verVentas(Convert.ToInt32(Session["user_id"]), 2, Convert.ToString(TB_Fecha1.Text), Convert.ToString(TB_Fecha2.Text));
            Session["data"] = data;
            this.llenarGV_Ventas();
            B_Ir.Enabled = true;
            this.ponerIn();
        }
        else
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese datos.');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

    protected void GV_Ventas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Ventas.PageIndex = e.NewPageIndex;
        this.llenarGV_Ventas();
    }

    bool validarLlenadoFechas()
    {
        if(TB_Fecha1.Text == "" || TB_Fecha2.Text == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}