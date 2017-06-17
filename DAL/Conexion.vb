Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.Text
Imports System.IO

Imports System.Web




Public Class Conexion

    'PONER LA NUEVA CLASE Y ADAPTAR TODO ACA


    'Casa
    'Private Shared MiStringConexion As String = "Data Source=TAKUMI\SQLEXPRESS;Initial Catalog=TFISAS;Integrated Security=True"

    'Trabajo
    Private Shared MiStringConexion As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("Produccion").ConnectionString

    'Facultad
    'Private Shared MiStringConexion As String = ""

    'Private mivieja As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("Produccion").ConnectionString

    'UAI
    'Data Source=.\SQL14_UAI;Initial Catalog=TFISAS;Integrated Security=True

    'UAI Master
    'Data Source=.\SQL14_UAI;Initial Catalog=Master;Integrated Security=True

    'PROGRAMADORA
    'Data Source=.;Initial Catalog=TFISAS;Integrated Security=True


    Private Shared ComandoRestore As SqlCommand
    Private Shared MiConexion As New SqlConnection(MiStringConexion)
    Private Shared MiTransaccion As SqlTransaction
    Private Shared MiComando As SqlCommand

    Shared Function retornaConexion() As SqlConnection
        Dim _objConexionMaster As New SqlConnection
        _objConexionMaster.ConnectionString = MiStringConexion
        Return _objConexionMaster
    End Function

    Shared Function retornaConexionMaestra() As SqlConnection
        Dim _objConexionMaster As New SqlConnection
        'Casa 
        '_objConexionMaster.ConnectionString = "Data Source=TAKUMI\SQLEXPRESS;Initial Catalog=Master;Integrated Security=True"

        _objConexionMaster.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("Maestra").ConnectionString
        'Trabajo
        '_objConexionMaster.ConnectionString = "Data Source=PROGRAMADORA-PC;Initial Catalog=master;Integrated Security=True"
        Return _objConexionMaster
    End Function

    Public Shared Function Leer(ByVal paramConsulta As String, ByVal Optional hdatos As Hashtable = Nothing) As DataTable
        Try

            Dim miDataTable As New DataTable
            MiComando = New SqlCommand
            MiComando.Connection = MiConexion
            MiComando.CommandText = paramConsulta
            MiComando.CommandType = CommandType.StoredProcedure
            If Not hdatos Is Nothing Then
                'si la hashtable no esta vacia, y tiene el dato q busco 
                For Each dato As String In hdatos.Keys
                    'cargo los parametros que le estoy pasando con la Hash
                    MiComando.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If
            Dim Adaptador As New SqlDataAdapter(MiComando)
            Adaptador.Fill(miDataTable)
            Return miDataTable
            MiConexion.Close()

        Catch ex As SqlException
            Try
                Dim directorio As String
                directorio = System.Configuration.ConfigurationSettings.AppSettings("rutaerrores").Trim
                CrearDirectorio(directorio)

                Dim nombre As String
                nombre = DateTime.Now.Year & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & ".TXT"

                Using outputFile As New StreamWriter(directorio & Convert.ToString(nombre))
                    outputFile.WriteLine("Type: " & ex.GetType.ToString)
                    outputFile.WriteLine("Error: " & ex.Message)
                    outputFile.WriteLine("Stack Trace: " & ex.StackTrace)
                    outputFile.WriteLine("HRESULT: " & ex.ToString)
                    outputFile.Write("Number" & ex.Number.ToString)
                End Using
            Catch ex2 As Exception
                Throw ex
            End Try
            Throw ex
        Catch ex As Exception
            Try
                Dim directorio As String
                directorio = System.Configuration.ConfigurationSettings.AppSettings("rutaerrores").Trim
                CrearDirectorio(directorio)

                Dim nombre As String
                nombre = DateTime.Now.Year & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & ".TXT"

                Using outputFile As New StreamWriter(directorio & Convert.ToString(nombre))
                    outputFile.WriteLine("Type: " & ex.GetType.ToString)
                    outputFile.WriteLine("Error: " & ex.Message)
                    outputFile.WriteLine("Stack Trace: " & ex.StackTrace)
                    outputFile.WriteLine("HRESULT: " & ex.ToString)
                End Using
            Catch ex2 As Exception
                Throw ex
            End Try
        End Try
    End Function

    Public Shared Sub ExecuteNonQuery(ByVal paramConsulta As String, ByVal hdatos As Hashtable)
        If MiConexion.State = ConnectionState.Closed Then
            MiConexion.ConnectionString = MiStringConexion
            MiConexion.Open()
        End If
        Try
            MiTransaccion = MiConexion.BeginTransaction
            MiComando = New SqlCommand
            MiComando.Connection = MiConexion
            MiComando.CommandText = paramConsulta
            MiComando.CommandType = CommandType.StoredProcedure
            MiComando.Transaction = MiTransaccion
            If Not hdatos Is Nothing Then
                For Each dato As String In hdatos.Keys
                    MiComando.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If
            Dim respuesta As Integer = MiComando.ExecuteNonQuery
            MiTransaccion.Commit()

        Catch ex As SqlException
            MiTransaccion.Rollback()

            Try
                Dim directorio As String
                directorio = System.Configuration.ConfigurationSettings.AppSettings("rutaerrores").Trim
                CrearDirectorio(directorio)

                Dim nombre As String
                nombre = DateTime.Now.Year & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & ".TXT"

                Using outputFile As New StreamWriter(directorio & Convert.ToString(nombre))
                    outputFile.WriteLine("Type: " & ex.GetType.ToString)
                    outputFile.WriteLine("Error: " & ex.Message)
                    outputFile.WriteLine("Stack Trace: " & ex.StackTrace)
                    outputFile.WriteLine("HRESULT: " & ex.ToString)
                    outputFile.Write("Number" & ex.Number.ToString)
                End Using
            Catch ex2 As Exception
                Throw ex
            End Try

            Throw ex
        Catch ex As Exception

            MiTransaccion.Rollback()
            Try
                Dim directorio As String
                directorio = System.Configuration.ConfigurationSettings.AppSettings("rutaerrores").Trim
                CrearDirectorio(directorio)

                Dim nombre As String
                nombre = DateTime.Now.Year & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & ".TXT"

                Using outputFile As New StreamWriter(directorio & Convert.ToString(nombre))
                    outputFile.WriteLine("Type: " & ex.GetType.ToString)
                    outputFile.WriteLine("Error: " & ex.Message)
                    outputFile.WriteLine("Stack Trace: " & ex.StackTrace)
                    outputFile.WriteLine("HRESULT: " & ex.ToString)
                End Using
            Catch ex2 As Exception
                Throw ex
            End Try
            Throw ex

        Finally
            MiConexion.Close()
        End Try
    End Sub




    Shared Function ObtenerID(ByVal paramTabla As String, ByVal paramCampoID As String) As Integer
        Try
            If MiConexion.State = ConnectionState.Closed Then
                MiConexion.Open()
            End If

            MiComando = New SqlCommand
            MiComando.Connection = MiConexion
            MiComando.CommandText = "ObtenerID"
            MiComando.CommandType = CommandType.StoredProcedure
            MiComando.Parameters.Add(New SqlParameter("@paramTabla", paramTabla))
            MiComando.Parameters.Add(New SqlParameter("@paramCampoID", paramCampoID))

            Dim _dataTable As New DataTable
            Dim _resultado As Integer
            Dim _dataAdapter As New SqlDataAdapter(MiComando)
            _dataAdapter.Fill(_dataTable)
            If _dataTable.Rows.Count = 0 Then
                _resultado = 1
            Else
                _resultado = (_dataTable.Rows(0).Item(0)) + 1
            End If
            Return _resultado

        Catch ex As Exception
            Try
                Dim directorio As String
                directorio = System.Configuration.ConfigurationSettings.AppSettings("rutaerrores").Trim
                CrearDirectorio(directorio)

                Dim nombre As String
                nombre = DateTime.Now.Year & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & ".TXT"

                Using outputFile As New StreamWriter(directorio & Convert.ToString(nombre))
                    outputFile.WriteLine("Type: " & ex.GetType.ToString)
                    outputFile.WriteLine("Error: " & ex.Message)
                    outputFile.WriteLine("Stack Trace: " & ex.StackTrace)
                    outputFile.WriteLine("HRESULT: " & ex.ToString)
                End Using
            Catch ex2 As Exception
                Throw ex
            End Try
            Throw ex
        Finally
            MiConexion.Close()
        End Try
    End Function


#Region "Agregado para Errores"
    Public Shared Sub CrearDirectorio(ByVal paramPath As String)
        Try
            Dim MiDirectorio As DirectoryInfo = New DirectoryInfo(paramPath)
            If Not MiDirectorio.Exists Then
                MiDirectorio.Create()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class
