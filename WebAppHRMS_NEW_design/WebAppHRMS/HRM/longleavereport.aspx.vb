Imports system.data
Imports system.data.oracleclient
Partial Class specificempattend_individualreport_3ffc5efa8526
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt6, dt7, dt8, dt9, dt10, dt11, dt12, dtlong, dtsanc, dtcomp, dtrejoin, dtfrom, dtnature As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim fdt, tdt, emp, sql, sql1, sqllong, sqlsanc, sqlcomp, sqlrejoin, sqlfrom, sqlnature As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim color = 0
    Dim firm As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fdt = Request.QueryString.Get("fdt")
        tdt = Request.QueryString.Get("tdt")
        emp = Request.QueryString.Get("emp")
        firm = Session("firm_id")
        Dim empcode As Integer
        empcode = Request.QueryString.Get("empcode")
        'If firm = 8 Then
        'sql = "select a.emp_code, a.emp_name, b.branch_name, c.dep_name, f.post_name, a.join_dt,(mst.to_date-mst.frm_dt) as total_leave, sum(case when san.status_id=1 then san.leave_days else 0 end ) as sanctioned_leave_days, sum(case when com.status_id=1 then 1 else 0 end ) as comp_off, (mst.to_date-mst.frm_dt) -(sum(case when san.status_id=1 then san.leave_days else 0 end )+sum(case when com.status_id=1 then 1 else 0 end )) as LOP, mst.to_date, mst.frm_dt, decode(mst.nature,10,'Maternity Leave',6,'Long Leave') as nature from employee_master a, branch_master b, department_mst c, post_mst f, employee_master_dtl em, hrm_long_leave_mst mst, hrm_leave_apply_sanction san, hrm_comp_appl com where a.firm_id =" & firm & " and a.emp_code in (select emp_code from hrm_long_leave_mst) and c.dep_id = a.department_id and a.firm_id = c.firm_id and f.post_id = a.post_id and b.branch_id = a.branch_id and mst.frm_dt=em.discont_dt and em.emp_code in(mst.emp_code) and em.emp_code=a.emp_code and san.emp_code=a.emp_code and san.leave_frdate between '" & fdt & "' and '" & tdt & "' and san.leave_todate between '" & fdt & "' and '" & tdt & "' and com.leave_dt between '" & fdt & "' and '" & tdt & "' and mst.frm_dt between '" & fdt & "' and '" & tdt & "' group by a.emp_code, a.emp_name, b.branch_name, c.dep_name, f.post_name, a.join_dt, (mst.to_date-mst.frm_dt), mst.to_date, mst.frm_dt, mst.nature order by a.emp_code"
        'sql = "select a.emp_code, a.emp_name, b.branch_name, c.dep_name, f.post_name, a.join_dt, (mst.to_date - mst.frm_dt) as total_leave, nvl(san.leave_days,0) as sanctioned_leave_days, nvl(com.comp_off,0) as comp_off, (mst.to_date - mst.frm_dt)- nvl(san.leave_days,0)-nvl(com.comp_off,0) as LOP, mst.to_date, mst.frm_dt, decode(mst.nature, 10, 'Maternity Leave', 6, 'Long Leave') as nature from employee_master a, branch_master b, department_mst c, post_mst f, hrm_long_leave_mst mst, (select com.emp_code,count(com.emp_code)comp_off from hrm_comp_appl com where com.status_id = 1 and com.leave_dt between '" & fdt & "' and '" & tdt & "' group by com.emp_code) com, (select san.emp_code,sum(san.leave_days)leave_days from hrm_leave_apply_sanction san where san.status_id = 1 and san.leave_frdate between '" & fdt & "' and '" & tdt & "' and san.leave_todate between '" & fdt & "' and '" & tdt & "' group by san.emp_code) san where a.firm_id =" & firm & " and c.dep_id = a.department_id and f.post_id = a.post_id and b.branch_id = a.branch_id and a.emp_code=mst.emp_code and san.emp_code(+) = mst.emp_code and com.emp_code(+)=mst.emp_code and mst.frm_dt between '" & fdt & "' and '" & tdt & "' order by a.emp_code"
        sql = "select a.emp_code, a.emp_name, b.branch_name, c.dep_name, f.post_name, a.join_dt, (mst.to_date - mst.frm_dt) as total_leave, nvl(sum(case when ldt.leave_id in(1,2,3) and ldt.leave_process_id in(1,2) and ldt.leave_frdate between '" & fdt & "' and '" & tdt & "' then ldt.leave_days else 0 end),0)as sanctioned_leave_days, nvl(com.comp_off, 0) as comp_off, (mst.to_date - mst.frm_dt)-((nvl(sum(case when ldt.leave_id in(1,2,3) and ldt.leave_process_id in(1,2) and ldt.leave_frdate between '" & fdt & "' and '" & tdt & "' then ldt.leave_days else 0 end),0))+(nvl(com.comp_off, 0))) as LOP, mst.to_date, mst.frm_dt, decode(mst.nature, 10, 'Maternity Leave', 6, 'Long Leave') as nature from employee_master a, branch_master b, department_mst c, post_mst f, employ_leave_dtl ldt, hrm_long_leave_mst mst, (select com.emp_code, count(com.emp_code) comp_off from hrm_comp_appl com where com.status_id = 1 and com.leave_dt between '" & fdt & "' and '" & tdt & "' group by com.emp_code) com where a.firm_id =24 and c.dep_id = a.department_id and f.post_id = a.post_id and ldt.emp_code=mst.emp_code and b.branch_id = a.branch_id and a.emp_code = mst.emp_code and com.emp_code(+) = mst.emp_code and mst.frm_dt between '" & fdt & "' and '" & tdt & "' group by a.emp_code, a.emp_name, b.branch_name, c.dep_name, f.post_name, a.join_dt, (mst.to_date - mst.frm_dt), nvl(com.comp_off, 0), nvl(com.comp_off, 0), mst.to_date, mst.frm_dt, mst.nature order by a.emp_code"
        'End If
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table
        tb.Attributes.Add("Border", "1")
        tb.Style.Add("border-collapse", "collapse")
        tb.Attributes.Add("width", "189%")
        If dt.Rows.Count > 0 Then
            Dim tr1 As New TableRow
            Dim td11 As New TableCell
            tr1.BackColor = Drawing.Color.Gold
            td11.Attributes.Add("width", "100%")
            td11.ColumnSpan = 200
            td11.HorizontalAlign = HorizontalAlign.Center
            td11.Text = "<font size=4 color=red><b>" & Session("firm_name") & "</b></font>"
            tr1.Controls.Add(td11)
            tb.Controls.Add(tr1)

            Dim tr3 As New TableRow
            tr3.BackColor = Drawing.Color.MistyRose
            Dim td31 As New TableCell

            Dim td32 As New TableCell
            td32.Attributes.Add("width", "40%")
            td32.ColumnSpan = 25
            td32.HorizontalAlign = HorizontalAlign.Center
            td32.Text = "<font size=2 color=darkblue><BR><BR><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
            tr3.Controls.Add(td32)

            Dim td321 As New TableCell
            td321.Attributes.Add("width", "40%")
            td321.ColumnSpan = 110
            td321.HorizontalAlign = HorizontalAlign.Center
            td321.Text = "<font size=3.0 color=darkbrown><BR><b>Long Leave Reports From &nbsp" & fdt & "&nbsp To &nbsp" & tdt & "</b></font>"
            tr3.Controls.Add(td321)


            td31.Attributes.Add("width", "40%")
            td31.ColumnSpan = 25
            td31.HorizontalAlign = HorizontalAlign.Center
            td31.Text = "<font size=2 color=darkblue><BR><BR><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
            tr3.Controls.Add(td31)

            tb.Controls.Add(tr3)

            Dim l11 As New TableRow
            Dim ld11 As New TableCell
            ld11.Attributes.Add("width", "80%")
            ld11.ColumnSpan = 200
            ld11.HorizontalAlign = HorizontalAlign.Center
            ld11.Text = "<font size=3><hr size='1' NOSHADE></font>"
            l11.Controls.Add(ld11)
            tb.Controls.Add(l11)

            Dim tr5 As New TableRow
            Dim td51 As New TableCell
            td51.Attributes.Add("width", "5%")
            td51.ColumnSpan = 12
            td51.HorizontalAlign = HorizontalAlign.Left
            td51.Text = "<font size=2.5><b>EMP CODE</b></font>"
            tr5.Controls.Add(td51)

            Dim td541 As New TableCell
            td541.Attributes.Add("width", "7%")
            td541.ColumnSpan = 12
            td541.HorizontalAlign = HorizontalAlign.Left
            td541.Text = "<font size=2.5><b>EMP NAME</b></font>"
            tr5.Controls.Add(td541)

            Dim td54 As New TableCell
            td54.Attributes.Add("width", "7%")
            td54.ColumnSpan = 12
            td54.HorizontalAlign = HorizontalAlign.Left
            td54.Text = "<font size=2.5><b>BRANCH</b></font>"
            tr5.Controls.Add(td54)

            Dim td55 As New TableCell
            td55.Attributes.Add("width", "7%")
            td55.ColumnSpan = 12
            td55.HorizontalAlign = HorizontalAlign.Left
            td55.Text = "<font size=2.5><b>DEPARTMENT</b></font>"
            tr5.Controls.Add(td55)

            Dim td56 As New TableCell
            td56.Attributes.Add("width", "5%")
            td56.ColumnSpan = 12
            td56.HorizontalAlign = HorizontalAlign.Left
            td56.Text = "<font size=2.5><b>POST</b></font>"
            tr5.Controls.Add(td56)

            Dim tS56 As New TableCell
            tS56.Attributes.Add("width", "7%")
            tS56.ColumnSpan = 12
            tS56.HorizontalAlign = HorizontalAlign.Left
            tS56.Text = "<font size=2.5><b>JOIN DATE</b></font>"
            tr5.Controls.Add(tS56)

            Dim td57 As New TableCell
            td57.Attributes.Add("width", "7%")
            td57.ColumnSpan = 12
            td57.HorizontalAlign = HorizontalAlign.Left
            td57.Text = "<font size=2.5><b>LONG LEAVE DAYS</b></font>"
            tr5.Controls.Add(td57)

            Dim tS57 As New TableCell
            tS57.Attributes.Add("width", "7%")
            tS57.ColumnSpan = 12
            tS57.HorizontalAlign = HorizontalAlign.Left
            tS57.Text = "<font size=2.5><b>SANCTIONED LEAVE DAYS</b></font>"
            tr5.Controls.Add(tS57)

            Dim td58 As New TableCell
            td58.Attributes.Add("width", "7%")
            td58.ColumnSpan = 12
            td58.HorizontalAlign = HorizontalAlign.Center
            td58.Text = "<font size=2.5><b>COMP-OFF DAYS</b></font>"
            tr5.Controls.Add(td58)
            tb.Controls.Add(tr5)
            tb.Controls.Add(tr5)

            Dim tS58 As New TableCell
            tS58.Attributes.Add("width", "7%")
            tS58.ColumnSpan = 12
            tS58.HorizontalAlign = HorizontalAlign.Center
            tS58.Text = "<font size=2.5><b>LOP DAYS</b></font>"
            tr5.Controls.Add(tS58)
            tb.Controls.Add(tr5)
            tb.Controls.Add(tr5)
            '---
            Dim tP57 As New TableCell
            tP57.Attributes.Add("width", "7%")
            tP57.ColumnSpan = 12
            tP57.HorizontalAlign = HorizontalAlign.Left
            tP57.Text = "<font size=2.5><b>REJOINED DATE</b></font>"
            tr5.Controls.Add(tP57)

            Dim tP58 As New TableCell
            tP58.Attributes.Add("width", "7%")
            tP58.ColumnSpan = 12
            tP58.HorizontalAlign = HorizontalAlign.Center
            tP58.Text = "<font size=2.5><b>LONG LEAVE FROM</b></font>"
            tr5.Controls.Add(tP58)
            tb.Controls.Add(tr5)
            tb.Controls.Add(tr5)

            Dim tP59 As New TableCell
            tP59.Attributes.Add("width", "7%")
            tP59.ColumnSpan = 12
            tP59.HorizontalAlign = HorizontalAlign.Center
            tP59.Text = "<font size=2.5><b>LEAVE NATURE</b></font>"
            tr5.Controls.Add(tP59)
            tb.Controls.Add(tr5)
            tb.Controls.Add(tr5)

            '---


            For Each dr In dt.Rows

                Dim tr6 As New TableRow
                If (color = 0) Then
                    tr6.BackColor = Drawing.Color.GhostWhite
                    color = 1
                Else
                    tr6.BackColor = Drawing.Color.WhiteSmoke
                    color = 0
                End If

                Dim td61 As New TableCell
                td61.Attributes.Add("width", "5%")
                td61.ColumnSpan = 12
                td61.HorizontalAlign = HorizontalAlign.Left
                td61.Text = "<font size=2>" & dr(0) & "</font>"
                tr6.Controls.Add(td61)

                Dim td64 As New TableCell
                td64.Attributes.Add("width", "7%")
                td64.ColumnSpan = 12
                td64.HorizontalAlign = HorizontalAlign.Left
                td64.Text = "<font size=2>" & dr(1) & "</font>"
                tr6.Controls.Add(td64)

                Dim td66 As New TableCell
                td66.Attributes.Add("width", "7%")
                td66.ColumnSpan = 12
                td66.HorizontalAlign = HorizontalAlign.Left
                td66.Text = "<font size=2>" & dr(2) & "</font>"
                tr6.Controls.Add(td66)

                Dim td67 As New TableCell
                td67.Attributes.Add("width", "7%")
                td67.ColumnSpan = 12
                td67.HorizontalAlign = HorizontalAlign.Left
                td67.Text = "<font size=2>" & dr(3) & "</font>"
                tr6.Controls.Add(td67)

                Dim tp67 As New TableCell
                tp67.Attributes.Add("width", "5%")
                tp67.ColumnSpan = 12
                tp67.HorizontalAlign = HorizontalAlign.Left
                tp67.Text = "<font size=2>" & dr(4) & "</font>"
                tr6.Controls.Add(tp67)

                Dim tp68 As New TableCell
                tp68.Attributes.Add("width", "7%")
                tp68.ColumnSpan = 12
                tp68.HorizontalAlign = HorizontalAlign.Left
                tp68.Text = "<font size=2>" & dr(5) & "</font>"
                tr6.Controls.Add(tp68)

                Dim tp69 As New TableCell
                tp69.Attributes.Add("width", "7%")
                tp69.ColumnSpan = 12
                tp69.HorizontalAlign = HorizontalAlign.Left
                tp69.Text = "<font size=2>" & dr(6) & "</font>"
                tr6.Controls.Add(tp69)

                Dim tp70 As New TableCell
                tp70.Attributes.Add("width", "7%")
                tp70.ColumnSpan = 12
                tp70.HorizontalAlign = HorizontalAlign.Left
                tp70.Text = "<font size=2>" & dr(7) & "</font>"
                tr6.Controls.Add(tp70)

                Dim tp71 As New TableCell
                tp71.Attributes.Add("width", "7%")
                tp71.ColumnSpan = 12
                tp71.HorizontalAlign = HorizontalAlign.Left
                tp71.Text = "<font size=2>" & dr(8) & "</font>"
                tr6.Controls.Add(tp71)

                Dim tp72 As New TableCell
                tp72.Attributes.Add("width", "7%")
                tp72.ColumnSpan = 12
                tp72.HorizontalAlign = HorizontalAlign.Left
                tp72.Text = "<font size=2>" & dr(9) & "</font>"
                tr6.Controls.Add(tp72)

                Dim tp73 As New TableCell
                tp73.Attributes.Add("width", "7%")
                tp73.ColumnSpan = 12
                tp73.HorizontalAlign = HorizontalAlign.Left
                tp73.Text = "<font size=2>" & dr(10) & "</font>"
                tr6.Controls.Add(tp73)

                Dim tp74 As New TableCell
                tp74.Attributes.Add("width", "7%")
                tp74.ColumnSpan = 12
                tp74.HorizontalAlign = HorizontalAlign.Left
                tp74.Text = "<font size=2>" & dr(11) & "</font>"
                tr6.Controls.Add(tp74)

                Dim tp75 As New TableCell
                tp75.Attributes.Add("width", "7%")
                tp75.ColumnSpan = 12
                tp75.HorizontalAlign = HorizontalAlign.Left
                tp75.Text = "<font size=2>" & dr(12) & "</font>"
                tr6.Controls.Add(tp75)
                '----
                Dim td68 As New TableCell
                td68.Attributes.Add("width", "1%")
                td68.Style.Add("display", "none")
                td68.ColumnSpan = 0
                td68.HorizontalAlign = HorizontalAlign.Center
                td68.Text = "<font size=2>&#10003;</font>"
                tr6.Controls.Add(td68)
                tb.Controls.Add(tr6)
                '-----


            Next
            Dim l3 As New TableRow
            Dim ld3 As New TableCell
            ld3.Attributes.Add("width", "100%")
            ld3.ColumnSpan = 200
            ld3.HorizontalAlign = HorizontalAlign.Center
            ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
            l3.Controls.Add(ld3)
            tb.Controls.Add(l3)
            Me.Panel1.Controls.Add(tb)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No Emploees Exists');")
            cl_script1.Append("       window.open('long_leave_rep.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub
End Class
