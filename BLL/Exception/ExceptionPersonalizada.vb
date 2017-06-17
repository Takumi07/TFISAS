
Imports Entidades


Public MustInherit Class ExceptionPersonalizada
    Inherits Exception
    Public MustOverride Function Mensaje(ByVal Optional paramUsuario As Entidades.Usuario = Nothing) As String
End Class


Public Class ExcepcionGenerica
    Inherits ExceptionPersonalizada
    Public Overrides Function Mensaje(ByVal Optional paramUsuario As Entidades.Usuario = Nothing) As String
        Try
            '109
            If IsNothing(paramUsuario) Then
                Return "Se ha producido un error al realizar la acción. Intente Nuevamente o contacte con el administrador."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 109)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Se ha producido un error al realizar la acción. Intente Nuevamente o contacte con el administrador."
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class


#Region "Validaciones Genericas"
Public Class CamposincompletosException
    Inherits ExceptionPersonalizada
    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '110
            If IsNothing(paramUsuario) Then
                Return "Los campos del formulario se encuentran incompletos o en un formato incorrecto. Intente nuevamente."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 110)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Los campos del formulario se encuentran incompletos o en un formato incorrecto. Intente nuevamente."
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class



Public Class camposIncorrectosException
    Inherits ExceptionPersonalizada



    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '111
            If IsNothing(paramUsuario) Then
                Return "Los campos ingresados estan incompletos o en un formato incorrecto. Intente nuevamente."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 111)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Los campos ingresados estan incompletos o en un formato incorrecto. Intente nuevamente."
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class



Public Class SelPerfilEliminado
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '149
            If IsNothing(paramUsuario) Then
                Return "Usted no puede asignarle a un usuario el Perfil Eliminado"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 149)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Usted no puede asignarle a un usuario el Perfil Eliminado"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
#End Region


#Region "Validaciones de Usuario"
Public Class usuarioBloqueadoException
    Inherits ExceptionPersonalizada


    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '112
            If IsNothing(paramUsuario) Then
                Return "El Usuario se Encuentra Bloqueado"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 112)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "El Usuario se Encuentra Bloqueado"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

Public Class usuarioInexistenteException
    Inherits ExceptionPersonalizada
    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '113
            If IsNothing(paramUsuario) Then
                Return "El Usuario es inexistente"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 113)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "El Usuario es inexistente"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class


Public Class passwordIncorrectoException
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '114
            If IsNothing(paramUsuario) Then
                Return "La password es incorrecta"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 114)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "La password es incorrecta"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class



Public Class NombreUsuarioUtilizado
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '115
            If IsNothing(paramUsuario) Then
                Return "El nombre de usuario ya se encuentra en uso"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 115)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "El nombre de usuario ya se encuentra en uso"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class



Public Class NoCoincidePasswordException
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '116
            If IsNothing(paramUsuario) Then
                Return "La password ingresadas no coinciden entre si."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 116)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "La password ingresadas no coinciden entre si."
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

Public Class PasswordCortaException
    Inherits ExceptionPersonalizada


    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '117
            If IsNothing(paramUsuario) Then
                Return "La password debe contener al menos 6 caracteres"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 117)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "La password debe contener al menos 6 caracteres"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class


Public Class UsuarioBajaException
    Inherits ExceptionPersonalizada


    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            'Esto ocurre cuando no se puede loguear porque esta dado de baja, osea que no hay nada que traducir
            Return "El usuario se encuentra dado de baja. Por favor regístrese nuevamente o contáctese con nosotros."

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class


Public Class PerfilEliminadoException
    Inherits ExceptionPersonalizada


    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            'Esto ocurre cuando no se puede loguear porque esta dado de baja, osea que no hay nada que traducir
            Return "Su perfil fue eliminado del sistema. Por favor póngase en contacto con el administrador."

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
#End Region



#Region "Validaciones de Idioma"
Public Class IdiomaDuplicadoException
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '118
            If IsNothing(paramUsuario) Then
                Return "Ya se ha registrado un Idioma con ese Nombre. Cambielo e intente nuevamente."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 118)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Ya se ha registrado un Idioma con ese Nombre. Cambielo e intente nuevamente."
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
#End Region


#Region "Validaciones de Backup Restore"
Public Class ExcepcionArchivoBD
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '119
            If IsNothing(paramUsuario) Then
                Return "El archivo que esta ingresando no cumple con el formato establecido."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 119)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "El archivo que esta ingresando no cumple con el formato establecido."
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class


Public Class FormatoBackuIncorrectoException

    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '120
            If IsNothing(paramUsuario) Then
                Return "El formato del archivo es incorrecto"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 120)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "El formato del archivo es incorrecto"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class


Public Class ArchivoBackupIncorrecto

    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '159
            If IsNothing(paramUsuario) Then
                Return "El archivo que desea restaurar es incorrecto"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 159)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "El archivo que desea restaurar es incorrecto"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class


Public Class NombreBackupDuplicado

    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '159
            If IsNothing(paramUsuario) Then
                Return "Ya existe un backup con el nombre ingresado."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 160)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Ya existe un backup con el nombre ingresado."
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class


#End Region



#Region "Validacion de BD"

Public Class ErrorConexion
    Inherits ExceptionPersonalizada
    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '121
            If IsNothing(paramUsuario) Then
                Return "La base de datos no se encuentra disponible"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 121)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "La base de datos no se encuentra disponible"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
#End Region



#Region "Validación Permisos"
Public Class PermisoDuplicadoException
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '122
            If IsNothing(paramUsuario) Then
                Return "Ya se ha registrado un Permiso con ese Nombre. Cambielo e intente nuevamente."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 122)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Ya se ha registrado un Permiso con ese Nombre. Cambielo e intente nuevamente."
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class




Public Class IngresarunPermisoException
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '123
            If IsNothing(paramUsuario) Then
                Return "Debe ingresar al menos un permiso para dar de alta al Perfil."
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 123)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Debe ingresar al menos un permiso para dar de alta al Perfil."
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

#End Region


#Region "Integridad BD"

Public Class IntegridadCorrupta
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '124
            If IsNothing(paramUsuario) Then
                Return "La integridad de la base de datos es corrupta"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 124)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "La integridad de la base de datos es corrupta"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
#End Region


#Region "Inventario"
Public Class NroRemitoDuplicado
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '247
            If IsNothing(paramUsuario) Then
                Return "El remito ya se encuentra cargado para el proveedor"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 247)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "El remito ya se encuentra cargado para el proveedor"
        Catch ex As Exception
            Return "El remito ya se encuentra cargado para el proveedor"
        End Try
    End Function
End Class
#End Region


#Region "Fecha"

Public Class FechaIncrorecta
    Inherits ExceptionPersonalizada

    Public Overrides Function Mensaje(Optional paramUsuario As Usuario = Nothing) As String
        Try
            '248
            If IsNothing(paramUsuario) Then
                Return "Fecha en formato incorrecto"
            Else
                Return BLL.IdiomaBLL.traducirMensaje(paramUsuario.Idioma, 248)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Return "Fecha en formato incorrecto"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
#End Region