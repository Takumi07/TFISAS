<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="ModificarPerfil.aspx.vb" Inherits="TFISAS.ModificarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">
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
                        <asp:Label ID="lbl_ModificacionPerfiles" runat="server">Modificarcion de Perfiles</asp:Label>
                    </div>
                    <div class="panel-body" id="listaperfiles" runat="server" visible="true">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">
                                <asp:GridView ID="gv_Perfiles" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Perfiles_PageIndexChanging" RowStyle-Height="40px">
                                    <PagerTemplate>
                                        <div class="label right">
                                            <asp:Label ID="lbl_pagina" runat="server" Text="Pagina" CssClass="margenPaginacion"></asp:Label>
                                            <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                        </div>
                                    </PagerTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Perfil" />
                                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                    <asp:ImageButton ID="btn_Editar" runat="server" OnCommand="Editar_Command" ImageUrl="~/Imagenes/edit.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <!--Agrego otro panel body-->
                    <div class="panel-body" id="modificarperfiles" runat="server" visible="false">

                        <div class="panel-body">
                            <br />
                            <div class="row">
                                <div class="col-md-2 col-md-offset-1">
                                    <div class="control-label">
                                        <asp:Label ID="lbl_Nombre" runat="server">Nombre</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-5 col-md-offset-1">
                                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" MaxLength="100" ReadOnly="false"></asp:TextBox>
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
                                        <asp:Button ID="btn_Modificar" runat="server" Text="Modificar" CssClass="btn btn-success btn-block" />
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
    </div>
    <br />
    <br />
    <br />
    <br />






</asp:Content>
