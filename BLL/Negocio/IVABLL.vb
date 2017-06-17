Public Class IVABLL
    Dim MiIVADAL As New DAL.IVADAL
    Public Function ListarIVA() As List(Of Entidades.IVA)
        Try
            Return (New DAL.IVADAL).ListarIVA
        Catch ex As Exception

        End Try
    End Function

End Class
