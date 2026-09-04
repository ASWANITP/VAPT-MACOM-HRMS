Imports System.Data
Imports System.Data.OracleClient
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Public Class emp_transfer_approve
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim sql, sql1, sql2, sql3, sql4, sql5 As String
    Dim UserCode As Integer
    Dim UserAll() As String

    Protected Sub cmd_reject_Click(sender As Object, e As EventArgs) Handles cmd_reject.Click
        If cmb_select.SelectedValue = -1 Then

            Dim script As String = "alert('Please Select Employee..');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script, True)
        Else
            Dim fir As String
            Dim detail As String
            fir = Session("firm_id")
            Dim UserAll() As String = Me.Session("user_id").ToString.Split("!")
            Dim approvedBy As String = UserAll(0)
            Dim brid, depid, postid, rperson, flat As String

            sql2 = "select em.branch_id, em.emp_code,em.department_id, em.post_id, em.report_person, em.br_dist, to_char(em.from_dt) from employ_transfer_dtl_temp em, employee_master e where em.emp_code = e.emp_code and em.status = 0 and em.emp_code =" & cmb_select.SelectedValue & ""
            dt2 = oh.ExecuteDataSet(sql2).Tables(0)
            brid = dt2.Rows(0)(0)
            depid = dt2.Rows(0)(2)
            postid = dt2.Rows(0)(3)
            rperson = dt2.Rows(0)(4)
            sql3 = "select em.branch_id, em.department_id, em.post_id, em.report_person, em.br_dist, to_char(em.from_dt), to_char(em.relieve_dt), to_char(em.report_dt) from employ_transfer_dtl_temp em, employee_master e where em.emp_code = e.emp_code and em.status = 1 and em.to_dt = (select max(em.to_dt) from employ_transfer_dtl_temp em where em.to_dt is not null) and em.emp_code = " & cmb_select.SelectedValue & ""
            dt3 = oh.ExecuteDataSet(sql3).Tables(0)
            sql5 = "select h.flat_no from tbl_rent_building_mst bm, tbl_rent_hostel_temp h where h.flat_no=bm.flat_no and h.emp_code = " & cmb_select.SelectedValue & " and h.t_status=0"
            dt5 = oh.ExecuteDataSet(sql5).Tables(0)
            If dt5.Rows.Count > 0 Then
                flat = dt5.Rows(0)(0)
            Else
                flat = ""
            End If
            detail = brid + "|" + cmb_select.SelectedValue + "|" + Me.txt_tfrjoiningdate.Text + "|" + Me.txt_releivingdate.Text + "|" + Me.txt_reportingdate.Text + "|" + depid + "|" + postid + "|" + fir + "|" + rperson


            Dim dist As String = Me.Txt_dis.Text + "|" + flat
            Dim parameter(5) As OracleParameter
            parameter(0) = New OracleParameter("details", OracleType.VarChar, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = detail
            parameter(1) = New OracleParameter("dist", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = dist
            parameter(2) = New OracleParameter("tfr_number", OracleType.VarChar, 150)
            parameter(2).Direction = ParameterDirection.Output

            parameter(3) = New OracleParameter("fl", OracleType.Number, 5)
            parameter(3).Value = 3

            parameter(4) = New OracleParameter("enter_By", OracleType.Number, 5)
            parameter(4).Value = 0

            parameter(5) = New OracleParameter("approve_By", OracleType.Number, 5)
            parameter(5).Value = approvedBy



            oh.ExecuteNonQuery("EMPLOY_TRANSFER_MAC", parameter)


            Dim cl_script1 As New System.Text.StringBuilder
            If Not IsDBNull(parameter(2).Value) AndAlso parameter(2).Value.ToString() <> "" Then
                cl_script1.Append("  alert('" & parameter(2).Value.ToString() & "');")
            Else
                cl_script1.Append("  alert('TRANSFER REJECTED!!!!');")
            End If
            cl_script1.Append("window.open('emp_transfer_approve.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub

    Protected Sub cmb_select_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_select.SelectedIndexChanged
        sql1 = "select a.emp_name,b.designation, c.branch_name, d.post_name, e.dep_name, a.join_dt,a.firm_id from employee_master a, designation_master b, branch_master c, post_mst d, department_mst e where a.emp_code =" & cmb_select.SelectedValue & " and b.designation_id = a.designation_id and c.branch_id = a.branch_id and d.post_id = a.post_id and e.dep_id = a.department_id"
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        Me.txt_name.Text = dt1.Rows(0)(0)
        Me.txt_currentPost.Text = dt1.Rows(0)(3)
        Me.txt_desig.Text = dt1.Rows(0)(1)
        Me.txt_currentdept.Text = dt1.Rows(0)(4)
        Me.txt_currentbranch.Text = dt1.Rows(0)(2)
        Me.txt_joiningdate.Text = dt1.Rows(0)(5)

        Dim firm As String = "select firm_name from firm_master where firm_id=" & dt1.Rows(0)(6) & ""
        dt = oh.ExecuteDataSet(firm).Tables(0)
        Me.Txt_firm.Text = dt.Rows(0)(0)


        sql2 = "select b.branch_name, d.dep_name, p.post_name, em.report_person, em.br_dist, to_char(em.from_dt) from employ_transfer_dtl_temp em, branch_master b, department_mst d, post_mst p, employee_master e where em.branch_id = b.branch_id and em.department_id = d.dep_id and em.post_id = p.post_id and em.emp_code = e.emp_code and em.status = 0 and em.emp_code=" & cmb_select.SelectedValue & ""
        dt2 = oh.ExecuteDataSet(sql2).Tables(0)
        sql3 = "select b.branch_name, d.dep_name, p.post_name, em.report_person, em.br_dist, to_char(em.from_dt),to_char(em.relieve_dt),to_char(em.report_dt) from employ_transfer_dtl_temp em, branch_master b, department_mst d, post_mst p, employee_master e where em.branch_id = b.branch_id and em.department_id = d.dep_id and em.post_id = p.post_id and em.emp_code = e.emp_code and em.status = 1 and em.to_dt=(select max(em.to_dt) from employ_transfer_dtl_temp em where em.to_dt is not null and em.emp_code=" & cmb_select.SelectedValue & ") and em.emp_code=" & cmb_select.SelectedValue & ""
        dt3 = oh.ExecuteDataSet(sql3).Tables(0)
        Me.cmb_newbranch.Text = dt2.Rows(0)(0)
        Me.cmb_newdept.Text = dt2.Rows(0)(1)
        Me.cmb_newpost.Text = dt2.Rows(0)(2)
        Me.txt_releivingdate.Text = dt3.Rows(0)(6)
        Me.txt_tfrjoiningdate.Text = dt2.Rows(0)(5)
        Me.txt_reportingdate.Text = dt3.Rows(0)(7)
        Me.Txt_dis.Text = dt2.Rows(0)(4)
        sql4 = "select post_id,post_name from post_mst where post_id=" & dt2.Rows(0)(3) & ""
        dt4 = oh.ExecuteDataSet(sql4).Tables(0)
        Me.cmb_report_person.Text = dt4.Rows(0)(1)

        sql5 = "select bm.flat_name, ca.rent_category_name, s.state_name from tbl_rent_hostel_temp h, tbl_rent_building_mst bm, tbl_rent_category ca, state_master s, branch b where h.flat_no=bm.flat_no and bm.rent_category_id=ca.rent_category_id and bm.branch_id=b.BRANCH_ID and b.STATE_ID=s.state_id and h.emp_code =" & cmb_select.SelectedValue & " and h.t_status=0 "
        dt5 = oh.ExecuteDataSet(sql5).Tables(0)
        If dt5.Rows.Count > 0 Then
            Me.cmb_cat.Text = dt5.Rows(0)(1)
            Me.cmb_hostel.Text = dt5.Rows(0)(0)
            Me.cmb_state.Text = dt5.Rows(0)(2)
        Else
            Me.cmb_cat.Text = ""
            Me.cmb_hostel.Text = ""
            Me.cmb_state.Text = ""
        End If
    End Sub

    Protected Sub cmd_clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        Server.Transfer("emp_transfer_approve.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cs As String = "var cont_name;cont_name='" & Me.txt_releivingdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        Dim script_val As String = "var disb ; disb='" & Me.cmd_confirm.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "Slll", script_val, True)
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=134 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            If Not IsPostBack Then
                sql = "select -1 as empcode, 'Empcode---Employee Name' as empname from dual union all select tr.emp_code, e.emp_name from employ_transfer_dtl_temp tr, employee_master e,employ_firm f where tr.emp_code = e.emp_code and tr.emp_code=f.emp_code and e.status_id=1 and tr.status = 0"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If (dt.Rows.Count < 1) Then
                    Me.cmb_select.Items.Add("No Employee Waiting ")

                Else
                    Me.cmb_select.DataSource = dt
                    Me.cmb_select.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_select.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_select.DataBind()
                End If
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If

    End Sub
    Sub clear()
        Me.txt_name.Text = ""
        Me.txt_desig.Text = ""
        Me.txt_currentbranch.Text = ""
        Me.txt_currentdept.Text = ""
        Me.txt_currentPost.Text = ""
        Me.txt_joiningdate.Text = ""
        Me.Txt_firm.Text = ""
    End Sub
    Protected Sub cmd_confirm_Click(sender As Object, e As EventArgs) Handles cmd_confirm.Click
        If cmb_select.SelectedValue = -1 Then

            Dim script As String = "alert('Please Select Employee..');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script, True)
        Else

            Dim fir As String
            Dim detail, curr_det As String
            fir = Session("firm_id")
            Dim UserAll() As String = Me.Session("user_id").ToString.Split("!")
            Dim approvedBy As String = UserAll(0)
            Dim brid, depid, postid, rperson, flat As String
            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")
            sql3 = "select nvl(deputation_id,0) from employ_transfer_dtl_temp where to_dt is null and emp_code='" & Me.cmb_select.Text & "'"
            dt4 = oh.ExecuteDataSet(sql3).Tables(0)
            Dim def As String
            If (dt4.Rows.Count <= 0) Then
                def = 0
            Else
                def = dt4.Rows(0)(0)
            End If
            Dim sql2 As String = "update employ_transfer_dtl set enter_by=" & sf(0) & " where emp_code='" & Me.cmb_select.Text & "' and to_dt is null"
            oh.ExecuteNonQuery(sql2)
            sql2 = "select em.branch_id, em.emp_code,em.department_id, em.post_id, em.report_person, em.br_dist, to_char(em.from_dt) from employ_transfer_dtl_temp em, employee_master e where em.emp_code = e.emp_code and em.status = 0 and em.emp_code =" & cmb_select.SelectedValue & ""
            dt2 = oh.ExecuteDataSet(sql2).Tables(0)
            brid = dt2.Rows(0)(0)
            depid = dt2.Rows(0)(2)
            postid = dt2.Rows(0)(3)
            rperson = dt2.Rows(0)(4)
            sql3 = "select em.branch_id, em.department_id, em.post_id, em.report_person, em.br_dist, to_char(em.from_dt), to_char(em.relieve_dt), to_char(em.report_dt) from employ_transfer_dtl_temp em, employee_master e where em.emp_code = e.emp_code and em.status = 1 and em.to_dt = (select max(em.to_dt) from employ_transfer_dtl_temp em where em.to_dt is not null) and em.emp_code = " & cmb_select.SelectedValue & ""
            dt3 = oh.ExecuteDataSet(sql3).Tables(0)
            sql5 = "select h.flat_no from tbl_rent_building_mst bm, tbl_rent_hostel_temp h where h.flat_no=bm.flat_no and h.emp_code = " & cmb_select.SelectedValue & " and h.t_status=0"
            dt5 = oh.ExecuteDataSet(sql5).Tables(0)
            If dt5.Rows.Count > 0 Then
                flat = dt5.Rows(0)(0)
            Else
                flat = ""
            End If
            Dim firm As String
            sql2 = "select firm_id from employee_master where emp_code='" & Me.cmb_select.Text & "'"
            dt3 = oh.ExecuteDataSet(sql2).Tables(0)
            Dim crf As String = dt3.Rows(0)(0)
            firm = crf + "|" + def


            fir = Session("firm_id")
            detail = brid + "|" + cmb_select.SelectedValue + "|" + Me.txt_tfrjoiningdate.Text + "|" + Me.txt_releivingdate.Text + "|" + Me.txt_reportingdate.Text + "|" + depid + "|" + postid + "|" + fir + "|" + rperson
            curr_det = Me.txt_name.Text + "~" + Me.txt_desig.Text + "~" + Me.txt_currentPost.Text + "~" + Me.txt_currentdept.Text + "~" + Me.txt_currentbranch.Text + "~" + Me.txt_joiningdate.Text + "~" + Me.Txt_firm.Text

            Dim dist As String = Me.Txt_dis.Text + "|" + flat
            Dim parameter(5) As OracleParameter
            parameter(0) = New OracleParameter("details", OracleType.VarChar, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = detail
            parameter(1) = New OracleParameter("dist", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = dist
            parameter(2) = New OracleParameter("tfr_number", OracleType.VarChar, 150)
            parameter(2).Direction = ParameterDirection.Output

            parameter(3) = New OracleParameter("fl", OracleType.Number, 5)
            parameter(3).Value = 2

            parameter(4) = New OracleParameter("enter_By", OracleType.Number, 5)
            parameter(4).Value = 0

            parameter(5) = New OracleParameter("approve_By", OracleType.Number, 5)
            parameter(5).Value = approvedBy



            oh.ExecuteNonQuery("EMPLOY_TRANSFER_MAC", parameter)

            'clear()
            ''init_fill()
            'Me.lbl_date.Text = ""
            'Dim cl_script1 As New System.Text.StringBuilder
            'If parameter(2).Value <> "" Then
            '    cl_script1.Append("  alert('" & parameter(2).Value & "');")
            'Else
            '    cl_script1.Append("  alert('TRANSFER CONFIRMED SUCCESSFULLY!!!!');")
            'End If

            ''cl_script1.Append("window.open('Payroll_Transfer.aspx?dtl=" & detail & "&no=" & parameter(2).Value & "&cr_dt=" & curr_det & "&frm=" & firm & "&dis=" & dist & "');")
            'cl_script1.Append("window.open('emp_transfer_approve.aspx','_self');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


            Dim paramValue As String = ""

            If Not IsDBNull(parameter(2).Value) Then
                paramValue = parameter(2).Value.ToString()
            End If
            If (paramValue = "Proposed Branch Has Same State Employee" Or
                paramValue = "Transfer Is Not Possible,User not Authorised" Or
                paramValue = "Same State Transfer Is Not Allowed In The Case Of Jr.Asst (T-NG)" Or
                paramValue = "This Branch Is Not Having 4 Crore Bussiness For transfering Jr-Officer & Above") Then

                Me.lbl_msg.Text = paramValue
                Exit Sub
            Else
                'Me.txt_tfrjoiningdate.Text = ""
                'Me.txt_releivingdate.Text = ""
                'Me.txt_reportingdate.Text = ""
                'clear()
                'init_fill()
                Me.lbl_date.Text = ""
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("  alert('TRANSFER CONFIRMED SUCCESSFULLY!!!!');")
                'Dim encodedCurrDet = HttpUtility.UrlEncode(curr_det)
                'cl_script1.Append("window.open('Payroll_Transfer.aspx?dtl=" & detail & "&no=" & parameter(2).Value & "&cr_dt=" & encodedCurrDet & "&frm=" & firm & "&dis=" & dist & "');")
                cl_script1.Append("window.open('emp_transfer_approve.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
        End If

    End Sub


    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Dim script1 As New System.Text.StringBuilder
        script1.Append("window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub

End Class