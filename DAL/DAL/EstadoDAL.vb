Public Class EstadoDAL
    Public Function ListarEstados() As List(Of Entidades.Estado)

    End Function


    Public Shared Sub FormatearEstado(ByVal paramDataRow As DataRow, ByVal paramEstado As Entidades.Estado)
        paramEstado.Estado = paramDataRow.Item("ID_Estado")
        paramEstado.Descripcion = paramDataRow.Item("Descripcion")
    End Sub

    Public Shared Function ObtenerUnEstado(ByVal paramID As Integer) As Entidades.Estado
        Dim MiEstado As New Entidades.Estado
        Dim misparametros As New Hashtable
        misparametros.Add("@ID_Estado", paramID)
        Dim MiDataTable As DataTable = DAL.Conexion.Leer("ListarUnEstado", misparametros)
        If MiDataTable.Rows.Count = 1 Then
            FormatearEstado(MiDataTable.Rows.Item(0), MiEstado)
        End If
        Return MiEstado
    End Function
End Class
