Imports Microsoft.VisualBasic

Public Class adv_string
    Public Function sentence_case(ByVal value) As String
        Dim hd_str As String = value
        Try

            hd_str = hd_str.ToLower
            hd_str = hd_str.Substring(0, 1).ToUpper + hd_str.Substring(1, hd_str.Length - 1)
            Dim find_ar() As Char = {" ", ",", "."}
            Dim pos As Integer
            pos = hd_str.IndexOfAny(find_ar, 1)
            While pos > 0
                hd_str = hd_str.Substring(0, pos + 1) + hd_str.Substring(pos + 1, 1).ToUpper + hd_str.Substring(pos + 2, hd_str.Length - pos - 2)
                pos = hd_str.IndexOfAny(find_ar, pos + 1)
            End While

        Catch ex As Exception

        End Try
        Return hd_str
    End Function
End Class
