Imports System.Data
Imports System.Data.OracleClient
Partial Class querygiven_longleave_1b51ec6c2653
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim hptable As New Table
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 14
        Dim headercell As New TableCell
        headercell.ColumnSpan = 14
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        hptable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 14
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 14
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        hptable.Controls.Add(sheader)

        Dim tt As New TableRow
        'tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 14
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 14
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>&nbsp;Long&nbsp;&nbsp;Leave&nbsp;&nbsp;Report&nbsp;</font></b>"
        tt.Controls.Add(tt1)
        hptable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 14

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 9
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 3
        subcell3.HorizontalAlign = HorizontalAlign.Left
        'subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        hptable.Controls.Add(subh)

        Dim line As New TableRow
        Dim linecell As New TableCell
        linecell.ColumnSpan = 14
        linecell.Text = "<hr>"
        line.Controls.Add(linecell)
        hptable.Controls.Add(line)
        '''''''''''''''''

        Dim colors As String
        colors = "#fff7ff"

        'If colors.Equals("#fff7ff") = True Then
        '    colors = "#eef9ff"
        'Else
        '    colors = "#fff7ff"
        'End If


        Dim field As New TableRow
        field.Width = 14
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        'f1.ColumnSpan = 1
        'f1.HorizontalAlign = HorizontalAlign.Center
        'f1.Text = "<b><font size=2>&nbsp;&nbsp;State&nbsp;&nbsp;&nbsp;</font></b>"
        'field.Controls.Add(f1)

        f2.ColumnSpan = 2
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>&nbsp;&nbsp;Branch&nbsp;ID&nbsp;and&nbsp;Name&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 2
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>&nbsp;&nbsp;Employee&nbsp;Code&nbsp;and&nbsp;Name&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 2
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>&nbsp;&nbsp;Departmt&nbsp;Name&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 2
        f5.HorizontalAlign = HorizontalAlign.Center
        f5.Text = "<b><font size=2>&nbsp;&nbsp;Designation&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 3
        f6.HorizontalAlign = HorizontalAlign.Center
        f6.Text = "<b><font size=2>&nbsp;&nbsp;Post&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f6)

        f7.ColumnSpan = 1
        f7.HorizontalAlign = HorizontalAlign.Center
        f7.Text = "<b><font size=2>&nbsp;&nbsp;Join&nbsp;Date&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f7)

        f8.ColumnSpan = 1
        f8.HorizontalAlign = HorizontalAlign.Center
        f8.Text = "<b><font size=2>&nbsp;&nbsp;Last&nbsp;Punch&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f8)

        f9.ColumnSpan = 1
        f9.HorizontalAlign = HorizontalAlign.Center
        f9.Text = "<b><font size=2>&nbsp;&nbsp;No&nbsp;of&nbsp;days&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f9)

        'f10.ColumnSpan = 1
        'f10.HorizontalAlign = HorizontalAlign.Center
        'f10.Text = "<b><font size=2>&nbsp;&nbsp;B.L/P.L/Chits &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Surplus&nbsp;&nbsp;</font></b>"
        'field.Controls.Add(f10)

        hptable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 14
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        hptable.Controls.Add(line1)




        '                  0            1            2          3             4          5           6             7              8           9          10
        str = "select distinct g.state_name,a.branch_id,b.branch_name,a.emp_code,c.emp_name,d.dep_name,e.designation,f.post_name,c.join_dt,a.last_punch,a.absent_days from staff_long_leave a,branch_master b,employee_master c,department_mst d,designation_master e,post_mst f,state_master g,employ_firm h where a.branch_id=b.branch_id and a.emp_code=c.emp_code and c.emp_code=h.emp_code   and h.firm_id=" & Session("firm_id") & "  and c.department_id=d.dep_id and c.designation_id=e.designation_id and c.post_id=f.post_id  and b.state_id=g.state_id and c.status_id=1 order by  g.state_name,b.branch_name"
        dt = oh.ExecuteDataSet(str).Tables(0)

        Dim state As String = ""

        For Each dr In dt.Rows

            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If

            If state <> dr(0) Then
                Dim rr As New TableRow
                rr.Width = 14
                rr.ForeColor = Drawing.Color.Black
                rr.BackColor = Drawing.Color.Wheat
                Dim rr1 As New TableCell
                rr1.ColumnSpan = 14
                rr1.HorizontalAlign = HorizontalAlign.Center
                rr1.Text = "<b><u><font size=2.5>" & dr(0) & "</font></u></b>"
                rr.Controls.Add(rr1)
                hptable.Controls.Add(rr)

            End If

            state = dr(0)

            Dim value As New TableRow
            value.Width = 14
            value.Attributes.Add("bgcolor", colors)

            Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10 As New TableCell

            'v1.ColumnSpan = 1
            'v1.HorizontalAlign = HorizontalAlign.Left  '"<a href=DrilldownShort.aspx?area_id=" & dr(4) & "&hw=" & dr(12) & ">
            'v1.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            'value.Controls.Add(v1)
            'hptable.Controls.Add(value)

            v2.ColumnSpan = 2
            v2.HorizontalAlign = HorizontalAlign.Left
            v2.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;&nbsp;" & dr(2) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v2)
            hptable.Controls.Add(value)
            ' c1 += dr(2)

            v3.ColumnSpan = 2
            v3.HorizontalAlign = HorizontalAlign.Left
            v3.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;&nbsp;" & dr(4) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v3)
            hptable.Controls.Add(value)
            'c2 += dr(3)

            v4.ColumnSpan = 2
            v4.HorizontalAlign = HorizontalAlign.Left
            v4.Text = "<font size=2>&nbsp;&nbsp;" & dr(5) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v4)
            hptable.Controls.Add(value)
            'c3 += dr(4)

            v5.ColumnSpan = 2
            v5.HorizontalAlign = HorizontalAlign.Left
            v5.Text = "<font size=2>&nbsp;&nbsp;" & dr(6) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v5)
            hptable.Controls.Add(value)
            ' c4 += dr(5)

            v6.ColumnSpan = 3
            v6.HorizontalAlign = HorizontalAlign.Left
            v6.Text = "<font size=2>&nbsp;&nbsp;&nbsp;" & dr(7) & "&nbsp;&nbsp;</font>"
            value.Controls.Add(v6)
            hptable.Controls.Add(value)
            'c5 += dr(6)

            v7.ColumnSpan = 1
            v7.HorizontalAlign = HorizontalAlign.Left
            v7.Text = "<font size=2>&nbsp;" & Format(dr(8), "dd/MMM/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v7)
            hptable.Controls.Add(value)
            'c6 += dr(7)

            v8.ColumnSpan = 1
            v8.HorizontalAlign = HorizontalAlign.Left
            If IsDBNull(dr(9)) Then
                v8.Text = "<font size=2>&nbsp;Not&nbsp;&nbsp;Punched!!&nbsp;</font>"
            Else
                v8.Text = "<font size=2>&nbsp;" & Format(dr(9), "dd/MMM/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            End If

            value.Controls.Add(v8)
            hptable.Controls.Add(value)
            'c7 += dr(7)

            v9.ColumnSpan = 1
            v9.HorizontalAlign = HorizontalAlign.Center
            v9.Text = "<font size=2>" & dr(10) & "&nbsp;&nbsp;</font>"
            value.Controls.Add(v9)
            hptable.Controls.Add(value)



            'v10.ColumnSpan = 1
            'v10.HorizontalAlign = HorizontalAlign.Center
            'v10.Text = "<font size=2>" & 0 & "</font>"
            'value.Controls.Add(v10)
            'hptable.Controls.Add(value)

        Next

        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 14
        linecell2.Text = "<hr>"
        line2.Controls.Add(linecell2)
        hptable.Controls.Add(line2)

        Panel1.Controls.Add(hptable)
    End Sub

    
End Class
