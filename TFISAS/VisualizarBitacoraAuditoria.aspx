<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="VisualizarBitacoraAuditoria.aspx.vb" Inherits="TFISAS.VisualizarBitacoraAuditoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JS/jquery-1.9.1.min.js"></script>
    <script src="JS/jquery-ui.js"></script>
    <link href="CSS/DateTimePicker.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $("#ContenidoPagina_txt_FechaDesde").datepicker();
        });
        $(function () {
            $("#ContenidoPagina_txt_FechaHasta").datepicker();
        });
    </script>
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
                        <asp:Label ID="lbl_BitacoraAuditoria" runat="server" Text="Bitacora Auditoria"></asp:Label>
                    </div>
                    <div class="panel-body" id="lista" runat="server" visible="true">
                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Label ID="lbl_Usuario_b" class="control-label Negrita" runat="server" Text="Usuario"></asp:Label>
                                    <asp:DropDownList ID="ddl_usuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>

                                <div class="col-sm-4">
                                    <asp:Label ID="lbl_operacion" class="control-label Negrita" runat="server" Text="Tipo de Operación"></asp:Label>
                                    <asp:DropDownList ID="ddl_operacion" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Label ID="lbl_FechaDesde" class="control-label Negrita" runat="server" Text="Fecha Desde"></asp:Label>
                                    <div class='input-group date'>
                                        <asp:TextBox ID="txt_FechaDesde" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="lbl_FechaHasta" class="control-label Negrita" runat="server" Text="Fecha Hasta"></asp:Label>
                                    <div class='input-group date'>
                                        <asp:TextBox ID="txt_FechaHasta" runat="server" class="form-control" data-provide="datepicker"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-4 col-sm-offset-4">
                                <div id="Aceptar" visible="true" runat="Server" >
                                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-block btn-success" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <asp:GridView ID="gv_BitacoraAuditoria" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="20" OnPageIndexChanging="gv_BitacoraAuditoria_PageIndexChanging">
                            <PagerTemplate>
                                <div class="label right">
                                    <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                </div>
                            </PagerTemplate>
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Usuario.NombreUsuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="TipoOperacion" HeaderText="Tipo de Operacion" />
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

                    <div class="panel-body" id="BitacoraA" runat="server" visible="false">
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
                                    <div class="col-sm-12">
                                        <asp:Label ID="lbl_Descripcion" class="control-label Negrita" runat="server" Text="Descripción"></asp:Label>
                                        <asp:TextBox ID="txt_descripcion" class="form-control" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                    </div>
                                </div>
                                <br />




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
