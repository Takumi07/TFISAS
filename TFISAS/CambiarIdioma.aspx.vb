Public Class CambiarIdioma
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'No hay usuario a quien cambiarle la contraseña
            If IsNothing(DirectCast(Session("Usuario"), Entidades.Usuario)) Then
                Response.Redirect("Index.aspx")
            End If
            If Not IsPostBack Then
                Me.CargarIdiomas()
                Me.txt_Idioma.Text = DirectCast(Session("Usuario"), Entidades.Usuario).Idioma.Nombre
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try


    End Sub



    Private Sub CargarIdiomas()
        Try
            Me.ddl_Idioma.DataSource = (New BLL.IdiomaBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ListarIdiomas)
            Me.ddl_Idioma.DataTextField = "Nombre"
            Me.ddl_Idioma.DataValueField = "ID"
            Me.ddl_Idioma.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub



    Private Function CargarIdioma() As Entidades.Idioma
        Try
            Return (New BLL.IdiomaBLL(Session("Usuario"))).Cargar(New Entidades.Idioma(ddl_Idioma.SelectedValue))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim MiUsuarioEntidad As New Entidades.Usuario
            MiUsuarioEntidad = DirectCast(Session("Usuario"), Entidades.Usuario)
            MiUsuarioEntidad.Idioma = Me.CargarIdioma
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            MiUsuarioBLL.Modificar(MiUsuarioEntidad)
            DirectCast(Session("Usuario"), Entidades.Usuario).Idioma = Me.CargarIdioma

            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 153) '153
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lbl_Error.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception
            Response.Redirect("Index.aspx", False)
        End Try



    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("index.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica

        Catch ex As Exception

        End Try
    End Sub
End Class