Imports Entidades
Imports DAL

Public Class MangaBLL
    Inherits ProductoBLL

    Dim MiUsuarioEntidad As New Entidades.Usuario
    Sub New()

    End Sub
    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub

    Dim MiMangaDAL As New MangaDAL



#Region "ABM"
    Public Overrides Sub Guardar(ByVal paramProducto As Entidades.Producto)
        Try
            MyBase.Guardar(paramProducto)
            Dim MiMangaDAL As New MangaDAL
            MiMangaDAL.NuevoProducto(paramProducto)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, MiUsuarioEntidad, 253))
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Modificar(ByVal paramProducto As Entidades.Producto)
        Try
            MyBase.Modificar(paramProducto)
            Dim MiMangaDAL As New MangaDAL
            MiMangaDAL.ModificarProducto(paramProducto)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, MiUsuarioEntidad, 254))
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Baja(ByVal paramProducto As Entidades.Producto)
        'Try
        '    'Es lo ùnico que va a hacer en baja porque solo la TABLA producto contiene el campo de BL.
        '    MyBase.Baja(paramProducto)
        'Catch ex As ExepcionModificarProducto
        '    Throw New ExepcionElimiarManga
        'Catch ex As Exception
        '    BitacoraBLL.GuardarBitacora("El Metodo" & ex.TargetSite.ToString & "genero el Mensaje " & ex.Message, BitacoraEntidad.TipoBitacora.Errores, SesionBLL.Current.Usuario.NombreUsu)
        '    Throw New ExepcionElimiarManga
        'End Try
    End Sub
#End Region


    Public Function ListarProductosManga() As List(Of Entidades.Manga)
        Try
            'Hacer este mètodo sino no hay nada que listar
            Return (New MangaDAL).ListarProductosManga

        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


    Public Function ObtenerUnManga(ByVal paramID As Integer) As Entidades.Manga
        Try
            Return (New DAL.MangaDAL).ObtenerUnManga(paramID)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function

    Public Overloads Function CalificarNovedadUnProducto(ByVal paramManga As Entidades.Manga) As Entidades.Manga
        Try
            Dim MiPuntaje As Integer
            'ASIGNACIÒN DE PUNTAJE POR FECHA DE ALTA.

            Dim int As Integer
            int = DateDiff(DateInterval.Hour, paramManga.Fecha_Alta_Sistema, Date.Now)
            If DateDiff(DateInterval.Hour, paramManga.Fecha_Alta_Sistema, Date.Now) <= 72 Then
                MiPuntaje = +120
            ElseIf DateDiff(DateInterval.Hour, paramManga.Fecha_Alta_Sistema, Date.Now) > 72 AndAlso DateDiff(DateInterval.Hour, paramManga.Fecha_Alta_Sistema, Date.Now) <= 96 Then
                MiPuntaje = +100
            ElseIf DateDiff(DateInterval.Hour, paramManga.Fecha_Alta_Sistema, Date.Now) > 96 AndAlso DateDiff(DateInterval.Hour, paramManga.Fecha_Alta_Sistema, Date.Now) <= 120 Then
                MiPuntaje = +80
            ElseIf DateDiff(DateInterval.Hour, paramManga.Fecha_Alta_Sistema, Date.Now) > 120 Then
                MiPuntaje = +50
            End If
            'FIN ASIGNACIÓN DE PUTNAJE POR FECHA DE ALTA.

            'Asignaciòn de puntaje por tipo de producto
            'Es constante, porque ya estoy adentro de manga. En producto pregunto por cada uno.
            MiPuntaje += 150
            'Fin Asignaciòn de puntaje por tipo de producto

            'Asignación de puntaje por fecha de arribo
            If DateDiff(DateInterval.Hour, paramManga.Fecha_Arribo_Sucursal, Date.Now) < 48 Then
                MiPuntaje += 100
            ElseIf DateDiff(DateInterval.Hour, paramManga.Fecha_Arribo_Sucursal, Date.Now) >= 48 AndAlso DateDiff(DateInterval.Hour, paramManga.Fecha_Arribo_Sucursal, Date.Now) <= 72 Then
                MiPuntaje += 75
            ElseIf DateDiff(DateInterval.Hour, paramManga.Fecha_Arribo_Sucursal, Date.Now) > 72 Then
                MiPuntaje += 50
            End If
            'Fin Asignación de puntaje por fecha de arribo


            'ACA ESTA LA MAGIA!!!!!!
            'ASIGNACIÒN ESPECIAL PARA MANGA!

            If DateDiff(DateInterval.DayOfYear, paramManga.Fec_Salida_PTomo, Date.Now) < 4 Then
                MiPuntaje += 130
            ElseIf DateDiff(DateInterval.DayOfYear, paramManga.Fec_Salida_PTomo, Date.Now) >= 4 AndAlso DateDiff(DateInterval.DayOfYear, paramManga.Fec_Salida_PTomo, Date.Now) < 10 Then
                MiPuntaje += 80
            ElseIf DateDiff(DateInterval.DayOfYear, paramManga.Fec_Salida_PTomo, Date.Now) >= 10 Then
                MiPuntaje += 50
            End If
            'FIN ASIGNACIÓN ESPECIAL PARA MANGA

            'Asigncación de Calificación
            If MiPuntaje >= 0 AndAlso MiPuntaje <= 219 Then
                paramManga.Novedad = 0
            ElseIf MiPuntaje >= 220 AndAlso MiPuntaje <= 270 Then
                paramManga.Novedad = 15
            ElseIf MiPuntaje >= 271 AndAlso MiPuntaje <= 349 Then
                paramManga.Novedad = 25
            ElseIf MiPuntaje >= 350 Then
                paramManga.Novedad = 35
            End If
            'Fin Asigncación de Calificación
            Return paramManga
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
End Class

