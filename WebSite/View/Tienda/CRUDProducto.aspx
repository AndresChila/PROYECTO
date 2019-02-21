<%@ Page Title="" Language="C#" MasterPageFile="/View/Tienda/MasterSuperAdmin.master" AutoEventWireup="true" CodeFile="/Controller/Tienda/CRUDProducto.aspx.cs" Inherits="View_Tienda_CRUDProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style10 {
            margin-right: 26px;
        }
        .auto-style11 {
            height: 23px;
        }
    .auto-style12 {
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Referencia Producto"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_ReferenciaProducto" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Precio"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Precio" runat="server" MaxLength="6"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Cantidad"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Cantidad" runat="server" MaxLength="3"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Talla"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DL_Tallas" runat="server">
                        <asp:ListItem>Seleccione una talla</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>1.5</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>2.5</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>3.5</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>4.5</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>5.5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>6.5</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>7.5</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>8.5</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>9.5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>10.5</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>11.5</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Button ID="B_AgregarProducto" runat="server" OnClick="B_AgregarProducto_Click" style="margin-bottom: 0px" Text="Agregar" Width="66px" />
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:GridView ID="GV_Productos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource2" EmptyDataText="No hay productos ingresados." OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GV_Productos_RowCommand" CssClass="auto-style10" PageSize="4">
                        <Columns>
                            <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Editar" Text="Seleccionar" CommandArgument='<%# Bind("idproducto") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" CommandArgument='<%# Bind("idproducto") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Referencia Producto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("referenciaproducto") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("referenciaproducto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talla">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("talla") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("talla") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("precio") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("precio") %>'></asp:Label>
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
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="eliminarProducto" SelectMethod="verProductos" TypeName="DAOUsuario">
                        <DeleteParameters>
                            <asp:Parameter Name="idproducto" Type="Int32" />
                        </DeleteParameters>
                    </asp:ObjectDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style11">
                    <asp:Label ID="Label6" runat="server" Text="Editar Datos"></asp:Label>
                </td>
                <td class="auto-style11">
                    &nbsp;</td>
                <td class="auto-style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style11">
                    <asp:Label ID="Label11" runat="server" Text="Referencia Producto"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TB_EditarReferencia" runat="server" Enabled="False" MaxLength="10"></asp:TextBox>
                </td>
                <td class="auto-style11"></td>
            </tr>
        <tr>
                <td class="auto-style11"></td>
                <td class="auto-style11">
                    <asp:Label ID="Label12" runat="server" Text="Precio"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TB_EditarPrecio" runat="server" MaxLength="6"></asp:TextBox>
                </td>
                <td class="auto-style11"></td>
            </tr>
        <tr>
                <td class="auto-style11"></td>
                <td class="auto-style11">
                    <asp:Label ID="Label13" runat="server" Text="Cantidad"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TB_EditarCantidad" runat="server" MaxLength="3"></asp:TextBox>
                </td>
                <td class="auto-style11"></td>
            </tr>
        <tr>
                <td class="auto-style11"></td>
                <td class="auto-style11">
                    <asp:Label ID="Label14" runat="server" Text="Talla"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:DropDownList ID="DL_EditarTallas" runat="server" Enabled="False" EnableTheming="False">
                        <asp:ListItem>Seleccione una talla</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>1.5</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>2.5</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>3.5</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>4.5</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>5.5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>6.5</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>7.5</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>8.5</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>9.5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>10.5</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>11.5</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style12">
                    <asp:Button ID="B_EditarProducto" runat="server" Enabled="False" OnClick="B_EditarProducto_Click" Text="Actualizar" Width="130px" />
                    <asp:Button ID="B_Cancelar" runat="server" Enabled="False" OnClick="B_Cancelar_Click" Text="Cancelar" Width="116px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

