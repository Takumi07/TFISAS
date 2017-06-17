Public Class IVA

    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
        End Set
    End Property


    Private vPorcentaje As Double
    Public Property Porcentaje() As Double
        Get
            Return vPorcentaje
        End Get
        Set(ByVal value As Double)
            vPorcentaje = value
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
End Class
