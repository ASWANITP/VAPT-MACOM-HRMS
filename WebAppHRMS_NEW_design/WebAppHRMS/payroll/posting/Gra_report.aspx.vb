Imports system.data
Imports system.data.oracleclient
Partial Class specificempattend_individualreport_13c4d4754035
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt6, dt7, dt8, dt9, dt10, dt11, dt12, dtlong, dtsanc, dtcomp, dtrejoin, dtfrom, dtnature As New DataTable
    Dim oh As New helper.oracle.OracleHelper
    Dim fdt, tdt, emp, sql, sql1, sqllong, sqlsanc, sqlcomp, sqlrejoin, sqlfrom, sqlnature As String
    Dim dr As DataRow
    Dim per, totalper As Double
    Dim totalp = 0, totals = 0
    Dim color = 0
    Dim firm As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        firm = Session("firm_id")
        sql = "select to_char(rownum) SLNO ,to_char(t.emp_code)emp_code,t.emp_name,to_char(t.join_dt)join_date,to_char(tt.discont_dt) discontinue_date, to_char(tt.discont_dt-t.join_dt) Total_Working_days, to_char(floor((tt.discont_dt-t.join_dt)/365)) NO_of_years_of_service from employee_master t,employee_master_dtl tt, employ_firm ef where t.emp_code=tt.emp_code and t.emp_code=ef.emp_code and (tt.discont_dt-t.join_dt)/365>5 and ef.firm_id=28"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim tb As New Table
        tb.Attributes.Add("Border", "1")
        tb.Style.Add("border-collapse", "collapse")
        tb.Attributes.Add("width", "189%")
        If dt.Rows.Count > 0 Then
            Dim tr1 As New TableRow
            Dim td11 As New TableCell
            tr1.BackColor = Drawing.Color.Gold
            td11.Attributes.Add("width", "100%")
            td11.ColumnSpan = 200
            td11.HorizontalAlign = HorizontalAlign.Center
            td11.Text = "<font size=4 color=red><b>" & Session("firm_name") & "</b></font>"
            tr1.Controls.Add(td11)
            tb.Controls.Add(tr1)

            Dim tr3 As New TableRow
            tr3.BackColor = Drawing.Color.MistyRose
            Dim td31 As New TableCell

            Dim td32 As New TableCell
            td32.Attributes.Add("width", "40%")
            td32.ColumnSpan = 25
            td32.HorizontalAlign = HorizontalAlign.Center
            td32.Text = "<font size=2 color=darkblue><BR><BR><b>Time :" & Format(Date.Now, "hh:mm:ss") & "</b></font>"
            tr3.Controls.Add(td32)

            Dim td321 As New TableCell
            td321.Attributes.Add("width", "40%")
            td321.ColumnSpan = 110
            td321.HorizontalAlign = HorizontalAlign.Center
            td321.Text = "<font size=3.0 color=darkbrown><BR><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Gratuity Report</b></font>"
            tr3.Controls.Add(td321)


            td31.Attributes.Add("width", "10%")
            td31.ColumnSpan = 25
            td31.HorizontalAlign = HorizontalAlign.Center
            td31.Text = "<font size=2 color=darkblue><BR><BR><b>Date :" & Format(Date.Now, "dd/MMM/yyyy") & "</b></font>"
            tr3.Controls.Add(td31)
            tb.Controls.Add(tr3)



            Dim l4 As New TableRow
            Dim ld4 As New TableCell
            ld4.Attributes.Add("width", "100%")
            ld4.ColumnSpan = 200
            ld4.HorizontalAlign = HorizontalAlign.Center
            ld4.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
            l4.Controls.Add(ld4)
            tb.Controls.Add(l4)



            Dim ta4 As New TableRow
            Dim ta32 As New TableCell
            ta32.Attributes.Add("width", "10%")
            ta32.ColumnSpan = 25
            ta32.HorizontalAlign = HorizontalAlign.Center
            ta32.Text = "<font size=2 color=black><BR><BR><b>SL.NO</b></font>"
            ta4.Controls.Add(ta32)
            tb.Controls.Add(ta4)

            Dim tb32 As New TableCell
            tb32.Attributes.Add("width", "10%")
            tb32.ColumnSpan = 25
            tb32.HorizontalAlign = HorizontalAlign.Center
            tb32.Text = "<font size=2 color=black><BR><BR><b>EMPLOYEE CODE</b></font>"
            ta4.Controls.Add(tb32)
            tb.Controls.Add(ta4)

            Dim tc32 As New TableCell
            tc32.Attributes.Add("width", "10%")
            tc32.ColumnSpan = 25
            tc32.HorizontalAlign = HorizontalAlign.Center
            tc32.Text = "<font size=2 color=black><BR><BR><b>EMPLOYEE NAME</b></font>"
            ta4.Controls.Add(tc32)
            tb.Controls.Add(ta4)

            Dim te32 As New TableCell
            te32.Attributes.Add("width", "10%")
            te32.ColumnSpan = 25
            te32.HorizontalAlign = HorizontalAlign.Center
            te32.Text = "<font size=2 color=black><BR><BR><b>JOINED DATE</b></font>"
            ta4.Controls.Add(te32)
            tb.Controls.Add(ta4)

            Dim tf32 As New TableCell
            tf32.Attributes.Add("width", "10%")
            tf32.ColumnSpan = 25
            tf32.HorizontalAlign = HorizontalAlign.Center
            tf32.Text = "<font size=2 color=black><BR><BR><b>LAST WORKING DATE</b></font>"
            ta4.Controls.Add(tf32)
            tb.Controls.Add(ta4)

            Dim tg32 As New TableCell
            tg32.Attributes.Add("width", "10%")
            tg32.ColumnSpan = 25
            tg32.HorizontalAlign = HorizontalAlign.Center
            tg32.Text = "<font size=2 color=black><BR><BR><b>TOTAL WORKING DAYS</b></font>"
            ta4.Controls.Add(tg32)
            tb.Controls.Add(ta4)

            Dim tH32 As New TableCell
            tH32.Attributes.Add("width", "10%")
            tH32.ColumnSpan = 25
            tH32.HorizontalAlign = HorizontalAlign.Center
            tH32.Text = "<font size=2 color=black><BR><BR><b>NO.OF YEARS OF SERVICE</b></font>"
            ta4.Controls.Add(tH32)
            tb.Controls.Add(ta4)


            For Each dr In dt.Rows

                Dim tr6 As New TableRow
                If (color = 0) Then
                    tr6.BackColor = Drawing.Color.GhostWhite
                    color = 1
                Else
                    tr6.BackColor = Drawing.Color.WhiteSmoke
                    color = 0
                End If

                Dim ta14 As New TableRow
                Dim ta132 As New TableCell
                ta132.Attributes.Add("width", "10%")
                ta132.ColumnSpan = 25
                ta132.HorizontalAlign = HorizontalAlign.Center
                ta132.Text = "<font size=2 color=blue><BR>" & dr(0) & "</font>"
                ta14.Controls.Add(ta132)
                tb.Controls.Add(ta14)

                Dim tb132 As New TableCell
                tb132.Attributes.Add("width", "10%")
                tb132.ColumnSpan = 25
                tb132.HorizontalAlign = HorizontalAlign.Center
                tb132.Text = "<font size=2 color=blue><BR>" & dr(1) & "</font>"
                ta14.Controls.Add(tb132)
                tb.Controls.Add(ta14)

                Dim tc132 As New TableCell
                tc132.Attributes.Add("width", "10%")
                tc132.ColumnSpan = 25
                tc132.HorizontalAlign = HorizontalAlign.Center
                tc132.Text = "<font size=2 color=blue><BR>" & dr(2) & "</font>"
                ta14.Controls.Add(tc132)
                tb.Controls.Add(ta14)

                Dim te132 As New TableCell
                te132.Attributes.Add("width", "10%")
                te132.ColumnSpan = 25
                te132.HorizontalAlign = HorizontalAlign.Center
                te132.Text = "<font size=2 color=blue><BR>" & dr(3) & "</font>"
                ta14.Controls.Add(te132)
                tb.Controls.Add(ta14)

                Dim tf132 As New TableCell
                tf132.Attributes.Add("width", "10%")
                tf132.ColumnSpan = 25
                tf132.HorizontalAlign = HorizontalAlign.Center
                tf132.Text = "<font size=2 color=blue><BR>" & dr(4) & "</font>"
                ta14.Controls.Add(tf132)
                tb.Controls.Add(ta14)

                Dim tg132 As New TableCell
                tg132.Attributes.Add("width", "10%")
                tg132.ColumnSpan = 25
                tg132.HorizontalAlign = HorizontalAlign.Center
                tg132.Text = "<font size=2 color=blue><BR>" & dr(5) & "</font>"
                ta14.Controls.Add(tg132)
                tb.Controls.Add(ta14)

                Dim tH132 As New TableCell
                tH132.Attributes.Add("width", "10%")
                tH132.ColumnSpan = 25
                tH132.HorizontalAlign = HorizontalAlign.Center
                tH132.Text = "<font size=2 color=blue><BR>" & dr(6) & "</b></font>"
                ta14.Controls.Add(tH132)
                tb.Controls.Add(ta14)

            Next
            Dim l3 As New TableRow
            Dim ld3 As New TableCell
            ld3.Attributes.Add("width", "100%")
            ld3.ColumnSpan = 200
            ld3.HorizontalAlign = HorizontalAlign.Center
            ld3.Text = "<font size=3><b><hr size='2' NOSHADE></b></font>"
            l3.Controls.Add(ld3)
            tb.Controls.Add(l3)
            Me.Panel1.Controls.Add(tb)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No Emploees Exists');")
            Me.submit.visible = False
            Me.Button1.visible = False
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub
End Class
