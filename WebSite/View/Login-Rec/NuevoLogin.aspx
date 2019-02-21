<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Login-Rec/NuevoLogin.aspx.cs" Inherits="View_NuevoLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 354px;
        }
        .auto-style4 {
            width: 438px;
            background-color: #FFFFFF;
        }
        .auto-style5 {
            width: 354px;
            text-align: center;
            font-size: xx-large;
            color: #FFFFFF;
            background-color: #0000CC;
        }
        .auto-style7 {
            background-color: #FFFFFF;
        }
        .auto-style8 {
            width: 354px;
            background-color: #FFFFFF;
        }
        .auto-style9 {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5" rowspan="10">LOGIN<br />
                        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style9" ForeColor="White" Text="Ingrese Cedula"></asp:Label>
                        <br />
                        <asp:TextBox ID="TB_Cedula" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label3" runat="server" CssClass="auto-style9" ForeColor="White" Text="Ingresa Contraseña"></asp:Label>
                        <br />
                        <asp:TextBox ID="TB_Clave" runat="server" TextMode="Password"></asp:TextBox>
                        <br />
                        <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="auto-style9" ForeColor="White">Olvide la contraseña</asp:LinkButton>
                        <br />
            <asp:Button ID="Button1" runat="server" OnClick="B_Login_Click" Text="Ingresar" />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="L_Aviso" runat="server" Text="..."></asp:Label>
        </div>
    </form>
</body>
</html>
