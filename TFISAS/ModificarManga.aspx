<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Maestra.Master" CodeBehind="ModificarManga.aspx.vb" Inherits="TFISAS.ModificarManga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="JS/jquery-1.9.1.min.js"></script>
    <script src="JS/jquery-ui.js"></script>
    <link href="CSS/DateTimePicker.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $("#ContenidoPagina_txt_FechaArribo").datepicker();
        });
        $(function () {
            $("#ContenidoPagina_txt_FechaSalida").datepicker();
        });

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
                alert(extensiones_permitidas.join());
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
                        <asp:Label ID="lbl_ModificarManga" runat="server">Modificar Manga</asp:Label>
                    </div>

                                        <div class="panel-body" id="ListaProductos" runat="server">
                        <div class="row">
                            <asp:GridView ID="gv_Productos" runat="server" CssClass="Grid-verde" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Productos_PageIndexChanging" RowStyle-Height="30px">
                                <PagerTemplate>
                                    <div class="control-label right">
                                        <asp:Label ID="lbl_pagina" runat="server" Text="Pagina" CssClass="margenPaginacion"></asp:Label>
                                        <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                    </div>
                                </PagerTemplate>
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Editorial" HeaderText="Editorial" />
                                    <asp:BoundField DataField="N_Tomo" HeaderText="Nº Tomo" />
                                    <asp:BoundField DataField="Genero" HeaderText="Genero" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="col-md-2  margenIconoMensaje ">
                                                <asp:ImageButton ID="btn_Editar" runat="server" OnCommand="btn_Editar_Command" ImageUrl="~/Imagenes/edit.png" Height="20px" CommandArgument='<%#Eval("ID")%>' />
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
</div>



                    <div class="panel-body" id="ModificarProducto" runat="server" visible ="false">
                        <div class="col-md-12 col-md-offset-2">
                            <div class="form-horizontal" role="form">
                                <div class="form-group">
                                    <div class="col-sm-8">
                                        <asp:Label ID="lbl_Nombre" class="control-label Negrita" runat="server" Text="Nombre"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfv_Nombre" ControlToValidate="txt_Nombre" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txt_Nombre" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-8">
                                        <asp:Label ID="lbl_Descripcion" class="control-label Negrita" runat="server" Text="Descripción"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfv_Descripcion" ControlToValidate="txt_Descripcion" runat="server" CssClass="labelRojo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txt_descripcion" class="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Genero" class="control-label Negrita" runat="server" Text="Genero"></asp:Label>
                                        <asp:DropDownList ID="ddl_Genero" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Editorial" class="control-label Negrita" runat="server" Text="Editorial"></asp:Label>
                                        <asp:DropDownList ID="ddl_Editorial" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <div class="col-sm-4">
                                    <asp:Label ID="lbl_FechaSalida" class="control-label Negrita" runat="server" Text="Fecha Salida"></asp:Label>
                                    <asp:RequiredFieldValidator 
                                         ID="rfv_txt_fechaSalida" 
                                         ControlToValidate="txt_FechaSalida" 
                                         Display="Dynamic" 
                                         runat="server" 
                                         CssClass="labelRojo" 
                                         SetFocusOnError="True" 
                                         ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <div class='input-group date'>
                                        <asp:TextBox ID="txt_FechaSalida" runat="server" class="form-control" data-provide="datepicker"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                    </div>
                                    <div class="col-sm-4">
                                     <asp:Label ID="lbl_FechaArribo" class="control-label Negrita" runat="server" Text="Fecha Arribo"></asp:Label>
                                     <asp:RequiredFieldValidator 
                                         ID="rev_txt_fechaarribo" 
                                         ControlToValidate="txt_fechaArribo" 
                                         Display="Dynamic" 
                                         runat="server" 
                                         CssClass="labelRojo" 
                                         SetFocusOnError="True" 
                                         ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <div class='input-group date'>
                                        <asp:TextBox ID="txt_FechaArribo" runat="server" class="form-control" data-provide="datepicker"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                    </div>
                                  </div>


                                                               <div class="form-group">
                                    <div class="col-sm-4">
                                    <asp:Label ID="lbl_FechaSalidaPTomo" class="control-label Negrita" runat="server" Text="Fecha Salida Proximo Tomo"></asp:Label>
                                    <asp:RequiredFieldValidator 
                                         ID="rfv_txt_FechaSalidaPTomo" 
                                         ControlToValidate="txt_FechaSalidaPTomo" 
                                         Display="Dynamic" 
                                         runat="server" 
                                         CssClass="labelRojo" 
                                         SetFocusOnError="True" 
                                         ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <div class='input-group date'>
                                        <asp:TextBox ID="txt_FechaSalidaPTomo" runat="server" class="form-control" data-provide="datepicker"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                    </div>
                                    <div class="col-sm-4">
                                     <asp:Label ID="lbl_NTomo" class="control-label Negrita" runat="server" Text="Nro Tomo"></asp:Label>
                                     <asp:RequiredFieldValidator 
                                         ID="rfv_nrotomo" 
                                         ControlToValidate="txt_nrotomo" 
                                         Display="Dynamic" 
                                         runat="server" 
                                         CssClass="labelRojo" 
                                         SetFocusOnError="True" 
                                         ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="rav_txt_nrotomo"
                                            runat="server"
                                            ErrorMessage="*"
                                            MinimumValue="1"
                                            MaximumValue="999999999"
                                            ControlToValidate="txt_nrotomo"
                                            SetFocusOnError="true"
                                            CssClass="labelRojo"></asp:RangeValidator>
                                        <asp:TextBox ID="txt_nrotomo" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                  </div>

                                <div class="form-group">
                                    <div class="col-sm-4" style="margin-left: 22px"">
                                        <b><asp:CheckBox ID="chk_Importado" CssClass="checkbox" Text="¿Producto Importado?" runat="server" /></b>
                                    </div>
                                    <div class="col-sm-4" style="margin-left: -22px"">
                                        <asp:Label ID="lbl_PrecioVenta" class="control-label Negrita" runat="server" Text="Precio Venta"></asp:Label>
                                        <asp:RequiredFieldValidator 
                                            ID="rfv_PrecioVenta" 
                                            ControlToValidate="txt_PrecioVenta" 
                                            SetFocusOnError="True"
                                            display="Dynamic"
                                            runat="server" 
                                            CssClass="labelRojo" 
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                        ID="rev_precioVenta"
                                        runat="server"
                                        Display="Dynamic"
                                        CssClass="labelRojo"
                                        SetFocusOnError="True"
                                        Text="*"
                                        ControlToValidate="txt_PrecioVenta"
                                        ValidationExpression="^[0-9]+[,]{0,1}[0-9]+$"
                                        ErrorMessage="*" />
                                        <asp:TextBox ID="txt_PrecioVenta" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Imagen" class="control-label Negrita" runat="server" Text="Imagen"></asp:Label>                        
                                        <asp:FileUpload ID="FilePhoto" runat="server" CssClass="fileupload"  onchange="readURL(this)" /><br />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Imagen2" class="control-label Negrita" runat="server" Text="Imagen"></asp:Label>
                                        <asp:FileUpload ID="FilePhoto2" runat="server" CssClass="fileupload"   onchange="readURL(this)"  /><br />
                                    </div>
                                </div>
                                
                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Imagen3" class="control-label Negrita" runat="server" Text="Imagen"></asp:Label>
                                        <asp:FileUpload ID="FilePhoto3" runat="server" CssClass="fileupload"  onchange="readURL(this)"  /><br />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Label ID="lbl_Imagen4" class="control-label Negrita" runat="server" Text="Imagen"></asp:Label>
                                        <asp:FileUpload ID="FilePhoto4" runat="server" CssClass="fileupload"  onchange="readURL(this)"  /><br />
                                    </div>
                                </div>
                                <div class="form-group">
                                     <div class="col-sm-4 text-center">
                                        <img id="previewimg" src="#" alt="Preview"  style="max-height: 400px; max-width: 594px;"/>
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
