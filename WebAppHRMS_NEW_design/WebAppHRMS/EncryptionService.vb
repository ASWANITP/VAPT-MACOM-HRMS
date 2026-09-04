
Imports System.Windows.Input
Imports Org.BouncyCastle.Crypto.Engines
Imports Org.BouncyCastle.Crypto.Modes
Imports Org.BouncyCastle.Crypto.Parameters
Imports Org.BouncyCastle.Security


Public Class EncryptionService


    Private ReadOnly _keyString As String
    Private ReadOnly _aesKey As Byte()     ' 32 bytes (AES-256)
    Private ReadOnly _hmacKey As Byte()    ' 32 bytes (independent HMAC key)
    Dim cipher As New Org.BouncyCastle.Crypto.Modes.GcmBlockCipher(New Org.BouncyCastle.Crypto.Engines.AesEngine())
    Private ReadOnly keyBytes As Byte()
    Public Sub New()
        _keyString = "3F2A9C7B1D4E6F8A0B5C7D9E2F4A6C8D"
        ' Derive keys deterministically from the configured string
        keyBytes = Encoding.UTF8.GetBytes(_keyString)
    End Sub


    Public Function Decrypt(base64Input As String) As String
        ' Decode Base64 input
        Dim combined As Byte() = Convert.FromBase64String(base64Input)

        ' Extract IV (first 12 bytes)
        Dim ivLength As Integer = 12
        Dim iv As Byte() = New Byte(ivLength - 1) {}
        Array.Copy(combined, 0, iv, 0, ivLength)

        ' Ciphertext + tag (remaining bytes)
        Dim cipherPlusTagLength As Integer = combined.Length - ivLength
        Dim cipherPlusTag As Byte() = New Byte(cipherPlusTagLength - 1) {}
        Array.Copy(combined, ivLength, cipherPlusTag, 0, cipherPlusTagLength)

        ' AES-GCM tag length is 16 bytes
        Dim tagLengthBits As Integer = 128

        ' Setup AES-GCM parameters
        Dim parameters As New AeadParameters(New KeyParameter(keyBytes), tagLengthBits, iv, Nothing)

        ' Initialize AES-GCM cipher for decryption
        Dim cipher As New Org.BouncyCastle.Crypto.Modes.GcmBlockCipher(New AesEngine())
        cipher.Init(False, parameters)

        ' Decrypt
        Dim output As Byte() = New Byte(cipher.GetOutputSize(cipherPlusTag.Length) - 1) {}
        Dim len As Integer = cipher.ProcessBytes(cipherPlusTag, 0, cipherPlusTag.Length, output, 0)
        cipher.DoFinal(output, len)

        ' Convert plaintext to string
        Return Encoding.UTF8.GetString(output).TrimEnd(ChrW(0))
    End Function


    Public Function Encrypt(plainText As String) As String
        ' Convert plaintext to bytes
        Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(plainText)

        ' Generate random IV (12 bytes for AES-GCM)
        Dim ivLength As Integer = 12
        Dim iv As Byte() = New Byte(ivLength - 1) {}
        Dim rng As New SecureRandom()
        rng.NextBytes(iv)

        ' AES-GCM tag length is 16 bytes (128 bits)
        Dim tagLengthBits As Integer = 128

        ' Setup AES-GCM parameters
        Dim parameters As New AeadParameters(New KeyParameter(keyBytes), tagLengthBits, iv, Nothing)

        ' Initialize AES-GCM cipher for encryption
        Dim cipher As New GcmBlockCipher(New AesEngine())
        cipher.Init(True, parameters)

        ' Encrypt
        Dim output As Byte() = New Byte(cipher.GetOutputSize(inputBytes.Length) - 1) {}
        Dim len As Integer = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, output, 0)
        cipher.DoFinal(output, len)

        ' Combine IV + ciphertext+tag
        Dim combined As Byte() = New Byte(iv.Length + output.Length - 1) {}
        Array.Copy(iv, 0, combined, 0, iv.Length)
        Array.Copy(output, 0, combined, iv.Length, output.Length)

        ' Return Base64 string
        Return Convert.ToBase64String(combined)
    End Function



End Class
