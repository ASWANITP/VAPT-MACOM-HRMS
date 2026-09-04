Imports System.Data
Imports System.Data.OracleClient
Partial Class PayRoll_Py_Sus_Revo_71cebe146396
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim e_dtl(4) As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lst_emp.Items.Add("john" & vbNewLine & "deepak")
        'lst_emp.DataBind()
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                'Me.txt_ecode.Text = ""
                'Me.txt_remark.Text = ""
                'Me.txt_tdate.Text = ""
                Me.lst_emp.Items.Clear()
                Me.lbl_emp.Visible = False
                Me.TABLE1.Visible = False
                lbl_ind.Text = "Suspention Date"
                Dim cont_name As String
                cont_name = "var cl_name;cl_name='" & Me.txt_ecode.ClientID & "';"
                Me.ClientScript.RegisterClientScriptBlock(Me.GetType, "con_name", cont_name, True)
            End If
        Else
            Response.Redirect("../../../show_err.aspx")
        End If
    End Sub

    Protected Sub rad_revok_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_revok.CheckedChanged

        Me.txt_ecode.Text = ""
        Me.txt_tdate.Text = ""
        Me.txt_remark.Text = ""
        Me.lst_emp.Items.Clear()
        Me.lbl_emp.Visible = True
        Me.TABLE1.Visible = True
        Me.TABLE2.Visible = False
        Me.lbl_ecode.Visible = False
        lbl_ind.Text = "Revocation Date"
        sus2revo_fill()
    End Sub

    Protected Sub rad_susp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_susp.CheckedChanged
        Me.txt_ecode.Text = ""
        Me.txt_tdate.Text = ""
        Me.txt_remark.Text = ""
        Me.lst_emp.Items.Clear()
        Me.lbl_emp.Visible = False
        Me.TABLE1.Visible = False
        Me.TABLE2.Visible = True
        Me.lbl_ecode.Visible = True
        lbl_ind.Text = "Suspention Date"
    End Sub

    Public Function listfill(ByVal ecode As Integer)
        'dt = oh.ExecuteDataSet("select em.emp_name||'('||em.emp_code||')',pm.post_name ,em.emp_code from employee_master em,post_mst pm where em.emp_code=" & ecode & " and em.post_id=pm.post_id").Tables(0)
        dt = oh.ExecuteDataSet("select em.emp_code||'-'||em.emp_name,dpm.dep_name,pm.post_name,dm.designation,bm.branch_name,em.emp_code from employee_master em,designation_master dm,post_mst pm,branch bm,department_mst dpm, employ_firm ef where bm.branch_id=em.branch_id and em.designation_id=dm.designation_id and em.post_id=pm.post_id and em.department_id=dpm.dep_id and em.emp_code=" & ecode & "  and ef.emp_code = em.emp_code and ef.firm_id = " & Session("firm_id") & " order by emp_code").Tables(0)
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
        Me.lst_emp.Items.Clear()
        If Me.txt_ecode.Text <> "" Then
            listfill(Val(Me.txt_ecode.Text))
            Me.Button1.Enabled = True
        End If
    End Sub

    Protected Sub drp_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drp_emp.SelectedIndexChanged
        Me.lst_emp.Items.Clear()
        Me.txt_remark.Text = ""
        Me.txt_tdate.Text = ""
        If Me.drp_emp.Items.Count > 0 Then
            listfill(Val(Me.drp_emp.SelectedValue))
            Me.Button1.Enabled = True
        Else
            Me.Button1.Enabled = False
        End If
    End Sub

    Sub sus2revo_fill()
        Me.drp_emp.Items.Clear()
        dt = oh.ExecuteDataSet("select em.emp_code||'-'||em.emp_name ,em.emp_code from employee_master em,employ_promotion_dtl epd,employ_firm ef where em.emp_code=epd.emp_code and epd.to_dt is null and epd.status_id=4 and ef.emp_code=epd.emp_code and ef.firm_id=" & Session("firm_id") & " order by em.emp_code").Tables(0)
        If dt.Rows.Count > 0 Then
            Me.drp_emp.DataSource = dt
            Me.drp_emp.DataTextField = dt.Columns(0).ColumnName
            Me.drp_emp.DataValueField = dt.Columns(1).ColumnName
            Me.drp_emp.DataBind()
        Else
            Me.drp_emp.Items.Add("NO SUSPENDED EMPLOYEE")
            Me.drp_emp.DataBind()
        End If
        If dt.Rows.Count >= 1 Then
            listfill(Val(Me.drp_emp.SelectedValue))
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.txt_remark.Text <> "" And Me.txt_tdate.Text <> "" Then

            Dim p(6) As OracleParameter
            p(0) = New OracleParameter("ecode", OracleType.Number, 5)
            p(0).Value = Val(h_ecode.Value)
            p(1) = New OracleParameter("eff_dt", OracleType.DateTime)
            p(1).Value = CDate(Me.txt_tdate.Text)
            p(6) = New OracleParameter("eff2_dt", OracleType.DateTime)
            p(6).Value = CDate("01-01-1900")
            p(2) = New OracleParameter("rmrk", OracleType.Char, 250)
            p(2).Value = Me.txt_remark.Text
            p(3) = New OracleParameter("opt", OracleType.Number, 1)
            If Me.rad_susp.Checked = True Then
                p(3).Value = 1
            Else
                p(3).Value = 2
            End If
            p(4) = New OracleParameter("aprv_ecode", OracleType.Number, 1)
            p(4).Value = CInt(Session("user_id").ToString.Split("!")(0))
            p(5) = New OracleParameter("status", OracleType.Number, 1)
            p(5).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("Pay_SusRevok", p)
            If p(5).Value = 1 Then
                'MsgBox("UPDATED")
                'MsgBox(p(5).Value)
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('UPDATED') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("window.open('pay_sus_rvk_Repo.aspx?ecode=" & h_ecode.Value & "&typ=" & p(3).Value & "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                Me.txt_ecode.Text = ""
                Me.txt_remark.Text = ""
                Me.txt_tdate.Text = ""
                Me.lst_emp.Items.Clear()
                sus2revo_fill()
                'Server.Transfer("pay_sus_rvk_Repo.aspx?ecode=" & h_ecode.Value & "&typ=" & p(3).Value)
                'Response.Redirect("pay_sus_rvk_Repo.aspx?ecode=" & h_ecode.Value & "&typ=" & p(3).Value)
            ElseIf p(5).Value = 2 Then
                ' MsgBox(p(5).Value)
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('EMPLOYEE ALREADY SUSPENDED/LONG or MATERNITY LEAVE/TERMINATED or RESIGNED..Etc') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

                'MsgBox("EMPLOYEE ALREADY SUSPENDED/IN LONG LEAVE/MATERNITY LEAVE")
                Me.txt_tdate.Text = ""
                Me.txt_remark.Text = ""
                Me.lst_emp.Items.Clear()
            Else
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('ERROR IN PROGRAM LOGIC') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                ' MsgBox("ERROR IN PROGRAM LOGIC")
            End If
        End If


    End Sub

End Class
