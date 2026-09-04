Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_hrm_tour_status_rpt1_91bab1816942
    Inherits System.Web.UI.Page
    Dim RH As New WholeHelper.ClsRepCtrl
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dtb As New DataTable
    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr As DataRow
    Dim tot_count As Double
    Dim REGID As Integer
    Dim color As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim fdate As String = (Request.QueryString.Get("fromdt"))
        Dim tdate As String = (Request.QueryString.Get("todt"))
        Dim empid As Integer = (Request.QueryString.Get("empid"))
        Dim brid As Integer
        Dim frid = Session("firm_id")
        Dim sql As String

        sql = "select t.emp_code, e.emp_name, to_date(t.from_dt), to_date(t.to_dt), t.to_branch||' ['||b.branch_name||']', t.tour_purpose, t.sanction_person||' ['||em.emp_name||']' from mactech.hrm_tour_dtl t join mactech.employee_master e on  t.emp_code = e.emp_code  left join mactech.branch_master b on b.branch_id=t.to_branch   left join mactech.employee_master em on em.emp_code=t.sanction_person  where t.tour_id = 1 and t.emp_code=" & empid & "and to_date(t.from_dt) >= to_date('" & fdate & "')    and to_date(t.to_dt) <= to_date('" & tdate & "')  order by t.emp_code, t.from_dt "
        dt = oh.ExecuteDataSet(Sql).Tables(0)
        Dim tb As New Table


        tb.Attributes.Add("width", "100%")

        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 80
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "50%")
        td21.ColumnSpan = 40
        td21.HorizontalAlign = HorizontalAlign.Right
        td21.Text = "<font size=2><b>Branch-id :" & Me.Session("branch_id") & "</b></font>"
        tr2.Controls.Add(td21)
        Dim td22 As New TableCell
        td22.Attributes.Add("width", "50%")
        td22.ColumnSpan = 40
        td22.HorizontalAlign = HorizontalAlign.Left
        td22.Text = "<font size=2><b>Branch :" & Me.Session("branch_name") & "</b></font>"
        tr2.Controls.Add(td22)
        tb.Controls.Add(tr2)


        Dim tr3 As New TableRow
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 40
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 40
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tb.Controls.Add(tr3)


        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.WhiteSmoke
        Dim td41 As New TableCell
        td41.Attributes.Add("width", "100%")
        td41.ColumnSpan = 80
        td41.HorizontalAlign = HorizontalAlign.Center
        Sql = "select initcap(branch_name) from mactech.branch_master where branch_id=" & brid
        dtb = oh.ExecuteDataSet(Sql).Tables(0)
        td41.Text = "<font size=3><b>Tour Report From :&nbsp" & fdate & " &nbsp To :" & tdate & " </b></font>"
        tr4.Controls.Add(td41)
        tb.Controls.Add(tr4)

        Dim l1 As New TableRow
        Dim ld1 As New TableCell
        ld1.Attributes.Add("width", "100%")
        ld1.ColumnSpan = 80
        ld1.HorizontalAlign = HorizontalAlign.Center
        ld1.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l1.Controls.Add(ld1)
        tb.Controls.Add(l1)

        Dim tr5 As New TableRow
        Dim td51 As New TableCell
        td51.Attributes.Add("width", "2%")
        td51.ColumnSpan = 8
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=2.5><b>EMPLOYEE CODE</b></font>"
        tr5.Controls.Add(td51)

        Dim td52 As New TableCell
        td52.Attributes.Add("width", "7%")
        td52.ColumnSpan = 16
        td52.HorizontalAlign = HorizontalAlign.Left
        td52.Text = "<font size=2.5><b>EMPLOYEE NAME</b></font>"
        tr5.Controls.Add(td52)

        Dim td53 As New TableCell
        td53.Attributes.Add("width", "15%")
        td53.ColumnSpan = 10
        td53.HorizontalAlign = HorizontalAlign.Left
        td53.Text = "<font size=2.5><b>FROM DATE</b></font>"
        tr5.Controls.Add(td53)


        Dim td54 As New TableCell
        td54.Attributes.Add("width", "10%")
        td54.ColumnSpan = 15
        td54.HorizontalAlign = HorizontalAlign.Left
        td54.Text = "<font size=2.5><b>TO DATE</b></font>"
        tr5.Controls.Add(td54)

        Dim td55 As New TableCell
        td55.Attributes.Add("width", "15%")
        td55.ColumnSpan = 6
        td55.HorizontalAlign = HorizontalAlign.Left
        td55.Text = "<font size=2.5><b>TO BRANCH</b></font>"
        tr5.Controls.Add(td55)

        Dim td56 As New TableCell
        td56.Attributes.Add("width", "10%")
        td56.ColumnSpan = 8
        td56.HorizontalAlign = HorizontalAlign.Center
        td56.Text = "<font size=2.5><b>TOUR PURPOSE</b></font>"
        tr5.Controls.Add(td56)


        Dim td58 As New TableCell
        td58.Attributes.Add("width", "20%")
        td58.ColumnSpan = 8
        td58.HorizontalAlign = HorizontalAlign.Center
        td58.Text = "<font size=2.5><b>SANCTIONED PERSON</b></font>"
        tr5.Controls.Add(td58)
        tb.Controls.Add(tr5)
        tb.Controls.Add(tr5)

        Dim l2 As New TableRow
        Dim ld2 As New TableCell
        ld2.Attributes.Add("width", "100%")
        ld2.ColumnSpan = 80
        ld2.HorizontalAlign = HorizontalAlign.Center
        ld2.Text = "<font size=3><hr size='2' NOSHADE></font>"
        l2.Controls.Add(ld2)
        tb.Controls.Add(l2)

        For Each dr In dt.Rows
            Dim tr6 As New TableRow
            If (color = 0) Then
                tr6.BackColor = Drawing.Color.GhostWhite
                color = 1
            Else
                tr6.BackColor = Drawing.Color.WhiteSmoke
                color = 0
            End If
            Dim td61 As New TableCell
            td61.Attributes.Add("width", "8%")
            td61.ColumnSpan = 8
            td61.HorizontalAlign = HorizontalAlign.Left
            td61.Text = "<font size=2>" & dr(0) & "</font>"
            tr6.Controls.Add(td61)

            Dim td62 As New TableCell
            td62.Attributes.Add("width", "7%")
            td62.ColumnSpan = 16
            td62.HorizontalAlign = HorizontalAlign.Center
            td62.Text = "<font size=2>" & dr(1) & "</font>"
            tr6.Controls.Add(td62)

            Dim td63 As New TableCell
            td63.Attributes.Add("width", "15%")
            td63.ColumnSpan = 10
            td63.HorizontalAlign = HorizontalAlign.Left 
            td63.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "</font>"
            tr6.Controls.Add(td63)


            Dim td64 As New TableCell
            td64.Attributes.Add("width", "15%")
            td64.ColumnSpan = 15
            td64.HorizontalAlign = HorizontalAlign.Left
            td64.Text = "<font size=2>" & Format(dr(3), "dd/MMM/yyyy") & "</font>"
            tr6.Controls.Add(td64)

            Dim td65 As New TableCell
            td65.Attributes.Add("width", "15%")
            td65.ColumnSpan = 6
            td65.HorizontalAlign = HorizontalAlign.Left
            td65.Text = "<font size=2>" & dr(4) & "</font>"
            tr6.Controls.Add(td65)

            Dim td66 As New TableCell
            td66.Attributes.Add("width", "10%")
            td66.ColumnSpan = 8
            td66.HorizontalAlign = HorizontalAlign.Center
            td66.Text = "<font size=2>" & dr(5) & "</font>"
            tr6.Controls.Add(td66)


            Dim td67 As New TableCell
            td67.Attributes.Add("width", "45%")
            td67.ColumnSpan = 8
            td67.HorizontalAlign = HorizontalAlign.Center
            td67.Text = "<font size=2>" & dr(6) & "</font>"
            tr6.Controls.Add(td67)
            tb.Controls.Add(tr6)
        Next

        Dim l3 As New TableRow
        Dim ld3 As New TableCell
        ld3.Attributes.Add("width", "100%")
        ld3.ColumnSpan = 80
        ld3.HorizontalAlign = HorizontalAlign.Center
        ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
        l3.Controls.Add(ld3)
        tb.Controls.Add(l3)
        Me.Panel1.Controls.Add(tb)
        Me.Panel1.HorizontalAlign = HorizontalAlign.Center

    End Sub

End Class
