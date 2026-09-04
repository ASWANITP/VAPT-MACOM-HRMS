Imports Microsoft.VisualBasic
Imports System.Data.OracleClient
Imports System.Data
Imports Main_IDAL.IDAL

Namespace Main_DAL.DAL
    Public Class Main_DAL
        Implements Main_IDAL.IDAL.Main_IDAL.Main_IDAL
        Public Function get_date(ByVal brno As Integer) As System.Data.DataTable Implements Main_IDAL.IDAL.Main_IDAL.Main_IDAL.get_date
            Dim oh1 As New Helper.Oracle.OracleHelper
            Dim SQL As String = "select get_date(" & CInt(brno) & ") from dual"
            Return oh1.ExecuteDataSet(SQL).Tables(0)
        End Function
    End Class
End Namespace

