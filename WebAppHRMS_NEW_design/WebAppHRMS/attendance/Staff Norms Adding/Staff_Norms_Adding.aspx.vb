Imports System.Data
Imports System.Data.OracleClient
Partial Class Staff_Norms_Staff_Norms_Adding_bc84d0cd8953
    Inherits System.Web.UI.Page
    Dim dt, dt1, dts, dt2, dt4, dt5, dt6, dt3, dt7 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID, firm, cnt, prime As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim cl_script0 As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr, dr1 As DataRow
    Dim ZoneID, primary, UserId, sel_branch, sel_department, sel_emp As Integer
    Dim form_id As Integer = 8837
    Dim sql, remar, dates, apl As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim User() As String = Session("user_id").ToString.Split("!")
        UserId = User(0)
        firm = Me.Session("firm_id")
        Dim EMPCODE As Integer
        EMPCODE = UserId
        If Not IsPostBack = True Then
            apl = "select count(*) from form_accessibility where form_id=" & form_id & " and emp_id=" & UserId & ""
            dt = oh.ExecuteDataSet(apl).Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You are not authorised!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                sql = "select 0, '----------Select--------' nj from dual union all select distinct t.dep_id, upper(t.dep_name) from department_mst t, employ_firm fg, employee_master m where fg.firm_id = 28 and fg.emp_code = m.emp_code and t.dep_id = m.department_id order by nj"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    Me.cmb_department.DataSource = dt
                    Me.cmb_department.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_department.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_department.DataBind()
                Else
                    dt = oh.ExecuteDataSet("select 0,'----------Select--------' from dual").Tables(0)
                    Me.cmb_department.DataSource = dt
                    Me.cmb_department.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_department.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_department.DataBind()
                End If
            End If
        End If
    End Sub


    Protected Sub btn_conf_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.txt_Requirement.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('please type the required norms !!');")
            cl_script1.Append("         window.open('Staff_Norms_Adding.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If Me.cmb_department.SelectedValue = 0 Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "<script> alert('SELECT DEPARTMENT')</script>", False)
                'ElseIf Me.cmb_branchfield.SelectedValue = 2 Then
                '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "<script> alert('SELECT BRANCH/FIELD')</script>", False)
            Else
                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")
                    Dim p(3) As OracleParameter

                    p(0) = New OracleParameter("department", OracleType.Number, 1000)
                    p(0).Value = Me.cmb_department.SelectedValue

                    p(1) = New OracleParameter("requirement", OracleType.Number, 10)
                    p(1).Value = Me.txt_Requirement.Text

                    p(2) = New OracleParameter("Userid", OracleType.Number, 10)
                    p(2).Value = User(0)

                    'p(3) = New OracleParameter("BranchField", OracleType.Number, 10)
                    'p(3).Value = Me.cmb_branchfield.SelectedValue

                    p(3) = New OracleParameter("Errmsg", OracleType.Char, 100)
                    p(3).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("HRM_STAFF_NORM_REQUIRED", p)
                    CbResult = p(3).Value

                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("alert('" & CbResult & "');")
                    cl_script1.Append("window.open('Staff_Norms_Adding.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "client script", cl_script1.ToString(), True)

                    Me.cmb_department.SelectedIndex = 0
                    Me.txt_short.Text = ""
                    Me.txt_ActualCount.Text = ""
                    Me.txt_Requirement.Text = ""
                    Me.txt_excess.Text = ""
                    'Me.cmb_branchfield.SelectedIndex = 0

                Catch ex As Exception
                    CbResult = ex.Message
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "<script> alert(' " + CbResult + " ')</script>", False)
                End Try
            End If
        End If
    End Sub

    Protected Sub cmb_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Server.Transfer("../../home.aspx")
    End Sub

    'Protected Sub cmb_branchfield_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_branchfield.SelectedIndexChanged

    '    'If Me.cmb_branchfield.SelectedValue = 0 Then
    '    '    dt2 = oh.ExecuteDataSet("SELECT COUNT(t.emp_code) FROM employee_master t WHERE t.status_id = 1 AND t.department_id = " & Me.cmb_department.SelectedValue & " AND t.branch_id = 0").Tables(0)
    '    'Else
    '    'dt2 = oh.ExecuteDataSet("SELECT COUNT(t.emp_code) FROM employee_master t WHERE t.status_id = 1 AND t.department_id = " & Me.cmb_department.SelectedValue & " AND t.branch_id <> 0").Tables(0)
    '    'End If

    '    If Me.txt_Requirement.Text = "" Then
    '        ' Alert when the requirement is empty
    '        Dim cl_script1 As New System.Text.StringBuilder
    '        cl_script1.Append("alert('Please type the required norms!');")
    '        cl_script1.Append("window.open('Staff_Norms_Adding.aspx','_self');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    '    Else
    '        Dim actualCount As Integer = Integer.Parse(dt2.Rows(0)(0).ToString())
    '        Dim requirement As Integer = Integer.Parse(Me.txt_Requirement.Text)

    '        If actualCount = requirement Then
    '            ' Alert when the requirement matches the actual count
    '            Dim cl_script1 As New System.Text.StringBuilder
    '            cl_script1.Append("alert('Do not accept required norms; actual count is the same!');")
    '            cl_script1.Append("window.open('Staff_Norms_Adding.aspx','_self');")
    '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    '        Else
    '            ' Calculate the difference and display it
    '            Me.txt_ActualCount.Text = actualCount.ToString()
    '            Dim result As Integer = actualCount - requirement
    '            Dim absoluteResult As Integer = Math.Abs(result)

    '            If result < 0 Then
    '                ' Display absolute value of result in txt_short if it's negative (indicating shortage)
    '                Me.txt_short.Text = absoluteResult.ToString()
    '                Me.txt_excess.Text = 0
    '            ElseIf result > 0 Then
    '                ' Display result in txt_excess if it's positive (indicating excess)
    '                Me.txt_short.Text = 0
    '                Me.txt_excess.Text = absoluteResult.ToString()
    '            Else
    '                ' If result is zero, clear both text boxes
    '                Me.txt_short.Text = 0
    '                Me.txt_excess.Text = 0
    '            End If
    '        End If
    '    End If

    'End Sub

    Protected Sub cmb_department_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_department.SelectedIndexChanged

        If Me.cmb_department.SelectedValue = 0 Then
            dt2 = oh.ExecuteDataSet("SELECT COUNT(t.emp_code) FROM employee_master t WHERE t.status_id = 1 AND t.department_id = " & Me.cmb_department.SelectedValue & "").Tables(0)
        Else
            dt2 = oh.ExecuteDataSet("SELECT COUNT(t.emp_code) FROM employee_master t WHERE t.status_id = 1 AND t.department_id = " & Me.cmb_department.SelectedValue & " ").Tables(0)
        End If

        If Me.txt_Requirement.Text = "" Then
            ' Alert when the requirement is empty
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("alert('Please type the required norms!');")
            cl_script1.Append("window.open('Staff_Norms_Adding.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim actualCount As Integer = Integer.Parse(dt2.Rows(0)(0).ToString())
            Dim requirement As Integer = Integer.Parse(Me.txt_Requirement.Text)

            If actualCount = requirement Then
                ' Alert when the requirement matches the actual count
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('Do not accept required norms; actual count is the same!');")
                cl_script1.Append("window.open('Staff_Norms_Adding.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                ' Calculate the difference and display it
                Me.txt_ActualCount.Text = actualCount.ToString()
                Dim result As Integer = actualCount - requirement
                Dim absoluteResult As Integer = Math.Abs(result)

                If result < 0 Then
                    ' Display absolute value of result in txt_short if it's negative (indicating shortage)
                    Me.txt_short.Text = absoluteResult.ToString()
                    Me.txt_excess.Text = 0
                ElseIf result > 0 Then
                    ' Display result in txt_excess if it's positive (indicating excess)
                    Me.txt_short.Text = 0
                    Me.txt_excess.Text = absoluteResult.ToString()
                Else
                    ' If result is zero, clear both text boxes
                    Me.txt_short.Text = 0
                    Me.txt_excess.Text = 0
                End If
            End If
        End If
    End Sub
End Class
