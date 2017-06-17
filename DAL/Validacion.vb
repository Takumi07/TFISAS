Public Class Validacion
    Public Shared Function CompararString(ByVal paramValor As Object) As String
        If IsDBNull(paramValor) Then
            Return ""
        Else
            'Intenta convertir, si no puede devuelve nothin
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
            If TypeOf paramValor Is DateTime Then
                Return Convert.ToDateTime(paramValor)
            Else
                Return Nothing
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
End Class
