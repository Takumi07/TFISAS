<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="ModificarUsuarios.aspx.vb" Inherits="TFISAS.ModificarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">

    <div class="container-fluid">
        <br />
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
                        <asp:Label ID="lbl_ModificarUsuario" runat="server">Modificar Usuario</asp:Label>
                    </div>
                    <div class="panel-body" id="ListaUsuarios" runat="server" visible="true">
                        <div class="row">
                            <asp:GridView ID="gv_Usuarios" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Usuarios_PageIndexChanging" RowStyle-Height="40px">
                                <PagerTemplate>
                                    <div class="label right">
                                        <asp:Label ID="lbl_pagina" runat="server" Text="Pagina" CssClass="margenPaginacion"></asp:Label>
                                        <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                    </div>
                                </PagerTemplate>
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario" />
                                    <asp:BoundField DataField="Idioma.Nombre" HeaderText="Idioma" />
                                    <asp:BoundField DataField="Permiso.Nombre" HeaderText="Permiso" />
                                    <asp:BoundField DataField="Bloqueado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Editable" HeaderText="Editable" />
                                    <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                <asp:ImageButton ID="btn_Bloquear" runat="server" OnClick="btn_Bloquear_Click" ImageUrl="~/Imagenes/padlock-close.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                                <asp:ImageButton ID="btn_desbloqueo" runat="server" OnClick="btn_desbloqueo_Click" ImageUrl="~/Imagenes/padlock-open.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                            </div>
                                            <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                <asp:ImageButton ID="btn_editar" runat="server" OnCommand="btn_editar_Command" ImageUrl="~/Imagenes/edit.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <!--Agrego otro panel body-->
                    <div class="panel-body" id="modificarusuario" runat="server" visible="false">
                        <div class="col-md-11 col-md-offset-2">
                            <div class="form-horizontal" role="form">

                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_NombreUsuario" class="control-label Negrita" runat="server" Text="Nombre de Usuario"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfv_NombreUsuario" ControlToValidate="txt_NombreUsuario" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txt_NombreUsuario" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_correo" class="control-label Negrita" runat="server" Text="Correo"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfv_Correo" ControlToValidate="txt_correo" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txt_correo" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Nombre" class="control-label Negrita" runat="server" Text="Nombre"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfv_nombre" ControlToValidate="txt_Nombre" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txt_nombre" class="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Apellido" class="control-label Negrita" runat="server" Text="Apellido"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfv_apellido" ControlToValidate="txt_apellido" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txt_apellido" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Perfil" class="control-label Negrita" runat="server" Text="Perfil"></asp:Label>
                                        <asp:DropDownList ID="ddl_Perfil" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Idioma" class="control-label Negrita" runat="server" Text="Idioma"></asp:Label>
                                        <asp:DropDownList ID="ddl_idioma" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-4" style="margin-left: 22px">
                                        <b>
                                            <asp:CheckBox ID="chk_editarse" CssClass="checkbox" Text="¿Puede editarse?" runat="server" /></b>
                                    </div>
                                    <div class="col-sm-4" style="margin-left: -22px">
                                        <asp:Label ID="lbl_DNI" class="control-label Negrita" runat="server" Text="DNI"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfv_dni" ControlToValidate="txt_dni" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rv_txt_dni"
                                         runat="server"
                                         ErrorMessage="*"
                                         MinimumValue="1"
                                         MaximumValue="9999999999"
                                         ControlToValidate="txt_DNI"
                                         SetFocusOnError="true"
                                         CssClass="labelRojo"></asp:RangeValidator>
                                        <asp:TextBox ID="txt_dni" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>


                                <br />
                                <br />
                                <div class="form-group">
                                    <div class="col-md-2 col-md-offset-2">
                                        <asp:Button ID="btn_modificar" runat="server" Text="Modificar" CssClass="btn btn-success btn-block" />
                                    </div>
                                    <div class="col-md-2">
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
</asp:Content>
