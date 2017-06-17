Public Class PermisoCompuesto
    Inherits PermisoBase

    Sub New()

    End Sub

    Sub New(ByVal paramID As Integer)
        Me.ID = paramID
    End Sub


    Private vEditable As Boolean
    Public Property Editable() As Boolean
        Get
            Return vEditable
        End Get
        Set(ByVal value As Boolean)
            vEditable = value
        End Set
    End Property

    Public vlistaPermisos As New List(Of PermisoBase)
    Public Property ListaPermisosSimple() As List(Of PermisoBase)
        Get
            Return vlistaPermisos
        End Get
        Set(ByVal value As List(Of PermisoBase))
            vlistaPermisos = value
        End Set
    End Property

    Public Overrides Function agregarHijo(ByVal paramPermiso As PermisoBase) As Boolean
        If Not vlistaPermisos.Contains(paramPermiso) Then
            Me.vlistaPermisos.Add(paramPermiso)
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function tieneHijos() As Boolean
        Return True
    End Function

    Public Overrides Function ObtenerHijos() As List(Of PermisoBase)
        'Cambie la lista por la property
        Return Me.ListaPermisosSimple
    End Function

    Public Function ValidaURL(ByVal paramURL As String) As Boolean
        'soy familia
        If Me.tieneHijos = True Then
            For Each miHijo As Entidades.PermisoBase In Me.vlistaPermisos
                If TypeOf (miHijo) Is Entidades.PermisoSimple Then
                    If paramURL.ToUpper = miHijo.URL.ToUpper Then
                        Return True
                        Exit Function
                    End If
                Else
                    Dim bool As Boolean
                    bool = DirectCast(miHijo, Entidades.PermisoCompuesto).ValidaURL(paramURL)
                    If bool = True Then
                        Return True
                    End If
                End If
            Next
        Else
            Return Me.vlistaPermisos.Any(Function(x) x.URL.ToUpper = paramURL.ToUpper)
        End If
    End Function

End Class
