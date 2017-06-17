Imports System.Globalization
Public Class AgregarIdioma
    Inherits System.Web.UI.Page
    Dim _listaPalabras As New List(Of Entidades.Palabra)
    Dim _listaNuevaPalabras As New List(Of Entidades.Palabra)




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session("Idioma") = (New BLL.IdiomaBLL(Session("Usuario"))).Cargar(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma)
            _listaPalabras = DirectCast(Session("Idioma"), Entidades.Idioma).Palabras
            If Not IsPostBack Then
                cargarGridView()
                CargarCulturas()
                Dim Context As HttpContext = HttpContext.Current
                If Context.Items.Contains("IdiomaaEditar") Then
                    Dim _IdiomaaEditar As New Entidades.Idioma
                    _IdiomaaEditar = DirectCast(Context.Items("IdiomaaEditar"), Entidades.Idioma)
                    cargarDatos(_IdiomaaEditar)
                    Session("IdiomaaEditar") = _IdiomaaEditar
                    'Traducir esto para que funcione bien
                    'lbl_AgregarIdioma.Text = "Modificar Idioma" 'Codigo de Traducción: lbl_ModificarIdioma
                    lbl_AgregarIdioma.Text = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 19)
                End If
                Session("listaNuevaPalabras") = _listaNuevaPalabras
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


    Private Sub CargarCulturas()
        Try
            ddl_cultura.DataSource = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures)
            ddl_cultura.DataTextField = "NativeName"
            ddl_cultura.DataValueField = "Name"
            ddl_cultura.DataBind()
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub



    Private Sub cargarDatos(ByVal paramIdioma As Entidades.Idioma)
        Try
            Me.txt_NombreIdioma.Text = paramIdioma.Nombre
            Me.txt_NombreIdioma.ReadOnly = True
            'Aca falta cargarle la cultura que tiene
            ddl_cultura.Items.FindByText(paramIdioma.Cultura.NativeName).Selected = True
            For Each pal As Entidades.Palabra In paramIdioma.Palabras
                For Each row As GridViewRow In Me.gv_Palabras.Rows
                    If pal.Codigo = row.Cells(1).Text Then
                        If row.Cells(3).HasControls() = True Then
                            For Each micontrol As Control In row.Cells(3).Controls
                                If TypeOf (micontrol) Is TextBox Then
                                    DirectCast(micontrol, TextBox).Text = pal.Traduccion
                                End If
                            Next
                        End If
                    End If
                Next
            Next
            Me.Aceptar.Visible = False
            Me.modificar.Visible = True

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




    Private Sub cargarGridView()
        Try
            'Para probar, sacar
            Session("Idioma") = (New BLL.IdiomaBLL(Session("Usuario"))).Cargar(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma)
            If Not IsNothing(Session("Idioma")) Then
                Me.gv_Palabras.DataSource = DirectCast(Session("Idioma"), Entidades.Idioma).Palabras
                Me.gv_Palabras.DataBind()
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




    Private Sub guardarPalabras()
        Try
            Dim _listaPalabrasNueva As List(Of Entidades.Palabra) = DirectCast(Session("listaNuevaPalabras"), List(Of Entidades.Palabra))
            For Each _row As GridViewRow In Me.gv_Palabras.Rows
                Dim _palabra As New Entidades.Palabra
                _palabra.ID_Control = CInt(_row.Cells(0).Text)
                _palabra.Codigo = _row.Cells(1).Text
                If _row.Cells(3).HasControls() = True Then
                    For Each micontrol As Control In _row.Cells(3).Controls
                        If TypeOf (micontrol) Is TextBox Then
                            'LO TIENE QUE GRABAR SI NO ESTA CARGADA LA PALABRA, SI ESTA LA DEBERIA REEMPLAZAR
                            If Not _listaPalabrasNueva.Contains(_palabra) Then
                                If Not DirectCast(micontrol, TextBox).Text = "" Then
                                    _palabra.Traduccion = Trim(DirectCast(micontrol, TextBox).Text)
                                    DirectCast(Session("listaNuevaPalabras"), List(Of Entidades.Palabra)).Add(_palabra)
                                End If
                            End If
                        End If
                    Next
                End If
            Next

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

    Private Sub obtenerPalabras()
        Try
            Dim _listaPalabrasnuevas As List(Of Entidades.Palabra)
            If Session("IdiomaaEditar") Is Nothing Then
                _listaPalabrasnuevas = DirectCast(Session("listanuevaPalabras"), List(Of Entidades.Palabra))
            Else
                _listaPalabrasnuevas = DirectCast(Session("IdiomaaEditar"), Entidades.Idioma).Palabras
            End If
            For Each pal As Entidades.Palabra In _listaPalabrasnuevas
                For Each row As GridViewRow In Me.gv_Palabras.Rows
                    If pal.Codigo = row.Cells(1).Text Then
                        If row.Cells(3).HasControls() = True Then
                            For Each micontrol As Control In row.Cells(3).Controls
                                If TypeOf (micontrol) Is TextBox Then
                                    DirectCast(micontrol, TextBox).Text = pal.Traduccion
                                End If
                            Next
                        End If
                    End If
                Next
            Next
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub gv_Palabras_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            guardarPalabras()
            Me.gv_Palabras.DataSource = _listaPalabras
            gv_Palabras.PageIndex = e.NewPageIndex
            gv_Palabras.DataBind()
            obtenerPalabras()
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
            Me.divError.Visible = False
            Dim ddl As DropDownList = CType(gv_Palabras.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Palabras.SetPageIndex(ddl.SelectedIndex)
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub


    Private Sub gv_Palabras_DataBound(sender As Object, e As EventArgs) Handles gv_Palabras.DataBound
        Try
            Dim ddl As DropDownList = CType(gv_Palabras.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            For cnt As Integer = 0 To gv_Palabras.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Palabras.PageIndex Then
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

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            Response.Redirect("administrarIdiomas.aspx")
        Catch ex As System.Data.SqlClient.SqlException
            Session("SQLERROR") = ex.Message
            Response.Redirect("Mensajes.aspx", False)
        Catch ex As BLL.ExcepcionGenerica
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Try
            Validaciones.validarSubmit(Me, Me.divError, Me.lblMensajeError)
            Dim MiIdiomaEntidad As New Entidades.Idioma
            Dim MiIdiomaBLL As New BLL.IdiomaBLL(Session("Usuario"))
            MiIdiomaEntidad.Nombre = Me.txt_NombreIdioma.Text
            If MiIdiomaBLL.chequearNombreIdioma(MiIdiomaEntidad) = True Then
                Throw New BLL.IdiomaDuplicadoException
            Else
                MiIdiomaEntidad.Cultura = CultureInfo.GetCultureInfo(ddl_cultura.SelectedValue)
                guardarPalabras()
                MiIdiomaEntidad.Palabras = DirectCast(Session("listaNuevaPalabras"), List(Of Entidades.Palabra))
                For Each _palabra As Entidades.Palabra In _listaPalabras
                    If Not MiIdiomaEntidad.Palabras.Contains(_palabra) Then
                        MiIdiomaEntidad.Palabras.Add(_palabra)
                    End If
                Next
                MiIdiomaBLL.altaIdioma(MiIdiomaEntidad)

                'Aviso por mensaje que todo salio bien
                'Poner el codigo de mensaje a traducir
                Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 20) '20
                Session("Redirect") = "administrarIdiomas.aspx"
                Response.Redirect("Mensajes.aspx", False)
            End If

        Catch ex As BLL.CamposincompletosException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
        Catch ex As BLL.IdiomaDuplicadoException
            Me.divError.Visible = True
            Me.lblMensajeError.Text = ex.Mensaje(Session("Usuario"))
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

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            Dim _idioma As New Entidades.Idioma
            Dim _bllidioma As New BLL.IdiomaBLL(Session("Usuario"))
            _idioma.ID = DirectCast(Session("IdiomaaEditar"), Entidades.Idioma).ID
            _idioma.Nombre = DirectCast(Session("IdiomaaEditar"), Entidades.Idioma).Nombre
            _idioma.Editable = DirectCast(Session("IdiomaaEditar"), Entidades.Idioma).Editable
            _idioma.Cultura = CultureInfo.GetCultureInfo(ddl_cultura.SelectedValue)
            guardarPalabras()
            _idioma.Palabras = DirectCast(Session("listaNuevaPalabras"), List(Of Entidades.Palabra))
            For Each _palabra As Entidades.Palabra In _listaPalabras
                If Not _idioma.Palabras.Contains(_palabra) Then
                    _idioma.Palabras.Add(_palabra)
                End If
            Next
            _bllidioma.modificarIdioma(_idioma)

            'Aca poner el codigo de la traudcciòn del mensaje
            Session("Mensaje") = BLL.IdiomaBLL.traducirMensaje(DirectCast(Session("Usuario"), Entidades.Usuario).Idioma, 21) '21
            Session("Redirect") = "administrarIdiomas.aspx"
            Response.Redirect("Mensajes.aspx", False)

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
End Class