Public Class BackupRestore
    'Ahora el nombre se va a autogenerar por la solicitud que realizaron.
    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vDirectorio As String
    Public Property Directorio() As String
        Get
            Return vDirectorio
        End Get
        Set(ByVal value As String)
            vDirectorio = value
        End Set
    End Property


    Private vUsuario As Entidades.Usuario
    Public Property Usuario() As Entidades.Usuario
        Get
            Return vUsuario
        End Get
        Set(ByVal value As Entidades.Usuario)
            vUsuario = value
        End Set
    End Property

End Class
