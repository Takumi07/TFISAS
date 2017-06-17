Public Class VentaDAL

    Public Sub AltaVenta(ByVal paramVenta As Entidades.Venta)
        Try
            Dim MisParametros As New Hashtable
            Dim MiNroFactura As Integer
            Dim MiFecha As Date


            'Valido Todo el Stock
            For Each MiPromocion As Entidades.Promocion In paramVenta.PromocionesCompradas
                Dim stock As Integer = 0
                stock = DAL.InventarioDAL.ObtenerStock(MiPromocion.Producto.ID)
                If stock <= 0 Then
                    Throw New Entidades.NoHayStock
                End If
            Next

            'Valido Todo el Stock
            For Each MiProducto As Entidades.Producto In paramVenta.ProductosComprados
                Dim stock As Integer = 0
                stock = DAL.InventarioDAL.ObtenerStock(MiProducto.ID)
                If stock <= 0 Then
                    Throw New Entidades.NoHayStock
                End If
            Next




            MiFecha = DateTime.Now
            MiNroFactura = Conexion.ObtenerID("Factura", "NroFactura")
            MisParametros.Add("@NroFactura", MiNroFactura)
            MisParametros.Add("@ID_Cliente", paramVenta.Cliente.ID)
            MisParametros.Add("@FechaEmision", MiFecha)
            Dim MiDVH As String
            MiDVH = MiNroFactura & paramVenta.Cliente.ID & MiFecha.ToString("u", System.Globalization.CultureInfo.InvariantCulture)
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(MiDVH))
            DAL.Conexion.ExecuteNonQuery("AltaFactura", MisParametros)
            DVDAL.CalcularDVV("Factura")


            Dim MiNroRenglon As Integer = 0
            For Each mipromocion As Entidades.Promocion In paramVenta.PromocionesCompradas
                Dim ID_Movimiento As Integer
                ID_Movimiento = InventarioDAL.GenerarMovimiento(mipromocion.Producto.ID, 3, mipromocion.Producto.CantidadComprada)
                MiNroRenglon += 1
                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@NroFactura", MiNroFactura)
                MisParametros2.Add("@NroRenglon", MiNroRenglon)
                MisParametros2.Add("@ID_Producto", mipromocion.Producto.ID)
                MisParametros2.Add("@ID_Movimiento", ID_Movimiento)
                MisParametros2.Add("@Cantidad", mipromocion.Producto.CantidadComprada)
                Dim MiDescuento As Decimal
                'Obtengo el valor de descuento.
                MiDescuento = ((mipromocion.Producto.Precio.Precio) * (100 - mipromocion.Descuento))
                MisParametros2.Add("@Descuento", MiDescuento)
                Dim MIDVHR As String = ""
                MIDVHR = MiNroFactura & MiNroRenglon & mipromocion.Producto.ID & ID_Movimiento & mipromocion.Producto.CantidadComprada & MiDescuento.ToString("0.00")
                MisParametros2.Add("@DVH", DAL.DVDAL.CalcularDVH(MIDVHR))
                DAL.Conexion.ExecuteNonQuery("AltaFacturaDetalle", MisParametros2)
                DVDAL.CalcularDVV("FacturaDetalle")
            Next


            For Each MiProducto As Entidades.Producto In paramVenta.ProductosComprados
                Dim ID_Movimiento As Integer
                ID_Movimiento = InventarioDAL.GenerarMovimiento(MiProducto.ID, 3, MiProducto.CantidadComprada)
                MiNroRenglon += 1
                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@NroFactura", MiNroFactura)
                MisParametros2.Add("@NroRenglon", MiNroRenglon)
                MisParametros2.Add("@ID_Producto", MiProducto.ID)
                MisParametros2.Add("@ID_Movimiento", ID_Movimiento)
                MisParametros2.Add("@Cantidad", MiProducto.CantidadComprada)
                Dim MiDescuento As Decimal
                'Obtengo el valor de descuento.
                MiDescuento = 0
                MisParametros2.Add("@Descuento", MiDescuento)
                Dim MIDVHR As String = ""
                MIDVHR = MiNroFactura & MiNroRenglon & MiProducto.ID & ID_Movimiento & MiProducto.CantidadComprada & MiDescuento.ToString("0.00")
                MisParametros2.Add("@DVH", DAL.DVDAL.CalcularDVH(MIDVHR))
                DAL.Conexion.ExecuteNonQuery("AltaFacturaDetalle", MisParametros2)
                DVDAL.CalcularDVV("FacturaDetalle")
            Next


        Catch ex As Entidades.NoHayStock
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Function ObtenerFacturas(ByVal paramCliente As Entidades.Cliente) As List(Of Entidades.Factura)
        Try
            Dim MiListaFacturas As New List(Of Entidades.Factura)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Cliente", paramCliente.ID)
            Dim miDataTable As DataTable = Conexion.Leer("ListarFacturas", MisParametros)
            For Each miDataRow As DataRow In miDataTable.Rows
                Dim MiFactura As New Entidades.Factura
                FormatearFactura(miDataRow, MiFactura)


                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@NroFactura", MiFactura.NroFactra)
                Dim MiDataTable2 As DataTable = Conexion.Leer("listarfacturadetalle", MisParametros2)

                For Each MiDataRow2 As DataRow In MiDataTable2.Rows
                    Dim MiFacturaRenglon As New Entidades.FacturaRenglon
                    FormatearFacturaRenglon(MiDataRow2, MiFacturaRenglon, MiFactura.FechaEmision)
                    MiFactura.FacturaRenglon.Add(MiFacturaRenglon)
                Next
                MiListaFacturas.Add(MiFactura)
            Next
            Return MiListaFacturas
        Catch ex As Exception

        End Try
    End Function




    Private Function FormatearFactura(ByVal paramDataRow As DataRow, ByVal paramFactura As Entidades.Factura)
        paramFactura.NroFactra = paramDataRow("NroFactura")
        paramFactura.FechaEmision = paramDataRow("FechaEmision")
    End Function


    Private Function FormatearFacturaRenglon(ByVal paramdatarow As DataRow, ByVal paramDetalleFactura As Entidades.FacturaRenglon, ByVal fecha As DateTime)
        paramDetalleFactura.NroRenglon = paramdatarow("NroRenglon")
        paramDetalleFactura.Producto = (New DAL.ProductoDAL).ListarUnProducto(paramdatarow("ID_Producto"))
        paramDetalleFactura.Cantidad = paramdatarow("Cantidad")
        paramDetalleFactura.Descuento = paramdatarow("Descuento")
        paramDetalleFactura.PrecioUnitario = DAL.PrecioDAL.ObtenerPrecioVenta(paramDetalleFactura.Producto, fecha)



    End Function
End Class
