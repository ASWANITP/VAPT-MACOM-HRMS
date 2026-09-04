Imports System.Data
Imports System.Data.OracleClient
Partial Class Fixed_TA_New_fixed_ta_insded_013c536f4038
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str, sql As String
    Dim FxTAInsTable As New Table
    Dim i As Integer = 0
    Dim genCnt As Integer = 0
    Dim LifeCnt As Integer = 0
    Dim MingenCnt As Integer = 0
    Dim MinLifeCnt As Integer = 0
    Dim strdet() As String
    Dim ARBRPOSTId As String
    Dim postID As Integer = 0
    Dim AreaID As Integer = 0
    Dim BranchID As Integer = 0
    Dim dedNo As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim lastDay As String = oh.ExecuteDataSet("select to_char(last_day(min(a.from_dt))) from hr_fixed_ta a").Tables(0).Rows(0)(0)
            Dim postCnt As Integer = oh.ExecuteDataSet("select count(*) from hr_fixed_ta a where a.emp_code = " & Me.Request.QueryString("empcode") & " and to_date('" & lastDay & "') between to_date(a.from_dt) and to_date(a.to_dt)").Tables(0).Rows(0)(0)
            If postCnt = 1 Then
                ARBRPOSTId = oh.ExecuteDataSet("select area_id||'*'||branch_id||'*'||post_id from hr_fixed_ta a where a.emp_code = " & Me.Request.QueryString("empcode") & " and to_date('" & lastDay & "') between to_date(a.from_dt) and to_date(a.to_dt)").Tables(0).Rows(0)(0)
            Else
                Dim warn1 As New TableRow
                warn1.Width = 8
                Dim w11 As New TableCell
                w11.ColumnSpan = 8
                w11.HorizontalAlign = HorizontalAlign.Center
                w11.Text = "<b><font size=2>Cannot specify..More than 1 Post in Last day..!!</font></b>"
                warn1.Controls.Add(w11)
                FxTAInsTable.Controls.Add(warn1)
                Me.pan_InsureDed.Controls.Add(FxTAInsTable)
                Exit Sub
            End If

            Me.strdet = Me.ARBRPOSTId.Split("*")
            Me.AreaID = Me.strdet(0)
            Me.BranchID = Me.strdet(1)
            Me.postID = Me.strdet(2)

            Dim empName As String = oh.ExecuteDataSet("select emp_code||' : '||emp_name from employee_master where emp_code = " & Me.Request.QueryString("empcode") & "").Tables(0).Rows(0)(0)
            If Me.postID = 198 Or Me.postID = 10 Then
                '                  0               1             2                3                            4           5                             6                                                                                                                    7       
                str = "select bm.branch_id,bm.branch_name,1 as Min_Gen_Cnt,nvl(a.gen_cnt,0) as Gen_Got,2 as Life_Min,nvl(a.life_cnt,0) as Life_Got,(case when a.gen_cnt < 1 then 1 else 0 end) + (case when a.life_cnt < 2 then 2 - a.life_cnt else 0 end) as Deduction_No,case when ((case when a.gen_cnt < 1 then 1 else 0 end) + (case when a.life_cnt < 2 then 2 - a.life_cnt else 0 end)) = 3 then '50% of TA Eligible' when ((case when a.gen_cnt < 1 then 1 else 0 end) + (case when a.life_cnt < 2 then 2 - a.life_cnt else 0 end)) = 2 then '50% of TA Eligible * 1/3' when ((case when a.gen_cnt < 1 then 1 else 0 end) + (case when a.life_cnt < 2 then 2 - a.life_cnt else 0 end)) = 1 then '50% of TA Eligible * 2/3' else '0' end as Ded_Amount from hrm_insurance_count a,branch_master bm where a.branch_id = bm.branch_id and a.branch_id = " & Me.BranchID & "  order by bm.branch_id"
            ElseIf Me.postID = 136 Or Me.postID = 197 Then
                str = "select bm.branch_id,bm.branch_name,1 as Min_Gen_Cnt,nvl(a.gen_cnt,0) as Gen_Got,2 as Life_Min,nvl(a.life_cnt,0) as Life_Got,(case when a.gen_cnt < 1 then 1 else 0 end) + (case when a.life_cnt < 2 then 2 - a.life_cnt else 0 end) as Deduction_No,'  ---' as remarks from hrm_insurance_count a,branch_master bm where a.branch_id = bm.branch_id and a.area_id = " & Me.AreaID & "  order by bm.branch_id"
            Else
                Dim warn2 As New TableRow
                warn2.Width = 8
                Dim w12 As New TableCell
                w12.ColumnSpan = 8
                w12.HorizontalAlign = HorizontalAlign.Center
                w12.Text = "<b><font size=2>You have No CIRCULAR NO. MAGRO -2085 deduction in Your TA..!!</font></b>"
                warn2.Controls.Add(w12)
                FxTAInsTable.Controls.Add(warn2)
                Me.pan_InsureDed.Controls.Add(FxTAInsTable)
                Exit Sub
            End If

            dt = oh.ExecuteDataSet(str).Tables(0)
            If dt.Rows.Count > 0 Then
                FxTAInsTable.Width = 8
                FxTAInsTable.Attributes.Add("width", "100%")

                Dim header As New TableRow
                header.BackColor = Drawing.Color.Gold
                header.ForeColor = Drawing.Color.Red
                header.Width = 8
                Dim headercell As New TableCell
                headercell.ColumnSpan = 8
                headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
                headercell.HorizontalAlign = HorizontalAlign.Center
                header.Controls.Add(headercell)
                FxTAInsTable.Controls.Add(header)

                Dim sheader As New TableRow
                sheader.Width = 8
                sheader.BackColor = Drawing.Color.LightGray
                Dim sheadercell1 As New TableCell
                sheadercell1.ColumnSpan = 8
                sheadercell1.HorizontalAlign = HorizontalAlign.Center
                sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
                sheader.Controls.Add(sheadercell1)
                FxTAInsTable.Controls.Add(sheader)

                Dim tt As New TableRow
                'tt.BackColor = Drawing.Color.LightSkyBlue
                tt.Width = 8
                Dim tt1 As New TableCell
                tt1.ColumnSpan = 8
                tt1.HorizontalAlign = HorizontalAlign.Center
                tt1.Text = "<b><font size=3>CIRCULAR NO. MAGRO -2085 Ded.n details of " & empName & "</font></b>"
                tt.Controls.Add(tt1)
                FxTAInsTable.Controls.Add(tt)

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
                FxTAInsTable.Controls.Add(subh)

                Dim line As New TableRow
                Dim linecell As New TableCell
                linecell.ColumnSpan = 8
                linecell.Text = "<hr>"
                line.Controls.Add(linecell)
                FxTAInsTable.Controls.Add(line)
                '----------------
                Dim colors As String
                colors = "#fff7ef"
                '-----------------

                Dim field As New TableRow
                field.Width = 8
                field.Attributes.Add("bgcolor", colors)
                Dim f1, f2, f3, f4, f5, f6, f7, f8 As New TableCell

                f1.ColumnSpan = 1  'BranchID
                f1.HorizontalAlign = HorizontalAlign.Center
                f1.Text = "<b><font size=2>Branch&nbsp;ID&nbsp;</font></b>"
                field.Controls.Add(f1)

                f2.ColumnSpan = 1  'Bname
                f2.HorizontalAlign = HorizontalAlign.Left
                f2.Text = "<b><font size=2>Branch&nbsp;Name&nbsp;</font></b>"
                field.Controls.Add(f2)

                f3.ColumnSpan = 1 'Gen Cnt
                f3.HorizontalAlign = HorizontalAlign.Center
                f3.Text = "<b><font size=2>Minimum Gen.Insurance Count</font></b>"
                field.Controls.Add(f3)

                f4.ColumnSpan = 1 'Post
                f4.HorizontalAlign = HorizontalAlign.Center
                f4.Text = "<b><font size=2>Gen.Insurance Got</font></b>"
                field.Controls.Add(f4)

                f5.ColumnSpan = 1
                f5.HorizontalAlign = HorizontalAlign.Center
                f5.Text = "<b><font size=2>Minimum Life Insurance Count</font></b>"
                field.Controls.Add(f5)

                f6.ColumnSpan = 1
                f6.HorizontalAlign = HorizontalAlign.Center
                f6.Text = "<b><font size=2>Life Insurance got</font></b>"
                field.Controls.Add(f6)

                f7.ColumnSpan = 1
                f7.HorizontalAlign = HorizontalAlign.Center
                f7.Text = "<b><font size=2>Ded.No</font></b>"
                field.Controls.Add(f7)

                f8.ColumnSpan = 1
                f8.HorizontalAlign = HorizontalAlign.Left
                f8.Text = "<b><font size=2>Ded.Amount&nbsp;</font></b>"
                field.Controls.Add(f8)

                FxTAInsTable.Controls.Add(field)

                Dim line1 As New TableRow
                Dim linecell1 As New TableCell
                linecell1.ColumnSpan = 8
                linecell1.Text = "<hr>"
                line1.Controls.Add(linecell1)
                FxTAInsTable.Controls.Add(line1)


                For Each dr In dt.Rows

                    '///////////////////////////values
                    Dim value As New TableRow
                    value.Width = 8
                    value.Attributes.Add("bgcolor", colors)
                    Dim v1, v2, v3, v4, v5, v6, v7, v8 As New TableCell

                    v1.ColumnSpan = 1    'branchid
                    v1.HorizontalAlign = HorizontalAlign.Center
                    v1.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
                    value.Controls.Add(v1)

                    v2.ColumnSpan = 1    'Brname
                    v2.HorizontalAlign = HorizontalAlign.Left
                    v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
                    value.Controls.Add(v2)

                    v3.ColumnSpan = 1   'Min Gen Cnt
                    v3.HorizontalAlign = HorizontalAlign.Center
                    v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
                    value.Controls.Add(v3)
                    Me.MingenCnt += dr(2)

                    v4.ColumnSpan = 1   'Gen Cnt Got
                    v4.HorizontalAlign = HorizontalAlign.Center
                    v4.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
                    value.Controls.Add(v4)
                    Me.genCnt = dr(3)

                    v5.ColumnSpan = 1   'Min Life cnt
                    v5.HorizontalAlign = HorizontalAlign.Center
                    v5.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
                    value.Controls.Add(v5)
                    Me.MinLifeCnt += dr(4)


                    v6.ColumnSpan = 1   'Life cnt got
                    v6.HorizontalAlign = HorizontalAlign.Center
                    v6.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
                    value.Controls.Add(v6)
                    Me.LifeCnt += dr(5)

                    v7.ColumnSpan = 1   'Ded No
                    v7.HorizontalAlign = HorizontalAlign.Right
                    v7.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
                    value.Controls.Add(v7)
                    Me.dedNo += dr(6)
                    If dr(6) > 0 Then
                        i += 1
                    End If

                    v8.ColumnSpan = 1   'remarks
                    v8.HorizontalAlign = HorizontalAlign.Left
                    v8.Text = "<font size=2>" & dr(7) & "&nbsp;</font>"
                    value.Controls.Add(v8)

                    FxTAInsTable.Controls.Add(value)
                Next
                Dim linew As New TableRow
                Dim linecellw1 As New TableCell
                linecellw1.ColumnSpan = 9
                linecellw1.Text = "<hr>"
                linew.Controls.Add(linecellw1)
                FxTAInsTable.Controls.Add(linew)
                If Me.postID = 136 Or Me.postID = 197 Then
                    Dim Rowtow As New TableRow
                    Rowtow.Width = 8
                    Dim cel1, cel2, cel3, cel4, cel5, cel6, cel7 As New TableCell

                    cel1.ColumnSpan = 2    '
                    cel1.HorizontalAlign = HorizontalAlign.Center
                    cel1.Text = "<font size=2>Ded.Branches: " & Me.i & "&nbsp;</font>"
                    Rowtow.Controls.Add(cel1)

                    cel2.ColumnSpan = 1    '
                    cel2.HorizontalAlign = HorizontalAlign.Center
                    cel2.Text = "<font size=2>" & Me.MingenCnt & "&nbsp;</font>"
                    Rowtow.Controls.Add(cel2)


                    cel3.ColumnSpan = 1   'ldays
                    cel3.HorizontalAlign = HorizontalAlign.Center
                    cel3.Text = "<font size=2>" & Me.genCnt & "&nbsp;</font>"
                    Rowtow.Controls.Add(cel3)


                    cel4.ColumnSpan = 1   'ta Ins deduction
                    cel4.HorizontalAlign = HorizontalAlign.Center
                    cel4.Text = "<font size=2>" & Me.MinLifeCnt & "&nbsp;</font>"
                    Rowtow.Controls.Add(cel4)


                    cel5.ColumnSpan = 1   '
                    cel5.HorizontalAlign = HorizontalAlign.Right
                    cel5.Text = "<font size=2>" & Me.LifeCnt & "&nbsp;</font>"
                    Rowtow.Controls.Add(cel5)

                    cel6.ColumnSpan = 1   '
                    cel6.HorizontalAlign = HorizontalAlign.Right
                    cel6.Text = "<font size=2>" & Me.dedNo & "&nbsp;</font>"
                    Rowtow.Controls.Add(cel6)

                    cel7.ColumnSpan = 1    '
                    cel7.HorizontalAlign = HorizontalAlign.Center
                    cel7.Text = "<font size=2>50%of TA Elig. * (" & Me.dedNo & " /(" & i & " * 3))</font>"
                    Rowtow.Controls.Add(cel7)

                    FxTAInsTable.Controls.Add(Rowtow)


                    Dim linex As New TableRow
                    Dim linecellx1 As New TableCell
                    linecellx1.ColumnSpan = 8
                    linecellx1.Text = "<hr>"
                    linex.Controls.Add(linecellx1)
                    FxTAInsTable.Controls.Add(linex)
                   
                End If
                Dim linex1 As New TableRow
                Dim linecellx11 As New TableCell
                linecellx11.ColumnSpan = 8
                linecellx11.Text = "<font size=1>Please refer CIRCULAR NO. MAGRO -2085 for Deduction details </font>"
                linex1.Controls.Add(linecellx11)
                FxTAInsTable.Controls.Add(linex1)
            Else

                Dim warn As New TableRow
                warn.Width = 8
                Dim w1 As New TableCell
                w1.ColumnSpan = 8
                w1.HorizontalAlign = HorizontalAlign.Center
                w1.Text = "<b><font size=2>No Data Found..!!</font></b>"
                warn.Controls.Add(w1)
                FxTAInsTable.Controls.Add(warn)

            End If

        Catch ex As Exception
            Dim warn1 As New TableRow
            warn1.Width = 8
            Dim w11 As New TableCell
            w11.ColumnSpan = 8
            w11.HorizontalAlign = HorizontalAlign.Center
            w11.Text = "<b><font size=2>" & ex.Message & "..!!</font></b>"
            warn1.Controls.Add(w11)
            FxTAInsTable.Controls.Add(warn1)
        End Try
        Me.pan_InsureDed.Controls.Add(FxTAInsTable)
    End Sub
End Class
