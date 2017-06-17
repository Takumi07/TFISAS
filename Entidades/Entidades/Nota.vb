Public Class Nota

    Private vTipoNota As TipoNota
    Public Property TipoDeNota() As TipoNota
        Get
            Return vTipoNota
        End Get
        Set(ByVal value As TipoNota)
            vTipoNota = value
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


    Private vNroFactura As Integer
    Public Property NroFactura() As Integer
        Get
            Return vNroFactura
        End Get
        Set(ByVal value As Integer)
            vNroFactura = value
        End Set
    End Property


    Private vNro As Integer
    Public Property Nro() As Integer
        Get
            Return vNro
        End Get
        Set(ByVal value As Integer)
            vNro = value
        End Set
    End Property



End Class
