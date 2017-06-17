Public Class CambiarContraseña
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'No hay usuario a quien cambiarle la Password
            If IsNothing(DirectCast(Session("Usuario"), Entidades.Usuario)) Then
                Response.Redirect("Index.aspx")
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lbl_Error)
            If txt_password.Text <> txt_confirmarPassword.Text Then
                Throw New BLL.NoCoincidePasswordException
            Else

                If Me.txt_password.Text.Length < 6 Then
                    Throw New BLL.PasswordCortaException
                End If

                Dim MiUsuarioBLL As New BLL.UsuarioBLL

                DirectCast(Session("Usuario"), Entidades.Usuario).Password = BLL.EncriptadoraBLL.EncriptarPass(Me.txt_password.Text)
                MiUsuarioBLL.Modificar(DirectCast(Session("Usuario"), Entidades.Usuario))


                Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 37) '37
                Response.Redirect("Mensajes.aspx", False)
            End If

        Catch ex As BLL.PasswordCortaException
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.NoCoincidePasswordException
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Index.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub
End Class