Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_SECURITY_HRM_RPT_BH_ABH_NotPunch4_3fb4ca573965
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Dim slno = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim branchid As Integer = Request.QueryString.Get("id")
        Dim branch As Integer = Request.QueryString.Get("BrID")
        dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & branch & "").Tables(0)
        BranchName = dt.Rows(0)(0)
        dt = oh.ExecuteDataSet("select area_name from area_master where area_id=" & branchid & "").Tables(0)
        Dim AREA_NAME As String = dt.Rows(0)(0)
        RH.Heading(Session("branch_id"), Session("branch_name"), Session("firm_name"), tb, "BH ABH NOT PUNCH REPORT OF " & AREA_NAME & "", 21)
        Dim tr07 As New TableRow
        Dim tr07_01, tr07_02, tr07_03, tr07_04, tr07_05, tr07_06 As New TableCell
        RH.AddColumn(tr07, tr07_01, 2, 10, "l", "SLNO")
        RH.AddColumn(tr07, tr07_02, 2, 10, "l", "BRANCH&nbsp;ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
        RH.AddColumn(tr07, tr07_03, 8, 10, "l", "BRANCH&nbsp;&nbsp;NAME")
        RH.AddColumn(tr07, tr07_04, 3, 10, "c", "BH SHORT")
        RH.AddColumn(tr07, tr07_05, 3, 10, "c", "ABH&nbsp;SHORT")
        RH.AddColumn(tr07, tr07_06, 3, 10, "c", "BH&nbsp;ABH&nbsp;SHORT")
        tb.Controls.Add(tr07)
        RH.DrawLine(tb, 21)
        'dt = oh.ExecuteDataSet("select bi.BRANCH_ID,case when bi.BRANCH_ID in(select branch_id from branch_master) then (select branch_name from branch_master where branch_id=bi.branch_id) else (select branch_name from before_completion where old_id=bi.branch_id) end as branch_name ,sum(decode(u.actual_bh-u.bh,0,1,0)) as bh_short,sum(decode(u.actual_abh-u.abh,0,1,0)) as abh_short,sum(case when u.actual_bh=u.bh and u.actual_abh=u.abh then 1 else 0 end) as bh_abh_short from (select t.BRANCH_ID,t.BRANCH_NAME, nvl(v.bh, 0) as BH,  nvl(w.abh, 0) as ABH, nvl(y.bh_abh, 0) as BH_ABH,nvl(dd.actual_bh,0) as actual_bh,nvl(ff.actual_abh,0) as actual_abh from branch t left outer join (select b.BRANCH_ID, b.BRANCH_NAME, count(e.EMP_CODE) as bh from daily_attend d,branch      b,employee_master  e where b.BRANCH_ID = d.BRANCH_ID and e.EMP_CODE = d.EMP_CODE and e.POST_ID in (10, 198)  and e.STATUS_ID =1 and (d.M_TIME is null or (d.M_TIME is not null and d.M_BRANCH<>b.BRANCH_ID and b.BRANCH_ID>=0)) group by b.BRANCH_ID, b.BRANCH_NAME) v on (t.BRANCH_ID = v.BRANCH_ID) left outer join (select b.BRANCH_ID, b.BRANCH_NAME,count(e.EMP_CODE) as abh from daily_attend d, branch      b, employee_master  e where b.BRANCH_ID = d.BRANCH_ID and e.EMP_CODE = d.EMP_CODE and e.POST_ID in (1)  and e.STATUS_ID =1 and (d.M_TIME is null or (d.M_TIME is not null and d.M_BRANCH<>b.BRANCH_ID and b.BRANCH_ID>=0)) group by b.BRANCH_ID, b.BRANCH_NAME) w on (w.branch_id = t.BRANCH_ID) left outer join (select b.BRANCH_ID, b.BRANCH_NAME, count(e.EMP_CODE) as bh_abh from daily_attend d, branch      b, employee_master  e where b.BRANCH_ID = d.BRANCH_ID and e.EMP_CODE = d.EMP_CODE  and e.POST_ID in (10, 198, 1)  and e.STATUS_ID =1 and (d.M_TIME is null or (d.M_TIME is not null and d.M_BRANCH<>b.BRANCH_ID and b.BRANCH_ID>=0))  group by b.BRANCH_ID, b.BRANCH_NAME) y on (y.branch_id =t.BRANCH_ID) left outer join (select et.BRANCH_ID,count(et.EMP_CODE) as actual_bh from employee_master et where et.STATUS_ID=1 and et.post_id in (198,10)  group by et.branch_id ) dd on (dd.branch_id=t.branch_id) left outer join (select eet.BRANCH_ID,count(eet.EMP_CODE) as actual_abh from employee_master eet where eet.STATUS_ID=1 and eet.post_id in (1)  group by eet.branch_id ) ff on (ff.branch_id=t.branch_id)  group by t.branch_id, t.branch_name, v.bh, w.abh, y.bh_abh,dd.actual_bh,ff.actual_abh) u,  ids_branch bi,area_detail ad where u.branch_id=bi.branch_id and bi.area_id=ad.area_id and ad.area_id='" & branchid & "' and  ((u.actual_bh=u.bh and u.bh<>0 )or (u.actual_abh=u.abh and u.abh>0) or ( (u.actual_bh+u.actual_abh)=(u.bh+u.abh))) group by bi.BRANCH_ID").Tables(0)
        dt = oh.ExecuteDataSet("select b.BRANCH_ID,b.BRANCH_NAME,sum(decode(u.actual_bh - u.bh, 0, 1, 0)) as bh_short,sum(decode(u.actual_abh - u.abh, 0, 1, 0)) as abh_short,sum(case when u.actual_bh = u.bh and u.actual_abh = u.abh then 1 else 0 end) as bh_abh_short from (select t.BRANCH_ID,t.BRANCH_NAME,nvl(v.bh, 0) as BH,nvl(w.abh, 0) as ABH,nvl(y.bh_abh, 0) as BH_ABH,nvl(dd.actual_bh, 0) as actual_bh,nvl(ff.actual_abh, 0) as actual_abh from branch t left outer join (select b.BRANCH_ID,b.BRANCH_NAME,count(e.EMP_CODE) as bh from daily_attend d, branch b, employee_master e where(b.BRANCH_ID = d.BRANCH_ID) and e.EMP_CODE = d.EMP_CODE and e.POST_ID in (10, 198)and e.STATUS_ID = 1 and (d.M_TIME is null or (d.M_TIME is not null and d.M_BRANCH <> b.BRANCH_ID and b.BRANCH_ID >= 0))group by b.BRANCH_ID, b.BRANCH_NAME) v on (t.BRANCH_ID =v.BRANCH_ID)left outer join (select b.BRANCH_ID,b.BRANCH_NAME,count(e.EMP_CODE) as abh from daily_attend d, branch b, employee_master e where(b.BRANCH_ID = d.BRANCH_ID)and e.EMP_CODE = d.EMP_CODE and e.POST_ID in (1) and e.STATUS_ID = 1 and (d.M_TIME is null or(d.M_TIME is not null and d.M_BRANCH <> b.BRANCH_ID and b.BRANCH_ID >= 0)) group by b.BRANCH_ID, b.BRANCH_NAME) w on (w.branch_id =t.BRANCH_ID)left outer join (select b.BRANCH_ID,b.BRANCH_NAME,count(e.EMP_CODE) as bh_abh from daily_attend d, branch b, employee_master e where(b.BRANCH_ID = d.BRANCH_ID)and e.EMP_CODE = d.EMP_CODE and e.POST_ID in (10, 198, 1)and e.STATUS_ID = 1 and (d.M_TIME is null or(d.M_TIME is not null and d.M_BRANCH <> b.BRANCH_ID and b.BRANCH_ID >= 0))group by b.BRANCH_ID, b.BRANCH_NAME) y on (y.branch_id =t.BRANCH_Id)left outer join (select et.BRANCH_ID,count(et.EMP_CODE) as actual_bh from employee_master et where(et.STATUS_ID = 1)and et.post_id in (198, 10) group by et.branch_id) dd on (dd.branch_id =t.branch_id)left outer join (select eet.BRANCH_ID,count(eet.EMP_CODE) as actual_abh from employee_master eet where(eet.STATUS_ID = 1) and eet.post_id in (1) group by eet.branch_id) ff on (ff.branch_id =t.branch_id) group by t.branch_id, t.branch_name, v.bh,w.abh,y.bh_abh,dd.actual_bh,ff.actual_abh) u,ids_branch bi,branch_dtl_new b where(u.branch_id = bi.branch_id) and b.BRANCH_ID=bi.BRANCH_ID and b.area_id = '" & branchid & "' and ((u.actual_bh = u.bh and u.bh <> 0) or  (u.actual_abh = u.abh and u.abh > 0) or   ((u.actual_bh + u.actual_abh) = (u.bh + u.abh)))group by b.BRANCH_ID, b.BRANCH_NAME ,actual_abh,actual_bh").Tables(0)

        If (dt.Rows.Count = 0) Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('No Details To Display..!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
        Dim RowBG As Integer = 0
        Dim count As Integer = 0
        Dim ItemTotal As Integer = 0
        Dim ItemTotal1 As Integer = 0
        Dim ItemTotal2 As Integer = 0
        tot_count = 1
        For Each dr In dt.Rows
            Dim tr09 As New TableRow
            Dim tr09_01, tr09_02, tr09_03, tr09_04, tr09_05, tr09_06 As New TableCell
            If RowBG = 0 Then
                tr09.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr09.BackColor = Drawing.Color.WhiteSmoke
                RowBG = 0
            End If
            slno = slno + 1
            RH.AddColumn(tr09, tr09_01, 2, 10, "l", slno)
            RH.AddColumn(tr09, tr09_02, 2, 10, "l", dr(0))
            RH.AddColumn(tr09, tr09_03, 8, 10, "l", dr(1))
            RH.AddColumn(tr09, tr09_04, 3, 10, "c", dr(2))
            RH.AddColumn(tr09, tr09_05, 3, 10, "c", dr(3))
            RH.AddColumn(tr09, tr09_06, 3, 10, "c", dr(4))
            tb.Controls.Add(tr09)
            count = count + 1
            ItemTotal += dr(2)
            ItemTotal1 += dr(3)
            ItemTotal2 += dr(4)
        Next
        RH.DrawLine(tb, 21)
        Dim tr10 As New TableRow
        Dim tr10_01, tr10_02, tr10_03, tr10_04, tr10_05, tr10_06, tr10_07 As New TableCell
        tr10.BackColor = Drawing.Color.WhiteSmoke
        RH.AddColumn(tr10, tr10_01, 2, 10, "l", "TOTAL :")
        RH.AddColumn(tr10, tr10_02, 2, 10, "c", " ")
        RH.AddColumn(tr10, tr10_03, 8, 10, "c", " ")
        RH.AddColumn(tr10, tr10_04, 3, 10, "c", ItemTotal)
        RH.AddColumn(tr10, tr10_05, 3, 10, "c", ItemTotal1)
        RH.AddColumn(tr10, tr10_06, 3, 10, "c", ItemTotal2)
        tb.Controls.Add(tr10)
        RH.DrawLine(tb, 21)
        Panel1.Controls.Add(tb)
    End Sub
End Class
