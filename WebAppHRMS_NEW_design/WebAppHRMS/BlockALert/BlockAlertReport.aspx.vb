Imports System.Data
Imports System.Data.OracleClient
Partial Class BlockALert_BlockAlertReport_7b62b1403635
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2, dt9 As New DataTable
    Dim dr As DataRow
    Dim str, str1 As String
    Dim BlAleTable As New Table
    Dim LoginUser() As String
    Dim Logger, BlockCount, i As Integer
    Dim colors As String = "#fff7ef"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoginUser = Me.Session("user_id").ToString.Split("!")
        Me.Logger = LoginUser(0)
        BlockCount = oh.ExecuteDataSet("select nvl(em.block_id,0) from employee_master em where em.emp_code = " & Me.Logger & "").Tables(0).Rows(0)(0)
        str = "select bm.block_id,bm.block_reason as Reason from employee_block_dtl eb,block_master_1 bm where eb.block_id = bm.block_id and eb.block_status = 1 and eb.emp_code = " & Me.Logger & " order by Reason"
        dt = oh.ExecuteDataSet(str).Tables(0)
        dt2 = oh.ExecuteDataSet("select am.alert_id,am.alert_reason as Reason from employee_alert_dtl ea,alert_master am where ea.alert_id = am.alert_id and ea.alert_status = 1 and ea.emp_code = " & Me.Logger & " order by Reason").Tables(0)
        If dt.Rows.Count > 0 Or Me.BlockCount > 0 Or Me.dt2.Rows.Count > 0 Then
            str1 = "select em.emp_code,em.emp_name,em.branch_id,br.BRANCH_NAME,dm.designation,dp.dep_name,pm.post_name from employee_master em,branch_master br,designation_master dm,post_mst pm,department_mst dp where em.branch_id = br.BRANCH_ID and em.designation_id = dm.designation_id and em.post_id = pm.post_id and em.department_id = dp.dep_id and em.emp_code = " & Me.Logger & " union select em.emp_code,em.emp_name,em.branch_id,bc.BRANCH_NAME,dm.designation,dp.dep_name,pm.post_name from employee_master em,before_completion bc,designation_master dm,post_mst pm,department_mst dp where em.branch_id = bc.old_ID and bc.branch_id is null and em.designation_id = dm.designation_id and em.post_id = pm.post_id and em.department_id = dp.dep_id and em.emp_code = " & Me.Logger & ""
            dt1 = oh.ExecuteDataSet(str1).Tables(0)

            BlAleTable.Attributes.Add("width", "100%")

            Dim header As New TableRow
            header.BackColor = Drawing.Color.Gold
            header.ForeColor = Drawing.Color.Red
            header.Width = 12
            Dim headercell As New TableCell
            headercell.ColumnSpan = 12
            headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
            headercell.HorizontalAlign = HorizontalAlign.Center
            header.Controls.Add(headercell)
            BlAleTable.Controls.Add(header)

            Dim sheader As New TableRow
            sheader.Width = 12
            sheader.BackColor = Drawing.Color.LightGray
            Dim sheadercell1 As New TableCell
            sheadercell1.ColumnSpan = 12
            sheadercell1.HorizontalAlign = HorizontalAlign.Center
            sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
            sheader.Controls.Add(sheadercell1)
            BlAleTable.Controls.Add(sheader)

            Dim tt As New TableRow
            'tt.BackColor = Drawing.Color.LightSkyBlue
            tt.Width = 12
            Dim tt1 As New TableCell
            tt1.ColumnSpan = 12
            tt1.HorizontalAlign = HorizontalAlign.Center
            tt1.Text = "<b><font size=3>My Punching Blocks and Alerts Page</font></b>"
            tt.Controls.Add(tt1)
            BlAleTable.Controls.Add(tt)

            Dim subh As New TableRow
            Dim subcell1 As New TableCell
            Dim subcell2 As New TableCell
            Dim subcell3 As New TableCell
            subh.Width = 12
            subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
            subcell1.ColumnSpan = 3
            subcell1.HorizontalAlign = HorizontalAlign.Left
            subh.Controls.Add(subcell1)

            subcell2.ColumnSpan = 6
            subcell2.HorizontalAlign = HorizontalAlign.Center
            subcell2.Text = " "
            subh.Controls.Add(subcell2)

            subcell3.ColumnSpan = 3
            subcell3.HorizontalAlign = HorizontalAlign.Right
            subcell3.Text = "<b><font size=2>Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
            'subcell3.Text = "<font size=2><b><div id= txt align= right></div></b></font></div>"
            subh.Controls.Add(subcell3)
            BlAleTable.Controls.Add(subh)

            Dim line As New TableRow
            Dim linecell As New TableCell
            linecell.ColumnSpan = 12
            linecell.Text = "<hr>"
            line.Controls.Add(linecell)
            BlAleTable.Controls.Add(line)

            Dim FirstRow As New TableRow
            FirstRow.Width = 12
            Dim fr1, fr2, fr3, fr4 As New TableCell

            fr1.ColumnSpan = 2
            fr1.HorizontalAlign = HorizontalAlign.Left
            fr1.Text = "<b><font size=2>EmpCode&nbsp;</font></b>"  'My&nbsp;
            FirstRow.Controls.Add(fr1)

            fr2.ColumnSpan = 4
            fr2.HorizontalAlign = HorizontalAlign.Left
            fr2.Text = "<b><font size=2>" & dt1.Rows(0)(0) & "&nbsp;</font></b>"
            FirstRow.Controls.Add(fr2)

            fr3.ColumnSpan = 2
            fr3.HorizontalAlign = HorizontalAlign.Left
            fr3.Text = "<b><font size=2>Emp&nbsp;Name&nbsp;</font></b>"
            FirstRow.Controls.Add(fr3)

            fr4.ColumnSpan = 3
            fr4.HorizontalAlign = HorizontalAlign.Left
            fr4.Text = "<b><font size=2>" & dt1.Rows(0)(1) & "</font></b>"
            FirstRow.Controls.Add(fr4)

            BlAleTable.Controls.Add(FirstRow)

            Dim SecondRow As New TableRow
            SecondRow.Width = 12
            Dim sr1, sr2, sr3, sr4 As New TableCell

            sr1.ColumnSpan = 2
            sr1.HorizontalAlign = HorizontalAlign.Left
            sr1.Text = "<b><font size=2>Designation&nbsp;</font></b>"
            SecondRow.Controls.Add(sr1)

            sr2.ColumnSpan = 4
            sr2.HorizontalAlign = HorizontalAlign.Left
            sr2.Text = "<b><font size=2>" & dt1.Rows(0)(4) & "&nbsp;</font></b>"
            SecondRow.Controls.Add(sr2)

            sr3.ColumnSpan = 2
            sr3.HorizontalAlign = HorizontalAlign.Left
            sr3.Text = "<b><font size=2>Branch&nbsp;Name&nbsp;</font></b>"
            SecondRow.Controls.Add(sr3)

            sr4.ColumnSpan = 3
            sr4.HorizontalAlign = HorizontalAlign.Left
            sr4.Text = "<b><font size=2>" & dt1.Rows(0)(3) & "</font></b>"
            SecondRow.Controls.Add(sr4)

            BlAleTable.Controls.Add(SecondRow)

            Dim ThirdRow As New TableRow
            ThirdRow.Width = 12
            Dim tr1, tr2, tr3, tr4 As New TableCell

            tr1.ColumnSpan = 2
            tr1.HorizontalAlign = HorizontalAlign.Left
            tr1.Text = "<b><font size=2>Department&nbsp;</font></b>"
            ThirdRow.Controls.Add(tr1)

            tr2.ColumnSpan = 4
            tr2.HorizontalAlign = HorizontalAlign.Left
            tr2.Text = "<b><font size=2>" & dt1.Rows(0)(5) & "&nbsp;</font></b>"
            ThirdRow.Controls.Add(tr2)

            tr3.ColumnSpan = 2
            tr3.HorizontalAlign = HorizontalAlign.Left
            tr3.Text = "<b><font size=2>Post&nbsp;</font></b>"
            ThirdRow.Controls.Add(tr3)

            tr4.ColumnSpan = 3
            tr4.HorizontalAlign = HorizontalAlign.Left
            tr4.Text = "<b><font size=2>" & dt1.Rows(0)(6) & "</font></b>"
            ThirdRow.Controls.Add(tr4)

            BlAleTable.Controls.Add(ThirdRow)

            Dim line2 As New TableRow
            Dim linecell2 As New TableCell
            linecell2.ColumnSpan = 12
            linecell2.Text = "<hr>"
            line2.Controls.Add(linecell2)
            BlAleTable.Controls.Add(line2)

            If Me.BlockCount > 0 Then
                Dim Risk1 As New TableRow
                Risk1.Width = 12
                Dim r1 As New TableCell
                r1.ColumnSpan = 12
                r1.HorizontalAlign = HorizontalAlign.Left
                r1.ForeColor = Drawing.Color.Red
                r1.Text = "<b><font size=3>&nbsp;TOP&nbsp;PRIORITY&nbsp;BLOCKS&nbsp;PENDING:</font></b>"
                Risk1.Controls.Add(r1)
                BlAleTable.Controls.Add(Risk1)
                If Me.BlockCount = 1 Then '1
                    CashEntryBlock()
                ElseIf Me.BlockCount = 2 Then ' 2
                    GoldEntryBlock()
                ElseIf Me.BlockCount = 4 Then ' 4
                    KeyBlock()
                ElseIf Me.BlockCount = 3 Then '1+2
                    CashEntryBlock()
                    GoldEntryBlock()
                ElseIf Me.BlockCount = 6 Then  ' 2+4
                    GoldEntryBlock()
                    KeyBlock()
                ElseIf Me.BlockCount = 5 Then  ' 1+4
                    CashEntryBlock()
                    KeyBlock()
                ElseIf Me.BlockCount = 7 Then  ' 1+2+4
                    CashEntryBlock()
                    GoldEntryBlock()
                    KeyBlock()
                End If
                Dim line4 As New TableRow
                Dim linecell4 As New TableCell
                linecell4.ColumnSpan = 12
                linecell4.Text = "<hr>"
                line4.Controls.Add(linecell4)
                BlAleTable.Controls.Add(line4)
            End If
            If dt.Rows.Count > 0 Then
                Dim Risk2 As New TableRow
                Risk2.Width = 12
                Dim r2 As New TableCell
                r2.ColumnSpan = 12
                r2.HorizontalAlign = HorizontalAlign.Left
                r2.ForeColor = Drawing.Color.Orange
                r2.Text = "<b><font size=3>&nbsp;LOW&nbsp;PRIORITY&nbsp;BLOCKS&nbsp;PENDING:</font></b>"
                Risk2.Controls.Add(r2)
                BlAleTable.Controls.Add(Risk2)

                For Each dr In dt.Rows
                    If dr(0) = 209 Then
                        dt9 = oh.ExecuteDataSet("select a.s_msg from hrm_punching_block a  where a.emp_code=" & Me.Logger & "").Tables(0)
                        Dim value As New TableRow
                        value.Width = 12
                        Dim v1 As New TableCell
                        v1.ColumnSpan = 12
                        v1.HorizontalAlign = HorizontalAlign.Left
                        v1.Text = "<b><font size=2>&nbsp;&nbsp;" & dt9.Rows(0)(0) & "</font></b>"
                        value.Controls.Add(v1)
                        BlAleTable.Controls.Add(value)
                    Else
                        Dim value As New TableRow
                        value.Width = 12
                        Dim v1 As New TableCell
                        v1.ColumnSpan = 12
                        v1.HorizontalAlign = HorizontalAlign.Left
                        v1.Text = "<b><font size=2>&nbsp;&nbsp;" & dr(1) & "</font></b>"
                        value.Controls.Add(v1)
                        BlAleTable.Controls.Add(value)
                    End If
                    
                Next
                Dim line5 As New TableRow
                Dim linecell5 As New TableCell
                linecell5.ColumnSpan = 12
                linecell5.Text = "<hr>"
                line5.Controls.Add(linecell5)
                BlAleTable.Controls.Add(line5)
            End If
            If dt2.Rows.Count > 0 Then
                Dim Risk3 As New TableRow
                Risk3.Width = 12
                Dim r3 As New TableCell
                r3.ColumnSpan = 12
                r3.HorizontalAlign = HorizontalAlign.Left
                r3.ForeColor = Drawing.Color.Green
                r3.Text = "<b><font size=3>&nbsp;WORK&nbsp;ALERTS&nbsp;TODAY&nbsp;:</font></b>"
                Risk3.Controls.Add(r3)
                BlAleTable.Controls.Add(Risk3)

                Dim Risk4 As New TableRow
                Risk4.Width = 12
                Dim r4 As New TableCell
                r4.ColumnSpan = 12
                r4.HorizontalAlign = HorizontalAlign.Left
                r4.ForeColor = Drawing.Color.Green
                r4.Text = "<b><font size=1>&nbsp;&nbsp;(Dear Employee, Please note that Below Details only Alerts..Not Block Your Punching Today..!!&nbsp;If you already done this Work,then No Problem..!!)</font></b>"
                Risk4.Controls.Add(r4)
                BlAleTable.Controls.Add(Risk4)

                For Each dr In dt2.Rows
                    Dim Avalue As New TableRow
                    Avalue.Width = 12
                    Dim v2 As New TableCell
                    v2.ColumnSpan = 12
                    v2.HorizontalAlign = HorizontalAlign.Left
                    v2.Text = "<b><font size=2>&nbsp;&nbsp;" & dr(1) & "</font></b>"
                    Avalue.Controls.Add(v2)
                    BlAleTable.Controls.Add(Avalue)
                Next
                Dim line5 As New TableRow
                Dim linecell5 As New TableCell
                linecell5.ColumnSpan = 12
                linecell5.Text = "<hr>"
                line5.Controls.Add(linecell5)
                BlAleTable.Controls.Add(line5)
            End If
        Else
            Dim warn As New TableRow
            warn.Width = 12
            Dim w1 As New TableCell
            w1.ColumnSpan = 12
            w1.HorizontalAlign = HorizontalAlign.Center
            w1.Text = "<b><font size=2>You have no punch blocks or alerts today...!!</font></b>"
            warn.Controls.Add(w1)
            BlAleTable.Controls.Add(warn)
        End If
            Me.panelPunchReport.Controls.Add(BlAleTable)
    End Sub
    Public Function KeyBlock()   ' BlockID = 4
        Dim KeyRow As New TableRow
        KeyRow.Attributes.Add("bgcolor", colors)
        KeyRow.Width = 12
        Dim k1 As New TableCell
        k1.ColumnSpan = 12
        k1.HorizontalAlign = HorizontalAlign.Left
        k1.Text = "<b><font size=2>&nbsp;&nbsp;KEY PUNCHING PENDING</font></b>"
        KeyRow.Controls.Add(k1)
        BlAleTable.Controls.Add(KeyRow)
    End Function
    Public Function CashEntryBlock()  ' BlockID = 1
        Dim CshRow As New TableRow
        CshRow.Attributes.Add("bgcolor", colors)
        CshRow.Width = 12
        Dim c1 As New TableCell
        c1.ColumnSpan = 12
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "<b><font size=2>&nbsp;&nbsp;CASH POSITION ENTRY PENDING</font></b>"
        CshRow.Controls.Add(c1)
        BlAleTable.Controls.Add(CshRow)
    End Function
    Public Function GoldEntryBlock()  ' BlockID = 2
        Dim GldRow As New TableRow
        GldRow.Attributes.Add("bgcolor", colors)
        GldRow.Width = 12
        Dim g1 As New TableCell
        g1.ColumnSpan = 12
        g1.HorizontalAlign = HorizontalAlign.Left
        g1.Text = "<b><font size=2>&nbsp;&nbsp;GOLD ENTRY CONFIRMATION PENDING</font></b>"
        GldRow.Controls.Add(g1)
        BlAleTable.Controls.Add(GldRow)
    End Function
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    'If dt.Rows.Count > 0 Then
    'Dim Head As String = ""
    '            Me.i = 0
    '            For Each dr In dt.Rows
    '                If Head = "" Then
    'Dim BHead As New TableRow
    '                    BHead.Width = 12
    'Dim BH1 As New TableCell
    '                    BH1.ColumnSpan = 12
    '                    BH1.HorizontalAlign = HorizontalAlign.Left
    '                    BH1.Text = "<b><font size=2>My Other Punch Blocking Works Pending</font></b>"
    '                    BHead.Controls.Add(BH1)
    '                    BlAleTable.Controls.Add(BHead)
    '                    Head = "1"
    '                End If
    '                If dr(0) = 2 And Head = "1" Then
    '                    i = 0
    'Dim BHead As New TableRow
    '                    BHead.Width = 12
    'Dim BH1 As New TableCell
    '                    BH1.ColumnSpan = 12
    '                    BH1.HorizontalAlign = HorizontalAlign.Left
    '                    BH1.Text = "<b><font size=2>Alerts Remembering My Works : This Will not Block Your Punching..Please Note..!!</font></b>"
    '                    BHead.Controls.Add(BH1)
    '                    BlAleTable.Controls.Add(BHead)
    '                    Head = "2"
    '                End If
    '                i += 1
    'Dim value As New TableRow
    '                value.Width = 12
    '                value.Attributes.Add("bgcolor", colors)
    'Dim v1 As New TableCell

    '                v1.ColumnSpan = 12
    '                v1.HorizontalAlign = HorizontalAlign.Left
    '                v1.Text = "<b><font size=2>" & Me.i & ".&nbsp;&nbsp;</font></b><font size=2>" & dr(2) & "&nbsp;</font>"
    '                value.Controls.Add(v1)
    '                BlAleTable.Controls.Add(value)
    '            Next
    '        Else
    'Dim PunOthR As New TableRow
    'Dim PunCel As New TableCell
    '            PunCel.ColumnSpan = 12
    '            PunCel.Text = "<b><font size=2>No Other Punch Blocks Found..!!</font></b>"
    '            PunOthR.Controls.Add(PunCel)
    '            BlAleTable.Controls.Add(PunOthR)
    '        End If
    'Dim line3 As New TableRow
    'Dim linecell3 As New TableCell
    '        linecell3.ColumnSpan = 12
    '        linecell3.Text = "<hr>"
    '        line3.Controls.Add(linecell3)
    '        BlAleTable.Controls.Add(line3)
End Class
