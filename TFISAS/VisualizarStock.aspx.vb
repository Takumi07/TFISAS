Public Class VisualizarStock
    Inherits System.Web.UI.Page
    Dim MiListaProductos As New List(Of Entidades.Producto)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
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
            MiListaProductos = (New BLL.ProductoBLL).ListarTodosProductosStock

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
            Me.gv_Productos.DataSource = MiListaProductos
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


    Protected Sub btn_Volver_Click(sender As Object, e As EventArgs) Handles btn_Volver.Click
        Response.Redirect("Index.aspx", False)
    End Sub

    Protected Sub gv_Productos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Me.cargarGridView()
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

        Dim ddl As DropDownList = CType(gv_Productos.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

        For cnt As Integer = 0 To gv_Productos.PageCount - 1
            Dim curr As Integer = cnt + 1
            Dim item As New ListItem(curr.ToString())
            If cnt = gv_Productos.PageIndex Then
                item.Selected = True
            End If

            ddl.Items.Add(item)

        Next cnt

    End Sub
End Class