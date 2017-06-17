Public Class TipoProducto
    Sub New()

    End Sub

    Sub New(ByVal paramID)
        vID_TipoProducto = paramID
    End Sub

    Private vID_TipoProducto As Integer
    Public Property ID_TipoProducto() As Integer
        Get
            Return vID_TipoProducto
        End Get
        Set(ByVal value As Integer)
            vID_TipoProducto = value
        End Set
    End Property

    Private vDescripcion As String
    Public Property Descripcion() As String
        Get
            Return vDescripcion
        End Get
        Set(ByVal value As String)
            vDescripcion = value
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
        Return vDescripcion
    End Function
End Class
