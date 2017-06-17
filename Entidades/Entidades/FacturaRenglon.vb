Public Class FacturaRenglon

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


    Private vPrecioUnitario As Entidades.Precio
    Public Property PrecioUnitario() As Entidades.Precio
        Get
            Return vPrecioUnitario
        End Get
        Set(ByVal value As Entidades.Precio)
            vPrecioUnitario = value
        End Set
    End Property


    Private vDescuento As Double
    Public Property Descuento() As Double
        Get
            Return vDescuento
        End Get
        Set(ByVal value As Double)
            vDescuento = value
        End Set
    End Property

End Class
