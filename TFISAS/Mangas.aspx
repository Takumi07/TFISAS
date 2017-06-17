<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Mangas.aspx.vb" Inherits="TFISAS.Mangas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="container">
        <div class="row">
            <asp:Panel ID="panelProductos" runat="server">
                <div class="col-sm-10 col-sm-offset-1">
                    <div class="features_items">
                        <!--Producto 1-->
                        <div id="producto1" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_1" runat="server" OnClick="img_producto_1_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_1" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_1" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_1" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_1" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                        <br />
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 1 -->
                        <!--Producto 2-->
                        <div id="producto2" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_2" runat="server" OnClick="img_producto_2_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_2" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_2" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_2" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_2" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 2 -->
                        <!--Producto 3-->
                        <div id="producto3" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_3" runat="server" OnClick="img_producto_3_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_3" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_3" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_3" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_3" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 3 -->
                        <!--Producto 4-->
                        <div id="producto4" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_4" runat="server" OnClick="img_producto_4_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_4" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_4" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_4" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_4" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 4 -->
                        <!--Producto 5-->
                        <div id="producto5" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_5" runat="server" OnClick="img_producto_5_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_5" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_5" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_5" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_5" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 5 -->
                        <!--Producto 6-->
                        <div id="producto6" runat="server">

                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_6" runat="server" OnClick="img_producto_6_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_6" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_6" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_6" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_6" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 6 -->
                        <!--Producto 7-->
                        <div id="producto7" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_7" runat="server" OnClick="img_producto_7_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_7" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_7" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_7" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_7" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 7 -->
                        <!--Producto 8-->
                        <div id="producto8" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_8" runat="server" OnClick="img_producto_8_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_8" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_8" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_8" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_8" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 8 -->
                        <!--Producto 9-->
                        <div id="producto9" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_9" runat="server" OnClick="img_producto_9_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_9" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_9" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_9" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_9" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 9 -->
                        <!--Producto 10-->
                        <div id="producto10" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_10" runat="server" OnClick="img_producto_10_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_10" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_10" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_10" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_10" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 10 -->
                        <!--Producto 11-->
                        <div id="producto11" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_11" runat="server" OnClick="img_producto_11_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_11" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_11" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_11" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_11" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 11 -->
                        <!--Producto 12-->
                        <div id="producto12" runat="server">
                            <div class="col-sm-4">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <br />
                                            <asp:ImageButton ID="img_producto_12" runat="server" OnClick="img_producto_12_Click" CssClass="img-responsive img-lista-producto" />
                                            <asp:Label ID="lbl_Precio_12" runat="server" CssClass="label-precio"></asp:Label>
                                            <asp:HiddenField ID="hf_12" runat="server" />
                                            <br />
                                            <asp:Label ID="lbl_Descripcion_12" runat="server" CssClass="label-descripcion"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Button ID="btn_agregar_12" runat="server" Text="Agregar al Carrito" CssClass="btn btn-naranja" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <!-- Fin Producto 12 -->
                    </div>
                    <div class="col-sm-2 col-sm-offset-10">
                        <asp:DropDownList ID="ddl_paginacion" runat="server" CssClass="dropdown" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
