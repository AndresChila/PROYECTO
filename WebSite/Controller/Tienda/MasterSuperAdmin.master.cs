using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

public partial class View_Tienda_MasterTienda : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user_id"] == null || Session["clave"] == null || Convert.ToInt32(Session["rol_id"]) != 1)
        {
            this.cerrarSesion();
            Response.Redirect("../Login-Rec/NuevoLogin.aspx");
        }
        else
        {
            Label_Usuario.Text = Session["nombre"].ToString();
            L_Sede.Text = Session["sede"].ToString();
        }

        this.notificaciones();
        this.notificaciones2();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgregarSede.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUDProducto.aspx");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("Asignar.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUDAdmin.aspx");
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("SuperVentasReportes.aspx");
    }

    protected void B_CerrarSesion_Click(object sender, EventArgs e)
    {
        this.cerrarSesion();
    }

    void cerrarSesion()
    {
        Session["clave"] = null;
        Session["user_id"] = null;
        Session["nombre_rol"] = null;
        Session["nombre"] = null;
        Session["sede"] = null;
        Session["rol_id"] = null;
        Response.Cache.SetNoStore();
        Response.Redirect("../Login-Rec/NuevoLogin.aspx");
    }
    
    void notificaciones()
    {
        DAOUsuario dAO = new DAOUsuario();
        int a = dAO.Notificacion_Asignaciones();
        if(a == 0)
        {
            L_c.Visible = false;
        }
        else
        {
            L_c.Text = Convert.ToString(a);
        }
    }

    void notificaciones2()
    {
        DAOUsuario dAO = new DAOUsuario();
        int a = dAO.Notificacion_Conflictos();
        if(a == 0)
        {
            L_c1.Visible = false;
        }
        else
        {
            L_c1.Text = Convert.ToString(a);
        }
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Conflictos.aspx");
    }
}
