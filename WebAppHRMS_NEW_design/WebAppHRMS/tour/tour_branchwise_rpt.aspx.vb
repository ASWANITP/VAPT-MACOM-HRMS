Imports System.Data
Imports System.Data.OracleClient
Partial Class Tour_Report_Brwise_tour_branchwise_rpt_09dfe71b3601
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim i As Integer = 0
    Dim tourtable As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'if session(brid)=req.querystrng9brid) then

        If Me.Request.QueryString("status") = 1 Then   'Individual Branch
            '                   0              1         2           3              4           5        ---------6------------------------------   --7-----   - 8----  ----------------------   9 ---------------------------  -----10-----------------------------------------      --------11-----------------    -------------------------------12-------------------------------------------   -----13--------------   -------14-------------------   -------- 15-----------------------------over/
            str = "select bm.branch_name,ht.emp_code,em.emp_name,dp.dep_name,dm.designation,pm.post_name,bm1.branch_name||'(Branch)' as tour_place,ht.from_dt,ht.to_dt,decode(ht.from_time,null,'NIL',ht.from_time)as From_Time,decode(ht.to_time,null,'NIL',ht.to_time) as To_Time,nvl(ht.advance_rs,0) as Advance,decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose)) as Purpose,ht.tra_dt as Apply_Date,ht.sanction_dt as Sanction_Date,ht.sanction_person||'  '||em1.emp_name as Sanction_Person from hrm_tour_dtl ht,employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,branch_master bm1,employee_master em1 where em.emp_code=ht.emp_code and ht.branch_id=bm.branch_id and ht.desig_id=dm.designation_id and ht.dep_id=dp.dep_id and ht.post_id=pm.post_id and ht.to_branch=bm1.branch_id and ht.sanction_person=em1.emp_code and ht.tour_id=1 and  em.firm_id=" & Session("firm_id") & " and ht.branch_id=" & Me.Request.QueryString("branchid") & " and to_date(ht.sanction_dt)>=to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(ht.sanction_dt)<=to_date('" & Me.Request.QueryString("todate") & "') union select bm.branch_name,ht.emp_code,em.emp_name,dp.dep_name,dm.designation,pm.post_name,bc1.branch_name||'(N.O.Branch)' as tour_place,ht.from_dt,ht.to_dt,decode(ht.from_time,null,'NIL',ht.from_time)as From_Time,decode(ht.to_time,null,'NIL',ht.to_time) as To_Time,nvl(ht.advance_rs,0) as Advance,decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose)) as Purpose,ht.tra_dt as Apply_Date,ht.sanction_dt as Sanction_Date,ht.sanction_person||'  '||em1.emp_name as Sanction_Person from hrm_tour_dtl ht,employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,before_completion bc1,employee_master em1 where em.emp_code=ht.emp_code and ht.branch_id=bm.branch_id and ht.desig_id=dm.designation_id and ht.dep_id=dp.dep_id and ht.post_id=pm.post_id and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.sanction_person=em1.emp_code and ht.tour_id=1 and ht.branch_id=" & Me.Request.QueryString("branchid") & " and to_date(ht.sanction_dt)>=to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(ht.sanction_dt)<=to_date('" & Me.Request.QueryString("todate") & "') union select bm.branch_name,ht.emp_code,em.emp_name,dp.dep_name,dm.designation,pm.post_name,decode(ht.others,null,'Not Specified',upper(ht.others))||'(Other Place)' as tour_place,ht.from_dt,ht.to_dt,decode(ht.from_time,null,'NIL',ht.from_time)as From_Time,decode(ht.to_time,null,'NIL',ht.to_time) as To_Time,nvl(ht.advance_rs,0) as Advance,decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose)) as Purpose,ht.tra_dt as Apply_Date,ht.sanction_dt as Sanction_Date,ht.sanction_person||'  '||em1.emp_name as Sanction_Person from hrm_tour_dtl ht,employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,employee_master em1 where em.emp_code=ht.emp_code and ht.branch_id=bm.branch_id and ht.desig_id=dm.designation_id and ht.dep_id=dp.dep_id and ht.post_id=pm.post_id and ht.to_branch is null and ht.sanction_person=em1.emp_code and ht.tour_id=1 and ht.branch_id=" & Me.Request.QueryString("branchid") & " and to_date(ht.sanction_dt)>=to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(ht.sanction_dt)<=to_date('" & Me.Request.QueryString("todate") & "') order by Sanction_Date,emp_code"

        ElseIf Me.Request.QueryString("status") = 0 Then  'All Branches

            'str = "select bm.branch_name,ht.emp_code,em.emp_name,dp.dep_name,dm.designation,pm.post_name,bm1.branch_name||'(Branch)' as tour_place,ht.from_dt,ht.to_dt,decode(ht.from_time,null,'NIL',ht.from_time)as From_Time,decode(ht.to_time,null,'NIL',ht.to_time) as To_Time,nvl(ht.advance_rs,0) as Advance,decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose)) as Purpose,ht.tra_dt as Apply_Date,ht.sanction_dt as Sanction_Date,ht.sanction_person||'  '||em1.emp_name as Sanction_Person from hrm_tour_dtl ht,employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,branch_master bm1,employee_master em1 where em.emp_code=ht.emp_code and ht.branch_id=bm.branch_id and ht.desig_id=dm.designation_id and ht.dep_id=dp.dep_id and ht.post_id=pm.post_id and ht.to_branch=bm1.branch_id and ht.sanction_person=em1.emp_code and ht.tour_id=1 and to_date(ht.sanction_dt)>=to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(ht.sanction_dt)<=to_date('" & Me.Request.QueryString("todate") & "') union select bm.branch_name,ht.emp_code,em.emp_name,dp.dep_name,dm.designation,pm.post_name,bc1.branch_name||'(N.O.Branch)' as tour_place,ht.from_dt,ht.to_dt,decode(ht.from_time,null,'NIL',ht.from_time)as From_Time,decode(ht.to_time,null,'NIL',ht.to_time) as To_Time,nvl(ht.advance_rs,0) as Advance,decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose)) as Purpose,ht.tra_dt as Apply_Date,ht.sanction_dt as Sanction_Date,ht.sanction_person||'  '||em1.emp_name as Sanction_Person from hrm_tour_dtl ht,employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,before_completion bc1,employee_master em1 where em.emp_code=ht.emp_code and ht.branch_id=bm.branch_id and ht.desig_id=dm.designation_id and ht.dep_id=dp.dep_id and ht.post_id=pm.post_id and ht.to_branch=bc1.old_id and bc1.branch_id is null and ht.sanction_person=em1.emp_code and ht.tour_id=1 and to_date(ht.sanction_dt)>=to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(ht.sanction_dt)<=to_date('" & Me.Request.QueryString("todate") & "') union select bm.branch_name,ht.emp_code,em.emp_name,dp.dep_name,dm.designation,pm.post_name,decode(ht.others,null,'Not Specified',upper(ht.others))||'(Other Place)' as tour_place,ht.from_dt,ht.to_dt,decode(ht.from_time,null,'NIL',ht.from_time)as From_Time,decode(ht.to_time,null,'NIL',ht.to_time) as To_Time,nvl(ht.advance_rs,0) as Advance,decode(ht.tour_purpose,null,'Not Specified',upper(ht.tour_purpose)) as Purpose,ht.tra_dt as Apply_Date,ht.sanction_dt as Sanction_Date,ht.sanction_person||'  '||em1.emp_name as Sanction_Person from hrm_tour_dtl ht,employee_master em,branch_master bm,designation_master dm,department_mst dp,post_mst pm,employee_master em1 where em.emp_code=ht.emp_code and ht.branch_id=bm.branch_id and ht.desig_id=dm.designation_id and ht.dep_id=dp.dep_id and ht.post_id=pm.post_id and ht.to_branch is null and ht.sanction_person=em1.emp_code and ht.tour_id=1 and to_date(ht.sanction_dt)>=to_date('" & Me.Request.QueryString("fromdate") & "') and to_date(ht.sanction_dt)<=to_date('" & Me.Request.QueryString("todate") & "') order by branch_name,Sanction_Date,emp_code"
            str = "select bm.branch_name,  ht.emp_code,  em.emp_name,  dp.dep_name,  dm.designation,  pm.post_name,  bm1.branch_name || '(Branch)' as tour_place,  ht.from_dt,  ht.to_dt,  decode(ht.from_time, null, 'NIL', ht.from_time) as From_Time,  decode(ht.to_time, null, 'NIL', ht.to_time) as To_Time,  nvl(ht.advance_rs, 0) as Advance,  decode(ht.tour_purpose,  null,  'Not Specified',  upper(ht.tour_purpose)) as Purpose,  ht.tra_dt as Apply_Date,  ht.sanction_dt as Sanction_Date,  ht.sanction_person || '  ' || em1.emp_name as Sanction_Person  from hrm_tour_dtl       ht,  employee_master    em,  branch_master      bm,  designation_master dm,  department_mst     dp,  post_mst           pm,  branch_master      bm1,  employee_master    em1,  employ_firm        ef  where em.emp_code = ht.emp_code  and ht.branch_id = bm.branch_id  and ht.desig_id = dm.designation_id  and ht.dep_id = dp.dep_id  and ht.post_id = pm.post_id  and ht.to_branch = bm1.branch_id  and ht.sanction_person = em1.emp_code  and em.emp_code = ef.emp_code  and ef.firm_id = " & Session("firm_id") & "  and ht.tour_id = 1  and to_date(ht.sanction_dt) >=  to_date('" & Me.Request.QueryString("fromdate") & "')  and to_date(ht.sanction_dt) <=  to_date('" & Me.Request.QueryString("todate") & "') union select bm.branch_name,  ht.emp_code,  em.emp_name,  dp.dep_name,  dm.designation,  pm.post_name,  bc1.branch_name || '(N.O.Branch)' as tour_place,  ht.from_dt,  ht.to_dt,  decode(ht.from_time, null, 'NIL', ht.from_time) as From_Time,  decode(ht.to_time, null, 'NIL', ht.to_time) as To_Time,  nvl(ht.advance_rs, 0) as Advance,  decode(ht.tour_purpose,  null,  'Not Specified',  upper(ht.tour_purpose)) as Purpose,  ht.tra_dt as Apply_Date,  ht.sanction_dt as Sanction_Date,  ht.sanction_person || '  ' || em1.emp_name as Sanction_Person  from hrm_tour_dtl       ht,  employee_master    em,  branch_master      bm,  designation_master dm,  department_mst     dp,  post_mst           pm,  before_completion  bc1,  employee_master    em1,  employ_firm        ef  where em.emp_code = ht.emp_code  and ht.branch_id = bm.branch_id  and ht.desig_id = dm.designation_id  and ht.dep_id = dp.dep_id  and ht.post_id = pm.post_id  and ht.to_branch = bc1.old_id  and bc1.branch_id is null  and em.emp_code = ef.emp_code and em.firm_id=" & Session("firm_id") & "  and ef.firm_id = " & Session("firm_id") & "  and ht.sanction_person = em1.emp_code  and ht.tour_id = 1  and to_date(ht.sanction_dt) >=  to_date('" & Me.Request.QueryString("fromdate") & "')  and to_date(ht.sanction_dt) <=  to_date('" & Me.Request.QueryString("todate") & "') union select bm.branch_name,  ht.emp_code,  em.emp_name,  dp.dep_name,  dm.designation,  pm.post_name,  decode(ht.others, null, 'Not Specified', upper(ht.others)) ||  '(Other Place)' as tour_place,  ht.from_dt,  ht.to_dt,  decode(ht.from_time, null, 'NIL', ht.from_time) as From_Time,  decode(ht.to_time, null, 'NIL', ht.to_time) as To_Time,  nvl(ht.advance_rs, 0) as Advance,  decode(ht.tour_purpose,  null,  'Not Specified',  upper(ht.tour_purpose)) as Purpose,  ht.tra_dt as Apply_Date,  ht.sanction_dt as Sanction_Date,  ht.sanction_person || '  ' || em1.emp_name as Sanction_Person  from hrm_tour_dtl       ht,  employee_master    em,  branch_master      bm,  designation_master dm,  department_mst     dp,  post_mst           pm,  employee_master    em1,  employ_firm        ef  where em.emp_code = ht.emp_code  and ht.branch_id = bm.branch_id  and ht.desig_id = dm.designation_id  and ht.dep_id = dp.dep_id  and ht.post_id = pm.post_id  and ht.to_branch is null  and ht.sanction_person = em1.emp_code  and ht.tour_id = 1  and em.emp_code = ef.emp_code  and ef.firm_id = " & Session("firm_id") & "  and to_date(ht.sanction_dt) >=  to_date('" & Me.Request.QueryString("fromdate") & "')  and to_date(ht.sanction_dt) <=  to_date('" & Me.Request.QueryString("todate") & "')  order by branch_name, Sanction_Date, emp_code"

        End If

        dt = oh.ExecuteDataSet(str).Tables(0)

        If dt.Rows.Count > 0 Then

            Dim header As New TableRow
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            header.Width = 14
            Dim headercell As New TableCell
            headercell.ColumnSpan = 14
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            tourtable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 14
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 14
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            tourtable.Controls.Add(sheader)

            Dim tt As New TableRow
            'tt.BackColor = Drawing.Color.LightSkyBlue
            tt.Width = 14
            Dim tt1 As New TableCell
            tt1.ColumnSpan = 14
            tt1.HorizontalAlign = HorizontalAlign.Center
            tt1.Text = "<b><font size=3>Employee Sanctioned Tour Report Between " & Me.Request.QueryString("fromdate") & " and " & Me.Request.QueryString("todate") & " </font></b>"
            tt.Controls.Add(tt1)
            tourtable.Controls.Add(tt)

            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 14

            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 3
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 8
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 3
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            'subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
            subh.Controls.Add(subcell3)
            tourtable.Controls.Add(subh)

            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 14
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            tourtable.Controls.Add(line)
            '''''''''''''''''

            Dim colors As String
            colors = "#fff7ef"

            Dim field As New TableRow
            field.Width = 14
            field.Attributes.Add("bgcolor", colors)
            Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15 As New TableCell


            f2.ColumnSpan = 1
            f2.HorizontalAlign = HorizontalAlign.Left
            f2.Text = "<b><font size=2>Emp.&nbsp;Code&nbsp;</font></b>"
            field.Controls.Add(f2)

            f3.ColumnSpan = 1
            f3.HorizontalAlign = HorizontalAlign.Left
            f3.Text = "<b><font size=2>Emp.&nbsp;Name&nbsp;</font></b>"
            field.Controls.Add(f3)

            f4.ColumnSpan = 1
            f4.HorizontalAlign = HorizontalAlign.Left
            f4.Text = "<b><font size=2>Deptmt&nbsp;</font></b>"
            field.Controls.Add(f4)

            f5.ColumnSpan = 1
            f5.HorizontalAlign = HorizontalAlign.Left
            f5.Text = "<b><font size=2>Desig.n&nbsp;</font></b>"
            field.Controls.Add(f5)

            f6.ColumnSpan = 1
            f6.HorizontalAlign = HorizontalAlign.Left
            f6.Text = "<b><font size=2>Post&nbsp;</font></b>"
            field.Controls.Add(f6)

            f7.ColumnSpan = 1
            f7.HorizontalAlign = HorizontalAlign.Left
            f7.Text = "<b><font size=2>Tour&nbsp;To&nbsp;</font></b>"
            field.Controls.Add(f7)

            f8.ColumnSpan = 1
            f8.HorizontalAlign = HorizontalAlign.Left
            f8.Text = "<b><font size=2>Tour&nbsp;From&nbsp;Date&nbsp;</font></b>"
            field.Controls.Add(f8)

            f9.ColumnSpan = 1
            f9.HorizontalAlign = HorizontalAlign.Left
            f9.Text = "<b><font size=2>Tour&nbsp;To&nbsp;Date&nbsp;</font></b>"
            field.Controls.Add(f9)

            f10.ColumnSpan = 1
            f10.HorizontalAlign = HorizontalAlign.Left
            f10.Text = "<b><font size=2>Time&nbsp;From&nbsp;</font></b>"
            field.Controls.Add(f10)

            f11.ColumnSpan = 1
            f11.HorizontalAlign = HorizontalAlign.Left
            f11.Text = "<b><font size=2>Time&nbsp;To&nbsp;</font></b>"
            field.Controls.Add(f11)

            f12.ColumnSpan = 1
            f12.HorizontalAlign = HorizontalAlign.Left
            f12.Text = "<b><font size=2>Advance Rs&nbsp;</font></b>"
            field.Controls.Add(f12)

            f13.ColumnSpan = 1
            f13.HorizontalAlign = HorizontalAlign.Left
            f13.Text = "<b><font size=2>Purpose&nbsp;</font></b>"
            field.Controls.Add(f13)

            f1.ColumnSpan = 1
            f1.HorizontalAlign = HorizontalAlign.Left
            f1.Text = "<b><font size=2>Tour&nbsp;Apply&nbsp;Date&nbsp;</font></b>"
            field.Controls.Add(f1)

            f14.ColumnSpan = 1
            f14.HorizontalAlign = HorizontalAlign.Left
            f14.Text = "<b><font size=2>Sanctioned&nbsp;By&nbsp;</font></b>"
            field.Controls.Add(f14)


            tourtable.Controls.Add(field)

            Dim line1 As New TableRow
            Dim linecell1 As New TableCell
            linecell1.ColumnSpan = 14
            linecell1.Text = "<hr>"
            line1.Controls.Add(linecell1)
            tourtable.Controls.Add(line1)


            Dim brname As String = ""
            Dim sancdate As String = ""

            For Each dr In dt.Rows

                'If colors.Equals("#fff7ef") = True Then
                '    colors = "#eef3ef"
                'Else
                '    colors = "#fff7ef"
                'End If

                If brname <> dr(0).ToString Then
                    If brname <> "" Then
                        brtotal()
                    End If
                    Dim rbname As New TableRow
                    rbname.Width = 14
                    Dim cbname As New TableCell
                    cbname.ColumnSpan = 14
                    cbname.HorizontalAlign = HorizontalAlign.Left
                    cbname.Text = "<font size=3>Branch:&nbsp;<b>" & dr(0) & "</b></font>"
                    rbname.Controls.Add(cbname)
                    tourtable.Controls.Add(rbname)

                    i = 0

                End If

                i += 1



                If sancdate <> dr(14).ToString Then

                    Dim rsdate As New TableRow
                    rsdate.Width = 14
                    Dim csdate As New TableCell
                    csdate.ColumnSpan = 14
                    csdate.HorizontalAlign = HorizontalAlign.Left
                    If IsDBNull(dr(14)) Then
                        csdate.Text = "<font size=3>Sanction date:&nbsp;<b>Not Entered</b></font>"
                    Else
                        csdate.Text = "<font size=3>Sanction date:&nbsp;<b>" & Format(dr(14), "dd-MMM-yyyy") & "</b></font>"
                    End If


                    rsdate.Controls.Add(csdate)
                    tourtable.Controls.Add(rsdate)

                End If

                brname = dr(0).ToString
                sancdate = dr(14).ToString

                '///////////////////////////values
                Dim value As New TableRow
                value.Width = 14
                value.Attributes.Add("bgcolor", colors)
                Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15 As New TableCell


                v2.ColumnSpan = 1    'EmpCode
                v2.HorizontalAlign = HorizontalAlign.Left
                v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                value.Controls.Add(v2)

                v3.ColumnSpan = 1   'EmpName
                v3.HorizontalAlign = HorizontalAlign.Left
                v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                value.Controls.Add(v3)

                v4.ColumnSpan = 1   'Deptmt
                v4.HorizontalAlign = HorizontalAlign.Left
                v4.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                value.Controls.Add(v4)

                v5.ColumnSpan = 1   'Desig
                v5.HorizontalAlign = HorizontalAlign.Left
                v5.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                value.Controls.Add(v5)

                v6.ColumnSpan = 1   'Post
                v6.HorizontalAlign = HorizontalAlign.Left
                v6.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                value.Controls.Add(v6)

                v7.ColumnSpan = 1    'Tour To
                v7.HorizontalAlign = HorizontalAlign.Left
                v7.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
                value.Controls.Add(v7)

                v8.ColumnSpan = 1    'Date From
                v8.HorizontalAlign = HorizontalAlign.Left
                v8.Text = "<font size=2>" & Format(dr(7), "dd-MMM-yyyy") & "&nbsp;</font>"
                value.Controls.Add(v8)

                v9.ColumnSpan = 1  'Date To
                v9.HorizontalAlign = HorizontalAlign.Left
                v9.Text = "<font size=2>" & Format(dr(8), "dd-MMM-yyyy") & "&nbsp;</font>"
                value.Controls.Add(v9)

                v10.ColumnSpan = 1   'Time From
                v10.HorizontalAlign = HorizontalAlign.Center
                v10.Text = "<font size=2>" & dr(9) & "&nbsp;</font>"
                value.Controls.Add(v10)

                v11.ColumnSpan = 1       'Time To
                v11.HorizontalAlign = HorizontalAlign.Center
                v11.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
                value.Controls.Add(v11)

                v12.ColumnSpan = 1    'Advance Rs
                v12.HorizontalAlign = HorizontalAlign.Right
                v12.Text = "<font size=2>" & FormatNumber(dr(11), 2) & "&nbsp;</font>"
                value.Controls.Add(v12)

                v13.ColumnSpan = 1          'Purpose
                v13.HorizontalAlign = HorizontalAlign.Left
                v13.Text = "<font size=2>" & dr(12) & "&nbsp;</font>"
                value.Controls.Add(v13)

                v1.ColumnSpan = 1             'Apply Date
                v1.HorizontalAlign = HorizontalAlign.Left
                v1.Text = "<font size=2>" & Format(dr(13), "dd-MMM-yyyy") & "&nbsp;</font>"
                value.Controls.Add(v1)

                v14.ColumnSpan = 1             'Sanctioned By
                v14.HorizontalAlign = HorizontalAlign.Left
                v14.Text = "<font size=2>" & dr(15) & "</font>"
                value.Controls.Add(v14)


                tourtable.Controls.Add(value)

            Next

            Dim lala As New TableRow
            Dim lala1 As New TableCell
            lala1.ColumnSpan = 14
            lala1.Text = "<hr>"
            lala.Controls.Add(lala1)
            tourtable.Controls.Add(lala)

            brtotal()

        Else

            Dim warn As New TableRow
            Dim warn1 As New TableCell
            warn1.ColumnSpan = 14
            warn1.Text = "<b><font size=3>No Data!!</font></b>"
            warn.Controls.Add(warn1)
            tourtable.Controls.Add(warn)


        End If

        'Else

        'Dim warnq As New TableRow
        'Dim warnq1 As New TableCell
        'warnq1.ColumnSpan = 14
        'warnq1.Text = "<b><font size=3>You Are Trying To Take Other Branch Details!!</font></b>"
        'warnq.Controls.Add(warnq1)
        'tourtable.Controls.Add(warnq)

        'End If

        Panel_Emp_Tour.Controls.Add(tourtable)


    End Sub

    Sub brtotal()
        Dim rbtot As New TableRow
        Dim cbtot As New TableCell
        cbtot.ColumnSpan = 14
        cbtot.HorizontalAlign = HorizontalAlign.Left
        cbtot.Text = "<b><font size=3>Total:&nbsp;" & i & "&nbsp;Sanctioned Record(s)</font></b>"
        rbtot.Controls.Add(cbtot)
        tourtable.Controls.Add(rbtot)

    End Sub
End Class
