Public Class ClienteBLL
    Dim MiClienteDAL As New DAL.ClienteDAL

#Region "ABML"


    Public Sub NuevoCliente(ByVal paramClienteEntidad As Entidades.Cliente)
        Try
            Dim MiUsuarioBLL As New UsuarioBLL
            MiUsuarioBLL.Alta(paramClienteEntidad)
            MiClienteDAL.NuevoCliente(paramClienteEntidad)
            BLL.BitacoraBLL.RegistrarBitacoraAuditoria(New Entidades.BitacoraAuditoria(Entidades.BitacoraBase.tipoOperacionBitacora.Alta, paramClienteEntidad, 249))

        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Sub

    Public Sub EliminarCliente(ByVal paramClienteEntidad As Entidades.Cliente)

    End Sub

    Public Sub ModificarCliente(ByVal paramClienteEntidad As Entidades.Cliente)

    End Sub

    Public Function ListarClientesPorCondicion(ByVal paramCondicion As String) As List(Of Entidades.Cliente)

    End Function


    Public Function LoginCliente(ByVal paramUsuario As Entidades.Usuario) As Entidades.Cliente
        Try
            Return MiClienteDAL.LoginCliente(paramUsuario)
        Catch ex As BLL.ExcepcionGenerica
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        Catch ex As Exception
            BLL.BitacoraBLL.RegistrarBitacoraErrores(New Entidades.BitacoraErrores(ex.StackTrace, ex.GetType.ToString, ex.Message))
            Throw ex
        End Try
    End Function
#End Region




    Public Function CalcularIndiceCliente(ByVal paramClienteEntidad As Entidades.Cliente) As Integer
        Try
            Dim MiGenero As New Entidades.Genero
            Dim MiTipoProducto As New Entidades.TipoProducto
            Dim CantidadCompras As Integer
            Dim DiasTranscurridos As Integer

            'Preparar Datos para algoritmo. 
            MiGenero = Me.EvaluarHistorialGenero(paramClienteEntidad)
            MiTipoProducto = Me.EvaluarHistorialTProducto(paramClienteEntidad)

            'Obtención de datos
            CantidadCompras = Me.CalcularCantidadCompras(paramClienteEntidad, MiGenero, MiTipoProducto)
            DiasTranscurridos = Me.CantidadDiasRegistrado(paramClienteEntidad)


            Dim ValorObtenido As Double
            If DiasTranscurridos <= 0 Then
                ValorObtenido = 0
            Else
                ValorObtenido = (CantidadCompras / DiasTranscurridos)
            End If


            If ValorObtenido > 0 Or ValorObtenido <= 0.35 Then
                Return 5
            ElseIf ValorObtenido > 0.35 Or ValorObtenido <= 0.8 Then
                Return 10
            ElseIf valorobtenido > 0.8 Then
                Return 15
            End If
            Return 0
        Catch ex As Exception

        End Try
    End Function


    Public Function CalcularCantidadCompras(ByVal paramClienteEntidad As Entidades.Cliente, ByVal paramGeneroEntidad As Entidades.Genero, ByVal paramTipoProductoEntidad As Entidades.TipoProducto) As Integer
        Try
            Dim CantidadComprasGenero As Integer
            Dim CantidadComprasTipoProducto As Integer
            'Si esto es nothing, lo convierte a Cero?
            CantidadComprasGenero = MiClienteDAL.CantidadDeComprasPorGenero(paramGeneroEntidad, paramClienteEntidad)
            CantidadComprasTipoProducto = MiClienteDAL.CantidadDeComprasporTProducto(paramTipoProductoEntidad, paramClienteEntidad)
            Return CantidadComprasGenero + CantidadComprasTipoProducto
        Catch ex As Exception

        End Try
    End Function


    Public Function EvaluarHistorialTProducto(ByVal paramClienteEntidad As Entidades.Cliente) As Entidades.TipoProducto
        'programar este para evaluar historial cliente
        Try
            Dim MiTipoProducto As New Entidades.TipoProducto
            Dim MiFecha As Date
            'Me devuelve los últimos 4 meses
            MiFecha = DateAdd(DateInterval.Month, -4, DateTime.Now)
            MiTipoProducto = MiClienteDAL.EvaluarHistorialTProducto(paramClienteEntidad, MiFecha)
            If IsNothing(MiTipoProducto) Then
                'Ver si esta fecha levanta
                Dim MiFecha2 As New Date

                MiTipoProducto = MiClienteDAL.EvaluarHistorialTProducto(paramClienteEntidad, MiFecha2)
                If IsNothing(MiTipoProducto) Then
                    Return Nothing
                Else
                    Return MiTipoProducto
                End If

            Else
                Return MiTipoProducto
            End If
        Catch ex As Exception

        End Try


    End Function

    Public Function EvaluarHistorialGenero(ByVal paramClienteEntidad As Entidades.Cliente) As Entidades.Genero
        'programar este para evaluar historial cliente
        Try
            Dim MiGenero As New Entidades.Genero
            Dim MiFecha As Date
            'Me devuelve los últimos 4 meses
            MiFecha = DateAdd(DateInterval.Month, -4, DateTime.Now)
            MiGenero = MiClienteDAL.EvaluarHistorialGenero(paramClienteEntidad, MiFecha)
            If IsNothing(MiGenero) Then
                'Ver si esta fecha levanta
                Dim MiFecha2 As New Date
                MiGenero = MiClienteDAL.EvaluarHistorialGenero(paramClienteEntidad, MiFecha2)
                If IsNothing(MiGenero) Then
                    Return Nothing
                Else
                    Return MiGenero
                End If
            Else
                Return MiGenero
            End If
        Catch ex As Exception

        End Try
    End Function


    Public Function CantidadDiasRegistrado(ByVal paramClienteEntidad As Entidades.Cliente) As Integer
        Dim CantidadDíasregistrados As Integer = 0
        CantidadDiasRegistrado = DateDiff(DateInterval.Day, Date.Now, paramClienteEntidad.FechaAlta)
        Return CantidadDiasRegistrado
    End Function

End Class
