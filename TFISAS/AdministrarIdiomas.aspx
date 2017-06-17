<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AdministrarIdiomas.aspx.vb" Inherits="TFISAS.ListaModificarIdioma" %>

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
                        <asp:Label ID="lbl_AdministrarIdiomas" runat="server">Administrar Idiomas</asp:Label>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <asp:GridView ID="gv_Idiomas" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Idiomas_PageIndexChanging" RowStyle-Height="30px">
                                <PagerTemplate>
                                    <div class="control-label right">
                                        <asp:Label ID="lbl_pagina" runat="server" Text="Pagina" CssClass="margenPaginacion"></asp:Label>
                                        <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                    </div>
                                </PagerTemplate>
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Editable" HeaderText="Editable" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="col-md-2  margenIconoMensaje ">
                                                <asp:ImageButton ID="btn_Editar" runat="server" OnCommand="btn_Editar_Command" ImageUrl="~/Imagenes/edit.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                            </div>
                                            <div class="col-md-2 col-md-offset-2 margenIconoMensaje">
                                                <asp:ImageButton ID="btn_Eliminar" runat="server" OnClientClick="return confirmDel();" ImageUrl="~/Imagenes/delete.png" OnClick="btn_Eliminar_Click" Height="20px" CommandArgument='<%#Eval("ID")%>' />
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
