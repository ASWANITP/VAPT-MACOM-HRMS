Imports System.Data
Imports System.Data.DataSet
Imports System.Data.oracleclient
Imports System.IO
Partial Class Leave_Leave_report_972c41178803
    Inherits System.Web.UI.Page
    Dim sql, gh, fnm As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim res, mm As String
    Dim dt, dt1, dt2 As New DataTable
    Dim script1 As New System.Text.StringBuilder
    Dim usr() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr As String
            usr = Me.Session("user_id").ToString.ToString.Split("!")(0)
            Dim oh As New Helper.Oracle.OracleHelper
            dt2 = oh.ExecuteDataSet("select COUNT(*) from form_accessibility t WHERE T.FORM_ID=5235 and t.EMP_ID=" & usr & "").Tables(0)
            If (dt2.Rows(0)(0) = 0) Then
                Server.Transfer("../show_err.aspx")
                Return
            End If
        End If
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frmdt As String = Me.TextBox8.Text
        Dim todt As String = Me.TextBox9.Text
        If (Me.TextBox8.Text = "") Then
            script1.Append("       alert('please select from date..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        ElseIf (Me.TextBox9.Text = "") Then
            script1.Append("        alert('please select to date..!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
            Exit Sub
        End If
        Dim oh As New Helper.Oracle.OracleHelper
        dt1 = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=133").Tables(0)
        Dim s1 As String = dt1.Rows(0)(0).ToString.Replace("frmdt", frmdt)
        s1 = s1.Replace("todt", todt)
        dt = oh.ExecuteDataSet(s1).Tables(0)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            Response.ClearContent()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Leave detailed data" + " " + DateTime.Now.ToString("dd-MMMM-yyyy" + " " + "hh:mm tt") + ".xls"))
            Response.ContentType = "application/ms-excel"
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            GridView1.AllowPaging = False
            GridView1.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.[End]()
        Else
            script1.Append("alert('NO DATA FOUND FOR THIS DATES...!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("~/home.aspx")
    End Sub
End Class
