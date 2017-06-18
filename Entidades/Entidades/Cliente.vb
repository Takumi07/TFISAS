Public Class Cliente
    Inherits Usuario

    Private vID_Cliente As Integer
    Public Property ID_Cliente() As Integer
        Get
            Return vID_Cliente
        End Get
        Set(ByVal value As Integer)
            vID_Cliente = value
        End Set
    End Property




    Private vFechaNacimiento As Date
    Public Property FechaNacimiento() As Date
        Get
            Return vFechaNacimiento
        End Get
        Set(ByVal value As Date)
            vFechaNacimiento = value
        End Set
    End Property


    Private vTelefono As String
    Public Property Telefono() As String
        Get
            Return vTelefono
        End Get
        Set(ByVal value As String)
            vTelefono = value
        End Set
    End Property


    Private vDireccion As Direccion
    Public Property Direccion() As Direccion
        Get
            Return vDireccion
        End Get
        Set(ByVal value As Direccion)
            vDireccion = value
        End Set
    End Property


    Public ReadOnly Property DVHC As String
        Get
            Return Me.ID_Cliente & Me.ID & Me.Direccion.ID & Me.FechaNacimiento.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Me.Telefono & Me.BL
        End Get
    End Property

End Class
