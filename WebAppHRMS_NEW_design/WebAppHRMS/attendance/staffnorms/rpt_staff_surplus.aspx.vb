Imports System.Data
Imports System.Data.OracleClient
Partial Class surplus_report_rpt_staff_surplus_f03ca7109592
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        'Dim dt As DataTable = oh.ExecuteDataSet("select br.branch_name,case when(st.bh_avbl-st.bh)>0 then st.bh_avbl-st.bh else 0 end as bh_surplus,case when(st.abh_avbl-st.abh)>0 then st.abh_avbl-st.abh else 0 end as abh_surplus,case when(st.jr_asst_avbl-st.jr_asst)>0 then st.jr_asst_avbl-st.jr_asst else 0 end as jr_asst_surplus,case when(st.sweeper_avbl-st.sweeper)>0 then st.sweeper_avbl-st.sweeper else 0 end as sweeper_surplus,case when(st.jo_avbl-st.jo)>0 then st.jo_avbl-st.jo else 0 end as jo_surplus,sm.state_name from staff_required st,branch_master br,state_master sm where br.state_id=sm.state_id and st.branch_id=br.branch_id and ((st.bh_avbl>st.bh) or (st.abh_avbl>st.abh) or (st.jr_asst_avbl>st.jr_asst) or (st.sweeper_avbl>st.sweeper) or (st.jo_avbl>st.jo)) union select bc.branch_name,case when(st.bh_avbl-st.bh)>0 then st.bh_avbl-st.bh else 0 end as bh_surplus,case when(st.abh_avbl-st.abh)>0 then st.abh_avbl-st.abh else 0 end as abh_surplus,case when(st.jr_asst_avbl-st.jr_asst)>0 then st.jr_asst_avbl-st.jr_asst else 0 end as jr_asst_surplus,case when(st.sweeper_avbl-st.sweeper)>0 then st.sweeper_avbl-st.sweeper else 0 end as sweeper_surplus,case when(st.jo_avbl-st.jo)>0  then st.jo_avbl-st.jo else 0 end as jo_surplus,sm.state_name from state_master sm,staff_required st,before_completion bc where bc.state_id=sm.state_id and st.branch_id=bc.old_id and bc.branch_id is null and ((st.bh_avbl>st.bh) or (st.abh_avbl>st.abh) or (st.jr_asst_avbl>st.jr_asst) or (st.sweeper_avbl>st.sweeper) or (st.jo_avbl>st.jo)) order by state_name,branch_name").Tables(0)
        'new norms                                            0                                                                          1                                                                                     2                                                                                                                               3                                                                                                                                                                                                                                                                                                      4                  5
        Dim dt As DataTable = oh.ExecuteDataSet("select br.branch_name,case when(st.bh_avbl-st.bh)>0 then st.bh_avbl-st.bh else 0 end as bh_surplus,case when(st.abh_avbl-st.abh)>0 then st.abh_avbl-st.abh else 0 end as abh_surplus,case when (nvl(st.sweeper_avbl,0)-nvl(st.sweeper,0))>0 then (nvl(st.sweeper_avbl,0)-nvl(st.sweeper,0)) else 0 end as Sweeper_surplus,case when ((nvl(st.jr_asst_avbl,0)+nvl(st.jo_avbl,0)+nvl(st.mng_trainee,0)+nvl(st.asst_mgr_gold,0))-(nvl(st.jr_asst,0)+nvl(st.jo,0)))>0 then ((nvl(st.jr_asst_avbl,0)+nvl(st.jo_avbl,0)+nvl(st.mng_trainee,0)+nvl(st.asst_mgr_gold,0))-(nvl(st.jr_asst,0)+nvl(st.jo,0))) else 0 end as Other_Staff_surplus,sm.state_name from staff_required st,branch_master br,state_master sm where br.state_id=sm.state_id and st.branch_id=br.branch_id and  br.firm_id=" & Session("firm_id") & " and ((st.bh_avbl>st.bh) or (st.abh_avbl>st.abh) or (st.sweeper_avbl>st.sweeper) or (((nvl(st.jr_asst_avbl,0)+nvl(st.jo_avbl,0)+nvl(st.mng_trainee,0)+nvl(st.asst_mgr_gold,0))>(nvl(st.jr_asst,0)+nvl(st.jo,0))))) union select bc.branch_name,case when(st.bh_avbl-st.bh)>0 then st.bh_avbl-st.bh else 0 end as bh_surplus,case when(st.abh_avbl-st.abh)>0 then st.abh_avbl-st.abh else 0 end as abh_surplus,case when(st.sweeper_avbl-st.sweeper)>0 then st.sweeper_avbl-st.sweeper else 0 end as sweeper_surplus,case when ((nvl(st.jr_asst_avbl,0)+nvl(st.jo_avbl,0)+nvl(st.mng_trainee,0)+nvl(st.asst_mgr_gold,0))-(nvl(st.jr_asst,0)+nvl(st.jo,0)))>0 then ((nvl(st.jr_asst_avbl,0)+nvl(st.jo_avbl,0)+nvl(st.mng_trainee,0)+nvl(st.asst_mgr_gold,0))-(nvl(st.jr_asst,0)+nvl(st.jo,0))) else 0 end as Other_Staff_Short,sm.state_name from state_master sm,staff_required st,before_completion bc where bc.state_id=sm.state_id and st.branch_id=bc.old_id and bc.branch_id is null and bc.firm_id=" & Session("firm_id") & " and ((st.bh_avbl>st.bh) or (st.abh_avbl>st.abh) or (((nvl(st.jr_asst_avbl,0)+nvl(st.jo_avbl,0)+nvl(st.mng_trainee,0)+nvl(st.asst_mgr_gold,0))>(nvl(st.jr_asst,0)+nvl(st.jo,0))) or (st.sweeper_avbl>st.sweeper)))order by state_name,branch_name").Tables(0)
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        ' tab1.Attributes.Add("border", 1)
        Dim tabr1 As New TableRow
        tabr1.Width = 6
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        Dim tabc1 As New TableCell
        tabc1.HorizontalAlign = HorizontalAlign.Center
        tabc1.Text = "<body align=center color=red><b><font size=4>" & Session("firm_name") & " </font></b></body>"
        tabc1.ColumnSpan = 6
        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 6
        tabr2.ForeColor = Drawing.Color.Maroon
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.HorizontalAlign = HorizontalAlign.Center
        tabc2.Text = "<body align=center><b> BRANCH-SURPLUS REPORT  </b></body>"
        tabc2.ColumnSpan = 6
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)


        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 6
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ColumnSpan = 1
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)

        Dim tabccc As New TableCell
        tabccc.ForeColor = Drawing.Color.Maroon
        tabccc.Attributes.Add("align", "left")
        tabccc.Text = " "
        tabccc.ColumnSpan = 4
        tabrr3.Controls.Add(tabccc)
        tab1.Controls.Add(tabrr3)

        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ForeColor = Drawing.Color.Maroon

        tabcc4.Attributes.Add("align", "right")

        Dim dat As String
        Dim hr As Integer = Date.Now.Hour
        If hr > 12 Then
            dat = "PM"
        Else
            dat = "AM"
        End If
        If (hr = 0) Then
            hr = 12
        End If

        If (hr > 12) Then
            hr = hr - 12
        End If

        tabcc4.Text = "<b><font size=2.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
        tabcc4.ColumnSpan = 2
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        Dim tabline As New TableRow
        tabline.Width = 6
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 6
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)

        '5th row

        Dim tabr5 As New TableRow
        tabr5.Width = 6
        tabr5.ForeColor = Drawing.Color.DarkSlateGray
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6 As New TableCell
        tabr5c1.ColumnSpan = 1
        tabr5c2.ColumnSpan = 1
        tabr5c3.ColumnSpan = 1
        tabr5c4.ColumnSpan = 1
        tabr5c5.ColumnSpan = 1
        tabr5c6.ColumnSpan = 1


        tabr5c1.HorizontalAlign = HorizontalAlign.Center
        tabr5c3.HorizontalAlign = HorizontalAlign.Center
        tabr5c4.HorizontalAlign = HorizontalAlign.Center
        tabr5c5.HorizontalAlign = HorizontalAlign.Center
        tabr5c6.HorizontalAlign = HorizontalAlign.Center
        'tabr5c7.HorizontalAlign = HorizontalAlign.Center

        tabr5c1.Text = "<font size=2.5><b>SI.NO</b></font>"
        tabr5c2.Text = "<font size=2.5><b>BRANCH</b></font>"
        tabr5c3.Text = "<font size=2.5><b>BH</b></font>"
        tabr5c4.Text = "<font size=2.5><b>A.B.H</b></font>"
        tabr5c5.Text = "<font size=2.5><b>SWEEPER</b></font>"
        tabr5c6.Text = "<font size=2.5><b>OTHERS</b></font>"
        'tabr5c7.Text = "<font size=2.5><b>JR.OFFICER</b></font>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        'tabr5.Controls.Add(tabr5c7)

        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 6
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 6
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)

        Dim COLORS As String
        Dim tot1 As Integer = 0
        Dim tot2 As Integer = 0
        Dim tot3 As Integer = 0
        Dim tot4 As Integer = 0
        Dim tot5 As Integer = 0

        '''''''''''''''''''''''''''''''''''''''''''
        'data
        COLORS = "#fff3ff"
        Dim dr As DataRow
        Dim count As Integer = 0
        Dim state As String = ""
        For Each dr In dt.Rows
            If state <> dr(5) Then
                state = dr(5)
                Dim brrow As New TableRow
                brrow.Width = 6
                Dim brcell As New TableCell
                brcell.ColumnSpan = 6
                brcell.HorizontalAlign = HorizontalAlign.Center
                brcell.Text = "<font size=3>" & state & "</font>"
                brcell.ForeColor = Drawing.Color.Red
                brrow.BackColor = Drawing.Color.SkyBlue
                brrow.Controls.Add(brcell)
                tab1.Controls.Add(brrow)

            End If
            count += 1
            If COLORS.Equals("#fff3ff") = True Then
                COLORS = "#eef9ff"
            Else
                COLORS = "#fff3ff"
            End If

            Dim tabr6 As New TableRow
            tabr6.Width = 6
            tabr6.Attributes.Add("bgcolor", COLORS)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7 As New TableCell
            tabr6c1.ColumnSpan = 1
            tabr6c2.ColumnSpan = 1
            tabr6c3.ColumnSpan = 1
            tabr6c4.ColumnSpan = 1
            tabr6c5.ColumnSpan = 1
            tabr6c6.ColumnSpan = 1
            'tabr6c7.ColumnSpan = 1


            tabr6c1.Attributes.Add("align", "center")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "center")
            tabr6c4.Attributes.Add("align", "center")
            tabr6c5.Attributes.Add("align", "center")
            tabr6c6.Attributes.Add("align", "center")
            'tabr6c7.Attributes.Add("align", "center")

            tabr6c1.Text = "<font size=2>" & count & "&nbsp;&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;</font>"
            If dr(1) <> 0 Then
                tabr6c3.ForeColor = Drawing.Color.Red
                tabr6c3.Font.Bold = True
            End If
            If dr(2) <> 0 Then
                tabr6c4.ForeColor = Drawing.Color.Red
                tabr6c4.Font.Bold = True
            End If
            If dr(3) <> 0 Then
                tabr6c5.ForeColor = Drawing.Color.Red
                tabr6c5.Font.Bold = True
            End If
            If dr(4) <> 0 Then
                tabr6c6.ForeColor = Drawing.Color.Red
                tabr6c6.Font.Bold = True
            End If
            'If dr(5) <> 0 Then
            '    tabr6c7.ForeColor = Drawing.Color.Red
            '    tabr6c7.Font.Bold = True
            'End If
            tabr6c3.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;</font>"
            tot1 += dr(1)
            tabr6c4.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;</font>"
            tot2 += dr(2)
            tabr6c5.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;</font>"
            tot3 += dr(3)
            tabr6c6.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
            tot4 += dr(4)
            'tabr6c7.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
            'tot5 += dr(5)

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c7)

            tab1.Controls.Add(tabr6)


        Next
        Dim tabline23 As New TableRow
        tabline23.Width = 6
        Dim tabcellline233 As New TableCell
        tabcellline233.ColumnSpan = 6
        tabcellline233.Text = "<hr>"
        tabline23.Controls.Add(tabcellline233)
        tab1.Controls.Add(tabline23)

        Dim totrow As New TableRow
        totrow.Width = 6
        totrow.ForeColor = Drawing.Color.Red

        Dim t1, t2, t3, t4, t5, t6 As New TableCell
        t1.ColumnSpan = 2
        t2.ColumnSpan = 1
        t3.ColumnSpan = 1
        t4.ColumnSpan = 1
        t5.ColumnSpan = 1
        ' t6.ColumnSpan = 1

        t2.HorizontalAlign = HorizontalAlign.Center
        t3.HorizontalAlign = HorizontalAlign.Center
        t4.HorizontalAlign = HorizontalAlign.Center
        t5.HorizontalAlign = HorizontalAlign.Center
        't6.HorizontalAlign = HorizontalAlign.Center
        t1.Text = "<font size=2><b>TOTAL : </b></font>"
        t2.Text = "<font size=2><b>" & tot1 & " </b></font>"
        t3.Text = "<font size=2><b>" & tot2 & " </b></font>"
        t4.Text = "<font size=2><b>" & tot3 & " </b></font>"
        t5.Text = "<font size=2><b>" & tot4 & " </b></font>"
        't6.Text = "<font size=2><b>" & tot5 & " </b></font>"
        totrow.Controls.Add(t1)
        totrow.Controls.Add(t2)
        totrow.Controls.Add(t3)
        totrow.Controls.Add(t4)
        totrow.Controls.Add(t5)
        ' totrow.Controls.Add(t6)
        tab1.Controls.Add(totrow)

        Dim tabline23w As New TableRow
        tabline23w.Width = 6
        Dim tabcellline233w As New TableCell
        tabcellline233w.ColumnSpan = 6
        tabcellline233w.Text = "<hr>"
        tabline23w.Controls.Add(tabcellline233w)
        tab1.Controls.Add(tabline23w)

        Me.Panel1.Controls.Add(tab1)

    End Sub

   
End Class
