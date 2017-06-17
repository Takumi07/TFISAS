Public Class ClienteDAL

    Public Function EvaluarHistorialTProducto(ByVal paramClienteEntidad As Entidades.Cliente, paramFecha As Date) As Entidades.TipoProducto
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Cliente", paramClienteEntidad.ID)
            MisParametros.Add("@Fecha", paramFecha)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("EvaluarTipoProducto", MisParametros)
            If MiDataTable.Rows.Count > 0 Then
                Return DAL.TipoProductoDAL.ObtenerTipoProducto(MiDataTable.Rows(0).Item("ID_TipoProducto"))
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function EvaluarHistorialGenero(ByVal paramClienteEntidad As Entidades.Cliente, paramfecha As Date) As Entidades.Genero
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Cliente", paramClienteEntidad.ID)
            MisParametros.Add("@Fecha", paramfecha)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("EvaluarGenero", MisParametros)
            If MiDataTable.Rows.Count > 0 Then
                Return DAL.GeneroDAL.ObtenerGenero(MiDataTable.Rows(0).Item("ID_Genero"))
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function


    Public Function CantidadDeComprasPorGenero(ByVal paramGenero As Entidades.Genero, ByVal paramClienteEntidad As Entidades.Cliente) As Integer
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Cliente", paramClienteEntidad.ID)
            MisParametros.Add("@ID_Genero", paramGenero.ID_Genero)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ComprasPorGenero", MisParametros)
            If MiDataTable.Rows.Count > 0 Then
                Return MiDataTable.Rows(0).Item("Cantidad")
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function CantidadDeComprasporTProducto(ByVal paramTProducto As Entidades.TipoProducto, ByVal paramClienteEntidad As Entidades.Cliente) As Integer
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Cliente", paramClienteEntidad.ID)
            MisParametros.Add("@ID_TipoProducto", paramTProducto.ID_TipoProducto)
            Dim MiDataTable As DataTable
            MiDataTable = Conexion.Leer("ComprasPorTipoProducto", MisParametros)
            If MiDataTable.Rows.Count > 0 Then
                Return MiDataTable.Rows(0).Item("Cantidad")
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function




    Public Sub NuevoCliente(ByVal paramClienteEntidad As Entidades.Cliente)
        Try
            Dim MiDireccionDAL As New DAL.DireccionDAL
            MiDireccionDAL.Alta(paramClienteEntidad.Direccion)
            Dim MisParametros As New Hashtable
            paramClienteEntidad.ID_Cliente = Conexion.ObtenerID("Cliente", "ID_Cliente")
            MisParametros.Add("@ID_Cliente", paramClienteEntidad.ID_Cliente)
            MisParametros.Add("@ID_Usuario", paramClienteEntidad.ID)
            MisParametros.Add("@ID_Direccion", paramClienteEntidad.Direccion.ID)
            MisParametros.Add("@Fecha_Nacimiento", paramClienteEntidad.FechaNacimiento)
            MisParametros.Add("@Telefono", paramClienteEntidad.Telefono)
            MisParametros.Add("@BL", paramClienteEntidad.BL)
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(paramClienteEntidad.DVHC))
            DAL.Conexion.ExecuteNonQuery("AltaCliente", MisParametros)
            DVDAL.CalcularDVV("Cliente")
        Catch ex As Exception

        End Try
    End Sub


    Public Sub EliminarCliente(ByVal paramClienteEntidad As Entidades.Cliente)

    End Sub


    Public Sub ModificarCliente(ByVal paramClienteEntidad As Entidades.Cliente)
    End Sub





    Public Function LoginCliente(ByVal paramUsuario As Entidades.Usuario) As Entidades.Cliente
        Try
            Dim misParametros As New Hashtable
            Dim MiCliente As New Entidades.Cliente
            Dim miDataTable As New DataTable
            misParametros.Add("@ID_Usuario", paramUsuario.ID)
            miDataTable = Conexion.Leer("ListarUnCliente", misParametros)
            If miDataTable.Rows.Count > 0 Then
                FormatearClienteConUsuario(paramUsuario, MiCliente)
                FormatearClientes(miDataTable.Rows(0), MiCliente)
                Return MiCliente
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function





    Private Sub FormatearClientes(ByVal paramRow As DataRow, ByVal paramClienteEntidad As Entidades.Cliente)
        paramClienteEntidad.ID_Cliente = Validacion.CompararInteger(paramRow.Item("ID_Cliente"))
        paramClienteEntidad.Direccion = (New DAL.DireccionDAL).ObtenerDireccion(paramRow.Item("ID_Direccion"))
        paramClienteEntidad.FechaNacimiento = Validacion.CompararDatetime(paramRow.Item("Fecha_Nacimiento"))
        paramClienteEntidad.Telefono = Validacion.CompararInteger(paramRow.Item("Telefono"))
        paramClienteEntidad.BL = paramRow.Item("BL")
    End Sub

    Private Sub FormatearClienteConUsuario(ByVal paramUsuario As Entidades.Usuario, ByVal paramClienteEntidad As Entidades.Cliente)
        paramClienteEntidad.ID = paramUsuario.ID
        paramClienteEntidad.NombreUsuario = paramUsuario.NombreUsuario
        paramClienteEntidad.Password = paramUsuario.Password
        paramClienteEntidad.Idioma = paramUsuario.Idioma
        paramClienteEntidad.Permiso = paramUsuario.Permiso
        paramClienteEntidad.Nombre = paramUsuario.Nombre
        paramClienteEntidad.Apellido = paramUsuario.Apellido
        paramClienteEntidad.DNI = paramUsuario.DNI
        paramClienteEntidad.FechaAlta = paramUsuario.FechaAlta
        paramClienteEntidad.Intentos = paramUsuario.Intentos
        paramClienteEntidad.Bloqueado = paramUsuario.Bloqueado
        paramClienteEntidad.Editable = paramUsuario.Editable
        paramClienteEntidad.Correo = paramUsuario.Correo
        paramClienteEntidad.BL = paramUsuario.BL
        paramClienteEntidad.ImagenUsuario = paramUsuario.ImagenUsuario
    End Sub


End Class
