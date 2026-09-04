Imports System.Data
Imports System.Data.OracleClient
Partial Class employeesearch_location_rpt_empsearch_location_b6a002804583
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim str As String = ""

        If Me.Request.QueryString("rdb") = 1 Then
            If Me.Request.QueryString("gender") = 2 Then
                str = "select e.emp_code || ' - ' || upper(e.emp_name),initcap(ep.perm_add1),initcap(p1.post_office),initcap(d1.district_name),initcap(s1.state_name)|| ' - ' ||p1.pin_code,initcap(ep.pres_add1),initcap(p2.post_office),initcap(d2.district_name),initcap(s2.state_name)|| ' - ' ||p2.pin_code,d.designation,case when e.branch_id in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=e.branch_id) else (select branch_name from before_completion where old_id=e.branch_id) end as branch_name ,ep.sex,case when(ep.res_phone) is null then ep.cont_phone else ep.res_phone end  from employee_master e,designation_master d,employ_personal_dtl ep,post_master p1,district_master d1,state_master s1,post_master p2,district_master d2,state_master s2,employ_firm f where e.emp_code=ep.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.designation_id=d.designation_id and ep.perm_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id and ep.pres_pin=p2.sr_number and p2.district_id=d2.district_id and d2.state_id=s2.state_id and e.status_id=1 and s1.state_id=" & Me.Request.QueryString("state") & " order by e.emp_code"
            Else
                str = "select e.emp_code || ' - ' || upper(e.emp_name),initcap(ep.perm_add1),initcap(p1.post_office),initcap(d1.district_name),initcap(s1.state_name)|| ' - ' ||p1.pin_code,initcap(ep.pres_add1),initcap(p2.post_office),initcap(d2.district_name),initcap(s2.state_name)|| ' - ' ||p2.pin_code,d.designation,case when e.branch_id in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=e.branch_id) else (select branch_name from before_completion where old_id=e.branch_id) end as branch_name,ep.sex,case when(ep.res_phone) is null then ep.cont_phone else ep.res_phone end  from employee_master e,designation_master d,employ_personal_dtl ep,post_master p1,district_master d1,state_master s1,post_master p2,district_master d2,state_master s2,employ_firm f where e.emp_code=ep.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.designation_id=d.designation_id and ep.perm_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id and ep.pres_pin=p2.sr_number and p2.district_id=d2.district_id and d2.state_id=s2.state_id and e.status_id=1 and s1.state_id=" & Me.Request.QueryString("state") & " and ep.sex=" & Me.Request.QueryString("gender") & " order by e.emp_code"
            End If
        ElseIf Me.Request.QueryString("rdb") = 2 Then
            If Me.Request.QueryString("gender") = 2 Then
                str = "select e.emp_code || ' - ' || upper(e.emp_name),initcap(ep.perm_add1),initcap(p1.post_office),initcap(d1.district_name),initcap(s1.state_name)|| ' - ' ||p1.pin_code,initcap(ep.pres_add1),initcap(p2.post_office),initcap(d2.district_name),initcap(s2.state_name)|| ' - ' ||p2.pin_code,d.designation,case when e.branch_id in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=e.branch_id) else (select branch_name from before_completion where old_id=e.branch_id) end as branch_name,ep.sex,case when(ep.res_phone) is null then ep.cont_phone else ep.res_phone end  from employee_master e,designation_master d,employ_personal_dtl ep,post_master p1,district_master d1,state_master s1,post_master p2,district_master d2,state_master s2,employ_firm f where e.emp_code=ep.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.designation_id=d.designation_id and ep.perm_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id and ep.pres_pin=p2.sr_number and p2.district_id=d2.district_id and d2.state_id=s2.state_id and e.status_id=1 and d1.district_id=" & Me.Request.QueryString("district") & " order by e.emp_code"
            Else
                str = "select e.emp_code || ' - ' || upper(e.emp_name),initcap(ep.perm_add1),initcap(p1.post_office),initcap(d1.district_name),initcap(s1.state_name)|| ' - ' ||p1.pin_code,initcap(ep.pres_add1),initcap(p2.post_office),initcap(d2.district_name),initcap(s2.state_name)|| ' - ' ||p2.pin_code,d.designation,case when e.branch_id in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=e.branch_id) else (select branch_name from before_completion where old_id=e.branch_id) end as branch_name,ep.sex,case when(ep.res_phone) is null then ep.cont_phone else ep.res_phone end  from employee_master e,designation_master d,employ_personal_dtl ep,post_master p1,district_master d1,state_master s1,post_master p2,district_master d2,state_master s2,employ_firm f where e.emp_code=ep.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.designation_id=d.designation_id and ep.perm_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id and ep.pres_pin=p2.sr_number and p2.district_id=d2.district_id and d2.state_id=s2.state_id and e.status_id=1 and d1.district_id=" & Me.Request.QueryString("district") & "and ep.sex=" & Me.Request.QueryString("gender") & " order by e.emp_code"
            End If
        Else
            If Me.Request.QueryString("gender") = 2 Then
                str = "select e.emp_code || ' - ' || upper(e.emp_name),initcap(ep.perm_add1),initcap(p1.post_office),initcap(d1.district_name),initcap(s1.state_name)|| ' - ' ||p1.pin_code,initcap(ep.pres_add1),initcap(p2.post_office),initcap(d2.district_name),initcap(s2.state_name)|| ' - ' ||p2.pin_code,d.designation,case when e.branch_id in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=e.branch_id) else (select branch_name from before_completion where old_id=e.branch_id) end as branch_name,ep.sex,case when(ep.res_phone) is null then ep.cont_phone else ep.res_phone end  from employee_master e,designation_master d,employ_personal_dtl ep,post_master p1,district_master d1,state_master s1,post_master p2,district_master d2,state_master s2,employ_firm f where e.emp_code=ep.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.designation_id=d.designation_id and ep.perm_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id and ep.pres_pin=p2.sr_number and p2.district_id=d2.district_id and d2.state_id=s2.state_id and e.status_id=1 and p1.sr_number=" & Me.Request.QueryString("post") & " order by e.emp_code"
            Else
                str = "select e.emp_code || ' - ' || upper(e.emp_name),initcap(ep.perm_add1),initcap(p1.post_office),initcap(d1.district_name),initcap(s1.state_name)|| ' - ' ||p1.pin_code,initcap(ep.pres_add1),initcap(p2.post_office),initcap(d2.district_name),initcap(s2.state_name)|| ' - ' ||p2.pin_code,d.designation,case when e.branch_id in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=e.branch_id) else (select branch_name from before_completion where old_id=e.branch_id) end as branch_name,ep.sex,case when(ep.res_phone) is null then ep.cont_phone else ep.res_phone end  from employee_master e,designation_master d,employ_personal_dtl ep,post_master p1,district_master d1,state_master s1,post_master p2,district_master d2,state_master s2,employ_firm f where e.emp_code=ep.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.designation_id=d.designation_id and ep.perm_pin=p1.sr_number and p1.district_id=d1.district_id and d1.state_id=s1.state_id and ep.pres_pin=p2.sr_number and p2.district_id=d2.district_id and d2.state_id=s2.state_id and e.status_id=1 and p1.sr_number=" & Me.Request.QueryString("post") & "and ep.sex=" & Me.Request.QueryString("gender") & " order by e.emp_code"
            End If
        End If


        Dim dt As DataTable = oh.ExecuteDataSet(str).Tables(0)
        Try

            If dt.Rows.Count = 0 Then
                Dim script1 As New System.Text.StringBuilder
                script1.Append("        alert('No Records Found'); ")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
                'Me.Server.Transfer("empsearch_location.aspx")
                Exit Sub
            End If
            Dim tab1 As New Table
            tab1.Attributes.Add("width", "100%")
            Dim tabr1 As New TableRow
            tabr1.Width = 12
            tabr1.Attributes.Add("bgcolor", "gold")
            tabr1.Attributes.Add("bordercolor", "red")
            Dim tabc1 As New TableCell

            ' tabc1.Text = "<body align=center color=red><b><font size=4>" & Session("firm_name") & " </font></b></body>"
            tabc1.ColumnSpan = 12
            tabc1.ForeColor = Drawing.Color.Red
            tabr1.Controls.Add(tabc1)
            tab1.Controls.Add(tabr1)

            '2nd row
            Dim tabr2 As New TableRow
            tabr2.Width = 12
            tabr2.ForeColor = Drawing.Color.Maroon
            'cell declaration
            Dim tabc2 As New TableCell

            tabc2.Text = "<body align=center><b> EMPLOYEE SEARCH RESULT </b></body>"
            tabc2.ColumnSpan = 12
            tabr2.Controls.Add(tabc2)
            tab1.Controls.Add(tabr2)


            '3RD ROW
            Dim tabrr3 As New TableRow
            tabrr3.Width = 12
            tabrr3.Attributes.Add("bgcolor", "#ffcca3")

            'cell declaration
            Dim tabcc3 As New TableCell
            tabcc3.ForeColor = Drawing.Color.Maroon
            tabcc3.Attributes.Add("align", "left")
            tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
            tabcc3.ColumnSpan = 6
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
            tabcc4.ColumnSpan = 6
            tabrr3.Controls.Add(tabcc4)
            tab1.Controls.Add(tabrr3)

            Dim tabline As New TableRow
            tabline.Width = 12
            Dim tabcellline As New TableCell
            tabcellline.ColumnSpan = 12
            tabcellline.Text = "<hr>"
            tabline.Controls.Add(tabcellline)
            tab1.Controls.Add(tabline)

            '5th row

            Dim tabr5 As New TableRow
            tabr5.Width = 10
            tabr5.ForeColor = Drawing.Color.DarkSlateGray
            Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7 As New TableCell
            tabr5c1.ColumnSpan = 1
            tabr5c2.ColumnSpan = 2
            tabr5c3.ColumnSpan = 2
            tabr5c4.ColumnSpan = 2
            tabr5c5.ColumnSpan = 2
            tabr5c6.ColumnSpan = 2
            tabr5c7.ColumnSpan = 1

            tabr5c1.HorizontalAlign = HorizontalAlign.Center

            tabr5c7.HorizontalAlign = HorizontalAlign.Center

            tabr5c1.Text = "<font size=2.5><b>SI.NO</b></font>"
            tabr5c2.Text = "<font size=2.5><b>EMP NAME</b></font>"
            tabr5c3.Text = "<font size=2.5><b>PERM ADDRESS</b></font>"
            tabr5c4.Text = "<font size=2.5><b>PRES.ADDRESS</b></font>"
            tabr5c5.Text = "<font size=2.5><b>DESIGNATION</b></font>"
            tabr5c6.Text = "<font size=2.5><b>BRANCH</b></font>"
            tabr5c7.Text = "<font size=2.5><b>GENDER</b></font>"

            tabr5.Controls.Add(tabr5c1)
            tabr5.Controls.Add(tabr5c2)
            tabr5.Controls.Add(tabr5c3)
            tabr5.Controls.Add(tabr5c4)
            tabr5.Controls.Add(tabr5c5)
            tabr5.Controls.Add(tabr5c6)
            tabr5.Controls.Add(tabr5c7)

            tab1.Controls.Add(tabr5)

            '''''''''''''''''''''''''''''''''''''''
            Dim tabline1 As New TableRow
            tabline1.Width = 12
            Dim tabcellline1 As New TableCell
            tabcellline1.ColumnSpan = 12
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
                tabr6.Width = 12
                tabr6.Attributes.Add("bgcolor", COLORS)
                Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7 As New TableCell
                tabr6c1.ColumnSpan = 1
                tabr6c2.ColumnSpan = 2
                tabr6c3.ColumnSpan = 2
                tabr6c4.ColumnSpan = 2
                tabr6c5.ColumnSpan = 2
                tabr6c6.ColumnSpan = 2
                tabr6c7.ColumnSpan = 1

                tabr6c1.Attributes.Add("align", "center")
                tabr6c2.Attributes.Add("align", "left")
                tabr6c3.Attributes.Add("align", "left")
                tabr6c4.Attributes.Add("align", "left")
                tabr6c5.Attributes.Add("align", "left")
                tabr6c6.Attributes.Add("align", "left")
                tabr6c7.Attributes.Add("align", "center")


                tabr6c1.Text = "<font size=2>" & count & "&nbsp;&nbsp;</font>"
                tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                tabr6c3.Text = "<font size=2>" & dr(1) & " ,<br>" & dr(2) & " ,<br>" & dr(3) & " ,  " & dr(4) & "<br> PH: " & dr(12) & "</font>"
                tabr6c4.Text = "<font size=2>" & dr(5) & " ,<br>" & dr(6) & " ,<br>" & dr(7) & " , " & dr(8) & "&nbsp;</font>"
                tabr6c5.Text = "<font size=2>" & dr(9) & "&nbsp;</font>"
                tabr6c6.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
                If dr(11) = 0 Then
                    tabr6c7.Text = "<font size=2>FEMALE&nbsp;&nbsp;</font>"
                    femalest += 1
                Else
                    tabr6c7.Text = "<font size=2>MALE&nbsp;&nbsp;</font>"
                    malest += 1
                End If


                tabr6.Controls.Add(tabr6c1)
                tabr6.Controls.Add(tabr6c2)
                tabr6.Controls.Add(tabr6c3)
                tabr6.Controls.Add(tabr6c4)
                tabr6.Controls.Add(tabr6c5)
                tabr6.Controls.Add(tabr6c6)
                tabr6.Controls.Add(tabr6c7)

                tab1.Controls.Add(tabr6)

                Dim tabline23 As New TableRow
                tabline23.Width = 12
                Dim tabcellline233 As New TableCell
                tabcellline233.ColumnSpan = 12
                tabcellline233.Text = "<hr>"
                tabline23.Controls.Add(tabcellline233)
                tab1.Controls.Add(tabline23)
            Next
            Dim totrow As New TableRow
            totrow.ForeColor = Drawing.Color.Red
            Dim tot1, tot2, tot3, tot4, tot5, tot6 As New TableCell
            tot1.ColumnSpan = 3
            tot1.Text = "TOTAL : " & count
            totrow.Controls.Add(tot1)

            tot2.ColumnSpan = 1
            tot2.Text = ""
            totrow.Controls.Add(tot2)

            tot3.ColumnSpan = 3
            tot3.Text = "MALE : " & malest
            totrow.Controls.Add(tot3)

            tot4.ColumnSpan = 1
            tot4.Text = ""
            totrow.Controls.Add(tot4)

            tot5.ColumnSpan = 3
            tot5.Text = "FEMALE : " & femalest
            totrow.Controls.Add(tot5)

            tot6.ColumnSpan = 1
            tot6.Text = ""
            totrow.Controls.Add(tot6)

            tab1.Controls.Add(totrow)
            Me.Panel1.Controls.Add(tab1)

        Catch ex As Exception
        Finally
            dt.Dispose()
            oh.dispose()
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oh.dispose()
    End Sub
End Class
