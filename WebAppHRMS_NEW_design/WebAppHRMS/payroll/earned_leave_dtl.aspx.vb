Imports System.Data
Imports System.Data.OracleClient
Partial Class staffaccount_earned_leave_dtl_97b3b9143676
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim user = Me.Session("user_id").ToString.Split("!")
        'Dim status As Integer = ob.checkUser(user(0), 12)
        'If status = 1 Then
        '    Server.Transfer("../show_err.aspx")
        '    Exit Sub
        'End If
        'If (Session("branch_id") <> 0) Then
        '    Server.Transfer("../show_err.aspx")
        '    Exit Sub
        'End If                             0            1              2         3               4                  5             6
        dt = oh.ExecuteDataSet("select em.emp_code,  em.emp_name,  ds.designation,  dp.dep_name,  br.branch_name,  el.earned_leave,  el.encash_leave,  el.earned_year  from hrm_earned_leave   el,  employee_master    em,  designation_master ds,  branch_master      br,  department_mst     dp,employ_firm f  where el.emp_id = em.emp_code  and em.designation_id = ds.designation_id  and em.department_id = dp.dep_id  and em.branch_id = br.branch_id  and em.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & " ").Tables(0)
        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 8
        line11.Text = "<hr align=center width=100% >"
        line1.Controls.Add(line11)

        Dim assettab As New Table
        assettab.Attributes.Add("width", "100%")

        Dim ta1 As New TableRow
        Dim ta11 As New TableCell
        ta11.ColumnSpan = 8
        ta1.Attributes.Add("bgcolor", "gold")
        ta1.Attributes.Add("bordercolor", "red")
        ta11.Text = "<font size=4><b>" & Session("firm_name") & "</b></font>"
        ta11.ForeColor = Drawing.Color.Red
        ta11.HorizontalAlign = HorizontalAlign.Center
        ta1.Controls.Add(ta11)

        assettab.Controls.Add(ta1)

        Dim tabr2 As New TableRow
        tabr2.Width = 8
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 8
        tabc2.Attributes.Add("align", "center")
        tabc2.Text = "<body align=center color=red><b><font size=3.5> EARNED LEAVE REPORT </font></b></body>"
        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        assettab.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")



        Dim ta3 As New TableRow
        ta3.Attributes.Add("bgcolor", "#ffcca3")
        ta3.ForeColor = Drawing.Color.Maroon
        ta3.Width = 8
        Dim ta31, ta32, ta33 As New TableCell
        ta31.ColumnSpan = 2
        ta32.ColumnSpan = 4
        ta33.ColumnSpan = 2
        ta31.Text = "<font size=3.5><b>Date :" & Format(Today, "dd/MM/yyyy") & " </b></font>"
        ta32.Text = "<font size=2><b>&nbsp;</b></font>"

        ta33.Text = "<font size=3.5><b>Time :" & Format(TimeOfDay, "hh:mm:ss tt") & " </b></font>"
        ta31.HorizontalAlign = HorizontalAlign.Left
        ta32.HorizontalAlign = HorizontalAlign.Center
        ta33.HorizontalAlign = HorizontalAlign.Right
        ta3.Controls.Add(ta31)
        ta3.Controls.Add(ta32)
        ta3.Controls.Add(ta33)
        assettab.Controls.Add(ta3)

        '---------------------------------------------------------------------------------
        Dim lin2101 As New TableRow
        lin2101.Width = 8
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 8
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        assettab.Controls.Add(lin2101)

        Dim lm4 As New TableRow
        lm4.ForeColor = Drawing.Color.Maroon
        lm4.Width = 8
        Dim lm41, lm42, lm43, lm44, lm45, lm46, lm47, lm48 As New TableCell

        lm48.ColumnSpan = 1
        lm48.Text = "<font size=2><b>CODE</b></font>"
        lm48.HorizontalAlign = HorizontalAlign.Left

        lm45.ColumnSpan = 1
        lm45.Text = "<font size=2><b> NAME </b></font>"
        lm45.HorizontalAlign = HorizontalAlign.Left


        lm41.ColumnSpan = 1
        lm41.Text = "<font size=2><b> DESIGNATION  </b></font>"
        lm41.HorizontalAlign = HorizontalAlign.Left

        lm42.ColumnSpan = 1
        lm42.Text = "<font size=2><b> DEPARTMENT</b></font>"
        lm42.HorizontalAlign = HorizontalAlign.Left

        lm43.ColumnSpan = 1
        lm43.Text = "<font size=2><b>BRANCH</b></font>"
        lm43.HorizontalAlign = HorizontalAlign.Left

        lm44.ColumnSpan = 1
        lm44.Text = "<font size=2><b> EARNED LEAVE </b></font>"
        lm44.HorizontalAlign = HorizontalAlign.Right


        lm46.ColumnSpan = 1
        lm46.Text = "<font size=2><b> ENCASHMENT LEAVE</b></font>"
        lm46.HorizontalAlign = HorizontalAlign.Right


        lm47.ColumnSpan = 1
        lm47.Text = "<font size=2><b> EARNED YEAR </b></font>"
        lm47.HorizontalAlign = HorizontalAlign.Right


        lm4.Controls.Add(lm48)
        lm4.Controls.Add(lm45)
        lm4.Controls.Add(lm41)
        lm4.Controls.Add(lm42)
        lm4.Controls.Add(lm43)
        lm4.Controls.Add(lm44)
        lm4.Controls.Add(lm46)
        lm4.Controls.Add(lm47)
        assettab.Controls.Add(lm4)

        Dim lin21 As New TableRow
        lin21.Width = 8
        Dim lin211 As New TableCell
        lin211.ColumnSpan = 8
        lin211.Text = "<hr align=center width=100% >"
        lin21.Controls.Add(lin211)
        assettab.Controls.Add(lin21)
        '------------------------------------------------------------------------------------------
        Dim dr As DataRow
        Dim cnt As Integer = 0
        Dim total As Integer = 0
        Dim colors As String = "#fff7ff"

        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                cnt += 1
                If colors.Equals("#fff7ff") = True Then
                    colors = "#eef9ff"
                Else
                    colors = "#fff7ff"
                End If

                Dim lm5 As New TableRow
                'lm5.Width = 7
                Dim lm51, lm52, lm53, lm54, lm55, lm56, lm57, lm58 As New TableCell
                lm55.ColumnSpan = 1
                lm55.HorizontalAlign = HorizontalAlign.Left
                lm55.Text = "<font size=2>" & dr(0) & " </font>"
                lm5.Controls.Add(lm55)


                lm5.Font.Size = 8
                lm51.ColumnSpan = 1
                lm51.HorizontalAlign = HorizontalAlign.Left
                lm51.Text = "<font size=2>" & dr(1) & " </font>"
                lm5.Controls.Add(lm51)

                lm52.ColumnSpan = 1
                lm52.HorizontalAlign = HorizontalAlign.Left
                lm52.Text = "<font size=2>" & dr(2) & " </font>"
                lm5.Controls.Add(lm52)

                lm53.ColumnSpan = 1
                lm53.HorizontalAlign = HorizontalAlign.Left
                lm53.Text = "<font size=2>" & dr(3) & " </font>"
                lm5.Controls.Add(lm53)

                lm54.ColumnSpan = 1
                lm54.HorizontalAlign = HorizontalAlign.Left
                lm54.Text = "<font size=2>" & dr(4) & " </font>"
                lm5.Controls.Add(lm54)


                lm56.ColumnSpan = 1
                lm56.HorizontalAlign = HorizontalAlign.Right
                lm56.Text = "<font size=2>" & dr(5) & " </font>"
                lm5.Controls.Add(lm56)

                lm57.ColumnSpan = 1
                lm57.HorizontalAlign = HorizontalAlign.Right
                lm57.Text = "<font size=2>" & dr(6) & " </font>"
                lm5.Controls.Add(lm57)

                lm58.ColumnSpan = 1
                lm58.HorizontalAlign = HorizontalAlign.Right
                lm58.Text = "<font size=2>" & dr(7) & " </font>"
                lm5.Controls.Add(lm58)

                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)
            Next
        End If
        Dim lin20 As New TableRow
        'lin20.Width = 7
        Dim lin201 As New TableCell
        lin201.ColumnSpan = 8
        lin201.Text = "<hr align=center width=100% >"
        lin20.Controls.Add(lin201)
        assettab.Controls.Add(lin20)


        Me.Panel1.Controls.Add(assettab)

    End Sub
End Class
