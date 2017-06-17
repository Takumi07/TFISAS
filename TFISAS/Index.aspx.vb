Public Class Index
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNothing(Session("Usuario")) Then
                Me.registrarse.Visible = True
            Else
                Me.registrarse.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class