Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Entidades

Public Class GeneroDAL

#Region "Consultas de Selección"
    ''' <summary> Método que devuelve todos los generos </summary>
    Public Function ListarGeneros() As List(Of Entidades.Genero)
        Dim MiListaGeneros As New List(Of Entidades.Genero)
        Dim misParametros As New Hashtable
        misParametros.Add("@bl", False)

        Dim miDataTable As DataTable = DAL.Conexion.Leer("ListarGeneros", misParametros)
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiGenero As New Entidades.Genero
            FormatearGenero(miDataRow, MiGenero)
            MiListaGeneros.Add(MiGenero)
        Next
        Return MiListaGeneros
    End Function



    'Esto es para darle cumplimiento a una funcionalidad de cliente
    Public Shared Function ObtenerGenero(ByVal paramID As Integer) As Entidades.Genero
        Dim MiGenero As New Entidades.Genero
        Dim MiDataTable As DataTable
        Dim MisParametros As New Hashtable
        MisParametros.Add("@ID_Genero", paramID)
        MiDataTable = Conexion.Leer("CargarUnGenero", MisParametros)
        For Each MiRow As DataRow In MiDataTable.Rows
            FormatearGenero(MiRow, MiGenero)
            Return MiGenero
        Next
    End Function



    Public Function VerfificarGeneroExiste(ByVal paramGenero As Entidades.Genero) As Boolean
        Dim ComandoStr As String
        ComandoStr = "Select * from genero where Descripcion= @descripcion and bl=@bl"
        'Dim MiComando = BD.MiComando(ComandoStr)
        'With MiComando.Parameters
        '    .Add(New SqlParameter("@descripcion", paramGenero.Descripcion))
        '    .Add(New SqlParameter("@bl", 0))
        'End With
        Dim MiDataTable As New DataTable
        'MiDataTable = BD.ExecuteDataTable(MiComando)
        If MiDataTable.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


#End Region



#Region "Consultas de Modificación"
    Public Sub GuardarGenero(ByVal paramGenero As Entidades.Genero)
        Dim ComandoStr As String
        ComandoStr = "insert into genero values(@ID, @Descripcion, @BL)"
        ' Dim MiComando = BD.MiComando(ComandoStr)
        'paramGenero.ID_Genero = BD.ObtenerID("Genero", "ID_Genero")
        'With (MiComando.Parameters)
        '    .Add(New SqlParameter("@ID", paramGenero.ID_Genero))
        '    .Add(New SqlParameter("@Descripcion", paramGenero.Descripcion))
        '    'poner esto en false en la BLL
        '    .Add(New SqlParameter("@BL", paramGenero.BL))
        'End With
        ' Conexion.ExecuteNonQuery(MiComando)
    End Sub


    Public Sub ModificarGenero(ByVal paramGenero As Entidades.Genero)
        Dim ComandoStr As String
        ComandoStr = "update Genero set descripcion = @descripcion where ID_Genero=@ID_Genero"
        'Dim MiComando = BD.MiComando(ComandoStr)
        'With MiComando.Parameters
        '    .Add(New SqlParameter("@ID_Genero", paramGenero.ID_Genero))
        '    .Add(New SqlParameter("@Descripcion", paramGenero.Descripcion))
        'End With
        'Conexion.ExecuteNonQuery(MiComando)
    End Sub


    Public Sub BajaGenero(ByVal paramGenero As Entidades.Genero)
        Dim ComandoStr As String
        ComandoStr = "update Genero set BL=@BL where ID_Genero=@ID_Genero"
        'Dim MiComando = BD.MiComando(ComandoStr)
        'With MiComando.Parameters
        '    .Add(New SqlParameter("@ID_Genero", paramGenero.ID_Genero))
        '    .Add(New SqlParameter("@BL", paramGenero.BL))
        'End With
        'Conexion.ExecuteNonQuery(MiComando)
    End Sub
#End Region



#Region "Formateo"
    Private Shared Sub FormatearGenero(ByVal paramDataRow As DataRow, ByVal paramGenero As Entidades.Genero)
        paramGenero.ID_Genero = paramDataRow.Item("ID_Genero")
        paramGenero.Descripcion = paramDataRow.Item("Descripcion")
        paramGenero.BL = paramDataRow.Item("BL")
    End Sub
#End Region
End Class
