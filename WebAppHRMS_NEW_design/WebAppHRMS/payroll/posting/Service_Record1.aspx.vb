Imports System.Data
Imports System.Data.OracleClient

Partial Class Service_Record1_92f15ef18726
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Dim dr, dr1 As DataRow
    Dim str, str1, str2, str3, str4 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim epn As String = Me.Request.QueryString("emp")
        Dim ratiotable As New Table


        Dim sr As New TableRow
        sr.Width = 100
        Dim sr1 As New TableCell
        sr1.ColumnSpan = 100
        sr1.HorizontalAlign = HorizontalAlign.Center
        sr1.Text = "<b><font size=3>Form&nbsp;&nbsp;B&nbsp;&nbsp;B&nbsp;</font></b>"
        sr.Controls.Add(sr1)
        ratiotable.Controls.Add(sr)

        Dim srr As New TableRow
        srr.Width = 100
        Dim srr1 As New TableCell
        srr1.ColumnSpan = 100
        srr1.HorizontalAlign = HorizontalAlign.Center
        srr1.Text = "<font size=2>[See&nbsp;&nbsp;Rule(10)&nbsp;&nbsp;1A]&nbsp;</font>"
        srr.Controls.Add(srr1)
        ratiotable.Controls.Add(srr)



      


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell

        subcell1.ColumnSpan = 20
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 20
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 20
        subcell3.HorizontalAlign = HorizontalAlign.Left
        subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        ratiotable.Controls.Add(subh)

        Dim tt As New TableRow
        tt.Width = 100
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 100
        tt1.HorizontalAlign = HorizontalAlign.Center         
        tt1.Text = "<b><font size=3>SERVICE&nbsp;&nbsp;RECORD&nbsp;&nbsp;</font></b>"
        tt.Controls.Add(tt1)
        ratiotable.Controls.Add(tt)


        Dim line As New TableRow
        Dim linecell As New TableCell
        linecell.ColumnSpan = 100
        linecell.Text = "<hr>"
        line.Controls.Add(linecell)
        ratiotable.Controls.Add(line)


        Dim user() As String

        user = Session("user_id").ToString.Split("!")

        '   dt = oh.ExecuteDataSet("select em.emp_name as Name_of_Employee,  ep.father_name as Name_of_Father,    case         when ep.birth_date is not null then          floor(to_number(to_date(sysdate) - to_date(ep.birth_date)) / 360)       end as Age,       ep.perm_add1 as Full_Residential_Address,       decode(ep.sex, 1, 'MALE', 0, 'FEMALE') as Sex,       em.join_dt as Date_Of_Entry_To_Service,       dm.designation as Designation,decode(ed.discont_dt, null , ' --- ',ed.discont_dt) as Resignation_Date from employee_master     em,       employ_personal_dtl ep,       designation_master  dm,       employee_master_dtl ed where em.designation_id = dm.designation_id and em.emp_code = ep.emp_code and em.emp_code = ed.emp_code and em.emp_code =" & user(0)).Tables(0)
        'dt = oh.ExecuteDataSet("select em.emp_name as Name_of_Employee,  ep.father_name as Name_of_Father,    case         when ep.birth_date is not null then          floor(to_number(to_date(sysdate) - to_date(ep.birth_date)) / 360)       end as Age,       ep.perm_add1 as Full_Residential_Address,       decode(ep.sex, 1, 'MALE', 0, 'FEMALE') as Sex,       em.join_dt as Date_Of_Entry_To_Service,       dm.designation as Designation,decode(ed.discont_dt, null , ' --- ',ed.discont_dt) as Resignation_Date from employee_master     em,       employ_personal_dtl ep,       designation_master  dm,       employee_master_dtl ed where em.designation_id = dm.designation_id and em.emp_code = ep.emp_code and em.emp_code = ed.emp_code and em.emp_code =" & epn & "").Tables(0)
        dt = oh.ExecuteDataSet("select em.emp_name as Name_of_Employee,  ep.father_name as Name_of_Father,    case         when ep.birth_date is not null then          floor(to_number(to_date(sysdate) - to_date(ep.birth_date)) / 360)       end as Age,       ep.perm_add1 as Full_Residential_Address,       decode(ep.sex, 1, 'MALE', 0, 'FEMALE') as Sex,       to_date(e.from_dt) as Date_Of_Entry_To_Service,       dm.designation as Designation,decode(ed.discont_dt, null , ' --- ',ed.discont_dt) as Resignation_Date from employee_master     em,       employ_personal_dtl ep,       designation_master  dm,       employee_master_dtl ed,employ_promotion_dtl e where  em.emp_code = ep.emp_code and e.designation_id = dm.designation_id and em.emp_code = ed.emp_code and e.emp_code = em.emp_code and em.emp_code =" & epn & "").Tables(0)


        Dim Name As String = dt.Rows(0)(0)
        Dim Father_Name As String = dt.Rows(0)(1)
        Dim Age As Integer = dt.Rows(0)(2)
        Dim Address As String = dt.Rows(0)(3)
        Dim sex As String = dt.Rows(0)(4)
        Dim date_of_join As Date = dt.Rows(0)(5)
        Dim Designation As String = dt.Rows(0)(6)
        Dim resignation_date As String = dt.Rows(0)(7)


        'Dim Name As String = dr1(0)
        'Dim Father_Name As String = dr1(1)
        'Dim Age As Integer = dr1(2)
        'Dim Address As String = dr1(3)
        'Dim sex As String = dr1(4)
        'Dim date_of_join As Date = Format(dr(5), "dd-mm-yyyy")
        'Dim Designation As String = dr1(6)
        'Dim resignation_date As String = dr1(7)


        Dim a1, a2, a3, a4, a5, a8, a9, a10, a11, a12, note As New TableRow

        a9.Width = 8
        Dim a9a, a9b As New TableCell
        a9a.ColumnSpan = 20
        a9b.ColumnSpan = 100

        a9a.HorizontalAlign = HorizontalAlign.Left

        a9b.HorizontalAlign = HorizontalAlign.Right
        a9a.Text = "<b><font size=2>1.&nbsp;&nbsp;Name&nbsp;&nbsp;of&nbsp;&nbsp;the&nbsp;&nbsp;Establishment&nbsp:</font></b>"
        a9b.Text = "<font size=2>" & Session("firm_name") & "</font>"
        a9.Controls.Add(a9a)
        a9.Controls.Add(a9b)
        ratiotable.Controls.Add(a9)

        a1.Width = 8
        Dim a1a, a1b As New TableCell
        a1a.ColumnSpan = 20
        a1b.ColumnSpan = 100

        a1a.HorizontalAlign = HorizontalAlign.Left

        a1b.HorizontalAlign = HorizontalAlign.Right
        a1a.Text = "<b><font size=2>2.&nbsp;&nbsp;Name&nbsp;&nbsp;Of&nbsp;&nbsp;the&nbsp;&nbsp;Employee&nbsp:</font></b>"
        a1b.Text = "<font size=2>" & Name & "</font>"
        a1.Controls.Add(a1a)
        a1.Controls.Add(a1b)
        ratiotable.Controls.Add(a1)

        a2.Width = 8
        Dim a2a, a2b As New TableCell
        a2a.ColumnSpan = 20
        a2b.ColumnSpan = 100
        a2a.HorizontalAlign = HorizontalAlign.Left
        a2b.HorizontalAlign = HorizontalAlign.Right
        a2a.Text = "<b><font size=2>3.&nbsp;&nbsp;Name&nbsp;&nbsp;Of&nbsp;&nbsp;the&nbsp;&nbsp;Father&nbsp;/Husband&nbsp;&nbsp:</font></b>"
        a2b.Text = "<font size=2>" & Father_Name & "</font>"
        a2.Controls.Add(a2a)
        a2.Controls.Add(a2b)
        ratiotable.Controls.Add(a2)

        a3.Width = 8
        Dim a3a, a3b As New TableCell
        a3a.ColumnSpan = 20
        a3b.ColumnSpan = 100
        a3a.HorizontalAlign = HorizontalAlign.Left
        a3b.HorizontalAlign = HorizontalAlign.Right
        a3a.Text = "<b><font size=2>4.&nbsp;&nbsp;Age&nbsp:</font></b>"
        a3b.Text = "<font size=2>" & Age & "</font>"
        a3.Controls.Add(a3a)
        a3.Controls.Add(a3b)
        ratiotable.Controls.Add(a3)

        a4.Width = 8
        Dim a4a, a4b As New TableCell
        a4a.ColumnSpan = 20
        a4b.ColumnSpan = 100
        a4a.HorizontalAlign = HorizontalAlign.Left
        a4b.HorizontalAlign = HorizontalAlign.Right
        a4a.Text = "<b><font size=2>5.&nbsp;&nbsp;Full&nbsp;&nbsp;Residential&nbsp;&nbsp;Address&nbsp:</font></b>"
        a4b.Text = "<font size=2>" & Address & "</font>"
        a4.Controls.Add(a4a)
        a4.Controls.Add(a4b)
        ratiotable.Controls.Add(a4)

        a5.Width = 8
        Dim a5a, a5b As New TableCell
        a5a.ColumnSpan = 20
        a5b.ColumnSpan = 100
        a5a.HorizontalAlign = HorizontalAlign.Left
        a5b.HorizontalAlign = HorizontalAlign.Right
        a5a.Text = "<b><font size=2>6.&nbsp;&nbsp;Sex&nbsp:</font></b>"
        a5b.Text = "<font size=2>" & sex & "</font>"
        a5.Controls.Add(a5a)
        a5.Controls.Add(a5b)
        ratiotable.Controls.Add(a5)

        For Each dr1 In dt.Rows


            Dim date_of_join1 As Date = Format(dr1(5), "dd-MMM-yyyy")
            Dim Designation1 As String = dr1(6)
            Dim a6, a7 As New TableRow
            a6.Width = 8
            Dim a6a, a6b As New TableCell
            a6a.ColumnSpan = 20
            a6b.ColumnSpan = 100
            a6a.HorizontalAlign = HorizontalAlign.Left
            a6b.HorizontalAlign = HorizontalAlign.Right
            a6a.Text = "<b><font size=2>7.&nbsp;&nbsp;Date&nbsp;&nbsp;of&nbsp;&nbsp;entry&nbsp;&nbsp;into&nbsp;&nbsp;service&nbsp:</font></b>"
            a6b.Text = "<font size=2>" & date_of_join1 & "</font>"
            a6.Controls.Add(a6a)
            a6.Controls.Add(a6b)
            ratiotable.Controls.Add(a6)




            a7.Width = 8
            Dim a7a, a7b As New TableCell
            a7a.ColumnSpan = 20
            a7b.ColumnSpan = 100
            a7a.HorizontalAlign = HorizontalAlign.Left
            a7b.HorizontalAlign = HorizontalAlign.Right
            a7a.Text = "<b><font size=2>8.&nbsp;&nbsp;Category/Designation&nbsp:</font></b>"
            a7b.Text = "<font size=2>" & Designation1 & "</font>"
            a7.Controls.Add(a7a)
            a7.Controls.Add(a7b)
            ratiotable.Controls.Add(a7)

        Next


        'Dim ttk1 As New TableRow
        'ttk1.Width = 8
        'Dim tt11 As New TableCell
        'tt11.ColumnSpan = 200
        'tt11.HorizontalAlign = HorizontalAlign.Center
        'tt11.Text = "<b><font size=3>BasicPay&nbsp;&nbsp;and&nbsp;&nbsp;D.A&nbsp;&nbsp</font></b>"
        'ttk1.Controls.Add(tt11)
        'ratiotable.Controls.Add(ttk1)


        Dim liney As New TableRow
        Dim linecelly As New TableCell
        linecelly.ColumnSpan = 100
        linecelly.Text = "<hr>"
        liney.Controls.Add(linecelly)
        ratiotable.Controls.Add(liney)




        '   str1 = "select p.basic_pay, p.from_dt,p.to_dt from employ_promotion_dtl p  where p.emp_code =" & user(0)
        'str1 = "select p.basic_pay, to_date(p.from_dt),nvl(p.to_dt,to_date(sysdate)) from employ_promotion_dtl p  where p.emp_code =" & epn & " order by to_date(p.from_dt)"
        str1 = "select p.basic_pay,w.actual_da,to_date(p.from_dt), nvl(p.to_dt, to_date(sysdate))  from employ_promotion_dtl p, m_wage w where p.emp_code = " & epn & " and p.emp_code = w.emp_code order by to_date(p.from_dt)"

        dt1 = oh.ExecuteDataSet(str1).Tables(0)
        For Each dr In dt1.Rows
            'Dim BasicPay As Integer = dt1.Rows(0)(0)
            'Dim Fromdt As Date = dt1.Rows(0)(1)
            'Dim Todt As Date = dt1.Rows(0)(2)

            Dim BasicPay As Integer = dr(0)
            Dim actualda As Integer = dr(1)
            Dim Fromdt As Date = Format(dr(2), "dd-MMM-yyyy")
            Dim Todt As Date = Format(dr(3), "dd-MMM-yyyy")

            Dim b1, b2, b3, b4 As New TableRow
            b1.Width = 8

            Dim b1a, b1b As New TableCell
            b1a.ColumnSpan = 20
            b1b.ColumnSpan = 100

            b1a.HorizontalAlign = HorizontalAlign.Left

            b1b.HorizontalAlign = HorizontalAlign.Right
            b1a.Text = "<b><font size=2>9.&nbsp;&nbsp;Pay&nbsp:</font></b>"
            b1b.Text = "<font size=2>" & BasicPay & "</font>"
            b1.Controls.Add(b1a)
            b1.Controls.Add(b1b)
            ratiotable.Controls.Add(b1)


            b4.Width = 8

            Dim b4a, b4b As New TableCell
            b4a.ColumnSpan = 20
            b4b.ColumnSpan = 100

            b4a.HorizontalAlign = HorizontalAlign.Left

            b4b.HorizontalAlign = HorizontalAlign.Right
            b4a.Text = "<b><font size=2>D.A.&nbsp:</font></b>"
            b4b.Text = "<font size=2>" & actualda & "</font>"
            b4.Controls.Add(b4a)
            b4.Controls.Add(b4b)
            ratiotable.Controls.Add(b4)


            b2.Width = 8
            ' b2.BackColor = Drawing.Color.SeaShell
            Dim b2a, b2b As New TableCell
            b2a.ColumnSpan = 20
            b2b.ColumnSpan = 100
            b2a.HorizontalAlign = HorizontalAlign.Left
            b2b.HorizontalAlign = HorizontalAlign.Right
            b2a.Text = "<b><font size=2>From&nbsp;&nbsp;Date&nbsp;&nbsp:</font></b>"
            b2b.Text = "<font size=2>" & Fromdt & "</font>"
            b2.Controls.Add(b2a)
            b2.Controls.Add(b2b)
            ratiotable.Controls.Add(b2)

            b3.Width = 8

            Dim b3a, b3b As New TableCell
            b3a.ColumnSpan = 20
            b3b.ColumnSpan = 100
            b3a.HorizontalAlign = HorizontalAlign.Left
            b3b.HorizontalAlign = HorizontalAlign.Right
            b3a.Text = "<b><font size=2>To&nbsp;&nbsp;Date&nbsp;&nbsp:</font></b>"
            b3b.Text = "<font size=2>" & Todt & "</font>"
            b3.Controls.Add(b3a)
            b3.Controls.Add(b3b)
            ratiotable.Controls.Add(b3)
        Next


        Dim linex As New TableRow
        Dim linecellx As New TableCell
        linecellx.ColumnSpan = 100
        linecellx.Text = "<hr>"
        linex.Controls.Add(linecellx)
        ratiotable.Controls.Add(linex)



        a8.Width = 8

        Dim a8a, a8b As New TableCell
        a8a.ColumnSpan = 20
        a8b.ColumnSpan = 100
        a8a.HorizontalAlign = HorizontalAlign.Left
        a8b.HorizontalAlign = HorizontalAlign.Right
        a8a.Text = "<b><font size=2>10.&nbsp;&nbsp;Date&nbsp;&nbsp;of&nbsp;&nbsp;Retrenchment/Discharge/Dismissal/Retirement/Resignation&nbsp:</font></b>"
        a8b.Text = "<font size=2>" & resignation_date & "</font>"
        a8.Controls.Add(a8a)
        a8.Controls.Add(a8b)
        ratiotable.Controls.Add(a8)



        a10.Width = 8

        Dim a10a, a10b As New TableCell
        a10a.ColumnSpan = 20
        a10b.ColumnSpan = 100
        a10a.HorizontalAlign = HorizontalAlign.Left
        a10b.HorizontalAlign = HorizontalAlign.Right
        a10a.Text = "<b><font size=2>11.&nbsp;&nbsp;Signature&nbsp;&nbsp;of&nbsp;&nbsp;the&nbsp;&nbsp;Employee&nbsp;&nbsp:</font></b>"
        a10.Controls.Add(a10a)
        a10.Controls.Add(a10b)
        ratiotable.Controls.Add(a10)

        a11.Width = 8

        Dim a11a, a11b As New TableCell
        a11a.ColumnSpan = 20
        a11b.ColumnSpan = 100
        a11a.HorizontalAlign = HorizontalAlign.Left
        a11b.HorizontalAlign = HorizontalAlign.Right
        a11a.Text = "<b><font size=2>12.&nbsp;&nbsp;Signature&nbsp;&nbsp;of&nbsp;&nbsp;the&nbsp;&nbsp;Employer&nbsp;&nbsp:</font></b>"
        a11.Controls.Add(a11a)
        a11.Controls.Add(a11b)
        ratiotable.Controls.Add(a11)


        a12.Width = 8

        Dim a12a, a12b As New TableCell
        a12a.ColumnSpan = 20
        a12b.ColumnSpan = 100
        a12a.HorizontalAlign = HorizontalAlign.Left
        a12b.HorizontalAlign = HorizontalAlign.Right
        a12a.Text = "<b><font size=2>13.&nbsp;&nbsp;Counter&nbsp;&nbsp;signature&nbsp;&nbsp;of&nbsp;&nbsp;the&nbsp;&nbsp;Inspector&nbsp;&nbsp:</font></b>"
        a12.Controls.Add(a12a)
        a12.Controls.Add(a12b)
        ratiotable.Controls.Add(a12)



        Dim linexx As New TableRow
        Dim linecellxx As New TableCell
        linecellxx.ColumnSpan = 100
        linecellxx.Text = "<hr>"
        linexx.Controls.Add(linecellxx)
        ratiotable.Controls.Add(linexx)

        note.Width = 8
        Dim note1, note2 As New TableCell
        note1.ColumnSpan = 20
        note2.ColumnSpan = 100
        note1.HorizontalAlign = HorizontalAlign.Left
        note2.HorizontalAlign = HorizontalAlign.Right
        note1.Text = "<b><font size=2>Note:- &nbsp;&nbsp;Whenever&nbsp;&nbsp;there&nbsp;&nbsp;is&nbsp;&nbsp;in&nbsp;&nbsp;Designation&nbsp;&nbsp;and&nbsp;&nbsp;wages,&nbsp;<br>&nbsp;the&nbsp;&nbsp;changes&nbsp;&nbsp;shall&nbsp;&nbsp;be&nbsp;&nbsp;noted&nbsp;&nbsp;in&nbsp;&nbsp;<br>columns&nbsp;&nbsp;8&nbsp;&nbsp;and&nbsp;&nbsp;9&nbsp;&nbsp;respoectively&nbsp;&nbsp;with&nbsp;&nbsp;the&nbsp;&nbsp;date&nbsp;&nbsp;of&nbsp;&nbsp;such&nbsp;&nbsp;changes&nbsp;&nbsp</font></b></br></br>"
        note.Controls.Add(note1)
        note.Controls.Add(note2)
        ratiotable.Controls.Add(note)





        'Dim linexy As New TableRow
        'Dim linecellxy As New TableCell
        'linecellxy.ColumnSpan = 100
        'linecellxy.Text = "<hr>"
        'linexy.Controls.Add(linecellxy)
        'ratiotable.Controls.Add(linexy)


        Panel1.Controls.Add(ratiotable)



    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Server.Transfer("../home.aspx")
    End Sub
End Class
