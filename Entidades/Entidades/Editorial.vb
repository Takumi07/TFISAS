Public Class Editorial

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

    Private vCorreo As String
    Public Property Correo() As String
        Get
            Return vCorreo
        End Get
        Set(ByVal value As String)
            vCorreo = value
        End Set
    End Property

    Private vBL As Boolean
    Public Property BL() As Boolean
        Get
            Return vBL
        End Get
        Set(ByVal value As Boolean)
            vBL = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.vNombre
    End Function
End Class
