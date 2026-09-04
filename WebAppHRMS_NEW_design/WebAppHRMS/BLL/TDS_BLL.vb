Imports Microsoft.VisualBasic
'Imports DAL_nmS.TDS_DAL
Imports System.Data.OracleClient
Imports System.Data
Namespace BLL_NMs
    Public Class TDS_BLL
        Dim obj As New DAL_nmS.TDS_DAL
        Dim oh As New helper.oracle.OracleHelper
        Dim dt As New DataTable
        Public Function emp_dtl(ByVal emp_id As Integer, ByVal month As String) As String
            Dim res As String
            res = obj.emp_dtl(emp_id, month)
            Return res
        End Function
        Public Function fill_data(ByVal id As Integer) As System.Data.DataTable
            dt = obj.fill_data(id)
            Return dt
        End Function
        Public Function fill_data_new(ByVal id As Integer, ByVal firm As Integer) As System.Data.DataTable
            dt = obj.fill_data_new(id, firm)
            Return dt
        End Function
        Public Function tds_confirm(ByVal tid As Integer, ByVal str As String) As String
            str = obj.tds_confirm(tid, str)
            Return str
        End Function
        Public Function tds_other_type_fill(ByVal id As Integer, ByVal category_id As Integer) As System.Data.DataTable
            Return obj.tds_other_type_fill(id, category_id)
        End Function
        Public Function tds_disp(ByVal id As Integer, ByVal emp_id As String) As String
            Return obj.tds_disp(id, emp_id)
        End Function

        Public Function tds_exp(ByVal id As Integer, ByVal emp_id As String, ByVal amount As Double)
            Return obj.tds_exp(id, emp_id, amount)
        End Function
        Public Function tds_rep(ByVal id As Integer, ByVal emp_id As String, ByVal month As String) As System.Data.DataTable
            Return obj.tds_rep(id, emp_id, month)
        End Function
    End Class
End Namespace