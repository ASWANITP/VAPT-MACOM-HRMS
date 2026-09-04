Imports System.Data
Imports System.Data.OracleClient
Partial Class Leave_Details_view_leave_rpt_33e25c202238
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim total As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim leavedtlstable As New Table

        leavedtlstable.Attributes.Add("width", "100%")
        Dim header As New TableRow
        header.Width = 10
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 10
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        leavedtlstable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 6
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 6
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        leavedtlstable.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 10
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 2
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 2
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)

        leavedtlstable.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 6
        pheadercell.ColumnSpan = 6
        pheadercell.HorizontalAlign = HorizontalAlign.Center

        pheadercell.Text = "<body align=center ><b><font size=3> Leave Details between " & Me.Request.QueryString("leavefrom") & " and " & Me.Request.QueryString("leaveto") & " </font></b>"
        pheader.Controls.Add(pheadercell)
        leavedtlstable.Controls.Add(pheader)

        Dim pheaderq As New TableRow
        Dim pheadercellq As New TableCell
        pheaderq.Width = 6
        pheadercellq.ColumnSpan = 6
        pheadercellq.HorizontalAlign = HorizontalAlign.Center
        If Me.Request.QueryString("leavetype") = 0 Then
            pheadercellq.Text = "<body align=center ><b><font size=3>Leave Type: All</font></b>"
        ElseIf Me.Request.QueryString("leavetype") = 1 Then
            pheadercellq.Text = "<body align=center ><b><font size=3>Leave Type: Casual</font></b>"
        ElseIf Me.Request.QueryString("leavetype") = 2 Then
            pheadercellq.Text = "<body align=center ><b><font size=3>Leave Type: Sick</font></b>"
        ElseIf Me.Request.QueryString("leavetype") = 3 Then
            pheadercellq.Text = "<body align=center ><b><font size=3>Leave Type: Earned</font></b>"
        ElseIf Me.Request.QueryString("leavetype") = 4 Then
            pheadercellq.Text = "<body align=center ><b><font size=3>Leave Type: L.O.P</font></b>"
        End If
        pheaderq.Controls.Add(pheadercellq)
        leavedtlstable.Controls.Add(pheaderq)

    


        If Me.Request.QueryString("leavetype") = 0 Then
            '                 0            1             2               3              4            5                6
            str = "select em.emp_code,em.emp_name,el.leave_frdate,el.leave_todate,nvl(el.leave_days,0),el.leave_reason,case when el.leave_id=4 and el.leave_process_id=1 then 'Sal. Not Processed (L.O.P)' when el.leave_id=4 and el.leave_process_id=2 then 'Sal. Processed (L.O.P)'when el.leave_id=4 and el.leave_process_id=3 then 'Entered For Arrear Salary (L.O.P)'else '-----' end as Leave_Status from employ_leave_dtl el,employee_master em where em.emp_code=el.emp_code and el.leave_process_id<>0 and el.leave_id in(1,2,3,4) and em.firm_id=" & Session("firm_id") & " and em.post_id=" & Me.Request.QueryString("postid") & " and to_date(el.leave_frdate)>=to_date('" & Me.Request.QueryString("leavefrom") & "') and to_date(el.leave_frdate)<=to_date('" & Me.Request.QueryString("leaveto") & "')"

        Else
            str = "select em.emp_code,em.emp_name,el.leave_frdate,el.leave_todate,nvl(el.leave_days,0),el.leave_reason,case when el.leave_id=4 and el.leave_process_id=1 then 'Sal. Not Processed (L.O.P)' when el.leave_id=4 and el.leave_process_id=2 then 'Sal. Processed (L.O.P)'when el.leave_id=4 and el.leave_process_id=3 then 'Entered For Arrear Salary (L.O.P)'else '-----' end as Leave_Status from employ_leave_dtl el,employee_master em where em.emp_code=el.emp_code and el.leave_process_id<>0 and el.leave_id=" & Me.Request.QueryString("leavetype") & " and em.firm_id=" & Session("firm_id") & " and em.post_id=" & Me.Request.QueryString("postid") & " and to_date(el.leave_frdate)>=to_date('" & Me.Request.QueryString("leavefrom") & "') and to_date(el.leave_frdate)<=to_date('" & Me.Request.QueryString("leaveto") & "')"
        End If

        dt = oh.ExecuteDataSet(str).Tables(0)



        If dt.Rows.Count = 0 Then
            Dim line1d As New TableRow
            Dim linecell1d As New TableCell
            line1d.Width = 6
            linecell1d.ColumnSpan = 6
            linecell1d.Text = "<b> No Leave Details Found !! Or Check whether You entered Correct information!!"
            line1d.Controls.Add(linecell1d)
            leavedtlstable.Controls.Add(line1d)
        Else
            

            Dim field As New TableRow
            field.Width = 8
            Dim f1, f2, f3, f4, f5, f6, f7, f8 As New TableCell


            f1.ColumnSpan = 1
            f1.HorizontalAlign = HorizontalAlign.Left
            f1.Text = "<b><font size=2>Si No</font></b>"
            field.Controls.Add(f1)



            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Left
            f7.Text = "<b><font size=2>Employee Code:</font></b>"
            field.Controls.Add(f7)



            f8.ColumnSpan = 1
            f8.HorizontalAlign = HorizontalAlign.Left
            f8.Text = "<b><font size=2>Employee Name:</font></b>"
            field.Controls.Add(f8)


            f2.ColumnSpan = 1
            f2.HorizontalAlign = HorizontalAlign.Left
            f2.Text = "<b><font size=2>Leave From</font></b>"
            field.Controls.Add(f2)

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Left
            f3.Text = "<b><font size=2>Leave To</font></b>"
            field.Controls.Add(f3)


            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Left
            f4.Text = "<b><font size=2>Leave Days</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Left
            f5.Text = "<b><font size=2>Leave Reason</font></b>"
            field.Controls.Add(f5)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Left
            f6.Text = "<b><font size=2>Leave Status</font></b>"
            field.Controls.Add(f6)


            leavedtlstable.Controls.Add(field)

            Dim linek As New TableRow
            Dim linecellk As New TableCell
            linek.Width = 6
            linecellk.ColumnSpan = 6
            linecellk.Text = "<hr>"
            linek.Controls.Add(linecellk)
            leavedtlstable.Controls.Add(linek)

            For Each dr In dt.Rows

                i += 1

                Dim value As New TableRow
                value.Width = 8
                Dim v0, v1, v2, v3, v4, v5, v6, v7, v8 As New TableCell


                '//SI no
                v1.ColumnSpan = 1
                v1.HorizontalAlign = HorizontalAlign.Center
                v1.Text = "<font size=2>" & i & "</font>"
                value.Controls.Add(v1)


                '//employee code
                v8.ColumnSpan = 1
                v8.HorizontalAlign = HorizontalAlign.Center
                v8.Text = "<font size=2>" & dr(0) & "</font>"
                value.Controls.Add(v8)


                '//employee name

                v0.ColumnSpan = 1
                v0.HorizontalAlign = HorizontalAlign.Center
                v0.Text = "<font size=2>" & dr(1) & "</font>"
                value.Controls.Add(v0)


                '//l From Date
                v2.ColumnSpan = 1
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "</font>"
                value.Controls.Add(v2)

                '///L To Date
                v3.ColumnSpan = 1
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & Format(dr(3), "dd/MMM/yyyy") & "</font>"
                value.Controls.Add(v3)

                '///l days
                v4.ColumnSpan = 1
                v4.HorizontalAlign = HorizontalAlign.Center
                v4.Text = "<font size=2>" & dr(4) & "</font>"
                value.Controls.Add(v4)
                total += dr(4)

                '///L Reason
                v5.ColumnSpan = 1
                v5.HorizontalAlign = HorizontalAlign.Left
                v5.Text = "<font size=2>" & dr(5) & "</font>"
                value.Controls.Add(v5)

                '//Status
                v6.ColumnSpan = 1
                v6.HorizontalAlign = HorizontalAlign.Left
                v6.Text = "<font size=2>" & dr(6) & "</font>"
                value.Controls.Add(v6)

                leavedtlstable.Controls.Add(value)
            Next
        End If

        Dim brow As New TableRow
        brow.Width = 6
        Dim bcell As New TableCell
        bcell.ColumnSpan = 6
        bcell.Text = "<hr>"
        brow.Controls.Add(bcell)
        leavedtlstable.Controls.Add(brow)

        If dt.Rows.Count > 0 Then
            Dim totr As New TableRow
            totr.Width = 6
            Dim a1 As New TableCell
            a1.ColumnSpan = 6

            a1.HorizontalAlign = HorizontalAlign.Left
            a1.Text = "<b><font size=2>Total Days:" & total & "</font></b>"
            totr.Controls.Add(a1)

            leavedtlstable.Controls.Add(totr)
        End If

        Panel_Leave.Controls.Add(leavedtlstable)
    End Sub


End Class
