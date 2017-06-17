Public Class PermisosBLL
    Dim MiUsuarioEntidad As New Entidades.Usuario

    'Sub New()

    'End Sub

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub

    Dim MiPermisoDAL As New DAL.PermisosDAL


#Region "Listar"
    Public Function ListarFamilias(ByVal paramFiltro As Boolean) As List(Of Entidades.PermisoBase)
        Try
            Return MiPermisoDAL.listarFamilias(paramFiltro)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function

    Public Function ListarFamilias(ByVal paramPermiso As Entidades.PermisoBase) As Entidades.PermisoCompuesto
        Try
            Return MiPermisoDAL.listarFamilias(paramPermiso)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function

    Public Function ListarFamilias(ByVal paramID As Integer) As Entidades.PermisoCompuesto
        Try
            Return MiPermisoDAL.listarFamilias(paramID)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


    Public Function ListarFamilias() As List(Of Entidades.PermisoCompuesto)
        Try
            Return MiPermisoDAL.listarFamilias()
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
#End Region

#Region "ABM"
    Public Sub Alta(ByVal paramPermiso As Entidades.PermisoBase)
        Try
            If chequearNombrePermiso(paramPermiso.Nombre) = False Then
                MiPermisoDAL.AltaPermiso(paramPermiso)
                BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, MiUsuarioEntidad, 89))
            Else
                'Permiso Duplicado
                BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, MiUsuarioEntidad, 90))
                Throw New PermisoDuplicadoException
            End If
        Catch ex As PermisoDuplicadoException
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub


    Public Sub Modificar(ByVal paramPermiso As Entidades.PermisoBase)
        Try
            MiPermisoDAL.ModificarPermiso(paramPermiso)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, MiUsuarioEntidad, 91))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Sub Baja(ByVal paramPermiso As Entidades.PermisoBase)
        Try
            'Primro actualizo y le pongo perfil eliminado, porque sino me tira restricción de FK
            Me.ActualizarPermisosDeUsuarios(paramPermiso.ID)
            MiPermisoDAL.BajaPermiso(paramPermiso)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Baja, MiUsuarioEntidad, 92))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

#End Region

#Region "Verificar Nombre"
    Public Function chequearNombrePermiso(ByVal paramNombrePermiso As String) As Boolean
        Try
            Return MiPermisoDAL.chequearNombrePermiso(paramNombrePermiso)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
#End Region


    Public Sub ActualizarPermisosDeUsuarios(ByVal paramIDPermiso As Integer)
        Try
            Dim MiUsuarioBLL As New UsuarioBLL
            MiUsuarioBLL.ActualizarPermisosDeUsuarios(paramIDPermiso)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub
End Class
