Imports System.Data
Imports System.Data.OracleClient
Partial Class search_employment_report_display_c85462ce5530
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("align", "left")
        tab.Attributes.Add("border", "0")

        'Dim trr1 As New TableRow
        'trr1.Width = 15
        'Dim tdr11 As New TableCell
        'tdr11.Attributes.Add("width", "100%")
        'tdr11.Attributes.Add("bgcolor", "gold")
        'tdr11.ColumnSpan = 15
        'tdr11.HorizontalAlign = HorizontalAlign.Center
        'tdr11.Text = "<font size=4><b> MANAPPURAM GROUP OF COMPANIES  </b></font>"
        'trr1.Controls.Add(tdr11)
        'tab.Controls.Add(trr1)

        Dim tr1 As New TableRow
        tr1.Width = 15
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 15
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tab.Controls.Add(tr1)

        Dim tr2 As New TableRow
        tr2.Width = 15
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "100%")
        td21.ColumnSpan = 15
        td21.HorizontalAlign = HorizontalAlign.Center
        td21.Text = "<font size=2><b> " & Me.Session("branch_name") & " </b></font>"
        tr2.Controls.Add(td21)
        tab.Controls.Add(tr2)


        Dim trr As New TableRow
        trr.Width = 15
        Dim tdr1 As New TableCell
        tdr1.Attributes.Add("width", "100%")
        tdr1.Attributes.Add("bgcolor", "lightblue")
        tdr1.ColumnSpan = 15
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.Text = "<font size=3><b> EMPLOYEE - EMPLOYMENT DETAILS  </b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)

        Dim tr3 As New TableRow
        tr3.Width = 15
        Dim td31, td3m As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 2
        td3m.ColumnSpan = 11
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        tr3.Controls.Add(td3m)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 2
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss tt") & "</b></font>"
        tr3.Controls.Add(td32)
        tab.Controls.Add(tr3)

        Dim lin2 As New TableRow
        lin2.Width = 15
        Dim lin22 As New TableCell
        lin22.ColumnSpan = 15
        lin22.Text = "<hr align=center width=100% >"
        lin2.Controls.Add(lin22)
        tab.Controls.Add(lin2)



        Dim trr2 As New TableRow
        trr2.Width = 15
        Dim tdr2 As New TableCell
        tdr2.Attributes.Add("width", "100%")
        tdr2.Attributes.Add("bgcolor", "snow")
        tdr2.ColumnSpan = 15
        tdr2.HorizontalAlign = HorizontalAlign.Center
        tdr2.Text = "<font size=3 color=red><b> DATE FROM " & Request.QueryString("fdat") & "  TO " & Request.QueryString("tdat") & "'  </b></font>"
        trr2.Controls.Add(tdr2)
        tab.Controls.Add(trr2)

        Dim lin2101 As New TableRow
        lin2101.Width = 15
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 15
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)

        Dim ta5 As New TableRow
        Dim ta51, ta52, ta53, ta54, ta55, ta56, ta60, ta61, ta62, ta63, ta64, ta551 As New TableCell
        ta62.Attributes.Add("width", "5%")
        ta52.Attributes.Add("width", "5%")

        ta52.ColumnSpan = 1
        ta53.ColumnSpan = 1
        ta54.ColumnSpan = 1
        ta55.ColumnSpan = 1
        ta56.ColumnSpan = 2
        'ta57.ColumnSpan = 1
        'ta58.ColumnSpan = 1
        'ta59.ColumnSpan = 1
        ta60.ColumnSpan = 2
        ta61.ColumnSpan = 1
        ta62.ColumnSpan = 4
        ta63.ColumnSpan = 2
        ' ta65.ColumnSpan = 1
        ' ta66.ColumnSpan = 1
        ' ta67.ColumnSpan = 1
        ta60.Text = "<font size=2><b>DATE OF JOINING</b></font>"
        ta52.Text = "<font size=2><b>BRANCH</b></font>"
        ta53.Text = "<font size=2><b>EMPLOY CODE</b></font>"
        ta54.Text = "<font size=2><b>EMPLOYEE NAME</b></font>"
        ta61.Text = "<font size=2><b>EMPLOY TYPE</b></font>"
        ta62.Text = "<font size=2><b>FIRM</b></font>"
        ta63.Text = "<font size=2><b>DESIGNATION</b></font>"
        ta55.Text = "<font size=2><b>DEPARTMENT</b></font>"
        ta56.Text = "<font size=2><b> POST OFFERED</b></font>"
        'ta57.Text = "<font size=2><b> LONG LEAVE</b></font>"
        'ta58.Text = "<font size=2><b>GL.&nbsp;RC. NORMS</b></font>"
        'ta59.Text = "<font size=2><b>GL.&nbsp;RC ACTUAL</b></font>"
        'ta65.Text = "<font size=2><b>GL.&nbsp;RC. SHORT</b></font>"
        'ta66.Text = "<font size=2><b>GL.&nbsp;RC. SURPLUS </b></font>"
        'ta67.Text = "<font size=2><b>GL.&nbsp;MKT. ACTUAL</b></font>"
        ta52.HorizontalAlign = HorizontalAlign.Center
        ta53.HorizontalAlign = HorizontalAlign.Center
        ta54.HorizontalAlign = HorizontalAlign.Center
        ta55.HorizontalAlign = HorizontalAlign.Center
        ta551.HorizontalAlign = HorizontalAlign.Center
        ta56.HorizontalAlign = HorizontalAlign.Center
        ' ta57.HorizontalAlign = HorizontalAlign.Left
        ' ta58.HorizontalAlign = HorizontalAlign.Left
        ' ta59.HorizontalAlign = HorizontalAlign.Left
        ta60.HorizontalAlign = HorizontalAlign.Center
        ta61.HorizontalAlign = HorizontalAlign.Center
        ta62.HorizontalAlign = HorizontalAlign.Center
        ta63.HorizontalAlign = HorizontalAlign.Center
        'ta65.HorizontalAlign = HorizontalAlign.Left
        'ta66.HorizontalAlign = HorizontalAlign.Center
        'ta67.HorizontalAlign = HorizontalAlign.Center



        ''
        ta5.Controls.Add(ta60)
        ta5.Controls.Add(ta52)
        ta5.Controls.Add(ta53)
        ta5.Controls.Add(ta54)
        ta5.Controls.Add(ta61)
        ta5.Controls.Add(ta62)
        ta5.Controls.Add(ta63)
        ta5.Controls.Add(ta55)
        ta5.Controls.Add(ta56)
        ' ta5.Controls.Add(ta57)
        ' ta5.Controls.Add(ta58)
        ' ta5.Controls.Add(ta59)
        ' ta5.Controls.Add(ta65)
        ' ta5.Controls.Add(ta66)
        'ta5.Controls.Add(ta67)


        Dim colors As String
        colors = "#ffdjff"
        ta5.Attributes.Add("bgcolor", colors)
        tab.Controls.Add(ta5)
        Dim dt As DataTable = oh.ExecuteDataSet("" & Request.QueryString("sql") & "").Tables(0)

        Dim dr As DataRow
        'Dim str As String
        ''                  0           1            2           3         4        -----------------------------------5-----------------------------------------------------------           ---------------------------6---------------------------------------------------                     -----------------------------7------------------                         ------------------------------------------------------8  ----------------                                   ---9----------------------------------                                                                                                        ----10---------------------------------------------------------------------------------------------                                 ----------------------11-----------------------------------------------------------                          -----------------------12--------------------------------------     --------------------------------------------     ------------------13--------------------------------------------------------
        'str = "select rm.reg_id,count(sr.branch_id),rm.reg_name,round(sum(sr.sr_bh)+sum(sr.bh)+sum(sr.abh)+sum(sr.jr_asst)+sum(sr.sweeper))as as_per_norms,round(sum(sr.sr_bh_avbl)+sum(sr.bh_avbl)+sum(sr.abh_avbl)+sum(sr.jr_asst_avbl)+sum(sr.sweeper_avbl)) as actual,round(sum(sr.sr_bh_avbl)+sum(sr.bh_avbl)+sum(sr.abh_avbl)+sum(sr.jr_asst_avbl)) as others,sum(sr.sweeper_avbl) as sweeper,nvl(sum(case when sr.jr_asst-sr.jr_asst_avbl<0 then 0 else sr.jr_asst-sr.jr_asst_avbl end),0) as short_jr,nvl(sum(case when sr.sweeper-sr.sweeper_avbl<0 then 0 else sr.sweeper-sr.sweeper_avbl end),0) as short_sweeper,nvl(sum(case when sr.jr_asst_avbl-sr.jr_asst<0 then 0 else sr.jr_asst_avbl-sr.jr_asst end),0) as surplus,sum(sr.long_leave) as long_leave,sum(sr.fldstaff_gold) as gl_rc_norm,sum(sr.fldstaff_gold_avbl) as gl_rc_actual,nvl(sum(case when sr.fldstaff_gold-sr.fldstaff_gold_avbl<0 then 0 else sr.fldstaff_gold-sr.fldstaff_gold_avbl end),0) as short_gl_rc,nvl(sum(case when sr.fldstaff_gold_avbl-sr.fldstaff_gold<0 then 0 else sr.fldstaff_gold_avbl-sr.fldstaff_gold end),0) as surplus_gl_rc,sum(sr.gl_marketing) as gl_mkt_actual  from staff_required sr,area_detail ad,region_master rm,division_detail dd,region_detail rd,zonal_detail zd where sr.branch_id=ad.branch_id and ad.area_id=dd.area_id and dd.div_id=rd.division_id and rd.region_id=zd.region_id  and rd.region_id=rm.reg_id and zd.zonal_id=" & Request.QueryString("zone_id") & " and sr.branch_id<>0 group by rm.reg_id,rm.reg_name"
        'dt = oh.ExecuteDataSet(str).Tables(0)


        Dim emp As Integer
        emp = 0



        For Each dr In dt.Rows

            If colors.Equals("#ffffef") = True Then
                colors = "#egf9ff"
            Else
                colors = "#ffffef"
            End If

            Dim lm5 As New TableRow
            lm5.Attributes.Add("bgcolor", colors)
            Dim lm49, lm51, lm52, lm53, lm54, lm55, lm56, lm60, sbh, bh, abh As New TableCell

            bh.Attributes.Add("width", "5%")
            lm51.Attributes.Add("width", "5%")
            ''''''''''''''''''''''''''''''''''''''''''''''''
            lm51.ColumnSpan = 2
            lm51.HorizontalAlign = HorizontalAlign.Center


            ''''''''''''''''''''''''''''
            '
            lm51.ColumnSpan = 2
            lm51.HorizontalAlign = HorizontalAlign.Center
            lm51.Text = "<font size=2>" & dr(3) & "</font>"
            lm5.Controls.Add(lm51)



            lm52.ColumnSpan = 1
            lm52.HorizontalAlign = HorizontalAlign.Left
            lm52.Text = "<font size=2> " & dr(0) & " </font>"
            lm5.Controls.Add(lm52)

            lm53.ColumnSpan = 1
            lm53.HorizontalAlign = HorizontalAlign.Left
            lm53.Text = "<font size=2> " & dr(1) & "</font>"
            lm5.Controls.Add(lm53)


            lm54.ColumnSpan = 1
            lm54.HorizontalAlign = HorizontalAlign.Left

            lm54.Text = "<font size=2>" & dr(2) & "</font></a>"
            lm5.Controls.Add(lm54)
            emp = emp + 1
            ''''''''''''''''''''
            sbh.ColumnSpan = 1
            sbh.HorizontalAlign = HorizontalAlign.Center
            sbh.Text = "<font size=2>" & dr(4) & "</font>"
            lm5.Controls.Add(sbh)
            'oth = oth + dr(5)
            bh.ColumnSpan = 4
            bh.HorizontalAlign = HorizontalAlign.Center
            bh.Text = "<font size=2>" & dr(5) & "</font>"
            lm5.Controls.Add(bh)
            ' swee = swee + dr(6)
            abh.ColumnSpan = 2
            abh.HorizontalAlign = HorizontalAlign.Center
            abh.Text = "<font size=2>" & dr(6) & "</font>"
            lm5.Controls.Add(abh)

            ' sjr = sjr + dr(7)



            '''''''''''''''''

            lm55.ColumnSpan = 1
            lm55.HorizontalAlign = HorizontalAlign.Center

            lm55.Text = "<font size=2> " & dr(7) & "</font>"
            lm5.Controls.Add(lm55)
            'sswee = sswee + dr(8)
            lm56.ColumnSpan = 2
            lm56.HorizontalAlign = HorizontalAlign.Center
            lm56.Text = "<font size=2> " & dr(8) & "</font>"
            lm5.Controls.Add(lm56)
            ' spjr = spjr + dr(9)
            'lm57.ColumnSpan = 1
            'lm57.HorizontalAlign = HorizontalAlign.Center
            'lm57.Text = "<font size=2> " & dr(10) & "</font>"
            'lm5.Controls.Add(lm57)
            'll = ll + dr(10)
            'lm58.ColumnSpan = 1
            'lm58.HorizontalAlign = HorizontalAlign.Center
            'lm58.Text = "<font size=2> " & dr(11) & "</font>"
            ''cn7 += dr(9)
            'lm5.Controls.Add(lm58)
            'grn = grn + dr(11)

            'lm59.ColumnSpan = 1
            'lm59.HorizontalAlign = HorizontalAlign.Center
            'lm59.Text = "<font size=2> " & dr(12) & "</font>"
            'lm5.Controls.Add(lm59)
            'gra = gra + dr(12)
            'lm65.ColumnSpan = 1
            'lm65.HorizontalAlign = HorizontalAlign.Center
            'lm65.Text = "<font size=2> " & dr(13) & "</font>"
            'lm5.Controls.Add(lm65)
            'grs = grs + dr(13)
            'lm66.ColumnSpan = 1
            'lm66.HorizontalAlign = HorizontalAlign.Center
            'lm66.Text = "<font size=2> " & dr(14) & "</font>"
            'lm5.Controls.Add(lm66)

            'grss = grss + dr(14)
            'lm67.ColumnSpan = 1
            'lm67.HorizontalAlign = HorizontalAlign.Center
            'lm67.Text = "<font size=2> " & dr(15) & "</font>"
            'lm5.Controls.Add(lm67)
            'gma = gma + dr(15)
            tab.Controls.Add(lm5)

        Next


        Dim li12 As New TableRow
        Dim li112 As New TableCell
        li112.ColumnSpan = 15
        li112.Text = "<hr align=center width=100% >"
        li12.Controls.Add(li112)
        tab.Controls.Add(li12)

        '''''''''''''''''''''''''''''''''''''''
        Dim llm5 As New TableRow
        llm5.Attributes.Add("bgcolor", "seashell")
        Dim llm49, llm51, llm52, llm53, llm54, llm55, llm56, llm60, lsbh, lbh, labh As New TableCell


        ''''''''''''''''''''''''''''''''''''''''''''''''
        llm51.ColumnSpan = 2
        llm51.HorizontalAlign = HorizontalAlign.Left


        ''''''''''''''''''''''''''''
        '
        llm51.ColumnSpan = 2
        llm51.HorizontalAlign = HorizontalAlign.Left
        llm51.Text = "<font size=2></font>"
        llm5.Controls.Add(llm51)


        llm52.ColumnSpan = 1
        llm52.HorizontalAlign = HorizontalAlign.Left
        llm52.Text = ""
        llm5.Controls.Add(llm52)

        llm53.ColumnSpan = 1
        llm53.HorizontalAlign = HorizontalAlign.Left
        llm53.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm53)


        llm54.ColumnSpan = 1
        llm54.HorizontalAlign = HorizontalAlign.Left

        llm54.Text = "<font size=2>" & emp & "</font></a>"
        llm5.Controls.Add(llm54)
        ''''''''''''''''''''
        lsbh.ColumnSpan = 1
        lsbh.HorizontalAlign = HorizontalAlign.Center
        lsbh.Text = "<font size=2></font>"
        llm5.Controls.Add(lsbh)

        lbh.ColumnSpan = 4
        lbh.HorizontalAlign = HorizontalAlign.Center
        lbh.Text = "<font size=2></font>"
        llm5.Controls.Add(lbh)

        labh.ColumnSpan = 2
        labh.HorizontalAlign = HorizontalAlign.Center
        labh.Text = "<font size=2></font>"
        llm5.Controls.Add(labh)





        '''''''''''''''''

        llm55.ColumnSpan = 1
        llm55.HorizontalAlign = HorizontalAlign.Center

        llm55.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm55)

        llm56.ColumnSpan = 2
        llm56.HorizontalAlign = HorizontalAlign.Center
        llm56.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm56)

        'llm57.ColumnSpan = 1
        'llm57.HorizontalAlign = HorizontalAlign.Center
        'llm57.Text = "<font size=2> </font>"
        'llm5.Controls.Add(llm57)
        'llm58.ColumnSpan = 1
        'llm58.HorizontalAlign = HorizontalAlign.Center
        'llm58.Text = "<font size=2></font>"
        ''cn7 += dr(9)
        'llm5.Controls.Add(llm58)


        'llm59.ColumnSpan = 1
        'llm59.HorizontalAlign = HorizontalAlign.Center
        'llm59.Text = "<font size=2> " & gra & "</font>"
        'llm5.Controls.Add(llm59)

        'llm65.ColumnSpan = 1
        'llm65.HorizontalAlign = HorizontalAlign.Center
        'llm65.Text = "<font size=2> " & grs & "</font>"
        'llm5.Controls.Add(llm65)

        'llm66.ColumnSpan = 1
        'llm66.HorizontalAlign = HorizontalAlign.Center
        'llm66.Text = "<font size=2> " & grss & "</font>"
        'llm5.Controls.Add(llm66)


        'llm67.ColumnSpan = 1
        'llm67.HorizontalAlign = HorizontalAlign.Center
        'llm67.Text = "<font size=2> " & gma & "</font>"
        'llm5.Controls.Add(llm67)

        tab.Controls.Add(llm5)

        '''''''''''''''''''''''''''''''''''''''''''''




        Dim lin21012 As New TableRow
        Dim lin210112 As New TableCell
        lin210112.ColumnSpan = 15
        lin210112.Text = "<hr align=center width=100% >"
        lin21012.Controls.Add(lin210112)
        tab.Controls.Add(lin21012)
        Dim lin21 As New TableRow
        Dim lin212 As New TableCell
        lin212.ColumnSpan = 15
        lin212.Text = "<a href=search_employment_details.aspx><font color=blue>BACK</font ></a>"
        lin21.Controls.Add(lin212)
        tab.Controls.Add(lin21)
        PanelDrilldownshort.Controls.Add(tab)
    End Sub
End Class
