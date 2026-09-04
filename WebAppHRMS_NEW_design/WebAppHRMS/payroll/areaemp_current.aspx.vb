Imports System.Data
Imports System.Data.OracleClient
Partial Class Emp_Current_areaemp_current_e4a9b6be9021
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim total As Integer = 0
    Dim exptotal As Double = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim areatable As New Table
        areatable.Attributes.Add("width", "100%")

        Dim header As New TableRow
        header.Width = 10
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 10
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        areatable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 10
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 10
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        areatable.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 10
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 3
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 4
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 3
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)

        areatable.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 10
        pheadercell.ColumnSpan = 10
        pheadercell.HorizontalAlign = HorizontalAlign.Center


        If Me.Request.QueryString("status") = 0 Then
            pheadercell.Text = "<body align=center ><b><font size=3> Areawise list of All(Resigned and Terminated Excluded)employees</font></b>"
        ElseIf Me.Request.QueryString("status") = 1 Then
            pheadercell.Text = "<body align=center ><b><font size=3> Areawise list of Normal employees</font></b>"
        ElseIf Me.Request.QueryString("status") = 3 Then
            pheadercell.Text = "<body align=center ><b><font size=3> Areawise list of Resigned employees</font></b>"
        ElseIf Me.Request.QueryString("status") = 4 Then
            pheadercell.Text = "<body align=center ><b><font size=3> Areawise list of Suspended employees</font></b>"
        ElseIf Me.Request.QueryString("status") = 6 Then
            pheadercell.Text = "<body align=center ><b><font size=3> Areawise list of employees in Long Leave</font></b>"
        ElseIf Me.Request.QueryString("status") = 10 Then
            pheadercell.Text = "<body align=center ><b><font size=3> Areawise list of employees in Maternity Leave</font></b>"
        ElseIf Me.Request.QueryString("status") = 5 Then
            pheadercell.Text = "<body align=center ><b><font size=3> Areawise list of Terminated employees</font></b>"

        End If
        pheader.Controls.Add(pheadercell)
        areatable.Controls.Add(pheader)

        If Me.Request.QueryString("status") = 0 Then
            str = "select bd.area_id,bd.AREA_NAME,count(ec.emp_code),sum(nvl(ec.exp_day,0))as Total_exp from branch_detail bd,employee_current ec where ec.status_id not in (3,5) and bd.division_id=" & Me.Request.QueryString("divid") & " and ec.branch_id=bd.BRANCH_ID group by  bd.area_id,bd.AREA_NAME"
        Else
            str = "select bd.area_id,bd.AREA_NAME,count(ec.emp_code),sum(nvl(ec.exp_day,0))as Total_exp from branch_detail bd,employee_current ec where ec.status_id=" & Me.Request.QueryString("status") & " and bd.division_id=" & Me.Request.QueryString("divid") & " and ec.branch_id=bd.BRANCH_ID group by  bd.area_id,bd.AREA_NAME"
        End If

        dt = oh.ExecuteDataSet(str).Tables(0)




        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 10
        linecell1.ColumnSpan = 10
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        areatable.Controls.Add(line1)





        Dim field As New TableRow
        field.Width = 10
        Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        f2.ColumnSpan = 4
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>Area Name</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 4
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>No&nbsp;of&nbsp;Employees</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 2
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>Total Exp. Days</font></b>"
        field.Controls.Add(f4)


        areatable.Controls.Add(field)

        Dim linek As New TableRow
        Dim linecellk As New TableCell
        linek.Width = 10
        linecellk.ColumnSpan = 10
        linecellk.Text = "<hr>"
        linek.Controls.Add(linecellk)
        areatable.Controls.Add(linek)

        For Each dr In dt.Rows

            Dim val As New TableRow
            val.Width = 10
            Dim v1, v2, v3 As New TableCell

            v1.ColumnSpan = 4
            v1.HorizontalAlign = HorizontalAlign.Left
            v1.Text = "<a href=branchemp_current.aspx?status=" & Me.Request.QueryString("status") & "&areaid=" & dr(0) & "><font size=2>" & dr(1) & "</font></a>"
            val.Controls.Add(v1)

            v2.ColumnSpan = 4
            v2.HorizontalAlign = HorizontalAlign.Right
            v2.Text = "<font size=2>" & dr(2) & "</font>"
            val.Controls.Add(v2)
            total += dr(2)

            v3.ColumnSpan = 2
            v3.HorizontalAlign = HorizontalAlign.Right
            v3.Text = "<font size=2>" & dr(3) & "</font>"
            val.Controls.Add(v3)
            Me.exptotal += dr(3)

            areatable.Controls.Add(val)

        Next

        Dim linee As New TableRow
        Dim linecelle As New TableCell
        linee.Width = 10
        linecelle.ColumnSpan = 10
        linecelle.Text = "<hr>"
        linee.Controls.Add(linecelle)
        areatable.Controls.Add(linee)

        Dim totrow As New TableRow
        totrow.Width = 10
        Dim t1 As New TableCell
        t1.ColumnSpan = 10
        t1.HorizontalAlign = HorizontalAlign.Right
        t1.Text = "<b><font size=2> Total Employees:&nbsp;" & Me.total & "and Total Exp.Days=" & Me.exptotal & "</font></b>"
        totrow.Controls.Add(t1)
        areatable.Controls.Add(totrow)

        Panel_Area.Controls.Add(areatable)
    End Sub
End Class
