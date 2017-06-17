Public Class Precio
    Sub New()

    End Sub

    Sub New(ByVal paramPrecio As Double, ByVal paramFechaInicio As DateTime, ByVal paramFechaFin As DateTime)
        Me.vPrecio = paramPrecio
        Me.vFechaInicio = paramFechaInicio
        Me.vFechaFin = paramFechaFin
    End Sub

    Sub New(ByVal paramPrecio As Double, ByVal paramFechaInicio As DateTime)
        Me.vPrecio = paramPrecio
        Me.vFechaInicio = paramFechaInicio
    End Sub

    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
        End Set
    End Property

    Private vPrecio As Decimal
    Public Property Precio() As Decimal
        Get
            Return vPrecio
        End Get
        Set(ByVal value As Decimal)
            vPrecio = value
        End Set
    End Property

    Private vFechaInicio As DateTime
    Public Property FechaInicio() As DateTime
        Get
            Return vFechaInicio
        End Get
        Set(ByVal value As DateTime)
            vFechaInicio = value
        End Set
    End Property

    Private vFechaFin As DateTime
    Public Property FechaFin() As DateTime
        Get
            Return vFechaFin
        End Get
        Set(ByVal value As DateTime)
            vFechaFin = value
        End Set
    End Property
End Class
