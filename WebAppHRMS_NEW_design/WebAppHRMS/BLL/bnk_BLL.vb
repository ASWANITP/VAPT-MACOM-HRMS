Imports Microsoft.VisualBasic
Imports System.Data.OracleClient
Imports System.Data
'Imports DAL_bnk.bnk_DAL
Namespace BLL_bnk
    Public Class bnk_BLL
        Dim obj As New DAL_bnk.bnk_DAL
        Dim oh As New helper.oracle.OracleHelper
        Dim dt As New DataTable
        Function fill_data(ByVal id As Integer, ByVal bis As Integer, ByVal usr As Integer) As DataTable
            dt = obj.fill_data(id, bis, usr)
            Return dt
        End Function
        Function fill_data_new(ByVal id As Integer, ByVal bis As Integer, ByVal usr As Integer, ByVal firm As Integer) As DataTable
            dt = obj.fill_data_new(id, bis, usr, firm)
            Return dt

        End Function

        Public Function check_usr(ByVal usr As Integer, ByVal id As Integer) As System.Data.DataTable
            dt = obj.check_usr(usr, id)
            Return dt
        End Function
        Public Function bnk_conf(ByVal bid As Integer, ByVal str As String) As String
            str = obj.bnk_conf(bid, str)
            Return str
        End Function
        Public Function pend_detail(ByVal id As Integer, ByVal dt_id As String) As System.Data.DataTable
            Dim dt As DataTable
            dt = obj.pend_detail(id, dt_id)
            Return dt
        End Function
        Public Function bc_confirm(ByVal id As Integer, ByVal str As String) As String
            Dim ret_str As String
            ret_str = obj.bc_confirm(id, str)
            Return ret_str
        End Function
        Public Function bank_dtl(ByVal id As Integer, ByVal fr_id As Integer, ByVal br_id As Integer) As System.Data.DataTable
            Dim dt As DataTable
            dt = obj.bank_dtl(id, fr_id, br_id)
            Return dt
        End Function
        Public Function charge_type(ByVal id As Integer) As System.Data.DataTable
            Dim dt As DataTable
            dt = obj.charge_type(id)
            Return dt
        End Function
        Public Function anx_ho_conf(ByVal bid As Integer, ByVal str As String) As String
            str = obj.anx_ho_conf(bid, str)
            Return str
        End Function


    End Class
End Namespace


