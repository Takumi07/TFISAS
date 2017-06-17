Imports Entidades

Public Class PermisosDAL

#Region "Stored Listos"

#Region "Select"
    Public Function listarFamilias(ByVal paramFiltro As Boolean) As List(Of Entidades.PermisoBase)
        Try
            Dim miListaFamilias As New List(Of Entidades.PermisoBase)
            Dim misParametros As New Hashtable
            If paramFiltro = True Then
                misParametros.Add("@accion", 0)
            Else
                misParametros.Add("@accion", DBNull.Value)
            End If
            Dim miDataTable As DataTable = DAL.Conexion.Leer("listarFamiliasFiltro", misParametros)
            For Each miDataRow As DataRow In miDataTable.Rows
                Dim miPermisoBase As Entidades.PermisoBase = formatearPermiso(miDataRow)
                miListaFamilias.Add(miPermisoBase)
            Next
            Return miListaFamilias
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>Me lista incluso el perfil eliminado</summary>
    Public Function listarFamilias() As List(Of Entidades.PermisoCompuesto)
        Try
            Dim miListaFamilias As New List(Of Entidades.PermisoCompuesto)
            Dim misParametros As New Hashtable
            misParametros.Add("@accion", 0)
            Dim miDataTable As DataTable = DAL.Conexion.Leer("listarFamilias", misParametros)
            For Each miDataRow As DataRow In miDataTable.Rows
                Dim miPermisoBase As Entidades.PermisoBase = formatearPermiso(miDataRow)
                miListaFamilias.Add(miPermisoBase)
            Next
            Return miListaFamilias
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function listarFamilias(ByVal paramPermiso As Entidades.PermisoBase) As Entidades.PermisoCompuesto
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IdPatente", paramPermiso.ID)
            Dim miDataTable As DataTable = DAL.Conexion.Leer("listarFamiliasID", MisParametros)
            If miDataTable.Rows.Count = 1 Then
                Return formatearPermiso(miDataTable.Rows(0))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function listarFamilias(paramID As Integer) As Entidades.PermisoCompuesto
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IdPatente", paramID)
            Dim _dt As DataTable = DAL.Conexion.Leer("listarFamiliasID", MisParametros)
            If _dt.Rows.Count = 1 Then
                Return formatearPermiso(_dt.Rows(0))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function ListarHijos(ByVal paramPermiso As PermisoBase) As List(Of Entidades.PermisoBase)
        Try
            Dim miListaPermisoBase As List(Of Entidades.PermisoBase) = New List(Of Entidades.PermisoBase)
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IDFamilia", paramPermiso.ID)
            Dim dt As DataTable = DAL.Conexion.Leer("ListarHijos", MisParametros)
            For Each miDataRow As DataRow In dt.Rows
                Dim MiPermiso As Entidades.PermisoBase = formatearPermiso(miDataRow)
                miListaPermisoBase.Add(MiPermiso)
            Next
            Return miListaPermisoBase
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region



#Region "ABM"
    Public Sub AltaPermiso(paramPermiso As Entidades.PermisoBase)
        Try
            Dim MiID As Integer = Conexion.ObtenerID("Patente", "ID_Patente")
            'Me guardo el id para el prototipo
            paramPermiso.ID = MiID
            If paramPermiso.tieneHijos = True Then
                Dim MiBool As Boolean
                MiBool = False
                Dim MisParametros As New Hashtable
                MisParametros.Add("@ID_Patente", MiID)
                MisParametros.Add("@Nombre", paramPermiso.Nombre)
                MisParametros.Add("@URL", DBNull.Value)
                MisParametros.Add("@esAccion", MiBool)
                'DVH
                Dim dvh As String = MiID & paramPermiso.Nombre & DBNull.Value & MiBool
                MisParametros.Add("@DVH", DVDAL.CalcularDVH(dvh))
                Conexion.ExecuteNonQuery("AltaPermisoPatente", MisParametros)

                For Each MiPermiso As Entidades.PermisoBase In paramPermiso.ObtenerHijos
                    Dim MisParametros2 As New Hashtable
                    MisParametros2.Add("@ID_Familia", MiID)
                    MisParametros2.Add("@ID_Patente", MiPermiso.ID)
                    'DVH
                    Dim dvhFP As String = MiID & MiPermiso.ID
                    MisParametros2.Add("@DVH", DVDAL.CalcularDVH(dvhFP))
                    Conexion.ExecuteNonQuery("AltaPermisoFamiliaPatente", MisParametros2)

                Next
            Else
                'Es un Permiso
                Dim MiBool As Boolean
                MiBool = True
                Dim MisParametros As New Hashtable
                MisParametros.Add("@ID_Patente", MiID)
                MisParametros.Add("@Nombre", paramPermiso.Nombre)
                MisParametros.Add("@URL", paramPermiso.URL)
                MisParametros.Add("@esAccion", MiBool)
                'DVH
                Dim dvh As String = MiID & paramPermiso.Nombre & DBNull.Value & MiBool
                MisParametros.Add("@DVH", DVDAL.CalcularDVH(dvh))
                DAL.Conexion.ExecuteNonQuery("AltaPermisoPatente", MisParametros)
            End If

            DAL.DVDAL.CalcularDVV("Patente")
            DAL.DVDAL.CalcularDVV("FamiliaPatente")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub BajaPermiso(ByVal paramPermisoBase As PermisoBase)
        Try
            'Quizá esto se podía hacer mas performante, pero al menos está en SP
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IDFamilia", paramPermisoBase.ID)
            DAL.Conexion.ExecuteNonQuery("BajaPermisoFamiliaPatenteFamilia", MisParametros)
            DAL.DVDAL.CalcularDVV("FamiliaPatente")


            Dim MisParametros2 As New Hashtable
            MisParametros2.Add("@IDFamilia", paramPermisoBase.ID)
            DAL.Conexion.ExecuteNonQuery("BajaPermisoFamiliaPatentePatente", MisParametros2)
            DAL.DVDAL.CalcularDVV("FamiliaPatente")



            Dim MisParametros3 As New Hashtable
            MisParametros3.Add("@IDPatente", paramPermisoBase.ID)
            DAL.Conexion.ExecuteNonQuery("BajaPermisoPatente", MisParametros3)
            DAL.DVDAL.CalcularDVV("Patente")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ModificarPermiso(paramPermiso As Entidades.PermisoBase)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@IDFamilia", paramPermiso.ID)
            DAL.Conexion.ExecuteNonQuery("BajaPermisoFamiliaPatenteFamilia", MisParametros)
            For Each MiPermiso As Entidades.PermisoBase In paramPermiso.ObtenerHijos
                Dim MisParametros2 As New Hashtable
                MisParametros2.Add("@ID_Familia", paramPermiso.ID)
                MisParametros2.Add("@ID_Patente", MiPermiso.ID)
                Dim dvhFP As String = paramPermiso.ID & MiPermiso.ID
                MisParametros2.Add("@DVH", DVDAL.CalcularDVH(dvhFP))
                If Not paramPermiso.ID = MiPermiso.ID Then
                    DAL.Conexion.ExecuteNonQuery("AltaPermisoFamiliaPatente", MisParametros2)
                End If
            Next

            DAL.DVDAL.CalcularDVV("Patente")
            DAL.DVDAL.CalcularDVV("FamiliaPatente")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#End Region











#Region "Formatear"
    Private Function formatearPermiso(ByVal paramDataRow As DataRow) As PermisoBase
        Try
            Dim miPermiso As Entidades.PermisoBase
            If Not paramDataRow.Item("esAccion") Is DBNull.Value AndAlso Convert.ToBoolean(paramDataRow.Item("esAccion")) Then
                miPermiso = New Entidades.PermisoSimple
            Else
                miPermiso = New Entidades.PermisoCompuesto
            End If
            miPermiso.ID = CInt(paramDataRow.Item("Id_Patente"))
            miPermiso.Nombre = Convert.ToString(paramDataRow.Item("Nombre"))
            miPermiso.URL = paramDataRow.Item("URL").ToString
            If miPermiso.tieneHijos Then
                Dim ListaHijos As List(Of Entidades.PermisoBase) = Me.ListarHijos(miPermiso)
                For Each hijo As Entidades.PermisoBase In ListaHijos
                    miPermiso.agregarHijo(hijo)
                Next
            End If
            Return miPermiso
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Public Function chequearNombrePermiso(paramNombrePermiso As String) As Boolean
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@Nombre", paramNombrePermiso)
            Dim _dt As DataTable = DAL.Conexion.Leer("obtenerIDPermiso", MisParametros)
            If _dt.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
