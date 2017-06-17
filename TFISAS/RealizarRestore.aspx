<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="RealizarRestore.aspx.vb" Inherits="TFISAS.RealizarRestore" %>
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
            <div class="col-md-8 col-md-offset-2">
                <div class="panel panel-verde">
                    <div class="panel-heading">
                        <asp:Label ID="lblPanelRestore" runat="server" Text="Realizar Restore"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <br />
                        <br />
                        <div class="form-horizontal">
                            <div class="form-group">
                                <asp:Label ID="lbl_Archivo" runat="server" Text="Archivo:" CssClass="col-sm-4 control-label labelStyle"></asp:Label>
                                <div class="col-sm-7">
                                    <asp:FileUpload ID="flu" runat="server" />
                                </div>
                                <div class="col-sm-1">
                                    <asp:RequiredFieldValidator ID="rfv_flu" runat="server" ControlToValidate="flu" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-md-3 col-md-offset-3">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-block btn-success" />
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-warning" CausesValidation="false"/>
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
