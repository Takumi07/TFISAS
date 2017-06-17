Public Class BitacoraDAL

    Public Sub RegistrarBitacora(ByVal paramBitacora As Entidades.BitacoraBase)
        Try
            'Esto va a guardar una u otra bitácora según lo que sea
            If TypeOf (paramBitacora) Is Entidades.BitacoraAuditoria Then
                'Guardo en la Tabla Auditoria
                Dim misParametros As New Hashtable
                paramBitacora.ID = Conexion.ObtenerID("BitacoraAuditoria", "ID_BitacoraA")
                misParametros.Add("@ID_BitacoraA", paramBitacora.ID)
                misParametros.Add("@TipoOperacion", CInt(paramBitacora.TipoOperacion))
                misParametros.Add("@ID_Usuario", Validacion.CompararInteger(paramBitacora.Usuario.ID))
                misParametros.Add("@Descripcion", DirectCast(paramBitacora, Entidades.BitacoraAuditoria).ID_Descripcion)
                misParametros.Add("@FechaHora", paramBitacora.FechaHora)
                misParametros.Add("@IP", IIf(IsNothing(paramBitacora.Usuario.IP), DBNull.Value, paramBitacora.Usuario.IP))
                misParametros.Add("@WebBrowser", IIf(IsNothing(paramBitacora.Usuario.WebBrowser), DBNull.Value, paramBitacora.Usuario.WebBrowser))
                misParametros.Add("@DVH", DVDAL.CalcularDVH(DirectCast(paramBitacora, Entidades.BitacoraAuditoria).DVH))
                Conexion.ExecuteNonQuery("AltaBitacoraAuditoria", misParametros)
                DVDAL.CalcularDVV("BitacoraAuditoria")

            ElseIf TypeOf (paramBitacora) Is Entidades.BitacoraErrores Then
                'Guardo en la Tabla Errores
                Dim misParametros As New Hashtable
                paramBitacora.ID = Conexion.ObtenerID("BitacoraErrores", "ID_BitacoraE")
                misParametros.Add("@ID_BitacoraE", paramBitacora.ID)
                misParametros.Add("@TipoOperacion", CInt(paramBitacora.TipoOperacion))
                misParametros.Add("@ID_Usuario", paramBitacora.Usuario.ID)
                misParametros.Add("@FechaHora", paramBitacora.FechaHora)
                misParametros.Add("@IP", IIf(IsNothing(paramBitacora.Usuario.IP), DBNull.Value, paramBitacora.Usuario.IP))
                misParametros.Add("@WebBrowser", IIf(IsNothing(paramBitacora.Usuario.WebBrowser), DBNull.Value, paramBitacora.Usuario.WebBrowser))
                misParametros.Add("@StackTrace", DirectCast(paramBitacora, Entidades.BitacoraErrores).StackTrace)
                misParametros.Add("@Mensaje", DirectCast(paramBitacora, Entidades.BitacoraErrores).Mensaje)
                misParametros.Add("@TipoExepcion", DirectCast(paramBitacora, Entidades.BitacoraErrores).TipoException)
                misParametros.Add("@DVH", DVDAL.CalcularDVH(DirectCast(paramBitacora, Entidades.BitacoraErrores).DVH))
                Dim a As String
                a = DirectCast(paramBitacora, Entidades.BitacoraErrores).DVH
                Conexion.ExecuteNonQuery("AltaBitacoraErrores", misParametros)
                DVDAL.CalcularDVV("BitacoraErrores")

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Function ListarBitacoraAuditoria() As List(Of Entidades.BitacoraAuditoria)
        Dim miDataTable As New DataTable
        Dim miListaBitacora As New List(Of Entidades.BitacoraAuditoria)
        Dim misParametros As New Hashtable
        miDataTable = Conexion.Leer("ListarBitacoraAuditoria")
        If miDataTable.Rows.Count > 0 Then
            For Each Item As DataRow In miDataTable.Rows
                Dim miBitacora As New Entidades.BitacoraAuditoria
                Me.formatearBitacoraAuditoria(miBitacora, Item)
                miListaBitacora.Add(miBitacora)
            Next
            Return miListaBitacora
        Else
            Return Nothing
        End If
    End Function



    Public Function ListarBitacoraErrores() As List(Of Entidades.BitacoraErrores)
        Dim miDataTable As New DataTable
        Dim miListaBitacora As New List(Of Entidades.BitacoraErrores)
        miDataTable = Conexion.Leer("ListarBitacoraErrores")
        If miDataTable.Rows.Count > 0 Then
            For Each Item As DataRow In miDataTable.Rows
                Dim miBitacora As New Entidades.BitacoraErrores
                Me.formatearBitacoraErrores(miBitacora, Item)
                miListaBitacora.Add(miBitacora)
            Next
            Return miListaBitacora
        Else
            Return Nothing
        End If
    End Function








#Region "Consulta Selección FILTRO"

    Public Function ListarBitacoraAuditoria(ByVal paramOperacion As Integer) As List(Of Entidades.BitacoraAuditoria)
        Try
            Dim MiListaBitacoraAuditoria As New List(Of Entidades.BitacoraAuditoria)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@TipoOperacion", paramOperacion)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarBitacoraAuditoriaOperacion", MisParametros)
            For Each MiDataRow As DataRow In MiDataTable.Rows
                Dim MiBitacoraAuditoriaEntidad As New Entidades.BitacoraAuditoria
                formatearBitacoraAuditoria(MiBitacoraAuditoriaEntidad, MiDataRow)
                MiListaBitacoraAuditoria.Add(MiBitacoraAuditoriaEntidad)
            Next
            Return MiListaBitacoraAuditoria
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function ListarBitacoraAuditoria(ByVal paramFechaDesde As Date, ByVal paramFechaHasta As Date) As List(Of Entidades.BitacoraAuditoria)
        Try

            Dim MiListaBitacoraAuditoria As New List(Of Entidades.BitacoraAuditoria)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@FechaDesde", paramFechaDesde)
            MisParametros.Add("@FechaHasta", paramFechaHasta)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarBitacoraAuditoriaFecha", MisParametros)
            For Each MiDataRow As DataRow In MiDataTable.Rows
                Dim MiBitacoraAuditoriaEntidad As New Entidades.BitacoraAuditoria
                formatearBitacoraAuditoria(MiBitacoraAuditoriaEntidad, MiDataRow)
                MiListaBitacoraAuditoria.Add(MiBitacoraAuditoriaEntidad)
            Next
            Return MiListaBitacoraAuditoria
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarBitacoraAuditoria(ByVal paramFechaDesde As Date, ByVal paramFechaHasta As Date, ByVal paramOperacion As Integer) As List(Of Entidades.BitacoraAuditoria)
        Try

            Dim MiListaBitacoraAuditoria As New List(Of Entidades.BitacoraAuditoria)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@FechaDesde", paramFechaDesde)
            MisParametros.Add("@FechaHasta", paramFechaHasta)
            MisParametros.Add("@TipoOperacion", paramOperacion)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarBitacoraAuditoriaFechaOperacion", MisParametros)
            For Each MiDataRow As DataRow In MiDataTable.Rows
                Dim MiBitacoraAuditoriaEntidad As New Entidades.BitacoraAuditoria
                formatearBitacoraAuditoria(MiBitacoraAuditoriaEntidad, MiDataRow)
                MiListaBitacoraAuditoria.Add(MiBitacoraAuditoriaEntidad)
            Next
            Return MiListaBitacoraAuditoria
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarBitacoraAuditoria(ByVal paramUsuario As Entidades.Usuario) As List(Of Entidades.BitacoraAuditoria)
        Try

            Dim MiListaBitacoraAuditoria As New List(Of Entidades.BitacoraAuditoria)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarBitacoraAuditoriaUsuario", MisParametros)
            For Each MiDataRow As DataRow In MiDataTable.Rows
                Dim MiBitacoraAuditoriaEntidad As New Entidades.BitacoraAuditoria
                formatearBitacoraAuditoria(MiBitacoraAuditoriaEntidad, MiDataRow)
                MiListaBitacoraAuditoria.Add(MiBitacoraAuditoriaEntidad)
            Next
            Return MiListaBitacoraAuditoria
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarBitacoraAuditoria(ByVal paramUsuario As Entidades.Usuario, ByVal paramOperacion As Integer) As List(Of Entidades.BitacoraAuditoria)
        Try
            Dim MiListaBitacoraAuditoria As New List(Of Entidades.BitacoraAuditoria)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)
            MisParametros.Add("@TipoOperacion", paramOperacion)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarBitacoraAuditoriaUsuarioOperacion", MisParametros)
            For Each MiDataRow As DataRow In MiDataTable.Rows
                Dim MiBitacoraAuditoriaEntidad As New Entidades.BitacoraAuditoria
                formatearBitacoraAuditoria(MiBitacoraAuditoriaEntidad, MiDataRow)
                MiListaBitacoraAuditoria.Add(MiBitacoraAuditoriaEntidad)
            Next
            Return MiListaBitacoraAuditoria
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarBitacoraAuditoria(ByVal paramUsuario As Entidades.Usuario, ByVal paramFechaDesde As Date, ByVal paramFechaHasta As Date) As List(Of Entidades.BitacoraAuditoria)
        Try
            Dim MiListaBitacoraAuditoria As New List(Of Entidades.BitacoraAuditoria)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)
            MisParametros.Add("@FechaDesde", paramFechaDesde)
            MisParametros.Add("@FechaHasta", paramFechaHasta)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarBitacoraAuditoriaUsuarioFecha", MisParametros)
            For Each MiDataRow As DataRow In MiDataTable.Rows
                Dim MiBitacoraAuditoriaEntidad As New Entidades.BitacoraAuditoria
                formatearBitacoraAuditoria(MiBitacoraAuditoriaEntidad, MiDataRow)
                MiListaBitacoraAuditoria.Add(MiBitacoraAuditoriaEntidad)
            Next
            Return MiListaBitacoraAuditoria
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarBitacoraAuditoria(ByVal paramUsuario As Entidades.Usuario, ByVal paramFechaDesde As Date, ByVal paramFechaHasta As Date, ByVal paramOperacion As Integer) As List(Of Entidades.BitacoraAuditoria)
        Try

            Dim MiListaBitacoraAuditoria As New List(Of Entidades.BitacoraAuditoria)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuario.ID)
            MisParametros.Add("@FechaDesde", paramFechaDesde)
            MisParametros.Add("@FechaHasta", paramFechaHasta)
            MisParametros.Add("@TipoOperacion", paramOperacion)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ListarBitacoraAuditoriaUsuarioFechaOperacion", MisParametros)
            For Each MiDataRow As DataRow In MiDataTable.Rows
                Dim MiBitacoraAuditoriaEntidad As New Entidades.BitacoraAuditoria
                formatearBitacoraAuditoria(MiBitacoraAuditoriaEntidad, MiDataRow)
                MiListaBitacoraAuditoria.Add(MiBitacoraAuditoriaEntidad)
            Next
            Return MiListaBitacoraAuditoria
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region







#Region "Formatear"
    Private Sub formatearBitacoraAuditoria(ByVal paramBitacora As Entidades.BitacoraAuditoria, ByVal paramDataRow As DataRow)
        paramBitacora.ID = paramDataRow("ID_BitacoraA")
        paramBitacora.TipoOperacion = paramDataRow("ID_TipoOperacion")
        paramBitacora.Usuario = UsuarioDAL.ListarUsuarioLazyAuditoriaPorID(DAL.Validacion.CompararInteger(paramDataRow("ID_Usuario")))
        paramBitacora.ID_Descripcion = DAL.Validacion.CompararInteger(paramDataRow("ID_Descripcion"))
        paramBitacora.FechaHora = DAL.Validacion.CompararDatetime(paramDataRow("FechaHora"))
        paramBitacora.IP = DAL.Validacion.CompararString(paramDataRow("IP"))
        paramBitacora.Webbrowser = DAL.Validacion.CompararString(paramDataRow("WebBrowser"))
    End Sub


    Private Sub formatearBitacoraErrores(ByVal paramBitacora As Entidades.BitacoraErrores, ByVal paramDataRow As DataRow)
        paramBitacora.ID = paramDataRow("ID_BitacoraE")
        paramBitacora.TipoOperacion = paramDataRow("ID_TipoOperacion")
        paramBitacora.Usuario = UsuarioDAL.ListarUsuarioLazyAuditoriaPorID(DAL.Validacion.CompararInteger(paramDataRow("ID_Usuario")))
        paramBitacora.FechaHora = DAL.Validacion.CompararDatetime(paramDataRow("FechaHora"))
        paramBitacora.IP = DAL.Validacion.CompararString(paramDataRow("IP"))
        paramBitacora.Webbrowser = DAL.Validacion.CompararString(paramDataRow("WebBrowser"))
        paramBitacora.StackTrace = DAL.Validacion.CompararString(paramDataRow("StackTrace"))
        paramBitacora.Mensaje = DAL.Validacion.CompararString(paramDataRow("Mensaje"))
        paramBitacora.TipoException = DAL.Validacion.CompararString(paramDataRow("TipoExepcion"))
    End Sub
#End Region






End Class
