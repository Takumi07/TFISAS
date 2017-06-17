Public Class AgregarManga
    Inherits System.Web.UI.Page


    Protected mensajeConfirmacion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'ACA PONER EL MENSAJE DE EXTENSIÓN CORRECTO!!!!!
            mensajeConfirmacion = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 9)
            If Not IsPostBack Then
                Me.CargarGeneros()
                Me.CargarEditoriales()
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

    Protected Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
            If IsDate(txt_FechaSalida.Text) = False Or IsDate(txt_FechaArribo.Text) = False Or IsDate(txt_FechaSalidaPTomo.Text) = False Then
                Throw New BLL.camposIncorrectosException
            End If


            Dim MiMangaEntidad As New Entidades.Manga
            Dim MiMangaBLL As New BLL.MangaBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            MiMangaEntidad.Nombre = Validaciones.CompararString(Me.txt_Nombre.Text)
            MiMangaEntidad.Descripcion = Validaciones.CompararString(Me.txt_descripcion.Text)
            MiMangaEntidad.Fecha_Arribo_Sucursal = Validaciones.CompararDatetime(Me.txt_FechaArribo.Text)
            MiMangaEntidad.Fecha_Salida = Validaciones.CompararDatetime(Me.txt_FechaSalida.Text)
            MiMangaEntidad.Importado = Validaciones.CompararBoolean(Me.chk_Importado.Checked)
            MiMangaEntidad.Precio = New Entidades.Precio(Validaciones.CompararDecimal(Me.txt_PrecioVenta.Text), DateTime.Now)
            MiMangaEntidad.TipoProducto = (New Entidades.TipoProducto(1))
            MiMangaEntidad.Genero = Me.CargarGenero

            MiMangaEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto))
            MiMangaEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto2))
            MiMangaEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto3))
            MiMangaEntidad.ListaImagenes.Add(Validaciones.ConvertirBase64(Me.FilePhoto4))

            MiMangaEntidad.Fec_Salida_PTomo = Validaciones.CompararDatetime(Me.txt_FechaSalidaPTomo.Text)
            MiMangaEntidad.N_Tomo = Validaciones.CompararInteger(Me.txt_nrotomo.Text)
            MiMangaEntidad.Editorial = Me.CargarEditorial

            MiMangaBLL.Guardar(MiMangaEntidad)
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

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    'Page.ClientScript.RegisterStartupScript(Me.GetType, "MyKey", "readURL('" & Me.FilePhoto & "');", True)
    'End Sub
End Class