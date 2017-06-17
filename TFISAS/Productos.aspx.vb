Public Class Productos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                obtenerProductos()
            Else
                Dim MiPagina As Integer
                If Me.ddl_paginacion.SelectedValue = "" Then
                    MiPagina = 1
                Else
                    MiPagina = Me.ddl_paginacion.SelectedValue
                End If
                obtenerProductos(MiPagina)
                Me.ddl_paginacion.SelectedValue = MiPagina
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try

    End Sub



    Private Sub obtenerProductos(Optional ByVal paramPagina As Integer = 1)
        Try
            Dim MiListaProductos As New List(Of Entidades.Producto)
            Dim MiProductoBLL As New BLL.ProductoBLL
            Dim MiInicioProducto As Integer = 1
            MiListaProductos = MiProductoBLL.ListarProductos
            generarpaginacion(MiListaProductos.Count)

            Dim PosicionDesde As Integer = 0
            Dim PosicionHasta As Integer = 0
            Dim Ocultacion As Integer = 0
            PosicionDesde = ((12 * paramPagina) - 12) + 1
            PosicionHasta = PosicionDesde + 11

            Dim Flag = 1
            For Each miproducto As Entidades.Producto In MiListaProductos
                If Flag >= PosicionDesde AndAlso Flag <= PosicionHasta Then
                    mostrarProducto(miproducto, MiInicioProducto)
                    MiInicioProducto += 1
                End If
                Flag += 1
            Next


            Ocultacion = MiListaProductos.Count - PosicionHasta
            If Ocultacion > 0 Then
                Ocultacion = 0
            Else
                Ocultacion = (12 + Ocultacion) + 1
            End If


            ocultarSobra((Ocultacion))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mostrarProducto(ByVal paramProducto As Entidades.Producto, ByVal paramIndice As Integer)
        Try
            Dim literalDiv As New HtmlGenericControl
            literalDiv = DirectCast(Me.panelProductos.FindControl("producto" & paramIndice), HtmlGenericControl)
            literalDiv.Visible = True
            Dim imagenProducto As ImageButton = Me.panelProductos.FindControl("img_producto_" & paramIndice)
            Dim lbl_Precio As Label = Me.panelProductos.FindControl("lbl_Precio_" & paramIndice)
            Dim value As HiddenField = Me.panelProductos.FindControl("hf_" & paramIndice)
            Dim lbl_Descripcion As Label = Me.panelProductos.FindControl("lbl_Descripcion_" & paramIndice)
            imagenProducto.ImageUrl = Validaciones.DevolverUnaImagenProducto(paramProducto)
            lbl_Precio.Text = "$ " & paramProducto.Precio.Precio.ToString("0.00")
            value.Value = paramProducto.ID
            lbl_Descripcion.Text = paramProducto.Nombre
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ocultarSobra(ByVal cantidadProductos As Integer)
        Try
            If cantidadProductos > 0 Then
                For x = cantidadProductos To 12
                    Dim literalDiv As New HtmlGenericControl
                    literalDiv = DirectCast(Me.panelProductos.FindControl("producto" & x), HtmlGenericControl)
                    literalDiv.Visible = False
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub generarpaginacion(ByVal paramPaginacion As Integer)
        Try
            Me.ddl_paginacion.Items.Clear()
            Dim cantPaginas As Integer = Math.Ceiling(paramPaginacion / 12)
            For x = 1 To cantPaginas
                Dim oListItem As New ListItem
                oListItem.Text = "Página " & x
                oListItem.Value = x
                Me.ddl_paginacion.Items.Add(oListItem)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub agregarAlCarrito(ByVal paramID As Integer)
        Try
            Dim _bllProducto As New BLL.ProductoBLL
            Dim oProducto As Entidades.Producto = _bllProducto.ListarUnProducto(paramID)
            If oProducto.Stock <= 0 Then
                Session("Error") = True
                If IsNothing(TryCast(Session("Usuario"), Entidades.Usuario)) Then
                    Session("Mensaje") = "Lamentablemente no poseemos stock de este producto."
                Else
                    Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(TryCast(Session("Usuario"), Entidades.Usuario).Idioma, 189)
                End If

                Session("Redirect") = "NuestrosProductos.aspx"
                Response.Redirect("Mensajes.aspx", False)
            Else

                If Not Session("Carrito_Compras") Is Nothing Then
                    Dim MiVenta As Entidades.Venta = DirectCast(Session("Carrito_Compras"), Entidades.Venta)
                    'CAMBIADO PARA QUE TENGA CANTIDAD
                    oProducto.CantidadComprada = 1
                    'FIN DE CAMBIADO PARA QUE TENGA CANTIDAD


                    Dim LoTengoEnLaPromo = False

                    'Si lo tengo en la promocion, le aumento la cantidad comprada
                    For Each Promocion As Entidades.Promocion In DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas
                        If oProducto.ID = Promocion.Producto.ID Then
                            Promocion.Producto.CantidadComprada += 1
                            LoTengoEnLaPromo = True
                        End If
                    Next

                    'No lo tengo en la promo, lo agrego o me fijo si lo tengo en el producto. 
                    If LoTengoEnLaPromo = False Then
                        If MiVenta.ProductosComprados.Any(Function(x) x.ID = oProducto.ID) = True Then
                            MiVenta.ProductosComprados.Find(Function(x) x.ID = oProducto.ID).CantidadComprada += 1
                        Else
                            MiVenta.ProductosComprados.Add(oProducto)
                        End If
                    End If

                    Session("Carrito_Compras") = MiVenta
                    ''''''CAMBIADO PARA LA VENTABLL
                    'Dim _listaProductos As List(Of Entidades.Producto) = DirectCast(Session("Carrito_Compras"), List(Of Entidades.Producto))
                    '_listaProductos.Add(oProducto)
                    'Session("Carrito_Compras") = _listaProductos
                Else
                    Dim MiVenta As New Entidades.Venta

                    'CAMBIADO PARA QUE TENGA CANTIDAD
                    oProducto.CantidadComprada = 1
                    'FIN DE CAMBIADO PARA QUE TENGA CANTIDAD

                    MiVenta.ProductosComprados.Add(oProducto)
                    Session("Carrito_Compras") = MiVenta

                    ''''''CAMBIADO PARA LA VENTABLL
                    'Dim _listaProductos As New List(Of Entidades.Producto)
                    '_listaProductos.Add(oProducto)
                    'Session("Carrito_Compras") = _listaProductos
                End If
                Response.Redirect("resumencompra.aspx")

            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

#Region "Agregar al Carrito"
    Protected Sub img_producto_1_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_1.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub img_producto_2_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_2.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub img_producto_3_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_3.Value)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub img_producto_4_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_4.Value)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub img_producto_5_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_5.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub img_producto_6_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_6.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub img_producto_7_Click(sender As Object, e As ImageClickEventArgs)
        agregarAlCarrito(Me.hf_7.Value)
    End Sub

    Protected Sub img_producto_8_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_8.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub img_producto_9_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_9.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub img_producto_10_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_10.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub img_producto_11_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_11.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub img_producto_12_Click(sender As Object, e As ImageClickEventArgs)
        Try
            agregarAlCarrito(Me.hf_12.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_1_Click(sender As Object, e As EventArgs) Handles btn_agregar_1.Click
        Try
            agregarAlCarrito(Me.hf_1.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_2_Click(sender As Object, e As EventArgs) Handles btn_agregar_2.Click
        Try
            agregarAlCarrito(Me.hf_2.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_3_Click(sender As Object, e As EventArgs) Handles btn_agregar_3.Click
        Try
            agregarAlCarrito(Me.hf_3.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_4_Click(sender As Object, e As EventArgs) Handles btn_agregar_4.Click
        Try
            agregarAlCarrito(Me.hf_4.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_5_Click(sender As Object, e As EventArgs) Handles btn_agregar_5.Click
        Try
            agregarAlCarrito(Me.hf_5.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_6_Click(sender As Object, e As EventArgs) Handles btn_agregar_6.Click
        Try
            agregarAlCarrito(Me.hf_6.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_7_Click(sender As Object, e As EventArgs) Handles btn_agregar_7.Click
        Try
            agregarAlCarrito(Me.hf_7.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_8_Click(sender As Object, e As EventArgs) Handles btn_agregar_8.Click
        Try
            agregarAlCarrito(Me.hf_8.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_9_Click(sender As Object, e As EventArgs) Handles btn_agregar_9.Click
        Try
            agregarAlCarrito(Me.hf_9.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_10_Click(sender As Object, e As EventArgs) Handles btn_agregar_10.Click
        Try
            agregarAlCarrito(Me.hf_10.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_11_Click(sender As Object, e As EventArgs) Handles btn_agregar_11.Click
        Try
            agregarAlCarrito(Me.hf_11.Value)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_agregar_12_Click(sender As Object, e As EventArgs) Handles btn_agregar_12.Click
        Try
            agregarAlCarrito(Me.hf_12.Value)
        Catch ex As Exception
        End Try
    End Sub
#End Region


End Class