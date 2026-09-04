Imports System.Data
Imports System.Data.OracleClient
Partial Class SUNDAY_Sunday_conso_3632b2806425
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt2 As New DataTable
    Dim dr As DataRow
    Dim dt1 As New DataTable
    Dim fir As Integer
    Dim firm, use As String
    Dim fmid As Integer
    Dim str, res, sql, sql2 As String
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        fir = Session("firm_id")
        firm = Session("firm_name")

        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        use = user(0)
        'Me.Master.subtitle = "Employees Leave Report"
        'Dim script_val As String
        'script_val = "var loanno;" & "loanno='" & "" & Me.txtLeaveFrom.ClientID & "'" & " ; "
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim aaaa = Session("access_id")
        If Not IsPostBack Then
            sql = "select count(t.emp_id) from form_accessibility t where t.form_id=1890  and t.emp_id='" & use & "' "
            dt = oh.ExecuteDataSet(sql).Tables(0)
            ''''
            sql2 = "select t.access_id from employee_master t where t.emp_code='" & use & "'  "
            dt2 = oh.ExecuteDataSet(sql2).Tables(0)
            Session("access_id") = dt2.Rows(0)(0)
            ''''
            If Session("access_id") = 33 Or dt.Rows(0)(0) > 0 Then

                Dim TodDate As String = oh.ExecuteDataSet("select to_char(to_date(SysDate),'dd/Mon/yyyy') from dual").Tables(0).Rows(0)(0)
                Me.txtLeaveFrom.Text = TodDate
                Me.txtLeaveToDate.Text = TodDate
                Me.hidLeaveFrom.Value = TodDate
                Me.hidLeaveTo.Value = TodDate
            Else
                Response.Redirect("../show_err.aspx")
            End If
        End If
    End Sub
    Protected Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfirm.Click
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim fid As Integer = Session("firm_id")
        If fid = 8 Then
            '    Me.Server.Transfer("Consolidated_repo_maf.aspx?fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
            'End If
            Me.Server.Transfer("Sunday_Conso_Reportt.aspx?fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
        End If
    End Sub
End Class


