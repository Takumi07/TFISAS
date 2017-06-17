Imports System.Threading

Public Class BitacoraBLL


    Dim MiBitacoraDAL As New DAL.BitacoraDAL

#Region "Alta"

    Public Shared Sub RegistrarBitacoraAuditoria(ByVal paramBitacoraAuditoria As Entidades.BitacoraAuditoria)
        Try
            Dim MiBitacoraDAL As New DAL.BitacoraDAL
            MiBitacoraDAL.RegistrarBitacora(paramBitacoraAuditoria)
        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub RegistrarBitacoraErrores(ByVal paramBitacoraErrores As Entidades.BitacoraErrores)

        Try
            If IsNothing(paramBitacoraErrores.Usuario) Then

                Dim MiUsuarioEntidad As New Entidades.Usuario
                'Usuario de Sistema
                MiUsuarioEntidad.ID = 0
                paramBitacoraErrores.Usuario = MiUsuarioEntidad
            End If
            Dim MiBitacoraDAL As New DAL.BitacoraDAL
            MiBitacoraDAL.RegistrarBitacora(paramBitacoraErrores)
        Catch ex As Exception

        End Try
    End Sub

#End Region


#Region "Listar Bitacora Auditoria"

    'Modifico si quiero una bitacora de errores o bitacora de auditorìa.
    Public Function ListarBitacoraAuditoria() As List(Of Entidades.BitacoraAuditoria)
        Try
            Dim listaBitacora As New List(Of Entidades.BitacoraAuditoria)
            listaBitacora = MiBitacoraDAL.ListarBitacoraAuditoria()
            Return listaBitacora
        Catch ex As Exception

        End Try
    End Function


    Public Function ListarBitacoraAuditoria(ByVal paramUsuario As Entidades.Usuario, ByVal paramFechaDesde As Date, ByVal paramFechaHasta As Date, ByVal paramOperacion As Integer) As List(Of Entidades.BitacoraAuditoria)
        Try
            If paramUsuario Is Nothing And paramFechaDesde = "#12:00:00 AM#" And paramFechaHasta = "#12:00:00 AM#" And paramOperacion = 0 Then
                'NO TIENE NADA
                Return MiBitacoraDAL.ListarBitacoraAuditoria
            ElseIf paramUsuario Is Nothing And paramFechaDesde = "#12:00:00 AM#" And paramFechaHasta = "#12:00:00 AM#" And paramOperacion <> 0 Then
                'TIENE SOLO OPERACION
                Return MiBitacoraDAL.ListarBitacoraAuditoria(paramOperacion)
            ElseIf paramUsuario Is Nothing And paramFechaDesde <> "#12:00:00 AM#" And paramFechaHasta <> "#12:00:00 AM#" And paramOperacion = 0 Then
                'TIENE LA FECHA
                Return MiBitacoraDAL.ListarBitacoraAuditoria(paramFechaDesde, paramFechaHasta)
            ElseIf paramUsuario Is Nothing And paramFechaDesde <> "#12:00:00 AM#" And paramFechaHasta <> "#12:00:00 AM#" And paramOperacion <> 0 Then
                'TIENE LA FECHA Y EL OPERACION
                Return MiBitacoraDAL.ListarBitacoraAuditoria(paramFechaDesde, paramFechaHasta, paramOperacion)
            ElseIf Not paramUsuario Is Nothing And paramFechaDesde = "#12:00:00 AM#" And paramFechaHasta = "#12:00:00 AM#" And paramOperacion = 0 Then
                'TIENE EL USUARIO
                Return MiBitacoraDAL.ListarBitacoraAuditoria(paramUsuario)
            ElseIf Not paramUsuario Is Nothing And paramFechaDesde = "#12:00:00 AM#" And paramFechaHasta = "#12:00:00 AM#" And paramOperacion <> 0 Then
                'TIENE EL USUARIO y EL OPERACION
                Return MiBitacoraDAL.ListarBitacoraAuditoria(paramUsuario, paramOperacion)
            ElseIf Not paramUsuario Is Nothing And paramFechaDesde <> "#12:00:00 AM#" And paramFechaHasta <> "#12:00:00 AM#" And paramOperacion = 0 Then
                'TIENE EL USUARIO Y LA FECHA
                Return MiBitacoraDAL.ListarBitacoraAuditoria(paramUsuario, paramFechaDesde, paramFechaHasta)
            ElseIf Not paramUsuario Is Nothing And paramFechaDesde <> "#12:00:00 AM#" And paramFechaHasta <> "#12:00:00 AM#" And paramOperacion <> 0 Then
                'TIENE EL USUARIO, LA PERSONA y EL ESTADO
                Return MiBitacoraDAL.ListarBitacoraAuditoria(paramUsuario, paramFechaDesde, paramFechaHasta, paramOperacion)
            End If
        Catch ex As Exception
            Throw New BLL.ExcepcionGenerica
        End Try
    End Function

#End Region







    Public Function ListarBitacoraErrores() As List(Of Entidades.BitacoraErrores)
        Try
            Dim listaBitacora As New List(Of Entidades.BitacoraErrores)
            listaBitacora = MiBitacoraDAL.ListarBitacoraErrores()
            Return listaBitacora
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Public Shared Function DevolverUsuario() As Entidades.Usuario
    '    Return DirectCast(Thread.CurrentPrincipal, Entidades.Usuario)
    'End Function
End Class