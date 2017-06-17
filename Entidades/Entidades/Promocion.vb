Public Class Promocion

    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
        End Set
    End Property

    Private vProducto As Producto
    Public Property Producto() As Producto
        Get
            Return vProducto
        End Get
        Set(ByVal value As Producto)
            vProducto = value
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
