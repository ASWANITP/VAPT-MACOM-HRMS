Imports System.Data
Imports System.Data.OracleClient
Partial Class staff_noms_staffnoms_rpt_21e1f8b57585
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim hwecode As Integer = 0
    Dim c2 As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As New DataTable
        
        'Dim Sql As String = "select br.branch_name,nvl((st.sr_bh+st.bh+st.abh+st.jr_asst+st.sweeper),0) as actual_norms,nvl((st.sr_bh_avbl+st.sweeper_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl),0)as actual_position,nvl((st.sr_bh_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl),0)as actual_others,nvl((st.sweeper_avbl),0) as actual_sweeper,(st.long_leave),st.branch_id,(case when (ST.JR_ASST-st.jr_asst_avbl)>0 then ST.JR_ASST-st.jr_asst_avbl else 0 end) as short_JS,(case when(st.sweeper-st.sweeper_avbl)>0 then st.sweeper-st.sweeper_avbl else 0 end) as short_sw,st.fldstaff_gold,st.fldstaff_gold_avbl,st.fldstaff_hp,st.fldstaff_hp_avbl,st.hp_other,st.bpc,st.auditors,st.hardware,st.life_ins,general_ins,(case when(st.sr_bh-st.sr_bh_avbl)>0 then st.sr_bh-st.sr_bh_avbl else 0 end+case when(st.bh-st.bh_avbl)>0 then st.bh-st.bh_avbl else 0 end+case when(st.abh-st.abh_avbl)>0 then st.abh-st.abh_avbl else 0 end+case when(st.jr_asst-st.jr_asst_avbl)>0 then st.jr_asst-st.jr_asst_avbl else 0 end+case when(st.sweeper-st.sweeper_avbl)>0 then st.sweeper-st.sweeper_avbl else 0 end) as tot_short,(case when(st.sr_bh_avbl-st.sr_bh)>0 then st.sr_bh_avbl-st.sr_bh else 0 end+case when(st.bh_avbl-st.bh)>0 then st.bh_avbl-st.bh else 0 end+case when(st.abh_avbl-st.abh)>0 then st.abh_avbl-st.abh else 0 end+case when(st.jr_asst_avbl-st.jr_asst)>0 then st.jr_asst_avbl-st.jr_asst else 0 end+case when(st.sweeper_avbl-st.sweeper)>0 then st.sweeper_avbl-st.sweeper else 0 end) as surplus,nvl(st.rel_officer,0),nvl(st.hon_dir,0),nvl(st.reg_dir,0),nvl(st.corp_tnr,0) from staff_required st,branch_master br,zonal_detail a,region_detail b,division_detail c,area_detail d where st.branch_id=br.branch_id and br.branch_id <>0 and   a.region_id=b.region_id and b.division_id = c.div_id and c.area_id = d.area_id and d.branch_id = br.branch_id and d.area_id=" & Request.QueryString.Get("arid") & " order by br.branch_id"

        '                                0                                     1 act norms                                                                                     2 act position                                                               3 actual others ok                          4 act sweepoer                 5 long leave    6 brid                                                    7 junr asst short                                                                    8 Sweeper Short                                                 9 fld stf gld        10 fld gold avbl      11 fld lon    12 fldlonavbl         13 hp other  14 bpc   15 audito  16 h/W    17 LI       18 gen ins                                                                                                                                                                                                                                                                                                                                                             19 Tot short                                                                                                                                                                                                                                                                                                                                                                                                20 surplus         21 reloffcer       22 hon dir           23 reg dir         24 corp triner        25 gl mkt new added                                   26 Jr off short                                           27 mgmttrainee 
        Dim Sql As String = "select br.branch_name,nvl((st.bh+st.abh+st.jr_asst+st.sweeper+st.jo),0) as actual_norms,nvl((st.sweeper_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.jo_avbl),0)as actual_position,nvl((st.bh_avbl+st.abh_avbl+st.jr_asst_avbl+st.jo_avbl),0)as actual_others,nvl(st.sweeper_avbl,0) as actual_sweeper,(st.long_leave),st.branch_id,(case when (ST.JR_ASST-st.jr_asst_avbl)>0 then ST.JR_ASST-st.jr_asst_avbl else 0 end) as short_JS,(case when(st.sweeper-st.sweeper_avbl)>0 then st.sweeper-st.sweeper_avbl else 0 end) as short_sw,st.fldstaff_gold,st.fldstaff_gold_avbl,st.fldstaff_loan,st.fldstaff_loan_avbl,st.hp_other,st.bpc,st.auditors,st.hardware,st.life_ins,general_ins,nvl((case when(st.bh-st.bh_avbl)>0 then st.bh-st.bh_avbl else 0 end+case when(st.abh-st.abh_avbl)>0 then st.abh-st.abh_avbl else 0 end+case when(st.jr_asst-st.jr_asst_avbl)>0 then st.jr_asst-st.jr_asst_avbl else 0 end+case when(st.sweeper-st.sweeper_avbl)>0 then st.sweeper-st.sweeper_avbl else 0 end+case when(st.jo-st.jo_avbl)>0 then st.jo-st.jo_avbl else 0 end),0) as tot_short,nvl((case when(st.bh_avbl-st.bh)>0 then st.bh_avbl-st.bh else 0 end+case when(st.abh_avbl-st.abh)>0 then st.abh_avbl-st.abh else 0 end+case when(st.jr_asst_avbl-st.jr_asst)>0 then st.jr_asst_avbl-st.jr_asst else 0 end+case when(st.sweeper_avbl-st.sweeper)>0 then st.sweeper_avbl-st.sweeper else 0 end+case when(st.jo_avbl-st.jo)>0 then st.jo_avbl-st.jo else 0 end),0) as surplus,nvl(st.rel_officer,0),nvl(st.hon_dir,0),nvl(st.reg_dir,0),nvl(st.corp_tnr,0),nvl(st.gl_marketing,0),nvl((CASE when st.Jo-st.jo_avbl<0 then 0 else st.Jo-st.jo_avbl end),0) as short_JROFFCER,nvl(st.mng_trainee,0)as MGMT_Trainee from staff_required st,branch_master br,zonal_detail a,region_detail b,division_detail c,area_detail d where st.branch_id=br.branch_id and br.branch_id <>0 and   a.region_id=b.region_id and b.division_id = c.div_id and c.area_id = d.area_id and d.branch_id = br.branch_id and d.area_id=" & Request.QueryString.Get("arid") & " order by br.branch_id"
        dt = oh.ExecuteDataSet(Sql).Tables(0)

        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        Dim tr1 As New TableRow
        tr1.Width = 55
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 55
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tab.Controls.Add(tr1)

        Dim tr2 As New TableRow
        tr2.Width = 55
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "100%")
        td21.ColumnSpan = 55
        td21.HorizontalAlign = HorizontalAlign.Center
        td21.Text = "<font size=2><b> " & Me.Session("branch_name") & " </b></font>"
        tr2.Controls.Add(td21)
        tab.Controls.Add(tr2)

        Dim trr As New TableRow
        trr.Width = 55
        Dim tdr1 As New TableCell
        tdr1.Attributes.Add("width", "100%")
        tdr1.ColumnSpan = 55
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.Text = "<font size=2><b> BRANCH WISE LIST </b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)

        Dim tr3 As New TableRow
        tr3.Width = 55
        Dim td31 As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 27
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 28
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
        tr3.Controls.Add(td32)
        tab.Controls.Add(tr3)

        Dim lin2101 As New TableRow
        lin2101.Width = 55
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 55
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)



        Dim tabh As New TableRow

        tabh.Width = 55
        Dim tabh1, tahjo, tabh2, tabh3, tabh4, tabh5, tabh6, tabh7, tabh8, tabh9, tabh10, tabh11, tabh12, tabh13, tabh14, tabh15, tabh16, tabh17, tabh18, ta67, ta68, ta69, ta70, ta71, ta72, ta73, ta74, tamgmt As New TableCell
        tabh1.HorizontalAlign = HorizontalAlign.Left
        tahjo.HorizontalAlign = HorizontalAlign.Left
        tabh2.HorizontalAlign = HorizontalAlign.Left
        tabh3.HorizontalAlign = HorizontalAlign.Left
        tabh4.HorizontalAlign = HorizontalAlign.Left
        tabh5.HorizontalAlign = HorizontalAlign.Left
        tabh6.HorizontalAlign = HorizontalAlign.Left
        tabh7.HorizontalAlign = HorizontalAlign.Left
        tabh8.HorizontalAlign = HorizontalAlign.Left
        tabh9.HorizontalAlign = HorizontalAlign.Left
        tabh10.HorizontalAlign = HorizontalAlign.Left
        tabh11.HorizontalAlign = HorizontalAlign.Left
        tabh12.HorizontalAlign = HorizontalAlign.Left
        tabh13.HorizontalAlign = HorizontalAlign.Left
        tabh14.HorizontalAlign = HorizontalAlign.Left
        tabh15.HorizontalAlign = HorizontalAlign.Left
        tabh16.HorizontalAlign = HorizontalAlign.Left
        tabh17.HorizontalAlign = HorizontalAlign.Left
        tabh18.HorizontalAlign = HorizontalAlign.Left
        ta67.HorizontalAlign = HorizontalAlign.Left
        ta68.HorizontalAlign = HorizontalAlign.Left
        ta69.HorizontalAlign = HorizontalAlign.Left
        ta70.HorizontalAlign = HorizontalAlign.Left
        ta71.HorizontalAlign = HorizontalAlign.Left
        ta72.HorizontalAlign = HorizontalAlign.Left
        ta73.HorizontalAlign = HorizontalAlign.Left
        ta74.HorizontalAlign = HorizontalAlign.Left

        tabh1.ColumnSpan = 2
        tahjo.ColumnSpan = 2
        tabh2.ColumnSpan = 2
        tabh3.ColumnSpan = 2
        tabh4.ColumnSpan = 2
        tabh5.ColumnSpan = 2
        tabh6.ColumnSpan = 2
        tabh7.ColumnSpan = 2
        tabh8.ColumnSpan = 2
        tabh9.ColumnSpan = 2
        tabh10.ColumnSpan = 2
        tabh11.ColumnSpan = 2
        tabh12.ColumnSpan = 2
        tabh13.ColumnSpan = 2
        tabh14.ColumnSpan = 2
        tabh15.ColumnSpan = 2
        tabh16.ColumnSpan = 2
        tabh17.ColumnSpan = 2
        tabh18.ColumnSpan = 2
        ta67.ColumnSpan = 2
        ta68.ColumnSpan = 2
        ta69.ColumnSpan = 2
        ta70.ColumnSpan = 2
        ta71.ColumnSpan = 2
        ta72.ColumnSpan = 2
        ta73.ColumnSpan = 2
        ta74.ColumnSpan = 2
        tamgmt.ColumnSpan = 1


        tabh1.Text = "<font size=2><B>BRANCH&nbsp;</B></font>"
        tabh2.Text = "<font size=2><B>AS PER NORMS&nbsp;</B></font>"
        tabh3.Text = "<font size=2><B>ACTUAL EMP&nbsp;</B></font>"
        tabh4.Text = "<font size=2><B>OTHERS&nbsp;</B></font>"
        tabh5.Text = "<font size=2><B>SWEEPER&nbsp;</B></font>"
        tabh6.Text = "<font size=2><B>SHORT(JR)&nbsp;</B></font>"
        tahjo.Text = "<font size=2><B>SHORT(JO)&nbsp;</B></font>"   ' New added
        tabh7.Text = "<font size=2><B>SHORT(SW)&nbsp;</B></font>"
        tabh8.Text = "<font size=2><B>SHORT(TOT)&nbsp;</B></font>"
        tabh9.Text = "<font size=2><B>SURPLUS&nbsp;</B></font>"
        tabh10.Text = "<font size=2><B>LONG LEAVE&nbsp;</B></font>"
        tabh11.Text = "<font size=2><B>FLD(G) NORMS&nbsp;</B></font>"
        tabh12.Text = "<font size=2><B>FLD(G)&nbsp;</B></font>"
        tabh13.Text = "<font size=2><B>FLD(LOAN) NORMS&nbsp;</B></font>"
        tabh14.Text = "<font size=2><B>FLD(LOAN)&nbsp;</B></font>"
        tabh15.Text = "<font size=2><B>HP&nbspSTAFF Norms&nbsp;</B></font>"
        tabh16.Text = "<font size=2><B>HP&nbspSTAFF Avble&nbsp;</font>"
        tabh17.Text = "<font size=2><B>BLOAN PLOAN CHITS Norms&nbsp;</B></font>"
        tabh18.Text = "<font size=2><B>BLOAN PLOAN CHITS Avble&nbsp;</B></font>"
        ta67.Text = "<font size=2><b>I/A&nbsp;</b></font>"
        ta68.Text = "<font size=2><b>H/W EMP&nbsp;CODE&nbsp;</b></font>"
        ta69.Text = "<font size=2><b>LIFE INS&nbsp;</b></font>"
        ta70.Text = "<font size=2><b>GEN INS&nbsp;</b></font>"
        ta71.Text = "<font size=2><b>RELSHIP OFFCRS&nbsp;</b></font>"
        ta72.Text = "<font size=2><b>HON. DIR&nbsp;</b></font>"
        ta73.Text = "<font size=2><b>REG. DIR&nbsp;</b></font>"
        ta74.Text = "<font size=2><b>CORP. TRAINER&nbsp;</b></font>"
        tamgmt.Text = "<font size=2><b>MGMT TRAINEE(G)&nbsp;</b></font>"

        tabh.Controls.Add(tabh1)
        tabh.Controls.Add(tabh2)
        tabh.Controls.Add(tabh3)
        tabh.Controls.Add(tabh4)
        tabh.Controls.Add(tabh5)
        tabh.Controls.Add(tabh6)
        tabh.Controls.Add(tahjo)
        tabh.Controls.Add(tabh7)
        tabh.Controls.Add(tabh8)
        tabh.Controls.Add(tabh9)
        tabh.Controls.Add(tabh10)
        tabh.Controls.Add(tabh11)
        tabh.Controls.Add(tabh12)
        tabh.Controls.Add(tabh13)
        tabh.Controls.Add(tabh14)
        tabh.Controls.Add(tabh15)
        tabh.Controls.Add(tabh16)
        tabh.Controls.Add(tabh17)
        tabh.Controls.Add(tabh18)
        tabh.Controls.Add(ta67)
        tabh.Controls.Add(ta68)
        tabh.Controls.Add(ta69)
        tabh.Controls.Add(ta70)
        tabh.Controls.Add(ta71)
        tabh.Controls.Add(ta72)
        tabh.Controls.Add(ta73)
        tabh.Controls.Add(ta74)
        tabh.Controls.Add(tamgmt)

        tab.Controls.Add(tabh)



        Dim tabrb1q As New TableRow
        tabrb1q.Width = 55
        Dim tabrb11 As New TableCell
        tabrb1q.Width = 55
        tabrb11.ColumnSpan = 55
        tabrb11.Text = "<hr>"
        tabrb1q.Controls.Add(tabrb11)
        tab.Controls.Add(tabrb1q)
        Dim c3, c4, c5, c6, c7, c8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, cjo, cmgmt As Integer

        c3 = c4 = c5 = c6 = c7 = c8 = C9 = C10 = C11 = C12 = C13 = C14 = C15 = C16 = C17 = C18 = C19 = C20 = C21 = C22 = C23 = C24 = cjo = cmgmt = 0

        Dim dr As DataRow
        For Each dr In dt.Rows

            Dim hwec As Integer = oh.ExecuteDataSet("select count(*) as HW from branch_list bl,employee_master em where bl.emp_code=em.emp_code and em.status_id=1 and bl.branch_id=" & dr(6)).Tables(0).Rows(0)(0)
            If hwec = 1 Then
                hwecode = oh.ExecuteDataSet("select bl.emp_code from branch_list bl where bl.branch_id=" & dr(6)).Tables(0).Rows(0)(0)
            Else
                hwecode = 0
            End If

            Dim tabr As New TableRow
            Dim tabrc1, tabrjo, tabrc2, tabrc3, tabrc4, tabrc5, tabrc6, tabrc7, tabrc8, tabrc9, tabrc10, tabrc11, tabrc12, tabrc13, tabrc14, tabrc15, tabrc16, tabrc17, tabrc18, tabrc19, tabrc20, tabrc21, tabrc22, tabrc23, tabrc24, tabrc25, tabrc26, tabmgmt As New TableCell
            tabr.Width = 55
            tabrc1.HorizontalAlign = HorizontalAlign.Left
            tabrjo.HorizontalAlign = HorizontalAlign.Center
            tabrc2.HorizontalAlign = HorizontalAlign.Center
            tabrc3.HorizontalAlign = HorizontalAlign.Center
            tabrc4.HorizontalAlign = HorizontalAlign.Center
            tabrc5.HorizontalAlign = HorizontalAlign.Center
            tabrc6.HorizontalAlign = HorizontalAlign.Center
            tabrc7.HorizontalAlign = HorizontalAlign.Center
            tabrc8.HorizontalAlign = HorizontalAlign.Center
            tabrc9.HorizontalAlign = HorizontalAlign.Center
            tabrc10.HorizontalAlign = HorizontalAlign.Center
            tabrc11.HorizontalAlign = HorizontalAlign.Center
            tabrc12.HorizontalAlign = HorizontalAlign.Center
            tabrc13.HorizontalAlign = HorizontalAlign.Center
            tabrc14.HorizontalAlign = HorizontalAlign.Center
            tabrc15.HorizontalAlign = HorizontalAlign.Center
            tabrc16.HorizontalAlign = HorizontalAlign.Center
            tabrc17.HorizontalAlign = HorizontalAlign.Center
            tabrc18.HorizontalAlign = HorizontalAlign.Center
            tabrc19.HorizontalAlign = HorizontalAlign.Center
            tabrc20.HorizontalAlign = HorizontalAlign.Center
            tabrc21.HorizontalAlign = HorizontalAlign.Center
            tabrc22.HorizontalAlign = HorizontalAlign.Center
            tabrc23.HorizontalAlign = HorizontalAlign.Center
            tabrc24.HorizontalAlign = HorizontalAlign.Center
            tabrc25.HorizontalAlign = HorizontalAlign.Center
            tabrc26.HorizontalAlign = HorizontalAlign.Center
            tabmgmt.HorizontalAlign = HorizontalAlign.Center

            tabrc1.ColumnSpan = 2
            tabrjo.ColumnSpan = 2
            tabrc2.ColumnSpan = 2
            tabrc3.ColumnSpan = 2
            tabrc4.ColumnSpan = 2
            tabrc5.ColumnSpan = 2
            tabrc6.ColumnSpan = 2
            tabrc7.ColumnSpan = 2
            tabrc8.ColumnSpan = 2
            tabrc9.ColumnSpan = 2
            tabrc10.ColumnSpan = 2
            tabrc11.ColumnSpan = 2
            tabrc12.ColumnSpan = 2
            tabrc13.ColumnSpan = 2
            tabrc14.ColumnSpan = 2
            tabrc15.ColumnSpan = 2
            tabrc16.ColumnSpan = 2
            tabrc17.ColumnSpan = 2
            tabrc18.ColumnSpan = 2
            tabrc19.ColumnSpan = 2
            tabrc20.ColumnSpan = 2
            tabrc21.ColumnSpan = 2
            tabrc22.ColumnSpan = 2
            tabrc23.ColumnSpan = 2
            tabrc24.ColumnSpan = 2
            tabrc25.ColumnSpan = 2
            tabrc26.ColumnSpan = 2
            tabmgmt.ColumnSpan = 1
            '               0                  1                                                                     2                                                                                      3                                                                           4                                             5              6                7                                      8                                     9                     10               11              12                 13     14
            'select br.branch_name,nvl((st.sr_bh+st.bh+st.abh+st.jr_asst+st.sweeper),0) as actual_norms,nvl((st.sr_bh_avbl+st.sweeper_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl),0)as actual_position,nvl((st.sr_bh_avbl+st.bh_avbl+st.abh_avbl+st.jr_asst_avbl),0)as actual_others,nvl((st.sweeper_avbl),0) as actual_sweeper,(st.long_leave),st.branch_id,(ST.JR_ASST-st.jr_asst_avbl) as short_JS,(st.sweeper-st.sweeper_avbl) as short_sw,st.fldstaff_gold,st.fldstaff_gold_avbl,st.fldstaff_hp,st.fldstaff_hp_avbl,st.hp_other,st.bpc from staff_required st,branch_master br,zonal_detail a,region_detail b,division_detail c,area_detail d where st.branch_id=br.branch_id and br.branch_id <>0 and   a.region_id=b.region_id and b.division_id = c.div_id and c.area_id = d.area_id and d.branch_id = br.branch_id and d.area_id=" & Request.QueryString.Get("arid") & " order by br.branch_id

            'Junior officer Short
            tabrjo.Text = "<font size=2>" & dr(26) & "</font>"
            cjo += dr(26)


            tabrc1.Text = "<font size=2>" & dr(0) & "</font>"
            tabrc2.Text = "<font size=2>" & dr(1) & "</font>"
            c2 += dr(1)   'Sum of Actual Norms
            tabrc3.Text = "<font size=2>" & dr(2) & "</font>"
            tabrc4.Text = "<font size=2>" & dr(3) & "</font>"
            tabrc5.Text = "<font size=2>" & dr(4) & "</font>"
            tabrc6.Text = "<font size=2>" & dr(7) & "</font>"   '7 junr asst short  
            c6 = c6 + dr(7)      '7 junr asst short   sum
            tabrc7.Text = "<font size=2>" & dr(8) & "</font>"    '8 Sweeper Short   
            c7 = c7 + dr(8)    '8 Sweeper Short   Sum

        
            If dr(19) > 0 Then     '19 Tot short                        dr(6)=branchid passing 
                tabrc8.Text = "<font size=2><a href=short.aspx?br_id=" & dr(6) & ">" & dr(19) & "</a></font>"
                c8 = c8 + dr(19)   ' Sum of Total Short
            Else
                tabrc8.Text = "<font size=2>0</font>"
            End If
            If dr(20) > 0 Then   'SUrplus                                dr(6)=branchid passing 
                tabrc9.Text = "<font size=2><a href=surplus.aspx?br_id=" & dr(6) & ">" & dr(20) & "</a></font>"
                C9 = C9 + dr(20)  'SUrplus sum
            Else
                tabrc9.Text = "<font size=2>0</font>"

            End If



            If dr(5) > 0 Then         'Long Leave                
                tabrc10.Text = "<font size=2><a href=normleave.aspx?br_id=" & dr(6) & ">" & dr(5) & "</a></font>"
            Else
                tabrc10.Text = "<font size=2>0</font>"
            End If

            tabrc11.Text = "<font size=2>" & dr(9) & "</font>"  '9 fld stf gld
            C11 += dr(9)       ' sum of 9 fld stf gld

            tabrc12.Text = "<font size=2>" & dr(10) & "</font>"
            C12 += dr(10)    '10 fld stf gld avbl

            tabrc13.Text = "<font size=2>" & dr(11) & "</font>"
            C13 += dr(11)    'fldstflon

            tabrc14.Text = "<font size=2>" & dr(12) & "</font>"
            C14 += dr(12)    ''fldstflon avbl 

            tabrc15.Text = "<font size=2>" & dr(13) & "</font>"   'HP other
            tabrc16.Text = "<font size=2>" & dr(13) & "</font>"    'HP other
            C15 += dr(13)
            tabrc17.Text = "<font size=2>" & dr(14) & "</font>"    'BPC
            tabrc18.Text = "<font size=2>" & dr(14) & "</font>"      'BPC
            C16 += dr(14)
            tabrc19.Text = "<font size=2>" & dr(15) & "</font>"   'Auditors
            C17 += dr(15)

            tabrc20.Text = "<font size=2>" & hwecode & "</font>"  'dr(16) not showing
            'If hwec <> 0 Then
            'C18 += 1
            'End If

            tabrc21.Text = "<font size=2>" & dr(17) & "</font>"  'Life Ins
            C19 += dr(17)
            tabrc22.Text = "<font size=2>" & dr(18) & "</font>"   'Gen Ins
            C20 += dr(18)
            tabrc23.Text = "<font size=2>" & dr(21) & "</font>"   'rel off
            C21 += dr(21)
            tabrc24.Text = "<font size=2>" & dr(22) & "</font>"   'honor
            C22 += dr(22)
            tabrc25.Text = "<font size=2>" & dr(23) & "</font>"   'reg off
            C23 += dr(23)
            tabrc26.Text = "<font size=2>" & dr(24) & "</font>"   'Corp tra
            C24 += dr(24)

            tabmgmt.Text = "<font size=2>" & dr(27) & "</font>"
            cmgmt += dr(27)

            tabr.Controls.Add(tabrc1)
            tabr.Controls.Add(tabrc2)
            tabr.Controls.Add(tabrc3)
            tabr.Controls.Add(tabrc4)
            tabr.Controls.Add(tabrc5)
            tabr.Controls.Add(tabrc6)
            tabr.Controls.Add(tabrjo)   ' New add
            tabr.Controls.Add(tabrc7)
            tabr.Controls.Add(tabrc8)
            tabr.Controls.Add(tabrc9)
            tabr.Controls.Add(tabrc10)
            tabr.Controls.Add(tabrc11)
            tabr.Controls.Add(tabrc12)
            tabr.Controls.Add(tabrc13)
            tabr.Controls.Add(tabrc14)
            tabr.Controls.Add(tabrc15)
            tabr.Controls.Add(tabrc16)
            tabr.Controls.Add(tabrc17)
            tabr.Controls.Add(tabrc18)
            tabr.Controls.Add(tabrc19)
            tabr.Controls.Add(tabrc20)
            tabr.Controls.Add(tabrc21)
            tabr.Controls.Add(tabrc22)
            tabr.Controls.Add(tabrc23)
            tabr.Controls.Add(tabrc24)
            tabr.Controls.Add(tabrc25)
            tabr.Controls.Add(tabrc26)
            tabr.Controls.Add(tabmgmt)

            tab.Controls.Add(tabr)


            c3 += dr(2)   ' Sum of Actual Position
            c4 += dr(3)   ' Actual Others
            c5 += dr(4)   ' Actual Sweeper
            If dr(5) > 0 Then
                C10 = C10 + dr(5)  'Long Leave sum
            End If
        Next

        Dim lin22 As New TableRow
        lin22.Width = 55
        Dim lin221 As New TableCell
        lin221.ColumnSpan = 55
        lin221.Text = "<hr align=center width=100% >"
        lin22.Controls.Add(lin221)
        tab.Controls.Add(lin22)

        Dim tabtot As New TableRow
        tabtot.Width = 55
        Dim tabt1, tabtjo, tabt2, tabt3, tabt4, tabt5, tabt6, tabt7, tabt8, tabt9, tabt10, tabt11, tabt12, tabt13, tabt14, tabt15, tabt16, tabt17, tabt18, tabt19, tabt20, tabt21, tabt22, tabt23, tabt24, tabt25, tabt26, lmgmt As New TableCell
        tabt1.ColumnSpan = 2
        tabtjo.ColumnSpan = 2  'new 
        tabt2.ColumnSpan = 2
        tabt3.ColumnSpan = 2
        tabt4.ColumnSpan = 2
        tabt5.ColumnSpan = 2
        tabt6.ColumnSpan = 2
        tabt7.ColumnSpan = 2
        tabt8.ColumnSpan = 2
        tabt9.ColumnSpan = 2
        tabt10.ColumnSpan = 2
        tabt11.ColumnSpan = 2
        tabt12.ColumnSpan = 2
        tabt13.ColumnSpan = 2
        tabt14.ColumnSpan = 2
        tabt15.ColumnSpan = 2
        tabt16.ColumnSpan = 2
        tabt17.ColumnSpan = 2
        tabt18.ColumnSpan = 2
        tabt19.ColumnSpan = 2
        tabt20.ColumnSpan = 2
        tabt21.ColumnSpan = 2
        tabt22.ColumnSpan = 2
        tabt23.ColumnSpan = 2
        tabt24.ColumnSpan = 2
        tabt25.ColumnSpan = 2
        tabt26.ColumnSpan = 2
        lmgmt.ColumnSpan = 2

        tabt1.HorizontalAlign = HorizontalAlign.Left
        tabt2.HorizontalAlign = HorizontalAlign.Center
        tabtjo.HorizontalAlign = HorizontalAlign.Center   'new
        tabt3.HorizontalAlign = HorizontalAlign.Center
        tabt4.HorizontalAlign = HorizontalAlign.Center
        tabt5.HorizontalAlign = HorizontalAlign.Center
        tabt6.HorizontalAlign = HorizontalAlign.Center
        tabt7.HorizontalAlign = HorizontalAlign.Center
        tabt8.HorizontalAlign = HorizontalAlign.Center
        tabt9.HorizontalAlign = HorizontalAlign.Center
        tabt10.HorizontalAlign = HorizontalAlign.Center
        tabt11.HorizontalAlign = HorizontalAlign.Center
        tabt12.HorizontalAlign = HorizontalAlign.Center
        tabt13.HorizontalAlign = HorizontalAlign.Center
        tabt14.HorizontalAlign = HorizontalAlign.Center
        tabt15.HorizontalAlign = HorizontalAlign.Center
        tabt16.HorizontalAlign = HorizontalAlign.Center
        tabt17.HorizontalAlign = HorizontalAlign.Center
        tabt18.HorizontalAlign = HorizontalAlign.Center
        tabt19.HorizontalAlign = HorizontalAlign.Center
        tabt20.HorizontalAlign = HorizontalAlign.Center
        tabt21.HorizontalAlign = HorizontalAlign.Center
        tabt22.HorizontalAlign = HorizontalAlign.Center
        tabt23.HorizontalAlign = HorizontalAlign.Center
        tabt24.HorizontalAlign = HorizontalAlign.Center
        tabt25.HorizontalAlign = HorizontalAlign.Center
        tabt26.HorizontalAlign = HorizontalAlign.Center
        lmgmt.HorizontalAlign = HorizontalAlign.Center

        tabt1.Text = "Total"
        tabt2.Text = c2
        tabt3.Text = c3
        tabt4.Text = c4
        tabt5.Text = c5
        tabt6.Text = c6
        tabt7.Text = c7
        tabt8.Text = c8
        tabt9.Text = C9
        tabt10.Text = C10
        tabt11.Text = C11
        tabt12.Text = C12
        tabt13.Text = C13
        tabt14.Text = C14
        tabt15.Text = C15
        tabt16.Text = C15
        tabt17.Text = C16
        tabt18.Text = C16
        tabt19.Text = C17
        ' tabt20.Text = C18
        tabt20.Text = "--"
        tabt21.Text = C19
        tabt22.Text = C20
        tabt23.Text = C21
        tabt24.Text = C22
        tabt25.Text = C23
        tabt26.Text = C24

        tabtjo.Text = cjo
        lmgmt.Text = cmgmt

        tabtot.Controls.Add(tabt1)
        tabtot.Controls.Add(tabt2)
        tabtot.Controls.Add(tabt3)
        tabtot.Controls.Add(tabt4)
        tabtot.Controls.Add(tabt5)
        tabtot.Controls.Add(tabt6)
        tabtot.Controls.Add(tabtjo)
        tabtot.Controls.Add(tabt7)
        tabtot.Controls.Add(tabt8)
        tabtot.Controls.Add(tabt9)
        tabtot.Controls.Add(tabt10)
        tabtot.Controls.Add(tabt11)
        tabtot.Controls.Add(tabt12)
        tabtot.Controls.Add(tabt13)
        tabtot.Controls.Add(tabt14)
        tabtot.Controls.Add(tabt15)
        tabtot.Controls.Add(tabt16)
        tabtot.Controls.Add(tabt17)
        tabtot.Controls.Add(tabt18)
        tabtot.Controls.Add(tabt19)
        tabtot.Controls.Add(tabt20)
        tabtot.Controls.Add(tabt21)
        tabtot.Controls.Add(tabt22)
        tabtot.Controls.Add(tabt23)
        tabtot.Controls.Add(tabt24)
        tabtot.Controls.Add(tabt25)
        tabtot.Controls.Add(tabt26)
        tabtot.Controls.Add(lmgmt)


        tab.Controls.Add(tabtot)
        Me.Panel1.Controls.Add(tab)
    End Sub
End Class
