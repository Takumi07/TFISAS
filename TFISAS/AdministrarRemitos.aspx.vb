Public Class AdministrarRemitos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.LLenarGrid()
                Me.ListaRemtios.Visible = True
                Me.DetalleRemito.Visible = False
                Me.CargarProveedores()
                If Session("Flag") = 1 Then
                    If Not IsNothing(Session("RemitoAAprobar")) Then
                        Me.LlenarDatos()
                        Me.ListaRemtios.Visible = False
                        Me.DetalleRemito.Visible = True
                        Session("Flag") = 0
                        Session("RemitoAAprobar") = Nothing
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Seleccionar_Command(sender As Object, e As CommandEventArgs)

        Try
            Dim combinatoria As String = sender.CommandArgument
            Dim NroRemito As Integer
            Dim IDProveedor As Integer
            Dim delimiter As Char = ";"c
            Dim substrings() As String = combinatoria.Split(delimiter)

            Dim nro As Integer = 0
            For Each substring In substrings
                If nro = 0 Then
                    NroRemito = substring
                ElseIf nro = 1 Then
                    IDProveedor = substring
                End If
                nro += 1
            Next
            Dim MiRemito As New Entidades.Remito
            MiRemito.NroRemito = CInt(NroRemito)
            MiRemito.Proveedor = New Entidades.Proveedor(CInt(IDProveedor))
            MiRemito = (New BLL.InventarioBLL(Session("Usuario"))).ObtenerUnRemito(MiRemito)
            Session("Flag") = 1
            Session("RemitoAAprobar") = MiRemito
            Response.Redirect("AdministrarRemitos.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub


    Private Sub LlenarDatos()
        Try
            txt_nroRemito.Text = DirectCast(Session("RemitoAAprobar"), Entidades.Remito).NroRemito
            ddl_Proveedor.SelectedValue = DirectCast(Session("RemitoAAprobar"), Entidades.Remito).Proveedor.ID
            txt_FechaRemito.Text = DirectCast(Session("RemitoAAprobar"), Entidades.Remito).FechaEmision
            gv_remitoDetalle.DataSource = DirectCast(Session("RemitoAAprobar"), Entidades.Remito).RemitoRenglon
            gv_remitoDetalle.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub


    Private Sub LLenarGrid()
        Try
            Me.gv_Remito.DataSource = (New BLL.InventarioBLL(Session("Usuario"))).ListarRemitos(1)
            Me.gv_Remito.DataBind
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Rechazar_Click(sender As Object, e As EventArgs) Handles btn_Rechazar.Click
        Try
            Dim MiRemitoBLL As New BLL.InventarioBLL(Session("Usuario"))
            Dim MiRemitoEntidad As New Entidades.Remito
            MiRemitoEntidad.Proveedor = Me.ObtenerProveedor
            MiRemitoEntidad.NroRemito = Me.txt_nroRemito.Text
            MiRemitoEntidad = MiRemitoBLL.ObtenerUnRemito(MiRemitoEntidad)
            MiRemitoEntidad.Estado = New Entidades.Estado(3)
            MiRemitoBLL.RechazarRemito(MiRemitoEntidad)
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 175)
            Session("Redirect") = "AdministrarRemitos.aspx"
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Aprobar_Click(sender As Object, e As EventArgs) Handles btn_Aprobar.Click
        Try
            Dim MiRemitoBLL As New BLL.InventarioBLL(Session("Usuario"))
            Dim MiRemitoEntidad As New Entidades.Remito
            'Nro de Remito - ID Proveedor
            'MiRemitoEntidad = MiRemitoBLL.ObtenerUnRemito()
            MiRemitoEntidad.Proveedor = Me.ObtenerProveedor
            MiRemitoEntidad.NroRemito = Me.txt_nroRemito.Text
            MiRemitoEntidad = MiRemitoBLL.ObtenerUnRemito(MiRemitoEntidad)
            MiRemitoEntidad.Estado = New Entidades.Estado(2)
            MiRemitoBLL.AprobarRemito(MiRemitoEntidad)
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 176)
            Session("Redirect") = "AdministrarRemitos.aspx"
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub


    Private Function ObtenerProveedor() As Entidades.Proveedor
        Try
            Dim MiListaProveedor As New List(Of Entidades.Proveedor)
            MiListaProveedor = (New BLL.ProveedorBLL).ListarProveedores()
            Return MiListaProveedor.Find(Function(x) x.ID = CInt(ddl_Proveedor.SelectedValue))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function

    Private Sub CargarProveedores()
        Try
            Me.ddl_Proveedor.DataSource = (New BLL.ProveedorBLL).ListarProveedores()
            Me.ddl_Proveedor.DataTextField = "Nombre"
            Me.ddl_Proveedor.DataValueField = "ID"
            Me.ddl_Proveedor.DataBind()
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