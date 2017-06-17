<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="CambiarContraseña.aspx.vb" Inherits="TFISAS.CambiarContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <br />
    <div class="container-fluid">
        <br />
        <div class="row">
            <div id="divError" class="mensaje-error col-md-12" runat="server" visible="false">
                <asp:Label ID="lbl_Error" runat="server" CssClass="label">Esto es una prueba de error.</asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-verde">
                    <div class="panel-heading">
                        <asp:Label ID="lblPanelCambioContraseña" runat="server" Text="Cambiar Contraseña"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <br />
                        <br />
                        <div class="form-horizontal">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="form-group">
                                    <asp:Label ID="lbl_password" class="control-label Negrita" runat="server" Text="Password"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rev_passwordd" ControlToValidate="txt_password" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txt_password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lbl_ConfirmarPassword" class="control-label Negrita" runat="server" Text="Confirmar Password"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rev_confirmarpassword" ControlToValidate="txt_confirmarPassword" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txt_confirmarPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-3 col-md-offset-3">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-block btn-success" />
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-warning" CausesValidation="false" />
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
                <br />
            </div>
        </div>
    </div>

</asp:Content>
