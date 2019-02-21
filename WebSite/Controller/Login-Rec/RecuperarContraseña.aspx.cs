using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_RecuperarContraseña : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            DAOUsuario user = new DAOUsuario();
            DataTable info = user.obtenerUsusarioToken(Request.QueryString[0]);

            if (int.Parse(info.Rows[0][0].ToString()) == -1)
#pragma warning disable CS0618 // Type or member is obsolete
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token es invalido. Genere uno nuevo');window.location=\"NuevoLogin.aspx\"</script>");
#pragma warning restore CS0618 // Type or member is obsolete
            else if (int.Parse(info.Rows[0][0].ToString()) == -1)
#pragma warning disable CS0618 // Type or member is obsolete
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token esta vencido. Genere uno nuevo');window.location=\"NuevoLogin.aspx\"</script>");
#pragma warning restore CS0618 // Type or member is obsolete
            else
                Session["user_id"] = int.Parse(info.Rows[0][0].ToString());       
        }

        else
            Response.Redirect("Loggin.aspx");
    }

    protected void B_Cambiar_Click(object sender, EventArgs e)
    {
        string a;
        DAOUsuario user = new DAOUsuario();
        EUsuario eUser = new EUsuario();

        eUser.UserId = int.Parse(Session["user_id"].ToString());
        eUser.Clave = Tb_Contraseña.Text;
        a = TB_Repetir.Text;
        if(TB_Repetir.Text == Tb_Contraseña.Text)
        {
            user.actualziarContrasena(eUser);
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Su contraseña ha sido actualizada.');window.location=\"NuevoLogin.aspx\"</script>");
#pragma warning disable CS0618 // Type or member is obsolete      
        }
        else
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Las contraseñas no coinciden');</script>");                                  
#pragma warning restore CS0618 // Type or member is obsolete
        }
        

    }
}