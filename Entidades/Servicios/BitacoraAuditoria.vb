Public Class BitacoraAuditoria
    Inherits BitacoraBase
    Sub New()

    End Sub
    Sub New(ByVal paramTipoOpe As tipoOperacionBitacora, paramUsuario As Entidades.Usuario, ByVal paramIDDescripcion As Integer)
        Me.TipoOperacion = paramTipoOpe
        Me.FechaHora = DateTime.Now
        Me.Usuario = paramUsuario
        Me.ID_Descripcion = paramIDDescripcion
    End Sub

    'Cambio por integer, porque va a ser traducible, asì que es el ID de la Descripciòn que va a estar gaurdada en idioma
    Private vID_Descripcion As Integer
    Public Property ID_Descripcion() As Integer
        Get
            Return vID_Descripcion
        End Get
        Set(ByVal value As Integer)
            vID_Descripcion = value
        End Set
    End Property

    Private vDVH As String
    Public ReadOnly Property DVH() As String
        Get
            Return Me.ID & Me.Usuario.ID & Me.TipoOperacion & Me.ID_Descripcion & Me.FechaHora.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.Usuario.IP & Me.Usuario.WebBrowser
        End Get

    End Property
End Class
