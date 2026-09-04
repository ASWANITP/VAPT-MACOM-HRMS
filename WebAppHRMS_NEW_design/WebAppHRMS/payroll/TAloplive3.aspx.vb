Imports System.Data
Imports System.Data.OracleClient
Partial Class TAloplive3_3b83237d2110
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim dr1 As DataRow
    Dim sql, str1, str2 As String

    Dim lo_leavetable As New Table

    Dim i As Integer = 0

    Dim ecode As Integer = 0
    Dim dupecode As Integer = 0
    Dim casual As Integer = 0
    Dim sick As Integer = 0
    Dim earned As Integer = 0
    Dim lop As Integer = 0


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lo_leavetable.Attributes.Add("width", "100%")
        Dim header As New TableRow
        header.Width = 16
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 16
        headcell.Text = "<b><font size=4>MANAPPURAM GROUP OF COMPANIES</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        lo_leavetable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 16
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 16
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 color=navy >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        lo_leavetable.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 16
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 4
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 6
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 4
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)

        lo_leavetable.Controls.Add(subh)

        Dim det As String = ""
        If (Request.QueryString("st") = 1) Then
            det = "LIVE EMPLOYEE"
        End If
        If (Request.QueryString("st") = 3) Then
            det = "RESIGNED EMPLOYEE"
        End If
        If (Request.QueryString("st") = 5) Then
            det = "TERMINATED EMPLOYEE"
        End If
        If (Request.QueryString("st") = 88) Then
            det = "REGULARIZED EMPLOYEE"
        End If
        If (Request.QueryString("st") = 10) Then
            det = "MATERNITY EMPLOYEE"
        End If
        If (Request.QueryString("st") = 4) Then
            det = "SUSPENDED EMPLOYEE"
        End If
        If (Request.QueryString("st") = 6) Then
            det = "LONG LEAVE EMPLOYEE"
        End If
        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 16
        pheadercell.ColumnSpan = 16
        pheadercell.HorizontalAlign = HorizontalAlign.Center

        pheadercell.Text = "<body align=center ><b><font size=3 color=blue>TA-" & det & "-LEAVE REPORT BETWEEN  " & Request.QueryString("fdt") & " AND " & Request.QueryString("tdt") & " </font></b>"
        pheader.Controls.Add(pheadercell)
        lo_leavetable.Controls.Add(pheader)
        If (Request.QueryString("st") = 88) Then

        Else
            Dim pheaderq As New TableRow
            Dim pheadercellq As New TableCell
            pheaderq.Width = 16
            pheadercellq.ColumnSpan = 16
            pheadercellq.HorizontalAlign = HorizontalAlign.Center

            pheadercellq.Text = "<body align=center ><b><font size=3>  Employee Code From " & Request.QueryString("lf") & " To " & Request.QueryString("lt") & "</font></b>"
            pheaderq.Controls.Add(pheadercellq)
            lo_leavetable.Controls.Add(pheaderq)
        End If
        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 16
        linecell1.ColumnSpan = 16
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        lo_leavetable.Controls.Add(line1)

        Dim field As New TableRow
        field.Width = 16
        Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell


        f2.ColumnSpan = 1
        f2.HorizontalAlign = HorizontalAlign.Left
        f2.Text = "<b><font size=2>EMPLOY CODE</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 2
        f3.HorizontalAlign = HorizontalAlign.Left
        f3.Text = "<b><font size=2>EMPLOYEE&nbsp;NAME</font></b>"
        field.Controls.Add(f3)


        f4.ColumnSpan = 1
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2 color=navy>LEAVE&nbsp;</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Center
        f5.Text = "<b><font size=2 color=navy>L/L&nbsp;</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 2
        f6.HorizontalAlign = HorizontalAlign.Center
        If (Request.QueryString("st") = 88) Then
            f6.Text = "<b><font size=2 color=red>REGULAR&nbsp;DATE</font></b>"
        Else
            f6.Text = "<b><font size=2 color=red>DISCONT.&nbsp;DATE</font></b>"
        End If
        field.Controls.Add(f6)

        'f7.ColumnSpan = 2
        'f7.HorizontalAlign = HorizontalAlign.Center
        'f7.Text = "<b><font size=2 color=blue>L.O.P</font></b>"
        'field.Controls.Add(f7)

        f8.ColumnSpan = 3
        f8.HorizontalAlign = HorizontalAlign.Left
        f8.Text = "<b><font size=2>&nbsp;DATE&nbsp;FROM&nbsp;</font></b>"
        field.Controls.Add(f8)

        f9.ColumnSpan = 3
        f9.HorizontalAlign = HorizontalAlign.Left
        f9.Text = "<b><font size=2>&nbsp;DATE&nbsp;TO&nbsp;</font></b>"
        field.Controls.Add(f9)

        f10.ColumnSpan = 3
        f10.HorizontalAlign = HorizontalAlign.Left
        f10.Text = "<b><font size=2>LEAVE&nbsp;REASON&nbsp;</font></b>"
        field.Controls.Add(f10)

        lo_leavetable.Controls.Add(field)

        Dim linek As New TableRow
        Dim linecellk As New TableCell
        linek.Width = 16
        linecellk.ColumnSpan = 16
        linecellk.Text = "<hr>"
        linek.Controls.Add(linecellk)
        lo_leavetable.Controls.Add(linek)
        '*************************live*********************************
        If (Request.QueryString("st") = 1) Then
            If (Request.QueryString("a") = 1) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl from employee_master e,employ_leave_dtl l,employ_firm f where e.emp_code=l.emp_code and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) and e.status_id=1 and e.emp_type=1 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " group by e.emp_code,e.emp_name").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select distinct  e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave from employee_master e,employ_transfer_dtl t,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and  t.emp_code=e.emp_code and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) and e.status_id=1 and e.emp_type=1 and t.status_id=6 group by e.emp_code,e.emp_name").Tables(0)
                End If
                ' dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl, sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end) as total_Leave from employee_master e,employ_leave_dtl l,employ_transfer_dtl t where e.emp_code=l.emp_code and t.emp_code=e.emp_code and ((l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "') or ((l.leave_todate between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "') or (l.leave_todate>'" & Request.QueryString("tdt") & "'))) and l.leave_process_id not in (0,3)  and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) and e.status_id=1 and e.emp_type=1 group by e.emp_code,e.emp_name,t.to_dt,t.from_dt,t.status_id union select e.emp_code,e.emp_name,sum(case when l.leave_process_id not in (0,3) and l.leave_frdate<=to_date('" & Request.QueryString("fdt") & "') and to_date(l.leave_todate)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(l.leave_todate)>=to_date('" & Request.QueryString("fdt") & "') then to_date(l.leave_todate)-to_date('" & Request.QueryString("fdt") & "')+1 when l.leave_process_id not in (0,3) and l.leave_frdate<=to_date('" & Request.QueryString("fdt") & "') and to_date(l.leave_todate)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when l.leave_process_id not in (0,3) and l.leave_frdate>to_date('" & Request.QueryString("fdt") & "') and l.leave_frdate<=to_date('" & Request.QueryString("tdt") & "') and to_date(l.leave_todate)<=to_date('" & Request.QueryString("tdt") & "') then l.leave_days when l.leave_process_id not in (0,3) and l.leave_frdate>to_date('" & Request.QueryString("fdt") & "') and l.leave_frdate<to_date('" & Request.QueryString("tdt") & "') and to_date(l.leave_todate)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(l.leave_frdate)+1  end) as tl, case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end as total_Leave from employee_master e,employ_leave_dtl l,employ_transfer_dtl t where e.emp_code=l.emp_code and t.emp_code=e.emp_code and ((l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "') or ((l.leave_todate between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "') or (l.leave_todate>'" & Request.QueryString("tdt") & "'))) and l.leave_process_id not in (0,3)  and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) and e.status_id=1 and e.emp_type=1 group by e.emp_code,e.emp_name,t.to_dt,t.from_dt,t.status_id ").Tables(0)
            End If
            If (Request.QueryString("a") = 2) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl from employee_master e,employ_leave_dtl l,employ_firm f  where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code=l.emp_code and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) and e.status_id=1 and e.emp_type=2 group by e.emp_code,e.emp_name").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select distinct  e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave from employee_master e,employ_transfer_dtl t,employ_firm f  where t.emp_code=e.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) and e.status_id=1 and e.emp_type=2 and t.status_id=6 group by e.emp_code,e.emp_name").Tables(0)
                End If
                'dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl, sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end) as total_Leave from employee_master e,employ_leave_dtl l,employ_transfer_dtl t where e.emp_code=l.emp_code and t.emp_code=e.emp_code and ((l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "') or ((l.leave_todate between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "') or (l.leave_todate>'" & Request.QueryString("tdt") & "'))) and l.leave_process_id not in (0,3)  and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) and e.status_id=1 and e.emp_type=2 group by e.emp_code,e.emp_name,t.to_dt,t.from_dt,t.status_id union select e.emp_code,e.emp_name,sum(case when l.leave_process_id not in (0,3) and l.leave_frdate<=to_date('" & Request.QueryString("fdt") & "') and to_date(l.leave_todate)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(l.leave_todate)>=to_date('" & Request.QueryString("fdt") & "') then to_date(l.leave_todate)-to_date('" & Request.QueryString("fdt") & "')+1 when l.leave_process_id not in (0,3) and l.leave_frdate<=to_date('" & Request.QueryString("fdt") & "') and to_date(l.leave_todate)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when l.leave_process_id not in (0,3) and l.leave_frdate>to_date('" & Request.QueryString("fdt") & "') and l.leave_frdate<=to_date('" & Request.QueryString("tdt") & "') and to_date(l.leave_todate)<=to_date('" & Request.QueryString("tdt") & "') then l.leave_days when l.leave_process_id not in (0,3) and l.leave_frdate>to_date('" & Request.QueryString("fdt") & "') and l.leave_frdate<to_date('" & Request.QueryString("tdt") & "') and to_date(l.leave_todate)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(l.leave_frdate)+1  end) as tl, case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end as total_Leave from employee_master e,employ_leave_dtl l,employ_transfer_dtl t where e.emp_code=l.emp_code and t.emp_code=e.emp_code and ((l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "') or ((l.leave_todate between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "') or (l.leave_todate>'" & Request.QueryString("tdt") & "'))) and l.leave_process_id not in (0,3)  and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) and e.status_id=1 and e.emp_type=2 group by e.emp_code,e.emp_name,t.to_dt,t.from_dt,t.status_id ").Tables(0)
            End If
            If (Request.QueryString("a") = 3) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl from employee_master e,employ_leave_dtl l,employ_firm f  where e.emp_code=l.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) and e.status_id=1  group by e.emp_code,e.emp_name").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select distinct  e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave from employee_master e,employ_transfer_dtl t,employ_firm f  where t.emp_code=e.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) and e.status_id=1 and t.status_id=6 group by e.emp_code,e.emp_name").Tables(0)
                End If
                '  dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl, sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end) as total_Leave from employee_master e,employ_leave_dtl l,employ_transfer_dtl t where e.emp_code=l.emp_code and t.emp_code=e.emp_code and ((l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "') or ((l.leave_todate between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "') or (l.leave_todate>'" & Request.QueryString("tdt") & "'))) and l.leave_process_id not in (0,3)  and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) and e.status_id=1 group by e.emp_code,e.emp_name,t.to_dt,t.from_dt,t.status_id union select e.emp_code,e.emp_name,sum(case when l.leave_process_id not in (0,3) and l.leave_frdate<=to_date('" & Request.QueryString("fdt") & "') and to_date(l.leave_todate)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(l.leave_todate)>=to_date('" & Request.QueryString("fdt") & "') then to_date(l.leave_todate)-to_date('" & Request.QueryString("fdt") & "')+1 when l.leave_process_id not in (0,3) and l.leave_frdate<=to_date('" & Request.QueryString("fdt") & "') and to_date(l.leave_todate)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when l.leave_process_id not in (0,3) and l.leave_frdate>to_date('" & Request.QueryString("fdt") & "') and l.leave_frdate<=to_date('" & Request.QueryString("tdt") & "') and to_date(l.leave_todate)<=to_date('" & Request.QueryString("tdt") & "') then l.leave_days when l.leave_process_id not in (0,3) and l.leave_frdate>to_date('" & Request.QueryString("fdt") & "') and l.leave_frdate<to_date('" & Request.QueryString("tdt") & "') and to_date(l.leave_todate)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(l.leave_frdate)+1  end) as tl, case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end as total_Leave from employee_master e,employ_leave_dtl l,employ_transfer_dtl t where e.emp_code=l.emp_code and t.emp_code=e.emp_code and ((l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "') or ((l.leave_todate between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "') or (l.leave_todate>'" & Request.QueryString("tdt") & "'))) and l.leave_process_id not in (0,3)  and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and e.shift_id not in (4,5) and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) and e.status_id=1 group by e.emp_code,e.emp_name,t.to_dt,t.from_dt,t.status_id ").Tables(0)
            End If
        End If
        '**************************resign*******************************************
        If (Request.QueryString("st") = 3) Then
            If (Request.QueryString("a") = 1) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f  where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and  m.new_empcode is null and to_date(m.discont_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_type=1 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_transfer_dtl t, employee_master_dtl m,employ_firm f where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and  m.new_empcode is null and to_date(m.discont_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and e.emp_code=t.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and t.status_id=6 and e.status_id=3 and e.emp_type=1 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 2) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and  m.new_empcode is null and to_date(m.discont_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_type=2 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_transfer_dtl t, employee_master_dtl m,employ_firm f  where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and  m.new_empcode is null and to_date(m.discont_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and e.emp_code=t.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and t.status_id=6 and e.status_id=3 and e.emp_type=2 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If

            End If
            If (Request.QueryString("a") = 3) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and  m.new_empcode is null and to_date(m.discont_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_transfer_dtl t, employee_master_dtl m,employ_firm f where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and  m.new_empcode is null and to_date(m.discont_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and e.emp_code=t.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and t.status_id=6 and e.status_id=3 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If
            End If
        End If
        '************************Regularized******************
        If (Request.QueryString("st") = 88) Then
            If (Request.QueryString("ca") = 1) Then
                dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl,to_char(to_date(em.join_dt)) as rel_dat from employee_master e, employ_leave_dtl l, employee_master em, employee_master_dtl m,employ_firm f where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.new_empcode is not null and to_date(m.discont_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and em.emp_code=m.new_empcode and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) group by e.emp_code,e.emp_name,em.join_dt order by e.emp_code").Tables(0)
            Else
                dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave,to_char(to_date(em.join_dt)) as rel_dat from employee_master e, employ_transfer_dtl t, employee_master em, employee_master_dtl m,employ_firm f  where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.new_empcode is not null and to_date(m.discont_dt) between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' and e.emp_code=t.emp_code and t.status_id=6 and em.emp_code=m.new_empcode and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>=3) group by e.emp_code,e.emp_name,em.join_dt order by e.emp_code").Tables(0)
            End If
        End If
        '**************************************Terminated******************************************8
        If (Request.QueryString("st") = 5) Then

            If (Request.QueryString("a") = 1) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f where e.emp_code=m.emp_code and e.emp_code=f.firm_id and f.firm_id=" & Session("firm_id") & " and m.new_empcode is null and to_date(m.discont_dt) between ' " & Request.QueryString("fdt") & "' and ' " & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_type=1 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_transfer_dtl t, employee_master_dtl m,employ_firm f where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.new_empcode is null and to_date(m.discont_dt) between ' " & Request.QueryString("fdt") & "' and ' " & Request.QueryString("tdt") & "' and e.emp_code=t.emp_code and t.status_id=6 and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_type=1 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>=3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 2) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f  where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.new_empcode is null and to_date(m.discont_dt) between ' " & Request.QueryString("fdt") & "' and ' " & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_type=2 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_transfer_dtl t, employee_master_dtl m,employ_firm f  where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.new_empcode is null and to_date(m.discont_dt) between ' " & Request.QueryString("fdt") & "' and ' " & Request.QueryString("tdt") & "' and e.emp_code=t.emp_code and t.status_id=6 and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_type=2 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>=3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 3) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as tl,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f  where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.new_empcode is null and to_date(m.discont_dt) between ' " & Request.QueryString("fdt") & "' and ' " & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ta_leavedays (e.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "')and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end )  as total_Leave,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_transfer_dtl t, employee_master_dtl m,employ_firm f  where e.emp_code=m.emp_code and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and m.new_empcode is null and to_date(m.discont_dt) between ' " & Request.QueryString("fdt") & "' and ' " & Request.QueryString("tdt") & "' and e.emp_code=t.emp_code and t.status_id=6 and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and ( ( select sum(case when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') and  to_date(t.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then to_date(t.to_dt)-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt<=to_date('" & Request.QueryString("fdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "')then to_date('" & Request.QueryString("tdt") & "')-to_date('" & Request.QueryString("fdt") & "')+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<=to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)<=to_date('" & Request.QueryString("tdt") & "') then to_date(t.to_dt)-to_date(t.from_dt)+1 when t.status_id=6 and t.to_dt is not null and t.from_dt>to_date('" & Request.QueryString("fdt") & "') and t.from_dt<to_date('" & Request.QueryString("tdt") & "') and to_date(t.to_dt)>to_date('" & Request.QueryString("tdt") & "') then to_date('" & Request.QueryString("tdt") & "')-to_date(t.from_dt)+1 else 0 end)   as  lop from employ_transfer_dtl t where e.emp_code=t.emp_code  )>=3) group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If
            End If
        End If
        '***************************************************MATERNITY************************
        If (Request.QueryString("st") = 10) Then

            If (Request.QueryString("a") = 1) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_transfer_dtl et,employ_firm f ,employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code)where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=et.emp_code and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=10 and et.status_id =em.status_id and em.emp_type=1 and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5)group by em.emp_code,em.emp_name,ed.discont_dt having ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3 order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select et.emp_code,em.emp_name,sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )as Leave_Days,ed.discont_dt from employ_transfer_dtl et,employ_transfer_dtl et1,employee_master em,employee_master_dtl ed,employ_firm f where et.emp_code=et1.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and et.emp_code=em.emp_code and et.emp_code=ed.emp_code and et.status_id=10 and et.status_id=em.status_id and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and  em.emp_code>9999 and em.shift_id not in(4,5) and em.emp_type=1 and to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(et.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and et.to_dt is null and et1.status_id=6 and et1.to_dt is not null and ((to_date(et1.from_dt)<=to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "'))or (to_date(et1.from_dt)>to_date('" & Request.QueryString("fdt") & "') and to_date(et1.to_dt)<to_date('" & Request.QueryString("tdt") & "'))) group by et.emp_code,em.emp_name,ed.discont_dt,et1.from_dt,et1.to_dt,et1.remarks having sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 2) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_transfer_dtl et,employ_firm f,employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code)where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and  em.emp_code=et.emp_code and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=10 and et.status_id =em.status_id and em.emp_type=2 and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5)group by em.emp_code,em.emp_name,ed.discont_dt having ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3 order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select et.emp_code,em.emp_name,sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )as Leave_Days,ed.discont_dt from employ_transfer_dtl et,employ_transfer_dtl et1,employee_master em,employ_firm f,employee_master_dtl ed where et.emp_code=et1.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and et.emp_code=em.emp_code and et.emp_code=ed.emp_code and et.status_id=10 and et.status_id=em.status_id and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and  em.emp_code>9999 and em.shift_id not in(4,5) and em.emp_type=2 and to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(et.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and et.to_dt is null and et1.status_id=6 and et1.to_dt is not null and ((to_date(et1.from_dt)<=to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "'))or (to_date(et1.from_dt)>to_date('" & Request.QueryString("fdt") & "') and to_date(et1.to_dt)<to_date('" & Request.QueryString("tdt") & "'))) group by et.emp_code,em.emp_name,ed.discont_dt,et1.from_dt,et1.to_dt,et1.remarks having sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 3) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_transfer_dtl et,employ_firm f,employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code)where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=et.emp_code and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=10 and et.status_id =em.status_id and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5)group by em.emp_code,em.emp_name,ed.discont_dt having ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3 order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select et.emp_code,em.emp_name,sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )as Leave_Days,ed.discont_dt from employ_transfer_dtl et,employ_transfer_dtl et1,employee_master em,employ_firm f,employee_master_dtl ed where et.emp_code=et1.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and et.emp_code=em.emp_code and et.emp_code=ed.emp_code and et.status_id=10 and et.status_id=em.status_id and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and  em.emp_code>9999 and em.shift_id not in(4,5) and to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(et.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and et.to_dt is null and et1.status_id=6 and et1.to_dt is not null and ((to_date(et1.from_dt)<=to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "'))or (to_date(et1.from_dt)>to_date('" & Request.QueryString("fdt") & "') and to_date(et1.to_dt)<to_date('" & Request.QueryString("tdt") & "'))) group by et.emp_code,em.emp_name,ed.discont_dt,et1.from_dt,et1.to_dt,et1.remarks having sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
        End If
        '**********************************SUSPENDED**************************************************

        If (Request.QueryString("st") = 4) Then

            If (Request.QueryString("a") = 1) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_promotion_dtl ep,employ_firm f,employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=ep.emp_code and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and ep.from_dt=ed.discont_dt and ep.to_dt is null and ep.status_id=4 and ep.status_id=em.status_id and em.emp_type=1 and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) group by em.emp_code,em.emp_name,ed.discont_dt having (ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select ep.emp_code,em.emp_name,sum(case when et.status_id=6 and to_date(et.from_dt)<to_date('" & Request.QueryString("fdt") & "') and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and et.to_dt is not null then (to_date(et.to_dt)-to_date(et.from_dt))+1 end )as Leave_Days,ed.discont_dt from employee_master em,employ_firm f , employee_master_dtl ed,employ_transfer_dtl et,employ_promotion_dtl ep where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=et.emp_code and em.emp_code=ep.emp_code and ep.status_id=4 and ep.status_id=em.status_id and ep.to_dt is null and to_date(ep.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ep.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(ep.from_dt)=to_date(ed.discont_dt) and et.status_id=6 and to_date(et.to_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "')and to_date(et.to_dt) is not null and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and em.emp_code>9999 and em.emp_type=1 and em.shift_id not in(4,5) group by ep.emp_code,em.emp_name,ed.discont_dt,et.from_dt,et.to_dt,et.remarks having sum(case when et.status_id=6 and to_date(et.from_dt)<to_date('" & Request.QueryString("fdt") & "') and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then (to_date(et.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "')then (to_date(et.to_dt)-to_date(et.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 2) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_promotion_dtl ep,employ_firm f ,employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=ep.emp_code and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and ep.from_dt=ed.discont_dt and ep.to_dt is null and ep.status_id=4 and ep.status_id=em.status_id and em.emp_type=2 and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) group by em.emp_code,em.emp_name,ed.discont_dt having (ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select ep.emp_code,em.emp_name,sum(case when et.status_id=6 and to_date(et.from_dt)<to_date('" & Request.QueryString("fdt") & "') and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and et.to_dt is not null then (to_date(et.to_dt)-to_date(et.from_dt))+1 end )as Leave_Days,ed.discont_dt from employee_master em,employee_master_dtl ed,employ_firm f ,employ_transfer_dtl et,employ_promotion_dtl ep where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=et.emp_code and em.emp_code=ep.emp_code and ep.status_id=4 and ep.status_id=em.status_id and ep.to_dt is null and to_date(ep.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ep.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(ep.from_dt)=to_date(ed.discont_dt) and et.status_id=6 and to_date(et.to_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "')and to_date(et.to_dt) is not null and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and em.emp_code>9999 and em.emp_type=2 and em.shift_id not in(4,5) group by ep.emp_code,em.emp_name,ed.discont_dt,et.from_dt,et.to_dt,et.remarks having sum(case when et.status_id=6 and to_date(et.from_dt)<to_date('" & Request.QueryString("fdt") & "') and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then (to_date(et.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "')then (to_date(et.to_dt)-to_date(et.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 3) Then
                If (Request.QueryString("ca") = 1) Then
                    Dim str As String = "select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_promotion_dtl ep,employ_firm f,employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=ep.emp_code and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and ep.from_dt=ed.discont_dt and ep.to_dt is null and ep.status_id=4 and ep.status_id=em.status_id  and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) group by em.emp_code,em.emp_name,ed.discont_dt having (ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) order by em.emp_code"
                    dt = oh.ExecuteDataSet(str).Tables(0)
                    'dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_promotion_dtl ep,employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and em.emp_code=ep.emp_code and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and ep.from_dt=ed.discont_dt and ep.to_dt is null and ep.status_id=4 and ep.status_id=em.status_id  and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) group by em.emp_code,em.emp_name,ed.discont_dt having(ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3) order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select ep.emp_code,em.emp_name,sum(case when et.status_id=6 and to_date(et.from_dt)<to_date('" & Request.QueryString("fdt") & "') and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and et.to_dt is not null then (to_date(et.to_dt)-to_date(et.from_dt))+1 end )as Leave_Days,ed.discont_dt from employee_master em,employ_firm f,employee_master_dtl ed,employ_transfer_dtl et,employ_promotion_dtl ep where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=et.emp_code and em.emp_code=ep.emp_code and ep.status_id=4 and ep.status_id=em.status_id and ep.to_dt is null and to_date(ep.from_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ep.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(ep.from_dt)=to_date(ed.discont_dt) and et.status_id=6 and to_date(et.to_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "')and to_date(et.to_dt) is not null and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) group by ep.emp_code,em.emp_name,ed.discont_dt,et.from_dt,et.to_dt,et.remarks having sum(case when et.status_id=6 and to_date(et.from_dt)<to_date('" & Request.QueryString("fdt") & "') and to_date(et.to_dt)>=to_date('" & Request.QueryString("fdt") & "')then (to_date(et.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "')then (to_date(et.to_dt)-to_date(et.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
        End If
        '*********************************longleave***************************************************

        If (Request.QueryString("st") = 6) Then

            If (Request.QueryString("a") = 1) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_firm f ,employ_transfer_dtl et,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code ) where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=et.emp_code and em.status_id=6 and em.status_id=et.status_id and et.to_dt is null and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and to_date(ed.discont_dt) is not null and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) and em.emp_type=1 group by em.emp_code,em.emp_name,ed.discont_dt having ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3 order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select et.emp_code,em.emp_name,sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )as Leave_Days,ed.discont_dt from employ_transfer_dtl et,employ_firm f,employ_transfer_dtl et1,employee_master em,employee_master_dtl ed where et.emp_code=et1.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and et.emp_code=em.emp_code and et.emp_code=ed.emp_code and et.status_id=6 and et.status_id=em.status_id and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5)and em.emp_type=1 and to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "')and to_date(et.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and et.to_dt is null and et1.status_id=6 and et1.to_dt is not null and to_date(et1.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(et1.to_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "') group by et.emp_code,em.emp_name,ed.discont_dt,et1.from_dt,et1.to_dt having sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 2) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_firm f ,employ_transfer_dtl et,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code ) where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=et.emp_code and em.status_id=6 and em.status_id=et.status_id and et.to_dt is null and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and to_date(ed.discont_dt) is not null and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) and em.emp_type=2 group by em.emp_code,em.emp_name,ed.discont_dt having ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3 order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select et.emp_code,em.emp_name,sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )as Leave_Days,ed.discont_dt from employ_transfer_dtl et,employ_transfer_dtl et1,employee_master em,employee_master_dtl ed ,employ_firm f where et.emp_code=et1.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and et.emp_code=em.emp_code and et.emp_code=ed.emp_code and et.status_id=6 and et.status_id=em.status_id and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5)and em.emp_type=2 and to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "')and to_date(et.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and et.to_dt is null and et1.status_id=6 and et1.to_dt is not null and to_date(et1.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(et1.to_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "') group by et.emp_code,em.emp_name,ed.discont_dt,et1.from_dt,et1.to_dt having sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
            If (Request.QueryString("a") = 3) Then
                If (Request.QueryString("ca") = 1) Then
                    dt = oh.ExecuteDataSet("select em.emp_code,em.emp_name,ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "')) as Leave_days,ed.discont_dt from employee_master_dtl ed,employ_firm f,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code ),employ_transfer_dtl et where em.emp_code=ed.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_code=et.emp_code and em.status_id=6 and em.status_id=et.status_id and et.to_dt is null and to_date(ed.discont_dt)>=to_date('" & Request.QueryString("fdt") & "') and to_date(ed.discont_dt)<=to_date('" & Request.QueryString("tdt") & "') and to_date(ed.discont_dt) is not null and em.emp_code>=" & Request.QueryString("lf") & " and em.emp_code<=" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) group by em.emp_code,em.emp_name,ed.discont_dt having ta_leavedays (em.emp_code ,to_date('" & Request.QueryString("fdt") & "'),to_date('" & Request.QueryString("tdt") & "'))>3 order by em.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select et.emp_code,em.emp_name,sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )as Leave_Days,ed.discont_dt from employ_transfer_dtl et,employ_transfer_dtl et1,employee_master em,employ_firm f,employee_master_dtl ed where et.emp_code=et1.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and et.emp_code=em.emp_code and et.emp_code=ed.emp_code and et.status_id=6 and et.status_id=em.status_id and em.emp_code>" & Request.QueryString("lf") & " and em.emp_code<" & Request.QueryString("lt") & " and em.emp_code>9999 and em.shift_id not in(4,5) and to_date(et.from_dt)>=to_date('" & Request.QueryString("fdt") & "')and to_date(et.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and et.to_dt is null and et1.status_id=6 and et1.to_dt is not null and to_date(et1.from_dt)<=to_date('" & Request.QueryString("tdt") & "')and to_date(et1.to_dt) between to_date('" & Request.QueryString("fdt") & "') and to_date('" & Request.QueryString("tdt") & "') group by et.emp_code,em.emp_name,ed.discont_dt,et1.from_dt,et1.to_dt having sum(case when to_date(et1.from_dt)<to_date('" & Request.QueryString("fdt") & "')and to_date(et1.to_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date('" & Request.QueryString("fdt") & "'))+1 when to_date(et1.from_dt)>=to_date('" & Request.QueryString("fdt") & "') then (to_date(et1.to_dt)-to_date(et1.from_dt))+1 end )>3 order by emp_code").Tables(0)
                End If
            End If
        End If
        '***************************************************************************************************88









        If dt.Rows.Count = 0 Then
            Dim line1d As New TableRow
            Dim linecell1d As New TableCell
            line1d.Width = 16
            linecell1d.ColumnSpan = 16
            linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
            line1d.Controls.Add(linecell1d)
            lo_leavetable.Controls.Add(line1d)
        Else

            For Each dr In dt.Rows

                i += 1

                Dim value As New TableRow
                Dim v1, v2, v3, v5, v6, v7, v8, v9, v10, v11 As New TableCell


                '//E_Code
                v2.ColumnSpan = 1
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(0) & "</font>"
                value.Controls.Add(v2)

                '///E_Name
                v3.ColumnSpan = 2
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & dr(1) & "</font>"
                value.Controls.Add(v3)


                '///C/L
                v5.ColumnSpan = 1
                v5.HorizontalAlign = HorizontalAlign.Center
                If (Request.QueryString("ca") = 6) Then
                    v5.Text = "--"
                End If
                If (Request.QueryString("ca") = 1) Then
                    v5.Text = "<font size=2 color=navy>" & dr(2) & "</font>"
                End If

                value.Controls.Add(v5)

                '//S/L
                v6.ColumnSpan = 1
                v6.HorizontalAlign = HorizontalAlign.Center
                If (Request.QueryString("ca") = 1) Then
                    v6.Text = "--"
                End If
                If (Request.QueryString("ca") = 6) Then
                    v6.Text = "<font size=2 color=navy>" & dr(2) & "</font>"
                End If
                value.Controls.Add(v6)
                If (Request.QueryString("st") = 1) Then
                    '///Earned Leave
                    v7.ColumnSpan = 2
                    v7.HorizontalAlign = HorizontalAlign.Center
                    v7.Text = "----"
                    value.Controls.Add(v7)
                Else
                    v7.ColumnSpan = 2
                    v7.HorizontalAlign = HorizontalAlign.Center
                    v7.Text = "<font size=2 color=red>" & dr(3) & "</font>"
                    value.Controls.Add(v7)
                End If

                '///////LOP
                'v8.ColumnSpan = 2
                'v8.HorizontalAlign = HorizontalAlign.Center
                'v8.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
                'value.Controls.Add(v8)

                '///////Leave_Fro_date
                v9.ColumnSpan = 3
                v9.HorizontalAlign = HorizontalAlign.Left
                v9.Text = " "
                value.Controls.Add(v9)

                '///////Leave_TO_date
                v10.ColumnSpan = 3
                v10.HorizontalAlign = HorizontalAlign.Left
                v10.Text = " "
                value.Controls.Add(v10)

                '///////Reason
                v11.ColumnSpan = 3
                v11.HorizontalAlign = HorizontalAlign.Left
                v11.Text = " "
                value.Controls.Add(v11)

                lo_leavetable.Controls.Add(value)

                If (Request.QueryString("ca") = 1) Then
                    str2 = "select leave_frdate,leave_todate,leave_reason from employ_leave_dtl where( (leave_frdate>='" & Request.QueryString("fdt") & "' and leave_todate<='" & Request.QueryString("tdt") & "') or (leave_todate between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' )  or ((leave_frdate between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "')  and leave_todate>'" & Request.QueryString("tdt") & "') )and emp_code=" & dr(0) & "  and leave_process_id not in (0,3) "
                Else
                    str2 = "select  t.from_dt,t.to_dt,t.remarks||' (L/L)' from employ_transfer_dtl t where( (t.from_dt>='" & Request.QueryString("fdt") & "' and t.to_dt<='" & Request.QueryString("tdt") & "') or (t.to_dt between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "' ) or ((t.from_dt between '" & Request.QueryString("fdt") & "' and '" & Request.QueryString("tdt") & "')  and t.to_dt>'" & Request.QueryString("tdt") & "') )and t.emp_code=" & dr(0) & " and t.status_id=6"
                End If

                dt1 = oh.ExecuteDataSet(str2).Tables(0)


                For Each dr1 In dt1.Rows
                    If IsDBNull(dr1(0)) Then

                    Else
                        Dim valueq As New TableRow
                        Dim vq1, vq2, vq3, vq5, vq6, vq7, vq8, vq9, vq10, vq11 As New TableCell


                        '//E_Code
                        vq2.ColumnSpan = 1
                        vq2.HorizontalAlign = HorizontalAlign.Left
                        vq2.Text = " "
                        valueq.Controls.Add(vq2)

                        '///E_Name
                        vq3.ColumnSpan = 2
                        vq3.HorizontalAlign = HorizontalAlign.Left
                        vq3.Text = " "
                        valueq.Controls.Add(vq3)


                        '///C/L
                        vq5.ColumnSpan = 1
                        vq5.HorizontalAlign = HorizontalAlign.Center
                        vq5.Text = " "
                        valueq.Controls.Add(vq5)

                        '//S/L
                        vq6.ColumnSpan = 1
                        vq6.HorizontalAlign = HorizontalAlign.Center
                        vq6.Text = " "
                        valueq.Controls.Add(vq6)

                        '///Earned
                        vq7.ColumnSpan = 2
                        vq7.HorizontalAlign = HorizontalAlign.Center
                        vq7.Text = " "
                        valueq.Controls.Add(vq7)

                        '/LOP
                        'vq8.ColumnSpan = 1
                        'vq8.HorizontalAlign = HorizontalAlign.Center
                        'vq8.Text = " "
                        'valueq.Controls.Add(vq8)

                        '///Leave_from_date
                        vq9.ColumnSpan = 3
                        vq9.HorizontalAlign = HorizontalAlign.Left
                        vq9.Text = "<font size=2>&nbsp;" & dr1(0) & "&nbsp;</font>"
                        valueq.Controls.Add(vq9)

                        '///Leave_to_date
                        vq10.ColumnSpan = 3
                        vq10.HorizontalAlign = HorizontalAlign.Left
                        vq10.Text = "<font size=2>&nbsp;" & dr1(1) & "&nbsp;</font>"
                        valueq.Controls.Add(vq10)

                        '////Leave_Reason
                        vq11.ColumnSpan = 3
                        vq11.HorizontalAlign = HorizontalAlign.Left
                        vq11.Text = "<font size=2>&nbsp;" & dr1(2) & "&nbsp;</font>"
                        valueq.Controls.Add(vq11)


                        lo_leavetable.Controls.Add(valueq)
                    End If


                Next
            Next


        End If

        Dim lin5 As New TableRow
        Dim lin6 As New TableCell
        lin6.ColumnSpan = 16
        lin6.Text = "<font size=4 color=NAVY>TOTAL EMPLOYEE-" & i & "</font>"
        lin5.Controls.Add(lin6)
        lo_leavetable.Controls.Add(lin5)

        Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
    End Sub

End Class
