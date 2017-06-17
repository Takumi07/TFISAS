Public Class FacturaProveedor
    Private vNroFactura As Integer
    Public Property NroFactra() As Integer
        Get
            Return vNroFactura
        End Get
        Set(ByVal value As Integer)
            vNroFactura = value
        End Set
    End Property

    Private vProveedor As Entidades.Proveedor
    Public Property Proveedor() As Entidades.Proveedor
        Get
            Return vProveedor
        End Get
        Set(ByVal value As Entidades.Proveedor)
            vProveedor = value
        End Set
    End Property


    Private vFechaEmision As Date
    Public Property FechaEmision() As Date
        Get
            Return vFechaEmision
        End Get
        Set(ByVal value As Date)
            vFechaEmision = value
        End Set
    End Property


    Private vFacturaRenglon As List(Of Entidades.FacturaProveedorRenglon)
    Public Property FacturaRenglon() As List(Of Entidades.FacturaProveedorRenglon)
        Get
            Return vFacturaRenglon
        End Get
        Set(ByVal value As List(Of Entidades.FacturaProveedorRenglon))
            vFacturaRenglon = value
        End Set
    End Property


    Private vEstado As Entidades.Estado
    Public Property Estado() As Entidades.Estado
        Get
            Return vEstado
        End Get
        Set(ByVal value As Entidades.Estado)
            vEstado = value
        End Set
    End Property
End Class
