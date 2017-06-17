Public Class Genero

    Private vID_Genero As Integer
    Public Property ID_Genero() As Integer
        Get
            Return vID_Genero
        End Get
        Set(ByVal value As Integer)
            vID_Genero = value
        End Set
    End Property



    Private VDescripcion As String
    Public Property Descripcion() As String
        Get
            Return VDescripcion
        End Get
        Set(ByVal value As String)
            VDescripcion = value
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


    Public Overrides Function ToString() As String
        Return VDescripcion
    End Function
End Class
