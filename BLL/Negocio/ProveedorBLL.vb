Public Class ProveedorBLL

    Public Function ListarProveedores() As List(Of Entidades.Proveedor)
        Try
            Return (New DAL.ProveedorDAL).ListarProveedores()
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
End Class
