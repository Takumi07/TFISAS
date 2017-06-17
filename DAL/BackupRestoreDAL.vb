Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.Text

Public Class BackupRestoreDAL
    Public Function RealizarBackup(ByVal paramBackupRestoreEntidad As Entidades.BackupRestore) As Boolean


        Using MiConectionMaster = Conexion.retornaConexionMaestra()
            Try
                Dim MiStringBuilder As New StringBuilder
                MiStringBuilder.Append("BACKUP DATABASE [TFISAS] TO DISK = '" & paramBackupRestoreEntidad.Directorio & "' ")
                MiStringBuilder.Append("WITH DESCRIPTION = 'Backup Alexis Yañez', NOFORMAT, NOINIT, ")
                MiStringBuilder.Append("NAME = '" & paramBackupRestoreEntidad.Nombre & "', SKIP, NOREWIND, NOUNLOAD, STATS = 10")
                Dim MiComando As New SqlCommand(MiStringBuilder.ToString, MiConectionMaster)
                MiConectionMaster.Open()
                MiComando.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
            Finally
                MiConectionMaster.Close()
            End Try
        End Using
    End Function

    Public Sub RealizarRestore(ByVal paramBackupRestoreEntidad As Entidades.BackupRestore)
        Dim MiConectionMaster As New SqlConnection
        Try
            MiConectionMaster = Conexion.retornaConexionMaestra()

            Dim MiStringBuilder As New StringBuilder
            MiStringBuilder.Append("ALTER DATABASE [TFISAS] SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [TFISAS] ")
            MiStringBuilder.Append("FROM DISK = '" & paramBackupRestoreEntidad.Directorio & "'  With Replace ALTER DATABASE [TFISAS] SET MULTI_USER")
            Dim MiComando As New SqlCommand(MiStringBuilder.ToString, MiConectionMaster)
            MiConectionMaster.Open()
            MiComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            MiConectionMaster.Close()
        End Try
    End Sub



    Public Function ValidarRestore(ByVal paramBackupRestoreEntidad As Entidades.BackupRestore)
        Try
            Dim MiConectionMaster As New SqlConnection
            MiConectionMaster = Conexion.retornaConexionMaestra
            Dim MiStringBuilder As New StringBuilder
            MiStringBuilder.Append("RESTORE VERIFYONLY FROM DISK = '" & paramBackupRestoreEntidad.Directorio & "'")
            Dim MiComando As New SqlCommand(MiStringBuilder.ToString, MiConectionMaster)
            MiConectionMaster.Open()
            Dim resu As Integer
            resu = MiComando.ExecuteNonQuery()
            Return resu
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Comando para validar el archivo
    'RESTORE VERIFYONLY FROM DISK = 'Z:\Cacabkp_2442017.bak'
End Class
