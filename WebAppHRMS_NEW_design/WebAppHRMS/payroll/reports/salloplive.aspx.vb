Imports System.Data
Imports System.Data.OracleClient
Partial Class salloplive_a11a9a7e5869
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim dr1 As DataRow
    Dim sql, str1, str2 As String
    Dim dt2 As New DataTable
    Dim lo_leavetable As New Table

    Dim i As Integer = 0

    Dim ecode As Integer = 0
    Dim dupecode As Integer = 0
    Dim casual As Integer = 0
    Dim sick As Integer = 0
    Dim earned As Integer = 0
    Dim lop As Integer = 0


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim fd As Integer = Request.QueryString("frm")
        Dim fd As Integer = Session("firm_id")
        dt = oh.ExecuteDataSet("select f.firm_name from firm_master f where f.firm_id=" & fd & "").Tables(0)
        'Dim fs As String = dt.Rows(0)(0)
        If (Request.QueryString("st") = 1) Then
            If (Request.QueryString("ca") = 1) Then
                lo_leavetable.Attributes.Add("width", "100%")
                Dim header As New TableRow
                header.Width = 26
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                Dim headcell As New TableCell
                headcell.ColumnSpan = 26
                headcell.Text = "<b><font size=4>" & dt.Rows(0)(0) & "</font></b>"
                headcell.HorizontalAlign = HorizontalAlign.Center
                header.Controls.Add(headcell)
                lo_leavetable.Controls.Add(header)

                Dim sheader As New TableRow
                sheader.Width = 26
                Dim sheadercell1 As New TableCell
                sheadercell1.ColumnSpan = 26
                sheadercell1.HorizontalAlign = HorizontalAlign.Center
                sheadercell1.Text = "<b><font size=2 color=navy >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
                sheader.Controls.Add(sheadercell1)
                lo_leavetable.Controls.Add(sheader)


                Dim subh As New TableRow
                Dim subcell1 As New TableCell
                Dim subcell2 As New TableCell
                Dim subcell3 As New TableCell
                subh.Width = 26
                subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
                subcell1.ColumnSpan = 4
                subcell1.HorizontalAlign = HorizontalAlign.Left
                subh.Controls.Add(subcell1)

                subcell2.ColumnSpan = 5
                subcell2.HorizontalAlign = HorizontalAlign.Center
                subcell2.Text = " "
                subh.Controls.Add(subcell2)

                subcell3.ColumnSpan = 4
                subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subh.Controls.Add(subcell3)

                lo_leavetable.Controls.Add(subh)

                Dim pheader As New TableRow
                Dim pheadercell As New TableCell
                pheader.Width = 26
                pheadercell.ColumnSpan = 26
                pheadercell.HorizontalAlign = HorizontalAlign.Center

                pheadercell.Text = "<body align=center ><b><font size=3 color=blue>LOP-LEAVE REPORT Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
                pheader.Controls.Add(pheadercell)
                lo_leavetable.Controls.Add(pheader)

                Dim pheaderq As New TableRow
                Dim pheadercellq As New TableCell
                pheaderq.Width = 26
                pheadercellq.ColumnSpan = 26
                pheadercellq.HorizontalAlign = HorizontalAlign.Center

                pheadercellq.Text = "<body align=center ><b><font size=3> From Employee Code " & Request.QueryString("lf") & " To " & Request.QueryString("lt") & "</font></b>"
                pheaderq.Controls.Add(pheadercellq)
                lo_leavetable.Controls.Add(pheaderq)

                Dim line1 As New TableRow
                Dim linecell1 As New TableCell
                line1.Width = 26
                linecell1.ColumnSpan = 26
                linecell1.Text = "<hr>"
                line1.Controls.Add(linecell1)
                lo_leavetable.Controls.Add(line1)

                Dim field As New TableRow
                field.Width = 26
                Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15 As New TableCell


                f2.ColumnSpan = 1
                f2.HorizontalAlign = HorizontalAlign.Left
                f2.Text = "<b><font size=2>EMPLOY CODE</font></b>"
                field.Controls.Add(f2)

                f3.ColumnSpan = 1
                f3.HorizontalAlign = HorizontalAlign.Left
                f3.Text = "<b><font size=2>EMPLOYEE&nbsp;NAME</font></b>"
                field.Controls.Add(f3)


                f14.ColumnSpan = 1
                f14.HorizontalAlign = HorizontalAlign.Left
                f14.Text = "<b><font size=2>BRANCH</font></b>"
                field.Controls.Add(f14)

                f15.ColumnSpan = 1
                f15.HorizontalAlign = HorizontalAlign.Left
                f15.Text = "<b><font size=2>AREA&nbsp;NAME</font></b>"
                field.Controls.Add(f15)


                f4.ColumnSpan = 1
                f4.HorizontalAlign = HorizontalAlign.Left
                f4.Text = "<b><font size=2 color=navy>C/L</font></b>"
                field.Controls.Add(f4)

                f5.ColumnSpan = 1
                f5.HorizontalAlign = HorizontalAlign.Left
                f5.Text = "<b><font size=2 color=navy>S/L</font></b>"
                field.Controls.Add(f5)

                f6.ColumnSpan = 1
                f6.HorizontalAlign = HorizontalAlign.Left
                f6.Text = "<b><font size=2 color=navy>E/L</font></b>"
                field.Controls.Add(f6)

                f7.ColumnSpan = 1
                f7.HorizontalAlign = HorizontalAlign.Left
                f7.Text = "<b><font size=2 color=blue>L.O.P</font></b>"
                field.Controls.Add(f7)

                f8.ColumnSpan = 1
                f8.HorizontalAlign = HorizontalAlign.Left
                f8.Text = "<b><font size=2>LEAVE&nbsp;DATE&nbsp;FROM&nbsp;</font></b>"
                field.Controls.Add(f8)

                f9.ColumnSpan = 1
                f9.HorizontalAlign = HorizontalAlign.Left
                f9.Text = "<b><font size=2>LEAVE&nbsp;DATE&nbsp;TO&nbsp;</font></b>"
                field.Controls.Add(f9)

                f10.ColumnSpan = 1
                f10.HorizontalAlign = HorizontalAlign.Left
                f10.Text = "<b><font size=2>LEAVE&nbsp;REASON&nbsp;</font></b>"
                field.Controls.Add(f10)

                f11.ColumnSpan = 1
                f11.HorizontalAlign = HorizontalAlign.Left
                f11.Text = "<b><font size=2>REMARKS</font></b>"
                field.Controls.Add(f11)

                f12.ColumnSpan = 1
                f12.HorizontalAlign = HorizontalAlign.Left
                f12.Text = "<b><font size=2>STATUS&nbsp;</font></b>"
                field.Controls.Add(f12)

                f13.ColumnSpan = 1
                f13.HorizontalAlign = HorizontalAlign.Left
                f13.Text = "<b><font size=2>SANCTION&nbsp;AUTHORITY&nbsp;</font></b>"
                field.Controls.Add(f13)


                lo_leavetable.Controls.Add(field)

                'Dim linek As New TableRow
                'Dim linecellk As New TableCell
                'linek.Width = 26
                'linecellk.ColumnSpan = 26
                'linecellk.Text = "<hr>"
                'linek.Controls.Add(linecellk)
                'lo_leavetable.Controls.Add(linek)
                If (Request.QueryString("a") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,d.branch_name,d.AREA_NAME,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end ) as  lop from employee_master e,employ_leave_dtl l,employ_firm f ,branch_master b, branch_detail d where e.emp_code=f.emp_code and e.emp_code=l.emp_code and l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "' and l.leave_process_id=1  and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and f.firm_id='" & fd & "' and e.shift_id not in (4,5) and e.emp_type=1 and e.status_id=1  and e.branch_id=d.branch_id  group by e.emp_code,e.emp_name ,d.branch_name, d.AREA_NAME order by e.emp_code").Tables(0)
                End If
                If (Request.QueryString("a") = 2) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,d.branch_name,d.AREA_NAME,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end ) as  lop from employee_master e,employ_leave_dtl l,employ_firm f ,branch_master b, branch_detail d where e.emp_code=f.emp_code and e.emp_code=l.emp_code and l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "' and l.leave_process_id=1  and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and f.firm_id='" & fd & "' and e.shift_id not in (4,5) and e.emp_type=2 and e.status_id=1 and e.branch_id=d.branch_id and d.BRANCH_ID=d.BRANCH_ID group by e.emp_code,e.emp_name ,d.branch_name, d.AREA_NAME order by e.emp_code").Tables(0)
                End If
                If (Request.QueryString("a") = 3) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,d.branch_name,d.AREA_NAME,sum(case when l.leave_id = 1 and l.leave_process_id = 1 then l.leave_days  else  0 end) as cl, sum(case when l.leave_id = 2 and l.leave_process_id = 1 then l.leave_days else  0 end) as sl,sum(case when l.leave_id = 3 and l.leave_process_id = 1 then l.leave_days else  0 end) as el,sum(case when l.leave_id = 4 and l.leave_process_id = 1 then l.leave_days else  0 end) as lop from employee_master e, employ_leave_dtl l, employ_firm f,branch_detail d where e.emp_code = f.emp_code and e.emp_code = l.emp_code and l.leave_frdate>= '" & Request.QueryString("fdt") & "' and l.leave_todate<= '" & Request.QueryString("tdt") & "'  and l.leave_process_id = 1 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code>9999 and f.firm_id='" & fd & "' and e.shift_id not in (4, 5) and e.status_id = 1 and e.branch_id = d.branch_id group by e.emp_code, e.emp_name,d.branch_name,d.AREA_NAME order by e.emp_code").Tables(0)
                End If


                If dt.Rows.Count = 0 Then
                    Dim line1d As New TableRow
                    Dim linecell1d As New TableCell
                    line1d.Width = 26
                    linecell1d.ColumnSpan = 26
                    linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
                    'line1d.Controls.Add(linecell1d)
                    'lo_leavetable.Controls.Add(line1d)
                Else

                    For Each dr In dt.Rows

                        i += 1

                        Dim value As New TableRow
                        Dim v1, v2, v3, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16 As New TableCell


                        '//E_Code
                        v2.ColumnSpan = 1
                        v2.HorizontalAlign = HorizontalAlign.Left
                        v2.Text = ""
                        value.Controls.Add(v2)

                        '///E_Name
                        v3.ColumnSpan = 1
                        v3.HorizontalAlign = HorizontalAlign.Left
                        v3.Text = ""
                        value.Controls.Add(v3)


                        '//branch
                        v12.ColumnSpan = 1
                        v12.HorizontalAlign = HorizontalAlign.Left
                        v12.Text = ""
                        value.Controls.Add(v12)


                        '///area name
                        v13.ColumnSpan = 1
                        v13.HorizontalAlign = HorizontalAlign.Left
                        v13.Text = ""
                        value.Controls.Add(v13)




                        '///C/L
                        v5.ColumnSpan = 1
                        v5.HorizontalAlign = HorizontalAlign.Center
                        v5.Text = ""
                        value.Controls.Add(v5)

                        '//S/L
                        v6.ColumnSpan = 1
                        v6.HorizontalAlign = HorizontalAlign.Center
                        v6.Text = ""
                        value.Controls.Add(v6)

                        '///Earned Leave
                        v7.ColumnSpan = 1
                        v7.HorizontalAlign = HorizontalAlign.Center
                        v7.Text = ""
                        value.Controls.Add(v7)

                        '///////LOP
                        v8.ColumnSpan = 1
                        v8.HorizontalAlign = HorizontalAlign.Center
                        v8.Text = ""
                        value.Controls.Add(v8)

                        '///////Leave_Fro_date
                        v9.ColumnSpan = 1
                        v9.HorizontalAlign = HorizontalAlign.Left
                        v9.Text = " "
                        value.Controls.Add(v9)

                        '///////Leave_TO_date
                        v10.ColumnSpan = 1
                        v10.HorizontalAlign = HorizontalAlign.Left
                        v10.Text = " "
                        value.Controls.Add(v10)

                        '///////Reason
                        v11.ColumnSpan = 1
                        v11.HorizontalAlign = HorizontalAlign.Left
                        v11.Text = " "
                        value.Controls.Add(v11)


                        '///////Remarks
                        v14.ColumnSpan = 1
                        v14.HorizontalAlign = HorizontalAlign.Left
                        v14.Text = " "
                        value.Controls.Add(v14)


                        '///////Status
                        v15.ColumnSpan = 1
                        v15.HorizontalAlign = HorizontalAlign.Left
                        v15.Text = " "
                        value.Controls.Add(v15)


                        '///////Sanction
                        v16.ColumnSpan = 1
                        v16.HorizontalAlign = HorizontalAlign.Left
                        v16.Text = " "
                        value.Controls.Add(v16)









                        lo_leavetable.Controls.Add(value)

                        'str2 = "select to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_frdate end) as fdt ,to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_todate end) as tdt,case when l.leave_id=4 and l.leave_process_id=1 then l.leave_reason end as reas from employ_leave_dtl l where l.emp_code=" & dr(0) & " and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and l.leave_process_id=1   "
                        str2 = "select to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_frdate end) as fdt ,to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_todate end) as tdt,case when l.leave_id=4 and l.leave_process_id=1 then l.leave_reason end as reas,hrmleavestatus(" & dr(0) & ",to_char(case when l.leave_id = 4 and l.leave_process_id = 1 then l.leave_frdate end)) as REMARKS,element(HRMLEAVE_sanctionAuthority(" & dr(0) & ",  " & Session("firm_id") & ", to_char(case when l.leave_id = 4 and l.leave_process_id = 1 then l.leave_frdate end)),1,'$') STATUS, element(HRMLEAVE_sanctionAuthority(" & dr(0) & ",  " & Session("firm_id") & ",to_char(case when l.leave_id = 4 and l.leave_process_id = 1 then l.leave_frdate end)),2,'$') RECOMMENDEDBY from employ_leave_dtl l where l.emp_code=" & dr(0) & " and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and l.leave_process_id = 1 and  l.leave_id=4   "

                        dt1 = oh.ExecuteDataSet(str2).Tables(0)


                        dt1 = oh.ExecuteDataSet(str2).Tables(0)

                        If dt1.Rows.Count > 0 Then

                            For Each dr1 In dt1.Rows
                                If IsDBNull(dr1(0)) Then

                                Else
                                    Dim valueq As New TableRow
                                    Dim vq1, vq2, vq3, vq5, vq6, vq7, vq8, vq9, vq10, vq11, vq12, vq13, vq14, vq16, vq17 As New TableCell


                                    '//E_Code
                                    vq2.ColumnSpan = 1
                                    vq2.HorizontalAlign = HorizontalAlign.Left
                                    vq2.Text = "<font size=2>" & dr(0) & "</font>"
                                    valueq.Controls.Add(vq2)

                                    '///E_Name
                                    vq3.ColumnSpan = 1
                                    vq3.HorizontalAlign = HorizontalAlign.Left
                                    vq3.Text = "<font size=2>" & dr(1) & "</font>"
                                    valueq.Controls.Add(vq3)

                                    '//Branch
                                    vq16.ColumnSpan = 1
                                    vq16.HorizontalAlign = HorizontalAlign.Left
                                    vq16.Text = "<font size=2>" & dr(2) & "</font>"
                                    valueq.Controls.Add(vq16)

                                    '///Area Name
                                    vq17.ColumnSpan = 1
                                    vq17.HorizontalAlign = HorizontalAlign.Left
                                    vq17.Text = "<font size=2>" & dr(3) & "</font>"
                                    valueq.Controls.Add(vq17)



                                    '///C/L
                                    vq5.ColumnSpan = 1
                                    vq5.HorizontalAlign = HorizontalAlign.Center
                                    vq5.Text = "<font size=2>" & dr(4) & "</font>"
                                    valueq.Controls.Add(vq5)

                                    '//S/L
                                    vq6.ColumnSpan = 1
                                    vq6.HorizontalAlign = HorizontalAlign.Center
                                    vq6.Text = "<font size=2>" & dr(5) & "</font>"
                                    valueq.Controls.Add(vq6)

                                    '///Earned
                                    vq7.ColumnSpan = 1
                                    vq7.HorizontalAlign = HorizontalAlign.Center
                                    vq7.Text = "<font size=2>" & dr(6) & "</font>"
                                    valueq.Controls.Add(vq7)

                                    '/LOP
                                    vq8.ColumnSpan = 1
                                    vq8.HorizontalAlign = HorizontalAlign.Center
                                    vq8.Text = "<font size=2>" & dr(7) & "</font>"
                                    valueq.Controls.Add(vq8)

                                    '///Leave_from_date
                                    vq9.ColumnSpan = 1
                                    vq9.HorizontalAlign = HorizontalAlign.Left
                                    vq9.Text = "<font size=2>&nbsp;" & dr1(0) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq9)

                                    '///Leave_to_date
                                    vq10.ColumnSpan = 1
                                    vq10.HorizontalAlign = HorizontalAlign.Left
                                    vq10.Text = "<font size=2>&nbsp;" & dr1(1) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq10)

                                    '////Leave_Reason
                                    vq11.ColumnSpan = 1
                                    vq11.HorizontalAlign = HorizontalAlign.Left
                                    vq11.Text = "<font size=2>&nbsp;" & dr1(2) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq11)



                                    '////Remarks
                                    vq12.ColumnSpan = 1
                                    vq12.HorizontalAlign = HorizontalAlign.Left
                                    vq12.Text = "<font size=2>&nbsp;" & dr1(3) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq12)



                                    '////Status
                                    vq13.ColumnSpan = 1
                                    vq13.HorizontalAlign = HorizontalAlign.Left
                                    vq13.Text = "<font size=2>&nbsp;&nbsp;" & dr1(4) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq13)



                                    '////Sanction Authority
                                    vq14.ColumnSpan = 1
                                    vq14.HorizontalAlign = HorizontalAlign.Left
                                    vq14.Text = "<font size=2>&nbsp;&nbsp;" & dr1(5) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq14)


                                    lo_leavetable.Controls.Add(valueq)
                                End If


                            Next

                        Else
                            Dim lin215 As New TableRow
                            Dim lin216 As New TableCell
                            lin216.ColumnSpan = 26
                            lin216.Text = "<font size=4><HR></font>"
                            lin215.Controls.Add(lin216)
                            'lo_leavetable.Controls.Add(lin215)
                        End If

                    Next


                End If

                Dim lin5 As New TableRow
                Dim lin6 As New TableCell
                lin6.ColumnSpan = 26
                lin6.Text = "<font size=4 color=NAVY>TOTAL EMPLOYEE-" & i & "</font>"
                lin5.Controls.Add(lin6)
                'lo_leavetable.Controls.Add(lin5)

                Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
            Else
                lo_leavetable.Attributes.Add("width", "100%")
                Dim header As New TableRow
                header.Width = 16
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                Dim headcell As New TableCell
                headcell.ColumnSpan = 16
                headcell.Text = "<b><font size=4>" & dt.Rows(0)(0) & "</font></b>"
                headcell.HorizontalAlign = HorizontalAlign.Center
                header.Controls.Add(headcell)
                lo_leavetable.Controls.Add(header)

                Dim sheader As New TableRow
                sheader.Width = 26
                Dim sheadercell1 As New TableCell
                sheadercell1.ColumnSpan = 26
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

                subcell2.ColumnSpan = 5
                subcell2.HorizontalAlign = HorizontalAlign.Center
                subcell2.Text = " "
                subh.Controls.Add(subcell2)

                subcell3.ColumnSpan = 4
                subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subh.Controls.Add(subcell3)

                lo_leavetable.Controls.Add(subh)

                Dim pheader As New TableRow
                Dim pheadercell As New TableCell
                pheader.Width = 26
                pheadercell.ColumnSpan = 26
                pheadercell.HorizontalAlign = HorizontalAlign.Center

                pheadercell.Text = "<body align=center ><b><font size=3 color=blue> Arrear Leave Report Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
                pheader.Controls.Add(pheadercell)
                lo_leavetable.Controls.Add(pheader)
                Dim eee As String
                Dim pheaderq As New TableRow
                Dim pheadercellq As New TableCell
                pheaderq.Width = 26
                pheadercellq.ColumnSpan = 26
                pheadercellq.HorizontalAlign = HorizontalAlign.Center
                If (Request.QueryString("a") = 1) Then
                    eee = "REGULAR EMPLOYEES"
                End If
                If (Request.QueryString("a") = 2) Then
                    eee = "OUTSOURCE EMPLOYEES"
                End If
                If (Request.QueryString("a") = 3) Then
                    eee = "ALL EMPLOYEES"
                End If
                pheadercellq.Text = "<body align=center ><b><font size=3> " & eee & "</font></b>"
                pheaderq.Controls.Add(pheadercellq)
                lo_leavetable.Controls.Add(pheaderq)

                Dim line1 As New TableRow
                Dim linecell1 As New TableCell
                line1.Width = 26
                linecell1.ColumnSpan = 26
                linecell1.Text = "<hr>"
                line1.Controls.Add(linecell1)
                ' lo_leavetable.Controls.Add(line1)

                Dim field As New TableRow
                field.Width = 26
                Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell


                f2.ColumnSpan = 1
                f2.HorizontalAlign = HorizontalAlign.Left
                f2.Text = "<b><font size=2>EMPLOY CODE</font></b>"
                field.Controls.Add(f2)

                f3.ColumnSpan = 1
                f3.HorizontalAlign = HorizontalAlign.Left
                f3.Text = "<b><font size=2>EMPLOYEE&nbsp;NAME</font></b>"
                field.Controls.Add(f3)

                f3.ColumnSpan = 1
                f3.HorizontalAlign = HorizontalAlign.Left
                f3.Text = "<b><font size=2>BRANCH&nbsp;</font></b>"
                field.Controls.Add(f3)

                f3.ColumnSpan = 1
                f3.HorizontalAlign = HorizontalAlign.Left
                f3.Text = "<b><font size=2>AREA&nbsp;NAME</font></b>"
                field.Controls.Add(f3)



                f4.ColumnSpan = 1
                f4.HorizontalAlign = HorizontalAlign.Left
                f4.Text = "<b><font size=2 color=navy>C/L</font></b>"
                field.Controls.Add(f4)

                f5.ColumnSpan = 1
                f5.HorizontalAlign = HorizontalAlign.Left
                f5.Text = "<b><font size=2 color=navy>S/L</font></b>"
                field.Controls.Add(f5)

                f6.ColumnSpan = 1
                f6.HorizontalAlign = HorizontalAlign.Left
                f6.Text = "<b><font size=2 color=navy>E/L</font></b>"
                field.Controls.Add(f6)

                f7.ColumnSpan = 1
                f7.HorizontalAlign = HorizontalAlign.Left
                f7.Text = "<b><font size=2 color=blue>L.O.P</font></b>"
                field.Controls.Add(f7)

                f8.ColumnSpan = 3
                f8.HorizontalAlign = HorizontalAlign.Left
                f8.Text = "<b><font size=2>LEAVE&nbsp;DATE&nbsp;FROM&nbsp;</font></b>"
                field.Controls.Add(f8)

                f9.ColumnSpan = 3
                f9.HorizontalAlign = HorizontalAlign.Left
                f9.Text = "<b><font size=2>LEAVE&nbsp;DATE&nbspTO&nbsp;</font></b>"
                field.Controls.Add(f9)

                f10.ColumnSpan = 3
                f10.HorizontalAlign = HorizontalAlign.Left
                f10.Text = "<b><font size=2>LEAVE&nbsp;REASON&nbsp;</font></b>"
                field.Controls.Add(f10)

                lo_leavetable.Controls.Add(field)

                Dim linek As New TableRow
                Dim linecellk As New TableCell
                linek.Width = 26
                linecellk.ColumnSpan = 26
                linecellk.Text = "<hr>"
                'linek.Controls.Add(linecellk)
                lo_leavetable.Controls.Add(linek)
                If (Request.QueryString("a") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_days else 0 end) as  lop from employee_master e,employ_leave_dtl l,employ_firm f where e.emp_code=f.emp_code and e.emp_code=l.emp_code and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and l.leave_frdate>='" & Request.QueryString("fdt") & " ' and l.leave_todate<='" & Request.QueryString("tdt") & " ' and e.emp_code in (select  distinct a.emp_code from employ_leave_dtl a,employee_master b where a.emp_code=b.emp_code and b.status_id=1 and a.leave_id=4 and a.leave_process_id=3 and a.leave_frdate>='" & Request.QueryString("fdt") & " ' and a.leave_todate<='" & Request.QueryString("tdt") & " ' and b.emp_type=1 ) and f.firm_id=" & fd & " and e.emp_code>9999 and e.shift_id not in (4,5) and e.emp_type=1 and e.status_id=1 group by e.emp_code,e.emp_name order by e.emp_code").Tables(0)
                End If
                If (Request.QueryString("a") = 2) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_days else 0 end) as  lop from employee_master e,employ_leave_dtl l,employ_firm f where e.emp_code=f.emp_code and e.emp_code=l.emp_code and l.leave_frdate>='" & Request.QueryString("fdt") & " ' and l.leave_todate<='" & Request.QueryString("tdt") & " ' and e.emp_code in (select  distinct a.emp_code from employ_leave_dtl a,employee_master b where a.emp_code=b.emp_code and b.status_id=1 and a.leave_id=4 and a.leave_process_id=3 and a.leave_frdate>='" & Request.QueryString("fdt") & " ' and a.leave_todate<='" & Request.QueryString("tdt") & " ' and b.emp_type=2 ) and e.emp_code>9999 and e.shift_id not in (4,5) and e.emp_type=2 and f.firm_id=" & fd & " and e.status_id=1 group by e.emp_code,e.emp_name order by e.emp_code").Tables(0)
                End If
                If (Request.QueryString("a") = 3) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_days else 0 end) as  lop from matech.employee_master e,employ_leave_dtl l,employ_firm f where e.emp_code=f.emp_code and e.emp_code=l.emp_code and e.emp_code in (select  distinct a.emp_code from employ_leave_dtl a,employee_master b where a.emp_code=b.emp_code and b.status_id=1 and a.leave_id=4 and a.leave_process_id=3 and a.leave_frdate>='" & Request.QueryString("fdt") & " ' and a.leave_todate<='" & Request.QueryString("tdt") & " ' ) and l.leave_frdate>='" & Request.QueryString("fdt") & " ' and l.leave_todate<='" & Request.QueryString("tdt") & " ' and e.emp_code>9999 and e.shift_id not in (4,5) and f.firm_id=" & fd & " and e.status_id=1 group by e.emp_code,e.emp_name  order by e.emp_code").Tables(0)
                End If
                If dt.Rows.Count = 0 Then
                    Dim line1d As New TableRow
                    Dim linecell1d As New TableCell
                    line1d.Width = 26
                    linecell1d.ColumnSpan = 26
                    linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
                    ' line1d.Controls.Add(linecell1d)
                    ' lo_leavetable.Controls.Add(line1d)
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
                        v3.ColumnSpan = 1
                        v3.HorizontalAlign = HorizontalAlign.Left
                        v3.Text = "<font size=2>" & dr(1) & "</font>"
                        value.Controls.Add(v3)


                        '///C/L
                        v5.ColumnSpan = 1
                        v5.HorizontalAlign = HorizontalAlign.Center
                        v5.Text = "<font size=2 color=navy>" & dr(2) & "</font>"
                        value.Controls.Add(v5)

                        '//S/L
                        v6.ColumnSpan = 1
                        v6.HorizontalAlign = HorizontalAlign.Center
                        v6.Text = "<font size=2 color=navy>" & dr(3) & "</font>"
                        value.Controls.Add(v6)

                        '///Earned Leave
                        v7.ColumnSpan = 1
                        v7.HorizontalAlign = HorizontalAlign.Center
                        v7.Text = "<font size=2 color=navy>" & dr(4) & "</font>"
                        value.Controls.Add(v7)

                        '///////LOP
                        v8.ColumnSpan = 1
                        v8.HorizontalAlign = HorizontalAlign.Center
                        v8.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
                        value.Controls.Add(v8)

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
                        v11.ColumnSpan = 2
                        v11.HorizontalAlign = HorizontalAlign.Left
                        v11.Text = " "
                        value.Controls.Add(v11)

                        lo_leavetable.Controls.Add(value)

                        str2 = "select to_char(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_frdate end) as fdt ,to_char(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_todate end) as tdt,case when l.leave_id=4 and l.leave_process_id=3 then l.leave_reason end as reas from employ_leave_dtl l where l.emp_code=" & dr(0) & " and l.leave_frdate>='" & Request.QueryString("fdt") & " ' and l.leave_todate<='" & Request.QueryString("tdt") & "' and l.leave_process_id=3 and l.leave_id=4"

                        dt1 = oh.ExecuteDataSet(str2).Tables(0)

                        If dt1.Rows.Count > 0 Then

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
                                    vq3.ColumnSpan = 1
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
                                    vq7.ColumnSpan = 1
                                    vq7.HorizontalAlign = HorizontalAlign.Center
                                    vq7.Text = " "
                                    valueq.Controls.Add(vq7)

                                    '/LOP
                                    vq8.ColumnSpan = 1
                                    vq8.HorizontalAlign = HorizontalAlign.Center
                                    vq8.Text = " "
                                    valueq.Controls.Add(vq8)

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
                                    vq11.ColumnSpan = 2
                                    vq11.HorizontalAlign = HorizontalAlign.Left
                                    vq11.Text = "<font size=2>&nbsp;" & dr1(2) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq11)


                                    lo_leavetable.Controls.Add(valueq)
                                End If


                            Next

                        Else
                            Dim lin215 As New TableRow
                            Dim lin216 As New TableCell
                            lin216.ColumnSpan = 16
                            lin216.Text = "<font size=4><HR></font>"
                            lin215.Controls.Add(lin216)
                            ' lo_leavetable.Controls.Add(lin215)
                        End If

                    Next


                End If

                Dim lin5 As New TableRow
                Dim lin6 As New TableCell
                lin6.ColumnSpan = 16
                lin6.Text = "<font size=4 color=NAVY>TOTAL EMPLOYEE-" & i & "</font>"
                lin5.Controls.Add(lin6)
                'lo_leavetable.Controls.Add(lin5)

                Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
            End If

        End If
        If (Request.QueryString("st") = 3) Then
            If (Request.QueryString("ca") = 1) Then

                lo_leavetable.Attributes.Add("width", "100%")
                Dim header As New TableRow
                header.Width = 16
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                Dim headcell As New TableCell
                headcell.ColumnSpan = 16
                headcell.Text = "<b><font size=4>" & dt.Rows(0)(0) & "</font></b>"
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
                subcell1.ColumnSpan = 5
                subcell1.HorizontalAlign = HorizontalAlign.Left
                subh.Controls.Add(subcell1)

                subcell2.ColumnSpan = 6
                subcell2.HorizontalAlign = HorizontalAlign.Center
                subcell2.Text = " "
                subh.Controls.Add(subcell2)

                subcell3.ColumnSpan = 5
                subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subh.Controls.Add(subcell3)

                lo_leavetable.Controls.Add(subh)

                Dim pheader As New TableRow
                Dim pheadercell As New TableCell
                pheader.Width = 16
                pheadercell.ColumnSpan = 16
                pheadercell.HorizontalAlign = HorizontalAlign.Center

                pheadercell.Text = "<body align=center ><b><font size=3 color=blue> LOP-Leave Report of Resigned Employee Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
                pheader.Controls.Add(pheadercell)
                lo_leavetable.Controls.Add(pheader)

                Dim pheaderq As New TableRow
                Dim pheadercellq As New TableCell
                pheaderq.Width = 16
                pheadercellq.ColumnSpan = 16
                pheadercellq.HorizontalAlign = HorizontalAlign.Center

                pheadercellq.Text = "<body align=center ><b><font size=3> <HR></font></b>"
                pheaderq.Controls.Add(pheadercellq)
                lo_leavetable.Controls.Add(pheaderq)

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

                f3.ColumnSpan = 1
                f3.HorizontalAlign = HorizontalAlign.Left
                f3.Text = "<b><font size=2>EMPLOYEE&nbsp;NAME</font></b>"
                field.Controls.Add(f3)


                f4.ColumnSpan = 1
                f4.HorizontalAlign = HorizontalAlign.Left
                f4.Text = "<b><font size=2 color=navy>C/L</font></b>"
                field.Controls.Add(f4)

                f5.ColumnSpan = 1
                f5.HorizontalAlign = HorizontalAlign.Left
                f5.Text = "<b><font size=2 color=navy>S/L</font></b>"
                field.Controls.Add(f5)

                f6.ColumnSpan = 1
                f6.HorizontalAlign = HorizontalAlign.Left
                f6.Text = "<b><font size=2 color=navy>E/L</font></b>"
                field.Controls.Add(f6)

                f7.ColumnSpan = 1
                f7.HorizontalAlign = HorizontalAlign.Left
                f7.Text = "<b><font size=2 color=blue>L.O.P</font></b>"
                field.Controls.Add(f7)

                fll.ColumnSpan = 1
                fll.HorizontalAlign = HorizontalAlign.Center
                fll.Text = "<b><font size=2 >REGULARISED DATE</font></b>"
                field.Controls.Add(fll)

                f8.ColumnSpan = 3
                f8.HorizontalAlign = HorizontalAlign.Left
                f8.Text = "<b><font size=2>LEAVE&nbsp;DATE FROM&nbsp;</font></b>"
                field.Controls.Add(f8)

                f9.ColumnSpan = 3
                f9.HorizontalAlign = HorizontalAlign.Left
                f9.Text = "<b><font size=2>LEAVE&nbsp;DATE TO&nbsp;</font></b>"
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
                ' linek.Controls.Add(linecellk)
                ' lo_leavetable.Controls.Add(linek)
                If (Request.QueryString("a") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f where e.emp_code=f.emp_code and e.emp_code=m.emp_code  and f.firm_id=" & fd & " and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_type=1 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " group by e.emp_code,e.emp_name,m.discont_dt union select e.emp_code,e.emp_name,0 as cl,0 as sl,0 as el,0 as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e,employ_leave_dtl l,employee_master_dtl m,employ_firm f where e.emp_code=f.emp_code  and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and  e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code not in (select f.emp_code from employ_leave_dtl f where e.emp_code=f.emp_code) and e.emp_type=2 group by e.emp_code,e.emp_name,m.discont_dt order by emp_code").Tables(0)
                End If
                If (Request.QueryString("a") = 2) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f where e.emp_code=f.emp_code and e.emp_code=m.emp_code  and f.firm_id=" & fd & " and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_type=2 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " group by e.emp_code,e.emp_name,m.discont_dt union select e.emp_code,e.emp_name,0 as cl,0 as sl,0 as el,0 as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e,mactechemploy_leave_dtl l,employee_master_dtl m,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and  e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code not in (select f.emp_code from employ_leave_dtl f where e.emp_code=f.emp_code) and e.emp_type=2 group by e.emp_code,e.emp_name,m.discont_dt order by emp_code").Tables(0)
                End If
                If (Request.QueryString("a") = 3) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,nvl(sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end),0) as cl,nvl(sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end),0) as sl,nvl(sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end),0) as el,nvl(sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end),0) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e,employ_leave_dtl l,employee_master_dtl m ,employ_firm f where e.emp_code=f.emp_code  and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and  e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " group by e.emp_code,e.emp_name,m.discont_dt union select e.emp_code,e.emp_name,0 as cl,0 as sl,0 as el,0 as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e,employ_leave_dtl l,employee_master_dtl m,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and  e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and e.emp_code not in (select f.emp_code from employ_leave_dtl f where e.emp_code=f.emp_code) group by e.emp_code,e.emp_name,m.discont_dt order by emp_code").Tables(0)
                End If


                If dt.Rows.Count = 0 Then
                    Dim line1d As New TableRow
                    Dim linecell1d As New TableCell
                    line1d.Width = 16
                    linecell1d.ColumnSpan = 16
                    linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
                    ' line1d.Controls.Add(linecell1d)
                    'lo_leavetable.Controls.Add(line1d)
                Else

                    For Each dr In dt.Rows

                        i += 1

                        Dim value As New TableRow
                        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell


                        '//E_Code
                        v2.ColumnSpan = 1
                        v2.HorizontalAlign = HorizontalAlign.Left
                        v2.Text = "<font size=2>" & dr(0) & "</font>"
                        value.Controls.Add(v2)

                        '///E_Name
                        v3.ColumnSpan = 1
                        v3.HorizontalAlign = HorizontalAlign.Left
                        v3.Text = "<font size=2>" & dr(1) & "</font>"
                        value.Controls.Add(v3)


                        '///C/L
                        v5.ColumnSpan = 1
                        v5.HorizontalAlign = HorizontalAlign.Center
                        v5.Text = "<font size=2 color=navy>" & dr(2) & "</font>"
                        value.Controls.Add(v5)

                        '//S/L
                        v6.ColumnSpan = 1
                        v6.HorizontalAlign = HorizontalAlign.Center
                        v6.Text = "<font size=2 color=navy>" & dr(3) & "</font>"
                        value.Controls.Add(v6)

                        '///Earned Leave
                        v7.ColumnSpan = 1
                        v7.HorizontalAlign = HorizontalAlign.Center
                        v7.Text = "<font size=2 color=navy>" & dr(4) & "</font>"
                        value.Controls.Add(v7)

                        '///////LOP
                        v8.ColumnSpan = 1
                        v8.HorizontalAlign = HorizontalAlign.Center
                        v8.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
                        value.Controls.Add(v8)

                        v4.ColumnSpan = 1
                        v4.HorizontalAlign = HorizontalAlign.Left
                        v4.Text = "<font size=2><u>" & dr(6) & "</u></font>"
                        value.Controls.Add(v4)

                        '///////Leave_Fro_date
                        v9.ColumnSpan = 3
                        v9.HorizontalAlign = HorizontalAlign.Left
                        v9.Text = " "
                        value.Controls.Add(v9)

                        '///////Leave_TO_date
                        v10.ColumnSpan = 3
                        v10.HorizontalAlign = HorizontalAlign.Left
                        v10.Text = ""
                        value.Controls.Add(v10)

                        '///////Reason
                        v11.ColumnSpan = 2
                        v11.HorizontalAlign = HorizontalAlign.Left
                        v11.Text = ""
                        value.Controls.Add(v11)

                        lo_leavetable.Controls.Add(value)

                        str2 = "select to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_frdate end) as fdt ,to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_todate end) as tdt,case when l.leave_id=4 and l.leave_process_id=1 then l.leave_reason end as reas from employ_leave_dtl l where l.emp_code=" & dr(0) & " and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and l.leave_process_id=1 "

                        dt1 = oh.ExecuteDataSet(str2).Tables(0)

                        If dt1.Rows.Count > 0 Then

                            For Each dr1 In dt1.Rows
                                If IsDBNull(dr1(0)) Then

                                Else
                                    Dim valueq As New TableRow
                                    Dim vq1, vq2, vq3, vq4, vq5, vq6, vq7, vq8, vq9, vq10, vq11 As New TableCell


                                    '//E_Code
                                    vq2.ColumnSpan = 1
                                    vq2.HorizontalAlign = HorizontalAlign.Left
                                    vq2.Text = " "
                                    valueq.Controls.Add(vq2)

                                    '///E_Name
                                    vq3.ColumnSpan = 1
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
                                    vq7.ColumnSpan = 1
                                    vq7.HorizontalAlign = HorizontalAlign.Center
                                    vq7.Text = " "
                                    valueq.Controls.Add(vq7)

                                    '/LOP
                                    vq8.ColumnSpan = 1
                                    vq8.HorizontalAlign = HorizontalAlign.Center
                                    vq8.Text = " "
                                    valueq.Controls.Add(vq8)
                                    '///
                                    vq4.ColumnSpan = 1
                                    vq4.HorizontalAlign = HorizontalAlign.Left
                                    vq4.Text = " "
                                    valueq.Controls.Add(vq4)
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
                                    vq11.ColumnSpan = 2
                                    vq11.HorizontalAlign = HorizontalAlign.Left
                                    vq11.Text = "<font size=2>&nbsp;" & dr1(2) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq11)


                                    lo_leavetable.Controls.Add(valueq)
                                End If


                            Next

                        Else
                            Dim lin215 As New TableRow
                            Dim lin216 As New TableCell
                            lin216.ColumnSpan = 16
                            lin216.Text = "<font size=4><HR></font>"
                            lin215.Controls.Add(lin216)
                            'lo_leavetable.Controls.Add(lin215)
                        End If

                    Next


                End If

                Dim lin5 As New TableRow
                Dim lin6 As New TableCell
                lin6.ColumnSpan = 16
                lin6.Text = "<font size=4 color=NAVY>TOTAL EMPLOYEE-" & i & "</font>"
                lin5.Controls.Add(lin6)
                ' lo_leavetable.Controls.Add(lin5)

                Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
            Else
                lo_leavetable.Attributes.Add("width", "100%")
                Dim header As New TableRow
                header.Width = 16
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                Dim headcell As New TableCell
                headcell.ColumnSpan = 16
                headcell.Text = "<b><font size=4>" & dt.Rows(0)(0) & "</font></b>"
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
                subcell1.ColumnSpan = 5
                subcell1.HorizontalAlign = HorizontalAlign.Left
                subh.Controls.Add(subcell1)

                subcell2.ColumnSpan = 6
                subcell2.HorizontalAlign = HorizontalAlign.Center
                subcell2.Text = " "
                subh.Controls.Add(subcell2)

                subcell3.ColumnSpan = 5
                subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subh.Controls.Add(subcell3)

                lo_leavetable.Controls.Add(subh)

                Dim pheader As New TableRow
                Dim pheadercell As New TableCell
                pheader.Width = 16
                pheadercell.ColumnSpan = 16
                pheadercell.HorizontalAlign = HorizontalAlign.Center

                pheadercell.Text = "<body align=center ><b><font size=3 color=blue> LOP-Leave Report of Resigned Employee Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
                pheader.Controls.Add(pheadercell)
                lo_leavetable.Controls.Add(pheader)

                Dim pheaderq As New TableRow
                Dim pheadercellq As New TableCell
                pheaderq.Width = 16
                pheadercellq.ColumnSpan = 16
                pheadercellq.HorizontalAlign = HorizontalAlign.Center

                pheadercellq.Text = "<body align=center ><b><font size=3> <HR></font></b>"
                pheaderq.Controls.Add(pheadercellq)
                lo_leavetable.Controls.Add(pheaderq)

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

                f3.ColumnSpan = 1
                f3.HorizontalAlign = HorizontalAlign.Left
                f3.Text = "<b><font size=2>EMPLOYEE&nbsp;NAME</font></b>"
                field.Controls.Add(f3)


                f4.ColumnSpan = 1
                f4.HorizontalAlign = HorizontalAlign.Left
                f4.Text = "<b><font size=2 color=navy>C/L</font></b>"
                field.Controls.Add(f4)

                f5.ColumnSpan = 1
                f5.HorizontalAlign = HorizontalAlign.Left
                f5.Text = "<b><font size=2 color=navy>S/L</font></b>"
                field.Controls.Add(f5)

                f6.ColumnSpan = 1
                f6.HorizontalAlign = HorizontalAlign.Left
                f6.Text = "<b><font size=2 color=navy>E/L</font></b>"
                field.Controls.Add(f6)

                f7.ColumnSpan = 1
                f7.HorizontalAlign = HorizontalAlign.Left
                f7.Text = "<b><font size=2 color=blue>L.O.P</font></b>"
                field.Controls.Add(f7)

                fll.ColumnSpan = 1
                fll.HorizontalAlign = HorizontalAlign.Center
                fll.Text = "<b><font size=2 >REGULARISED DATE</font></b>"
                field.Controls.Add(fll)

                f8.ColumnSpan = 3
                f8.HorizontalAlign = HorizontalAlign.Left
                f8.Text = "<b><font size=2>LEAVE&nbsp;DATE FROM&nbsp;</font></b>"
                field.Controls.Add(f8)

                f9.ColumnSpan = 3
                f9.HorizontalAlign = HorizontalAlign.Left
                f9.Text = "<b><font size=2>LEAVE&nbsp;DATE TO&nbsp;</font></b>"
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
                'linek.Controls.Add(linecellk)
                'lo_leavetable.Controls.Add(linek)
                If (Request.QueryString("a") = 1) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_days else 0 end) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_type=1 and  e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and l.leave_process_id=3 group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If
                If (Request.QueryString("a") = 2) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_days else 0 end) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m ,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_type=2 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and l.leave_process_id=3 group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If
                If (Request.QueryString("a") = 3) Then
                    dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_days else 0 end) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and  e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=3 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " and l.leave_process_id=3 group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
                End If


                If dt.Rows.Count = 0 Then
                    Dim line1d As New TableRow
                    Dim linecell1d As New TableCell
                    line1d.Width = 16
                    linecell1d.ColumnSpan = 16
                    linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
                    'line1d.Controls.Add(linecell1d)
                    'lo_leavetable.Controls.Add(line1d)
                Else

                    For Each dr In dt.Rows

                        i += 1

                        Dim value As New TableRow
                        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell


                        '//E_Code
                        v2.ColumnSpan = 1
                        v2.HorizontalAlign = HorizontalAlign.Left
                        v2.Text = "<font size=2>" & dr(0) & "</font>"
                        value.Controls.Add(v2)

                        '///E_Name
                        v3.ColumnSpan = 1
                        v3.HorizontalAlign = HorizontalAlign.Left
                        v3.Text = "<font size=2>" & dr(1) & "</font>"
                        value.Controls.Add(v3)


                        '///C/L
                        v5.ColumnSpan = 1
                        v5.HorizontalAlign = HorizontalAlign.Center
                        v5.Text = "<font size=2 color=navy>" & dr(2) & "</font>"
                        value.Controls.Add(v5)

                        '//S/L
                        v6.ColumnSpan = 1
                        v6.HorizontalAlign = HorizontalAlign.Center
                        v6.Text = "<font size=2 color=navy>" & dr(3) & "</font>"
                        value.Controls.Add(v6)

                        '///Earned Leave
                        v7.ColumnSpan = 1
                        v7.HorizontalAlign = HorizontalAlign.Center
                        v7.Text = "<font size=2 color=navy>" & dr(4) & "</font>"
                        value.Controls.Add(v7)

                        '///////LOP
                        v8.ColumnSpan = 1
                        v8.HorizontalAlign = HorizontalAlign.Center
                        v8.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
                        value.Controls.Add(v8)

                        v4.ColumnSpan = 1
                        v4.HorizontalAlign = HorizontalAlign.Left
                        v4.Text = "<font size=2><u>" & dr(6) & "</u></font>"
                        value.Controls.Add(v4)

                        '///////Leave_Fro_date
                        v9.ColumnSpan = 3
                        v9.HorizontalAlign = HorizontalAlign.Left
                        v9.Text = " "
                        value.Controls.Add(v9)

                        '///////Leave_TO_date
                        v10.ColumnSpan = 3
                        v10.HorizontalAlign = HorizontalAlign.Left
                        v10.Text = ""
                        value.Controls.Add(v10)

                        '///////Reason
                        v11.ColumnSpan = 2
                        v11.HorizontalAlign = HorizontalAlign.Left
                        v11.Text = ""
                        value.Controls.Add(v11)

                        lo_leavetable.Controls.Add(value)

                        str2 = "select to_char(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_frdate end) as fdt ,to_char(case when l.leave_id=4 and l.leave_process_id=3 then l.leave_todate end) as tdt,case when l.leave_id=4 and l.leave_process_id=3 then l.leave_reason end as reas from employ_leave_dtl l where l.emp_code=" & dr(0) & " and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and l.leave_process_id=3 "

                        dt1 = oh.ExecuteDataSet(str2).Tables(0)

                        If dt1.Rows.Count > 0 Then

                            For Each dr1 In dt1.Rows
                                If IsDBNull(dr1(0)) Then

                                Else
                                    Dim valueq As New TableRow
                                    Dim vq1, vq2, vq3, vq4, vq5, vq6, vq7, vq8, vq9, vq10, vq11 As New TableCell


                                    '//E_Code
                                    vq2.ColumnSpan = 1
                                    vq2.HorizontalAlign = HorizontalAlign.Left
                                    vq2.Text = " "
                                    valueq.Controls.Add(vq2)

                                    '///E_Name
                                    vq3.ColumnSpan = 1
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
                                    vq7.ColumnSpan = 1
                                    vq7.HorizontalAlign = HorizontalAlign.Center
                                    vq7.Text = " "
                                    valueq.Controls.Add(vq7)

                                    '/LOP
                                    vq8.ColumnSpan = 1
                                    vq8.HorizontalAlign = HorizontalAlign.Center
                                    vq8.Text = " "
                                    valueq.Controls.Add(vq8)
                                    '///
                                    vq4.ColumnSpan = 1
                                    vq4.HorizontalAlign = HorizontalAlign.Left
                                    vq4.Text = " "
                                    valueq.Controls.Add(vq4)
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
                                    vq11.ColumnSpan = 2
                                    vq11.HorizontalAlign = HorizontalAlign.Left
                                    vq11.Text = "<font size=2>&nbsp;" & dr1(2) & "&nbsp;</font>"
                                    valueq.Controls.Add(vq11)


                                    lo_leavetable.Controls.Add(valueq)
                                End If


                            Next

                        Else
                            Dim lin215 As New TableRow
                            Dim lin216 As New TableCell
                            lin216.ColumnSpan = 16
                            lin216.Text = "<font size=4><HR></font>"
                            lin215.Controls.Add(lin216)
                            lo_leavetable.Controls.Add(lin215)
                        End If

                    Next


                End If

                Dim lin5 As New TableRow
                Dim lin6 As New TableCell
                lin6.ColumnSpan = 16
                lin6.Text = "<font size=4 color=NAVY>TOTAL EMPLOYEE-" & i & "</font>"
                lin5.Controls.Add(lin6)
                lo_leavetable.Controls.Add(lin5)

                Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
            End If
        End If
        If (Request.QueryString("st") = 88) Then
            lo_leavetable.Attributes.Add("width", "100%")
            Dim header As New TableRow
            header.Width = 16
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 16
            headcell.Text = "<b><font size=4>" & dt.Rows(0)(0) & "</font></b>"
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
            subcell1.ColumnSpan = 5
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 6
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 5
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)

            lo_leavetable.Controls.Add(subh)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 16
            pheadercell.ColumnSpan = 16
            pheadercell.HorizontalAlign = HorizontalAlign.Center

            pheadercell.Text = "<body align=center ><b><font size=3 color=blue> LOP-Leave Report of Regularized Employee Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
            pheader.Controls.Add(pheadercell)
            lo_leavetable.Controls.Add(pheader)

            Dim pheaderq As New TableRow
            Dim pheadercellq As New TableCell
            pheaderq.Width = 16
            pheadercellq.ColumnSpan = 16
            pheadercellq.HorizontalAlign = HorizontalAlign.Center

            pheadercellq.Text = "<body align=center ><b><font size=3> <HR></font></b>"
            pheaderq.Controls.Add(pheadercellq)
            lo_leavetable.Controls.Add(pheaderq)

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

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Left
            f3.Text = "<b><font size=2>EMPLOYEE&nbsp;NAME</font></b>"
            field.Controls.Add(f3)


            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Left
            f4.Text = "<b><font size=2 color=navy>C/L</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Left
            f5.Text = "<b><font size=2 color=navy>S/L</font></b>"
            field.Controls.Add(f5)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Left
            f6.Text = "<b><font size=2 color=navy>E/L</font></b>"
            field.Controls.Add(f6)

            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Left
            f7.Text = "<b><font size=2 color=blue>L.O.P</font></b>"
            field.Controls.Add(f7)

            fll.ColumnSpan = 1
            fll.HorizontalAlign = HorizontalAlign.Center
            fll.Text = "<b><font size=2 >REGULARISED DATE</font></b>"
            field.Controls.Add(fll)

            f8.ColumnSpan = 3
            f8.HorizontalAlign = HorizontalAlign.Left
            f8.Text = "<b><font size=2>LEAVE&nbsp;DATE FROM&nbsp;</font></b>"
            field.Controls.Add(f8)

            f9.ColumnSpan = 3
            f9.HorizontalAlign = HorizontalAlign.Left
            f9.Text = "<b><font size=2>LEAVE&nbsp;DATE TO&nbsp;</font></b>"
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
            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end) as  lop,to_char(to_date(em.join_dt)) as rel_dat from employee_master e left outer join employ_leave_dtl l on (e.emp_code=l.emp_code and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and l.leave_process_id=1  ), employee_master em, employee_master_dtl m where e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date('" & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is not null and to_date(m.discont_dt)<='" & Request.QueryString("tdt") & "' and em.emp_code=m.new_empcode and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 group by e.emp_code,e.emp_name,em.join_dt order by e.emp_code").Tables(0)


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
                    Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell


                    '//E_Code
                    v2.ColumnSpan = 1
                    v2.HorizontalAlign = HorizontalAlign.Left
                    v2.Text = "<font size=2>" & dr(0) & "</font>"
                    value.Controls.Add(v2)

                    '///E_Name
                    v3.ColumnSpan = 1
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & dr(1) & "</font>"
                    value.Controls.Add(v3)


                    '///C/L
                    v5.ColumnSpan = 1
                    v5.HorizontalAlign = HorizontalAlign.Center
                    v5.Text = "<font size=2 color=navy>" & dr(2) & "</font>"
                    value.Controls.Add(v5)

                    '//S/L
                    v6.ColumnSpan = 1
                    v6.HorizontalAlign = HorizontalAlign.Center
                    v6.Text = "<font size=2 color=navy>" & dr(3) & "</font>"
                    value.Controls.Add(v6)

                    '///Earned Leave
                    v7.ColumnSpan = 1
                    v7.HorizontalAlign = HorizontalAlign.Center
                    v7.Text = "<font size=2 color=navy>" & dr(4) & "</font>"
                    value.Controls.Add(v7)

                    '///////LOP
                    v8.ColumnSpan = 1
                    v8.HorizontalAlign = HorizontalAlign.Center
                    v8.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
                    value.Controls.Add(v8)

                    v4.ColumnSpan = 1
                    v4.HorizontalAlign = HorizontalAlign.Left
                    v4.Text = "<font size=2><u>" & dr(6) & "</u></font>"
                    value.Controls.Add(v4)

                    '///////Leave_Fro_date
                    v9.ColumnSpan = 3
                    v9.HorizontalAlign = HorizontalAlign.Left
                    v9.Text = " "
                    value.Controls.Add(v9)

                    '///////Leave_TO_date
                    v10.ColumnSpan = 3
                    v10.HorizontalAlign = HorizontalAlign.Left
                    v10.Text = ""
                    value.Controls.Add(v10)

                    '///////Reason
                    v11.ColumnSpan = 2
                    v11.HorizontalAlign = HorizontalAlign.Left
                    v11.Text = ""
                    value.Controls.Add(v11)

                    lo_leavetable.Controls.Add(value)

                    str2 = "select to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_frdate end) as fdt ,to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_todate end) as tdt,case when l.leave_id=4 and l.leave_process_id=1 then l.leave_reason end as reas from employ_leave_dtl l where l.emp_code=" & dr(0) & " and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and l.leave_process_id=1 "

                    dt1 = oh.ExecuteDataSet(str2).Tables(0)

                    If dt1.Rows.Count > 0 Then

                        For Each dr1 In dt1.Rows
                            If IsDBNull(dr1(0)) Then

                            Else
                                Dim valueq As New TableRow
                                Dim vq1, vq2, vq3, vq4, vq5, vq6, vq7, vq8, vq9, vq10, vq11 As New TableCell


                                '//E_Code
                                vq2.ColumnSpan = 1
                                vq2.HorizontalAlign = HorizontalAlign.Left
                                vq2.Text = " "
                                valueq.Controls.Add(vq2)

                                '///E_Name
                                vq3.ColumnSpan = 1
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
                                vq7.ColumnSpan = 1
                                vq7.HorizontalAlign = HorizontalAlign.Center
                                vq7.Text = " "
                                valueq.Controls.Add(vq7)

                                '/LOP
                                vq8.ColumnSpan = 1
                                vq8.HorizontalAlign = HorizontalAlign.Center
                                vq8.Text = " "
                                valueq.Controls.Add(vq8)
                                '///
                                vq4.ColumnSpan = 1
                                vq4.HorizontalAlign = HorizontalAlign.Left
                                vq4.Text = " "
                                valueq.Controls.Add(vq4)
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
                                vq11.ColumnSpan = 2
                                vq11.HorizontalAlign = HorizontalAlign.Left
                                vq11.Text = "<font size=2>&nbsp;" & dr1(2) & "&nbsp;</font>"
                                valueq.Controls.Add(vq11)


                                lo_leavetable.Controls.Add(valueq)
                            End If


                        Next

                    Else
                        Dim lin215 As New TableRow
                        Dim lin216 As New TableCell
                        lin216.ColumnSpan = 16
                        lin216.Text = "<font size=4><HR></font>"
                        lin215.Controls.Add(lin216)
                        lo_leavetable.Controls.Add(lin215)
                    End If

                Next


            End If

            Dim lin5 As New TableRow
            Dim lin6 As New TableCell
            lin6.ColumnSpan = 16
            lin6.Text = "<font size=4 color=NAVY>TOTAL EMPLOYEE-" & i & "</font>"
            lin5.Controls.Add(lin6)
            lo_leavetable.Controls.Add(lin5)

            Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
        End If
        If (Request.QueryString("st") = 5) Then

            lo_leavetable.Attributes.Add("width", "100%")
            Dim header As New TableRow
            header.Width = 16
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 16
            headcell.Text = "<b><font size=4>" & dt.Rows(0)(0) & "</font></b>"
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
            subcell1.ColumnSpan = 5
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 6
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 5
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)

            lo_leavetable.Controls.Add(subh)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 16
            pheadercell.ColumnSpan = 16
            pheadercell.HorizontalAlign = HorizontalAlign.Center

            pheadercell.Text = "<body align=center ><b><font size=3 color=blue> LOP-Leave Report of Terminated Employee Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
            pheader.Controls.Add(pheadercell)
            lo_leavetable.Controls.Add(pheader)

            Dim pheaderq As New TableRow
            Dim pheadercellq As New TableCell
            pheaderq.Width = 16
            pheadercellq.ColumnSpan = 16
            pheadercellq.HorizontalAlign = HorizontalAlign.Center

            pheadercellq.Text = "<body align=center ><b><font size=3> <HR></font></b>"
            pheaderq.Controls.Add(pheadercellq)
            lo_leavetable.Controls.Add(pheaderq)

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

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Left
            f3.Text = "<b><font size=2>EMPLOYEE&nbsp;NAME</font></b>"
            field.Controls.Add(f3)


            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Left
            f4.Text = "<b><font size=2 color=navy>C/L</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Left
            f5.Text = "<b><font size=2 color=navy>S/L</font></b>"
            field.Controls.Add(f5)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Left
            f6.Text = "<b><font size=2 color=navy>E/L</font></b>"
            field.Controls.Add(f6)

            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Left
            f7.Text = "<b><font size=2 color=blue>L.O.P</font></b>"
            field.Controls.Add(f7)

            fll.ColumnSpan = 1
            fll.HorizontalAlign = HorizontalAlign.Center
            fll.Text = "<b><font size=2 >RELEIVE DATE</font></b>"
            field.Controls.Add(fll)

            f8.ColumnSpan = 3
            f8.HorizontalAlign = HorizontalAlign.Left
            f8.Text = "<b><font size=2>LEAVE&nbsp;DATE FROM&nbsp;</font></b>"
            field.Controls.Add(f8)

            f9.ColumnSpan = 3
            f9.HorizontalAlign = HorizontalAlign.Left
            f9.Text = "<b><font size=2>LEAVE&nbsp;DATE TO&nbsp;</font></b>"
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
            If (Request.QueryString("a") = 1) Then
                dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m ,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date(' " & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<=' " & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>=' " & Request.QueryString("fdt") & "' and l.leave_todate<=' " & Request.QueryString("tdt") & "'  and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_type=1 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
            End If
            If (Request.QueryString("a") = 2) Then
                dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m ,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date(' " & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<=' " & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>=' " & Request.QueryString("fdt") & "' and l.leave_todate<=' " & Request.QueryString("tdt") & "' and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_type=2 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
            End If
            If (Request.QueryString("a") = 3) Then
                dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,sum(case when l.leave_id=1 and l.leave_process_id =1 then l.leave_days else 0 end) as cl,sum(case when l.leave_id=2 and l.leave_process_id =1 then l.leave_days else 0 end) as sl,sum(case when l.leave_id=3 and l.leave_process_id =1 then l.leave_days else 0 end) as el,sum(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_days else 0 end) as  lop,to_char(to_date(m.discont_dt)) as res_dat from employee_master e, employ_leave_dtl l, employee_master_dtl m ,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fd & " and e.emp_code=m.emp_code and to_char(to_date(m.discont_dt),'MM/YYYY')=to_char(to_date(' " & Request.QueryString("tdt") & "'),'MM/YYYY') and m.new_empcode is null and to_date(m.discont_dt)<=' " & Request.QueryString("tdt") & "' and e.emp_code=l.emp_code and l.leave_frdate>=' " & Request.QueryString("fdt") & "' and l.leave_todate<=' " & Request.QueryString("tdt") & "' and e.emp_code>9999 and e.shift_id not in (4,5) and e.status_id=5 and e.emp_code between " & Request.QueryString("lf") & " and " & Request.QueryString("lt") & " group by e.emp_code,e.emp_name,m.discont_dt order by e.emp_code").Tables(0)
            End If


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
                    Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell


                    '//E_Code
                    v2.ColumnSpan = 1
                    v2.HorizontalAlign = HorizontalAlign.Left
                    v2.Text = "<font size=2>" & dr(0) & "</font>"
                    value.Controls.Add(v2)

                    '///E_Name
                    v3.ColumnSpan = 1
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & dr(1) & "</font>"
                    value.Controls.Add(v3)


                    '///C/L
                    v5.ColumnSpan = 1
                    v5.HorizontalAlign = HorizontalAlign.Center
                    v5.Text = "<font size=2 color=navy>" & dr(2) & "</font>"
                    value.Controls.Add(v5)

                    '//S/L
                    v6.ColumnSpan = 1
                    v6.HorizontalAlign = HorizontalAlign.Center
                    v6.Text = "<font size=2 color=navy>" & dr(3) & "</font>"
                    value.Controls.Add(v6)

                    '///Earned Leave
                    v7.ColumnSpan = 1
                    v7.HorizontalAlign = HorizontalAlign.Center
                    v7.Text = "<font size=2 color=navy>" & dr(4) & "</font>"
                    value.Controls.Add(v7)

                    '///////LOP
                    v8.ColumnSpan = 1
                    v8.HorizontalAlign = HorizontalAlign.Center
                    v8.Text = "<font size=2 color=blue>" & dr(5) & "</font>"
                    value.Controls.Add(v8)

                    v4.ColumnSpan = 1
                    v4.HorizontalAlign = HorizontalAlign.Left
                    v4.Text = "<font size=2><u>" & dr(6) & "</u></font>"
                    value.Controls.Add(v4)

                    '///////Leave_Fro_date
                    v9.ColumnSpan = 3
                    v9.HorizontalAlign = HorizontalAlign.Left
                    v9.Text = " "
                    value.Controls.Add(v9)

                    '///////Leave_TO_date
                    v10.ColumnSpan = 3
                    v10.HorizontalAlign = HorizontalAlign.Left
                    v10.Text = ""
                    value.Controls.Add(v10)

                    '///////Reason
                    v11.ColumnSpan = 2
                    v11.HorizontalAlign = HorizontalAlign.Left
                    v11.Text = ""
                    value.Controls.Add(v11)

                    lo_leavetable.Controls.Add(value)

                    str2 = "select to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_frdate end) as fdt ,to_char(case when l.leave_id=4 and l.leave_process_id=1 then l.leave_todate end) as tdt,case when l.leave_id=4 and l.leave_process_id=1 then l.leave_reason end as reas from employ_leave_dtl l where l.emp_code=" & dr(0) & " and l.leave_frdate>='" & Request.QueryString("fdt") & "' and l.leave_todate<='" & Request.QueryString("tdt") & "' and l.leave_process_id=1 "

                    dt1 = oh.ExecuteDataSet(str2).Tables(0)

                    If dt1.Rows.Count > 0 Then

                        For Each dr1 In dt1.Rows
                            If IsDBNull(dr1(0)) Then

                            Else
                                Dim valueq As New TableRow
                                Dim vq1, vq2, vq3, vq4, vq5, vq6, vq7, vq8, vq9, vq10, vq11 As New TableCell


                                '//E_Code
                                vq2.ColumnSpan = 1
                                vq2.HorizontalAlign = HorizontalAlign.Left
                                vq2.Text = " "
                                valueq.Controls.Add(vq2)

                                '///E_Name
                                vq3.ColumnSpan = 1
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
                                vq7.ColumnSpan = 1
                                vq7.HorizontalAlign = HorizontalAlign.Center
                                vq7.Text = " "
                                valueq.Controls.Add(vq7)

                                '/LOP
                                vq8.ColumnSpan = 1
                                vq8.HorizontalAlign = HorizontalAlign.Center
                                vq8.Text = " "
                                valueq.Controls.Add(vq8)
                                '///
                                vq4.ColumnSpan = 1
                                vq4.HorizontalAlign = HorizontalAlign.Left
                                vq4.Text = " "
                                valueq.Controls.Add(vq4)
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
                                vq11.ColumnSpan = 2
                                vq11.HorizontalAlign = HorizontalAlign.Left
                                vq11.Text = "<font size=2>&nbsp;" & dr1(2) & "&nbsp;</font>"
                                valueq.Controls.Add(vq11)


                                lo_leavetable.Controls.Add(valueq)
                            End If


                        Next

                    Else
                        Dim lin215 As New TableRow
                        Dim lin216 As New TableCell
                        lin216.ColumnSpan = 16
                        lin216.Text = "<font size=4><HR></font>"
                        lin215.Controls.Add(lin216)
                        lo_leavetable.Controls.Add(lin215)
                    End If

                Next


            End If

            Dim lin5 As New TableRow
            Dim lin6 As New TableCell
            lin6.ColumnSpan = 16
            lin6.Text = "<font size=4 color=NAVY>TOTAL EMPLOYEE-" & i & "</font>"
            lin5.Controls.Add(lin6)
            lo_leavetable.Controls.Add(lin5)

            Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
        End If
        If (Request.QueryString("st") = 6) Then
            Dim dt, dt1 As New DataTable
            Dim dr As DataRow
            Dim dr1 As DataRow
            Dim sql, str1, str2 As String

            Dim lo_leavetable As New Table

            Dim i As Integer = 0


            lo_leavetable.Attributes.Add("width", "100%")
            Dim header As New TableRow
            header.Width = 10
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 10
            headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headcell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headcell)
            lo_leavetable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 10
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 10
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            lo_leavetable.Controls.Add(sheader)


            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 10
            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 3
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 4
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 3
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)

            lo_leavetable.Controls.Add(subh)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 10
            pheadercell.ColumnSpan = 10
            pheadercell.HorizontalAlign = HorizontalAlign.Center

            pheadercell.Text = "<body align=center ><b><font size=3> Long Leave Report Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
            pheader.Controls.Add(pheadercell)
            lo_leavetable.Controls.Add(pheader)

            Dim pheaderq As New TableRow
            Dim pheadercellq As New TableCell
            pheaderq.Width = 10
            pheadercellq.ColumnSpan = 10
            pheadercellq.HorizontalAlign = HorizontalAlign.Center

            pheadercellq.Text = "<body align=center ><b><font size=3> From Employee Code " & Request.QueryString("lf") & " To " & Request.QueryString("lt") & "</font></b>"
            pheaderq.Controls.Add(pheadercellq)
            lo_leavetable.Controls.Add(pheaderq)

            Dim line1 As New TableRow
            Dim linecell1 As New TableCell
            line1.Width = 10
            linecell1.ColumnSpan = 10
            linecell1.Text = "<hr>"
            line1.Controls.Add(linecell1)
            lo_leavetable.Controls.Add(line1)

            Dim colors As String



            Dim field As New TableRow
            field.Width = 10
            'field.Attributes.Add("bgcolor", colors)
            Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell

            'f1.ColumnSpan = 1
            'f1.HorizontalAlign = HorizontalAlign.Center
            'f1.Text = "<b><font size=2>Si No</font></b>"
            'field.Controls.Add(f1)

            f2.ColumnSpan = 1
            f2.HorizontalAlign = HorizontalAlign.Center
            f2.Text = "<b><font size=2>Emp&nbsp;Code</font></b>"
            field.Controls.Add(f2)

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Center
            f3.Text = "<b><font size=2>Emp&nbsp;Name</font></b>"
            field.Controls.Add(f3)

            fll.ColumnSpan = 1
            fll.HorizontalAlign = HorizontalAlign.Center
            fll.Text = "<b><font size=2>Long Leave from</font></b>"
            field.Controls.Add(fll)

            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Center
            f4.Text = "<b><font size=2>C/L</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Center
            f5.Text = "<b><font size=2>S/L</font></b>"
            field.Controls.Add(f5)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Center
            f6.Text = "<b><font size=2>E/L</font></b>"
            field.Controls.Add(f6)

            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Center
            f7.Text = "<b><font size=2>L.O.P</font></b>"
            field.Controls.Add(f7)

            f8.ColumnSpan = 1
            f8.HorizontalAlign = HorizontalAlign.Center
            f8.Text = "<b><font size=2>Leave&nbsp;From</font></b>"
            field.Controls.Add(f8)

            f9.ColumnSpan = 1
            f9.HorizontalAlign = HorizontalAlign.Center
            f9.Text = "<b><font size=2>Leave&nbsp;To</font></b>"
            field.Controls.Add(f9)

            f10.ColumnSpan = 1
            f10.HorizontalAlign = HorizontalAlign.Center
            f10.Text = "<b><font size=2>Reason</font></b>"
            field.Controls.Add(f10)

            lo_leavetable.Controls.Add(field)

            Dim linek As New TableRow
            Dim linecellk As New TableCell
            linek.Width = 10
            linecellk.ColumnSpan = 10
            linecellk.Text = "<hr>"
            linek.Controls.Add(linecellk)
            lo_leavetable.Controls.Add(linek)



            If Me.Request.QueryString("a") = 3 Then
                '                  0           1           2                   3                                     4                                  5                                              6                     
                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1 else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Lop from employee_master em,employee_master_dtl ed,employ_transfer_dtl et,employ_leave_dtl el where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and em.emp_code=el.emp_code and el.leave_process_id=1 and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"
                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_firm f,employ_transfer_dtl et,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and  ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.emp_code =f.emp_code and f.firm_id=" & fd & " and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"

            ElseIf Me.Request.QueryString("a") = 1 Then

                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Lop from employee_master em,employee_master_dtl ed,employ_transfer_dtl et,employ_leave_dtl el where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and em.emp_code=el.emp_code and el.leave_process_id=1 and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=1 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"
                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_firm f,employ_transfer_dtl et,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "')and et.emp_code =f.emp_code and f.firm_id=" & fd & " and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=1 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"

            ElseIf Me.Request.QueryString("a") = 2 Then

                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Lop from employee_master em,employee_master_dtl ed,employ_transfer_dtl et,employ_leave_dtl el where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and em.emp_code=el.emp_code and el.leave_process_id=1 and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=2 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"
                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_firm f,employ_transfer_dtl et,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "')and et.emp_code =f.emp_code and f.firm_id=" & fd & " and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=2 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"

            End If
            dt = oh.ExecuteDataSet(str1).Tables(0)
            If dt.Rows.Count = 0 Then
                Dim line1d As New TableRow
                Dim linecell1d As New TableCell
                line1d.Width = 10
                linecell1d.ColumnSpan = 10
                linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
                line1d.Controls.Add(linecell1d)
                lo_leavetable.Controls.Add(line1d)
            Else

                For Each dr In dt.Rows

                    i += 1


                    Dim value As New TableRow
                    value.Width = 10
                    Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell
                    value.Attributes.Add("bgcolor", colors)

                    '//SI no
                    'v1.ColumnSpan = 1
                    'v1.HorizontalAlign = HorizontalAlign.Center
                    'v1.Text = "<font size=2>" & i & "</font>"
                    'value.Controls.Add(v1)

                    '//E_Code
                    v2.ColumnSpan = 1
                    v2.HorizontalAlign = HorizontalAlign.Left
                    v2.Text = "<font size=2>" & dr(0) & "</font>"
                    value.Controls.Add(v2)

                    '///E_Name
                    v3.ColumnSpan = 1
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & dr(1) & "</font>"
                    value.Controls.Add(v3)

                    '///Long_Leave From
                    v4.ColumnSpan = 1
                    v4.HorizontalAlign = HorizontalAlign.Left
                    v4.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "</font>"
                    value.Controls.Add(v4)

                    '///C/L
                    v5.ColumnSpan = 1
                    v5.HorizontalAlign = HorizontalAlign.Left
                    v5.Text = "<font size=2>" & dr(3) & "</font>"
                    value.Controls.Add(v5)

                    '//S/L
                    v6.ColumnSpan = 1
                    v6.HorizontalAlign = HorizontalAlign.Left
                    v6.Text = "<font size=2>" & dr(4) & "</font>"
                    value.Controls.Add(v6)

                    '///Earned Leave
                    v7.ColumnSpan = 1
                    v7.HorizontalAlign = HorizontalAlign.Left
                    v7.Text = "<font size=2>" & dr(5) & "</font>"
                    value.Controls.Add(v7)

                    '///////LOP
                    v8.ColumnSpan = 1
                    v8.HorizontalAlign = HorizontalAlign.Left
                    v8.Text = "<font size=2>" & dr(6) & "</font>"
                    value.Controls.Add(v8)

                    '///////Leave_Fro_date
                    v9.ColumnSpan = 1
                    v9.HorizontalAlign = HorizontalAlign.Left
                    v9.Text = " "
                    value.Controls.Add(v9)

                    '///////Leave_TO_date
                    v10.ColumnSpan = 1
                    v10.HorizontalAlign = HorizontalAlign.Left
                    v10.Text = " "
                    value.Controls.Add(v10)

                    '///////Reason'////////
                    v11.ColumnSpan = 1
                    v11.HorizontalAlign = HorizontalAlign.Left
                    v11.Text = " "
                    value.Controls.Add(v11)

                    lo_leavetable.Controls.Add(value)


                    str2 = "select el.leave_frdate,el.leave_todate,el.leave_reason from employ_leave_dtl el where el.leave_id = 4 and el.leave_process_id = 1 And el.emp_code =" & dr(0) & ""

                    dt1 = oh.ExecuteDataSet(str2).Tables(0)

                    If dt1.Rows.Count > 0 Then

                        For Each dr1 In dt1.Rows

                            'If colors.Equals("#fff7ff") = True Then
                            '    colors = "#eef9ff"
                            'Else
                            '    colors = "#fff7ff"
                            'End If

                            Dim valueq As New TableRow
                            valueq.Width = 10
                            Dim vq1, vq2, vq3, vq4, vq5, vq6, vq7, vq8, vq9, vq10, vq11 As New TableCell
                            valueq.Attributes.Add("bgcolor", colors)


                            '//SI no
                            'vq1.ColumnSpan = 1
                            'vq1.HorizontalAlign = HorizontalAlign.Center
                            'vq1.Text = " "
                            'valueq.Controls.Add(vq1)

                            '//E_Code
                            vq2.ColumnSpan = 1
                            vq2.HorizontalAlign = HorizontalAlign.Left
                            vq2.Text = " "
                            valueq.Controls.Add(vq2)

                            '///E_Name
                            vq3.ColumnSpan = 1
                            vq3.HorizontalAlign = HorizontalAlign.Left
                            vq3.Text = " "
                            valueq.Controls.Add(vq3)

                            '///Long_Leave From
                            vq4.ColumnSpan = 1
                            vq4.HorizontalAlign = HorizontalAlign.Left
                            vq4.Text = " "
                            valueq.Controls.Add(vq4)

                            '///C/L
                            vq5.ColumnSpan = 1
                            vq5.HorizontalAlign = HorizontalAlign.Left
                            vq5.Text = " "
                            valueq.Controls.Add(vq5)

                            '//S/L
                            vq6.ColumnSpan = 1
                            vq6.HorizontalAlign = HorizontalAlign.Center
                            vq6.Text = " "
                            valueq.Controls.Add(vq6)

                            '///Earned
                            vq7.ColumnSpan = 1
                            vq7.HorizontalAlign = HorizontalAlign.Center
                            vq7.Text = " "
                            valueq.Controls.Add(vq7)

                            '/LOP
                            vq8.ColumnSpan = 1
                            vq8.HorizontalAlign = HorizontalAlign.Center
                            vq8.Text = " "
                            valueq.Controls.Add(vq8)

                            '///Leave_from_date
                            vq9.ColumnSpan = 1
                            vq9.HorizontalAlign = HorizontalAlign.Left
                            vq9.Text = "<font size=2>" & Format(dr1(0), "dd/MMM/yyyy") & "&nbsp;</font>"
                            valueq.Controls.Add(vq9)

                            '///Leave_to_date
                            vq10.ColumnSpan = 1
                            vq10.HorizontalAlign = HorizontalAlign.Left
                            vq10.Text = "<font size=2>" & Format(dr1(1), "dd/MMM/yyyy") & "&nbsp;</font>"
                            valueq.Controls.Add(vq10)

                            '////Leave_Reason
                            vq11.ColumnSpan = 1
                            vq11.HorizontalAlign = HorizontalAlign.Left
                            vq11.Text = "<font size=2>" & dr1(2) & "</font>"
                            valueq.Controls.Add(vq11)

                            lo_leavetable.Controls.Add(valueq)

                        Next

                    End If

                Next

                Dim tline23 As New TableRow
                tline23.Width = 10
                Dim tcellline233 As New TableCell
                tcellline233.ColumnSpan = 10
                tcellline233.HorizontalAlign = HorizontalAlign.Left
                tcellline233.Text = "<b><font size=2>Total:" & i & "&nbsp;Employees</font></b>"
                tline23.Controls.Add(tcellline233)

                lo_leavetable.Controls.Add(tline23)


            End If

            Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
        End If

        If (Request.QueryString("st") = 4) Then

            Dim dt, dt1 As New DataTable
            Dim dr As DataRow
            Dim dr1 As DataRow
            Dim sql, str1, str2 As String

            Dim lo_leavetable As New Table

            Dim i As Integer = 0

            lo_leavetable.Attributes.Add("width", "100%")
            Dim header As New TableRow
            header.Width = 10
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 10
            headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headcell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headcell)
            lo_leavetable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 10
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 10
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            lo_leavetable.Controls.Add(sheader)


            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 10
            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 3
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 4
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 3
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)

            lo_leavetable.Controls.Add(subh)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 10
            pheadercell.ColumnSpan = 10
            pheadercell.HorizontalAlign = HorizontalAlign.Center

            pheadercell.Text = "<body align=center ><b><font size=3> LOP and Other Leave Details of Suspended Employees Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
            pheader.Controls.Add(pheadercell)
            lo_leavetable.Controls.Add(pheader)

            Dim pheaderq As New TableRow
            Dim pheadercellq As New TableCell
            pheaderq.Width = 10
            pheadercellq.ColumnSpan = 10
            pheadercellq.HorizontalAlign = HorizontalAlign.Center

            pheadercellq.Text = "<body align=center ><b><font size=3> From Employee Code " & Request.QueryString("lf") & " To " & Request.QueryString("lt") & "</font></b>"
            pheaderq.Controls.Add(pheadercellq)
            lo_leavetable.Controls.Add(pheaderq)

            Dim line1 As New TableRow
            Dim linecell1 As New TableCell
            line1.Width = 10
            linecell1.ColumnSpan = 10
            linecell1.Text = "<hr>"
            line1.Controls.Add(linecell1)
            lo_leavetable.Controls.Add(line1)

            Dim colors As String



            Dim field As New TableRow
            field.Width = 10
            field.Attributes.Add("bgcolor", colors)
            Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell

            'f1.ColumnSpan = 1
            'f1.HorizontalAlign = HorizontalAlign.Center
            'f1.Text = "<b><font size=2>Si No</font></b>"
            'field.Controls.Add(f1)

            f2.ColumnSpan = 1
            f2.HorizontalAlign = HorizontalAlign.Center
            f2.Text = "<b><font size=2>Emp&nbsp;Code</font></b>"
            field.Controls.Add(f2)

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Center
            f3.Text = "<b><font size=2>Emp&nbsp;Name</font></b>"
            field.Controls.Add(f3)

            fll.ColumnSpan = 1
            fll.HorizontalAlign = HorizontalAlign.Center
            fll.Text = "<b><font size=2>Suspension Date</font></b>"
            field.Controls.Add(fll)

            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Center
            f4.Text = "<b><font size=2>C/L</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Center
            f5.Text = "<b><font size=2>S/L</font></b>"
            field.Controls.Add(f5)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Center
            f6.Text = "<b><font size=2>E/L</font></b>"
            field.Controls.Add(f6)

            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Center
            f7.Text = "<b><font size=2>L.O.P</font></b>"
            field.Controls.Add(f7)

            f8.ColumnSpan = 1
            f8.HorizontalAlign = HorizontalAlign.Center
            f8.Text = "<b><font size=2>Leave&nbsp;From</font></b>"
            field.Controls.Add(f8)

            f9.ColumnSpan = 1
            f9.HorizontalAlign = HorizontalAlign.Center
            f9.Text = "<b><font size=2>Leave&nbsp;To</font></b>"
            field.Controls.Add(f9)

            f10.ColumnSpan = 1
            f10.HorizontalAlign = HorizontalAlign.Center
            f10.Text = "<b><font size=2>Reason</font></b>"
            field.Controls.Add(f10)

            lo_leavetable.Controls.Add(field)

            Dim linek As New TableRow
            Dim linecellk As New TableCell
            linek.Width = 10
            linecellk.ColumnSpan = 10
            linecellk.Text = "<hr>"
            linek.Controls.Add(linecellk)
            lo_leavetable.Controls.Add(linek)



            If Me.Request.QueryString("a") = 3 Then
                '                  0           1           2                   3                                     4                                  5                                              6                     
                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_promotion_dtl ep,employ_firm f, employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and em.emp_code=ep.emp_code and ed.emp_code and f.emp_code  and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and ep.from_dt=ed.discont_dt and ep.to_dt is null and f.firm_id=" & fd & " and ep.status_id=4 and ep.status_id =em.status_id and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt"
                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_transfer_dtl et,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and el.leave_frdate<=ed.discont_dt and  ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"

            ElseIf Me.Request.QueryString("a") = 1 Then

                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_promotion_dtl ep,employ_firm f, employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and ed.emp_code and f.emp_code  and em.emp_code=ep.emp_code  and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and ep.from_dt=ed.discont_dt and f.firm_id=" & fd & " and ep.to_dt is null and ep.status_id=4 and em.emp_type=1 and ep.status_id =em.status_id and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt"
                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_transfer_dtl et,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and el.leave_frdate<=ed.discont_dt and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=1 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"

            ElseIf Me.Request.QueryString("a") = 2 Then

                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Lop from employee_master em,employee_master_dtl ed,employ_transfer_dtl et,employ_leave_dtl el where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and em.emp_code=el.emp_code and el.leave_process_id=1 and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=2 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"
                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_transfer_dtl et,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and el.leave_frdate<=ed.discont_dt and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=2 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"
                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_promotion_dtl ep,employ_firm f, employee_master em left outer join employ_leave_dtl el on(em.emp_code=el.emp_code) where em.emp_code=ed.emp_code and em.emp_code=ep.emp_code and ed.emp_code and f.emp_code  and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and ep.from_dt=ed.discont_dt and f.firm_id=" & fd & " and ep.to_dt is null and ep.status_id=4 and em.emp_type=2 and ep.status_id =em.status_id and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt"
            End If

            dt = oh.ExecuteDataSet(str1).Tables(0)
            If dt.Rows.Count = 0 Then
                Dim line1d As New TableRow
                Dim linecell1d As New TableCell
                line1d.Width = 10
                linecell1d.ColumnSpan = 10
                linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
                line1d.Controls.Add(linecell1d)
                lo_leavetable.Controls.Add(line1d)
            Else

                For Each dr In dt.Rows

                    i += 1


                    Dim value As New TableRow
                    value.Width = 10
                    Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell
                    value.Attributes.Add("bgcolor", colors)

                    '//SI no
                    'v1.ColumnSpan = 1
                    'v1.HorizontalAlign = HorizontalAlign.Center
                    'v1.Text = "<font size=2>" & i & "</font>"
                    'value.Controls.Add(v1)

                    '//E_Code
                    v2.ColumnSpan = 1
                    v2.HorizontalAlign = HorizontalAlign.Left
                    v2.Text = "<font size=2>" & dr(0) & "</font>"
                    value.Controls.Add(v2)

                    '///E_Name
                    v3.ColumnSpan = 1
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & dr(1) & "</font>"
                    value.Controls.Add(v3)

                    '///Long_Leave From
                    v4.ColumnSpan = 1
                    v4.HorizontalAlign = HorizontalAlign.Left
                    v4.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "</font>"
                    value.Controls.Add(v4)

                    '///C/L
                    v5.ColumnSpan = 1
                    v5.HorizontalAlign = HorizontalAlign.Left
                    v5.Text = "<font size=2>" & dr(3) & "</font>"
                    value.Controls.Add(v5)

                    '//S/L
                    v6.ColumnSpan = 1
                    v6.HorizontalAlign = HorizontalAlign.Left
                    v6.Text = "<font size=2>" & dr(4) & "</font>"
                    value.Controls.Add(v6)

                    '///Earned Leave
                    v7.ColumnSpan = 1
                    v7.HorizontalAlign = HorizontalAlign.Left
                    v7.Text = "<font size=2>" & dr(5) & "</font>"
                    value.Controls.Add(v7)

                    '///////LOP
                    v8.ColumnSpan = 1
                    v8.HorizontalAlign = HorizontalAlign.Left
                    v8.Text = "<font size=2>" & dr(6) & "</font>"
                    value.Controls.Add(v8)

                    '///////Leave_Fro_date
                    v9.ColumnSpan = 1
                    v9.HorizontalAlign = HorizontalAlign.Left
                    v9.Text = " "
                    value.Controls.Add(v9)

                    '///////Leave_TO_date
                    v10.ColumnSpan = 1
                    v10.HorizontalAlign = HorizontalAlign.Left
                    v10.Text = " "
                    value.Controls.Add(v10)

                    '///////Reason'////////
                    v11.ColumnSpan = 1
                    v11.HorizontalAlign = HorizontalAlign.Left
                    v11.Text = " "
                    value.Controls.Add(v11)

                    lo_leavetable.Controls.Add(value)

                    str2 = "select el.leave_frdate,el.leave_todate,el.leave_reason from employ_leave_dtl el where el.leave_id = 4 and el.leave_process_id = 1 And el.emp_code =" & dr(0) & ""

                    dt1 = oh.ExecuteDataSet(str2).Tables(0)

                    If dt1.Rows.Count > 0 Then

                        For Each dr1 In dt1.Rows

                            'If colors.Equals("#fff7ff") = True Then
                            '    colors = "#eef9ff"
                            'Else
                            '    colors = "#fff7ff"
                            'End If

                            Dim valueq As New TableRow
                            valueq.Width = 10
                            Dim vq1, vq2, vq3, vq4, vq5, vq6, vq7, vq8, vq9, vq10, vq11 As New TableCell
                            valueq.Attributes.Add("bgcolor", colors)


                            '//SI no
                            'vq1.ColumnSpan = 1
                            'vq1.HorizontalAlign = HorizontalAlign.Center
                            'vq1.Text = " "
                            'valueq.Controls.Add(vq1)

                            '//E_Code
                            vq2.ColumnSpan = 1
                            vq2.HorizontalAlign = HorizontalAlign.Left
                            vq2.Text = " "
                            valueq.Controls.Add(vq2)

                            '///E_Name
                            vq3.ColumnSpan = 1
                            vq3.HorizontalAlign = HorizontalAlign.Left
                            vq3.Text = " "
                            valueq.Controls.Add(vq3)

                            '///Long_Leave From
                            vq4.ColumnSpan = 1
                            vq4.HorizontalAlign = HorizontalAlign.Left
                            vq4.Text = " "
                            valueq.Controls.Add(vq4)

                            '///C/L
                            vq5.ColumnSpan = 1
                            vq5.HorizontalAlign = HorizontalAlign.Left
                            vq5.Text = " "
                            valueq.Controls.Add(vq5)

                            '//S/L
                            vq6.ColumnSpan = 1
                            vq6.HorizontalAlign = HorizontalAlign.Center
                            vq6.Text = " "
                            valueq.Controls.Add(vq6)

                            '///Earned
                            vq7.ColumnSpan = 1
                            vq7.HorizontalAlign = HorizontalAlign.Center
                            vq7.Text = " "
                            valueq.Controls.Add(vq7)

                            '/LOP
                            vq8.ColumnSpan = 1
                            vq8.HorizontalAlign = HorizontalAlign.Center
                            vq8.Text = " "
                            valueq.Controls.Add(vq8)

                            '///Leave_from_date
                            vq9.ColumnSpan = 1
                            vq9.HorizontalAlign = HorizontalAlign.Left
                            vq9.Text = "<font size=2>" & Format(dr1(0), "dd/MMM/yyyy") & "&nbsp;</font>"
                            valueq.Controls.Add(vq9)

                            '///Leave_to_date
                            vq10.ColumnSpan = 1
                            vq10.HorizontalAlign = HorizontalAlign.Left
                            vq10.Text = "<font size=2>" & Format(dr1(1), "dd/MMM/yyyy") & "&nbsp;</font>"
                            valueq.Controls.Add(vq10)

                            '////Leave_Reason
                            vq11.ColumnSpan = 1
                            vq11.HorizontalAlign = HorizontalAlign.Left
                            vq11.Text = "<font size=2>" & dr1(2) & "</font>"
                            valueq.Controls.Add(vq11)

                            lo_leavetable.Controls.Add(valueq)

                        Next

                    End If

                Next
                Dim bline As New TableRow
                bline.Width = 10
                Dim bline1 As New TableCell
                bline1.ColumnSpan = 10
                bline1.Text = "<hr>"
                bline.Controls.Add(bline1)

                lo_leavetable.Controls.Add(bline)

                Dim tline23 As New TableRow
                tline23.Width = 10
                Dim tcellline233 As New TableCell
                tcellline233.ColumnSpan = 10
                tcellline233.HorizontalAlign = HorizontalAlign.Left
                tcellline233.Text = "<b><font size=2>Total:" & i & "&nbsp;Employees</font></b>"
                tline23.Controls.Add(tcellline233)

                lo_leavetable.Controls.Add(tline23)


            End If

            Pan_Sal_Long_Leave.Controls.Add(lo_leavetable)
        End If
        If (Request.QueryString("st") = 10) Then
            Dim dr As DataRow
            Dim dr1 As DataRow
            Dim maternity_table As New Table

            Dim i As Integer = 0

            maternity_table.Attributes.Add("width", "100%")
            Dim header As New TableRow
            header.Width = 10
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 10
            headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headcell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headcell)
            maternity_table.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 10
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 10
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            maternity_table.Controls.Add(sheader)


            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 10
            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 3
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 4
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 3
            subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subh.Controls.Add(subcell3)

            maternity_table.Controls.Add(subh)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 10
            pheadercell.ColumnSpan = 10
            pheadercell.HorizontalAlign = HorizontalAlign.Center

            pheadercell.Text = "<body align=center ><b><font size=3> LOP and Other Leave Details of Maternity Employees Between  " & Request.QueryString("fdt") & " and " & Request.QueryString("tdt") & " </font></b>"
            pheader.Controls.Add(pheadercell)
            maternity_table.Controls.Add(pheader)

            Dim pheaderq As New TableRow
            Dim pheadercellq As New TableCell
            pheaderq.Width = 10
            pheadercellq.ColumnSpan = 10
            pheadercellq.HorizontalAlign = HorizontalAlign.Center

            pheadercellq.Text = "<body align=center ><b><font size=3> From Employee Code " & Request.QueryString("lf") & " To " & Request.QueryString("lt") & "</font></b>"
            pheaderq.Controls.Add(pheadercellq)
            maternity_table.Controls.Add(pheaderq)

            Dim line1 As New TableRow
            Dim linecell1 As New TableCell
            line1.Width = 10
            linecell1.ColumnSpan = 10
            linecell1.Text = "<hr>"
            line1.Controls.Add(linecell1)
            maternity_table.Controls.Add(line1)

            'Dim colors As String
            'colors = "#fff7ff"


            Dim field As New TableRow
            field.Width = 10
            'field.Attributes.Add("bgcolor", colors)
            Dim f1, f2, f3, fll, f4, f5, f6, f7, f8, f9, f10 As New TableCell

            'f1.ColumnSpan = 1
            'f1.HorizontalAlign = HorizontalAlign.Center
            'f1.Text = "<b><font size=2>Si No</font></b>"
            'field.Controls.Add(f1)

            f2.ColumnSpan = 1
            f2.HorizontalAlign = HorizontalAlign.Center
            f2.Text = "<b><font size=2>Emp&nbsp;Code</font></b>"
            field.Controls.Add(f2)

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Center
            f3.Text = "<b><font size=2>Emp&nbsp;Name</font></b>"
            field.Controls.Add(f3)

            fll.ColumnSpan = 1
            fll.HorizontalAlign = HorizontalAlign.Center
            fll.Text = "<b><font size=2>Maternity Date</font></b>"
            field.Controls.Add(fll)

            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Center
            f4.Text = "<b><font size=2>C/L</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Center
            f5.Text = "<b><font size=2>S/L</font></b>"
            field.Controls.Add(f5)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Center
            f6.Text = "<b><font size=2>E/L</font></b>"
            field.Controls.Add(f6)

            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Center
            f7.Text = "<b><font size=2>L.O.P</font></b>"
            field.Controls.Add(f7)

            f8.ColumnSpan = 1
            f8.HorizontalAlign = HorizontalAlign.Center
            f8.Text = "<b><font size=2>Leave&nbsp;From</font></b>"
            field.Controls.Add(f8)

            f9.ColumnSpan = 1
            f9.HorizontalAlign = HorizontalAlign.Center
            f9.Text = "<b><font size=2>Leave&nbsp;To</font></b>"
            field.Controls.Add(f9)

            f10.ColumnSpan = 1
            f10.HorizontalAlign = HorizontalAlign.Center
            f10.Text = "<b><font size=2>Reason</font></b>"
            field.Controls.Add(f10)

            maternity_table.Controls.Add(field)

            Dim linek As New TableRow
            Dim linecellk As New TableCell
            linek.Width = 10
            linecellk.ColumnSpan = 10
            linecellk.Text = "<hr>"
            linek.Controls.Add(linecellk)
            maternity_table.Controls.Add(linek)



            If Me.Request.QueryString("a") = 3 Then
                '                  0           1           2                   3                                     4                                  5                                              6                     
                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1 else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Lop from employee_master em,employee_master_dtl ed,employ_transfer_dtl et,employ_leave_dtl el where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and em.emp_code=el.emp_code and el.leave_process_id=1 and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"
                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_transfer_dtl et,employ_firm f,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and f.firm_id=" & fd & " and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=10 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"

            ElseIf Me.Request.QueryString("a") = 1 Then

                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Lop from employee_master em,employee_master_dtl ed,employ_transfer_dtl et,employ_leave_dtl el where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and em.emp_code=el.emp_code and el.leave_process_id=1 and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=1 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"
                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_transfer_dtl et,employ_firm f,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and f.firm_id=" & fd & " and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=10 and em.emp_type=1 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"

            ElseIf Me.Request.QueryString("a") = 2 Then

                'str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then (el.leave_todate-el.leave_frdate)+1  else 0 end) as Lop from employee_master em,employee_master_dtl ed,employ_transfer_dtl et,employ_leave_dtl el where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and em.emp_code=el.emp_code and el.leave_process_id=1 and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=6 and em.emp_type=2 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"
                str1 = "select em.emp_code,em.emp_name,ed.discont_dt,sum(case when el.leave_id=1 and el.leave_process_id=1 then el.leave_days else 0 end) as Casual,sum(case when el.leave_id=2 and el.leave_process_id=1 then el.leave_days else 0 end )as Sick,sum(case when el.leave_id=3 and el.leave_process_id=1 then el.leave_days else 0 end) as Earned,sum(case when el.leave_id=4 and el.leave_process_id=1 then el.leave_days else 0 end) as Lop from employee_master_dtl ed,employ_transfer_dtl et,employ_firm f,employee_master em left outer join employ_leave_dtl el on(el.emp_code=em.emp_code) where em.emp_code=ed.emp_code and em.emp_code=et.emp_code and f.firm_id=" & fd & " and ed.discont_dt>=to_date('" & Request.QueryString("fdt") & "') and ed.discont_dt<=to_date('" & Request.QueryString("tdt") & "') and et.from_dt=ed.discont_dt and et.to_dt is null and et.status_id=10 and em.emp_type=2 and em.emp_code>=" & Me.Request.QueryString("lf") & " and em.emp_code<=" & Me.Request.QueryString("lt") & " group by em.emp_code,em.emp_name,ed.discont_dt order by em.emp_code"

            End If
            dt = oh.ExecuteDataSet(str1).Tables(0)
            If dt.Rows.Count = 0 Then
                Dim line1d As New TableRow
                Dim linecell1d As New TableCell
                line1d.Width = 10
                linecell1d.ColumnSpan = 10
                linecell1d.Text = "<b> No Employees Found !! Or Check whether You entered Correct information!!"
                line1d.Controls.Add(linecell1d)
                maternity_table.Controls.Add(line1d)
            Else

                For Each dr In dt.Rows

                    i += 1

                    ' If colors.Equals("#fff7ff") = True Then
                    ' colors = "#eef9ff"
                    'Else
                    '  colors = "#fff7ff"
                    '  End If

                    Dim value As New TableRow
                    value.Width = 10
                    Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell
                    'value.Attributes.Add("bgcolor", colors)

                    '//SI no
                    'v1.ColumnSpan = 1
                    'v1.HorizontalAlign = HorizontalAlign.Center
                    'v1.Text = "<font size=2>" & i & "</font>"
                    'value.Controls.Add(v1)

                    '//E_Code
                    v2.ColumnSpan = 1
                    v2.HorizontalAlign = HorizontalAlign.Left
                    v2.Text = "<font size=2>" & dr(0) & "</font>"
                    value.Controls.Add(v2)

                    '///E_Name
                    v3.ColumnSpan = 1
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & dr(1) & "</font>"
                    value.Controls.Add(v3)

                    '///Long_Leave From
                    v4.ColumnSpan = 1
                    v4.HorizontalAlign = HorizontalAlign.Left
                    v4.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "</font>"
                    value.Controls.Add(v4)

                    '///C/L
                    v5.ColumnSpan = 1
                    v5.HorizontalAlign = HorizontalAlign.Left
                    v5.Text = "<font size=2>" & dr(3) & "</font>"
                    value.Controls.Add(v5)

                    '//S/L
                    v6.ColumnSpan = 1
                    v6.HorizontalAlign = HorizontalAlign.Left
                    v6.Text = "<font size=2>" & dr(4) & "</font>"
                    value.Controls.Add(v6)

                    '///Earned Leave
                    v7.ColumnSpan = 1
                    v7.HorizontalAlign = HorizontalAlign.Left
                    v7.Text = "<font size=2>" & dr(5) & "</font>"
                    value.Controls.Add(v7)

                    '///////LOP
                    v8.ColumnSpan = 1
                    v8.HorizontalAlign = HorizontalAlign.Left
                    v8.Text = "<font size=2>" & dr(6) & "</font>"
                    value.Controls.Add(v8)

                    '///////Leave_Fro_date
                    v9.ColumnSpan = 1
                    v9.HorizontalAlign = HorizontalAlign.Left
                    v9.Text = " "
                    value.Controls.Add(v9)

                    '///////Leave_TO_date
                    v10.ColumnSpan = 1
                    v10.HorizontalAlign = HorizontalAlign.Left
                    v10.Text = " "
                    value.Controls.Add(v10)

                    '///////Reason'////////
                    v11.ColumnSpan = 1
                    v11.HorizontalAlign = HorizontalAlign.Left
                    v11.Text = " "
                    value.Controls.Add(v11)

                    maternity_table.Controls.Add(value)

                    str2 = "select el.leave_frdate,el.leave_todate,el.leave_reason from employ_leave_dtl el where el.leave_id = 4 and el.leave_process_id = 1 And el.emp_code =" & dr(0) & ""

                    dt1 = oh.ExecuteDataSet(str2).Tables(0)

                    If dt1.Rows.Count > 0 Then

                        For Each dr1 In dt1.Rows

                            'If colors.Equals("#fff7ff") = True Then
                            '    colors = "#eef9ff"
                            'Else
                            '    colors = "#fff7ff"
                            'End If

                            Dim valueq As New TableRow
                            valueq.Width = 10
                            Dim vq1, vq2, vq3, vq4, vq5, vq6, vq7, vq8, vq9, vq10, vq11 As New TableCell
                            ' valueq.Attributes.Add("bgcolor", colors)


                            '//SI no
                            'vq1.ColumnSpan = 1
                            'vq1.HorizontalAlign = HorizontalAlign.Center
                            'vq1.Text = " "
                            'valueq.Controls.Add(vq1)

                            '//E_Code
                            vq2.ColumnSpan = 1
                            vq2.HorizontalAlign = HorizontalAlign.Left
                            vq2.Text = " "
                            valueq.Controls.Add(vq2)

                            '///E_Name
                            vq3.ColumnSpan = 1
                            vq3.HorizontalAlign = HorizontalAlign.Left
                            vq3.Text = " "
                            valueq.Controls.Add(vq3)

                            '///Long_Leave From
                            vq4.ColumnSpan = 1
                            vq4.HorizontalAlign = HorizontalAlign.Left
                            vq4.Text = " "
                            valueq.Controls.Add(vq4)

                            '///C/L
                            vq5.ColumnSpan = 1
                            vq5.HorizontalAlign = HorizontalAlign.Left
                            vq5.Text = " "
                            valueq.Controls.Add(vq5)

                            '//S/L
                            vq6.ColumnSpan = 1
                            vq6.HorizontalAlign = HorizontalAlign.Center
                            vq6.Text = " "
                            valueq.Controls.Add(vq6)

                            '///Earned
                            vq7.ColumnSpan = 1
                            vq7.HorizontalAlign = HorizontalAlign.Center
                            vq7.Text = " "
                            valueq.Controls.Add(vq7)

                            '/LOP
                            vq8.ColumnSpan = 1
                            vq8.HorizontalAlign = HorizontalAlign.Center
                            vq8.Text = " "
                            valueq.Controls.Add(vq8)

                            '///Leave_from_date
                            vq9.ColumnSpan = 1
                            vq9.HorizontalAlign = HorizontalAlign.Left
                            vq9.Text = "<font size=2>" & Format(dr1(0), "dd/MMM/yyyy") & "&nbsp;</font>"
                            valueq.Controls.Add(vq9)

                            '///Leave_to_date
                            vq10.ColumnSpan = 1
                            vq10.HorizontalAlign = HorizontalAlign.Left
                            vq10.Text = "<font size=2>" & Format(dr1(1), "dd/MMM/yyyy") & "&nbsp;</font>"
                            valueq.Controls.Add(vq10)

                            '////Leave_Reason
                            vq11.ColumnSpan = 1
                            vq11.HorizontalAlign = HorizontalAlign.Left
                            vq11.Text = "<font size=2>" & dr1(2) & "</font>"
                            valueq.Controls.Add(vq11)

                            maternity_table.Controls.Add(valueq)

                        Next

                    End If

                Next
                Dim bline As New TableRow
                bline.Width = 10
                Dim bline1 As New TableCell
                bline1.ColumnSpan = 10
                bline1.Text = "<hr>"
                bline.Controls.Add(bline1)

                maternity_table.Controls.Add(bline)

                Dim tline23 As New TableRow
                tline23.Width = 10
                Dim tcellline233 As New TableCell
                tcellline233.ColumnSpan = 10
                tcellline233.HorizontalAlign = HorizontalAlign.Left
                tcellline233.Text = "<b><font size=2>Total:" & i & "&nbsp;Employees</font></b>"
                tline23.Controls.Add(tcellline233)

                maternity_table.Controls.Add(tline23)


            End If

            Pan_Sal_Long_Leave.Controls.Add(maternity_table)
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("salary_lop_live.aspx")
    End Sub
End Class
