Public Class Palabra
    Private vCodigo As String
    Public Property Codigo() As String
        Get
            Return vCodigo
        End Get
        Set(ByVal value As String)
            vCodigo = value
        End Set
    End Property

    Private vTraduccion As String
    Public Property Traduccion() As String
        Get
            Return vTraduccion
        End Get
        Set(ByVal value As String)
            vTraduccion = value
        End Set
    End Property

    Private vID_Control As Integer
    Public Property ID_Control() As Integer
        Get
            Return vID_Control
        End Get
        Set(ByVal value As Integer)
            vID_Control = value
        End Set
    End Property


    Public Overrides Function Equals(obj As Object) As Boolean
        If Me.ID_Control = DirectCast(obj, Entidades.Palabra).ID_Control Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
