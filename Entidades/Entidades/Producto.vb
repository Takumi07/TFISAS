Public Class Producto
    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
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

    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vStock As Integer
    Public Property Stock() As Integer
        Get
            Return vStock
        End Get
        Set(ByVal value As Integer)
            vStock = value
        End Set
    End Property

    Private vFecha_Alta_Sistema As DateTime
    Public Property Fecha_Alta_Sistema() As DateTime
        Get
            Return vFecha_Alta_Sistema
        End Get
        Set(ByVal value As DateTime)
            vFecha_Alta_Sistema = value
        End Set
    End Property

    Private vFecha_Salida As Date
    Public Property Fecha_Salida() As Date
        Get
            Return vFecha_Salida
        End Get
        Set(ByVal value As Date)
            vFecha_Salida = value
        End Set
    End Property

    Private vFecha_Arribo_Sucursal As Date
    Public Property Fecha_Arribo_Sucursal() As Date
        Get
            Return vFecha_Arribo_Sucursal
        End Get
        Set(ByVal value As Date)
            vFecha_Arribo_Sucursal = value
        End Set
    End Property

    Private vNovedad As Integer
    Public Property Novedad() As Integer
        Get
            Return vNovedad
        End Get
        Set(ByVal value As Integer)
            vNovedad = value
        End Set
    End Property

    Private vFlujoVenta As Integer
    Public Property FlujoVenta() As Integer
        Get
            Return vFlujoVenta
        End Get
        Set(ByVal value As Integer)
            vFlujoVenta = value
        End Set
    End Property

    Private vGenero As Entidades.Genero
    Public Property Genero() As Entidades.Genero
        Get
            Return vGenero
        End Get
        Set(ByVal value As Entidades.Genero)
            vGenero = value
        End Set
    End Property


    Private vTipoProducto As Entidades.TipoProducto
    Public Property TipoProducto() As Entidades.TipoProducto
        Get
            Return vTipoProducto
        End Get
        Set(ByVal value As Entidades.TipoProducto)
            vTipoProducto = value
        End Set
    End Property

    Private vBL As Boolean
    Public Property BL() As Boolean
        Get
            Return vBL
        End Get
        Set(ByVal value As Boolean)
            vBL = value
        End Set
    End Property


    Private vImportado As Boolean
    Public Property Importado() As Boolean
        Get
            Return vImportado
        End Get
        Set(ByVal value As Boolean)
            vImportado = value
        End Set
    End Property

    Private vPrecio As Precio
    Public Property Precio() As Precio
        Get
            Return vPrecio
        End Get
        Set(ByVal value As Precio)
            vPrecio = value
        End Set
    End Property


    Private vCantidadComprada As Integer
    Public Property CantidadComprada() As Integer
        Get
            Return vCantidadComprada
        End Get
        Set(ByVal value As Integer)
            vCantidadComprada = value
        End Set
    End Property


    Private vListaImagenes As New List(Of String)
    Public Property ListaImagenes() As List(Of String)
        Get
            Return vListaImagenes
        End Get
        Set(ByVal value As List(Of String))
            vListaImagenes = value
        End Set
    End Property

    Public ReadOnly Property DVH As String
        Get
            Return Me.vID & Me.vGenero.ID_Genero & Me.vTipoProducto.ID_TipoProducto & Me.vDescripcion & Me.vNombre & Me.vFecha_Alta_Sistema.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.vFecha_Salida.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.vFecha_Arribo_Sucursal.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.vImportado & Me.vBL
        End Get
    End Property


    Public Overrides Function ToString() As String
        Return vNombre
    End Function
End Class
