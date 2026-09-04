Imports System.Data
Imports System.Data.OracleClient
Partial Class nov2009_mmm_br_select_promo_b84839234561
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frID = Session("firm_ID").ToString
        'krishnadas added[maben sreejesh requested]
        dt = oh.ExecuteDataSet("select e.emp_code from employee_master e,employ_firm f where e.emp_code=f.emp_code and e.emp_code=" & Me.Txt_emp.Text & " and status_id=1 and f.firm_id=" & frID & "").Tables(0)

        If dt.Rows.Count > 0 Then
            Response.Redirect("prom_rev_reporttt.aspx?emp=" & Me.Txt_emp.Text & "")
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Employee does not exist');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        '--changed
        If Session("access_id") <> 33 Then

            Me.Server.Transfer("../show_err.aspx")
        End If
    End Sub

    Protected Sub btn_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("       window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
    End Sub
End Class
