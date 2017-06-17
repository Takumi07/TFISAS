Public Class ProductosPromocionales
    Inherits System.Web.UI.Page
    Dim MiListaPromocionProducto As New List(Of Entidades.Promocion)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.GenerarPromociones()
            Me.CargarPromociones()
        End If
    End Sub


    Private Sub GenerarPromociones()
        Dim MiPromocionBLL As New BLL.PromocionBLL
        MiListaPromocionProducto = MiPromocionBLL.PromocionXProducto()
    End Sub


    Private Sub CargarPromociones()
        Dim contador As Integer = 0
        For Each MiPromocion As Entidades.Promocion In MiListaPromocionProducto
            contador += 1
            'Dim Thumbnail As String = "thumbnail"
            'Dim imagen As String = "imagen"
            'Dim precio As String = "precio"
            'Dim producto As String = "Producto"
            'Dim descripcion As String = "Descripcion"
            'Dim mpContentPlaceHolder As New ContentPlaceHolder
            'mpContentPlaceHolder = Me.FindControl("contenidoPagina")

            If contador = 1 Then
                Me.thumbnail1.Visible = True
                Me.imagen1.Src = Validaciones.DevolverUnaImagenProducto(MiPromocion.Producto)
                Me.PrecioOriginal1.Text = Me.PrecioOriginal1.Text & " $ " & MiPromocion.Producto.Precio.Precio.ToString("0.00")
                Me.precio1.Text = Me.precio1.Text & " $ " & (MiPromocion.Producto.Precio.Precio.ToString("0.00") * ((100 - MiPromocion.Descuento) / 100)).ToString("0.00")
                Me.Nombre1.Text = MiPromocion.Producto.Nombre
                Me.descuento1.Text = Me.descuento1.Text & " " & MiPromocion.Descuento & " %"
                Dim des As String
                If MiPromocion.Producto.Descripcion.Length > 290 Then
                    des = MiPromocion.Producto.Descripcion.Substring(0, 285) & "..."
                Else
                    des = MiPromocion.Producto.Descripcion
                End If

                Me.Descripcion1.Text = des

            ElseIf contador = 2 Then
                Me.thumbnail2.Visible = True
                Me.imagen2.Src = Validaciones.DevolverUnaImagenProducto(MiPromocion.Producto)
                Me.precio2.Text = "$ " & (MiPromocion.Producto.Precio.Precio.ToString("0.00") * ((100 - MiPromocion.Descuento) / 100)).ToString("0.00")
                Me.Nombre2.Text = MiPromocion.Producto.Nombre
                Dim des As String
                If MiPromocion.Producto.Descripcion.Length > 290 Then
                    des = MiPromocion.Producto.Descripcion.Substring(0, 285) & "..."
                Else
                    des = MiPromocion.Producto.Descripcion
                End If

                Me.Descripcion2.Text = des
            ElseIf contador = 3 Then
                Me.thumbnail3.Visible = True
                Me.imagen3.Src = Validaciones.DevolverUnaImagenProducto(MiPromocion.Producto)
                Me.Precio3.Text = "$ " & (MiPromocion.Producto.Precio.Precio.ToString("0.00") * ((100 - MiPromocion.Descuento) / 100)).ToString("0.00")
                Me.Nombre3.Text = MiPromocion.Producto.Nombre
                Dim des As String
                If MiPromocion.Producto.Descripcion.Length > 290 Then
                    des = MiPromocion.Producto.Descripcion.Substring(0, 285) & "..."
                Else
                    des = MiPromocion.Producto.Descripcion
                End If

                Me.Descripcion3.Text = des
            ElseIf contador = 4 Then
                Me.thumbnail4.Visible = True
                Me.imagen4.Src = Validaciones.DevolverUnaImagenProducto(MiPromocion.Producto)
                Me.precio4.Text = "$ " & (MiPromocion.Producto.Precio.Precio.ToString("0.00") * ((100 - MiPromocion.Descuento) / 100)).ToString("0.00")
                Me.Nombre4.Text = MiPromocion.Producto.Nombre
                Dim des As String
                If MiPromocion.Producto.Descripcion.Length > 290 Then
                    des = MiPromocion.Producto.Descripcion.Substring(0, 285) & "..."
                Else
                    des = MiPromocion.Producto.Descripcion
                End If
                Me.Descripcion4.Text = des
            ElseIf contador = 5 Then
                Me.thumbnail5.Visible = True
                Me.imagen5.Src = Validaciones.DevolverUnaImagenProducto(MiPromocion.Producto)
                Me.Precio5.Text = "$ " & (MiPromocion.Producto.Precio.Precio.ToString("0.00") * ((100 - MiPromocion.Descuento) / 100)).ToString("0.00")
                Me.Nombre5.Text = MiPromocion.Producto.Nombre
                Dim des As String
                If MiPromocion.Producto.Descripcion.Length > 290 Then
                    des = MiPromocion.Producto.Descripcion.Substring(0, 285) & "..."
                Else
                    des = MiPromocion.Producto.Descripcion
                End If
                Me.Descripcion5.Text = des
            ElseIf contador = 6 Then
                Me.thumbnail6.Visible = True
                Me.imagen6.Src = Validaciones.DevolverUnaImagenProducto(MiPromocion.Producto)
                Me.precio6.Text = "$ " & (MiPromocion.Producto.Precio.Precio.ToString("0.00") * ((100 - MiPromocion.Descuento) / 100)).ToString("0.00")
                Me.Nombre6.Text = MiPromocion.Producto.Nombre
                Dim des As String
                If MiPromocion.Producto.Descripcion.Length > 290 Then
                    des = MiPromocion.Producto.Descripcion.Substring(0, 285) & "..."
                Else
                    des = MiPromocion.Producto.Descripcion
                End If
                Me.Descripcion6.Text = des
            End If
        Next

    End Sub

End Class