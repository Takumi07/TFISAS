Imports Entidades
Public Class EditorialDAL
    Public Function ListarEditoriales() As List(Of Entidades.Editorial)
        Dim MiListaEditoriales As New List(Of Entidades.Editorial)
        Dim misParametros As New Hashtable
        misParametros.Add("@bl", False)

        Dim miDataTable As DataTable = DAL.Conexion.Leer("ListarEditoriales", misParametros)
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiEditorial As New Entidades.Editorial
            FormatearEditorial(miDataRow, MiEditorial)
            MiListaEditoriales.Add(MiEditorial)
        Next
        Return MiListaEditoriales
    End Function





    Public Shared Function ObtenerUnaEditorial(ByVal paramID As Integer) As Entidades.Editorial
        Dim MiEditorial As New Entidades.Editorial
        Dim MisParametros As New Hashtable
        MisParametros.Add("@ID_Editorial", paramID)
        Dim miDataTable As DataTable = DAL.Conexion.Leer("ListarUnaEditorial", MisParametros)
        For Each MiRow As DataRow In miDataTable.Rows
            FormatearEditorial(MiRow, MiEditorial)
            Return MiEditorial
        Next
    End Function


    Public Sub GuardarEditorial(ByVal paramEditorial As Entidades.Editorial)
    End Sub


    Public Sub ModificarEditorial(ByVal paramEditorial As Entidades.Editorial)
    End Sub


    Public Sub BajaEditorial(ByVal paramEditorial As Entidades.Editorial)
        'Si muere una editorial mueren todas sus obras
    End Sub


    Private Shared Sub FormatearEditorial(ByVal paramDataRow As DataRow, ByVal paramEditorial As Entidades.Editorial)
        paramEditorial.ID = paramDataRow.Item("ID_Editorial")
        paramEditorial.Nombre = paramDataRow.Item("Nombre")
        paramEditorial.Correo = paramDataRow.Item("Correo")
        paramEditorial.BL = paramDataRow.Item("BL")
    End Sub


End Class
