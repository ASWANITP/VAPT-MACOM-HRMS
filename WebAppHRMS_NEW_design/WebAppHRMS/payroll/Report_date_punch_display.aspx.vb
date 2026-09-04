Imports System.Data
Imports System.Data.OracleClient
Partial Class Report_date_punch_display_9d69b99f5755
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("align", "left")
        tab.Attributes.Add("border", "0")

        Dim trr1 As New TableRow
        trr1.Width = 20
        Dim tdr11 As New TableCell
        tdr11.Attributes.Add("width", "100%")
        tdr11.Attributes.Add("bgcolor", "gold")
        tdr11.ColumnSpan = 20
        tdr11.HorizontalAlign = HorizontalAlign.Center
        tdr11.Text = "<font size=4><b> MANAPPURAM GROUP OF COMPANIES  </b></font>"
        trr1.Controls.Add(tdr11)
        tab.Controls.Add(trr1)

        Dim tr1 As New TableRow
        tr1.Width = 20
        Dim td11 As New TableCell
        td11.Attributes.Add("width", "100%")
        td11.ColumnSpan = 20
        td11.HorizontalAlign = HorizontalAlign.Center
        td11.Text = "<font size=4><b>" & Me.Session("firm_name") & "</b></font>"
        tr1.Controls.Add(td11)
        tab.Controls.Add(tr1)

        Dim tr2 As New TableRow
        tr2.Width = 20
        Dim td21 As New TableCell
        td21.Attributes.Add("width", "100%")
        td21.ColumnSpan = 20
        td21.HorizontalAlign = HorizontalAlign.Center
        td21.Text = "<font size=2><b> " & Me.Session("branch_name") & " </b></font>"
        tr2.Controls.Add(td21)
        tab.Controls.Add(tr2)


        Dim trr As New TableRow
        trr.Width = 20
        Dim tdr1 As New TableCell
        tdr1.Attributes.Add("width", "100%")
        tdr1.Attributes.Add("bgcolor", "lightblue")
        tdr1.ColumnSpan = 20
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.Text = "<font size=2><b> PUNCHING DETAILS ON REPORTING DATE  </b></font>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)

        Dim tr3 As New TableRow
        tr3.Width = 20
        Dim td31, td3m As New TableCell
        td31.Attributes.Add("width", "50%")
        td31.ColumnSpan = 3
        td3m.ColumnSpan = 14
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=2><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
        tr3.Controls.Add(td31)
        tr3.Controls.Add(td3m)
        Dim td32 As New TableCell
        td32.Attributes.Add("width", "50%")
        td32.ColumnSpan = 3
        td32.HorizontalAlign = HorizontalAlign.Right
        td32.Text = "<font size=2><b>Time :" & Format(Date.Now, "hh:mm:ss tt") & "</b></font>"
        tr3.Controls.Add(td32)
        tab.Controls.Add(tr3)

        'Dim lin2 As New TableRow
        'lin2.Width = 20
        'Dim lin22 As New TableCell
        'lin22.ColumnSpan = 20
        'lin22.Text = "<hr align=center width=100% >"
        'lin2.Controls.Add(lin22)
        'tab.Controls.Add(lin2)



        'Dim trr2 As New TableRow
        'trr2.Width = 20
        'Dim tdr2 As New TableCell
        'tdr2.Attributes.Add("width", "100%")
        'tdr2.Attributes.Add("bgcolor", "snow")
        'tdr2.ColumnSpan = 20
        'tdr2.HorizontalAlign = HorizontalAlign.Center
        'tdr2.Text = "<font size=3 color=red><b> DETAILS  </b></font>"
        'trr2.Controls.Add(tdr2)
        'tab.Controls.Add(trr2)

        Dim lin2101 As New TableRow
        lin2101.Width = 20
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 20
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)

        Dim ta5 As New TableRow
        Dim ta51, ta52, ta53, ta70, ta71, ta54, ta60, ta61, ta62, ta64, ta551, ta55, ta56, ta63 As New TableCell
        ta62.Attributes.Add("width", "5%")
        ta52.Attributes.Add("width", "5%")

        ta52.ColumnSpan = 1
        ta53.ColumnSpan = 2
        ta54.ColumnSpan = 2
        ta55.ColumnSpan = 2
        ' ta56.ColumnSpan = 2
        ta70.ColumnSpan = 1
        ta60.ColumnSpan = 2
        ta61.ColumnSpan = 2
        ta62.ColumnSpan = 2
        ta63.ColumnSpan = 2
        ta71.ColumnSpan = 4
        ta60.Text = "<font size=2><b>BRANCH&nbsp;</b></font>"
        ta52.Text = "<font size=2><b>CODE</b></font>"
        ta53.Text = "<font size=2><b>EMPLOY&nbsp;NAME</b></font>"
        ta54.Text = "<font size=2><b>&nbsp;POST&nbsp;</b></font>"
        ta70.Text = "<font size=2><b>REPORTING&nbsp;DATE&nbsp;</b></font>"
        ta61.Text = "<font size=2><b>MORNING&nbsp;TIME</b></font>"
        ta62.Text = "<font size=2><b>MORNING&nbsp;BRANCH</b></font>"
        ta63.Text = "<font size=2><b>EVENING&nbsp;TIME</b></font>"
        ta55.Text = "<font size=2><b>EVENING&nbsp;BRANCH</b></font>"
        ta71.Text = "<font size=2><b>&nbsp;&nbsp;&nbsp;STATUS&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
        'ta56.Text = "<font size=2><b>ABH&nbsp;NATIVE</b></font>"

        ta52.HorizontalAlign = HorizontalAlign.Left
        ta53.HorizontalAlign = HorizontalAlign.Center
        ta54.HorizontalAlign = HorizontalAlign.Center
        ta55.HorizontalAlign = HorizontalAlign.Center
        ta551.HorizontalAlign = HorizontalAlign.Center
        'ta56.HorizontalAlign = HorizontalAlign.Center
        ta70.HorizontalAlign = HorizontalAlign.Center
        ta71.HorizontalAlign = HorizontalAlign.Center
        ta60.HorizontalAlign = HorizontalAlign.Left
        ta61.HorizontalAlign = HorizontalAlign.Center
        ta62.HorizontalAlign = HorizontalAlign.Center
        ta63.HorizontalAlign = HorizontalAlign.Center



        ''
        ta5.Controls.Add(ta60)
        ta5.Controls.Add(ta52)
        ta5.Controls.Add(ta53)
        ta5.Controls.Add(ta54)
        ta5.Controls.Add(ta70)
        ta5.Controls.Add(ta61)
        ta5.Controls.Add(ta62)
        ta5.Controls.Add(ta63)
        ta5.Controls.Add(ta55)
        ta5.Controls.Add(ta71)
        ' ta5.Controls.Add(ta56)


        Dim colors As String
        colors = "#ffdjff"
        ta5.Attributes.Add("bgcolor", colors)
        tab.Controls.Add(ta5)

        If Request.QueryString("state") = 1 Then
            dt = oh.ExecuteDataSet("select b.branch_name,e.emp_code,e.emp_name,p.post_name,to_char(et.report_dt) as rp_dt,case when a.m_time is null then '----' else a.M_TIME end as m_time,case when a.M_TIME is null then '---' else b1.branch_name end as m_branch,case when a.E_TIME is null then '----' else a.E_TIME end as e_time,case when a.E_TIME is null then '---' else b2.branch_name end as e_branch,case when a.M_TIME is null and a.E_TIME is null and t.BRANCH_ID<>a.M_BRANCH or t.branch_id<>a.E_BRANCH then 'NOT&nbsp;REPORTED' else 'REPORTED' end as status  from employee_master e,employ_transfer_dtl et,post_mst p,attendance a,branch_master b,branch_master b1,branch_master b2,employ_transfer_dtl t where e.emp_code=et.emp_code and et.emp_code=t.emp_code and to_date(et.report_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "') and et.to_dt+1=t.from_dt and e.status_id=1 and e.emp_code=a.EMP_CODE and et.report_dt=a.CURR_DATE and b.branch_id=t.branch_id and b1.branch_id=a.M_BRANCH and b2.branch_id=a.E_BRANCH and p.post_id=t.post_id order by et.report_dt").Tables(0)
        End If
        If Request.QueryString("state") = 2 Then
            dt = oh.ExecuteDataSet("select b.branch_name,e.emp_code,e.emp_name,p.post_name,to_char(et.report_dt) as rp_dt,case when a.m_time is null then '----' else a.M_TIME end as m_time,case when a.M_TIME is null then '---' else b1.branch_name end as m_branch,case when a.E_TIME is null then '----' else a.E_TIME end as e_time,case when a.E_TIME is null then '---' else b2.branch_name end as e_branch,case when a.M_TIME is null and a.E_TIME is null and t.BRANCH_ID<>a.M_BRANCH or t.branch_id<>a.E_BRANCH then 'NOT&nbsp;REPORTED' else 'REPORTED' end as status  from employee_master e,employ_transfer_dtl et,post_mst p,attendance a,branch_master b,branch_master b1,branch_master b2,employ_transfer_dtl t where e.emp_code=et.emp_code and et.emp_code=t.emp_code and to_date(et.report_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "') and et.to_dt+1=t.from_dt and e.status_id=1 and e.emp_code=a.EMP_CODE and et.report_dt=a.CURR_DATE and b.branch_id=t.branch_id and b1.branch_id=a.M_BRANCH and b2.branch_id=a.E_BRANCH and t.post_id in (17,18,10,11,12,13,14,15,16,101,149,146,148,90) and p.post_id=t.post_id order by et.report_dt").Tables(0)
        End If
        If Request.QueryString("state") = 3 Then
            dt = oh.ExecuteDataSet("select b.branch_name,e.emp_code,e.emp_name,p.post_name,to_char(et.report_dt) as rp_dt,case when a.m_time is null then '----' else a.M_TIME end as m_time,case when a.M_TIME is null then '---' else b1.branch_name end as m_branch,case when a.E_TIME is null then '----' else a.E_TIME end as e_time,case when a.E_TIME is null then '---' else b2.branch_name end as e_branch,case when a.M_TIME is null and a.E_TIME is null and t.BRANCH_ID<>a.M_BRANCH or t.branch_id<>a.E_BRANCH then 'NOT&nbsp;REPORTED' else 'REPORTED' end as status  from employee_master e,employ_transfer_dtl et,post_mst p,attendance a,branch_master b,branch_master b1,branch_master b2,employ_transfer_dtl t where e.emp_code=et.emp_code and et.emp_code=t.emp_code and to_date(et.report_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "') and et.to_dt+1=t.from_dt and e.status_id=1 and e.emp_code=a.EMP_CODE and et.report_dt=a.CURR_DATE and b.branch_id=t.branch_id and b1.branch_id=a.M_BRANCH and b2.branch_id=a.E_BRANCH and t.post_id in (1,2,3,4,5,6,7,8,9) and p.post_id=t.post_id order by et.report_dt").Tables(0)
        End If

        Dim dr As DataRow

        Dim emp As Integer
        emp = 0



        For Each dr In dt.Rows

            If colors.Equals("#egf9ff") = True Then
                'colors = "#egf9ff"
                colors = "#EDDA74"
            Else
                colors = "#egf9ff"
                '  colors = "#ffffef"
            End If

            Dim lm5 As New TableRow
            lm5.Attributes.Add("bgcolor", colors)
            Dim lm49, lm61, lm62, lm51, lm52, lm53, lm54, lm60, sbh, bh, lm56, lm55, abh As New TableCell

            ''''''''''''''''''''''''''''''''''''''''''''''''
            lm51.ColumnSpan = 2
            lm51.HorizontalAlign = HorizontalAlign.Center


            ''''''''''''''''''''''''''''
            '
            lm51.ColumnSpan = 2
            lm51.HorizontalAlign = HorizontalAlign.Left
            lm51.Text = "<font size=2>" & dr(0) & "</font>"
            lm5.Controls.Add(lm51)



            lm52.ColumnSpan = 1
            lm52.HorizontalAlign = HorizontalAlign.Left
            lm52.Text = "<font size=2> " & dr(1) & " </font>"
            lm5.Controls.Add(lm52)
            emp = emp + 1

            lm53.ColumnSpan = 2
            lm53.HorizontalAlign = HorizontalAlign.Left
            lm53.Text = "<font size=2> " & dr(2) & "</font>"
            lm5.Controls.Add(lm53)

            lm61.ColumnSpan = 2
            lm61.HorizontalAlign = HorizontalAlign.Left
            lm61.Text = "<font size=2>" & dr(3) & "</font>"
            lm5.Controls.Add(lm61)


            lm54.ColumnSpan = 1
            lm54.HorizontalAlign = HorizontalAlign.Center

            lm54.Text = "<font size=2>" & dr(4) & "</font></a>"
            lm5.Controls.Add(lm54)

            ''''''''''''''''''''
            sbh.ColumnSpan = 2
            sbh.HorizontalAlign = HorizontalAlign.Center
            sbh.Text = "<font size=2>" & dr(5) & "</font>"
            lm5.Controls.Add(sbh)

            bh.ColumnSpan = 2
            bh.HorizontalAlign = HorizontalAlign.Center
            bh.Text = "<font size=2>" & dr(6) & "</font>"
            lm5.Controls.Add(bh)
            abh.ColumnSpan = 2
            abh.HorizontalAlign = HorizontalAlign.Center
            abh.Text = "<font size=2>" & dr(7) & "</font>"
            lm5.Controls.Add(abh)

            ''''''''''''''''''

            lm55.ColumnSpan = 2
            lm55.HorizontalAlign = HorizontalAlign.Center

            lm55.Text = "<font size=2> " & dr(8) & "</font>"
            lm5.Controls.Add(lm55)

            lm62.ColumnSpan = 4
            lm62.HorizontalAlign = HorizontalAlign.Left
            lm62.Text = "<font size=2> " & dr(9) & " </font>"
            lm5.Controls.Add(lm62)

            'lm56.ColumnSpan = 2
            'lm56.HorizontalAlign = HorizontalAlign.Center
            'lm56.Text = "<font size=2> " & dr(10) & "</font>"
            'lm5.Controls.Add(lm56)
            tab.Controls.Add(lm5)

        Next


        Dim li12 As New TableRow
        Dim li112 As New TableCell
        li112.ColumnSpan = 20
        li112.Text = "<hr align=center width=100% >"
        li12.Controls.Add(li112)
        tab.Controls.Add(li12)

        '''''''''''''''''''''''''''''''''''''''
        Dim llm5 As New TableRow
        llm5.Attributes.Add("bgcolor", "seashell")
        Dim llm49, llm51, llm52, llm53, llm54, llm60, lsbh, lbh, labh, llm55, llm56 As New TableCell


        ''''''''''''''''''''''''''''''''''''''''''''''''
        llm51.ColumnSpan = 2
        llm51.HorizontalAlign = HorizontalAlign.Left


        ''''''''''''''''''''''''''''
        '
        llm51.ColumnSpan = 2
        llm51.HorizontalAlign = HorizontalAlign.Left
        llm51.Text = "<font size=2></font>"
        llm5.Controls.Add(llm51)


        llm52.ColumnSpan = 2
        llm52.HorizontalAlign = HorizontalAlign.Left
        llm52.Text = "<font size=2>" & emp & "</font>"
        llm5.Controls.Add(llm52)

        llm53.ColumnSpan = 2
        llm53.HorizontalAlign = HorizontalAlign.Left
        llm53.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm53)


        llm54.ColumnSpan = 2
        llm54.HorizontalAlign = HorizontalAlign.Left

        llm54.Text = "<font size=2></font></a>"
        llm5.Controls.Add(llm54)
        ''''''''''''''''''''
        lsbh.ColumnSpan = 1
        lsbh.HorizontalAlign = HorizontalAlign.Center
        lsbh.Text = "<font size=2></font>"
        llm5.Controls.Add(lsbh)

        lbh.ColumnSpan = 2
        lbh.HorizontalAlign = HorizontalAlign.Center
        lbh.Text = "<font size=2></font>"
        llm5.Controls.Add(lbh)

        labh.ColumnSpan = 2
        labh.HorizontalAlign = HorizontalAlign.Center
        labh.Text = "<font size=2></font>"
        llm5.Controls.Add(labh)

        llm55.ColumnSpan = 1
        llm55.HorizontalAlign = HorizontalAlign.Center

        llm55.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm55)

        llm56.ColumnSpan = 2
        llm56.HorizontalAlign = HorizontalAlign.Center
        llm56.Text = "<font size=2> </font>"
        llm5.Controls.Add(llm56)
        tab.Controls.Add(llm5)

        '''''''''''''''''''''''''''''''''''''''''''''
        Dim lin21012 As New TableRow
        Dim lin210112 As New TableCell
        lin210112.ColumnSpan = 20
        lin210112.Text = "<hr align=center width=100% >"
        lin21012.Controls.Add(lin210112)
        tab.Controls.Add(lin21012)
        Dim lin21 As New TableRow
        Dim lin212 As New TableCell
        lin212.ColumnSpan = 20
        lin212.Text = "<a href=Report_date_punch.aspx><font color=blue>BACK</font ></a>"
        lin21.Controls.Add(lin212)
        tab.Controls.Add(lin21)
        Panel.Controls.Add(tab)
    End Sub
End Class
