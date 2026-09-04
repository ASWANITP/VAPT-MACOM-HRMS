Imports System.Data
Imports System.Data.OracleClient
Partial Class Leave_Module_leave_applied_status_indi_9d3dab947224
    Inherits System.Web.UI.Page
    Dim fir As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        fir = Session("firm_id")
        Dim cs As String = "var cont_name;cont_name='" & Me.cmb_code.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE APPLIED STAUS INDIVIDUAL"
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim fid As Integer = 542
        Dim dt As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.form_id=542 and f.emp_id=" & user(0) & "").Tables(0).Rows(0)(0)
        If dt = 0 Then
            Me.Server.Transfer("../show_err.aspx")
        End If
        If Not IsPostBack Then
            'Session("user_id") = "31039!123"
            'Dim user() As String
            'user = Session("user_id").ToString.Split("!")
           
            ' Dim sql As String = "select e.emp_code, e.emp_code || '***' || emp_name from employee_master e,region_master r,branch_dtl_new b where e.status_id = 1 and e.BRANCH_ID=b.BRANCH_ID and b.reg_id=r.reg_id and r.rh_hr=" & user(0) & " and e.emp_code > 9999 order by emp_code"
            Dim sql As String = "select e.emp_code, e.emp_code || '***' || emp_name  from employee_master e,branch_dtl_new b  where e.status_id = 1 and e.emp_code in(select emp_code from employ_firm where firm_id=" & fir & ") and e.BRANCH_ID = b.BRANCH_ID  order by emp_code"
            Dim dt1 As DataTable = oh.ExecuteDataSet(sql).Tables(0)
            If dt1.Rows.Count > 0 Then
                Me.cmb_code.DataSource = dt1
                Me.cmb_code.DataTextField = dt1.Columns(1).ColumnName
                Me.cmb_code.DataValueField = dt1.Columns(0).ColumnName
                Me.cmb_code.DataBind()
                Me.txt_from.Text = Format(CDate("1 / JAN / 2013"), "dd/MMM/yyyy")
                Me.txt_to.Text = Format(Now.Date, "dd/MMM/yyyy")
            End If
        End If
        Me.txt_from.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_from')")
        Me.txt_to.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_to')")

    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Session("firm_id") = 2 Then
            Me.Response.Redirect("rpt_leave_applied_status_indi_new.aspx?empcode=" & Me.cmb_code.Text & "&fromdt=" & Me.txt_from.Text & "&todt=" & Me.txt_to.Text)
        Else
            Me.Response.Redirect("rpt_leave_applied_status_indi.aspx?empcode=" & Me.cmb_code.Text & "&fromdt=" & Me.txt_from.Text & "&todt=" & Me.txt_to.Text)
        End If
    End Sub
End Class
