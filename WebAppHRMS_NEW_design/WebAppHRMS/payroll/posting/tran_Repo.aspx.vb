Imports System.Data
Imports System.Data.OracleClient
Partial Class tran_Repo_cd52ecde1951
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt6, dt11, dt9, dt12, dt8, dt25 As New DataTable
    Dim sql3, sql4, dep, sql5, sql7, sql15 As String
    Dim cas, cast, sic, sict, ear, eart As Integer
    Dim cd As String
    Dim DT27 As DataTable
    Dim sal, tot As String
    Dim oh As New helper.oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frm As Integer = Session("firm_id")
        Dim frr As String = Session("firm_name")
        Dim details, empno, cr_dtl, firm_id As String
        Dim dtls(), cr_dt(), fir(), dd(), dd1() As String
        DT27 = oh.ExecuteDataSet("SELECT F.FIRM_ABBR ,f.firm_address FROM FIrm_MASTER F WHERE F.FIRM_id=" & frm & "").Tables(0)
        details = Request.QueryString.Get("dtl")
        empno = Request.QueryString.Get("no")
        cr_dtl = Request.QueryString.Get("cr_dt")
        firm_id = Request.QueryString.Get("frm")
        dtls = details.ToString.Split("|")
        cr_dt = cr_dtl.ToString.Split("|")
        fir = firm_id.ToString.Split("|")
        dd = dtls(6).ToString.Split("*")

        Dim ddd As Date = cr_dt(5)

        '-------------------Formatting table---------------------------------'
        Dim tb As New Table
        tb.Attributes.Add("width", "100%")
        tb.Attributes.Add("align", "center")
        Dim btr1 As New TableRow
        Dim btd1 As New TableCell
        btd1.Attributes.Add("width", "100%")
        btd1.ColumnSpan = 100
        btd1.HorizontalAlign = HorizontalAlign.Left
        btr1.Controls.Add(btd1)
        tb.Controls.Add(btr1)
        '------------------------------------------------------------------'
        Dim tr As New TableRow
        Dim td As New TableCell
        td.Attributes.Add("width", "100%")
        td.ColumnSpan = 100
        tr.BackColor = Drawing.Color.SeaShell
        td.HorizontalAlign = HorizontalAlign.Center
        td.Text = "<font size=4 color=darkblue><b><u>" & frr & "</font></b></u>"
        tr.Cells.Add(td)
        tb.Controls.Add(tr)
        '-------------------------------------------------------------------'
        Dim tr1 As New TableRow
        Dim td1 As New TableCell
        td1.Attributes.Add("width", "100%")
        td1.ColumnSpan = 100
        td1.HorizontalAlign = HorizontalAlign.Center
        tr1.Controls.Add(td1)
        tb.Controls.Add(tr1)
        '------------------------------------------------------------------'
        Dim tr0 As New TableRow
        Dim td0 As New TableCell
        td0.Attributes.Add("width", "100%")
        td0.ColumnSpan = 100
        td0.HorizontalAlign = HorizontalAlign.Center
        td0.Text = "<font size=3 color=darkblue>" & DT27.Rows(0)(1) & "</font>"
        tr0.Controls.Add(td0)
        tb.Controls.Add(tr0)
        '----------------------------------------------------
        Dim atr1 As New TableRow
        Dim atd1 As New TableCell
        atd1.Attributes.Add("width", "100%")
        atd1.ColumnSpan = 100
        atd1.HorizontalAlign = HorizontalAlign.Center
        atr1.Controls.Add(atd1)
        tb.Controls.Add(atr1)
        '------------------------------------------------------------------'
        Dim tr3 As New TableRow
        Dim td3 As New TableCell
        td3.Attributes.Add("width", "100%")
        td3.ColumnSpan = 100
        td3.HorizontalAlign = HorizontalAlign.Center
        td3.Text = "<font size=4 color=blue> DEPARTMENT OF HUMAN RESOURCE MANAGEMENT </font></b>"
        tr3.Controls.Add(td3)
        tb.Controls.Add(tr3)
        '--------------------------------------------------
        Dim tr4 As New TableRow
        Dim td4 As New TableCell
        td4.Attributes.Add("width", "50")
        td4.ColumnSpan = 25
        td4.HorizontalAlign = HorizontalAlign.Left
        td4.Text = "<font size=3 color=blue>" & Format(Date.Now, "hh:mm:ss") & "</font></b>"
        tr4.Controls.Add(td4)
        tb.Controls.Add(tr4)

        Dim td8 As New TableCell
        td8.Attributes.Add("width", "50%")
        td8.ColumnSpan = 50
        td8.HorizontalAlign = HorizontalAlign.Left
        td8.Text = "<font size=3 > </font>"
        tr4.Controls.Add(td8)
        tb.Controls.Add(tr4)

        Dim td5 As New TableCell
        td5.Attributes.Add("width", "75%")
        td5.ColumnSpan = 75
        td5.HorizontalAlign = HorizontalAlign.Right
        td5.Text = "<font size=3 color=blue>" & Format(Date.Now, "dd/MMM/yyyy") & "  </font></b>"
        tr4.Controls.Add(td5)
        tb.Controls.Add(tr4)
        ''---------------------------------------------------
        Dim tr6 As New TableRow


        Dim td9 As New TableCell
        td9.Attributes.Add("width", "100%")
        td9.ColumnSpan = 100
        td9.HorizontalAlign = HorizontalAlign.Center
        tr6.BackColor = Drawing.Color.SeaShell
        td9.Text = "<font size=4 color=blue><b>DUPLICATE TRANSFER ORDER</b></font>"
        tr6.Controls.Add(td9)
        tb.Controls.Add(tr6)


        ''------------------------------------------------------
        Dim tr5 As New TableRow
        Dim td10 As New TableCell
        tr5.Attributes.Add("width", "100%")
        td10.ColumnSpan = 100
        td10.HorizontalAlign = HorizontalAlign.Center
        td10.Text = "<font size=3 color=darkblue>&nbsp" & empno & "   </font></b>"
        tr5.Controls.Add(td10)
        tb.Controls.Add(tr5)

        ''-------------------------------------------------------

        'Dim atr5 As New TableRow
        'Dim atd10 As New TableCell
        'atr5.Attributes.Add("width", "100%")
        'atd10.ColumnSpan = 100
        'atd10.HorizontalAlign = HorizontalAlign.Center
        'atd10.Text = "<font size=4><HR>  </font></b>"
        'atr5.Controls.Add(atd10)
        'tb.Controls.Add(atr5)

        'Dim atr55 As New TableRow
        'Dim atd11 As New TableCell
        'atd11.Attributes.Add("width", "100%")
        'atd11.ColumnSpan = 50
        'atd11.HorizontalAlign = HorizontalAlign.Left
        'atd11.Text = "<font size=3>&nbsp</font>"
        'atr55.Controls.Add(atd11)
        'tb.Controls.Add(atr55)

        'Dim atd12 As New TableCell
        'atd12.Attributes.Add("width", "100%")
        'atd12.ColumnSpan = 50
        'atd12.HorizontalAlign = HorizontalAlign.Left
        'atd12.Text = "<font size=3 color=darkblue> </font>"
        'atr55.Controls.Add(atd12)
        'tb.Controls.Add(atr55)

        ''-------------------------------------------------------

        Dim tr7 As New TableRow
        Dim td13 As New TableCell
        tr7.Attributes.Add("width", "15%")
        td13.ColumnSpan = 1
        td13.HorizontalAlign = HorizontalAlign.Center
        td13.Text = "<font size=3></font>"
        tr7.Controls.Add(td13)
        tb.Controls.Add(tr7)

        Dim td14 As New TableCell
        td14.Attributes.Add("width", "35%")
        td14.ColumnSpan = 35
        td14.HorizontalAlign = HorizontalAlign.Left
        td14.Text = "<font size=3 color=black><b>Name of employee</b></font>"
        tr7.Controls.Add(td14)
        tb.Controls.Add(tr7)

        Dim td15 As New TableCell
        td15.Attributes.Add("width", "55%")
        td15.ColumnSpan = 55
        td15.HorizontalAlign = HorizontalAlign.Left
        td15.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & cr_dt(0) & "  </font>"
        tr7.Controls.Add(td15)
        tb.Controls.Add(tr7)

        ''-------------------------------------------------------


        Dim atr7 As New TableRow
        Dim atd13 As New TableCell
        atr7.Attributes.Add("width", "15%")
        atd13.ColumnSpan = 1
        atd13.HorizontalAlign = HorizontalAlign.Center
        atd13.Text = "<font size=3>&nbsp  </font>"
        atr7.Controls.Add(atd13)
        tb.Controls.Add(atr7)

        Dim atd14 As New TableCell
        atd14.Attributes.Add("width", "35%")
        atd14.ColumnSpan = 35
        atd14.HorizontalAlign = HorizontalAlign.Left
        atd14.Text = "<font size=3 color=black><b>Employee Code</b> </font>"
        atr7.Controls.Add(atd14)
        tb.Controls.Add(atr7)

        Dim atd15 As New TableCell
        atd15.Attributes.Add("width", "55%")
        atd15.ColumnSpan = 55
        atd15.HorizontalAlign = HorizontalAlign.Left
        atd15.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & dtls(1) & " </font>"
        atr7.Controls.Add(atd15)
        tb.Controls.Add(atr7)

        ''-------------------------------------------------------

        Dim tr8 As New TableRow
        Dim td16 As New TableCell
        tr8.Attributes.Add("width", "15%")
        td16.ColumnSpan = 1
        td16.HorizontalAlign = HorizontalAlign.Center
        td16.Text = "<font size=3>&nbsp  </font>"
        tr8.Controls.Add(td16)
        tb.Controls.Add(tr8)

        Dim td17 As New TableCell
        td17.Attributes.Add("width", "35%")
        td17.ColumnSpan = 35
        td17.HorizontalAlign = HorizontalAlign.Left
        td17.Text = "<font size=3 color=black> <b>Date of Joining the Service </b></font>"
        tr8.Controls.Add(td17)
        tb.Controls.Add(tr8)

        sql3 = "select basic_pay ,emp_type,da_flag from employee_master where emp_code=" & dtls(1) & " and status_id=1 "
        dt3 = oh.ExecuteDataSet(sql3).Tables(0)
        If (dt3.Rows(0)(1) = 2) Then

            Dim sttr As String = Format(ddd, "dd/MMM/yyyy")
            Dim td18 As New TableCell
            td18.Attributes.Add("width", "55%")
            td18.ColumnSpan = 55
            td18.HorizontalAlign = HorizontalAlign.Left
            td18.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & sttr & " </font>"
            tr8.Controls.Add(td18)
            tb.Controls.Add(tr8)
        Else
            'Dim Sql15 As String = "select join_dt from employee_master where join_dt in (select min(join_dt) from employee_master where emp_name like '" & cr_dt(0) & "' ) and emp_name like '" & cr_dt(0) & "'"
            'dt12 = oh.ExecuteDataSet(Sql15).Tables(0)
            ' Dim str As String = Format(dt12.Rows(0)(0), "dd/MMM/yyyy")

            Dim sttr As String = Format(ddd, "dd/MMM/yyyy")
            Dim td18 As New TableCell
            td18.Attributes.Add("width", "55%")
            td18.ColumnSpan = 55
            td18.HorizontalAlign = HorizontalAlign.Left
            td18.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & sttr & " </font>"
            tr8.Controls.Add(td18)
            tb.Controls.Add(tr8)
        End If

        ''-------------------------------------------------------

        Dim tr9 As New TableRow
        Dim td19 As New TableCell
        tr9.Attributes.Add("width", "15%")
        td19.ColumnSpan = 1
        td19.HorizontalAlign = HorizontalAlign.Center
        td19.Text = "<font size=3>&nbsp  </font>"
        tr9.Controls.Add(td19)
        tb.Controls.Add(tr9)

        Dim td20 As New TableCell
        td20.Attributes.Add("width", "35%")
        td20.ColumnSpan = 35
        td20.HorizontalAlign = HorizontalAlign.Left
        td20.Text = "<font size=3 color=black><b>Present Designation</b> </font>"
        tr9.Controls.Add(td20)
        tb.Controls.Add(tr9)

        Dim td21 As New TableCell
        td21.Attributes.Add("width", "55%")
        td21.ColumnSpan = 55
        td21.HorizontalAlign = HorizontalAlign.Left
        td21.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & cr_dt(1) & "  </font>"
        tr9.Controls.Add(td21)
        tb.Controls.Add(tr9)


        ''-------------------------------------------------------

        Dim tr10 As New TableRow
        Dim td22 As New TableCell
        tr10.Attributes.Add("width", "15%")
        td22.ColumnSpan = 1
        td22.HorizontalAlign = HorizontalAlign.Center
        td22.Text = "<font size=3>&nbsp  </font>"
        tr10.Controls.Add(td22)
        tb.Controls.Add(tr10)

        Dim td23 As New TableCell
        td23.Attributes.Add("width", "35%")
        td23.ColumnSpan = 35
        td23.HorizontalAlign = HorizontalAlign.Left
        td23.Text = "<font size=3 color=black><b> Present Branch </b></font>"
        tr10.Controls.Add(td23)
        tb.Controls.Add(tr10)

        Dim td24 As New TableCell
        td24.Attributes.Add("width", "55%")
        td24.ColumnSpan = 55
        td24.HorizontalAlign = HorizontalAlign.Left
        td24.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & cr_dt(4) & "</font>"
        tr10.Controls.Add(td24)
        tb.Controls.Add(tr10)

        ''-------------------------------------------------------

        Dim tr11 As New TableRow
        Dim td25 As New TableCell
        tr11.Attributes.Add("width", "15%")
        td25.ColumnSpan = 1
        td25.HorizontalAlign = HorizontalAlign.Center
        td25.Text = "<font size=3>&nbsp  </font>"
        tr11.Controls.Add(td25)
        tb.Controls.Add(tr11)

        Dim td29 As New TableCell
        td29.Attributes.Add("width", "35%")
        td29.ColumnSpan = 35
        td29.HorizontalAlign = HorizontalAlign.Left
        td29.Text = "<font size=3  color=black><b>Present Department & Post </b> </font>"
        tr11.Controls.Add(td29)
        tb.Controls.Add(tr11)

        Dim td28 As New TableCell
        td28.Attributes.Add("width", "55%")
        td28.ColumnSpan = 55
        td28.HorizontalAlign = HorizontalAlign.Left
        td28.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & cr_dt(3) & "," & cr_dt(2) & " </font>"
        tr11.Controls.Add(td28)
        tb.Controls.Add(tr11)
        ''---------------------------------------------------

        Dim Sql2 As String = "select branch_name from branch_master where branch_id = " & dtls(0) & " "
        dt = oh.ExecuteDataSet(Sql2).Tables(0)
        If dt.Rows.Count = 0 Then
            Sql2 = "select branch_name from before_completion where old_id = " & dtls(0) & " and branch_id is null "
            dt = oh.ExecuteDataSet(Sql2).Tables(0)
        End If
        Dim tr13 As New TableRow
        Dim td27 As New TableCell
        tr13.Attributes.Add("width", "15%")
        td27.ColumnSpan = 1
        td27.HorizontalAlign = HorizontalAlign.Center
        td27.Text = "<font size=3>&nbsp </font>"
        tr13.Controls.Add(td27)
        tb.Controls.Add(tr13)

        Dim td31 As New TableCell
        td31.Attributes.Add("width", "35%")
        td31.ColumnSpan = 35
        td31.HorizontalAlign = HorizontalAlign.Left
        td31.Text = "<font size=3 color=black> <b>Proposed Branch</b></font>"
        tr13.Controls.Add(td31)
        tb.Controls.Add(tr13)

        Dim td34 As New TableCell
        td34.Attributes.Add("width", "55%")
        td34.ColumnSpan = 55
        td34.HorizontalAlign = HorizontalAlign.Left
        td34.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & dt.Rows(0)(0) & " </font>"
        tr13.Controls.Add(td34)
        tb.Controls.Add(tr13)
        ''------------------------------------------------------------
        Dim tr91 As New TableRow
        Dim td191 As New TableCell
        tr91.Attributes.Add("width", "15%")
        td191.ColumnSpan = 1
        td191.HorizontalAlign = HorizontalAlign.Center
        td191.Text = "<font size=3>&nbsp  </font>"
        tr91.Controls.Add(td191)
        tb.Controls.Add(tr91)

        Dim td201 As New TableCell
        td201.Attributes.Add("width", "35%")
        td201.ColumnSpan = 35
        td201.HorizontalAlign = HorizontalAlign.Left
        td201.Text = "<font size=3 color=black><b>Proposed Designation</b> </font>"
        tr91.Controls.Add(td201)
        tb.Controls.Add(tr91)

        Dim td211 As New TableCell
        td211.Attributes.Add("width", "55%")
        td211.ColumnSpan = 55
        td211.HorizontalAlign = HorizontalAlign.Left
        td211.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & cr_dt(1) & "  </font>"
        tr91.Controls.Add(td211)
        tb.Controls.Add(tr91)
        ''-------------------------------------------------------
        Sql2 = "select dep_name from department_mst where dep_id=" & dtls(5) & " "
        dt = oh.ExecuteDataSet(Sql2).Tables(0)
        dep = dt.Rows(0)(0)

        Dim Sql4 As String = "select post_name,post_id from post_mst where post_id=" & dd(0) & ""
        dt1 = oh.ExecuteDataSet(Sql4).Tables(0)

        Dim tr14 As New TableRow
        Dim td36 As New TableCell
        tr14.Attributes.Add("width", "15%")
        td36.ColumnSpan = 1
        td36.HorizontalAlign = HorizontalAlign.Center
        td36.Text = "<font size=3>&nbsp  </font>"
        tr14.Controls.Add(td36)
        tb.Controls.Add(tr14)

        Dim td32 As New TableCell
        td32.Attributes.Add("width", "35%")
        td32.ColumnSpan = 35
        td32.HorizontalAlign = HorizontalAlign.Left
        td32.Text = "<font size=3 color=black><b>Proposed Department & Post</b> </font>"
        tr14.Controls.Add(td32)
        tb.Controls.Add(tr14)


        Dim td35 As New TableCell
        td35.Attributes.Add("width", "55%")
        td35.ColumnSpan = 55
        td35.HorizontalAlign = HorizontalAlign.Left
        td35.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & dep & "&nbsp," & dt1.Rows(0)(0) & " </font>"
        tr14.Controls.Add(td35)
        tb.Controls.Add(tr14)

        ''-------------------------------------------------------

        ''--------------------------------------------------
        Dim tr15 As New TableRow
        Dim td37 As New TableCell
        tr15.Attributes.Add("width", "15%")
        td37.ColumnSpan = 1
        td37.HorizontalAlign = HorizontalAlign.Center
        td37.Text = "<font size=3>&nbsp  </font>"
        tr15.Controls.Add(td37)
        tb.Controls.Add(tr15)

        Dim td42 As New TableCell
        td42.Attributes.Add("width", "35%")
        td42.ColumnSpan = 35
        td42.HorizontalAlign = HorizontalAlign.Left
        td42.Text = "<font size=3 color=black ><b> Releiving Date </b>  </font>"
        tr15.Controls.Add(td42)
        tb.Controls.Add(tr15)

        Dim td47 As New TableCell
        td47.Attributes.Add("width", "55%")
        td47.ColumnSpan = 55
        td47.HorizontalAlign = HorizontalAlign.Left
        td47.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & dtls(3) & " </font>"
        tr15.Controls.Add(td47)
        tb.Controls.Add(tr15)

        ''-------------------------------------------------------
        Dim tr16 As New TableRow
        Dim td38 As New TableCell
        tr16.Attributes.Add("width", "15%")
        td38.ColumnSpan = 1
        td38.HorizontalAlign = HorizontalAlign.Center
        td38.Text = "<font size=3>&nbsp  </font>"
        tr16.Controls.Add(td38)
        tb.Controls.Add(tr16)

        Dim td43 As New TableCell
        td43.Attributes.Add("width", "35%")
        td43.ColumnSpan = 35
        td43.HorizontalAlign = HorizontalAlign.Left
        td43.Text = "<font size=3 color=black><b>Proposed Joining Date</b> </font>"
        tr16.Controls.Add(td43)
        tb.Controls.Add(tr16)

        Dim td48 As New TableCell
        td48.Attributes.Add("width", "55%")
        td48.ColumnSpan = 55
        td48.HorizontalAlign = HorizontalAlign.Left
        td48.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & dtls(2) & "</font>"
        tr16.Controls.Add(td48)
        tb.Controls.Add(tr16)

        ''-------------------------------------------------------
        Dim tr17 As New TableRow
        Dim td39 As New TableCell
        tr17.Attributes.Add("width", "15%")
        td39.ColumnSpan = 1
        td39.HorizontalAlign = HorizontalAlign.Center
        td39.Text = "<font size=3>&nbsp  </font>"
        tr17.Controls.Add(td39)
        tb.Controls.Add(tr17)

        Dim td44 As New TableCell
        td44.Attributes.Add("width", "35%")
        td44.ColumnSpan = 35
        td44.HorizontalAlign = HorizontalAlign.Left
        td44.Text = "<font size=3 color=black><b> Reporting Date </b> </font>"
        tr17.Controls.Add(td44)
        tb.Controls.Add(tr17)


        Dim td49 As New TableCell
        td49.Attributes.Add("width", "55%")
        td49.ColumnSpan = 55
        td49.HorizontalAlign = HorizontalAlign.Left
        td49.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & dtls(4) & " </font>"
        tr17.Controls.Add(td49)
        tb.Controls.Add(tr17)

        ''-------------------------------------------------------
        Dim tr181 As New TableRow
        Dim td401 As New TableCell
        tr181.Attributes.Add("width", "15%")
        td401.ColumnSpan = 1
        td401.HorizontalAlign = HorizontalAlign.Center
        td401.Text = "<font size=3>&nbsp  </font>"
        tr181.Controls.Add(td401)
        tb.Controls.Add(tr181)

        Dim td451 As New TableCell
        td451.Attributes.Add("width", "35%")
        td451.ColumnSpan = 35
        td451.HorizontalAlign = HorizontalAlign.Left
        td451.Text = "<font size=3 color=black><b> Date of Confirmed </b>  </font>"
        tr181.Controls.Add(td451)
        tb.Controls.Add(tr181)
        sql3 = "select basic_pay ,emp_type,da_flag from employee_master where emp_code=" & dtls(1) & " and status_id=1 "
        dt3 = oh.ExecuteDataSet(sql3).Tables(0)

        If (dt3.Rows(0)(1) = 2) Then
            cd = "NOT CONFIRMED YET"
        Else
            'Dim Sql15 As String = "select join_dt from employee_master where join_dt in (select max(join_dt) from employee_master where emp_name like '" & cr_dt(0) & "' ) and emp_name like '" & cr_dt(0) & "'"
            'dt12 = oh.ExecuteDataSet(Sql15).Tables(0)

            dt8 = oh.ExecuteDataSet("select emp_code from employee_master_dtl where new_empcode= " & dtls(1) & "").Tables(0)
            If (dt8.Rows.Count = 0) Then
                Dim Sql15 As String = "select join_dt from employee_master where emp_code=" & dtls(1) & ""
                dt12 = oh.ExecuteDataSet(Sql15).Tables(0)

                cd = Format(dt12.Rows(0)(0), "dd/MMM/yyyy")
                '  cd = "NOT CONFIRMED YET"
            Else
                Dim Sql15 As String = "select join_dt from employee_master where emp_code=" & dtls(1) & ""
                dt12 = oh.ExecuteDataSet(Sql15).Tables(0)

                cd = Format(dt12.Rows(0)(0), "dd/MMM/yyyy")

            End If



        End If
        Dim td501 As New TableCell
        td501.Attributes.Add("width", "55%")
        td501.ColumnSpan = 55
        td501.HorizontalAlign = HorizontalAlign.Left
        td501.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & cd & " </font>"
        tr181.Controls.Add(td501)
        tb.Controls.Add(tr181)
        ''----------------------------------------------------

        ''-------------------------------------------------------
        Dim Sql1 As String = "select post_name from post_mst where post_id=" & dtls(8) & " "
        dt1 = oh.ExecuteDataSet(Sql1).Tables(0)

        Dim tr19 As New TableRow
        Dim td41 As New TableCell
        tr19.Attributes.Add("width", "15%")
        td41.ColumnSpan = 1
        td41.HorizontalAlign = HorizontalAlign.Center
        td41.Text = "<font size=3>&nbsp  </font>"
        tr19.Controls.Add(td41)
        tb.Controls.Add(tr19)

        Dim td46 As New TableCell
        td46.Attributes.Add("width", "35%")
        td46.ColumnSpan = 35
        td46.HorizontalAlign = HorizontalAlign.Left
        td46.Text = "<font size=3 color=black><b>Report To</b></font>"
        tr19.Controls.Add(td46)
        tb.Controls.Add(tr19)


        Dim td51 As New TableCell
        td51.Attributes.Add("width", "55%")
        td51.ColumnSpan = 55
        td51.HorizontalAlign = HorizontalAlign.Left
        td51.Text = "<font size=3 color=darkblue>&nbsp-&nbsp " & dt1.Rows(0)(0) & " </font>"
        tr19.Controls.Add(td51)
        tb.Controls.Add(tr19)
        ''--------------------------------------------------------
        ''----------------------------------------------------

        Dim Sql As String = "select emp_name from employee_master where emp_code>9999 and emp_code=" & dtls(8) & ""
        dt = oh.ExecuteDataSet(Sql).Tables(0)


        sql3 = "select basic_pay ,emp_type,da_flag from employee_master where emp_code=" & dtls(1) & "  "
        dt3 = oh.ExecuteDataSet(sql3).Tables(0)
        Dim Sql5 As String = "select value from da_index where to_dt is null and firm_id=" & frm & ""
        dt4 = oh.ExecuteDataSet(Sql5).Tables(0)
        Dim sal As String = dt4.Rows(0)(0)
        If (dt3.Rows(0)(1) = 1) Then
            If (dt3.Rows(0)(2) = "T") Then
                sal = dt4.Rows(0)(0)
                tot = dt3.Rows(0)(0) + dt4.Rows(0)(0)
            Else
                If (dt3.Rows(0)(2) = "F" Or dt3.Rows(0)(2) = "") Then
                    sal = 0
                    tot = dt3.Rows(0)(0) + sal
                End If
            End If
        Else
            If (dt3.Rows(0)(1) = 2) Then
                If (dt3.Rows(0)(2) = "T") Then
                    sal = dt4.Rows(0)(0)
                    tot = dt3.Rows(0)(0) + sal
                Else
                    If (dt3.Rows(0)(2) = "F" Or dt3.Rows(0)(2) = "") Then
                        sal = 0
                        tot = dt3.Rows(0)(0) + sal
                    End If

                End If
            End If
            If (dt3.Rows(0)(1) = 3) Then
                sal = 0
                tot = dt3.Rows(0)(0) + sal
            End If
        End If
        Dim tr20 As New TableRow
        Dim td412 As New TableCell
        tr20.Attributes.Add("width", "15%")
        td412.ColumnSpan = 1
        td412.HorizontalAlign = HorizontalAlign.Center
        td412.Text = "<font size=3>&nbsp  </font>"
        tr20.Controls.Add(td412)
        tb.Controls.Add(tr20)

        Dim td417 As New TableCell
        td417.Attributes.Add("width", "35%")
        td417.ColumnSpan = 35
        td417.HorizontalAlign = HorizontalAlign.Left
        td417.Text = "<font size=3 color=black><b> Present Salary </b>  </font>"
        tr20.Controls.Add(td417)
        tb.Controls.Add(tr20)

        Dim td52 As New TableCell
        td52.Attributes.Add("width", "55%")
        td52.ColumnSpan = 55
        td52.HorizontalAlign = HorizontalAlign.Left
        td52.Text = "<font size=3 color=darkblue>&nbsp-&nbspBASIC(" & dt3.Rows(0)(0) & " )+VDA(" & sal & ")= " & tot & "&nbsp;RS. </font>"
        tr20.Controls.Add(td52)
        tb.Controls.Add(tr20)
        ''---------------------------------------------
        Dim tr21 As New TableRow
        Dim td422 As New TableCell
        tr21.Attributes.Add("width", "15%")
        td422.ColumnSpan = 1
        td422.HorizontalAlign = HorizontalAlign.Center
        td422.Text = "<font size=3>&nbsp  </font>"
        tr21.Controls.Add(td422)
        tb.Controls.Add(tr21)

        Dim td427 As New TableCell
        td427.Attributes.Add("width", "35%")
        td427.ColumnSpan = 35
        td427.HorizontalAlign = HorizontalAlign.Left
        td427.Text = "<font size=3 color=black><b> Proposed Salary </b>  </font>"
        tr21.Controls.Add(td427)
        tb.Controls.Add(tr21)

        Dim td54 As New TableCell
        td54.Attributes.Add("width", "55%")
        td54.ColumnSpan = 55
        td54.HorizontalAlign = HorizontalAlign.Left
        td54.Text = "<font size=3 color=darkblue>&nbsp-&nbspBASIC(" & dt3.Rows(0)(0) & " )+VDA(" & sal & ")= " & tot & "&nbsp;RS. </font>"
        tr21.Controls.Add(td54)
        tb.Controls.Add(tr21)
        ''-------------------------------------------------------



        Dim tr1913 As New TableRow
        Dim td4113 As New TableCell
        tr1913.Attributes.Add("width", "35%")
        td4113.ColumnSpan = 35
        td4113.HorizontalAlign = HorizontalAlign.Center
        td4113.Text = "<font size=3>&nbsp  </font>"
        tr1913.Controls.Add(td4113)
        tb.Controls.Add(tr1913)

        Dim td4613 As New TableCell
        td4613.Attributes.Add("width", "55%")
        td4613.ColumnSpan = 55
        td4613.HorizontalAlign = HorizontalAlign.Center
        td4613.Text = "<font size=3 color=black><b></b></font>"
        tr1913.Controls.Add(td4613)
        tb.Controls.Add(tr1913)

        ''--------------------------------------------------------


        Dim tr191 As New TableRow
        Dim td411 As New TableCell
        tr191.Attributes.Add("width", "35%")
        td411.ColumnSpan = 35
        td411.HorizontalAlign = HorizontalAlign.Right
        td411.Text = "<font size=3>&nbsp  </font>"
        tr191.Controls.Add(td411)
        tb.Controls.Add(tr191)


        Dim td461 As New TableCell
        td461.Attributes.Add("width", "100%")
        td461.ColumnSpan = 100
        td461.HorizontalAlign = HorizontalAlign.Left
        td461.Text = "<font size=4 color=blue><b><u>      LEAVE DETAILS   </b></font></u>"
        tr191.Controls.Add(td461)
        tb.Controls.Add(tr191)

        ''--------------------------------------------------------
        dt25 = oh.ExecuteDataSet("select count(emp_code) from employee_master where emp_code=" & dtls(1) & " and emp_type=1 and to_number(to_date('" & dtls(3) & "')-to_date(join_dt))>365").Tables(0)

        If (dt25.Rows(0)(0) = 1) Then

            Sql5 = "select distinct case when to_char(process_date,'dd')<15 then to_number(to_char(process_date,'MM'))-1 else  to_number(to_char(process_date,'MM'))  end from employ_leave_master where emp_code=" & dtls(1) & " "
            Dim dt88 As DataTable = oh.ExecuteDataSet("select nvl(sum(cas),0) as cs,nvl(sum(sick),0) as sk,nvl(sum(earn),0) as er,nvl(sum(lop),0) as lp from (select case when el.leave_id=1 then sum(el.leave_days) end as cas,case when el.leave_id=2 then sum(el.leave_days) end as sick,case when el.leave_id=3 then sum(el.leave_days) end as earn,case when el.leave_id=4 then sum(el.leave_days) end as lop from employ_leave_dtl el where el.emp_code=" & dtls(1) & " and el.leave_process_id not in (0,3) and to_date(el.leave_frdate)>=to_date('01-jan-'||to_char(sysdate,'yyyy')) group by el.leave_id) ").Tables(0)
            Dim dt6 As DataTable = oh.ExecuteDataSet(Sql5).Tables(0)
            sql15 = "select leave_days,leave_id from employ_leave_master where emp_code=" & dtls(1) & ""
            Dim dt16 As DataTable = oh.ExecuteDataSet(sql15).Tables(0)
            Dim dr As DataRow
            For Each dr In dt16.Rows

                If (dr(1) = 1) Then

                    cast = 12 - dt6.Rows(0)(0)
                    cas = dr(0)
                End If
                If (dr(1) = 2) Then
                    sic = dr(0)
                    sict = 12 - dt6.Rows(0)(0)
                End If
                If (dr(1) = 3) Then
                    ear = dr(0)
                    eart = 12 - dt6.Rows(0)(0)
                End If
                ''-----   --------------------------------------------------
            Next
            Dim tr161 As New TableRow
            Dim td381 As New TableCell
            tr161.Attributes.Add("width", "15%")
            td381.ColumnSpan = 1
            td381.HorizontalAlign = HorizontalAlign.Center
            td381.Text = "<font size=3>&nbsp  </font>"
            tr161.Controls.Add(td381)
            tb.Controls.Add(tr161)

            Dim td431 As New TableCell
            td431.Attributes.Add("width", "30%")
            td431.ColumnSpan = 30
            td431.HorizontalAlign = HorizontalAlign.Left
            td431.Text = "<font size=3 color=black><b>Types of Leave:</b> </font>"
            tr161.Controls.Add(td431)
            tb.Controls.Add(tr161)

            Dim td481 As New TableCell
            td481.Attributes.Add("width", "55%")
            td481.ColumnSpan = 55
            td481.HorizontalAlign = HorizontalAlign.Left
            td481.Text = "<font size=3 color=darkblue>&nbsp-&nbsp  Casual&nbsp&nbsp&nbsp&nbsp   Sick&nbsp&nbsp&nbsp&nbsp   Earned&nbsp&nbsp&nbsp&nbsp   L.O.P</font>"
            tr161.Controls.Add(td481)
            tb.Controls.Add(tr161)

            ''-------------------------------------------------------
            Dim tr1713 As New TableRow
            Dim td3913 As New TableCell
            tr1713.Attributes.Add("width", "15%")
            td3913.ColumnSpan = 1
            td3913.HorizontalAlign = HorizontalAlign.Center
            td3913.Text = "<font size=3>&nbsp  </font>"
            tr1713.Controls.Add(td3913)
            tb.Controls.Add(tr1713)

            Dim td4413 As New TableCell
            td4413.Attributes.Add("width", "30%")
            td4413.ColumnSpan = 30
            td4413.HorizontalAlign = HorizontalAlign.Left
            td4413.Text = "<font size=3 color=black><b> At the beginning </b> </font>"
            tr1713.Controls.Add(td4413)
            tb.Controls.Add(tr1713)


            Dim td4913 As New TableCell
            td4913.Attributes.Add("width", "55%")
            td4913.ColumnSpan = 55
            td4913.HorizontalAlign = HorizontalAlign.Left
            td4913.Text = "<font size=3 color=darkblue>&nbsp-&nbsp&nbsp&nbsp&nbsp&nbsp  " & cast & "&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp &nbsp" & sict & "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp " & eart & "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp   NA   </font>"
            tr1713.Controls.Add(td4913)
            tb.Controls.Add(tr1713)
            ''----------------------------------------------------------------
            Dim tr171 As New TableRow
            Dim td391 As New TableCell
            tr171.Attributes.Add("width", "15%")
            td391.ColumnSpan = 1
            td391.HorizontalAlign = HorizontalAlign.Center
            td391.Text = "<font size=3>&nbsp  </font>"
            tr171.Controls.Add(td391)
            tb.Controls.Add(tr171)

            Dim td441 As New TableCell
            td441.Attributes.Add("width", "30%")
            td441.ColumnSpan = 30
            td441.HorizontalAlign = HorizontalAlign.Left
            td441.Text = "<font size=3 color=black><b> Avail </b> </font>"
            tr171.Controls.Add(td441)
            tb.Controls.Add(tr171)


            Dim td491 As New TableCell
            td491.Attributes.Add("width", "55%")
            td491.ColumnSpan = 55
            td491.HorizontalAlign = HorizontalAlign.Left
            td491.Text = "<font size=3 color=darkblue>&nbsp-&nbsp&nbsp&nbsp&nbsp&nbsp  " & dt88.Rows(0)(0) & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp &nbsp&nbsp&nbsp&nbsp" & dt88.Rows(0)(1) & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp &nbsp&nbsp&nbsp" & dt88.Rows(0)(2) & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp&nbsp&nbsp" & dt88.Rows(0)(3) & "   </font>"
            tr171.Controls.Add(td491)
            tb.Controls.Add(tr171)
            ''----------------------------------------------------------------------------------------------------------
            Dim tr1712 As New TableRow
            Dim td3912 As New TableCell
            tr1712.Attributes.Add("width", "15%")
            td3912.ColumnSpan = 1
            td3912.HorizontalAlign = HorizontalAlign.Center
            td3912.Text = "<font size=3>&nbsp  </font>"
            tr1712.Controls.Add(td3912)
            tb.Controls.Add(tr1712)

            Dim td4412 As New TableCell
            td4412.Attributes.Add("width", "30%")
            td4412.ColumnSpan = 30
            td4412.HorizontalAlign = HorizontalAlign.Left
            td4412.Text = "<font size=3 color=black><b> Balance </b> </font>"
            tr1712.Controls.Add(td4412)
            tb.Controls.Add(tr1712)


            Dim td4912 As New TableCell
            td4912.Attributes.Add("width", "55%")
            td4912.ColumnSpan = 55
            td4912.HorizontalAlign = HorizontalAlign.Left
            td4912.Text = "<font size=3 color=darkblue>&nbsp-&nbsp&nbsp&nbsp&nbsp&nbsp " & cas & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp &nbsp&nbsp&nbsp" & sic & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp &nbsp&nbsp&nbsp" & ear & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp   &nbsp&nbsp&nbspNA  </font>"
            tr1712.Controls.Add(td4912)
            tb.Controls.Add(tr1712)


            ''-------------------------------------------------------

        Else
            Dim dt88 As DataTable = oh.ExecuteDataSet("select nvl(sum(cas),0) as cs,nvl(sum(sick),0) as sk,nvl(sum(earn),0) as er,nvl(sum(lop),0) as lp from (select case when el.leave_id=1 then sum(el.leave_days) end as cas,case when el.leave_id=2 then sum(el.leave_days) end as sick,case when el.leave_id=3 then sum(el.leave_days) end as earn,case when el.leave_id=4 then sum(el.leave_days) end as lop from employ_leave_dtl el where el.emp_code=" & dtls(1) & " and el.leave_process_id not in (0,3) and to_date(el.leave_frdate)>=to_date('01-jan-'||to_char(sysdate,'yyyy')) group by el.leave_id) ").Tables(0)
            Dim tr161 As New TableRow
            Dim td381 As New TableCell
            tr161.Attributes.Add("width", "15%")
            td381.ColumnSpan = 1
            td381.HorizontalAlign = HorizontalAlign.Center
            td381.Text = "<font size=3>&nbsp  </font>"
            tr161.Controls.Add(td381)
            tb.Controls.Add(tr161)

            Dim td431 As New TableCell
            td431.Attributes.Add("width", "30%")
            td431.ColumnSpan = 30
            td431.HorizontalAlign = HorizontalAlign.Left
            td431.Text = "<font size=3 color=black><b>Types of Leave:</b> </font>"
            tr161.Controls.Add(td431)
            tb.Controls.Add(tr161)

            Dim td481 As New TableCell
            td481.Attributes.Add("width", "55%")
            td481.ColumnSpan = 55
            td481.HorizontalAlign = HorizontalAlign.Left
            td481.Text = "<font size=3 color=darkblue>&nbsp-&nbsp  Casual&nbsp&nbsp&nbsp&nbsp   Sick&nbsp&nbsp&nbsp&nbsp   Earned&nbsp&nbsp&nbsp&nbsp   L.O.P</font>"
            tr161.Controls.Add(td481)
            tb.Controls.Add(tr161)

            ''-------------------------------------------------------

            Dim tr171 As New TableRow
            Dim td391 As New TableCell
            tr171.Attributes.Add("width", "15%")
            td391.ColumnSpan = 1
            td391.HorizontalAlign = HorizontalAlign.Center
            td391.Text = "<font size=3>&nbsp  </font>"
            tr171.Controls.Add(td391)
            tb.Controls.Add(tr171)

            Dim td441 As New TableCell
            td441.Attributes.Add("width", "30%")
            td441.ColumnSpan = 30
            td441.HorizontalAlign = HorizontalAlign.Left
            td441.Text = "<font size=3 color=black><b> At the beginning </b> </font>"
            tr171.Controls.Add(td441)
            tb.Controls.Add(tr171)


            Dim td491 As New TableCell
            td491.Attributes.Add("width", "55%")
            td491.ColumnSpan = 55
            td491.HorizontalAlign = HorizontalAlign.Left
            td491.Text = "<font size=3 color=darkblue>&nbsp-&nbsp Only one leave per month&nbsp  &nbsp&nbsp&nbsp NA   </font>"
            tr171.Controls.Add(td491)
            tb.Controls.Add(tr171)
            ''---------------------------------------------------------------------------------------------
            Dim tr1714 As New TableRow
            Dim td3914 As New TableCell
            tr1714.Attributes.Add("width", "15%")
            td3914.ColumnSpan = 1
            td3914.HorizontalAlign = HorizontalAlign.Center
            td3914.Text = "<font size=3>&nbsp  </font>"
            tr1714.Controls.Add(td3914)
            tb.Controls.Add(tr1714)

            Dim td4414 As New TableCell
            td4414.Attributes.Add("width", "30%")
            td4414.ColumnSpan = 30
            td4414.HorizontalAlign = HorizontalAlign.Left
            td4414.Text = "<font size=3 color=black><b> Avail </b> </font>"
            tr1714.Controls.Add(td4414)
            tb.Controls.Add(tr1714)


            Dim td4914 As New TableCell
            td4914.Attributes.Add("width", "55%")
            td4914.ColumnSpan = 55
            td4914.HorizontalAlign = HorizontalAlign.Left
            td4914.Text = "<font size=3 color=darkblue>&nbsp-&nbsp  " & dt88.Rows(0)(0) & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" & dt88.Rows(0)(1) & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp &nbsp&nbsp&nbsp" & dt88.Rows(0)(2) & "&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp&nbsp" & dt88.Rows(0)(3) & "   </font>"
            tr1714.Controls.Add(td4914)
            tb.Controls.Add(tr1714)
            ''--------------------------------------------------------------
            Dim tr1712 As New TableRow
            Dim td3912 As New TableCell
            tr1712.Attributes.Add("width", "15%")
            td3912.ColumnSpan = 1
            td3912.HorizontalAlign = HorizontalAlign.Center
            td3912.Text = "<font size=3>&nbsp  </font>"
            tr1712.Controls.Add(td3912)
            tb.Controls.Add(tr1712)

            Dim td4412 As New TableCell
            td4412.Attributes.Add("width", "30%")
            td4412.ColumnSpan = 30
            td4412.HorizontalAlign = HorizontalAlign.Left
            td4412.Text = "<font size=3 color=black><b> Balance </b> </font>"
            tr1712.Controls.Add(td4412)
            tb.Controls.Add(tr1712)


            Dim td4912 As New TableCell
            td4912.Attributes.Add("width", "55%")
            td4912.ColumnSpan = 55
            td4912.HorizontalAlign = HorizontalAlign.Left
            td4912.Text = "<font size=3 color=darkblue>&nbsp-&nbsp NA   </font>"
            tr1712.Controls.Add(td4912)
            tb.Controls.Add(tr1712)
            ''-------------------------------------------------------
        End If
        ''-----------------------------------------------------------
        Dim tr16141 As New TableRow
        Dim td38141 As New TableCell
        tr16141.Attributes.Add("width", "15%")
        td38141.ColumnSpan = 1
        td38141.HorizontalAlign = HorizontalAlign.Center
        td38141.Text = "<font size=3>&nbsp  </font>"
        tr16141.Controls.Add(td38141)
        tb.Controls.Add(tr16141)

        Dim td43141 As New TableCell
        td43141.Attributes.Add("width", "30%")
        td43141.ColumnSpan = 30
        td43141.HorizontalAlign = HorizontalAlign.Center
        td43141.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
        tr16141.Controls.Add(td43141)
        tb.Controls.Add(tr16141)

        Dim tr1614 As New TableRow
        Dim td3814 As New TableCell
        tr1614.Attributes.Add("width", "100%")
        td3814.ColumnSpan = 1
        td3814.HorizontalAlign = HorizontalAlign.Left
        td3814.Text = "<font size=3>&nbsp</font>"
        tr1614.Controls.Add(td3814)
        tb.Controls.Add(tr1614)


        Dim td4314 As New TableCell
        td4314.Attributes.Add("width", "100%")
        td4314.ColumnSpan = 100
        td4314.HorizontalAlign = HorizontalAlign.Left
        td4314.Text = "<i><font size=3 color=black><b>Compliance of the above instructions shall be promptly reported by the branches.</b> </font></i>"
        tr1614.Controls.Add(td4314)
        tb.Controls.Add(tr1614)

        ''-------------------------------------------------------------
        Dim tr16142 As New TableRow
        Dim td38142 As New TableCell
        tr16142.Attributes.Add("width", "15%")
        td38142.ColumnSpan = 1
        td38142.HorizontalAlign = HorizontalAlign.Center
        td38142.Text = "<font size=3>&nbsp  </font>"
        tr16142.Controls.Add(td38142)
        tb.Controls.Add(tr16142)

        Dim td43143 As New TableCell
        td43143.Attributes.Add("width", "30%")
        td43143.ColumnSpan = 30
        td43143.HorizontalAlign = HorizontalAlign.Center
        td43143.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
        tr16142.Controls.Add(td43143)
        tb.Controls.Add(tr16142)

        Dim tr16143 As New TableRow
        Dim td38143 As New TableCell
        tr16143.Attributes.Add("width", "15%")
        td38143.ColumnSpan = 1
        td38143.HorizontalAlign = HorizontalAlign.Center
        td38143.Text = "<font size=3>&nbsp  </font>"
        tr16143.Controls.Add(td38143)
        tb.Controls.Add(tr16143)

        Dim td43142 As New TableCell
        td43142.Attributes.Add("width", "30%")
        td43142.ColumnSpan = 30
        td43142.HorizontalAlign = HorizontalAlign.Center
        td43142.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
        tr16142.Controls.Add(td43142)
        tb.Controls.Add(tr16142)

        Dim tr1615 As New TableRow
        Dim td3815 As New TableCell
        tr1615.Attributes.Add("width", "15%")
        td3815.ColumnSpan = 1
        td3815.HorizontalAlign = HorizontalAlign.Left
        td3815.Text = "<font size=3>&nbsp  </font>"
        tr1615.Controls.Add(td3815)
        tb.Controls.Add(tr1615)

        Dim td4315 As New TableCell
        td4315.Attributes.Add("width", "100%")
        td4315.ColumnSpan = 100
        td4315.HorizontalAlign = HorizontalAlign.Left
        td4315.Text = "<font size=3 color=black>DGM(HRM)</font>"
        tr1615.Controls.Add(td4315)
        tb.Controls.Add(tr1615)
        Me.Panel1.Controls.Add(tb)

        Dim td4343 As New TableCell
        td4343.Attributes.Add("width", "30%")
        td4343.ColumnSpan = 30
        td4343.HorizontalAlign = HorizontalAlign.Center
        td4343.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
        tr16143.Controls.Add(td4343)
        tb.Controls.Add(tr16143)

        Dim tr1616 As New TableRow
        Dim td3816 As New TableCell
        tr1616.Attributes.Add("width", "15%")
        td3816.ColumnSpan = 1
        td3816.HorizontalAlign = HorizontalAlign.Left
        td3816.Text = "<font size=3>&nbsp  </font>"
        tr1616.Controls.Add(td3816)
        tb.Controls.Add(tr1616)

        ''-----------------------new-----------------------------------
        Dim td43145 As New TableCell
        td43145.Attributes.Add("width", "50%")
        td43145.ColumnSpan = 50
        td43145.HorizontalAlign = HorizontalAlign.Center
        td43145.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
        tr16143.Controls.Add(td43145)
        tb.Controls.Add(tr16143)

        Dim tr16166 As New TableRow
        Dim td3817 As New TableCell
        tr16166.Attributes.Add("width", "50%")
        td3817.ColumnSpan = 50
        td3817.HorizontalAlign = HorizontalAlign.Left
        td3817.Text = "<font size=3>&nbsp  </font>"
        tr16166.Controls.Add(td3817)
        tb.Controls.Add(tr16166)

        Dim td4317 As New TableCell

        td4317.Attributes.Add("width", "50%")
        td4317.ColumnSpan = 100
        td4317.HorizontalAlign = HorizontalAlign.Center
        td4317.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
        tr16166.Controls.Add(td4317)
        tb.Controls.Add(tr16166)

        Dim tr1617 As New TableRow
        Dim td387 As New TableCell
        tr1617.Attributes.Add("width", "50%")
        td387.ColumnSpan = 50
        td387.HorizontalAlign = HorizontalAlign.Left
        td387.Text = "<font size=3>&nbsp  </font>"
        tr1617.Controls.Add(td387)
        tb.Controls.Add(tr1617)
        Dim tr78 As New TableRow
        Dim td78 As New TableCell
        tr78.Attributes.Add("width", "50%")
        td78.ColumnSpan = 50
        td78.HorizontalAlign = HorizontalAlign.Left
        td78.Text = "<font size=3>&nbsp  </font>"
        tr78.Controls.Add(td78)
        tb.Controls.Add(tr78)

        Dim Sql6 As String = "select post_name,post_id from post_mst where post_id=" & dd(0) & ""
        dt1 = oh.ExecuteDataSet(Sql6).Tables(0)
        If (dt1.Rows(0)(1) <= 18 Or dt1.Rows(0)(1) = 101) Then


            Dim tb1 As New Table
            tb1.Attributes.Add("width", "100%")
            tb1.Attributes.Add("align", "center")
            Dim btr111 As New TableRow
            Dim btd11 As New TableCell
            btd11.Attributes.Add("width", "100%")
            btd11.ColumnSpan = 100
            btd11.HorizontalAlign = HorizontalAlign.Center
            btr111.Controls.Add(btd11)
            tb1.Controls.Add(btr111)
            '------------------------------------------------------------------'
            Dim tr2 As New TableRow
            Dim td2 As New TableCell
            td2.ColumnSpan = 100
            tr2.BackColor = Drawing.Color.SeaShell
            td2.HorizontalAlign = HorizontalAlign.Center
            td2.Text = "<font size=4 color=darkblue><b><u>" & frr & "</font></b></u>"
            tr2.Cells.Add(td2)
            tb1.Controls.Add(tr2)
            '-------------------------------------------------------------------'
            Dim tr34 As New TableRow
            Dim td88 As New TableCell
            td88.Attributes.Add("width", "100%")
            td88.ColumnSpan = 100
            td88.HorizontalAlign = HorizontalAlign.Center
            tr34.Controls.Add(td88)
            tb1.Controls.Add(tr34)
            '------------------------------------------------------------------'
            Dim tr35 As New TableRow
            Dim td89 As New TableCell
            td89.Attributes.Add("width", "100%")
            td89.ColumnSpan = 100
            td89.HorizontalAlign = HorizontalAlign.Center
            td89.Text = "<font size=3 color=darkblue>" & DT27.Rows(0)(1) & "</font>"
            tr35.Controls.Add(td89)
            tb1.Controls.Add(tr35)
            '----------------------------------------------------
            Dim atr11 As New TableRow
            Dim atd24 As New TableCell
            atd24.Attributes.Add("width", "100%")
            atd24.ColumnSpan = 100
            atd24.HorizontalAlign = HorizontalAlign.Center
            atr11.Controls.Add(atd24)
            tb1.Controls.Add(atr11)
            '------------------------------------------------------------------'
            Dim tr36 As New TableRow
            Dim td90 As New TableCell
            td90.Attributes.Add("width", "100%")
            td90.ColumnSpan = 100
            td90.HorizontalAlign = HorizontalAlign.Center
            td90.Text = "<font size=4 color=blue> DEPARTMENT OF HUMAN RESOURCE MANAGEMENT </font></b>"
            tr36.Controls.Add(td90)
            tb1.Controls.Add(tr36)
            '--------------------------------------------------
            Dim tr37 As New TableRow
            Dim td91 As New TableCell
            td91.Attributes.Add("width", "25")
            td91.ColumnSpan = 25
            td91.HorizontalAlign = HorizontalAlign.Left
            td91.Text = "<font size=3 color=blue>" & Format(Date.Now, "hh:mm:ss") & "</font></b>"
            tr37.Controls.Add(td91)
            tb1.Controls.Add(tr37)

            Dim td92 As New TableCell
            td92.Attributes.Add("width", "30%")
            td92.ColumnSpan = 30
            td92.HorizontalAlign = HorizontalAlign.Left
            td92.Text = "<font size=3 > </font>"
            tr37.Controls.Add(td8)
            tb1.Controls.Add(tr37)

            Dim td93 As New TableCell
            td93.Attributes.Add("width", "25%")
            td93.ColumnSpan = 25
            td93.HorizontalAlign = HorizontalAlign.Right
            td93.Text = "<font size=3 color=blue>" & Format(Date.Now, "dd/MMM/yyyy") & "  </font></b>"
            tr37.Controls.Add(td93)
            tb1.Controls.Add(tr37)
            ''---------------------------------------------------
            Dim tr38 As New TableRow


            Dim td94 As New TableCell
            td94.Attributes.Add("width", "100%")
            td94.ColumnSpan = 100
            td94.HorizontalAlign = HorizontalAlign.Center
            tr38.BackColor = Drawing.Color.SeaShell
            td94.Text = "<font size=4 color=blue><b><u>TRANSFER ORDER</b></u></font>"
            tr38.Controls.Add(td94)
            tb1.Controls.Add(tr38)


            ''------------------------------------------------------
            Dim tr39 As New TableRow
            Dim td95 As New TableCell
            tr39.Attributes.Add("width", "100%")
            td95.ColumnSpan = 100
            td95.HorizontalAlign = HorizontalAlign.Center
            td95.Text = "<font size=3 color=darkblue>&nbsp" & empno & "   </font></b>"
            tr39.Controls.Add(td95)
            tb1.Controls.Add(tr39)

            If (dtls(7) = 0) Then

                Dim Sql8 As String = "select branch_name from branch_master where branch_id = " & dtls(0) & " "
                dt = oh.ExecuteDataSet(Sql8).Tables(0)
                If dt.Rows.Count = 0 Then
                    Sql8 = "select branch_name from before_completion where old_id = " & dtls(0) & " and branch_id is null "
                    dt = oh.ExecuteDataSet(Sql8).Tables(0)
                End If
                Dim tr40 As New TableRow
                Dim tc3 As New TableCell
                tc3.Attributes.Add("width", "100%")
                tc3.ColumnSpan = 30
                tc3.HorizontalAlign = HorizontalAlign.Left
                tc3.Text = "<font size=3><b> Transfer & Posting </b></font>"
                tr40.Controls.Add(tc3)

                tb1.Controls.Add(tr40)
                ''-------------------
                Dim tc31 As New TableCell
                tc31.Attributes.Add("width", "100%")
                tc31.ColumnSpan = 60
                tc31.HorizontalAlign = HorizontalAlign.Right
                tc31.Text = "<font size=3><b> Employee Code:" & dtls(1) & "</b></font>"
                tr40.Controls.Add(tc31)

                tb1.Controls.Add(tr40)
                ''---------------------------
                Dim tr41 As New TableRow
                Dim tc4 As New TableCell
                tc4.Attributes.Add("width", "100%")
                tc4.ColumnSpan = 100
                tc4.HorizontalAlign = HorizontalAlign.Left
                tc4.Text = "<font size=2><b><HR></b></font>"
                tr41.Controls.Add(tc4)

                tb1.Controls.Add(tr41)
                ''--------------------------------------

                ''--------------------------------------

                If (dt1.Rows(0)(1) <= 9) Then


                    Dim tr42 As New TableRow
                    Dim tc5 As New TableCell
                    tc5.Attributes.Add("width", "100%")
                    tc5.ColumnSpan = 95
                    tc5.HorizontalAlign = HorizontalAlign.Left
                    tc5.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mr / Ms." & cr_dt(0) & "," & cr_dt(1) & " -" & cr_dt(2) & "," & cr_dt(4) & " branch is transferred from " & cr_dt(4) & " branch and posted at our " & dt.Rows(0)(0) & "  branch as Assistant Branch Head with effect from " & dtls(2) & ". He / She will be relieved from  " & cr_dt(4) & " branch on the close of the  business on " & dtls(3) & " so as to report at " & dt.Rows(0)(0) & " branch on " & dtls(4) & ". </font>"
                    tr42.Controls.Add(tc5)
                    tb1.Controls.Add(tr42)
                    ''--------------------space-------------------

                    Dim td77 As New TableCell
                    Dim tr77 As New TableRow
                    td77.Attributes.Add("width", "50%")
                    td77.ColumnSpan = 95
                    td77.HorizontalAlign = HorizontalAlign.Center
                    td77.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
                    tr77.Controls.Add(td77)
                    tb1.Controls.Add(tr77)

                    ''---------------------------------------------


                    Dim tr421 As New TableRow
                    Dim tc51 As New TableCell
                    tc51.Attributes.Add("width", "100%")
                    tc51.ColumnSpan = 95
                    tc51.HorizontalAlign = HorizontalAlign.Left
                    tc51.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;He / She will hold the joint responsibility on matters like Branch administration, maintenance of books of accounts, office discipline, and joint custody of the  assets  of the company, securities etc. with the Branch Head,as cited in Circular No.MAGRO-338 dated 24th December,2004. </font>"
                    tr421.Controls.Add(tc51)
                    tb1.Controls.Add(tr421)
                    ''--------------------space-------------------

                    Dim td771 As New TableCell
                    Dim tr771 As New TableRow
                    td771.Attributes.Add("width", "50%")
                    td771.ColumnSpan = 95
                    td771.HorizontalAlign = HorizontalAlign.Center
                    td771.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
                    tr771.Controls.Add(td771)
                    tb1.Controls.Add(tr771)

                    ''---------------------------------------


                    Dim tr422 As New TableRow
                    Dim tc52 As New TableCell
                    tc52.Attributes.Add("width", "100%")
                    tc52.ColumnSpan = 95
                    tc52.HorizontalAlign = HorizontalAlign.Left
                    tc52.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;He / She is authorised to accept deposits on the behalf of the company  and issue deposit receipts under joint signature with the Branch Head,in accordance with the rules and  regulations in vogue  governing the  issue of the same. In the absence of the Branch Head, he / she will be completely responsible for running the office and authorised to advance loans against  gold ornaments after ascertaining the quality and purity of same, strictly complying with the procedures and rate of advance in vogue.</font>"
                    tr422.Controls.Add(tc52)
                    tb1.Controls.Add(tr422)


                End If
                ''---------------------------------------

                If ((dt1.Rows(0)(1) >= 10 And dt1.Rows(0)(1) <= 18) Or dt1.Rows(0)(1) = 101) Then

                    Dim tr42 As New TableRow
                    Dim tc5 As New TableCell
                    tc5.Attributes.Add("width", "100%")
                    tc5.ColumnSpan = 95
                    tc5.HorizontalAlign = HorizontalAlign.Left
                    tc5.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mr / Ms." & cr_dt(0) & "," & cr_dt(1) & " -" & cr_dt(2) & "," & cr_dt(4) & " branch is transferred from " & cr_dt(4) & " branch and posted at our " & dt.Rows(0)(0) & "  branch as Branch Head with effect from " & dtls(2) & ". He / She will be relieved from  " & cr_dt(4) & " branch on the close of the  business on " & dtls(3) & " so as to report at " & dt.Rows(0)(0) & " branch on " & dtls(4) & ". </font>"
                    tr42.Controls.Add(tc5)
                    tb1.Controls.Add(tr42)
                    ''--------------------space-------------------

                    Dim td77 As New TableCell
                    Dim tr77 As New TableRow
                    td77.Attributes.Add("width", "50%")
                    td77.ColumnSpan = 100
                    td77.HorizontalAlign = HorizontalAlign.Center
                    td77.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
                    tr77.Controls.Add(td77)
                    tb1.Controls.Add(tr77)

                    ''---------------------------------------------


                    Dim tr421 As New TableRow
                    Dim tc51 As New TableCell
                    tc51.Attributes.Add("width", "100%")
                    tc51.ColumnSpan = 95
                    tc51.HorizontalAlign = HorizontalAlign.Left
                    tc51.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;He / She will take  the  complete charge of " & dt.Rows(0)(0) & " branch from  the  joint custodians  of the branch on or before " & dtls(2) & " and  submit the usual charge  report  in the  prescribed format  CR-1. He / She will be  responsible for branch administration,maintenance of books of accounts, office discipline, and joint custody of the assets of the company, securities etc. with  the Branch Head,  as cited  in  Circular No.MAGRO-338 dated 24th December,2004.</font>"
                    tr421.Controls.Add(tc51)
                    tb1.Controls.Add(tr421)
                    ''--------------------space-------------------

                    Dim td771 As New TableCell
                    Dim tr771 As New TableRow
                    td771.Attributes.Add("width", "50%")
                    td771.ColumnSpan = 100
                    td771.HorizontalAlign = HorizontalAlign.Center
                    td771.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
                    tr771.Controls.Add(td771)
                    tb1.Controls.Add(tr771)


                    ''---------------------------------------


                    Dim tr422 As New TableRow
                    Dim tc52 As New TableCell
                    tc52.Attributes.Add("width", "100%")
                    tc52.ColumnSpan = 95
                    tc52.HorizontalAlign = HorizontalAlign.Left
                    tc52.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;He/She is authorised to  accept deposits on the  behalf of  the company and issue deposit receipts under joint signature  with the Branch Head,in accordance with  the rules  and  regulations in  vogue governing the issue of the same. In the absence of the Branch Head,  he / she will be completely responsible for running the office and authorised to advance loans against gold ornaments after ascertaining  the quality and purity of same, strictly  complying with  the procedures and  rate of  advance in vogue.</font>"
                    tr422.Controls.Add(tc52)
                    tb1.Controls.Add(tr422)


                End If
                ''----------------------------------------------
                Dim tr43 As New TableRow
                Dim tc6 As New TableCell
                tc6.Attributes.Add("width", "100%")
                tc6.ColumnSpan = 55
                tc6.HorizontalAlign = HorizontalAlign.Right
                tc6.Text = "<font size=2><b></b></font>"
                tr43.Controls.Add(tc6)

                tb1.Controls.Add(tr43)

                Dim tr44 As New TableRow
                Dim tc61 As New TableCell
                tc61.Attributes.Add("width", "100%")
                tc61.ColumnSpan = 10
                tc61.HorizontalAlign = HorizontalAlign.Left
                tc61.Text = "<font size=2><b></b></font>"
                tr43.Controls.Add(tc61)

                tb1.Controls.Add(tr44)

                Dim tr45 As New TableRow
                Dim tc7 As New TableCell
                tc7.Attributes.Add("width", "100%")
                tc7.ColumnSpan = 10
                tc7.HorizontalAlign = HorizontalAlign.Left
                tc7.Text = "<font size=2><b>  </b></font>"
                tr45.Controls.Add(tc7)

                tb1.Controls.Add(tr45)

                Dim tr146 As New TableRow
                Dim tc18 As New TableCell
                tc18.Attributes.Add("width", "100%")
                tc18.ColumnSpan = 30
                tc18.HorizontalAlign = HorizontalAlign.Left
                tc18.Text = "<font size=2><b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></font>"
                tr146.Controls.Add(tc18)

                tb1.Controls.Add(tr146)

                Dim tr47 As New TableRow
                Dim tc9 As New TableCell
                tc9.Attributes.Add("width", "100%")
                tc9.ColumnSpan = 10
                tc9.HorizontalAlign = HorizontalAlign.Left
                tc9.Text = "<font size=2 ><b>DGM(HRM) </b></font>"
                tr47.Controls.Add(tc9)

                tb1.Controls.Add(tr47)

                Dim tr452 As New TableRow
                Dim tc72 As New TableCell
                tc72.Attributes.Add("width", "100%")
                tc72.ColumnSpan = 10
                tc72.HorizontalAlign = HorizontalAlign.Left
                tc72.Text = "<font size=2><b>  </b></font>"
                tr452.Controls.Add(tc72)

                tb1.Controls.Add(tr452)

                Dim tr246 As New TableRow
                Dim tc28 As New TableCell
                tc28.Attributes.Add("width", "100%")
                tc28.ColumnSpan = 30
                tc28.HorizontalAlign = HorizontalAlign.Left
                tc28.Text = "<font size=2><b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></font>"
                tr246.Controls.Add(tc28)



                Dim tr48 As New TableRow
                Dim tc10 As New TableCell
                tc10.Attributes.Add("width", "100%")
                tc10.ColumnSpan = 10
                tc10.HorizontalAlign = HorizontalAlign.Left
                tc10.Text = "<font size=2><b> </b></font>"
                tr48.Controls.Add(tc10)

                tb1.Controls.Add(tr48)

                Dim tr49 As New TableRow
                Dim tc11, tc111 As New TableCell
                tc11.Attributes.Add("width", "100%")
                tc111.Attributes.Add("width", "100%")
                tc11.ColumnSpan = 6
                tc111.ColumnSpan = 4
                tc111.HorizontalAlign = HorizontalAlign.Left
                tc11.HorizontalAlign = HorizontalAlign.Left
                tc11.Text = "<font size=2><b> TO, </b></font>"
                tc111.Text = "<font size=2><b> </b></font>"
                tr49.Controls.Add(tc11)
                tr49.Controls.Add(tc111)

                tb1.Controls.Add(tr49)

                Dim tr481 As New TableRow
                Dim tc101 As New TableCell
                tc101.Attributes.Add("width", "100%")
                tc101.ColumnSpan = 10
                tc101.HorizontalAlign = HorizontalAlign.Left
                tc101.Text = "<font size=2><b> </b></font>"
                tr481.Controls.Add(tc101)

                tb1.Controls.Add(tr48)

                Dim tr491 As New TableRow
                Dim tc112, tc1111 As New TableCell
                tc112.Attributes.Add("width", "100%")
                tc1111.Attributes.Add("width", "100%")
                tc112.ColumnSpan = 20
                tc1111.ColumnSpan = 10
                tc1111.HorizontalAlign = HorizontalAlign.Left
                tc112.HorizontalAlign = HorizontalAlign.Left
                tc112.Text = "<font size=2><b>  </b></font>"
                tc1111.Text = "<font size=2><b> </b></font>"
                tr491.Controls.Add(tc112)
                tr491.Controls.Add(tc1111)

                tb1.Controls.Add(tr49)



                Dim tr12 As New TableRow
                Dim tc12, tc121 As New TableCell
                tc12.Attributes.Add("width", "100%")
                tc121.Attributes.Add("width", "100%")
                tc12.ColumnSpan = 40
                tc121.ColumnSpan = 10
                tc12.HorizontalAlign = HorizontalAlign.Left
                tc121.HorizontalAlign = HorizontalAlign.Left
                tc12.Text = "<font size=2 color=darkblue>Mr/Ms. " & cr_dt(0) & " </font>"
                tc121.Text = "<font size=2><b> </b></font>"
                tr12.Controls.Add(tc12)
                tr12.Controls.Add(tc121)

                tb1.Controls.Add(tr12)

                Dim tr131 As New TableRow
                Dim tc13, tc131 As New TableCell
                tc13.Attributes.Add("width", "100%")
                tc131.Attributes.Add("width", "100%")
                tc13.ColumnSpan = 25
                tc131.ColumnSpan = 4
                tc13.HorizontalAlign = HorizontalAlign.Left
                tc131.HorizontalAlign = HorizontalAlign.Left
                tc13.Text = "<font size=2 color=darkblue>" & cr_dt(1) & " </font>"
                tc131.Text = "<font size=2><b> </b></font>"
                tr131.Controls.Add(tc13)
                tr131.Controls.Add(tc131)

                tb1.Controls.Add(tr131)

                Dim tr141 As New TableRow
                Dim tc14, tc141 As New TableCell
                tc14.Attributes.Add("width", "100%")
                tc141.Attributes.Add("width", "100%")
                tc14.ColumnSpan = 25
                tc141.ColumnSpan = 4
                tc14.HorizontalAlign = HorizontalAlign.Left
                tc141.HorizontalAlign = HorizontalAlign.Left
                tc14.Text = "<font size=2 color=darkblue>" & cr_dt(2) & " </font>"
                tc141.Text = "<font size=2><b> </b></font>"
                tr141.Controls.Add(tc14)
                tr141.Controls.Add(tc141)

                tb1.Controls.Add(tr141)

                Dim tr151 As New TableRow
                Dim tc15, tc151 As New TableCell
                tc15.Attributes.Add("width", "100%")
                tc151.Attributes.Add("width", "100%")
                tc15.ColumnSpan = 25
                tc151.ColumnSpan = 4
                tc15.HorizontalAlign = HorizontalAlign.Left
                tc151.HorizontalAlign = HorizontalAlign.Left
                tc15.Text = "<font size=2 color=darkblue>" & cr_dt(3) & " </font>"
                tc151.Text = "<font size=2><b> </b></font>"
                tr151.Controls.Add(tc15)
                tr151.Controls.Add(tc151)

                tb1.Controls.Add(tr151)

                Dim tr161 As New TableRow
                Dim tc16, tc161 As New TableCell
                tc16.Attributes.Add("width", "100%")
                tc161.Attributes.Add("width", "100%")
                tc16.ColumnSpan = 25
                tc161.ColumnSpan = 4
                tc16.HorizontalAlign = HorizontalAlign.Left
                tc161.HorizontalAlign = HorizontalAlign.Left
                tc16.Text = "<font size=2 color=darkblue>" & cr_dt(4) & " </font>"
                tc161.Text = "<font size=2><b> </b></font>"
                tr161.Controls.Add(tc16)
                tr161.Controls.Add(tc161)
                tb1.Controls.Add(tr161)

                Dim tr494 As New TableRow
                Dim tc114, tc1114 As New TableCell
                tc114.Attributes.Add("width", "100%")
                tc1114.Attributes.Add("width", "100%")
                tc114.ColumnSpan = 20
                tc1114.ColumnSpan = 10
                tc1114.HorizontalAlign = HorizontalAlign.Left
                tc114.HorizontalAlign = HorizontalAlign.Left
                tc114.Text = "<font size=2><b>  </b></font>"
                tc1114.Text = "<font size=2><b> </b></font>"
                tr494.Controls.Add(tc114)
                tr494.Controls.Add(tc1114)

                tb1.Controls.Add(tr494)



                Dim tr126 As New TableRow
                Dim tc126, tc127 As New TableCell
                tc126.Attributes.Add("width", "100%")
                tc127.Attributes.Add("width", "100%")
                tc126.ColumnSpan = 70
                tc127.ColumnSpan = 30
                tc126.HorizontalAlign = HorizontalAlign.Left
                tc127.HorizontalAlign = HorizontalAlign.Left
                tc126.Text = "<font size=2><b>CC : BH- " & cr_dt(4) & " | BH- " & dt.Rows(0)(0) & "</b></font>"
                tc127.Text = "<font size=2><b> </b></font>"
                tr126.Controls.Add(tc126)
                tr126.Controls.Add(tc127)

                tb1.Controls.Add(tr126)
            Else

                Dim tr451 As New TableRow
                Dim tc71 As New TableCell
                tc71.Attributes.Add("width", "100%")
                tc71.ColumnSpan = 50
                tc71.HorizontalAlign = HorizontalAlign.Left
                tc71.Text = "<font size=2><b>  </b></font>"
                tr451.Controls.Add(tc71)

                tb1.Controls.Add(tr451)

                Dim tr147 As New TableRow
                Dim tc187 As New TableCell
                tc187.Attributes.Add("width", "100%")
                tc187.ColumnSpan = 50
                tc187.HorizontalAlign = HorizontalAlign.Left
                tc187.Text = "<font size=2><b>  </b></font>"
                tr147.Controls.Add(tc187)

                tb1.Controls.Add(tr147)


                Dim sql11 As String = "select firm_id from firm_master  where firm_name='" & cr_dt(6) & "'"

                dt11 = oh.ExecuteDataSet(sql11).Tables(0)

                If (dt11.Rows(0)(0) = dtls(7)) Then

                Else

                    Dim tr401 As New TableRow
                    Dim tc31 As New TableCell
                    tc31.Attributes.Add("width", "100%")
                    tc31.ColumnSpan = 30
                    tc31.HorizontalAlign = HorizontalAlign.Left
                    tc31.Text = "<font size=3><b> Deputation </b></font>"
                    tr401.Controls.Add(tc31)

                    tb1.Controls.Add(tr401)
                    ''--------------------------
                    Dim tc331 As New TableCell
                    tc331.Attributes.Add("width", "100%")
                    tc331.ColumnSpan = 70
                    tc331.HorizontalAlign = HorizontalAlign.Right
                    tc331.Text = "<font size=3><b> Employee Code:" & dtls(1) & " </b></font>"
                    tr401.Controls.Add(tc331)

                    tb1.Controls.Add(tr401)
                    ''-----------------------------

                    Dim tr411 As New TableRow
                    Dim tc41 As New TableCell
                    tc41.Attributes.Add("width", "100%")
                    tc41.ColumnSpan = 35
                    tc41.HorizontalAlign = HorizontalAlign.Left
                    tc41.Text = "<font size=2><b>----------------------------------------------------- </b></font>"
                    tr411.Controls.Add(tc41)
                    tb1.Controls.Add(tr411)
                    ''-------------------------------------------------

                    Dim tr402 As New TableRow
                    Dim tc32 As New TableCell
                    tc32.Attributes.Add("width", "100%")
                    tc32.ColumnSpan = 100
                    tc32.HorizontalAlign = HorizontalAlign.Left
                    tc32.Text = "<font size=3 color=darkblue> Mr / Ms." & cr_dt(0) & "," & cr_dt(1) & " -" & cr_dt(2) & "," & cr_dt(4) & " branch is deputed from " & cr_dt(6) & " to " & dt11.Rows(0)(0) & ".</font>"
                    tr402.Controls.Add(tc32)

                    tb1.Controls.Add(tr402)

                    Dim tr413 As New TableRow
                    Dim tc43 As New TableCell
                    tc43.Attributes.Add("width", "100%")
                    tc43.ColumnSpan = 10
                    tc43.HorizontalAlign = HorizontalAlign.Left
                    tc43.Text = "<font size=2><b></b></font>"
                    tr413.Controls.Add(tc43)
                    tb1.Controls.Add(tr413)

                End If

                ''-----------------------------------------------------------
                Dim Sql8 As String = "select branch_name from branch_master where branch_id = " & dtls(0) & " "
                dt = oh.ExecuteDataSet(Sql8).Tables(0)
                If dt.Rows.Count = 0 Then
                    Sql8 = "select branch_name from before_completion where old_id = " & dtls(0) & " and branch_id is null "
                    dt = oh.ExecuteDataSet(Sql8).Tables(0)
                End If


                Dim tr40 As New TableRow
                Dim tc3 As New TableCell
                tc3.Attributes.Add("width", "100%")
                tc3.ColumnSpan = 30
                tc3.HorizontalAlign = HorizontalAlign.Left
                tc3.Text = "<font size=3><b> Transfer & Posting </b></font>"
                tr40.Controls.Add(tc3)

                tb1.Controls.Add(tr40)
                ''----------------
                'Dim tc33 As New TableCell
                'tc33.Attributes.Add("width", "100%")
                'tc33.ColumnSpan = 10
                'tc33.HorizontalAlign = HorizontalAlign.Left
                'tc33.Text = "<font size=3><b> Employee Code:" & dtls(1) & " </b></font>"
                'tr40.Controls.Add(tc33)

                'tb1.Controls.Add(tr40)
                ''--------------

                Dim tr41 As New TableRow
                Dim tc4 As New TableCell
                tc4.Attributes.Add("width", "100%")
                tc4.ColumnSpan = 35
                tc4.HorizontalAlign = HorizontalAlign.Left
                tc4.Text = "<font size=2><b>----------------------------------------------------- </b></font>"
                tr41.Controls.Add(tc4)

                tb1.Controls.Add(tr41)

                If (dt1.Rows(0)(1) <= 9) Then


                    Dim tr42 As New TableRow
                    Dim tc5 As New TableCell
                    tc5.Attributes.Add("width", "100%")
                    tc5.ColumnSpan = 95
                    tc5.HorizontalAlign = HorizontalAlign.Left
                    tc5.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mr / Ms." & cr_dt(0) & "," & cr_dt(1) & " -" & cr_dt(2) & "," & cr_dt(4) & " branch is transferred from " & cr_dt(4) & " branch and posted at our " & dt.Rows(0)(0) & "  branch as Assistant Branch Head with effect from " & dtls(2) & ". He / She will be relieved from  " & cr_dt(4) & " branch on the close of the  business on " & dtls(3) & " so as to report at " & dt.Rows(0)(0) & " branch on " & dtls(4) & ". </font>"
                    tr42.Controls.Add(tc5)
                    tb1.Controls.Add(tr42)

                    ''--------------------space-------------------

                    Dim td777 As New TableCell
                    Dim tr777 As New TableRow
                    td777.Attributes.Add("width", "100%")
                    td777.ColumnSpan = 95
                    td777.HorizontalAlign = HorizontalAlign.Center
                    td777.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
                    tr777.Controls.Add(td777)
                    tb1.Controls.Add(tr777)

                    ''--------------------space-------------------

                    Dim tr421 As New TableRow
                    Dim tc51 As New TableCell
                    tc51.Attributes.Add("width", "100%")
                    tc51.ColumnSpan = 95
                    tc51.HorizontalAlign = HorizontalAlign.Left
                    tc51.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;He / She will hold the joint responsibility on matters like Branch administration, maintenance of books of accounts, office discipline, and joint custody of the  assets  of the company, securities etc. with the Branch Head,as cited in Circular No.MAGRO-338 dated 24th December,2004. </font>"
                    tr421.Controls.Add(tc51)
                    tb1.Controls.Add(tr421)

                    ''--------------------space-------------------

                    Dim td772 As New TableCell
                    Dim tr772 As New TableRow
                    td772.Attributes.Add("width", "50%")
                    td772.ColumnSpan = 95
                    td772.HorizontalAlign = HorizontalAlign.Center
                    td772.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
                    tr772.Controls.Add(td772)
                    tb1.Controls.Add(tr772)
                    'tb1.Controls.Add(tr772)
                    ''-----------------------------------------------------
                    Dim tr422 As New TableRow
                    Dim tc52 As New TableCell
                    tc52.Attributes.Add("width", "100%")
                    tc52.ColumnSpan = 95
                    tc52.HorizontalAlign = HorizontalAlign.Left
                    tc52.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;He / She is authorised to accept deposits on the behalf of the company  and issue deposit receipts under joint signature with the Branch Head,in accordance with the rules and  regulations in vogue  governing the  issue of the same. In the absence of the Branch Head, he / she will be completely responsible for running the office and authorised to advance loans against  gold ornaments after ascertaining the quality and purity of same, strictly complying with the procedures and rate of advance in vogue.</font>"
                    tr422.Controls.Add(tc52)
                    tb1.Controls.Add(tr422)


                End If
                ''---------------------------------------

                If ((dt1.Rows(0)(1) >= 10 And dt1.Rows(0)(1) <= 18) Or dt1.Rows(0)(1) = 101) Then


                    Dim tr422 As New TableRow
                    Dim tc52 As New TableCell
                    tc52.Attributes.Add("width", "100%")
                    tc52.ColumnSpan = 95
                    tc52.HorizontalAlign = HorizontalAlign.Left
                    tc52.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mr / Ms." & cr_dt(0) & "," & cr_dt(1) & " -" & cr_dt(2) & "," & cr_dt(4) & " branch is transferred from " & cr_dt(4) & " branch and posted at our " & dt.Rows(0)(0) & "  branch as Branch Head with effect from " & dtls(2) & ". He / She will be relieved from  " & cr_dt(4) & " branch on the close of the  business on " & dtls(3) & " so as to report at " & dt.Rows(0)(0) & " branch on " & dtls(4) & ". </font>"
                    tr422.Controls.Add(tc52)
                    tb1.Controls.Add(tr422)

                    ''--------------------space-------------------

                    Dim td77 As New TableCell
                    Dim tr77 As New TableRow
                    td77.Attributes.Add("width", "50%")
                    td77.ColumnSpan = 95
                    td77.HorizontalAlign = HorizontalAlign.Center
                    td77.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
                    tr77.Controls.Add(td77)
                    tb1.Controls.Add(tr77)

                    ''--------------------space-------------------

                    Dim tr424 As New TableRow
                    Dim tc54 As New TableCell
                    tc54.Attributes.Add("width", "100%")
                    tc54.ColumnSpan = 95
                    tc54.HorizontalAlign = HorizontalAlign.Left
                    tc54.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;He / She will take  the  complete charge of " & dt.Rows(0)(0) & " branch from  the  joint custodians  of the branch on or before " & dtls(2) & " and  submit the usual charge  report  in the  prescribed format  CR-1. He / She will be  responsible for branch administration,maintenance of books of accounts, office discipline, and joint custody of the assets of the company, securities etc. with  the Branch Head,  as cited  in  Circular No.MAGRO-338 dated 24th December,2004. </font>"
                    tr424.Controls.Add(tc54)
                    tb1.Controls.Add(tr424)
                    ''--------------------space-------------------

                    Dim td771 As New TableCell
                    Dim tr771 As New TableRow
                    td771.Attributes.Add("width", "50%")
                    td771.ColumnSpan = 95
                    td771.HorizontalAlign = HorizontalAlign.Center
                    td771.Text = "<font size=3 color=black><b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b> </font>"
                    tr771.Controls.Add(td771)
                    tb1.Controls.Add(tr771)
                    tb1.Controls.Add(tr771)
                    ''------------------------------------------------------

                    Dim tr426 As New TableRow
                    Dim tc56 As New TableCell
                    tc56.Attributes.Add("width", "100%")
                    tc56.ColumnSpan = 95
                    tc56.HorizontalAlign = HorizontalAlign.Left
                    tc56.Text = "<font size=3 color=darkblue>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;He/She is authorised to  accept deposits on the  behalf of  the company and issue deposit receipts under joint signature  with the Branch Head,in accordance with  the rules  and  regulations in  vogue governing the issue of the same. In the absence of the Branch Head,  he / she will be completely responsible for running the office and authorised to advance loans against gold ornaments after ascertaining  the quality and purity of same, strictly  complying with  the procedures and  rate of  advance in vogue.  </font>"
                    tr426.Controls.Add(tc56)
                    tb1.Controls.Add(tr426)

                End If
                ''----------------------------------------------

                Dim tr43 As New TableRow
                Dim tc6 As New TableCell
                tc6.Attributes.Add("width", "100%")
                tc6.ColumnSpan = 55
                tc6.HorizontalAlign = HorizontalAlign.Right
                tc6.Text = "<font size=2><b></b></font>"
                tr43.Controls.Add(tc6)

                tb1.Controls.Add(tr43)

                Dim tr44 As New TableRow
                Dim tc61 As New TableCell
                tc61.Attributes.Add("width", "100%")
                tc61.ColumnSpan = 10
                tc61.HorizontalAlign = HorizontalAlign.Left
                tc61.Text = "<font size=2><b></b></font>"
                tr43.Controls.Add(tc61)

                tb1.Controls.Add(tr44)

                Dim tr45 As New TableRow
                Dim tc7 As New TableCell
                tc7.Attributes.Add("width", "100%")
                tc7.ColumnSpan = 10
                tc7.HorizontalAlign = HorizontalAlign.Left
                tc7.Text = "<font size=2><b>  </b></font>"
                tr45.Controls.Add(tc7)

                tb1.Controls.Add(tr45)

                Dim tr146 As New TableRow
                Dim tc18 As New TableCell
                tc18.Attributes.Add("width", "100%")
                tc18.ColumnSpan = 30
                tc18.HorizontalAlign = HorizontalAlign.Left
                tc18.Text = "<font size=2><b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></font>"
                tr146.Controls.Add(tc18)

                tb1.Controls.Add(tr146)

                Dim tr47 As New TableRow
                Dim tc9 As New TableCell
                tc9.Attributes.Add("width", "100%")
                tc9.ColumnSpan = 10
                tc9.HorizontalAlign = HorizontalAlign.Left
                tc9.Text = "<font size=2><b>DGM(HRM) </b></font>"
                tr47.Controls.Add(tc9)

                tb1.Controls.Add(tr47)

                Dim tr452 As New TableRow
                Dim tc72 As New TableCell
                tc72.Attributes.Add("width", "100%")
                tc72.ColumnSpan = 10
                tc72.HorizontalAlign = HorizontalAlign.Left
                tc72.Text = "<font size=2><b>  </b></font>"
                tr452.Controls.Add(tc72)

                tb1.Controls.Add(tr452)

                Dim tr246 As New TableRow
                Dim tc28 As New TableCell
                tc28.Attributes.Add("width", "100%")
                tc28.ColumnSpan = 30
                tc28.HorizontalAlign = HorizontalAlign.Left
                tc28.Text = "<font size=2><b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></font>"
                tr246.Controls.Add(tc28)



                Dim tr48 As New TableRow
                Dim tc10 As New TableCell
                tc10.Attributes.Add("width", "100%")
                tc10.ColumnSpan = 10
                tc10.HorizontalAlign = HorizontalAlign.Left
                tc10.Text = "<font size=2><b> </b></font>"
                tr48.Controls.Add(tc10)

                tb1.Controls.Add(tr48)

                Dim tr49 As New TableRow
                Dim tc11, tc111 As New TableCell
                tc11.Attributes.Add("width", "100%")
                tc111.Attributes.Add("width", "100%")
                tc11.ColumnSpan = 6
                tc111.ColumnSpan = 4
                tc111.HorizontalAlign = HorizontalAlign.Left
                tc11.HorizontalAlign = HorizontalAlign.Left
                tc11.Text = "<font size=2><b> TO </b></font>"
                tc111.Text = "<font size=2><b> </b></font>"
                tr49.Controls.Add(tc11)
                tr49.Controls.Add(tc111)

                tb1.Controls.Add(tr49)

                Dim tr481 As New TableRow
                Dim tc101 As New TableCell
                tc101.Attributes.Add("width", "100%")
                tc101.ColumnSpan = 10
                tc101.HorizontalAlign = HorizontalAlign.Left
                tc101.Text = "<font size=2><b> </b></font>"
                tr481.Controls.Add(tc101)

                tb1.Controls.Add(tr481)

                Dim tr491 As New TableRow
                Dim tc112, tc1111 As New TableCell
                tc112.Attributes.Add("width", "100%")
                tc1111.Attributes.Add("width", "100%")
                tc112.ColumnSpan = 20
                tc1111.ColumnSpan = 10
                tc1111.HorizontalAlign = HorizontalAlign.Left
                tc112.HorizontalAlign = HorizontalAlign.Left
                tc112.Text = "<font size=2><b>  </b></font>"
                tc1111.Text = "<font size=2><b> </b></font>"
                tr491.Controls.Add(tc112)
                tr491.Controls.Add(tc1111)

                tb1.Controls.Add(tr491)



                Dim tr12 As New TableRow
                Dim tc12, tc121 As New TableCell
                tc12.Attributes.Add("width", "100%")
                tc121.Attributes.Add("width", "100%")
                tc12.ColumnSpan = 40
                tc121.ColumnSpan = 10
                tc12.HorizontalAlign = HorizontalAlign.Left
                tc121.HorizontalAlign = HorizontalAlign.Left
                tc12.Text = "<font size=2>Mr/Ms. " & cr_dt(0) & " </font>"
                tc121.Text = "<font size=2><b> </b></font>"
                tr12.Controls.Add(tc12)
                tr12.Controls.Add(tc121)

                tb1.Controls.Add(tr12)

                Dim tr131 As New TableRow
                Dim tc13, tc131 As New TableCell
                tc13.Attributes.Add("width", "100%")
                tc131.Attributes.Add("width", "100%")
                tc13.ColumnSpan = 30
                tc131.ColumnSpan = 4
                tc13.HorizontalAlign = HorizontalAlign.Left
                tc131.HorizontalAlign = HorizontalAlign.Left
                tc13.Text = "<font size=2 color=darkblue>" & cr_dt(1) & " </font>"
                tc131.Text = "<font size=2><b> </b></font>"
                tr131.Controls.Add(tc13)
                tr131.Controls.Add(tc131)

                tb1.Controls.Add(tr131)

                Dim tr141 As New TableRow
                Dim tc14, tc141 As New TableCell
                tc14.Attributes.Add("width", "100%")
                tc141.Attributes.Add("width", "100%")
                tc14.ColumnSpan = 25
                tc141.ColumnSpan = 4
                tc14.HorizontalAlign = HorizontalAlign.Left
                tc141.HorizontalAlign = HorizontalAlign.Left
                tc14.Text = "<font size=2 color=darkblue>" & cr_dt(2) & " </font>"
                tc141.Text = "<font size=2><b> </b></font>"
                tr141.Controls.Add(tc14)
                tr141.Controls.Add(tc141)

                tb1.Controls.Add(tr141)

                Dim tr151 As New TableRow
                Dim tc15, tc151 As New TableCell
                tc15.Attributes.Add("width", "100%")
                tc151.Attributes.Add("width", "100%")
                tc15.ColumnSpan = 25
                tc151.ColumnSpan = 4
                tc15.HorizontalAlign = HorizontalAlign.Left
                tc151.HorizontalAlign = HorizontalAlign.Left
                tc15.Text = "<font size=2 color=darkblue>" & cr_dt(3) & " </font>"
                tc151.Text = "<font size=2><b> </b></font>"
                tr151.Controls.Add(tc15)
                tr151.Controls.Add(tc151)

                tb1.Controls.Add(tr151)

                Dim tr161 As New TableRow
                Dim tc16, tc161 As New TableCell
                tc16.Attributes.Add("width", "100%")
                tc161.Attributes.Add("width", "100%")
                tc16.ColumnSpan = 25
                tc161.ColumnSpan = 4
                tc16.HorizontalAlign = HorizontalAlign.Left
                tc161.HorizontalAlign = HorizontalAlign.Left
                tc16.Text = "<font size=2 color=darkblue>" & cr_dt(4) & " </font>"
                tc161.Text = "<font size=2><b> </b></font>"
                tr161.Controls.Add(tc16)
                tr161.Controls.Add(tc161)

                tb1.Controls.Add(tr161)

                ''-------------------------
                Dim tr494 As New TableRow
                Dim tc114, tc1114 As New TableCell
                tc114.Attributes.Add("width", "100%")
                tc1114.Attributes.Add("width", "100%")
                tc114.ColumnSpan = 20
                tc1114.ColumnSpan = 10
                tc1114.HorizontalAlign = HorizontalAlign.Left
                tc114.HorizontalAlign = HorizontalAlign.Left
                tc114.Text = "<font size=2><b>  </b></font>"
                tc1114.Text = "<font size=2><b> </b></font>"
                tr494.Controls.Add(tc114)
                tr494.Controls.Add(tc1114)

                tb1.Controls.Add(tr494)



                Dim tr126 As New TableRow
                Dim tc126, tc127 As New TableCell
                tc126.Attributes.Add("width", "100%")
                tc127.Attributes.Add("width", "100%")
                tc126.ColumnSpan = 80
                tc127.ColumnSpan = 10
                tc126.HorizontalAlign = HorizontalAlign.Left
                tc127.HorizontalAlign = HorizontalAlign.Left
                tc126.Text = "<font size=2><b>CC : BH- " & cr_dt(4) & " / BH- " & dt.Rows(0)(0) & "/HRM</b></font>"
                tc127.Text = "<font size=2><b> </b></font>"
                tr126.Controls.Add(tc126)
                tr126.Controls.Add(tc127)

                tb1.Controls.Add(tr126)



            End If



            ''-------------------------------------------------
            Me.Panel2.Controls.Add(tb1)
            ''-------------------------------------------------------
        End If

    End Sub
End Class
