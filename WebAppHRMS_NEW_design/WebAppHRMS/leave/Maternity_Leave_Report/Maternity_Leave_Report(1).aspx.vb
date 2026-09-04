Imports System.Data
Imports System.Data.OracleClient

Partial Class Referral_Incentive_Referral_Report_d7fedeed3757
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim i As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        ' Dim sql As String = "select em.emp_code,em.emp_name, bm.branch_name, dm.designation, ls.leave_frdate as Leave_From_Date, ls.leave_todate as Leave_To_Date, ls.leave_days from Employee_Master em, hrm_leave_apply_sanction ls, branch_master  bm, designation_master dm where em.emp_code = ls.emp_code and em.branch_id = bm.branch_id and em.designation_id = dm.designation_id and ls.status_id not in(3,2) and ls.leave_id = 10 and ls.leave_frdate between  '" & Request.QueryString.Get("fdt") & "' and  '" & Request.QueryString.Get("tdt") & "'   order by ls.leave_frdate"
        Dim sql As String = "select em.emp_code,em.emp_name, bm.branch_name, dm.designation, ls.leave_frdate as Leave_From_Date, ls.leave_todate as Leave_To_Date, ls.leave_days,bd.area_name,bd.reg_name from Employee_Master em, hrm_leave_apply_sanction ls, branch_master  bm, designation_master dm,branch_dtl_new bd,employ_firm ef where em.emp_code = ls.emp_code and em.emp_code = ef.emp_code and ef.firm_id = ' " & Session("firm_id") & " ' and em.branch_id = bm.branch_id and em.designation_id = dm.designation_id and ls.status_id not in(3,2) and ls.leave_id = 10 and ls.leave_frdate between  '" & Request.QueryString.Get("fdt") & "' and  '" & Request.QueryString.Get("tdt") & "' and bd.BRANCH_ID = bm.branch_id   order by ls.leave_frdate"

        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")

        Dim tabr1 As New TableRow
        tabr1.Width = 100
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")

        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 100
        tabc1.Text = "<body align=center ><b><font size=4> " & Session("firm_name") & " </font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab.Controls.Add(tabr1)

        Dim trr As New TableRow
        trr.Width = 100
        Dim tdr1 As New TableCell
        tdr1.ColumnSpan = 100
        tdr1.HorizontalAlign = HorizontalAlign.Center
        tdr1.ForeColor = Drawing.Color.Navy
        tdr1.Text = "<Center><font size=4><b><u>..Maternity Leave Report..</u></b></font></center>"
        trr.Controls.Add(tdr1)
        tab.Controls.Add(trr)



        Dim lin2101 As New TableRow
        lin2101.Width = 200
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 200
        lin21011.Text = "<hr>"
        lin2101.Controls.Add(lin21011)
        tab.Controls.Add(lin2101)




        Dim tabh As New TableRow
        tabh.Width = 9
        Dim tabh1, tabh2, tabh3, tabh4, tabh5, tabh6, tabh7, tabh8, tabh9 As New TableCell
        tabh1.HorizontalAlign = HorizontalAlign.Center
        tabh2.HorizontalAlign = HorizontalAlign.Center
        tabh3.HorizontalAlign = HorizontalAlign.Center
        tabh4.HorizontalAlign = HorizontalAlign.Center
        tabh5.HorizontalAlign = HorizontalAlign.Center
        tabh6.HorizontalAlign = HorizontalAlign.Center
        tabh7.HorizontalAlign = HorizontalAlign.Center
        tabh8.HorizontalAlign = HorizontalAlign.Center
        tabh9.HorizontalAlign = HorizontalAlign.Center
        

        tabh1.ColumnSpan = 7
        tabh2.ColumnSpan = 7
        tabh3.ColumnSpan = 7
        tabh4.ColumnSpan = 7
        tabh5.ColumnSpan = 9
        tabh6.ColumnSpan = 9
        tabh7.ColumnSpan = 9
        tabh8.ColumnSpan = 7
        tabh9.ColumnSpan = 7
    

        tabh1.Text = "<font size=2><B>EMP CODE</B></font>"
        tabh2.Text = "<font size=2><B>EMP NAME</B></font>"
        tabh3.Text = "<font size=2><B>BRANCH_NAME</B></font>"
        tabh4.Text = "<font size=2><B>DESIGNATION</B></font>"
        tabh5.Text = "<font size=2><B>LEAVE_FROM</B></font>"
        tabh6.Text = "<font size=2><B>LEAVE_TO</B></font>"
        tabh7.Text = "<font size=2><B>LEAVE_DAYS</B></font>"
        tabh8.Text = "<font size=2><B>AREA_NAME</B></font>"
        tabh9.Text = "<font size=2><B>REG_NAME</B></font>"
        


        tabh.Controls.Add(tabh1)
        tabh.Controls.Add(tabh2)
        tabh.Controls.Add(tabh3)
        tabh.Controls.Add(tabh4)
        tabh.Controls.Add(tabh5)
        tabh.Controls.Add(tabh6)
        tabh.Controls.Add(tabh7)
        tabh.Controls.Add(tabh8)
        tabh.Controls.Add(tabh9)
        

        tab.Controls.Add(tabh)

        Dim tabrb1q As New TableRow
        Dim tabrb11 As New TableCell
        tabrb1q.Width = 200
        tabrb11.ColumnSpan = 200
        tabrb11.Text = "<hr>"
        tabrb1q.Controls.Add(tabrb11)
        tab.Controls.Add(tabrb1q)

        Dim dr As DataRow
        For Each dr In dt.Rows
            i += 1
            Dim tabr As New TableRow
            Dim tabrc1, tabrc2, tabrc3, tabrc4, tabrc5, tabrc6, tabrc7, tabrc8, tabrc9 As New TableCell
            tabr.Width = 9
            tabrc1.HorizontalAlign = HorizontalAlign.center
            tabrc2.HorizontalAlign = HorizontalAlign.center
            tabrc3.HorizontalAlign = HorizontalAlign.center
            tabrc4.HorizontalAlign = HorizontalAlign.center
            tabrc5.HorizontalAlign = HorizontalAlign.center
            tabrc6.HorizontalAlign = HorizontalAlign.center
            tabrc7.HorizontalAlign = HorizontalAlign.Center
            tabrc8.HorizontalAlign = HorizontalAlign.Center
            tabrc9.HorizontalAlign = HorizontalAlign.Center
         
            
            tabrc1.ColumnSpan = 7
            tabrc2.ColumnSpan = 7
            tabrc3.ColumnSpan = 7
            tabrc4.ColumnSpan = 7
            tabrc5.ColumnSpan = 9
            tabrc6.ColumnSpan = 9
            tabrc7.ColumnSpan = 10
            tabrc8.ColumnSpan = 7
            tabrc9.ColumnSpan = 7
           


            tabrc1.Text = "<b><font size=2>" & dr(0) & "</font></b>"
            tabrc2.Text = "<font size=2>" & dr(1) & "</font>"
            tabrc3.Text = "<font size=2>" & dr(2) & "</font>"
            tabrc4.Text = "<font size=2>" & dr(3) & "</font>"
            tabrc5.Text = "<font size=2>" & dr(4) & "</font>"
            tabrc6.Text = "<b><font size=2>" & dr(5) & "</font></b>"
            tabrc7.Text = "<font size=2>" & dr(6) & "</font>"
            tabrc8.Text = "<font size=2>" & dr(7) & "</font>"
            tabrc9.Text = "<font size=2>" & dr(8) & "</font>"
           
            

            tabr.Controls.Add(tabrc1)
            tabr.Controls.Add(tabrc2)
            tabr.Controls.Add(tabrc3)
            tabr.Controls.Add(tabrc4)
            tabr.Controls.Add(tabrc5)
            tabr.Controls.Add(tabrc6)
            tabr.Controls.Add(tabrc7)
            tabr.Controls.Add(tabrc8)
            tabr.Controls.Add(tabrc9)
 


            tab.Controls.Add(tabr)

        Next

        Dim lin22 As New TableRow
        Dim lin221 As New TableCell
        lin22.width = 200
        lin221.ColumnSpan = 200
        lin221.Text = "<hr >"
        lin22.Controls.Add(lin221)
        tab.Controls.Add(lin22)

        Me.Panel1.Controls.Add(tab)


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Server.Transfer(" window.open('../home.aspx','_self');")
        Server.Transfer("../home.aspx")


    End Sub
End Class
