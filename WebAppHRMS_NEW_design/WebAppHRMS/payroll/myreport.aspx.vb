Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Punching_myreport_ab1286b96950
    Inherits System.Web.UI.Page
    Dim dt, dts As New DataTable
    Dim dr As DataRow
    Dim str, strs, sf(), frm As String
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frm = Session("firm_id")
        Dim dts1 As DataTable

        dts1 = oh.ExecuteDataSet("select query from hrm_report_master where firm_id=99 and query_id=177").Tables(0)
        Dim strd() As String = dts1.Rows(0)(0).ToString.Split("#")
        dts = oh.ExecuteDataSet(strd(1).ToString.Replace("mycode", Me.Session("user_id").ToString.Split("!")(0))).Tables(0)
        If dts.Rows(0)(0) = 0 Then
            Dim cl_script As New StringBuilder
            cl_script.Append("alert('You are not authorised!!') ;")
            cl_script.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
        End If
        Dim hotable As New Table
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 4
        Dim headercell As New TableCell
        headercell.ColumnSpan = 4
        headercell.Text = "<b><font size=4>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        hotable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 4
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 4
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        'sheadercell1.Text = "<b><font size=3>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        hotable.Controls.Add(sheader)
        Dim tt As New TableRow
        ' tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 4
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 4
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>&nbsp;&nbsp;&nbsp;EMPLOYEE&nbsp;ATTRITION&nbsp;PERCENTAGE&nbsp;REPORT&nbsp;</font></b>"
        tt.Controls.Add(tt1)
        hotable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 4

        subcell1.Text = "<b><font size=3> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 2
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 1
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 1
        subcell3.HorizontalAlign = HorizontalAlign.Left
        'subcell3.Text = "<b><font size=3.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.Text = "<font size=3><b><div id= txt align= right></div></b></font></div>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        hotable.Controls.Add(subh)


        Dim linea As New TableRow
        Dim linecella As New TableCell
        linecella.ColumnSpan = 4
        linecella.Text = "<hr>"
        linea.Controls.Add(linecella)
        hotable.Controls.Add(linea)

        Dim colors As String
        colors = "#fff7ff"


        Dim field As New TableRow
        field.Width = 3
        field.Attributes.Add("bgcolor", colors)
        Dim f0, f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 As New TableCell

        f0.ColumnSpan = 1
        f0.HorizontalAlign = HorizontalAlign.Center
        f0.Text = "<b><font size=3>&nbsp;&nbsp;SL.NO </font></b>"
        field.Controls.Add(f0)



        'f1.ColumnSpan = 1
        'f1.HorizontalAlign = HorizontalAlign.Center
        'f1.Text = "<b><font size=3>&nbsp;&nbsp;DATE</font></b>"
        'field.Controls.Add(f1)

        f2.ColumnSpan = 1
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=3>&nbsp;EMP CODE&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 1
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=3>&nbsp;&nbsp;EMP NAME&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f3)

        'f4.ColumnSpan = 1
        'f4.HorizontalAlign = HorizontalAlign.Center
        'f4.Text = "<b><font size=3>&nbsp;&nbsp;EXIT TIME&nbsp;&nbsp;</font></b>"
        'field.Controls.Add(f4)

        'f5.ColumnSpan = 1
        'f5.HorizontalAlign = HorizontalAlign.Center
        'f5.Text = "<b><font size=3>&nbsp;&nbsp;ENTRY TIME&nbsp;&nbsp;</font></b>"
        'field.Controls.Add(f5)

        'f6.ColumnSpan = 1
        'f6.HorizontalAlign = HorizontalAlign.Center
        'f6.Text = "<b><font size=3>&nbsp;&nbsp;PLACE&nbsp;&nbsp;</font></b>"
        'field.Controls.Add(f6)

        'f7.ColumnSpan = 1
        'f7.HorizontalAlign = HorizontalAlign.Center
        'f7.Text = "<b><font size=3>&nbsp;&nbsp;TYPE&nbsp;&nbsp;</font></b>"
        'field.Controls.Add(f7)

        'f8.ColumnSpan = 1
        'f8.HorizontalAlign = HorizontalAlign.Center
        'f8.Text = "<b><font size=3>&nbsp;&nbsp;RECOMMENDER&nbsp;&nbsp;</font></b>"
        'field.Controls.Add(f8)


        'f9.ColumnSpan = 1
        'f9.HorizontalAlign = HorizontalAlign.Center
        'f9.Text = "<b><font size=3>&nbsp;&nbsp;APPROVER&nbsp;&nbsp;</font></b>"
        'field.Controls.Add(f9)

        f10.ColumnSpan = 1
        f10.HorizontalAlign = HorizontalAlign.Center
        f10.Text = "<b><font size=3>&nbsp;&nbsp;PERCENTAGE&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f10)



        hotable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 4
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        hotable.Controls.Add(line1)
        '                   0            1            2          3       ---------------------------4---------------------------------------------    -----------------------------------------5----------------------------------------    eliminated Boerd of Directors...norm id=32 on 06-12-08           
        'str = "select distinct sn.norm_id,  sn.dept_name,  sn.requirement,  sn.actual,  case  when sn.requirement - sn.actual > 0 then  sn.requirement - sn.actual  else  0  end as short,  case  when sn.actual - sn.requirement > 0 then  sn.actual - sn.requirement  else  0  end as surplus  from staff_norm_ho sn,employee_master e,employ_firm f  where sn.norm_id <> 32  and e.department_id=sn.dep_id  and e.status_id=1  and e.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  order by sn.dept_name"
        'str = strd(3).Replace("mybranch", 0)
        'dt = oh.ExecuteDataSet(str).Tables(0)

        'sf = Session("user_id").ToString.Split("!")
        strs = strd(0)
        dt = oh.ExecuteDataSet(strs).Tables(0)

        Dim i As Integer = 0

        Dim c0 As Integer = 0
        Dim c1 As Integer = 0
        Dim c2 As Double = 0
        Dim c3 As Integer = 0
        Dim c4 As Integer = 0
        Dim c5 As Integer = 0
        Dim c6 As Integer = 0
        Dim c7 As Integer = 0
        Dim c8 As Integer = 0
        Dim c9 As Integer = 0
        Dim c10 As Integer = 0




        For Each dr In dt.Rows
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If

            Dim value As New TableRow
            value.Width = 8
            value.Attributes.Add("bgcolor", colors)

            Dim v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 As New TableCell
            i = i + 1

            v0.ColumnSpan = 1
            'v1.ColumnSpan = 1



            v0.ColumnSpan = 1
            v0.HorizontalAlign = HorizontalAlign.Right
            v0.Text = "<font size=3>&nbsp;" & i & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v0)
            hotable.Controls.Add(value)

            v1.ColumnSpan = 1
            v1.HorizontalAlign = HorizontalAlign.Left
            v1.Text = "<font size=3>&nbsp;" & dr(0) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v1)
            hotable.Controls.Add(value)
            'c1 += dr(1)


            v2.ColumnSpan = 1
            v2.HorizontalAlign = HorizontalAlign.Left
            v2.Text = "<font size=3>&nbsp;" & dr(1) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            value.Controls.Add(v2)
            hotable.Controls.Add(value)

            v3.ColumnSpan = 1
            v3.HorizontalAlign = HorizontalAlign.Left
            'v3.Text = "<font size=3>&nbsp;" & dr(2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
            Dim col, subcol As String
            If CInt(dr(2)) < 50 Then
                col = "#00FF00"
            Else
                col = "#FF0000"
            End If

            If col = "#00FF00" Then
                subcol = "black"
            Else
                subcol = "yellow"
            End If
            'v3.Text = "<font size=3><div style='height: 15px; width: " & dr(2) & "0px; background-color: " & col & "'></div></font>"
            v3.Text = "<font size=2><table border='1' style=border-color:black;><tr><td width='100px'><div style='text-align: right;width: " & dr(2) & "px;height: 15px;background-color: " & col & ";color:" & subcol & ";' class='rectangle'>" & dr(2) & "</div></td></tr></table></font>"
            value.Controls.Add(v3)
            hotable.Controls.Add(value)


            hotable.Controls.Add(value)





        Next

        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 15
        linecell2.Text = "<hr>"
        line2.Controls.Add(linecell2)
        hotable.Controls.Add(line2)

        


        PanelHoNSS.Controls.Add(hotable)
    End Sub

End Class



