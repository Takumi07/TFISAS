Public Class TipoMovimientoDAL
    Public Function ListarTipoMovimiento() As List(Of Entidades.TipoMovimiento)

        Dim MisMovimientos As New List(Of Entidades.TipoMovimiento)
        Dim miDataTable As DataTable = DAL.Conexion.Leer("ListarTipoMovimiento")
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiMovimiento As New Entidades.TipoMovimiento
            FormatearTipoMovimiento(miDataRow, MiMovimiento)
            MisMovimientos.Add(MiMovimiento)
        Next
        Return MisMovimientos
    End Function



    Private Sub FormatearTipoMovimiento(ByVal paramDataRow As DataRow, ByVal paramTipoMovimiento As Entidades.TipoMovimiento)
        paramTipoMovimiento.ID = paramDataRow.Item("ID_TipoMovimiento")
        paramTipoMovimiento.Descripcion = paramDataRow.Item("Descripcion")
        paramTipoMovimiento.Valor = paramDataRow.Item("Valor")
    End Sub




End Class
