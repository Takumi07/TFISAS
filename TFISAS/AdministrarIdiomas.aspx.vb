Public Class ListaModificarIdioma
    Inherits System.Web.UI.Page
    'Dim MiIdiomaBLL As New BLL.IdiomaBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
    Dim MiListaIdioma As New List(Of Entidades.Idioma)
    Protected mensajeConfirmacion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            mensajeConfirmacion = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 9)
            Me.cargar()
            If Not IsPostBack Then
                Me.cargarGridView()
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
    Private Sub cargar()
        Try
            MiListaIdioma = (New BLL.IdiomaBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ListarIdiomas)

        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        End Try
    End Sub

    Private Sub cargarGridView()
        Try
            Me.gv_Idiomas.DataSource = MiListaIdioma
            Me.gv_Idiomas.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gv_Idiomas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Me.cargarGridView()
            gv_Idiomas.PageIndex = e.NewPageIndex
            gv_Idiomas.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Idiomas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Idiomas.SetPageIndex(ddl.SelectedIndex)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_Editar_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim MiIdiomaBLL As New BLL.IdiomaBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            Dim Context As HttpContext = HttpContext.Current
            If Context.Items.Contains("IdiomaaEditar") = True Then
                Context.Items.Remove("IdiomaaEditar")
            End If
            Dim _idioma As New Entidades.Idioma
            _idioma.ID = CInt(e.CommandArgument)
            Context.Items.Add("IdiomaaEditar", MiIdiomaBLL.Cargar(_idioma))
            'Aca voy a la opción que me deja modificar
            Server.Transfer("agregarIdioma.aspx")

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

    Private Sub gv_Idiomas_DataBound(sender As Object, e As EventArgs) Handles gv_Idiomas.DataBound
        Try
            For Each row As GridViewRow In gv_Idiomas.Rows
                If Not row.Cells(2).Text = "" Then
                    If CBool(row.Cells(2).Text) = False Then
                        Dim imageneliminar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Eliminar"), System.Web.UI.WebControls.ImageButton)
                        imageneliminar.Visible = False
                        Dim imagenEditar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Editar"), System.Web.UI.WebControls.ImageButton)
                        imagenEditar.Visible = False
                    End If
                End If
            Next

            gv_Idiomas.Columns(2).Visible = False

            Dim ddl As DropDownList = CType(gv_Idiomas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

            For cnt As Integer = 0 To gv_Idiomas.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Idiomas.PageIndex Then
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

    Protected Sub btn_Eliminar_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Dim MiIdiomaBLL As New BLL.IdiomaBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            Dim _idioma As New Entidades.Idioma
            _idioma.ID = CInt(sender.CommandArgument)
            _idioma = MiIdiomaBLL.Cargar(_idioma)
            'ACA TENGO QUE VER DE HACER UN PROCEDIMIENTO PARA TODAS LAS PERSONAS QUE TENGAN ESE IDIOMA DADO DE BAJA
            MiIdiomaBLL.bajaIdioma(_idioma)
            'Aca se puede poner un mensaje de todo bien si se quiere
            Response.Redirect("administrarIdiomas.aspx", False)

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
End Class