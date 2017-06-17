Public Class RemitoRenglon


    Private vNroRenglon As Integer
    Public Property NroRenglon() As Integer
        Get
            Return vNroRenglon
        End Get
        Set(ByVal value As Integer)
            vNroRenglon = value
        End Set
    End Property


    Private vProducto As Entidades.Producto
    Public Property Producto() As Entidades.Producto
        Get
            Return vProducto
        End Get
        Set(ByVal value As Entidades.Producto)
            vProducto = value
        End Set
    End Property



    Private vCantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return vCantidad
        End Get
        Set(ByVal value As Integer)
            vCantidad = value
        End Set
    End Property

End Class
