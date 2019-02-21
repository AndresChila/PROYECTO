using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_AgregarSede : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }

    protected void B_AgregarSede_Click(object sender, EventArgs e)
    {
        bool resultadoSede = Regex.IsMatch(TB_NombreSede.Text, @"^[a-zA-Z]+$");
        bool resultadoCiudad = Regex.IsMatch(TB_Ciudad.Text, @"^[a-zA-Z]+$");
        
        if (validarLlenoSede() == true)
        {
            if (resultadoSede == true)
            {
                if (resultadoCiudad == true)
                {
                    Sede sede = new Sede();
                    DAOUsuario dAO = new DAOUsuario();

                    sede.NombreSede = TB_NombreSede.Text;
                    sede.Ciudad = TB_Ciudad.Text;
                    sede.Direccion = TB_Direccion.Text;

                    if (dAO.crearSede(sede) == true)
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Sede creada exitosamente. ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
                    }
                    else
                    {
                        dAO.editarAgregarSedeNuevamente(sede.NombreSede, sede.Ciudad);
#pragma warning disable CS0618 // Type or member is obsolete
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ya hay una sede en esta ciudad.  ');</script>");
                        return;
#pragma warning restore CS0618 // Type or member is obsolete
                    };

                    TB_Ciudad.Text = "";
                    TB_NombreSede.Text = "";
                    TB_Direccion.Text = "";
                    GridView1.DataBind();
                }
                else
                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese solo letras en la ciudad de la sede. ');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                }
            }
            else
            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese solo letras en el nombre de la sede.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            }
        }
        else
        {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese todos los datos. ');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DAOUsuario dAO = new DAOUsuario();
            int id = Convert.ToInt32(e.CommandArgument);
            dAO.eliminarSede(id);
        }
    }

    bool validarLlenoSede()
    {
        if (TB_NombreSede.Text == "" || TB_Ciudad.Text == "" || TB_Direccion.Text == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

   
}