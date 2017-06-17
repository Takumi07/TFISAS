Public Class InventarioDAL



    Public Sub CierreInventario()

    End Sub

    Public Sub AjustarStock(ByVal paramAjuste As Entidades.AjustarStock)

    End Sub

    Public Sub AprobarAjusteStock(ByVal paramAjuste As Entidades.AjustarStock)

    End Sub

    Public Sub RechazarAjusteStock(ByVal paramAjuste As Entidades.AjustarStock)

    End Sub








    Public Function ListarAjustesStock() As List(Of Entidades.AjustarStock)

    End Function


    Public Function ListarAjustesStockAproPendiente() As List(Of Entidades.AjustarStock)

    End Function


    Private Sub FormatearAjusteStock(ByVal paramRow As DataRow, ByVal paramAjusteStock As Entidades.AjustarStock)

    End Sub


#Region "Remito"



    Public Sub CargaRemito(ByVal paramRemito As Entidades.Remito)
        Try
            'Genero la Cabecera.
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Proveedor", paramRemito.Proveedor.ID)
            MisParametros.Add("@NroRemito", paramRemito.NroRemito)
            MisParametros.Add("@ID_Estado", paramRemito.Estado.Estado)
            MisParametros.Add("@FechaEmision", paramRemito.FechaEmision)
            Dim DVH As String = ""
            DVH = paramRemito.Proveedor.ID & paramRemito.NroRemito & paramRemito.Estado.Estado & paramRemito.FechaEmision.ToString("u", System.Globalization.CultureInfo.InvariantCulture)
            MisParametros.Add("@DVH", DAL.DVDAL.CalcularDVH(DVH))
            DAL.Conexion.ExecuteNonQuery("AgregarRemito", MisParametros)
            DVDAL.CalcularDVV("Remito")


            'Ahora Genero el Detalle
            For Each MiRemitoDetalle As Entidades.RemitoRenglon In paramRemito.RemitoRenglon
                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@NroRemito", paramRemito.NroRemito)
                MisParametros2.Add("@ID_Proveedor", paramRemito.Proveedor.ID)
                MisParametros2.Add("@NroRenglon", MiRemitoDetalle.NroRenglon)
                MisParametros2.Add("@ID_Producto", MiRemitoDetalle.Producto.ID)
                MisParametros2.Add("@Cantidad", MiRemitoDetalle.Cantidad)
                Dim DVHR As String = ""
                DVHR = paramRemito.NroRemito & paramRemito.Proveedor.ID & MiRemitoDetalle.NroRenglon & MiRemitoDetalle.Producto.ID & MiRemitoDetalle.Cantidad
                MisParametros2.Add("@DVH", DAL.DVDAL.CalcularDVH(DVHR))
                DAL.Conexion.ExecuteNonQuery("AgregaRemitoDetalle", MisParametros2)
            Next
            DVDAL.CalcularDVV("RemitoDetalle")
        Catch ex As Exception

        End Try

    End Sub

    Public Sub AprobarRemito(ByVal paramRemito As Entidades.Remito)
        Try
            'Apruebo el remito
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Proveedor", paramRemito.Proveedor.ID)
            MisParametros.Add("@NroRemito", paramRemito.NroRemito)
            MisParametros.Add("@ID_Estado", paramRemito.Estado.Estado)
            Dim DVH As String = ""
            DVH = paramRemito.Proveedor.ID & paramRemito.NroRemito & paramRemito.Estado.Estado & paramRemito.FechaEmision.ToString("u", System.Globalization.CultureInfo.InvariantCulture)
            MisParametros.Add("@DVH", DAL.DVDAL.CalcularDVH(DVH))
            DAL.Conexion.ExecuteNonQuery("ModificarEstadoRemito", MisParametros)
            DVDAL.CalcularDVV("Remito")


            For Each MiRemitoDetalle As Entidades.RemitoRenglon In paramRemito.RemitoRenglon

                Dim ID_Movimiento As Integer

                'Valido si es Stock Inicial o entrada
                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@ID_Producto", MiRemitoDetalle.Producto.ID)
                Dim MiDataTable As DataTable
                MiDataTable = DAL.Conexion.Leer("VerificarTipoMovimiento", MisParametros2)
                If MiDataTable.Rows.Count >= 1 Then
                    'Ya hay Stock Incial
                    ID_Movimiento = GenerarMovimiento(MiRemitoDetalle.Producto.ID, 2, MiRemitoDetalle.Cantidad)
                Else
                    'Es un Stock Inicial
                    ID_Movimiento = GenerarMovimiento(MiRemitoDetalle.Producto.ID, 1, MiRemitoDetalle.Cantidad)
                End If

                'Vinculo el renglon del remito con el Movimiento Generado
                Dim MisParametros3 As New Hashtable
                MisParametros3.Add("@NroRemito", paramRemito.NroRemito)
                MisParametros3.Add("@ID_Proveedor", paramRemito.Proveedor.ID)
                MisParametros3.Add("@NroRenglon", MiRemitoDetalle.NroRenglon)
                MisParametros3.Add("@ID_Producto", MiRemitoDetalle.Producto.ID)
                MisParametros3.Add("@ID_Movimiento", ID_Movimiento)
                Dim DVHR As String = ""
                DVHR = paramRemito.NroRemito & paramRemito.Proveedor.ID & MiRemitoDetalle.NroRenglon & MiRemitoDetalle.Producto.ID & ID_Movimiento & MiRemitoDetalle.Cantidad
                MisParametros3.Add("@DVH", DVDAL.CalcularDVH(DVHR))
                DAL.Conexion.ExecuteNonQuery("VincularRemitoMovimiento", MisParametros3)
                DVDAL.CalcularDVV("RemitoDetalle")
            Next
        Catch ex As Exception

        End Try





    End Sub

    Public Sub RechazarRemito(ByVal paramRemito As Entidades.Remito)
        Try
            'Rechazo el remito
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Proveedor", paramRemito.Proveedor.ID)
            MisParametros.Add("@NroRemito", paramRemito.NroRemito)
            MisParametros.Add("@ID_Estado", paramRemito.Estado.Estado)
            Dim DVH As String = ""
            DVH = paramRemito.Proveedor.ID & paramRemito.NroRemito & paramRemito.Estado.Estado & paramRemito.FechaEmision.ToString("u", System.Globalization.CultureInfo.InvariantCulture)
            MisParametros.Add("@DVH", DAL.DVDAL.CalcularDVH(DVH))
            DAL.Conexion.ExecuteNonQuery("ModificarEstadoRemito", MisParametros)
            DVDAL.CalcularDVV("Remito")
        Catch ex As Exception

        End Try
    End Sub


    Public Function VerificarNroRemito(ByVal NroRemito As Integer, ByVal ID_Proveedor As Integer)
        Try
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@NroRemito", NroRemito)
            MisParametros.Add("@ID_Proveedor", ID_Proveedor)
            MiDataTable = Conexion.Leer("VerificarRemito", MisParametros)
            If MiDataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function


    ''' <summary>
    ''' Lista los remitos en diversos estados
    ''' </summary>
    ''' <param name="paramEstado">1 = Pendiente, 2 = Aprobado, 3 = Rechazado</param>
    ''' <returns>Retorna una lista de remitos completos (con sus renglones) </returns>
    Public Function ListarRemitos(ByVal paramEstado As Integer) As List(Of Entidades.Remito)

        Try
            Dim MiListaRemito As New List(Of Entidades.Remito)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Estado", paramEstado)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarRemitosEstado", MisParametros)
            For Each MiRow As DataRow In MiDataTable.Rows
                Dim MiRemito As New Entidades.Remito
                FormatearRemito(MiRow, MiRemito)


                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@NroRemito", MiRemito.NroRemito)
                MisParametros2.Add("@ID_Proveedor", MiRemito.Proveedor.ID)
                Dim MiDataTable2 As DataTable
                MiDataTable2 = Conexion.Leer("ListarUnDetalleRemito", MisParametros2)

                For Each MiRowD As DataRow In MiDataTable2.Rows
                    Dim MiRemitoDetalle As New Entidades.RemitoRenglon
                    Me.FormatearRemitoDetalle(MiRowD, MiRemitoDetalle)
                    MiRemito.RemitoRenglon.Add(MiRemitoDetalle)
                Next
                MiListaRemito.Add(MiRemito)
            Next
            Return MiListaRemito
        Catch ex As Exception

        End Try

    End Function





    Public Function ObtenerUnRemito(ByVal paramRemito As Entidades.Remito) As Entidades.Remito

        Try
            Dim MiRemito As New Entidades.Remito
            Dim MisParametros As New Hashtable
            MisParametros.Add("@NroRemito", paramRemito.NroRemito)
            MisParametros.Add("@ID_Proveedor", paramRemito.Proveedor.ID)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarUnRemito", MisParametros)
            For Each MiRow As DataRow In MiDataTable.Rows
                FormatearRemito(MiRow, MiRemito)
                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@NroRemito", MiRemito.NroRemito)
                MisParametros2.Add("@ID_Proveedor", MiRemito.Proveedor.ID)
                Dim MiDataTable2 As DataTable
                MiDataTable2 = Conexion.Leer("ListarUnDetalleRemito", MisParametros2)
                For Each MiRowD As DataRow In MiDataTable2.Rows
                    Dim MiRemitoDetalle As New Entidades.RemitoRenglon
                    Me.FormatearRemitoDetalle(MiRowD, MiRemitoDetalle)
                    MiRemito.RemitoRenglon.Add(MiRemitoDetalle)
                Next
            Next
            Return MiRemito
        Catch ex As Exception

        End Try




    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ID_Producto"></param>
    ''' <param name="ID_TipoMovimiento"></param>
    ''' <param name="Cantidad"></param>
    ''' <returns>Devuelve el ID_Movimiento Generado</returns>
    Public Shared Function GenerarMovimiento(ByVal ID_Producto As Integer, ID_TipoMovimiento As Integer, ByVal Cantidad As Integer) As Integer
        Try
            Dim MisParametros As New Hashtable

            Dim ID_Movimiento As Integer
            ID_Movimiento = Conexion.ObtenerID("Movimientos", "ID_Movimiento")
            MisParametros.Add("@ID_Movimiento", ID_Movimiento)
            MisParametros.Add("@ID_Producto", ID_Producto)
            MisParametros.Add("@ID_TipoMovimiento", ID_TipoMovimiento)
            Dim Fecha As Date
            Fecha = DateTime.Now
            MisParametros.Add("@Fecha", Fecha)
            MisParametros.Add("@Cantidad", Cantidad)
            Dim DVH As String = ""
            DVH = ID_Movimiento & ID_Producto & ID_TipoMovimiento & Fecha.ToString("u", System.Globalization.CultureInfo.InvariantCulture) & Cantidad
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(DVH))
            DAL.Conexion.ExecuteNonQuery("AltaMovimiento", MisParametros)
            DVDAL.CalcularDVV("Movimientos")
            Return ID_Movimiento
        Catch ex As Exception

        End Try
    End Function


    Public Shared Function ObtenerStock(ByVal ID_Producto As Integer) As Integer
        Try
            Dim Stock As Integer = 0
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Producto", ID_Producto)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarMovimientosDeUnProducto", MisParametros)
            For Each MiRow As DataRow In MiDataTable.Rows
                Dim cuenta As Integer = 0
                cuenta = CInt(MiRow("Cantidad")) * MiRow("Valor")
                Stock += cuenta
            Next
            Return Stock

        Catch ex As Exception
        End Try
    End Function





#Region "Formatear"

    Public Sub FormatearRemito(ByVal paramDataRow As DataRow, paramRemito As Entidades.Remito)
        paramRemito.Proveedor = (New DAL.ProveedorDAL).ObtenerProveedor(paramDataRow("ID_Proveedor"))
        paramRemito.NroRemito = paramDataRow("NroRemito")
        paramRemito.Estado = DAL.EstadoDAL.ObtenerUnEstado(paramDataRow("ID_Estado"))
        paramRemito.FechaEmision = paramDataRow("FechaEmision")
    End Sub




    Public Sub FormatearRemitoDetalle(ByVal paramDataRow As DataRow, paramRemitoDetalle As Entidades.RemitoRenglon)
        paramRemitoDetalle.NroRenglon = paramDataRow("NroRenglon")
        paramRemitoDetalle.Producto = (New DAL.ProductoDAL).ListarUnProducto(paramDataRow("ID_Producto"))
        paramRemitoDetalle.Cantidad = paramDataRow("Cantidad")
    End Sub



#End Region



#End Region
End Class
