Imports System.Data
Imports System.Data.OracleClient
Partial Class TA_Updation_deptwise_ta_updation_9b8162a53815
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim str As String
    Dim itemvalue As Integer = 0
    Dim cl_script As New StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Departmentwise Updation of Allowances and Others"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_Value.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then

            str = "select emp_code,emp_code||'   '||emp_name from employee_master where emp_code>9999 and emp_code in (select emp_code from employee_master_dtl where (discont_dt is NULL or discont_dt>=to_date(sysdate)-90)) order by emp_code "
            dt = oh.ExecuteDataSet(str).Tables(0)
            Me.Cmb_Employee.DataSource = dt
            Me.Cmb_Employee.DataTextField = dt.Columns(1).ColumnName
            Me.Cmb_Employee.DataValueField = dt.Columns(0).ColumnName
            Me.Cmb_Employee.DataBind()

        End If



    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Try
            Dim para(3) As OracleParameter

            para(0) = New OracleParameter("empcode", OracleType.Number, 5)
            para(0).Value = Me.Cmb_Employee.SelectedValue
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("item_number", OracleType.Number, 2)
            para(1).Value = Me.Cmb_Item.SelectedValue
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("item_value", OracleType.Double)
            para(2).Value = Me.Txt_Value.Text
            para(2).Direction = ParameterDirection.Input

            para(3) = New OracleParameter("flag", OracleType.Number, 1)
            para(3).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("deptwise_ta_upd_ins", para)
            If para(3).Value = 1 Then
                cl_script.Append(" alert('Successfully Inserted!!! ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            ElseIf para(3).Value = 2 Then
                cl_script.Append(" alert('Successfully Updated!!! ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

            ElseIf para(3).Value = 0 Then
                cl_script.Append(" alert('Some Problems may have occured!!! ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            End If
        Catch ex As Exception

            cl_script.Append("   alert('" & ex.ToString & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

        Finally
            '    cl_script.Append("   alert('" & ex.ToString & " ') ;")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            '    clear()
        End Try

    End Sub

    Protected Sub Cmd_Report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Report.Click
        Me.Server.Transfer("itemwise_ta_report.aspx?item_code=" & Me.Cmb_Item.SelectedValue & "&item_name=" & Me.Cmb_Item.SelectedItem.ToString)
    End Sub
End Class
