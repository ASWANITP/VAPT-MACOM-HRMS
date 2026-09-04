Imports System.Data
Imports System.Data.OracleClient
Partial Class employee_search_rpt_empserach_6b6db7e74774
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String
        If Me.Request.QueryString("rdb") = 1 Then
            'sql = "select distinct e.emp_code ||' - ' ||upper(e.emp_name),initcap(ep.pres_add1),initcap(post.post_office),initcap(d.district_name),initcap(s.state_name),post.pin_code,ep.res_phone,initcap(ep.landmark),upper(des.designation),case when e.branch_id in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=e.branch_id) else (select branch_name from before_completion bc where bc.old_id=e.branch_id) end as branch_name,initcap(case when e.status_id=1 then 'LIVE' else case when e.status_id=3 then 'RESIGNED' else case when e.status_id=4 then 'SUSPENDED' else case when e.status_id=6 then 'LONGLEAVE' else case when e.status_id=10 then 'MATERNITY' else case when e.status_id=5 and em.new_empcode is null then 'TERMINATED' else case when e.status_id=5 and em.new_empcode is not null then 'REGULARISED' end end end end end end end ) from employee_master e,employ_personal_dtl ep,post_master post,district_master d,state_master s,designation_master des,employee_master_dtl em where e.emp_code=ep.emp_code and e.emp_code=em.emp_code  and ep.pres_pin=post.sr_number and post.district_id=d.district_id and d.state_id=s.state_id and e.designation_id=des.designation_id and e.emp_code=" & Me.Request.QueryString("code")
            sql = "select distinct e.emp_code || ' - ' || upper(e.emp_name), initcap(ep.pres_add1), initcap(post.post_office),initcap(d.district_name), initcap(s.state_name), post.pin_code, ep.res_phone, initcap(ep.landmark), upper(des.designation),  case when e.branch_id in (select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id = e.branch_id) else (select branch_name from before_completion bc where bc.old_id = e.branch_id) end as branch_name, ep.father_name,ep.birth_date,decode(ep.id_proof,'1','PASSPORT','2','DRIVING LICENCE','3','VOTERID','4','RATION CARD','5','OTHERS'),ep.idproof_number,NVL(ep.cont_phone,'--'),qq.qualification,q.year_pass, initcap(case when e.status_id = 1 then 'LIVE'  else  case when e.status_id = 3 then 'RESIGNED' else case  when e.status_id = 4 then  'SUSPENDED'  else  case when e.status_id = 6 then 'LONGLEAVE'  else case when e.status_id = 10 then 'MATERNITY' else case  when e.status_id = 5 and em.new_empcode is null then 'TERMINATED' else case when e.status_id = 5 and em.new_empcode is not null then 'REGULARISED' end end end end end end end) from employee_master e, employ_personal_dtl ep, post_master post, district_master  d,state_master  s,designation_master  des, employee_master_dtl em, employ_qualification_dtl q, qualification_master  qq,employ_firm f where e.emp_code = ep.emp_code and e.emp_code = em.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & "  and ep.pres_pin = post.sr_number and q.qualification = qq.qualification_id and post.district_id = d.district_id and d.state_id = s.state_id and q.year_pass in  (select max(q1.year_pass) from employ_qualification_dtl q1 where q.emp_code=q1.emp_code) and e.emp_code=q.emp_code and e.designation_id = des.designation_id and e.emp_code =" & Me.Request.QueryString("code")
        Else
            'sql = "select distinct e.emp_code||' - ' ||upper(e.emp_name),initcap(ep.pres_add1),initcap(post.post_office),initcap(d.district_name),initcap(s.state_name),post.pin_code,ep.res_phone,initcap(ep.landmark),upper(des.designation),case when e.branch_id in(select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id=e.branch_id) else (select branch_name from before_completion bc where bc.old_id=e.branch_id) end as branch_name,initcap(case when e.status_id=1 then 'LIVE' else case when e.status_id=3 then 'RESIGNED' else case when e.status_id=4 then 'SUSPENDED' else case when e.status_id=6 then 'LONGLEAVE' else case when e.status_id=10 then 'MATERNITY' else case when e.status_id=5 and em.new_empcode is null then 'TERMINATED' else case when e.status_id=5 and em.new_empcode is not null then 'REGULARISED' end end end end end end end ) from employee_master e,employ_personal_dtl ep,post_master post,district_master d,state_master s,designation_master des,employee_master_dtl em  where e.emp_code=ep.emp_code and e.emp_code=em.emp_code  and ep.pres_pin=post.sr_number and post.district_id=d.district_id and d.state_id=s.state_id and e.designation_id=des.designation_id and (e.emp_name like upper('" & Me.Request.QueryString("name") & "%') or e.emp_name like '" & Me.Request.QueryString("name") & "%')"
            sql = "select distinct e.emp_code || ' - ' || upper(e.emp_name), initcap(ep.pres_add1),initcap(post.post_office), initcap(d.district_name), initcap(s.state_name), post.pin_code, ep.res_phone, initcap(ep.landmark), upper(des.designation), case  when e.branch_id in (select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id = e.branch_id)  else (select branch_name from before_completion bc where bc.old_id = e.branch_id) end as branch_name, ep.father_name, ep.birth_date, decode(ep.id_proof,  '1', 'PASSPORT', '2', 'DRIVING LICENCE', '3', 'VOTERID', '4', 'RATION CARD','5','OTHERS'), ep.idproof_number, ep.cont_phone, qq.qualification, q.year_pass, initcap(case when e.status_id = 1 then 'LIVE'  else  case when e.status_id = 3 then  'RESIGNED' else case when e.status_id = 4 then 'SUSPENDED'  else case when e.status_id = 6 then 'LONGLEAVE' else  case  when e.status_id = 10 then'MATERNITY' else case when e.status_id = 5 and em.new_empcode is null then 'TERMINATED' else  case  when e.status_id = 5 and em.new_empcode is not null then 'REGULARISED' end end end end end end end) from employee_master  e,employ_personal_dtl ep,post_master  post,district_master  d,state_master  s,designation_master  des,employee_master_dtl em,employ_qualification_dtl q,qualification_master     qq,employ_firm f where  e.emp_code = ep.emp_code and e.emp_code = em.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and ep.pres_pin = post.sr_number and q.qualification = qq.qualification_id and post.district_id = d.district_id and d.state_id = s.state_id and q.year_pass in (select max(q1.year_pass) from employ_qualification_dtl q1 where q.emp_code = q1.emp_code) and e.emp_code = q.emp_code and e.designation_id = des.designation_id and (e.emp_name like upper('" & Me.Request.QueryString("name") & "%') or e.emp_name like '" & Me.Request.QueryString("name") & "%')"
        End If
        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)

        Try

            Dim tab1 As New Table
            tab1.Attributes.Add("width", "160%")
            Dim tabr1 As New TableRow
            tabr1.Width = 20
            tabr1.Attributes.Add("bgcolor", "gold")
            tabr1.Attributes.Add("bordercolor", "red")
            Dim tabc1 As New TableCell

            tabc1.Text = "<body align=center color=red><b><font size=4>" & Session("firm_name") & " </font></b></body>"
            tabc1.ColumnSpan = 20
            tabc1.ForeColor = Drawing.Color.Red
            tabr1.Controls.Add(tabc1)
            tab1.Controls.Add(tabr1)

            '2nd row
            Dim tabr2 As New TableRow
            tabr2.Width = 20
            tabr2.ForeColor = Drawing.Color.Maroon
            'cell declaration
            Dim tabc2 As New TableCell

            tabc2.Text = "<body align=center><b> EMPLOYEE SEARCH RESULT </b></body>"
            tabc2.ColumnSpan = 20
            tabr2.Controls.Add(tabc2)
            tab1.Controls.Add(tabr2)


            '3RD ROW
            Dim tabrr3 As New TableRow
            tabrr3.Width = 20
            tabrr3.Attributes.Add("bgcolor", "#ffcca3")

            'cell declaration
            Dim tabcc3 As New TableCell
            tabcc3.ForeColor = Drawing.Color.Maroon
            tabcc3.Attributes.Add("align", "left")
            tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
            tabcc3.ColumnSpan = 7
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
            tabcc4.ColumnSpan = 14
            tabrr3.Controls.Add(tabcc4)
            tab1.Controls.Add(tabrr3)

            Dim tabline As New TableRow
            tabline.Width = 20
            Dim tabcellline As New TableCell
            tabcellline.ColumnSpan = 20
            tabcellline.Text = "<hr>"
            tabline.Controls.Add(tabcellline)
            tab1.Controls.Add(tabline)

            '5th row

            Dim tabr5 As New TableRow
            tabr5.Width = 20
            tabr5.ForeColor = Drawing.Color.DarkSlateGray
            Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11, tabr5c12, tabr5c13, tabr5c14 As New TableCell
            tabr5c1.ColumnSpan = 2
            tabr5c2.ColumnSpan = 2
            tabr5c3.ColumnSpan = 1
            tabr5c4.ColumnSpan = 2
            tabr5c5.ColumnSpan = 2
            tabr5c6.ColumnSpan = 2
            tabr5c7.ColumnSpan = 1
            tabr5c8.ColumnSpan = 1
            tabr5c9.ColumnSpan = 1
            tabr5c10.ColumnSpan = 1
            tabr5c11.ColumnSpan = 1
            tabr5c12.ColumnSpan = 1
            tabr5c13.ColumnSpan = 2
            tabr5c14.ColumnSpan = 1

            tabr5c3.HorizontalAlign = HorizontalAlign.Center

            tabr5c7.HorizontalAlign = HorizontalAlign.Center

            tabr5c1.Text = "<font size=2.5><b>EMP NAME</b></font>"
            tabr5c8.Text = "<font size=2.5><b>FATHER NAME</b></font>"
            tabr5c2.Text = "<font size=2.5><b>ADDRESS</b></font>"
            tabr5c3.Text = "<font size=2.5><b>PHONE</b></font>"
            tabr5c4.Text = "<font size=2.5><b>LANDMARK</b></font>"
            tabr5c5.Text = "<font size=2.5><b>DESIGNATION</b></font>"
            tabr5c6.Text = "<font size=2.5><b>BRANCH</b></font>"
            tabr5c9.Text = "<font size=2.5><b>D.O.B</b></font>"
            tabr5c10.Text = "<font size=2.5><b>ID PROOF</b></font>"
            tabr5c11.Text = "<font size=2.5><b>ID NUM</b></font>"
            tabr5c12.Text = "<font size=2.5><b>MOBILE</b></font>"
            tabr5c13.Text = "<font size=2.5><b>QUALIFY</b></font>"
            tabr5c14.Text = "<font size=2.5><b>YR OF PASS</b></font>"
            tabr5c7.Text = "<font size=2.5><b>STATUS</b></font>"

            tabr5.Controls.Add(tabr5c1)
            tabr5.Controls.Add(tabr5c2)
            tabr5.Controls.Add(tabr5c3)
            tabr5.Controls.Add(tabr5c4)
            tabr5.Controls.Add(tabr5c5)
            tabr5.Controls.Add(tabr5c6)
            tabr5.Controls.Add(tabr5c7)
            tabr5.Controls.Add(tabr5c8)
            tabr5.Controls.Add(tabr5c9)
            tabr5.Controls.Add(tabr5c10)
            tabr5.Controls.Add(tabr5c11)
            tabr5.Controls.Add(tabr5c12)
            tabr5.Controls.Add(tabr5c13)
            tabr5.Controls.Add(tabr5c14)

            tab1.Controls.Add(tabr5)

            '''''''''''''''''''''''''''''''''''''''
            Dim tabline1 As New TableRow
            tabline1.Width = 20
            Dim tabcellline1 As New TableCell
            tabcellline1.ColumnSpan = 20
            tabcellline1.Text = "<hr>"
            tabline1.Controls.Add(tabcellline1)
            tab1.Controls.Add(tabline1)

            Dim COLORS As String

            '''''''''''''''''''''''''''''''''''''''''''
            'data
            ' COLORS = "#fff3ff"
            Dim dr As DataRow
            For Each dr In dt.Rows
                'If COLORS.Equals("#fff3ff") = True Then
                '    COLORS = "#eef9ff"
                'Else
                '    COLORS = "#fff3ff"
                'End If


                Dim tabr6 As New TableRow
                tabr6.Width = 20
                ' tabr6.Attributes.Add("bgcolor", colors)
                Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11, tabr6c12, tabr6c13, tabr6c14 As New TableCell
                tabr6c1.ColumnSpan = 2
                tabr6c2.ColumnSpan = 2
                tabr6c3.ColumnSpan = 1
                tabr6c4.ColumnSpan = 2
                tabr6c5.ColumnSpan = 2
                tabr6c6.ColumnSpan = 2
                tabr6c7.ColumnSpan = 1
                tabr6c8.ColumnSpan = 1
                tabr6c9.ColumnSpan = 1
                tabr6c10.ColumnSpan = 1
                tabr6c11.ColumnSpan = 1
                tabr6c12.ColumnSpan = 1
                tabr6c13.ColumnSpan = 2
                tabr6c14.ColumnSpan = 1

                tabr6c1.Attributes.Add("align", "left")
                tabr6c2.Attributes.Add("align", "left")
                tabr6c3.Attributes.Add("align", "center")
                tabr6c4.Attributes.Add("align", "left")
                tabr6c5.Attributes.Add("align", "left")
                tabr6c6.Attributes.Add("align", "left")
                tabr6c7.Attributes.Add("align", "center")
                tabr6c8.Attributes.Add("align", "center")
                tabr6c9.Attributes.Add("align", "center")
                tabr6c10.Attributes.Add("align", "center")
                tabr6c11.Attributes.Add("align", "center")
                tabr6c12.Attributes.Add("align", "center")
                tabr6c13.Attributes.Add("align", "center")
                tabr6c14.Attributes.Add("align", "center")

                tabr6c1.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;</font>"
                tabr6c2.Text = "<font size=2>" & dr(1) & " , " & dr(2) & " ,  " & dr(3) & " , " & dr(4) & " -  " & dr(5) & "&nbsp;&nbsp;</font>"
                tabr6c3.Text = "<font size=2>" & dr(6) & "&nbsp;&nbsp;</font>"
                tabr6c4.Text = "<font size=2>" & dr(7) & "&nbsp;&nbsp;</font>"
                tabr6c5.Text = "<font size=2>" & dr(8) & "&nbsp;&nbsp;</font>"
                tabr6c6.Text = "<font size=2>" & dr(9) & "&nbsp;&nbsp;</font>"
                tabr6c8.Text = "<font size=2>" & dr(10) & "&nbsp;&nbsp;</font>"
                tabr6c7.Text = "<font size=2>" & dr(17) & "&nbsp;&nbsp;</font>"
                tabr6c9.Text = "<font size=2>" & dr(11) & "&nbsp;&nbsp;</font>"
                tabr6c10.Text = "<font size=2>" & dr(12) & "&nbsp;&nbsp;</font>"
                tabr6c11.Text = "<font size=2>" & dr(13) & "&nbsp;&nbsp;</font>"
                tabr6c12.Text = "<font size=2>" & dr(14) & "&nbsp;&nbsp;</font>"
                tabr6c13.Text = "<font size=2>" & dr(15) & "&nbsp;&nbsp;</font>"
                tabr6c14.Text = "<font size=2>" & dr(16) & "&nbsp;&nbsp;</font>"

                tabr6.Controls.Add(tabr6c1)
                tabr6.Controls.Add(tabr6c2)
                tabr6.Controls.Add(tabr6c3)
                tabr6.Controls.Add(tabr6c4)
                tabr6.Controls.Add(tabr6c5)
                tabr6.Controls.Add(tabr6c6)
                tabr6.Controls.Add(tabr6c7)
                tabr6.Controls.Add(tabr6c8)
                tabr6.Controls.Add(tabr6c9)
                tabr6.Controls.Add(tabr6c10)
                tabr6.Controls.Add(tabr6c11)
                tabr6.Controls.Add(tabr6c12)
                tabr6.Controls.Add(tabr6c13)
                tabr6.Controls.Add(tabr6c14)

                tab1.Controls.Add(tabr6)

                Dim tabline23 As New TableRow
                tabline23.Width = 20
                Dim tabcellline233 As New TableCell
                tabcellline233.ColumnSpan = 20
                tabcellline233.Text = "<hr>"
                tabline23.Controls.Add(tabcellline233)
                tab1.Controls.Add(tabline23)
            Next

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
