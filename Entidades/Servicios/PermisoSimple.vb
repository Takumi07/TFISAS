Public Class PermisoSimple
    Inherits PermisoBase

    Public Overrides Function agregarHijo(ByVal paramPermiso As PermisoBase) As Boolean
        Return False
    End Function


    Public Overrides Function tieneHijos() As Boolean
        Return False
    End Function


    Public Overrides Function ObtenerHijos() As List(Of PermisoBase)
        Return Nothing
    End Function
End Class
