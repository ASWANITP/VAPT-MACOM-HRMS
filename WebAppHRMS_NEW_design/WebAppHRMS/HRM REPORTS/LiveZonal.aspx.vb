Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_ResignedZonal_08317a9b6352
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim tb As New Table
    Dim dr As DataRow
    Dim FromDt, ToDt As String
    Dim tot_participant, Status As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Dim FromStr() As String = (Request.QueryString("from_dt")).ToString.Split("/")
            FromDt = Format(CDate(FromStr(1) + "/" + FromStr(0) + "/" + FromStr(2)), "dd-MMM-yyyy")
            Dim ToStr() As String = (Request.QueryString("to_dt")).ToString.Split("/")
            ToDt = Format(CDate(ToStr(1) + "/" + ToStr(0) + "/" + ToStr(2)), "dd-MMM-yyyy")
            Status = Request.QueryString("Status")
            Dim sql As String = ""
            If Status = 1 Then 'Indicates It is Trained Option Selected
                'sql = "select d.zonal_id,d.zonal_name,count(*) as count from employee_master a,examination_dtl c,branch_detail d where a.status_id=1 and to_date(a.join_dt)>='" & FromDt & "' and to_date(a.join_dt)<='" & ToDt & "' and c.status='P' and a.emp_code=c.emp_code and a.branch_id=d.branch_id group by d.zonal_id,d.zonal_name"
                sql = "select d.zonal_id,d.zonal_name,count(*) as count from employee_master a,examination_dtl c,branch_detail d where a.status_id=1  and c.status='P' and a.emp_code=c.emp_code and a.branch_id=d.branch_id group by d.zonal_id,d.zonal_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            Else
                'sql = "select z.zonal_id,z.zonal_name,count(*) as count from (select c.zonal_id,c.zonal_name from  employee_master a,branch_detail c where  a.status_id=1 and to_date(a.join_dt)>='" & FromDt & "' and to_date(a.join_dt)<='" & ToDt & "' and a.branch_id=c.branch_id and a.emp_code not in (select emp_code from examination_dtl) union all select c.zonal_id,c.zonal_name from  employee_master a,branch_detail c where  a.status_id=1 and to_date(a.join_dt)>='" & FromDt & "' and to_date(a.join_dt)<='" & ToDt & "' and a.branch_id=c.branch_id and a.emp_code in (select emp_code from examination_dtl where status='F')) z group by z.zonal_id,z.zonal_name"
                sql = "select z.zonal_id,z.zonal_name,count(*) as count from (select c.zonal_id,c.zonal_name from  employee_master a,branch_detail c where  a.status_id=1 and to_date(a.join_dt)>='" & FromDt & "' and to_date(a.join_dt)<='" & ToDt & "' and a.branch_id=c.branch_id and a.emp_code not in (select emp_code from examination_dtl) union all select c.zonal_id,c.zonal_name from  employee_master a,branch_detail c where  a.status_id=1  and a.branch_id=c.branch_id and a.emp_code in (select emp_code from examination_dtl where status='F')) z group by z.zonal_id,z.zonal_name"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If dt.Rows.Count > 0 Then
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
        tr01_01.ColumnSpan = 12
        tr01_01.Attributes.Add("width", "100%")
        tr01_01.Text = "<b><font size=4> " & Session("firm_name") & " </b>"
        tr01_01.HorizontalAlign = HorizontalAlign.Center
        tr01.Controls.Add(tr01_01)
        tb.Controls.Add(tr01)

        Dim tr04 As New TableRow
        Dim tr04_01, tr04_02 As New TableCell

        tr04_01.ColumnSpan = 6
        tr04_01.Attributes.Add("width", "50%")
        tr04_01.Text = " Date: " + Format(Date.Now, "dd-MMM-yyyy") + " "
        tr04_01.HorizontalAlign = HorizontalAlign.Left
        tr04.Controls.Add(tr04_01)

        tr04_02.ColumnSpan = 6
        tr04_02.Attributes.Add("width", "50%")
        tr04_02.Text = "Time:" + Format(Date.Now, "hh :mm :ss") + " "
        tr04_02.HorizontalAlign = HorizontalAlign.Right
        tr04.Controls.Add(tr04_02)

        tb.Controls.Add(tr04)

        Dim tr06 As New TableRow
        Dim tr06_01 As New TableCell
        tr06_01.ColumnSpan = 12
        tr06_01.Attributes.Add("width", "100%")
        tr06_01.Text = "<b>&nbsp;</b>"
        tr06.Controls.Add(tr06_01)
        tb.Controls.Add(tr06)

        Dim tr05 As New TableRow
        Dim tr05_01 As New TableCell
        tr05_01.ColumnSpan = 12
        tr05_01.Attributes.Add("width", "100%")
        If Status = 1 Then
            tr05_01.Text = "ZONALWISE TRAINED EXISTING EMPLOYEES REPORT "
        Else
            tr05_01.Text = "ZONALWISE UNTRAINED EXISTING EMPLOYEES REPORT "
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
        tr07_01.ColumnSpan = 12
        tr07_01.Attributes.Add("width", "100%")
        tr07_01.Text = "<b><hr></b>"
        tr07.Controls.Add(tr07_01)
        tb.Controls.Add(tr07)

        Dim tr08 As New TableRow
        Dim tr08_01, tr08_02, tr08_03 As New TableCell
        tr08.Font.Bold = True
        tr08_01.ColumnSpan = 5
        tr08_01.Attributes.Add("width", "45%")
        tr08_01.Text = "ZONAL"
        tr08_01.HorizontalAlign = HorizontalAlign.Left
        tr08.Controls.Add(tr08_01)

        tr08_02.ColumnSpan = 4
        tr08_02.Attributes.Add("width", "40%")
        tr08_02.Text = "TOTAL PARTICIPANTS"
        tr08_02.HorizontalAlign = HorizontalAlign.Right
        tr08.Controls.Add(tr08_02)

        tr08_03.ColumnSpan = 3
        tr08_03.Attributes.Add("width", "15%")
        tr08_03.Text = " "
        tr08_03.HorizontalAlign = HorizontalAlign.Right
        tr08.Controls.Add(tr08_03)

        tb.Controls.Add(tr08)
        Dim tr09 As New TableRow
        Dim tr09_01 As New TableCell
        tr09_01.ColumnSpan = 12
        tr09_01.Attributes.Add("width", "100%")
        tr09_01.Text = "<b><hr></b>"
        tr09.Controls.Add(tr09_01)
        tb.Controls.Add(tr09)
    End Sub
    Public Sub Data_print()
        Dim RowBg As Integer = 1
        For Each dr In dt.Rows
            Dim tr010 As New TableRow
            Dim tr010_01, tr010_02, tr010_03 As New TableCell
            If RowBG = 0 Then
                tr010.BackColor = Drawing.Color.AliceBlue
                RowBG = 1
            Else
                tr010.BackColor = Drawing.Color.WhiteSmoke
                RowBG = 0
            End If
            tr010_01.ColumnSpan = 5
            tr010_01.Attributes.Add("width", "45%")
            tr010_01.Text = "<a href=javascript:nextpage(" & dr(0) & "," & Status & ",'" & FromDt & "','" & ToDt & "')>" & dr(1) & ""
            tr010_01.HorizontalAlign = HorizontalAlign.Left
            tr010.Controls.Add(tr010_01)

            tr010_02.ColumnSpan = 4
            tr010_02.Attributes.Add("width", "40%")
            tr010_02.Text = dr(2)
            tr010_02.HorizontalAlign = HorizontalAlign.Right
            tr010.Controls.Add(tr010_02)

            tr010_03.ColumnSpan = 3
            tr010_03.Attributes.Add("width", "15%")
            tr010_03.Text = ""
            tr010_03.HorizontalAlign = HorizontalAlign.Right
            tr010.Controls.Add(tr010_03)

            tb.Controls.Add(tr010)

            tot_participant += dr(2)
        Next
        Dim tr011 As New TableRow
        Dim tr011_01 As New TableCell
        tr011_01.ColumnSpan = 12
        tr011_01.Attributes.Add("width", "100%")
        tr011_01.Text = "<b><hr></b>"
        tr011.Controls.Add(tr011_01)
        tb.Controls.Add(tr011)

        Dim tr012 As New TableRow
        Dim tr012_01, tr012_02, tr012_03 As New TableCell
        tr012.Font.Bold = True
        tr012_01.ColumnSpan = 5
        tr012_01.Attributes.Add("width", "45%")
        tr012_01.Text = "TOTAL"
        tr012_01.HorizontalAlign = HorizontalAlign.Left
        tr012.Controls.Add(tr012_01)

        tr012_02.ColumnSpan = 4
        tr012_02.Attributes.Add("width", "40%")
        tr012_02.Text = tot_participant
        tr012_02.HorizontalAlign = HorizontalAlign.Right
        tr012.Controls.Add(tr012_02)

        tr012_03.ColumnSpan = 3
        tr012_03.Attributes.Add("width", "15%")
        tr012_03.Text = " "
        tr012.Controls.Add(tr012_03)
        tb.Controls.Add(tr012)

        Dim tr013 As New TableRow
        Dim tr013_01 As New TableCell
        tr013_01.ColumnSpan = 12
        tr013_01.Attributes.Add("width", "100%")
        tr013_01.Text = "<b><hr></b>"
        tr013.Controls.Add(tr013_01)
        tb.Controls.Add(tr013)

    End Sub
End Class
