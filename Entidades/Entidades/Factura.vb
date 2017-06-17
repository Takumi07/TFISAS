Public Class Factura
    Private vNroFactura As Integer
    Public Property NroFactra() As Integer
        Get
            Return vNroFactura
        End Get
        Set(ByVal value As Integer)
            vNroFactura = value
        End Set
    End Property

    Private vFechaEmision As DateTime
    Public Property FechaEmision() As DateTime
        Get
            Return vFechaEmision
        End Get
        Set(ByVal value As DateTime)
            vFechaEmision = value
        End Set
    End Property


    Private vFacturaRenglon As New List(Of Entidades.FacturaRenglon)
    Public Property FacturaRenglon() As List(Of Entidades.FacturaRenglon)
        Get
            Return vFacturaRenglon
        End Get
        Set(ByVal value As List(Of Entidades.FacturaRenglon))
            vFacturaRenglon = value
        End Set
    End Property


End Class
