Imports System.Data
Imports System.Data.OracleClient
Partial Class Individual_Indiv_payment_03fcc1784685
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim to_dt, cn, i, idl As New Integer
        Dim start_dt, st(), usr(), ename As String
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_eMPNAME.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        usr = Me.Session("user_id").ToString.Split("!")
        Try
            If Not IsPostBack Then
                str = "select to_char(sysdate,'DD') from dual"
                dt = oh.ExecuteDataSet(str).Tables(0)
                to_dt = dt.Rows(0)(0)
                str = "select PARMTR_value from general_parameter where module_id=90 and parmtr_id=3 union select emp_name from employee_master where emp_code=" & usr(0) & ""
                dt = oh.ExecuteDataSet(str).Tables(0)
                start_dt = dt.Rows(0)(0)
                ename = dt.Rows(1)(0)
                st = start_dt.Split(",")
                cn = st.Length
                idl = 0
                For i = 0 To cn - 1
                    If to_dt = st(i) Then
                        idl = 1
                        Exit For
                    End If
                Next
                If idl = 1 Then
                   ' str = "select iam.all_name||'~'||nvl(round(sum(all_amount),2),0)||'~'||iam.all_id from incentives_allowances_dtl iad,incentives_allowances_master iam where iam.all_id=iad.all_id and iad.emp_code=" & usr(0) & " and iad.branch_id=" & Me.Session("branch_id") & "  group by iam.all_name,iam.all_id union select 'SALARY'||'~'||nvl(sum(net_pay),0)||'~'||0 from salari where emp_id=" & usr(0) & " and branch_id=" & Me.Session("branch_id") & ""
                    str = "select emp_code from employee_master_dtl where new_empcode=" & usr(0) & ""
                    dt = oh.ExecuteDataSet(str).Tables(0)
                    If dt.Rows.Count = 1 Then
                        usr(0) = dt.Rows(0)(0)
                        str = "select iam.all_name||'~'||nvl(round(sum(all_amount),2),0)||'~'||iam.all_id from incentives_allowances_dtl iad,incentives_allowances_master iam where iam.all_id=iad.all_id and iad.emp_code=" & usr(0) & " group by iam.all_name,iam.all_id union select 'SALARY'||'~'||nvl(sum(nvl(net_pay,0)+nvl(bonus,0)-nvl(cutting,0)),0)||'~'||0 from salari where emp_id=" & usr(0) & ""
                        dt = oh.ExecuteDataSet(str).Tables(0)
                        Dim dr As DataRow
                        For Each dr In dt.Rows
                            If Me.hid_value.Value = "" Then
                                Me.hid_value.Value = dr(0)
                            Else
                                Me.hid_value.Value = Me.hid_value.Value & "*" & dr(0)
                            End If
                        Next
                        Me.txt_eMPCODE.Value = usr(0)
                        Me.txt_eMPNAME.Value = ename
                    Else
                        Me.Label1.Text = "YOU HAVE NO OLD EMPLOYEE CODE"
                    End If
                Else
                    Me.Server.Transfer("../show_err.aspx?You cannot Take salary now")
                End If
                End If
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim user() As String = Me.Session("user_id").ToString.Split("!")
            Dim str As String = Me.txt_eMPCODE.Value & "^" & Me.hid_tot.Value & "^" & Me.Session("branch_id") & "^" & Me.hid_sal.Value & "^" & Me.hid_ta.Value & "^" & user(0)
            Dim op(4) As OracleParameter
            op(0) = New OracleParameter("str", OracleType.VarChar, 800)
            op(0).Value = str
            op(1) = New OracleParameter("flag", OracleType.Number, 2)
            op(1).Direction = ParameterDirection.Output
            op(2) = New OracleParameter("msg", OracleType.VarChar, 100)
            op(2).Direction = ParameterDirection.Output
            op(3) = New OracleParameter("idfy", OracleType.Number, 2)
            op(3).Value = 3
            op(4) = New OracleParameter("transno", OracleType.Number, 8)
            op(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_emp_verification", op)
            Dim a As New Integer
            a = op(1).Value
            Dim cl_script As New StringBuilder
            If a = 1 Then
                cl_script.Append("   alert('" & op(2).Value & "!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Else
                cl_script.Append("   alert('" & op(2).Value & "!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            End If
            'Me.hid_value.Value = ""
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub
End Class
