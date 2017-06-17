Imports System.Globalization
Imports System.IO
Public Class BackupRestoreBLL
    Dim MiBackupRestoreDAL As New DAL.BackupRestoreDAL
    Dim MiUsuarioEntidad As New Entidades.Usuario

    Sub New()

    End Sub

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub



    Public Sub RealizarBackup(ByVal paramBackupRestoreEntidad As Entidades.BackupRestore)
        Try
            Dim MiResultado As Boolean
            Dim MiDirectorio As String
            Me.CrearDirectorio(paramBackupRestoreEntidad.Directorio)

            MiDirectorio = paramBackupRestoreEntidad.Directorio & paramBackupRestoreEntidad.Nombre
            paramBackupRestoreEntidad.Directorio = MiDirectorio

            Try
                Me.VerificarNombre(paramBackupRestoreEntidad.Directorio)
            Catch ex As bll.NombreBackupDuplicado
                Throw ex
            Catch ex As Exception
                Throw ex
            End Try

            MiResultado = MiBackupRestoreDAL.RealizarBackup(paramBackupRestoreEntidad)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Backup, MiUsuarioEntidad, 107))

        Catch ex As BLL.NombreBackupDuplicado
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub



    Public Function RealizarRestore(ByVal paramBackupRestoreEntidad As Entidades.BackupRestore)

        Try
            'Valido que el archivo tenga la extención correcta
            If Right(Trim(paramBackupRestoreEntidad.Nombre), 4) <> ".bak" Then
                Dim ExceptionArchivoBD As New BLL.ExcepcionArchivoBD
                Throw ExceptionArchivoBD
            End If




            'SOLICITARON QUE ANTES DE QUE SE REALICE UN RESTORE SE HAGA UN BACKUP PREVENTIVO.
            'ESTE BACKUP PREVENTIVO SE DEJARÁ EN EL SERVIDOR

            Dim MiBackupPreventivo As New Entidades.BackupRestore
            MiBackupPreventivo.Nombre = DateTime.Now.Year & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & ".BAK"
            MiBackupPreventivo.Directorio = System.Configuration.ConfigurationSettings.AppSettings("rutabackup").Trim
            Me.RealizarBackup(MiBackupPreventivo)


            Dim MiDirectorio As String
            MiDirectorio = paramBackupRestoreEntidad.Directorio & paramBackupRestoreEntidad.Nombre
            paramBackupRestoreEntidad.Directorio = MiDirectorio


            Try
                If MiBackupRestoreDAL.ValidarRestore(paramBackupRestoreEntidad) Then

                End If
            Catch ex As System.Data.SqlClient.SqlException
                Throw New BLL.ArchivoBackupIncorrecto
            Catch ex As Exception
                Throw New BLL.ArchivoBackupIncorrecto
            End Try


            'HAGO EL RESTORE QUE SOLICITO EL USAURIO
            MiBackupRestoreDAL.RealizarRestore(paramBackupRestoreEntidad)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Restore, MiUsuarioEntidad, 108))



        Catch ex As BLL.ArchivoBackupIncorrecto
            Throw ex
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
        Catch ex As BLL.ExcepcionArchivoBD
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


    Public Sub CrearDirectorio(ByVal paramPath As String)
        Try
            Dim MiDirectorio As DirectoryInfo = New DirectoryInfo(paramPath)
            If Not MiDirectorio.Exists Then
                MiDirectorio.Create()
            End If

        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub


    Public Sub VerificarNombre(ByVal paramPath As String)
        Try
            If System.IO.File.Exists(paramPath) = True Then
                Throw New BLL.NombreBackupDuplicado
            Else

            End If
        Catch ex As bll.NombreBackupDuplicado
            Throw ex
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub
End Class
