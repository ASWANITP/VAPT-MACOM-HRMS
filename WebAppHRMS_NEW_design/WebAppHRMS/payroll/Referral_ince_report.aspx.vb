Imports System.Data
Imports System.Data.OracleClient
Partial Class Referral_incentive_report_8e854ba32547
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frm As Integer = Session("firm_id")
        '--KRISHNADAS CREATED FOR JEWEL REFERRAL INCENTIVE
        Dim sql As String
        'sql = "select t.emp_code,t.emp_name,d.dep_name,dm.designation, p.post_name,s.M_TIME,s.E_TIME from employee_master t join employ_firm f on f.emp_code = t.emp_code and f.firm_id = 2 and t.status_id = 1  and t.branch_id=" & itid & " join department_mst d on d.dep_id = t.department_id join designation_master dm on dm.designation_id = t.designation_id join post_mst p on p.post_id = t.post_id join(select att.EMP_CODE,att.CURR_DATE,att.M_TIME,att.E_TIME,att.SHIFT_ID,att.M_SHIFT,tb.shift_id as TIMETAB_SHIFT,tb.in_time from attendance att join time_tab tb on att.SHIFT_ID=tb.shift_id where att.CURR_DATE = to_date('12-Sep-2015') and to_char(att.M_TIME)>to_char(tb.in_time) and att.M_TIME<>'JOIN')s on s.EMP_CODE=t.emp_code order by t.emp_code"


        sql = "select t.designation_id,d.designation,t.amount,t.first_emi,t.second_emi,t.third_emi,f.firm_abbr from hrm_referral_amount_master t join designation_master d on d.designation_id=t.designation_id join firm_master f on f.firm_id=t.firm_id where t.firm_id=" & frm & " order by 2"

        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)

        'Dim dt1 As DataTable = oh.ExecuteDataSet("select t.branch_name from branch_master t where t.branch_id=" & itid & " ").Tables(0)
        'Dim name As String = dt1.Rows(0)(0)




        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 7
        line11.Text = "<hr align=center width=100% >"
        line1.Controls.Add(line11)

        Dim assettab As New Table
        assettab.Attributes.Add("width", "100%")

        Dim ta1 As New TableRow
        Dim ta11 As New TableCell
        ta11.ColumnSpan = 7
        ta1.Attributes.Add("bgcolor", "lightgrey") 'gold
        ta1.Attributes.Add("bordercolor", "black")
        ta11.Text = "<font size=4.5><b>" & Session("firm_name") & "</b></font>"
        ta11.ForeColor = Drawing.Color.Black
        ta11.HorizontalAlign = HorizontalAlign.Center
        ta1.Controls.Add(ta11)

        assettab.Controls.Add(ta1)

        Dim tabr2 As New TableRow
        tabr2.Width = 10
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 10
        tabc2.Attributes.Add("align", "center")
        tabc2.Text = "<body align=center color=red><b><font size=3>" & Session("branch_name") & "</font></b></body>"

        tabc2.ForeColor = Drawing.Color.Black
        tabr2.Controls.Add(tabc2)
        assettab.Controls.Add(tabr2)




        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#F5F5F5")


        Dim ta3 As New TableRow
        ta3.Attributes.Add("bgcolor", "#F5F5F5")
        ta3.ForeColor = Drawing.Color.Black
        ta3.Width = 7
        Dim ta31, ta32, ta33 As New TableCell
        ta31.ColumnSpan = 2
        ta32.ColumnSpan = 3
        ta33.ColumnSpan = 2
        ta31.Text = "<font size=3.5><b>Date :" & Format(Today, "dd/MM/yyyy") & " </b></font>"
        ta32.Text = "<font size=3><b>REFERRAL INCENTIVE AMOUNT STRUCTURE[DESIGNATION WISE]</b></font>"

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
        lin2101.Width = 10
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 10
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        assettab.Controls.Add(lin2101)

        Dim lm4 As New TableRow
        lm4.Width = 7
        Dim lm41, lm42, lm43, lm44, lm45, lm46, lm47, lm48, lm49, lm50 As New TableCell
        lm41.ColumnSpan = 1
        lm41.Text = "<font size=2><b> DESIGNATION ID </b></font>"
        lm41.HorizontalAlign = HorizontalAlign.Left

        lm42.ColumnSpan = 1
        lm42.Text = "<font size=2><b> DESIGNATION NAME </b></font>"
        lm42.HorizontalAlign = HorizontalAlign.Left


        lm43.ColumnSpan = 1
        lm43.Text = "<font size=2><b> TOTAL AMOUNT </b></font>"
        lm43.HorizontalAlign = HorizontalAlign.Left

        lm44.ColumnSpan = 1
        lm44.Text = "<font size=2><b> FIRST STEP AMOUNT </b></font>"
        lm44.HorizontalAlign = HorizontalAlign.Left

        lm45.ColumnSpan = 1
        lm45.Text = "<font size=2><b> SECOND STEP AMOUNT </b></font>"
        lm45.HorizontalAlign = HorizontalAlign.Left

        lm46.ColumnSpan = 1
        lm46.Text = "<font size=2><b> THIRD STEP AMOUNT </b></font>"
        lm46.HorizontalAlign = HorizontalAlign.Left

        lm47.ColumnSpan = 1
        lm47.Text = "<font size=2><b> FIRM </b></font>"
        lm47.HorizontalAlign = HorizontalAlign.Left




        lm4.Controls.Add(lm41)
        lm4.Controls.Add(lm42)
        lm4.Controls.Add(lm43)
        lm4.Controls.Add(lm44)
        lm4.Controls.Add(lm45)
        lm4.Controls.Add(lm46)
        lm4.Controls.Add(lm47)

        assettab.Controls.Add(lm4)

        Dim lin21 As New TableRow
        lin21.Width = 7
        Dim lin211 As New TableCell
        lin211.ColumnSpan = 7
        lin211.Text = "<hr align=center width=100% >"
        lin21.Controls.Add(lin211)
        assettab.Controls.Add(lin21)


        '------------------------------------------------------------------------------------------
        Dim dr As DataRow
        Dim colors As String = "#F5F5F5"

        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows

                Dim lm5 As New TableRow
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

            Next
        End If


        Dim lin301 As New TableRow
        lin301.Width = 7
        Dim lin3011 As New TableCell
        lin3011.ColumnSpan = 7
        lin3011.Text = "<hr align=center width=100% >"
        lin301.Controls.Add(lin3011)
        assettab.Controls.Add(lin301)

        Me.Panel1.Controls.Add(assettab)

    End Sub
End Class
