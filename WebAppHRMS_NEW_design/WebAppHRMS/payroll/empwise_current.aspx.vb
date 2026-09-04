Imports System.Data
Imports System.Data.OracleClient
Partial Class Emp_Current_empwise_current_2ecf94013064
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    Dim total As Integer = 0
    Dim exptotal As Double = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("status") = 0 Then
            '                   0           1          2             3              4          5          6             7           8         9                  10           11               12
            str = "select ec.emp_code,ec.emp_name,ec.contact_no,ec.designation,ec.department,ec.post,ec.join_dt,ec.qualification,ec.age,nvl(ec.exp_day,0),ec.emp_type,ec.discont_dt,nvl(ec.old_empcode,0) from employee_current ec where ec.status_id not in(3,5) and ec.branch_id=" & Me.Request.QueryString("branchid") & " order by ec.emp_code"
        Else
            '                 0           1               2                   3             4              5        6             7        8        9           10          11             12                13                    
            str = "select ec.emp_code,ec.emp_name,ec.contact_no,ec.designation,ec.department,ec.post,ec.join_dt,ec.qualification,ec.age,ec.exp_day,ec.emp_type,ec.discont_dt,nvl(ec.old_empcode,0) from employee_current ec where ec.status_id=" & Me.Request.QueryString("status") & " and ec.branch_id=" & Me.Request.QueryString("branchid") & " order by ec.emp_code"

        End If
        dt = oh.ExecuteDataSet(str).Tables(0)


        Dim empcurtable As New Table
        empcurtable.Attributes.Add("width", "100%")

        Dim header As New TableRow
        header.Width = 13
        header.BackColor = Drawing.Color.Gold
        header.ForeColor = Drawing.Color.Red
        Dim headcell As New TableCell
        headcell.ColumnSpan = 13
        headcell.Text = "<b><font size=3>" & Session("firm_name") & "</font></b>"
        headcell.HorizontalAlign = HorizontalAlign.Center
        header.Controls.Add(headcell)
        empcurtable.Controls.Add(header)

        Dim sheader As New TableRow
        sheader.Width = 13
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 14
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2 >Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        empcurtable.Controls.Add(sheader)


        Dim subh As New TableRow
        Dim subcell1 As New TableCell
        Dim subcell2 As New TableCell
        Dim subcell3 As New TableCell
        subh.Width = 13
        subcell1.Text = "<b><font size=2> Date:" & Format(Date.Now, "dd/MMM/yyyy") & "</font></b>"
        subcell1.ColumnSpan = 3
        subcell1.HorizontalAlign = HorizontalAlign.Left
        subh.Controls.Add(subcell1)

        subcell2.ColumnSpan = 7
        subcell2.HorizontalAlign = HorizontalAlign.Center
        subcell2.Text = " "
        subh.Controls.Add(subcell2)

        subcell3.ColumnSpan = 3
        subcell3.Text = "<b><font size=2>Time: " & Format(Date.Now, "hh:mm:ss tt") & "</font></b>"
        subcell3.HorizontalAlign = HorizontalAlign.Right
        subh.Controls.Add(subcell3)

        empcurtable.Controls.Add(subh)

        Dim pheader As New TableRow
        Dim pheadercell As New TableCell
        pheader.Width = 13
        pheadercell.ColumnSpan = 13
        pheadercell.HorizontalAlign = HorizontalAlign.Center


        If Me.Request.QueryString("status") = 0 Then
            pheadercell.Text = "<body align=center ><b><font size=3>" & Me.Request.QueryString("branchname") & ": list of All(Resigned,Terminated Not Included)employees</font></b>"
        ElseIf Me.Request.QueryString("status") = 1 Then
            pheadercell.Text = "<body align=center ><b><font size=3>" & Me.Request.QueryString("branchname") & ":list of Normal employees</font></b>"
        ElseIf Me.Request.QueryString("status") = 3 Then
            pheadercell.Text = "<body align=center ><b><font size=3>" & Me.Request.QueryString("branchname") & ": list of Resigned employees</font></b>"
        ElseIf Me.Request.QueryString("status") = 4 Then
            pheadercell.Text = "<body align=center ><b><font size=3>" & Me.Request.QueryString("branchname") & ": list of Suspended employees</font></b>"
        ElseIf Me.Request.QueryString("status") = 6 Then
            pheadercell.Text = "<body align=center ><b><font size=3>" & Me.Request.QueryString("branchname") & ":list of employees in Long Leave</font></b>"
        ElseIf Me.Request.QueryString("status") = 10 Then
            pheadercell.Text = "<body align=center ><b><font size=3>" & Me.Request.QueryString("branchname") & ": list of employees in Maternity Leave</font></b>"
        ElseIf Me.Request.QueryString("status") = 5 Then
            pheadercell.Text = "<body align=center ><b><font size=3>" & Me.Request.QueryString("branchname") & ": list of Terminated employees</font></b>"

        End If
        pheader.Controls.Add(pheadercell)
        empcurtable.Controls.Add(pheader)



        Dim line1 As New TableRow
        Dim linecell1 As New TableCell
        line1.Width = 13
        linecell1.ColumnSpan = 13
        linecell1.Text = "<hr>"
        line1.Controls.Add(linecell1)
        empcurtable.Controls.Add(line1)





        Dim field As New TableRow
        field.Width = 13
        Dim f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14 As New TableCell

        f1.ColumnSpan = 1
        f1.HorizontalAlign = HorizontalAlign.Left
        f1.Text = "<b><font size=2>Emp Code</font></b>"
        field.Controls.Add(f1)


        f2.ColumnSpan = 1
        f2.HorizontalAlign = HorizontalAlign.Left
        f2.Text = "<b><font size=2>Emp Name</font></b>"
        field.Controls.Add(f2)

        f3.ColumnSpan = 1
        f3.HorizontalAlign = HorizontalAlign.Left
        f3.Text = "<b><font size=2>Cont. No</font></b>"
        field.Controls.Add(f3)

        f4.ColumnSpan = 1
        f4.HorizontalAlign = HorizontalAlign.Left
        f4.Text = "<b><font size=2>Desig.</font></b>"
        field.Controls.Add(f4)

        f5.ColumnSpan = 1
        f5.HorizontalAlign = HorizontalAlign.Left
        f5.Text = "<b><font size=2>Deptmt</font></b>"
        field.Controls.Add(f5)

        f6.ColumnSpan = 1
        f6.HorizontalAlign = HorizontalAlign.Left
        f6.Text = "<b><font size=2>Post</font></b>"
        field.Controls.Add(f6)

        f7.ColumnSpan = 1
        f7.HorizontalAlign = HorizontalAlign.Left
        f7.Text = "<b><font size=2>D.O.J</font></b>"
        field.Controls.Add(f7)


        f8.ColumnSpan = 1
        f8.HorizontalAlign = HorizontalAlign.Left
        f8.Text = "<b><font size=2>Qualif.n</font></b>"
        field.Controls.Add(f8)


        f9.ColumnSpan = 1
        f9.HorizontalAlign = HorizontalAlign.Left
        f9.Text = "<b><font size=2>Age</font></b>"
        field.Controls.Add(f9)

        f10.ColumnSpan = 1
        f10.HorizontalAlign = HorizontalAlign.Left
        f10.Text = "<b><font size=2>Exp. Days</font></b>"
        field.Controls.Add(f10)


        f11.ColumnSpan = 1
        f11.HorizontalAlign = HorizontalAlign.Left
        f11.Text = "<b><font size=2>Emp Type</font></b>"
        field.Controls.Add(f11)


        f12.ColumnSpan = 1
        f12.HorizontalAlign = HorizontalAlign.Left
        f12.Text = "<b><font size=2>Discont Dt</font></b>"
        field.Controls.Add(f12)


        f13.ColumnSpan = 1
        f13.HorizontalAlign = HorizontalAlign.Left
        f13.Text = "<b><font size=2>Old EmCode</font></b>"
        field.Controls.Add(f13)

        'f14.ColumnSpan = 1
        'f14.HorizontalAlign = HorizontalAlign.Left
        'f14.Text = "<b><font size=2>Grade</font></b>"
        'field.Controls.Add(f14)



        empcurtable.Controls.Add(field)

        Dim linek As New TableRow
        Dim linecellk As New TableCell
        linek.Width = 13
        linecellk.ColumnSpan = 13
        linecellk.Text = "<hr>"
        linek.Controls.Add(linecellk)
        empcurtable.Controls.Add(linek)

        For Each dr In dt.Rows

            total += 1

            Dim val As New TableRow
            val.Width = 13
            Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14 As New TableCell

            'Code
            v1.ColumnSpan = 1
            v1.HorizontalAlign = HorizontalAlign.Left
            v1.Text = "<font size=2>" & dr(0) & "&nbsp;</font>"
            val.Controls.Add(v1)


            'name
            v2.ColumnSpan = 1
            v2.HorizontalAlign = HorizontalAlign.Left
            v2.Text = "<font size=2>" & dr(1) & "&nbsp;</font>"
            val.Controls.Add(v2)

            'cont no
            v3.ColumnSpan = 1
            v3.HorizontalAlign = HorizontalAlign.Left
            If IsDBNull(dr(2)) Then
                v3.Text = "<font size=2>----</font>"
            Else
                v3.Text = "<font size=2>" & dr(2) & "&nbsp;</font>"
            End If

            val.Controls.Add(v3)

            'Designtion
            v4.ColumnSpan = 1
            v4.HorizontalAlign = HorizontalAlign.Left
            v4.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
            val.Controls.Add(v4)

            'Deptmt
            v5.ColumnSpan = 1
            v5.HorizontalAlign = HorizontalAlign.Left
            v5.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
            val.Controls.Add(v5)

            'Post
            v6.ColumnSpan = 1
            v6.HorizontalAlign = HorizontalAlign.Left
            v6.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
            val.Controls.Add(v6)

            'DOJ
            v7.ColumnSpan = 1
            v7.HorizontalAlign = HorizontalAlign.Left
            v7.Text = "<font size=2>" & Format(dr(6), "dd/MMM/yyyy") & "&nbsp;</font>"
            val.Controls.Add(v7)


            'Qualficn
            v8.ColumnSpan = 1
            v8.HorizontalAlign = HorizontalAlign.Left
            v8.Text = "<font size=2>" & dr(7) & "</font>"
            val.Controls.Add(v8)

            ''Age
            v9.ColumnSpan = 1
            v9.HorizontalAlign = HorizontalAlign.Right
            If dr(8) = 0 Or IsDBNull(dr(8)) Then
                v9.Text = "<font size=2>----</font>"
            Else
                v9.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
            End If
            val.Controls.Add(v9)


            'ExpZ_days
            v10.ColumnSpan = 1
            v10.HorizontalAlign = HorizontalAlign.Right
            v10.Text = "<font size=2>" & dr(9) & "&nbsp;</font>"
            val.Controls.Add(v10)
            Me.exptotal += dr(9)

            'Emptype
            v11.ColumnSpan = 1
            v11.HorizontalAlign = HorizontalAlign.Left
            v11.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
            val.Controls.Add(v11)

            'Disc date
            v12.ColumnSpan = 1
            v12.HorizontalAlign = HorizontalAlign.Left
            If IsDBNull(dr(11)) Then
                v12.Text = "<font size=2>----</font>"
            Else
                v12.Text = "<font size=2>" & Format(dr(11), "dd/MMM/yyyy") & "&nbsp;</font>"
            End If
            val.Controls.Add(v12)

            'Old Vode
            v13.ColumnSpan = 1
            v13.HorizontalAlign = HorizontalAlign.Left
            If IsDBNull(dr(12)) Or dr(12) = 0 Then
                v13.Text = "<font size=2>----</font>"
            Else
                v13.Text = "<font size=2>" & dr(12) & "&nbsp;</font>"
            End If
            val.Controls.Add(v13)

            'Grade
            'v14.ColumnSpan = 1
            'v14.HorizontalAlign = HorizontalAlign.Left
            'v14.Text = "<font size=2>" & dr(13) & "</font>"
            'val.Controls.Add(v14)


            empcurtable.Controls.Add(val)

        Next

        Dim linee As New TableRow
        Dim linecelle As New TableCell
        linee.Width = 13
        linecelle.ColumnSpan = 13
        linecelle.Text = "<hr>"
        linee.Controls.Add(linecelle)
        empcurtable.Controls.Add(linee)

        Dim totrow As New TableRow
        totrow.Width = 13
        Dim t1 As New TableCell
        t1.ColumnSpan = 13
        t1.HorizontalAlign = HorizontalAlign.Left
        t1.Text = "<b><font size=2> Total Employee(s):&nbsp;" & Me.total & " and Total Exp.Days=" & Me.exptotal & "</font></b>"
        totrow.Controls.Add(t1)
        empcurtable.Controls.Add(totrow)

        Panel_Empwise.Controls.Add(empcurtable)
    End Sub
End Class
