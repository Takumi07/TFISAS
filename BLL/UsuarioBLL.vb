

Public Class UsuarioBLL
    Dim miUsuarioDAL As New DAL.UsuarioDAL

    Public Function Login(ByVal nombreUsuario As String, ByVal Password As String, ByVal paramWebbrowser As String, ByVal paramIP As String) As Entidades.Usuario
        Try

            Dim miUsuarioLogin As New Entidades.Usuario

            miUsuarioLogin.NombreUsuario = nombreUsuario
            miUsuarioLogin.Password = EncriptadoraBLL.EncriptarPass(Password)
            'Compruebo si el Usuario existe en la BD
            Dim miUsuarioLogueado As New Entidades.Usuario
            miUsuarioLogueado = chequearUsuario(miUsuarioLogin)



            If miUsuarioLogueado Is Nothing Then
                Throw New BLL.usuarioInexistenteException
            Else
                miUsuarioLogueado.IP = paramIP
                miUsuarioLogueado.WebBrowser = paramWebbrowser
                'Si el usuario existe en la BD entonces compruebo que no este dado de baja

                If chequearBaja(miUsuarioLogueado) = True Then
                    Throw New BLL.UsuarioBajaException
                Else
                    'Valido si el usuario tiene "Perfil Eliminado"
                    If miUsuarioLogueado.Permiso.ID = 0 Then
                        Throw New BLL.PerfilEliminadoException
                    Else

                        'Si el usuario existe en la BD entonces compruebo si la password es la correcta
                        If comprobarPassword(miUsuarioLogin, miUsuarioLogueado) Then
                            'Si el usuario existe en la BD y la contraseña es correcta compruebo si o esta bloqueado. Limpio UsuarioLogin
                            miUsuarioLogin = Nothing
                            If Me.comprobarBloqueado(miUsuarioLogueado) = True Then
                                Throw New BLL.usuarioBloqueadoException
                            Else
                                'Si esta todo correcto vuelvo los intentos a 0
                                Me.resetearIntentos(miUsuarioLogueado)
                                BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Login, miUsuarioLogueado, 99))
                                Return miUsuarioLogueado
                            End If
                        Else
                            'Si ingreso el password mal le sumo un intento
                            Me.actualizarIntentos(miUsuarioLogueado)
                            Throw New BLL.passwordIncorrectoException
                        End If

                    End If
                End If
            End If

        Catch ex As BLL.PerfilEliminadoException
            Throw ex
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
        Catch ex As BLL.UsuarioBajaException
            Throw ex
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
        Catch ex As BLL.usuarioInexistenteException
            Throw ex
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
        Catch ex As BLL.usuarioBloqueadoException
            Throw ex
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
        Catch ex As BLL.passwordIncorrectoException
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function





    Public Function verificarSiExisteUsuario(ByVal paramNombreUsuario As String) As Boolean
        Try
            Return miUsuarioDAL.verificarSiExisteUsuario(paramNombreUsuario)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function


    Public Function chequearBaja(ByVal paramUsuario As Entidades.Usuario) As Boolean
        Try
            Return paramUsuario.BL
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function




    Public Function chequearUsuario(ByVal paramUsuario As Entidades.Usuario) As Entidades.Usuario
        Try
            Return miUsuarioDAL.chequearUsuario(paramUsuario)
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function

    Public Function comprobarPassword(ByVal paramUsuario1 As Entidades.Usuario, ByVal paramUsuario2 As Entidades.Usuario) As Boolean
        Try
            If paramUsuario1.Password = paramUsuario2.Password Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Function

    Public Function comprobarBloqueado(ByVal paramUsuario As Entidades.Usuario) As Boolean
        Try
            If paramUsuario.Bloqueado = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function

    Public Sub bloquearUsuario(ByVal paramUsuario As Entidades.Usuario)
        Try
            paramUsuario.Bloqueado = True
            miUsuarioDAL.ModificarUsuario(paramUsuario)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Bloqueo, paramUsuario, 97))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Sub desbloquearUsuario(ByVal paramUsuario As Entidades.Usuario)
        Try
            paramUsuario.Bloqueado = False
            miUsuarioDAL.ModificarUsuario(paramUsuario)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Desbloqueo, paramUsuario, 96))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Sub actualizarIntentos(ByVal paramUsuario As Entidades.Usuario)
        Try
            paramUsuario.Intentos += 1
            If paramUsuario.Intentos >= 3 Then
                Me.bloquearUsuario(paramUsuario)
            End If
            miUsuarioDAL.ModificarUsuario(paramUsuario)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, paramUsuario, 95))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Sub resetearIntentos(ByVal paramUsuario As Entidades.Usuario)
        Try
            paramUsuario.Intentos = 0
            miUsuarioDAL.ModificarUsuario(paramUsuario)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, paramUsuario, 94))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Sub asignarIdioma(ByVal paramUsuario As Entidades.Usuario)
        Try
            miUsuarioDAL.ModificarUsuario(paramUsuario)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, paramUsuario, 98))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub




    Public Sub ActualizarPermisosDeUsuarios(ByVal paramIDPermiso As Integer)
        Try
            Dim MiUsuarioDAL As New DAL.UsuarioDAL

            Dim MiListaDeUsuarios As New List(Of Entidades.Usuario)
            'Me traigo todos los usuarios que tienen el permiso que estoy dando de baja
            MiListaDeUsuarios = MiUsuarioDAL.ListarUsuariosPermiso(paramIDPermiso)

            'Itero Todos los Usuarios   
            For Each MiUsuario As Entidades.Usuario In MiListaDeUsuarios
                'Les asigno el perfil "eliminado" para hacer una tratativa luego con esos usuarios
                MiUsuario.Permiso.ID = 0
                MiUsuarioDAL.ModificarUsuario(MiUsuario)
                BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, MiUsuario, 93))
            Next
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub



    Public Sub ActualizarIdiomasDeUsuarios(ByVal paramIDIdioma As Integer)
        Try
            Dim MiUsuarioDAL As New DAL.UsuarioDAL

            Dim MiListaDeUsuarios As New List(Of Entidades.Usuario)
            'Me traigo todos los usuairos que tienen el idioma que estoy dando de baja
            MiListaDeUsuarios = MiUsuarioDAL.ListarUsuariosIdioma(paramIDIdioma)

            'Itero Todos los Usuarios   
            For Each MiUsuario As Entidades.Usuario In MiListaDeUsuarios
                'Les asigno el idioma default que no se puede borrar 
                MiUsuario.Idioma.ID = 1
                MiUsuarioDAL.ModificarUsuario(MiUsuario)
                BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, MiUsuario, 103))
            Next
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub


#Region "Listar"

    Public Function ListarTodos() As List(Of Entidades.Usuario)
        Try
            Return (New DAL.UsuarioDAL).ListarTodos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarNoBaja() As List(Of Entidades.Usuario)
        Try
            Return (New DAL.UsuarioDAL).ListarNoBaja
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarUsuario(ByVal paramID As Integer) As Entidades.Usuario
        Try
            Return (New DAL.UsuarioDAL).ListarUsuarioPorID(paramID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ListarTodosUsuarioLazyFiltroAuditoria() As List(Of Entidades.Usuario)
        Try
            Return (New DAL.UsuarioDAL).ListarTodosLazyAuditoria
        Catch ex As Exception

        End Try
    End Function

#End Region



#Region "ABM"
    Public Sub Alta(ByVal paramUsuarioEntidad As Entidades.Usuario)
        Try
            Dim MiUsuarioDAL As New DAL.UsuarioDAL
            paramUsuarioEntidad.Bloqueado = False
            paramUsuarioEntidad.Intentos = 0
            paramUsuarioEntidad.FechaAlta = DateTime.Now
            paramUsuarioEntidad.BL = False
            MiUsuarioDAL.Alta(paramUsuarioEntidad)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, paramUsuarioEntidad, 104))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub

    Public Sub Modificar(ByVal paramUsuarioEntidad As Entidades.Usuario)
        Try
            Dim MiUsuarioDAL As New DAL.UsuarioDAL
            MiUsuarioDAL.ModificarUsuario(paramUsuarioEntidad)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Modificacion, paramUsuarioEntidad, 105))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try

    End Sub

    Public Sub Baja(ByVal paramUsuario As Entidades.Usuario)
        Try
            paramUsuario.BL = True
            miUsuarioDAL.ModificarUsuario(paramUsuario)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Baja, paramUsuario, 106))
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub
#End Region



#Region "Recuperar Contraseña"
    Public Sub RecuperarContraseña(ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim _usu As New DAL.UsuarioDAL
            Dim PassparaMail As String
            PassparaMail = BLL.EncriptadoraBLL.GenerarPassword
            paramUsuario.Password = BLL.EncriptadoraBLL.EncriptarPass(PassparaMail)
            _usu.ModificarUsuario(paramUsuario)
            Try
                MailingBLL.enviarMailRecupero(paramUsuario, PassparaMail)
            Catch ex As Exception
                Return
            End Try
            ' BLL.BitacoraBLL.Alta(BLL.SesionBLL.Current.Usuario, Entidades.Bitacora.tipoPrioridadBitacora.Alta, Entidades.Bitacora.tipoOperacionBitacora.Modificacion, "Cambio de Contraseña")
        Catch ex As Exception
            Throw New BLL.ExcepcionGenerica
        End Try
    End Sub
#End Region
End Class
