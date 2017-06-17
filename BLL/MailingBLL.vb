﻿Imports System.IO
Public Class MailingBLL


    Public Shared Sub enviarMailRegistroUsuario(ByVal paramUsuario As Entidades.Usuario, ByVal passgenerada As String)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.IsBodyHtml = True
            Correo.From = New System.Net.Mail.MailAddress("shigamianimestore@gmail.com", "Shigami Anime Store")
            Correo.To.Add(paramUsuario.Correo)
            Correo.Subject = "Shigami Anime Store - Registro de Usuario"
            Correo.Body = "<html><head> </head><body><img src=""http://i61.tinypic.com/2moqwb4.png"" width=""50px"" height=""50px"" /><b> " &
            " Registro de Usuario</b><hr " &
            " style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " &
            " <br /> <br /><span><b> Estimado Usuario:  <br/> Se registró al nuevo usuario  " & paramUsuario.NombreUsuario & " en nuestro sistema. <br />Su clave de acceso es <strong>" & passgenerada & "</strong>. Por favor, no olvide cambiar la misma al ingresar al Sistema. <br/> Saluda Atte. <br/><br/> Shigami Anime Store <br/>  </span><p>  &nbsp;</p><p>   &nbsp;</p><hr " &
            "style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " &
            " </body></html> "
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("shigamianimestore@gmail.com", BLL.EncriptadoraBLL.Desencriptar("0D4053E7DB1441AB9C58D29E63FE16C0"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Shared Sub enviarMailRecupero(ByVal _paramUsuario As Entidades.Usuario, passgenerada As String)
        Try


            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.IsBodyHtml = True
            Correo.From = New System.Net.Mail.MailAddress("shigamianimestore@gmail.com", "Shigami Anime Store")
            Correo.To.Add(_paramUsuario.Correo)
            Correo.Subject = "Shigami Anime Store - Recupero de Contraseña"
            Correo.Body = "<html><head> </head><body><img src=""http://i61.tinypic.com/2moqwb4.png"" width=""50px"" height=""50px"" /><b> " &
                " Recupero de Contraseña</b><hr " &
                " style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " &
                " <br /> <br /><span><b> Estimado Usuario: <br/> Se envía su nueva contraseña para acceder con su usuario " & _paramUsuario.NombreUsuario & " en nuestro sistema. <br />Su nueva clave de acceso es <strong>" & passgenerada & "</strong>. Por favor, no olvide cambiar la misma al ingresar al Sistema. <br/> Saluda Atte. <br/><br/>Shigami Anime Store<br/>  </span><p>  &nbsp;</p><p>   &nbsp;</p><hr " &
                "style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " &
                " </body></html> "
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("shigamianimestore@gmail.com", BLL.EncriptadoraBLL.Desencriptar("0D4053E7DB1441AB9C58D29E63FE16C0"))
            smtp.EnableSsl = True


            'Antes del Send, guardo en algo.    
            'Esto pincha seguro.
            Try
                Dim directorio As String
                directorio = System.Configuration.ConfigurationSettings.AppSettings("rutaerrores").Trim
                CrearDirectorio(directorio)

                Dim nombre As String
                nombre = DateTime.Now.Year & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & ".TXT"

                Using outputFile As New StreamWriter(directorio & Convert.ToString(nombre))
                    outputFile.WriteLine("Remitente: " & Correo.From.ToString)
                    outputFile.WriteLine("Destinatario: " & Correo.To.ToString)
                    outputFile.WriteLine("Asunto: " & Correo.Subject)
                    outputFile.WriteLine("Cuerpo: " & Correo.Body)
                End Using

            Catch ex As Exception
                Return
            End Try
            smtp.Send(Correo)


        Catch ex As Exception
            Return
        End Try
    End Sub



    Public Shared Sub CrearDirectorio(ByVal paramPath As String)
        Try
            Dim MiDirectorio As DirectoryInfo = New DirectoryInfo(paramPath)
            If Not MiDirectorio.Exists Then
                MiDirectorio.Create()
            End If

        Catch ex As BLL.ExcepcionGenerica
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Public Shared Sub enviarMailBloqueado(ByVal _paramUsuario As Entidades.Usuario)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.IsBodyHtml = True
            Correo.From = New System.Net.Mail.MailAddress("shigamianimestore@gmail.com", "Shigami Anime Store")
            Correo.To.Add(_paramUsuario.Correo)
            Correo.Subject = "Shigami Anime Store - Usuario Bloqueado"
            Correo.Body = "<html><head> </head><body><img src=""http://i61.tinypic.com/2moqwb4.png"" width=""50px"" height=""50px"" /><b> " &
            " Usuario Bloqueado</b><hr " &
            " style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #003366;"" /> " &
            " <br /> <br /><span><b> Estimado Usuario:  el usuario  " & _paramUsuario.NombreUsuario & " fue Bloqueado por razones de Seguridad. Para activarlo nuevamente comuniquese con el Administrador.<br/> Saluda Atte. <br/><br/> Shigami Anime Store<br/></span><p>  &nbsp;</p><p>   &nbsp;</p><hr " &
            "style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #003366;"" /> " &
            " </body></html> "
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("shigamianimestore@gmail.com", BLL.EncriptadoraBLL.Desencriptar("0D4053E7DB1441AB9C58D29E63FE16C0"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class
