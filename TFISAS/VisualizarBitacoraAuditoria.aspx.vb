Imports System.Globalization
Imports System.Threading

Public Class VisualizarBitacoraAuditoria
    Inherits System.Web.UI.Page
    Dim MiBitacoraBLL As New BLL.BitacoraBLL
    Private MiListaBitacoraAuditoria As New List(Of Entidades.BitacoraAuditoria)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNothing(Session("BitacoraA")) Then
                Me.cargar()
                If Not IsPostBack Then
                    Me.obtenerTipoOperacion()
                    Me.obtenerUsuarios()
                    Me.cargarGridView()

                    Session("UsuarioBitacora") = Nothing
                    Session("FechaHasta") = Nothing
                    Session("FechaDesde") = Nothing
                    Session("OperacionBitacora") = Nothing
                End If
            Else
                Me.BitacoraA.Visible = True
                Me.lista.Visible = False

                Me.MostrarValores()
            End If



            'Creo que aca la puedo blanquear
            Session("BitacoraA") = Nothing
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
            If Not IsNothing(DirectCast(Session("UsuarioBitacora"), Entidades.Usuario)) Or Not IsNothing(Session("FechaHasta")) Or Not IsNothing(Session("FechaDesde")) Or Not IsNothing(Session("OperacionBitacora")) Then
                MiListaBitacoraAuditoria = MiBitacoraBLL.ListarBitacoraAuditoria(DirectCast(Session("UsuarioBitacora"), Entidades.Usuario), Session("FechaDesde"), Session("FechaHasta"), Session("OperacionBitacora"))
            Else
                MiListaBitacoraAuditoria = MiBitacoraBLL.ListarBitacoraAuditoria
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

    Private Sub cargarGridView()
        Try
            'Para probar, sacar
            Me.gv_BitacoraAuditoria.DataSource = MiListaBitacoraAuditoria
            Me.gv_BitacoraAuditoria.DataBind()
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
            Dim MiBitacoraAuditoria As New Entidades.BitacoraAuditoria
            MiBitacoraAuditoria = DirectCast(Session("BitacoraA"), Entidades.BitacoraAuditoria)

            txt_ID.Text = MiBitacoraAuditoria.ID
            txt_usuario.Text = MiBitacoraAuditoria.Usuario.NombreUsuario
            txt_tipooperacion.Text = [Enum].GetName(GetType(Entidades.BitacoraBase.tipoOperacionBitacora), MiBitacoraAuditoria.TipoOperacion)
            txt_fechahora.Text = MiBitacoraAuditoria.FechaHora
            txt_ip.Text = MiBitacoraAuditoria.IP
            txt_webbrowser.Text = MiBitacoraAuditoria.Webbrowser
            txt_descripcion.Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, Validaciones.CompararInteger(MiBitacoraAuditoria.ID_Descripcion))  'Aca ver como me traigo del idioma lo que le corresponde
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gv_BitacoraAuditoria_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Me.cargarGridView()
            gv_BitacoraAuditoria.PageIndex = e.NewPageIndex
            gv_BitacoraAuditoria.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub obtenerTipoOperacion()
        Try
            Me.ddl_operacion.DataSource = System.Enum.GetValues(GetType(Entidades.BitacoraBase.tipoOperacionBitacora))
            Me.ddl_operacion.DataBind()
            Me.ddl_operacion.Items.Insert(0, "Todos")
            Me.ddl_operacion.Items.RemoveAt(10)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub



    Private Sub obtenerUsuarios()
        Try
            Dim MiUsuarioBLL As New BLL.UsuarioBLL
            Me.ddl_usuario.DataSource = MiUsuarioBLL.ListarTodosUsuarioLazyFiltroAuditoria
            Me.ddl_usuario.DataTextField = "NombreUsuario"
            Me.ddl_usuario.DataValueField = "ID"
            Me.ddl_usuario.DataBind()
            Me.ddl_usuario.Items.Insert(0, "Todos")
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
            Dim ddl As DropDownList = CType(gv_BitacoraAuditoria.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_BitacoraAuditoria.SetPageIndex(ddl.SelectedIndex)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub




    Private Sub gv_BitacoraErrores_DataBound(sender As Object, e As EventArgs) Handles gv_BitacoraAuditoria.DataBound
        Try
            Dim ddl As DropDownList = CType(gv_BitacoraAuditoria.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            For cnt As Integer = 0 To gv_BitacoraAuditoria.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_BitacoraAuditoria.PageIndex Then
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
            For Each MiBitacoraAuditoria As Entidades.BitacoraAuditoria In MiListaBitacoraAuditoria
                If MiBitacoraAuditoria.ID = e.CommandArgument Then
                    Session("BitacoraA") = MiBitacoraAuditoria
                    Exit For
                End If
            Next

            Response.Redirect("VisualizarBitacoraAuditoria.aspx")
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
            Session("BitacoraA") = Nothing
            Response.Redirect("VisualizarBitacoraAuditoria.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub


    Public Function validarFecha() As Boolean
        Try
            Dim FechaDesde As Date
            Dim fechaHasta As Date

            If Me.txt_FechaDesde.Text = "" And txt_FechaHasta.Text = "" Then
                Return True
            Else
                If Me.txt_FechaDesde.Text = "" And txt_FechaHasta.Text <> "" Then
                    Return False
                Else

                    If Me.txt_FechaDesde.Text <> "" And txt_FechaHasta.Text = "" Then
                        Return False
                    Else

                        FechaDesde = CDate(txt_FechaDesde.Text)
                        fechaHasta = CDate(txt_FechaHasta.Text)
                        If DateTime.Compare(FechaDesde, fechaHasta) < 0 Then
                            Return True
                        ElseIf DateTime.Compare(FechaDesde, fechaHasta) = 0 Then
                            Return True
                        ElseIf DateTime.Compare(FechaDesde, fechaHasta) > 0 Then
                            Return False
                        End If

                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Function




    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Me.divError.Visible = False
            If validarFecha() = True Then

                Dim _usuario As Entidades.Usuario = Nothing
                Dim UsuarioBLL As New BLL.UsuarioBLL
                Dim BitacoraBLL As New BLL.BitacoraBLL
                Dim _fechaDesde As Date
                Dim _fechaHasta As Date
                Dim _operacion As Integer = 0
                If Not ddl_usuario.SelectedIndex = 0 Then
                    _usuario = New Entidades.Usuario
                    _usuario.ID = Me.ddl_usuario.SelectedValue
                    _usuario = UsuarioBLL.ListarUsuario(Me.ddl_usuario.SelectedValue)
                    Session("UsuarioBitacora") = _usuario
                Else
                    Session("UsuarioBitacora") = Nothing
                End If
                If Not ddl_operacion.SelectedIndex = 0 Then
                    _operacion = ddl_operacion.SelectedIndex
                    Session("OperacionBitacora") = _operacion
                End If
                If Not txt_FechaDesde.Text = "" Then
                    _fechaDesde = CDate(txt_FechaDesde.Text)
                    Session("FechaDesde") = _fechaDesde
                Else
                    _fechaDesde = New Date(1, 1, 1)
                    Session("FechaDesde") = _fechaDesde
                End If
                If Not txt_FechaHasta.Text = "" Then
                    _fechaHasta = CDate(txt_FechaHasta.Text)
                    Session("FechaHasta") = _fechaHasta
                Else
                    _fechaHasta = New Date(1, 1, 1)
                    Session("FechaHasta") = _fechaHasta
                End If

                MiListaBitacoraAuditoria = BitacoraBLL.ListarBitacoraAuditoria(_usuario, _fechaDesde, _fechaHasta, _operacion)
                Me.cargarGridView()
                gv_BitacoraAuditoria.PageIndex = 0
                Dim ddl As DropDownList = CType(gv_BitacoraAuditoria.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
                ddl.SelectedIndex = 0
            Else
                Throw New BLL.camposIncorrectosException
            End If
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
End Class