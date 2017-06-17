Public Class EliminarUsuario
    Inherits System.Web.UI.Page
    Private MiListaUsuarios As New List(Of Entidades.Usuario)
    Protected mensajeConfirmacion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            mensajeConfirmacion = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 47) '47
            Me.Cargar()
            If Not IsPostBack Then
                Me.CargarGridView()
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

    Protected Sub btn_Eliminar_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            Dim MiUsuarioEntidad As New Entidades.Usuario
            MiUsuarioEntidad = MiUsuarioBLL.ListarUsuario(CInt(sender.CommandArgument))

            MiUsuarioBLL.Baja(MiUsuarioEntidad)
            'MANDAR MENSAJE DE TODO CORRECTO OK
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 48) '48
            'Cambiar a administrar Perfil
            Session("Redirect") = "EliminarUsuario.aspx"
            Response.Redirect("Mensajes.aspx", False)
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


    Private Sub gv_Usuarios_DataBound(sender As Object, e As EventArgs) Handles gv_Usuarios.DataBound
        Try

            For Each row As GridViewRow In gv_Usuarios.Rows
                If Not row.Cells(5).Text = "" Then
                    If CBool(row.Cells(5).Text) = False Or DirectCast(Session("Usuario"), Entidades.Usuario).ID = Validaciones.CompararInteger(row.Cells(0).Text) Then
                        Dim imagenEliminar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Eliminar"), System.Web.UI.WebControls.ImageButton)
                        imagenEliminar.Visible = False
                    End If
                End If
                gv_Usuarios.Columns(5).Visible = False


                If Not row.Cells(4).Text = "" Then
                    If CBool(row.Cells(4).Text) = True Then
                        row.Cells(4).Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 49) '49
                    Else
                        row.Cells(4).Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 50) '50
                    End If
                End If

            Next
            Dim ddl As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

            For cnt As Integer = 0 To gv_Usuarios.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Usuarios.PageIndex Then
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



    Protected Sub gv_Usuarios_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Cargar()
            Me.gv_Usuarios.DataSource = MiListaUsuarios
            gv_Usuarios.PageIndex = e.NewPageIndex
            gv_Usuarios.DataBind()

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
            Dim ddl As DropDownList = CType(gv_Usuarios.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Usuarios.SetPageIndex(ddl.SelectedIndex)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarGridView()
        Try
            Me.gv_Usuarios.DataSource = MiListaUsuarios
            Me.gv_Usuarios.DataBind()
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
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            MiListaUsuarios = MiUsuarioBLL.ListarNoBaja
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