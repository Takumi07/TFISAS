Imports Entidades
Imports DAL

Public Class TipoProductoBLL

    Dim MiUsuarioEntidad As New Entidades.Usuario

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub

    Dim MiTipoProductoDAL As New DAL.TipoProductoDAL

    ''' <summary> Método que devuelve todos los Tipos de Productos </summary>
    Public Function ListarTipoProducto() As List(Of Entidades.TipoProducto)
        Try
            Return (New TipoProductoDAL).ListarTipoProducto
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


    Public Function ObtenerTipoProducto(ByVal paramID As Integer) As Entidades.TipoProducto
        Try
            Return TipoProductoDAL.ObtenerTipoProducto(paramID)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
    Public Sub GuardarTipoProducto(ByVal paramTipoProducto As Entidades.TipoProducto)
    End Sub


    Public Sub ModificarTipoProducto(ByVal paramTipoProducto As Entidades.TipoProducto)
    End Sub


    Public Sub BajaTipoProducto(ByVal paramTipoProducto As Entidades.TipoProducto)
    End Sub

End Class
