Public Class FacturaProveedorDAL
    Public Sub CargarFacturaProveedor(ByVal paramFacturaProveedor As Entidades.FacturaProveedor)

    End Sub

    Public Sub ModificarFacturaSinAprobar(ByVal paramFactura As Entidades.FacturaProveedor)

    End Sub

    Public Sub EliminarFacturaSinAprobar(ByVal paramFactura As Entidades.FacturaProveedor)

    End Sub

    Public Sub AprobarFactura(ByVal paramFactura As Entidades.FacturaProveedor)

        For Each MiRenglon As Entidades.FacturaProveedorRenglon In paramFactura.FacturaRenglon
            Dim NuevoStock As Integer
            NuevoStock = MiRenglon.Producto.Stock + MiRenglon.Cantidad

        Next
    End Sub


    Public Sub RechazarFactura(ByVal paramFactura As Entidades.FacturaProveedor)

    End Sub
    Public Function ListarEstados() As List(Of Entidades.Estado)

    End Function

    Public Function ListarFacturasPendientesAprobacion() As List(Of Entidades.FacturaProveedor)

    End Function


    Private Sub FormatearFacturaProveedor(ByVal paramRow As DataRow, ByVal paramFacturaProveedor As Entidades.FacturaProveedor)
    End Sub

    Private Sub FormatearEstadoFactura(ByVal paramRow As DataRow, ByVal paramEstadoFactura As Entidades.Estado)

    End Sub
End Class
