<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="VisualizarStock.aspx.vb" Inherits="TFISAS.VisualizarStock" %>

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
                        <asp:Label ID="lbl_ProductosStock" runat="server">Stock de Productos</asp:Label>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <asp:GridView ID="gv_Productos" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="30" OnPageIndexChanging="gv_Productos_PageIndexChanging" RowStyle-Height="30px">
                                <PagerTemplate>
                                    <div class="control-label right">
                                        <asp:Label ID="lbl_pagina" runat="server" Text="Pagina" CssClass="margenPaginacion Negrita"></asp:Label>
                                        <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                    </div>
                                </PagerTemplate>
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Genero.Descripcion" HeaderText="Genero" />
                                    <asp:BoundField DataField="TipoProducto.Descripcion" HeaderText="Tipo" />
                                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                </Columns>
                            </asp:GridView>
                        </div>

                        <br />
                        <br />
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button ID="btn_Volver" runat="server" Text="Volver" CssClass="btn btn-block btn-info" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
