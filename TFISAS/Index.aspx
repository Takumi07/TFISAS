<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Index.aspx.vb" Inherits="TFISAS.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">

    <div class="row">
        <div class="col-xs-6 col-xs-offset-4">
            <div class="center-block">
                <!--<asp:Image ID="img_bienvenidos" ImageUrl="imagenes/Bienvenidos.png" CssClass="img-responsive" runat="server" />-->
                <asp:Label ID="lbl_Bienvenidos" runat="server" CssClass="form-group Titulo" Text="Bienvenidos"></asp:Label>
            </div>
        </div>

    </div>

    <br />
    <br />
    <div class="row">
        <div class="col-xs-6 col-md-6">
            <a href="PromocionesProductos.aspx" class="thumbnail">
                <asp:Image ID="ImgProdPromo" ImageUrl="imagenes/GokuShenLong.png" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_Promociones" runat="server" CssClass="form-group" Text="Promociones Por Producto"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>


        <div class="col-xs-6 col-md-6" id="registrarse" runat="server">
            <a href="Registrarse.aspx" class="thumbnail">
                <asp:Image ID="Image1" ImageUrl="imagenes/registrarse.jpg" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_registrate" runat="server" CssClass="form-group" Text="¡Regístrate!"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>

        <div class="col-xs-6 col-md-6">
            <a href="promocionesclientes.aspx" class="thumbnail">
                <asp:Image ID="ImgPromoCliente" ImageUrl="imagenes/tuspromos.jpg" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_PromoClientes" runat="server" CssClass="form-group" Text="¡Tus propias promociones!"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>
    </div>


    <br />
    <br />
    <br />
    <br />
</asp:Content>
