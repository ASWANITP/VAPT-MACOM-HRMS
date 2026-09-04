Imports System.Data
Imports System.Data.OracleClient
Partial Class sd_updation_hrm_salary_sd_confirmation_6b6dff1c8099
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim cs As String = "var cont_name;cont_name='" & Me.cmb_dpt.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
            Me.Panel2.Visible = False
            Me.cmb_dpt.Attributes.Add("onchange", "combochange()")
            If Not IsPostBack Then
                If Session("access_id") <> 33 Then
                    Response.Redirect("../show_err.aspx")
                    Exit Sub
                End If
                departmentfill()
            End If

        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub
    Private Sub departmentfill()
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select distinct d.dep_id,d.dep_name from department_mst d,employee_master e where e.status_id =1 and e.emp_code>9999 and e.department_id=d.dep_id and e.branch_id=0 and e.emp_code in(select emp_id from salari where status=0 union select emp_code from incentives_allowances_dtl where status=0) and e.emp_code not in(select emp_code from hrm_sd_confirmation) order by d.dep_name").Tables(0)
        Try
            Me.cmb_dpt.DataSource = dt
            Me.cmb_dpt.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_dpt.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_dpt.DataBind()
            Me.hid3.Value = dt.Rows(0)(0)
        Catch ex As Exception
        Finally
            dt.Dispose()
            oh.dispose()
        End Try
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Me.Panel1.Visible = True
        Me.Panel2.Visible = True
        Dim sql As String = ""
       
        sql = "select e.emp_code,e.emp_name,case when e.emp_code in(select emp_id from salari)  then (select nvl(s.net_pay,0)+nvl(s.bonus,0)-nvl(s.cutting,0)  from salari s where emp_id=e.emp_code) else 0 end as salary, case when e.emp_code in(select emp_code from incentives_allowances_dtl) then (select sum(a.all_amount) from incentives_allowances_dtl a where a.emp_code=e.emp_code group by a.emp_code) else 0 end as allownace, em.sdno from employee_master e,employee_master_dtl em  where e.emp_code=em.emp_code and e.branch_id=0  and e.status_id=1 and e.emp_code not in(select emp_code from hrm_sd_confirmation)  and e.emp_code in(select s.emp_id from salari s where s.status=0 union select a.emp_code from incentives_allowances_dtl a where status=0) and e.department_id=" & Me.cmb_dpt.SelectedValue & "  order by e.emp_code "

        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        Try
            Dim tab As New Table
            tab.Attributes.Add("width", "100%")
            tab.Attributes.Add("border", "1")

            If dt.Rows.Count = 0 Then
                Dim tab1 As New TableRow
                Dim tabc1 As New TableCell
                tabc1.HorizontalAlign = HorizontalAlign.Center
                tabc1.Text = "No Details Found"
                tab1.Controls.Add(tabc1)
                tab.Controls.Add(tab1)
            Else
                Dim hrow As New TableRow
                hrow.Width = 9
                Dim h1, h2, h3, h4, h6, h7, h8, h9 As New TableCell
                h1.ColumnSpan = 1
                h2.ColumnSpan = 1
                h3.ColumnSpan = 2
                h4.ColumnSpan = 1
                h6.ColumnSpan = 1
                h7.ColumnSpan = 1
                h8.ColumnSpan = 1
                h9.ColumnSpan = 1

                h1.HorizontalAlign = HorizontalAlign.Center
                h2.HorizontalAlign = HorizontalAlign.Left
                h3.HorizontalAlign = HorizontalAlign.Left
                h4.HorizontalAlign = HorizontalAlign.Right
                h6.HorizontalAlign = HorizontalAlign.Center
                h7.HorizontalAlign = HorizontalAlign.Left
                h8.HorizontalAlign = HorizontalAlign.Right
                h9.HorizontalAlign = HorizontalAlign.Right

                h1.Text = "<font size=2><b>SI.NO</b></font>"
                h2.Text = "<font size=2><b>EMP CODE</b></font>"
                h3.Text = "<font size=2><b>EMP NAME</b></font>"
                h4.Text = "<font size=2><b>AMOUNT</b></font>"

                h6.Text = "<input type=checkbox onclick=checkallfunction() id=chkall name=txt_all />CHECK ALL"
                h7.Text = "<font size=2><b>SD.NO</b></font>"
                h8.Text = "<font size=2><b>SALARY</b></font>"
                h9.Text = "<font size=2><b>ALLOWNACE</b></font>"

                hrow.Controls.Add(h1)
                hrow.Controls.Add(h2)
                hrow.Controls.Add(h3)
                hrow.Controls.Add(h7)
                hrow.Controls.Add(h8)
                hrow.Controls.Add(h9)
                hrow.Controls.Add(h4)
                hrow.Controls.Add(h6)
                tab.Controls.Add(hrow)

                Dim count As Integer = 0
                Dim dr As DataRow
                Dim chk(dt.Rows.Count) As CheckBox
                hid1.Value = dt.Rows.Count
                Dim tot As Integer = 0
                Dim tot1 As Integer = 0
                Dim tot2 As Integer = 0

                For Each dr In dt.Rows
                    count += 1
                    Dim inrow As New TableRow
                    inrow.Width = 9
                    Dim in1, in2, in3, in4, in6, in7, in8, in9 As New TableCell
                    in1.ColumnSpan = 1
                    in2.ColumnSpan = 1
                    in3.ColumnSpan = 2
                    in4.ColumnSpan = 1
                    in6.ColumnSpan = 1
                    in6.ColumnSpan = 1
                    in7.ColumnSpan = 1
                    in8.ColumnSpan = 1
                    in9.ColumnSpan = 1

                    in1.HorizontalAlign = HorizontalAlign.Center
                    in2.HorizontalAlign = HorizontalAlign.Left
                    in3.HorizontalAlign = HorizontalAlign.Left
                    in4.HorizontalAlign = HorizontalAlign.Right
                    in6.HorizontalAlign = HorizontalAlign.Center
                    in7.HorizontalAlign = HorizontalAlign.Center
                    in8.HorizontalAlign = HorizontalAlign.Right
                    in9.HorizontalAlign = HorizontalAlign.Right

                    in1.Text = "<font size=2.5>" & count & "</font>"
                    in2.Text = "<font size=2.5>" & dr(0) & " </font>"
                    in3.Text = "<font size=2.5>" & dr(1) & " </font>"
                    in4.Text = "<font size=2.5>" & dr(2) + dr(3) & " &nbsp;&nbsp;&nbsp;</font>"

                    Dim s As String = dr(0) & "@" & dr(4) & "@" & dr(2) + dr(3) & "@" & dr(2) & "@" & dr(3)
                    in6.Text = "<input type=checkbox id=chk_" & s & " onclick=sdselect('" & count & "') name=txt_" & count & " />"
                    in7.Text = "<font size=2.5>" & dr(4) & " &nbsp;&nbsp;&nbsp;</font>"
                    in8.Text = "<font size=2.5>" & dr(2) & " &nbsp;&nbsp;&nbsp;</font>"
                    in9.Text = "<font size=2.5>" & dr(3) & " &nbsp;&nbsp;&nbsp;</font>"
                    tot1 += dr(2)
                    tot2 += dr(3)
                    tot += dr(2) + dr(3)
                    inrow.Controls.Add(in1)
                    inrow.Controls.Add(in2)
                    inrow.Controls.Add(in3)
                    inrow.Controls.Add(in7)
                    inrow.Controls.Add(in8)
                    inrow.Controls.Add(in9)
                    inrow.Controls.Add(in4)
                    inrow.Controls.Add(in6)
                    tab.Controls.Add(inrow)
                Next
                Dim totrow As New TableRow
                totrow.Width = 9
                Dim t1, t2, t3, t4, t5 As New TableCell
                t1.ColumnSpan = 5
                t2.ColumnSpan = 1
                t3.ColumnSpan = 1
                t4.ColumnSpan = 1
                t5.ColumnSpan = 1

                totrow.ForeColor = Drawing.Color.Red
                totrow.BackColor = Drawing.Color.Tan
                t1.Text = "<b>TOTAL : </b>"
                t2.Text = "<b>" & tot1 & "&nbsp;&nbsp;&nbsp;</b>"
                t3.Text = "<b>" & tot2 & "&nbsp;&nbsp;&nbsp;</b>"
                t4.Text = "<b>" & tot & "&nbsp;&nbsp;&nbsp;</b>"

                t5.Text = "&nbsp;"
                t2.HorizontalAlign = HorizontalAlign.Right
                t3.HorizontalAlign = HorizontalAlign.Right
                t4.HorizontalAlign = HorizontalAlign.Right

                totrow.Controls.Add(t1)
                totrow.Controls.Add(t2)
                totrow.Controls.Add(t3)
                totrow.Controls.Add(t4)
                totrow.Controls.Add(t5)
                tab.Controls.Add(totrow)

            End If

            Me.Panel1.Controls.Add(tab)
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        Finally
            dt.Dispose()
            oh.dispose()
        End Try
    End Sub

    Protected Sub cmd_confirm1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm1.Click
        Try
            'Session("user_id") = "34534!wer"
            'Session("branch_id") = 1
            Dim user() As String
            user = Session("user_id").ToString.Split("!")

            Dim script1 As New System.Text.StringBuilder

            Dim param(5) As OracleParameter
            param(0) = New OracleParameter("str", OracleType.VarChar)
            param(0).Direction = ParameterDirection.Input
            param(0).Value = Me.hid2.Value

            param(1) = New OracleParameter("depid", OracleType.Number)
            param(1).Direction = ParameterDirection.Input
            param(1).Value = Me.cmb_dpt.SelectedValue

            param(2) = New OracleParameter("allid", OracleType.VarChar)
            param(2).Direction = ParameterDirection.Input
            ' param(2).Value = Me.RadioButtonList1.SelectedValue
            param(2).Value = 0

            param(3) = New OracleParameter("branchid", OracleType.VarChar)
            param(3).Direction = ParameterDirection.Input
            param(3).Value = Session("branch_id")

            param(4) = New OracleParameter("verifyid", OracleType.VarChar)
            param(4).Direction = ParameterDirection.Input
            param(4).Value = user(0)

            param(5) = New OracleParameter("msg", OracleType.VarChar)
            param(5).Direction = ParameterDirection.Output
            param(5).Size = 150

            oh.ExecuteNonQuery("hrmsdconfirmation", param)
            script1.Append("        alert('" & param(5).Value & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        Finally
            oh.dispose()
            departmentfill()
        End Try
    End Sub
End Class
