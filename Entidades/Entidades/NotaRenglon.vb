Public Class NotaRenglon

    Private vID_Renglon As Integer
    Public Property ID_Renglon() As Integer
        Get
            Return vID_Renglon
        End Get
        Set(ByVal value As Integer)
            vID_Renglon = value
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

    Private vDescripcion As String
    Public Property Descripcion() As String
        Get
            Return vDescripcion
        End Get
        Set(ByVal value As String)
            vDescripcion = value
        End Set
    End Property


    Private vMonto As Double
    Public Property Monto() As Double
        Get
            Return vMonto
        End Get
        Set(ByVal value As Double)
            vMonto = value
        End Set
    End Property





End Class
