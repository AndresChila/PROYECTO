using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_NuevoLogin : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LB_Recuperar_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerarToken.aspx");
    }
    protected void B_Login_Click(object sender, EventArgs e)
    {
            
        Loguearse log = new Loguearse();
        UUsuario user = new UUsuario();
        user = log.loguear(TB_Cedula.Text.ToString(), TB_Clave.Text.ToString());
            
        DAOUsuario guardarUsuario = new DAOUsuario();
        DataTable data = guardarUsuario.loggin(user.Usuario, user.Clave);

        user = new CoreUser().autenticar(user);


        Session["clave"] = user.Clave;
        Session["user_id"] = user.Usuario;
        Session["nombre_rol"] = user.Nombre_rol;
        Session["rol_id"] = user.Rol_id;
        Session["nombre"] = user.Nombre;
        Session["sede"] = user.Sede;
        pintar(user);
        Validaciones validarRol = new Validaciones();
        Response.Redirect(validarRol.validarRol(user.Rol_id));
    }

    public void pintar(UUsuario user)
    {
        Response.Write("<script>window.alert('"+user.Mensaje+"');</script>");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerarToken.aspx");
    }
}