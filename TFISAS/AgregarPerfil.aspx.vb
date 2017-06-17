Public Class AgregarPerfil
    Inherits System.Web.UI.Page
    'Private MiPermisoBLL As New BLL.PermisosBLL(Session("Usuario"))

    Private MiListaPermisos As List(Of Entidades.PermisoBase)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.cargarTodos()
            If Not IsPostBack Then
                Me.CargarTreeView()

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


    Public Sub cargarTodos()
        Try
            MiListaPermisos = (New BLL.PermisosBLL(DirectCast(Session("Usuario"), Entidades.Usuario)).ListarFamilias(False))
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

    Private Function obtenerPermisos(ByVal idPermiso As Integer) As Entidades.PermisoCompuesto
        Try
            Return (New BLL.PermisosBLL(DirectCast(Session("Usuario"), Entidades.Usuario))).ListarFamilias(idPermiso)
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


    Private Sub CargarTreeView()
        Try
            armarTreeView(MiListaPermisos, Me.treeviewPermisos)
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



#Region "Armado"
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

#End Region

    Protected Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Try

            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
            If validarListaPermisos() = True Then
                Dim _entidadPermiso As New Entidades.PermisoCompuesto
                _entidadPermiso.Nombre = txt_nombre.Text
                For Each _nodo As TreeNode In treeviewPermisos.CheckedNodes
                    Dim _per As Entidades.PermisoBase = MiListaPermisos.Item(retornarIndice(MiListaPermisos, _nodo.Text))
                    If revisarLista(_per, _entidadPermiso.ListaPermisosSimple) = True Then
                        _entidadPermiso.ListaPermisosSimple.Add(_per)
                    End If
                Next
                Dim MiPermisoBLL As New BLL.PermisosBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
                MiPermisoBLL.Alta(_entidadPermiso)

                'MANDAR MENSAJE DE TODO CORRECTO OK
                Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 24) '24
                'Cambiar a administrar Perfil
                Session("Redirect") = "modificarPerfil.aspx"
                Response.Redirect("Mensajes.aspx", False)
            Else
                Throw New BLL.CamposincompletosException
            End If
        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.PermisoDuplicadoException
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

    Private Function validarListaPermisos() As Boolean
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
    End Function

    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Try
            Response.Redirect("index.aspx", False)
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