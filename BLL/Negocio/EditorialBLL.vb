Imports Entidades

Public Class EditorialBLL

    Dim MiUsuarioEntidad As New Entidades.Usuario

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub
    Public Function ListarEditoriales() As List(Of Entidades.Editorial)
        Try
            Return (New DAL.EditorialDAL).ListarEditoriales
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function




    Public Function ListarUnaEditorial(ByVal paramID As Integer) As Entidades.Editorial
        Try
            Return DAL.EditorialDAL.ObtenerUnaEditorial(paramID)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function

    Public Sub GuardarEditorial(ByVal paramEditorial As Entidades.Editorial)
    End Sub


    Public Sub ModificarEditorial(ByVal paramEditorial As Entidades.Editorial)
    End Sub


    Public Sub BajaEditorial(ByVal paramEditorial As Entidades.Editorial)
        'Si muere una editorial mueren todas sus obras
    End Sub
End Class
