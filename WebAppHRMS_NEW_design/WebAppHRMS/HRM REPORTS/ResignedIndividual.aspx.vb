Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_ResignedIndividual_18319a946608
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim tb As New Table
    Dim dr As DataRow
    Dim FromDt, ToDt, BranchName, FrmTime, Ttime As String
    Dim BranchID, Status, tot_participant, experience As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            FromDt = Request.QueryString.Get("FromDt")
            ToDt = Request.QueryString.Get("ToDt")
            BranchID = Request.QueryString.Get("BranchID")
            Status = Request.QueryString.Get("Status")
            dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BranchID & "").Tables(0)
            BranchName = dt.Rows(0)(0)
            If Status = 1 Then
                dt = oh.ExecuteDataSet("select a.emp_code,a.emp_name,c.designation,d.dep_name,a.join_dt,b.discont_dt from employee_master a,employee_master_dtl b,designation_master c,department_mst d where a.branch_id=" & BranchID & " and a.status_id=3 and a.emp_code=b.emp_code and b.discont_dt is not null and to_date(b.discont_dt)>='" & FromDt & "' and to_date(b.discont_dt)<='" & ToDt & "' and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.emp_code in (select emp_code from examination_dtl where status='P')").Tables(0)
            Else
                'dt = oh.ExecuteDataSet("select z.branch_id,z.branch_name,count(*) as count from (select c.branch_id,c.branch_name from  employee_master a,employee_master_dtl b,branch_detail c where c.area_id=" & AreaID & " and a.emp_code=b.emp_code and a.status_id=3 and b.discont_dt is not null and to_date(b.discont_dt)>='" & FromDt & "' and to_date(b.discont_dt)<='" & ToDt & "' and a.branch_id=c.branch_id and a.emp_code not in (select emp_code from examination_dtl) union all select c.branch_id,c.branch_name from  employee_master a,employee_master_dtl b,branch_detail c where c.area_id=" & AreaID & " and a.emp_code=b.emp_code and a.status_id=3 and b.discont_dt is not null and to_date(b.discont_dt)>='" & FromDt & "' and to_date(b.discont_dt)<='" & ToDt & "' and a.branch_id=c.branch_id and a.emp_code in (select emp_code from examination_dtl where status='F')) z group by z.branch_id,z.branch_name").Tables(0)
                dt = oh.ExecuteDataSet("select a.emp_code,a.emp_name,c.designation,d.dep_name,a.join_dt,b.discont_dt from employee_master a,employee_master_dtl b,designation_master c,department_mst d where a.branch_id=" & BranchID & " and a.status_id=3 and a.emp_code=b.emp_code and b.discont_dt is not null and to_date(b.discont_dt)>='" & FromDt & "' and to_date(b.discont_dt)<='" & ToDt & "' and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.emp_code in (select emp_code from examination_dtl where status='F') union all select a.emp_code,a.emp_name,c.designation,d.dep_name,a.join_dt,b.discont_dt from employee_master a,employee_master_dtl b,designation_master c,department_mst d where a.branch_id=" & BranchID & " and a.status_id=3 and a.emp_code=b.emp_code and b.discont_dt is not null and to_date(b.discont_dt)>='" & FromDt & "' and to_date(b.discont_dt)<='" & ToDt & "' and a.designation_id=c.designation_id and a.department_id=d.dep_id and a.emp_code not in (select emp_code from examination_dtl)").Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                'tb.Attributes.Add("border", "1")
                Head_print()
                Data_print()
                Panel1.Controls.Add(tb)
            Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('No Data for Display!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            End If
        End If
    End Sub
    Public Sub Head_print()
        tb.Font.Name = "Courier New"
        Dim tr01 As New TableRow
        Dim tr01_01 As New TableCell
        tr01_01.ColumnSpan = 15
        tr01_01.Attributes.Add("width", "100%")
        tr01_01.Text = "<b><font size=4> " & Session("firm_name") & " </b>"
        tr01_01.HorizontalAlign = HorizontalAlign.Center
        tr01.Controls.Add(tr01_01)
        tb.Controls.Add(tr01)

        Dim tr04 As New TableRow
        Dim tr04_01, tr04_02 As New TableCell

        tr04_01.ColumnSpan = 7
        tr04_01.Attributes.Add("width", "50%")
        tr04_01.Text = " Date: " + Format(Date.Now, "dd-MMM-yyyy") + " "
        tr04_01.HorizontalAlign = HorizontalAlign.Left
        tr04.Controls.Add(tr04_01)

        tr04_02.ColumnSpan = 8
        tr04_02.Attributes.Add("width", "50%")
        tr04_02.Text = "Time:" + Format(Date.Now, "hh :mm :ss") + " "
        tr04_02.HorizontalAlign = HorizontalAlign.Right
        tr04.Controls.Add(tr04_02)

        tb.Controls.Add(tr04)

        Dim tr06 As New TableRow
        Dim tr06_01 As New TableCell
        tr06_01.ColumnSpan = 15
        tr06_01.Attributes.Add("width", "100%")
        tr06_01.Text = "<b>&nbsp;</b>"
        tr06.Controls.Add(tr06_01)
        tb.Controls.Add(tr06)

        Dim tr05 As New TableRow
        Dim tr05_01 As New TableCell
        tr05_01.ColumnSpan = 15
        tr05_01.Attributes.Add("width", "100%")
        If Status = 1 Then
            tr05_01.Text = "TRAINED EMPLOYEES REPORT OF BRANCH :- " & BranchName & " "
        Else
            tr05_01.Text = "UNTRAINED EMPLOYEES REPORT OF BRANCH :- " & BranchName & " "
        End If
        tr05.Controls.Add(tr05_01)
        tb.Controls.Add(tr05)

        Dim tr014 As New TableRow
        Dim tr014_01 As New TableCell
        tr014_01.ColumnSpan = 12
        tr014_01.Attributes.Add("width", "100%")
        tr014_01.Text = "FROM " & FromDt & " TO " & ToDt & ""
        tr014.Controls.Add(tr014_01)
        tb.Controls.Add(tr014)

        Dim tr07 As New TableRow
        Dim tr07_01 As New TableCell
        tr07_01.ColumnSpan = 15
        tr07_01.Attributes.Add("width", "100%")
        tr07_01.Text = "<b><hr></b>"
        tr07.Controls.Add(tr07_01)
        tb.Controls.Add(tr07)

        Dim tr08 As New TableRow
        Dim tr08_01, tr08_02, tr08_03, tr08_04, tr08_05, tr08_06, tr08_07 As New TableCell
        tr08.Font.Bold = True
        tr08_01.ColumnSpan = 1
        tr08_01.Attributes.Add("width", "10%")
        tr08_01.Text = "EMP-ID"
        tr08_01.HorizontalAlign = HorizontalAlign.Left
        tr08.Controls.Add(tr08_01)

        tr08_02.ColumnSpan = 2
        tr08_02.Attributes.Add("width", "20%")
        tr08_02.Text = "NAME"
        tr08_02.HorizontalAlign = HorizontalAlign.Left
        tr08.Controls.Add(tr08_02)

        tr08_03.ColumnSpan = 3
        tr08_03.Attributes.Add("width", "20%")
        tr08_03.Text = "DESIGNATION"
        tr08_03.HorizontalAlign = HorizontalAlign.Left
        tr08.Controls.Add(tr08_03)

        tr08_04.ColumnSpan = 3
        tr08_04.Attributes.Add("width", "25%")
        tr08_04.Text = "DEPARTMENT"
        tr08_04.HorizontalAlign = HorizontalAlign.Left
        tr08.Controls.Add(tr08_04)

        tr08_05.ColumnSpan = 2
        tr08_05.Attributes.Add("width", "15%")
        tr08_05.Text = "JOINING"
        tr08_05.HorizontalAlign = HorizontalAlign.Left
        tr08.Controls.Add(tr08_05)

        tr08_06.ColumnSpan = 1
        tr08_06.Attributes.Add("width", "10%")
        tr08_06.Text = "RELEIVING"
        tr08_06.HorizontalAlign = HorizontalAlign.Left
        tr08.Controls.Add(tr08_06)


        tb.Controls.Add(tr08)
        Dim tr09 As New TableRow
        Dim tr09_01 As New TableCell
        tr09_01.ColumnSpan = 15
        tr09_01.Attributes.Add("width", "100%")
        tr09_01.Text = "<b><hr></b>"
        tr09.Controls.Add(tr09_01)
        tb.Controls.Add(tr09)
    End Sub
    Public Sub Data_print()
        For Each dr In dt.Rows
            Dim tr010 As New TableRow
            Dim tr010_01, tr010_02, tr010_03, tr010_04, tr010_05, tr010_06, tr010_07, tr010_08, tr010_09 As New TableCell

            tr010_01.ColumnSpan = 1
            tr010_01.Attributes.Add("width", "10%")
            'tr010_01.Text = "<small>" & dr(0) & "</small>"
            tr010_01.Text = "<small>" & dr(0) & "</small>"
            tr010_01.HorizontalAlign = HorizontalAlign.Left
            tr010.Controls.Add(tr010_01)

            tr010_02.ColumnSpan = 2
            tr010_02.Attributes.Add("width", "20%")
            tr010_02.Text = "<small>" & dr(1) & "</small>"
            tr010_02.HorizontalAlign = HorizontalAlign.Left
            tr010.Controls.Add(tr010_02)

            tr010_03.ColumnSpan = 3
            tr010_03.Attributes.Add("width", "20%")
            tr010_03.Text = "<small>" & dr(2) & "</small>"
            tr010_03.HorizontalAlign = HorizontalAlign.Left
            tr010.Controls.Add(tr010_03)

            tr010_04.ColumnSpan = 3
            tr010_04.Attributes.Add("width", "25%")
            tr010_04.Text = "<small>" & dr(3) & "</small>"
            tr010_04.HorizontalAlign = HorizontalAlign.Left
            tr010.Controls.Add(tr010_04)

            tr010_05.ColumnSpan = 2
            tr010_05.Attributes.Add("width", "15%")
            tr010_05.Text = "<small> " & Format(dr(4), "dd/MMM/yyyy") & "</small>"
            tr010_05.HorizontalAlign = HorizontalAlign.Left
            tr010.Controls.Add(tr010_05)

            tr010_06.ColumnSpan = 1
            tr010_06.Attributes.Add("width", "10%")
            tr010_06.Text = "<small>" & Format(dr(5), "dd/MMM/yyyy") & "</small>"
            tr010_06.HorizontalAlign = HorizontalAlign.Right
            tr010.Controls.Add(tr010_06)

            tr010_07.ColumnSpan = 1
            tr010_07.Attributes.Add("width", "5%")
            tr010_07.Text = " "
            tr010_07.HorizontalAlign = HorizontalAlign.Right
            tr010.Controls.Add(tr010_07)

            tb.Controls.Add(tr010)

            tot_participant += 1

        Next
        Dim tr011 As New TableRow
        Dim tr011_01 As New TableCell
        tr011_01.ColumnSpan = 15
        tr011_01.Attributes.Add("width", "100%")
        tr011_01.Text = "<b><hr></b>"
        tr011.Controls.Add(tr011_01)
        tb.Controls.Add(tr011)

        Dim tr012 As New TableRow
        Dim tr012_01, tr012_02, tr012_03, tr012_04 As New TableCell
        tr012.Font.Bold = True
        tr012_01.ColumnSpan = 4
        tr012_01.Attributes.Add("width", "20%")
        tr012_01.Text = "TOTAL"
        tr012_01.HorizontalAlign = HorizontalAlign.Left
        tr012.Controls.Add(tr012_01)

        tr012_03.ColumnSpan = 8
        tr012_03.Attributes.Add("width", "55%")
        tr012_03.Text = tot_participant
        tr012_03.HorizontalAlign = HorizontalAlign.Left
        tr012.Controls.Add(tr012_03)

        tr012_04.ColumnSpan = 1
        tr012_04.Attributes.Add("width", "5%")
        tr012_04.Text = " "
        tr012.Controls.Add(tr012_04)
        tb.Controls.Add(tr012)

        Dim tr013 As New TableRow
        Dim tr013_01 As New TableCell
        tr013_01.ColumnSpan = 15
        tr013_01.Attributes.Add("width", "100%")
        tr013_01.Text = "<b><hr></b>"
        tr013.Controls.Add(tr013_01)
        tb.Controls.Add(tr013)

    End Sub
End Class
