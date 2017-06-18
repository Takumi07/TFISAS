Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Entidades
Public Class ProductoDAL



    ''' <summary>
    ''' Este método NO lista los mangas
    ''' </summary>
    ''' <returns></returns>

    Public Function ListarProductos() As List(Of Entidades.Producto)
        Try
            Dim MiListaProductos As New List(Of Entidades.Producto)

            Dim MisParametros As New Hashtable
            MisParametros.Add("@BL", False)
            Dim miDataTable As DataTable = Conexion.Leer("ListarProductos", MisParametros)
            For Each miDataRow As DataRow In miDataTable.Rows
                Dim MiProductoEntidad As New Entidades.Producto
                FormatearProducto(miDataRow, MiProductoEntidad)
                MiListaProductos.Add(MiProductoEntidad)
            Next
            Return MiListaProductos

        Catch ex As Exception

        End Try
    End Function


    ''' <summary>
    '''Método con Lazy Loading que lista todos los productos NO DADOS DE BAJA para ver su stock. INCLUYE LOS MANGAS. Objetos INCOMPLETOS. 
    ''' </summary>
    ''' <returns></returns>
    Public Function ListarTodosProductosStock() As List(Of Entidades.Producto)
        Try
            Dim MiListaProductos As New List(Of Entidades.Producto)

            Dim MisParametros As New Hashtable
            MisParametros.Add("@BL", False)
            Dim miDataTable As DataTable = Conexion.Leer("ListarTodosProductosStock", MisParametros)
            For Each miDataRow As DataRow In miDataTable.Rows
                Dim MiProductoEntidad As New Entidades.Producto
                FormatearProductoLazyStock(miDataRow, MiProductoEntidad)
                MiListaProductos.Add(MiProductoEntidad)
            Next
            Return MiListaProductos

        Catch ex As Exception

        End Try
    End Function





    Public Function ListarUnProducto(ByVal paramID As Integer) As Entidades.Producto
        Try
            Dim MiProducto As New Entidades.Producto
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Producto", paramID)
            MiDataTable = Conexion.Leer("ListarUnProducto", MisParametros)
            If MiDataTable.Rows.Count >= 1 Then
                FormatearProducto(MiDataTable.Rows(0), MiProducto)
            End If
            Return MiProducto
        Catch ex As Exception

        End Try
    End Function


    Public Function ListarUnProducto(ByVal paramProducto As Entidades.Producto) As Entidades.Producto
        Try
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Producto", paramProducto.ID)
            MiDataTable = Conexion.Leer("ListarUnProducto", MisParametros)
            If MiDataTable.Rows.Count >= 1 Then
                FormatearProducto(MiDataTable.Rows(0), paramProducto)
            End If
            Return paramProducto
        Catch ex As Exception

        End Try
    End Function



    ''' <summary>Este método se encargará de persistir un producto.</summary>
    ''' <param name="paramProducto"></param>
    Public Overridable Sub NuevoProducto(ByVal paramProducto As Entidades.Producto)
        Try
            'CÒDIGO PARA FOMATEAR LOS PRECIOS!!!
            'pProducto.Precio.PrecioVenta.ToString("0.00")
            Dim MisParametros As New Hashtable
            paramProducto.ID = Conexion.ObtenerID("Producto", "ID_Producto")
            MisParametros.Add("@ID_Producto", paramProducto.ID)
            MisParametros.Add("@ID_Genero", paramProducto.Genero.ID_Genero)
            MisParametros.Add("@ID_TipoProducto", paramProducto.TipoProducto.ID_TipoProducto)
            MisParametros.Add("@Descripcion", paramProducto.Descripcion)
            MisParametros.Add("@Nombre", paramProducto.Nombre)
            MisParametros.Add("@Fec_Alta_Sistema", paramProducto.Fecha_Alta_Sistema)
            MisParametros.Add("@Fec_Salida", paramProducto.Fecha_Salida)
            MisParametros.Add("@Fec_Arribo_Suc", paramProducto.Fecha_Arribo_Sucursal)
            MisParametros.Add("@Importado", paramProducto.Importado)
            MisParametros.Add("@BL", paramProducto.BL)
            Dim a As String
            a = paramProducto.DVH
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(paramProducto.DVH))
            DAL.Conexion.ExecuteNonQuery("AltaProducto", MisParametros)
            DVDAL.CalcularDVV("Producto")


            'Finalizo la vigencia del precio
            Dim MisParametros4 As New Hashtable
            MisParametros4.Add("@ID_Producto", paramProducto.ID)



            Dim MiPrecioEntidad As New Entidades.Precio
            Dim MiDataTable As New DataTable
            MiDataTable = Conexion.Leer("CargarPrecioVenta", MisParametros4)

            If MiDataTable.Rows.Count > 0 Then


                PrecioDAL.FormatearPrecio(MiDataTable.Rows(0), MiPrecioEntidad)

                Dim MisParametros5 As New Hashtable
                'Esta es la fecha que se le va aplicar a la finalizaciòn
                MisParametros5.Add("@Fecha_Inicio", paramProducto.Precio.FechaInicio)
                MisParametros5.Add("@ID_Producto", paramProducto.ID)
                MisParametros5.Add("@DVH", MiPrecioEntidad.FechaInicio.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & paramProducto.ID & paramProducto.Precio.FechaInicio.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & paramProducto.Precio.Precio)
                DAL.Conexion.ExecuteNonQuery("InvalidarPrecioVenta", MisParametros5)
            End If



            'Ahora impacto el Pecio
            Dim MisParametros2 As New Hashtable
            paramProducto.Precio.ID = Conexion.ObtenerID("PrecioVenta", "ID_PrecioVenta")
            MisParametros2.Add("@ID_PrecioVenta", paramProducto.Precio.ID)
            MisParametros2.Add("@fechaInicio", paramProducto.Precio.FechaInicio)
            MisParametros2.Add("@ID_Producto", paramProducto.ID)
            MisParametros2.Add("@precio", paramProducto.Precio.Precio)
            MisParametros2.Add("@DVH", DVDAL.CalcularDVH(paramProducto.Precio.ID & paramProducto.Precio.FechaInicio.ToString("u", System.Globalization.CultureInfo.InvariantCulture) &
                 paramProducto.ID &
                 paramProducto.Precio.Precio.ToString("0.00")))
            Dim mist As String = paramProducto.Precio.ID & paramProducto.Precio.FechaInicio.ToString("u", System.Globalization.CultureInfo.InvariantCulture) &
                 paramProducto.ID &
                 paramProducto.Precio.Precio.ToString("0.00")
            DAL.Conexion.ExecuteNonQuery("AltaPrecio", MisParametros2)
            DVDAL.CalcularDVV("PrecioVenta")



            'Ahora impacto las imágenes
            For Each MiImagen As String In paramProducto.ListaImagenes
                If MiImagen <> "" Then
                    Dim MisParametros3 As New Hashtable
                    MisParametros3.Add("@ID_Imagen", Conexion.ObtenerID("ImagenProducto", "ID_Imagen"))
                    MisParametros3.Add("@ID_Producto", paramProducto.ID)
                    MisParametros3.Add("@Imagen", MiImagen)
                    DAL.Conexion.ExecuteNonQuery("AltaImagenProducto", MisParametros3)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Overridable Sub ModificarProducto(ByVal paramProducto As Entidades.Producto)

        Dim MisParametros As New Hashtable
        MisParametros.Add("@ID_Producto", paramProducto.ID)
        MisParametros.Add("@ID_Genero", paramProducto.Genero.ID_Genero)
        MisParametros.Add("@ID_TipoProducto", paramProducto.TipoProducto.ID_TipoProducto)
        MisParametros.Add("@Descripcion", paramProducto.Descripcion)
        MisParametros.Add("@Nombre", paramProducto.Nombre)
        MisParametros.Add("@Fec_Salida", paramProducto.Fecha_Salida)
        MisParametros.Add("@Fec_Arribo_Suc", paramProducto.Fecha_Arribo_Sucursal)
        MisParametros.Add("@Importado", paramProducto.Importado)
        MisParametros.Add("@BL", paramProducto.BL)
        MisParametros.Add("@DVH", DVDAL.CalcularDVH(paramProducto.DVH))
        DAL.Conexion.ExecuteNonQuery("ModificarProducto", MisParametros)
        DVDAL.CalcularDVV("Producto")


        'Finalizo la vigencia del precio
        Dim MisParametros4 As New Hashtable
        MisParametros4.Add("@ID_Producto", paramProducto.ID)



        Dim MiPrecioEntidad As New Entidades.Precio
        Dim MiDataTable As New DataTable
        MiDataTable = Conexion.Leer("CargarPrecioVenta", MisParametros4)

        If MiDataTable.Rows.Count > 0 Then


            PrecioDAL.FormatearPrecio(MiDataTable.Rows(0), MiPrecioEntidad)

            Dim MisParametros5 As New Hashtable
            'Esta es la fecha que se le va aplicar a la finalizaciòn
            MisParametros5.Add("@Fecha_Inicio", paramProducto.Precio.FechaInicio)
            MisParametros5.Add("@ID_Producto", paramProducto.ID)
            MisParametros5.Add("@DVH", DVDAL.CalcularDVH(
                               MiPrecioEntidad.ID &
                               MiPrecioEntidad.FechaInicio.ToString("u", System.Globalization.CultureInfo.InvariantCulture) &
                               paramProducto.ID &
                               paramProducto.Precio.FechaInicio.ToString("u", System.Globalization.CultureInfo.InvariantCulture) &
                               MiPrecioEntidad.Precio.ToString("0.00")))


            DAL.Conexion.ExecuteNonQuery("InvalidarPrecioVenta", MisParametros5)
        End If



        'Ahora impacto el Pecio
        Dim MisParametros2 As New Hashtable
        paramProducto.Precio.ID = Conexion.ObtenerID("PrecioVenta", "ID_PrecioVenta")
        MisParametros2.Add("@ID_PrecioVenta", paramProducto.Precio.ID)
        MisParametros2.Add("@fechaInicio", paramProducto.Precio.FechaInicio)
        MisParametros2.Add("@ID_Producto", paramProducto.ID)
        MisParametros2.Add("@precio", paramProducto.Precio.Precio)
        MisParametros2.Add("@DVH", DVDAL.CalcularDVH(paramProducto.Precio.ID &
                                                     paramProducto.Precio.FechaInicio.ToString("u", System.Globalization.CultureInfo.InvariantCulture) &
                                                     paramProducto.ID &
                                                     paramProducto.Precio.Precio.ToString("0.00")))
        Dim mist As String = paramProducto.Precio.ID & paramProducto.Precio.FechaInicio.ToString("u", System.Globalization.CultureInfo.InvariantCulture) &
                 paramProducto.ID &
                 paramProducto.Precio.Precio.ToString("0.00")
        DAL.Conexion.ExecuteNonQuery("AltaPrecio", MisParametros2)
        DVDAL.CalcularDVV("PrecioVenta")

        'Ahora impacto las imágenes
        For Each MiImagen As String In paramProducto.ListaImagenes
            If MiImagen <> "" Then
                Dim MisParametros3 As New Hashtable
                MisParametros3.Add("@ID_Imagen", Conexion.ObtenerID("ImagenProducto", "ID_Imagen"))
                MisParametros3.Add("@ID_Producto", paramProducto.ID)
                MisParametros3.Add("@Imagen", MiImagen)
                DAL.Conexion.ExecuteNonQuery("AltaImagenProducto", MisParametros3)
            End If
        Next

    End Sub


    Public Overridable Sub BajaProducto(ByVal paramProducto As Entidades.Producto)
        'Dim ComandoStr As String
        'ComandoStr = "update Producto set BL=@BL where ID_Producto=@ID_Producto"
        'Dim MiComando = BD.MiComando(ComandoStr)
        'With MiComando.Parameters
        '    .Add(New SqlParameter("@ID_Producto", paramProducto.ID))
        '    .Add(New SqlParameter("@BL", True))
        'End With
        'Conexion.ExecuteNonQuery(MiComando)
    End Sub


    Public Function VentasAsociadasProducto(ByVal paramProducto As Entidades.Producto) As Integer
        Try
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Producto", paramProducto.ID)
            MiDataTable = Conexion.Leer("VentasAsiciadasProducto", MisParametros)
            If MiDataTable.Rows.Count >= 1 Then
                Return Validacion.CompararInteger(MiDataTable.Rows(0).Item(0))
            Else
                Return 0
            End If
        Catch ex As Exception

        End Try
    End Function



    Public Shared Sub FormatearProducto(ByVal paramRow As DataRow, ByVal paramProducto As Entidades.Producto)
        paramProducto.ID = paramRow("ID_Producto")
        paramProducto.Genero = GeneroDAL.ObtenerGenero(paramRow("ID_Genero"))
        paramProducto.TipoProducto = TipoProductoDAL.ObtenerTipoProducto(paramRow("ID_TipoProducto"))
        paramProducto.Descripcion = paramRow("Descripcion")
        paramProducto.Nombre = paramRow("Nombre")
        paramProducto.Fecha_Alta_Sistema = paramRow("Fec_Alta_Sistema")
        paramProducto.Fecha_Salida = paramRow("Fec_Salida")
        paramProducto.Fecha_Arribo_Sucursal = paramRow("Fec_Arribo_Suc")
        paramProducto.Importado = paramRow("Importado")
        paramProducto.BL = paramRow("BL")
        paramProducto.Precio = PrecioDAL.ObtenerPrecioVigente(paramProducto)
        paramProducto.ListaImagenes = ListarImagenes(paramProducto)
        paramProducto.Stock = DAL.InventarioDAL.ObtenerStock(paramRow("ID_Producto"))
    End Sub

    Private Shared Function ListarImagenes(ByVal paramProducto As Entidades.Producto) As List(Of String)
        Dim MisImagenes As New List(Of String)
        Dim MisParametros As New Hashtable
        MisParametros.Add("@ID_Producto", paramProducto.ID)
        Dim miDataTable As DataTable = Conexion.Leer("ListarImagenesProducto", MisParametros)
        For Each miDataRow As DataRow In miDataTable.Rows
            MisImagenes.Add(miDataTable.Rows(0)("Imagen"))
        Next
        Return MisImagenes
    End Function


    Public Shared Sub FormatearProductoLazyStock(ByVal paramRow As DataRow, ByVal paramProducto As Entidades.Producto)
        paramProducto.ID = paramRow("ID_Producto")
        paramProducto.Genero = GeneroDAL.ObtenerGenero(paramRow("ID_Genero"))
        paramProducto.TipoProducto = TipoProductoDAL.ObtenerTipoProducto(paramRow("ID_TipoProducto"))
        paramProducto.Nombre = paramRow("Nombre")
        paramProducto.Stock = DAL.InventarioDAL.ObtenerStock(paramRow("ID_Producto"))
    End Sub
End Class
