Public Class ProvinciaDAL

    Public Function ListarProvincias() As List(Of Entidades.Provincia)
        Try
            Dim MiListaProvincias As New List(Of Entidades.Provincia)
            Dim miDataTable As DataTable = DAL.Conexion.Leer("ListarProvincias")
            For Each miDataRow As DataRow In miDataTable.Rows
                Dim MiProvincia As New Entidades.Provincia
                Me.FormatearProvincia(miDataRow, MiProvincia)
                MiListaProvincias.Add(MiProvincia)
            Next
            Return MiListaProvincias
        Catch ex As Exception

        End Try
    End Function


    Public Function ObtenerProvincia(ByVal paramID As Integer) As Entidades.Provincia
        Try
            Dim misParametros As New Hashtable
            Dim MiPronvincia As New Entidades.Provincia
            Dim miDataTable As New DataTable
            misParametros.Add("@ID_Provincia", paramID)
            miDataTable = Conexion.Leer("listarunaprovincia", misParametros)
            If miDataTable.Rows.Count > 0 Then
                FormatearProvincia(miDataTable.Rows(0), MiPronvincia)
                Return MiPronvincia
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub FormatearProvincia(ByVal paramRow As DataRow, ByVal paramProvincia As Entidades.Provincia)
        paramProvincia.ID = paramRow.Item("ID_Provincia")
        paramProvincia.Descripcion = paramRow.Item("Descripcion")
    End Sub

End Class
