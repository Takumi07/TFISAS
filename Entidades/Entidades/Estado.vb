Public Class Estado
    Sub New()


    End Sub


    Sub New(ByVal paramID As Integer)
        vID = paramID
    End Sub

    Private vID As Integer
    Public Property Estado() As Integer
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
End Class
