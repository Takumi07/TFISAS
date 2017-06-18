Public Class Factura

    'Sacar estos datos de la tabla DATOFACTURA

    Private vRazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return vRazonSocial
        End Get
        Set(ByVal value As String)
            vRazonSocial = value
        End Set
    End Property


    Private vActividad As String
    Public Property Actividad() As String
        Get
            Return vActividad
        End Get
        Set(ByVal value As String)
            vActividad = value
        End Set
    End Property

    Private vDireccion As String
    Public Property Direccion() As String
        Get
            Return vDireccion
        End Get
        Set(ByVal value As String)
            vDireccion = value
        End Set
    End Property


    Private vCiudad As String
    Public Property Ciudad() As String
        Get
            Return vCiudad
        End Get
        Set(ByVal value As String)
            vCiudad = value
        End Set
    End Property


    Private vPais As String
    Public Property Pais() As String
        Get
            Return vPais
        End Get
        Set(ByVal value As String)
            vPais = value
        End Set
    End Property

    Private vContacto As String
    Public Property Contacto() As String
        Get
            Return vContacto
        End Get
        Set(ByVal value As String)
            vContacto = value
        End Set
    End Property

    Private vCorreo As String
    Public Property Correo() As String
        Get
            Return vCorreo
        End Get
        Set(ByVal value As String)
            vCorreo = value
        End Set
    End Property


    Private vCuit As String
    Public Property CUIT() As String
        Get
            Return vCuit
        End Get
        Set(ByVal value As String)
            vCuit = value
        End Set
    End Property

    Private vNroIngresosBrutos As String
    Public Property NroIngresosBrutos() As String
        Get
            Return vNroIngresosBrutos
        End Get
        Set(ByVal value As String)
            vNroIngresosBrutos = value
        End Set
    End Property

    Private vFechaInicioActividad As Date
    Public Property FechaInicioActividad() As Date
        Get
            Return vFechaInicioActividad
        End Get
        Set(ByVal value As Date)
            vFechaInicioActividad = value
        End Set
    End Property


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
