Public Class Institucional
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNothing(DirectCast(Session("Usuario"), Entidades.Usuario)) Then
                Me.lbl_DescripcionEmpresa.Text = BLL.IdiomaBLL.traducirMensaje(New Entidades.Idioma(1), 156)
                Me.lbl_NuestraEmpresa.Text = BLL.IdiomaBLL.traducirMensaje(New Entidades.Idioma(1), 157)
            Else
                Me.lbl_DescripcionEmpresa.Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 156)
                Me.lbl_NuestraEmpresa.Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 157)
            End If

        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica

        Catch ex As Exception

        End Try


    End Sub

End Class