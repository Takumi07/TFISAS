<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Institucional.aspx.vb" Inherits="TFISAS.Institucional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">



    <div class="row">





        <div class="col-xs-4 col-md-4">
            <br />
            <asp:Image ID="ImgFiguras" ImageUrl="imagenes/DBZEmpresa.jpg" CssClass="img-responsive" runat="server" />
            <br />
        </div>

        <div class="col-xs-8 col-md-8">
            <div class="caption text-center">
                <h2>
                    <asp:Label ID="lbl_NuestraEmpresa" runat="server" CssClass="form-group"></asp:Label>
                </h2>
            </div>
            <div class="text-justify">
                
                    <asp:Label ID="lbl_DescripcionEmpresa" runat="server" CssClass="form-group"></asp:Label>
               
            </div>
        </div>


    </div>



</asp:Content>
