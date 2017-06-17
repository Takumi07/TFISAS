<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Mensajes.aspx.vb" Inherits="TFISAS.Mensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <br />
    <br />
    <br />
    <div class="row">
        <div id="divMensaje" class="text-center col-md-12" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <asp:Image ID="img_error" runat="server" CssClass="" ImageUrl="~/Imagenes/success.png" Width="250px" Height="250px" />
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lbl_Mensaje" runat="server" CssClass="labelStyle" Font-Size="XX-Large"></asp:Label>
                </div>
            </div>
        </div>

        <div id="divError" class="text-center col-md-12" runat="server" visible="false">
            <div class="row">
                <div class="col-md-12">
                    <asp:Image ID="Image1" runat="server" CssClass="" ImageUrl="~/Imagenes/error.png" Width="250px" Height="250px" />
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lbl_MensajeError" runat="server" CssClass="labelStyle" Font-Size="XX-Large"></asp:Label>
                </div>
            </div>
        </div>
        <div id="divErrorSQL" class="text-center col-md-12" runat="server" visible="false">
            <div class="row">
                <div class="col-md-12">
                    <asp:Image ID="Image2" runat="server" CssClass="" ImageUrl="~/Imagenes/noConect.png" Width="512px" Height="369px" />
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lbl_SQLError" runat="server" CssClass="labelStyle" Font-Size="XX-Large"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
