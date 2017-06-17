Public MustInherit Class BitacoraBase
    Public Enum tipoOperacionBitacora
        Alta = 1
        Baja = 2
        Modificacion = 3
        Login = 4
        Logout = 5
        Bloqueo = 6
        Desbloqueo = 7
        Backup = 8
        Restore = 9
        Errores = 10
    End Enum

    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
        End Set
    End Property

    Private vFechaHora As DateTime
    Public Property FechaHora() As DateTime
        Get
            Return vFechaHora
        End Get
        Set(ByVal value As DateTime)
            vFechaHora = value
        End Set
    End Property

    Private vTipoOperacion As tipoOperacionBitacora
    Public Property TipoOperacion() As tipoOperacionBitacora
        Get
            Return vTipoOperacion
        End Get
        Set(ByVal value As tipoOperacionBitacora)
            vTipoOperacion = value
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




    'usado solo para la visualizaciòn!!!!!!
#Region "Solo para listar"
    Private vIP As String
    Public Property IP() As String
        Get
            Return vIP
        End Get
        Set(ByVal value As String)
            vIP = value
        End Set
    End Property


    Private vWebBrowser As String
    Public Property Webbrowser() As String
        Get
            Return vWebBrowser
        End Get
        Set(ByVal value As String)
            vWebBrowser = value
        End Set
    End Property
#End Region
End Class
