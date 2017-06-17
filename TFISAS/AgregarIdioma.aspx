<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AgregarIdioma.aspx.vb" Inherits="TFISAS.AgregarIdioma" %>

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
                        <asp:Label ID="lbl_AgregarIdioma" runat="server" Text="Agregar Idioma"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-5 col-md-offset-1">
                                <div class="control-label">
                                    <asp:Label ID="lbl_Nombre" runat="server">Nombre</asp:Label>
                                    <asp:RequiredFieldValidator ID="rfv_lbl_nombre" runat="server" ErrorMessage="*" ControlToValidate="txt_NombreIdioma" EnableClientScript="false" Display="Dynamic" CssClass="labelRojo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:TextBox ID="txt_NombreIdioma" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-5 col-md-offset-1">
                                <asp:Label ID="lbl_cultura" runat="server" CssClass="control-label">Cultura</asp:Label>
                            </div>
                            <div class="col-md-4 col-md-offset-1">
                                <asp:DropDownList ID="ddl_cultura" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <br />



                        <asp:GridView ID="gv_Palabras" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="20" OnPageIndexChanging="gv_Palabras_PageIndexChanging">
                            <PagerTemplate>
                                <div class="label right">
                                    <asp:Label ID="lbl_pagina" runat="server" Text="Pagina" CssClass="margenPaginacion"></asp:Label>
                                    <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                </div>
                            </PagerTemplate>
                            <Columns>
                                <asp:BoundField DataField="ID_Control" HeaderText="ID" />
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                <asp:BoundField DataField="Traduccion" HeaderText="Traduccion" />
                                <asp:TemplateField HeaderText="Nuevo Texto" HeaderStyle-Width="400px">
                                    <ItemTemplate>
                                        <asp:TextBox Width="350px" ID="txt_NuevoTexto" runat="server" CssClass="textarea" TextMode="MultiLine" Wrap="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="350px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <br />
                        <br />

                        <div class="row">
                            <div id="Aceptar" visible="true" runat="Server" class="col-md-3 col-md-offset-3">
                                <asp:Button ID="btn_Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-block btn-success" />
                            </div>
                            <div id="modificar" visible="false" runat="Server" class="col-md-3 col-md-offset-3">
                            <asp:Button ID="btn_Modificar" runat="server" Text="Modificar" CssClass="btn btn-block btn-success" />
                            </div>
                                <div class="col-md-3">
                                <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-warning" CausesValidation="false" />
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
