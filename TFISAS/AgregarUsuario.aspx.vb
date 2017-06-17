Public Class AgregarUsuario
    Inherits System.Web.UI.Page
    Protected mensajeConfirmacion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'ACA PONER EL MENSAJE DE EXTENSIÓN CORRECTO!!!!!
            mensajeConfirmacion = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 9)

            If Not IsPostBack Then
                Me.CargarIdiomas()
                Me.CargarPermisos()
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

    Protected Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            If ddl_Perfil.SelectedValue = 0 Then
                'Me seleccionó el perfil eliminado para una persona y no lo dejo pasar.
                Throw New BLL.SelPerfilEliminado
            Else
                Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
                If Me.txt_password.Text.Length < 6 Then
                    Throw New BLL.PasswordCortaException
                End If
                If Me.txt_password.Text <> Me.txt_confirmarPassword.Text Then
                    Throw New BLL.NoCoincidePasswordException
                Else

                    If (New BLL.UsuarioBLL).verificarSiExisteUsuario(txt_NombreUsuario.Text) = True Then
                        Throw New BLL.NombreUsuarioUtilizado
                    Else
                        Dim MiUsuarioEntidad As New Entidades.Usuario
                        MiUsuarioEntidad.NombreUsuario = txt_NombreUsuario.Text
                        MiUsuarioEntidad.Password = BLL.EncriptadoraBLL.EncriptarPass(txt_password.Text)
                        MiUsuarioEntidad.Correo = txt_correo.Text
                        MiUsuarioEntidad.Permiso = Me.CargarPermiso()
                        MiUsuarioEntidad.Idioma = Me.CargarIdioma
                        MiUsuarioEntidad.Editable = Me.chk_editarse.Checked
                        MiUsuarioEntidad.ImagenUsuario = Me.ConvertirBase64
                        MiUsuarioEntidad.DNI = Me.txt_dni.Text
                        MiUsuarioEntidad.Nombre = Me.txt_nombre.Text
                        MiUsuarioEntidad.Apellido = Me.txt_apellido.Text
                        Dim MiUsuarioBLL As New BLL.UsuarioBLL
                        MiUsuarioBLL.Alta(MiUsuarioEntidad)



                        'Aca le aviso que se registro correctamente? Logearlo de una?
                        Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 33) '33
                        Response.Redirect("Mensajes.aspx", False)
                    End If
                End If
            End If
        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.SelPerfilEliminado
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.PasswordCortaException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.NombreUsuarioUtilizado
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.NoCoincidePasswordException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try


    End Sub



    Private Sub CargarPermisos()
        Try
            Dim MisPermisos As New List(Of Entidades.PermisoBase)
            MisPermisos = (New BLL.PermisosBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ListarFamilias(True))
            MisPermisos.Remove(MisPermisos.Find(Function(x) x.ID = 0))
            Me.ddl_Perfil.DataSource = MisPermisos
            Me.ddl_Perfil.DataTextField = "Nombre"
            Me.ddl_Perfil.DataValueField = "ID"
            Me.ddl_Perfil.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
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
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub


    Private Function CargarPermiso() As Entidades.PermisoCompuesto
        Try
            Return (New BLL.PermisosBLL(Session("Usuario"))).ListarFamilias(CInt(ddl_Perfil.SelectedValue))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function

    Private Function CargarIdioma() As Entidades.Idioma
        Try
            Return (New BLL.IdiomaBLL(Session("Usuario"))).Cargar(New Entidades.Idioma(ddl_idioma.SelectedValue))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function


    Protected Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            Response.Redirect("index.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub



    Public Function ConvertirBase64() As String
        If Me.FilePhoto.PostedFile.ContentLength <> 0 Then
            Return Convert.ToBase64String(Me.FilePhoto.FileBytes)
        Else
            Return ""
        End If
    End Function
End Class