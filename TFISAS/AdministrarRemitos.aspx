<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AdministrarRemitos.aspx.vb" Inherits="TFISAS.AdministrarRemitos" %>

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
                        <asp:Label ID="lbl_AdministrarRemitos" runat="server">Administrar Remitos</asp:Label>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12 col-md-offset-2">
                            <div class="form-horizontal" role="form">
                                <div id="ListaRemtios" runat="server">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-8">
                                                    <asp:GridView ID="gv_Remito" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" RowStyle-Height="20px">
                                                        <Columns>
                                                            <asp:BoundField DataField="NroRemito" HeaderText="Nro Remito" />
                                                            <asp:BoundField DataField="Proveedor.Nombre" HeaderText="Proveedor" />
                                                            <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emision" />
                                                            <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                                        <asp:ImageButton ID="btn_Seleccionar" runat="server" OnCommand="btn_Seleccionar_Command" ImageUrl="~/Imagenes/arrow.png" Height="20px" CausesValidation="false" CommandArgument='<%#Eval("NroRemito") & ";" & Eval("Proveedor.ID")%>' />
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

                                <div id="DetalleRemito" runat="server" visible="false">
                                    <div class="form-group">
                                        <div class="col-sm-4">
                                            <asp:Label ID="lbl_NRemito" class="control-label Negrita" runat="server" Text="Nro Remito"></asp:Label>
                                            <asp:TextBox ID="txt_nroRemito" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4">

                                            <asp:Label ID="lbl_FechaRemito" class="control-label Negrita" runat="server" Text="Fecha Remito"></asp:Label>
                                            <div class='input-group date'>
                                                <asp:TextBox ID="txt_FechaRemito" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-8">
                                            <asp:Label ID="lbl_Proveedor" class="control-label Negrita" runat="server" Text="Proveedor"></asp:Label>
                                            <asp:DropDownList ID="ddl_Proveedor" Enabled="false" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <br />
                                    <div class="form-group">
                                        <div class="col-sm-8">
                                            <asp:GridView ID="gv_remitoDetalle" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" RowStyle-Height="20px">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRenglon" HeaderText="Renglon" />
                                                    <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-2 col-sm-offset-2">
                                            <asp:Button ID="btn_Aprobar" runat="server" Text="Aprobar" CssClass="btn btn-block btn-info" CausesValidation="false" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btn_Rechazar" runat="server" Text="Rechazar" CssClass="btn btn-block btn-danger" CausesValidation="false" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>







</asp:Content>
