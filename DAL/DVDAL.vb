Imports DAL
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient
Imports System.Configuration
Public Class DVDAL

    ''' <summary>Calcula los dígitos verificadores Horizontales para insertar un registro.</summary>
    ''' <param name="Fila">Registro a insertar</param>
    ''' <returns>DVH de ese registro</returns>
    Public Shared Function CalcularDVH(ByRef Fila As String) As String
        Try
            Dim UE As New UnicodeEncoding
            Dim bHash As Byte()
            Dim bCadena() As Byte = UE.GetBytes(Fila)
            Dim s1Service As New SHA1CryptoServiceProvider
            bHash = s1Service.ComputeHash(bCadena)
            Dim Resumen As String
            Resumen = Convert.ToBase64String(bHash)
            Return Resumen
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    ''' <summary>Calcula los dígitos verificadores verticales.</summary>
    ''' <param name="paramTabla">Tabla a la cual se le calcula los DVV</param>
    Public Shared Sub CalcularDVV(ByRef paramTabla As String)
        Try
            Dim hdatos As New Hashtable
            Dim DS As New DataTable

            Dim fila As String
            For Each dr As DataRow In RecorrerTabla(paramTabla).Rows
                fila = fila & dr.Item("DVH")
            Next

            Dim DVV As String
            DVV = CalcularDVH(fila)

            hdatos.Add("@NombreTabla", paramTabla)
            'modificado para que genere los dvv de la tabla pertinente
            DS = DAL.Conexion.Leer("CargarDVV", hdatos)

            If DS.Rows.Count = 1 Then
                ModificarRegistro(paramTabla, DVV)
            Else
                GuardarRegistro(paramTabla, DVV)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Shared Sub GuardarRegistro(ByVal paramTabla As String, ByVal paramDVV As String)
        Dim hdatos As New Hashtable
        hdatos.Add("@Tabla", paramTabla)
        hdatos.Add("@DVV", paramDVV)
        Conexion.ExecuteNonQuery("AltaDVV", hdatos)
    End Sub
    Public Shared Sub ModificarRegistro(ByVal paramTabla As String, ByVal paramDVV As String)
        Dim hdatos As New Hashtable
        hdatos.Add("@Tabla", paramTabla)
        hdatos.Add("@DVV", paramDVV)
        Conexion.ExecuteNonQuery("ModificarDVV", hdatos)
    End Sub

    Public Shared Function RecorrerTabla(ByVal pNombreTabla As String) As DataTable
        Dim hdatos As New Hashtable
        hdatos.Add("@NombreTabla", pNombreTabla)
        Return Conexion.Leer("CargarContenidoTabla", hdatos)
    End Function

    Public Function ListarDVV() As DataTable
        Return Conexion.Leer("CargarDVV", Nothing)
    End Function
    Public Function ListarTodosDVV() As DataTable
        Return Conexion.Leer("CargarTodosDVV", Nothing)
    End Function



    Public Shared Sub ActualizarDVH(ByVal paramTabla As String, ByVal paramValor As String, ByVal Optional hdatos As Hashtable = Nothing)
        Try

            'HAGO ESTE MÉTODO PARA CORREGIR LA INTEGRIDAD PARA CUANDO INSERTO COSAS POR AFUERA, COMO LOS CONTROLES, MENSAJE DE IDIOMAS, ETC
            'VER CUANDO VAYA AGREGANDO TABLAS
            Dim MiConexion As New SqlConnection
            MiConexion = Conexion.retornaConexion

            If MiConexion.State = ConnectionState.Closed Then
                MiConexion.Open()
            End If
            Try
                Dim MiSQLComand As New SqlCommand
                MiSQLComand.Connection = MiConexion


                MiSQLComand.Parameters.Add(New SqlParameter("@DVH", paramValor))
                Dim consulta As String
                'consulta = "update " & paramTabla.ToString & " set DVH=@DVH where " & paramColumnname.ToString & "=" & paramID

                consulta = "update " & paramTabla.ToString & " set DVH=@DVH where "

                Dim flag As Integer = 0
                If Not hdatos Is Nothing Then
                    'si la hashtable no esta vacia, y tiene el dato q busco 
                    For Each dato As String In hdatos.Keys
                        'cargo los parametros que le estoy pasando con la Hash
                        If flag > 0 Then
                            If TypeOf (hdatos(dato)) Is DateTime Then
                                consulta = consulta & " and " & dato & "='" & hdatos(dato) & "'"
                            Else
                                consulta = consulta & " and " & dato & "=" & hdatos(dato)
                            End If

                        Else
                            consulta = consulta & " " & dato & "=" & hdatos(dato)
                        End If

                        flag += 1

                    Next
                End If

                'HAGO ESTO PORQUE EL STORED PRODCEDURE NO LE GUSTA LOS PARÁMETROS ANIDADOS
                MiSQLComand.CommandText = consulta
                MiSQLComand.CommandType = CommandType.Text
                MiSQLComand.ExecuteNonQuery()
            Catch ex As SqlException
                MiConexion.Close()
                Throw ex
            Catch ex As Exception
                MiConexion.Close()
                Throw ex
            Finally
                MiConexion.Close()
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    ''' <summary>Verifica si la tabla DVV existe por si me la borraron de la base de datos como en la primer entrega</summary>
    Public Shared Function VerificarTabla(ByVal NombreTabla As String) As Boolean
        Dim misParametros As New Hashtable
        misParametros.Add("@NombreTabla", NombreTabla)
        Dim miDataTable As New DataTable
        miDataTable = Conexion.Leer("VerificarExisteTabla", misParametros)
        If miDataTable.Rows(0).Item(0) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
