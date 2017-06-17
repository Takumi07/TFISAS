Public Class Venta

    Private vCliente As New Entidades.Cliente
    Public Property Cliente() As Entidades.Cliente
        Get
            Return vCliente
        End Get
        Set(ByVal value As Entidades.Cliente)
            vCliente = value
        End Set
    End Property

    Private vProductosComprados As New List(Of Entidades.Producto)
    Public Property ProductosComprados() As List(Of Entidades.Producto)
        Get
            Return vProductosComprados
        End Get
        Set(ByVal value As List(Of Entidades.Producto))
            vProductosComprados = value
        End Set
    End Property

    Private vPromocionesCompradas As New List(Of Entidades.Promocion)
    Public Property PromocionesCompradas() As List(Of Entidades.Promocion)
        Get
            Return vPromocionesCompradas
        End Get
        Set(ByVal value As List(Of Entidades.Promocion))
            vPromocionesCompradas = value
        End Set
    End Property

End Class
