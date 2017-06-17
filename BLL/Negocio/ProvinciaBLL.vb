Public Class ProvinciaBLL

    Public Function ListarProvincias() As List(Of Entidades.Provincia)
        Try
            Return (New DAL.ProvinciaDAL).ListarProvincias
        Catch ex As Exception

        End Try
    End Function



    Public Function ObtenerProvincia(ByVal paramID As Integer) As Entidades.Provincia
        Try
            Return (New DAL.ProvinciaDAL).ObtenerProvincia(paramID)
        Catch ex As Exception

        End Try
    End Function

End Class
