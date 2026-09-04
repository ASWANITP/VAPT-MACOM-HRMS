Imports System.Data
Imports System.Data.OracleClient
Partial Class Salary_Total_Report_salary_total_report_dec35be37771
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim salarytable As New Table
    Dim str_tkn As New StringBuilder

    Dim total As Double = 0
    Dim i As Integer = 0
    Dim colors As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim acess As Integer
        acess = oh.ExecuteDataSet("select t.access_id from employee_master t where t.emp_code=" & user(0) & "").Tables(0).Rows(0)(0)






        '--------------- ReqID 8592 starts------------------------------
        If Session("firm_id") = 8 Then

            If acess = 33 Then

                '---------------------end-------------------------------------


                If Me.Session("branch_id") = 0 Then
                    '                 0             1           2               3                             4           5                               6                         7        8     
                    '  str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null order by branchname,emp_code"
                    str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master bm,  employ_firm ef,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id and em.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,  employ_firm ef,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and em.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and bc2.branch_id is null order by branchname,emp_code"
                    'rec_firm included//////////////////////////////////
                    '                 0          1             2                3                          4             5                                    6                          7         8          9
                    'str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname_verify,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt,fm3.firm_abbr as rec_firm from employee_master em,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2,firm_master fm3 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id and hm.rec_firm=fm3.firm_id union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname_verify,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt,fm3.firm_abbr as rec_firm from employee_master em,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2,firm_master fm3 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null and hm.rec_firm=fm3.firm_id order by branchname_verify,emp_code"



                Else
                    dt = oh.ExecuteDataSet("select count(*) from form_accessibility f,emp_master e where f.emp_id=e.POST_ID and f.form_id=749 and e.EMP_CODE=" & Session("user_id") & " and e.STATUS_ID=1").Tables(0)
                    If dt.Rows(0)(0) = 0 Then
                        Server.Transfer("../show_err.aspx")
                    Else
                        'str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id and hm.verify_br=" & Me.Session("branch_id") & " union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null and hm.verify_br=" & Me.Session("branch_id") & " order by branchname,emp_code"
                        str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,employ_firm ef,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id  and em.emp_code = ef.emp_code    and ef.firm_id = '" & Session("firm_id") & "' and hm.verify_br=" & Me.Session("branch_id") & " union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,employ_firm ef,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null and em.emp_code = ef.emp_code    and ef.firm_id = '" & Session("firm_id") & "' and hm.verify_br=" & Me.Session("branch_id") & " order by branchname,emp_code"
                        'rec_firm included//////////////////////////////////
                        'str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname_verify,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt,fm3.firm_abbr as rec_firm from employee_master em,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2,firm_master fm3 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id and hm.rec_firm=fm3.firm_id and hm.verify_br=" & Me.Session("branch_id") & " union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname_verify,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt,fm3.firm_abbr as rec_firm from employee_master em,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2,firm_master fm3 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null and hm.rec_firm=fm3.firm_id and hm.verify_br=" & Me.Session("branch_id") & " order by branchname_verify,emp_code"
                    End If
                End If



                '--------------- ReqID 8592 starts------------------------------

            Else
                str_tkn.Append("         alert('You Are not authorised .....!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                Exit Sub
            End If
        Else
            If Me.Session("branch_id") = 0 Then

                '                 0             1           2               3                             4           5                               6                         7        8     
                '  str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null order by branchname,emp_code"
                str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master bm,  employ_firm ef,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id and em.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,  employ_firm ef,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and em.emp_code = ef.emp_code   and ef.firm_id = '" & Session("firm_id") & "' and bc2.branch_id is null order by branchname,emp_code"
                'rec_firm included//////////////////////////////////
                '                 0          1             2                3                          4             5                                    6                          7         8          9
                'str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname_verify,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt,fm3.firm_abbr as rec_firm from employee_master em,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2,firm_master fm3 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id and hm.rec_firm=fm3.firm_id union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname_verify,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt,fm3.firm_abbr as rec_firm from employee_master em,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2,firm_master fm3 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null and hm.rec_firm=fm3.firm_id order by branchname_verify,emp_code"



            Else
                dt = oh.ExecuteDataSet("select count(*) from form_accessibility f,emp_master e where f.emp_id=e.POST_ID and f.form_id=749 and e.EMP_CODE=" & Session("user_id") & " and e.STATUS_ID=1").Tables(0)
                If dt.Rows(0)(0) = 0 Then
                    Server.Transfer("../show_err.aspx")
                Else
                    'str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id and hm.verify_br=" & Me.Session("branch_id") & " union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null and hm.verify_br=" & Me.Session("branch_id") & " order by branchname,emp_code"
                    str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,employ_firm ef,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id  and em.emp_code = ef.emp_code    and ef.firm_id = '" & Session("firm_id") & "' and hm.verify_br=" & Me.Session("branch_id") & " union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt from employee_master em,employ_firm ef,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and hm.rec_by<>'BLOCK' and hm.rec_by<>'SDPROCESS' and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null and em.emp_code = ef.emp_code    and ef.firm_id = '" & Session("firm_id") & "' and hm.verify_br=" & Me.Session("branch_id") & " order by branchname,emp_code"
                    'rec_firm included//////////////////////////////////
                    'str = "select hm.emp_code,em.emp_name,dm.designation,bm2.branch_name as emp_branch,fm2.firm_abbr,bm.branch_name as branchname_verify,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt,fm3.firm_abbr as rec_firm from employee_master em,hrm_employ_verification hm,branch_master bm,designation_master dm,firm_master fm1,firm_master fm2,branch_master bm2,firm_master fm3 where em.emp_code=hm.emp_code and hm.verify_br=bm.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and bm.firm_id=fm1.firm_id and hm.emp_branch=bm2.branch_id and bm2.firm_id=fm2.firm_id and hm.rec_firm=fm3.firm_id and hm.verify_br=" & Me.Session("branch_id") & " union select hm.emp_code,em.emp_name,dm.designation,bc2.branch_name as emp_branch,'----',ba.branch_name as branchname_verify,fm1.firm_abbr as verify_firm,nvl(hm.salary,0),hm.rec_dt,fm3.firm_abbr as rec_firm from employee_master em,hrm_employ_verification hm,branch_master ba,designation_master dm,firm_master fm1,before_completion bc2,firm_master fm3 where em.emp_code=hm.emp_code and hm.verify_br=ba.branch_id and em.designation_id=dm.designation_id and hm.status_id=1 and ba.firm_id=fm1.firm_id and hm.emp_branch=bc2.old_id and bc2.branch_id is null and hm.rec_firm=fm3.firm_id and hm.verify_br=" & Me.Session("branch_id") & " order by branchname_verify,emp_code"
                End If
            End If



        End If

        '---------------------end-------------------------------------





        dt = oh.ExecuteDataSet(str).Tables(0)

        If dt.Rows.Count > 0 Then

            salarytable.Attributes.Add("width", "100%")
            Dim header As New TableRow
            header.Width = 10
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            Dim headcell As New TableCell
            headcell.ColumnSpan = 10
            headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headcell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headcell)
            salarytable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 10
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 10
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            salarytable.Controls.Add(sheader)


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

            salarytable.Controls.Add(subh)

            Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'MONTH') from salari s").Tables(0).Rows(0)(0)

            Dim y As Integer = oh.ExecuteDataSet("select distinct to_char(to_date(s.sal_dt),'YYYY') from salari s").Tables(0).Rows(0)(0)

            Dim pheader As New TableRow
            Dim pheadercell As New TableCell
            pheader.Width = 10
            pheadercell.ColumnSpan = 10
            pheadercell.HorizontalAlign = HorizontalAlign.Center

            pheadercell.Text = "<body align=center ><b><font size=3>Branchwise Employees Salary of " & s & "&nbsp;&nbsp;" & y & "</font></b>"
            pheader.Controls.Add(pheadercell)
            salarytable.Controls.Add(pheader)

            Dim line1 As New TableRow
            Dim linecell1 As New TableCell
            line1.Width = 10
            linecell1.ColumnSpan = 10
            linecell1.Text = "<hr>"
            line1.Controls.Add(linecell1)
            salarytable.Controls.Add(line1)

            'Dim colors As String
            'colors = "#fff7ff"

            Dim bname As String = ""

            fill()

            'colors = "#eef3ef"
            For Each dr In dt.Rows

                If bname <> dr(5) Then



                    Dim rbname As New TableRow
                    rbname.Width = 10
                    rbname.Attributes.Add("bgcolor", "#F5F5F5")
                    Dim cbname As New TableCell
                    cbname.ColumnSpan = 10
                    cbname.HorizontalAlign = HorizontalAlign.Left
                    cbname.Text = "<b><font size=2>Cash Withdraw Branch:&nbsp;" & dr(5).ToString & "&nbsp;(&nbsp;" & dr(6).ToString & "&nbsp;)&nbsp;</font></b>"
                    rbname.Controls.Add(cbname)
                    salarytable.Controls.Add(rbname)



                End If

                bname = dr(5).ToString
                i += 1

                'If colors.Equals("#FAF8CC") = True Then
                '    colors = "#FFF8C6"
                'Else
                '    colors = "#FAF8CC"
                'End If

                Dim value As New TableRow
                value.Width = 10
                'value.Attributes.Add("bgcolor", colors)
                Dim v1, v2, v3, v4, v5, v6, v7 As New TableCell

                v1.ColumnSpan = 1   'ecode
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                value.Controls.Add(v1)

                v2.ColumnSpan = 2    'ename
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                value.Controls.Add(v2)

                v3.ColumnSpan = 2                    'designation
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                value.Controls.Add(v3)

                v4.ColumnSpan = 2   'working_branch
                v4.HorizontalAlign = HorizontalAlign.Left
                v4.Text = "<font size=2>" & dr(3) & "&nbsp;-&nbsp;" & dr(4) & "&nbsp;</font>"
                value.Controls.Add(v4)

                v5.ColumnSpan = 1     'salary
                v5.HorizontalAlign = HorizontalAlign.Right
                v5.Text = "<font size=2>" & FormatNumber(dr(7), 2) & "&nbsp;</font>"
                value.Controls.Add(v5)
                total += dr(7)

                v6.ColumnSpan = 2   'Received_Date
                v6.HorizontalAlign = HorizontalAlign.Center
                If IsDBNull(dr(8)) Then
                    v6.Text = "<font size=2>----&nbsp;</font>"
                Else
                    v6.Text = "<font size=2>" & Format(dr(8), "dd-MMM-yyyy") & "&nbsp;</font>"
                End If

                value.Controls.Add(v6)

                'v7.ColumnSpan = 1   'Received_Firm
                'v7.HorizontalAlign = HorizontalAlign.Left
                'v7.Text = "<font size=2>" & dr(9) & "</font>"
                'value.Controls.Add(v7)

                salarytable.Controls.Add(value)
            Next

            Dim lineq As New TableRow
            lineq.Width = 10
            Dim l1 As New TableCell
            l1.ColumnSpan = 10
            l1.Text = "<hr>"
            lineq.Controls.Add(l1)
            salarytable.Controls.Add(lineq)

            Dim warn As New TableRow
            warn.Width = 10
            Dim w1 As New TableCell
            w1.ColumnSpan = 10
            w1.HorizontalAlign = HorizontalAlign.Left
            w1.Text = "<b><font size=2>Total Employees=" & Me.i & "&nbsp;and Sum of Total Salary=&nbsp;" & FormatNumber(Me.total, 2) & "&nbsp;&nbsp;</font></b>"
            warn.Controls.Add(w1)
            salarytable.Controls.Add(warn)
        Else
            Dim sarn As New TableRow
            sarn.Width = 10
            Dim s1 As New TableCell
            s1.ColumnSpan = 10
            s1.HorizontalAlign = HorizontalAlign.Center
            s1.Text = "<b><font size=2>No Employees found!!</font></b>"
            sarn.Controls.Add(s1)
            salarytable.Controls.Add(sarn)
        End If



        Panel_Salary_Total.Controls.Add(salarytable)






    End Sub

    Sub fill()

        Dim field As New TableRow
        field.Width = 10
        Dim f1, f2, f3, f4, f5, f6, f7 As New TableCell
        'colors = "#8BB381"
        field.Attributes.Add("bgcolor", "#E6E6FA")

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Left
        f1.Text = "<b><font size=2>Emp&nbsp;Code&nbsp;</font></b>"
        field.Controls.Add(f1)

        f2.ColumnSpan = 2
        f2.HorizontalAlign = HorizontalAlign.Left
        f2.Text = "<b><font size=2>Employee&nbsp;Name&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 2
        f3.HorizontalAlign = HorizontalAlign.Left
        f3.Text = "<b><font size=2>Designation&nbsp;</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 2
        f4.HorizontalAlign = HorizontalAlign.Left
        f4.Text = "<b><font size=2>Working&nbsp;Branch&nbsp;</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Center
        f5.Text = "<b><font size=2>Salary&nbsp;</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 2
        f6.HorizontalAlign = HorizontalAlign.Center
        f6.Text = "<b><font size=2>Salary&nbsp;Received&nbsp;on</font></b>"
        field.Controls.Add(f6)

        'f7.ColumnSpan = 1
        'f7.HorizontalAlign = HorizontalAlign.Left
        'f7.Text = "<b><font size=2>Received Firm</font></b>"
        'field.Controls.Add(f7)

        salarytable.Controls.Add(field)

    End Sub

End Class
