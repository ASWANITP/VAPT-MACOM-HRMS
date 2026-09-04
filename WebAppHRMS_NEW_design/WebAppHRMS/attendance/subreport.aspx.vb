Imports System.Data
Imports System.Data.OracleClient
Partial Class DetailReport_subreport_b978cc2e2769
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Private Function checknull(ByVal a) As String
        If IsDBNull(a) Then
            Return ("0.00")

        Else
            Return (FormatNumber(a, 2))
        End If
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------------        0           1          2        3          4         5         6        7         8           9         10       11        12            13         14          15           16        17         18          19        20        21          22         23          24          25         26            27          
        str = "select upper(e.emp_name),nvl(t.fix_ta,0),nvl(t.act_ta,0),nvl(t.outstation,0),nvl(t.abh_ta,0),nvl(t.bh_all,0),nvl(t.bh_ta,0),nvl(t.incentive,0),nvl(t.tele_all,0),nvl(t.dist_all,0),nvl(t.hp_ta,0),nvl(t.hp_incent,0),nvl(t.ins_incent,0),nvl(t.forex_inc,0),nvl(t.glr_incent,0),nvl(t.dep_mob,0),nvl(t.bond_inc,0),nvl(t.bus_loan,0),nvl(t.pers_loan,0),nvl(t.gold_ga,0),nvl(t.manag_inc,0),nvl(t.month_inc,0),nvl(t.dep_mkt,0),nvl(t.legal_inc,0),nvl(t.civil_inc,0),nvl(t.chits_inc,0),nvl(t.other_inc,0),nvl(t.summer_inc,0),b.branch_name from ta_br t,branch_master b,employee_master e where e.emp_code=t.emp_id and b.branch_id=e.branch_id and t.emp_id=" & Request.QueryString("emp_code") & " union all select upper(e.emp_name),nvl(t.fix_ta,0),nvl(t.act_ta,0),nvl(t.outstation,0),nvl(t.abh_ta,0),nvl(t.bh_all,0),nvl(t.bh_ta,0),nvl(t.incentive,0),nvl(t.tele_all,0),nvl(t.dist_all,0),nvl(t.hp_ta,0),nvl(t.hp_incent,0),nvl(t.ins_incent,0),nvl(t.forex_inc,0),nvl(t.glr_incent,0),nvl(t.dep_mob,0),nvl(t.bond_inc,0),nvl(t.bus_loan,0),nvl(t.pers_loan,0),nvl(t.gold_ga,0),nvl(t.manag_inc,0),nvl(t.month_inc,0),nvl(t.dep_mkt,0),nvl(t.legal_inc,0),nvl(t.civil_inc,0),nvl(t.chits_inc,0),nvl(t.other_inc,0),nvl(t.summer_inc,0),bc.branch_name from ta_br t,before_completion bc,employee_master e where e.emp_code=t.emp_id and bc.old_id=e.branch_id and bc.branch_id is null and t.emp_id=" & Request.QueryString("emp_code") & ""
        dt = oh.ExecuteDataSet(str).Tables(0)
        Dim subtot As Integer = dt.Rows(0)(1) + dt.Rows(0)(2) + dt.Rows(0)(3) + dt.Rows(0)(4) + dt.Rows(0)(5) + dt.Rows(0)(6) + dt.Rows(0)(7) + dt.Rows(0)(8) + dt.Rows(0)(9) + dt.Rows(0)(10) + dt.Rows(0)(11) + dt.Rows(0)(12) + dt.Rows(0)(13) + dt.Rows(0)(14) + dt.Rows(0)(15) + dt.Rows(0)(16) + dt.Rows(0)(17) + dt.Rows(0)(18) + dt.Rows(0)(19) + dt.Rows(0)(20) + dt.Rows(0)(21) + dt.Rows(0)(22) + dt.Rows(0)(23) + dt.Rows(0)(24) + dt.Rows(0)(25) + dt.Rows(0)(26) + dt.Rows(0)(27)
        Dim subtable As New Table
        subtable.Attributes.Add("width", "100%")
        'subtable.Attributes.Add("border", 1)
        Dim header As New TableRow
        Dim headercell As New TableCell
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        headercell.ColumnSpan = 4
        headercell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headercell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headercell)
        subtable.Controls.Add(header)

        Dim sheader As New TableRow
        'sheader.BackColor = Drawing.Color.Gold
        'sheader.ForeColor = Drawing.Color.Red
        Dim sheadercell1 As New TableCell
        Dim sheadercell2 As New TableCell
        sheadercell1.ColumnSpan = 4
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        subtable.Controls.Add(sheader)

        'Dim i As Integer
        'For i = 1 To 4
        '    Dim blank As New TableRow
        '    subtable.Controls.Add(blank)
        'Next
        Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)
        Dim head As New TableRow
        head.Width = 4
        Dim hh1 As New TableCell
        hh1.ColumnSpan = 4
        hh1.Text = "<body align=center><b><font size=2.5> Employeewise TA subreport of " & s & " " & Now.Year & " </font></b></body>"
        head.Controls.Add(hh1)
        subtable.Controls.Add(head)

        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell

        subcell1.ColumnSpan = 1
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subh.Controls.Add(subcell1)
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.ColumnSpan = 2

        'subcell2.Text = "<body align=center><b><font size=2.5> Employeewise TA subreport of " & s & " " & Now.Year & " </font></b></body>"
        'subcell2.Text = "<b><font size=3>" & "Employeewise TA subreport" & "</font></b>"
        subh.Controls.Add(subcell2)
        subcell3.HorizontalAlign = HorizontalAlign.Right
       


        subcell3.Text = "<b><font size=2> Time:" & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subh.Controls.Add(subcell3)
        subtable.Controls.Add(subh)
        Dim linerowa As New TableRow
        Dim linecella As New TableCell
        linecella.ColumnSpan = 4
        linecella.HorizontalAlign = HorizontalAlign.Center
        linecella.Text = "<hr>"
        linerowa.Controls.Add(linecella)
        subtable.Controls.Add(linerowa)



        Dim empc As New TableRow
        Dim empc1, empc2 As New TableCell
        empc.Width = 4
        empc1.ColumnSpan = 2
        empc2.ColumnSpan = 2
        empc1.HorizontalAlign = HorizontalAlign.Left
        empc2.HorizontalAlign = HorizontalAlign.Left
        empc1.Text = "<b><font size=2>&nbsp;Employee&nbsp;Code&nbsp;:</font></b>"
        empc2.Text = "<font size=2>" & Request.QueryString("emp_code") & "<font>"
        empc.Controls.Add(empc1)
        empc.Controls.Add(empc2)

        subtable.Controls.Add(empc)

        Dim empn As New TableRow
        Dim empn1, empn2 As New TableCell
        empn.Width = 4
        empn1.ColumnSpan = 2
        empn2.ColumnSpan = 2
        empn1.HorizontalAlign = HorizontalAlign.Left
        empn2.HorizontalAlign = HorizontalAlign.Right
        empn1.Text = "<b><font size=2>&nbsp;Employee&nbsp;Name&nbsp;:</font></b>"
        empn2.Text = "<font size=2>" & dt.Rows(0)(0) & "<font>"
        empn.Controls.Add(empn1)
        empn.Controls.Add(empn2)
        subtable.Controls.Add(empn)


        'b.branch_name  dt.rows(0)(27)


        Dim bname As New TableRow
        Dim bname1, bname2 As New TableCell
        bname.Width = 4
        bname1.ColumnSpan = 2
        bname2.ColumnSpan = 2
        bname1.HorizontalAlign = HorizontalAlign.Left
        bname2.HorizontalAlign = HorizontalAlign.Right
        bname1.Text = "<b><font size=2>&nbsp;Branch&nbsp;Name&nbsp;:</font></b>"
        bname2.Text = "<font size=2>" & dt.Rows(0)(28) & "<font>"
        bname.Controls.Add(bname1)
        bname.Controls.Add(bname2)
        subtable.Controls.Add(bname)

        ''''''''''''''''''''''''
        Dim fixta As New TableRow
        Dim fixta1, fixta2 As New TableCell
        fixta.Width = 4
        fixta1.ColumnSpan = 2
        fixta2.ColumnSpan = 2
        fixta1.HorizontalAlign = HorizontalAlign.Left
        fixta2.HorizontalAlign = HorizontalAlign.Right
        fixta1.Text = "<b><font size=2>&nbsp;Fixed&nbsp;Travelling&nbsp;Allowances&nbsp;:</font></b>"
        fixta2.Text = "<font size=2>" & checknull(dt.Rows(0)(1)) & "<font>"
        fixta.Controls.Add(fixta1)
        fixta.Controls.Add(fixta2)

        subtable.Controls.Add(fixta)

        Dim actta As New TableRow
        Dim actta1, actta2 As New TableCell
        actta.Width = 4
        actta1.ColumnSpan = 2
        actta2.ColumnSpan = 2
        actta1.HorizontalAlign = HorizontalAlign.Left
        actta2.HorizontalAlign = HorizontalAlign.Right
        actta1.Text = "<b><font size=2>&nbsp;Actual&nbsp;Travelling&nbsp;Allowances&nbsp;:</font></b>"
        actta2.Text = "<font size=2>" & checknull(dt.Rows(0)(2)) & "<font>"
        actta.Controls.Add(actta1)
        actta.Controls.Add(actta2)

        subtable.Controls.Add(actta)

        Dim out As New TableRow
        Dim out1, out2 As New TableCell
        out.Width = 4
        out1.ColumnSpan = 2
        out2.ColumnSpan = 2
        out1.HorizontalAlign = HorizontalAlign.Left
        out2.HorizontalAlign = HorizontalAlign.Right
        out1.Text = "<b><font size=2>&nbsp;Out&nbsp;Station&nbsp;:</font></b>"
        out2.Text = "<font size=2>" & checknull(dt.Rows(0)(3)) & "<font>"
        out.Controls.Add(out1)
        out.Controls.Add(out2)

        subtable.Controls.Add(out)

        Dim abhta As New TableRow
        Dim abhta1, abhta2 As New TableCell
        abhta.Width = 4
        abhta1.ColumnSpan = 2
        abhta2.ColumnSpan = 2
        abhta1.HorizontalAlign = HorizontalAlign.Left
        abhta2.HorizontalAlign = HorizontalAlign.Right
        abhta1.Text = "<b><font size=2>&nbsp;Assistant&nbsp;Branch&nbsp;Head&nbsp;Travelling&nbsp;Allowances&nbsp;:</font></b>"
        abhta2.Text = "<font size=2>" & checknull(dt.Rows(0)(4)) & "<font>"
        abhta.Controls.Add(abhta1)
        abhta.Controls.Add(abhta2)
        subtable.Controls.Add(abhta)

        Dim bhall As New TableRow
        Dim bhall1, bhall2 As New TableCell
        bhall.Width = 4
        bhall1.ColumnSpan = 2
        bhall2.ColumnSpan = 2
        bhall1.HorizontalAlign = HorizontalAlign.Left
        bhall2.HorizontalAlign = HorizontalAlign.Right
        bhall1.Text = "<b><font size=2>&nbsp;Branch&nbsp;Head&nbsp;Allowances&nbsp;:</font></b>"
        bhall2.Text = "<font size=2>" & checknull(dt.Rows(0)(5)) & "<font>"
        bhall.Controls.Add(bhall1)
        bhall.Controls.Add(bhall2)
        subtable.Controls.Add(bhall)

        Dim bhta As New TableRow
        Dim bhta1, bhta2 As New TableCell
        bhta.Width = 4
        bhta1.ColumnSpan = 2
        bhta2.ColumnSpan = 2
        bhta1.HorizontalAlign = HorizontalAlign.Left
        bhta2.HorizontalAlign = HorizontalAlign.Right
        bhta1.Text = "<b><font size=2>&nbsp;Branch&nbsp;Head&nbsp;Travelling&nbsp;Allowances&nbsp;:</font></b>"
        bhta2.Text = "<font size=2>" & checknull(dt.Rows(0)(6)) & "<font>"
        bhta.Controls.Add(bhta1)
        bhta.Controls.Add(bhta2)
        subtable.Controls.Add(bhta)

        Dim incen As New TableRow
        Dim incen1, incen2 As New TableCell
        incen.Width = 4
        incen1.ColumnSpan = 2
        incen2.ColumnSpan = 2
        incen1.HorizontalAlign = HorizontalAlign.Left
        incen2.HorizontalAlign = HorizontalAlign.Right
        incen1.Text = "<b><font size=2>&nbsp;Incentives&nbsp;:</font></b>"
        incen2.Text = "<font size=2>" & checknull(dt.Rows(0)(7)) & "<font>"
        incen.Controls.Add(incen1)
        incen.Controls.Add(incen2)
        subtable.Controls.Add(incen)

        Dim telall As New TableRow
        Dim telall1, telall2 As New TableCell
        telall.Width = 4
        telall1.ColumnSpan = 2
        telall2.ColumnSpan = 2
        telall1.HorizontalAlign = HorizontalAlign.Left
        telall2.HorizontalAlign = HorizontalAlign.Right
        telall1.Text = "<b><font size=2>&nbsp;Telephone&nbsp;(&nbsp;Mobile&nbsp;)&nbsp;&nbsp;Allowances&nbsp:</font></b>"
        telall2.Text = "<font size=2>" & checknull(dt.Rows(0)(8)) & "<font>"
        telall.Controls.Add(telall1)
        telall.Controls.Add(telall2)
        subtable.Controls.Add(telall)

        Dim distall As New TableRow
        Dim distall1, distall2 As New TableCell
        distall.Width = 4
        distall1.ColumnSpan = 2
        distall2.ColumnSpan = 2
        distall1.HorizontalAlign = HorizontalAlign.Left
        distall2.HorizontalAlign = HorizontalAlign.Right
        distall1.Text = "<b><font size=2>&nbsp;Distance&nbsp;Allowance&nbsp;:</font></b>"
        distall2.Text = "<font size=2>" & checknull(dt.Rows(0)(9)) & "<font>"
        distall.Controls.Add(distall1)
        distall.Controls.Add(distall2)
        subtable.Controls.Add(distall)

        Dim hpta As New TableRow
        Dim hpta1, hpta2 As New TableCell
        hpta.Width = 4
        hpta1.ColumnSpan = 2
        hpta2.ColumnSpan = 2
        hpta1.HorizontalAlign = HorizontalAlign.Left
        hpta2.HorizontalAlign = HorizontalAlign.Right
        hpta1.Text = "<b><font size=2>&nbsp;HP&nbsp;TA&nbsp;:</font></b>"
        hpta2.Text = "<font size=2>" & checknull(dt.Rows(0)(10)) & "<font>"
        hpta.Controls.Add(hpta1)
        hpta.Controls.Add(hpta2)
        subtable.Controls.Add(hpta)

        Dim hpinc As New TableRow
        Dim hpinc1, hpinc2 As New TableCell
        hpinc.Width = 4
        hpinc1.ColumnSpan = 2
        hpinc2.ColumnSpan = 2
        hpinc1.HorizontalAlign = HorizontalAlign.Left
        hpinc2.HorizontalAlign = HorizontalAlign.Right
        hpinc1.Text = "<b><font size=2>&nbsp;HP&nbsp;Incentives&nbsp;:</font></b>"
        hpinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(11)) & "<font>"
        hpinc.Controls.Add(hpinc1)
        hpinc.Controls.Add(hpinc2)
        subtable.Controls.Add(hpinc)

        Dim insinc As New TableRow
        Dim insinc1, insinc2 As New TableCell
        insinc.Width = 4
        insinc1.ColumnSpan = 2
        insinc2.ColumnSpan = 2
        insinc1.HorizontalAlign = HorizontalAlign.Left
        insinc2.HorizontalAlign = HorizontalAlign.Right
        insinc1.Text = "<b><font size=2>&nbsp;Insurance&nbsp;Incentives&nbsp;:</font></b>"
        insinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(12)) & "<font>"
        insinc.Controls.Add(insinc1)
        insinc.Controls.Add(insinc2)
        subtable.Controls.Add(insinc)

        Dim forexinc As New TableRow
        Dim forexinc1, forexinc2 As New TableCell
        forexinc.Width = 4
        forexinc1.ColumnSpan = 2
        forexinc2.ColumnSpan = 2
        forexinc1.HorizontalAlign = HorizontalAlign.Left
        forexinc2.HorizontalAlign = HorizontalAlign.Right
        forexinc1.Text = "<b><font size=2>&nbsp;Forex&nbsp;Incentives&nbsp;:</font></b>"
        forexinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(13)) & "<font>"
        forexinc.Controls.Add(forexinc1)
        forexinc.Controls.Add(forexinc2)
        subtable.Controls.Add(forexinc)

        Dim glrinc As New TableRow
        Dim glrinc1, glrinc2 As New TableCell
        glrinc.Width = 4
        glrinc1.ColumnSpan = 2
        glrinc2.ColumnSpan = 2
        glrinc1.HorizontalAlign = HorizontalAlign.Left
        glrinc2.HorizontalAlign = HorizontalAlign.Right
        glrinc1.Text = "<b><font size=2>&nbsp;Gold&nbsp;Loan&nbsp;Recovery&nbsp;&nbsp;Incentives&nbsp;:</font></b>"
        glrinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(14)) & "<font>"
        glrinc.Controls.Add(glrinc1)
        glrinc.Controls.Add(glrinc2)
        subtable.Controls.Add(glrinc)


        Dim depmob As New TableRow
        Dim depmob1, depmob2 As New TableCell
        depmob.Width = 4
        depmob1.ColumnSpan = 2
        depmob2.ColumnSpan = 2
        depmob1.HorizontalAlign = HorizontalAlign.Left
        depmob2.HorizontalAlign = HorizontalAlign.Right
        depmob1.Text = "<b><font size=2>&nbsp;Deposit&nbsp;Mobilisation&nbsp;:</font></b>"
        depmob2.Text = "<font size=2>" & checknull(dt.Rows(0)(15)) & "<font>"
        depmob.Controls.Add(depmob1)
        depmob.Controls.Add(depmob2)
        subtable.Controls.Add(depmob)

        Dim bondinc As New TableRow
        Dim bondinc1, bondinc2 As New TableCell
        bondinc.Width = 4
        bondinc1.ColumnSpan = 2
        bondinc2.ColumnSpan = 2
        bondinc1.HorizontalAlign = HorizontalAlign.Left
        bondinc2.HorizontalAlign = HorizontalAlign.Right
        bondinc1.Text = "<b><font size=2>&nbsp;Bond&nbsp;Incentives&nbsp;:</font></b>"
        bondinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(16)) & "<font>"
        bondinc.Controls.Add(bondinc1)
        bondinc.Controls.Add(bondinc2)
        subtable.Controls.Add(bondinc)

        Dim busloan As New TableRow
        Dim busloan1, busloan2 As New TableCell
        busloan.Width = 4
        busloan1.ColumnSpan = 2
        busloan2.ColumnSpan = 2
        busloan1.HorizontalAlign = HorizontalAlign.Left
        busloan2.HorizontalAlign = HorizontalAlign.Right
        busloan1.Text = "<b><font size=2>&nbsp;Business&nbsp;Loan&nbsp;:</font></b>"
        busloan2.Text = "<font size=2>" & checknull(dt.Rows(0)(17)) & "<font>"
        busloan.Controls.Add(busloan1)
        busloan.Controls.Add(busloan2)
        subtable.Controls.Add(busloan)

        Dim persloan As New TableRow
        Dim persloan1, persloan2 As New TableCell
        persloan.Width = 4
        persloan1.ColumnSpan = 2
        persloan2.ColumnSpan = 2
        persloan1.HorizontalAlign = HorizontalAlign.Left
        persloan2.HorizontalAlign = HorizontalAlign.Right
        persloan1.Text = "<b><font size=2>&nbsp;Personal&nbsp;Loan&nbsp;:</font></b>"
        persloan2.Text = "<font size=2>" & checknull(dt.Rows(0)(18)) & "<font>"
        persloan.Controls.Add(persloan1)
        persloan.Controls.Add(persloan2)
        subtable.Controls.Add(persloan)

        Dim goldga As New TableRow
        Dim goldga1, goldga2 As New TableCell
        goldga.Width = 4
        goldga1.ColumnSpan = 2
        goldga2.ColumnSpan = 2
        goldga1.HorizontalAlign = HorizontalAlign.Left
        goldga2.HorizontalAlign = HorizontalAlign.Right
        goldga1.Text = "<b><font size=2>&nbsp;Gold&nbsp;General&nbsp;Administration&nbsp;Incentives&nbsp;:</font></b>"
        goldga2.Text = "<font size=2>" & checknull(dt.Rows(0)(19)) & "<font>"
        goldga.Controls.Add(goldga1)
        goldga.Controls.Add(goldga2)
        subtable.Controls.Add(goldga)

        Dim managinc As New TableRow
        Dim managinc1, managinc2 As New TableCell
        managinc.Width = 4
        managinc1.ColumnSpan = 2
        managinc2.ColumnSpan = 2
        managinc1.HorizontalAlign = HorizontalAlign.Left
        managinc2.HorizontalAlign = HorizontalAlign.Right
        managinc1.Text = "<b><font size=2>&nbsp;Manager&nbsp;Incentives&nbsp;:</font></b>"
        managinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(20)) & "<font>"
        managinc.Controls.Add(managinc1)
        managinc.Controls.Add(managinc2)
        subtable.Controls.Add(managinc)


        Dim monthinc As New TableRow
        Dim monthinc1, monthinc2 As New TableCell
        monthinc.Width = 4
        monthinc1.ColumnSpan = 2
        monthinc2.ColumnSpan = 2
        monthinc1.HorizontalAlign = HorizontalAlign.Left
        monthinc2.HorizontalAlign = HorizontalAlign.Right
        monthinc1.Text = "<b><font size=2>&nbsp;Monthly&nbsp;Incentives&nbsp;:</font></b>"
        monthinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(21)) & "<font>"
        monthinc.Controls.Add(monthinc1)
        monthinc.Controls.Add(monthinc2)
        subtable.Controls.Add(monthinc)

        Dim depmkt As New TableRow
        Dim depmkt1, depmkt2 As New TableCell
        depmkt.Width = 4
        depmkt1.ColumnSpan = 2
        depmkt2.ColumnSpan = 2
        depmkt1.HorizontalAlign = HorizontalAlign.Left
        depmkt2.HorizontalAlign = HorizontalAlign.Right
        depmkt1.Text = "<b><font size=2>&nbsp;Deposit&nbsp;Marketing&nbsp;Incentives&nbsp:</font></b>"
        depmkt2.Text = "<font size=2>" & checknull(dt.Rows(0)(22)) & "<font>"
        depmkt.Controls.Add(depmkt1)
        depmkt.Controls.Add(depmkt2)
        subtable.Controls.Add(depmkt)

        Dim leginc As New TableRow
        Dim leginc1, leginc2 As New TableCell
        leginc.Width = 4
        leginc1.ColumnSpan = 2
        leginc2.ColumnSpan = 2
        leginc1.HorizontalAlign = HorizontalAlign.Left
        leginc2.HorizontalAlign = HorizontalAlign.Right
        leginc1.Text = "<b><font size=2>&nbsp;Legal&nbsp;Incentives&nbsp:</font></b>"
        leginc2.Text = "<font size=2>" & checknull(dt.Rows(0)(23)) & "<font>"
        leginc.Controls.Add(leginc1)
        leginc.Controls.Add(leginc2)
        subtable.Controls.Add(leginc)

        Dim civilinc As New TableRow
        Dim civilinc1, civilinc2 As New TableCell
        civilinc.Width = 4
        civilinc1.ColumnSpan = 2
        civilinc2.ColumnSpan = 2
        civilinc1.HorizontalAlign = HorizontalAlign.Left
        civilinc2.HorizontalAlign = HorizontalAlign.Right
        civilinc1.Text = "<b><font size=2>&nbsp;Civil&nbsp;Incentives&nbsp:</font></b>"
        civilinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(24)) & "<font>"
        civilinc.Controls.Add(civilinc1)
        civilinc.Controls.Add(civilinc2)
        subtable.Controls.Add(civilinc)


        Dim chitsinc As New TableRow
        Dim chitsinc1, chitsinc2 As New TableCell
        chitsinc.Width = 4
        chitsinc1.ColumnSpan = 2
        chitsinc2.ColumnSpan = 2
        chitsinc1.HorizontalAlign = HorizontalAlign.Left
        chitsinc2.HorizontalAlign = HorizontalAlign.Right
        chitsinc1.Text = "<b><font size=2>&nbsp;Chits&nbsp;Incentives&nbsp:</font></b>"
        chitsinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(25)) & "<font>"
        chitsinc.Controls.Add(chitsinc1)
        chitsinc.Controls.Add(chitsinc2)
        subtable.Controls.Add(chitsinc)

        Dim othinc As New TableRow
        Dim othinc1, othinc2 As New TableCell
        othinc.Width = 4
        othinc1.ColumnSpan = 2
        othinc2.ColumnSpan = 2
        othinc1.HorizontalAlign = HorizontalAlign.Left
        othinc2.HorizontalAlign = HorizontalAlign.Right
        othinc1.Text = "<b><font size=2>&nbsp;Other&nbsp;Incentives&nbsp:</font></b>"
        othinc2.Text = "<font size=2>" & checknull(dt.Rows(0)(26)) & "<font>"
        othinc.Controls.Add(othinc1)
        othinc.Controls.Add(othinc2)
        subtable.Controls.Add(othinc)

        Dim suminc As New TableRow
        Dim suminc1, suminc2 As New TableCell
        suminc.Width = 4
        suminc1.ColumnSpan = 2
        suminc2.ColumnSpan = 2
        suminc1.HorizontalAlign = HorizontalAlign.Left
        suminc2.HorizontalAlign = HorizontalAlign.Right
        suminc1.Text = "<b><font size=2>&nbsp;Summer&nbsp;Allowances&nbsp:</font></b>"
        suminc2.Text = "<font size=2>" & checknull(dt.Rows(0)(27)) & "<font>"
        suminc.Controls.Add(suminc1)
        suminc.Controls.Add(suminc2)
        subtable.Controls.Add(suminc)

        Dim linerow1 As New TableRow
        Dim linecell2 As New TableCell
        linecell2.ColumnSpan = 4
        linecell2.HorizontalAlign = HorizontalAlign.Center
        linecell2.Text = "<hr>"
        linerow1.Controls.Add(linecell2)
        subtable.Controls.Add(linerow1)

        Dim total As New TableRow
        total.Width = 4
        Dim tt1, tt2 As New TableCell
        tt1.ColumnSpan = 2
        tt2.ColumnSpan = 2
        tt1.HorizontalAlign = HorizontalAlign.Left
        tt1.Text = "<b><font size=2>Total&nbsp;&nbsp;Incentives&nbsp;&nbsp;:</font></b>"
        tt2.HorizontalAlign = HorizontalAlign.Right
        tt2.Text = "<b><font size=2>" & FormatNumber(subtot, 2) & "</font></b>"
        total.Controls.Add(tt1)
        total.Controls.Add(tt2)
        subtable.Controls.Add(total)

        Dim linerow1a As New TableRow
        Dim linecell2a As New TableCell
        linecell2a.ColumnSpan = 4
        linecell2a.HorizontalAlign = HorizontalAlign.Center
        linecell2a.Text = "<hr>"
        linerow1a.Controls.Add(linecell2a)
        subtable.Controls.Add(linerow1a)

        Dim back As New TableRow
        Dim back1 As New TableCell
        back1.ColumnSpan = 4
        back1.HorizontalAlign = HorizontalAlign.Center
        back1.Text = "<a href=firstreport.aspx><font size=2>Back To Main Report</font></a>"
        back.Controls.Add(back1)
        subtable.Controls.Add(back)


        Panel1.BorderStyle = BorderStyle.Groove
        Panel1.Controls.Add(subtable)
    End Sub
End Class
