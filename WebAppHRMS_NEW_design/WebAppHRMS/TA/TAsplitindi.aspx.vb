Imports System.Data
Imports System.Data.OracleClient
Imports System.Text
Partial Class honormsandshort_honorshsur_d76245355411
    Inherits System.Web.UI.Page
    Dim dt, dts As New DataTable
    Dim dr As DataRow
    Dim str, strs As String
    Dim code As Integer
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim hotable As New Table
        Dim header As New TableRow
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        header.Width = 8
        Dim headercell As New TableCell
        headercell.ColumnSpan = 20
        headercell.Text = "<b><font size=4>Manappuram Comptech And Consultants Limited</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        hotable.Controls.Add(header)

        strs = "select initcap(to_char(branch_name||'('||branch_id||')')) from branch_master where branch_id=0"
        dts = oh.ExecuteDataSet(strs).Tables(0)

        Dim sheader As New TableRow
        sheader.Width = 8
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 20
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        'sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        hotable.Controls.Add(sheader)
        Dim tt As New TableRow
        ' tt.BackColor = Drawing.Color.LightSkyBlue
        tt.Width = 8
        Dim tt1 As New TableCell
        tt1.ColumnSpan = 20
        tt1.HorizontalAlign = HorizontalAlign.Center
        tt1.Text = "<b><font size=3>&nbsp;&nbsp;&nbsp;TA&nbsp;Status Report&nbsp;</font></b>"
        tt.Controls.Add(tt1)
        hotable.Controls.Add(tt)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 8

        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 8
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 4
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subh.Controls.Add(subcell2)
        subcell3.ColumnSpan = 8
        subcell3.HorizontalAlign = HorizontalAlign.Left
        'subcell3.Text = "<b><font size=2.5>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)
        hotable.Controls.Add(subh)


        Dim linea As New TableRow
        Dim linecella As New TableCell
        linecella.ColumnSpan = 20
        linecella.Text = "<hr>"
        linea.Controls.Add(linecella)
        hotable.Controls.Add(linea)

        Dim colors As String
        colors = "#fff7ff"


        Dim field As New TableRow
        field.Width = 20
        field.Attributes.Add("bgcolor", colors)
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, G1, G2 As New TableCell

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Center
        f1.Text = "<b><font size=2>&nbsp;&nbsp;SL.NO&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f1)

        G1.ColumnSpan = 1
        G1.HorizontalAlign = HorizontalAlign.Center
        G1.Text = "<b><font size=2>&nbsp;&nbsp;EMP CODE&nbsp;&nbsp;</font></b>"
        field.Controls.Add(G1)

        G2.ColumnSpan = 3
        G2.HorizontalAlign = HorizontalAlign.Center
        G2.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;EMP NAME&nbsp;&nbsp;</font></b>"
        field.Controls.Add(G2)

        f2.ColumnSpan = 3
        f2.HorizontalAlign = HorizontalAlign.Center
        f2.Text = "<b><font size=2>&nbsp;&nbsp;&nbsp;REQUESTED DATE&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 1
        f3.HorizontalAlign = HorizontalAlign.Center
        f3.Text = "<b><font size=2>&nbsp;&nbsp;DISTRICT&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 1
        f4.HorizontalAlign = HorizontalAlign.Center
        f4.Text = "<b><font size=2>&nbsp;&nbsp;FROM&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Center
        f5.Text = "<b><font size=2>&nbsp;&nbsp;TO&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 1
        f6.HorizontalAlign = HorizontalAlign.Center
        f6.Text = "<b><font size=2>&nbsp;&nbsp;FIRM&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f6)

        f7.ColumnSpan = 1
        f7.HorizontalAlign = HorizontalAlign.Center
        f7.Text = "<b><font size=2>&nbsp;&nbsp;KM&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f7)

        f8.ColumnSpan = 1
        f8.HorizontalAlign = HorizontalAlign.Center
        f8.Text = "<b><font size=2>&nbsp;&nbsp;RATE&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f8)

        f9.ColumnSpan = 1
        f9.HorizontalAlign = HorizontalAlign.Center
        f9.Text = "<b><font size=2>&nbsp;&nbsp;FARE&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f9)

        f10.ColumnSpan = 1
        f10.HorizontalAlign = HorizontalAlign.Center
        f10.Text = "<b><font size=2>&nbsp;&nbsp;BATTA&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f10)

        f11.ColumnSpan = 1
        f11.HorizontalAlign = HorizontalAlign.Center
        f11.Text = "<b><font size=2>&nbsp;&nbsp;REQUESTED AMOUNT&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f11)

        f12.ColumnSpan = 1
        f12.HorizontalAlign = HorizontalAlign.Center
        f12.Text = "<b><font size=2>&nbsp;&nbsp;RECOMMENDED AMOUNT&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f12)

        f13.ColumnSpan = 1
        f13.HorizontalAlign = HorizontalAlign.Center
        f13.Text = "<b><font size=2>&nbsp;&nbsp;FINAL TA AMOUNT SANCTIONED&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f13)

        f14.ColumnSpan = 1
        f14.HorizontalAlign = HorizontalAlign.Center
        f14.Text = "<b><font size=2>&nbsp;&nbsp;REMARKS&nbsp;&nbsp;</font></b>"
        field.Controls.Add(f14)


        hotable.Controls.Add(field)

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        linecell1.ColumnSpan = 20
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        hotable.Controls.Add(line1)
        Dim dt1 As DataTable = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=75 and firm_id=99").Tables(0)
        If Session("access_id") = 33 Then
            If Request.QueryString("ecode").ToString <> "0" Then
                str = dt1.Rows(0)(0).ToString.Split("#")(0).Replace("mycode", Request.QueryString("ecode"))
                dt = oh.ExecuteDataSet(str).Tables(0)
            Else
                str = dt1.Rows(0)(0).ToString.Split("#")(2).Replace("myfrom", Request.QueryString("fdt"))
                str = str.Replace("myto", Request.QueryString("tdt"))
                dt = oh.ExecuteDataSet(str).Tables(0)
            End If
        Else
            str = dt1.Rows(0)(0).ToString.Split("#")(0).Replace("mycode", Session("user_id").ToString.Split("!")(0))
            dt = oh.ExecuteDataSet(str).Tables(0)
        End If
        Dim i As Integer = 0
        Dim c1 As Integer = 0
        Dim c2 As Integer = 0
        Dim c3 As Integer = 0
        Dim c4 As Integer = 0
        Dim c5 As Integer = 0
        If dt.Rows.Count <= 0 Then
            Dim valuew As New TableRow
            valuew.Width = 20
            'valuew.Attributes.Add("color", "red")
            Dim v1w As New TableCell
            v1w.ColumnSpan = 20
            v1w.HorizontalAlign = HorizontalAlign.Center
            v1w.Text = "<font size=4 style='color:red;'>NO RECORDS FOUND!</font>"
            valuew.Controls.Add(v1w)
            hotable.Controls.Add(valuew)
        Else
            For Each dr In dt.Rows
                If colors.Equals("#fff7ff") = True Then
                    colors = "#eef9ff"
                Else
                    colors = "#fff7ff"
                End If

                Dim value As New TableRow
                value.Width = 20
                value.Attributes.Add("bgcolor", colors)

                Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v2a, v3a As New TableCell
                i = i + 1

                v1.ColumnSpan = 1
                v1.HorizontalAlign = HorizontalAlign.Center  '"<a href=DrilldownShort.aspx?area_id=" & dr(4) & "&hw=" & dr(12) & ">
                v1.Text = "<font size=2>" & i & "</font>"
                value.Controls.Add(v1)
                hotable.Controls.Add(value)
                '//////////////////

                v2a.ColumnSpan = 3
                v2a.HorizontalAlign = HorizontalAlign.Left 'drill down eliminated due to report not needed..norms same as actual..!!
                'v2.Text = "<a href=honormshortdrilldown.aspx?norm_id=" & dr(0) & "><font size=2>&nbsp;" & dr(1) & "&nbsp;&nbsp;</font></a>"
                v2a.Text = "<font size=2>&nbsp;" & dr(13) & "&nbsp;&nbsp;</font>"
                value.Controls.Add(v2a)
                hotable.Controls.Add(value)


                v3a.ColumnSpan = 1
                v3a.HorizontalAlign = HorizontalAlign.Right
                v3a.Text = "<font size=2>&nbsp;" & dr(14) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v3a)
                hotable.Controls.Add(value)
                '//////////////////

                v2.ColumnSpan = 3
                v2.HorizontalAlign = HorizontalAlign.Left 'drill down eliminated due to report not needed..norms same as actual..!!
                'v2.Text = "<a href=honormshortdrilldown.aspx?norm_id=" & dr(0) & "><font size=2>&nbsp;" & dr(1) & "&nbsp;&nbsp;</font></a>"
                v2.Text = "<font size=2>&nbsp;" & dr(0) & "&nbsp;&nbsp;</font>"
                value.Controls.Add(v2)
                hotable.Controls.Add(value)


                v3.ColumnSpan = 1
                v3.HorizontalAlign = HorizontalAlign.Right
                v3.Text = "<font size=2>&nbsp;" & dr(1) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v3)
                hotable.Controls.Add(value)


                v4.ColumnSpan = 1
                v4.HorizontalAlign = HorizontalAlign.Right
                v4.Text = "<font size=2>&nbsp;" & dr(2) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v4)
                hotable.Controls.Add(value)
                'c2 += dr(4)

                v5.ColumnSpan = 1
                v5.HorizontalAlign = HorizontalAlign.Right
                v5.Text = "<font size=2>&nbsp;" & dr(3) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v5)
                hotable.Controls.Add(value)
                'c3 += dr(5)

                v6.ColumnSpan = 1
                v6.HorizontalAlign = HorizontalAlign.Right
                v6.Text = "<font size=2>&nbsp;" & dr(4) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v6)
                hotable.Controls.Add(value)

                v7.ColumnSpan = 1
                v7.HorizontalAlign = HorizontalAlign.Right
                v7.Text = "<font size=2>&nbsp;" & dr(5) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v7)
                hotable.Controls.Add(value)

                v8.ColumnSpan = 1
                v8.HorizontalAlign = HorizontalAlign.Right
                v8.Text = "<font size=2>&nbsp;" & dr(6) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v8)
                hotable.Controls.Add(value)

                v9.ColumnSpan = 1
                v9.HorizontalAlign = HorizontalAlign.Right
                v9.Text = "<font size=2>&nbsp;" & dr(7) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v9)
                hotable.Controls.Add(value)

                v10.ColumnSpan = 1
                v10.HorizontalAlign = HorizontalAlign.Right
                v10.Text = "<font size=2>&nbsp;" & dr(8) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v10)
                hotable.Controls.Add(value)

                v11.ColumnSpan = 1
                v11.HorizontalAlign = HorizontalAlign.Right
                v11.Text = "<font size=2>&nbsp;" & dr(9) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v11)
                hotable.Controls.Add(value)

                v12.ColumnSpan = 1
                v12.HorizontalAlign = HorizontalAlign.Right
                v12.Text = "<font size=2>&nbsp;" & dr(10) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v12)
                hotable.Controls.Add(value)

                v13.ColumnSpan = 1
                v13.HorizontalAlign = HorizontalAlign.Right
                v13.Text = "<font size=2>&nbsp;" & dr(11) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v13)
                hotable.Controls.Add(value)

                v14.ColumnSpan = 1
                v14.HorizontalAlign = HorizontalAlign.Right
                v14.Text = "<font size=2>&nbsp;" & dr(12) & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                value.Controls.Add(v14)
                hotable.Controls.Add(value)
                'c4 += dr(6)

            Next
        End If


        Dim line2 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 20
            linecell2.Text = "<hr>"
            line2.Controls.Add(linecell2)
            hotable.Controls.Add(line2)

            PanelHoNSS.Controls.Add(hotable)
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub btexport_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btexport.ServerClick
        Dim dt1s As DataTable = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=75 and firm_id=99").Tables(0)
        If Session("access_id") = 33 Then
            If Request.QueryString("ecode").ToString <> "0" Then
                strs = dt1s.Rows(0)(0).ToString.Split("#")(0).Replace("mycode", Request.QueryString("ecode"))
                dts = oh.ExecuteDataSet(strs).Tables(0)
            Else
                strs = dt1s.Rows(0)(0).ToString.Split("#")(2).Replace("myfrom", Request.QueryString("fdt"))
                strs = str.Replace("myto", Request.QueryString("tdt"))
                dts = oh.ExecuteDataSet(strs).Tables(0)
            End If
        Else
            strs = dt1s.Rows(0)(0).ToString.Split("#")(0).Replace("mycode", Session("user_id").ToString.Split("!")(0))
            dts = oh.ExecuteDataSet(strs).Tables(0)
        End If



        'Dim dt3 As DataTable = oh.ExecuteDataSet("select * from ta_macom_ins t,employee_master e where e.emp_code=t.emp_code").Tables(0)
        If dts.Rows.Count > 0 Then
            griv.DataSource = dts
            griv.DataBind()
            Response.ClearContent()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "TA STATUS REPORT" + " " + DateTime.Now.ToString("dd-MMMM-yyyy" + " " + "hh:mm tt") + ".xls"))
            Response.ContentType = "application/ms-excel"
            Dim sw As New System.IO.StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            griv.AllowPaging = False
            griv.HeaderRow.Style.Add("background-color", "#FFFFFF")
            For i As Integer = 0 To griv.HeaderRow.Cells.Count - 1
                griv.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
            Next
            griv.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.[End]()
        End If
    End Sub
End Class
