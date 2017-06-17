Public Class Registrarse
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.llenarProvincias()
                Me.CargarIdiomas()
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)

            Dim MiClienteEntidad As New Entidades.Cliente
            Dim MiClienteBLL As New BLL.ClienteBLL

            If IsDate(txt_FechaNacimiento.Text) = False Then
                Throw New BLL.camposIncorrectosException
            End If


            If Me.txt_password.Text.Length < 6 Then
                Throw New BLL.PasswordCortaException
            End If

            If Me.txt_password.Text <> Me.txt_confirmarPassword.Text Then
                'Esto funciona para llamar al modal!
                Throw New BLL.NoCoincidePasswordException
            Else
                'Me.Validate()

                If (New BLL.UsuarioBLL).verificarSiExisteUsuario(txt_NombreUsuario.Text) = True Then
                    Throw New BLL.NombreUsuarioUtilizado
                Else

                    With MiClienteEntidad
                        .NombreUsuario = Me.txt_NombreUsuario.Text
                        .Correo = Me.txt_correo.Text
                        'Aca encriptar, antes comparar
                        .Password = BLL.EncriptadoraBLL.EncriptarPass(Me.txt_password.Text)
                        .Nombre = Me.txt_nombre.Text
                        .Apellido = Me.txt_apellido.Text
                        .DNI = Me.txt_DNI.Text
                        .Telefono = Me.txt_telefono.Text
                        .FechaNacimiento = Me.txt_FechaNacimiento.Text
                    End With


                    Dim MiIdiomaEntidad As New Entidades.Idioma
                    MiIdiomaEntidad = Me.CargarIdioma


                    Dim MiDireccionEntidad As New Entidades.Direccion
                    With MiDireccionEntidad
                        .Altura = Me.txt_altura.Text
                        .Calle = Me.txt_calle.Text
                        'Cambiar o ver como hacemos
                        '.Provincia = ddl_Provincia
                        .Provincia = Me.ObtenerProvincia
                        'Cambiar y ver como hacemos
                        .Localidad = Me.txt_localidad.Text

                        .CodigoPostal = Me.txt_CodigoPostal.Text
                        .Piso = Me.txt_Piso.Text
                        .Departamento = Me.txt_departamento.Text
                    End With


                    MiClienteEntidad.Idioma = MiIdiomaEntidad
                    MiClienteEntidad.Direccion = MiDireccionEntidad

                    'ACA LE ASIGNO EL PERFIL QUE LE CORRESPONDE AL CLIENTE 
                    MiClienteEntidad.Permiso = New Entidades.PermisoCompuesto(18)

                    MiClienteBLL.NuevoCliente(MiClienteEntidad)


                    'Aca le aviso que se registro correctamente? Logearlo de una?
                    Session("Redirect") = "Login.aspx"
                    Session("Mensaje") = "El usuario se ha registrado correctamente. Por favor, acceda al sistema."
                    Response.Redirect("Mensajes.aspx", False)

                    'TENGO QUE VER SI LO QUIERO LOGEAR DESPUÉS DE QUE SE REGISTRA
                End If
            End If

        Catch ex As BLL.PasswordCortaException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.camposIncorrectosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.NombreUsuarioUtilizado
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.NoCoincidePasswordException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            Response.Redirect("Index.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub llenarProvincias()
        Try
            Me.ddl_Provincia.DataSource = (New BLL.ProvinciaBLL).ListarProvincias
            Me.ddl_Provincia.DataTextField = "Descripcion"
            Me.ddl_Provincia.DataValueField = "ID"
            Me.ddl_Provincia.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarIdiomas()
        Try
            Me.ddl_idioma.DataSource = (New BLL.IdiomaBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ListarIdiomas)
            Me.ddl_idioma.DataTextField = "Nombre"
            Me.ddl_idioma.DataValueField = "ID"
            Me.ddl_idioma.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub



    Private Function CargarIdioma() As Entidades.Idioma
        Try
            Return (New BLL.IdiomaBLL(Session("Usuario"))).Cargar(New Entidades.Idioma(ddl_idioma.SelectedValue))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Function



    Private Function ObtenerProvincia() As Entidades.Provincia
        Try
            Return (New BLL.ProvinciaBLL).ObtenerProvincia(ddl_Provincia.SelectedValue)

        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Function


End Class