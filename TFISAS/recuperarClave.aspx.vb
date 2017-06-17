Public Class recuperarClave
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            If MiUsuarioBLL.verificarSiExisteUsuario(txtUsuario.Text) = False Then
                Throw New BLL.usuarioInexistenteException
            Else
                Dim MiUsuarioEntidad As New Entidades.Usuario
                MiUsuarioEntidad.NombreUsuario = txtUsuario.Text
                MiUsuarioEntidad = MiUsuarioBLL.chequearUsuario(MiUsuarioEntidad)
                MiUsuarioBLL.RecuperarContraseña(MiUsuarioEntidad)
            End If
            Session("Mensaje") = "Se envió un correo a su casilla con una nueva contraseña."
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.usuarioInexistenteException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("~\index.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub
End Class