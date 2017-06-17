<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="RealizarBackup.aspx.vb" Inherits="TFISAS.RealizarBackup" %>

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
                        <asp:Label ID="lblPanelBackup" runat="server" Text="Realizar Backup"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <br />
                        <br />
                        <div class="form-horizontal">
                            <div class="form-group">
                                <asp:Label ID="lbl_Nombre" runat="server" Text="Nombre:" CssClass="col-sm-4 control-label labelStyle"></asp:Label>
                                <div class="col-sm-6">
                                        <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-1">
                                    <asp:RequiredFieldValidator ID="rfv_txt_nombre" runat="server" ControlToValidate="txt_nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">

                                <asp:Label ID="lbl_Directorio" runat="server" Text="Directorio:" CssClass="col-sm-4 control-label labelStyle"></asp:Label>
                                <div class="col-sm-6">
                                        <asp:TextBox ID="txt_directorio" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-sm-1">
                                    <asp:RequiredFieldValidator ID="rfv_txt_directorio" runat="server" ControlToValidate="txt_directorio" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
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
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-warning"  CausesValidation="false"/>
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
