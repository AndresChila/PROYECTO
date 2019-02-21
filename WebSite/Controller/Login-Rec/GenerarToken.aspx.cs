using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_GenerarToken : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_Recuperar_Click(object sender, EventArgs e)
    {
        DAOUsuario dao = new DAOUsuario();
        System.Data.DataTable validez = dao.generarToken(int.Parse(TB_User_Name.Text.ToString()));
        if (int.Parse(validez.Rows[0]["cedula"].ToString()) > 0)
        {
            EUserToken token = new EUserToken();
            token.Id = int.Parse(validez.Rows[0]["cedula"].ToString());
            token.Nombre = validez.Rows[0]["clave"].ToString();
            //token.User_name = validez.Rows[0]["user_name"].ToString();
            token.Estado = int.Parse(validez.Rows[0]["estado"].ToString());
            token.Correo = validez.Rows[0]["correo"].ToString();
            token.Fecha = DateTime.Now.ToFileTimeUtc();

            String userToken = encriptar(JsonConvert.SerializeObject(token));
            dao.almacenarToken(userToken, token.Id);

            Correo correo = new Correo();

            String mensaje = "su link de acceso es: " + "http://localhost:65074/View/Login-Rec/RecuperarContraseña.aspx?" + userToken;
            correo.enviarCorreo(token.Correo, userToken, mensaje);

            L_Mensaje.Text = "Su nueva contraseña ha sido enviada a su correo";
        }
        else if(int.Parse(validez.Rows[0]["cedula"].ToString()) == -2)
        {
            L_Mensaje.Text = "Ya extsite un token, por favor verifique su correo.";
        }
        else
        {
            L_Mensaje.Text = "El usurio digitado no existe";
        } 

    }

    private string encriptar(string input)
    {
        SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = provider.ComputeHash(inputBytes);

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < hashedBytes.Length; i++)
            output.Append(hashedBytes[i].ToString("x2").ToLower());

        return output.ToString();
    }
}