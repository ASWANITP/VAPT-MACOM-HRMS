Imports System.Data
Imports System.Data.OracleClient
Partial Class New_folder__3_Self_cancell_resign_6e4849046935
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dtq As New DataTable
    Dim UserAll(), res, sql, str As String

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim usr() As String

        usr = Me.Session("user_id").ToString.Split("!")
        If Me.Text_remar.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Please Enter Remarks!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If

        sql = "select t.status as stat from m_resign_appl t where t.emp_code ='" & usr(0) & "' and t.status<>3"

        dtq = oh.ExecuteDataSet(sql).Tables(0)
        If dtq.Rows(0)(0) = 0 Then
            Dim parameter(2) As OracleParameter
            parameter(0) = New OracleParameter("code", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.lbl_code.Text

            parameter(1) = New OracleParameter("reas", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.Text_remar.Text

            parameter(2) = New OracleParameter("msg", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("m_resigning_can_self", parameter)
            If parameter(2).Value = 1 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Cancelled successfully!!');")
                cl_script1.Append("window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                'Server.Transfer("cancel_resign.aspx")
                Exit Sub
            End If
            If parameter(2).Value = 2 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('No Such application Exist for Cancellation!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If
            If parameter(2).Value = 3 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
                ' cl_script1.Append("window.open('cancel_resign.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If
        ElseIf dtq.Rows(0)(0) = 1 Then
            Dim parameter(2) As OracleParameter
            parameter(0) = New OracleParameter("code", OracleType.Number, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = Me.lbl_code.Text

            parameter(1) = New OracleParameter("reas", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Me.Text_remar.Text

            parameter(2) = New OracleParameter("msg", OracleType.Number, 150)
            parameter(2).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("m_resigning_can_self2", parameter)
            If parameter(2).Value = 1 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Cancelled successfully!!');")
                cl_script1.Append("window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                'Server.Transfer("cancel_resign.aspx")
                Exit Sub
            End If
            If parameter(2).Value = 2 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('No Such application Exist for Cancellation!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If
            If parameter(2).Value = 3 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("        alert('Error ...Contact IT Department...!!');")
                ' cl_script1.Append("window.open('cancel_resign.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Exit Sub
            End If
        End If

        'Server.Transfer("cancel_resign.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim usr() As String

        usr = Me.Session("user_id").ToString.Split("!")
        Dim ff As Integer = Session("firm_id")

        If ff <> 2 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('You are not Authorised to Visit This Page!!');")
            cl_script1.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If


        Dim dt3 As DataTable = oh.ExecuteDataSet("select count(t.emp_code) from m_resign_appl t where t.status=6 and t.emp_code='" & usr(0) & "'").Tables(0)
        If dt3.Rows(0)(0) = 1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Already Cancelled!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
       
        If Not IsPostBack Then
            sql = "select r.emp_code||' --- '||e.emp_name||'  ---  Branch: '||b.branch_name,e.emp_code from m_resign_appl r,employee_master e,branch b,employ_firm f where e.emp_code=r.emp_code and e.EMP_CODE=f.emp_code and f.firm_id=" & ff & " and e.branch_id=b.branch_id and r.status in (0,1) and e.status_id=1 order by emp_code"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code,emp_name from employee_master where emp_code='" & usr(0) & "' and status_id=1 ").Tables(0)
                Dim dt2 As DataTable = oh.ExecuteDataSet("select to_date(r.resign_dt), u.categ || ' -- ' || w.college_nm || ' , ' || w.course || ' , ' || w.durtion as reason, to_date(r.relieve_dt) from m_resign_appl r, resign_reason_mst u, resign_higherstudies_reason w where r.emp_code = '" & usr(0) & "' and r.reason = u.categ_id and w.emp_code = r.emp_code and to_date(r.resign_dt) = to_date(w.tra_dt) and w.status = r.status and r.status in (1,0) union select to_date(r.resign_dt), u.categ || ' -- ' || q.reason as reason, to_date(r.relieve_dt) from m_resign_appl r, resign_reason_mst u, resign_personal_reason q where u.categ_id = r.reason and r.emp_code = '" & usr(0) & "' and q.emp_code = r.emp_code and to_date(r.resign_dt) = to_date(q.tra_dt) and q.status = r.status and r.status in (1,0) union select to_date(r.resign_dt), u.categ || ' -- ' || q1.firm || ' , ' || q1.reason || ' , ' || q1.nature_work || ' , ' || q1.salary as reason, to_date(r.relieve_dt) from m_resign_appl r, resign_reason_mst u, resign_otheremploy_reason q1 where r.emp_code = '" & usr(0) & "' and r.reason = u.categ_id and q1.emp_code = r.emp_code and to_date(r.resign_dt) = to_date(q1.tra_dt) and q1.status = r.status and r.status in (1,0) union select to_date(r.resign_dt), u.categ || ' -- ' || q.reason as reason, to_date(r.relieve_dt) from m_resign_appl r, resign_reason_mst u, resign_personal_reason q where r.emp_code = '" & usr(0) & "' and u.categ_id = r.reason and q.emp_code = r.emp_code and to_date(r.resign_dt) = to_date(q.tra_dt) and q.status = r.status and r.status in (1,0) union select to_date(r.resign_dt), u.categ || ' -- ' || q2.partner_name || ' , ' || q2.job_partner || ' , ' || q2.place_marriage as reason, to_date(r.relieve_dt) from m_resign_appl r, resign_reason_mst u, resign_marriage_reason q2 where r.emp_code = '" & usr(0) & "' and r.reason = u.categ_id and q2.emp_code = r.emp_code and to_date(r.resign_dt) = to_date(q2.tra_dt) and q2.status = r.status and r.status in (1,0) union select to_date(r.resign_dt), u.categ || ' -- ' || q3.reason as reason, to_date(r.relieve_dt) from m_resign_appl r, resign_reason_mst u, resign_other_reason q3 where r.emp_code = '" & usr(0) & "' and u.categ_id = r.reason and q3.emp_code = r.emp_code and to_date(r.resign_dt) = to_date(q3.tra_dt) and q3.status = r.status and r.status in (1,0)").Tables(0)
                If dt2.Rows.Count = 0 Then
                    Dim cl_script11 As New System.Text.StringBuilder
                    cl_script11.Append("        alert('No Data Found...!!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
                    Exit Sub

                End If
                Me.lbl_code.Text = dt1.Rows(0)(0)
                Me.txt_name.Text = dt1.Rows(0)(1)
                Me.Txt_rsdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")
                Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(0)), "dd/MMM/yyyy")


                'If IsDBNull(dt2.Rows(0)(2)) Then
                '    Me.Txt_rdt.Text = ""
                'Else
                '    Me.Txt_rdt.Text = Format(CDate(dt2.Rows(0)(2)), "dd/MMM/yyyy")
                'End If

                If IsDBNull(dt2.Rows(0)(1)) Then
                    Me.Txt_rea.Text = " "
                Else
                    Me.Txt_rea.Text = dt2.Rows(0)(1)
                End If

            
            Else
                Dim cl_script11 As New System.Text.StringBuilder
                cl_script11.Append("        alert('No Data Found...!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)

            End If
        End If

    End Sub
End Class
