Public Class Manga
    Inherits Entidades.Producto

    Private vFec_Salida_PTomo As Date
    Public Property Fec_Salida_PTomo() As Date
        Get
            Return vFec_Salida_PTomo
        End Get
        Set(ByVal value As Date)
            vFec_Salida_PTomo = value
        End Set
    End Property

    Private vN_Tomo As Integer
    Public Property N_Tomo() As Integer
        Get
            Return vN_Tomo
        End Get
        Set(ByVal value As Integer)
            vN_Tomo = value
        End Set
    End Property

    Private vEditorial As Entidades.Editorial
    Public Property Editorial() As Entidades.Editorial
        Get
            Return vEditorial
        End Get
        Set(ByVal value As Entidades.Editorial)
            vEditorial = value
        End Set
    End Property

    Public ReadOnly Property DVHM As String
        Get
            Return Me.ID & Me.vEditorial.ID & Me.vFec_Salida_PTomo.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.vN_Tomo
        End Get
    End Property

End Class
