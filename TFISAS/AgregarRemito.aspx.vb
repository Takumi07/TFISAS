Public Class AgregarRemito
    Inherits System.Web.UI.Page

    Dim MiRemito As New Entidades.Remito

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Not IsNothing(Session("Flag")) Then
                    If Session("Flag") = 2 Or Session("Flag") = 3 Then
                        Session("Flag") = Session("Flag") - 1
                        Me.CargarGrid()
                        Me.CargarProveedores()
                        Me.CargarProductos()
                        Me.llenardatos()
                    ElseIf Session("Flag") = 1 Or Session("Flag") = 0 Then
                        Session("Flag") = Nothing
                        Me.CargarProveedores()
                        Me.CargarProductos()
                        Me.llenardatos()
                        Me.CargarGrid()
                    End If
                Else
                    If IsNothing(Session("RemitoACargar")) Then
                        Session("RemitoACargar") = New Entidades.Remito
                        Me.CargarProveedores()
                        Me.CargarProductos()
                    Else
                        If DirectCast(Session("RemitoACargar"), Entidades.Remito).RemitoRenglon.Count = 0 Then
                            Session("RemitoACargar") = New Entidades.Remito
                            Me.CargarProveedores()
                            Me.CargarProductos()
                        Else
                            Me.CargarProductos()
                            Me.CargarProveedores()
                            Me.CargarGrid()
                            Me.llenardatos()
                        End If
                    End If
                End If

                'If Context.Items.Contains("RemitoACargar") Then
                '    Dim remitoaeditar As New Entidades.Remito
                '    remitoaeditar = DirectCast(Context.Items("RemitoACargar"), Entidades.Remito)
                '    Session("RemitoACargar") = remitoaeditar
                'End If
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



    Private Sub CargarGrid()
        Try
            If Not IsNothing(Session("RemitoACargar")) Then
                Me.gv_Remito.DataSource = DirectCast(Session("RemitoACargar"), Entidades.Remito).RemitoRenglon
                Me.gv_Remito.DataBind()
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

    Private Sub llenardatos()
        Try
            Me.txt_nroRemito.Text = DirectCast(Session("RemitoACargar"), Entidades.Remito).NroRemito
            Me.txt_FechaRemito.Text = DirectCast(Session("RemitoACargar"), Entidades.Remito).FechaEmision
            Me.ddl_Proveedor.SelectedValue = DirectCast(Session("RemitoACargar"), Entidades.Remito).Proveedor.ID
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub



    Private Sub CargarProductos()
        Try
            Dim MiListaProductos As New List(Of Entidades.Producto)
            MiListaProductos = (New BLL.ProductoBLL).ListarProductos

            Dim MiListaProductosManga As New List(Of Entidades.Manga)
            MiListaProductosManga = (New BLL.MangaBLL).ListarProductosManga
            'Mágico...
            MiListaProductos.AddRange(MiListaProductosManga)

            Me.ddl_Producto.DataSource = MiListaProductos
            Me.ddl_Producto.DataTextField = "Nombre"
            Me.ddl_Producto.DataValueField = "ID"
            Me.ddl_Producto.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            Dim MiRemitoBLL As New BLL.InventarioBLL(DirectCast(Session("Usuario"), Entidades.Usuario))
            If IsDate(txt_FechaRemito.Text) = False Then
                Throw New BLL.camposIncorrectosException
            End If

            If DateTime.Compare(Validaciones.CompararDatetime(txt_FechaRemito.Text), DateTime.Now) > 0 Then
                Throw New BLL.camposIncorrectosException
            End If

            If Me.txt_FechaRemito.Text = "" Or Me.txt_nroRemito.Text = "" Or IsNumeric(Me.txt_nroRemito.Text) = False Or DirectCast(Session("RemitoACargar"), Entidades.Remito).RemitoRenglon.Count = 0 Then
                Throw New BLL.CamposincompletosException
            End If
            DirectCast(Session("RemitoACargar"), Entidades.Remito).FechaEmision = Me.txt_FechaRemito.Text
            DirectCast(Session("RemitoACargar"), Entidades.Remito).Proveedor = Me.ObtenerProveedor
            DirectCast(Session("RemitoACargar"), Entidades.Remito).NroRemito = Me.txt_nroRemito.Text
            Dim MiEstado As New Entidades.Estado
            MiEstado.Estado = 1
            DirectCast(Session("RemitoACargar"), Entidades.Remito).Estado = MiEstado

            If MiRemitoBLL.VerificarNroRemito(DirectCast(Session("RemitoACargar"), Entidades.Remito).NroRemito, DirectCast(Session("RemitoACargar"), Entidades.Remito).Proveedor.ID) = True Then
                Throw New BLL.NroRemitoDuplicado
            End If

            MiRemitoBLL.CargaRemito(DirectCast(Session("RemitoACargar"), Entidades.Remito))

            Session("RemitoACargar") = Nothing
            Session("Flag") = Nothing
            'MANDAR MENSAJE DE TODO CORRECTO OK
            'Session("Mensaje") = "El remito fue dado de alta con éxito."
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 258)
            'Cambiar a administrar Perfil
            Session("Redirect") = "Index.aspx"
            Response.Redirect("Mensajes.aspx", False)




        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.camposIncorrectosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.NroRemitoDuplicado
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

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
            Dim MiRemitoRengonID As Integer
            If IsNothing(DirectCast(Session("RemitoACargar"), Entidades.Remito)) Then
                Session("RemitoACargar") = New Entidades.Remito
                MiRemitoRengonID = 1
            Else
                MiRemitoRengonID = DirectCast(Session("RemitoACargar"), Entidades.Remito).RemitoRenglon.Count + 1
            End If

            DirectCast(Session("RemitoACargar"), Entidades.Remito).NroRemito = txt_nroRemito.Text
            DirectCast(Session("RemitoACargar"), Entidades.Remito).FechaEmision = txt_FechaRemito.Text
            DirectCast(Session("RemitoACargar"), Entidades.Remito).Proveedor = Me.ObtenerProveedor

            Dim MiRemitoRenglon As New Entidades.RemitoRenglon

            MiRemitoRenglon.Producto = Me.ObtenerProducto
            MiRemitoRenglon.Cantidad = Me.txt_cantidad.Text
            MiRemitoRenglon.NroRenglon = MiRemitoRengonID


            DirectCast(Session("RemitoACargar"), Entidades.Remito).RemitoRenglon.Add(MiRemitoRenglon)
            'Prueba
            Session("Flag") = 2
            Response.Redirect("AgregarRemito.aspx", False)


            'Context.Items.Add("RemitoACargar", DirectCast(Session("RemitoACargar"), Entidades.Remito))
            ''Aca voy a la opción que me deja modificar
            'Server.Transfer("AgregarRemito.aspx")



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

        End Try
    End Sub

    Private Function ObtenerProducto() As Entidades.Producto
        Try
            Return (New BLL.ProductoBLL(Session("Usuario"))).ListarUnProducto(CInt(ddl_Producto.SelectedValue))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Function


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


    Protected Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            Session("RemitoACargar") = Nothing
            Session("Flag") = Nothing
            Response.Redirect("Index.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Eliminar_Command(sender As Object, e As CommandEventArgs)
        Try
            Dim renglon As Integer = CInt(sender.CommandArgument)
            DirectCast(Session("RemitoACargar"), Entidades.Remito).RemitoRenglon.Remove(DirectCast(Session("RemitoACargar"), Entidades.Remito).RemitoRenglon.Find(Function(x) x.NroRenglon = CInt(sender.CommandArgument)))

            Dim ID_Renglon = 0
            For Each MiRenglon As Entidades.RemitoRenglon In DirectCast(Session("RemitoACargar"), Entidades.Remito).RemitoRenglon
                ID_Renglon += 1
                MiRenglon.NroRenglon = ID_Renglon
            Next

            Session("Flag") = 2
            Response.Redirect("AgregarRemito.aspx", False)
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