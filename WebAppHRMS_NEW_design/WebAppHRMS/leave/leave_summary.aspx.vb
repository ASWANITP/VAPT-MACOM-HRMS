Imports System.Data
Imports System.Data.OracleClient
Imports System.Configuration
Imports System.IO
Partial Class Auction_Listed_pledges_448d588b8861
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim res As String
    Dim sql As String
    Dim dt, dt1, chck, chck1 As New DataTable
    Dim d1 As String
    Dim dr As DataRow
    Dim tbl As New Table
    Dim count, type As New Integer
    Dim fdate, tdate, brid, fd, branch_name As String
    Dim total1, total2, total3, total4, total5, total6, total7, total8, total9, total10, total11, total12, total13, total14, total15, total16, total17, total18, total19, total20, total21, total22, total23, total24, total25, total26, total27, total28, total29 As String
    Dim date1 As Date
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_frDt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cl_script21 As New System.Text.StringBuilder(1, 500)
        cl_script21.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script21.ToString, True)
    End Sub
    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView2.PageIndex = e.NewPageIndex
        Me.BindGrid(Me.txt_frDt.Text, Me.txt_toDt.Text)
    End Sub
    Private Sub BindGrid(ByVal frm As Date, ByVal too As Date)
        Dim op(1) As OracleParameter
        op(0) = New OracleParameter("frdate", OracleType.DateTime)
        op(0).Value = Format(CDate(frm), "MM/dd/yyyy")
        op(0).Direction = ParameterDirection.Input
        op(1) = New OracleParameter("toodate", OracleType.DateTime)
        op(1).Value = Format(CDate(too), "MM/dd/yyyy")
        op(1).Direction = ParameterDirection.Input
        oh.ExecuteNonQuery("macom_above_leaves", op)
        Dim Sql3 As String = "select t.emp_code EMP_CODE, em.emp_name name, to_char(t.leave_frdate) from_date, to_char(t.leave_todate) To_date, t.leave_type, t.total_days, t.reason, m.dep_name from hrm_macom_leaves t, employee_master em, department_mst m where t.emp_code=em.emp_code and em.department_id=m.dep_id and em.firm_id=8 and em.emp_code = t.emp_code order by 6 desc"
        Dim dt3 = oh.ExecuteDataSet(Sql3).Tables(0)
        If dt3.Rows.Count > 0 Then
            GridView2.DataSource = dt3
            GridView2.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If (Me.txt_frDt.Text = "" Or Me.txt_toDt.Text = "") Or (Me.txt_frDt.Text Is Nothing Or Me.txt_toDt.Text Is Nothing) Or (IsDBNull(Me.txt_frDt.Text) Or IsDBNull(Me.txt_toDt.Text)) Then
        '    Dim cl_script21 As New System.Text.StringBuilder(1, 500)
        '    cl_script21.Append("alert('Select Both From Date and  To Date!!');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script21.ToString, True)
        '    Exit Sub
        'End If
        If Me.hids.Value = "1" Then
            Me.BindGrid(Me.txt_frDt.Text, Me.txt_toDt.Text)
            Button3.Visible = True
        Else
            Button3.Visible = False
        End If

    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Dim dt As DataTable
        Select Case (x)
            Case "8"
                If (str(2) = "" Or str(1) = "") Or (str(2) Is Nothing Or str(1) Is Nothing) Or (IsDBNull(str(2)) Or IsDBNull(str(1))) Then
                    res = "Select Both Dates!!"
                ElseIf (CDate(str(2)) < CDate(str(1))) Then
                    res = "Choose Dates Correctly!"
                ElseIf (CDate(str(2)) > CDate(Date.Today)) Then
                    res = "Future Date not allowed!"
                End If
                'Case "5"
                '    Me.BindGrid(str(1), str(2))
        End Select
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim dt3 = oh.ExecuteDataSet("select t.emp_code EMP_CODE, em.emp_name name, to_char(t.leave_frdate) from_date, to_char(t.leave_todate) To_date, t.leave_type, t.total_days, t.reason, m.dep_name from hrm_macom_leaves t, employee_master em, department_mst m where t.emp_code=em.emp_code and em.department_id=m.dep_id and em.firm_id=8 and em.emp_code = t.emp_code order by 6 desc").Tables(0)
        If dt3.Rows.Count > 0 Then
            GridView3.DataSource = dt3
            GridView3.DataBind()
            Response.ClearContent()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "LEAVE REPORT" + " " + DateTime.Now.ToString("dd-MMMM-yyyy" + " " + "hh:mm tt") + ".xls"))
            Response.ContentType = "application/ms-excel"
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            GridView3.AllowPaging = False
            GridView3.HeaderRow.Style.Add("background-color", "#FFFFFF")
            For i As Integer = 0 To GridView2.HeaderRow.Cells.Count - 1
                GridView3.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
            Next
            GridView3.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.[End]()
        End If

    End Sub

End Class
