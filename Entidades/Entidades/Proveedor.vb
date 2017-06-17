Public Class Proveedor
    Sub New()

    End Sub

    Sub New(ByVal paramID As Integer)
        vID = paramID
    End Sub

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

    Private vContacto As String
    Public Property Contacto() As String
        Get
            Return vContacto
        End Get
        Set(ByVal value As String)
            vContacto = value
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


End Class
