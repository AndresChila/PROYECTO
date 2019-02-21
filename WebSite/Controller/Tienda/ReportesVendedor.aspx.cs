using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_ReportesVendedor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (validarNumeros(TB_Factura.Text) == true)
        {
            Session["idVenta"] = TB_Factura.Text;
            Response.Redirect("../Tienda/VistaFactura.aspx");
        }
        else
        {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese datos.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
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