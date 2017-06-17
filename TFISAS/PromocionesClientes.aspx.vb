Public Class PromocionesClientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNothing(Session("Usuario")) Then
                Response.Redirect("Login.aspx")
            Else
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
            Dim MisPromociones As New List(Of Entidades.Promocion)
            Dim MiPromocionBLL As New BLL.PromocionBLL
            Dim MiCliente As New Entidades.Cliente

            MiCliente = TryCast(Session("Usuario"), Entidades.Cliente)
            If Not IsNothing(MiCliente) Then
                MisPromociones = MiPromocionBLL.PromocionXCliente(MiCliente)
                If Not IsNothing(MisPromociones) AndAlso MisPromociones.Count <> 0 Then
                    generarpaginacion(MisPromociones.Count)
                    ' nro de pagina parampagina
                    'Total por pagina 12
                    Dim PosicionDesde As Integer = 0
                    Dim PosicionHasta As Integer = 0
                    Dim Ocultacion As Integer = 0
                    PosicionDesde = ((12 * paramPagina) - 12) + 1
                    PosicionHasta = PosicionDesde + 11



                    Me.SinPromocion.Visible = False
                    Dim MiInicioProducto As Integer = 1

                    Dim Flag = 1
                    For Each MiPromocion As Entidades.Promocion In MisPromociones
                        If Flag >= PosicionDesde AndAlso Flag <= PosicionHasta Then
                            mostrarProducto(MiPromocion, MiInicioProducto)
                            MiInicioProducto += 1
                        End If
                        Flag += 1
                    Next

                    Ocultacion = MisPromociones.Count - PosicionHasta
                    If Ocultacion > 0 Then
                        Ocultacion = 0
                    Else
                        Ocultacion = (12 + Ocultacion) + 1
                    End If
                    ocultarSobra((Ocultacion))
                Else
                    Me.panelProductos.Visible = False
                    Me.SinPromocion.Visible = True
                    ocultarSobra(1)
                End If

            Else
                ocultarSobra(1)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mostrarProducto(ByVal paramPromocion As Entidades.Promocion, ByVal paramIndice As Integer)
        Try
            Dim literalDiv As New HtmlGenericControl
            literalDiv = DirectCast(Me.panelProductos.FindControl("producto" & paramIndice), HtmlGenericControl)
            literalDiv.Visible = True
            Dim imagenProducto As ImageButton = Me.panelProductos.FindControl("img_producto_" & paramIndice)
            Dim lbl_Precio As Label = Me.panelProductos.FindControl("lbl_Precio_" & paramIndice)
            Dim lbl_PrecioDes As Label = Me.panelProductos.FindControl("lbl_PrecioDes_" & paramIndice)
            Dim value As HiddenField = Me.panelProductos.FindControl("hf_" & paramIndice)
            Dim lbl_Descripcion As Label = Me.panelProductos.FindControl("lbl_Descripcion_" & paramIndice)

            imagenProducto.ImageUrl = Validaciones.DevolverUnaImagenProducto(paramPromocion.Producto)
            lbl_Precio.Text = " $ " & paramPromocion.Producto.Precio.Precio.ToString("0.00")
            value.Value = paramPromocion.Producto.ID
            lbl_Descripcion.Text = paramPromocion.Producto.Nombre
            lbl_PrecioDes.Text = " $ " & (paramPromocion.Producto.Precio.Precio * ((100 - paramPromocion.Descuento) / 100)).ToString("0.00")
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
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
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
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception

        End Try
    End Sub

    Private Sub agregarAlCarrito(ByVal paramID As Integer)
        Try
            'Tengo el ID del producto.
            Dim MisPromociones As New List(Of Entidades.Promocion)
            Dim MiPromocionBLL As New BLL.PromocionBLL
            Dim MiCliente As New Entidades.Cliente
            Dim MiPromocion As New Entidades.Promocion
            MiCliente = TryCast(Session("Usuario"), Entidades.Cliente)
            MisPromociones = MiPromocionBLL.PromocionXCliente(MiCliente)

            For Each Promocion As Entidades.Promocion In MisPromociones
                If Promocion.Producto.ID = paramID Then
                    MiPromocion = Promocion
                End If
            Next
            If Not Session("Carrito_Compras") Is Nothing Then
                Dim MiVenta As Entidades.Venta = DirectCast(Session("Carrito_Compras"), Entidades.Venta)
                Dim ID As Integer
                If IsNothing(DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas) Then
                    ID = 1
                Else
                    'Valido si ya tengo ese producto.
                    If Not IsNothing(DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados) Then
                        For Each MiProducto As Entidades.Producto In DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados
                            If MiProducto.ID = MiPromocion.Producto.ID Then
                                MiPromocion.Producto.CantidadComprada = MiProducto.CantidadComprada + 1
                            End If
                        Next
                        'ver que pasa aca si no se cumple.
                        DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados.Remove(DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados.Find(Function(x) x.ID = MiPromocion.Producto.ID))
                    End If
                    ID = DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas.Count + 1
                End If


                Dim LoTengoEnLaPromo = False
                If Not IsNothing(DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas) Then
                    For Each Promo As Entidades.Promocion In DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas
                        If Promo.Producto.ID = MiPromocion.Producto.ID Then
                            Promo.Producto.CantidadComprada += 1
                            LoTengoEnLaPromo = True
                        End If

                    Next
                End If
                If LoTengoEnLaPromo = False Then
                    MiPromocion.ID = ID
                    MiVenta.PromocionesCompradas.Add(MiPromocion)
                    Session("Carrito_Compras") = MiVenta
                End If
            Else
                Dim MiVenta As New Entidades.Venta
                'Porque es la primera.
                MiPromocion.ID = 1
                MiPromocion.Producto.CantidadComprada = 1
                MiVenta.PromocionesCompradas.Add(MiPromocion)
                Session("Carrito_Compras") = MiVenta
            End If
            Response.Redirect("resumencompra.aspx")
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
        Try
            agregarAlCarrito(Me.hf_7.Value)
        Catch ex As Exception
        End Try
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