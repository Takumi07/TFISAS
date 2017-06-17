Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Globalization
Public Class IdiomaDAL

    'Pasar a StoredProcedure
#Region "ABM"
    Public Sub altaIdioma(ByVal paramIdiomaEntidad As Entidades.Idioma)
        Try
            'Creo el idioma en la tabla idioma
            paramIdiomaEntidad.ID = Conexion.ObtenerID("Idioma", "ID_Idioma")
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Idioma", paramIdiomaEntidad.ID)
            MisParametros.Add("@Nombre", paramIdiomaEntidad.Nombre)
            MisParametros.Add("@Editable", paramIdiomaEntidad.Editable)
            MisParametros.Add("@BL", paramIdiomaEntidad.BL)
            MisParametros.Add("@Cultura", paramIdiomaEntidad.Cultura.Name)
            'Calculo los dìgitos verificadores horizontales
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(paramIdiomaEntidad.DVH))
            Conexion.ExecuteNonQuery("AltaIdioma", MisParametros)
            'Calculo los dígitos verificadores verticales
            DVDAL.CalcularDVV("Idioma")



            'Creo las palabras para ese idioma
            For Each _pal As Entidades.Palabra In paramIdiomaEntidad.Palabras
                Dim MisParametrosT As New Hashtable
                MisParametrosT.Add("@ID_Control", _pal.ID_Control)
                MisParametrosT.Add("@ID_idioma", paramIdiomaEntidad.ID)
                MisParametrosT.Add("@Palabra", _pal.Traduccion)
                'Calculo los dìgitos verificadores horizontales
                MisParametrosT.Add("@DVH", DVDAL.CalcularDVH(_pal.ID_Control & paramIdiomaEntidad.ID & _pal.Traduccion))
                DAL.Conexion.ExecuteNonQuery("AltaTraduccion", MisParametrosT)
                'Calculo los dígitos verificadores verticales
                DVDAL.CalcularDVV("Traduccion")
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub modificarIdioma(ByVal paramEntidad As Entidades.Idioma)
        Try

            Dim MisParametros2 As New Hashtable
            MisParametros2.Add("@ID_Idioma", paramEntidad.ID)
            MisParametros2.Add("@Cultura", paramEntidad.Cultura.Name)
            Dim a As String
            a = paramEntidad.DVH
            MisParametros2.Add("@DVH", DVDAL.CalcularDVH(paramEntidad.DVH))
            Conexion.ExecuteNonQuery("ModificarIdioma", MisParametros2)
            DVDAL.CalcularDVV("Idioma")

            'Modifico cada palabra de la traducción
            For Each _pal As Entidades.Palabra In paramEntidad.Palabras
                Dim MisParametros As New Hashtable
                MisParametros.Add("@ID_Control", _pal.ID_Control)
                MisParametros.Add("@ID_idioma", paramEntidad.ID)
                MisParametros.Add("@Palabra", _pal.Traduccion)
                MisParametros.Add("@DVH", DVDAL.CalcularDVH(_pal.ID_Control & paramEntidad.ID & _pal.Traduccion))
                DAL.Conexion.ExecuteNonQuery("ModificarTraduccion", MisParametros)
                DVDAL.CalcularDVV("Traduccion")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub bajaIdioma(ByVal paramIdiomaEntidad As Entidades.Idioma)
        Try

            Dim misParametros As New Hashtable
            misParametros.Add("@ID_Idioma", paramIdiomaEntidad.ID)
            misParametros.Add("@BL", paramIdiomaEntidad.BL)
            'Calculo los dìgitos verificadores horizontales
            misParametros.Add("@DVH", DVDAL.CalcularDVH(paramIdiomaEntidad.DVH))
            Conexion.ExecuteNonQuery("BajaIdioma", misParametros)
            DVDAL.CalcularDVV("Idioma")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region




    Public Function Cargar(ByVal paramIdiomaEntidad As Entidades.Idioma) As Entidades.Idioma
        Try
            Dim MiIdiomaEntidad As New Entidades.Idioma
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Idioma", paramIdiomaEntidad.ID)
            MiDataTable = Conexion.Leer("CargarUnIdioma", MisParametros)
            formatearIdioma(MiDataTable.Rows(0), MiIdiomaEntidad)
            For Each MiRow As DataRow In MiDataTable.Rows
                Dim MiPalabra As New Entidades.Palabra
                formatearPalabra2(MiRow, MiPalabra)
                MiIdiomaEntidad.Palabras.Add(MiPalabra)
            Next
            Return MiIdiomaEntidad
        Catch ex As Exception
            Throw ex
        End Try

    End Function



#Region "AgregadoParaCargarPorPagina"
    Public Function Cargar(ByVal paramIdiomaEntidad As Entidades.Idioma, ByVal paramPage As String) As Entidades.Idioma
        Try
            Dim MiIdiomaEntidad As New Entidades.Idioma
            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Idioma", paramIdiomaEntidad.ID)
            MisParametros.Add("@NombrePagina", paramPage)
            MiDataTable = Conexion.Leer("CargarIdiomaPagina", MisParametros)

            'Cargo la cabecera
            Dim MiDataTable2 As DataTable
            Dim MisParametros2 As New Hashtable
            MisParametros2.Add("@ID_Idioma", paramIdiomaEntidad.ID)
            MiDataTable2 = Conexion.Leer("CargarCabeceraIdioma", MisParametros2)
            formatearIdioma(MiDataTable2.Rows(0), MiIdiomaEntidad)

            'Le cargo las palabras de esa pagina
            For Each MiRow As DataRow In MiDataTable.Rows
                Dim MiPalabra As New Entidades.Palabra
                formatearPalabra(MiRow, MiPalabra)
                MiIdiomaEntidad.Palabras.Add(MiPalabra)
            Next
            Return MiIdiomaEntidad
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


    Public Function consultarIdioma(paramIDIdioma As Integer) As Entidades.Idioma
        Try
            'Dim MisParametros As New Hashtable
            'MisParametros.Add("@ID_Idioma", paramIDIdioma)
            'MisParametros.Add("@BL", False)
            'Dim _dt As DataTable = Conexion.Leer("consultarIdiomaID", MisParametros)
            'If _dt.Rows.Count = 1 Then
            '    Return Me.ConvertirIdioma(_dt.Rows(0))
            'Else
            '    Return Nothing
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function listarIdiomas() As List(Of Entidades.Idioma)
        Try
            Dim _listaIdiomas As New List(Of Entidades.Idioma)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@BL", False)
            Dim miDataTable As DataTable = Conexion.Leer("listarIdiomas", MisParametros)
            For Each miDataRow As DataRow In miDataTable.Rows
                Dim miIdioma As New Entidades.Idioma
                formatearIdioma(miDataRow, miIdioma)
                _listaIdiomas.Add(miIdioma)
            Next
            Return _listaIdiomas
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function traducirMensaje(ByVal paramIdioma As Entidades.Idioma, ByVal paramIDControl As Integer) As String
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Idioma", Validacion.CompararInteger(paramIdioma.ID))
            MisParametros.Add("@ID_Control", Validacion.CompararInteger(paramIDControl))
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("CargarMensaje", MisParametros)

            If MiDataTable.Rows.Count >= 1 Then
                Return MiDataTable.Rows(0).Item("Palabra").ToString
            Else
                Return "No se encontró una traducción para este mensaje en su idioma. Por favor, reporte su idioma al administrador."
            End If

            Return Conexion.Leer("CargarMensaje", MisParametros).Rows(0).Item("Palabra").ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function chequearNombreIdioma(ByVal paramIdiomaEntidad As Entidades.Idioma) As Boolean
        Try

            Dim MiDataTable As DataTable
            Dim MisParametros As New Hashtable
            MisParametros.Add("@Nombre", paramIdiomaEntidad.Nombre)
            MiDataTable = Conexion.Leer("chequearNombreIdioma", MisParametros)
            If MiDataTable.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function







#Region "Formatear"

    Public Sub formatearIdioma(ByVal paramDataRow As DataRow, ByVal paramIdioma As Entidades.Idioma)
        Try
            paramIdioma.ID = paramDataRow.Item("ID_Idioma")
            paramIdioma.Nombre = paramDataRow.Item("Nombre")
            paramIdioma.Editable = paramDataRow.Item("Editable")
            'Revisar si se instancia bien
            Try
                paramIdioma.Cultura = New CultureInfo(paramDataRow.Item("Cultura").ToString)

            Catch ex As CultureNotFoundException
                'Si no la encuentra por la pc, le meto la default
                paramIdioma.Cultura = New CultureInfo("es")
            End Try

            paramIdioma.BL = paramDataRow.Item("BL")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub formatearPalabra(ByVal paramDataRow As DataRow, ByVal paramPalabra As Entidades.Palabra)
        Try
            paramPalabra.ID_Control = paramDataRow("ID_Control")
            paramPalabra.Codigo = paramDataRow("Nombre")
            paramPalabra.Traduccion = paramDataRow("Palabra")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub formatearPalabra2(ByVal paramDataRow As DataRow, ByVal paramPalabra As Entidades.Palabra)
        Try
            paramPalabra.ID_Control = paramDataRow("ID_Control")
            paramPalabra.Codigo = paramDataRow("NombreControl")
            paramPalabra.Traduccion = paramDataRow("Palabra")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
