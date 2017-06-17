Public Class ModificarProducto
    Inherits System.Web.UI.Page
    Protected mensajeConfirmacion As String


    Private MiListaProducto As New List(Of Entidades.Producto)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'ACA PONER EL MENSAJE DE EXTENSIÓN CORRECTO!!!!!
            'mensajeConfirmacion = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 9)
            If Not IsPostBack Then
                If Session("Flag") = 2 Or Session("Flag") = 3 Then
                    Session("Flag") = Session("Flag") - 1
                ElseIf Session("Flag") = 1 Then
                    Session("ProductoAEditar") = Nothing
                Else
                    Session("Flag") = 0
                End If


                If IsNothing(Session("ProductoAEditar")) Then
                    'Si es nada, la tengo que seleccionar
                    Me.Cargar()
                    Me.ListaProductos.Visible = True
                    Me.ModificarProducto.Visible = False
                    Me.CargarGridView()
                Else
                    'Tengo que modificar el Usuario
                    Me.ListaProductos.Visible = False
                    Me.ModificarProducto.Visible = True
                    Me.CargarGeneros()
                    Me.CargarTiposProductos()
                    Me.CargarDatos()
                End If
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub





    Private Sub Cargar()
        Try
            Dim MiProductoBLL As New BLL.ProductoBLL
            MiListaProducto = MiProductoBLL.ListarProductos
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub





    Private Sub CargarGridView()
        Try
            Me.gv_Productos.DataSource = MiListaProducto
            Me.gv_Productos.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub



    Private Sub CargarDatos()

        Try
            Dim MiProducto As Entidades.Producto
            MiProducto = DirectCast(Session("ProductoAEditar"), Entidades.Producto)
            Me.txt_Nombre.Text = MiProducto.Nombre
            Me.txt_descripcion.Text = MiProducto.Descripcion
            Me.txt_FechaArribo.Text = MiProducto.Fecha_Arribo_Sucursal
            Me.txt_FechaSalida.Text = MiProducto.Fecha_Salida
            Me.txt_PrecioVenta.Text = MiProducto.Precio.Precio
            Me.ddl_Genero.SelectedValue = MiProducto.Genero.ID_Genero
            Me.ddl_TipoProducto.SelectedValue = MiProducto.TipoProducto.ID_TipoProducto
            Me.chk_Importado.Checked = MiProducto.Importado
            'ddl_idioma.Items.FindByText(MiUsuario.Idioma.Nombre).Selected = True
            'ddl_Perfil.Items.FindByText(MiUsuario.Permiso.Nombre).Selected = True
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            Response.Redirect("ModificarProducto.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CargarGeneros()
        Try
            Dim MiListaGeneros As New List(Of Entidades.Genero)
            MiListaGeneros = (New BLL.GeneroBLL(DirectCast(Session("Usuario"), Entidades.Usuario))).ListarGeneros

            Me.ddl_Genero.DataSource = MiListaGeneros
            Me.ddl_Genero.DataTextField = "Descripcion"
            Me.ddl_Genero.DataValueField = "ID_Genero"
            Me.ddl_Genero.DataBind()

        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub


    Private Sub CargarTiposProductos()
        Try
            Dim MiListaTipoProducto As New List(Of Entidades.TipoProducto)
            MiListaTipoProducto = (New BLL.TipoProductoBLL(DirectCast(Session("Usuario"), Entidades.Usuario))).ListarTipoProducto
            MiListaTipoProducto.Remove(MiListaTipoProducto.Find(Function(x) x.ID_TipoProducto = 1))
            Me.ddl_TipoProducto.DataSource = MiListaTipoProducto
            Me.ddl_TipoProducto.DataTextField = "Descripcion"
            Me.ddl_TipoProducto.DataValueField = "ID_TipoProducto"
            Me.ddl_TipoProducto.DataBind()

        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)

            If IsDate(txt_FechaArribo.Text) = False Or IsDate(txt_FechaSalida.Text) = False Then
                Throw New BLL.camposIncorrectosException
            End If

            Dim MiProductoEntidad As New Entidades.Producto
            Dim MiProductoBLL As New BLL.ProductoBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            MiProductoEntidad = MiProductoBLL.ListarUnProducto(DirectCast(Session("ProductoAEditar"), Entidades.Producto).ID)
            MiProductoEntidad.Nombre = Validaciones.CompararString(Me.txt_Nombre.Text)
            MiProductoEntidad.Descripcion = Validaciones.CompararString(Me.txt_descripcion.Text)
            MiProductoEntidad.Fecha_Arribo_Sucursal = Validaciones.CompararDatetime(Me.txt_FechaArribo.Text)
            MiProductoEntidad.Fecha_Salida = Validaciones.CompararDatetime(Me.txt_FechaSalida.Text)
            MiProductoEntidad.Importado = Validaciones.CompararBoolean(Me.chk_Importado.Checked)
            MiProductoEntidad.Precio = New Entidades.Precio(Validaciones.CompararDecimal(Me.txt_PrecioVenta.Text), DateTime.Now)
            MiProductoEntidad.TipoProducto = Me.CargarTipoProducto
            MiProductoEntidad.Genero = Me.CargarGenero
            MiProductoEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto))
            MiProductoEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto2))
            MiProductoEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto3))
            MiProductoEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto4))
            MiProductoBLL.Modificar(MiProductoEntidad)
            'Mostrar el mensaje correcto
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 33) '33
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.camposIncorrectosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub



    Private Function CargarGenero() As Entidades.Genero
        Try
            Return (New BLL.GeneroBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ObtenerGenero(CInt(ddl_Genero.SelectedValue)))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Function


    Private Function CargarTipoProducto() As Entidades.TipoProducto
        Try
            Return (New BLL.TipoProductoBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ObtenerTipoProducto(CInt(ddl_TipoProducto.SelectedValue)))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function

    Protected Sub btn_Editar_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim Context As HttpContext = HttpContext.Current
            Dim MiProductoBLL As New BLL.ProductoBLL

            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            If Not IsNothing(Session("ProductoAEditar")) Then
                Session("ProductoAEditar") = Nothing
            End If
            Session("ProductoAEditar") = MiProductoBLL.ListarUnProducto(CInt(e.CommandArgument))
            'Y se vino la negrada (Ver si lo puedo hacer de otra forma)
            Session("Flag") = 3
            'Aca mando a la misma página pero con parámetros
            Response.Redirect("ModificarProducto.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Message
        End Try
    End Sub

    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Productos.SetPageIndex(ddl.SelectedIndex)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gv_Productos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Cargar()
            Me.gv_Productos.DataSource = MiListaProducto
            gv_Productos.PageIndex = e.NewPageIndex
            gv_Productos.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_Productos_DataBound(sender As Object, e As EventArgs) Handles gv_Productos.DataBound
        Try
            Dim ddl As DropDownList = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

            For cnt As Integer = 0 To gv_Productos.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Productos.PageIndex Then
                    item.Selected = True
                End If
                ddl.Items.Add(item)
            Next cnt
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub
End Class