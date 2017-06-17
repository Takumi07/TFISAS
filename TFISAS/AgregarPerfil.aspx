<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AgregarPerfil.aspx.vb" Inherits="TFISAS.AgregarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">

    <br />
    <div class="container-fluid">
        <div class="row">
            <div id="divError" class="mensaje-error col-md-12" runat="server" visible="false">
                <asp:Label ID="lblMensajeError" runat="server" CssClass="label">Esto es una prueba de error.</asp:Label>
            </div>
        </div>
        <br />




        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-verde">
                    <div class="panel-heading">
                        <asp:Label ID="lbl_agregarPerfil" runat="server">Agregar Perfil</asp:Label>
                    </div>
                    <div class="panel-body">
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-md-offset-1">
                                <div class="control-label">
                                    <asp:Label ID="lbl_Nombre" runat="server">Nombre</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_nombre" runat="server"
                                    ControlToValidate="txt_nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="labelRojo"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-md-offset-1">
                                <div class="control-label">
                                    <asp:Label ID="lbl_Permisos" runat="server">Permisos</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                <asp:TreeView ID="treeviewPermisos" runat="server" ExpandDepth="0" ForeColor="Black" CssClass="control-label"></asp:TreeView>
                            </div>
                        </div>

                        <br />
                        <br />
                        <div id="agregar" runat="server">
                            <div class="row">
                                <div class="col-md-2 col-md-offset-3">
                                    <asp:Button ID="btn_Aceptar" runat="server" Text="Agregar" CssClass="btn btn-success btn-block" />
                                </div>
                                <div class="col-md-2 col-md-offset-2">
                                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-warning btn-block" CausesValidation="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>

</asp:Content>
