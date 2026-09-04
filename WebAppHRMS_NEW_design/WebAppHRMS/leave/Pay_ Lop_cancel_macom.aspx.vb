Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.ReportAppServer.DataDefModel

Partial Class Payroll_LeaveUpdation_1dc57b001466
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6 As New DataTable
    Dim str, str1, str2, str3, str4, str5 As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim st() As String
    Dim id_flag As Integer = 0
    Public Shared flg_ar As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("access_id") = 33 Then
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "LOP Cancellation "
            Dim cs As String = "var cont_name;cont_name='" & Me.txt_id.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
            Me.btn_confirm.Attributes.Add("onclick", "return  btn_onclick()")
            Me.btn_ok.Attributes.Add("onclick", "return  btn_ok()")
            Me.chk_ar.Attributes.Add("onclick", "arrear()")
            Me.chk_no.Attributes.Add("onclick", "no_arrear()")
            If (Not IsPostBack) Then
                Me.UpdatePanel1.Visible = False
                Me.btn_confirm.Enabled = False
                Me.hf_eid.Value = 0
                Me.TABLE1.Visible = False
                Me.TABLE2.Visible = False
                displayCase(0)
            End If
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If
    End Sub

    Protected Sub txt_id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id.TextChanged
        Me.UpdatePanel1.Visible = False
        Me.btn_confirm.Enabled = False
        employee_fill()
    End Sub
    Sub employee_fill()
        Dim ff As Integer = Session("firm_id")
        If (Me.txt_id.Text = "") Then
            id_flag = 0
            Me.hf_eid.Value = 0
        Else
            str1 = "select e.emp_code,e.emp_name,b.branch_name from mactech.employee_master e ,mactech.branch b,mactech.employ_firm f where e.emp_code=f.emp_code and f.firm_id= " & ff & " and e.emp_code=" & Me.txt_id.Text & "and e.emp_code>'9999'and e.branch_id=b.branch_id"
            dt1 = oh.ExecuteDataSet(str1).Tables(0)
            If (dt1.Rows.Count < 1) Then
                Me.lbl_name.ForeColor = Drawing.Color.Red
                Me.lbl_name.Text = "Invalid Employee ID"
                Me.txt_id.Text = ""

                id_flag = 0
                Me.hf_eid.Value = 0
                Me.TABLE1.Visible = False
                TABLE2.Visible = False
                Me.UpdatePanel1.Visible = False
                Me.btn_confirm.Enabled = False
            Else

                Me.TABLE1.Visible = True
                TABLE2.Visible = True
                Me.lbl_name.ForeColor = Drawing.Color.Red
                Me.lbl_name.Text = "" + dt1.Rows(0)(1) + "   Branch :" + dt1.Rows(0)(2)
                id_flag = Me.txt_id.Text

                Me.hf_eid.Value = Me.txt_id.Text

                fill_leave_dtl()
                leave_dtl_fill()
                remaining_fill()
                Me.UpdatePanel1.Visible = True
            End If
        End If
    End Sub
    Sub fill_leave_dtl()
        str2 = "select d.leave_seq,d.leave_frdate||' * '||d.leave_todate||' * '||m.leave_type||' * '||d.leave_days||'-Days'||' * ' ||d.leave_reason  from mactech.employ_leave_dtl d,mactech.leave_master m,mactech.general_parameter g where d.emp_code=" & Me.txt_id.Text & " and m.leave_id=d.leave_id and d.leave_process_id in(1,2) and to_date(d.leave_frdate)>add_months(to_date(sysdate),-g.parmtr_value) and g.parmtr_id=777 and d.leave_id in(4) order by d.leave_frdate desc,d.leave_id"
        dt2 = oh.ExecuteDataSet(str2).Tables(0)
        If (dt2.Rows.Count > 0) Then
            Me.ddl_leave.DataSource = dt2
            Me.ddl_leave.DataValueField = dt2.Columns(0).ColumnName
            Me.ddl_leave.DataTextField = dt2.Columns(1).ColumnName
            Me.ddl_leave.DataBind()
            Me.btn_confirm.Enabled = True
            Me.ddl_frm.Enabled = True
            Me.ddl_to.Enabled = True
        Else
            Dim li As New ListItem
            li.Text = "Nothing To Update"
            li.Value = "999xxx"
            Me.ddl_frm.Enabled = False
            Me.ddl_to.Enabled = False
            Me.ddl_leave.Items.Clear()
            ddl_leave.Items.Add(li)
            ddl_leave.DataBind()
            Me.ddl_frm.Items.Clear()
            Me.ddl_to.Items.Clear()
            Me.lbl_frm.Text = ""
            Me.lbl_days.Text = "0"
            Me.btn_confirm.Enabled = False
        End If
    End Sub
    'Krishnadas Resignation with penalty checking added........
    Sub leave_dtl_fill()
        Dim processid, cnt As Integer
        Dim str = " Leave of Resignation With Penalty"
        Dim str1 = " Leave of Resignation Without Penalty"
        If (Me.ddl_leave.SelectedItem.Value <> "999xxx") Then
            st = Me.ddl_leave.SelectedItem.Text.Split("*")
            cnt = oh.ExecuteDataSet("select count(*) from mactech.employ_leave_dtl d where d.leave_seq=" & Me.ddl_leave.SelectedItem.Value & " and d.leave_process_id in (1,2)").Tables(0).Rows(0)(0)
            Me.lbl_frm.Text = st(0)
            Me.lbl_to.Text = st(1)
            Me.lbl_type.Text = st(2)
            Me.lbl_days.Text = st(3)
            Me.lbl_reason.Text = st(4)
            ''--Resignation with penalty removal case-jan-14-2016 Krishnadas
            If (CStr(st(4)).Trim() = CStr(str).Trim()) Or (CStr(st(4)).Trim() = CStr(str1).Trim()) Then
                If cnt = 1 Then
                    processid = oh.ExecuteDataSet("select d.leave_process_id from mactech.employ_leave_dtl d where d.leave_seq=" & Me.ddl_leave.SelectedItem.Value & " and d.leave_process_id in (1,2)").Tables(0).Rows(0)(0)
                    If processid = 2 Then
                        displayCase(1)
                    ElseIf processid = 1 Then
                        displayCase(0)
                    End If
                End If
            Else
                displayCase(0)

            End If
            ''--------End--------------
            from_date_fill()
            to_date_fill()
        End If
    End Sub
    Sub from_date_fill()
        Dim fdt, tdt, cdt As Date
        Dim i, count As Integer
        fdt = Format(CDate(st(0)), "dd-MMM-yyyy")
        tdt = Format(CDate(st(1)), "dd-MMM-yyyy")
        count = DateDiff(DateInterval.Day, fdt, tdt)

        cdt = fdt
        Me.ddl_frm.Items.Clear()
        For i = 0 To (count)
            Me.ddl_frm.Items.Add(Format(cdt, "dd-MMM-yyyy"))

            cdt = cdt.AddDays(1)
        Next
    End Sub
    Sub to_date_fill()
        Dim fdt, tdt, cdt As Date
        Dim count, i As Integer
        fdt = Format(CDate(Me.ddl_frm.SelectedItem.Text), "dd-MMM-yyyy")
        tdt = Format(CDate(Me.lbl_to.Text), "dd-MMM-yyyy")
        count = DateDiff(DateInterval.Day, fdt, tdt)
        cdt = fdt
        Me.ddl_to.Items.Clear()
        For i = 0 To (count)
            Me.ddl_to.Items.Add(Format(cdt, "dd-MMM-yyyy"))
            cdt = cdt.AddDays(1)
        Next
    End Sub
    Sub remaining_fill()
        str4 = "select lm.leave_type,m.leave_days from mactech.employ_leave_master m,mactech.leave_master lm where m.emp_code=" & Me.txt_id.Text & "and m.leave_id=lm.leave_id"
        dt4 = oh.ExecuteDataSet(str4).Tables(0)
    End Sub
    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        lbl_err.Text = ""
        employee_fill()
    End Sub
    Protected Sub DDL_leave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_leave.SelectedIndexChanged
        leave_dtl_fill()
        lbl_err.Text = ""
    End Sub
    Protected Sub ddl_frm_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        to_date_fill()
    End Sub
    Function validate_date()

        'dt5 = oh.ExecuteDataSet("select validate_dt(" & Me.txt_id.Text & ",to_date('" & Me.ddl_frm.SelectedItem.Text & "'),1),validate_dt(" & Me.txt_id.Text & ",to_date('" & Me.ddl_to.SelectedItem.Text & "'),1) from dual").Tables(0)
        'If ((CDate(dt5.Rows(0)(0)) <> CDate(Me.ddl_frm.SelectedItem.Text)) And (CDate(Me.ddl_to.SelectedItem.Text) <> CDate(dt5.Rows(0)(1)))) Then
        '    Dim cl_script0 As New System.Text.StringBuilder
        '    cl_script0.Append("         alert('Error !!!! You Can not Select a Holiday as From Date or  To date');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        '    Return 0
        '    Exit Function
        'End If
        Return 1
    End Function
    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        Dim chkval As Integer = 0
        If (validate_date() = 0) Then
            Exit Sub
        End If
        Dim parm_coll1(8) As OracleParameter
        parm_coll1(0) = New OracleParameter("leve_seq", OracleType.Number, 15)
        parm_coll1(0).Value = Me.ddl_leave.SelectedItem.Value
        parm_coll1(0).Direction = ParameterDirection.Input
        parm_coll1(1) = New OracleParameter("emp_id", OracleType.Number, 6)
        parm_coll1(1).Value = Me.txt_id.Text
        parm_coll1(1).Direction = ParameterDirection.Input
        parm_coll1(2) = New OracleParameter("from_dt", OracleType.DateTime)
        parm_coll1(2).Value = CDate(Me.ddl_frm.SelectedItem.Value)
        parm_coll1(2).Direction = ParameterDirection.Input
        parm_coll1(3) = New OracleParameter("to_dt", OracleType.DateTime)
        parm_coll1(3).Value = CDate(Me.ddl_to.SelectedItem.Value)
        parm_coll1(3).Direction = ParameterDirection.Input
        parm_coll1(4) = New OracleParameter("error_msg", OracleType.LongVarChar, 400)
        parm_coll1(4).Direction = ParameterDirection.Output
        parm_coll1(5) = New OracleParameter("flg", OracleType.Number, 2)
        parm_coll1(5).Direction = ParameterDirection.Output
        parm_coll1(6) = New OracleParameter("userid", OracleType.VarChar, 50)
        parm_coll1(6).Value = Session("user_id")
        parm_coll1(6).Direction = ParameterDirection.Input

        ''--Resignation with penalty removal case-jan-14-2016 Krishnadas
        parm_coll1(7) = New OracleParameter("arrear_st", OracleType.Number, 15)
        If flg_ar = 1 Then
            If Me.chk_ar.Checked = True Then
                chkval = 1
            Else
                chkval = 2
            End If
        Else
            chkval = 0
        End If
        parm_coll1(7).Value = chkval
        parm_coll1(7).Direction = ParameterDirection.Input
        ''---------End

        ''-- Add remarks parameter
        parm_coll1(8) = New OracleParameter("remarks", OracleType.VarChar, 100)
        parm_coll1(8).Value = Me.txt_remarks.Text ' Assuming there's a textbox named txt_remarks for remarks
        parm_coll1(8).Direction = ParameterDirection.Input

        oh.ExecuteNonQuery("mactech.upd_cancel_leave_macom", parm_coll1)
        Dim cl_script0 As New System.Text.StringBuilder
        If (parm_coll1(5).Value = 0) Then
            cl_script0.Append("alert('Error !!!!');")
            Me.lbl_err.Text = parm_coll1(4).Value.ToString
        Else
            cl_script0.Append("alert('Successfull !!!');")
            cl_script0.Append("window.open('Pay_ Lop_cancel_macom.aspx','_self');")
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub


    ''--Resignation with penalty removal case-jan-14-2016 Krishnadas

    Sub displayCase(ByVal num As Integer)
        If num = 0 Then
            Me.Label9.Visible = False
            Me.Label10.Visible = False
            Me.Label11.Visible = False
            Me.chk_ar.Visible = False
            Me.chk_no.Visible = False
            Me.chk_no.Checked = False
            Me.chk_ar.Checked = False
            flg_ar = 0
        Else
            Me.Label9.Visible = True
            Me.Label10.Visible = True
            Me.Label11.Visible = True
            Me.chk_ar.Visible = True
            Me.chk_no.Visible = True
            Me.chk_no.Checked = True
            Me.chk_ar.Checked = False
            flg_ar = 1
        End If
    End Sub
End Class