Imports System.Data
Imports System.Data.OracleClient
Partial Class BlockALert_HighRiskPendingRpt_f667e4fe7420
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim PunTable As New Table
    Dim i As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Label1.Text = ""
            str = "select bm.branch_id,bm.branch_name,eb.emp_code,em.emp_name,pm.post_name,Case when eb.block_id = 7 then 'Failed to Enter Cash Position,Gold Confirmation and to do Key Punching' When eb.block_id = 3 then 'Failed to Enter Cash Position and Gold Confirmation' when eb.block_id = 1 then 'Failed to Enter Cash Position' when eb.block_id = 2 then 'Failed to Enter Gold Confirmation' when eb.block_id = 4 then 'Failed to do Key Punching' when eb.block_id = 5 then 'Failed to Enter Cash Position and to do Key Punching' when eb.block_id = 6 then 'Failed to Enter Gold Confirmation and to do Key Punching' else 'Unrecognised Status' End as Block_Status,case when em.status_id = 1 then 'LIVE' when em.status_id = 3 then 'RESIGNED' when em.status_id = 4 then 'SUSPENDED' when em.status_id = 6 then 'LONG LEAVE' when em.status_id = 10 then 'MATERNITY LEAVE' when em.status_id = 5 and ed.new_empcode is null then 'TERMINATED' when em.status_id = 5 and ed.new_empcode is not null then 'REGULARISED' when em.status_id = 9 and ed.new_empcode is not null then 'REGULARISED' end as Emp_Status from employee_master em,employ_transfer_dtl et,employee_main_block_his eb,branch_master bm,post_mst pm,employee_master_dtl ed where em.emp_code = et.emp_code and em.emp_code = eb.emp_code and em.emp_code = ed.emp_code and et.branch_id = bm.branch_id and et.post_id = pm.post_id and to_date(eb.block_date) = to_date('" & Me.Request.QueryString("SelDate") & "') and et.status_id = 8 and ((to_date('" & Me.Request.QueryString("SelDate") & "') between to_date(et.from_dt) and to_date(et.to_dt)) or (to_date('" & Me.Request.QueryString("SelDate") & "') >= to_date(et.from_dt) and et.to_dt is Null)) and et.branch_id > 0 and et.post_id in (1,10,198) order by branch_name"
            dt = oh.ExecuteDataSet(str).Tables(0)
            If dt.Rows.Count > 0 Then
                PunTable.Attributes.Add("width", "100%")

                Dim header As New TableRow
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                header.Width = 8
                Dim headercell As New TableCell
                headercell.ColumnSpan = 8
                headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
                headercell.HorizontalAlign = HorizontalAlign.Center
                header.Controls.Add(headercell)
                PunTable.Controls.Add(header)

                Dim sheader As New TableRow
                sheader.Width = 8
                sheader.BackColor = Drawing.Color.LightGray
                Dim sheadercell1 As New TableCell
                sheadercell1.ColumnSpan = 8
                sheadercell1.HorizontalAlign = HorizontalAlign.Center
                sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
                sheader.Controls.Add(sheadercell1)
                PunTable.Controls.Add(sheader)

                Dim tt As New TableRow
                'tt.BackColor = Drawing.Color.LightSkyBlue
                tt.Width = 8
                Dim tt1 As New TableCell
                tt1.ColumnSpan = 8
                tt1.HorizontalAlign = HorizontalAlign.Center
                tt1.Text = "<b><font size=3>High Risk Not Updated Details of " & Me.Request.QueryString("SelDate") & "</font></b>"
                tt.Controls.Add(tt1)
                PunTable.Controls.Add(tt)

                Dim subh As New TableRow
                Dim subcell1 As New TableCell
                Dim subcell2 As New TableCell
                Dim subcell3 As New TableCell
                subh.Width = 8
                subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
                subcell1.ColumnSpan = 2
                subcell1.HorizontalAlign = HorizontalAlign.Left
                subh.Controls.Add(subcell1)

                subcell2.ColumnSpan = 4
                subcell2.HorizontalAlign = HorizontalAlign.Center
                subcell2.Text = " "
                subh.Controls.Add(subcell2)

                subcell3.ColumnSpan = 2
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
                'subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
                subh.Controls.Add(subcell3)
                PunTable.Controls.Add(subh)

                Dim line As New TableRow
                Dim linecell As New TableCell
                linecell.ColumnSpan = 8
                linecell.Text = "<hr>"
                line.Controls.Add(linecell)
                PunTable.Controls.Add(line)

                '------------------
                Dim colors As String
                colors = "#fff7ef"
                '-----------------

                Dim field As New TableRow
                field.Width = 8
                field.Attributes.Add("bgcolor", colors)
                Dim f1, f2, f3, f4, f5, f6, f7, f8 As New TableCell

                f1.ColumnSpan = 1
                f1.HorizontalAlign = HorizontalAlign.Center
                f1.Text = "<b><font size=2>Si&nbsp;No&nbsp;</font></b>"
                field.Controls.Add(f1)

                f2.ColumnSpan = 1
                f2.HorizontalAlign = HorizontalAlign.Center
                f2.Text = "<b><font size=2>Br.&nbsp;ID&nbsp;</font></b>"
                field.Controls.Add(f2)

                f3.ColumnSpan = 1
                f3.HorizontalAlign = HorizontalAlign.Left
                f3.Text = "<b><font size=2>Branch&nbsp;Name&nbsp;</font></b>"
                field.Controls.Add(f3)

                f4.ColumnSpan = 1
                f4.HorizontalAlign = HorizontalAlign.Center
                f4.Text = "<b><font size=2>Emp&nbsp;Code&nbsp;</font></b>"
                field.Controls.Add(f4)

                f5.ColumnSpan = 1
                f5.HorizontalAlign = HorizontalAlign.Left
                f5.Text = "<b><font size=2>Emp&nbsp;Name&nbsp;</font></b>"
                field.Controls.Add(f5)

                f8.ColumnSpan = 1
                f8.HorizontalAlign = HorizontalAlign.Left
                f8.Text = "<b><font size=2>Post&nbsp;Name&nbsp;</font></b>"
                field.Controls.Add(f8)

                f6.ColumnSpan = 1
                f6.HorizontalAlign = HorizontalAlign.Left
                f6.Text = "<b><font size=2>High&nbsp;Risk&nbsp;Blocks&nbsp;</font></b>"
                field.Controls.Add(f6)

                f7.ColumnSpan = 1
                f7.HorizontalAlign = HorizontalAlign.Left
                f7.Text = "<b><font size=2>Emp&nbsp;Status&nbsp;</font></b>"
                field.Controls.Add(f7)

                PunTable.Controls.Add(field)

                Dim line1 As New TableRow
                Dim linecell1 As New TableCell
                linecell1.ColumnSpan = 8
                linecell1.Text = "<hr>"
                line1.Controls.Add(linecell1)
                PunTable.Controls.Add(line1)

                For Each dr In dt.Rows

                    If colors.Equals("#fff7ef") = True Then
                        colors = "#eef3ef"
                    Else
                        colors = "#fff7ef"
                    End If
                    i += 1

                    '///////////////////////////values
                    Dim value As New TableRow
                    value.Width = 8
                    value.Attributes.Add("bgcolor", colors)
                    Dim v1, v2, v3, v4, v5, v6, v7, v8 As New TableCell

                    v1.ColumnSpan = 1    'si No
                    v1.HorizontalAlign = HorizontalAlign.Center
                    v1.Text = "<font size=2>" & i & "&nbsp;</font>"
                    value.Controls.Add(v1)

                    v2.ColumnSpan = 1    'Br ID
                    v2.HorizontalAlign = HorizontalAlign.Center
                    v2.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                    value.Controls.Add(v2)

                    v3.ColumnSpan = 1   'B Name
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                    value.Controls.Add(v3)

                    v4.ColumnSpan = 1   'Emp Code
                    v4.HorizontalAlign = HorizontalAlign.Center
                    v4.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                    value.Controls.Add(v4)

                    v5.ColumnSpan = 1   'EmpName
                    v5.HorizontalAlign = HorizontalAlign.Left
                    v5.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                    value.Controls.Add(v5)


                    v6.ColumnSpan = 1   'Post
                    v6.HorizontalAlign = HorizontalAlign.Left
                    v6.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                    value.Controls.Add(v6)

                    v7.ColumnSpan = 1   'Risks
                    v7.HorizontalAlign = HorizontalAlign.Left
                    v7.ForeColor = Drawing.Color.Red
                    v7.Text = "<b><font size=2>" & dr(5) & "&nbsp;</font></b>"
                    value.Controls.Add(v7)

                    v8.ColumnSpan = 1   'Curr. Status
                    v8.HorizontalAlign = HorizontalAlign.Left
                    v8.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
                    value.Controls.Add(v8)

                    PunTable.Controls.Add(value)
                Next
                Dim linew As New TableRow
                Dim linecellw1 As New TableCell
                linecellw1.ColumnSpan = 8
                linecellw1.Text = "<hr>"
                linew.Controls.Add(linecellw1)
                PunTable.Controls.Add(linew)
            Else
                Dim warn As New TableRow
                warn.Width = 6
                Dim w1 As New TableCell
                w1.ColumnSpan = 6
                w1.HorizontalAlign = HorizontalAlign.Center
                w1.Text = "<b><font size=2>Sorry..!! No Records Found for " & Me.Request.QueryString("SelDate") & "..!!</font></b>"
                warn.Controls.Add(w1)
                PunTable.Controls.Add(warn)
            End If
            Me.pan_HighRisk.Controls.Add(PunTable)
        Catch ex As Exception
            Me.Label1.Text = ex.Message.ToString
        End Try
    End Sub
End Class
