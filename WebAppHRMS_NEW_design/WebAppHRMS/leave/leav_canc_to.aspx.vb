Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_leav_canc_b481b37b4524
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            adddata()
        End If
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_name.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
    End Sub
    Sub adddata()
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        Dim dt As New DataTable
        ' Dim sql As String = "select h.emp_code||'*'||e.emp_name||'*'||lm.leave_type||'*'||h.leave_frdate||'*'||h.leave_todate||'*'||h.leave_days||'*'||h.leave_apply_date||'*'||hd.reason_name||'*'||h.leave_seq,'EmpCode:'||e.emp_code||' Emp Name:'||e.emp_name||' From Date:'||h.leave_frdate||' To Date'||h.leave_todate from hrm_leave_apply_sanction h,employee_master e,hrm_category_dtl hd,leave_master lm where h.emp_code=e.emp_code and h.leave_id=lm.leave_id and h.category_id=hd.category_id and h.reason_id=hd.reason_id and h.emp_code='" & st2 & "' and h.status_id in (0,4) union select h.emp_code||'*'||e.emp_name||'*'||lm.leave_type||'*'||h.leave_frdate||'*'||h.leave_todate||'*'||h.leave_days||'*'||h.leave_apply_date||'*'||hd.reason_name||'*'||h.leave_seq,'EmpCode:'||e.emp_code||' Emp Name:'||e.emp_name||' From Date:'||h.leave_frdate||' To Date'||h.leave_todate from hrm_leave_apply_sanction h,employee_master e,hrm_category_dtl hd,leave_master lm where h.emp_code=e.emp_code and h.leave_id=lm.leave_id and h.category_id=hd.category_id and h.reason_id=hd.reason_id and h.emp_code='" & st2 & "' and h.status_id=1 and to_date(h.leave_frdate)>to_date(sysdate)"
        Dim sql As String = "select h.emp_code||'*'||e.emp_name||'*'||lm.leave_type||'*'||h.leave_frdate||'*'||h.leave_todate||'*'||h.leave_days||'*'||h.leave_apply_date||'*'||hd.reason_name||'*'||h.leave_seq,'EmpCode:'||e.emp_code||' Emp Name:'||e.emp_name||' From Date:'||h.leave_frdate||' To Date'||h.leave_todate,h.leave_frdate as frdt from hrm_leave_apply_sanction h,employee_master e,hrm_category_dtl hd,leave_master lm where h.emp_code=e.emp_code and h.leave_id=lm.leave_id and h.category_id=hd.category_id and h.reason_id=hd.reason_id and h.emp_code='" & st2 & "'  and h.status_id in (0,4,5) union select h.emp_code||'*'|| e.emp_name||'*'||lm.leave_type||'*'||h.leave_frdate||'*'||h.leave_todate||'*'|| h.leave_days||'*'||h.leave_apply_date||'*'||h.leave_reason||'*'||h.leave_seq, 'EmpCode:'||e.emp_code||' Emp Name:'||e.emp_name||' From Date:'||h.leave_frdate|| ' To Date'||h.leave_todate,h.leave_frdate as frdt from employ_leave_dtl h,employee_master e, leave_master lm where h.emp_code=e.emp_code and h.leave_id= lm.leave_id  and  h.emp_code='" & st2 & "'  and h.leave_process_id not in(0,3) and to_date(h.leave_frdate)>to_date(sysdate)  order by frdt"

        dt = oh.ExecuteDataSet(sql).Tables(0)
        If (dt.Rows.Count = 0) Then
            Me.cmb_emp.Items.Clear()
            Me.cmb_emp.Items.Add("NO LEAVE TO BE CANCELLED")
            Me.cmb_emp.ForeColor = Drawing.Color.Red
            Me.hid_value.Value = ""
            CLEAR()
        Else

            Dim i, j As New Integer
            i = dt.Rows.Count
            For j = 0 To i - 1
                If Me.hid_value.Value = "" Then
                    Me.hid_value.Value = dt.Rows(j)(0)
                Else
                    Me.hid_value.Value = Me.hid_value.Value & "~" & dt.Rows(j)(0)
                End If
            Next
            Me.cmb_emp.DataSource = dt
            Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_emp.DataBind()
            fill_emp()
        End If
    End Sub
    Sub fill_emp()
        Dim st() As String = Me.cmb_emp.SelectedValue.Split("*")
        Me.txt_code.Value = st(0)
        Me.txt_name.Value = st(1)
        Me.txt_type.Value = st(2)
        Me.txt_from.Value = st(3)
        Me.txt_to.Value = st(4)
        Me.txt_days.Value = st(5)
        Me.txt_appl_dt.Value = st(6)
        Me.txt_reason.Value = st(7)
        Me.hid_seq.Value = st(8)
    End Sub
    Sub CLEAR()
        Me.txt_code.Value = ""
        Me.txt_name.Value = ""
        Me.txt_type.Value = ""
        Me.txt_from.Value = ""
        Me.txt_to.Value = ""
        Me.txt_days.Value = ""
        Me.txt_appl_dt.Value = ""
        Me.txt_reason.Value = ""
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim leave_cancel(7) As OracleParameter
            leave_cancel(0) = New OracleParameter("emp_id", OracleType.Int32)
            leave_cancel(0).Direction = ParameterDirection.Input
            leave_cancel(0).Value = Me.txt_code.Value
            leave_cancel(6) = New OracleParameter("usr_id", OracleType.VarChar, 50)
            leave_cancel(6).Direction = ParameterDirection.Input
            leave_cancel(6).Value = Me.Session("user_id")
            leave_cancel(1) = New OracleParameter("from_date", OracleType.DateTime)
            leave_cancel(1).Direction = ParameterDirection.Input
            leave_cancel(1).Value = CDate(Me.txt_from.Value)
            leave_cancel(2) = New OracleParameter("to_date", OracleType.DateTime)
            leave_cancel(2).Direction = ParameterDirection.Input
            leave_cancel(2).Value = CDate(Me.txt_to.Value)
            leave_cancel(3) = New OracleParameter("days", OracleType.Int32)
            leave_cancel(3).Direction = ParameterDirection.Input
            leave_cancel(3).Value = Me.txt_days.Value
            leave_cancel(4) = New OracleParameter("flag", OracleType.Int32)
            leave_cancel(4).Direction = ParameterDirection.Output
            leave_cancel(5) = New OracleParameter("msg", OracleType.VarChar, 3000)
            leave_cancel(5).Direction = ParameterDirection.Output
            leave_cancel(7) = New OracleParameter("leav_sq", OracleType.VarChar, 50)
            leave_cancel(7).Direction = ParameterDirection.Input
            leave_cancel(7).Value = Me.hid_seq.Value
            oh.ExecuteNonQuery("hrm_leave_cancel", leave_cancel)

            If leave_cancel(4).Value = 1 Then
                Dim dtf, dtt As New Date
                Dim emp As New Integer
                dtf = Me.txt_from.Value
                dtt = Me.txt_to.Value
                emp = Me.txt_code.Value
                Dim cl_script As New StringBuilder
                'cl_script.Append("   alert('EMPCODE:" & emp & " FROM:" & dtf & " TO:" & dtt & "  LEAVE CANCELLED"!!) ;")
                cl_script.Append("   alert('EMPCODE:" & emp & "FROM:" & dtf & "TO:" & dtt & " LEAVE CANCELLED!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                CLEAR()
                adddata()
            Else
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('" & leave_cancel(5).Value & "!!') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            End If
        Catch ex As Exception
            Me.lbl_message.Text = ex.Message
        End Try
        
    End Sub
End Class
