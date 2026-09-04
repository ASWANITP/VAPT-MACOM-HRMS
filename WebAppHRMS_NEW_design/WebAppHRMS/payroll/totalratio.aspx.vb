Imports System.Data
Imports System.Data.OracleClient
Partial Class mfratio_totalratio_a1fd015b5477
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Dim dr As DataRow
    Dim str, str1, str2, str3, str4 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ratiotable As New Table
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Lavender
        header.ForeColor = Drawing.Color.Black
        header.Width = 8
        Dim headercell As New TableCell
        headercell.ColumnSpan = 8
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        ratiotable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 8
        sheader.BackColor = Drawing.Color.AliceBlue
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 8
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        ratiotable.Controls.Add(sheader)

       
        Dim subh As New TableRow
        subh.BackColor = Drawing.Color.SeaShell
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 8

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 4
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 2
        subcell3.HorizontalAlign = HorizontalAlign.Left
        'subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        ratiotable.Controls.Add(subh)

        Dim tt As New TableRow
        tt.BackColor = Drawing.Color.Honeydew
        tt.ForeColor = Drawing.Color.Blue
        tt.Width = 8
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 8
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>Total&nbsp;&nbsp;Employees&nbsp;&nbsp;and&nbsp;&nbsp;Ratio&nbsp;&nbsp;Report&nbsp;</font></b>"
        tt.Controls.Add(tt1)
        ratiotable.Controls.Add(tt)


        Dim line As New TableRow
        Dim linecell As New TableCell
        linecell.ColumnSpan = 8
        linecell.Text = "<hr>"
        line.Controls.Add(linecell)
        ratiotable.Controls.Add(line)

        '////////////////  total employees,male,female count and %   //////////////////////////////////////

        'dt = oh.ExecuteDataSet("select count(case pd.sex when 1 then 1 else 0 end),decode(pd.sex,1,'male',0,'female') as sex from employee_master em,employ_personal_dtl pd where em.emp_code=pd.emp_code and em.status_id=1 and em.emp_code>9999 group by sex").Tables(0)
        dt = oh.ExecuteDataSet("select count(em.emp_code) as total,  count(decode(pd.sex, 1, 1)) as male,  count(decode(pd.sex, 0, 1)) as female  from employee_master em, employ_personal_dtl pd,employ_firm f  where em.emp_code = pd.emp_code  and em.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and em.status_id = 1  and em.emp_code > 9999").Tables(0)
        Dim total As Integer = dt.Rows(0)(0)
        Dim male As Integer = dt.Rows(0)(1)
        Dim female As Integer = dt.Rows(0)(2)
        Dim maleper As Double = FormatNumber(male / total * 100, 2)
        Dim femaleper As Double = FormatNumber(female / total * 100, 2)
        'dim malefemale as Double =FormatNumber(


        Dim a1, a2, a3, a4, a5, a6 As New TableRow
        a1.Width = 8
        a1.BackColor = Drawing.Color.WhiteSmoke
        Dim a1a, a1b As New TableCell
        a1a.ColumnSpan = 4
        a1b.ColumnSpan = 4

        a1a.HorizontalAlign = HorizontalAlign.Left

        a1b.HorizontalAlign = HorizontalAlign.Right
        a1a.Text = "<b><font size=2>Total&nbsp;&nbsp;Staffs:</font></b>"
        a1b.Text = "<font size=2>" & total & "</font>"
        a1.Controls.Add(a1a)
        a1.Controls.Add(a1b)
        ratiotable.Controls.Add(a1)

        a2.Width = 8
        a2.BackColor = Drawing.Color.SeaShell
        Dim a2a, a2b As New TableCell
        a2a.ColumnSpan = 4
        a2b.ColumnSpan = 4
        a2a.HorizontalAlign = HorizontalAlign.Left
        a2b.HorizontalAlign = HorizontalAlign.Right
        a2a.Text = "<b><font size=2>Total&nbsp;&nbsp;Male&nbsp;&nbsp;Staffs:</font></b>"
        a2b.Text = "<font size=2>" & male & "</font>"
        a2.Controls.Add(a2a)
        a2.Controls.Add(a2b)
        ratiotable.Controls.Add(a2)

        a3.Width = 8
        a3.BackColor = Drawing.Color.WhiteSmoke
        Dim a3a, a3b As New TableCell
        a3a.ColumnSpan = 4
        a3b.ColumnSpan = 4
        a3a.HorizontalAlign = HorizontalAlign.Left
        a3b.HorizontalAlign = HorizontalAlign.Right
        a3a.Text = "<b><font size=2>Total&nbsp;&nbsp;Female&nbsp;&nbsp;Staffs:</font></b>"
        a3b.Text = "<font size=2>" & female & "</font>"
        a3.Controls.Add(a3a)
        a3.Controls.Add(a3b)
        ratiotable.Controls.Add(a3)

        a4.Width = 8
        a4.BackColor = Drawing.Color.SeaShell
        Dim a4a, a4b As New TableCell
        a4a.ColumnSpan = 4
        a4b.ColumnSpan = 4
        a4a.HorizontalAlign = HorizontalAlign.Left
        a4b.HorizontalAlign = HorizontalAlign.Right
        a4a.Text = "<b><font size=2>Male&nbsp;&nbsp;&nbsp;Percentage:&nbsp;</font></b>"
        a4b.Text = "<font size=2>" & maleper & "</font>"
        a4.Controls.Add(a4a)
        a4.Controls.Add(a4b)
        ratiotable.Controls.Add(a4)

        a5.Width = 8
        a5.BackColor = Drawing.Color.WhiteSmoke
        Dim a5a, a5b As New TableCell
        a5a.ColumnSpan = 4
        a5b.ColumnSpan = 4
        a5a.HorizontalAlign = HorizontalAlign.Left
        a5b.HorizontalAlign = HorizontalAlign.Right
        a5a.Text = "<b><font size=2>Female&nbsp;&nbsp;&nbsp;Percentage:&nbsp;</font></b>"
        a5b.Text = "<font size=2>" & femaleper & "</font>"
        a5.Controls.Add(a5a)
        a5.Controls.Add(a5b)
        ratiotable.Controls.Add(a5)

        Dim free As New TableRow
        free.Width = 8
        free.BackColor = Drawing.Color.Linen
        free.ForeColor = Drawing.Color.Red
        Dim f1 As New TableCell
        f1.ColumnSpan = 8
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>*****</font></b>"
        free.Controls.Add(f1)
        ratiotable.Controls.Add(free)


        Dim linez As New TableRow
        Dim linecellz As New TableCell
        linecellz.ColumnSpan = 8
        linecellz.Text = "<hr>"
        linez.Controls.Add(linecellz)
        ratiotable.Controls.Add(linez)

        '//////////////////////////////////  employees total,permanant,outsource and %  /////////////////////////////////////////////////


        Dim ttk1 As New TableRow
        ttk1.BackColor = Drawing.Color.Honeydew
        ttk1.ForeColor = Drawing.Color.Blue
        ttk1.Width = 8
        Dim tt11 As New TableCell
        tt11.ColumnSpan = 8
        tt11.HorizontalAlign = HorizontalAlign.Center
        tt11.Text = "<b><font size=3>Permanant&nbsp;&nbsp;Employees,&nbsp;&nbsp;Outsource&nbsp;&nbsp;Employees&nbsp;&nbsp;and&nbsp;&nbsp;their&nbsp;&nbsp;Ratio&nbsp;&nbsp;Report&nbsp;</font></b>"
        ttk1.Controls.Add(tt11)
        ratiotable.Controls.Add(ttk1)

        Dim liney As New TableRow
        Dim linecelly As New TableCell
        linecelly.ColumnSpan = 8
        linecelly.Text = "<hr>"
        liney.Controls.Add(linecelly)
        ratiotable.Controls.Add(liney)

        str1 = "select count(e.emp_code) as total,  count(decode(e.emp_type, 1, 1)) as permanant,  count(decode(e.emp_type, 2, 1)) as outsource  from employee_master e, employ_personal_dtl pd,employ_firm f  where e.emp_code = pd.emp_code  and e.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and e.status_id = 1  and e.emp_code > 9999"
        dt1 = oh.ExecuteDataSet(str1).Tables(0)
        Dim permanant As Integer = 0
        Dim outsource As Integer = 0
        total = dt1.Rows(0)(0)
        permanant = dt1.Rows(0)(1)
        outsource = dt1.Rows(0)(2)
        Dim permper As Double = FormatNumber(permanant / total * 100, 2)
        Dim outper As Double = FormatNumber(outsource / total * 100, 2)

       
        Dim b1, b2, b3, b4, b5, b6 As New TableRow
        b1.Width = 8
        b1.BackColor = Drawing.Color.WhiteSmoke
        Dim b1a, b1b As New TableCell
        b1a.ColumnSpan = 4
        b1b.ColumnSpan = 4

        b1a.HorizontalAlign = HorizontalAlign.Left

        b1b.HorizontalAlign = HorizontalAlign.Right
        b1a.Text = "<b><font size=2>Total&nbsp;&nbsp;Staffs:</font></b>"
        b1b.Text = "<font size=2>" & total & "</font>"
        b1.Controls.Add(b1a)
        b1.Controls.Add(b1b)
        ratiotable.Controls.Add(b1)

        b2.Width = 8
        b2.BackColor = Drawing.Color.SeaShell
        Dim b2a, b2b As New TableCell
        b2a.ColumnSpan = 4
        b2b.ColumnSpan = 4
        b2a.HorizontalAlign = HorizontalAlign.Left
        b2b.HorizontalAlign = HorizontalAlign.Right
        b2a.Text = "<b><font size=2>Total&nbsp;&nbsp;Permanant&nbsp;&nbsp;Staffs:</font></b>"
        b2b.Text = "<font size=2>" & permanant & "</font>"
        b2.Controls.Add(b2a)
        b2.Controls.Add(b2b)
        ratiotable.Controls.Add(b2)

        b3.Width = 8
        b3.BackColor = Drawing.Color.WhiteSmoke
        Dim b3a, b3b As New TableCell
        b3a.ColumnSpan = 4
        b3b.ColumnSpan = 4
        b3a.HorizontalAlign = HorizontalAlign.Left
        b3b.HorizontalAlign = HorizontalAlign.Right
        b3a.Text = "<b><font size=2>Total&nbsp;&nbsp;Outsource&nbsp;&nbsp;Staffs:</font></b>"
        b3b.Text = "<font size=2>" & outsource & "</font>"
        b3.Controls.Add(b3a)
        b3.Controls.Add(b3b)
        ratiotable.Controls.Add(b3)

        b4.Width = 8
        b4.BackColor = Drawing.Color.SeaShell
        Dim b4a, b4b As New TableCell
        b4a.ColumnSpan = 4
        b4b.ColumnSpan = 4
        b4a.HorizontalAlign = HorizontalAlign.Left
        b4b.HorizontalAlign = HorizontalAlign.Right
        b4a.Text = "<b><font size=2>Permanant&nbsp;&nbsp;&nbsp;Percentage:&nbsp;</font></b>"
        b4b.Text = "<font size=2>" & permper & "</font>"
        b4.Controls.Add(b4a)
        b4.Controls.Add(b4b)
        ratiotable.Controls.Add(b4)

        b5.Width = 8
        b5.BackColor = Drawing.Color.WhiteSmoke
        Dim b5a, b5b As New TableCell
        b5a.ColumnSpan = 4
        b5b.ColumnSpan = 4
        b5a.HorizontalAlign = HorizontalAlign.Left
        b5b.HorizontalAlign = HorizontalAlign.Right
        b5a.Text = "<b><font size=2>Outsource&nbsp;&nbsp;&nbsp;Percentage:&nbsp;</font></b>"
        b5b.Text = "<font size=2>" & outper & "</font>"
        b5.Controls.Add(b5a)
        b5.Controls.Add(b5b)
        ratiotable.Controls.Add(b5)

        Dim freeb As New TableRow
        freeb.Width = 8
        freeb.BackColor = Drawing.Color.Linen
        freeb.ForeColor = Drawing.Color.Red
        Dim f1b As New TableCell
        f1b.ColumnSpan = 8
        f1b.HorizontalAlign = HorizontalAlign.Center
        f1b.Text = "<b><font size=2>*****</font></b>"
        freeb.Controls.Add(f1b)
        ratiotable.Controls.Add(freeb)


        Dim linex As New TableRow
        Dim linecellx As New TableCell
        linecellx.ColumnSpan = 8
        linecellx.Text = "<hr>"
        linex.Controls.Add(linecellx)
        ratiotable.Controls.Add(linex)

        '///////////////////////////////////////////////////// permanant employees,male,female and %   //////////////////////////////

        Dim ttk2 As New TableRow
        ttk2.BackColor = Drawing.Color.Honeydew
        ttk2.ForeColor = Drawing.Color.Blue
        ttk2.Width = 8
        Dim tt12 As New TableCell
        tt12.ColumnSpan = 8
        tt12.HorizontalAlign = HorizontalAlign.Center
        tt12.Text = "<b><font size=3>Permanant&nbsp;&nbsp;Employees&nbsp;&nbsp;Male&nbsp;&nbsp;Female&nbsp;&nbsp;Ratio&nbsp;&nbsp;Report&nbsp;</font></b>"
        ttk2.Controls.Add(tt12)
        ratiotable.Controls.Add(ttk2)

        Dim linew As New TableRow
        Dim linecellw As New TableCell
        linecellw.ColumnSpan = 8
        linecellw.Text = "<hr>"
        linew.Controls.Add(linecellw)
        ratiotable.Controls.Add(linew)

        str2 = "select count(em.emp_code)  from employee_master em, employ_personal_dtl pd,employ_firm f  where em.emp_code = pd.emp_code  and em.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and em.status_id = 1  and em.emp_code > 9999  and em.emp_type = 1  and pd.sex = 1  union all  select count(em.emp_code)  from employee_master em, employ_personal_dtl pd,employ_firm f  where em.emp_code = pd.emp_code  and em.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and em.status_id = 1  and em.emp_code > 9999  and em.emp_type = 1  and pd.sex = 0"
        dt2 = oh.ExecuteDataSet(str2).Tables(0)
        Dim pmale As Integer = dt2.Rows(0)(0)
        Dim pfemale As Integer = dt2.Rows(1)(0)
        Dim perm As Integer = pmale + pfemale
        Dim permmaleper As Double = FormatNumber(pmale / perm * 100, 2)
        Dim permfemaleper As Double = FormatNumber(pfemale / perm * 100, 2)


        Dim c1, c2, c3, c4, c5, c6 As New TableRow
        c1.Width = 8
        c1.BackColor = Drawing.Color.WhiteSmoke
        Dim c1a, c1b As New TableCell
        c1a.ColumnSpan = 4
        c1b.ColumnSpan = 4

        c1a.HorizontalAlign = HorizontalAlign.Left

        c1b.HorizontalAlign = HorizontalAlign.Right
        c1a.Text = "<b><font size=2>Total&nbsp;&nbsp;Permanant&nbsp;&nbsp;Staffs:</font></b>"
        c1b.Text = "<font size=2>" & perm & "</font>"
        c1.Controls.Add(c1a)
        c1.Controls.Add(c1b)
        ratiotable.Controls.Add(c1)

        c2.Width = 8
        c2.BackColor = Drawing.Color.SeaShell
        Dim c2a, c2b As New TableCell
        c2a.ColumnSpan = 4
        c2b.ColumnSpan = 4
        c2a.HorizontalAlign = HorizontalAlign.Left
        c2b.HorizontalAlign = HorizontalAlign.Right
        c2a.Text = "<b><font size=2>Total&nbsp;&nbsp;Male&nbsp;&nbsp;Staffs:</font></b>"
        c2b.Text = "<font size=2>" & pmale & "</font>"
        c2.Controls.Add(c2a)
        c2.Controls.Add(c2b)
        ratiotable.Controls.Add(c2)

        c3.Width = 8
        c3.BackColor = Drawing.Color.WhiteSmoke
        Dim c3a, c3b As New TableCell
        c3a.ColumnSpan = 4
        c3b.ColumnSpan = 4
        c3a.HorizontalAlign = HorizontalAlign.Left
        c3b.HorizontalAlign = HorizontalAlign.Right
        c3a.Text = "<b><font size=2>Total&nbsp;&nbsp;Female&nbsp;&nbsp;Staffs:</font></b>"
        c3b.Text = "<font size=2>" & pfemale & "</font>"
        c3.Controls.Add(c3a)
        c3.Controls.Add(c3b)
        ratiotable.Controls.Add(c3)

        c4.Width = 8
        c4.BackColor = Drawing.Color.SeaShell
        Dim c4a, c4b As New TableCell
        c4a.ColumnSpan = 4
        c4b.ColumnSpan = 4
        c4a.HorizontalAlign = HorizontalAlign.Left
        c4b.HorizontalAlign = HorizontalAlign.Right
        c4a.Text = "<b><font size=2>Male&nbsp;&nbsp;Staffs&nbsp;&nbsp;Percentage:&nbsp;</font></b>"
        c4b.Text = "<font size=2>" & permmaleper & "</font>"
        c4.Controls.Add(c4a)
        c4.Controls.Add(c4b)
        ratiotable.Controls.Add(c4)

        c5.Width = 8
        c5.BackColor = Drawing.Color.WhiteSmoke
        Dim c5a, c5b As New TableCell
        c5a.ColumnSpan = 4
        c5b.ColumnSpan = 4
        c5a.HorizontalAlign = HorizontalAlign.Left
        c5b.HorizontalAlign = HorizontalAlign.Right
        c5a.Text = "<b><font size=2>Female&nbsp;&nbsp;Staffs&nbsp;&nbsp;Percentage:&nbsp;&nbsp;</font></b>"
        c5b.Text = "<font size=2>" & permfemaleper & "</font>"
        c5.Controls.Add(c5a)
        c5.Controls.Add(c5b)
        ratiotable.Controls.Add(c5)

        Dim freec As New TableRow
        freec.Width = 8
        freec.BackColor = Drawing.Color.Linen
        freec.ForeColor = Drawing.Color.Red
        Dim f1c As New TableCell
        f1c.ColumnSpan = 8
        f1c.HorizontalAlign = HorizontalAlign.Center
        f1c.Text = "<b><font size=2>*****</font></b>"
        freec.Controls.Add(f1c)
        ratiotable.Controls.Add(freec)


        Dim linev As New TableRow
        Dim linecellv As New TableCell
        linecellv.ColumnSpan = 8
        linecellv.Text = "<hr>"
        linev.Controls.Add(linecellv)
        ratiotable.Controls.Add(linev)


        '//////////////////////////////   outsource employees total,male,female & %   ////////////////////////////
        Dim ttk3 As New TableRow
        ttk3.BackColor = Drawing.Color.Honeydew
        ttk3.ForeColor = Drawing.Color.Blue
        ttk3.Width = 8
        Dim tt13 As New TableCell
        tt13.ColumnSpan = 8
        tt13.HorizontalAlign = HorizontalAlign.Center
        tt13.Text = "<b><font size=3>Outsource&nbsp;&nbsp;Employees&nbsp;&nbsp;Male&nbsp;&nbsp;Female&nbsp;&nbsp;Ratio&nbsp;&nbsp;Report&nbsp;</font></b>"
        ttk3.Controls.Add(tt13)
        ratiotable.Controls.Add(ttk3)

        Dim lineu As New TableRow
        Dim linecellu As New TableCell
        linecellu.ColumnSpan = 8
        linecellu.Text = "<hr>"
        lineu.Controls.Add(linecellu)
        ratiotable.Controls.Add(lineu)

        str3 = "select count(em.emp_code)  from employee_master em, employ_personal_dtl pd,employ_firm f  where em.emp_code = pd.emp_code  and em.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and em.status_id = 1  and em.emp_code > 9999  and em.emp_type = 2  and pd.sex = 1  union all  select count(em.emp_code)  from employee_master em, employ_personal_dtl pd,employ_firm f  where em.emp_code = pd.emp_code  and em.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and em.status_id = 1  and em.emp_code > 9999  and em.emp_type = 2  and pd.sex = 0"
        dt3 = oh.ExecuteDataSet(str3).Tables(0)
        Dim outmale As Integer = dt3.Rows(0)(0)
        Dim outfemale As Integer = dt3.Rows(1)(0)
        Dim outs As Integer = outmale + outfemale
        Dim outmmaleper As Double = FormatNumber(outmale / outs * 100, 2)
        Dim outfemaleper As Double = FormatNumber(outfemale / outs * 100, 2)


        Dim d1, d2, d3, d4, d5, d6 As New TableRow
        d1.Width = 8
        d1.BackColor = Drawing.Color.WhiteSmoke
        Dim d1a, d1b As New TableCell
        d1a.ColumnSpan = 4
        d1b.ColumnSpan = 4

        d1a.HorizontalAlign = HorizontalAlign.Left

        d1b.HorizontalAlign = HorizontalAlign.Right
        d1a.Text = "<b><font size=2>Total&nbsp;&nbsp;Outsource&nbsp;&nbsp;Staffs:</font></b>"
        d1b.Text = "<font size=2>" & outs & "</font>"
        d1.Controls.Add(d1a)
        d1.Controls.Add(d1b)
        ratiotable.Controls.Add(d1)

        d2.Width = 8
        d2.BackColor = Drawing.Color.SeaShell
        Dim d2a, d2b As New TableCell
        d2a.ColumnSpan = 4
        d2b.ColumnSpan = 4
        d2a.HorizontalAlign = HorizontalAlign.Left
        d2b.HorizontalAlign = HorizontalAlign.Right
        d2a.Text = "<b><font size=2>Total&nbsp;&nbsp;Male&nbsp;&nbsp;Staffs:</font></b>"
        d2b.Text = "<font size=2>" & outmale & "</font>"
        d2.Controls.Add(d2a)
        d2.Controls.Add(d2b)
        ratiotable.Controls.Add(d2)

        d3.Width = 8
        d3.BackColor = Drawing.Color.WhiteSmoke
        Dim d3a, d3b As New TableCell
        d3a.ColumnSpan = 4
        d3b.ColumnSpan = 4
        d3a.HorizontalAlign = HorizontalAlign.Left
        d3b.HorizontalAlign = HorizontalAlign.Right
        d3a.Text = "<b><font size=2>Total&nbsp;&nbsp;Female&nbsp;&nbsp;Staffs:</font></b>"
        d3b.Text = "<font size=2>" & outfemale & "</font>"
        d3.Controls.Add(d3a)
        d3.Controls.Add(d3b)
        ratiotable.Controls.Add(d3)

        d4.Width = 8
        d4.BackColor = Drawing.Color.SeaShell
        Dim d4a, d4b As New TableCell
        d4a.ColumnSpan = 4
        d4b.ColumnSpan = 4
        d4a.HorizontalAlign = HorizontalAlign.Left
        d4b.HorizontalAlign = HorizontalAlign.Right
        d4a.Text = "<b><font size=2>Male&nbsp;&nbsp;Staffs&nbsp;&nbsp;Percentage:&nbsp;</font></b>"
        d4b.Text = "<font size=2>" & outmmaleper & "</font>"
        d4.Controls.Add(d4a)
        d4.Controls.Add(d4b)
        ratiotable.Controls.Add(d4)

        d5.Width = 8
        d5.BackColor = Drawing.Color.WhiteSmoke
        Dim d5a, d5b As New TableCell
        d5a.ColumnSpan = 4
        d5b.ColumnSpan = 4
        d5a.HorizontalAlign = HorizontalAlign.Left
        d5b.HorizontalAlign = HorizontalAlign.Right
        d5a.Text = "<b><font size=2>Female&nbsp;&nbsp;Staffs&nbsp;&nbsp;Percentage:&nbsp;&nbsp;</font></b>"
        d5b.Text = "<font size=2>" & outfemaleper & "</font>"
        d5.Controls.Add(d5a)
        d5.Controls.Add(d5b)
        ratiotable.Controls.Add(d5)

        Dim freed As New TableRow
        freed.Width = 8
        freed.BackColor = Drawing.Color.Linen
        freed.ForeColor = Drawing.Color.Red
        Dim f1d As New TableCell
        f1d.ColumnSpan = 8
        f1d.HorizontalAlign = HorizontalAlign.Center
        f1d.Text = "<b><font size=2>*****</font></b>"
        freed.Controls.Add(f1d)
        ratiotable.Controls.Add(freed)


        'Dim linet As New TableRow
        'Dim linecellt As New TableCell
        'linecellt.ColumnSpan = 8
        'linecellt.Text = "<hr>"
        'linet.Controls.Add(linecellt)
        'ratiotable.Controls.Add(linet)



        '//////////////////////////////
        'Pan_tmfratio.BorderStyle = BorderStyle.Groove
        'Pan_tmfratio.BorderColor = Drawing.Color.Pink
        Pan_tmfratio.Controls.Add(ratiotable)
    End Sub
End Class
