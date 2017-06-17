Public Class IdiomaBLL
    Dim MiIdiomaDAL As New DAL.IdiomaDAL
    Dim MiUsuarioEntidad As New Entidades.Usuario

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub



#Region "ABM"
    Public Sub altaIdioma(ByVal paramIdioma As Entidades.Idioma)
        Try
            paramIdioma.Editable = True
            paramIdioma.BL = False
            MiIdiomaDAL.altaIdioma(paramIdioma)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, MiUsuarioEntidad, 100))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Sub modificarIdioma(ByVal paramIdioma As Entidades.Idioma)
        Try
            MiIdiomaDAL.modificarIdioma(paramIdioma)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, MiUsuarioEntidad, 101))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub


    Public Sub bajaIdioma(ByVal paramIdioma As Entidades.Idioma)
        Try
            paramIdioma.BL = True
            MiIdiomaDAL.bajaIdioma(paramIdioma)
            'Pongo el idioma default a los usuarios que estaban usando el idioma que se da de baja
            Me.ActualizarIdiomasDeUsuarios(paramIdioma.ID)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Baja, MiUsuarioEntidad, 102))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

#End Region




#Region "Agregado - Baja de Idioma"
    Public Sub ActualizarIdiomasDeUsuarios(ByVal paramIDIdioma As Integer)
        Try
            Dim MiUsuarioBLL As New UsuarioBLL
            MiUsuarioBLL.ActualizarIdiomasDeUsuarios(paramIDIdioma)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub
#End Region



    ''' <summary>Devuelve un idioma completo. Idioma + Palabras</summary>
    Public Function Cargar(ByVal paramIdiomaEntidad As Entidades.Idioma) As Entidades.Idioma
        Try
            Return MiIdiomaDAL.Cargar(paramIdiomaEntidad)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function





#Region "AgregadoParaCargarPorPagina"
    ''' <summary> Devuelve las palabras de ESA página + la master, el idioma esta inclompleto, las traducciones no.</summary>
    Public Function Cargar(ByVal paramIdiomaEntidad As Entidades.Idioma, ByVal paramPage As String) As Entidades.Idioma
        Try
            Return MiIdiomaDAL.Cargar(paramIdiomaEntidad, paramPage)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
#End Region




    Public Function ListarIdiomas() As List(Of Entidades.Idioma)
        Try
            Return MiIdiomaDAL.listarIdiomas()
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function

    Public Shared Function traducirMensaje(ByVal paramIdioma As Entidades.Idioma, ByVal paramIDControl As Integer) As String
        Try
            'No esta logeado, no se el idioma
            If IsNothing(paramIdioma) Then
                paramIdioma = New Entidades.Idioma(1)
            End If
            Return DAL.IdiomaDAL.traducirMensaje(paramIdioma, paramIDControl)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function chequearNombreIdioma(ByVal paramIdioma As Entidades.Idioma) As Boolean
        Try
            Return MiIdiomaDAL.chequearNombreIdioma(paramIdioma)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(MiUsuarioEntidad, ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
End Class
