Imports System.Data
Imports System.Data.OracleClient
Partial Class PayRoll_Py_Sus_Revo_ce58b57d5528
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim e_dtl(4) As String
    Dim rescnt As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.lst_emp.Items.Clear()
            'Me.lbl_emp.Visible = False
            'Me.TABLE1.Visible = False
            'lbl_fdt.Text = "Suspention Date"
            Dim cont_name As String
            cont_name = "var cl_name;cl_name='" & Me.txt_ecode.ClientID & "';"
            Me.ClientScript.RegisterClientScriptBlock(Me.GetType, "con_name", cont_name, True)
        End If
    End Sub
    Public Function listfill(ByVal ecode As Integer)
        'rescnt = oh.ExecuteDataSet("select count(*) from employee_resigtermi a where a.emp_code = " & ecode & " and a.status_id = 3").Tables(0).Rows(0)(0)
        'If rescnt = 0 Then   ' Not entered in empresigtermi
        'dt = oh.ExecuteDataSet("select em.emp_name||'('||em.emp_code||')',pm.post_name ,em.emp_code from employee_master em,post_mst pm where em.emp_code=" & ecode & " and em.post_id=pm.post_id").Tables(0)
        dt = oh.ExecuteDataSet("select em.emp_name||'('||em.emp_code||')',dpm.dep_name,pm.post_name,dm.designation,bm.branch_name,em.emp_code from employee_master em,designation_master dm,post_mst pm,department_mst dpm,branch_master bm where em.designation_id=dm.designation_id and em.post_id=pm.post_id and em.department_id=dpm.dep_id and bm.branch_id=em.branch_id and em.status_id in(1,4)  and em.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") and em.emp_code=" & ecode & " union select em.emp_name||'('||em.emp_code||')',dpm.dep_name,pm.post_name,dm.designation,bc.branch_name,em.emp_code from employee_master em,designation_master dm,post_mst pm,department_mst dpm,before_completion bc where em.designation_id=dm.designation_id and em.post_id=pm.post_id and em.department_id=dpm.dep_id and bc.old_id=em.branch_id and bc.branch_id is null and em.status_id in(1,4) and em.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") and em.emp_code=" & ecode & "").Tables(0)
        Dim i As New Integer
        If dt.Rows.Count > 0 Then
            e_dtl(0) = "Employee  : "
            e_dtl(1) = "Department : "
            e_dtl(2) = "Post : "
            e_dtl(3) = "Designation : "
            e_dtl(4) = "Branch : "
            For i = 0 To dt.Columns.Count - 2
                lst_emp.Items.Add(e_dtl(i) + dt.Rows(0)(i))
                lst_emp.DataBind()
            Next
            h_ecode.Value = dt.Rows(0)(5)
        Else
            lst_emp.Items.Add("NO SUCH EMPLOYEE")
            lst_emp.DataBind()
        End If
    End Function
    Protected Sub txt_ecode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ecode.TextChanged
        rescnt = oh.ExecuteDataSet("select count(*) from employee_resigtermi a where a.emp_code = " & Me.txt_ecode.Text & " and a.status_id = 3").Tables(0).Rows(0)(0)
        If rescnt = 0 Then   ' Not entered in empresigtermi
            Me.lst_emp.Items.Clear()
            If Me.txt_ecode.Text <> "" Then
                listfill(Val(Me.txt_ecode.Text))
                Me.Button1.Enabled = True
            End If
        ElseIf rescnt = 1 Then  'One row exists..!!
            Dim reas As String = oh.ExecuteDataSet("select to_char(a.discont_dt)||' with Reason : '||decode(a.remarks,null,'No Reason Entered..!!',a.remarks) from employee_resigtermi a where a.emp_code = " & Me.txt_ecode.Text & " and a.status_id = 3").Tables(0).Rows(0)(0)
            Dim cl_script_a As New System.Text.StringBuilder
            cl_script_a.Append("    alert('This Employee already put Resignation on " & reas & "..!!\n So Please Cancel Resignation on that Date and then Retry..!!');")
            cl_script_a.Append("       window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script_a.ToString, True)
        Else   'More than One row exists..!!
            Dim cl_script_b As New System.Text.StringBuilder
            cl_script_b.Append("    alert('For this Employee there exists more than one Resignation Dates..\nSo Please inform IT immediately and Cancel Resignation on that Dates and then Retry..!!');")
            cl_script_b.Append("       window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script_b.ToString, True)
        End If

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.txt_RoTdt.Text <> "" And Me.lst_emp.Items.Count > 2 Then

            Dim p(6) As OracleParameter
            p(0) = New OracleParameter("ecode", OracleType.Number, 5)
            p(0).Value = Val(h_ecode.Value)
            p(1) = New OracleParameter("eff_dt", OracleType.DateTime)
            If Me.txt_NoRdt.Text = "" Then
                p(1).Value = "15/AUG/1947"
            Else
                p(1).Value = CDate(Me.txt_NoRdt.Text)
            End If
            '///effective date
            p(6) = New OracleParameter("eff2_dt", OracleType.DateTime)
            p(6).Value = CDate(Me.txt_RoTdt.Text)
            p(2) = New OracleParameter("rmrk", OracleType.Char, 250)
            p(2).Value = Me.txt_remark.Text
            p(3) = New OracleParameter("opt", OracleType.Number, 1)
            If Me.rad_resig.Checked = True Then
                p(3).Value = 3
            Else
                p(3).Value = 4
            End If
            p(4) = New OracleParameter("aprv_ecode", OracleType.Number, 1)
            p(4).Value = CInt(Session("user_id").ToString.Split("!")(0))
            p(5) = New OracleParameter("status", OracleType.Number, 1)
            p(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("Pay_SusRevok", p)
            If p(5).Value = 1 Then



                Dim stat As Integer
                stat = oh.ExecuteDataSet("select e.status_id from employee_master e where e.emp_code=" & Val(h_ecode.Value) & "").Tables(0).Rows(0)(0)

                If stat = 1 Then
                    Dim cl_script12 As New System.Text.StringBuilder
                    cl_script12.Append("         alert('EMPLOYEE ALREADY IN LIVE STATUS');")
                    cl_script12.Append("       window.open('../../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script12.ToString, True)
                End If


                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert(' UPDATED');")
                cl_script1.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                If Me.rad_termi.Checked = True Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("window.open('pay_sus_rvk_Repo.aspx?ecode=" & h_ecode.Value & "');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                End If
                Me.txt_ecode.Text = ""
                Me.txt_remark.Text = ""
                Me.txt_NoRdt.Text = ""
                Me.txt_RoTdt.Text = ""
                Me.lst_emp.Items.Clear()
                'sus2revo_fill()
                'Server.Transfer("pay_sus_rvk_Repo.aspx?ecode=" & h_ecode.Value & "&typ=" & p(3).Value)
                'Response.Redirect("pay_sus_rvk_Repo.aspx?ecode=" & h_ecode.Value & "&typ=" & p(3).Value)

            ElseIf p(5).Value = 2 Then

                'MsgBox("EMPLOYEE ALREADY SUSPENDED/LONG or MATERNITY LEAVE/TERMINATED or RESIGNED..Etc")
                Me.txt_NoRdt.Text = ""
                Me.txt_RoTdt.Text = ""
                Me.txt_remark.Text = ""
                Me.lst_emp.Items.Clear()
                '/ rajesh  ElseIf p(5).Value = 2 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert(' Not UPDATED');")
                cl_script0.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

            ElseIf p(5).Value = 10 Then

                Dim cl_script10 As New System.Text.StringBuilder
                cl_script10.Append("         alert(' Effective Date Not to be Less Than Last Salary Processed Date!!Cannot resign Or Terminate in this Date!!');")
                cl_script10.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script10.ToString, True)

            ElseIf p(5).Value = 11 Then

                Dim cl_script11 As New System.Text.StringBuilder
                cl_script11.Append("         alert('This Employee had applied leave after this Effective Date!!So First Cancel all Leave after this Date!!');")
                cl_script11.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)

            ElseIf p(5).Value = 12 Then  ' Modified on 03-oct-2009

                Dim cl_script12 As New System.Text.StringBuilder
                cl_script12.Append("         alert('This Employee has a Transfer after Your Proposed Resignation / Suspension Date..!! \n Please Check..!!'');")
                cl_script12.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script12.ToString, True)

            ElseIf p(5).Value = 13 Then  ' Modified on 03-oct-2009

                Dim cl_script13 As New System.Text.StringBuilder
                cl_script13.Append("         alert('This Employee has a Promotion / Salary Increment after Your Proposed Resignation / Suspension Date..!! \n Please Check..!!');")
                cl_script13.Append("       window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script13.ToString, True)

            End If
        End If
    End Sub
    Protected Sub rad_resig_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_resig.CheckedChanged
        Me.txt_ecode.Text = ""
        Me.txt_NoRdt.Text = ""
        Me.txt_RoTdt.Text = ""
        Me.txt_remark.Text = ""
        Me.lst_emp.Items.Clear()
    End Sub

    Protected Sub rad_termi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_termi.CheckedChanged
        Me.txt_ecode.Text = ""
        Me.txt_NoRdt.Text = ""
        Me.txt_RoTdt.Text = ""
        Me.txt_remark.Text = ""
        Me.lst_emp.Items.Clear()
    End Sub
End Class
