Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_Employees_3DaysLate_RptCode_15efad5e3833
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frdt As String = Request.QueryString.Get("frdt")
        Dim todt As String = Request.QueryString.Get("todt")


        Dim dt As New DataTable
        Dim str As String
        str = "select t.emp_code,e.emp_name,b.branch_name,d.dep_name,dm.designation, p.post_name,t.date1  FIRST_LATE,t.date2 SECOND_LATE, t.date3 THIRD_LATE,t.leav_dt LEAVE_DATE from late_leave_mab_new t join employee_master e on e.emp_code = t.emp_code join branch_master b on b.branch_id = e.branch_id  join department_mst d on d.dep_id = e.department_id join designation_mst dm on dm.designation_id = e.designation_id join post_mst p on p.post_id = e.post_id join employ_firm f on f.emp_code = t.emp_code and f.firm_id in (" & Session("firm_id") & ") where to_date(t.leav_dt) between to_date('" & frdt & "')  and to_date('" & todt & "') and t.count_lv = 3"
        dt = oh.ExecuteDataSet("select t.emp_code,e.emp_name,b.branch_name,d.dep_name,dm.designation, p.post_name,t.date1  FIRST_LATE,t.date2 SECOND_LATE, t.date3 THIRD_LATE,t.leav_dt LEAVE_DATE from late_leave_mab_new t join employee_master e on e.emp_code = t.emp_code join branch_master b on b.branch_id = e.branch_id  join department_mst d on d.dep_id = e.department_id join designation_mst dm on dm.designation_id = e.designation_id join post_mst p on p.post_id = e.post_id join employ_firm f on f.emp_code = t.emp_code and f.firm_id in (" & Session("firm_id") & ") where to_date(t.leav_dt) between to_date('" & frdt & "')  and to_date('" & todt & "') and t.count_lv = 3 order by t.leav_dt,t.emp_code").Tables(0)

        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 10
        line11.Text = "<hr align=center width=100% >"
        line1.Controls.Add(line11)

        Dim assettab As New Table
        assettab.Attributes.Add("width", "100%")

        Dim ta1 As New TableRow
        Dim ta11 As New TableCell
        ta11.ColumnSpan = 10
        ta1.Attributes.Add("bgcolor", "whitesmoke")
        ta1.Attributes.Add("bordercolor", "black")
        ta11.Text = "<font size=4><b>" & Session("firm_name") & "</b></font>"
        ta11.ForeColor = Drawing.Color.Red
        ta11.HorizontalAlign = HorizontalAlign.Center
        ta1.Controls.Add(ta11)

        assettab.Controls.Add(ta1)

        Dim tabr2 As New TableRow
        tabr2.Width = 10
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 10
        tabc2.Attributes.Add("align", "center")
        tabc2.Text = "<body align=center color=black><b><font size=2.5>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DATE  FROM " & frdt & "&nbsp;TO&nbsp;" & todt & "</font></b></body>"

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        assettab.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        'tabrr3.Attributes.Add("bgcolor", "#ffcca3")


        Dim ta3 As New TableRow
        'ta3.Attributes.Add("bgcolor", "#ffcca3")
        ta3.ForeColor = Drawing.Color.Maroon
        ta3.Width = 10 ' 7
        Dim ta31, ta32, ta33 As New TableCell
        ta31.ColumnSpan = 2 '2
        ta32.ColumnSpan = 6 '3
        ta33.ColumnSpan = 2 '2
        ta31.Text = "<font size=3.5><b>Date :" & Format(Today, "dd/MM/yyyy") & " </b></font>"
        ta32.Text = "<font size=2><b>EMPLOYEE'S 3 DAYS LATE REPORT&nbsp;</b></font>"

        ta33.Text = "<font size=3.5><b>Time :" & Format(TimeOfDay, "hh:mm:ss tt") & " </b></font>"
        ta31.HorizontalAlign = HorizontalAlign.Left
        ta32.HorizontalAlign = HorizontalAlign.Center
        ta33.HorizontalAlign = HorizontalAlign.Left
        ta3.Controls.Add(ta31)
        ta3.Controls.Add(ta32)
        ta3.Controls.Add(ta33)
        assettab.Controls.Add(ta3)

        '---------------------------------------------------------------------------------
        Dim lin2101 As New TableRow
        lin2101.Width = 10
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 10
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        assettab.Controls.Add(lin2101)

        Dim lm4 As New TableRow
        lm4.Width = 10
        Dim lm41, lm42, lm43, lm44, lm45, lm46, lm47, lm48, lm49, lm50 As New TableCell
        lm41.ColumnSpan = 1
        lm41.Text = "<font size=2><b> Employee Code  </b></font>"
        lm41.HorizontalAlign = HorizontalAlign.Left

        lm42.ColumnSpan = 1
        lm42.Text = "<font size=2><b> Employee Name </b></font>"
        lm42.HorizontalAlign = HorizontalAlign.Left


        lm43.ColumnSpan = 1
        lm43.Text = "<font size=2><b> Branch Name </b></font>"
        lm43.HorizontalAlign = HorizontalAlign.Left

        lm44.ColumnSpan = 1
        lm44.Text = "<font size=2><b> Department Name </b></font>"
        lm44.HorizontalAlign = HorizontalAlign.Left

        lm45.ColumnSpan = 1
        lm45.Text = "<font size=2><b> Designation </b></font>"
        lm45.HorizontalAlign = HorizontalAlign.Left

        lm46.ColumnSpan = 1
        lm46.Text = "<font size=2><b> Post Name </b></font>"
        lm46.HorizontalAlign = HorizontalAlign.Left

        lm47.ColumnSpan = 1
        lm47.Text = "<font size=2><b> First Late </b></font>"
        lm47.HorizontalAlign = HorizontalAlign.Left

        lm48.ColumnSpan = 1
        lm48.Text = "<font size=2><b> Second Late </b></font>"
        lm48.HorizontalAlign = HorizontalAlign.Left

        lm49.ColumnSpan = 1
        lm49.Text = "<font size=2><b> Third Late </b></font>"
        lm49.HorizontalAlign = HorizontalAlign.Left

        lm50.ColumnSpan = 1
        lm50.Text = "<font size=2><b> Leave Date </b></font>"
        lm50.HorizontalAlign = HorizontalAlign.Left



        lm4.Controls.Add(lm41)
        lm4.Controls.Add(lm42)
        lm4.Controls.Add(lm43)
        lm4.Controls.Add(lm44)
        lm4.Controls.Add(lm45)
        lm4.Controls.Add(lm46)
        lm4.Controls.Add(lm47)
        lm4.Controls.Add(lm48)
        lm4.Controls.Add(lm49)
        lm4.Controls.Add(lm50)

        assettab.Controls.Add(lm4)

        Dim lin21 As New TableRow
        lin21.Width = 10
        Dim lin211 As New TableCell
        lin211.ColumnSpan = 10
        lin211.Text = "<hr align=center width=100% >"
        lin21.Controls.Add(lin211)
        assettab.Controls.Add(lin21)


        '------------------------------------------------------------------------------------------
        Dim dr As DataRow
        Dim cnt As Integer = 0
        Dim total As Integer = 0
        Dim itemid As Integer = 0
        Dim itemtot As Integer = 0
        Dim itemqun As Integer = 0
        Dim st As Integer = 0
        Dim colors As Integer = 0
        Dim lm5 As New TableRow
        If dt.Rows.Count > 0 Then

            For Each dr In dt.Rows
                If colors = 0 Then
                    lm5.BackColor = Drawing.Color.WhiteSmoke
                    colors = 1
                Else
                    lm5.BackColor = Drawing.Color.GhostWhite
                    colors = 0
                End If


                lm5.Width = 7
                Dim lm51, lm52, lm53, lm54, lm55, lm56, lm57, lm58, lm59, lm60 As New TableCell
                lm5.Font.Size = 8
                lm51.ColumnSpan = 1
                lm51.HorizontalAlign = HorizontalAlign.Left
                lm51.Text = "<font size=2>" & dr(0) & " </font>"
                lm5.Controls.Add(lm51)

                lm52.ColumnSpan = 1
                lm52.HorizontalAlign = HorizontalAlign.Left
                lm52.Text = "<font size=2>" & dr(1) & " </font>"
                lm5.Controls.Add(lm52)


                lm53.ColumnSpan = 1
                lm53.HorizontalAlign = HorizontalAlign.Left
                lm53.Text = "<font size=2>" & dr(2) & " </font>"
                lm5.Controls.Add(lm53)

                lm54.ColumnSpan = 1
                lm54.HorizontalAlign = HorizontalAlign.Left
                lm54.Text = "<font size=2>" & dr(3) & " </font>"
                lm5.Controls.Add(lm54)
                assettab.Controls.Add(lm5)


                lm55.ColumnSpan = 1
                lm55.HorizontalAlign = HorizontalAlign.Left
                lm55.Text = "<font size=2>" & dr(4) & " </font>"
                lm5.Controls.Add(lm55)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)


                lm56.ColumnSpan = 1
                lm56.HorizontalAlign = HorizontalAlign.Left
                lm56.Text = "<font size=2>" & dr(5) & " </font>"
                lm5.Controls.Add(lm56)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)



                lm57.ColumnSpan = 1
                lm57.HorizontalAlign = HorizontalAlign.Left
                lm57.Text = "<font size=2>" & dr(6) & " </font>"
                lm5.Controls.Add(lm57)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)


                lm58.ColumnSpan = 1
                lm58.HorizontalAlign = HorizontalAlign.Left
                lm58.Text = "<font size=2>" & dr(7) & " </font>"
                lm5.Controls.Add(lm58)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)


                lm59.ColumnSpan = 1
                lm59.HorizontalAlign = HorizontalAlign.Left
                lm59.Text = "<font size=2>" & dr(8) & " </font>"
                lm5.Controls.Add(lm59)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)

                lm60.ColumnSpan = 1
                lm60.HorizontalAlign = HorizontalAlign.Left
                lm60.Text = "<font size=2>" & dr(9) & " </font>"
                lm5.Controls.Add(lm60)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)
            Next
        End If








        Dim lin301 As New TableRow
        lin301.Width = 7
        Dim lin3011 As New TableCell
        lin3011.ColumnSpan = 10 ' 7
        lin3011.Text = "<hr align=center width=100% >"
        lin301.Controls.Add(lin3011)
        assettab.Controls.Add(lin301)

        Me.Panel1.Controls.Add(assettab)
    End Sub
End Class
