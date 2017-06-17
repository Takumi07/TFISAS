Public Class ModificarPerfil
    Inherits System.Web.UI.Page

    Private _Milistapermisos As List(Of Entidades.PermisoBase)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Si esto tiene una familia, es porque seleccione una y no la termine de editar
                If TypeOf (Session("FamiliaaEditar")) Is Entidades.PermisoBase Then
                    Session("FamiliaaEditar") = Nothing
                End If


                If IsNothing(Session("FamiliaaEditar")) Then
                    'Si es nada, la tengo que seleccionar
                    Me.Cargar()
                    Me.listaperfiles.Visible = True
                    Me.modificarperfiles.Visible = False
                    Me.CargarGridView()
                Else
                    Me.cargarTodos()
                    Me.CargarTreeView()

                    'Tengo que modificar el perfil
                    Me.listaperfiles.Visible = False
                    Me.modificarperfiles.Visible = True

                    Dim _idPermiso As Integer = CInt(Session("FamiliaaEditar"))
                    Dim _permisoaEditar As Entidades.PermisoCompuesto = obtenerPermisos(_idPermiso)
                    Me.cargarPermiso(_permisoaEditar)
                    Session("FamiliaaEditar") = _permisoaEditar
                End If
            Else
                Me.cargarTodos()
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


    Private Sub Cargar()
        Try
            Dim _MigestorPermiso As New BLL.PermisosBLL(Session("Usuario"))
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

    Public Sub cargarTodos()
        Try
            Dim _MigestorPermiso As New BLL.PermisosBLL(Session("Usuario"))
            _Milistapermisos = _MigestorPermiso.ListarFamilias(False)
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


    Protected Sub Editar_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim Context As HttpContext = HttpContext.Current

            If Not IsNothing(Session("FamiliaaEditar")) Then
                Session("FamiliaaEditar") = Nothing
            End If
            Session("FamiliaaEditar") = CInt(e.CommandArgument)

            'Aca mando a la misma página pero con parámetros
            Response.Redirect("ModificarPerfil.aspx", False)
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



    Private Sub gv_Perfiles_DataBound(sender As Object, e As EventArgs) Handles gv_Perfiles.DataBound
        Try
            For Each row As GridViewRow In gv_Perfiles.Rows
                'ACA VAN LAS VALIDACIONES DE LOS PERFILES QUE NO QUIERO QUE ME EDITEN!!!
                'ADMINISTRADOR, CLIENTE
                If Validaciones.CompararInteger(row.Cells(0).Text) = 13 Or Validaciones.CompararInteger(row.Cells(0).Text) = 18 Or Validaciones.CompararInteger(row.Cells(0).Text) = DirectCast(Session("Usuario"), Entidades.Usuario).Permiso.ID Then 'Valido el administrador
                    Dim imagenEditar As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Editar"), System.Web.UI.WebControls.ImageButton)
                    imagenEditar.Visible = False
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

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            If validarListaPermisos() = True Then
                Dim _MigestorPermiso As New BLL.PermisosBLL(Session("Usuario"))
                Dim _entidadPermiso As New Entidades.PermisoCompuesto
                _entidadPermiso.Nombre = txt_nombre.Text
                For Each _nodo As TreeNode In treeviewPermisos.CheckedNodes
                    Dim _per As Entidades.PermisoBase = _Milistapermisos.Item(retornarIndice(_Milistapermisos, _nodo.Text))
                    If revisarLista(_per, _entidadPermiso.ListaPermisosSimple) = True Then
                        _entidadPermiso.ListaPermisosSimple.Add(_per)
                    End If
                Next
                _entidadPermiso.ID = DirectCast(Session("FamiliaaEditar"), Entidades.PermisoCompuesto).ID
                _MigestorPermiso.Modificar(_entidadPermiso)
                Session.Remove("FamiliaaEditar")

                'MANDAR MENSAJE DE TODO CORRECTO OK
                Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 56) '56
                'Cambiar a administrar Perfil
                Session("Redirect") = "ModificarPerfil.aspx"
                Response.Redirect("Mensajes.aspx", False)

            Else
                Throw New BLL.IngresarunPermisoException
            End If

        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.IngresarunPermisoException
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

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Try
            Session.Remove("FamiliaaEditar")
            Response.Redirect("modificarPerfil.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub


    Private Function validarListaPermisos() As Boolean
        Try
            Dim flagNodo As Boolean = False
            For Each _node As TreeNode In Me.treeviewPermisos.Nodes
                If _node.Checked = True Then
                    flagNodo = True
                End If
            Next
            If flagNodo = False Then
                Return False
            Else
                Return True
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function


    Public Shared Function retornarIndice(ByVal _listapermisos As List(Of Entidades.PermisoBase), ByVal _nombre As String) As Integer
        Try
            For Each _per As Entidades.PermisoBase In _listapermisos
                If _per.Nombre = _nombre Then
                    Return _listapermisos.IndexOf(_per)
                End If
            Next
            Return 0
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function revisarLista(ByVal _per As Entidades.PermisoBase, _listaper As List(Of Entidades.PermisoBase)) As Boolean
        Try
            If _listaper.Contains(_per) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Private Function obtenerPermisos(ByVal idPermiso As Integer) As Entidades.PermisoCompuesto
        Try
            Dim _MigestorPermiso As New BLL.PermisosBLL(Session("Usuario"))
            Return _MigestorPermiso.ListarFamilias(idPermiso)

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
    End Function

    Public Sub cargarPermiso(ByVal paramPermiso As Entidades.PermisoCompuesto)
        Try
            chequearTreeView(paramPermiso, Me.treeviewPermisos)
            Me.txt_nombre.Text = paramPermiso.Nombre
            Me.txt_nombre.Enabled = True

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
    Public Shared Sub chequearTreeView(ByVal _permiso As Entidades.PermisoCompuesto, ByRef _tree As TreeView)
        Try
            For Each _node As TreeNode In _tree.Nodes
                If _node.Text = _permiso.Nombre Then
                    _node.Checked = True
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CargarTreeView()
        Try
            armarTreeView(_Milistapermisos, Me.treeviewPermisos)
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

    Public Shared Sub armarTreeView(ByVal _listapermisos As List(Of Entidades.PermisoBase), ByRef _tree As TreeView)
        Try
            For Each _per As Entidades.PermisoBase In _listapermisos
                _tree.Nodes.Add(New TreeNode(_per.Nombre))
                _tree.Nodes(_tree.Nodes.Count - 1).ShowCheckBox = True
                If _per.tieneHijos = True Then
                    agregarNodoHijo(_per, _tree.Nodes(_tree.Nodes.Count - 1))
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub agregarNodoHijo(ByVal _listaCompuesto As Entidades.PermisoCompuesto, ByRef _treenodo As TreeNode)
        Try
            For Each _per As Entidades.PermisoBase In _listaCompuesto.ListaPermisosSimple
                _treenodo.ChildNodes.Add(New TreeNode(_per.Nombre))
                If Not _per.URL = Nothing And _listaCompuesto.URL <> Nothing Then
                    _treenodo.ChildNodes(_treenodo.ChildNodes.Count - 1).ShowCheckBox = True
                End If
                If _per.tieneHijos = True Then
                    agregarNodoHijo(_per, _treenodo.ChildNodes(_treenodo.ChildNodes.Count - 1))
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class