Public Class BitacoraErrores
    Inherits BitacoraBase
    Sub New()

    End Sub

    Sub New(paramStackTrace As String, paramTipoException As String, paramMensaje As String)
        Me.TipoOperacion = Entidades.BitacoraBase.tipoOperacionBitacora.Errores
        Me.FechaHora = DateTime.Now
        Me.StackTrace = paramStackTrace
        Me.TipoException = paramTipoException
        Me.Mensaje = paramMensaje
    End Sub



    Sub New(paramUsuario As Entidades.Usuario, paramStackTrace As String, paramTipoException As String, paramMensaje As String)
        Me.TipoOperacion = Entidades.BitacoraBase.tipoOperacionBitacora.Errores
        Me.FechaHora = DateTime.Now
        Me.Usuario = paramUsuario
        Me.StackTrace = paramStackTrace
        Me.TipoException = paramTipoException
        Me.Mensaje = paramMensaje
    End Sub

    Private vStackTrace As String
    Public Property StackTrace() As String
        Get
            Return vStackTrace
        End Get
        Set(ByVal value As String)
            vStackTrace = value
        End Set
    End Property

    Private vTipoException As String
    Public Property TipoException() As String
        Get
            Return vTipoException
        End Get
        Set(ByVal value As String)
            vTipoException = value
        End Set
    End Property

    Private vMensaje As String
    Public Property Mensaje() As String
        Get
            Return vMensaje
        End Get
        Set(ByVal value As String)
            vMensaje = value
        End Set
    End Property



    Public ReadOnly Property DVH() As String
        Get
            Return Me.ID & Me.Usuario.ID & Me.TipoOperacion & Me.FechaHora.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.Usuario.IP & Me.Usuario.WebBrowser & Me.StackTrace & Me.Mensaje & Me.TipoException
        End Get
    End Property
End Class
