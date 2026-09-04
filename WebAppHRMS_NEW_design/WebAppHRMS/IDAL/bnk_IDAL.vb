Imports Microsoft.VisualBasic
Imports System.Data
Namespace IDAL_bnk
    Public Class bnk_IDAL
        Public Interface IDAL_int
            Function fill_data(ByVal id As Integer, ByVal bis As Integer, ByVal usr As Integer) As DataTable
            Function check_usr(ByVal usr As Integer, ByVal id As Integer) As DataTable
            Function bnk_conf(ByVal bid As Integer, ByVal str As String) As String
            Function pend_detail(ByVal id As Integer, ByVal dt_id As String) As System.Data.DataTable
            Function charge_type(ByVal id As Integer) As System.Data.DataTable
            Function bc_confirm(ByVal id As Integer, ByVal str As String) As String
            Function bank_dtl(ByVal id As Integer, ByVal fr_id As Integer, ByVal br_id As Integer) As System.Data.DataTable
            Function anx_ho_conf(ByVal bid As Integer, ByVal str As String) As String
            Function fill_data_new(ByVal id As Integer, ByVal bis As Integer, ByVal usr As Integer, ByVal firm As Integer) As DataTable

        End Interface
    End Class
End Namespace
