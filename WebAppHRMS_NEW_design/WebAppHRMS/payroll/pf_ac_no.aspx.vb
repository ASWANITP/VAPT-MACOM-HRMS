Imports System.Data
Imports System.Data.OracleClient
Partial Class pf_ac_no_entry_pf_ac_no_33f12f708933
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As DataTable
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_code.SelectedIndexChanged
        dt = oh.ExecuteDataSet("select firm_id from employee_master where emp_code= " & Me.cmb_code.SelectedValue).Tables(0)
        Dim acno As String = ""
        If dt.Rows(0)(0) = 1 Then
            acno = "KR/KC/15076/"
        Else
            acno = "KR/KC/15001/"

        End If
        Me.txt_company.Text = acno
        Me.txt_pf.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            codefill()
            DropDownList1_SelectedIndexChanged(sender, e)

        End If
    End Sub

    Private Sub codefill()
        dt = oh.ExecuteDataSet("select emp_code,emp_code || ' - ' || emp_name from employee_master where status_id=1 and emp_code  in (select emp_code from employee_master_dtl where pf_accno is null)   and emp_code in(select emp_code from employ_firm f where f.firm_id=" & Session("firm_id") & ") order by emp_code").Tables(0)
        Me.cmb_code.DataSource = dt
        Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
        Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_code.DataBind()

    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim script1 As New System.Text.StringBuilder
        If Me.txt_pf.Text = "" Then
            script1.Append("        alert('Please enter Pf No');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Dim pf As String = Me.txt_company.Text & Me.txt_pf.Text
        Dim param(2) As OracleParameter
        param(0) = New OracleParameter("empcode", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Me.cmb_code.SelectedValue

        param(1) = New OracleParameter("pfno", OracleType.VarChar)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = pf

        param(2) = New OracleParameter("flag", OracleType.Number)
        param(2).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("pf_accno_add", param)

        If param(2).Value = 0 Then
            script1.Append("        alert('Successfully Confirmed');")
            Me.txt_pf.Text = ""
            Me.txt_company.Text = ""
            codefill()
            DropDownList1_SelectedIndexChanged(sender, e)
        ElseIf param(2).Value = 1 Then
            script1.Append("        alert('Sorry,Error....');")
        Else
            script1.Append("        alert('This PF No. Already Exists.. Please Enter Another..');")

        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
End Class
