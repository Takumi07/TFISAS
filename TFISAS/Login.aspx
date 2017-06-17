<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Login.aspx.vb" Inherits="TFISAS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <br />
    <div class="container-fluid">
        <br />
        <div class="row">
            <div id="divError" class="mensaje-error col-md-12" runat="server" visible="false">
                <asp:Label ID="lblMensajeError" runat="server" CssClass="label">Esto es una prueba de error.</asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-verde">
                    <div class="panel-heading">
                        <asp:Label ID="lblPanelLogin" runat="server" Text="Autenticación"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <br />
                        <div class="form-horizontal">
                            <div class="form-group">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="col-sm-4 control-label labelStyle Negrita"></asp:Label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-user" aria-hidden="true"></span></span>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <asp:RequiredFieldValidator ID="RtxtUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">

                                <asp:Label ID="lblPassword" runat="server" Text="Contraseña:" CssClass="col-sm-4 control-label labelStyle Negrita"></asp:Label>
                                <div class="col-sm-6">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon" id="basic-addon2"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></span>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <asp:RequiredFieldValidator ID="RtxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-6">
                                    <asp:LinkButton ID="lnk_recupero" CssClass="Negrita" PostBackUrl="~/recuperarClave.aspx" runat="server">¿Olvidó su clave?</asp:LinkButton>
                                </div>
                            </div>
                        </div>

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
