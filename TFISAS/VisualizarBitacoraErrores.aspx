<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="VisualizarBitacoraErrores.aspx.vb" Inherits="TFISAS.VisualizarBitacoraErrores" %>

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
                        <asp:Label ID="lbl_BitacoraErrores" runat="server" Text="Bitacora Errores"></asp:Label>
                    </div>
                    <div class="panel-body" id="lista" runat="server" visible="true">
                        <asp:GridView ID="gv_BitacoraErrores" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="20" OnPageIndexChanging="gv_BitacoraErrores_PageIndexChanging">
                            <PagerTemplate>
                                <div class="label right">
                                    <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                </div>
                            </PagerTemplate>
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Usuario.NombreUsuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="TipoOperacion" HeaderText="Tipo de Operacion" />
                                <asp:BoundField DataField="TipoException" HeaderText="Tipo de Excepción" />
                                <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" />
                                <asp:TemplateField HeaderText="Visualizar" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <div class="col-md-3 col-md-offset-2 margenGridBErrores">
                                            <asp:ImageButton ID="btn_seleccionar" runat="server" OnCommand="btn_seleccionar_Command" ImageUrl="~/Imagenes/arrow.png" Height="30px" CommandArgument='<%#Eval("ID")%>' />
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView> 
                        <br />
                        <br />
                    </div>

                    <div class="panel-body" id="bitacorae" runat="server" visible="false">
                        <div class="col-md-10 col-md-offset-1">
                            <div class="form-horizontal" role="form">
                                <div class="form-group">
                                    <div class="col-sm-6">
                                        <asp:Label ID="lbl_ID" class="control-label Negrita" runat="server" Text="Identificador"></asp:Label>
                                        <asp:TextBox ID="txt_ID" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="col-sm-6">
                                        <asp:Label ID="lbl_Usuario" class="control-label Negrita" runat="server" Text="Usuario"></asp:Label>
                                        <asp:TextBox ID="txt_usuario" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-6">
                                        <asp:Label ID="lbl_TipoOperacion" class="control-label Negrita" runat="server" Text="Tipo Operación"></asp:Label>
                                        <asp:TextBox ID="txt_tipooperacion" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label ID="lbl_fechahora" class="control-label Negrita" runat="server" Text="Fecha y Hora"></asp:Label>
                                        <asp:TextBox ID="txt_fechahora" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-6">
                                        <asp:Label ID="lbl_ip" class="control-label Negrita" runat="server" Text="IP"></asp:Label>
                                        <asp:TextBox ID="txt_ip" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label ID="lbl_webbrowser" class="control-label Negrita" runat="server" Text="Webbrowser"></asp:Label>
                                        <asp:TextBox ID="txt_webbrowser" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-6">
                                        <asp:Label ID="lbl_tipoExepcion" class="control-label Negrita" runat="server" Text="Tipo Exepción"></asp:Label>
                                        <asp:TextBox ID="txt_tipoExepcion" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:Label ID="lbl_stacktrace" class="control-label Negrita" runat="server" Text="Stack Trace"></asp:Label>
                                        <asp:TextBox ID="txt_stactrace" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:Label ID="lbl_Mensaje" class="control-label Negrita" runat="server" Text="Mensaje"></asp:Label>
                                        <asp:TextBox ID="txt_mensaje" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                    </div>
                                </div>
                                <br/>
                                <div class="form-group">
                                    <div class="col-sm-6 col-sm-offset-3">
                                        <asp:Button ID="btn_Volver" runat="server" Text="Volver" CssClass="btn btn-block btn-info" />
                                    </div>
                                </div>



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
