

Public Class Desarrollo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            BLL.DVBLL.GenerarIntegridad()
            MsgBox("Terminado")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MiVentaBLL As New BLL.VentaBLL
        MiVentaBLL.ObtenerFacturas(DirectCast(Session("Usuario"), Entidades.Cliente))
    End Sub
End Class