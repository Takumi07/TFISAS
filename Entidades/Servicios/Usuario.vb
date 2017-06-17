Imports System.Security.Principal


Public Class Usuario

    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
        End Set
    End Property

    Private vNombreUsuario As String
    Public Property NombreUsuario() As String
        Get
            Return vNombreUsuario
        End Get
        Set(ByVal value As String)
            vNombreUsuario = value
        End Set
    End Property

    Private vPassword As String
    Public Property Password() As String
        Get
            Return vPassword
        End Get
        Set(ByVal value As String)
            vPassword = value
        End Set
    End Property

    Private vPermiso As Entidades.PermisoCompuesto
    Public Property Permiso() As Entidades.PermisoCompuesto
        Get
            Return vPermiso
        End Get
        Set(ByVal value As Entidades.PermisoCompuesto)
            vPermiso = value
        End Set
    End Property

    Private vIdioma As Entidades.Idioma
    Public Property Idioma() As Entidades.Idioma
        Get
            Return vIdioma
        End Get
        Set(ByVal value As Entidades.Idioma)
            vIdioma = value
        End Set
    End Property


    Private vBloqueado As Boolean
    Public Property Bloqueado() As Boolean
        Get
            Return vBloqueado
        End Get
        Set(ByVal value As Boolean)
            vBloqueado = value
        End Set
    End Property

    Private vEditable As Boolean
    Public Property Editable() As Boolean
        Get
            Return vEditable
        End Get
        Set(ByVal value As Boolean)
            vEditable = value
        End Set
    End Property

    Private vIntentos As Integer
    Public Property Intentos() As Integer
        Get
            Return vIntentos
        End Get
        Set(ByVal value As Integer)
            vIntentos = value
        End Set
    End Property

    Private vFechaAlta As DateTime
    Public Property FechaAlta() As DateTime
        Get
            Return vFechaAlta
        End Get
        Set(ByVal value As DateTime)
            vFechaAlta = value
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

    Private vCorreo As String
    Public Property Correo() As String
        Get
            Return vCorreo
        End Get
        Set(ByVal value As String)
            vCorreo = value
        End Set
    End Property



    '/*AGREGADO PARA PODER BITACOREAR*/
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
    Public Property WebBrowser() As String
        Get
            Return vWebBrowser
        End Get
        Set(ByVal value As String)
            vWebBrowser = value
        End Set
    End Property


    Private vDNI As ULong
    Public Property DNI() As ULong
        Get
            Return vDNI
        End Get
        Set(ByVal value As ULong)
            vDNI = value
        End Set
    End Property

    Private vNombre As String = ""
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vApellido As String = ""
    Public Property Apellido() As String
        Get
            Return vApellido
        End Get
        Set(ByVal value As String)
            vApellido = value
        End Set
    End Property


    'Esto toma un string que es base64
    Private vImagenUsuario As String = ""
    Public Property ImagenUsuario As String
        Get
            Return vImagenUsuario
        End Get
        Set(ByVal value As String)
            vImagenUsuario = value
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return Me.NombreUsuario
    End Function
    Public ReadOnly Property DVH() As String
        Get
            Try
                Return Me.ID & Me.NombreUsuario & Me.Password & Me.Permiso.ID & Me.Idioma.ID & Me.Nombre & Me.Apellido.ToString & Me.DNI & Me.Bloqueado & Me.Editable & Me.Intentos & Me.FechaAlta.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.Correo & Me.ImagenUsuario.ToString & Me.BL
            Catch ex As Exception

            End Try
        End Get
    End Property
End Class
