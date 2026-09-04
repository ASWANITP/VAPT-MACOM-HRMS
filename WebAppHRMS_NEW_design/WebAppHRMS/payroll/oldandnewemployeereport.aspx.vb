Imports System.Data
Imports System.Data.OracleClient
Partial Class Old_New_EmpCode_oldandnewemployeereport_07a3d1cd6321
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1, dt As New DataTable
    Dim dr As DataRow
    Dim str, str1 As String
    Dim i As Integer = 0
    Dim cl_script As New StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("empcode") = 0 Then

            'str = "select em.emp_code as New_Code,em.emp_name,em.join_dt,ed.discont_dt,ed.emp_code as OLd_Code from employee_master em,employee_master_dtl ed where em.status_id=1 and em.emp_code=ed.new_empcode and to_date(ed.discont_dt)>=to_date('" & Me.Request.QueryString("regdatefrom") & "')-2 and to_date(ed.discont_dt)<=to_date('" & Me.Request.QueryString("regdateto") & "') and to_date(em.join_dt)>=to_date('" & Me.Request.QueryString("regdatefrom") & "') order by ed.discont_dt,em.emp_code"
            str = "select em.emp_code as New_Code,  em.emp_name,  em.join_dt,  ed.discont_dt,  ed.emp_code as OLd_Code,  decode(em.status_id,  1,  'Live',  3,  'Resigned',  4,  'Suspended',  5,  'Terminated',  6,  'Long Leave',  10,  'Maternity') as currnt_status  from employee_master em, employee_master_dtl ed,employ_firm f  where em.emp_code = ed.new_empcode  and em.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and to_date(ed.discont_dt) >=  to_date('" & Me.Request.QueryString("regdatefrom") & "') - 2  and to_date(ed.discont_dt) <=  to_date('" & Me.Request.QueryString("regdateto") & "')  and to_date(em.join_dt) >=  to_date('" & Me.Request.QueryString("regdatefrom") & "')  and to_date(em.join_dt) <=  to_date('" & Me.Request.QueryString("regdateto") & "')  order by ed.discont_dt, em.emp_code"
            dt = oh.ExecuteDataSet(str).Tables(0)
        ElseIf Me.Request.QueryString("empcode") <> 0 Then

            Dim a As Integer = oh.ExecuteDataSet("select count(*) from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code=" & Me.Request.QueryString("empcode")).Tables(0).Rows(0)(0)

            If a = 0 Then

                cl_script.Append("   alert('No Employee with this Code!!') ;")
                cl_script.Append("       window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

            ElseIf a <> 0 Then


                Dim s As Integer = oh.ExecuteDataSet("select nvl(new_empcode,0) from employee_master_dtl where emp_code=" & Me.Request.QueryString("empcode")).Tables(0).Rows(0)(0)
                If s = 0 Then
                    Dim b As Integer = oh.ExecuteDataSet("select emp_type from employee_master where emp_code=" & Me.Request.QueryString("empcode")).Tables(0).Rows(0)(0)

                    If b = 1 Then
                        Dim n As Integer = oh.ExecuteDataSet("select count(*) from employee_master_dtl where new_empcode=" & Me.Request.QueryString("empcode")).Tables(0).Rows(0)(0)
                        If n = 0 Then
                            str = "select em.emp_code as a1,em.emp_name,em.join_dt,to_date('15/Aug/1947'),0 as a2,decode(em.status_id,1,'Live',3,'Resigned',4,'Suspended',5,'Terminated',6,'Long Leave',10,'Maternity')as currnt_status from employee_master em where em.emp_code=" & Me.Request.QueryString("empcode") & ""
                        Else
                            str = "select ed.new_empcode as a1,em.emp_name,em.join_dt,ed.discont_dt,ed.emp_code as a2,decode(em.status_id,1,'Live',3,'Resigned',4,'Suspended',5,'Terminated',6,'Long Leave',10,'Maternity')as currnt_status from employee_master em,employee_master_dtl ed where em.emp_code=ed.new_empcode and em.emp_code=" & Me.Request.QueryString("empcode") & ""
                        End If

                    ElseIf b = 2 Then
                        str = "select em.emp_code,em.emp_name,em.join_dt,'15/Aug/1947',0,decode(em.status_id,1,'Live',3,'Resigned',4,'Suspended',5,'Terminated',6,'Long Leave',10,'Maternity')as currnt_status from employee_master em where em.emp_code=" & Me.Request.QueryString("empcode") & ""
                    End If

                    dt = oh.ExecuteDataSet(str).Tables(0)
                ElseIf s <> 0 Then

                    str = "select em.emp_code as a1,em.emp_name,em.join_dt,ed.discont_dt,ed.emp_code as a2,decode(em.status_id,1,'Live',3,'Resigned',4,'Suspended',5,'Terminated',6,'Long Leave',10,'Maternity')as currnt_status from employee_master em,employee_master_dtl ed where em.emp_code=ed.new_empcode and ed.emp_code=" & Me.Request.QueryString("empcode") & ""
                    dt = oh.ExecuteDataSet(str).Tables(0)
                End If

            End If

        End If


            Dim regtable As New Table
        regtable.Width = 7

            regtable.Attributes.Add("width", "100%")
            Dim header As New TableRow
        header.Width = 7
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
        headcell.ColumnSpan = 7
            headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headcell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headcell)
            regtable.Controls.Add(header)

            Dim sheader As New TableRow
        sheader.Width = 7
            Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 7
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            regtable.Controls.Add(sheader)


            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
        subh.Width = 7
            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 2
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 3
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 2
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)

            regtable.Controls.Add(subh)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
        pheader.Width = 7
        pheadercell.ColumnSpan = 7
            pheadercell.HorizontalAlign = HorizontalAlign.Center
            If Me.Request.QueryString("empcode") = 0 Then
                pheadercell.Text = "<b><font size=3> Regularised Employees Between  " & Request.QueryString("regdatefrom") & " and " & Request.QueryString("regdateto") & " </font></b>"
            Else
                pheadercell.Text = "<b><font size=3> Old or New Employee Code of " & Request.QueryString("empcode") & " </font></b>"
            End If
            pheader.Controls.Add(pheadercell)
            regtable.Controls.Add(pheader)


            Dim line1 As New TableRow
            Dim linecell1 As New TableCell
        line1.Width = 7
        linecell1.ColumnSpan = 7
            linecell1.Text = "<hr>"
            line1.Controls.Add(linecell1)
            regtable.Controls.Add(line1)

            Dim colors As String
            colors = "#fff7ff"


            Dim field As New TableRow
        field.Width = 7
            field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6 As New TableCell


            f1.ColumnSpan = 1
            f1.HorizontalAlign = HorizontalAlign.Left
            f1.Text = "<b><font size=2>New&nbsp;EmpCode</font></b>"
            field.Controls.Add(f1)

            f2.ColumnSpan = 2
            f2.HorizontalAlign = HorizontalAlign.Left
            f2.Text = "<b><font size=2>Emp&nbsp;Name</font></b>"
            field.Controls.Add(f2)

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Left
            f3.Text = "<b><font size=2>Join&nbsp;Date</font></b>"
            field.Controls.Add(f3)

            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Left
            f4.Text = "<b><font size=2>Disc.Date</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Left
            f5.Text = "<b><font size=2>Old&nbsp;EmpCode</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 1
        f6.HorizontalAlign = HorizontalAlign.Left
        f6.Text = "<b><font size=2>Current Status</font></b>"
        field.Controls.Add(f6)


            regtable.Controls.Add(field)

            Dim linek As New TableRow
            Dim linecellk As New TableCell
        linek.Width = 7
        linecellk.ColumnSpan = 7
            linecellk.Text = "<hr>"
            linek.Controls.Add(linecellk)
            regtable.Controls.Add(linek)

            If dt.Rows.Count = 0 Then
                Dim err As New TableRow
            err.Width = 7
                Dim er1 As New TableCell
            er1.ColumnSpan = 7
                er1.HorizontalAlign = HorizontalAlign.Center
            er1.Text = "<b><font size=2>NO EMPLOYEE EXISTS!!!</font></b>"
                err.Controls.Add(er1)
                regtable.Controls.Add(err)
            Else
                For Each dr In dt.Rows
                    i += 1

                    If colors.Equals("#fff7ff") = True Then
                        colors = "#eef9ff"
                    Else
                        colors = "#fff7ff"
                    End If

                    Dim value As New TableRow
                value.Width = 7
                Dim v1, v2, v3, v4, v5, v6 As New TableCell
                    value.Attributes.Add("bgcolor", colors)


                    '//New E_Code
                    v1.ColumnSpan = 1
                    v1.HorizontalAlign = HorizontalAlign.Left
                    v1.Text = "<font size=2>" & dr(0) & "</font>"
                    value.Controls.Add(v1)

                    '///E_Name
                    v2.ColumnSpan = 2
                    v2.HorizontalAlign = HorizontalAlign.Left
                    v2.Text = "<font size=2>" & dr(1) & "</font>"
                    value.Controls.Add(v2)

                    '///Join Date
                    v3.ColumnSpan = 1
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "</font>"
                    value.Controls.Add(v3)

                    '///Discontinue Date
                    v4.ColumnSpan = 1
                v4.HorizontalAlign = HorizontalAlign.Left
                If CDate(dr(3)) = Format(CDate("15 /Aug / 1947"), "dd/MMM/yyyy") Then
                    v4.Text = "<font size=2>----</font>"
                Else
                    v4.Text = "<font size=2>" & Format(dr(3), "dd/MMM/yyyy") & "</font>"
                End If

                'v4.Text = "<font size=2>" & Format(dr(3), "dd/MMM/yyyy") & "</font>"
                value.Controls.Add(v4)

                '//Old Ecode
                v5.ColumnSpan = 1
                v5.HorizontalAlign = HorizontalAlign.Left
                If dr(4) = 0 Then
                    v5.Text = "<font size=2>----</font>"
                Else
                    v5.Text = "<font size=2>" & dr(4) & "</font>"
                End If
                value.Controls.Add(v5)


                v6.ColumnSpan = 1
                v6.HorizontalAlign = HorizontalAlign.Left
                v6.Text = "<font size=2>" & dr(5) & "</font>"
                value.Controls.Add(v6)



                regtable.Controls.Add(value)
            Next

                Dim aaw As New TableRow
            aaw.Width = 7
                Dim aaw1 As New TableCell
            aaw1.ColumnSpan = 7
                aaw1.HorizontalAlign = HorizontalAlign.Left
                aaw1.Text = "<b><font size=2>Total:" & i & "&nbsp;Employees</font></b>"
                aaw.Controls.Add(aaw1)

                regtable.Controls.Add(aaw)


            End If





            Pan_EmpCode.Controls.Add(regtable)
    End Sub
End Class
