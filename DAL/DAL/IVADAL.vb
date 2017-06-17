Public Class IVADAL
    Public Function ListarIVA() As List(Of Entidades.IVA)
        Dim MiListaIVA As New List(Of Entidades.IVA)
        Dim miDataTable As DataTable = DAL.Conexion.Leer("ListarIVA")
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiIVA As New Entidades.IVA
            FormatearIVA(miDataRow, MiIVA)
            MiListaIVA.Add(MiIVA)
        Next
        Return MiListaIVA
    End Function

    Private Sub FormatearIVA(ByVal paramRow As DataRow, ByVal paramIVA As Entidades.IVA)
        paramIVA.ID = paramRow.Item("ID_IVA")
        paramIVA.Porcentaje = paramRow.Item("Porcentaje")
        paramIVA.Descripcion = paramRow.Item("Descripcion")
    End Sub

End Class
