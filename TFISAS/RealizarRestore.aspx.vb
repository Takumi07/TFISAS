Public Class RealizarRestore
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
            Dim MiBackupRestoreBLL As New BLL.BackupRestoreBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            Dim MiBackupRestoreEntidad As New Entidades.BackupRestore
            Dim Path As String
            Path = System.Configuration.ConfigurationSettings.AppSettings("rutabackup").Trim
            MiBackupRestoreEntidad.Directorio = Path
            MiBackupRestoreEntidad.Nombre = Me.flu.FileName



            'ACA VER QUE ES LO QUE TENGO QUE PONERLE
            'MiBackupRestoreEntidad.Usuario = BLL.SesionBLL.Current.Usuario


            MiBackupRestoreBLL.RealizarRestore(MiBackupRestoreEntidad)

            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 65) '65
            Response.Redirect("Mensajes.aspx", False)

        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.ExcepcionArchivoBD
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.ArchivoBackupIncorrecto
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