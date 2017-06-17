Public Class FacturaProveedorRenglon


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


    Private vPrecioUnitario As Double
    Public Property PrecioUnitario() As Double
        Get
            Return vPrecioUnitario
        End Get
        Set(ByVal value As Double)
            vPrecioUnitario = value
        End Set
    End Property


    Private vIVA As Entidades.IVA
    Public Property IVA() As Entidades.IVA
        Get
            Return vIVA
        End Get
        Set(ByVal value As Entidades.IVA)
            vIVA = value
        End Set
    End Property

End Class
