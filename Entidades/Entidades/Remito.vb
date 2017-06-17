Public Class Remito
    Private vNroRemito As Integer
    Public Property NroRemito() As Integer
        Get
            Return vNroRemito
        End Get
        Set(ByVal value As Integer)
            vNroRemito = value
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



    Private vEstado As Entidades.Estado
    Public Property Estado() As Entidades.Estado
        Get
            Return vEstado
        End Get
        Set(ByVal value As Entidades.Estado)
            vEstado = value
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



    Private vRemitoRenglon As New List(Of Entidades.RemitoRenglon)
    Public Property RemitoRenglon() As List(Of Entidades.RemitoRenglon)
        Get
            Return vRemitoRenglon
        End Get
        Set(ByVal value As List(Of Entidades.RemitoRenglon))
            vRemitoRenglon = value
        End Set
    End Property

End Class
