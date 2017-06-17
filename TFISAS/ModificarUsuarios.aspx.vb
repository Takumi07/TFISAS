Public Class ModificarUsuarios
    Inherits System.Web.UI.Page
    Private MiListaUsuarios As New List(Of Entidades.Usuario)
    Protected mensajeConfirmacion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'ACA PONER EL MENSAJE DE EXTENSIÓN CORRECTO!!!!!
            'mensajeConfirmacion = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 9)
            If Not IsPostBack Then
                If Session("Flag") <> 1 Then
                    Session("UsuarioAEditar") = Nothing
                    Session("Flag") = 0
                Else
                    Session("Flag") = 0
                End If


                If IsNothing(Session("UsuarioAEditar")) Then
                    'Si es nada, la tengo que seleccionar
                    Me.Cargar()
                    Me.ListaUsuarios.Visible = True
                    Me.modificarusuario.Visible = False
                    Me.CargarGridView()
                Else
                    'Tengo que modificar el Usuario
                    Me.ListaUsuarios.Visible = False
                    Me.modificarusuario.Visible = True
                    Me.CargarIdiomas()
                    Me.CargarPermisos()
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



    Private Sub CargarDatos()

        Try
            Dim MiUsuario As Entidades.Usuario
            MiUsuario = DirectCast(Session("UsuarioAEditar"), Entidades.Usuario)
            Me.txt_NombreUsuario.Text = MiUsuario.NombreUsuario
            Me.txt_correo.Text = MiUsuario.Correo
            Me.txt_apellido.Text = MiUsuario.Apellido
            Me.txt_nombre.Text = MiUsuario.Nombre
            Me.txt_dni.Text = MiUsuario.DNI
            ddl_idioma.Items.FindByText(MiUsuario.Idioma.Nombre).Selected = True
            ddl_Perfil.Items.FindByText(MiUsuario.Permiso.Nombre).Selected = True
            Me.chk_editarse.Checked = MiUsuario.Editable
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarPermisos()
        Try
            Dim MisPermisos As New List(Of Entidades.PermisoCompuesto)
            MisPermisos = (New BLL.PermisosBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ListarFamilias())

            Me.ddl_Perfil.DataSource = MisPermisos
            Me.ddl_Perfil.DataTextField = "Nombre"
            Me.ddl_Perfil.DataValueField = "ID"
            Me.ddl_Perfil.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub


    Private Sub CargarIdiomas()
        Try
            Me.ddl_idioma.DataSource = (New BLL.IdiomaBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ListarIdiomas)
            Me.ddl_idioma.DataTextField = "Nombre"
            Me.ddl_idioma.DataValueField = "ID"
            Me.ddl_idioma.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_Usuarios_DataBound(sender As Object, e As EventArgs) Handles gv_Usuarios.DataBound
        Try

            For Each row As GridViewRow In gv_Usuarios.Rows

                If Validaciones.CompararInteger(row.Cells(0).Text) = Validaciones.CompararInteger(DirectCast(Session("Usuario"), Entidades.Usuario).ID) Then
                    If CBool(row.Cells(4).Text) = True Then
                        row.Cells(4).Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 49) '49
                    Else
                        row.Cells(4).Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 50) '50
                    End If

                    Dim imagen As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Bloquear"), System.Web.UI.WebControls.ImageButton)
                    imagen.Visible = False
                    Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_desBloqueo"), System.Web.UI.WebControls.ImageButton)
                    imagen2.Visible = False
                    Dim imagenModificar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_editar"), System.Web.UI.WebControls.ImageButton)
                    imagenModificar.Visible = False
                Else
                    If Not row.Cells(4).Text = "" Then
                        If CBool(row.Cells(4).Text) = True Then
                            row.Cells(4).Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 49) '49
                            Dim imagen As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Bloquear"), System.Web.UI.WebControls.ImageButton)
                            imagen.Visible = False
                            Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_desBloqueo"), System.Web.UI.WebControls.ImageButton)
                            imagen2.Visible = True
                        Else
                            row.Cells(4).Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 50) '50
                            Dim imagen As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_desBloqueo"), System.Web.UI.WebControls.ImageButton)
                            imagen.Visible = False
                            Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Bloquear"), System.Web.UI.WebControls.ImageButton)
                            imagen2.Visible = True
                        End If
                    End If



                    If Not row.Cells(5).Text = "" Then
                        If CBool(row.Cells(5).Text) = False Then
                            Dim imagenModificar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_editar"), System.Web.UI.WebControls.ImageButton)
                            imagenModificar.Visible = False
                        End If
                    End If
                End If



                gv_Usuarios.Columns(5).Visible = False

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

    Protected Sub btn_desbloqueo_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            Dim MiUsuarioEntidad As New Entidades.Usuario
            MiUsuarioEntidad = MiUsuarioBLL.ListarUsuario(CInt(sender.CommandArgument))
            MiUsuarioEntidad.Bloqueado = False
            MiUsuarioBLL.Modificar(MiUsuarioEntidad)
            Response.Redirect("ModificarUsuarios.aspx", False)
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

    Protected Sub btn_Bloquear_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            Dim MiUsuarioEntidad As New Entidades.Usuario
            MiUsuarioEntidad = MiUsuarioBLL.ListarUsuario(CInt(sender.CommandArgument))
            MiUsuarioEntidad.Bloqueado = True
            MiUsuarioBLL.modificar(MiUsuarioEntidad)
            Response.Redirect("ModificarUsuarios.aspx", False)
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

    Protected Sub btn_editar_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim Context As HttpContext = HttpContext.Current
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            If Not IsNothing(Session("UsuarioAEditar")) Then
                Session("UsuarioAEditar") = Nothing
            End If
            Session("UsuarioAEditar") = MiUsuarioBLL.ListarUsuario(CInt(e.CommandArgument))
            'Y se vino la negrada (Ver si lo puedo hacer de otra forma)
            Session("Flag") = 1


            'Aca mando a la misma página pero con parámetros
            Response.Redirect("ModificarUsuarios.aspx", False)
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

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Try
            'Me.FilePhoto = Nothing
            Session("UsuarioAEditar") = Nothing
            Response.Redirect("ModificarUsuarios.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Private Function CargarPermiso() As Entidades.PermisoCompuesto
        Try
            Return (New BLL.PermisosBLL(Session("Usuario"))).ListarFamilias(CInt(ddl_Perfil.SelectedValue))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function

    Private Function CargarIdioma() As Entidades.Idioma
        Try
            Return (New BLL.IdiomaBLL(Session("Usuario"))).Cargar(New Entidades.Idioma(ddl_idioma.SelectedValue))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Try
            If ddl_Perfil.SelectedValue = 0 Then
                'Me seleccionó el perfil eliminado para una persona y no lo dejo pasar.
                Throw New BLL.SelPerfilEliminado
            Else
                Validaciones.validarSubmit(Me, divError, lblMensajeError)
                Dim MiUsuarioBLL As New BLL.UsuarioBLL
                Dim MiUsuarioEntidad As New Entidades.Usuario
                MiUsuarioEntidad = MiUsuarioBLL.ListarUsuario(DirectCast(Session("UsuarioAEditar"), Entidades.Usuario).ID)
                MiUsuarioEntidad.Correo = txt_correo.Text
                MiUsuarioEntidad.Permiso = Me.CargarPermiso
                MiUsuarioEntidad.Idioma = Me.CargarIdioma
                MiUsuarioEntidad.Editable = chk_editarse.Checked
                MiUsuarioEntidad.DNI = Me.txt_dni.Text
                MiUsuarioEntidad.Nombre = Me.txt_nombre.Text
                MiUsuarioEntidad.Apellido = Me.txt_apellido.Text

                MiUsuarioBLL.Modificar(MiUsuarioEntidad)
                Session.Remove("UsuarioAEditar")
                'MANDAR MENSAJE DE TODO CORRECTO OK
                Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 59) '59
                'Cambiar a administrar Perfil
                Session("Redirect") = "ModificarUsuarios.aspx"
                Response.Redirect("Mensajes.aspx", False)
            End If

        Catch ex As BLL.SelPerfilEliminado
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
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