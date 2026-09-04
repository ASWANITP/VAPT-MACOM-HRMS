Imports System.Data
Imports System.Data.OracleClient
Partial Class Auction_pledgeReport_af2a2f688355
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim tbl As New Table
    Dim count As Integer
    Dim comp_date As String
    Dim total1, total2, total3, total4, total5, total6, total7 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        comp_date = Request.QueryString.Get("FromDt")

        sql1 = "select count(*) from hrm_comp_eligible t join employee_master e on e.emp_code = t.emp_code join hrm_comp_mst m on m.comp_id = t.comp_id join employ_firm f on f.emp_code = t.emp_code and f.firm_id=" & Session("FIRM_ID") & "  join branch_master b on b.branch_id = e.branch_id join hrm_comp_dtl d on d.comp_id = t.comp_id and d.emp_code=t.emp_code where t.comp_dt=to_date('" & comp_date & "') order by B.branch_name,t.emp_code"
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)

        If dt1.Rows(0)(0) = 0 Then

            '  Response.Write("NO DATA FOUND")
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('NO DATA FOUND !');")
            cl_script1.Append("         window.open('Compenastory_date.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else

            FillReportHeader()
            FillColumnHeader()
            FillColumnField()
            FillTotalField()
            Panel1.Controls.Add(tbl)
        End If

    End Sub

    Sub FillReportHeader()
        tbl.Attributes.Add("width", "100%")
        tbl.Attributes.Add("align", "center")
        tbl.Attributes.Add("border", "0")
        Dim tr1 As New TableRow
        Dim tc1 As New TableCell

        tc1.ColumnSpan = 7

        tc1.Text = "<font size=4><b>" & Session("firm_name") & "</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.Gold
        tc1.ForeColor = Drawing.Color.Red
        tc1.BorderColor = Drawing.Color.Red
        tr1.Controls.Add(tc1)
        tbl.Controls.Add(tr1)
        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tc2.ColumnSpan = 7
        tc2.Text = "<font size=2><b>" & Session("branch_name") & " </font></b>"
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc2.BackColor = Drawing.Color.LightCyan
        tr2.Controls.Add(tc2)
        tbl.Controls.Add(tr2)
        Dim tr3 As New TableRow
        Dim tc31 As New TableCell
        Dim tc32 As New TableCell
        Dim tc33 As New TableCell
        tc31.ColumnSpan = 1
        tc32.ColumnSpan = 5
        tc33.ColumnSpan = 1

        tc31.Text = "<font size=2><b>DATE : " & Format(Date.Now, "dd-MMM-yyyy") & "</font></b>"
        tc31.HorizontalAlign = HorizontalAlign.Left
        tc32.Text = "<font size=2><b> COMPENSATORY REPORT ON :" + comp_date + "</font></b>"
        tc32.HorizontalAlign = HorizontalAlign.Center
        tc33.Text = "<b><font size=2 >TIME : " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        tc33.HorizontalAlign = HorizontalAlign.Right
        tr3.ForeColor = Drawing.Color.Red
        tr3.BackColor = Drawing.Color.Gold
        tr3.Controls.Add(tc31)
        tr3.Controls.Add(tc32)
        tr3.Controls.Add(tc33)
        tbl.Controls.Add(tr3)
    End Sub
    Sub FillColumnHeader()
        Dim tr4 As New TableRow
        tr4.BackColor = Drawing.Color.LightGray
        Dim tc40, tc41, tc42, tc43, tc44, tc45, tc46, tc47, tc48, tc49, tc50, tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58 As New TableCell
        tr4.BackColor = Drawing.Color.LightGray
        tr4.ForeColor = Drawing.Color.Black
        tr4.Font.Bold = True
        tc40.Text = "<font size=2><b>BRANCH NAME</font>"
        tc41.Text = "<font size=2><b>EMPLOYEE CODE</font>"
        tc42.Text = "<font size=2><b>EMPLOYEE NAME</font>"
        tc43.Text = "<font size=2><b>COMPENSATORY ID</font>"
        tc44.Text = "<font size=2><b>COMPENSATORY NAME </font>"
        tc45.Text = "<font size=2><b>COMPENSATORY DATE </font>"
        tc46.Text = "<font size=2><b>EXPIRY DATE</font>"
        'tc47.Text = "<font size=2><b>AUCTIONED DATE</font>"
        'tc48.Text = "<font size=2><b>SETTLEMENT AMOUNT</font>"
        'tc49.Text = "<font size=2><b>AUCTION AMOUNT</font>"
        'tc50.Text = "<font size=2><b>AUCTION LOSS</font>"
        'tc51.Text = "<font size=2><b>PRICE VARIANCE LTV MORE THAN " + V_LTV + "</font>"

     
        tc40.HorizontalAlign = HorizontalAlign.Left
        tc41.HorizontalAlign = HorizontalAlign.Left
        tc42.HorizontalAlign = HorizontalAlign.Left
        tc43.HorizontalAlign = HorizontalAlign.Left
        tc44.HorizontalAlign = HorizontalAlign.Left
        tc45.HorizontalAlign = HorizontalAlign.Center
        tc46.HorizontalAlign = HorizontalAlign.Center
        'tc47.HorizontalAlign = HorizontalAlign.Center
        'tc48.HorizontalAlign = HorizontalAlign.Right
        'tc49.HorizontalAlign = HorizontalAlign.Right
        'tc50.HorizontalAlign = HorizontalAlign.Right
        'tc51.HorizontalAlign = HorizontalAlign.Right
       

        tr4.Controls.Add(tc40)
        tr4.Controls.Add(tc41)
        tr4.Controls.Add(tc42)
        tr4.Controls.Add(tc43)
        tr4.Controls.Add(tc44)
        tr4.Controls.Add(tc45)
        tr4.Controls.Add(tc46)
        'tr4.Controls.Add(tc47)
        'tr4.Controls.Add(tc48)
        'tr4.Controls.Add(tc49)
        'tr4.Controls.Add(tc50)
        'tr4.Controls.Add(tc51)
      

        tbl.Controls.Add(tr4)

    End Sub
    Sub FillColumnField()

        sql = "select b.branch_name,t.emp_code,e.emp_name,t.comp_id,m.comp_name,TO_CHAR(t.comp_dt,'DD-MON-YYYY'),to_char(d.exp_date,'DD-MON-YYYY') from hrm_comp_eligible t join employee_master e on e.emp_code = t.emp_code join hrm_comp_mst m on m.comp_id = t.comp_id join employ_firm f on f.emp_code = t.emp_code and f.firm_id=" & Session("FIRM_ID") & "  join branch_master b on b.branch_id = e.branch_id join hrm_comp_dtl d on d.comp_id = t.comp_id and d.emp_code=t.emp_code where t.comp_dt=to_date('" & comp_date & "') order by B.branch_name,t.emp_code"
        dt = oh.ExecuteDataSet(sql).Tables(0)

        count = 0
        For Each dr In dt.Rows
            Dim tr5 As New TableRow
            tr5.BackColor = Drawing.Color.WhiteSmoke
            Dim tc50, tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc60, tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68 As New TableCell
            tc50.Text = "<FONT SIZE =2><font color='blue'>" & dr(0) & "</font>"
            tc51.Text = "<FONT SIZE =2><font color='blue'>" & dr(1) & "</font>"
            tc52.Text = "<FONT SIZE =2><font color='blue'>" & dr(2) & "</font>"
            tc53.Text = "<FONT SIZE =2><font color='blue'>" & dr(3) & "</font>"
            tc54.Text = "<FONT SIZE =2><font color='blue'>" & dr(4) & "</font>"
            tc55.Text = "<FONT SIZE =2> <font color='blue'>" & dr(5) & "</font>"
            tc56.Text = "<FONT SIZE =2> <font color='blue'>" & dr(6) & "</font>"
            'tc57.Text = "<FONT SIZE =2> <font color='blue'>" & dr(7) & "</font>"
            'tc58.Text = "<FONT SIZE =2> <font color='blue'>" & FormatNumber(dr(8)) & "</font>"
            'tc59.Text = "<FONT SIZE =2> <font color='blue'>" & FormatNumber(dr(9)) & "</font>"
            'tc60.Text = "<FONT SIZE =2> <font color='blue'>" & FormatNumber(dr(10)) & "</font>"
            'tc61.Text = "<FONT SIZE =2> <font color='blue'>" & FormatNumber(dr(11)) & "</font>"
            

            count = count + 1
            'total1 += dr(6)
            'total2 += dr(8)
            'total3 += dr(9)
            'total4 += dr(10)
            'total5 += dr(11)
            'total6 += dr(7)
            'total7 += dr(8)
            'total5 += dr(6)
            'tc51.HorizontalAlign = HorizontalAlign.Center
            tc50.HorizontalAlign = HorizontalAlign.Left
            tc51.HorizontalAlign = HorizontalAlign.Left
            tc52.HorizontalAlign = HorizontalAlign.Left
            tc53.HorizontalAlign = HorizontalAlign.Center
            tc54.HorizontalAlign = HorizontalAlign.Center
            tc55.HorizontalAlign = HorizontalAlign.Right
            tc56.HorizontalAlign = HorizontalAlign.Right
            'tc57.HorizontalAlign = HorizontalAlign.Center
            'tc58.HorizontalAlign = HorizontalAlign.Right
            'tc59.HorizontalAlign = HorizontalAlign.Right
            'tc60.HorizontalAlign = HorizontalAlign.Right
            'tc61.HorizontalAlign = HorizontalAlign.Right
            

            tr5.Controls.Add(tc50)
            tr5.Controls.Add(tc51)
            tr5.Controls.Add(tc52)
            tr5.Controls.Add(tc53)
            tr5.Controls.Add(tc54)
            tr5.Controls.Add(tc55)
            tr5.Controls.Add(tc56)
            'tr5.Controls.Add(tc57)
            'tr5.Controls.Add(tc58)
            'tr5.Controls.Add(tc59)
            'tr5.Controls.Add(tc60)
            'tr5.Controls.Add(tc61)
            

            tbl.Controls.Add(tr5)

        Next
    End Sub
    Sub FillTotalField()

        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.LightGray
        Dim tc60, tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68, tc69, tc70 As New TableCell
        tr6.BackColor = Drawing.Color.LightGray
        tr6.ForeColor = Drawing.Color.Black
        tr6.Font.Bold = True

        tc60.ColumnSpan = 1
        tc61.ColumnSpan = 1
        tc62.ColumnSpan = 1
        tc63.ColumnSpan = 1
        tc64.ColumnSpan = 1
        tc65.ColumnSpan = 1
        tc66.ColumnSpan = 1
        'tc67.ColumnSpan = 1
        'tc68.ColumnSpan = 1
        'tc69.ColumnSpan = 1
        tc60.Text = "<font size=2><b>Total</font>"
        tc61.Text = "<font size=2><b>" & count & "</font>"
        tc62.Text = "<font size=2><b></font>"
        tc63.Text = "<font size=2><b></font>"
        tc64.Text = "<font size=2><b></font>"
        tc65.Text = "<font size=2><b></font>"
        tc66.Text = "<font size=2><b></font>"
        ' tc68.Text = "<font size=2><b></font>"

        tc60.HorizontalAlign = HorizontalAlign.Left
        tc61.HorizontalAlign = HorizontalAlign.Left
        tc62.HorizontalAlign = HorizontalAlign.Right
        tc63.HorizontalAlign = HorizontalAlign.Right
        tc64.HorizontalAlign = HorizontalAlign.Right
        tc65.HorizontalAlign = HorizontalAlign.Right
        tc66.HorizontalAlign = HorizontalAlign.Right
        'tc67.HorizontalAlign = HorizontalAlign.Right
        'tc68.HorizontalAlign = HorizontalAlign.Right

        tr6.Controls.Add(tc60)
        tr6.Controls.Add(tc61)
        tr6.Controls.Add(tc62)
        tr6.Controls.Add(tc63)
        tr6.Controls.Add(tc64)
        tr6.Controls.Add(tc65)
        tr6.Controls.Add(tc66)
        'tr6.Controls.Add(tc67)
        'tr6.Controls.Add(tc68)

        tbl.Controls.Add(tr6)

    End Sub
End Class
