using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_CRUDCliente : System.Web.UI.Page
{
    DAOUsuario dao = new DAOUsuario();
    Cliente cliente = new Cliente();
    DataTable cli = new DataTable();

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

        if (validarLlenoAgregar() == true)
        {
            if (validarNumeros(TB_Cedula.Text) == true)
            {
                if (resultadoNombre == true)
                {
                    if (resultadoApellido == true)
                    {
                        if (validarNumeros(TB_Telefono.Text) == true)
                        {
                            cliente.Cedula = int.Parse(TB_Cedula.Text);
                            cliente.Nombre = TB_Nombre.Text;
                            cliente.Apellido = TB_Apellido.Text;
                            cliente.Direccion = TB_Direccion.Text;
                            cliente.Telefono = Convert.ToInt64(TB_Telefono.Text);
                            cliente.Sexo = D_Sexo.SelectedValue;
                            if(cliente.Cedula <= 0 || cliente.Telefono <= 0)
                            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese los datos correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                                return;
                            }
                            dao.CrearCliente(cliente);
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Cliente registrado exitosamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

                            TB_Cedula.Text = "";
                            TB_Nombre.Text = "";
                            TB_Apellido.Text = "";
                            TB_Direccion.Text = "";
                            TB_Telefono.Text = "";

                            cli = dao.traerClientes();
                            GV_Clientes.DataSource = cli;
                            GV_Clientes.DataBind();
                            DropDownList1.Items.Add(TB_Cedula.Text);
                            DropDownList1.DataBind();
                        }
                        else
                        {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el telefono del Cliente correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                        }
                    }
                    else
                    {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el apellido del Cliente correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                    }
                }
                else
                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el nombre del Cliente correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                }
            }
            else
            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese la cedula del Cliente correctamente.');</script>");
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
        bool resultadoNombre = Regex.IsMatch(TB_Nombre0.Text, @"^[a-zA-Z]+$");
        bool resultadoApellido = Regex.IsMatch(TB_Apellido0.Text, @"^[a-zA-Z]+$");

        if (validarLlenoEditar() == true)
        {
            if (validarNumeros(TB_Cedula0.Text) == true)
            {
                if (resultadoNombre == true)
                {
                    if (resultadoApellido == true)
                    {
                        if (validarNumeros(TB_Telefono0.Text) == true)
                        {
                            Cliente cliente2 = new Cliente();

                            cliente2.Cedula = int.Parse(TB_Cedula0.Text);

                            cliente2.Nombre = TB_Nombre0.Text;
                            cliente2.Apellido = TB_Apellido0.Text;
                            cliente2.Direccion = TB_Direccion0.Text;
                            cliente2.Telefono = Convert.ToInt64(TB_Telefono0.Text);
                            cliente2.Sexo = D_Sexo0.SelectedValue;
                            if (cliente.Cedula <= 0 || cliente.Telefono <= 0)
                            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese los datos correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                                return;
                            }
                            dao.actualizarCliente(cliente2);

                            TB_Cedula0.Text = "";
                            TB_Nombre0.Text = "";
                            TB_Apellido0.Text = "";
                            TB_Direccion0.Text = "";
                            TB_Telefono0.Text = "";

                            cli = dao.traerClientes();
                            GV_Clientes.DataSource = cli;
                            GV_Clientes.DataBind();
                            DropDownList1.Items.Add(TB_Cedula.Text);
                        }
                        else
                        {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el telefono del Cliente correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                        }
                    }
                    else
                    {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el apellido del Cliente correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                    }
                }
                else
                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el nombre del Cliente correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                }
            }
            else
            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese la cedula del Cliente correctamente.');</script>");
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

    bool validarLlenoEditar()
    {
        if (TB_Cedula0.Text == "" || TB_Nombre0.Text == "" || TB_Apellido0.Text == "" || TB_Direccion0.Text == "" || TB_Telefono0.Text == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool validarLlenoAgregar()
    {
        if (TB_Cedula.Text == "" || TB_Nombre.Text == "" || TB_Apellido.Text == "" || TB_Direccion.Text == "" || TB_Telefono.Text == "")
        {
            return false;
        }
        else
        {
            return true;
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

    protected void GV_Clientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Clientes.PageIndex = e.NewPageIndex;
        cli = dao.traerClientes();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
    }
}