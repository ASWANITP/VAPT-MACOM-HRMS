Imports Microsoft.VisualBasic
Namespace Main_BLL
    Public Class Main_BLL
        Dim main_subd As New Main_DAL.DAL.Main_DAL
        Public Function fill_date(ByVal brno As String) As Data.DataTable
            If brno = "" Then
                Dim dt As New Data.DataTable
                Return dt
            Else
                Return main_subd.get_date(CInt(brno))
            End If
        End Function
    End Class
End Namespace