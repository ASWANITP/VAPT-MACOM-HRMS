Imports System.Data
Imports System.Data.OracleClient
Partial Class Auction_Listed_pledges_3b4510c88157
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim tbl As New Table
    Dim count, type As New Integer
    Dim fdate, tdate, brid, fd, branch_name As String
    Dim total1, total2, total3, total4, total5, total6, total7, total8, total9, total10, total11, total12, total13, total14, total15, total16, total17 As String
    Dim date1 As Date 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        brid = Session("branch_id")
        '  type = Request.QueryString.Get("adt")
        FillReportHeader()
        FillColumnHeader()
        FillColumnField()
        FillTotalField()
        Panel1.Controls.Add(tbl)
    End Sub


    Sub FillReportHeader()
        tbl.Attributes.Add("width", "100%")
        tbl.Attributes.Add("align", "center")
        tbl.Attributes.Add("border", "0")
        Dim tr1 As New TableRow
        Dim tc1 As New TableCell

        tc1.ColumnSpan = 8

        tc1.Text = "<font size=4><b>" & Session("firm_name") & "</font></b>"
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.BackColor = Drawing.Color.Gold
        tc1.ForeColor = Drawing.Color.Red
        tc1.BorderColor = Drawing.Color.Red
        tr1.Controls.Add(tc1)
        tbl.Controls.Add(tr1)
        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tc2.ColumnSpan = 8
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
        tc32.ColumnSpan = 6
        tc33.ColumnSpan = 1

        tc31.Text = "<font size=2><b>DATE : " & Format(Date.Now, "dd-MMM-yyyy") & "</font></b>"
        tc31.HorizontalAlign = HorizontalAlign.Left
        tc32.Text = "<font size=2><b>BLOOD GROUP OF ALL EMPLOYEES</font></b>"
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
        Dim tc41, tc42, tc43, tc44, tc45, tc46, tc47, tc48, tc49, tc50, tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc60, tc61, tc62, tc63, tc64 As New TableCell
        tr4.BackColor = Drawing.Color.LightGray
        tr4.ForeColor = Drawing.Color.Black
        tr4.Font.Bold = True

        tc41.ColumnSpan = 1
        tc42.ColumnSpan = 1
        tc43.ColumnSpan = 1
        tc44.ColumnSpan = 4
        tc45.ColumnSpan = 1

        tc41.Text = "<font size=2><b>SL NO.</font>"
        tc42.Text = "<font size=2><b>FIRM</font>"
        tc43.Text = "<font size=2><b>EMPLOYEE CODE</font>"
        tc44.Text = "<font size=2><b>NAME</font>"
        tc45.Text = "<font size=2><b>BLOOD GROUP</font>"
        'tc46.Text = "<font size=2><b>PAID AMOUNT</font>"
        'tc47.Text = "<font size=2><b>BALANCE TO BE PAID</font>"
        'tc48.Text = "<font size=2><b>STATUS</font>"
        'tc49.Text = "<font size=2><b>NUMBER OF INSTALLMENTS</font>"

        tc41.HorizontalAlign = HorizontalAlign.Left
        tc42.HorizontalAlign = HorizontalAlign.Left
        tc43.HorizontalAlign = HorizontalAlign.Left
        tc44.HorizontalAlign = HorizontalAlign.Left
        tc45.HorizontalAlign = HorizontalAlign.Left
        
       
        tr4.Controls.Add(tc41)
        tr4.Controls.Add(tc42)
        tr4.Controls.Add(tc43)
        tr4.Controls.Add(tc44)
        tr4.Controls.Add(tc45)
        
        tbl.Controls.Add(tr4)

    End Sub
    Sub FillColumnField()


        sql = "select c.firm_abbr firm,t.emp_code,t.emp_name,d.blood_type blood_group from employ_personal_dtl  t,employ_firm b,firm_master c ,bloodgroup_master d,employee_master em  where t.emp_code= b.emp_code and c.firm_id=b.firm_id and d.blood_id=t.blood_id and em.emp_code=t.emp_code and em.status_id=1 and b.firm_id=" & Session("firm_id") & "  order by  2"
        Dim Cnt As Integer = 0
        Dim RowBG As Integer = 0

        dt = oh.ExecuteDataSet(sql).Tables(0)
        For Each dr In dt.Rows
            Dim tr5 As New TableRow
            tr5.BackColor = Drawing.Color.WhiteSmoke
            Dim tc51, tc52, tc53, tc54, tc55, tc56, tc57, tc58, tc59, tc60, tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68, tc69, tc70 As New TableCell

            Cnt += 1

            tc51.Text = "<FONT SIZE =2><font color='blue'>" & Cnt & "</font>"
            tc52.Text = "<FONT SIZE =2><font color='blue'>" & dr(0) & "</font>"
            tc53.Text = "<FONT SIZE =2><font color='blue'>" & (dr(1)) & "</font>"
            tc54.Text = "<FONT SIZE =2><font color='blue'>" & (dr(2)) & "</font>"
            tc55.Text = "<FONT SIZE =2><font color='blue'>" & (dr(3)) & "</font>"
            'tc56.Text = "<FONT SIZE =2><font color='blue'>" & dr(5) & "</font>"
            'tc57.Text = "<FONT SIZE =2><font color='blue'>" & dr(6) & "</font>"
            'tc58.Text = "<FONT SIZE =2><font color='blue'>" & dr(7) & "</font>"
            'tc59.Text = "<FONT SIZE =2><font color='blue'>" & dr(8) & "</font>"

            If RowBG = 0 Then
                RowBG = 1
                tr5.BackColor = Drawing.Color.Snow
            Else
                RowBG = 0
            End If

            tc51.HorizontalAlign = HorizontalAlign.Left
            tc52.HorizontalAlign = HorizontalAlign.Left
            tc53.HorizontalAlign = HorizontalAlign.Left
            tc54.HorizontalAlign = HorizontalAlign.Left
            tc55.HorizontalAlign = HorizontalAlign.Left

            tc51.ColumnSpan = 1
            tc52.ColumnSpan = 1
            tc53.ColumnSpan = 1
            tc54.ColumnSpan = 4
            tc55.ColumnSpan = 1

            tr5.Controls.Add(tc51)
            tr5.Controls.Add(tc52)
            tr5.Controls.Add(tc53)
            tr5.Controls.Add(tc54)
            tr5.Controls.Add(tc55)
            'tr5.Controls.Add(tc56)
            'tr5.Controls.Add(tc57)
            'tr5.Controls.Add(tc58)
            'tr5.Controls.Add(tc59)

            tbl.Controls.Add(tr5)
            count = count + 1
            'total1 = total1 + dr(2)
            ' total2 = total2 + dr(3)
            ' total3 = total3 + dr(4)
            'total4 = total4 + dr(5)
            ' total5 = total5 + dr(6)
        Next


    End Sub
    Sub FillTotalField()

        Dim tr6 As New TableRow
        tr6.BackColor = Drawing.Color.LightGray
        Dim tc61, tc62, tc63, tc64, tc65, tc66, tc67, tc68, tc69, tc70, tc71, tc72, tc73, tc74, tc75, tc76, tc77, tc78, tc79, tc80 As New TableCell
        tr6.BackColor = Drawing.Color.LightGray
        tr6.ForeColor = Drawing.Color.Black
        tr6.Font.Bold = True
        tc61.ColumnSpan = 1
        tc62.ColumnSpan = 1
        tc63.ColumnSpan = 1
        tc64.ColumnSpan = 4
        tc65.ColumnSpan = 1
        'tc66.ColumnSpan = 1
        'tc67.ColumnSpan = 1
        'tc68.ColumnSpan = 2

        tc61.Text = "<font size=2><b>Total</font>"
        tc62.Text = "<font size=2><b>" & count & "</font>"
        ' tc63.Text = "<font size=2><b>" & FormatNumber(total1) & "</font>"
        ' tc64.Text = "<font size=2><b>" & FormatNumber(total2) & "</font>"
        ' tc65.Text = "<font size=2><b>" & FormatNumber(total3) & "</font>"
        ' tc66.Text = "<font size=2><b>" & FormatNumber(total4) & "</font>"
        'tc67.Text = "<font size=2><b>" & FormatNumber(total5) & "</font>"

        tc61.HorizontalAlign = HorizontalAlign.Left
        tc62.HorizontalAlign = HorizontalAlign.Left
        tc63.HorizontalAlign = HorizontalAlign.Right
        tc64.HorizontalAlign = HorizontalAlign.Right
        tc65.HorizontalAlign = HorizontalAlign.Right
      
        tr6.Controls.Add(tc61)
        tr6.Controls.Add(tc62)
        tr6.Controls.Add(tc63)
        tr6.Controls.Add(tc64)
        tr6.Controls.Add(tc65)
        'tr6.Controls.Add(tc66)
        'tr6.Controls.Add(tc67)
        'tr6.Controls.Add(tc68)
        tbl.Controls.Add(tr6)
    End Sub
End Class
