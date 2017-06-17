Public MustInherit Class PermisoBase
    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
        End Set
    End Property

    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vURL As String
    Public Property URL() As String
        Get
            Return vURL
        End Get
        Set(ByVal value As String)
            vURL = value
        End Set
    End Property

    Public MustOverride Function agregarHijo(ByVal paramPermiso As PermisoBase) As Boolean
    Public MustOverride Function tieneHijos() As Boolean
    Public MustOverride Function ObtenerHijos() As List(Of PermisoBase)

    Public Overrides Function Equals(ByVal paramObj As Object) As Boolean
        If Not paramObj Is Nothing Then
            If TypeOf paramObj Is PermisoBase Then
                Return Me.Nombre.Equals(CType(paramObj, PermisoBase).Nombre)
            ElseIf TypeOf paramObj Is String Then
                Return Me.Nombre.Equals(paramObj)
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Overrides Function ToString() As String
        Return Nombre.ToString
    End Function
End Class
