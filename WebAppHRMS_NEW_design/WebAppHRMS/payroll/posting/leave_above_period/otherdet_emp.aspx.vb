Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_above_10_otherdet_emp_001784844581
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim othdetail As New Table

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '                  0           1           2       3       4            5            6              7            8       9             10            11        12          13          14             15          16
        str = "select ec.emp_code,ec.emp_name,ec.gender,ec.age,ec.marital,ec.contact_no,ec.designation,ec.department,ec.post,ec.join_dt,ec.qualification,ec.exp_day,ec.status,ec.emp_type,ec.discont_dt,ec.old_empcode,gm.grade from employee_current ec,grade_master gm where ec.grade_id=gm.grade_id and ec.emp_code=" & Me.Request.QueryString("empcode")
        dt = oh.ExecuteDataSet(str).Tables(0)

        othdetail.Attributes.Add("width", "100%")
        Dim header As New TableRow
        header.Width = 10
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 10
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        othdetail.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 10
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 10
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        othdetail.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 10
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 3
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 4
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 3
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)

        othdetail.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 10
        pheadercell.ColumnSpan = 10
        pheadercell.HorizontalAlign = HorizontalAlign.Center

        pheadercell.Text = "<u><body align=center ><b><font size=3> Other Details </font></b></u>"
        pheader.Controls.Add(pheadercell)
        othdetail.Controls.Add(pheader)

       

        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 10
        linecell1.ColumnSpan = 10
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        othdetail.Controls.Add(line1)

        If dt.Rows.Count > 0 Then

            Dim code As New TableRow
            code.Width = 10
            Dim c1, c2 As New TableCell
            c1.ColumnSpan = 4
            c2.ColumnSpan = 6
            c1.HorizontalAlign = HorizontalAlign.Left
            c2.HorizontalAlign = HorizontalAlign.Left
            c1.Text = "<b><font size=2>Employee Code:</font></b>"
            c2.Text = "<font size=2>" & dt.Rows(0)(0) & "</font>"
            code.Controls.Add(c1)
            code.Controls.Add(c2)
            othdetail.Controls.Add(code)

            Dim name As New TableRow
            name.Width = 10
            Dim name1, name2 As New TableCell
            name1.ColumnSpan = 4
            name2.ColumnSpan = 6
            name1.HorizontalAlign = HorizontalAlign.Left
            name2.HorizontalAlign = HorizontalAlign.Left
            name1.Text = "<b><font size=2>Employee Name:</font></b>"
            name2.Text = "<font size=2>" & dt.Rows(0)(1) & "</font>"
            name.Controls.Add(name1)
            name.Controls.Add(name2)
            othdetail.Controls.Add(name)

            Dim gendr As New TableRow
            gendr.Width = 10
            Dim gendr1, gendr2 As New TableCell
            gendr1.ColumnSpan = 4
            gendr2.ColumnSpan = 6
            gendr1.HorizontalAlign = HorizontalAlign.Left
            gendr2.HorizontalAlign = HorizontalAlign.Left
            gendr1.Text = "<b><font size=2>Gender:</font></b>"
            gendr2.Text = "<font size=2>" & dt.Rows(0)(2) & "</font>"
            gendr.Controls.Add(gendr1)
            gendr.Controls.Add(gendr2)
            othdetail.Controls.Add(gendr)

            Dim eage As New TableRow
            eage.Width = 10
            Dim eage1, eage2 As New TableCell
            eage1.ColumnSpan = 4
            eage2.ColumnSpan = 6
            eage1.HorizontalAlign = HorizontalAlign.Left
            eage2.HorizontalAlign = HorizontalAlign.Left
            eage1.Text = "<b><font size=2>Age:</font></b>"
            eage2.Text = "<font size=2>" & dt.Rows(0)(3) & "</font>"
            eage.Controls.Add(eage1)
            eage.Controls.Add(eage2)
            othdetail.Controls.Add(eage)

            Dim mstatus As New TableRow
            mstatus.Width = 10
            Dim mstatus1, mstatus2 As New TableCell
            mstatus1.ColumnSpan = 4
            mstatus2.ColumnSpan = 6
            mstatus1.HorizontalAlign = HorizontalAlign.Left
            mstatus2.HorizontalAlign = HorizontalAlign.Left
            mstatus1.Text = "<b><font size=2>Martial Status:</font></b>"
            mstatus2.Text = "<font size=2>" & dt.Rows(0)(4) & "</font>"
            mstatus.Controls.Add(mstatus1)
            mstatus.Controls.Add(mstatus2)
            othdetail.Controls.Add(mstatus)

            Dim contno As New TableRow
            contno.Width = 10
            Dim contno1, contno2 As New TableCell
            contno1.ColumnSpan = 4
            contno2.ColumnSpan = 6
            contno1.HorizontalAlign = HorizontalAlign.Left
            contno2.HorizontalAlign = HorizontalAlign.Left
            contno1.Text = "<b><font size=2>Contact Number:</font></b>"
            contno2.Text = "<font size=2>" & dt.Rows(0)(5) & "</font>"
            contno.Controls.Add(contno1)
            contno.Controls.Add(contno2)
            othdetail.Controls.Add(contno)

            Dim desig As New TableRow
            desig.Width = 10
            Dim desig1, desig2 As New TableCell
            desig1.ColumnSpan = 4
            desig2.ColumnSpan = 6
            desig1.HorizontalAlign = HorizontalAlign.Left
            desig2.HorizontalAlign = HorizontalAlign.Left
            desig1.Text = "<b><font size=2>Designation:</font></b>"
            desig2.Text = "<font size=2>" & dt.Rows(0)(6) & "</font>"
            desig.Controls.Add(desig1)
            desig.Controls.Add(desig2)
            othdetail.Controls.Add(desig)

            Dim deptmt As New TableRow
            deptmt.Width = 10
            Dim deptmt1, deptmt2 As New TableCell
            deptmt1.ColumnSpan = 4
            deptmt2.ColumnSpan = 6
            deptmt1.HorizontalAlign = HorizontalAlign.Left
            deptmt2.HorizontalAlign = HorizontalAlign.Left
            deptmt1.Text = "<b><font size=2>Department:</font></b>"
            deptmt2.Text = "<font size=2>" & dt.Rows(0)(7) & "</font>"
            deptmt.Controls.Add(deptmt1)
            deptmt.Controls.Add(deptmt2)
            othdetail.Controls.Add(deptmt)

            Dim epost As New TableRow
            epost.Width = 10
            Dim epost1, epost2 As New TableCell
            epost1.ColumnSpan = 4
            epost2.ColumnSpan = 6
            epost1.HorizontalAlign = HorizontalAlign.Left
            epost2.HorizontalAlign = HorizontalAlign.Left
            epost1.Text = "<b><font size=2>Post:</font></b>"
            epost2.Text = "<font size=2>" & dt.Rows(0)(8) & "</font>"
            epost.Controls.Add(epost1)
            epost.Controls.Add(epost2)
            othdetail.Controls.Add(epost)

            Dim JoiDt As New TableRow
            JoiDt.Width = 10
            Dim JoiDt1, JoiDt2 As New TableCell
            JoiDt1.ColumnSpan = 4
            JoiDt2.ColumnSpan = 6
            JoiDt1.HorizontalAlign = HorizontalAlign.Left
            JoiDt2.HorizontalAlign = HorizontalAlign.Left
            JoiDt1.Text = "<b><font size=2>Join Date:</font></b>"
            JoiDt2.Text = "<font size=2>" & dt.Rows(0)(9) & "</font>"
            JoiDt.Controls.Add(JoiDt1)
            JoiDt.Controls.Add(JoiDt2)
            othdetail.Controls.Add(JoiDt)

            Dim equal As New TableRow
            equal.Width = 10
            Dim equal1, equal2 As New TableCell
            equal1.ColumnSpan = 4
            equal2.ColumnSpan = 6
            equal1.HorizontalAlign = HorizontalAlign.Left
            equal2.HorizontalAlign = HorizontalAlign.Left
            equal1.Text = "<b><font size=2>Qualification:</font></b>"
            equal2.Text = "<font size=2>" & dt.Rows(0)(10) & "</font>"
            equal.Controls.Add(equal1)
            equal.Controls.Add(equal2)
            othdetail.Controls.Add(equal)

            Dim exdays As New TableRow
            exdays.Width = 10
            Dim exdays1, exdays2 As New TableCell
            exdays1.ColumnSpan = 4
            exdays2.ColumnSpan = 6
            exdays1.HorizontalAlign = HorizontalAlign.Left
            exdays2.HorizontalAlign = HorizontalAlign.Left
            exdays1.Text = "<b><font size=2>Exp. Days in Manappuram:</font></b>"
            exdays2.Text = "<font size=2>" & dt.Rows(0)(11) & "</font>"
            exdays.Controls.Add(exdays1)
            exdays.Controls.Add(exdays2)
            othdetail.Controls.Add(exdays)

            Dim estts As New TableRow
            estts.Width = 10
            Dim estts1, estts2 As New TableCell
            estts1.ColumnSpan = 4
            estts2.ColumnSpan = 6
            estts1.HorizontalAlign = HorizontalAlign.Left
            estts2.HorizontalAlign = HorizontalAlign.Left
            estts1.Text = "<b><font size=2>Current Status:</font></b>"
            estts2.Text = "<font size=2>" & dt.Rows(0)(12) & "</font>"
            estts.Controls.Add(estts1)
            estts.Controls.Add(estts2)
            othdetail.Controls.Add(estts)

            Dim emtpe As New TableRow
            emtpe.Width = 10
            Dim emtpe1, emtpe2 As New TableCell
            emtpe1.ColumnSpan = 4
            emtpe2.ColumnSpan = 6
            emtpe1.HorizontalAlign = HorizontalAlign.Left
            emtpe2.HorizontalAlign = HorizontalAlign.Left
            emtpe1.Text = "<b><font size=2>Emp. Type:</font></b>"
            emtpe2.Text = "<font size=2>" & dt.Rows(0)(13) & "</font>"
            emtpe.Controls.Add(emtpe1)
            emtpe.Controls.Add(emtpe2)
            othdetail.Controls.Add(emtpe)

            If Not IsDBNull(dt.Rows(0)(14)) Then
                Dim ddate As New TableRow
                ddate.Width = 10
                Dim ddate1, ddate2 As New TableCell
                ddate1.ColumnSpan = 4
                ddate2.ColumnSpan = 6
                ddate1.HorizontalAlign = HorizontalAlign.Left
                ddate2.HorizontalAlign = HorizontalAlign.Left
                ddate1.Text = "<b><font size=2>Discontinue Date:</font></b>"
                ddate2.Text = "<font size=2>" & Format(dt.Rows(0)(14), "dd/MMM/yyyy") & "</font>"
                ddate.Controls.Add(ddate1)
                ddate.Controls.Add(ddate2)
                othdetail.Controls.Add(ddate)
            End If

            If Not IsDBNull(dt.Rows(0)(15)) Then
                Dim oemcde As New TableRow
                oemcde.Width = 10
                Dim oemcde1, oemcde2 As New TableCell
                oemcde1.ColumnSpan = 4
                oemcde2.ColumnSpan = 6
                oemcde1.HorizontalAlign = HorizontalAlign.Left
                oemcde2.HorizontalAlign = HorizontalAlign.Left
                oemcde1.Text = "<b><font size=2>Old Emp Code:</font></b>"
                oemcde2.Text = "<font size=2>" & dt.Rows(0)(15) & "</font>"
                oemcde.Controls.Add(oemcde1)
                oemcde.Controls.Add(oemcde2)
                othdetail.Controls.Add(oemcde)
            End If

            Dim egrad As New TableRow
            egrad.Width = 10
            Dim egrad1, egrad2 As New TableCell
            egrad1.ColumnSpan = 4
            egrad2.ColumnSpan = 6
            egrad1.HorizontalAlign = HorizontalAlign.Left
            egrad2.HorizontalAlign = HorizontalAlign.Left
            egrad1.Text = "<b><font size=2>Grade:</font></b>"
            egrad2.Text = "<font size=2>" & dt.Rows(0)(16) & "</font>"
            egrad.Controls.Add(egrad1)
            egrad.Controls.Add(egrad2)
            othdetail.Controls.Add(egrad)
        Else
            Dim war As New TableRow
            war.Width = 10
            Dim war1 As New TableCell
            war1.ColumnSpan = 10
            war1.HorizontalAlign = HorizontalAlign.Center
            war1.Text = "<b><font size=2>No Details Of This Employee!!</font></b>"
            war.Controls.Add(war1)
            othdetail.Controls.Add(war)
        End If



        Panel_Other.Controls.Add(othdetail)

    End Sub

End Class
