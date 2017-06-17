Public Class TipoMovimientoBLL
    Dim MiTipoMovimientoDAL As New DAL.TipoMovimientoDAL
    Public Function ListarTipoMovimiento() As List(Of Entidades.TipoMovimiento)
        Try
            Return (New DAL.TipoMovimientoDAL).ListarTipoMovimiento
        Catch ex As Exception

        End Try
    End Function
End Class
