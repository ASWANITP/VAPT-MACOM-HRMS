Imports System.Data
Imports System.Data.OracleClient
Partial Class employee_search_for_staff_welfare_rpt_empsearchwfd_bf35010d7808
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = ""
        Dim dat5 As Date = Me.Request.QueryString("dat")
        If Me.Request.QueryString("rdb") = 1 Then
            'date
            str = "select em.emp_code || ' - ' || em.emp_name,ep.perm_add1,pm1.post_office,d1.district_name,sm1.state_name,ep.pres_add1,pm2.post_office,d2.district_name,sm2.state_name,br.branch_name,dm.designation,dpt.dep_name,ep.birth_date,ep.cont_phone,ep.res_phone from employee_master em,employ_personal_dtl ep,branch_master br,designation_master dm,department_mst dpt,post_master pm1,post_master pm2,district_master d1,state_master sm1,district_master d2,state_master sm2 ,employ_firm ef where  ef.emp_code=em.emp_code and ef.firm_id= " & Session("firm_id") & " and em.emp_code=ep.emp_code and em.branch_id=br.branch_id and em.designation_id=dm.designation_id and em.department_id=dpt.dep_id and em.emp_code>9999 and em.status_id=1 and ep.perm_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.pres_pin=pm2.sr_number and pm2.district_id=d2.district_id and d2.state_id=sm2.state_id  and to_char(to_Date(ep.birth_date),'MM')=" & dat5.Month & " and to_char(to_Date(ep.birth_date),'DD')=" & dat5.Day & " union select em.emp_code || ' - ' || em.emp_name,ep.perm_add1,pm1.post_office,d1.district_name,sm1.state_name,ep.pres_add1,pm2.post_office,d2.district_name,sm2.state_name,bc.branch_name,dm.designation,dpt.dep_name,ep.birth_date,ep.cont_phone,ep.res_phone from employee_master em,employ_personal_dtl ep,before_completion bc,designation_master dm,department_mst dpt,post_master pm1,post_master pm2,district_master d1,state_master sm1,district_master d2,state_master sm2 ,employ_firm ef where  ef.emp_code=em.emp_code and ef.firm_id= " & Session("firm_id") & " and em.emp_code=ep.emp_code and em.branch_id=bc.old_id and bc.branch_id is null and em.designation_id=dm.designation_id and em.department_id=dpt.dep_id and em.emp_code>9999 and em.status_id=1 and ep.perm_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.pres_pin=pm2.sr_number and pm2.district_id=d2.district_id and d2.state_id=sm2.state_id and to_char(to_Date(ep.birth_date),'MM')=" & dat5.Month & "and to_char(to_Date(ep.birth_date),'DD')=" & dat5.Day
        Else
            str = "select em.emp_code || ' - ' || em.emp_name,ep.perm_add1,pm1.post_office,d1.district_name,sm1.state_name,ep.pres_add1,pm2.post_office,d2.district_name,sm2.state_name,br.branch_name,dm.designation,dpt.dep_name,ep.birth_date,ep.cont_phone,ep.res_phone,to_char(to_date(ep.birth_date),'DD') as dt from employee_master em,employ_personal_dtl ep,branch_master br,designation_master dm,department_mst dpt,post_master pm1,post_master pm2,district_master d1,state_master sm1,district_master d2,state_master sm2,employ_firm ef where  ef.emp_code=em.emp_code and ef.firm_id= " & Session("firm_id") & " and em.emp_code=ep.emp_code and em.branch_id=br.branch_id and em.designation_id=dm.designation_id and em.department_id=dpt.dep_id and em.emp_code>9999 and em.status_id=1 and ep.perm_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.pres_pin=pm2.sr_number and pm2.district_id=d2.district_id and d2.state_id=sm2.state_id  and to_char(to_Date(ep.birth_date),'MM')=" & Me.Request.QueryString("month") & " union select em.emp_code || ' - ' || em.emp_name,ep.perm_add1,pm1.post_office,d1.district_name,sm1.state_name,ep.pres_add1,pm2.post_office,d2.district_name,sm2.state_name,bc.branch_name,dm.designation,dpt.dep_name,ep.birth_date,ep.cont_phone,ep.res_phone,to_char(to_date(ep.birth_date),'DD') as dt from employee_master em,employ_personal_dtl ep,before_completion bc,designation_master dm,department_mst dpt,post_master pm1,post_master pm2,district_master d1,state_master sm1,district_master d2,state_master sm2 ,employ_firm ef where  ef.emp_code=em.emp_code and ef.firm_id= " & Session("firm_id") & " and em.emp_code=ep.emp_code and em.branch_id=bc.old_id and bc.branch_id is null and em.designation_id=dm.designation_id and em.department_id=dpt.dep_id and em.emp_code>9999 and em.status_id=1 and ep.perm_pin=pm1.sr_number and pm1.district_id=d1.district_id and d1.state_id=sm1.state_id and ep.pres_pin=pm2.sr_number and pm2.district_id=d2.district_id and d2.state_id=sm2.state_id and to_char(to_Date(ep.birth_date),'MM')=" & Me.Request.QueryString("month") & " order by dt"
        End If

        Dim dt As DataTable = oh.ExecuteDataSet(str).Tables(0)

        If dt.Rows.Count = 0 Then
            Dim cl_script01 As New System.Text.StringBuilder
            cl_script01.Append("         alert(' No Records Found');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script01.ToString, True)
            Response.Redirect("employee_search_swf.aspx")
            Exit Sub
        End If
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        Dim tabr1 As New TableRow
        tabr1.Width = 16
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        Dim tabc1 As New TableCell

        tabc1.Text = "<body align=center color=red><b><font size=4>" & Session("firm_name") & " </font></b></body>"
        tabc1.ColumnSpan = 16
        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 16
        tabr2.ForeColor = Drawing.Color.Maroon
        'cell declaration
        Dim tabc2 As New TableCell

        tabc2.Text = "<body align=center><b> EMPLOYEE SEARCH RESULT FOR SWF</b></body>"
        tabc2.ColumnSpan = 16
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)


        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 16
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ColumnSpan = 8
        tabrr3.Controls.Add(tabcc3)
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
        tabcc4.ColumnSpan = 8
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        Dim tabline As New TableRow
        tabline.Width = 16
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 16
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)

        '5th row

        Dim tabr5 As New TableRow
        tabr5.Width = 16
        tabr5.ForeColor = Drawing.Color.DarkSlateGray
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10 As New TableCell
        tabr5c1.ColumnSpan = 1
        tabr5c2.ColumnSpan = 2
        tabr5c3.ColumnSpan = 2
        tabr5c4.ColumnSpan = 2
        tabr5c5.ColumnSpan = 2
        tabr5c6.ColumnSpan = 2
        tabr5c7.ColumnSpan = 1
        tabr5c8.ColumnSpan = 1
        tabr5c9.ColumnSpan = 1
        tabr5c10.ColumnSpan = 2

        tabr5c1.HorizontalAlign = HorizontalAlign.Center

        tabr5c7.HorizontalAlign = HorizontalAlign.Center

        tabr5c1.Text = "<font size=2.5><b>SI.NO</b></font>"
        tabr5c2.Text = "<font size=2.5><b>EMP NAME</b></font>"
        tabr5c3.Text = "<font size=2.5><b>PERM ADDRESS</b></font>"
        tabr5c4.Text = "<font size=2.5><b>PRES.ADDRESS</b></font>"
        tabr5c5.Text = "<font size=2.5><b>DESIGNATION&nbsp;</b></font>"
        tabr5c6.Text = "<font size=2.5><b>DEPARTMENT</b></font>"
        tabr5c10.Text = "<font size=2.5><b>BRANCH</b></font>"

        tabr5c7.Text = "<font size=2.5><b>DATE OF BIRTH</b></font>"

        tabr5c8.Text = "<font size=2.5><b>CONTACT PH.</b></font>"
        tabr5c9.Text = "<font size=2.5><b>RESIDENCE PH.</b></font>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c10)
        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c8)
        tabr5.Controls.Add(tabr5c9)


        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 16
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 16
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)

        Dim COLORS As String

        '''''''''''''''''''''''''''''''''''''''''''
        'data
        COLORS = "#fff3ff"
        Dim dr As DataRow
        Dim count As Integer = 0
        Dim malest As Integer = 0
        Dim femalest As Integer = 0

        For Each dr In dt.Rows
            count += 1
            If COLORS.Equals("#fff3ff") = True Then
                COLORS = "#eef9ff"
            Else
                COLORS = "#fff3ff"
            End If

            Dim tabr6 As New TableRow
            tabr6.Width = 16
            tabr6.Attributes.Add("bgcolor", COLORS)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10 As New TableCell
            tabr6c1.ColumnSpan = 1
            tabr6c2.ColumnSpan = 2
            tabr6c3.ColumnSpan = 2
            tabr6c4.ColumnSpan = 2
            tabr6c5.ColumnSpan = 2
            tabr6c6.ColumnSpan = 2
            tabr6c7.ColumnSpan = 1
            tabr6c8.ColumnSpan = 1
            tabr6c9.ColumnSpan = 1
            tabr6c10.ColumnSpan = 2


            tabr6c1.Attributes.Add("align", "center")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "left")
            tabr6c5.Attributes.Add("align", "left")
            tabr6c6.Attributes.Add("align", "left")
            tabr6c7.Attributes.Add("align", "center")
            tabr6c8.Attributes.Add("align", "center")
            tabr6c9.Attributes.Add("align", "center")
            tabr6c10.Attributes.Add("align", "left")


            tabr6c1.Text = "<font size=2>" & count & "&nbsp;&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr(1) & " ,<br>" & dr(2) & " ,<br>" & dr(3) & " ,  " & dr(4) & "&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(5) & " ,<br>" & dr(6) & " ,<br>" & dr(7) & " , " & dr(8) & "&nbsp;</font>"
            tabr6c5.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
            tabr6c6.Text = "<font size=2>" & dr(11) & "&nbsp;</font>"
            tabr6c10.Text = "<font size=2>" & dr(9) & "&nbsp;</font>"

            tabr6c7.Text = "<font size=2>" & Format(dr(12), "dd/MMM/yyyy") & "&nbsp;</font>"

            If Not IsDBNull(dr(13)) Then
                tabr6c8.Text = "<font size=2>&nbsp;&nbsp;" & dr(13) & "&nbsp;</font>"
            Else
                tabr6c8.Text = " "
            End If

            If Not IsDBNull(dr(14)) Then
                tabr6c9.Text = "<font size=2>" & dr(14) & "&nbsp;</font>"
            Else
                tabr6c9.Text = " "
            End If


            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c10)
            tabr6.Controls.Add(tabr6c7)
            tabr6.Controls.Add(tabr6c8)
            tabr6.Controls.Add(tabr6c9)
            tab1.Controls.Add(tabr6)

            Dim tabline23 As New TableRow
            tabline23.Width = 16
            Dim tabcellline233 As New TableCell
            tabcellline233.ColumnSpan = 16
            tabcellline233.Text = "<hr>"
            tabline23.Controls.Add(tabcellline233)
            tab1.Controls.Add(tabline23)
        Next

        Me.Panel1.Controls.Add(tab1)




    End Sub
End Class
