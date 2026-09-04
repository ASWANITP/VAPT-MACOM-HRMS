Imports System.Data
Imports System.Data.OracleClient
Partial Class Leave_Details_emp_leave_select_7d01b3032265
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim str As String
    Dim fir As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "View different leave details of selected Employee"


        fir = Session("firm_id")
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_From.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then
            If Session("access_id") = 33 Then

                str = "select e.emp_code,e.emp_code||'    '||e.emp_name from employee_master e,employ_firm ef where e.emp_code>9999 and shift_id not in(4,5)and status_id<>3 and e.emp_code=ef.emp_code and ef.firm_id=" & fir & " order by emp_code"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Me.Cmb_Employee.DataSource = dt
                Me.Cmb_Employee.DataTextField = dt.Columns(1).ColumnName
                Me.Cmb_Employee.DataValueField = dt.Columns(0).ColumnName
                Me.Cmb_Employee.DataBind()
            Else
                Response.Redirect("../show_err.aspx")
            End If

        End If

    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        If CDate(Me.Txt_From.Text) > CDate(Me.Txt_to.Text) Or CDate(Me.Txt_to.Text) > Date.Now Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('To Date Invalid');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            Me.Server.Transfer("view_leave_rpt.aspx?empcode=" & Me.Cmb_Employee.SelectedValue & "&leavetype=" & Me.Cmb_Leave.SelectedValue & "&leavefrom=" & Me.Txt_From.Text & "&leaveto=" & Me.Txt_to.Text)
        End If
    End Sub
End Class
