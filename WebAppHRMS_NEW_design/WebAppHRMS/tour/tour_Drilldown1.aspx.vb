Imports System.Data
Imports System.Data.OracleClient
Partial Class tour_Drilldown1_7b63df988861
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("align", "left")
        tab.Attributes.Add("border", "0")

        Dim trr1 As New TableRow
        trr1.Width = 15
        Dim tdr11 As New TableCell
        tdr11.Attributes.Add("width", "100%")
        tdr11.Attributes.Add("bgcolor", "gold")
        tdr11.ColumnSpan = 15
        tdr11.HorizontalAlign = HorizontalAlign.Center
        tdr11.Text = "<font size=4><b> MANAPPURAM GROUP OF COMPANIES  </b></font>"
        trr1.Controls.Add(tdr11)
        tab.Controls.Add(trr1)

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
        tdr1.Text = "<font size=3><b> TOUR DETAILS </b></font>"
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
        

        Dim ta5 As New TableRow
        Dim ta51, ta52, ta53, ta54, ta55, ta56, ta57, ta58, ta59, ta60, ta61, ta62, ta63, ta64, ta65, ta551, ta66, ta67 As New TableCell
        ta52.ColumnSpan = 5
        ta53.ColumnSpan = 5
        ta60.ColumnSpan = 5

        
        ta60.Text = "<font size=2><b>DEPARTMENT&nbsp;</b></font>"
        ta52.Text = "<font size=2><b>DEPARTMENT&nbsp;&nbsp;HEAD</b></font>"
        ta53.Text = "<font size=2><b>TOTAL&nbsp;&nbsp;TOUR</b></font>"

        ta52.HorizontalAlign = HorizontalAlign.Center
        ta53.HorizontalAlign = HorizontalAlign.Center
        ta60.HorizontalAlign = HorizontalAlign.Center

       



        ''
        ta5.Controls.Add(ta60)
        ta5.Controls.Add(ta52)
        ta5.Controls.Add(ta53)
       
        Dim colors As String
        colors = "#ffdjff"
        ta5.Attributes.Add("bgcolor", colors)
        tab.Controls.Add(ta5)

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim str As String
        '                  0           1            2           3         4        -----------------------------------5-----------------------------------------------------------           ---------------------------6---------------------------------------------------                     -----------------------------7------------------                         ------------------------------------------------------8  ----------------                                   ---9----------------------------------                                                                                                        ----10---------------------------------------------------------------------------------------------                                 ----------------------11-----------------------------------------------------------                          -----------------------12--------------------------------------     --------------------------------------------     ------------------13--------------------------------------------------------
        str = "select distinct d.dep_name,d.dep_id,d.dep_head||'-'||e.emp_name,count(d.dep_id) from department_mst d,hrm_tour_dtl t,employee_master e where d.dep_id=t.dep_id and d.dep_head=e.emp_code and t.branch_id=0 group by d.dep_name,d.dep_head,e.emp_name,d.dep_id"
        dt = oh.ExecuteDataSet(str).Tables(0)


        Dim br, norm, act As Integer
        br = 0
        norm = 0
        act = 0
        Dim frdt, todt As String
        frdt = Format(CDate(Request.QueryString("fdt")), "dd/MMM/yyyy")
        todt = Format(CDate(Request.QueryString("tdt")), "dd/MMM/yyyy")
        For Each dr In dt.Rows

            If colors.Equals("#ffffef") = True Then
                colors = "#egf9ff"
            Else
                colors = "#ffffef"
            End If

            Dim lm5 As New TableRow
            lm5.Attributes.Add("bgcolor", colors)
            Dim lm51, lm52, lm53 As New TableCell


            ''''''''''''''''''''''''''''''''''''''''''''''''
            lm51.ColumnSpan = 5
            lm51.HorizontalAlign = HorizontalAlign.Center


            ''''''''''''''''''''''''''''
            '
            lm51.HorizontalAlign = HorizontalAlign.Center
            'lm51.Text = "<a href=tour_ao_rpt1.aspx?dtl=" & dr(1) & "&dep=" & dr(0) & "&fromdt='" & frdt & "'&toodt='" & todt & "'><font size=2 color =blue> " & dr(0) & "&nbsp;</font>"
            lm51.Text = "<font size=2.5 ><a href = javascript:next(" & dr(1) & ",'" & frdt & "','" & todt & "')><b>" & dr(0) & "</b></a></font>"
            lm5.Controls.Add(lm51)



            lm52.ColumnSpan = 5
            lm52.HorizontalAlign = HorizontalAlign.Center
            lm52.Text = "<font size=2>" & dr(2) & "</font>"
            lm5.Controls.Add(lm52)

            lm53.ColumnSpan = 5
            lm53.HorizontalAlign = HorizontalAlign.Center
            lm53.Text = "<font size=2> " & dr(3) & "</font>"
            lm5.Controls.Add(lm53)

            norm = norm + dr(3)

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
        Dim llm51, llm52, llm53 As New TableCell


        ''''''''''''''''''''''''''''''''''''''''''''''''
        llm51.ColumnSpan = 5
        llm51.HorizontalAlign = HorizontalAlign.Center


        ''''''''''''''''''''''''''''
        '
        llm51.ColumnSpan = 5
        llm51.HorizontalAlign = HorizontalAlign.Center
        llm51.Text = ""
        llm5.Controls.Add(llm51)


        llm52.ColumnSpan = 5
        llm52.HorizontalAlign = HorizontalAlign.Center
        llm52.Text = "<font size=2>TOTAL&nbsp;TOUR</font>"
        llm5.Controls.Add(llm52)

        llm53.ColumnSpan = 5
        llm53.HorizontalAlign = HorizontalAlign.Center
        llm53.Text = "<font size=2> " & norm & "</font>"
        llm5.Controls.Add(llm53)

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
        lin212.Text = "<a href=Tour_Ao_report.aspx?><font color=blue>---BACK---</font ></a>"
        lin21.Controls.Add(lin212)
        tab.Controls.Add(lin21)
        PanelDrilldownshort.Controls.Add(tab)
    End Sub
End Class
