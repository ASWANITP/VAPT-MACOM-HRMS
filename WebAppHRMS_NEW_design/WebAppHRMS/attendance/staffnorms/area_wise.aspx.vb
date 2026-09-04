Imports System.Data.OracleClient
Imports System.Data

Partial Class staff_noms_area_wise_e2dd00368958
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("align", "left")
        tab.Attributes.Add("border", "0")

        Dim tr1 As New TableRow
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 31
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tab.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "100%")
        td21.ColumnSpan = 31
        td21.HorizontalAlign = HorizontalAlign.Center
        td21.Text = "<font size=2><b> " & Me.Session("branch_name") & " </b></font>"
        tr2.Controls.Add(td21)
        tab.Controls.Add(tr2)

        Dim trr As New TableRow
        Dim tdr1 As New TableCell
        tdr1.Attributes.Add("width", "100%")
        tdr1.ColumnSpan = 31
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.Text = "<font size=2><b> AREA WISE LIST </b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)

        Dim tr3 As New TableRow
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 15
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 16
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tab.Controls.Add(tr3)

        Dim lin2101 As New TableRow
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 31
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)



        Dim ta5 As New TableRow
        ta5.Width = 31
        Dim ta51, ta52, tajo, ta67HWnorm68, ta53, ta54, ta55, ta56, ta57, ta58, ta59, ta60, ta61, ta62, ta63, ta64, ta551, ta552, ta65, ta66, ta67, ta68, ta69, ta70, ta71, ta72, ta73, ta74, ta75, ta76, tamgmt As New TableCell
        tajo.ColumnSpan = 1
        ta67HWnorm68.ColumnSpan = 1
        ta51.ColumnSpan = 1
        ta52.ColumnSpan = 1
        ta53.ColumnSpan = 1
        ta54.ColumnSpan = 1
        ta55.ColumnSpan = 1
        ta56.ColumnSpan = 1
        ta57.ColumnSpan = 1
        ta58.ColumnSpan = 1
        ta59.ColumnSpan = 1
        ta60.ColumnSpan = 1
        ta61.ColumnSpan = 1
        ta62.ColumnSpan = 1
        ta63.ColumnSpan = 1
        ta64.ColumnSpan = 1
        ta551.ColumnSpan = 1
        ta552.ColumnSpan = 1
        ta65.ColumnSpan = 1
        ta66.ColumnSpan = 1
        ta67.ColumnSpan = 1
        ta68.ColumnSpan = 1
        ta69.ColumnSpan = 1
        ta70.ColumnSpan = 1
        ta71.ColumnSpan = 1
        ta72.ColumnSpan = 1
        ta73.ColumnSpan = 1
        ta74.ColumnSpan = 1
        ta75.ColumnSpan = 1
        ta76.ColumnSpan = 1
        tamgmt.ColumnSpan = 1

        ta51.Text = "<font size=2><b>AREA&nbsp;NAME&nbsp;</b></font>"
        ta52.Text = "<font size=2><b>AS PER NORMS&nbsp;</b></font>"
        ta53.Text = "<font size=2><b>ACTUAL EMP&nbsp;</b></font>"
        ta54.Text = "<font size=2><b>OTHERS&nbsp;</b></font>"
        ta55.Text = "<font size=2><b>SWEEPER&nbsp;</b></font>"
        ta56.Text = "<font size=2><b>SHORT(JR)&nbsp;</b></font>"
        tajo.Text = "<font size=2><b>SHORT(JO)&nbsp;</b></font>"  '--New add
        ta57.Text = "<font size=2><b>SHORT(SW)&nbsp;</b></font>"
        ta58.Text = "<font size=2><b>SHORT(TOT)&nbsp;</b></font>"
        ta59.Text = "<font size=2><b>SURPLUS&nbsp;</b></font>"
        ta60.Text = "<font size=2><b>LONG LEAVE&nbsp;</b></font>"
        ta61.Text = "<font size=2><b>FLD(G) NORMS&nbsp;</b></font>"
        ta62.Text = "<font size=2><b>FLD(G)&nbsp;</b></font>"
        ta63.Text = "<font size=2><b>FLD(HP) NORMS&nbsp;</b></font>"
        ta64.Text = "<font size=2><b>FLD HP&nbsp;</b></font>"
        ta551.Text = "<font size=2><b>HP&nbspSTAFF Norms&nbsp;</b></font>"
        ta65.Text = "<font size=2><b>HP&nbspSTAFF Avble&nbsp;</b></font>"
        ta552.Text = "<font size=2><b>BLOAN PLOAN CHITS Norms&nbsp;</b></font>"
        ta66.Text = "<font size=2><b>BLOAN PLOAN CHITS Avble&nbsp;</b></font>"
        ta67.Text = "<font size=2><b>I/A&nbsp;</b></font>"
        ta67HWnorm68.Text = "<font size=2><b>H/W NORMS&nbsp;</b></font>"        'New added
        ta68.Text = "<font size=2><b>H/W ACTUAL&nbsp;</b></font>"
        ta69.Text = "<font size=2><b>LIFE INS&nbsp;</b></font>"
        ta70.Text = "<font size=2><b>GEN INS&nbsp;</b></font>"
        ta71.Text = "<font size=2><b>GL MKTING&nbsp;</b></font>"
        ta72.Text = "<font size=2><b>SHORT(AM)&nbsp;</b></font>"
        ta73.Text = "<font size=2><b>RELSHIP&nbsp;</b></font>"
        ta74.Text = "<font size=2><b>HON. DIR&nbsp;</b></font>"
        ta75.Text = "<font size=2><b>REG. DIR&nbsp;</b></font>"
        ta76.Text = "<font size=2><b>CORP. TRAINER&nbsp;</b></font>"
        tamgmt.Text = "<font size=2><b>MGMT TRAINEE(G)&nbsp;</b></font>"


        ta51.HorizontalAlign = HorizontalAlign.Left
        ta52.HorizontalAlign = HorizontalAlign.Left
        ta53.HorizontalAlign = HorizontalAlign.Left
        ta54.HorizontalAlign = HorizontalAlign.Left
        ta55.HorizontalAlign = HorizontalAlign.Left
        ta56.HorizontalAlign = HorizontalAlign.Left
        ta57.HorizontalAlign = HorizontalAlign.Left
        ta58.HorizontalAlign = HorizontalAlign.Left
        ta59.HorizontalAlign = HorizontalAlign.Left
        ta60.HorizontalAlign = HorizontalAlign.Left
        ta61.HorizontalAlign = HorizontalAlign.Left
        ta62.HorizontalAlign = HorizontalAlign.Left
        ta63.HorizontalAlign = HorizontalAlign.Left
        ta64.HorizontalAlign = HorizontalAlign.Left
        ta551.HorizontalAlign = HorizontalAlign.Left
        ta552.HorizontalAlign = HorizontalAlign.Left
        ta65.HorizontalAlign = HorizontalAlign.Left
        ta66.HorizontalAlign = HorizontalAlign.Left
        ta67.HorizontalAlign = HorizontalAlign.Left
        ta68.HorizontalAlign = HorizontalAlign.Left
        ta69.HorizontalAlign = HorizontalAlign.Left
        ta70.HorizontalAlign = HorizontalAlign.Left
        ta71.HorizontalAlign = HorizontalAlign.Left
        ta72.HorizontalAlign = HorizontalAlign.Left
        ta73.HorizontalAlign = HorizontalAlign.Left
        ta74.HorizontalAlign = HorizontalAlign.Left
        ta75.HorizontalAlign = HorizontalAlign.Left
        ta76.HorizontalAlign = HorizontalAlign.Left
        tajo.HorizontalAlign = HorizontalAlign.Left
        ta67HWnorm68.HorizontalAlign = HorizontalAlign.Left
        tamgmt.HorizontalAlign = HorizontalAlign.Left



        ta5.Controls.Add(ta51)
        ta5.Controls.Add(ta52)
        ta5.Controls.Add(ta53)
        ta5.Controls.Add(ta54)
        ta5.Controls.Add(ta55)
        ta5.Controls.Add(ta56)
        ta5.Controls.Add(tajo)     '---------------new
        ta5.Controls.Add(ta57)
        ta5.Controls.Add(ta58)
        ta5.Controls.Add(ta59)
        ta5.Controls.Add(ta60)
        ta5.Controls.Add(ta61)
        ta5.Controls.Add(ta62)
        ta5.Controls.Add(ta63)
        ta5.Controls.Add(ta64)
        ta5.Controls.Add(ta551)
        ta5.Controls.Add(ta65)
        ta5.Controls.Add(ta552)
        ta5.Controls.Add(ta66)
        ta5.Controls.Add(ta67)
        ta5.Controls.Add(ta67HWnorm68)   ' New
        ta5.Controls.Add(ta68)
        ta5.Controls.Add(ta69)
        ta5.Controls.Add(ta70)
        ta5.Controls.Add(ta71)
        ta5.Controls.Add(ta72)
        ta5.Controls.Add(ta73)
        ta5.Controls.Add(ta74)
        ta5.Controls.Add(ta75)
        ta5.Controls.Add(ta76)
        ta5.Controls.Add(tamgmt)

        tab.Controls.Add(ta5)

        Dim lin21012 As New TableRow
        Dim lin210112 As New TableCell
        lin210112.ColumnSpan = 31
        lin210112.Text = "<hr align=center width=100% >"
        lin21012.Controls.Add(lin210112)
        tab.Controls.Add(lin21012)

        Dim dt As New DataTable
        Dim sql As String = Nothing
        Dim dr As DataRow

        Dim cn1 As Integer = 0
        Dim cn2 As Integer = 0
        Dim cn3 As Integer = 0
        Dim cn4 As Integer = 0
        Dim cn5 As Integer = 0
        Dim cn6 As Integer = 0
        Dim cn7 As Integer = 0
        Dim cn8 As Integer = 0
        Dim cn9 As Integer = 0
        Dim cn10 As Integer = 0
        Dim cn11 As Integer = 0
        Dim cn12 As Integer = 0
        Dim cn13 As Integer = 0
        Dim cn14 As Integer = 0
        Dim cn15 As Integer = 0
        Dim cn16 As Integer = 0
        Dim cn17 As Integer = 0
        Dim cn18 As Integer = 0
        Dim cn19 As Integer = 0
        Dim cn20 As Integer = 0
        Dim cn21 As Integer = 0
        Dim cn22 As Integer = 0
        Dim cn23 As Integer = 0
        Dim cn24 As Integer = 0
        Dim cn25 As Integer = 0
        Dim cnjo As Integer = 0     '-------new
        Dim cnhwnorms As Integer = 0 '-------new
        Dim cnmgmt As Integer = 0 '-------new


        '        sql = "select d.area_id,zm.area_name,nvl(sum(st.sr_bh+st.bh+st.abh+st.jr_asst+st.sweeper),0) as actual_norms,nvl(sum(st.sr_bh_avbl+st.sweeper_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl),0)as actual_position,nvl(sum(st.sr_bh_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl),0)as actual_others,nvl(sum(st.sweeper_avbl),0) as actual_sweeper,sum(st.long_leave),sum(CASE when ST.JR_ASST-st.jr_asst_avbl<0 then 0 else st.jr_asst-st.jr_asst_avbl end) as short_JS,sum(case when st.sweeper-st.sweeper_avbl<0 then 0 else st.sweeper-st.sweeper_avbl end) as short_sw  from staff_required st,branch_master br,zonal_detail a,region_detail b,division_detail c,area_detail d,area_master zm where st.branch_id=br.branch_id and br.branch_id <>0 and   a.region_id=b.region_id and b.division_id = c.div_id and c.area_id = d.area_id and d.branch_id = br.branch_id and c.div_id=" & Request.QueryString.Get("dvid") & " and zm.area_id=d.area_id group by d.area_id,zm.area_name order by d.area_id"


        ' sql = "select d.area_id,zm.area_name,nvl(sum(st.sr_bh+st.bh+st.abh+st.jr_asst+st.sweeper),0) as actual_norms,nvl(sum(st.sr_bh_avbl+st.sweeper_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl),0)as actual_position,nvl(sum(st.sr_bh_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl),0)as actual_others,nvl(sum(st.sweeper_avbl),0) as actual_sweeper,nvl(sum(st.long_leave),0),nvl(sum(CASE when ST.JR_ASST-st.jr_asst_avbl<0 then 0 else st.jr_asst-st.jr_asst_avbl end),0) as short_JS,nvl(sum(case when st.sweeper-st.sweeper_avbl<0 then 0 else st.sweeper-st.sweeper_avbl end),0) as short_sw,nvl(sum(case when(st.sr_bh+st.bh+st.abh+st.jr_asst+st.sweeper-(st.sr_bh_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.sweeper_avbl))<0 then 0 else (st.sr_bh+st.bh+st.abh+st.jr_asst+st.sweeper-(st.sr_bh_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.sweeper_avbl)) end),0) as short_tot,nvl(sum(case when (st.sr_bh_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.sweeper_avbl-st.sr_bh-st.bh-st.abh-st.jr_asst-st.sweeper)<0 then 0 else(st.sr_bh_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.sweeper_avbl-st.sr_bh-st.bh-st.abh-st.jr_asst-st.sweeper) end),0) as surplus,nvl(sum(st.fldstaff_gold),0),nvl(sum(st.fldstaff_gold_avbl),0),nvl(sum(st.fldstaff_hp),0),nvl(sum(st.fldstaff_hp_avbl),0),nvl(sum(st.hp_other),0),nvl(sum(st.bpc),0),nvl(sum(st.auditors),0),nvl(sum(st.hardware),0),nvl(sum(st.life_ins),0),nvl(sum(general_ins),0),nvl(sum(gl_marketing),0),decode(zm.area_head_id,0,1,0) from staff_required st,branch_master br,zonal_detail a,region_detail b,division_detail c,area_detail d,area_master zm where st.branch_id=br.branch_id and br.branch_id <>0 and   a.region_id=b.region_id and b.division_id = c.div_id and c.area_id = d.area_id and d.branch_id = br.branch_id and c.div_id=" & Request.QueryString.Get("dvid") & " and zm.area_id=d.area_id group by d.area_id,zm.area_name,zm.area_head_id order by d.area_id"
        '                 0               1                                                       2                                                                                          3                                                                                 4                                          5                                     6                                                                                                       7                                                                                         8                                                                                                              9                                                                                                                                                                                                                                                                                                                                                                                                 10                                                                                                                                                                                                                                                                                                                                                                                           11                12                              13                               14                               15                           16                  17                       18                   19                      20                       21                       22                                 23                    24                    25                      26                    27                           28  
        sql = "select d.area_id,zm.area_name,nvl(sum(st.bh+st.abh+st.jr_asst+st.sweeper+st.jo),0) as actual_norms,nvl(sum(st.sweeper_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.jo_avbl),0)as actual_position,nvl(sum(st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.jo_avbl),0)as actual_others,nvl(sum(st.sweeper_avbl),0) as actual_sweeper,nvl(sum(st.long_leave),0),nvl(sum(CASE when ST.JR_ASST-st.jr_asst_avbl<0 then 0 else st.jr_asst-st.jr_asst_avbl end),0) as short_JRASST,nvl(sum(CASE when st.Jo-st.jo_avbl<0 then 0 else st.Jo-st.jo_avbl end),0) as short_JROFFCER,nvl(sum(case when st.sweeper-st.sweeper_avbl<0 then 0 else st.sweeper-st.sweeper_avbl end),0) as short_sweeper,nvl(sum(case when(st.bh-st.bh_avbl)>0 then st.bh-st.bh_avbl else 0 end+case when(st.abh-st.abh_avbl)>0 then st.abh-st.abh_avbl else 0 end+case when(st.jr_asst-st.jr_asst_avbl)>0 then st.jr_asst-st.jr_asst_avbl else 0 end+case when(st.sweeper-st.sweeper_avbl)>0 then st.sweeper-st.sweeper_avbl else 0 end+case when(st.jo-st.jo_avbl)>0 then st.jo-st.jo_avbl else 0 end),0) as tot_short,sum(case when(st.bh_avbl-st.bh)>0 then st.bh_avbl-st.bh else 0 end+case when(st.abh_avbl-st.abh)>0 then st.abh_avbl-st.abh else 0 end+case when(st.jr_asst_avbl-st.jr_asst)>0 then st.jr_asst_avbl-st.jr_asst else 0 end+case when(st.sweeper_avbl-st.sweeper)>0 then st.sweeper_avbl-st.sweeper else 0 end+case when(st.jo_avbl-st.jo)>0 then st.jo_avbl-st.jo else 0 end) as surplus,nvl(sum(st.fldstaff_gold),0),nvl(sum(st.fldstaff_gold_avbl),0),nvl(sum(st.fldstaff_loan),0),nvl(sum(st.fldstaff_loan_avbl),0),nvl(sum(st.hp_other),0),nvl(sum(st.bpc),0),nvl(sum(st.auditors),0),nvl(sum(st.hardware),0),nvl(sum(st.life_ins),0),nvl(sum(general_ins),0),nvl(sum(gl_marketing),0),decode(zm.area_head_id,0,1,0),nvl(sum(st.rel_officer),0),nvl(sum(st.hon_dir),0),nvl(sum(st.reg_dir),0),nvl(sum(st.corp_tnr),0),nvl(sum(st.mng_trainee),0) from staff_required st,branch_master br,zonal_detail a,region_detail b,division_detail c,area_detail d,area_master zm where st.branch_id=br.branch_id and br.branch_id <>0 and   a.region_id=b.region_id and b.division_id = c.div_id and c.area_id = d.area_id and d.branch_id = br.branch_id and c.div_id=" & Request.QueryString.Get("dvid") & " and zm.area_id=d.area_id group by d.area_id,zm.area_name,zm.area_head_id order by d.area_id"
        Dim oh As New Helper.Oracle.OracleHelper
        dt = oh.ExecuteDataSet(sql).Tables(0)
        For Each dr In dt.Rows

            '--------------hardware norms-----------------------
            Dim hw1 As Integer = oh.ExecuteDataSet("select ceil(count(*)/10) from branch_master where branch_id in(select b.branch_id from branch_detail b where b.area_id=" & dr(0) & ")").Tables(0).Rows(0)(0)
            '--------------hardware norms completed-----------!!!!!!!!!

            Dim lm5 As New TableRow
            lm5.Width = 31
            Dim lm51, lm52, lm53, celjunof, celhwnms, lm54, lm55, lm56, lm57, lm58, lm59, lm60, lm61, lm62, lm63, lm64, lm65, lm66, lm67, lm68, lm69, lm70, lm71, lm72, lm73, lm74, lm75, lm76, lm77, lm78, lmmgmt As New TableCell
            lm51.ColumnSpan = 1
            lm51.HorizontalAlign = HorizontalAlign.Left
            lm51.Text = "<font size=2><a href=javascript:openwin(" & dr(0) & ")>" & dr(1) & "</a></font>"
            lm5.Controls.Add(lm51)


            lm52.ColumnSpan = 1
            lm52.HorizontalAlign = HorizontalAlign.Center
            lm52.Text = "<font size=2> " & dr(2) & "</font>"
            lm5.Controls.Add(lm52)
            cn1 += dr(2)

            lm53.ColumnSpan = 1
            lm53.HorizontalAlign = HorizontalAlign.Center
            lm53.Text = "<font size=2> " & dr(3) & "</font>"
            lm5.Controls.Add(lm53)
            cn2 += dr(3)

            lm54.ColumnSpan = 1
            lm54.HorizontalAlign = HorizontalAlign.Center
            lm54.Text = "<font size=2> " & dr(4) & "</font>"
            lm5.Controls.Add(lm54)
            cn3 += dr(4)

            lm55.ColumnSpan = 1
            lm55.HorizontalAlign = HorizontalAlign.Center
            lm55.Text = "<font size=2> " & dr(5) & "</font>"
            lm5.Controls.Add(lm55)
            cn4 += dr(5)

            lm56.ColumnSpan = 1
            lm56.HorizontalAlign = HorizontalAlign.Center
            If dr(7) > 0 Then
                lm56.Text = "<font size=2> " & dr(7) & "</font>"
                cn5 += dr(7)
            Else
                lm56.Text = "<font size=2> 0 </font>"
            End If
            lm5.Controls.Add(lm56)

            '-----Juior Officer---------------

            celjunof.ColumnSpan = 1
            celjunof.HorizontalAlign = HorizontalAlign.Center
            If dr(8) > 0 Then
                celjunof.Text = "<font size=2> " & dr(8) & "</font>"
                cnjo += dr(8)
            Else
                celjunof.Text = "<font size=2> 0 </font>"
            End If
            lm5.Controls.Add(celjunof)

            '-----------------------------------

            lm57.ColumnSpan = 1
            lm57.HorizontalAlign = HorizontalAlign.Center
            If dr(9) > 0 Then
                cn6 += dr(9)
                lm57.Text = "<font size=2> " & dr(9) & "</font>"
            Else
                lm57.Text = "<font size=2> 0 </font>"
            End If
            lm5.Controls.Add(lm57)

            lm58.ColumnSpan = 1
            lm58.HorizontalAlign = HorizontalAlign.Center
            lm58.Text = "<font size=2> " & dr(10) & "</font>"
            cn7 += dr(10)
            lm5.Controls.Add(lm58)


            lm59.ColumnSpan = 1
            lm59.HorizontalAlign = HorizontalAlign.Center
            lm59.Text = "<font size=2> " & dr(11) & "</font>"
            cn8 += dr(11)
            lm5.Controls.Add(lm59)

            lm60.ColumnSpan = 1
            lm60.HorizontalAlign = HorizontalAlign.Center
            lm60.Text = "<font size=2> " & dr(6) & "</font>"
            lm5.Controls.Add(lm60)
            cn9 += dr(6)

            lm61.ColumnSpan = 1
            lm61.HorizontalAlign = HorizontalAlign.Center
            lm61.Text = "<font size=2> " & dr(12) & "</font>"
            cn10 += dr(12)
            lm5.Controls.Add(lm61)


            lm62.ColumnSpan = 1
            lm62.HorizontalAlign = HorizontalAlign.Center
            lm62.Text = "<font size=2> " & dr(13) & "</font>"
            cn11 += dr(13)
            lm5.Controls.Add(lm62)

            lm63.ColumnSpan = 1
            lm63.HorizontalAlign = HorizontalAlign.Center
            lm63.Text = "<font size=2> " & dr(14) & "</font>"
            lm5.Controls.Add(lm63)
            cn12 += dr(14)


            lm64.ColumnSpan = 1
            lm64.HorizontalAlign = HorizontalAlign.Center
            lm64.Text = "<font size=2> " & dr(15) & "</font>"
            lm5.Controls.Add(lm64)
            cn13 += dr(15)

            lm65.ColumnSpan = 1
            lm65.HorizontalAlign = HorizontalAlign.Center
            lm65.Text = "<font size=2> " & dr(16) & "</font>"
            lm5.Controls.Add(lm65)
            cn14 += dr(16)

            lm66.ColumnSpan = 1
            lm66.HorizontalAlign = HorizontalAlign.Center
            lm66.Text = "<font size=2> " & dr(16) & "</font>"
            lm5.Controls.Add(lm66)

            lm67.ColumnSpan = 1
            lm67.HorizontalAlign = HorizontalAlign.Center
            lm67.Text = "<font size=2> " & dr(17) & "</font>"
            lm5.Controls.Add(lm67)
            cn15 += dr(17)

            lm68.ColumnSpan = 1
            lm68.HorizontalAlign = HorizontalAlign.Center
            lm68.Text = "<font size=2> " & dr(17) & "</font>"
            lm5.Controls.Add(lm68)

            lm69.ColumnSpan = 1
            lm69.HorizontalAlign = HorizontalAlign.Center
            lm69.Text = "<font size=2> " & dr(18) & "</font>"
            lm5.Controls.Add(lm69)
            cn16 += dr(18)

            '----hw norms

            celhwnms.ColumnSpan = 1
            celhwnms.HorizontalAlign = HorizontalAlign.Center
            celhwnms.Text = "<font size=2> " & hw1 & "</font>"
            lm5.Controls.Add(celhwnms)
            cnhwnorms += hw1

            '----------------------

            lm70.ColumnSpan = 1
            lm70.HorizontalAlign = HorizontalAlign.Center
            lm70.Text = "<font size=2> " & dr(19) & "</font>"
            lm5.Controls.Add(lm70)
            cn17 += dr(19)

            lm71.ColumnSpan = 1
            lm71.HorizontalAlign = HorizontalAlign.Center
            lm71.Text = "<font size=2> " & dr(20) & "</font>"
            lm5.Controls.Add(lm71)
            cn18 += dr(20)

            lm72.ColumnSpan = 1
            lm72.HorizontalAlign = HorizontalAlign.Center
            lm72.Text = "<font size=2> " & dr(21) & "</font>"
            cn19 += dr(21)
            lm5.Controls.Add(lm72)

            lm73.ColumnSpan = 1
            lm73.HorizontalAlign = HorizontalAlign.Center
            lm73.Text = "<font size=2> " & dr(22) & "</font>"
            lm5.Controls.Add(lm73)
            cn20 += dr(22)

            lm74.ColumnSpan = 1
            lm74.HorizontalAlign = HorizontalAlign.Center
            lm74.Text = "<font size=2> " & dr(23) & "</font>"
            cn21 += dr(23)
            lm5.Controls.Add(lm74)

            lm75.ColumnSpan = 1
            lm75.HorizontalAlign = HorizontalAlign.Center
            lm75.Text = "<font size=2> " & dr(24) & "</font>"
            cn22 += dr(24)
            lm5.Controls.Add(lm75)

            lm76.ColumnSpan = 1
            lm76.HorizontalAlign = HorizontalAlign.Center
            lm76.Text = "<font size=2> " & dr(25) & "</font>"
            cn23 += dr(25)
            lm5.Controls.Add(lm76)

            lm77.ColumnSpan = 1
            lm77.HorizontalAlign = HorizontalAlign.Center
            lm77.Text = "<font size=2> " & dr(26) & "</font>"
            cn24 += dr(26)
            lm5.Controls.Add(lm77)

            lm78.ColumnSpan = 1
            lm78.HorizontalAlign = HorizontalAlign.Center
            lm78.Text = "<font size=2> " & dr(27) & "</font>"
            cn25 += dr(27)
            lm5.Controls.Add(lm78)

            lmmgmt.ColumnSpan = 1
            lmmgmt.HorizontalAlign = HorizontalAlign.Center
            lmmgmt.Text = "<font size=2> " & dr(28) & "</font>"
            lm5.Controls.Add(lmmgmt)
            cnmgmt += dr(28)

            tab.Controls.Add(lm5)

        Next

        Dim lin22 As New TableRow
        Dim lin221 As New TableCell
        lin221.ColumnSpan = 31
        lin221.Text = "<hr align=center width=100% >"
        lin22.Controls.Add(lin221)
        tab.Controls.Add(lin22)


        Dim t5 As New TableRow
        Dim tt1, ttjo, tthwnms, tt2, tt3, tt4, tt5, tt6, tt7, tt8, tt9, tt10, tt11, tt12, tt13, tt14, tt15, tt16, tt17, tt18, tt19, tt20, tt21, tt22, tt23, tt24, tt25, tt26, tt27, tt28, ttmgmt As New TableCell

        tt1.ColumnSpan = 1
        tt1.HorizontalAlign = HorizontalAlign.Left
        tt1.Text = "<font size=2>Total</font>"
        t5.Controls.Add(tt1)


        tt2.ColumnSpan = 1
        tt2.HorizontalAlign = HorizontalAlign.Center
        tt2.Text = "<font size=2> " & cn1 & "</font>"
        t5.Controls.Add(tt2)

        tt3.ColumnSpan = 1
        tt3.HorizontalAlign = HorizontalAlign.Center
        tt3.Text = "<font size=2> " & cn2 & "</font>"
        t5.Controls.Add(tt3)

        tt4.ColumnSpan = 1
        tt4.HorizontalAlign = HorizontalAlign.Center
        tt4.Text = "<font size=2> " & cn3 & "</font>"
        t5.Controls.Add(tt4)

        tt5.ColumnSpan = 1
        tt5.HorizontalAlign = HorizontalAlign.Center
        tt5.Text = "<font size=2> " & cn4 & "</font>"
        t5.Controls.Add(tt5)

        tt6.ColumnSpan = 1
        tt6.HorizontalAlign = HorizontalAlign.Center
        tt6.Text = "<font size=2> " & cn5 & "</font>"
        t5.Controls.Add(tt6)

        '-jo
        ttjo.ColumnSpan = 1
        ttjo.HorizontalAlign = HorizontalAlign.Center
        ttjo.Text = "<font size=2> " & cnjo & "</font>"
        t5.Controls.Add(ttjo)

        '-----------------


        tt7.ColumnSpan = 1
        tt7.HorizontalAlign = HorizontalAlign.Center
        tt7.Text = "<font size=2> " & cn6 & "</font>"
        t5.Controls.Add(tt7)

        tt8.ColumnSpan = 1
        tt8.HorizontalAlign = HorizontalAlign.Center
        tt8.Text = "<font size=2> " & cn7 & "</font>"
        t5.Controls.Add(tt8)

        tt9.ColumnSpan = 1
        tt9.HorizontalAlign = HorizontalAlign.Center
        tt9.Text = "<font size=2> " & cn8 & "</font>"
        t5.Controls.Add(tt9)

        tt10.ColumnSpan = 1
        tt10.HorizontalAlign = HorizontalAlign.Center
        tt10.Text = "<font size=2> " & cn9 & "</font>"
        t5.Controls.Add(tt10)

        tt11.ColumnSpan = 1
        tt11.HorizontalAlign = HorizontalAlign.Center
        tt11.Text = "<font size=2> " & cn10 & "</font>"
        t5.Controls.Add(tt11)

        tt12.ColumnSpan = 1
        tt12.HorizontalAlign = HorizontalAlign.Center
        tt12.Text = "<font size=2> " & cn11 & "</font>"
        t5.Controls.Add(tt12)

        tt13.ColumnSpan = 1
        tt13.HorizontalAlign = HorizontalAlign.Center
        tt13.Text = "<font size=2> " & cn12 & "</font>"
        t5.Controls.Add(tt13)

        tt14.ColumnSpan = 1
        tt14.HorizontalAlign = HorizontalAlign.Center
        tt14.Text = "<font size=2> " & cn13 & "</font>"
        t5.Controls.Add(tt14)

        tt15.ColumnSpan = 1
        tt15.HorizontalAlign = HorizontalAlign.Center
        tt15.Text = "<font size=2> " & cn14 & "</font>"
        t5.Controls.Add(tt15)

        tt16.ColumnSpan = 1
        tt16.HorizontalAlign = HorizontalAlign.Center
        tt16.Text = "<font size=2> " & cn14 & "</font>"
        t5.Controls.Add(tt16)

        tt17.ColumnSpan = 1
        tt17.HorizontalAlign = HorizontalAlign.Center
        tt17.Text = "<font size=2> " & cn15 & "</font>"
        t5.Controls.Add(tt17)

        tt18.ColumnSpan = 1
        tt18.HorizontalAlign = HorizontalAlign.Center
        tt18.Text = "<font size=2> " & cn15 & "</font>"
        t5.Controls.Add(tt18)

        tt19.ColumnSpan = 1
        tt19.HorizontalAlign = HorizontalAlign.Center
        tt19.Text = "<font size=2> " & cn16 & "</font>"
        t5.Controls.Add(tt19)

        '-----------------new Hardware norms
        tthwnms.ColumnSpan = 1
        tthwnms.HorizontalAlign = HorizontalAlign.Center
        tthwnms.Text = "<font size=2> " & cnhwnorms & "</font>"
        t5.Controls.Add(tthwnms)

        tt20.ColumnSpan = 1
        tt20.HorizontalAlign = HorizontalAlign.Center
        tt20.Text = "<font size=2> " & cn17 & "</font>"
        t5.Controls.Add(tt20)

        tt21.ColumnSpan = 1
        tt21.HorizontalAlign = HorizontalAlign.Center
        tt21.Text = "<font size=2> " & cn18 & "</font>"
        t5.Controls.Add(tt21)

        tt22.ColumnSpan = 1
        tt22.HorizontalAlign = HorizontalAlign.Center
        tt22.Text = "<font size=2> " & cn19 & "</font>"
        t5.Controls.Add(tt22)

        tt23.ColumnSpan = 1
        tt23.HorizontalAlign = HorizontalAlign.Center
        tt23.Text = "<font size=2> " & cn20 & "</font>"
        t5.Controls.Add(tt23)

        tt24.ColumnSpan = 1
        tt24.HorizontalAlign = HorizontalAlign.Center
        tt24.Text = "<font size=2> " & cn21 & "</font>"
        t5.Controls.Add(tt24)


        tt25.ColumnSpan = 1
        tt25.HorizontalAlign = HorizontalAlign.Center
        tt25.Text = "<font size=2> " & cn22 & "</font>"
        t5.Controls.Add(tt25)


        tt26.ColumnSpan = 1
        tt26.HorizontalAlign = HorizontalAlign.Center
        tt26.Text = "<font size=2> " & cn23 & "</font>"
        t5.Controls.Add(tt26)

        tt27.ColumnSpan = 1
        tt27.HorizontalAlign = HorizontalAlign.Center
        tt27.Text = "<font size=2> " & cn24 & "</font>"
        t5.Controls.Add(tt27)


        tt28.ColumnSpan = 1
        tt28.HorizontalAlign = HorizontalAlign.Center
        tt28.Text = "<font size=2> " & cn25 & "</font>"
        t5.Controls.Add(tt28)

        ttmgmt.ColumnSpan = 1
        ttmgmt.HorizontalAlign = HorizontalAlign.Center
        ttmgmt.Text = "<font size=2> " & cnmgmt & "</font>"
        t5.Controls.Add(ttmgmt)


        tab.Controls.Add(t5)

      

        Me.Panel1.Controls.Add(tab)
    End Sub
End Class
