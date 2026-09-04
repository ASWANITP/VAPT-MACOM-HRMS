Imports System.Data
Imports System.Data.OracleClient

Partial Class EXTRAFORMS_HRM_SALARY_cd0a3f602667
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim dt, dt1 As New DataTable
    Dim CbResult As String = Nothing
    Dim Radio1, Radio2, Radio3 As String
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "SD FINAL CONFIRM"
        Dim usr As Integer = Session("user_id").ToString.Split("!")(0)
        Dim BranchID As Integer = CInt(Session("branch_id"))
        If BranchID <> 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Sorry,Pls Login in Head Office!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        If Session("firm_id") <> 2 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Sorry,Pls Login in Maben!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

        End If
        Dim cs As String = "var cont_name;cont_name='" & Me.Panel1.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        Dim sql As String = "select count(*) from form_accessibility f where f.emp_id=" & usr & " and f.form_id=109"
        Dim pa As DataTable = oh.ExecuteDataSet(sql).Tables(0)

        If pa.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Sorry,You Are Not Authorised To View This Page!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        If Me.RadioButtonList1.SelectedValue = 0 Then
            DataFill()
        ElseIf Me.RadioButtonList1.SelectedValue = 1 Then
            DataFill()
        End If
    End Sub

    Public Sub DataFill()
        Me.Panel1.Visible = True
        If Me.RadioButtonList1.SelectedValue = 0 Then
            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,h.amount,'SALARY',h.sd_no,f.firm_abbr,h.rec_firm from employee_master e,hrm_sd_confirmation h,firm_master f where e.emp_code=h.emp_code and h.firm_id=f.firm_id and h.all_id=0 and h.given_status=1 and h.process_status=0 order by e.emp_code").Tables(0)
        Else
            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,h.amount,'Allowances',h.sd_no,f.firm_abbr,h.rec_firm from employee_master e,hrm_sd_confirmation h,firm_master f where e.emp_code=h.emp_code and h.firm_id=f.firm_id and h.all_id=1 and h.given_status=1 and h.process_status=0 order by e.emp_code").Tables(0)
        End If

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
                Dim h1, h2, h3, h4, h5, h6, h7 As New TableCell
                h1.ColumnSpan = 1
                h2.ColumnSpan = 2
                h3.ColumnSpan = 2
                h4.ColumnSpan = 2
                h5.ColumnSpan = 1
                h6.ColumnSpan = 1
                h7.ColumnSpan = 2

                h1.HorizontalAlign = HorizontalAlign.Left
                h2.HorizontalAlign = HorizontalAlign.Left
                h3.HorizontalAlign = HorizontalAlign.Left
                h4.HorizontalAlign = HorizontalAlign.Left
                h5.HorizontalAlign = HorizontalAlign.Right
                h6.HorizontalAlign = HorizontalAlign.Left
                h7.HorizontalAlign = HorizontalAlign.Left

                h1.Text = "<font size=2><b>SI.NO</b></font>"
                h2.Text = "<font size=2><b>EMP CODE</b></font>"
                h3.Text = "<font size=2><b>EMP NAME</b></font>"
                h4.Text = "<font size=2><b>SD NUMBER</b></font>"
                h5.Text = "<font size=2><b>AMOUNT</b></font>"
                h6.Text = "<font size=2><b>FIRM</b></font>"
                h7.Text = "<input type=checkbox onclick=checkallfunction() id=chkall name=txt_all />CHECK ALL"

                hrow.Controls.Add(h1)
                hrow.Controls.Add(h2)
                hrow.Controls.Add(h3)
                hrow.Controls.Add(h4)
                hrow.Controls.Add(h5)
                hrow.Controls.Add(h6)
                hrow.Controls.Add(h7)
                tab.Controls.Add(hrow)

                Dim count As Integer = 0
                Dim dr As DataRow
                Dim chk(dt.Rows.Count) As CheckBox
                hid1.Value = dt.Rows.Count
                Dim tot As Integer = 0
                For Each dr In dt.Rows
                    count += 1
                    Dim inrow As New TableRow
                    inrow.Width = 10
                    Dim in1, in2, in3, in4, in5, in6, in7, in8 As New TableCell
                    in1.ColumnSpan = 1
                    in2.ColumnSpan = 2
                    in3.ColumnSpan = 2
                    in4.ColumnSpan = 1
                    in5.ColumnSpan = 1
                    in6.ColumnSpan = 2
                    in7.ColumnSpan = 2
                    in8.ColumnSpan = 1

                    in1.HorizontalAlign = HorizontalAlign.Left
                    in2.HorizontalAlign = HorizontalAlign.Left
                    in3.HorizontalAlign = HorizontalAlign.Left
                    in4.HorizontalAlign = HorizontalAlign.Right
                    in6.HorizontalAlign = HorizontalAlign.Left
                    in7.HorizontalAlign = HorizontalAlign.Left
                    in8.HorizontalAlign = HorizontalAlign.Left
                    in1.Text = "<font size=2.5>" & count & "</font>"
                    in2.Text = "<font size=2.5>" & dr(0) & " </font>"
                    in3.Text = "<font size=2.5>" & dr(1) & " </font>"
                    in4.Text = "<font size=2.5>" & FormatNumber(dr(2)) & " </font>"
                    tot += dr(2)
                    Dim s As String = dr(0) & "@" & dr(4) & "@" & dr(2) & "@" & dr(6) & "@" & dr(1)
                    in6.Text = "<input type=checkbox id=chk_" & s & " onclick=sdselect('" & count & "') name=txt_" & count & " />"
                    in7.Text = "<font size=2.5>" & dr(4) & " </font>"
                    in8.Text = "<font size=2.5>" & dr(5) & " </font>"
                    inrow.Controls.Add(in1)
                    inrow.Controls.Add(in2)
                    inrow.Controls.Add(in3)
                    inrow.Controls.Add(in7)
                    inrow.Controls.Add(in4)
                    inrow.Controls.Add(in8)
                    inrow.Controls.Add(in6)
                    tab.Controls.Add(inrow)
                Next
                Dim totrow As New TableRow
                totrow.Width = 12
                Dim tot1, tot2, tot3 As New TableCell
                tot1.ColumnSpan = 7
                tot2.ColumnSpan = 1
                tot3.ColumnSpan = 4
                totrow.ForeColor = Drawing.Color.Red
                totrow.BackColor = Drawing.Color.Tan
                tot1.Text = "<b>TOTAL : </b>"
                tot2.Text = "<b>" & FormatNumber(tot) & "</b>"
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

    Protected Sub btn_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click

     
        Try
            Dim script1 As New System.Text.StringBuilder

            Dim param(6) As OracleParameter
            param(0) = New OracleParameter("fmno", OracleType.Number)
            param(0).Direction = ParameterDirection.Input
            param(0).Value = Session("firm_id")

            param(1) = New OracleParameter("brno", OracleType.Number)
            param(1).Direction = ParameterDirection.Input
            param(1).Value = Session("branch_id")

            param(2) = New OracleParameter("userid", OracleType.VarChar)
            param(2).Direction = ParameterDirection.Input
            param(2).Value = Session("user_id")

            param(3) = New OracleParameter("conf_str", OracleType.VarChar)
            param(3).Direction = ParameterDirection.Input
            param(3).Value = Me.hid2.Value

            param(4) = New OracleParameter("flag", OracleType.Number)
            param(4).Direction = ParameterDirection.Output

            param(5) = New OracleParameter("err_stat", OracleType.Number)
            param(5).Direction = ParameterDirection.Output

            param(6) = New OracleParameter("err_msg", OracleType.VarChar, 500)
            param(6).Direction = ParameterDirection.Output
            If Me.RadioButtonList1.SelectedValue = 1 Then
                oh.ExecuteNonQuery("hrm_salary_toao", param)
            Else
                oh.ExecuteNonQuery("hrm_ta_toao", param)
            End If
            script1.Append("        alert('" & param(6).Value & "');")
            script1.Append("        window.open('hrm_salary.aspx','_self');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        Finally
            oh.dispose()
        End Try
    End Sub
End Class
