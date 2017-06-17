Public Class PromocionBLL


    'A ver que pasa con las variables globales.
    Dim MiProductoBLL As New ProductoBLL
    Dim MiPromocionDAL As New DAL.PromocionDAL
    Dim MiClienteBLL As New ClienteBLL

    Sub New()

    End Sub

    Public Function PromocionXProducto() As List(Of Entidades.Promocion)
        Try
            Dim MiListaProductoEntidad As New List(Of Entidades.Producto)
            Dim MiListaMangaEntidad As New List(Of Entidades.Manga)
            Dim MiProductoBLL As New BLL.ProductoBLL
            Dim MiMangaBLL As New BLL.MangaBLL

            MiListaProductoEntidad = MiProductoBLL.ListarProductos
            MiListaMangaEntidad = MiMangaBLL.ListarProductosManga

            For Each MiProducto As Entidades.Producto In MiListaProductoEntidad
                MiProducto = MiProductoBLL.CalificarNovedadUnProducto(MiProducto)
                MiProducto = MiProductoBLL.CalificarFlujoVentaUnProducto(MiProducto)
            Next


            For Each MiManga As Entidades.Manga In MiListaMangaEntidad
                MiManga = MiMangaBLL.CalificarNovedadUnProducto(MiManga)
                MiManga = MiMangaBLL.CalificarFlujoVentaUnProducto(MiManga)
            Next


            MiListaProductoEntidad.AddRange(MiListaMangaEntidad)
            'Falta quitar los productos sin stock
            MiListaProductoEntidad.RemoveAll(Function(x) x.Stock = 0)



            Dim MiListaPromocionEntidad As New List(Of Entidades.Promocion)
            'MiListaPromocionEntidad = MiPromocionDAL.ListarPromocionXProducto()

            For Each MiProducto As Entidades.Producto In MiListaProductoEntidad
                Dim MiPromocion As New Entidades.Promocion
                MiPromocion.Producto = MiProducto
                MiListaPromocionEntidad.Add(MiPromocion)
            Next

            MiListaPromocionEntidad = Me.ObtenerProductosNovedadPromedio(MiListaPromocionEntidad)
            MiListaPromocionEntidad = Me.ObtenerProductosFlujoVentaPromedio(MiListaPromocionEntidad)

            For Each MiPromocion As Entidades.Promocion In MiListaPromocionEntidad
                If MiPromocion.Producto.TipoProducto.Descripcion = "Manga" And MiPromocion.Producto.Importado = True Then
                    MiPromocion.Descuento = 10
                ElseIf MiPromocion.Producto.TipoProducto.Descripcion = "Manga" And MiPromocion.Producto.Importado = False Then
                    MiPromocion.Descuento = 15
                End If

                If MiPromocion.Producto.TipoProducto.Descripcion = "Comic" And MiPromocion.Producto.Importado = True Then
                    MiPromocion.Descuento = 5
                ElseIf MiPromocion.Producto.TipoProducto.Descripcion = "Comic" And MiPromocion.Producto.Importado = False Then
                    MiPromocion.Descuento = 10
                End If
                If MiPromocion.Producto.TipoProducto.Descripcion = "Figura de Acción" And MiPromocion.Producto.Importado = True Then
                    MiPromocion.Descuento = 5
                ElseIf MiPromocion.Producto.TipoProducto.Descripcion = "Figura de Acción" And MiPromocion.Producto.Importado = False Then
                    MiPromocion.Descuento = 15
                End If
                If MiPromocion.Producto.TipoProducto.Descripcion = "Cosplay" And MiPromocion.Producto.Importado = True Then
                    MiPromocion.Descuento = 7
                ElseIf MiPromocion.Producto.TipoProducto.Descripcion = "Cosplay" And MiPromocion.Producto.Importado = False Then
                    MiPromocion.Descuento = 12
                End If
                If MiPromocion.Producto.TipoProducto.Descripcion = "Merchandising" And MiPromocion.Producto.Importado = True Then
                    MiPromocion.Descuento = 7
                ElseIf MiPromocion.Producto.TipoProducto.Descripcion = "Merchandising" And MiPromocion.Producto.Importado = False Then
                    MiPromocion.Descuento = 12
                End If
            Next


            Return MiListaPromocionEntidad
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Function



    Public Function PromocionXCliente(ByVal paramClienteEntidad As Entidades.Cliente) As List(Of Entidades.Promocion)
        Try
            'Esta te la hago acá porque voy a toquetear la lista....
            Dim MiListaPromocionEntidad As New List(Of Entidades.Promocion)
            Dim MiIndiceDeCliente As Integer
            MiIndiceDeCliente = MiClienteBLL.CalcularIndiceCliente(paramClienteEntidad)
            Dim MiGeneroEntidad As New Entidades.Genero
            Dim MiTipoProductoEntidad As New Entidades.TipoProducto
            Dim MiProductoBLL As New BLL.ProductoBLL
            Dim MiMangaBLL As New BLL.MangaBLL

            MiGeneroEntidad = (New ClienteBLL).EvaluarHistorialGenero(paramClienteEntidad)
            MiTipoProductoEntidad = (New ClienteBLL).EvaluarHistorialTProducto(paramClienteEntidad)

            If IsNothing(MiGeneroEntidad) Or IsNothing(MiTipoProductoEntidad) Then
                Return Nothing
            Else
                'Esto obtiene Productos + Mangas
                MiListaPromocionEntidad = MiPromocionDAL.ListarPromocionXCliente(paramClienteEntidad, MiTipoProductoEntidad, MiGeneroEntidad)
                'CHEQUEAR BIEN ESTO.... PONELE QUE FUNQUE...

                MiListaPromocionEntidad.RemoveAll(Function(x) x.Producto.Stock <= 0)




                For Each MiPromocionEntidad As Entidades.Promocion In MiListaPromocionEntidad
                    MiPromocionEntidad.Producto = MiProductoBLL.CalificarFlujoVentaUnProducto(MiPromocionEntidad.Producto)
                    'Elijo que algoritmo aplicar
                    If TypeOf (MiPromocionEntidad.Producto) Is Entidades.Manga Then
                        MiPromocionEntidad.Producto = MiMangaBLL.CalificarNovedadUnProducto(MiPromocionEntidad.Producto)
                    Else
                        MiPromocionEntidad.Producto = MiProductoBLL.CalificarNovedadUnProducto(MiPromocionEntidad.Producto)
                    End If
                Next
                'Realizo el filtro de calificaión de novedad con valor promedio
                MiListaPromocionEntidad = Me.ObtenerProductosNovedadPromedio(MiListaPromocionEntidad)
                MiListaPromocionEntidad = Me.ObtenerProductosFlujoVentaPromedio(MiListaPromocionEntidad)

                For Each MiPromocionEntidad As Entidades.Promocion In MiListaPromocionEntidad
                    MiPromocionEntidad.Descuento = MiIndiceDeCliente
                Next

                Return MiListaPromocionEntidad
            End If
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Function


    Public Function ObtenerProductosNovedadPromedio(ByVal paramListaPromocionEntidad As List(Of Entidades.Promocion)) As List(Of Entidades.Promocion)
        Try
            Dim CantidadProductos As Integer
            Dim CalificacionTotal As Integer
            For Each MiPromocionEntidad As Entidades.Promocion In paramListaPromocionEntidad
                CantidadProductos += 1
                CalificacionTotal += MiPromocionEntidad.Producto.Novedad
            Next

            Dim CalificacionPromedio As Double
            CalificacionPromedio = CalificacionTotal / CantidadProductos
            paramListaPromocionEntidad.RemoveAll(Function(x) x.Producto.Novedad > CalificacionPromedio)
            Return paramListaPromocionEntidad
        Catch ex As Exception
        End Try
    End Function


    Public Function ObtenerProductosFlujoVentaPromedio(ByVal paramListaPromocionEntidad As List(Of Entidades.Promocion)) As List(Of Entidades.Promocion)
        Try
            Dim CantidadProductos As Integer
            Dim CalificacionTotal As Integer
            For Each MiPromocionEntidad As Entidades.Promocion In paramListaPromocionEntidad
                CantidadProductos += 1
                CalificacionTotal += MiPromocionEntidad.Producto.FlujoVenta
            Next
            Dim CalificacionPromedio As Double
            CalificacionPromedio = CalificacionTotal / CantidadProductos
            paramListaPromocionEntidad.RemoveAll(Function(x) x.Producto.FlujoVenta > CalificacionPromedio)
            Return paramListaPromocionEntidad
        Catch ex As Exception
        End Try
    End Function
End Class
