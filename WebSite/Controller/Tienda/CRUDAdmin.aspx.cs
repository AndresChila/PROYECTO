using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_CRUDAdmin : System.Web.UI.Page
{
    DAOUsuario dao = new DAOUsuario();
    Usuario usuario = new Usuario();
    DataTable usu = new DataTable();
    DataTable sedess = new DataTable();
    DataTable admins = new DataTable();

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
            }
        }

        if (!IsPostBack)
        {
            for (int i = 0; i < sedess.Rows.Count; i++)
            {
                D_Sedes0.Items.Add(sedess.Rows[i]["nombresede"].ToString()+"-"+sedess.Rows[i]["ciudad"].ToString());
            }
        }       
        
    }

    protected void B_Agregar_Click(object sender, EventArgs e)
    {
        bool resultadoNombre = Regex.IsMatch(TB_Nombre.Text, @"^[a-zA-Z]+$");

        if (validarLlenoAgregar() == true)
        {
            if (resultadoNombre == true)
            {
                if (validarNumeros(TB_Telefono.Text) == true)
                {
                    if (validarNumeros(TB_Cedula.Text) == true)
                    {
                        if (validarCedula() == true)
                        {
                            if (validarAdmin() == true)
                            {
                                usuario.Cedula = Convert.ToInt64(TB_Cedula.Text);
                                if(usuario.Cedula <= 0)
                                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese los datos de la cédula correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                                    return;
                                }
                                usuario.Nombre = TB_Nombre.Text;//
                                usuario.Clave = TB_Clave.Text;
                                usuario.Direccion = TB_Direccion.Text;
                                usuario.Telefono = Convert.ToInt64(TB_Telefono.Text);//
                                if (usuario.Telefono <= 0)
                                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese los datos del teléfono correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                                    return;
                                }
                                usuario.Sexo = D_Sexo.SelectedValue;
                                usuario.Sede = D_Sedes.SelectedValue;
                                usuario.Correo = TB_Correo.Text;
                                usuario.Estado = 1;
                                usuario.Session = "hola";
                                usuario.RolId = 2;
                                usuario.LastModified = DateTime.Now;

                                dao.CrearUsuario(usuario);

                                this.limpiar();

                                this.llenarGV_Usuarios();
                                
                            }
                            else
                            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ya existe un usuario para esta sede.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                            }
                        }
                        else
                        {
                            dao.agregarUsuarioNuevamente(TB_Cedula.Text);
                            usu = dao.traerUsuariosAdmin();
                            GV_Productos.DataSource = usu;
                            GV_Productos.DataBind();
                            

                            

#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Este usuario ya existe');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                        }
                    }
                    else
                    {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese la cedula del Admin correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                    }
                }
                else
                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el telefono del Admin correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                }
            }
            else
            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el nombre del Admin correctamente.');</script>");
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

    void traerEditar(int a)
    {
        for (int i = 0; i < usu.Rows.Count; i++)
        {
            if (a == Convert.ToInt32(usu.Rows[i]["cedula"]))
            {
                TB_Cedula0.Text = usu.Rows[i]["cedula"].ToString();
                TB_Nombre0.Text = usu.Rows[i]["nombre"].ToString();
                TB_Clave0.Text = usu.Rows[i]["clave"].ToString();
                TB_Direccion0.Text = usu.Rows[i]["direccion"].ToString();
                TB_Telefono0.Text = usu.Rows[i]["telefono"].ToString();

                TB_Correo0.Text = usu.Rows[i]["correo"].ToString();
                
            }
        }
    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        bool resultadoNombre = Regex.IsMatch(TB_Nombre0.Text, @"^[a-zA-Z]+$");

        if (validarLlenoEditar() == true)
        {
            if (resultadoNombre == true)
            {
                if (validarNumeros(TB_Telefono0.Text) == true)
                {
                    Usuario usuario2 = new Usuario();

                    usuario2.Cedula = int.Parse(TB_Cedula0.Text);
                    usuario2.Nombre = TB_Nombre0.Text;
                    usuario2.Clave = TB_Clave0.Text;
                    usuario2.Direccion = TB_Direccion0.Text;
                    usuario2.Telefono = Convert.ToInt64(TB_Telefono0.Text);
                    usuario2.Sexo = D_Sexo0.SelectedValue;
                    usuario2.Sede = D_Sedes0.SelectedValue;
                    usuario2.Correo = TB_Correo0.Text;
                    usuario2.Estado = 1;
                    usuario2.Session = "";
                    usuario2.RolId = 2;
                    usuario2.LastModified = DateTime.Now;

                    dao.actualizarUsuario(usuario2);

                    this.limpiarEditar();
                     
                    this.llenarGV_Usuarios();
                }
                else
                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el telefono del Admin correctamente.');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                }
            }
            else
            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Ingrese el nombre del Admin correctamente.');</script>");
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

    bool validarLlenoAgregar()
    {
        if (TB_Cedula.Text == "" || TB_Nombre.Text == "" || TB_Clave.Text == "" || TB_Direccion.Text == "" || TB_Telefono.Text == "" || TB_Correo.Text == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool validarLlenoEditar()
    {
        if (TB_Cedula0.Text == "" || TB_Nombre0.Text == "" || TB_Clave0.Text == "" || TB_Direccion0.Text == "" || TB_Telefono0.Text == "" || TB_Correo0.Text == "")
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

    public bool validarCedula()
    {
        DataTable cedula = new DataTable();

        cedula = dao.traerUsuariosAdmin();
        for (int i = 0; i < cedula.Rows.Count; i++)
        {
            if (cedula.Rows[i]["cedula"].ToString() == TB_Cedula.Text)
            {
                return false;
            }
        }
        return true;
    }

    public bool validarAdmin()
    {
        DataTable sede = new DataTable();

        sede = dao.traerUsuariosAdmin();

        for (int i = 0; i < sede.Rows.Count; i++)
        {
            if (sede.Rows[i]["sede"].ToString() == D_Sedes.SelectedValue && sede.Rows[i]["rol_id"].ToString() == "2")
            {
                return false;
            }
        }
        return true;
    }

    protected void D_Sedes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Productos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Productos.PageIndex = e.NewPageIndex;
        this.llenarGV_Usuarios();
    }

    protected void GV_Productos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Editar"))
        {
            this.traerEditar(Convert.ToInt32(e.CommandArgument));
            this.estadoEditar(true);
        }
        if (e.CommandName.Equals("Eliminar"))
        {
            this.eliminarUsuario(Convert.ToString(e.CommandArgument));           
            
        }
    }

    void eliminarUsuario(string a)
    {
        dao.eliminarUsuario(a);
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
}