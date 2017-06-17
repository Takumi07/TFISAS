
Public Class RealizarBackup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.txt_directorio.Text = System.Configuration.ConfigurationSettings.AppSettings("rutabackup").Trim
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
            Dim MiBackupRestoreBLL As New BLL.BackupRestoreBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            Dim MiBackupRestoreEntidad As New Entidades.BackupRestore
            MiBackupRestoreEntidad.Directorio = txt_directorio.Text
            If Len(txt_nombre.Text) <= 3 Then
                MiBackupRestoreEntidad.Nombre = txt_nombre.Text & ".bak"
            Else
                If Mid(txt_nombre.Text, (Len(txt_nombre.Text) - 3)) = ".bak" Then
                    MiBackupRestoreEntidad.Nombre = txt_nombre.Text
                Else
                    MiBackupRestoreEntidad.Nombre = txt_nombre.Text & ".bak"
                End If
            End If


            MiBackupRestoreBLL.RealizarBackup(MiBackupRestoreEntidad)
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 62)  '62
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.NombreBackupDuplicado
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
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
End Class