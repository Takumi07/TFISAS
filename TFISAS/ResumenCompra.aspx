<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="ResumenCompra.aspx.vb" Inherits="TFISAS.ResumenCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">

    <asp:HiddenField ID="hf_subtotal" runat="server" />
    <asp:HiddenField ID="hf_total" runat="server" />
    <asp:HiddenField ID="hf_descuentos" runat="server" />
    <div class="container">
        <br />
        <br />
        <br />

        <div class="col-xs-6 col-md-6 col-md-offset-3" id="carrito_vacio" runat="server">
            <a href="NuestrosProductos.aspx" class="thumbnail">
                <div class="caption text-center">
                    <h2>
                        <asp:Label ID="lbl_CarritoVacio" runat="server" CssClass="form-group" Text="Por el momento el carrito de compras esta vacío."></asp:Label>
                    </h2>
                </div>
                <asp:Image ID="Image1" ImageUrl="imagenes/CompraVacia.jpg" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_Continuacomprando" runat="server" CssClass="form-group" Text="¡Continúa Comprando!"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>








        <br />
        <br />
        <div id="carrito_lleno" runat="server" visible="false">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gv_carrito" runat="server" AutoGenerateColumns="False" CssClass="Grid-verde">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="img_producto" runat="server" Height="120px"></asp:Image>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Producto">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombre" ControlStyle-Width="40%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Nombre" runat="server" Text="Label" CssClass="label-titulo-small"></asp:Label>
                                    <asp:HiddenField ID="ID" runat="server" />
                                </ItemTemplate>
                                <ControlStyle Width="100%"></ControlStyle>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad" ControlStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Cantidad" runat="server" Text="Label" CssClass="label-titulo-small"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actualizar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="Actualizar_cantidad_Menos" runat="server" Height="20px" Width="20px" CausesValidation="False" ImageUrl="~/IMAGENES/minus.ico" OnClick="Actualizar_cantidad_Menos_Click" CommandArgument='<%#Eval("ID")%>'></asp:ImageButton>
                                    <asp:ImageButton ID="Actualizar_Cantidad" runat="server" Height="20px" Width="20px" CausesValidation="False" ImageUrl="~/IMAGENES/plus.ico" OnClick="Actualizar_Cantidad_Click" CommandArgument='<%#Eval("ID")%>'></asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio" ControlStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Precio" runat="server" Text="Label" CssClass="label-titulo-small"></asp:Label>
                                </ItemTemplate>

                                <ControlStyle Width="100%"></ControlStyle>

                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock" ControlStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Stock" runat="server" Text="Label" CssClass="label-titulo-small"></asp:Label>
                                </ItemTemplate>

                                <ControlStyle Width="100%"></ControlStyle>

                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Quitar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="eliminar_producto" runat="server" Height="20px" CausesValidation="False" ImageUrl="~/IMAGENES/delete.png" OnClick="eliminar_producto_Click" CommandArgument='<%#Eval("ID")%>'></asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>



                        </Columns>
                    </asp:GridView>
                </div>
            </div>


            <!--FIN DEL CARRITO DE COMPRA NORMAL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!--->
            <br />
            <br />

            <!--INICIO DEL CARRITO DE COMRPA DE PROMOCIONES!!!-->

            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gv_carritop" runat="server" AutoGenerateColumns="False" CssClass="Grid-verde">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="img_productop" runat="server" Height="120px"></asp:Image>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Producto">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombre" ControlStyle-Width="40%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Nombrep" runat="server" Text="Label" CssClass="label-titulo-small"></asp:Label>
                                    <asp:HiddenField ID="IDP" runat="server" />
                                </ItemTemplate>
                                <ControlStyle Width="100%"></ControlStyle>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad" ControlStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_CantidadP" runat="server" Text="Label" CssClass="label-titulo-small"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actualizar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="Actualizar_cantidad_Menos_Promo" runat="server" Height="20px" Width="20px" CausesValidation="False" ImageUrl="~/IMAGENES/minus.ico" OnClick="Actualizar_cantidad_Menos_Promo_Click" CommandArgument='<%#Eval("ID")%>'></asp:ImageButton>
                                    <asp:ImageButton ID="Actualizar_Cantidad_Promo" runat="server" Height="20px" Width="20px" CausesValidation="False" ImageUrl="~/IMAGENES/plus.ico" OnClick="Actualizar_Cantidad_Promo_Click" CommandArgument='<%#Eval("ID")%>'></asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio" ControlStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Preciop" runat="server" Text="Label" CssClass="label-titulo-small"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100%"></ControlStyle>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Descuento" ControlStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_DescuentoP" runat="server" Text="label" CssClass="label-titulo-small"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100%"></ControlStyle>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock" ControlStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Stockp" runat="server" Text="Label" CssClass="label-titulo-small"></asp:Label>
                                </ItemTemplate>

                                <ControlStyle Width="100%"></ControlStyle>

                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Quitar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="eliminar_producto_promo" runat="server" Height="20px" CausesValidation="False" ImageUrl="~/IMAGENES/delete.png" OnClick="eliminar_producto_promo_Click" CommandArgument='<%#Eval("ID")%>'></asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>



                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <!-- FIN DEL CARRITO DE COMPRAS DE PROMOCIONES-->



            <br />
            <br />
            <div class="row">
                <div class="col-sm-4 col-sm-offset-4">
                    <div class="table-responsive">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="label-titulo-small">
                                        <asp:Label ID="lbl_TotalCarrito" runat="server" Text="Total del Carrito:"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbl_Subtotal" runat="server" Text="" CssClass="label-precio-small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label-titulo-small">
                                        <asp:Label ID="lbl_DescCarrito" runat="server" Text="Descuentos:"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbl_descuentos" runat="server" Text="" CssClass="label-precio-small"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="label-titulo-small">
                                        <asp:Label ID="lbl_TotalCompra" runat="server" Text="Total de Compra:"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbl_Total" runat="server" Text="" CssClass="label-precio-small"></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                        <asp:Button ID="btn_Confirmar" runat="server" Text="Confirmar Pedido" CssClass="btn btn-success center-block" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
    </div>




</asp:Content>
