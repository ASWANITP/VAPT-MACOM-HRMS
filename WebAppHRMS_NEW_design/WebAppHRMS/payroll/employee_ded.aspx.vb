Imports System.Data
Imports System.Data.OracleClient
Partial Class employee_ded_976c71f41186
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "<b><U>SALARY DEDUCTIONS</U></b>"
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_amt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.txt_amt.Attributes.Add("onkeypress", "return isNumberKey(event)")
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                Me.txt_amt.Focus()
                Dim dt As DataTable
                dt = oh.ExecuteDataSet("select emp_code,emp_code || ' - ' ||emp_name from employee_master where emp_code>9999 and shift_id not in (4,5) order by emp_code").Tables(0)
                Me.cmb_empcode.DataSource = dt
                Me.cmb_empcode.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_empcode.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_empcode.DataBind()
            End If
        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('You are not Authorized');")
            script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If

        
    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        'oh.ExecuteNonQuery("insert into employ_sal_ded values(" & Me.cmb_empcode.SelectedValue & "," & Val(Me.txt_amt.Text) & ",'" & Me.txt_reason.Text & "','" & Me.dt_enterdt.fromdate & "','" & Format(Now.Date, "dd/MMM/yyyy") & "')")

        Dim param(5) As OracleParameter
        param(0) = New OracleParameter("empid", OracleType.Number, 10)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Me.cmb_empcode.SelectedValue

        param(1) = New OracleParameter("dedamt", OracleType.Double)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.txt_amt.Text

        param(2) = New OracleParameter("reason", OracleType.LongVarChar)
        param(2).Direction = ParameterDirection.Input
        param(2).Value = Me.txt_reason.Text

        param(3) = New OracleParameter("deddate", OracleType.DateTime)
        param(3).Direction = ParameterDirection.Input
        param(3).Value = Me.dt_enterdt.Text

        param(4) = New OracleParameter("prdate", OracleType.DateTime)
        param(4).Direction = ParameterDirection.Input
        param(4).Value = Now.Date

        param(5) = New OracleParameter("status", OracleType.Number)
        param(5).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("salded", param)

        Dim output As Integer = CInt(param(5).Value)

        If output = 1 Then
            Dim scrp_val As New System.Text.StringBuilder
            scrp_val.Append("   alert('successfully saved');")
            scrp_val.Append("window.open('employee_ded.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", scrp_val.ToString, True)
        Else
            Dim scrp_val As New System.Text.StringBuilder
            scrp_val.Append("   alert('Couldnot saved');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", scrp_val.ToString, True)

        End If

        Me.txt_amt.Text = ""
        Me.txt_reason.Text = ""
    End Sub

End Class
