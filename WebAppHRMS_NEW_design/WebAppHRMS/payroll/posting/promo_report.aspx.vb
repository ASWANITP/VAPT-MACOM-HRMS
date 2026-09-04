Imports System.Data
Imports System.Data.OracleClient
Partial Class promotiondetails_promotion_display_report_98a695785275
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim sql As String
    Dim PromTable As New Table
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("EmpCode") <> "" Then
            sql = "select t.from_dt,t.to_dt,case when t.designation_id is Null then '-----' else d.designation end as des,nvl(t.basic_pay, 0),case when to_date(t.to_dt) is null then to_date(sysdate) - to_date(t.from_dt) + 1 else (to_date(t.to_dt) - to_date(t.from_dt) + 1) end as days,decode(t.status_id,1,'JOINING',7,'PROMOTION',11,'INCREMENT',4,'SUSPENSION') as status from employ_promotion_dtl t left outer join designation_master d on (t.designation_id = d.designation_id) where t.emp_code = " & Request.QueryString("EmpCode") & " order by from_dt, status"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim empName As String = oh.ExecuteDataSet("select emp_name from employee_master where emp_code = " & Me.Request.QueryString("EmpCode")).Tables(0).Rows(0)(0)
                PromTable.Attributes.Add("width", "100%")
                PromTable.Attributes.Add("align", "center")

                Dim header As New TableRow
                header.Width = 6
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                Dim headercell As New TableCell
                headercell.ColumnSpan = 6
                headercell.Text = "MANAPPURAM FINANCE LIMITED</font></b>"
                headercell.HorizontalAlign = HorizontalAlign.Center
                header.Controls.Add(headercell)
                PromTable.Controls.Add(header)

                Dim sheader As New TableRow
                sheader.BackColor = Drawing.Color.LightGray
                Dim sheadercell1 As New TableCell
                sheadercell1.ColumnSpan = 6
                sheadercell1.HorizontalAlign = HorizontalAlign.Center
                sheadercell1.Text = "<font size=2 ><b>A.O Valapad Thrissur</b></font>"
                sheader.Controls.Add(sheadercell1)
                PromTable.Controls.Add(sheader)

                Dim tt As New TableRow
                tt.BackColor = Drawing.Color.LightSkyBlue
                tt.Width = 6
                Dim tt1 As New TableCell
                tt1.ColumnSpan = 6
                tt1.HorizontalAlign = HorizontalAlign.Center
                tt1.Text = "<b><font size=2>Promotion Details of " & Me.Request.QueryString("EmpCode") & " : " & empName & " </font></b>"
                tt.Controls.Add(tt1)
                PromTable.Controls.Add(tt)

                Dim subh As New TableRow
                Dim subcell1 As New TableCell
                Dim subcell3 As New TableCell
                subh.Width = 6

                subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd-MMM-yyyy") & "</font></b>"
                subcell1.ColumnSpan = 3
                subcell1.HorizontalAlign = HorizontalAlign.Left
                subh.Controls.Add(subcell1)

                subcell3.ColumnSpan = 3
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
                subcell3.HorizontalAlign = HorizontalAlign.Right
                subh.Controls.Add(subcell3)

                PromTable.Controls.Add(subh)

                Dim line As New TableRow
                Dim linecell As New TableCell
                linecell.ColumnSpan = 6
                linecell.Text = "<hr>"
                line.Controls.Add(linecell)
                PromTable.Controls.Add(line)

                Dim row2 As New TableRow
                row2.Width = 6
                Dim r1, r2, r3, r5, r6, r7 As New TableCell

                r1.ColumnSpan = 1
                r1.HorizontalAlign = HorizontalAlign.Center
                r1.Text = "<b><font size=2>From&nbsp;Date&nbsp;</font></b>"
                row2.Controls.Add(r1)

                r2.ColumnSpan = 1
                r2.HorizontalAlign = HorizontalAlign.Center
                r2.Text = "<b><font size=2>To&nbsp;Date&nbsp;</font></b>"
                row2.Controls.Add(r2)

                r3.ColumnSpan = 1
                r3.HorizontalAlign = HorizontalAlign.Left
                r3.Text = "<b><font size=2>Designation&nbsp;</font></b>"
                row2.Controls.Add(r3)

                r5.ColumnSpan = 1
                r5.HorizontalAlign = HorizontalAlign.Center
                r5.Text = "<b><font size=2>Basic&nbsp;Pay&nbsp;</font></b>"
                row2.Controls.Add(r5)

                r6.ColumnSpan = 1
                r6.HorizontalAlign = HorizontalAlign.Left
                r6.Text = "<b><font size=2>Work&nbsp;Days&nbsp;</font></b>"
                row2.Controls.Add(r6)

                r7.ColumnSpan = 1
                r7.HorizontalAlign = HorizontalAlign.Left
                r7.Text = "<b><font size=2>Status</font></b>"
                row2.Controls.Add(r7)

                PromTable.Controls.Add(row2)

                Dim lineu As New TableRow
                Dim linecellu As New TableCell
                linecellu.ColumnSpan = 6
                linecellu.Text = "<hr>"
                lineu.Controls.Add(linecellu)
                PromTable.Controls.Add(lineu)

                For Each dr In dt.Rows

                    Dim value As New TableRow
                    value.Width = 6
                    Dim v1, v2, v3, v4, v5, v6 As New TableCell

                    v1.ColumnSpan = 1
                    v1.HorizontalAlign = HorizontalAlign.Center
                    v1.Text = "<font size=2>" & Format(dr(0), "dd-MMM-yyyy") & "&nbsp;</font></b>" '"<b><font size=2>Employee&nbsp;Code&nbsp;</font></b>"
                    value.Controls.Add(v1)

                    v2.ColumnSpan = 1
                    v2.HorizontalAlign = HorizontalAlign.Center
                    If IsDBNull(dr(1)) Then
                        v2.Text = "<font size=2>---&nbsp;</font></b>"
                    Else
                        v2.Text = "<font size=2>" & Format(dr(1), "dd-MMM-yyyy") & "&nbsp;</font></b>"
                    End If
                    value.Controls.Add(v2)

                    v3.ColumnSpan = 1
                    v3.HorizontalAlign = HorizontalAlign.Left
                    v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font></b>"
                    value.Controls.Add(v3)

                    v4.ColumnSpan = 1
                    v4.HorizontalAlign = HorizontalAlign.Right
                    v4.Text = "<font size=2>" & FormatNumber(dr(3), 2) & "&nbsp;</font></b>"
                    value.Controls.Add(v4)

                    v5.ColumnSpan = 1
                    v5.HorizontalAlign = HorizontalAlign.Right
                    v5.Text = "<font size=2>" & dr(4) & "&nbsp;</font></b>" 'lDays
                    value.Controls.Add(v5)

                    v6.ColumnSpan = 1
                    v6.HorizontalAlign = HorizontalAlign.Left
                    v6.Text = "<font size=2>" & dr(5) & "&nbsp;</font></b>"
                    value.Controls.Add(v6)

                    PromTable.Controls.Add(value)
                Next

                Dim line4 As New TableRow
                Dim linecell4 As New TableCell
                linecell4.ColumnSpan = 6
                linecell4.Text = "<hr>"
                line4.Controls.Add(linecell4)
                PromTable.Controls.Add(line4)

            Else
                Dim warn As New TableRow
                warn.Width = 7
                Dim w1 As New TableCell
                w1.ColumnSpan = 7
                w1.Text = "<font size=2><b> No Data Found For this Employee..!!</b></font>"
                warn.Controls.Add(w1)
                PromTable.Controls.Add(warn)
            End If
        Else
            Dim warna As New TableRow
            warna.Width = 6
            Dim wa1 As New TableCell
            wa1.ColumnSpan = 6
            wa1.Text = "<font size=2><b> Session Gone..Please Login Agail and retry..!!</b></font>"
            warna.Controls.Add(wa1)
            PromTable.Controls.Add(warna)
        End If

        Me.Panel1.Controls.Add(PromTable)
    End Sub
End Class
