<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="EliminarUsuario.aspx.vb" Inherits="TFISAS.EliminarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmDel() {
            var myValue = "<%=mensajeConfirmacion%>";
            var agree = confirm(myValue);
            if (agree) return true;
            else return false;
        }
    </script>
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
                        <asp:Label ID="lbl_EliminarUsuario" runat="server">Eliminar Usuario</asp:Label>
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
                                                <asp:ImageButton ID="btn_Eliminar" runat="server" OnClick="btn_Eliminar_Click" OnClientClick="return confirmDel();" ImageUrl="~/Imagenes/delete.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
