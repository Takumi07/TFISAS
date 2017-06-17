Public Class AgregarProducto
    Inherits System.Web.UI.Page
    Protected mensajeConfirmacion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'ACA PONER EL MENSAJE DE EXTENSIÓN CORRECTO!!!!!
            mensajeConfirmacion = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 9)
            If Not IsPostBack Then
                Me.CargarGeneros()
                Me.CargarTiposProductos()
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

    Protected Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            Response.Redirect("index.aspx")
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
            If IsDate(txt_FechaSalida.Text) = False Or IsDate(txt_FechaArribo.Text) = False Then
                Throw New BLL.camposIncorrectosException
            End If
            Dim MiProductoEntidad As New Entidades.Producto
            Dim MiProductoBLL As New BLL.ProductoBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
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
            MiProductoBLL.Guardar(MiProductoEntidad)
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
End Class