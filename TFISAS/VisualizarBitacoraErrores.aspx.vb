Public Class VisualizarBitacoraErrores
    Inherits System.Web.UI.Page


    Dim MiBitacoraBLL As New BLL.BitacoraBLL
    Private MiListaBitacoraErrores As New List(Of Entidades.BitacoraErrores)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNothing(Session("BitacoraE")) Then
                Me.cargar()
                If Not IsPostBack Then
                    Me.cargarGridView()
                End If
            Else
                Me.bitacorae.Visible = True
                Me.lista.Visible = False

                Me.MostrarValores()
            End If

            'Creo que aca la puedo blanquear
            Session("BitacoraE") = Nothing
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
            MiListaBitacoraErrores = MiBitacoraBLL.ListarBitacoraErrores
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarGridView()
        Try
            'Para probar, sacar
            Me.gv_BitacoraErrores.DataSource = MiListaBitacoraErrores
            Me.gv_BitacoraErrores.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MostrarValores()
        Try
            Dim MiBitacoraErrores As New Entidades.BitacoraErrores
            MiBitacoraErrores = DirectCast(Session("BitacoraE"), Entidades.BitacoraErrores)

            txt_ID.Text = MiBitacoraErrores.ID
            txt_usuario.Text = MiBitacoraErrores.Usuario.NombreUsuario
            txt_tipooperacion.Text = [Enum].GetName(GetType(Entidades.BitacoraBase.tipoOperacionBitacora), MiBitacoraErrores.TipoOperacion)
            txt_fechahora.Text = MiBitacoraErrores.FechaHora
            txt_ip.Text = MiBitacoraErrores.IP
            txt_webbrowser.Text = MiBitacoraErrores.Webbrowser
            txt_stactrace.Text = MiBitacoraErrores.StackTrace
            txt_mensaje.Text = MiBitacoraErrores.Mensaje
            txt_tipoExepcion.Text = MiBitacoraErrores.TipoException
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gv_BitacoraErrores_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Me.cargarGridView()
            gv_BitacoraErrores.PageIndex = e.NewPageIndex
            gv_BitacoraErrores.DataBind()
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
            Dim ddl As DropDownList = CType(gv_BitacoraErrores.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_BitacoraErrores.SetPageIndex(ddl.SelectedIndex)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub




    Private Sub gv_BitacoraErrores_DataBound(sender As Object, e As EventArgs) Handles gv_BitacoraErrores.DataBound
        Try
            Dim ddl As DropDownList = CType(gv_BitacoraErrores.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            For cnt As Integer = 0 To gv_BitacoraErrores.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_BitacoraErrores.PageIndex Then
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

    Protected Sub btn_seleccionar_Command(sender As Object, e As CommandEventArgs)
        Try
            For Each mibitacoraerror As Entidades.BitacoraErrores In MiListaBitacoraErrores
                If mibitacoraerror.ID = e.CommandArgument Then
                    Session("BitacoraE") = mibitacoraerror
                    Exit For
                End If
            Next

            Response.Redirect("VisualizarBitacoraErrores.aspx")
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
        Try
            Session("BitacoraE") = Nothing
            Response.Redirect("VisualizarBitacoraErrores.aspx")
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