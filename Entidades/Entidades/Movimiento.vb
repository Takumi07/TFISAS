Public Class Movimiento


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


    Private vTipoMovimiento As Entidades.TipoMovimiento
    Public Property TipoMovimiento() As Entidades.TipoMovimiento
        Get
            Return vTipoMovimiento
        End Get
        Set(ByVal value As Entidades.TipoMovimiento)
            vTipoMovimiento = value
        End Set
    End Property


    Private vNroFactura As Integer
    Public Property NroFactura() As Integer
        Get
            Return vNroFactura
        End Get
        Set(ByVal value As Integer)
            vNroFactura = value
        End Set
    End Property




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

    Private vNroRenglon As Integer
    Public Property NroRenglon() As Integer
        Get
            Return vNroRenglon
        End Get
        Set(ByVal value As Integer)
            vNroRenglon = value
        End Set
    End Property



    Private vAjusteStock As Entidades.AjustarStock
    Public Property AjusteStock() As Entidades.AjustarStock
        Get
            Return vAjusteStock
        End Get
        Set(ByVal value As Entidades.AjustarStock)
            vAjusteStock = value
        End Set
    End Property

    Private vFecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return vFecha
        End Get
        Set(ByVal value As DateTime)
            vFecha = value
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

    Public ReadOnly Property DVH() As String
        Get
            If Not IsNothing(Me.vAjusteStock) Then
                Return Me.ID & Me.Producto.ID & Me.TipoMovimiento.ID & Me.AjusteStock.ID & Me.Fecha.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.Cantidad
            End If

            If Me.vNroFactura <> 0 Then
                Return Me.ID & Me.Producto.ID & Me.TipoMovimiento.ID & Me.NroFactura & Me.Fecha.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.Cantidad
            End If

            If Me.vNroRemito <> 0 Then
                Return Me.ID & Me.Producto.ID & Me.TipoMovimiento.ID & Me.NroRemito & Me.Proveedor.ID & Me.NroRenglon & Me.Fecha.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.Cantidad
            End If
        End Get
    End Property
End Class
