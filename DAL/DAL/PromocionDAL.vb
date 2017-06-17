Public Class PromocionDAL

    Public Function ListarPromocionXCliente(ByVal paramClienteEntidad As Entidades.Cliente, ByVal paramTProducto As Entidades.TipoProducto, ByVal paramGenero As Entidades.Genero) As List(Of Entidades.Promocion)
        Dim MiListaEntidadesPromocion As New List(Of Entidades.Promocion)
        Dim MisParametros As New Hashtable
        MisParametros.Add("@ID_Genero", paramGenero.ID_Genero)
        MisParametros.Add("@ID_TipoProducto", paramTProducto.ID_TipoProducto)
        MisParametros.Add("@BL", False)
        MisParametros.Add("@ID_Cliente", paramClienteEntidad.ID)
        Dim miDataTable As DataTable = Conexion.Leer("ListarPCliente", MisParametros)

        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiPromocion As New Entidades.Promocion
            'Manga
            If miDataRow("ID_TipoProducto") = 1 Then
                Dim MiMangaEntidad As New Entidades.Manga
                MiMangaEntidad = (New MangaDAL).ObtenerUnManga(miDataRow("ID_Producto"))
                MiPromocion.Producto = MiMangaEntidad
            Else
                'Otro
                Dim MiProducto As New Entidades.Producto
                MiProducto = (New ProductoDAL).ListarUnProducto(miDataRow("ID_Producto"))
                MiPromocion.Producto = MiProducto
            End If
            MiListaEntidadesPromocion.Add(MiPromocion)
        Next
        Return MiListaEntidadesPromocion
    End Function
End Class
