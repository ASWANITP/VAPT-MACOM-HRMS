Imports System.Data
Imports System.Data.OracleClient
Partial Class sd_updation_sd_updation_ho_ca22701b6306
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper

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
        If Me.RadioButtonList1.SelectedValue = 0 Then
            dt = oh.ExecuteDataSet("select distinct d.dep_id,d.dep_name from department_mst d,m_wage m,employee_master e where m.emp_code=e.emp_code and e.status_id=1 and e.emp_code>9999 and e.department_id=d.dep_id and e.branch_id=0 and e.emp_code not in(select emp_code from hrm_sd_confirmation h where h.all_id=0) order by d.dep_name").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select distinct d.dep_id,d.dep_name from department_mst d,incentives_allowances_dtl m,employee_master e where m.emp_code=e.emp_code and e.status_id=1 and e.emp_code>9999 and e.branch_id=0 and e.department_id=d.dep_id and e.emp_code not in(select emp_code from hrm_sd_confirmation h where h.all_id=1) order by d.dep_name").Tables(0)
        End If

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
        If Me.RadioButtonList1.SelectedValue = 0 Then
            sql = "select s.emp_id,e.emp_name,nvl(s.net_pay,0)+nvl(s.bonus,0)-nvl(s.cutting,0) as salary,'SALARY',em.sdno from salari s ,employee_master e,employee_master_dtl em where s.emp_id=e.emp_code and s.emp_id=em.emp_code and e.branch_id=0 and e.status_id=1 and e.department_id=" & Me.cmb_dpt.SelectedValue & "  order by s.emp_id"
        Else
            sql = "select al.emp_code,e.emp_name,sum(al.all_amount),'Allowances',em.sdno from incentives_allowances_dtl al ,employee_master e ,incentives_allowances_master am,employee_master_dtl em where al.emp_code=e.emp_code and al.all_id=am.all_id  and e.status_id=1 and e.branch_id=0 and e.emp_code=em.emp_code and e.department_id=" & Me.cmb_dpt.SelectedValue & " group by al.emp_code,e.emp_name,em.sdno order by al.emp_code"
        End If
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
                hrow.Width = 7
                Dim h1, h2, h3, h4, h6, h7 As New TableCell
                h1.ColumnSpan = 1
                h2.ColumnSpan = 1
                h3.ColumnSpan = 2
                h4.ColumnSpan = 1
                h6.ColumnSpan = 1
                h7.ColumnSpan = 1

                h1.HorizontalAlign = HorizontalAlign.Center
                h2.HorizontalAlign = HorizontalAlign.Left
                h3.HorizontalAlign = HorizontalAlign.Left
                h4.HorizontalAlign = HorizontalAlign.Right
                h6.HorizontalAlign = HorizontalAlign.Center
                h7.HorizontalAlign = HorizontalAlign.Left
                h1.Text = "<font size=2><b>SI.NO</b></font>"
                h2.Text = "<font size=2><b>EMP CODE</b></font>"
                h3.Text = "<font size=2><b>EMP NAME</b></font>"
                h4.Text = "<font size=2><b>AMOUNT</b></font>"
              
                h6.Text = "<input type=checkbox onclick=checkallfunction() id=chkall name=txt_all />CHECK ALL"
                h7.Text = "<font size=2><b>SD.NO</b></font>"
                hrow.Controls.Add(h1)
                hrow.Controls.Add(h2)
                hrow.Controls.Add(h3)
                hrow.Controls.Add(h7)
                hrow.Controls.Add(h4)
                hrow.Controls.Add(h6)
                tab.Controls.Add(hrow)

                Dim count As Integer = 0
                Dim dr As DataRow
                Dim chk(dt.Rows.Count) As CheckBox
                hid1.Value = dt.Rows.Count
                Dim tot As Integer = 0
                For Each dr In dt.Rows
                    count += 1
                    Dim inrow As New TableRow
                    inrow.Width = 7
                    Dim in1, in2, in3, in4, in6, in7 As New TableCell
                    in1.ColumnSpan = 1
                    in2.ColumnSpan = 1
                    in3.ColumnSpan = 2
                    in4.ColumnSpan = 1
                    in6.ColumnSpan = 1
                    in6.ColumnSpan = 1
                    in7.ColumnSpan = 1

                    in1.HorizontalAlign = HorizontalAlign.Center
                    in2.HorizontalAlign = HorizontalAlign.Left
                    in3.HorizontalAlign = HorizontalAlign.Left
                    in4.HorizontalAlign = HorizontalAlign.Right
                    in6.HorizontalAlign = HorizontalAlign.Center
                    in7.HorizontalAlign = HorizontalAlign.Center

                    in1.Text = "<font size=2.5>" & count & "</font>"
                    in2.Text = "<font size=2.5>" & dr(0) & " </font>"
                    in3.Text = "<font size=2.5>" & dr(1) & " </font>"
                    in4.Text = "<font size=2.5>" & dr(2) & " &nbsp;&nbsp;&nbsp;</font>"
                    tot += dr(2)
                    Dim s As String = dr(0) & "@" & dr(4) & "@" & dr(2)
                    in6.Text = "<input type=checkbox id=chk_" & s & " onclick=sdselect('" & count & "') name=txt_" & count & " />"
                    in7.Text = "<font size=2.5>" & dr(4) & " &nbsp;&nbsp;&nbsp;</font>"
                    inrow.Controls.Add(in1)
                    inrow.Controls.Add(in2)
                    inrow.Controls.Add(in3)
                    inrow.Controls.Add(in7)
                    inrow.Controls.Add(in4)
                    inrow.Controls.Add(in6)
                    tab.Controls.Add(inrow)
                Next
                Dim totrow As New TableRow
                totrow.Width = 7
                Dim tot1, tot2, tot3 As New TableCell
                tot1.ColumnSpan = 5
                tot2.ColumnSpan = 1
                tot3.ColumnSpan = 1
                totrow.ForeColor = Drawing.Color.Red
                totrow.BackColor = Drawing.Color.Tan
                tot1.Text = "<b>TOTAL : </b>"
                tot2.Text = "<b>" & tot & "&nbsp;&nbsp;&nbsp;</b>"
                tot3.Text = "&nbsp;"
                tot2.HorizontalAlign = HorizontalAlign.Right
                totrow.Controls.Add(tot1)
                totrow.Controls.Add(tot2)
                totrow.Controls.Add(tot3)
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
            param(2).Value = Me.RadioButtonList1.SelectedValue

            param(3) = New OracleParameter("branchid", OracleType.VarChar)
            param(3).Direction = ParameterDirection.Input
            param(3).Value = Session("branch_id")

            param(4) = New OracleParameter("verifyid", OracleType.VarChar)
            param(4).Direction = ParameterDirection.Input
            param(4).Value = user(0)

            param(5) = New OracleParameter("msg", OracleType.VarChar)
            param(5).Direction = ParameterDirection.Output
            param(5).Size = 50

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

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oh.dispose()
    End Sub

   
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        departmentfill()
    End Sub

    
End Class
