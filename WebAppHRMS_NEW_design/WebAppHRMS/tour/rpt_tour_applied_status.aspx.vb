Imports System.Data
Imports System.Data.OracleClient
Partial Class tour_cancellation_rpt_tour_applied_status_3a0aca325312
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Dim UserAll(), branch(0), res, sql, str As String
    Dim UserCode, stat, brid, ecode As Integer
    Dim dt, dt1 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        branch = Me.Session("branch_id").ToString.Split("!")
        brid = branch(0)
        ecode = Request.QueryString("edc")
        If brid = 0 Then
            'Dim str As String = "select e.from_dt, e.to_dt, e.from_time, e.to_time,e.advance_rs, case  when e.to_branch in (select branch_id from branch) then (select branch_name from branch br where br.branch_id = e.to_branch) else e.others end as to_branch,e.tour_purpose, tra_dt as apply_date, decode(e.tour_id,1,'SANCTIONED',0,'APPLIED',2,'REJECTED',3,'CANCELLED',4,'RECOMMENDED') as status,re.emp_code||'-'|| re.emp_name as RECOM, DECODE(E.TRAINING_NORMAL, 1, 'YES', NULL, 'NO') as TRAING_STATUS, r.emp_code||'-'||r.emp_name as SANCTION, e.sanction_dt, NVL((select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code and a.curr_date between e.from_dt and e.to_dt and a.m_time = 'TOUR' and a.e_time = 'TOUR' and a.gun_status > 0),'NO BLOCK') as BLOCK_STA,  case  when(select to_char(count(a.curr_date)) from attend a where a.emp_code = e.emp_code  and a.curr_date between e.from_dt and e.to_dt and a.m_time = 'TOUR' and a.e_time = 'TOUR' and a.gun_status > 0) > 0 then 'BLOCK' else 'NO' end AS BLOCK_STATUS  from hrm_tour_dtl e,employee_master r,employee_master re where e.emp_code =" & Me.Request.QueryString("empcode") & " and re.emp_code=e.recom_person and r.emp_code=e.sanction_person and e.from_dt between ('" & Request.QueryString("fromdt") & "') and ('" & Request.QueryString("todt") & "')"
            'Dim str As String = "select e.from_dt, e.to_dt, e.from_time, e.to_time,e.advance_rs, case  when e.to_branch in (select branch_id from branch) then (select branch_name from branch br where br.branch_id = e.to_branch) else e.others end as to_branch,e.tour_purpose, tra_dt as apply_date, decode(e.tour_id,1,'SANCTIONED',0,'APPLIED',2,'REJECTED',3,'CANCELLED',4,'RECOMMENDED') as status, re.emp_code  as RECOM, case when re.emp_code>0 then re.emp_code || '-' || re.emp_name else '' end as RECOM, DECODE(E.TRAINING_NORMAL, 1, 'YES', NULL, 'NO') as TRAING_STATUS, r.emp_code  as SANCTION, case when r.emp_code>0 then r.emp_code || '-' || r.emp_name else '' end as SANCTION, e.sanction_dt, NVL((select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code and a.curr_date between e.from_dt and e.to_dt and a.gun_status > 0),'NO BLOCK') as BLOCK_STA,  case  when(select to_char(count(a.curr_date)) from attend a where a.emp_code = e.emp_code  and a.curr_date between e.from_dt and e.to_dt and a.gun_status > 0) > 0 then 'BLOCK' else 'NO' end AS BLOCK_STATUS  from hrm_tour_dtl e,employee_master r,employee_master re where e.emp_code =" & Me.Request.QueryString("empcode") & " and re.emp_code=e.recom_person and r.emp_code=e.sanction_person and e.from_dt between ('" & Request.QueryString("fromdt") & "') and ('" & Request.QueryString("todt") & "')"
            'Dim str As String = "select e.from_dt,e.to_dt,e.from_time,e.to_time,e.advance_rs, case  when e.to_branch in (select branch_id from branch) then (select branch_name from branch br where br.branch_id = e.to_branch) else  e.others  end as to_branch, e.tour_purpose, tra_dt as apply_date, decode(e.tour_id,  1, 'SANCTIONED',  0, 'APPLIED',  2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED') as status, re.emp_code as RECOM,  case  when re.emp_code > 0 then  re.emp_code || '-' || re.emp_name  else  ''   end as RECOM, DECODE(E.TRAINING_NORMAL, 1, 'YES', NULL, 'NO') as TRAING_STATUS, r.emp_code  as SANCTION,  case   when r.emp_code > 0 then r.emp_code || '-' || r.emp_name  else  '' end as SANCTION, e.sanction_dt, NVL((select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code  and a.curr_date between e.from_dt and e.to_dt  and a.gun_status > 0), 'NO BLOCK') as BLOCK_STA,  case  when (select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code and a.curr_date between e.from_dt and e.to_dt and a.gun_status > 0) > 0 then 'BLOCK' else  'NO' end AS BLOCK_STATUS from hrm_tour_dtl e,employee_master re,employee_master r where e.emp_code = " & Me.Request.QueryString("empcode") & " and re.emp_code=e.recom_person and r.emp_code = e.sanction_person and e.from_dt between ('" & Request.QueryString("fromdt") & "') and ('" & Request.QueryString("todt") & "') order by e.from_dt"
            'Dim str As String = "select e.from_dt,e.to_dt,e.from_time,e.to_time,e.advance_rs, case  when e.to_branch in (select branch_id from branch) then (select branch_name from branch br where br.branch_id = e.to_branch) else  e.others  end as to_branch, e.tour_purpose, tra_dt as apply_date, decode(e.tour_id,  1, 'SANCTIONED',  0, 'APPLIED',  2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED') as status,  e.recom_person as RECOM,  case  when e.recom_person > 0 then e.recom_person ||'-'||re.emp_name  else  ''  end RECOM,  DECODE(E.TRAINING_NORMAL, 1, 'YES', NULL, 'NO') as TRAING_STATUS, r.emp_code  as SANCTION,  case   when r.emp_code > 0 then r.emp_code || '-' || r.emp_name  else  '' end as SANCTION, e.sanction_dt, NVL((select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code  and a.curr_date between e.from_dt and e.to_dt  and a.gun_status > 0), 'NO BLOCK') as BLOCK_STA,  case  when (select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code and a.curr_date between e.from_dt and e.to_dt and a.gun_status > 0) > 0 then 'BLOCK' else  'NO' end AS BLOCK_STATUS from hrm_tour_dtl e left outer join employee_master r on (r.emp_code = e.sanction_person ) left outer join employee_master re on (re.emp_code=e.recom_person) where e.emp_code = " & Me.Request.QueryString("empcode") & "  and r.emp_code = e.sanction_person and e.from_dt between ('" & Request.QueryString("fromdt") & "') and ('" & Request.QueryString("todt") & "') order by e.from_dt"
            'Dim str1 As String = "select e.from_dt,e.to_dt,e.from_time,e.to_time,e.advance_rs, case  when e.to_branch in (select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id = e.to_branch) else  e.others  end as to_branch, e.tour_purpose, tra_dt as apply_date, decode(e.tour_id,  1, 'SANCTIONED',  0, 'APPLIED',  2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED') as status,  e.recom_person as RECOM,  case  when e.recom_person > 0 then e.recom_person ||'-'||re.emp_name  else  ''  end RECOM,  DECODE(E.TRAINING_NORMAL, 1, 'YES', NULL, 'NO') as TRAING_STATUS, r.emp_code  as SANCTION,  case   when r.emp_code > 0 then r.emp_code || '-' || r.emp_name  else  '' end as SANCTION, e.sanction_dt, NVL((select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code  and a.curr_date between e.from_dt and e.to_dt  and a.gun_status > 0), 'NO BLOCK') as BLOCK_STA,  case  when (select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code and a.curr_date between e.from_dt and e.to_dt and a.gun_status > 0) > 0 then 'BLOCK' else  'NO' end AS BLOCK_STATUS from hrm_tour_dtl e left outer join employee_master r on (r.emp_code = e.sanction_person ) left outer join employee_master re on (re.emp_code=e.recom_person) where e.emp_code = " & ecode & "  and r.emp_code = e.sanction_person and e.from_dt between ('" & Request.QueryString("fdt") & "') and ('" & Request.QueryString("tdt") & "')"
            Dim str1 As String = "select e.from_dt,e.to_dt,e.from_time,e.to_time,e.advance_rs, case  when e.to_branch in (select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id = e.to_branch) else  e.others  end as to_branch, e.tour_purpose, tra_dt as apply_date, decode(e.tour_id,  1, 'SANCTIONED',  0, 'APPLIED',  2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED') as status,  e.recom_person as RECOM,  case  when e.recom_person > 0 then e.recom_person ||'-'||re.emp_name  else  ''  end RECOM,  DECODE(E.TRAINING_NORMAL, 1, 'YES', NULL, 'NO') as TRAING_STATUS, r.emp_code  as SANCTION,  case   when r.emp_code > 0 then r.emp_code || '-' || r.emp_name  else  '' end as SANCTION, e.sanction_dt, NVL((select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code  and a.curr_date between e.from_dt and e.to_dt  and a.gun_status > 0), 'NO BLOCK') as BLOCK_STA,  case  when (select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code and a.curr_date between e.from_dt and e.to_dt and a.gun_status > 0) > 0 then 'BLOCK' else  'NO' end AS BLOCK_STATUS from hrm_tour_dtl e left outer join employee_master r on (r.emp_code = e.sanction_person ) left outer join employee_master re on (re.emp_code=e.recom_person) where e.emp_code = " & ecode & "  and r.emp_code = e.sanction_person and (e.from_dt between ('" & Request.QueryString("fdt") & "') and ('" & Request.QueryString("tdt") & "') or e.to_dt between ('" & Request.QueryString("fdt") & "') and ('" & Request.QueryString("tdt") & "'))"
            dt = oh.ExecuteDataSet(str1).Tables(0)

        Else
            ' Dim str As String = "select e.from_dt,e.to_dt,e.from_time,e.to_time,e.advance_rs, case  when e.to_branch in (select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id = e.to_branch) else  e.others  end as to_branch, e.tour_purpose, tra_dt as apply_date, decode(e.tour_id,  1, 'SANCTIONED',  0, 'APPLIED',  2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED') as status,  e.recom_person as RECOM,  case  when e.recom_person > 0 then e.recom_person ||'-'||re.emp_name  else  ''  end RECOM,  DECODE(E.TRAINING_NORMAL, 1, 'YES', NULL, 'NO') as TRAING_STATUS, r.emp_code  as SANCTION,  case   when r.emp_code > 0 then r.emp_code || '-' || r.emp_name  else  '' end as SANCTION, e.sanction_dt, NVL((select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code  and a.curr_date between e.from_dt and e.to_dt  and a.gun_status > 0), 'NO BLOCK') as BLOCK_STA,  case  when (select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code and a.curr_date between e.from_dt and e.to_dt and a.gun_status > 0) > 0 then 'BLOCK' else  'NO' end AS BLOCK_STATUS from hrm_tour_dtl e left outer join employee_master r on (r.emp_code = e.sanction_person ) left outer join employee_master re on (re.emp_code=e.recom_person) where e.emp_code = " & UserCode & "  and r.emp_code = e.sanction_person and e.from_dt between ('" & Request.QueryString("fdt") & "') and ('" & Request.QueryString("tdt") & "')"
            Dim str As String = "select e.from_dt,e.to_dt,e.from_time,e.to_time,e.advance_rs, case  when e.to_branch in (select branch_id from branch_master) then (select branch_name from branch_master br where br.branch_id = e.to_branch) else  e.others  end as to_branch, e.tour_purpose, tra_dt as apply_date, decode(e.tour_id,  1, 'SANCTIONED',  0, 'APPLIED',  2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED') as status,  e.recom_person as RECOM,  case  when e.recom_person > 0 then e.recom_person ||'-'||re.emp_name  else  ''  end RECOM,  DECODE(E.TRAINING_NORMAL, 1, 'YES', NULL, 'NO') as TRAING_STATUS, r.emp_code  as SANCTION,  case   when r.emp_code > 0 then r.emp_code || '-' || r.emp_name  else  '' end as SANCTION, e.sanction_dt, NVL((select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code  and a.curr_date between e.from_dt and e.to_dt  and a.gun_status > 0), 'NO BLOCK') as BLOCK_STA,  case  when (select to_char(count(a.curr_date)) from attend a  where a.emp_code = e.emp_code and a.curr_date between e.from_dt and e.to_dt and a.gun_status > 0) > 0 then 'BLOCK' else  'NO' end AS BLOCK_STATUS from hrm_tour_dtl e left outer join employee_master r on (r.emp_code = e.sanction_person ) left outer join employee_master re on (re.emp_code=e.recom_person) where e.emp_code = " & UserCode & "  and r.emp_code = e.sanction_person and (e.from_dt between ('" & Request.QueryString("fdt") & "') and ('" & Request.QueryString("tdt") & "') or e.to_dt between ('" & Request.QueryString("fdt") & "') and ('" & Request.QueryString("tdt") & "'))"
            dt = oh.ExecuteDataSet(str).Tables(0)

        End If
        'Dim dt As DataTable = oh.ExecuteDataSet(str).Tables(0)
        'dt = oh.ExecuteDataSet(str).Tables(0)

        'table declaration
        Dim tab1 As New Table
        tab1.BorderWidth = 1
        tab1.Attributes.Add("width", "150%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 11
        'tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 15
        tabc1.Text = "<body align=center><b><font size=4>" & Session("firm_name") & "</font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 11
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 15
        tabc2.Attributes.Add("align", "center")
        tabc2.Text = "<body align=center color=red><b><font size=3.5> TOUR STATUS REPORT OF " & Me.Request.QueryString("edc") & "(" & Me.Request.QueryString("enam") & ")</font></b></body>"

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 4
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)

        Dim tabcct As New TableCell
        tabcct.ColumnSpan = 7
        tabcct.Attributes.Add("align", "left")
        tabcct.Text = ""
        tabcct.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcct)
        tab1.Controls.Add(tabrr3)


        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 4
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

        tabcc4.Text = "<b><font size=3.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 11
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 15
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 11
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11, tabr5c12, tabr5c13, tabr5c14 As New TableCell

        tabr5c1.ColumnSpan = "1"
        tabr5c2.ColumnSpan = "1"
        tabr5c3.ColumnSpan = "1"
        tabr5c4.ColumnSpan = "1"
        tabr5c5.ColumnSpan = "1"
        tabr5c6.ColumnSpan = "1"
        tabr5c7.ColumnSpan = "2"
        tabr5c8.ColumnSpan = "1"
        tabr5c9.ColumnSpan = "1"
        tabr5c10.ColumnSpan = "1"
        tabr5c11.ColumnSpan = "1"
        tabr5c12.ColumnSpan = "1"
        tabr5c13.ColumnSpan = "1"
        tabr5c14.ColumnSpan = "1"

        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Center
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Center
        tabr5c8.HorizontalAlign = HorizontalAlign.Left
        tabr5c9.HorizontalAlign = HorizontalAlign.Left
        tabr5c10.HorizontalAlign = HorizontalAlign.Left
        tabr5c11.HorizontalAlign = HorizontalAlign.Left
        tabr5c12.HorizontalAlign = HorizontalAlign.Left
        tabr5c13.HorizontalAlign = HorizontalAlign.Left
        tabr5c14.HorizontalAlign = HorizontalAlign.Left

        tabr5c1.Text = "<b><font size=2.5>FROM DT.</font></b>"
        tabr5c2.Text = "<b><font size=2.5>TO DT.</font></b>"
        tabr5c3.Text = "<b><font size=2.5>FROM TIME.</font></b>"
        tabr5c4.Text = "<b><font size=2.5>TO TIME</font></b>"
        tabr5c5.Text = "<b><font size=2.5>ADVANCE</font></b>"
        tabr5c6.Text = "<b><font size=2.5>TO BRANCH</font></b>"
        tabr5c7.Text = "<b><font size=2.5>PURPOSE</font></b>"
        tabr5c8.Text = "<b><font size=2.5>APPLY DATE</font></b>"
        tabr5c9.Text = "<b><font size=2.5>STATUS</font></b>"
        tabr5c10.Text = "<b><font size=2.5>RECOM BY</font></b>"
        tabr5c11.Text = "<b><font size=2.5>TRAINING STATUS</font></b>"
        tabr5c12.Text = "<b><font size=2.5>SANCTION BY</font></b>"
        tabr5c13.Text = "<b><font size=2.5>SANCTION DT</font></b>"
        tabr5c14.Text = "<b><font size=2.5>BLOCK STATUS</font></b>"

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

        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 11
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 15
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''
        Dim colors As String
        colors = "#fff7ff"
        Dim dr As DataRow
        For Each dr In dt.Rows
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 11
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11, tabr6c12, tabr6c13, tabr6c14 As New TableCell

            tabr6c1.ColumnSpan = "1"
            tabr6c2.ColumnSpan = "1"
            tabr6c3.ColumnSpan = "1"
            tabr6c4.ColumnSpan = "1"
            tabr6c5.ColumnSpan = "1"
            tabr6c6.ColumnSpan = "2"
            tabr6c7.ColumnSpan = "1"
            tabr6c8.ColumnSpan = "1"
            tabr6c9.ColumnSpan = "1"
            tabr6c10.ColumnSpan = "1"
            tabr6c11.ColumnSpan = "1"
            tabr6c12.ColumnSpan = "1"
            tabr6c13.ColumnSpan = "1"
            tabr6c14.ColumnSpan = "1"


            tabr6c1.Attributes.Add("align", "left")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "centre")
            tabr6c5.Attributes.Add("align", "centre")
            tabr6c6.Attributes.Add("align", "left")
            tabr6c7.Attributes.Add("align", "left")
            tabr6c8.Attributes.Add("align", "left")
            tabr6c9.Attributes.Add("align", "left")
            tabr6c10.Attributes.Add("align", "left")
            tabr6c11.Attributes.Add("align", "left")
            tabr6c12.Attributes.Add("align", "left")
            tabr6c13.Attributes.Add("align", "left")
            tabr6c14.Attributes.Add("align", "left")

            tabr6c1.Text = "<font size=2>" & Format(dr(0), "dd/MMM/yyyy") & "&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & Format(dr(1), "dd/MMM/yyyy") & "&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
            tabr6c5.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
            tabr6c6.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
            tabr6c7.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
            tabr6c8.Text = "<font size=2>" & Format(dr(7), "dd/MMM/yyyy") & "&nbsp;</font>"
            tabr6c9.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
            tabr6c10.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
            tabr6c11.Text = "<font size=2>" & dr(11) & "&nbsp;</font>"
            tabr6c12.Text = "<font size=2>" & dr(13) & "&nbsp;</font>"
            tabr6c13.Text = "<font size=2>" & dr(14) & "&nbsp;</font>"
            tabr6c14.Text = "<font size=2>" & dr(16) & "&nbsp;</font>"

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
        Next

        Me.Panel1.Controls.Add(tab1)
    End Sub
End Class
