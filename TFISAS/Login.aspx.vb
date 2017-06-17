Imports System.Threading

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
            'Obtengo la IP (Funciona solo si lo Hosteo, sino te va a devolver siempre 1....1 porque estas hosteando con el visual segùn internet
            Dim MiIP As String = ""
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
            Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If String.IsNullOrEmpty(sIPAddress) Then
                MiIP = context.Request.ServerVariables("REMOTE_ADDR")
            Else
                Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
                MiIP = ipArray(0)
            End If


            Dim MiUsuarioEntidad As Entidades.Usuario
            Dim MiUsuarioBLL As New BLL.UsuarioBLL


            MiUsuarioEntidad = MiUsuarioBLL.Login(txtUsuario.Text, txtPassword.Text, Request.Browser.Browser & " " & Request.Browser.Version, MiIP)
            If MiUsuarioEntidad.Permiso.ID = 18 Then
                Dim MiClienteBLL As New BLL.ClienteBLL
                Dim MiClienteEntidad As New Entidades.Cliente
                MiClienteEntidad = MiClienteBLL.LoginCliente(MiUsuarioEntidad)
                Session("Usuario") = MiClienteEntidad
            Else
                Session("Usuario") = MiUsuarioEntidad
            End If

            'Probar a ver que ocurre.
            Session.Timeout = 1400
            Response.Redirect("~\index.aspx", False)

        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.PerfilEliminadoException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.UsuarioBajaException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.usuarioInexistenteException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.usuarioBloqueadoException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As BLL.passwordIncorrectoException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Session("Usuario") = Nothing
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