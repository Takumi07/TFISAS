Imports System.Threading
Imports System.Security.Principal



Public Class Maestra
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim MiPagina As String = Right(Request.Path, Len(Request.Path) - 1).ToUpper
            If MiPagina = "Mensajes.aspx".ToUpper Then
                If Not IsNothing(Session("FlagSQL")) AndAlso CBool(Session("FlagSQL")) = True Then
                    Me.menuOpcionesUsuario.Visible = False
                    Me.menuSistema.Visible = False
                    Session("FlagSQL") = Nothing
                Else
                    If Not IsNothing(Session("F5")) AndAlso CBool(Session("F5")) = True Then
                        Me.menuOpcionesUsuario.Visible = False
                        Me.menuSistema.Visible = False
                        Session("F5") = Nothing
                    Else
                        If Not IsNothing(Session("Usuario")) Then
                            Me.HabilitarMenu()
                            Me.MenuUsuario()
                            Me.TraducirPagina()
                        Else
                            Me.DeshabilitarMenu()
                        End If
                    End If

                End If
            Else
                If BLL.DVBLL.Integridad = False Then
                    'Integridad Corrupta
                    Me.divDBError.Visible = True
                Else
                    Me.ValidarPagina()
                    If IsNothing(Session("Usuario")) Then
                        'No hay usuario Logeado
                        Me.menuOpcionesUsuario.Visible = False
                        Me.menuSistema.Visible = False
                    Else
                        Me.HabilitarMenu()
                        Me.MenuUsuario()
                        Me.TraducirPagina()
                    End If
                End If
            End If

        Catch ex As System.Data.SqlClient.SqlException
            'Te deslogeo porque es un SQL Error
            Session("Usuario") = Nothing
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica

        Catch ex As BLL.IntegridadCorrupta
            'Te deslogeo porque esta corrupta
            Session("Usuario") = Nothing
            'Te quito los menues
            Me.menuOpcionesUsuario.Visible = False
            Me.menuSistema.Visible = False
            'Habilito la notificación
            Me.divDBError.Visible = True
            'Deshabilito el contenido de la página
            Dim mpContentPlaceHolder As New ContentPlaceHolder
            mpContentPlaceHolder = Me.FindControl("contenidoPagina")
            mpContentPlaceHolder.Visible = False
        Catch ex As Exception
        End Try



    End Sub

    Protected Sub lkPassword_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("CambiarContraseña.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lkIdioma_Click(sender As Object, e As EventArgs)
        Try
            Response.Redirect("CambiarIdioma.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lkPerfil_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub MenuUsuario()
        Try
            Dim MiUsuario As New Entidades.Usuario
            MiUsuario = DirectCast(Session("Usuario"), Entidades.Usuario)
            Me.lbl_NombreUsuarioTexto.Text = MiUsuario.NombreUsuario


            'Aca tendrìa que ir la imagen
            If DirectCast(Session("Usuario"), Entidades.Usuario).ImagenUsuario = "" Or IsNothing(DirectCast(Session("Usuario"), Entidades.Usuario).ImagenUsuario) Then
                Me.imagenperfil.Src = "Imagenes/michael.jpg"
            Else
                Me.imagenperfil.Src = "data:image/png;base64," & DirectCast(Session("Usuario"), Entidades.Usuario).ImagenUsuario
            End If

            Dim MiHijoR As New MenuItem

            For Each MiMenuItemPadre As MenuItem In menuEstatico.Items
                If MiMenuItemPadre.Value.ToUpper = "Login".ToUpper Then
                    MiHijoR = MiMenuItemPadre
                End If
            Next

            menuEstatico.Items.Remove(MiHijoR)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub DeshabilitarMenu()
        menuEstatico.Visible = True
        menuOpcionesUsuario.Visible = False
        menuPrincipal.Visible = False
        menuSistema.Visible = False
    End Sub

    Private Sub HabilitarMenu()
        Try
            Dim MiUsuario As New Entidades.Usuario
            MiUsuario = DirectCast(Session("Usuario"), Entidades.Usuario)
            Dim MiPermisoCompuesto As New Entidades.PermisoCompuesto
            MiPermisoCompuesto = DirectCast(MiUsuario.Permiso, Entidades.PermisoCompuesto)

            Dim MiListaHijos As New List(Of MenuItem)

            Dim MiListaPadres As New List(Of MenuItem)

            'Empiezo a trabajar
            'Tengo todos los menues.
            For Each MiMenuItem As MenuItem In menuPrincipal.Items
                MiMenuItem.Enabled = False
                'Tiene Submenues?
                If MiMenuItem.ChildItems.Count > 0 Then
                    For Each MiItemHijo As MenuItem In MiMenuItem.ChildItems
                        If MiPermisoCompuesto.ValidaURL(MiItemHijo.NavigateUrl) = True Then
                            MiMenuItem.Enabled = True
                            MiItemHijo.Enabled = True
                        Else
                            MiItemHijo.Enabled = False
                            MiListaHijos.Add(MiItemHijo)
                        End If
                    Next
                End If
            Next


            'Pele, el negro de mambru y DungaDunga son mas blancos que la negrada que hago aca
            'Funciona

            For Each MiMenuItemPadre As MenuItem In menuPrincipal.Items
                For Each mihijo As MenuItem In MiListaHijos
                    MiMenuItemPadre.ChildItems.Remove(mihijo)
                Next
            Next

            For Each MiMenuItemPadre As MenuItem In menuPrincipal.Items
                If MiMenuItemPadre.ChildItems.Count = 0 Then
                    MiListaPadres.Add(MiMenuItemPadre)
                End If
            Next

            For Each SoyPadre As MenuItem In MiListaPadres
                menuPrincipal.Items.Remove(SoyPadre)
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub





    Private Sub ValidarPagina()

        Try
            Dim MiPagina As String = Right(Request.Path, Len(Request.Path) - 1).ToUpper

            'Vale esto? Acaso son ilegales los pisos floreados?
            Dim MisPaginasDefecto As New List(Of String)
            'Aca meto todas las URL que no voy a chequear.

            MisPaginasDefecto.Add("index.aspx".ToUpper)
            MisPaginasDefecto.Add("Institucional.aspx".ToUpper)
            MisPaginasDefecto.Add("Login.aspx".ToUpper)
            MisPaginasDefecto.Add("Mensajes.aspx".ToUpper)
            MisPaginasDefecto.Add("NuestrosProductos.aspx".ToUpper)
            'VER ESTE CASO EN PARTICULAR.
            MisPaginasDefecto.Add("Registrarse.aspx".ToUpper)


            'ACA PUEDO PONER TAMBIÉN PÁGINAS QUE TODOS LOS USUARIOS NECESITEN TENER SI O SI

            MisPaginasDefecto.Add("CambiarContraseña.aspx".ToUpper)
            MisPaginasDefecto.Add("CambiarIdioma.aspx".ToUpper)
            MisPaginasDefecto.Add("recuperarClave.aspx".ToUpper)
            MisPaginasDefecto.Add("PromocionesProductos.aspx".ToUpper)
            MisPaginasDefecto.Add("ResumenCompra.aspx".ToUpper)
            MisPaginasDefecto.Add("Productos.aspx".ToUpper)
            MisPaginasDefecto.Add("Mangas.aspx".ToUpper)



            'PARA PROVAR!!!!!!!! SACAR!! NO OLVIDAR!!!
            MisPaginasDefecto.Add("PromocionesClientes.aspx".ToUpper)

            If MisPaginasDefecto.Contains(MiPagina) Then
                'Es una página default, te dejo pasar.

            Else

                Dim MiUsuario As New Entidades.Usuario
                MiUsuario = DirectCast(Session("Usuario"), Entidades.Usuario)
                If Not IsNothing(MiUsuario) Then

                    Dim MiPermisoCompuesto As New Entidades.PermisoCompuesto
                    MiPermisoCompuesto = DirectCast(MiUsuario.Permiso, Entidades.PermisoCompuesto)

                    If MiPermisoCompuesto.ValidaURL(MiPagina) = True Then
                        'Te dejo pasar, porq tenes permisos
                    Else
                        Session("Error") = True
                        Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 148) '148
                        Response.Redirect("Mensajes.aspx", False)
                    End If
                Else
                    Session("Error") = True
                    Session("Mensaje") = "Usted no posee autorización para visualizar este contenido." '148
                    Response.Redirect("Mensajes.aspx", False)
                End If

            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub





    Protected Sub TraducirPagina()

        If IsNothing(Session("Usuario")) Then
            'No hay usario logeado, por ahora no te hago nada...

        Else
            Try


                Dim MiIdioma As New Entidades.Idioma
                'Esto tiene cargado el idioma del usuario identificando solo el idioma sin las palabras.
                MiIdioma = DirectCast(Session("Usuario"), Entidades.Usuario).Idioma
                'Obtengo la pàgina
                Dim MiPagina As String = Right(Request.Path, Len(Request.Path) - 1)
                'Cargo las traducciones para esa pàgina de ese idioma + la master
                MiIdioma = (New BLL.IdiomaBLL(Session("Usuario"))).Cargar(MiIdioma, MiPagina.ToString)
                'Tengo las Palabars de Esta página
                Session("Idioma") = MiIdioma


                'Traduzco Los Menúes
                Me.traducirMenuEstatico()
                Me.traducirMenuUsuario()

                'Traduzco el  Copyright

                Me.Copyright.Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 147) '147



                'Falta traducir el menu especial del usuario logeado (Fotito Arriba)


                Dim mpContentPlaceHolder As New ContentPlaceHolder
                mpContentPlaceHolder = Me.FindControl("contenidoPagina")
                traducirControl(mpContentPlaceHolder.Controls)
            Catch ex As System.Data.SqlClient.SqlException
                'Sino referencia cíclica....
                'Session("SQLERROR") = ex.Message
                'Response.Redirect("Mensajes.aspx", False)
            Catch ex As Exception

            End Try
        End If

    End Sub






#Region "Traductor"

#Region "Traductor Menues"
    Private Sub traducirMenuEstatico()
        Try
            Dim MiMenuP As Menu
            MiMenuP = Me.FindControl("menuEstatico")
            If MiMenuP.Items.Count > 0 Then
                traducirMenuRecursivo(MiMenuP.Items)
            End If
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub traducirMenuUsuario()
        Try
            Dim MiMenuP As Menu
            MiMenuP = Me.FindControl("menuPrincipal")
            If MiMenuP.Items.Count > 0 Then
                traducirMenuRecursivo(MiMenuP.Items)
            End If

            Me.traducir(DirectCast(Me.FindControl("lkPassword"), LinkButton))
            Me.traducir(DirectCast(Me.FindControl("lkIdioma"), LinkButton))
            Me.traducir(DirectCast(Me.FindControl("lkPerfil"), LinkButton))
            Me.traducir(DirectCast(Me.FindControl("lkLogOut"), LinkButton))
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub traducirMenuRecursivo(ByVal _items As MenuItemCollection)
        Try
            For Each MiMenuItem As MenuItem In _items
                traducir(MiMenuItem)
                If MiMenuItem.ChildItems.Count > 0 Then
                    traducirMenuRecursivo(MiMenuItem.ChildItems)
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub
#End Region


    Private Sub traducirControl(ByVal paramListaControl As ControlCollection)
        Try
            For Each miControl As Control In paramListaControl
                If TypeOf miControl Is Button Then
                    traducir(DirectCast(miControl, Button))
                ElseIf TypeOf miControl Is CheckBox Then
                    traducir(DirectCast(miControl, CheckBox))
                ElseIf TypeOf miControl Is RadioButton Then
                    traducir(DirectCast(miControl, RadioButton))
                ElseIf TypeOf miControl Is Label Then
                    traducir(DirectCast(miControl, Label))
                ElseIf TypeOf miControl Is ImageButton Then
                    traducir(DirectCast(miControl, ImageButton))
                ElseIf TypeOf miControl Is LinkButton Then
                    traducir(DirectCast(miControl, LinkButton))
                ElseIf TypeOf miControl Is GridView Then
                    traducir(DirectCast(miControl, GridView))
                ElseIf TypeOf miControl Is HtmlGenericControl Then
                    traducirControl(miControl.Controls)
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub traducir(ByVal _menuitem As MenuItem)
        Try
            For Each MiPalabra As Entidades.Palabra In CType(Session("Idioma"), Entidades.Idioma).Palabras
                If UCase(MiPalabra.Codigo) = UCase(_menuitem.Value) Then
                    _menuitem.Text = MiPalabra.Traduccion
                    Exit For
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub traducir(ByVal _image As ImageButton)
        Try
            For Each MiPalabra As Entidades.Palabra In CType(Session("Idioma"), Entidades.Idioma).Palabras
                If UCase(MiPalabra.Codigo) = UCase(_image.ID) Then
                    _image.ImageUrl = MiPalabra.Traduccion
                    Exit For
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub traducir(ByVal _radio As RadioButton)
        Try
            For Each MiPalabra As Entidades.Palabra In CType(Session("Idioma"), Entidades.Idioma).Palabras
                If UCase(MiPalabra.Codigo) = UCase(_radio.ID) Then
                    _radio.Text = MiPalabra.Traduccion
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub traducir(ByVal _label As Label)
        Try
            For Each MiPalabra As Entidades.Palabra In CType(Session("Idioma"), Entidades.Idioma).Palabras
                If UCase(MiPalabra.Codigo) = UCase(_label.ID) Then
                    _label.Text = MiPalabra.Traduccion
                    Exit For
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub traducir(ByVal _button As Button)
        Try
            For Each MiPalabra As Entidades.Palabra In CType(Session("Idioma"), Entidades.Idioma).Palabras
                If UCase(MiPalabra.Codigo) = UCase(_button.ID) Then
                    _button.Text = MiPalabra.Traduccion
                    Exit For
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub traducir(ByVal _checkbox As CheckBox)
        Try
            For Each MiPalabra As Entidades.Palabra In CType(Session("Idioma"), Entidades.Idioma).Palabras
                If UCase(MiPalabra.Codigo) = UCase(_checkbox.ID) Then
                    _checkbox.Text = MiPalabra.Traduccion
                    Exit For
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub traducir(ByVal _linkbutton As LinkButton)
        Try
            For Each MiPalabra As Entidades.Palabra In CType(Session("Idioma"), Entidades.Idioma).Palabras
                If UCase(MiPalabra.Codigo) = UCase(_linkbutton.ID) Then
                    _linkbutton.Text = MiPalabra.Traduccion
                    Exit For
                End If
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub traducir(ByVal MiGridView As GridView)
        Try
            Dim indice As Integer = 0
            For Each MiColumna As Object In MiGridView.Columns
                indice += 1
            Next
            For x As Integer = 0 To indice - 1
                For Each MiPalabra As Entidades.Palabra In CType(Session("Idioma"), Entidades.Idioma).Palabras
                    If MiGridView.Rows.Count > 0 Then
                        'Revisar aca, es headerRow???? No me cierra
                        If UCase(MiPalabra.Codigo) = UCase(MiGridView.HeaderRow.Cells(x).Text) Then
                            MiGridView.HeaderRow.Cells(x).Text = MiPalabra.Traduccion
                        End If
                    End If
                Next
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lkLogOut_Click(sender As Object, e As EventArgs)
        Try
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Logout, DirectCast(Session("Usuario"), Entidades.Usuario), 150))
            Session("Usuario") = Nothing
            Session("Carrito_Compras") = Nothing
            Session.Contents.RemoveAll()
            Response.Redirect("Index.aspx", False)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As Exception

        End Try

    End Sub
#End Region


    Public Function ConvertirAImagen() As System.Drawing.Image
        Dim imageBytes As Byte()
        imageBytes = Convert.FromBase64String(DirectCast(Session("Usuario"), Entidades.Usuario).ImagenUsuario)

        Dim ms As New System.IO.MemoryStream(imageBytes, 0, imageBytes.Length)
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim imagen As System.Drawing.Image
        imagen = System.Drawing.Image.FromStream(ms, True)
        Return imagen
    End Function

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs)

    End Sub
End Class