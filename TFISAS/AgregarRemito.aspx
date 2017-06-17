<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AgregarRemito.aspx.vb" Inherits="TFISAS.AgregarRemito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JS/jquery-1.9.1.min.js"></script>
    <script src="JS/jquery-ui.js"></script>
    <link href="CSS/DateTimePicker.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $("#ContenidoPagina_txt_FechaRemito").datepicker();
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
                        <asp:Label ID="lbl_AgregarRemito" runat="server" Text="Agregar Remito"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12 col-md-offset-2">
                            <div class="form-horizontal" role="form">
                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_NRemito" class="control-label Negrita" runat="server" Text="Nro Remito"></asp:Label>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_nroremito"
                                            ControlToValidate="txt_nroRemito"
                                            Display="Dynamic"
                                            runat="server"
                                            CssClass="labelRojo"
                                            SetFocusOnError="True"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rav_nroRemito"
                                            runat="server"
                                            ErrorMessage="*"
                                            MinimumValue="1"
                                            MaximumValue="999999999"
                                            ControlToValidate="txt_nroRemito"
                                            CssClass="labelRojo"></asp:RangeValidator>
                                        <asp:TextBox ID="txt_nroRemito" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_FechaRemito" class="control-label Negrita" runat="server" Text="Fecha Remito"></asp:Label>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_FechaRemito"
                                            ControlToValidate="txt_FechaRemito"
                                            Display="Dynamic"
                                            runat="server"
                                            CssClass="labelRojo"
                                            SetFocusOnError="True"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <div class='input-group date'>
                                            <asp:TextBox ID="txt_FechaRemito" runat="server" class="form-control" data-provide="datepicker"></asp:TextBox>
                                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-8">
                                        <asp:Label ID="lbl_Proveedor" class="control-label Negrita" runat="server" Text="Proveedor"></asp:Label>
                                        <asp:DropDownList ID="ddl_Proveedor" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Producto" class="control-label Negrita" runat="server" Text="Producto"></asp:Label>
                                        <asp:DropDownList ID="ddl_Producto" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Label ID="lbl_Cantidad" class="control-label Negrita" runat="server" Text="Cantidad"></asp:Label>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_cantidad"
                                            ControlToValidate="txt_cantidad"
                                            Display="Dynamic"
                                            runat="server"
                                            CssClass="labelRojo"
                                            SetFocusOnError="True"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rav_txt_cantidad"
                                            runat="server"
                                            ErrorMessage="*"
                                            MinimumValue="1"
                                            MaximumValue="999999999"
                                            ControlToValidate="txt_cantidad"
                                            CssClass="labelRojo"></asp:RangeValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_precioVenta"
                                            runat="server"
                                            Display="Dynamic"
                                            CssClass="labelRojo"
                                            SetFocusOnError="True"
                                            Text="*"
                                            ControlToValidate="txt_cantidad"
                                            ValidationExpression="^[0-9]+$"
                                            ErrorMessage="*" />
                                        <asp:TextBox ID="txt_cantidad" class="form-control" runat="server"></asp:TextBox>

                                    </div>
                                    <div class="col-sm-2">
                                        <br />
                                        <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-block btn-info" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-8">
                                        <asp:GridView ID="gv_Remito" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" RowStyle-Height="20px">
                                            <Columns>
                                                <asp:BoundField DataField="NroRenglon" HeaderText="Renglon" />
                                                <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <div class="col-md-3 col-md-offset-2 margenIconoMensaje">
                                                            <asp:ImageButton ID="btn_Eliminar" runat="server" OnCommand="btn_Eliminar_Command" ImageUrl="~/Imagenes/delete.png" Height="20px" CausesValidation="false" CommandArgument='<%#Eval("NroRenglon")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <div class="col-sm-2 col-sm-offset-2">
                                        <asp:Button ID="btn_Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-block btn-success" CausesValidation="false" />
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-warning" CausesValidation="false" />
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
    </div>

</asp:Content>
