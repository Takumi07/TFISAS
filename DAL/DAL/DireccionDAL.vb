Public Class DireccionDAL

    Public Sub Alta(ByVal paramDireccion As Entidades.Direccion)
        Try
            Dim MisParametros As New Hashtable
            paramDireccion.ID = Conexion.ObtenerID("Direccion", "ID_Direccion")
            MisParametros.Add("@ID_Direccion", paramDireccion.ID)
            MisParametros.Add("@Altura", paramDireccion.Altura)
            MisParametros.Add("@Calle", paramDireccion.Calle)
            MisParametros.Add("@CodigoPostal", paramDireccion.CodigoPostal)
            MisParametros.Add("@Departamento", paramDireccion.Departamento)
            MisParametros.Add("@Localidad", paramDireccion.Localidad)
            MisParametros.Add("@Piso", paramDireccion.Piso)
            MisParametros.Add("@ID_Provincia", paramDireccion.Provincia.ID)
            MisParametros.Add("@DVH", DVDAL.CalcularDVH(paramDireccion.DVH))
            DAL.Conexion.ExecuteNonQuery("AltaDireccion ", MisParametros)
            DVDAL.CalcularDVV("Direccion")
        Catch ex As Exception

        End Try
    End Sub



    Public Function ObtenerDireccion(ByVal paramID As Integer) As Entidades.Direccion
        Try
            Dim misParametros As New Hashtable
            Dim MiDireccion As New Entidades.Direccion
            Dim miDataTable As New DataTable
            misParametros.Add("@ID_Direccion", paramID)
            miDataTable = Conexion.Leer("ListarUnaDireccion", misParametros)
            If miDataTable.Rows.Count > 0 Then
                FormatearDireccion(miDataTable.Rows(0), MiDireccion)
                Return MiDireccion
            Else
                Return Nothing
            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub FormatearDireccion(ByVal paramDataRow As DataRow, paramDireccion As Entidades.Direccion)
        paramDireccion.ID = paramDataRow("ID_Direccion")
        paramDireccion.Altura = paramDataRow("Altura")
        paramDireccion.Calle = paramDataRow("Calle")
        paramDireccion.CodigoPostal = paramDataRow("CodigoPostal")
        paramDireccion.Departamento = paramDataRow("Departamento")
        paramDireccion.Localidad = paramDataRow("Localidad")
        paramDireccion.Piso = paramDataRow("Piso")
        paramDireccion.Provincia = (New DAL.ProvinciaDAL).ObtenerProvincia(paramDataRow("ID_Provincia"))
    End Sub

End Class
