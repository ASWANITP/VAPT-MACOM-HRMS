Imports System.Data
Imports System.Data.OracleClient
Public Class Comp_Approval
    Inherits System.Web.UI.Page
    Dim str, strs As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim CbResult As String = Nothing
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable
    Dim sb As New System.Text.StringBuilder()


    Protected Sub cmd_confirm_Click(sender As Object, e As EventArgs) Handles cmd_confirm.Click

        Dim firmid As Integer

        firmid = Session("firm_id")
        Dim usr = Me.Session("user_id").ToString.Split("!")
        Dim markerFlag As Integer = 2



        Dim param(10) As OracleParameter

        param(0) = New OracleParameter("firm", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = firmid

        param(1) = New OracleParameter("comdt", OracleType.DateTime)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = DateTime.Now

        param(2) = New OracleParameter("exdt", OracleType.DateTime)
        param(2).Direction = ParameterDirection.Input
        param(2).Value = DateTime.Now

        param(3) = New OracleParameter("comnm", OracleType.VarChar, 5000)
        param(3).Direction = ParameterDirection.Input
        param(3).Value = 0

        param(4) = New OracleParameter("userid", OracleType.VarChar, 200)
        param(4).Direction = ParameterDirection.Input
        param(4).Value = usr(0)

        If Me.chk_branch.Checked = True Then
            param(5) = New OracleParameter("data", OracleType.VarChar, 5000)
            param(5).Direction = ParameterDirection.Input
            param(5).Value = Me.Hidden2.Value


        End If
        'If Me.chk_emp.Checked = True Then
        '    param(5) = New OracleParameter("data", OracleType.VarChar, 5000)
        '    param(5).Value = ViewState("strs").ToString()


        'End If
        If Me.chk_emp.Checked = True Then
            Dim selectedEmpCodes As New List(Of String)

            For Each row As GridViewRow In gvEmpComp.Rows
                Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)
                If chk IsNot Nothing AndAlso chk.Checked Then
                    Dim empCode As String = row.Cells(0).Text.Trim() ' Column 1 is EmployeeCode
                    selectedEmpCodes.Add(empCode)
                End If
            Next

            If selectedEmpCodes.Count = 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Please select at least one employee');", True)
                Exit Sub
            End If

            param(5) = New OracleParameter("data", OracleType.VarChar, 5000)
            param(5).Value = String.Join("#", selectedEmpCodes)
        End If

        If Me.chk_branch.Checked = True Then
            param(6) = New OracleParameter("com_id", OracleType.VarChar, 5000)
            param(6).Direction = ParameterDirection.Input
            param(6).Value = Me.cmb_branch.SelectedValue
        End If

        If Me.chk_emp.Checked = True Then
            Dim selectedCompIds As New List(Of String)

            For Each row As GridViewRow In gvEmpComp.Rows
                Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)
                If chk IsNot Nothing AndAlso chk.Checked Then
                    Dim compId As String = gvEmpComp.DataKeys(row.RowIndex).Value.ToString()
                    selectedCompIds.Add(compId)
                End If
            Next

            If selectedCompIds.Count = 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Please select at least one employee');", True)
                Exit Sub
            End If

            param(6) = New OracleParameter("com_id", OracleType.VarChar, 5000)
            param(6).Direction = ParameterDirection.Input
            param(6).Value = String.Join("#", selectedCompIds)
        End If



        param(7) = New OracleParameter("status", OracleType.Number)
        param(7).Direction = ParameterDirection.Input
        param(7).Value = -1

        param(8) = New OracleParameter("maker_flag", OracleType.Number)
        param(8).Direction = ParameterDirection.Input
        param(8).Value = 2

        param(9) = New OracleParameter("err_stat", OracleType.Number)
        param(9).Direction = ParameterDirection.Output

        param(10) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        param(10).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrm_comp_credit_new_macom", param)

        If param(9).Value = 1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Successfully Approved and Inserted');")
            cl_script1.Append("         window.open('Comp_Approval.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Some Problems Occured.. Try again');")
            'cl_script1.Append("         window.open('comp_new_add.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If


    End Sub

    Protected Sub Rej_btn_Click(sender As Object, e As EventArgs) Handles Rej_btn.Click
        Dim firmid As Integer

        firmid = Session("firm_id")
        Dim usr = Me.Session("user_id").ToString.Split("!")
        Dim markerFlag As Integer = 2

        Dim param(10) As OracleParameter

        param(0) = New OracleParameter("firm", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = firmid

        param(1) = New OracleParameter("comdt", OracleType.DateTime)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = DateTime.Now

        param(2) = New OracleParameter("exdt", OracleType.DateTime)
        param(2).Direction = ParameterDirection.Input
        param(2).Value = DateTime.Now

        param(3) = New OracleParameter("comnm", OracleType.VarChar, 5000)
        param(3).Direction = ParameterDirection.Input
        param(3).Value = 0

        param(4) = New OracleParameter("userid", OracleType.VarChar, 200)
        param(4).Direction = ParameterDirection.Input
        param(4).Value = usr(0)

        If Me.chk_branch.Checked = True Then
            param(5) = New OracleParameter("data", OracleType.VarChar, 5000)
            param(5).Direction = ParameterDirection.Input
            param(5).Value = Me.Hidden2.Value


        End If
        'If Me.chk_emp.Checked = True Then
        '    param(5) = New OracleParameter("data", OracleType.VarChar, 5000)
        '    param(5).Value = ViewState("strs").ToString()
        'End If
        If Me.chk_emp.Checked = True Then
            Dim selectedEmpCodes As New List(Of String)

            For Each row As GridViewRow In gvEmpComp.Rows
                Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)
                If chk IsNot Nothing AndAlso chk.Checked Then
                    Dim empCode As String = row.Cells(0).Text.Trim() ' Column 1 is EmployeeCode
                    selectedEmpCodes.Add(empCode)
                End If
            Next

            If selectedEmpCodes.Count = 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Please select at least one employee');", True)
                Exit Sub
            End If

            param(5) = New OracleParameter("data", OracleType.VarChar, 5000)
            param(5).Value = String.Join("#", selectedEmpCodes)
        End If

        If Me.chk_branch.Checked = True Then
            param(6) = New OracleParameter("com_id", OracleType.VarChar, 5000)
            param(6).Direction = ParameterDirection.Input
            param(6).Value = Me.cmb_branch.SelectedValue
        End If

        If Me.chk_emp.Checked = True Then
            Dim selectedCompIds As New List(Of String)

            For Each row As GridViewRow In gvEmpComp.Rows
                Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)
                If chk IsNot Nothing AndAlso chk.Checked Then
                    Dim compId As String = gvEmpComp.DataKeys(row.RowIndex).Value.ToString()
                    selectedCompIds.Add(compId)
                End If
            Next

            If selectedCompIds.Count = 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Please select at least one employee');", True)
                Exit Sub
            End If

            param(6) = New OracleParameter("com_id", OracleType.VarChar, 5000)
            param(6).Direction = ParameterDirection.Input
            param(6).Value = String.Join("#", selectedCompIds)
        End If

        param(7) = New OracleParameter("status", OracleType.Number)
        param(7).Direction = ParameterDirection.Input
        param(7).Value = -1

        param(8) = New OracleParameter("maker_flag", OracleType.Number)
        param(8).Direction = ParameterDirection.Input
        param(8).Value = 3

        param(9) = New OracleParameter("err_stat", OracleType.Number)
        param(9).Direction = ParameterDirection.Output

        param(10) = New OracleParameter("err_msg", OracleType.VarChar, 100)
        param(10).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrm_comp_credit_new_macom", param)

        If param(9).Value = 1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Successfully Rejected');")
            cl_script1.Append("         window.open('Comp_Approval.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Some Problems Occured.. Try again');")
            'cl_script1.Append("         window.open('comp_new_add.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub

    Protected Sub chk_emp_CheckedChanged(sender As Object, e As EventArgs) Handles chk_emp.CheckedChanged
        If chk_emp.Checked Then

            ' Get the data for the employee grid
            Dim dt As DataTable = GetEmpCompensatoryData()

            ' Store it if needed for later use
            ViewState("EmpCompDt") = dt
            ' ViewState("strs") = BuildCompString(dt)

            If dt.Rows.Count = 0 Then
                Dim script As String = "alert('No data found'); document.getElementById('" & chk_emp.ClientID & "').checked = false;"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertNoData", script, True)

                gvEmpComp.Visible = False
                gvEmpComp.DataSource = Nothing
                gvEmpComp.DataBind()
                Exit Sub
            End If


            ' If data exists → bind and show grid
            gvEmpComp.DataSource = dt
            gvEmpComp.DataBind()
            gvEmpComp.Visible = True

        Else
            ' When unchecked → hide and clear
            gvEmpComp.Visible = False
            gvEmpComp.DataSource = Nothing
            gvEmpComp.DataBind()
            Hidden2.Value = ""
        End If
    End Sub

    Private Sub BindEmpCompGrid()
        Dim dt As DataTable = GetEmpCompensatoryData()

        ViewState("EmpCompDt") = dt ' Store in ViewState
        gvEmpComp.DataSource = dt
        gvEmpComp.DataBind()
    End Sub
    Private Function GetEmpCompensatoryData() As DataTable
        Dim dt As New DataTable()
        dt = oh.ExecuteDataSet("SELECT m.emp_code AS EmployeeCode,  TO_CHAR(TRUNC(m.comp_date), 'DD-MM-YYYY') AS CompensatoryDate, n.comp_name AS CompensatoryName, m.comp_id AS com_id FROM HRM_COMP_DTL_TEMP m INNER JOIN hrm_comp_mst n ON n.comp_id = m.comp_id WHERE m.typ_stat=1 and m.maker_id=0 ORDER BY m.emp_code, m.comp_date ").Tables(0)

        Return dt
    End Function
    Private Function BuildCompString(dt As DataTable) As String
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim row = dt.Rows(i)
            If i > 0 Then sb.Append("#")
            sb.Append(row("EmployeeCode").ToString())

        Next
        Return sb.ToString()
    End Function



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPENSATORY APPROVE"
        Dim UserAll(), UserCode As String
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        'Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        'Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If Not IsPostBack Then
            Dim emno As Integer = oh.ExecuteDataSet("select count(d.emp_id)  from form_accessibility d  where d.emp_id=" & UserCode & " and d.form_id=134").Tables(0).Rows(0)(0)

            dt = oh.ExecuteDataSet("SELECT add_months(to_date(TO_CHAR(TRUNC(current_date, 'YYYY'), 'DD-MON-YYYY')),12)-1 FROM dual").Tables(0)
            dt5 = oh.ExecuteDataSet("select -1, '-Select Branch Wise Assigned Compensatory' as branch_name from dual union all select distinct n.comp_id, n.comp_name||'-->'||m.comp_date||'-->ADMINISTRATIVE_OFFICE' from HRM_COMP_DTL_TEMP m inner join hrm_comp_mst n on n.comp_id=m.comp_id where m.typ_stat = 0 and m.maker_id=0").Tables(0)
            Me.cmb_branch.DataSource = dt5
            Me.cmb_branch.DataTextField = dt5.Columns(1).ColumnName
            Me.cmb_branch.DataValueField = dt5.Columns(0).ColumnName
            Me.cmb_branch.DataBind()
        End If
    End Sub



End Class