﻿Public Class Validaciones
    Public Shared Sub validarSubmit(ByVal paramPage As Page, ByRef _txtError As HtmlGenericControl, ByRef _labelError As Label)
        paramPage.Validate()
        'Para mi esta al pedo el else... Porque siempre lo tengo visible false
        If Not paramPage.IsValid Then
            Throw New BLL.CamposincompletosException
            'Else
            '_txtError.Visible = False
            '_labelError.Text = ""
        End If
    End Sub



    Public Shared Function CompararString(ByVal paramValor As Object) As String
        If IsDBNull(paramValor) Then
            Return ""
        Else
            'Intenta convertir, si no puede devuelve nothing
            If TryCast(paramValor, String) = Nothing Then
                Return ""
            Else
                Return paramValor.ToString
            End If

        End If
    End Function

    Public Shared Function CompararInteger(ByVal paramValor As Object) As Integer
        If IsDBNull(paramValor) Then
            Return 0
        Else
            If Int64.TryParse(paramValor, 0) Then
                Return Integer.Parse(paramValor)
            Else
                Return 0
            End If
        End If
    End Function


    Public Shared Function CompararDatetime(ByVal paramValor As Object) As DateTime
        If IsDBNull(paramValor) Then
            Return Nothing
        Else
            If paramValor = "" Then
                Return Nothing
            Else
                Return Convert.ToDateTime(paramValor)
            End If
        End If
    End Function

    Public Shared Function CompararUlong(ByVal paramValor As Object) As ULong
        If IsDBNull(paramValor) Then
            Return 0
        Else

            If ULong.TryParse(paramValor, 0) Then
                Return ULong.Parse(paramValor)
            Else
                Return 0
            End If
        End If
    End Function

    Public Shared Function CompararBoolean(ByVal paramvalor As Object) As Boolean
        If IsDBNull(paramvalor) Then
            Return False
        Else
            If Boolean.TryParse(paramvalor, False) Then
                Return Boolean.Parse(paramvalor)
            Else
                Return False
            End If

        End If
    End Function


    Public Shared Function CompararDouble(ByVal paramvalor As Object) As Double
        If IsDBNull(paramvalor) Then
            Return 0.00
        Else
            If Double.TryParse(paramvalor, 0.00) Then
                Return paramvalor
            Else
                Return 0.00
            End If
        End If
    End Function

    Public Shared Function CompararDecimal(ByVal paramValor As Object) As Decimal
        If IsDBNull(paramValor) Then
            Return 0.00
        Else
            If Decimal.TryParse(paramValor, 0.00) Then
                Return Decimal.Parse(paramValor)
            Else
                Return 0.00
            End If
        End If
    End Function

    Public Shared Function CompararByte(ByVal paramValor As Object) As Byte
        If IsDBNull(paramValor) Then
            Return 0
        Else

            If Byte.TryParse(paramValor, 0) Then
                Return Byte.Parse(paramValor)
            Else
                Return 0
            End If
        End If
    End Function




    Public Shared Function ConvertirBase64(ByVal paramFileUpload As FileUpload) As String
        If paramFileUpload.PostedFile.ContentLength <> 0 Then
            Return Convert.ToBase64String(paramFileUpload.FileBytes)
        Else
            Return ""
        End If
    End Function


    Public Shared Function DevolverUnaImagenProducto(ByVal paramProducto As Entidades.Producto) As String
        If paramProducto.ListaImagenes.Count > 0 Then
            Return "data:image/png;base64," & paramProducto.ListaImagenes(0)
        Else
            Return "data:image/png;base64,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"
        End If

    End Function


End Class
