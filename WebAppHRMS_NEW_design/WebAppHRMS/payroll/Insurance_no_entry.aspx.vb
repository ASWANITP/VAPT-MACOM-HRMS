Imports System.Data
Imports System.Data.OracleClient

Partial Class ESI_Insurance_no_entry_2c4585a08711
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("access_id") <> 33 Then
                Server.Transfer("../show_err.aspx")
            End If

            codefill()

            Dim dt As DataTable = oh.ExecuteDataSet("select si_no,local_office || ' ( ' || d.district_name || ' , ' || s.state_name || ' ) ' from esi_local_office_master e,district_master d,state_master s where e.district_id=d.district_id and d.state_id=s.state_id order by local_office").Tables(0)
            If dt.Rows.Count > 0 Then
                Me.cmb_local.DataSource = dt
                Me.cmb_local.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_local.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_local.DataBind()
            Else
                Dim script1 As New StringBuilder
                script1.Append("alert('No Local Office Available In The List.. Please Update Local Office List');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", script1.ToString, True)
            End If
        End If
    End Sub
    Private Sub codefill()
        Dim dt As DataTable = oh.ExecuteDataSet("select emp_code,emp_code || ' - ' || emp_name from employee_master where emp_code  in (select emp_code from employee_master_dtl where insurance_no is null)order by emp_code").Tables(0)
        Me.cmb_code.DataSource = dt
        Me.cmb_code.DataTextField = dt.Columns(1).ColumnName
        Me.cmb_code.DataValueField = dt.Columns(0).ColumnName
        Me.cmb_code.DataBind()
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim script1 As New System.Text.StringBuilder
        If Me.txt_insurance.Text = "" Then
            script1.Append("        alert('Please enter Insurance No');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        ElseIf Me.cmb_local.Items.Count = 0 Then
            script1.Append("        alert('Please enter Local Office');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Dim param(3) As OracleParameter
        param(0) = New OracleParameter("empcode", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = Me.cmb_code.SelectedValue

        param(1) = New OracleParameter("insuranceno", OracleType.VarChar)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.txt_insurance.Text


        param(2) = New OracleParameter("local", OracleType.Number)
        param(2).Direction = ParameterDirection.Input
        param(2).Value = Me.cmb_local.SelectedValue

        param(3) = New OracleParameter("flag", OracleType.Number)
        param(3).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("insurance_no_add", param)

        If param(3).Value = 0 Then
            script1.Append("        alert('Successfully Confirmed');")
            Me.txt_insurance.Text = ""
            codefill()
        ElseIf param(3).Value = 1 Then
            script1.Append("        alert('Sorry,Error....');")
        Else
            script1.Append("        alert('This Insurance No. Already Exists.. Please Enter Another..');")

        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub
End Class
