Imports System.Data
Imports System.Data.OracleClient
Partial Class PayRoll_pay_sus_rvk_Repo_1365a61c2883
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim typtest As Integer = 2
        Dim tc5 As New TableCell
        MsgBox(Request.QueryString.Get("ecode"))
        dt = oh.ExecuteDataSet("select em.emp_name,em.emp_code,dm.dep_name,pm.post_name,bm.branch_name,to_char(er.discont_dt),eprd.perm_add1,upper(pm2.post_office),pm2.pin_code,upper(dm2.district_name),sm.state_name from employee_master em,branch_master bm,department_mst dm,post_mst pm,employ_personal_dtl1 eprd,employee_resigtermi er,district_master dm2,state_master sm,post_master pm2 where em.branch_id=bm.branch_id and em.department_id=dm.dep_id and em.post_id=pm.post_id and eprd.emp_code=em.emp_code and er.status_id=5 and  er.emp_code=em.emp_code and eprd.perm_pin=pm2.sr_number and pm2.district_id=dm2.district_id and dm2.state_id=sm.state_id and em.emp_code=" & Request.QueryString.Get("ecode") & "").Tables(0)
        '                                           0         1          2             3            4               5                   6                7             8              9              10                                                                                                                                                                                                                                                                                                                                                                " & Request.QueryString.Get("ecode") & "                                                 
        'type = "Termination From The Service"
        ''tc5.Text = "<font size=3><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mr/Ms." & dt.Rows(0)(0) & " (Emp.Code:" & dt.Rows(0)(1) & ")," & dt.Rows(0)(2) & "," & dt.Rows(0)(3) & "," & dt.Rows(0)(4) & ": branch has been placed into Suspension With effect from :" & dt.Rows(0)(5) & " for " & dt.Rows(0)(6) & "  noticed at our " & dt.Rows(0)(4) & "  Branch,pending detailed enquiry into the matter. </b></font>"

        Dim tb As New Table
        Dim tr1 As New TableRow
        tb.Attributes.Add("width", "100%")
        'tb.Attributes.Add("border", "2")
        Dim tc1 As New TableCell
        tc1.Attributes.Add("width", "100%")
        tc1.ColumnSpan = 10
        tc1.HorizontalAlign = HorizontalAlign.Right
        tc1.Text = "<font size=2><b> Date : " & Format(Date.Now, "dd/MMM/yyyy") & " </b></font>"
        tr1.Controls.Add(tc1)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tc2.Attributes.Add("width", "100%")
        tc2.ColumnSpan = 10
        tc2.HorizontalAlign = HorizontalAlign.Right
        tc2.Text = "<font size=2><b> Time : " & Format(Date.Now, "hh:mm:ss") & " </b></font>"
        tr2.Controls.Add(tc2)

        tb.Controls.Add(tr2)

        Dim tr3 As New TableRow
        Dim tc3 As New TableCell
        tc3.Attributes.Add("width", "100%")
        tc3.ColumnSpan = 10
        tc3.HorizontalAlign = HorizontalAlign.Left
        tc3.Text = "<font size=3><b> Termination From The Service </b></font>"
        tr3.Controls.Add(tc3)

        tb.Controls.Add(tr3)

        Dim tr4 As New TableRow
        Dim tc4 As New TableCell
        tc4.Attributes.Add("width", "100%")
        tc4.ColumnSpan = 10
        tc4.HorizontalAlign = HorizontalAlign.Left
        tc4.Text = "<font size=2><b>------------------------------------------------------</b></font>"
        tr4.Controls.Add(tc4)

        tb.Controls.Add(tr4)


        Dim tr5 As New TableRow

        tc5.Attributes.Add("width", "100%")
        tc5.ColumnSpan = 10
        tc5.HorizontalAlign = HorizontalAlign.Left
        tc5.Text = "<font size=3><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;It is hereby informed that your services  are found to be unsatisfactory. so you are terminated from the service of the Company with effect from " & dt.Rows(0)(5) & "as per the condition  stated in  your  Appointment letter dated . </b></font>"

        tr5.Controls.Add(tc5)

        tb.Controls.Add(tr5)

        Dim tr6 As New TableRow
        Dim tc6 As New TableCell
        tc6.Attributes.Add("width", "100%")

        tc6.ColumnSpan = 10
        tc6.HorizontalAlign = HorizontalAlign.Left
        tc6.Text = "<font size=2><b></b></font>"
        tr6.Controls.Add(tc6)

        tb.Controls.Add(tr6)

        Dim tr61 As New TableRow
        Dim tc61 As New TableCell
        tc61.Attributes.Add("width", "100%")
        tc61.ColumnSpan = 10
        tc61.HorizontalAlign = HorizontalAlign.Left
        tc61.Text = "<font size=2><b></b></font>"
        tr6.Controls.Add(tc61)

        tb.Controls.Add(tr61)

        Dim tr7 As New TableRow
        Dim tc7 As New TableCell
        tc7.Attributes.Add("width", "100%")
        tc7.ColumnSpan = 10
        tc7.HorizontalAlign = HorizontalAlign.Left
        tc7.Text = "<font size=2><b> V.P.NANDAKUMAR </b></font>"
        tr7.Controls.Add(tc7)

        tb.Controls.Add(tr7)

        Dim tr8 As New TableRow
        Dim tc8 As New TableCell
        tc8.Attributes.Add("width", "100%")
        tc8.ColumnSpan = 10
        tc8.HorizontalAlign = HorizontalAlign.Left
        tc8.Text = "<font size=2><b>  Chairman & Managing Director </b></font>"
        tr8.Controls.Add(tc8)

        tb.Controls.Add(tr8)

        Dim tr9 As New TableRow
        Dim tc9 As New TableCell
        tc9.Attributes.Add("width", "100%")
        tc9.ColumnSpan = 10
        tc9.HorizontalAlign = HorizontalAlign.Left
        tc9.Text = "<font size=2><b> </b></font>"
        tr9.Controls.Add(tc9)

        tb.Controls.Add(tr9)


        Dim tr10 As New TableRow
        Dim tc10 As New TableCell
        tc10.Attributes.Add("width", "100%")
        tc10.ColumnSpan = 10
        tc10.HorizontalAlign = HorizontalAlign.Left
        tc10.Text = "<font size=2><b> </b></font>"
        tr10.Controls.Add(tc10)

        tb.Controls.Add(tr10)

        Dim tr11 As New TableRow
        Dim tc11, tc111 As New TableCell
        tc11.Attributes.Add("width", "100%")
        tc111.Attributes.Add("width", "100%")
        tc11.ColumnSpan = 6
        tc111.ColumnSpan = 4
        tc111.HorizontalAlign = HorizontalAlign.Left
        tc11.HorizontalAlign = HorizontalAlign.Left
        tc11.Text = "<font size=2><b> TO, </b></font>"
        tc111.Text = "<font size=2><b> ADDRESS, </b></font>"
        tr11.Controls.Add(tc11)
        tr11.Controls.Add(tc111)

        tb.Controls.Add(tr11)

        Dim tr12 As New TableRow
        Dim tc12, tc121 As New TableCell
        tc12.Attributes.Add("width", "100%")
        tc121.Attributes.Add("width", "100%")
        tc12.ColumnSpan = 6
        tc121.ColumnSpan = 4
        tc12.HorizontalAlign = HorizontalAlign.Left
        tc121.HorizontalAlign = HorizontalAlign.Left
        tc12.Text = "<font size=2><b>Mr/Ms. " & dt.Rows(0)(0) & " </b></font>"
        tc121.Text = "<font size=2><b>Mr/Ms. " & dt.Rows(0)(0) & " </b></font>"
        tr12.Controls.Add(tc12)
        tr12.Controls.Add(tc121)

        tb.Controls.Add(tr12)

        Dim tr13 As New TableRow
        Dim tc13, tc131 As New TableCell
        tc13.Attributes.Add("width", "100%")
        tc131.Attributes.Add("width", "100%")
        tc13.ColumnSpan = 6
        tc131.ColumnSpan = 4
        tc13.HorizontalAlign = HorizontalAlign.Left
        tc131.HorizontalAlign = HorizontalAlign.Left
        tc13.Text = "<font size=2><b>Emp.Code: " & dt.Rows(0)(1) & " </b></font>"
        tc131.Text = "<font size=2><b>" & dt.Rows(0)(6) & " </b></font>"
        tr13.Controls.Add(tc13)
        tr13.Controls.Add(tc131)

        tb.Controls.Add(tr13)

        Dim tr14 As New TableRow
        Dim tc14, tc141 As New TableCell
        tc14.Attributes.Add("width", "100%")
        tc141.Attributes.Add("width", "100%")
        tc14.ColumnSpan = 6
        tc141.ColumnSpan = 4
        tc14.HorizontalAlign = HorizontalAlign.Left
        tc141.HorizontalAlign = HorizontalAlign.Left
        tc14.Text = "<font size=2><b>" & dt.Rows(0)(2) & " </b></font>"
        tc141.Text = "<font size=2><b>" & dt.Rows(0)(7) & ". P.O -" & dt.Rows(0)(8) & " </b></font>"
        tr14.Controls.Add(tc14)
        tr14.Controls.Add(tc141)

        tb.Controls.Add(tr14)

        Dim tr15 As New TableRow
        Dim tc15, tc151 As New TableCell
        tc15.Attributes.Add("width", "100%")
        tc151.Attributes.Add("width", "100%")
        tc15.ColumnSpan = 6
        tc151.ColumnSpan = 4
        tc15.HorizontalAlign = HorizontalAlign.Left
        tc151.HorizontalAlign = HorizontalAlign.Left
        tc15.Text = "<font size=2><b>" & dt.Rows(0)(3) & " </b></font>"
        tc151.Text = "<font size=2><b>" & dt.Rows(0)(9) & ":Dist. </b></font>"
        tr15.Controls.Add(tc15)
        tr15.Controls.Add(tc151)

        tb.Controls.Add(tr15)

        Dim tr16 As New TableRow
        Dim tc16, tc161 As New TableCell
        tc16.Attributes.Add("width", "100%")
        tc161.Attributes.Add("width", "100%")
        tc16.ColumnSpan = 6
        tc161.ColumnSpan = 4
        tc16.HorizontalAlign = HorizontalAlign.Left
        tc161.HorizontalAlign = HorizontalAlign.Left
        tc16.Text = "<font size=2><b>" & dt.Rows(0)(4) & ": Branch </b></font>"
        tc161.Text = "<font size=2><b>" & dt.Rows(0)(10) & " </b></font>"
        tr16.Controls.Add(tc16)
        tr16.Controls.Add(tc161)

        tb.Controls.Add(tr16)

        Me.Panel1.Controls.Add(tb)

    End Sub
End Class
