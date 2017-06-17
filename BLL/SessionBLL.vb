'Public Class SessionBLL
'    Private Sub New()

'    End Sub

'    Private Shared ReadOnly _current As SessionBLL = New SessionBLL

'    Public Shared Function Current() As SessionBLL
'        Return (_current)
'    End Function


'    'Modificado para obtener IP y Webbrowser
'    Public Shared Sub Inicializar(ByVal ParamUsuario As Entidades.Usuario)
'        'BITACOREAR
'        _current.vUsuario = ParamUsuario

'        'BitacoraBLL.RegistrarBitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Login, 1, "ACA VA IP", "ACA VA WEBBROWSER", "VALOR ANTERIOR", "VALOR POSTERIOR")


'    End Sub

'    Private vUsuario As Entidades.Usuario
'    Public ReadOnly Property Usuario() As Entidades.Usuario
'        Get
'            Return vUsuario
'        End Get
'    End Property

'#Region "Agregado"
'    Public Shared Sub AsignarIdioma(ByVal paramIdioma As Entidades.Idioma)
'        _current.Usuario.Idioma = paramIdioma
'    End Sub
'#End Region



'    Public Shared Sub Finalizar()
'        'BITACOREAR
'        _current.vUsuario = Nothing
'    End Sub



'End Class
