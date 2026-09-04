Imports System.Data
Imports System.Data.OracleClient
Partial Class ENCASHMENT_RPT_encash_notRequested_6880a24b4574
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim tb As New Table
    Dim dr As DataRow
    Dim BrID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BrID = Session("branch_id")
        If BrID <> 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Pls Login in Head Office!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        dt1 = oh.ExecuteDataSet("select count(*)from employee_master a where a.emp_code=" & User(0) & " and a.access_id=33 and a.status_id=1").Tables(0)
        If dt1.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "EARNED LEAVE ENCASHMENT NOT REQUESTED LIST", 30)
        Dim tr07 As New TableRow
        tr07.BackColor = Drawing.Color.PapayaWhip
        tr07.ForeColor = Drawing.Color.Maroon
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06, tr07_07 As New TableCell
        RH.AddColumn(tr07, tr07_01, 1, 1, "c", "SLNO")
        RH.AddColumn(tr07, tr07_02, 1, 2, "c", "EMP&nbsp;CODE&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 8, 10, "l", "EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_04, 8, 10, "l", "BRANCH&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_05, 8, 10, "l", "POST&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_06, 2, 10, "c", "EARNED&nbsp;LEAVE AS&nbsp;ON&nbsp;31/DEC/2010")
        RH.AddColumn(tr07, tr07_07, 2, 10, "c", "&nbsp;&nbsp;STATUS")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 30)
        'dt = oh.ExecuteDataSet("select a.emp_id, b.emp_name, c.branch_name, d.post_name, a.earned_leave,e.remark from hrm_earned_leave a, employee_master b, branch_master c, post_mst d,status_mst e where a.emp_id = b.emp_code And b.branch_id = c.branch_id And b.post_id = d.post_id and a.encash_leave = 0 and b.status_id in (1, 10, 4, 6,3,5) and b.status_id=e.status_id order by b.emp_code").Tables(0)
        dt = oh.ExecuteDataSet("select a.emp_id,b.emp_name,c.branch_name,case when b.post_id in (select post_id from post_mst) then (select post_name from post_mst p where p.post_id = b.post_id)else 'NIL' end as post,a.earned_leave, e.remark from hrm_earned_leave a, employee_master b, branch c, status_mst e,employ_firm ef where a.emp_id = b.emp_code And b.branch_id = c.branch_id and a.encash_leave = 0 and a.status_id in (1, 10, 4, 6, 3, 5) and a.status_id = e.status_id and b.emp_code=ef.emp_code  and ef.firm_id= '" & Session("firm_id") & "' and  a.salary is null order by e.remark,b.emp_code").Tables(0)
        Dim slno As Integer = 0
        Dim RowBG As Integer = 0
        For Each dr In dt.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06, tr09_07 As New TableCell
            slno = slno + 1
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr09.BackColor = Drawing.Color.Snow
                RowBG = 0
            End If
            RH.AddColumn(tr09, tr09_01, 1, 1, "c", slno)
            RH.AddColumn(tr09, tr09_02, 1, 2, "c", dr(0))
            RH.AddColumn(tr09, tr09_03, 8, 10, "l", dr(1))
            RH.AddColumn(tr09, tr09_04, 8, 10, "l", dr(2))
            RH.AddColumn(tr09, tr09_05, 8, 10, "l", dr(3))
            RH.AddColumn(tr09, tr09_06, 2, 10, "c", dr(4))
            RH.AddColumn(tr09, tr09_07, 2, 10, "c", dr(5))
            tb.Controls.Add(tr09)
        Next
        RH.DrawLine(tb, 30)
        Panel1.Controls.Add(tb)
    End Sub
End Class
