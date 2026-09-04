
Imports System.Data
Imports System.Data.OracleClient
Public Class increment_all_approve
    Inherits System.Web.UI.Page
    'Implements System.Web.UI.ICallbackEventHandler
    Dim res As String
    Dim tot As Integer


    Dim str, str1 As String
    Dim sql, sql1 As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable

    Protected Sub cmd_report_Click(sender As Object, e As EventArgs) Handles cmd_report.Click
        Dim frd As Integer = Session("firm_id")
        Dim df() As String
        Dim da, amnt As Decimal
        Dim empcode As Integer = cmb_employee.SelectedValue
        If Me.cmb_employee.SelectedValue = 0 Then
            Dim msgbx As New System.Text.StringBuilder
            msgbx.Append("         alert('PLEASE SELECT EMPLOYEE');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
        Else

            sql = "select t.emp_code,t.designation_id,t.basic_pay,t.payment_id from EMPLOY_PROMOTION_DTL t where t.emp_code=" & empcode & " order by t.enter_dt desc"
            dt2 = oh.ExecuteDataSet(sql).Tables(0)
            Dim dg As DataTable = oh.ExecuteDataSet("select payment_id||'!'||designation_id,designation from designation_master where designation_id=" & dt2.Rows(0)(1) & " ").Tables(0)
            df = dg.Rows(0)(0).split("!")
            'If Me.cmb_basic.Items.Count > 0 Then
            If df(0) <> 14 Then
                dt4 = oh.ExecuteDataSet("select value from da_index where to_dt is NULL  and firm_id=" & frd & "").Tables(0)

                da = CDec(dt4.Rows(0)(0))

            Else
                da = 0
            End If
            'End If
            Dim cl_script1 As New System.Text.StringBuilder
            'If Me.cmb_basic.Text <> "NOT IN THE LIST AND WANT TO ENTER..?" Then
            '    amnt = Me.cmb_basic.value
            'Else
            If Me.txt_amount.Value = "" Then
                amnt = 0
            Else
                amnt = Me.txt_amount.Value

            End If
            'End If
            sql = "select nvl(approve_remarks,'-') from employ_promotion_dtl where emp_code=" & Me.cmb_employee.SelectedValue & " and to_dt is null"
            dt4 = oh.ExecuteDataSet(sql).Tables(0)
            Dim aj As String = ""
            If Me.text_remark.Value <> "" Then
                aj = Me.text_remark.Value
            Else
                aj = dt4.Rows(0)(0)
            End If
            cl_script1.Append("window.open('increment_report.aspx?name=" & Me.txt_name.Value & "&post=" & Me.txt_post.Value & "&cbasic=" & Me.txt_basic.Value & "&firm=" & Me.txt_firm.Value & "&des=" & Me.txt_designtn.Value & "&dep=" & Me.txt_deptmnt.Value & "&brn=" & Me.txt_branch.Value & "&jod=" & Me.txt_joindt.Value & "&efdt=" & Me.txt_effdt.Value & "&ecode=" & Me.cmb_employee.SelectedValue & "&pbasic=" & amnt & "&remark=" & aj & "&da=" & da & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub

    Protected Sub cmd_reject_Click(sender As Object, e As EventArgs) Handles cmd_reject.Click
        Dim oh As New Helper.Oracle.OracleHelper
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim ApproveBy As String = usr(0)
        Dim op(9) As OracleParameter
        Dim frd As Integer = Session("firm_id")
        If cmb_employee.SelectedValue = 0 Then

            Dim script As String = "alert('Please select an employee...');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script, True)
        Else

            op(0) = New OracleParameter("empcode", OracleType.Number, 10)
            op(0).Value = Me.cmb_employee.SelectedValue
            op(0).Direction = ParameterDirection.Input

            op(1) = New OracleParameter("payid", OracleType.Number, 5)
            op(1).Value = 0
            op(1).Direction = ParameterDirection.Input

            op(2) = New OracleParameter("basic", OracleType.Number, 5)
            op(2).Value = Me.txt_amount.Value
            op(2).Direction = ParameterDirection.Input

            op(3) = New OracleParameter("eff_dt", OracleType.DateTime, 12)
            op(3).Value = Me.txt_effdt.Value
            op(3).Direction = ParameterDirection.Input

            op(4) = New OracleParameter("remark", OracleType.VarChar, 25)
            op(4).Value = Me.text_remark.Value
            op(4).Direction = ParameterDirection.Input

            op(5) = New OracleParameter("usrid", OracleType.VarChar, 25)
            op(5).Value = Session("user_id")
            op(5).Direction = ParameterDirection.Input

            op(6) = New OracleParameter("EnterBy", OracleType.Number, 25)
            op(6).Value = 0
            'op(6).Direction = ParameterDirection.Input

            op(9) = New OracleParameter("Approved_By", OracleType.Number, 25)
            op(9).Value = ApproveBy
            op(9).Direction = ParameterDirection.Input

            op(7) = New OracleParameter("fl", OracleType.Number, 5)
            op(7).Value = 3

            op(8) = New OracleParameter("update_flag", OracleType.Number)
            op(8).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("EMPLOY_SAL_INCREMENT_MACOM", op)

            Dim script1 As New System.Text.StringBuilder
            If op(8).Value = 1 Then

                script1.Append("        alert('Rejected!!');")
                script1.Append("       window.open('increment_all_approve.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            Else
                script1.Append("        alert('Sorry,An Error Occured!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            End If
        End If
    End Sub

    Protected Sub cmb_employee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_employee.SelectedIndexChanged
        Dim frd As Integer = Session("firm_id")
        Dim empcode As Integer = cmb_employee.SelectedValue

        sql = "select e.emp_code,e.emp_name,p.post_name,d.designation,dd.dep_name,b.branch_name,e.join_dt,fm.firm_name,e.basic_pay from employee_master e, employ_firm f,designation_master d,post_mst p,branch_master b,firm_master fm,department_mst dd where e.emp_code = f.emp_code and e.emp_code=" & empcode & "and e.post_id=p.post_id and e.designation_id=d.designation_id and e.branch_id=b.branch_id and e.firm_id=fm.firm_id and e.department_id=dd.dep_id and e.status_id = 1 and e.emp_code > 9999 and f.firm_id = 8 and e.shift_id not in (4, 5) order by emp_code"
        dt = oh.ExecuteDataSet(sql).Tables(0)

        Me.txt_name.Value = dt.Rows(0)(1)
        Me.txt_post.Value = dt.Rows(0)(2)
        Me.txt_designtn.Value = dt.Rows(0)(3)
        Me.txt_deptmnt.Value = dt.Rows(0)(4)
        Me.txt_branch.Value = dt.Rows(0)(5)
        Me.txt_joindt.Value = dt.Rows(0)(6)
        Me.txt_firm.Value = dt.Rows(0)(7)
        Me.txt_basic.Value = dt.Rows(0)(8)

        sql = "select t.emp_code,t.designation_id,t.basic_pay,t.payment_id,t.from_dt,t.enter_dt,t.status_id, t.recom_remarks,t.status,t.enter_by from EMPLOY_PROMOTION_TEMP t where t.emp_code=" & empcode & " and t.status=0 "
        dt2 = oh.ExecuteDataSet(sql).Tables(0)

        sql = "select payment_id,t.designation_id,designation from designation_master t where t.designation_id=" & dt2.Rows(0)(1) & ""
        dt1 = oh.ExecuteDataSet(sql).Tables(0)
        Me.cmb_pay.Value = dt1.Rows(0)(2)
        Me.txt_amount.Value = dt2.Rows(0)(2)
        Dim basic_amt As Integer = Me.txt_amount.Value
        Me.txt_effdt.Value = dt2.Rows(0)(4)
        'Me.txt_totalsal.Text = dt2.Rows(0)(0)
        If dt2.Rows(0)(7) = "" Then
            Me.text_remark.Value = ""
        Else
            Me.text_remark.Value = dt2.Rows(0)(7)
        End If

        If dt1(0)(0) <> 14 Then
            dt4 = oh.ExecuteDataSet("select value from da_index where to_dt is NULL  and firm_id=" & frd & "").Tables(0)
            Dim sal As Decimal
            sal = CDec(basic_amt) + CDec(dt4.Rows(0)(0))
            Me.txt_totalsal.Value = sal
        Else
            Me.txt_totalsal.Value = CDec(basic_amt)
        End If



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cs As String = "var cont_name;cont_name='" & Me.cmb_employee.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)




        Dim fid As Integer = Session("firm_id")
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=134 and emp_id=" & usr(0) & "").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Response.Redirect("../../show_err.aspx")
        End If
        If Session("access_id") = 33 Then
            If Not IsPostBack Then

                sql = "select 'SELECT EMPLOYEE', 0 emp_code from dual union select e.emp_code || '--------' || e.emp_name, e.emp_code from employee_master e, employ_firm f,employ_promotion_temp em where e.emp_code = f.emp_code and e.emp_code=em.emp_code and em.status=0 and e.status_id = 1 and e.emp_code > 9999 and f.firm_id = " & fid & " and e.shift_id not in (4, 5) order by emp_code"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If (dt.Rows.Count < 1) Then
                    Me.cmb_employee.Items.Add("No Employee Waiting ")
                Else
                    Me.cmb_employee.DataSource = dt
                    Me.cmb_employee.DataTextField = dt.Columns(0).ColumnName
                    Me.cmb_employee.DataValueField = dt.Columns(1).ColumnName
                    Me.cmb_employee.DataBind()
                End If
            End If
            'Me.cmb_employee.Attributes.Add("onchange", "fill1()")
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../../home.aspx")
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        Dim oh As New Helper.Oracle.OracleHelper
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim ApproveBy As String = usr(0)
        'Dim amnt As Integer
        Dim op(9) As OracleParameter
        Dim frd As Integer = Session("firm_id")
        If cmb_employee.SelectedValue = 0 Then

            Dim script As String = "alert('Please select an employee...');"
            ClientScript.RegisterStartupScript(Me.GetType(), "alertScript", script, True)
        Else
            sql = "select t.emp_code,t.designation_id,t.basic_pay,t.payment_id,t.from_dt,t.enter_dt,t.status_id,t.approve_remarks,t.status,t.enter_by from EMPLOY_PROMOTION_TEMP t where t.emp_code=" & Me.cmb_employee.SelectedValue & ""
            dt2 = oh.ExecuteDataSet(sql).Tables(0)
            sql = "select payment_id,t.designation_id,designation from designation_master t where t.designation_id=" & dt2.Rows(0)(1) & ""
            dt1 = oh.ExecuteDataSet(sql).Tables(0)

            op(0) = New OracleParameter("empcode", OracleType.Number, 10)
            op(0).Value = Me.cmb_employee.SelectedValue
            op(0).Direction = ParameterDirection.Input

            op(1) = New OracleParameter("payid", OracleType.Number, 5)
            op(1).Value = dt1(0)(0)
            op(1).Direction = ParameterDirection.Input

            op(2) = New OracleParameter("basic", OracleType.Number, 5)
            op(2).Value = Me.txt_amount.Value
            op(2).Direction = ParameterDirection.Input

            op(3) = New OracleParameter("eff_dt", OracleType.DateTime, 12)
            op(3).Value = Me.txt_effdt.Value
            op(3).Direction = ParameterDirection.Input

            op(4) = New OracleParameter("remark", OracleType.VarChar, 25)
            op(4).Value = Me.text_remark.Value
            op(4).Direction = ParameterDirection.Input

            op(5) = New OracleParameter("usrid", OracleType.VarChar, 25)
            op(5).Value = Session("user_id")
            op(5).Direction = ParameterDirection.Input

            op(6) = New OracleParameter("EnterBy", OracleType.Number, 25)
            op(6).Value = 0
            'op(6).Direction = ParameterDirection.Input

            op(9) = New OracleParameter("Approved_By", OracleType.Number, 25)
            op(9).Value = ApproveBy
            op(9).Direction = ParameterDirection.Input

            op(7) = New OracleParameter("fl", OracleType.Number, 5)
            op(7).Value = 1

            op(8) = New OracleParameter("update_flag", OracleType.Number)
            op(8).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("EMPLOY_SAL_INCREMENT_MACOM", op)


            'Dim cl_script0 As New System.Text.StringBuilder
            'cl_script0.Append("         alert(' Sucessfully Approved');")
            ''cl_script0.Append("       window.open('increment_report.aspx?name=" & Me.txt_name.Value & "&post=" & Me.txt_post.Value & "&cbasic=" & Me.txt_basic.Value & "&firm=" & Me.txt_firm.Value & "&des=" & Me.txt_designtn.Value & "&dep=" & Me.txt_deptmnt.Value & "&brn=" & Me.txt_branch.Value & "&jod=" & Me.txt_joindt.Value & "&efdt=" & Me.txt_effdt.Text & "&ecode=" & Me.cmb_employee.SelectedValue & "&remark=" & Me.text_remark.Text & "&pbasic=" & amnt & "&da=" & da & "');")
            ''cl_script0.Append("       window.open('increment_all.aspx','_self');")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            Dim script1 As New System.Text.StringBuilder
            If op(8).Value = 1 Then

                script1.Append("        alert('Successfully Approved');")
                'script1.Append("       window.open('increment_report.aspx?name=" & Me.txt_name.Value & "&post=" & Me.txt_post.Value & "&cbasic=" & Me.txt_basic.Value & "&firm=" & Me.txt_firm.Value & "&des=" & Me.txt_designtn.Value & "&dep=" & Me.txt_deptmnt.Value & "&brn=" & Me.txt_branch.Value & "&jod=" & Me.txt_joindt.Value & "&efdt=" & Me.txt_effdt.Text & "&ecode=" & Me.cmb_employee.SelectedValue & "&remark=" & Me.text_remark.Text & "&pbasic=" & amnt & "&da=" & da & "');")
                script1.Append("       window.open('increment_all_approve.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            Else
                script1.Append("        alert('Sorry,An Error Occured!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

            End If
        End If
    End Sub

End Class



