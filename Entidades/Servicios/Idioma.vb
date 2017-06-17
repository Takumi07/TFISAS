Imports System.Globalization

Public Class Idioma

    Sub New()

    End Sub

    Sub New(ByVal paramID As Integer)
        Me.vID = paramID
    End Sub

    Private vID As Integer
    Public Property ID() As Integer
        Get
            Return vID
        End Get
        Set(ByVal value As Integer)
            vID = value
        End Set
    End Property

    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
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

    Private vEditable As Boolean
    Public Property Editable() As Boolean
        Get
            Return vEditable
        End Get
        Set(ByVal value As Boolean)
            vEditable = value
        End Set
    End Property

    Private vPalabras As New List(Of Entidades.Palabra)
    Public Property Palabras() As List(Of Entidades.Palabra)
        Get
            Return vPalabras
        End Get
        Set(ByVal value As List(Of Entidades.Palabra))
            vPalabras = value
        End Set
    End Property

    'Lo voy a usar para ver si lo tengo en la base de datos.
    Private _cultura As CultureInfo
    Public Property Cultura() As CultureInfo
        Get
            Return _cultura
        End Get
        Set(ByVal value As CultureInfo)
            _cultura = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Nombre.ToString
    End Function


    Public ReadOnly Property DVH() As String
        Get
            Return Me.ID & Me.Nombre & Me.Editable & Me.Cultura.Name & Me.BL
        End Get

    End Property
End Class
