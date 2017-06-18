<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="Registrarse.aspx.vb" Inherits="TFISAS.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JS/jquery-1.9.1.min.js"></script>
    <script src="JS/jquery-ui.js"></script>
    <link href="CSS/DateTimePicker.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $("#ContenidoPagina_txt_FechaNacimiento").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <br />
    <div class="container-fluid">
        <div class="row">
            <div id="divError" class="mensaje-error col-md-12" runat="server" visible="false">
                <asp:Label ID="lblMensajeError" runat="server" CssClass="label"></asp:Label>
            </div>
        </div>
        <br />
        <div class="col-md-10 col-md-offset-2">
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_NombreUsuario" class="control-label Negrita" runat="server" Text="Nombre de Usuario"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_NombreUsuario" ControlToValidate="txt_NombreUsuario" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_NombreUsuario" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-4">
                        <asp:Label ID="lbl_correo" class="control-label Negrita" runat="server" Text="Correo"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_Correo" ControlToValidate="txt_correo" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_correo" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_password" class="control-label Negrita" runat="server" Text="Password"></asp:Label>
                        <asp:RequiredFieldValidator ID="rev_passwordd" ControlToValidate="txt_password" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_ConfirmarPassword" class="control-label Negrita" runat="server" Text="Confirmar Password"></asp:Label>
                        <asp:RequiredFieldValidator ID="rev_confirmarpassword" ControlToValidate="txt_confirmarPassword" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_confirmarPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-sm-4">

                        <asp:Label ID="lbl_Nombre" class="control-label Negrita" runat="server" Text="Nombre"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_Nombre" ControlToValidate="txt_nombre" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_nombre" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">

                        <asp:Label ID="lbl_apellido" class="control-label Negrita" runat="server" Text="Apellido"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_Apellido" ControlToValidate="txt_apellido" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_apellido" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="form-group">
                    <div class="col-sm-4">

                        <asp:Label ID="lbl_DNI" class="control-label Negrita" runat="server" Text="DNI"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_dni" ControlToValidate="txt_DNI" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_txt_dni"
                            runat="server"
                            ErrorMessage="*"
                            MinimumValue="1"
                            MaximumValue="9999999999"
                            ControlToValidate="txt_DNI"
                            SetFocusOnError="true"
                            CssClass="labelRojo"></asp:RangeValidator>
                        <asp:TextBox ID="txt_DNI" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_FechaNacimiento" class="control-label Negrita" runat="server" Text="Fecha Nacimiento"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_FechaNacimiento" ControlToValidate="txt_FechaNacimiento" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <div class='input-group date'>
                            <asp:TextBox ID="txt_FechaNacimiento" runat="server" class="form-control" data-provide="datepicker"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_Telefono" class="control-label Negrita" runat="server" Text="Telefono"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_Telefono" ControlToValidate="txt_telefono" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_telefono" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_Idioma" class="control-label Negrita" runat="server" Text="Idioma"></asp:Label>
                        <asp:DropDownList ID="ddl_idioma" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_Calle" class="control-label Negrita" runat="server" Text="Calle"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_Calle" SetFocusOnError="true" ControlToValidate="txt_calle" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_calle" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_Altura" class="control-label Negrita" runat="server" Text="Altura"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_Altura" SetFocusOnError="true" ControlToValidate="txt_altura" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_txt_altura"
                            runat="server"
                            ErrorMessage="*"
                            MinimumValue="1"
                            MaximumValue="999999999"
                            ControlToValidate="txt_altura"
                            SetFocusOnError="true"
                            CssClass="labelRojo"></asp:RangeValidator>
                        <asp:TextBox ID="txt_altura" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_Provincia" class="control-label Negrita" runat="server" Text="Provincia"></asp:Label>
                        <asp:DropDownList ID="ddl_Provincia" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_localidad" class="control-label Negrita" runat="server" Text="Localidad"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_txt_localidad" ControlToValidate="txt_localidad" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_localidad" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-4">
                        <asp:Label ID="lbl_CodigoPostal" class="control-label Negrita" runat="server" Text="Código Postal"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfv_CodigoPostal" ControlToValidate="txt_CodigoPostal" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt_CodigoPostal" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="lbl_Piso" class="control-label Negrita" runat="server" Text="Piso"></asp:Label>
                        <asp:TextBox ID="txt_Piso" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        <asp:Label ID="lbl_Departamento" class="control-label Negrita" runat="server" Text="Depto"></asp:Label>
                       <asp:TextBox ID="txt_departamento" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <div class="col-sm-2 col-sm-offset-2">
                        <asp:Button ID="btn_aceptar" runat="server" Text="Aceptar" CssClass="btn btn-block btn-success" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-warning" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
