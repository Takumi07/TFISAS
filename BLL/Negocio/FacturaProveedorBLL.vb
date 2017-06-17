Public Class FacturaProveedorBLL
    Dim MiFacturaProveedor As New DAL.FacturaProveedorDAL

    Public Sub CargarFacturaProveedor(ByVal paramFacturaProveedor As Entidades.FacturaProveedor)

    End Sub

    Public Sub ModificarFacturaSinAprobar(ByVal paramFactura As Entidades.FacturaProveedor)

    End Sub

    Public Sub EliminarFacturaSinAprobar(ByVal paramFactura As Entidades.FacturaProveedor)

    End Sub

    Public Sub AprobarFactura(ByVal paramFactura As Entidades.FacturaProveedor)

    End Sub


    Public Sub RechazarFactura(ByVal paramFactura As Entidades.FacturaProveedor)

    End Sub

    Public Function ListarEstados() As List(Of Entidades.Estado)

    End Function

    Public Function ListarFacturasPendientesAprobacion() As List(Of Entidades.FacturaProveedor)

    End Function
End Class
