Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.ComponentModel
Public Class EncriptadoraBLL
    Dim MiUsuarioEntidad As New Entidades.Usuario

    Sub New()

    End Sub

    Sub New(ByVal paramUsuarioEntidad As Entidades.Usuario)
        MiUsuarioEntidad = paramUsuarioEntidad
    End Sub


    ''' <summary>Encripta la Password</summary><param name="Texto">Password del Usuario</param>
    Public Shared Function EncriptarPass(ByVal Texto As String) As String
        Try
            Dim MiMD5 As MD5 = MD5CryptoServiceProvider.Create()
            Dim MiData As Byte() = MiMD5.ComputeHash(Encoding.Default.GetBytes(Texto))
            Dim MiStringBuilder As StringBuilder = New StringBuilder()
            For i As Integer = 0 To MiData.Length - 1
                MiStringBuilder.AppendFormat("{0:x2}", MiData(i))
            Next
            Return MiStringBuilder.ToString.ToUpper
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>Encripta un texto que puede ser desencriptado</summary> <param name="paramTexto">Texto a encriptar</param>
    Public Shared Function Encriptar(ByVal paramTexto As String) As String
        Dim MiCipherMode As CipherMode = CipherMode.ECB
        Dim MiClave As String = "ALEXIS"
        Try
            Dim MiDES As New TripleDESCryptoServiceProvider
            Dim InputbyteArray() As Byte = Encoding.Default.GetBytes(paramTexto)
            Dim MihashMD5 As New MD5CryptoServiceProvider
            MiDES.Key = MihashMD5.ComputeHash(Encoding.Default.GetBytes(MiClave))
            MiDES.Mode = MiCipherMode
            Dim MiMemoryStream As MemoryStream = New MemoryStream
            Dim MiCryptoStream As CryptoStream = New CryptoStream(MiMemoryStream, MiDES.CreateEncryptor(), CryptoStreamMode.Write)
            MiCryptoStream.Write(InputbyteArray, 0, InputbyteArray.Length)
            MiCryptoStream.FlushFinalBlock()
            Dim MiStringBuilder As StringBuilder = New StringBuilder
            Dim MiMemoryToArray() As Byte = MiMemoryStream.ToArray
            MiMemoryStream.Close()
            Dim I As Integer
            For I = 0 To UBound(MiMemoryToArray)
                MiStringBuilder.AppendFormat("{0:X2}", MiMemoryToArray(I))
            Next
            Return MiStringBuilder.ToString
        Catch ex As System.Security.Cryptography.CryptographicException
            Throw ex
        End Try
    End Function

    ''' <summary>Desencripta un valor encriptado con anterioridad</summary><param name="paramTexto">Texto Encriptado</param>
    Public Shared Function Desencriptar(ByVal paramTexto As String) As String
        Dim MiCipherMode As CipherMode = CipherMode.ECB
        Dim MiClave As String = "ALEXIS"
        Try
            If paramTexto = String.Empty Then
                Return ""
            Else
                Dim MiDES As New TripleDESCryptoServiceProvider
                Dim InputbyteArray(CType(paramTexto.Length / 2 - 1, Integer)) As Byte
                Dim MihashMD5 As New MD5CryptoServiceProvider
                MiDES.Key = MihashMD5.ComputeHash(Encoding.Default.GetBytes(MiClave))
                MiDES.Mode = MiCipherMode
                Dim X As Integer
                For X = 0 To InputbyteArray.Length - 1
                    Dim IJ As Int32 = (Convert.ToInt32(paramTexto.Substring(X * 2, 2), 16))
                    Dim BT As New ByteConverter
                    InputbyteArray(X) = New Byte
                    InputbyteArray(X) = CType(BT.ConvertTo(IJ, GetType(Byte)), Byte)
                Next
                Dim MiMemoryStream As MemoryStream = New MemoryStream
                Dim MiCryptoStream As CryptoStream = New CryptoStream(MiMemoryStream, MiDES.CreateDecryptor(), CryptoStreamMode.Write)
                MiCryptoStream.Write(InputbyteArray, 0, InputbyteArray.Length)
                MiCryptoStream.FlushFinalBlock()
                Dim MiStringBuilder As StringBuilder = New StringBuilder
                Dim MiMemoryToArray() As Byte = MiMemoryStream.ToArray
                MiMemoryStream.Close()
                Dim I As Integer
                For I = 0 To UBound(MiMemoryToArray)
                    MiStringBuilder.Append(Chr(MiMemoryToArray(I)))
                Next
                Return MiStringBuilder.ToString
            End If
        Catch ex As System.Security.Cryptography.CryptographicException
            Throw ex
        End Try
    End Function



    Public Shared Function GenerarPassword() As String
        Try
            Dim length As Integer = 8
            Dim guidResult As String = System.Guid.NewGuid().ToString()
            guidResult = guidResult.Replace("-", String.Empty)
            Return UCase(guidResult.Substring(0, length))
        Catch ex As Exception
            Throw New BLL.ExcepcionGenerica
        End Try
    End Function


    '/**************************Revisar Si Me Sirven Como Están*********************************************/
    Public Shared Sub EncriptarArchivo(ByVal paramRutaArchivoEntrada As String, ByVal paramRutaArchivoSalida As String)
        Try
            Dim MiClave As String = "Password"
            Dim MiFileStreamEntrada As New FileStream(paramRutaArchivoEntrada, FileMode.Open, FileAccess.Read)
            Dim MiFileStreamSalida As New FileStream(paramRutaArchivoSalida, FileMode.Create, FileAccess.Write)

            Dim MiDES As New DESCryptoServiceProvider()

            'Establecer la clave secreta para el algoritmo DES.
            'Se necesita una clave de 64 bits y IV para este proveedor
            MiDES.Key = ASCIIEncoding.ASCII.GetBytes(MiClave)

            'Establecer el vector de inicialización.
            MiDES.IV = ASCIIEncoding.ASCII.GetBytes(MiClave)

            'crear cifrado DES a partir de esta instancia
            Dim MiCrearEncriptador As ICryptoTransform = MiDES.CreateEncryptor()
            'Crear una secuencia de cifrado que transforma la secuencia
            'de archivos mediante cifrado DES
            Dim MiCryptoStream As New CryptoStream(MiFileStreamSalida, MiCrearEncriptador, CryptoStreamMode.Write)

            'Leer el texto del archivo en la matriz de bytes
            Dim bytearrayinput(MiFileStreamEntrada.Length - 1) As Byte
            MiFileStreamEntrada.Read(bytearrayinput, 0, bytearrayinput.Length)
            'Escribir el archivo cifrado con DES
            MiCryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length)
            MiCryptoStream.Close()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Shared Sub DesencriptarArchivo(ByVal paramRutaArchivoEntrada As String, ByVal paramRutaArchivoSalida As String)
        Try
            Dim MiClave As String = "Password"
            Dim MiDES As New DESCryptoServiceProvider()

            'Establecer la clave secreta para el algoritmo DES.
            MiDES.Key() = ASCIIEncoding.ASCII.GetBytes(MiClave)
            'Establecer el vector de inicialización.
            MiDES.IV = ASCIIEncoding.ASCII.GetBytes(MiClave)

            'crear la secuencia de archivos para volver a leer el archivo cifrado
            Dim MiFileStreamEntrada As New FileStream(paramRutaArchivoEntrada, FileMode.Open, FileAccess.Read)
            'crear descriptor DES a partir de nuestra instancia de DES
            Dim MiCrearEncriptador As ICryptoTransform = MiDES.CreateDecryptor()
            'crear conjunto de secuencias de cifrado para leer y realizar una transformación de descifrado DES en los bytes entrantes
            Dim MiCryptoStream As New CryptoStream(MiFileStreamEntrada, MiCrearEncriptador, CryptoStreamMode.Read)
            'imprimir el contenido de archivo descifrado
            Dim MiStreamWriter As New StreamWriter(paramRutaArchivoSalida)
            MiStreamWriter.Write(New StreamReader(MiCryptoStream).ReadToEnd)
            MiStreamWriter.Flush()
            MiStreamWriter.Close()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub




End Class
