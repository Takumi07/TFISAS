Public Class Mensajes
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsNothing(Session("SQLERROR")) Then
                Me.divError.Visible = False
                Me.divMensaje.Visible = False
                Me.divErrorSQL.Visible = True
                Me.lbl_SQLError.Text = "Tenemos un error de base de datos. Estaremos operativos a la brevedad."
                Session("SQLERROR") = Nothing
                Session("FlagSQL") = True

            Else
                If IsNothing(Session("Error")) Or CBool(Session("Error")) = False Then
                    If Session("Mensaje") IsNot Nothing Then
                        Me.divError.Visible = False
                        Me.divErrorSQL.Visible = False
                        Me.divMensaje.Visible = True
                        Me.lbl_Mensaje.Text = Session("Mensaje")
                        'No hay mensaje que mostrar, es f5?
                    Else
                        'Esto es lo que cambie para que no aparezca la pantalla en verde cuando dan f5 ver que consecuencia tiene
                        Me.divError.Visible = False
                        Me.divErrorSQL.Visible = False
                        Me.divMensaje.Visible = False
                        Me.lbl_Mensaje.Text = ""
                        'fin del agregado!
                        Session("F5") = True
                    End If
                    Session("Mensaje") = Nothing
                    Me.redireccionar()
                Else
                    If Session("Mensaje") IsNot Nothing Then
                        Me.divError.Visible = True
                        Me.divMensaje.Visible = False
                        Me.divErrorSQL.Visible = False
                        Me.lbl_MensajeError.Text = Session("Mensaje")
                    End If
                    Session("Mensaje") = Nothing
                    Session("Error") = Nothing
                    Me.redireccionar()
                End If
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub redireccionar()
        Try
            Dim Redirect As String = ""
            If Not IsNothing(Session("Redirect")) Then
                'Redirecciono a la página que quiero
                Redirect = "4;URL=" & Session("Redirect")
            Else
                'Redirección default
                Redirect = "4;URL=index.aspx"
            End If
            Session("Redirect") = Nothing
            Response.AddHeader("REFRESH", Redirect)
        Catch ex As Exception

        End Try

    End Sub

End Class