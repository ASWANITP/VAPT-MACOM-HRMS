Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_Hrm_SPA_TA_Rpt_b3f5f7f44877
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Dim REGID As Integer
    Dim firm As String
    Dim fir As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        firm = Session("firm_name")
        fir = Session("firm_id")
        dt2 = oh.ExecuteDataSet("select access_id from employee_master where emp_code=" & UserId & "").Tables(0)
        Dim Access As Integer = dt2.Rows(0)(0)
        If Access <> 33 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), firm, tb, "SPECIAL ALLOWANCE AND TA REPORT IN HO", 27)
        Dim tr07 As New TableRow
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07, tr07_08, tr07_09, tr07_10 As New TableCell
        RH.AddColumn(tr07, tr07_02, 3, 10, "c", "<b>EMP&nbsp;CODE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 10, 10, "l", "<b>EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_04, 5, 10, "l", "<b>ALLOWANCE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_06, 3, 10, "l", "<b>FROM&nbsp;DATE&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_07, 3, 10, "l", "<b>TO&nbsp;DATE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")

        RH.AddColumn(tr07, tr07_05, 3, 10, "l", "<b>AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 27)
        dt1 = oh.ExecuteDataSet("select to_date(to_char(add_months(sysdate,-1),'YYYYMM'),'YYYYMM') from dual").Tables(0)
        Dim PreviousDate = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
        'dt = oh.ExecuteDataSet("select h.emp_code,e.emp_name,decode(h.all_id,1,'Fixed TA',39,'Special Allowance'),h.amount,h.to_date,h.from_dt from hrm_ta_employees h,employee_master e where h.emp_code=e.emp_code and (to_date(h.to_date) is null or to_date(h.to_date)>=to_date('" & PreviousDate & "')) order by h.emp_code").Tables(0)
        dt = oh.ExecuteDataSet("select h.emp_code,  e.emp_name,  decode(h.all_id, 1, 'Fixed TA', 39, 'Special Allowance'),  h.amount,  h.to_date,  h.from_dt,  ef.firm_id  from hrm_ta_employees h, employee_master e,employ_firm ef  where h.emp_code = e.emp_code  and ef.firm_id=" & fir & "  and ef.emp_code=e.emp_code  and (to_date(h.to_date) is null or  to_date(h.to_date) >= to_date('" & PreviousDate & "')) and h.all_id in(1,39)  order by h.emp_code").Tables(0)
        If dt.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('No Details !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
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
            RH.AddColumn(tr09, tr09_01, 3, 10, "c", dr(0))
            RH.AddColumn(tr09, tr09_02, 10, 10, "l", dr(1))
            RH.AddColumn(tr09, tr09_03, 5, 10, "l", dr(2))
            RH.AddColumn(tr09, tr09_05, 3, 10, "l", Format(dr(5), "dd/MMM/yyyy"))
            If Not IsDBNull(dr(4)) Then
                RH.AddColumn(tr09, tr09_06, 3, 10, "l", Format(dr(4), "dd/MMM/yyyy"))
            Else
                RH.AddColumn(tr09, tr09_06, 3, 10, "l", "-")
            End If

            RH.AddColumn(tr09, tr09_04, 3, 10, "l", FormatNumber(dr(3)))
            tb.Controls.Add(tr09)
            tot_count += 1
        Next
        RH.DrawLine(tb, 27)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03 As New TableCell
        tr10.BackColor = Drawing.Color.AliceBlue
        RH.AddColumn(tr10, tr10_01, 10, 5, "l", "TOTAL :&nbsp;&nbsp;&nbsp;&nbsp;" & "<b>" & tot_count)
        RH.AddColumn(tr10, tr10_03, 16, 5, "r", "")
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 27)
        Panel1.Controls.Add(tb)
    End Sub
End Class
