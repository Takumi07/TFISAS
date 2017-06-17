<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="ODL_ProductosPromocionales.aspx.vb" Inherits="TFISAS.ProductosPromocionales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div class="row">
        <br />
        <br />
        <div class="col-sm-4 col-lg-4 col-md-4">
            <div class="thumbnail" id="thumbnail1" runat="server" visible="false" style="width: 300px; height: 700px; max-height: 700px; max-width: 400px;">
                <img src="" id="imagen1" alt="" runat="server" class="img-responsive" style="max-height: 350px; max-width: 350px;">
                <div class="caption">
                    <div class="col-md-12">
                        <h4>
                            <asp:Label ID="Nombre1" runat="server" CssClass="Negrita" Text="Label"></asp:Label>
                        </h4>
                        <!--<h5 class="pull-right" runat="server">-->
                        <asp:Label ID="PrecioOriginal1" runat="server" CssClass="pull-right" Text="Precio de Lista"></asp:Label>
                        <!--</h5>-->
                        <!--<h5 class="pull-right" runat="server">-->
                        <asp:Label ID="precio1" runat="server" CssClass="Negrita pull-right" Text="Precio Promocional"></asp:Label>
                        <!--</h5>-->
                        <!--<h5 class="pull-right" runat="server">-->
                        <div class="text-center">
                            <asp:Label ID="descuento1" CssClass="labelVerde" runat="server" Text="Descuento"></asp:Label>
                        </div>
                        <!--</h5>-->
                    </div>

                    <div>
                        <p runat="server" class="text-justify">
                            <asp:Label ID="Descripcion1" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                    <asp:Button ID="Button1" runat="server" CssClass="btn-info btn-block btn" Text="Comprar" />

                </div>
            </div>
        </div>
        <div class="col-sm-4 col-lg-4 col-md-4">
            <div class="thumbnail" id="thumbnail2" runat="server" visible="false" style="width: 300px; height: 900px; max-height: 900px; max-width: 400px;">
                <img src="" id="imagen2" alt="" runat="server" style="max-height: 300px; max-width: 300px;">
                <div class="caption">
                    <h4 class="pull-right" runat="server">
                        <asp:Label ID="precio2" runat="server" Text="Label"></asp:Label></h4>
                    <h4><a href="#" id="producto2" runat="server"></a></h4>
                    <h4>
                        <asp:Label ID="Nombre2" CssClass="Negrita" runat="server" Text="Label"></asp:Label></h4>
                    <p runat="server">
                        <asp:Label ID="Descripcion2" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>



        <div class="col-sm-4 col-lg-4 col-md-4">
            <div class="thumbnail" id="thumbnail3" runat="server" visible="false" style="width: 300px; height: 900px; max-height: 900px; max-width: 400px;">
                <img src="" id="imagen3" alt="" runat="server" style="max-height: 350px; max-width: 350px;">
                <div class="caption">
                    <h4 class="pull-right" runat="server">
                        <asp:Label ID="Precio3" runat="server" Text="Label"></asp:Label></h4>
                    <h4><a href="#" id="producto3" runat="server"></a></h4>
                    <h4>
                        <asp:Label ID="Nombre3" CssClass="Negrita" runat="server" Text="Label"></asp:Label></h4>
                    <p runat="server">
                        <asp:Label ID="Descripcion3" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-lg-4 col-md-4">
            <div class="thumbnail" id="thumbnail4" runat="server" visible="false" style="width: 300px; height: 900px; max-height: 900px; max-width: 400px;">
                <img src="" id="imagen4" alt="" runat="server" style="max-height: 350px; max-width: 350px;">
                <div class="caption">
                    <h4 class="pull-right" runat="server">
                        <asp:Label ID="precio4" runat="server" Text="Label"></asp:Label></h4>
                    <h4><a href="#" id="producto4" runat="server"></a></h4>
                    <h4>
                        <asp:Label ID="Nombre4" CssClass="Negrita" runat="server" Text="Label"></asp:Label></h4>
                    <p runat="server">
                        <asp:Label ID="Descripcion4" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>


        <div class="col-sm-4 col-lg-4 col-md-4">
            <div class="thumbnail" id="thumbnail5" runat="server" visible="false" style="width: 300px; height: 900px; max-height: 900px; max-width: 400px;">
                <img src="" id="imagen5" alt="" runat="server" style="max-height: 350px; max-width: 350px;">
                <div class="caption">
                    <h4 class="pull-right" runat="server">
                        <asp:Label ID="Precio5" runat="server" Text="Label"></asp:Label></h4>
                    <h4><a href="#" id="producto5" runat="server"></a></h4>
                    <h4>
                        <asp:Label ID="Nombre5" CssClass="Negrita" runat="server" Text="Label"></asp:Label></h4>
                    <p runat="server">
                        <asp:Label ID="Descripcion5" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-lg-4 col-md-4">
            <div class="thumbnail" id="thumbnail6" runat="server" visible="false" style="width: 300px; height: 900px; max-height: 900px; max-width: 400px;">
                <img src="" id="imagen6" alt="" runat="server" style="max-height: 350px; max-width: 350px;">
                <div class="caption">
                    <h4 class="pull-right" runat="server">
                        <asp:Label ID="precio6" runat="server" Text="Label"></asp:Label></h4>
                    <h4><a href="#" id="producto6" runat="server"></a></h4>
                    <h4>
                        <asp:Label ID="Nombre6" CssClass="Negrita" runat="server" Text="Label"></asp:Label></h4>
                    <p runat="server">
                        <asp:Label ID="Descripcion6" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
