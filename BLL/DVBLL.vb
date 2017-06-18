Public Class DVBLL
    Dim MiUsuarioEntidad As New Entidades.Usuario

    Sub New()

    End Sub

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub

    Public Shared Function Integridad() As Boolean
        Try
            Dim MiDVDAL As New DAL.DVDAL


            If DAL.DVDAL.VerificarTabla("DVV") = False Then
                Throw New BLL.IntegridadCorrupta
            End If


            If Not MiDVDAL.ListarTodosDVV Is Nothing Then

                'Obtengo todos los registros de la tabla DVV
                'Osea tengo todas las tablas que se le calculan integridad en la BD
                For Each MiDataRow As DataRow In MiDVDAL.ListarTodosDVV.Rows
                    'Por cada tabla que tengo integridad
                    Dim MiDataTable As DataTable
                    Dim MiCampo As String = ""
                    Dim MiFila As String = ""
                    Dim DVVcalc As String = ""
                    'Obtengo el nombre de la tabla
                    Dim DVVtabla As String = MiDataRow.Item("DVV").ToString
                    'Obtengo todos los registros de esa tabla
                    MiDataTable = DAL.DVDAL.RecorrerTabla(MiDataRow.Item("NombreTabla"))
                    Dim cont As Integer = 0

                    'Esto lo hago por si me borran todas las rows de la tabla en la bd
                    'Verificar bien!
                    Dim dr2 As DataRow
                    If MiDataTable.Rows.Count = 0 Then
                        Throw New BLL.IntegridadCorrupta
                    Else
                        dr2 = MiDataTable.Rows(0)
                    End If

                    'Obtengo cuantas columnas tiene esa tabla
                    'Mejor con propiedad length?
                    For Each item In dr2.ItemArray
                        cont += 1
                    Next

                    Dim miFilaComparacion As String

                    For Each dr3 As DataRow In MiDataTable.Rows
                        MiFila = ""
                        miFilaComparacion = ""
                        'Con esto no agarro la columna DVH
                        For i As Integer = 0 To cont - 2
                            'Lo Convierto a DATETIME cosa de que este igual ahora que en el objeto que lo calcule cuando guardó 
                            '(porque el insert o update se hace del objeto) 
                            'Ver si hay que hacer algo con lo que solo es fecha.
                            If TypeOf dr3.Item(i) Is DateTime Then
                                MiCampo = CDate(dr3.Item(i)).ToString("u", System.Globalization.CultureInfo.InvariantCulture)
                            ElseIf TypeOf dr3.Item(i) Is Decimal Then
                                'Cambiar Esto
                                'paramProducto.Precio.Precio.ToString("0.00")
                                'Por esto:
                                'dr3.Item(i).ToString("0.00")
                                MiCampo = Format(dr3.Item(i), “##0.00”)
                                'MiCampo = dr3.Item(i).ToString("0.00")
                            Else
                                MiCampo = dr3.Item(i).ToString
                            End If
                            'Concateno toda la fila.
                            MiFila = MiFila & MiCampo
                            miFilaComparacion = miFilaComparacion & MiCampo
                        Next
                        'Calculo los dvh para la fila
                        MiFila = DAL.DVDAL.CalcularDVH(MiFila)

                        'Si es diferente, cambiaron un dato
                        '/*************************************/
                        '/********REVISAR**********************/
                        '/*************************************/
                        'Ojo si DVH es vacío, pincha

                        '/*****EN TEORÌA, SOLUCIONADO*********/

                        If IsDBNull(dr3.Item("DVH")) Then

                            Throw New BLL.IntegridadCorrupta
                        Else
                            If MiFila <> dr3.Item("DVH") Then


                                Throw New BLL.IntegridadCorrupta
                            End If
                        End If
                        'Si es igual, concateno para el DVV
                        DVVcalc = DVVcalc & MiFila
                    Next
                    'Calculo el DVV para la tabla
                    DVVcalc = DAL.DVDAL.CalcularDVH(DVVcalc)
                    'Si es diferente tocaron la tabla DVV (porque ya validamos todas las rows)
                    If DVVtabla <> DVVcalc Then
                        Throw New BLL.IntegridadCorrupta
                    End If
                Next
                Return True
            End If

        Catch ex As BLL.IntegridadCorrupta
            'BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(Nothing, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(Nothing, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


    Public Shared Sub GenerarIntegridad()
        Try


            Dim MiDVDAL As New DAL.DVDAL
            If Not MiDVDAL.ListarTodosDVV Is Nothing Then

                'Obtengo todos los registros de la tabla DVV
                'Osea tengo todas las tablas que se le calculan integridad en la BD
                For Each MiDataRow As DataRow In MiDVDAL.ListarTodosDVV.Rows
                    'Por cada tabla que tengo integridad
                    Dim MiDataTable As DataTable
                    Dim MiCampo As String = ""
                    Dim MiFila As String = ""
                    Dim DVVcalc As String = ""
                    'Obtengo el nombre de la tabla
                    Dim DVVtabla As String = MiDataRow.Item("DVV").ToString

                    Dim MiNombreTabla As String = ""
                    MiNombreTabla = MiDataRow.Item("NombreTabla")

                    'Obtengo todos los registros de esa tabla
                    MiDataTable = DAL.DVDAL.RecorrerTabla(MiDataRow.Item("NombreTabla"))
                    Dim cont As Integer = 0
                    Dim dr2 As DataRow = MiDataTable.Rows(0)

                    'Me guardo el ID Para hacer el update
                    Dim MIID As Integer = 0
                    Dim MiNombreColumna As String = ""

                    'Obtengo cuantas columnas tiene esa tabla
                    'Mejor con propiedad length?
                    For Each item In dr2.ItemArray
                        cont += 1
                    Next

                    Dim miFilaComparacion As String

                    For Each dr3 As DataRow In MiDataTable.Rows
                        MiNombreColumna = MiDataTable.Columns.Item(0).ColumnName
                        miFilaComparacion = ""
                        Dim MiHastable As New Hashtable
                        MiFila = ""
                        'Con esto no agarro la columna DVH
                        For i As Integer = 0 To cont - 2
                            'Me guardo el ID


                            'Esto lo hago así para generar la primera vez la integridad. Despuès no deberìa usarlo msa
                            'Igual dejo el mètodo para cuando creo algo por afuera, me puede servir



                            'Lo viste a Pelé? Bueno, esto es mas negro todavía

                            If MiDataRow.Item("NombreTabla") = "FamiliaPatente" Then
                                If i = 0 Then MiHastable.Add("ID_Familia", DAL.Validacion.CompararInteger(dr3.Item(i)))
                                If i = 1 Then MiHastable.Add("ID_Patente", DAL.Validacion.CompararInteger(dr3.Item(i)))

                            ElseIf MiDataRow.Item("NombreTabla") = "Traduccion" Then
                                If i = 0 Then MiHastable.Add("ID_Control", DAL.Validacion.CompararInteger(dr3.Item(i)))
                                If i = 1 Then MiHastable.Add("ID_Idioma", DAL.Validacion.CompararInteger(dr3.Item(i)))

                            ElseIf MiDataRow.Item("NombreTabla") = "PaginaControl" Then
                                If i = 0 Then MiHastable.Add("ID_Pagina", DAL.Validacion.CompararInteger(dr3.Item(i)))
                                If i = 1 Then MiHastable.Add("ID_Control", DAL.Validacion.CompararInteger(dr3.Item(i)))
                            ElseIf MiDataRow.Item("NombreTabla") = "Remito" Then
                                If i = 0 Then MiHastable.Add("ID_Proveedor", DAL.Validacion.CompararInteger(dr3.Item(i)))
                                If i = 1 Then MiHastable.Add("NroRemito", DAL.Validacion.CompararInteger(dr3.Item(i)))
                            ElseIf MiDataRow.Item("NombreTabla") = "RemitoDetalle" Then
                                If i = 0 Then MiHastable.Add("NroRemito", DAL.Validacion.CompararInteger(dr3.Item(i)))
                                If i = 1 Then MiHastable.Add("ID_Proveedor", DAL.Validacion.CompararInteger(dr3.Item(i)))
                                If i = 2 Then MiHastable.Add("NroRenglon", DAL.Validacion.CompararInteger(dr3.Item(i)))
                            ElseIf MiDataRow.Item("NombreTabla") = "FacturaDetalle" Then
                                If i = 0 Then MiHastable.Add("NroFactura", DAL.Validacion.CompararInteger(dr3.Item(i)))
                                If i = 1 Then MiHastable.Add("ID_Producto", DAL.Validacion.CompararInteger(dr3.Item(i)))
                            Else
                                'Aca me sirve la clásica, porque solo tengo 1 campo de PK
                                If i = 0 Then MiHastable.Add(MiNombreColumna, DAL.Validacion.CompararInteger(dr3.Item(i)))
                            End If



                            'If i = 0 Then MIID = DAL.Validacion.CompararInteger(dr3.Item(i))

                            If TypeOf dr3.Item(i) Is DateTime Then
                                MiCampo = CDate(dr3.Item(i)).ToString("u", System.Globalization.CultureInfo.InvariantCulture)
                            ElseIf TypeOf dr3.Item(i) Is Decimal Then
                                MiCampo = Format(dr3.Item(i), “##0.00”)
                            Else
                                MiCampo = dr3.Item(i).ToString
                            End If
                            'Concateno toda la fila.
                            MiFila = MiFila & MiCampo
                            miFilaComparacion = miFilaComparacion & MiCampo
                        Next
                        'Calculo los dvh para la fila
                        MiFila = DAL.DVDAL.CalcularDVH(MiFila)


                        DAL.DVDAL.ActualizarDVH(MiNombreTabla, MiFila, MiHastable)


                        DVVcalc = DVVcalc & MiFila
                    Next
                    'Calculo el DVV para la tabla
                    DVVcalc = DAL.DVDAL.CalcularDVH(DVVcalc)
                    DAL.DVDAL.ModificarRegistro(MiNombreTabla, DVVcalc)
                Next
            End If

        Catch ex As BLL.IntegridadCorrupta
            'BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(Nothing, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            'BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(Nothing, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub


End Class
