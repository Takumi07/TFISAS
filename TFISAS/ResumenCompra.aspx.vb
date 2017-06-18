Public Class ResumenCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                generarGrilla()
                generarGrillaPromo()
            Else

            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub


    Private Sub generarGrilla()
        Try
            Dim MiVentaEntidad As Entidades.Venta

            MiVentaEntidad = DirectCast(Session("Carrito_Compras"), Entidades.Venta)

            If Not IsNothing(MiVentaEntidad) Then

                Dim MiListaProducto As New List(Of Entidades.Producto)
                Dim descuento As Double = 0.0
                Dim subtotal As Double = 0.0
                Dim total As Double = 0.0

                MiListaProducto = MiVentaEntidad.ProductosComprados
                If MiListaProducto IsNot Nothing Then
                    Me.carrito_vacio.Visible = False
                    Me.carrito_lleno.Visible = True
                    If MiListaProducto.Count > 0 Then
                        Me.gv_carrito.DataSource = MiListaProducto
                        Me.gv_carrito.DataBind()
                        For x = 0 To MiListaProducto.Count - 1
                            subtotal += MiListaProducto(x).Precio.Precio * MiListaProducto(x).CantidadComprada
                            'Actualizo el Stock por si rechazó la compra por falta de stock
                            MiListaProducto(x).Stock = BLL.InventarioBLL.ObtenerStock(MiListaProducto(x).ID)
                            valorToGrilla(gv_carrito, x, MiListaProducto(x))
                        Next
                        total = subtotal
                    End If
                Else
                    Me.carrito_vacio.Visible = True
                    Me.carrito_lleno.Visible = False
                End If
                Me.hf_descuentos.Value = descuento
                Me.hf_subtotal.Value = subtotal
                Me.hf_total.Value = total
                Me.lbl_descuentos.Text = FormatCurrency(descuento)
                Me.lbl_Subtotal.Text = FormatCurrency(subtotal)
                Me.lbl_Total.Text = FormatCurrency(total)
            Else
                Me.carrito_vacio.Visible = True
                Me.carrito_lleno.Visible = False
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub


    Private Sub generarGrillaPromo()
        Try
            Dim MiVentaEntidad As Entidades.Venta

            MiVentaEntidad = DirectCast(Session("Carrito_Compras"), Entidades.Venta)

            If Not IsNothing(MiVentaEntidad) Then

                Dim MiListaPromociones As New List(Of Entidades.Promocion)
                Dim descuento As Double = 0.0
                Dim subtotal As Double = 0.0
                Dim total As Double = 0.0

                descuento += Me.hf_descuentos.Value
                subtotal += Me.hf_subtotal.Value
                total += Me.hf_total.Value


                MiListaPromociones = MiVentaEntidad.PromocionesCompradas
                If MiListaPromociones IsNot Nothing Then
                    Me.carrito_vacio.Visible = False
                    Me.carrito_lleno.Visible = True
                    If MiListaPromociones.Count > 0 Then
                        Me.gv_carritop.DataSource = MiListaPromociones
                        Me.gv_carritop.DataBind()
                        For x = 0 To MiListaPromociones.Count - 1
                            subtotal += (MiListaPromociones(x).Producto.Precio.Precio * MiListaPromociones(x).Producto.CantidadComprada) * ((100 - MiListaPromociones(x).Descuento) / 100)
                            descuento += (MiListaPromociones(x).Producto.Precio.Precio * MiListaPromociones(x).Producto.CantidadComprada) * (MiListaPromociones(x).Descuento / 100)
                            'Actualizo el Stock por si rechazó la compra por falta de stock
                            MiListaPromociones(x).Producto.Stock = BLL.InventarioBLL.ObtenerStock(MiListaPromociones(x).Producto.ID)
                            valorPromoToGrilla(gv_carritop, x, MiListaPromociones(x))
                        Next
                        total = subtotal
                    End If
                Else
                    Me.carrito_vacio.Visible = True
                    Me.carrito_lleno.Visible = False
                End If
                Me.hf_descuentos.Value = descuento
                Me.hf_subtotal.Value = subtotal
                Me.hf_total.Value = total
                Me.lbl_descuentos.Text = "$ " & descuento.ToString("0.00")
                Me.lbl_Subtotal.Text = "$ " & subtotal.ToString("0.00")
                Me.lbl_Total.Text = "$ " & total.ToString("0.00")
            Else
                Me.carrito_vacio.Visible = True
                Me.carrito_lleno.Visible = False
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub


    Private Sub gv_carrito_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles gv_carrito.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(1).Attributes.Add("colspan", "2")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gv_carritop_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles gv_carritop.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(1).Attributes.Add("colspan", "2")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub valorToGrilla(ByVal paramGV As GridView, ByVal paramFila As Integer, ByVal paramProducto As Entidades.Producto)
        Try
            Dim paramImagenProducto = DirectCast(paramGV.Rows(paramFila).FindControl("img_producto"), Image)
            paramImagenProducto.ImageUrl = Validaciones.DevolverUnaImagenProducto(paramProducto)
            Dim paramTalleProducto = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_Nombre"), Label)
            paramTalleProducto.Text = paramProducto.Nombre
            Dim paramCantidadComprada = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_cantidad"), Label)
            paramCantidadComprada.Text = paramProducto.CantidadComprada

            Dim paramPrecio = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_precio"), Label)
            paramPrecio.Text = "$ " & paramProducto.Precio.Precio.ToString("0.00")

            Dim paramStock = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_stock"), Label)
            paramStock.Text = paramProducto.Stock


            Dim paramID = DirectCast(paramGV.Rows(paramFila).FindControl("ID"), HiddenField)
            paramID.Value = paramProducto.ID
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Private Sub valorPromoToGrilla(ByVal paramGV As GridView, ByVal paramFila As Integer, ByVal paramPromocion As Entidades.Promocion)
        Try
            Dim paramImagenProducto = DirectCast(paramGV.Rows(paramFila).FindControl("img_productop"), Image)
            paramImagenProducto.ImageUrl = Validaciones.DevolverUnaImagenProducto(paramPromocion.Producto)
            Dim paramTalleProducto = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_Nombrep"), Label)
            paramTalleProducto.Text = paramPromocion.Producto.Nombre
            Dim paramCantidadComprada = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_cantidadp"), Label)
            paramCantidadComprada.Text = paramPromocion.Producto.CantidadComprada

            Dim paramPrecio = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_preciop"), Label)
            paramPrecio.Text = "$ " & paramPromocion.Producto.Precio.Precio.ToString("0.00")


            Dim paramDescuento = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_descuentop"), Label)
            paramDescuento.Text = "$ " & (paramPromocion.Producto.Precio.Precio * paramPromocion.Producto.CantidadComprada) * (paramPromocion.Descuento / 100)

            Dim paramStock = DirectCast(paramGV.Rows(paramFila).FindControl("lbl_stockp"), Label)
            paramStock.Text = paramPromocion.Producto.Stock


            Dim paramID = DirectCast(paramGV.Rows(paramFila).FindControl("IDP"), HiddenField)
            paramID.Value = paramPromocion.ID
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub




    Protected Sub eliminar_producto_Click(sender As Object, e As ImageClickEventArgs)
        Try
            DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados.Remove(DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados.Find(Function(x) x.ID = CInt(sender.commandargument)))
            If DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados.Count = 0 AndAlso DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas.Count = 0 Then
                Session("Carrito_Compras") = Nothing
            End If
            Response.Redirect("ResumenCompra.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_Confirmar_Click(sender As Object, e As EventArgs) Handles btn_Confirmar.Click
        Try
            Dim MiVentaBLL As New BLL.VentaBLL
            Dim MiVentaEntidad As Entidades.Venta
            MiVentaEntidad = DirectCast(Session("Carrito_Compras"), Entidades.Venta)
            MiVentaEntidad.Cliente = TryCast(Session("Usuario"), Entidades.Cliente)
            If IsNothing(MiVentaEntidad.Cliente) Then
                Session("Usuario") = Nothing
                Response.Redirect("Login.aspx", False)
            Else
                MiVentaBLL.AltaVenta(MiVentaEntidad)
                'Session("Mensaje") = "Su compra fue realizada con éxito." '20
                Session("Carrito_Compras") = Nothing
                Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 234)
                Session("Redirect") = "index.aspx"
                Response.Redirect("Mensajes.aspx", False)
            End If

        Catch ex As Entidades.NoHayStock
            Session("Error") = True
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 235)
            Session("Redirect") = "resumencompra.aspx"
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub Actualizar_Cantidad_Click(sender As Object, e As ImageClickEventArgs)
        Try
            For Each MiProducto As Entidades.Producto In DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados
                If MiProducto.ID = CInt(CInt(sender.CommandArgument)) Then
                    If MiProducto.CantidadComprada = MiProducto.Stock Then

                    Else
                        MiProducto.CantidadComprada = MiProducto.CantidadComprada + 1
                        Response.Redirect("ResumenCompra.aspx")
                    End If
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Actualizar_cantidad_Menos_Click(sender As Object, e As ImageClickEventArgs)
        Try
            For Each MiProducto As Entidades.Producto In DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados
                If MiProducto.ID = CInt(CInt(sender.CommandArgument)) Then
                    If MiProducto.CantidadComprada = 1 Then
                    Else
                        MiProducto.CantidadComprada = MiProducto.CantidadComprada - 1
                        Response.Redirect("ResumenCompra.aspx")
                    End If
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Actualizar_cantidad_Menos_Promo_Click(sender As Object, e As ImageClickEventArgs)
        Try
            For Each MiPromocion As Entidades.Promocion In DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas
                If MiPromocion.ID = CInt(CInt(sender.CommandArgument)) Then
                    If MiPromocion.Producto.CantidadComprada = 1 Then
                    Else
                        MiPromocion.Producto.CantidadComprada = MiPromocion.Producto.CantidadComprada - 1
                        Response.Redirect("ResumenCompra.aspx")
                    End If
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Actualizar_Cantidad_Promo_Click(sender As Object, e As ImageClickEventArgs)
        Try
            For Each MiPromocion As Entidades.Promocion In DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas
                If MiPromocion.ID = CInt(CInt(sender.CommandArgument)) Then
                    If MiPromocion.Producto.CantidadComprada = MiPromocion.Producto.Stock Then

                    Else
                        MiPromocion.Producto.CantidadComprada = MiPromocion.Producto.CantidadComprada + 1
                        Response.Redirect("ResumenCompra.aspx")
                    End If
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub eliminar_producto_promo_Click(sender As Object, e As ImageClickEventArgs)
        Try
            DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas.Remove(DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas.Find(Function(x) x.ID = CInt(sender.commandargument)))
            If DirectCast(Session("Carrito_Compras"), Entidades.Venta).ProductosComprados.Count = 0 AndAlso DirectCast(Session("Carrito_Compras"), Entidades.Venta).PromocionesCompradas.Count = 0 Then
                Session("Carrito_Compras") = Nothing
            End If
            Response.Redirect("ResumenCompra.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
        Catch ex As Exception
        End Try
    End Sub


End Class