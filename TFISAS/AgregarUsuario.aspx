<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="AgregarUsuario.aspx.vb" Inherits="TFISAS.AgregarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JS/jquery-1.9.1.min.js"></script>

    <script>
        function readURL(input) {
            extensiones_permitidas = new Array(".gif", ".jpg", ".png");
            var file = input.files[0];
            /*Con esto valido el Tamaño*/
            /*alert(file.size);*/

            var nombre = file.name;
            var extension = (nombre.substring(nombre.lastIndexOf('.'))).toLowerCase();

            /*alert(extension);*/

            permitida = false;
            for (var i = 0; i < extensiones_permitidas.length; i++) {
                if (extensiones_permitidas[i] == extension) {
                    permitida = true;
                    break;
                }
            }

            if (!permitida) {
                alert("<%=mensajeConfirmacion%>" + extensiones_permitidas.join());
            } else {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#previewimg').attr('src', e.target.result);
                    }

                    reader.readAsDataURL(input.files[0]);
                }
            }
        }
        $("#filePhoto").change(function () {
            var input = document.getElementById('archivo');
            var file = input.files[0];
            alert(file.size);
            readURL(this);
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
                        <asp:Label ID="lbl_NuevoUsuario" runat="server">Nuevo Usuario</asp:Label>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-11 col-md-offset-2">
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
                                        <asp:TextBox ID="txt_correo" class="form-control" runat="server" ></asp:TextBox>
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
                                        <asp:Label ID="lbl_password" class="control-label Negrita" runat="server" Text="Contraseña"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rev_passwordd" ControlToValidate="txt_password" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txt_password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_ConfirmarPassword" class="control-label Negrita" runat="server" Text="Confirmar Contraseña"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rev_confirmarpassword" ControlToValidate="txt_confirmarPassword" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txt_confirmarPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
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
                                    <div class="col-sm-4" style="margin-left: 22px"">
                                        <b>
                                            <asp:CheckBox ID="chk_editarse" CssClass="checkbox" Text="¿Puede editarse?" runat="server" /></b>
                                    </div>
                                    <div class="col-sm-4" style="margin-left: -22px">
                                        <asp:Label ID="lbl_DNI" class="control-label Negrita" runat="server" Text="DNI"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfv_dni" ControlToValidate="txt_dni" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator
                                        ID="rev_dni"
                                        runat="server"
                                        Display="Dynamic"
                                        CssClass="labelRojo"
                                        SetFocusOnError="True"
                                        Text="*"
                                        ControlToValidate="txt_dni"
                                        ValidationExpression="^[0-9]"
                                        ErrorMessage="*" />
                                        <asp:TextBox ID="txt_dni" class="form-control" runat="server"></asp:TextBox>
                                   </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Imagen" class="control-label Negrita" runat="server" Text="Imagen"></asp:Label>
                                        <asp:FileUpload ID="FilePhoto" runat="server" CssClass="fileupload" onchange="readURL(this)" /><br />
                                    </div>
                                    <div class="col-sm-4 text-center">
                                        <img id="previewimg" src="#" alt="Preview" width="100" height="100" />
                                    </div>
                                </div>

                                <br />
                                <br />
                                <div class="form-group">
                                    <div class="col-sm-2 col-sm-offset-2">
                                        <asp:Button ID="btn_Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-block btn-success" />
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-warning" CausesValidation="false" />
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


