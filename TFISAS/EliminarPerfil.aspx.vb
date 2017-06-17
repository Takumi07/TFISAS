Public Class EliminarPefil
    Inherits System.Web.UI.Page


    'Private _MigestorPermiso As New BLL.PermisosBLL(Session("Usuario"))
    Private _Milistapermisos As List(Of Entidades.PermisoBase)
    Protected mensajeConfirmacion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Aca poner el mensaje Traducido
            mensajeConfirmacion = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 39) '39

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

    Private Sub CargarGridView()
        Try
            Me.gv_Perfiles.DataSource = _Milistapermisos
            Me.gv_Perfiles.DataBind()
            'Me.gv_Perfiles.Columns(0).Visible = False
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
            Dim _MigestorPermiso As New BLL.PermisosBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            _Milistapermisos = _MigestorPermiso.ListarFamilias(True)
            _Milistapermisos.Remove(_Milistapermisos.Find(Function(x) x.ID = 0))
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

    Private Sub gv_Perfiles_DataBound(sender As Object, e As EventArgs) Handles gv_Perfiles.DataBound
        Try
            For Each row As GridViewRow In gv_Perfiles.Rows
                'Aca tengo que filtrar los que no se pueden tocar como cliente y etc.
                'Filtrado Administrador y el perfil que tiene el usuario asignado
                If Validaciones.CompararInteger(row.Cells(0).Text) = 13 Or Validaciones.CompararInteger(row.Cells(0).Text) = 18 Or Validaciones.CompararInteger(row.Cells(0).Text) = DirectCast(Session("Usuario"), Entidades.Usuario).Permiso.ID Then
                    Dim imageneliminar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Eliminar"), System.Web.UI.WebControls.ImageButton)
                    imageneliminar.Visible = False
                End If
            Next


            Dim ddl As DropDownList = CType(gv_Perfiles.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)

            For cnt As Integer = 0 To gv_Perfiles.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Perfiles.PageIndex Then
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



    Protected Sub gv_Perfiles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Cargar()
            Me.gv_Perfiles.DataSource = _Milistapermisos
            gv_Perfiles.PageIndex = e.NewPageIndex
            gv_Perfiles.DataBind()
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
            Dim ddl As DropDownList = CType(gv_Perfiles.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Perfiles.SetPageIndex(ddl.SelectedIndex)
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
            Dim _MigestorPermiso As New BLL.PermisosBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            'Me tengo que traer el permiso completo por el tema de los DVH
            Dim MiPermisoCompuesto As New Entidades.PermisoCompuesto
            MiPermisoCompuesto = (New BLL.PermisosBLL(Session("Usuario"))).ListarFamilias(CInt(sender.CommandArgument))
            _MigestorPermiso.Baja(MiPermisoCompuesto)

            'MANDAR MENSAJE DE TODO CORRECTO OK
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 40) '40
            'Cambiar a administrar Perfil
            Session("Redirect") = "EliminarPerfil.aspx"
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

End Class