<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="NuestrosProductos.aspx.vb" Inherits="TFISAS.NuestrosProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">

    <div class="row">
        <br />
        <div class="col-xs-4 col-md-4">
            <a href="Mangas.aspx" class="thumbnail">
                <asp:Image ID="ImgManga" ImageUrl="imagenes/manga.jpg" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_Manga" runat="server" CssClass="form-group" Text="Manga"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>

        <div class="col-xs-4 col-md-4">
            <a href="Productos.aspx" class="thumbnail">
                <asp:Image ID="ImgComics" ImageUrl="imagenes/comics.jpg" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_Comics"  runat="server" CssClass="form-group" Text="Comics"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>

        <div class="col-xs-4 col-md-4">
            <a href="Productos.aspx" class="thumbnail">
                <asp:Image ID="ImgFiguras" ImageUrl="imagenes/Figura.jpg" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_Figuras" runat="server" CssClass="form-group" Text="Figuras"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>
    </div>

    <div class="row">



        <div class="col-xs-6 col-md-4 col-md-offset-2">
            <a href="Productos.aspx" class="thumbnail">
                <asp:Image ID="ImgCosplay" ImageUrl="imagenes/Cosplay.jpg" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_Cosplay"  runat="server" CssClass="form-group" Text="Cosplay"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>


        <div class="col-xs-6 col-md-4">
            <a href="Productos.aspx" class="thumbnail">
                <asp:Image ID="ImgMerchandising" ImageUrl="imagenes/Merchandising.jpg" CssClass="img-responsive" runat="server" />
                <div class="caption text-center">
                    <h3>
                        <asp:Label ID="lbl_Merchandising"  runat="server" CssClass="form-group" Text="Merchandising"></asp:Label>
                    </h3>
                </div>
            </a>
        </div>

    </div>

</asp:Content>
