<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterSuperAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/Asignar.aspx.cs" Inherits="View_Tienda_Asignar" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style10 {
            width: 206px;
        }
        .auto-style11 {
            height: 23px;
        }
        .auto-style12 {
            width: 206px;
            height: 23px;
        }
        .auto-style13 {
            width: 152px;
        }
        .auto-style14 {
            height: 23px;
            width: 152px;
        }
        .auto-style15 {
            height: 24px;
        }
        .auto-style16 {
            width: 206px;
            height: 24px;
            text-align: left;
        }
        .auto-style17 {
            width: 152px;
            height: 24px;
            text-align: center;
        }
        .auto-style18 {
            width: 152px;
            text-align: center;
        height: 30px;
            margin-left: 40px;
        }
        .auto-style19 {
            height: 23px;
            width: 152px;
            text-align: center;
        }
    .auto-style20 {
        height: 26px;
    }
    .auto-style21 {
        width: 206px;
        height: 26px;
    }
    .auto-style22 {
        width: 152px;
        text-align: center;
        height: 26px;
    }
    .auto-style23 {
        height: 30px;
    }
    .auto-style24 {
        width: 206px;
        height: 30px;
    }
        .auto-style25 {
            height: 89px;
        }
        .auto-style26 {
            width: 206px;
            height: 89px;
        }
        .auto-style27 {
            width: 152px;
            height: 89px;
        }
        .auto-style28 {
            width: 206px;
            height: 23px;
            text-align: center;
        }
        .auto-style29 {
            width: 206px;
            text-decoration: none;
            text-align: center;
        }
        .auto-style30 {
            text-align: center;
        }
        .auto-style31 {
            height: 26px;
            text-align: center;
        }
        .auto-style32 {
            height: 23px;
            text-align: center;
        }
        .auto-style33 {
            height: 30px;
            text-align: center;
        }
        .auto-style34 {
            margin-right: 0px;
        }
        .auto-style35 {
            height: 89px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style29">
                <asp:Label ID="Label9" runat="server" Text="Productos en bodega."></asp:Label>
            </td>
            <td class="auto-style13">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style10">
                <div class="auto-style30">
                <asp:GridView ID="GV_ProductosBodega" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="ReferenciaProducto" HeaderText="ReferenciaProducto" SortExpression="ReferenciaProducto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                        <asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                        <asp:BoundField DataField="Idproducto" HeaderText="Idproducto" SortExpression="Idproducto" />
                        <asp:BoundField DataField="Entregado" HeaderText="Entregado" SortExpression="Entregado" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                </div>
                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="Productos" TypeName="DAOUsuario"></asp:ObjectDataSource>
            </td>
            <td class="auto-style13">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:Label ID="Label10" runat="server" Text="Asignaciones pendientes."></asp:Label>
                <asp:Label ID="L_CantidadPendientes" runat="server"></asp:Label>
            </td>
            <td class="auto-style28">
                <asp:Label ID="Label11" runat="server" Text="Detalle del Pedido"></asp:Label>
            </td>
            <td class="auto-style14">
                &nbsp;</td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:GridView ID="GV_Pedido" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource5" OnSelectedIndexChanged="GV_Pedido_SelectedIndexChanged" OnRowCommand="GV_Pedido_RowCommand" PageSize="5">
                    <Columns>
                        <asp:TemplateField HeaderText="Seleccionar" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar" CommandArgument='<%# Bind("idpedido") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IdPedido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idpedido") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("idpedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sede">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("sede") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("sede") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fecha") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="verPedido" TypeName="DAOUsuario"></asp:ObjectDataSource>
            </td>
            <td class="auto-style28">
                <asp:GridView ID="GV_Pedidos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="Seleccione un pedido para ver su detalle." Width="326px">
                    <Columns>
                        <asp:TemplateField HeaderText="Referencia">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("referencia") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Referencia" runat="server" Text='<%# Bind("referencia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Talla">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("talla") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Talla" runat="server" Text='<%# Bind("talla") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </td>
            <td class="auto-style19">
                &nbsp;</td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style15"></td>
            <td class="auto-style16">
                <asp:Button ID="Button3" runat="server" Text="Validar" OnClick="Button2_Click" />
                <asp:Label ID="Label12" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Label14" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Button ID="Button2" runat="server" Text="Asignar" Enabled="False" OnClick="Button2_Click1" />
                <asp:Label ID="Label17" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="auto-style17">
                &nbsp;</td>
            <td class="auto-style15"></td>
        </tr>
        <tr>
            <td class="auto-style31">
                &nbsp;</td>
            <td class="auto-style21">
            </td>
            <td class="auto-style22">
            </td>
            <td class="auto-style20"></td>
        </tr>
        <tr>
            <td class="auto-style32">
                <asp:Label ID="Label15" runat="server" Text="Asignación Sin Pedido"></asp:Label>
            </td>
            <td class="auto-style12">
                &nbsp;</td>
            <td class="auto-style19">
                &nbsp;</td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style33">
                <asp:GridView ID="GV_AsignarSinPedido" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style34" DataSourceID="ObjectDataSource1" PageSize="5">
                    <Columns>
                        <asp:TemplateField HeaderText="Referencia">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ReferenciaProducto") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Referencia" runat="server" Text='<%# Bind("ReferenciaProducto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Talla">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Talla" runat="server" Text='<%# Bind("Talla") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="TB_Cantidad" runat="server" MaxLength="3">0</asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Productos" TypeName="DAOUsuario"></asp:ObjectDataSource>
            </td>
            <td class="auto-style24">&nbsp;</td>
            <td class="auto-style18">
                &nbsp;</td>
            <td class="auto-style23"></td>
        </tr>
        <tr>
            <td class="auto-style32">
                <asp:Label ID="Label16" runat="server" Text="Sede"></asp:Label>
            </td>
            <td class="auto-style28">
                <asp:DropDownList ID="DL_Sedes" runat="server" DataSourceID="ObjectDataSource3" DataTextField="NombreSede" DataValueField="NombreSede" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="Sedes" TypeName="DAOUsuario"></asp:ObjectDataSource>
                </td>
            <td class="auto-style14"></td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:Button ID="B_Asignar" runat="server" OnClick="B_Asignar_Click" Text="Asignar" />
            </td>
            <td class="auto-style26">
                </td>
            <td class="auto-style27"></td>
            <td class="auto-style25"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

