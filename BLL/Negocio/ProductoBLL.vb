Imports Entidades
Imports DAL

Public Class ProductoBLL

    Dim MiUsuarioEntidad As New Entidades.Usuario
    Sub New()

    End Sub
    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub


    Dim MiProductoDAL As New ProductoDAL



    Public Function CalificarFlujoVentaUnProducto(ByVal paramProducto As Entidades.Producto) As Entidades.Producto
        Try
            Dim CDiasProdIngHastaFechAct As Integer
            Dim CDiasAltaProdHastaFechIng As Integer
            Dim ValorReferente As Double
            Dim VentasAsociadas As Integer
            Dim Puntaje As Double

            CDiasProdIngHastaFechAct = DateDiff(DateInterval.DayOfYear, paramProducto.Fecha_Arribo_Sucursal, Date.Now)
            'Ojo! Puede dar Cero! 
            CDiasAltaProdHastaFechIng = DateDiff(DateInterval.DayOfYear, paramProducto.Fecha_Alta_Sistema, paramProducto.Fecha_Arribo_Sucursal)

            If CDiasAltaProdHastaFechIng = 0 Or CDiasProdIngHastaFechAct = 0 Then
                ValorReferente = 0
            Else
                ValorReferente = CDiasProdIngHastaFechAct / CDiasAltaProdHastaFechIng
            End If




            VentasAsociadas = (New ProductoDAL).VentasAsociadasProducto(paramProducto)

            If VentasAsociadas = 0 Or ValorReferente = 0 Then
                Puntaje = 0
            Else
                Puntaje = VentasAsociadas / ValorReferente
            End If


            If Puntaje <= 299 Then
                paramProducto.FlujoVenta = 10
            End If
            If Puntaje > 300 And Puntaje <= 599 Then
                paramProducto.FlujoVenta = 15
            End If
            If Puntaje >= 600 Then
                paramProducto.FlujoVenta = 25
            End If
            Return paramProducto
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Function










    Public Overridable Function CalificarNovedadUnProducto(ByVal paramProducto As Entidades.Producto) As Entidades.Producto
        Try
            Dim MiPuntaje As Integer
            'ASIGNACIÒN DE PUNTAJE POR FECHA DE ALTA.
            If DateDiff(DateInterval.Hour, paramProducto.Fecha_Alta_Sistema, Date.Now) <= 72 Then
                MiPuntaje += 120
            ElseIf DateDiff(DateInterval.Hour, paramProducto.Fecha_Alta_Sistema, Date.Now) > 72 AndAlso DateDiff(DateInterval.Hour, paramProducto.Fecha_Alta_Sistema, Date.Now) <= 96 Then
                MiPuntaje += 100
            ElseIf DateDiff(DateInterval.Hour, paramProducto.Fecha_Alta_Sistema, Date.Now) > 96 AndAlso DateDiff(DateInterval.Hour, paramProducto.Fecha_Alta_Sistema, Date.Now) <= 120 Then
                MiPuntaje += 80
            ElseIf DateDiff(DateInterval.Hour, paramProducto.Fecha_Alta_Sistema, Date.Now) > 120 Then
                MiPuntaje += 50
            End If
            'FIN ASIGNACIÓN DE PUTNAJE POR FECHA DE ALTA.

            'Asignaciòn de puntaje por tipo de producto
            If paramProducto.TipoProducto.Descripcion = "Cosplay" Then
                MiPuntaje += 100
            ElseIf paramProducto.TipoProducto.Descripcion = "Comics" Then
                MiPuntaje += 90
            ElseIf paramProducto.TipoProducto.Descripcion = "Figuras" Then
                MiPuntaje += 70
            ElseIf paramProducto.TipoProducto.Descripcion = "Merchandising" Then
                MiPuntaje += 50
            End If
            'Fin Asignaciòn de puntaje por tipo de producto

            'Asignación de puntaje por fecha de arribo
            If DateDiff(DateInterval.Hour, paramProducto.Fecha_Arribo_Sucursal, Date.Now) < 48 Then
                MiPuntaje += 100
            ElseIf DateDiff(DateInterval.Hour, paramProducto.Fecha_Arribo_Sucursal, Date.Now) >= 48 AndAlso DateDiff(DateInterval.Hour, paramProducto.Fecha_Arribo_Sucursal, Date.Now) <= 72 Then
                MiPuntaje += 75
            ElseIf DateDiff(DateInterval.Hour, paramProducto.Fecha_Arribo_Sucursal, Date.Now) > 72 Then
                MiPuntaje += 50
            End If
            'Fin Asignación de puntaje por fecha de arribo

            'Asignación de puntaje Producto Importado
            If paramProducto.Importado = True Then
                MiPuntaje += 100
            Else
                MiPuntaje += 0
            End If


            'Asigncación de Calificación
            If MiPuntaje >= 0 AndAlso MiPuntaje <= 219 Then
                paramProducto.Novedad = 0
            ElseIf MiPuntaje >= 220 AndAlso MiPuntaje <= 270 Then
                paramProducto.Novedad = 15
            ElseIf MiPuntaje >= 271 AndAlso MiPuntaje <= 349 Then
                paramProducto.Novedad = 25
            ElseIf MiPuntaje >= 350 Then
                paramProducto.Novedad = 35
            End If
            'Fin Asigncación de Calificación

            Return paramProducto
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Function


    Public Overridable Function ListarProductos() As List(Of Entidades.Producto)
        Try
            Return (New ProductoDAL).ListarProductos
            'BitacoraBLL.GuardarBitacora("Se listaron todos los productos de la base de datos", BitacoraEntidad.TipoBitacora.Consulta, SesionBLL.Current.Usuario.NombreUsu)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Function

    Public Function ListarUnProducto(ByVal paramID As Integer) As Entidades.Producto
        Try
            Return (New ProductoDAL).ListarUnProducto(paramID)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Function

#Region "ABM"
    Public Overridable Sub Guardar(ByVal paramProducto As Entidades.Producto)
        Try
            Dim MiProductoDAL As New ProductoDAL
            paramProducto.Fecha_Alta_Sistema = Date.Now
            paramProducto.BL = False
            MiProductoDAL.NuevoProducto(paramProducto)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, MiUsuarioEntidad, 255))

        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub

    Public Overridable Sub Modificar(ByVal paramProducto As Entidades.Producto)
        Try
            Dim MiProductoDAL As New ProductoDAL
            MiProductoDAL.ModificarProducto(paramProducto)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, MiUsuarioEntidad, 256))

        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub

    Public Overridable Sub Baja(ByVal paramProducto As Entidades.Producto)
        Try
            Dim MiProductoDAL As New ProductoDAL
            MiProductoDAL.BajaProducto(paramProducto)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub
#End Region





End Class
