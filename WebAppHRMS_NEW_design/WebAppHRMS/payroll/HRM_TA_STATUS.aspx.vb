Imports System.Data
Imports System.Data.OracleClient

Partial Class Report_detail_query_307bd9b71286
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    'Krishnadas jan-13-2016-----------new report


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim sql As String
        Dim frid = Session("firm_id")
        Dim fromdt = Request.QueryString.Get("fdt")
        Dim todt = Request.QueryString.Get("tdt")

        sql = "select t.emp_code,       m.emp_name,       to_char(t.from_dt,'dd/mm/yyyy') FROM_DT,        to_char(t.to_dt,'dd/mm/yyyy') TO_DT,        t.source,        t.destination,        t.distance||' '||'KM',        s.description,        k.description,        decode(t.status_id, 0, 'APPLIED', 1, 'SANCTIONED', 3, 'CANCELLED', 4,  'RECOMMENDED')STATUS, case when t.recc_by is not null then substr(t.recc_by,0,instr(t.recc_by,'!')-1) || '-' || (select q.emp_name from employee_master q where q.emp_code = substr(t.recc_by,0,instr(t.recc_by,'!')-1)) else  '-'  end  RECC_BY , case when t.sanc_by is not null then substr(t.sanc_by,0,instr(t.sanc_by,'!')-1) || '-' ||  (select q1.emp_name from employee_master q1 where q1.emp_code = substr(t.sanc_by,0,instr(t.sanc_by,'!')-1))  else  '-'  end  SANC_BY, case when t.cancel_by is not null then t.cancel_by || '-' || (select q2.emp_name from employee_master q2 where q2.emp_code = t.cancel_by) else  '-' end CANCEL_BY , t.req_amount, nvl(t.sanc_amount,t.req_amount) from hrm_ta_request t join employee_master m on m.emp_code = t.emp_code    join (select t.status_id, t.description  from status_master t  where t.module_id = 118  and t.option_id = 1) s on s.status_id =  t.purpose_id join (select t.status_id, t.description  from status_master t where t.module_id = 118   and t.option_id = 2) k on k.status_id = t.mode_id where t.emp_code = " & User(0) & "  and to_date(t.from_dt) between  to_date('" & fromdt & "') and to_date('" & todt & "') order by t.from_dt"


        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)

        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 21
        line11.Text = "<hr align=center width=100% >"
        line1.Controls.Add(line11)

        Dim assettab As New Table
        assettab.Attributes.Add("width", "100%")

        Dim ta1 As New TableRow
        Dim ta11 As New TableCell
        ta11.ColumnSpan = 21
        ta1.Attributes.Add("bgcolor", "lightgrey") 'gold
        ta1.Attributes.Add("bordercolor", "black")
        ta11.Text = "<font size=4.5><b>" & Session("firm_name") & "</b></font>"
        ta11.ForeColor = Drawing.Color.Black 'Red
        ta11.HorizontalAlign = HorizontalAlign.Center
        ta1.Controls.Add(ta11)

        assettab.Controls.Add(ta1)


        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#F5F5F5")


        Dim ta3 As New TableRow
        ta3.Attributes.Add("bgcolor", "#F5F5F5")
        ta3.ForeColor = Drawing.Color.Black 'Maroon
        ta3.Width = 21
        Dim ta31, ta32, ta33 As New TableCell
        ta31.ColumnSpan = 2
        ta32.ColumnSpan = 17
        ta33.ColumnSpan = 2
        ta31.Text = "<font size=3.5><b>Date :" & Format(Today, "dd/MM/yyyy") & " </b></font>"
        ta32.Text = "<font size=3><b>TRAVEL ALLOWANCE STATUS REPORT&nbsp;</b></font>"

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
        lin2101.Width = 21
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 21
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        assettab.Controls.Add(lin2101)

        Dim lm4 As New TableRow
        lm4.Width = 21
        Dim lm41, lm42, lm43, lm44, lm45, lm46, lm47, lm48, lm49, lm50, lm81, lm82, lm83, lm84, lm85, lm86 As New TableCell
        lm41.ColumnSpan = 1
        lm41.Text = "<font size=2><b> EMPLOYEE CODE </b></font>"
        lm41.HorizontalAlign = HorizontalAlign.Left

        lm42.ColumnSpan = 2
        lm42.Text = "<font size=2><b> EMPLOYEE NAME </b></font>"
        lm42.HorizontalAlign = HorizontalAlign.Left


        lm43.ColumnSpan = 1
        lm43.Text = "<font size=2><b> FROM DATE </b></font>"
        lm43.HorizontalAlign = HorizontalAlign.Left

        lm44.ColumnSpan = 1
        lm44.Text = "<font size=2><b> TO DATE </b></font>"
        lm44.HorizontalAlign = HorizontalAlign.Left

        lm45.ColumnSpan = 2
        lm45.Text = "<font size=2><b> SOURCE </b></font>"
        lm45.HorizontalAlign = HorizontalAlign.Left

        lm46.ColumnSpan = 2
        lm46.Text = "<font size=2><b> DESTINATION </b></font>"
        lm46.HorizontalAlign = HorizontalAlign.Left

        lm47.ColumnSpan = 1
        lm47.Text = "<font size=2><b> DISTANCE </b></font>"
        lm47.HorizontalAlign = HorizontalAlign.Left

        lm48.ColumnSpan = 1
        lm48.Text = "<font size=2><b> PURPOSE </b></font>"
        lm48.HorizontalAlign = HorizontalAlign.Left

        lm49.ColumnSpan = 1
        lm49.Text = "<font size=2><b> MODE </b></font>"
        lm49.HorizontalAlign = HorizontalAlign.Left


        lm81.ColumnSpan = 1
        lm81.Text = "<font size=2><b> STATUS </b></font>"
        lm81.HorizontalAlign = HorizontalAlign.Left

        lm82.ColumnSpan = 2
        lm82.Text = "<font size=2><b> RECOMMENDED BY </b></font>"
        lm82.HorizontalAlign = HorizontalAlign.Left

        lm83.ColumnSpan = 2
        lm83.Text = "<font size=2><b> SANCTIONED BY </b></font>"
        lm83.HorizontalAlign = HorizontalAlign.Left

        lm84.ColumnSpan = 2
        lm84.Text = "<font size=2><b> CANCELLED BY </b></font>"
        lm84.HorizontalAlign = HorizontalAlign.Left

        lm85.ColumnSpan = 1
        lm85.Text = "<font size=2><b> REQUESTED AMOUNT </b></font>"
        lm85.HorizontalAlign = HorizontalAlign.Left

        lm86.ColumnSpan = 1
        lm86.Text = "<font size=2><b> SANCTIONED AMOUNT </b></font>"
        lm86.HorizontalAlign = HorizontalAlign.Left

        lm4.Controls.Add(lm41)
        lm4.Controls.Add(lm42)
        lm4.Controls.Add(lm43)
        lm4.Controls.Add(lm44)
        lm4.Controls.Add(lm45)
        lm4.Controls.Add(lm46)
        lm4.Controls.Add(lm47)
        lm4.Controls.Add(lm48)
        lm4.Controls.Add(lm49)
        lm4.Controls.Add(lm81)
        lm4.Controls.Add(lm82)
        lm4.Controls.Add(lm83)
        lm4.Controls.Add(lm84)
        lm4.Controls.Add(lm85)
        lm4.Controls.Add(lm86)


        assettab.Controls.Add(lm4)

        Dim lin21 As New TableRow
        lin21.Width = 21
        Dim lin211 As New TableCell
        lin211.ColumnSpan = 21
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
        Dim colors As String = "#F5F5F5"

        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows

                Dim lm5 As New TableRow
                lm5.Width = 21
                Dim lm51, lm52, lm53, lm54, lm55, lm56, lm57, lm58, lm59, lm60, lm61, lm62, lm63, lm64, lm65, lm66, lm67, lm68 As New TableCell
                lm5.Font.Size = 8
                lm51.ColumnSpan = 1
                lm51.HorizontalAlign = HorizontalAlign.Left
                lm51.Text = "<font size=1>" & dr(0) & " </font>"   'EMPLOYEE CODE
                lm5.Controls.Add(lm51)

                lm52.ColumnSpan = 2
                lm52.HorizontalAlign = HorizontalAlign.Left
                lm52.Text = "<font size=1.5>" & dr(1) & " </font>"  ' EMPLOYEE NAME
                lm5.Controls.Add(lm52)


                lm53.ColumnSpan = 1
                lm53.HorizontalAlign = HorizontalAlign.Left
                lm53.Text = "<font size=1.5>" & dr(2) & " </font>" 'FROM DATE
                lm5.Controls.Add(lm53)

                lm54.ColumnSpan = 1
                lm54.HorizontalAlign = HorizontalAlign.Left
                lm54.Text = "<font size=1.5>" & dr(3) & " </font>" 'TO DATE
                lm5.Controls.Add(lm54)
                assettab.Controls.Add(lm5)


                lm55.ColumnSpan = 2
                lm55.HorizontalAlign = HorizontalAlign.Left
                lm55.Text = "<font size=1.5>" & dr(4) & " </font>" 'SOURCE
                lm5.Controls.Add(lm55)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)


                lm56.ColumnSpan = 2
                lm56.HorizontalAlign = HorizontalAlign.Left
                lm56.Text = "<font size=1.5>" & dr(5) & " </font>" 'DESTINATION
                lm5.Controls.Add(lm56)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)



                lm57.ColumnSpan = 1
                lm57.HorizontalAlign = HorizontalAlign.Left
                lm57.Text = "<font size=1.5>" & dr(6) & " </font>" 'DISTANCE
                lm5.Controls.Add(lm57)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)


                lm58.ColumnSpan = 1
                lm58.HorizontalAlign = HorizontalAlign.Left
                lm58.Text = "<font size=1.5>" & dr(7) & " </font>" 'PURPOSE
                lm5.Controls.Add(lm58)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)


                lm59.ColumnSpan = 1
                lm59.HorizontalAlign = HorizontalAlign.Left
                lm59.Text = "<font size=1.5>" & dr(8) & " </font>" 'MODE
                lm5.Controls.Add(lm59)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)



                lm60.ColumnSpan = 1
                lm60.HorizontalAlign = HorizontalAlign.Left
                lm60.Text = "<font size=1.5>" & dr(9) & " </font>" 'STATUS
                lm5.Controls.Add(lm60)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)



                lm61.ColumnSpan = 2
                lm61.HorizontalAlign = HorizontalAlign.Left
                lm61.Text = "<font size=1.5>" & dr(10) & " </font>" 'RECC BY
                lm5.Controls.Add(lm61)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)



                lm62.ColumnSpan = 2
                lm62.HorizontalAlign = HorizontalAlign.Left
                lm62.Text = "<font size=1.5>" & dr(11) & " </font>" 'SANC BY
                lm5.Controls.Add(lm62)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)



                lm63.ColumnSpan = 2
                lm63.HorizontalAlign = HorizontalAlign.Left
                lm63.Text = "<font size=1.5>" & dr(12) & " </font>" 'CANCELL BY
                lm5.Controls.Add(lm63)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)

                lm64.ColumnSpan = 1
                lm64.HorizontalAlign = HorizontalAlign.Left
                lm64.Text = "<font size=1.5>" & dr(13) & " </font>" 'REQ AMOUNT
                lm5.Controls.Add(lm64)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)

                lm65.ColumnSpan = 1
                lm65.HorizontalAlign = HorizontalAlign.Left
                lm65.Text = "<font size=1.5>" & dr(14) & " </font>" 'SANC AMOUNT
                lm5.Controls.Add(lm65)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)


                cnt += 1
            Next
        End If


        Dim lin301 As New TableRow
        lin301.Width = 21
        Dim lin3011 As New TableCell
        lin3011.ColumnSpan = 21
        lin3011.Text = "<hr align=center width=100% >"
        lin301.Controls.Add(lin3011)
        assettab.Controls.Add(lin301)


        Dim reg20 As New TableRow
        'reg20.Width = 7
        ' reg20.BackColor = Drawing.Color.Maroon
        Dim reg201 As New TableCell
        reg201.ColumnSpan = 21
        reg201.HorizontalAlign = HorizontalAlign.Left
        reg201.Text = "<font size=3 color=black ><b>TOTAL : " & cnt & "&nbsp;&nbsp;  </b></font>"
        reg20.Controls.Add(reg201)
        assettab.Controls.Add(reg20)

        Dim lin20 As New TableRow
        'lin20.Width = 7
        Dim lin201 As New TableCell
        lin201.ColumnSpan = 21
        lin201.Text = "<hr align=center width=100% >"
        lin20.Controls.Add(lin201)
        assettab.Controls.Add(lin20)



        Me.Panel1.Controls.Add(assettab)
    End Sub

    Protected Sub btn_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Response.Redirect("HRM_TA_DATE_SELE.aspx")
    End Sub
End Class
