

Imports System.Data
Imports System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder
Imports System.Data.OracleClient
Imports Microsoft.VisualBasic.Logging
Imports System.Windows.Forms.AxHost
Public Class hrm_CompulsoryLeave_Mac_Approve
    Inherits System.Web.UI.Page
    'Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If ddlEcode.SelectedValue = "status" Then

            Dim script As String = "alert('Please select Employee..');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script, True)
        Else
            Dim mreg As Integer = 0
            Dim ereg As Integer = 0
            Dim lop As Integer = 0
            Dim regstatus As Integer = 0
            'Dim sta As String
            Dim selectedValue As String = ddlEcode.SelectedValue.Split("~")(1)
            Dim status As String = ddlEcode.SelectedValue.Split("~")(0)
            Dim ldate As String = ddlEcode.SelectedValue.Split("~")(2)
            Dim usr() As String = Me.Session("user_id").ToString.Split("!")
            Dim approvedBy As String = usr(0)
            dt = oh.ExecuteDataSet("select to_date(t.ldate),status,t.remark,t.m_regn,t.e_regn,t.lop,t.reg_status from HRM_ATTENDANCE_REGTEMP t where t.emp_code=" & selectedValue & " and t.t_status=0 and t.status=" & status & " and to_date(t.ldate)='" & ldate & "'").Tables(0)
            'sta = dt.Rows(0)(1)


            Try
                Dim p(12) As OracleParameter

                p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
                p(0).Direction = ParameterDirection.Input
                p(0).Value = selectedValue


                p(1) = New OracleParameter("UserID", OracleType.Number, 6)
                p(1).Direction = ParameterDirection.Input
                p(1).Value = UserCode

                p(2) = New OracleParameter("Ldate", OracleType.DateTime)
                p(2).Direction = ParameterDirection.Input
                p(2).Value = CDate(Me.txtDate.Text)


                p(3) = New OracleParameter("Sta", OracleType.Number, 2)
                p(3).Direction = ParameterDirection.Input
                p(3).Value = dt.Rows(0)(1)

                p(4) = New OracleParameter("mregn", OracleType.Number, 1)
                p(4).Direction = ParameterDirection.Input
                p(4).Value = dt.Rows(0)(3)


                p(5) = New OracleParameter("eregn", OracleType.Number, 1)
                p(5).Direction = ParameterDirection.Input
                p(5).Value = dt.Rows(0)(4)

                p(6) = New OracleParameter("lop", OracleType.Number, 1)
                p(6).Direction = ParameterDirection.Input
                p(6).Value = dt.Rows(0)(5)

                p(7) = New OracleParameter("remarks", OracleType.VarChar, 75)
                p(7).Direction = ParameterDirection.Input
                p(7).Value = Me.txt_remarks.Text


                p(9) = New OracleParameter("regstatus", OracleType.Number, 1)
                p(9).Direction = ParameterDirection.Input
                p(9).Value = dt.Rows(0)(6)
                'If Me.CheckBox1.Checked = True Then
                '    p(9).Value = 1

                'ElseIf Me.CheckBox1.Checked = False Then
                '    p(9).Value = 0
                'ElseIf Me.CheckBox2.Checked = True Then
                '    p(9).Value = 2
                'ElseIf Me.CheckBox2.Checked = False Then
                '    p(9).Value = 3
                'Else
                '    p(9).Value = 5

                'End If
                p(10) = New OracleParameter("fl", OracleType.Number, 5)
                p(10).Value = 3

                p(11) = New OracleParameter("EnterBy", OracleType.Number, 25)
                p(11).Value = 0

                p(12) = New OracleParameter("Approved_By", OracleType.Number, 25)
                p(12).Value = approvedBy


                p(8) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                p(8).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("HRM_COMPULSARYLEAVE_MAC", p)
                str_tkn.Append("         alert('" & p(8).Value & "');")
                str_tkn.Append(" window.open('hrm_CompulsoryLeave_Mac_Approve.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub ddlEcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEcode.SelectedIndexChanged

        Dim selectedValue As String = ddlEcode.SelectedValue.Split("~")(1)
        Dim status As String = ddlEcode.SelectedValue.Split("~")(0)
        Dim ldate As String = ddlEcode.SelectedValue.Split("~")(2)
        'Dim lldate As Date = to_dt(ldate)
        Dim selectedText As String = ddlEcode.SelectedItem.Text

        dt = oh.ExecuteDataSet("select e.emp_name,b.BRANCH_NAME , p.post_name, d.designation from employee_master e,post_mst p,designation_master d,branch_dtl_new b,employ_firm ef where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.designation_id=d.designation_id and e.status_id =1 and e.emp_code=" & selectedValue & "  and ef.firm_id=" & Session("firm_id") & "  and ef.emp_code=e.emp_code").Tables(0)

        If dt.Rows.Count > 0 Then
            txtEname.Text = dt.Rows(0)(0).ToString()
            txtBranch.Text = dt.Rows(0)(1).ToString()
            txtPost.Text = dt.Rows(0)(2).ToString()
            txtDes.Text = dt.Rows(0)(3).ToString()

        Else
            txtEname.Text = ""
            txtBranch.Text = ""
            txtPost.Text = ""
            txtDes.Text = ""
        End If
        Dim sta As String
        Dim mreg As Integer = 0
        Dim ereg As Integer = 0
        Dim lop As Integer = 0
        dt = oh.ExecuteDataSet("select to_date(t.ldate),status,t.remark,t.m_regn,t.e_regn,t.lop,t.reg_status from HRM_ATTENDANCE_REGTEMP t where t.emp_code=" & selectedValue & " and t.t_status=0 and t.status=" & status & " and to_date(t.ldate)='" & ldate & "'").Tables(0)

        If dt.Rows.Count > 0 Then
            Me.txtDate.Text = dt.Rows(0)(0)
            sta = dt.Rows(0)(1)
            'Me.cmb_type.SelectedValue = sta
            Select Case sta
                Case "1"
                    cmb_type.Text = "COMPULSORY LEAVE"
                Case "2"
                    cmb_type.Text = "LATE"
                Case "3"
                    cmb_type.Text = "EARLY GOING"
                Case "4"
                    cmb_type.Text = "REGULARISE"
                Case Else
                    cmb_type.Text = ""
            End Select
            If sta = 1 Then
                If dt.Rows(0)(5) = 1 Then

                    Me.txt_remarks.Text = dt.Rows(0)(2)
                    Me.txt_remarks.Visible = True
                    Me.tdRemarks.Visible = True
                    Me.chk_lop1.Visible = True
                    Span1.Visible = True
                    Me.chk_lop1.Checked = True
                ElseIf dt.Rows(0)(5) = 2 Then

                    Me.txt_remarks.Text = dt.Rows(0)(2)
                    Me.txt_remarks.Visible = True
                    Me.tdRemarks.Visible = True
                    Span2.Visible = True
                    Me.chk_lop2.Visible = True
                    Me.chk_lop2.Checked = True
                ElseIf dt.Rows(0)(5) = 0 Then
                    Me.chk_lop2.Checked = False
                End If
            End If

            If sta = 3 Then
                Me.txt_remarks.Text = dt.Rows(0)(2)
                Me.txt_remarks.Visible = True
                Me.tdRemarks.Visible = True
            ElseIf sta = "" Then
                Me.txt_remarks.Visible = False
            End If

            If sta = 4 Then


                If IsDBNull(dt.Rows(0)(2)) Then
                    Me.txt_remarks.Visible = False
                    Me.tdRemarks.Visible = False
                Else
                    Me.txt_remarks.Visible = True
                    Me.tdRemarks.Visible = True
                    Me.txt_remarks.Text = dt.Rows(0)(2)
                End If
            End If

        Else
            Me.txtDate.Text = dt.Rows(0)(0)
            Me.cmb_type.Text = ""
        End If





    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If

        '------------------------------------------------------------------------

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtBranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        'Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        'Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPULSORY LEAVE APPROVAL"
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=134 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            If Not IsPostBack Then

                ' dt = oh.ExecuteDataSet("SELECT -1 AS empcode, 'EMPCODE---EMPNAME---STATUS', -1 as status FROM dual UNION ALL SELECT t.emp_code, t.emp_code || '---' || e.emp_name || '---' || CASE t.status WHEN 1 THEN 'COMPULSORY LEAVE' WHEN 2 THEN 'LATE' WHEN 3 THEN 'EARLY GOING' WHEN 4 THEN 'REGULARISE' || CASE WHEN t.m_regn = 1 AND t.e_regn = 1 THEN '---Morning---Evening' WHEN t.m_regn = 1 THEN '---Morning' WHEN t.e_regn = 1 THEN '---Evening' ELSE '' END ELSE 'UNKNOWN' END AS description,t.status FROM hrm_attendance_regtemp t JOIN employee_master e ON t.emp_code = e.emp_code WHERE t.t_status = 0").Tables(0)
                'dt = oh.ExecuteDataSet("SELECT -1 AS empcode, 'EMPCODE---EMPNAME---STATUS', 'status' FROM dual UNION ALL SELECT t.emp_code, t.emp_code || '---' || e.emp_name || '---' || CASE t.status WHEN 1 THEN 'COMPULSORY LEAVE' WHEN 2 THEN 'LATE' WHEN 3 THEN 'EARLY GOING' WHEN 4 THEN 'REGULARISE' || CASE WHEN t.m_regn = 1 AND t.e_regn = 1 THEN '---Morning---Evening' WHEN t.m_regn = 1 THEN '---Morning' WHEN t.e_regn = 1 THEN '---Evening' ELSE '' END ELSE 'UNKNOWN' END AS description,t.status || '~' || t.emp_code AS status FROM hrm_attendance_regtemp t JOIN employee_master e ON t.emp_code = e.emp_code WHERE t.t_status = 0").Tables(0)
                dt = oh.ExecuteDataSet("SELECT -1 AS empcode, 'EMPCODE---EMPNAME---STATUS', 'status' FROM dual UNION ALL SELECT t.emp_code, t.emp_code || '---' || e.emp_name || '---' || CASE t.status WHEN 1 THEN 'COMPULSORY LEAVE' WHEN 2 THEN 'LATE' WHEN 3 THEN 'EARLY GOING' WHEN 4 THEN 'REGULARISE' || CASE WHEN t.m_regn = 1 AND t.e_regn = 1 THEN '---Morning---Evening' WHEN t.m_regn = 1 THEN '---Morning' WHEN t.e_regn = 1 THEN '---Evening' ELSE '' END ELSE 'UNKNOWN' END AS description, t.status || '~' || t.emp_code ||'~'||t.ldate AS status FROM hrm_attendance_regtemp t JOIN employee_master e ON t.emp_code = e.emp_code WHERE t.t_status = 0").Tables(0)
                Me.ddlEcode.DataSource = dt

                Me.ddlEcode.DataValueField = dt.Columns(2).ColumnName
                Me.ddlEcode.DataTextField = dt.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
                Me.CheckBox1.Visible = False
                spnforgot.Visible = False
                Me.CheckBox2.Visible = False
                spntech.Visible = False
                Me.chkMor.Visible = False
                Me.chkEve.Visible = False
                Me.chk_lop1.Visible = False
                Span1.Visible = False
                Span2.Visible = False
                Me.chk_lop2.Visible = False
                Me.txt_remarks.Visible = False
                Me.tdRemarks.Visible = False

            End If
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If
        'Me.txtDate.Text = Format(Now.Date, "dd/MMM/yyyy")
        'End If
        'Me.CheckBox1.Attributes.Add("onclick")
    End Sub

    'Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
    '    Return cbResult
    'End Function

    'Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

    '    Dim cal_data = eventArgument
    '    Dim str() As String
    '    str = cal_data.ToString.Split("$")
    '    Dim st As New StringBuilder
    '    Dim x = str(0)

    '    Select Case (x)

    '        Case "1"
    '            'Added on 09-03-2017 for RqstID = 12732
    '            'dt = oh.ExecuteDataSet("select e.emp_name|| '*' ||b.BRANCH_NAME || '*' || p.post_name || '*' || d.designation from employee_master e,post_mst p,designation_master d,branch_dtl_new b where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.designation_id=d.designation_id and e.status_id =1 and e.emp_code=" & str(1) & "").Tables(0)
    '            dt = oh.ExecuteDataSet("select e.emp_name|| '*' ||b.BRANCH_NAME || '*' || p.post_name || '*' || d.designation from employee_master e,post_mst p,designation_master d,branch_dtl_new b,employ_firm ef where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.designation_id=d.designation_id and e.status_id =1 and e.emp_code=" & str(1) & "  and ef.firm_id=" & Session("firm_id") & "  and ef.emp_code=e.emp_code").Tables(0)
    '            If dt.Rows.Count = 0 Then
    '                str_tkn.Append("NULL")
    '            Else
    '                str_tkn.Append(dt.Rows(0)(0))
    '                cbResult = str_tkn.ToString
    '            End If
    '    End Select

    'End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If ddlEcode.SelectedValue = "status" Then

            Dim script As String = "alert('Please select Employee..');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script, True)
        Else
            ' Dim stat As Integer
            Dim mreg As Integer = 0
            Dim ereg As Integer = 0
            Dim lop As Integer = 0
            Dim regstatus As Integer = 0
            'Dim sta As String

            Dim selectedValue As String = ddlEcode.SelectedValue.Split("~")(1)
            Dim status As String = ddlEcode.SelectedValue.Split("~")(0)
            Dim ldate As String = ddlEcode.SelectedValue.Split("~")(2)
            Dim usr() As String = Me.Session("user_id").ToString.Split("!")
            Dim approvedBy As String = usr(0)
            dt = oh.ExecuteDataSet("select to_date(t.ldate),status,t.remark,t.m_regn,t.e_regn,t.lop,t.reg_status from HRM_ATTENDANCE_REGTEMP t where t.emp_code=" & selectedValue & " and t.t_status=0 and t.status=" & status & " and to_date(t.ldate)='" & ldate & "'").Tables(0)
            'sta = dt.Rows(0)(1)


            Try
                Dim p(12) As OracleParameter

                p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
                p(0).Direction = ParameterDirection.Input
                p(0).Value = selectedValue


                p(1) = New OracleParameter("UserID", OracleType.Number, 6)
                p(1).Direction = ParameterDirection.Input
                p(1).Value = UserCode

                p(2) = New OracleParameter("Ldate", OracleType.DateTime)
                p(2).Direction = ParameterDirection.Input
                p(2).Value = CDate(Me.txtDate.Text)


                p(3) = New OracleParameter("Sta", OracleType.Number, 2)
                p(3).Direction = ParameterDirection.Input
                p(3).Value = dt.Rows(0)(1)

                p(4) = New OracleParameter("mregn", OracleType.Number, 1)
                p(4).Direction = ParameterDirection.Input
                p(4).Value = dt.Rows(0)(3)


                p(5) = New OracleParameter("eregn", OracleType.Number, 1)
                p(5).Direction = ParameterDirection.Input
                p(5).Value = dt.Rows(0)(4)

                p(6) = New OracleParameter("lop", OracleType.Number, 1)
                p(6).Direction = ParameterDirection.Input
                p(6).Value = dt.Rows(0)(5)

                p(7) = New OracleParameter("remarks", OracleType.VarChar, 75)
                p(7).Direction = ParameterDirection.Input
                p(7).Value = Me.txt_remarks.Text


                p(9) = New OracleParameter("regstatus", OracleType.Number, 1)
                p(9).Direction = ParameterDirection.Input
                p(9).Value = dt.Rows(0)(6)
                'If Me.CheckBox1.Checked = True Then
                '    p(9).Value = 1

                'ElseIf Me.CheckBox1.Checked = False Then
                '    p(9).Value = 0
                'ElseIf Me.CheckBox2.Checked = True Then
                '    p(9).Value = 2
                'ElseIf Me.CheckBox2.Checked = False Then
                '    p(9).Value = 3
                'Else
                '    p(9).Value = 5

                'End If
                p(10) = New OracleParameter("fl", OracleType.Number, 5)
                p(10).Value = 2

                p(11) = New OracleParameter("EnterBy", OracleType.Number, 25)
                p(11).Value = 0

                p(12) = New OracleParameter("Approved_By", OracleType.Number, 25)
                p(12).Value = approvedBy


                p(8) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                p(8).Direction = ParameterDirection.Output

                oh.ExecuteNonQuery("HRM_COMPULSARYLEAVE_MAC", p)
                str_tkn.Append("         alert('" & p(8).Value & "');")
                str_tkn.Append(" window.open('hrm_CompulsoryLeave_Mac_Approve.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/home.aspx")
    End Sub
End Class

