Public Class InventarioBLL
    Dim MiInventario As New DAL.InventarioDAL
    Dim MiUsuarioEntidad As New Entidades.Usuario

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub



    Public Sub CierreInventario()

    End Sub




    Public Shared Function ObtenerStock(ByVal ID_Producto As Integer) As Integer
        Try
            Return DAL.InventarioDAL.ObtenerStock(ID_Producto)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


#Region "Remito"
    Public Sub CargaRemito(ByVal paramRemito As Entidades.Remito)
        Try
            MiInventario.CargaRemito(paramRemito)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, MiUsuarioEntidad, 250))
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub

    Public Sub AprobarRemito(ByVal paramRemito As Entidades.Remito)
        Try
            MiInventario.AprobarRemito(paramRemito)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, MiUsuarioEntidad, 251))
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub

    Public Sub RechazarRemito(ByVal paramRemito As Entidades.Remito)
        Try
            MiInventario.RechazarRemito(paramRemito)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, MiUsuarioEntidad, 252))
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Function VerificarNroRemito(ByVal NroRemito As Integer, ByVal ID_Proveedor As Integer)
        Try
            Return (New DAL.InventarioDAL).VerificarNroRemito(NroRemito, ID_Proveedor)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


    Public Function ListarRemitos(ByVal paramEstado As Integer) As List(Of Entidades.Remito)
        Try
            Return (New DAL.InventarioDAL).ListarRemitos(paramEstado)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function



    Public Function ObtenerUnRemito(ByVal paramRemito As Entidades.Remito) As Entidades.Remito
        Try
            Return (New DAL.InventarioDAL).ObtenerUnRemito(paramRemito)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
#End Region



#Region "Ajuste Stock"
    Public Sub AjustarStock(ByVal paramAjuste As Entidades.AjustarStock)

    End Sub

    Public Sub AprobarAjusteStock(ByVal paramAjuste As Entidades.AjustarStock)

    End Sub

    Public Sub RechazarAjusteStock(ByVal paramAjuste As Entidades.AjustarStock)

    End Sub
    Public Function ListarAjustesStock() As List(Of Entidades.AjustarStock)

    End Function


    Public Function ListarAjustesStockAproPendiente() As List(Of Entidades.AjustarStock)

    End Function


#End Region

End Class
