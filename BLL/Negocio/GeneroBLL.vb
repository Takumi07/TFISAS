Imports Entidades
Imports DAL
Public Class GeneroBLL
    Dim MiUsuarioEntidad As New Entidades.Usuario

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub
    Dim MiGeneroDAL As New DAL.GeneroDAL

    ''' <summary> Método que devuelve todos los generos </summary>
    Public Function ListarGeneros() As List(Of Entidades.Genero)
        Try
            Return (New GeneroDAL).ListarGeneros
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


    Public Function ObtenerGenero(ByVal paramID As Integer) As Entidades.Genero
        Try
            Return GeneroDAL.ObtenerGenero(paramID)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
End Class
