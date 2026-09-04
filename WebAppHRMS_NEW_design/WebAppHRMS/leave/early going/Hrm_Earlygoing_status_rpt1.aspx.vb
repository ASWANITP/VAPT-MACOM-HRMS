Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_Hrm_Earlygoing_status_rpt1_87bf94912296
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim fromdate As String = Session("fromdt").ToString()
        Dim todate As String = Session("todt").ToString()
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "EARLY GOING STATUS REPORT OF " & BranchName & "" & vbNewLine & " FROM " & fromdate & " TO " & todate & " " & vbNewLine & "", 44)
        Dim tr07 As New TableRow
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_10 As New TableCell
        RH.AddColumn(tr07, tr07_01, 5, 10, "l", "<b>BRANCH&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_02, 3, 10, "l", "<b>EMP&nbsp;CODE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 10, 10, "l", "<b>EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_04, 5, 10, "l", "<b>DEPARTMENT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_05, 3, 10, "c", "<b>&nbsp;&nbsp;ENTER&nbsp;DATE&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_06, 3, 10, "c", "<b>&nbsp;&nbsp;GOING&nbsp;DATE&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_07, 10, 10, "l", "<b>&nbsp;&nbsp;REASON&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_08, 5, 10, "l", "<b>STATUS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 44)
        'dt = oh.ExecuteDataSet("select bm.BRANCH_NAME,e.emp_code,em.emp_name,d.dep_name,to_date(e.tra_dt),to_date(e.going_dt),e.reason,decode(e.status,1,'Sanction',2,'Reject',0,'Applied',4,'Recommended',5,'Cancelled',6,'Recommended') from hrm_earlygoing_appl e,employee_master em,branch_dtl_new bm,department_mst d where e.emp_code=em.emp_code and e.branch_id=bm.BRANCH_ID and to_date(e.going_dt)>=to_date('" & fromdate & "') and to_date(e.going_dt)<=to_date('" & todate & "') and d.dep_id=e.dep_id and e.emp_code=" & User(0) & " order by e.emp_code,e.tra_dt").Tables(0)
        dt = oh.ExecuteDataSet("select bm.BRANCH_NAME,e.emp_code,em.emp_name,d.dep_name,to_date(e.tra_dt),to_date(e.going_dt),e.reason,decode(e.status,1,'Sanction',2,'Reject',0,'Applied',4,'Recommended',5,'Cancelled',6,'Recommended') from hrm_earlygoing_appl e,employee_master em,branch_dtl_new bm,department_mst d,employ_firm ef where e.emp_code=em.emp_code and e.branch_id=bm.BRANCH_ID  and em.emp_code = ef.emp_code and ef.firm_id = ' " & Session("firm_id") & " ' and to_date(e.going_dt)>=to_date('" & fromdate & "') and to_date(e.going_dt)<=to_date('" & todate & "') and d.dep_id=e.dep_id and e.emp_code=" & User(0) & " order by e.emp_code,e.tra_dt").Tables(0)

        If dt.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('No Details !!!!');")
            cl_script0.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If

        Dim RowBG As Integer = 0
        Dim ItemTotal As Integer = 0
        tot_count = 0
        Dim Total As Double = 0
        For Each dr In dt.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07, tr09_08, tr09_09, tr09_10 As New TableCell
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr09.BackColor = Drawing.Color.MintCream
                RowBG = 0
            End If
            RH.AddColumn(tr09, tr09_01, 5, 10, "l", dr(0))
            RH.AddColumn(tr09, tr09_02, 3, 10, "l", dr(1))
            RH.AddColumn(tr09, tr09_03, 10, 10, "l", dr(2))
            RH.AddColumn(tr09, tr09_04, 5, 10, "l", dr(3))
            RH.AddColumn(tr09, tr09_05, 3, 10, "c", Format(dr(4), "dd/MMM/yyyy"))
            RH.AddColumn(tr09, tr09_06, 3, 10, "c", Format(dr(5), "dd/MMM/yyyy"))
            RH.AddColumn(tr09, tr09_07, 10, 10, "l", dr(6))
            RH.AddColumn(tr09, tr09_08, 5, 10, "l", dr(7))
            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 44)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.AliceBlue
        RH.AddColumn(tr10, tr10_01, 10, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
        RH.AddColumn(tr10, tr10_03, 29, 5, "r", "")
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 44)
        Panel1.Controls.Add(tb)
    End Sub
End Class
