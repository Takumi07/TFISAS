Public Class UsuarioDAL



#Region "ABM"
    Public Sub Alta(ByVal paramusuarioentidad As Entidades.Usuario)
        Try
            Dim MisParametros As New Hashtable
            paramusuarioentidad.ID = Conexion.ObtenerID("Usuario", "ID_Usuario")
            MisParametros.Add("@ID_Usuario", paramusuarioentidad.ID)
            MisParametros.Add("@NombreUsuario", paramusuarioentidad.NombreUsuario)
            MisParametros.Add("@Password", paramusuarioentidad.Password)
            MisParametros.Add("@ID_Patente", paramusuarioentidad.Permiso.ID)
            MisParametros.Add("@ID_Idioma", paramusuarioentidad.Idioma.ID)
            MisParametros.Add("@Nombre", paramusuarioentidad.Nombre)
            MisParametros.Add("@Apellido", paramusuarioentidad.Apellido)
            MisParametros.Add("@DNI", Convert.ToInt32(paramusuarioentidad.DNI))
            MisParametros.Add("@Bloqueado", paramusuarioentidad.Bloqueado)
            MisParametros.Add("@editable", paramusuarioentidad.Editable)
            MisParametros.Add("@Intentos", paramusuarioentidad.Intentos)
            MisParametros.Add("@FechaAlta", paramusuarioentidad.FechaAlta)
            MisParametros.Add("@Correo", paramusuarioentidad.Correo)
            MisParametros.Add("@ImagenUsuario", paramusuarioentidad.ImagenUsuario)
            MisParametros.Add("@BL", paramusuarioentidad.BL)
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(paramusuarioentidad.DVH))
            DAL.Conexion.ExecuteNonQuery("AltaUsuario", MisParametros)
            DVDAL.CalcularDVV("Usuario")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ModificarUsuario(ByVal paramUsuarioEntidad As Entidades.Usuario)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Usuario", paramUsuarioEntidad.ID)
            MisParametros.Add("@Password", paramUsuarioEntidad.Password)
            MisParametros.Add("@ID_Patente", paramUsuarioEntidad.Permiso.ID)
            MisParametros.Add("@ID_Idioma", paramUsuarioEntidad.Idioma.ID)
            MisParametros.Add("@Nombre", paramUsuarioEntidad.Nombre)
            MisParametros.Add("@Apellido", paramUsuarioEntidad.Apellido)
            MisParametros.Add("@DNI", Convert.ToInt32(paramUsuarioEntidad.DNI))
            MisParametros.Add("@Bloqueado", paramUsuarioEntidad.Bloqueado)
            MisParametros.Add("@editable", paramUsuarioEntidad.Editable)
            MisParametros.Add("@Intentos", paramUsuarioEntidad.Intentos)
            MisParametros.Add("@Correo", paramUsuarioEntidad.Correo)
            MisParametros.Add("@ImagenUsuario", paramUsuarioEntidad.ImagenUsuario)
            MisParametros.Add("@BL", paramUsuarioEntidad.BL)
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(paramUsuarioEntidad.DVH))
            Dim a As String
            a = paramUsuarioEntidad.DVH
            DAL.Conexion.ExecuteNonQuery("ModificarUsuario", MisParametros)
            DVDAL.CalcularDVV("Usuario")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


#End Region


#Region "Listar - Seleccionar"

    Public Function ListarUsuariosIdioma(ByVal paramIDIdioma As Integer) As List(Of Entidades.Usuario)
        Dim MiListaUsuarioEntidad As New List(Of Entidades.Usuario)
        Dim MisParametros As New Hashtable
        MisParametros.Add("@ID_Idioma", paramIDIdioma)
        Dim miDataTable As DataTable = Conexion.Leer("ListarUsuariosBIdioma", MisParametros)
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiUsuarioEntidad As New Entidades.Usuario
            formatearUsuario(miDataRow, MiUsuarioEntidad)
            MiListaUsuarioEntidad.Add(MiUsuarioEntidad)
        Next
        Return MiListaUsuarioEntidad
    End Function


    Public Function ListarUsuariosPermiso(ByVal paramPermiso As Integer) As List(Of Entidades.Usuario)
        Dim MiListaUsuarioEntidad As New List(Of Entidades.Usuario)
        Dim MisParametros As New Hashtable
        MisParametros.Add("@ID_Patente", paramPermiso)
        Dim miDataTable As DataTable = Conexion.Leer("ListarUsuariosBPermisos", MisParametros)
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiUsuarioEntidad As New Entidades.Usuario
            formatearUsuario(miDataRow, MiUsuarioEntidad)
            MiListaUsuarioEntidad.Add(MiUsuarioEntidad)
        Next
        Return MiListaUsuarioEntidad
    End Function


    Public Function chequearUsuario(ByVal paramUsuario As Entidades.Usuario) As Entidades.Usuario
        Dim misParametros As New Hashtable
        Dim miUsuario As New Entidades.Usuario
        Dim miDataTable As New DataTable
        misParametros.Add("@NombreUsuario", paramUsuario.NombreUsuario)
        miDataTable = Conexion.Leer("Usuario_ChequearUsuario", misParametros)
        If miDataTable.Rows.Count > 0 Then
            formatearUsuario(miDataTable.Rows(0), miUsuario)
            Return miUsuario
        Else
            Return Nothing
        End If
    End Function

    Public Function verificarSiExisteUsuario(ByVal paramNombreUsuario As String) As Boolean
        Try
            Dim misParametros As New Hashtable
            Dim miDataTable As New DataTable
            misParametros.Add("@NombreUsuario", paramNombreUsuario)
            miDataTable = Conexion.Leer("Usuario_ChequearUsuario", misParametros)
            If miDataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function ListarUsuarioPorID(ByVal paramID As Integer) As Entidades.Usuario
        Try
            Dim misParametros As New Hashtable
            Dim miUsuario As New Entidades.Usuario
            Dim miDataTable As New DataTable
            misParametros.Add("@ID_Usuario", paramID)
            miDataTable = Conexion.Leer("ListarUsuarioPorID", misParametros)
            If miDataTable.Rows.Count > 0 Then
                formatearUsuario(miDataTable.Rows(0), miUsuario)
                Return miUsuario
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function




    ''' <summary>Trae todos los usuarios, incluyendo los dados de baja. </summary>
    Public Function ListarTodos() As List(Of Entidades.Usuario)
        Dim MiListaUsuarioEntidad As New List(Of Entidades.Usuario)
        Dim miDataTable As DataTable = Conexion.Leer("ListarUsuariosTodos")
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiUsuarioEntidad As New Entidades.Usuario
            formatearUsuario(miDataRow, MiUsuarioEntidad)
            MiListaUsuarioEntidad.Add(MiUsuarioEntidad)
        Next
        Return MiListaUsuarioEntidad
    End Function

    ''' <summary>Trae Todos los usuarios, menos los dado de baja</summary>
    Public Function ListarNoBaja() As List(Of Entidades.Usuario)
        Dim MiListaUsuarioEntidad As New List(Of Entidades.Usuario)
        Dim miDataTable As DataTable = Conexion.Leer("ListarUsuarios")
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiUsuarioEntidad As New Entidades.Usuario
            formatearUsuario(miDataRow, MiUsuarioEntidad)
            MiListaUsuarioEntidad.Add(MiUsuarioEntidad)
        Next
        Return MiListaUsuarioEntidad
    End Function

#End Region



    Public Sub formatearUsuario(paramDataRow As DataRow, paramUsuario As Entidades.Usuario)
        Try
            paramUsuario.ID = Validacion.CompararInteger(paramDataRow.Item("ID_Usuario"))
            paramUsuario.NombreUsuario = Validacion.CompararString(paramDataRow.Item("NombreUsuario"))
            paramUsuario.Password = paramDataRow.Item("Password")
            'Me traigo el idioma entidad que le corresponde a ese usuario.
            paramUsuario.Idioma = (New DAL.IdiomaDAL).Cargar(New Entidades.Idioma(Validacion.CompararInteger(paramDataRow.Item("ID_Idioma"))))
            'Me traingo el permiso entidad que le corresponde a ese usuario
            paramUsuario.Permiso = (New DAL.PermisosDAL).listarFamilias(Validacion.CompararInteger(paramDataRow.Item("ID_Patente")))


            paramUsuario.Nombre = Validacion.CompararString(paramDataRow.Item("Nombre"))
            paramUsuario.Apellido = Validacion.CompararString(paramDataRow.Item("Apellido"))
            paramUsuario.DNI = Validacion.CompararUlong(paramDataRow.Item("DNI"))




            'Valdiar aca que no pinche si es dbnull!!!!!!!!!!!
            paramUsuario.FechaAlta = IIf(IsDBNull(paramDataRow.Item("FechaAlta")), Nothing, paramDataRow.Item("FechaAlta"))
            paramUsuario.Intentos = Validacion.CompararInteger(paramDataRow.Item("Intentos"))
            paramUsuario.Bloqueado = paramDataRow.Item("Bloqueado")
            paramUsuario.Editable = paramDataRow.Item("Editable")
            paramUsuario.Correo = Validacion.CompararString(paramDataRow.Item("Correo"))
            paramUsuario.BL = paramDataRow.Item("BL")

            'Imagen Byte
            paramUsuario.ImagenUsuario = Validacion.CompararString(paramDataRow.Item("ImagenUsuario"))
        Catch ex As Exception
            Throw ex
        End Try

    End Sub





    Public Shared Function ListarUsuarioLazyAuditoriaPorID(ByVal paramID As Integer) As Entidades.Usuario
        Try
            Dim misParametros As New Hashtable
            Dim miUsuario As New Entidades.Usuario
            Dim miDataTable As New DataTable
            misParametros.Add("@ID_Usuario", paramID)
            miDataTable = Conexion.Leer("ListarUsuarioLazyAuditoriaPorID", misParametros)
            If miDataTable.Rows.Count > 0 Then
                formatearUsuarioLazyAuditoria(miDataTable.Rows(0), miUsuario)
                Return miUsuario
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function



    ''' <summary>Trae todos los usuarios, incluyendo los dados de baja, pero optimizado para auditoria. </summary>
    Public Function ListarTodosLazyAuditoria() As List(Of Entidades.Usuario)
        Dim MiListaUsuarioEntidad As New List(Of Entidades.Usuario)
        Dim miDataTable As DataTable = Conexion.Leer("ListarUsuariosTodosLazyAuditoria")
        For Each miDataRow As DataRow In miDataTable.Rows
            Dim MiUsuarioEntidad As New Entidades.Usuario
            formatearUsuarioLazyAuditoria(miDataRow, MiUsuarioEntidad)
            MiListaUsuarioEntidad.Add(MiUsuarioEntidad)
        Next
        Return MiListaUsuarioEntidad
    End Function




    Public Shared Sub formatearUsuarioLazyAuditoria(paramDataRow As DataRow, paramUsuario As Entidades.Usuario)
        Try
            paramUsuario.ID = Validacion.CompararInteger(paramDataRow.Item("ID_Usuario"))
            paramUsuario.NombreUsuario = Validacion.CompararString(paramDataRow.Item("NombreUsuario"))
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
