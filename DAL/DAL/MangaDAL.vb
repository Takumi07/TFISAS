Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Entidades


Public Class MangaDAL
    Inherits DAL.ProductoDAL

    ''' 
    ''' <param name="paramProducto"></param>
    Public Overrides Sub NuevoProducto(ByVal paramProducto As Entidades.Producto)
        Try
            Dim MisParametros As New Hashtable
            'El ID del producto me tiene que venir de mybase
            MisParametros.Add("@ID_Producto", paramProducto.ID)
            MisParametros.Add("@ID_Editorial", DirectCast(paramProducto, Entidades.Manga).Editorial.ID)
            MisParametros.Add("@Fec_Salida_PTomo", DirectCast(paramProducto, Entidades.Manga).Fec_Salida_PTomo)
            MisParametros.Add("@N_Tomo", DirectCast(paramProducto, Entidades.Manga).N_Tomo)
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(DirectCast(paramProducto, Entidades.Manga).DVHM))
            DAL.Conexion.ExecuteNonQuery("AltaManga", MisParametros)
            DVDAL.CalcularDVV("Manga")
        Catch ex As Exception

        End Try

    End Sub

    Public Overrides Sub ModificarProducto(ByVal paramProducto As Producto)

        Try

            Dim MisParametros As New Hashtable
            'El ID del producto me tiene que venir de mybase
            MisParametros.Add("@ID_Producto", paramProducto.ID)
            MisParametros.Add("@ID_Editorial", DirectCast(paramProducto, Entidades.Manga).Editorial.ID)
            MisParametros.Add("@Fec_Salida_PTomo", DirectCast(paramProducto, Entidades.Manga).Fec_Salida_PTomo)
            MisParametros.Add("@N_Tomo", DirectCast(paramProducto, Entidades.Manga).N_Tomo)
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(DirectCast(paramProducto, Entidades.Manga).DVHM))
            DAL.Conexion.ExecuteNonQuery("ModificarManga", MisParametros)
            DVDAL.CalcularDVV("Manga")

        Catch ex As Exception

        End Try




    End Sub

    Public Overrides Sub BajaProducto(ByVal Producto As Producto)
        'Esto esta en en la base porque solo la tabla producto tiene el campo bl. Entoces llamo a mybase.baja.
    End Sub

    Public Function ObtenerUnManga(ByVal paramID As Integer) As Manga
        Dim MiManga As New Manga
        Dim miDataTable As New DataTable
        Dim misParametros As New Hashtable
        MiManga.ID = paramID
        misParametros.Add("@ID_Producto", paramID)
        miDataTable = Conexion.Leer("ListarUnManga", misParametros)
        If miDataTable.Rows.Count > 0 Then
            'Me traigo la parte del producto
            MiManga = MyBase.ListarUnProducto(MiManga)
            FormatearManga(miDataTable.Rows(0), MiManga)
            Return MiManga
        Else
            Return Nothing
        End If
    End Function


    ''' <summary>
    ''' Lista los mangas que NO estan dados de baja
    ''' </summary>
    ''' <returns></returns>
    Public Function ListarProductosManga() As List(Of Entidades.Manga)
        Try
            Dim MiListaMangas As New List(Of Entidades.Manga)
            Dim MisParametros As New Hashtable
            Dim miDataTable As DataTable = DAL.Conexion.Leer("ListarMangas", MisParametros)
            For Each miDataRow As DataRow In miDataTable.Rows
                Dim MiManga As New Entidades.Manga
                'Me traigo la parte del producto que necesito
                'Ojo no anda, revisar!!
                FormatearManga(miDataRow, MiManga)
                MiManga = MyBase.ListarUnProducto(MiManga)
                MiListaMangas.Add(MiManga)
            Next
            Return MiListaMangas
        Catch ex As Exception

        End Try
    End Function

    Private Sub FormatearManga(ByVal paramRow As DataRow, ByVal paramManga As Manga)
        paramManga.ID = paramRow("ID_Producto")
        paramManga.Editorial = DAL.EditorialDAL.ObtenerUnaEditorial(paramRow("ID_Editorial"))
        paramManga.Fec_Salida_PTomo = paramRow("Fec_Salida_PTomo")
        paramManga.N_Tomo = paramRow("N_Tomo")
    End Sub
End Class



