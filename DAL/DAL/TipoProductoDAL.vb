Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Entidades
Public Class TipoProductoDAL
#Region "Consultas de Selección"
    ''' <summary> Método que devuelve todos los Tipos de productos </summary>
    Public Function ListarTipoProducto() As List(Of Entidades.TipoProducto)
        Dim MiListaTipoProducto As New List(Of Entidades.TipoProducto)
        Dim misParametros As New Hashtable
        misParametros.Add("@bl", False)

        Dim miDataTable As DataTable = DAL.Conexion.Leer("ListarTipoProducto", misParametros)
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiTipoProducto As New Entidades.TipoProducto
            FormatearTipoProducto(miDataRow, MiTipoProducto)
            MiListaTipoProducto.Add(MiTipoProducto)
        Next
        Return MiListaTipoProducto
    End Function



    'Esto es para darle cumplimiento a una funcionalidad de cliente
    Public Shared Function ObtenerTipoProducto(ByVal paramID As Integer) As Entidades.TipoProducto
        Dim MiDataTable As DataTable
        Dim MisParametros As New Hashtable
        MisParametros.Add("@ID_TipoProducto", paramID)
        MiDataTable = Conexion.Leer("CargarUnTipoProducto", MisParametros)
        For Each MiRow As DataRow In MiDataTable.Rows
            Dim MiTipoProducto As New TipoProducto
            FormatearTipoProducto(MiRow, MiTipoProducto)
            Return MiTipoProducto
        Next
    End Function



    Public Sub GuardarTipoProducto(ByVal paramTipoProducto As Entidades.TipoProducto)
    End Sub


    Public Sub ModificarTipoProducto(ByVal paramTipoProducto As Entidades.TipoProducto)
    End Sub


    Public Sub BajaTipoProducto(ByVal paramTipoProducto As Entidades.TipoProducto)
    End Sub


#End Region

#Region "Formateo"
    Private Shared Sub FormatearTipoProducto(ByVal paramDataRow As DataRow, ByVal paramTipoProducto As Entidades.TipoProducto)
        paramTipoProducto.ID_TipoProducto = paramDataRow.Item("ID_TipoProducto")
        paramTipoProducto.Descripcion = paramDataRow.Item("Descripcion")
        paramTipoProducto.BL = paramDataRow.Item("BL")
    End Sub
#End Region


End Class
