Public Class PrecioDAL



    Public Shared Function ObtenerPrecioVigente(ByVal paramProducto As Entidades.Producto) As Entidades.Precio

        Try
            Dim MiPrecio As New Entidades.Precio
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Producto", paramProducto.ID)
            MiDataTable = Conexion.Leer("CargarPrecioVigente", MisParametros)
            If MiDataTable.Rows.Count >= 1 Then
                FormatearPrecio(MiDataTable.Rows(0), MiPrecio)
            End If
            Return MiPrecio
        Catch ex As Exception
            Throw ex
        End Try
    End Function





    Public Shared Function ObtenerPrecioVenta(ByVal paramproducto As Entidades.Producto, ByVal paramfecha As DateTime) As Entidades.Precio
        Try
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            Dim MiListaPrecio As New List(Of Entidades.Precio)
            MisParametros.Add("@ID_Producto", paramproducto.ID)
            MiDataTable = Conexion.Leer("ListarPreciosProducto", MisParametros)
            For Each miDataRow As DataRow In MiDataTable.Rows
                Dim MiPrecio As New Entidades.Precio
                FormatearPrecio(miDataRow, MiPrecio)
                MiListaPrecio.Add(MiPrecio)
            Next


            Dim FlagAnterior As Boolean = False
            Dim FlagPosterior As Boolean = False

            For Each MiPrecio As Entidades.Precio In MiListaPrecio
                'Fecha Inicio es ANTERIOR a la fecha
                If DateTime.Compare(MiPrecio.FechaInicio, paramfecha) < 0 Then
                    FlagAnterior = True

                    'Fecha Inicio es IGUAL a la fecha
                ElseIf DateTime.Compare(MiPrecio.FechaInicio, paramfecha) = 0 Then
                    FlagAnterior = True
                    'Fecha Inicio es posterior a la fecha.
                ElseIf DateTime.Compare(MiPrecio.FechaInicio, paramfecha) > 0 Then
                    FlagAnterior = False
                End If


                'Esto es por si la fecha fin es null
                If MiPrecio.FechaFin <> "#1/1/0001 12:00:00 AM#" Then


                    'Fecha Fin es ANTERIOR a la fecha
                    If DateTime.Compare(MiPrecio.FechaFin, paramfecha) < 0 Then
                        FlagPosterior = False

                        'Fecha Fin es IGUAL a la fecha
                    ElseIf DateTime.Compare(MiPrecio.FechaFin, paramfecha) = 0 Then
                        FlagPosterior = True

                        'Fecha Fin es posterior a la fecha.
                    ElseIf DateTime.Compare(MiPrecio.FechaFin, paramfecha) > 0 Then
                        FlagPosterior = True
                    End If
                Else
                    FlagPosterior = True
                End If




                If FlagAnterior = True AndAlso FlagPosterior = True Then
                    Return MiPrecio
                End If

            Next


        Catch ex As Exception

        End Try
    End Function



    Public Shared Sub FormatearPrecio(ByVal paramRow As DataRow, ByVal paramPrecio As Entidades.Precio)
        paramPrecio.ID = Validacion.CompararInteger(paramRow("ID_PrecioVenta"))
        paramPrecio.FechaInicio = Validacion.CompararDatetime(paramRow("FechaInicio"))
        paramPrecio.FechaFin = Validacion.CompararDatetime(paramRow("FechaFin"))
        paramPrecio.Precio = Validacion.CompararDecimal(paramRow("Precio"))
    End Sub


End Class
