Public Class Direccion

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _altura As Integer
    Public Property Altura() As Integer
        Get
            Return _altura
        End Get
        Set(ByVal value As Integer)
            _altura = value
        End Set
    End Property

    Private _calle As String
    Public Property Calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal value As String)
            _calle = value
        End Set
    End Property

    Private _codigoPostal As String
    Public Property CodigoPostal() As String
        Get
            Return _codigoPostal
        End Get
        Set(ByVal value As String)
            _codigoPostal = value
        End Set
    End Property


    Private _departamento As String
    Public Property Departamento() As String
        Get
            Return _departamento
        End Get
        Set(ByVal value As String)
            _departamento = value
        End Set
    End Property


    Private _localidad As String
    Public Property Localidad() As String
        Get
            Return _localidad
        End Get
        Set(ByVal value As String)
            _localidad = value
        End Set
    End Property

    Private _piso As String
    Public Property Piso() As String
        Get
            Return _piso
        End Get
        Set(ByVal value As String)
            _piso = value
        End Set
    End Property



    Private vProvincia As Entidades.Provincia
    Public Property Provincia() As Entidades.Provincia
        Get
            Return vProvincia
        End Get
        Set(ByVal value As Entidades.Provincia)
            vProvincia = value
        End Set
    End Property


    Public ReadOnly Property DVH() As String
        Get
            Return Me.ID & Me.Altura & Me.Calle & Me.CodigoPostal & Me.Departamento & Me.Localidad & Me.Piso & Me.Provincia.ID
        End Get
    End Property
End Class
