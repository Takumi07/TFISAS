Public Class ProveedorDAL


    Public Function ListarProveedores() As List(Of Entidades.Proveedor)
        Dim MiListaProveedor As New List(Of Entidades.Proveedor)
        Dim misParametros As New Hashtable
        misParametros.Add("@bl", False)
        Dim miDataTable As DataTable = DAL.Conexion.Leer("listarproveedores", misParametros)
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiProveedor As New Entidades.Proveedor
            Me.FormatearProveedor(miDataRow, MiProveedor)
            MiListaProveedor.Add(MiProveedor)
        Next
        Return MiListaProveedor
    End Function



    Public Function ObtenerProveedor(ByVal ID_Proveedor As Integer) As Entidades.Proveedor
        Dim MiProveedor As New Entidades.Proveedor
        Dim misparametros As New Hashtable
        misparametros.Add("@ID_Proveedor", ID_Proveedor)
        Dim MiDataTable As DataTable = DAL.Conexion.Leer("ListarUnProveedor", misparametros)
        If MiDataTable.Rows.Count = 1 Then
            Me.FormatearProveedor(MiDataTable.Rows.Item(0), MiProveedor)
        End If
        Return MiProveedor
    End Function

    Private Sub FormatearProveedor(ByVal paramRow As DataRow, ByVal paramProveedor As Entidades.Proveedor)
        paramProveedor.ID = paramRow.Item("ID_Proveedor")
        paramProveedor.Nombre = paramRow.Item("Nombre")
        paramProveedor.Correo = paramRow.Item("Correo")
        paramProveedor.Contacto = paramRow.Item("Contacto")
        paramProveedor.BL = paramRow.Item("BL")
    End Sub
End Class
