Imports Microsoft.VisualBasic
Imports System.Data.OracleClient
Imports System.Data
'Imports IDAL_bnk.bnk_IDAL
Namespace DAL_bnk
    Public Class bnk_DAL
        Implements IDAL_bnk.bnk_IDAL.IDAL_int
        Dim oh As New helper.oracle.OracleHelper
        Dim sql As String
        Dim dt As New DataTable
        Public Function check_usr(ByVal usr As Integer, ByVal id As Integer) As System.Data.DataTable Implements IDAL_bnk.bnk_IDAL.IDAL_int.check_usr
            If id = 12 Then
                sql = "select * from form_accessibility where emp_id=" & usr & " and form_id=74"

                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 13 Then
                sql = "select count(*) from printer_status where branch_id=" & usr & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            Return dt
        End Function

        Public Function bnk_conf(ByVal bid As Integer, ByVal str As String) As String Implements IDAL_bnk.bnk_IDAL.IDAL_int.bnk_conf
            If bid = 14 Then
                Try
                    Dim param(1) As OracleParameter
                    param(0) = New OracleParameter("str", OracleType.VarChar, 500)
                    param(0).Direction = ParameterDirection.InputOutput
                    param(0).Value = str
                    param(1) = New OracleParameter("flag", OracleType.Number, 2)
                    param(1).Direction = ParameterDirection.InputOutput
                    param(1).Value = 0
                    oh.ExecuteNonQuery("bank_ho_approval", param)
                    str = param(0).Value
                Catch ex As Exception
                    str = ex.Message
                Finally
                End Try
            End If
            If bid = 15 Then
                Try
                    Dim param(1) As OracleParameter
                    param(0) = New OracleParameter("str", OracleType.VarChar, 500)
                    param(0).Direction = ParameterDirection.InputOutput
                    param(0).Value = str
                    param(1) = New OracleParameter("flag", OracleType.Number, 2)
                    param(1).Direction = ParameterDirection.InputOutput
                    param(1).Value = 1
                    oh.ExecuteNonQuery("bank_ho_approval", param)
                    str = param(0).Value
                Catch ex As Exception
                    str = ex.Message
                Finally
                End Try
            End If
            Return str
        End Function

        Public Function fill_data(ByVal id As Integer, ByVal bis As Integer, ByVal usr As Integer) As System.Data.DataTable Implements IDAL_bnk.bnk_IDAL.IDAL_int.fill_data
            If id = 11 Then
                sql = "select b.branch_name ||'||'||bt.charge_name||'||'|| t.charge_amt,b.branch_name||'@'||bt.charge_name||'@'||t.charge_amt||'@'||to_date(t.tra_dt)||'@'||s.account_name||'@'||t.branch_id||'@'||t.firm_id||'@'||t.bank_accno||'@'||t.charge_id||'@'||t.document_no||'@'||" & usr & "  from bank_charge_master t,branch_master b,bank_charge_type bt,subsidary_master s  where b.branch_id=t.branch_id and bt.charge_id=t.charge_id and s.branch_id=t.branch_id and s.firm_id=t.firm_id and s.parent_acc=32100 and s.account_no=t.bank_accno and s.status_id=1 and t.charge_id=1 and t.status_id=1"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 12 Then
                sql = "select * from  employee_master where branch_id=" & bis & " and emp_code in (select emp_code from daily_attend where m_time is not null and m_branch=" & bis & ") and emp_code=" & usr & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count = 0 Then
                    sql = "select * from area_master where area_head_id=" & usr & " and area_head_id is not null and area_head_id in (select emp_code from daily_attend where m_time is not null) and area_id in (select  area_id from area_detail where branch_id=" & bis & ")"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                End If
            End If
            Return dt
        End Function
        Public Function fill_data_new(ByVal id As Integer, ByVal bis As Integer, ByVal usr As Integer, ByVal firm As Integer) As System.Data.DataTable Implements IDAL_bnk.bnk_IDAL.IDAL_int.fill_data_new
            If id = 11 Then
                sql = "select b.branch_name ||'||'||bt.charge_name||'||'|| t.charge_amt,b.branch_name||'@'||bt.charge_name||'@'||t.charge_amt||'@'||to_date(t.tra_dt)||'@'||s.account_name||'@'||t.branch_id||'@'||t.firm_id||'@'||t.bank_accno||'@'||t.charge_id||'@'||t.document_no||'@'||" & usr & "  from bank_charge_master t,branch_master b,bank_charge_type bt,subsidary_master s  where b.branch_id=t.branch_id and bt.charge_id=t.charge_id and s.branch_id=t.branch_id and s.firm_id=t.firm_id and s.parent_acc=32100 and s.account_no=t.bank_accno and s.status_id=1  and t.status_id=1 and t.firm_id=" & firm
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 12 Then
                sql = "select * from  employee_master where branch_id=" & bis & " and emp_code in (select emp_code from daily_attend where m_time is not null and m_branch=" & bis & ") and emp_code=" & usr & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count = 0 Then
                    sql = "select * from area_master where area_head_id=" & usr & " and area_head_id is not null and area_head_id in (select emp_code from daily_attend where m_time is not null) and area_id in (select  area_id from area_detail where branch_id=" & bis & ")"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                End If
            End If
            Return dt
        End Function

        Public Function bank_dtl(ByVal id As Integer, ByVal fr_id As Integer, ByVal br_id As Integer) As System.Data.DataTable Implements IDAL_bnk.bnk_IDAL.IDAL_int.bank_dtl
            If id = 31 Then
                sql = "select t.account_no,t.account_name from subsidary_master t where t.firm_id=" & fr_id & " and t.branch_id=" & br_id & " and t.parent_acc=32100 and t.status_id=1"
            End If
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Return dt
        End Function

        Public Function bc_confirm(ByVal id As Integer, ByVal str As String) As String Implements IDAL_bnk.bnk_IDAL.IDAL_int.bc_confirm
            Dim ret_str As String = ""
            Dim pass_val() As String
            Try
                If id = 3 Then
                    'MsgBox(str)
                    pass_val = str.Split("*")

                    Dim param(7) As OracleParameter
                    param(0) = New OracleParameter("docid", OracleType.VarChar, 20)
                    param(0).Value = pass_val(0)
                    param(1) = New OracleParameter("br_id", OracleType.Number, 5)
                    param(1).Value = CInt(pass_val(1))

                    param(2) = New OracleParameter("fr_id", OracleType.Number, 2)
                    param(2).Value = CInt(pass_val(2))
                    param(3) = New OracleParameter("amount", OracleType.Number, 10)
                    ' param(3).Value = CInt(pass_val(3))
                    param(3).Value = CDbl(pass_val(3))
                    param(4) = New OracleParameter("usr", OracleType.VarChar, 20)
                    param(4).Value = pass_val(4)
                    param(5) = New OracleParameter("err_stat", OracleType.Number)
                    param(5).Direction = ParameterDirection.Output
                    param(6) = New OracleParameter("err_msg", OracleType.VarChar, 500)
                    param(6).Direction = ParameterDirection.Output
                    param(7) = New OracleParameter("tno", OracleType.Number, 10)
                    param(7).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("bc_pend_app", param)
                    ret_str = param(5).Value & "*" & param(6).Value & "*" & param(7).Value
                    ' MsgBox(ret_str)
                End If
                If id = 1 Then
                    pass_val = str.Split("*")
                    Dim p(11) As OracleParameter
                    p(0) = New OracleParameter("br_id", OracleType.Number, 5)
                    p(0).Value = pass_val(0)
                    p(1) = New OracleParameter("fr_id", OracleType.Number, 5)
                    p(1).Value = pass_val(1)

                    p(2) = New OracleParameter("bank_id", OracleType.Number, 10)
                    p(2).Value = pass_val(2)

                    p(3) = New OracleParameter("chg_id", OracleType.Number, 5)
                    p(3).Value = pass_val(3)
                    p(4) = New OracleParameter("chg_amt", OracleType.Number, 10)
                    p(4).Value = pass_val(4)

                    p(5) = New OracleParameter("docid", OracleType.VarChar, 25)
                    p(5).Value = pass_val(5)
                    p(6) = New OracleParameter("usr", OracleType.VarChar, 25)
                    p(6).Value = pass_val(6)

                    p(7) = New OracleParameter("err_stat", OracleType.Number)
                    p(7).Direction = ParameterDirection.Output
                    p(8) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
                    p(8).Direction = ParameterDirection.Output
                    p(9) = New OracleParameter("tno", OracleType.Number, 10)
                    p(9).Direction = ParameterDirection.Output
                    p(10) = New OracleParameter("VendorCode", OracleType.VarChar, 20)
                    p(10).Value = pass_val(8)
                    p(11) = New OracleParameter("HSNCode", OracleType.VarChar, 20)
                    p(11).Value = pass_val(10)

                    oh.ExecuteNonQuery("bc_bank_chg", p)
                    ret_str = p(7).Value & "*" & p(8).Value & "*" & p(9).Value
                End If
            Catch ex As Exception
                ret_str = ex.Message
            End Try
            Return ret_str
        End Function

        Public Function charge_type(ByVal id As Integer) As System.Data.DataTable Implements IDAL_bnk.bnk_IDAL.IDAL_int.charge_type
            If id = 31 Then
                sql = "select 0 as charge_id,'Select Charge' from dual union select t.charge_id,t.charge_name from bank_charge_type t order by charge_id"
            End If
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Return dt
        End Function

        Public Function pend_detail(ByVal id As Integer, ByVal dt_id As String) As System.Data.DataTable Implements IDAL_bnk.bnk_IDAL.IDAL_int.pend_detail
            If id = 31 Then
                sql = "select distinct s.account_name||' * '||t.charge_name||' * '||b.charge_amt,b.document_no||'*'||to_char(b.tra_dt,'dd/MON/yyyy')||'*'||b.charge_amt from bank_charge_master b,subsidary_master s,bank_charge_type t where b.bank_accno=s.account_no and b.branch_id=s.branch_id and b.firm_id=s.firm_id and s.parent_acc=32100 and t.charge_id=b.charge_id and b.status_id=2 and b.branch_id=" & dt_id & ""
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If id = 32 Then
                sql = "select count(*) from bank_charge_master t where t.document_no='" & dt_id & "' and to_number(substr(document_no,7,2))<>3"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows(0)(0) = 0 Then
                    sql = "select t.cust_name,t.dep_amt from deposit_mst t where t.doc_id='" & dt_id & "'"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                Else
                    sql = "select 2,3 from dual"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                End If
            End If

            Return dt
        End Function
        Public Function anx_ho_conf(ByVal bid As Integer, ByVal str As String) As String Implements IDAL_bnk.bnk_IDAL.IDAL_int.anx_ho_conf
            Dim flag_check As Integer
            If bid = 14 Then
                flag_check = 1 ' SANCTION 
            End If
            If bid = 15 Then
                flag_check = 2 ' REJECT
            End If
            Try
                Dim param(1) As OracleParameter
                param(0) = New OracleParameter("str", OracleType.VarChar, 1000)
                param(0).Direction = ParameterDirection.InputOutput
                param(0).Value = CStr(str)
                param(1) = New OracleParameter("flag", OracleType.Number, 2)
                param(1).Direction = ParameterDirection.InputOutput
                param(1).Value = CStr(flag_check)
                'param(2) = New OracleParameter("errmsg", OracleType.VarChar, 20)
                'param(2).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("anx_summary", param)
                str = CStr(param(0).Value)

            Catch ex As Exception
                str = ex.Message
            Finally
            End Try
            Return str

        End Function

    End Class
End Namespace
