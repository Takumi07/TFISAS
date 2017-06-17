Public Class VentaBLL

    Dim MiVentaDAL As New DAL.VentaDAL

    Public Sub AltaVenta(ByVal paramVenta As Entidades.Venta)
        Try
            MiVentaDAL.AltaVenta(paramVenta)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, paramVenta.Cliente, 257))
        Catch ex As Entidades.NoHayStock
            Throw ex
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(paramVenta.Cliente, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(paramVenta.Cliente, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub





    Public Function ObtenerFacturas(ByVal paramCliente As Entidades.Cliente) As List(Of Entidades.Factura)
        Try
            Return MiVentaDAL.ObtenerFacturas(paramCliente)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(paramCliente, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(paramCliente, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
End Class
