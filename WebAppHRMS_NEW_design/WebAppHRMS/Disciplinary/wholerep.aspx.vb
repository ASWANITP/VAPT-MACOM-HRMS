Imports System.Data
Imports System.Data.OracleClient
Imports System.IO

Partial Class salary_report_sal_wage_rpt_4cd638817906
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim colors, firm As String
    Dim s As String
    Dim dr As DataRow
    Dim sy As Integer = 0
    Dim sdt As String
    Dim fir, regi, catgry, values As Integer
    Dim dt, dt1, dt2, dt6 As New DataTable
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        regi = Request.QueryString("regid")
        'Dim user() As String
        catgry = Request.QueryString("cat")
        values = Request.QueryString("val")
        Dim dtacc As New DataTable
        Dim brdt As New DataTable



        Dim sdf2 As String = "select rownum, t.emp_code, e.emp_name, dp.dep_name, p.post_name, ds.designation, upper(mr.discipline_name)disciplinary_action, to_char(t.occuredfrmdt)occuredfrmdt, to_char(t.occuredtodt)occuredtodt, t.usercomments, t.occuredfrmtm, t.occuredtotm, t.attachment, to_char(t.showcausegvndt)showcausegvndt, t.showattachment, to_char(t.causerplydt)causerplydt, t.SHOWCAUSEATTACHNAME, t. SHOWCAUSERPLYATTACHNAME from disciplinary_dtl t, employee_master e, department_mst dp, designation_master ds, post_mst p, hrm_DISCIPLINARY_MASTER mr where t.emp_code = e.emp_code and dp.dep_id = e.department_id and p.post_id = e.post_id and mr.discipline_id = t.disciplinaryid and ds.designation_id = e.designation_id AND t.disciplinaryid=" & Request.QueryString("discipline_id") & "  AND to_DATE(t.occuredfrmdt) >='" & Request.QueryString("occuredfrmdt") & "' AND to_DATE(t.occuredtodt) <='" & Request.QueryString("occuredtodt") & " 'order by 1, 2"
        Dim sdf1 As String = "select rownum, t.emp_code, e.emp_name, dp.dep_name, p.post_name, ds.designation, upper(mr.discipline_name)disciplinary_action, to_char(t.occuredfrmdt)occuredfrmdt, to_char(t.occuredtodt)occuredtodt, t.usercomments, t.occuredfrmtm, t.occuredtotm, t.attachment, to_char(t.showcausegvndt)showcausegvndt, t.showattachment, to_char(t.causerplydt)causerplydt, t.SHOWCAUSEATTACHNAME, t. SHOWCAUSERPLYATTACHNAME from disciplinary_dtl t, employee_master e, department_mst dp, designation_master ds, post_mst p, hrm_DISCIPLINARY_MASTER mr where t.emp_code = e.emp_code and dp.dep_id = e.department_id and p.post_id = e.post_id and mr.discipline_id = t.disciplinaryid and ds.designation_id = e.designation_id AND t.disciplinaryid=" & Request.QueryString("discipline_id") & "  and to_DATE(t.occuredfrmdt) >='" & Request.QueryString("occuredfrmdt") & "' AND to_DATE(t.occuredtodt) <='" & Request.QueryString("occuredtodt") & "' order by 1, 2"
        If Request.QueryString("discipline_id") = 1 Then
            dt = oh.ExecuteDataSet(sdf1).Tables(0)
        Else
            dt = oh.ExecuteDataSet(sdf2).Tables(0)
        End If



        Panel1.Visible = False
        Panel2.Visible = True

        'dt = oh.ExecuteDataSet("select bd.BRANCH_NAME, count(e1.emp_code)total_no_emp,bd.BRANCH_ID from masset.employee_master e1, masset.employee_master_dtl em2, masset.branch_master br, masset.branch_detail bd, masset.state_master sm, masset.designation_master dm, masset.department_mst dep, masset.post_mst p where em2.emp_code = e1.emp_code and e1.status_id = 1 and e1.branch_id = br.branch_id and br.branch_id = bd.branch_id and br.state_id = sm.state_id and e1.designation_id = dm.designation_id and e1.department_id = dep.dep_id and e1.post_id = p.post_id and e1.firm_id=4 and bd.reg_id=" & regi & " group by bd.BRANCH_NAME,bd.BRANCH_ID").Tables(0)

        '''''''''''''''''''''''''''''''''''''







        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        tab.Attributes.Add("border", 1)
        Dim tabr1 As New TableRow
        tabr1.Width = 200
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.BorderStyle = BorderStyle.Solid
        tabr1.BorderColor = Drawing.Color.Red

        Dim tabc1 As New TableCell
        tabc1.ColumnSpan = 200
        tabc1.Text = "<body align=center color=red><b><font size=4>MANAPURAM CROMPTECH AMD CONSULTANTS LIMITED</font></b></body>"
        tabc1.ForeColor = Drawing.Color.Red
        tabc1.Attributes.Add("align", "CENTER")
        tabr1.Controls.Add(tabc1)
        tab.Controls.Add(tabr1)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabr2 As New TableRow
        'tabr2.Attributes.Add("bgcolor", "bisque")
        tabr2.ForeColor = Drawing.Color.Maroon

        Dim tabc2 As New TableCell
        tabc2.Attributes.Add("bgcolor", "gold")
        tabc2.Text = "<b> </b>"
        tabc2.ColumnSpan = 20
        tabc2.HorizontalAlign = HorizontalAlign.Center
        tabc2.ForeColor = Drawing.Color.Brown
        'sdt = oh.ExecuteDataSet("select to_char(sal_dt,'MONTH - yyyy') from m_wage where emp_code=" & user(0)).Tables(0).Rows(0)(0)
        'If sdt <> "" Then
        '    s = sdt
        'Else
        '    s = "Last Month"
        'End If
        tabc2.BackColor = Drawing.Color.AliceBlue
        tabc2.ColumnSpan = 160
        tabc2.Text = "<body align=center color=red><b><font size=4>DISCIPLINARY ACTION REPORT</font></b></body>"
        tabc2.Attributes.Add("align", "CENTER")
        tabr2.Controls.Add(tabc2)
        tab.Controls.Add(tabr2)

        'Dim tablineaq As New TableRow
        'tablineaq.Width = 20
        'Dim tabcelllineaq As New TableCell
        'tabcelllineaq.ColumnSpan = 20
        'tabcelllineaq.Text = "<hr>"
        'tablineaq.Controls.Add(tabcelllineaq)
        'tab.Controls.Add(tablineaq)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''








        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim tabline As New TableRow
        'tabline.Width = 20
        'Dim tabcellline As New TableCell
        'tabcellline.ColumnSpan = 20
        'tabcellline.Text = "<hr>"
        'tabline.Controls.Add(tabcellline)
        'tab.Controls.Add(tabline)

        '================
        Dim tabr3a As New TableRow
        tabr3a.Width = 80
        tabr3a.Attributes.Add("bgcolor", "#ffcca3")
        Dim tabc3a As New TableCell
        tabc3a.ColumnSpan = 10
        tabc3a.HorizontalAlign = HorizontalAlign.Center
        tabc3a.ForeColor = Drawing.Color.Maroon
        tabc3a.Text = "<b><font size=3.5><b>Sl.no </b></font></b>"
        tabr3a.Controls.Add(tabc3a)
        tab.Controls.Add(tabr3a)


        Dim tabc4a As New TableCell
        tabc4a.Attributes.Add("width", "80%")
        tabc4a.HorizontalAlign = HorizontalAlign.Center
        tabc4a.ColumnSpan = 10
        tabc4a.ForeColor = Drawing.Color.Maroon
        tabc4a.Font.Bold = True
        tabc4a.Text = "<b><font size=3.5><b>Emp.Code</b></font></b>"
        tabr3a.Controls.Add(tabc4a)
        tab.Controls.Add(tabr3a)

        Dim tabc4a1 As New TableCell
        tabc4a1.Attributes.Add("width", "80%")
        tabc4a1.HorizontalAlign = HorizontalAlign.Center
        tabc4a1.ColumnSpan = 10
        tabc4a1.ForeColor = Drawing.Color.Maroon
        tabc4a1.Font.Bold = True
        tabc4a1.Text = "<b><font size=3.5><b>Emp.name</b></font></b>"
        tabr3a.Controls.Add(tabc4a1)
        tab.Controls.Add(tabr3a)


        Dim tabc4a2 As New TableCell
        tabc4a2.Attributes.Add("width", "80%")
        tabc4a2.HorizontalAlign = HorizontalAlign.Center
        tabc4a2.ColumnSpan = 10
        tabc4a2.ForeColor = Drawing.Color.Maroon
        tabc4a2.Font.Bold = True
        tabc4a2.Text = "<b><font size=3.5><b>Department</b></font></b>"
        tabr3a.Controls.Add(tabc4a2)
        tab.Controls.Add(tabr3a)

        Dim tabc4a3 As New TableCell
        tabc4a3.Attributes.Add("width", "80%")
        tabc4a3.HorizontalAlign = HorizontalAlign.Center
        tabc4a3.ColumnSpan = 10
        tabc4a3.ForeColor = Drawing.Color.Maroon
        tabc4a3.Font.Bold = True
        tabc4a3.Text = "<b><font size=3.5><b>Post</b></font></b>"
        tabr3a.Controls.Add(tabc4a3)
        tab.Controls.Add(tabr3a)

        Dim tabc4a4 As New TableCell
        tabc4a4.Attributes.Add("width", "80%")
        tabc4a4.HorizontalAlign = HorizontalAlign.Center
        tabc4a4.ColumnSpan = 10
        tabc4a4.ForeColor = Drawing.Color.Maroon
        tabc4a4.Font.Bold = True
        tabc4a4.Text = "<b><font size=3.5><b>Designation</b></font></b>"
        tabr3a.Controls.Add(tabc4a4)
        tab.Controls.Add(tabr3a)



        Dim tabc4a5 As New TableCell
        tabc4a5.Attributes.Add("width", "80%")
        tabc4a5.HorizontalAlign = HorizontalAlign.Center
        tabc4a5.ColumnSpan = 10
        tabc4a5.ForeColor = Drawing.Color.Maroon
        tabc4a5.Font.Bold = True
        tabc4a5.Text = "<b><font size=3.5><b>Disciplinary action</b></font></b>"
        tabr3a.Controls.Add(tabc4a5)
        tab.Controls.Add(tabr3a)


        Dim tabc4a6 As New TableCell
        tabc4a6.Attributes.Add("width", "80%")
        tabc4a6.HorizontalAlign = HorizontalAlign.Center
        tabc4a6.ColumnSpan = 10
        tabc4a6.ForeColor = Drawing.Color.Maroon
        tabc4a6.Font.Bold = True
        tabc4a6.Text = "<b><font size=3.5><b>Action Occurred from date</b></font></b>"
        tabr3a.Controls.Add(tabc4a6)
        tab.Controls.Add(tabr3a)




        Dim tabc4a7 As New TableCell
        tabc4a7.Attributes.Add("width", "80%")
        tabc4a7.HorizontalAlign = HorizontalAlign.Center
        tabc4a7.ColumnSpan = 10
        tabc4a7.ForeColor = Drawing.Color.Maroon
        tabc4a7.Font.Bold = True
        tabc4a7.Text = "<b><font size=3.5><b>Action Occurred to date</b></font></b>"
        tabr3a.Controls.Add(tabc4a7)
        tab.Controls.Add(tabr3a)


        Dim tabc4a8 As New TableCell
        tabc4a8.Attributes.Add("width", "80%")
        tabc4a8.HorizontalAlign = HorizontalAlign.Center
        tabc4a8.ColumnSpan = 10
        tabc4a8.ForeColor = Drawing.Color.Maroon
        tabc4a8.Font.Bold = True
        tabc4a8.Text = "<b><font size=3.5><b>Comments</b></font></b>"
        tabr3a.Controls.Add(tabc4a8)
        tab.Controls.Add(tabr3a)



        Dim tabc4a9 As New TableCell
        tabc4a9.Attributes.Add("width", "80%")
        tabc4a9.HorizontalAlign = HorizontalAlign.Center
        tabc4a9.ColumnSpan = 10
        tabc4a9.ForeColor = Drawing.Color.Maroon
        tabc4a9.Font.Bold = True
        tabc4a9.Text = "<b><font size=3.5><b>Action occurred from time</b></font></b>"
        tabr3a.Controls.Add(tabc4a9)
        tab.Controls.Add(tabr3a)



        Dim tabc4a10 As New TableCell
        tabc4a10.Attributes.Add("width", "80%")
        tabc4a10.HorizontalAlign = HorizontalAlign.Center
        tabc4a10.ColumnSpan = 10
        tabc4a10.ForeColor = Drawing.Color.Maroon
        tabc4a10.Font.Bold = True
        tabc4a10.Text = "<b><font size=3.5><b>Action occurred to time</b></font></b>"
        tabr3a.Controls.Add(tabc4a10)
        tab.Controls.Add(tabr3a)





        Dim tabc4a11 As New TableCell
        tabc4a11.Attributes.Add("width", "80%")
        tabc4a11.HorizontalAlign = HorizontalAlign.Center
        tabc4a11.ColumnSpan = 10
        tabc4a11.ForeColor = Drawing.Color.Maroon
        tabc4a11.Font.Bold = True
        tabc4a11.Text = "<b><font size=3.5><b>Showcause (attachment)</b></font></b>"
        tabr3a.Controls.Add(tabc4a11)
        tab.Controls.Add(tabr3a)



        Dim tabc4a12 As New TableCell
        tabc4a12.Attributes.Add("width", "80%")
        tabc4a12.HorizontalAlign = HorizontalAlign.Center
        tabc4a12.ColumnSpan = 10
        tabc4a12.ForeColor = Drawing.Color.Maroon
        tabc4a12.Font.Bold = True
        tabc4a12.Text = "<b><font size=3.5><b>showcause given date</b></font></b>"
        tabr3a.Controls.Add(tabc4a12)
        tab.Controls.Add(tabr3a)


        Dim tabc4a13 As New TableCell
        tabc4a13.Attributes.Add("width", "80%")
        tabc4a13.HorizontalAlign = HorizontalAlign.Center
        tabc4a13.ColumnSpan = 10
        tabc4a13.ForeColor = Drawing.Color.Maroon
        tabc4a13.Font.Bold = True
        tabc4a13.Text = "<b><font size=3.5><b>Showcause reply (attachname)</b></font></b>"
        tabr3a.Controls.Add(tabc4a13)
        tab.Controls.Add(tabr3a)

        Dim tabc4a14 As New TableCell
        tabc4a14.Attributes.Add("width", "80%")
        tabc4a14.HorizontalAlign = HorizontalAlign.Center
        tabc4a14.ColumnSpan = 10
        tabc4a14.ForeColor = Drawing.Color.Maroon
        tabc4a14.Font.Bold = True
        tabc4a14.Text = "<b><font size=3.5><b>Showcause reply date</b></font></b>"
        tabr3a.Controls.Add(tabc4a14)
        tab.Controls.Add(tabr3a)





        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim tablinea As New TableRow
        'tablinea.Width = 20
        'Dim tabcelllinea As New TableCell
        'tabcelllinea.ColumnSpan = 20
        'tabcelllinea.Text = "<hr>"
        'tablinea.Controls.Add(tabcelllinea)
        'tab.Controls.Add(tablinea)
        '================
        If dt.Rows.Count = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('No Data Found..!!');")
            cl_script1.Append("window.open('discwhole.aspx','_self');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)





            Exit Sub
        End If
        Dim tot As Integer = 0
        For Each dr In dt.Rows
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tabr5 As New TableRow
            tabr5.Width = 20
            tabr5.Attributes.Add("bgcolor", "#fffcff")

            Dim tabr5c1 As New TableCell
            tabr5c1.ColumnSpan = 10
            tabr5c1.HorizontalAlign = HorizontalAlign.Center
            tabr5c1.Text = "<FONT SIZE=3>" & dr(0) & "</FONT>"
            tabr5.Controls.Add(tabr5c1)
            tab.Controls.Add(tabr5)
            tabr5c1.Width = 20

            Dim tabr6c1 As New TableCell
            tabr6c1.ColumnSpan = 10
            tabr6c1.HorizontalAlign = HorizontalAlign.Center
            tabr6c1.Text = "<FONT SIZE=3>" & dr(1) & "</FONT>"
            tabr5.Controls.Add(tabr6c1)
            tab.Controls.Add(tabr5)

            Dim tabr7c1 As New TableCell
            tabr7c1.ColumnSpan = 10
            tabr7c1.HorizontalAlign = HorizontalAlign.Center
            tabr7c1.Text = "<FONT SIZE=3>" & dr(2) & "</FONT>"
            tabr5.Controls.Add(tabr7c1)
            tab.Controls.Add(tabr5)


            Dim tabr8c1 As New TableCell
            tabr8c1.ColumnSpan = 10
            tabr8c1.HorizontalAlign = HorizontalAlign.Center
            tabr8c1.Text = "<FONT SIZE=3>" & dr(3) & "</FONT>"
            tabr5.Controls.Add(tabr8c1)
            tab.Controls.Add(tabr5)

            Dim tabr9c1 As New TableCell
            tabr9c1.ColumnSpan = 10
            tabr9c1.HorizontalAlign = HorizontalAlign.Center
            tabr9c1.Text = "<FONT SIZE=3>" & dr(4) & "</FONT>"
            tabr5.Controls.Add(tabr9c1)
            tab.Controls.Add(tabr5)


            Dim tabr10c1 As New TableCell
            tabr10c1.ColumnSpan = 10
            tabr10c1.HorizontalAlign = HorizontalAlign.Center
            tabr10c1.Text = "<FONT SIZE=3>" & dr(5) & "</FONT>"
            tabr5.Controls.Add(tabr10c1)
            tab.Controls.Add(tabr5)



            Dim tabr11c1 As New TableCell
            tabr11c1.ColumnSpan = 10
            tabr11c1.HorizontalAlign = HorizontalAlign.Center
            tabr11c1.Text = "<FONT SIZE=3>" & dr(6) & "</FONT>"
            tabr5.Controls.Add(tabr11c1)
            tab.Controls.Add(tabr5)


            Dim tabr12c1 As New TableCell
            tabr12c1.ColumnSpan = 10
            tabr12c1.HorizontalAlign = HorizontalAlign.Center
            tabr12c1.Text = "<FONT SIZE=3>" & dr(7) & "</FONT>"
            tabr5.Controls.Add(tabr12c1)
            tab.Controls.Add(tabr5)


            Dim tabr13c1 As New TableCell
            tabr13c1.ColumnSpan = 10
            tabr13c1.HorizontalAlign = HorizontalAlign.Center
            tabr13c1.Text = "<FONT SIZE=3>" & dr(8) & "</FONT>"
            tabr5.Controls.Add(tabr13c1)
            tab.Controls.Add(tabr5)


            Dim tabr14c1 As New TableCell
            tabr14c1.ColumnSpan = 10
            tabr14c1.HorizontalAlign = HorizontalAlign.Center
            If IsDBNull(dr(9)) Then
                tabr14c1.Text = "<FONT SIZE=3>No comments</FONT>"
            Else
                tabr14c1.Text = "<FONT SIZE=3>" & dr(9) & "</FONT>"
            End If

            tabr5.Controls.Add(tabr14c1)
            tab.Controls.Add(tabr5)

            Dim tabr15c1 As New TableCell
            tabr15c1.ColumnSpan = 10
            tabr15c1.HorizontalAlign = HorizontalAlign.Center
            tabr15c1.Text = "<FONT SIZE=3>" & dr(10) & "</FONT>"
            tabr5.Controls.Add(tabr15c1)
            tab.Controls.Add(tabr5)



            Dim tabr16c1 As New TableCell
            tabr16c1.ColumnSpan = 10
            tabr16c1.HorizontalAlign = HorizontalAlign.Center
            tabr16c1.Text = "<FONT SIZE=3>" & dr(11) & "</FONT>"
            tabr5.Controls.Add(tabr16c1)
            tab.Controls.Add(tabr5)

            Dim tabr17c1 As New TableCell
            tabr17c1.ColumnSpan = 10
            tabr17c1.HorizontalAlign = HorizontalAlign.Center
            tabr17c1.Text = "<FONT SIZE=3><font size=2><a href=javascript:Openform1(" & dr(1) & ")>" & dr(16) & "</a></font>"

            tabr5.Controls.Add(tabr17c1)
            tab.Controls.Add(tabr5)




            Dim tabr18c1 As New TableCell
            tabr18c1.ColumnSpan = 10
            tabr18c1.HorizontalAlign = HorizontalAlign.Center
            tabr18c1.Text = "<FONT SIZE=3>" & dr(13) & "</FONT>"
            tabr5.Controls.Add(tabr18c1)
            tab.Controls.Add(tabr5)



            Dim tabr19c1 As New TableCell
            tabr19c1.ColumnSpan = 10
            tabr19c1.HorizontalAlign = HorizontalAlign.Center
            tabr19c1.Text = "<FONT SIZE=3><font size=2><a href=javascript:Openform2(" & dr(1) & ")>" & dr(17) & "</a></font>"
            tabr5.Controls.Add(tabr19c1)
            tab.Controls.Add(tabr5)


            Dim tabr20c1 As New TableCell
            tabr20c1.ColumnSpan = 10
            tabr20c1.HorizontalAlign = HorizontalAlign.Center
            tabr20c1.Text = "<FONT SIZE=3>" & dr(15) & "</FONT>"
            tabr5.Controls.Add(tabr20c1)
            tab.Controls.Add(tabr5)




            tot = tot + 1
        Next


        '

        Panel2.Controls.Add(tab)


        Dim tabr8a As New TableRow
        tabr8a.Width = 80
        tabr8a.Attributes.Add("bgcolor", "#ffcca3")
        Dim tabc8a As New TableCell
        tabc8a.ColumnSpan = 180
        tabc8a.HorizontalAlign = HorizontalAlign.Center
        tabc8a.ForeColor = Drawing.Color.Maroon
        tabc8a.Text = "<b><font size=3.5><b> Total Count:" & tot & "<b></font></b>"
        tabr8a.Controls.Add(tabc8a)
        tab.Controls.Add(tabr8a)

        Dim tabr3 As New TableRow
        tabr3.Width = 200
        'tabr3.Attributes.Add("bgcolor", "#ffcca3")
        Dim tabc3 As New TableCell
        tabc3.ColumnSpan = 180
        tabc3.HorizontalAlign = HorizontalAlign.Center
        tabc3.ForeColor = Drawing.Color.Maroon

        tabc3.Text = "<font size=2><button class='btn btn-success' id='btnExport' onclick='fnExcelReport()'>Export to Excel</button></font>"
        tabr3.Controls.Add(tabc3)
        tab.Controls.Add(tabr3)



    End Sub
    Private Function dbnull(ByVal a) As String
        Dim a1 As Double

        If IsDBNull(a) Then
            Return 0
        Else
            a1 = FormatNumber(a, 2)
            Return FormatNumber(a, 2)
        End If
    End Function

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub
    Protected Sub bt1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt1.ServerClick
        Dim ap As String = """"
        Dim Sql3 As String = "select rownum sl_no, t.emp_code, e.emp_name, dp.dep_name, p.post_name, ds.designation, upper(mr.discipline_name)action, to_char(t.occuredfrmdt) occured_frmdate, to_char(t.occuredtodt) occured_todate, t.usercomments, upper(to_char(t.occuredfrmtm)) occured_fromtime, upper(to_char(t.occuredtotm)) occured_totime, to_char(t.showcausegvndt) showcause_givendate, to_char(t.causerplydt) showcause_replydate from disciplinary_dtl t, employee_master e, department_mst dp, designation_master ds, post_mst p, hrm_DISCIPLINARY_MASTER mr where t.emp_code = e.emp_code And dp.dep_id = e.department_id And p.post_id = e.post_id And mr.discipline_id = t.disciplinaryid And ds.designation_id = e.designation_id And t.disciplinaryid = " & Request.QueryString("discipline_id") & " And to_DATE(t.occuredfrmdt) >='" & Request.QueryString("occuredfrmdt") & "' AND  to_DATE(t.occuredtodt)<='" & Request.QueryString("occuredtodt") & "'order by 1,2"

        Dim dt3 = oh.ExecuteDataSet(Sql3).Tables(0)
        If dt3.Rows.Count > 0 Then
            GridView1.DataSource = dt3
            GridView1.DataBind()
            Response.ClearContent()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Disciplinary Report Data" + " " + DateTime.Now.ToString("dd-MMMM-yyyy" + " " + "hh:mm tt") + ".xls"))
            Response.ContentType = "application/ms-excel"
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            GridView1.AllowPaging = False
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF")
            For i As Integer = 0 To GridView1.HeaderRow.Cells.Count - 1
                GridView1.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
            Next
            GridView1.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.[End]()

        End If
    End Sub
End Class
