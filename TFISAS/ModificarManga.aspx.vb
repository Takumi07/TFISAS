Public Class ModificarManga
    Inherits System.Web.UI.Page
    Protected mensajeConfirmacion As String


    Private MiListaManga As New List(Of Entidades.Manga)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
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
                    Me.CargarEditoriales()
                    Me.CargarDatos()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub





    Private Sub Cargar()
        Try
            Dim MiMangaBLL As New BLL.MangaBLL
            MiListaManga = MiMangaBLL.ListarProductosManga
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
            Me.gv_Productos.DataSource = MiListaManga
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
            Dim MiManga As Entidades.Manga
            MiManga = DirectCast(Session("ProductoAEditar"), Entidades.Manga)
            Me.txt_Nombre.Text = MiManga.Nombre
            Me.txt_descripcion.Text = MiManga.Descripcion
            Me.txt_FechaArribo.Text = MiManga.Fecha_Arribo_Sucursal
            Me.txt_FechaSalida.Text = MiManga.Fecha_Salida
            Me.txt_PrecioVenta.Text = MiManga.Precio.Precio.ToString("0.00")
            Me.ddl_Genero.SelectedValue = MiManga.Genero.ID_Genero
            Me.chk_Importado.Checked = MiManga.Importado
            Me.txt_FechaSalidaPTomo.Text = MiManga.Fec_Salida_PTomo
            Me.txt_nrotomo.Text = MiManga.N_Tomo
            Me.ddl_Editorial.SelectedValue = MiManga.Editorial.ID
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
            Response.Redirect("ModificarManga.aspx")
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



    Protected Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
            If IsDate(txt_FechaArribo.Text) = False Or IsDate(txt_FechaSalida.Text) = False Or IsDate(txt_FechaSalidaPTomo.Text) = False Then
                Throw New BLL.camposIncorrectosException
            End If

            Dim MiMangaEntidad As New Entidades.Manga
            Dim MiMangaBLL As New BLL.MangaBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            MiMangaEntidad = MiMangaBLL.ObtenerUnManga(DirectCast(Session("ProductoAEditar"), Entidades.Producto).ID)
            MiMangaEntidad.Nombre = Validaciones.CompararString(Me.txt_Nombre.Text)
            MiMangaEntidad.Descripcion = Validaciones.CompararString(Me.txt_descripcion.Text)
            MiMangaEntidad.Fecha_Arribo_Sucursal = Validaciones.CompararDatetime(Me.txt_FechaArribo.Text)
            MiMangaEntidad.Fecha_Salida = Validaciones.CompararDatetime(Me.txt_FechaSalida.Text)
            MiMangaEntidad.Importado = Validaciones.CompararBoolean(Me.chk_Importado.Checked)
            MiMangaEntidad.Precio = New Entidades.Precio(Validaciones.CompararDecimal(Me.txt_PrecioVenta.Text), DateTime.Now)
            MiMangaEntidad.Genero = Me.CargarGenero

            MiMangaEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto))
            MiMangaEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto2))
            MiMangaEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto3))
            MiMangaEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto4))

            MiMangaEntidad.Fec_Salida_PTomo = Validaciones.CompararDatetime(Me.txt_FechaSalidaPTomo.Text)
            MiMangaEntidad.N_Tomo = Validaciones.CompararInteger(Me.txt_nrotomo.Text)
            MiMangaEntidad.Editorial = Me.CargarEditorial

            MiMangaBLL.Modificar(MiMangaEntidad)
            'Mostrar el mensaje correcto
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 203) '33
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

    Private Sub CargarEditoriales()
        Try
            Dim MiListaEditoriales As New List(Of Entidades.Editorial)
            MiListaEditoriales = (New BLL.EditorialBLL(DirectCast(Session("Usuario"), Entidades.Usuario))).ListarEditoriales
            Me.ddl_Editorial.DataSource = MiListaEditoriales
            Me.ddl_Editorial.DataTextField = "Nombre"
            Me.ddl_Editorial.DataValueField = "ID"
            Me.ddl_Editorial.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Private Function CargarEditorial() As Entidades.Editorial
        Try
            Return (New BLL.EditorialBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ListarUnaEditorial(CInt(ddl_Editorial.SelectedValue)))
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
            Return (New BLL.TipoProductoBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ObtenerTipoProducto(CInt(1)))
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
            Dim MiMangaBLL As New BLL.MangaBLL
            If Not IsNothing(Session("ProductoAEditar")) Then
                Session("ProductoAEditar") = Nothing
            End If
            Session("ProductoAEditar") = MiMangaBLL.ObtenerUnManga(CInt(e.CommandArgument))
            'Y se vino la negrada (Ver si lo puedo hacer de otra forma)
            Session("Flag") = 3
            'Aca mando a la misma página pero con parámetros
            Response.Redirect("ModificarManga.aspx", False)
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
            Me.gv_Productos.DataSource = MiListaManga
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