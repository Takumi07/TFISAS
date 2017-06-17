Public Class AjustarStock

    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
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

    Private vCantidadAnterior As Integer
    Public Property CantidadAnterior() As Integer
        Get
            Return vCantidadAnterior
        End Get
        Set(ByVal value As Integer)
            vCantidadAnterior = value
        End Set
    End Property

    Private vCantidadPosterior As Integer
    Public Property CantidadPosterior() As Integer
        Get
            Return vCantidadPosterior
        End Get
        Set(ByVal value As Integer)
            vCantidadPosterior = value
        End Set
    End Property


    Private vFechaAjuste As DateTime
    Public Property FechaAjuste() As DateTime
        Get
            Return vFechaAjuste
        End Get
        Set(ByVal value As DateTime)
            vFechaAjuste = value
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


    Private vTipoMovimiento As Entidades.TipoMovimiento
    Public Property TipoMovimiento() As Entidades.TipoMovimiento
        Get
            Return vTipoMovimiento
        End Get
        Set(ByVal value As Entidades.TipoMovimiento)
            vTipoMovimiento = value
        End Set
    End Property

    Private vEstadoAjuste As Entidades.Estado
    Public Property EstadoAjuste() As Entidades.Estado
        Get
            Return vEstadoAjuste
        End Get
        Set(ByVal value As Entidades.Estado)
            vEstadoAjuste = value
        End Set
    End Property

End Class
