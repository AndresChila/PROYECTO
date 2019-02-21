using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_Bodega : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        llenarGridView();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    void llenarGridView()
    {
        DAOUsuario dao = new DAOUsuario();
        DataTable gri = new DataTable();
        gri = dao.verInventario(Convert.ToString(Session["sede"]));

        GV_Inventario.DataSource = gri;
        GV_Inventario.DataBind();

    }

    protected void GV_Inventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Inventario.PageIndex = e.NewPageIndex;
        llenarGridView();

    }
}