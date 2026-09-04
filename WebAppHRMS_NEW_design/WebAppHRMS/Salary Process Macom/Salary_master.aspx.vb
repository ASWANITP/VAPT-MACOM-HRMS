Imports System.IO
Imports System.Data
Imports System.Data.oracleclient
Imports Helper.Oracle.OracleHelper
Partial Class Circular_Show_Corcular_circular_display_b4c564f21859
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim CbResult As String = Nothing
    Dim oh1 As New Helper.Oracle.OracleHelper
    Dim dt1, fgt As New DataTable
    Dim err_flag As Boolean
    Dim q_str As String
    Dim upc As String = "N"
    Dim s As Integer = 1
    Dim str_tkn As New System.Text.StringBuilder
    Dim cl_sct As New StringBuilder
    Dim acces_id, br_id, fir_id As Integer
    Dim sysip As String
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim user As String
        trowam.Visible = False
        tr4.Visible = False
        If Me.Session("user_id") = "" Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append(" alert('Please Login Again and Retry....!! ');")
            cl_script1.Append("    window.open('../main.aspx?key=75872','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            Exit Sub
        End If
        dt1 = oh1.ExecuteDataSet("select count(t.emp_id) ecod  from form_accessibility t  where form_id = 2026  and emp_id = " & Session("user_id").ToString.Split("!")(0)).Tables(0)
        If dt1.Rows(0)(0) = 0 Then
            Server.Transfer("~/show_err.aspx")
        End If
        acces_id = Request.QueryString.Get("acces_id")
        user = Request.QueryString.Get("userid")
        fir_id = Request.QueryString.Get("fir_id")
        br_id = Request.QueryString.Get("brid")
        sysip = Request.QueryString.Get("sysip")
        Dim dt_pri, dt As New DataTable
        Dim mid As Integer = Request.QueryString("mid")
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.down1_d.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If mid = 0 Then

            div3.Visible = False
            div2.Visible = False
            div4.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
            Dim usr() As String = Session("user_id").split("!")
            Dim empcode As Integer
            empcode = usr(0)
            Dim user_id_to As String = empcode
            q_str = "select t.* from SALARY_DASH t"
            dt = oh1.ExecuteDataSet(q_str).Tables(0)

            Dim tab As New Table
            tab.BorderStyle = BorderStyle.None
            tab.Attributes.Add("width", "850px")
            tab.Attributes.Add("align", "center")
            tab.Attributes.Add("border", "2")

            Dim tr2 As New TableRow
            tr2.ForeColor = Drawing.Color.FloralWhite
            Dim tc3 As New TableCell
            tc3.BorderStyle = BorderStyle.None
            tc3.ColumnSpan = 9
            tc3.Text = "<b><i><font size=3><img alt='Alert' id='midf' src='icons8-alarm.gif'/></font></i></b>"
            tc3.HorizontalAlign = HorizontalAlign.Center
            tr2.Controls.Add(tc3)
            tab.Controls.Add(tr2)

            Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt,'Mon-YYYY')from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)

            Dim showa As String = ""
            Dim showa1 As String = ""
            Dim sals As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt) from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
            Dim oak As DataTable = oh1.ExecuteDataSet("select count(*) from SALARY_PROCESS_UPD where consol_allow=1 and ledg_entry<>1 and proc_month='" & sals.Rows(0)(0) & "'").Tables(0)
            Dim oak1 As DataTable = oh1.ExecuteDataSet("select count(*) from SALARY_PROCESS_UPD where ledg_entry=1 and proc_month='" & sals.Rows(0)(0) & "'").Tables(0)
            If oak.Rows.Count > 0 Then
                If oak.Rows(0)(0) = 1 Then
                    showa = "Current Month Salary Processing Is In Progress"
                    showa1 = "Welcome To Salary Month : " & sal.Rows(0)(0) & ", Please Ensure All Pending Approvals & Notes Regarding Promotion, Transfer, Increment...etc Is Completed On Before Processing"
                ElseIf oak1.Rows(0)(0) = 1 Then
                    showa = "Current Month Salary Processing Is Completed"
                    showa1 = "Welcome To Salary Month : " & sal.Rows(0)(0) & ""
                Else
                    showa = "System Is Ready For Current Month Salary Processing"
                    showa1 = "Welcome To Salary Month : " & sal.Rows(0)(0) & ", Please Ensure All Pending Approvals & Notes Regarding Promotion, Transfer, Increment...etc Is Completed On Before Processing"
                End If
            Else
                showa = "System Is Ready For Current Month Salary Processing"
                showa1 = "Welcome To Salary Month : " & sal.Rows(0)(0) & ", Please Ensure All Pending Approvals & Notes Regarding Promotion, Transfer, Increment...etc Is Completed On Before Processing"
            End If

            Dim tot1 As New TableRow
            Dim totc1 As New TableCell
            totc1.ColumnSpan = 9
            totc1.BorderStyle = BorderStyle.None
            totc1.Text = " <font size=5 style='color:blue'><i><MARQUEE scrollamount=5 scrolldelay=100 style=WIDTH: 6px; HEIGHT: 3px bgColor=white><STRONG><FONT color=darkred> " + showa1 + " </FONT></STRONG></MARQUEE></i></font>"
            totc1.HorizontalAlign = HorizontalAlign.Left
            tot1.Controls.Add(totc1)
            tab.Controls.Add(tot1)


            Dim tot As New TableRow
            Dim totc As New TableCell
            totc.ColumnSpan = 9
            totc.BorderStyle = BorderStyle.None
            totc.Text = " <font size=5 style='color:blue'>&nbsp;</font>"
            totc.HorizontalAlign = HorizontalAlign.Left
            tot.Controls.Add(totc)
            tab.Controls.Add(tot)

            Dim tot12 As New TableRow
            Dim totc12 As New TableCell
            totc12.ColumnSpan = 9
            totc12.BorderStyle = BorderStyle.None
            totc12.Text = " <font size=5 style='color:blue'><i>&nbsp;</i></font>"
            totc12.HorizontalAlign = HorizontalAlign.Left
            tot12.Controls.Add(totc12)
            tab.Controls.Add(tot12)

            Dim tot13 As New TableRow
            Dim totc13 As New TableCell
            totc13.ColumnSpan = 9
            totc13.BorderStyle = BorderStyle.None
            totc13.Text = " <font size=5 style='color:blue'><i>&nbsp;</i></font>"
            totc13.HorizontalAlign = HorizontalAlign.Left
            tot13.Controls.Add(totc13)
            tab.Controls.Add(tot13)

            Dim tot14 As New TableRow
            Dim totc14 As New TableCell
            totc14.ColumnSpan = 9
            totc14.BorderStyle = BorderStyle.None
            totc14.Text = " <font size=5 style='color:darkred'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='color:#009900'>&#x2714;</span>" & showa & "</font>"
            totc14.HorizontalAlign = HorizontalAlign.Left
            tot14.Controls.Add(totc14)
            tab.Controls.Add(tot14)

            Dim tot15 As New TableRow
            Dim totc15 As New TableCell
            totc15.ColumnSpan = 9
            totc15.BorderStyle = BorderStyle.None
            totc15.Text = " <font size=5 style='color:blue'><i>&nbsp;</i></font>"
            totc15.HorizontalAlign = HorizontalAlign.Left
            tot13.Controls.Add(totc15)
            tab.Controls.Add(tot15)

            Dim tot16 As New TableRow
            Dim totc16 As New TableCell
            totc16.ColumnSpan = 9
            totc16.BorderStyle = BorderStyle.None
            totc16.Text = " <font size=5 style='color:blue'><i>&nbsp;</i></font>"
            totc16.HorizontalAlign = HorizontalAlign.Left
            tot16.Controls.Add(totc16)
            tab.Controls.Add(tot16)

            Dim tot17s As New TableRow
            Dim totc17s As New TableCell
            totc17s.ColumnSpan = 9
            totc17s.BorderStyle = BorderStyle.None
            totc17s.Text = " <font size=5 style='color:blue'><i>&nbsp;</i></font>"
            totc17s.HorizontalAlign = HorizontalAlign.Left
            tot17s.Controls.Add(totc17s)
            tab.Controls.Add(tot17s)

            Dim tot18 As New TableRow
            Dim totc18 As New TableCell
            totc18.ColumnSpan = 9
            totc18.BorderStyle = BorderStyle.None
            totc18.Text = " <font size=5 style='color:blue'><i>&nbsp;</i></font>"
            totc18.HorizontalAlign = HorizontalAlign.Left
            tot18.Controls.Add(totc18)
            tab.Controls.Add(tot18)

            Dim tot19 As New TableRow
            Dim totc19 As New TableCell
            totc19.ColumnSpan = 9
            totc19.BorderStyle = BorderStyle.None
            totc19.Text = " <font size=5 style='color:blue'><i>&nbsp;</i></font>"
            totc19.HorizontalAlign = HorizontalAlign.Left
            tot19.Controls.Add(totc19)
            tab.Controls.Add(tot19)

            Dim tot17 As New TableRow
            Dim totc17 As New TableCell
            totc17.ColumnSpan = 9
            totc17.BorderStyle = BorderStyle.None
            totc17.Text = " <font size=5 style='color:blue'><i>&nbsp;</i></font>"
            totc17.HorizontalAlign = HorizontalAlign.Left
            tot17.Controls.Add(totc17)
            tab.Controls.Add(tot17)
            Me.Pnl_Inbox.Controls.Add(tab)
            'End If
        End If
        If mid = 21 Then
            div2.Visible = False
            div3.Visible = False
            div4.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
            Dim tab As New Table
            tab.Attributes.Add("border-collapse", "collapse")
            tab.Attributes.Add("width", "850px")
            tab.Attributes.Add("align", "center")
            tab.Attributes.Add("border", "2")

            Dim tr2s As New TableRow
            tr2s.BackColor = Drawing.Color.DarkRed
            tr2s.ForeColor = Drawing.Color.White
            Dim tc3s As New TableCell
            tc3s.ColumnSpan = 3
            tc3s.Text = "<b><i><font size=5> CHECK LISTS </font></i></b>"
            tc3s.HorizontalAlign = HorizontalAlign.Center
            tr2s.Controls.Add(tc3s)
            tab.Controls.Add(tr2s)


            Dim tr5 As New TableRow
            Dim tc51s As New TableCell
            tc51s.Text = "<font size=4><b>PARTICULARS</font>"
            tc51s.ForeColor = Drawing.Color.DarkRed
            tc51s.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc51s)
            Dim tc5321s As New TableCell
            tc5321s.Text = "<font size=4><b>DUE MONTHS</font>"
            tc5321s.ForeColor = Drawing.Color.DarkRed
            tc5321s.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc5321s)
            tab.Controls.Add(tr5)


            Dim tr6 As New TableRow

            Dim tc63 As New TableCell
            tc63.Text = "<font size=3>VDA</font>"
            tc63.HorizontalAlign = HorizontalAlign.Center
            tc63.ForeColor = Drawing.Color.DarkRed
            tr6.Controls.Add(tc63)

            Dim tc64 As New TableCell
            tc64.Text = "<font size=3>Monthly</font>"
            tc64.HorizontalAlign = HorizontalAlign.Center
            tc64.ForeColor = Drawing.Color.DarkRed
            tr6.Controls.Add(tc64)
            tab.Controls.Add(tr6)


            Dim tr6s As New TableRow
            Dim tc63s As New TableCell
            tc63s.Text = "<font size=3>Professional Tax</font>"
            tc63s.HorizontalAlign = HorizontalAlign.Center
            tc63s.ForeColor = Drawing.Color.DarkRed
            tr6s.Controls.Add(tc63s)

            Dim tc64s As New TableCell
            tc64s.Text = "<font size=3>February & August</font>"
            tc64s.HorizontalAlign = HorizontalAlign.Center
            tc64s.ForeColor = Drawing.Color.DarkRed
            tr6s.Controls.Add(tc64s)
            tab.Controls.Add(tr6s)


            Dim tr6sw As New TableRow
            Dim tc63sw As New TableCell
            tc63sw.Text = "<font size=3>ESI Outmark</font>"
            tc63sw.HorizontalAlign = HorizontalAlign.Center
            tc63sw.ForeColor = Drawing.Color.DarkRed
            tr6sw.Controls.Add(tc63sw)

            Dim tc64se As New TableCell
            tc64se.Text = "<font size=3>March & September</font>"
            tc64se.HorizontalAlign = HorizontalAlign.Center
            tc64se.ForeColor = Drawing.Color.DarkRed
            tr6sw.Controls.Add(tc64se)
            tab.Controls.Add(tr6sw)


            Dim tr6sw1 As New TableRow
            Dim tc63sw1 As New TableCell
            tc63sw1.Text = "<font size=3>Mediclaim</font>"
            tc63sw1.HorizontalAlign = HorizontalAlign.Center
            tc63sw1.ForeColor = Drawing.Color.DarkRed
            tr6sw1.Controls.Add(tc63sw1)

            Dim tc64se1 As New TableCell
            tc64se1.Text = "<font size=3>Monthly</font>"
            tc64se1.HorizontalAlign = HorizontalAlign.Center
            tc64se1.ForeColor = Drawing.Color.DarkRed
            tr6sw1.Controls.Add(tc64se1)
            tab.Controls.Add(tr6sw1)

            Me.Pnl_Inbox.Controls.Add(tab)
        End If
        If mid = 1 Then
            dt1 = oh1.ExecuteDataSet("select query from hrm_report_master where query_id=145 and firm_id=99").Tables(0)
            Dim shar() As String = dt1.Rows(0)(0).ToString.Split("$")
            div1.Visible = False
            div2.InnerHtml = shar(0)
            div3.Visible = False
            div4.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 5 Then
            div1.Visible = False
            div2.Visible = False
            div4.Visible = False
            down1_d.Visible = True
            down2_d.Visible = False
            down3_d.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 6 Then
            div1.Visible = False
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = True
            down3_d.Visible = False
            div5.Visible = False
            div4.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 7 Then
            div1.Visible = False
            div2.Visible = False
            div4.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = True
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 8 Then
            div1.Visible = False
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 9 Then
            div1.Visible = False
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 10 Then
            div1.Visible = False
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 11 Then
            div1.Visible = False
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 12 Then
            div1.Visible = False
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 13 Then
            div1.Visible = False
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 15 Then
            div1.Visible = False
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 16 Then
            div1.Visible = True
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div4.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 17 Then
            div1.Visible = True
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div4.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 18 Then
            div1.Visible = True
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div4.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 19 Then
            div1.Visible = True
            div2.Visible = False
            down1_d.Visible = False
            down2_d.Visible = False
            down3_d.Visible = False
            div3.Visible = False
            div4.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
        End If
        If mid = 20 Then
            If Not IsPostBack Then
                div1.Visible = False
                div2.Visible = False
                down1_d.Visible = False
                down2_d.Visible = False
                down3_d.Visible = False
                div3.Visible = False
                div4.Visible = False
                div5.Visible = True
                div6.Visible = False
                div7.Visible = False
                Dim dto As DataTable = oh1.ExecuteDataSet("select '---Select---' as,0 ad from dual union all select a.emp_Code||'~'||e.emp_name,e.emp_code from incentives_allowances_dtl a,employee_master e where e.emp_code=a.emp_code and a.all_id=3 and a.rec_firm=" & Session("firm_id") & " order by ad").Tables(0)
                Me.drop.DataSource = dto
                Me.drop.DataTextField = dto.Columns(0).ColumnName
                Me.drop.DataValueField = dto.Columns(1).ColumnName
                Me.drop.DataBind()
            End If
        End If
        If mid = 22 Then
            If Not IsPostBack Then
                div1.Visible = False
                div2.Visible = False
                down1_d.Visible = False
                down2_d.Visible = False
                down3_d.Visible = False
                div3.Visible = False
                div4.Visible = False
                div5.Visible = False
                div6.Visible = True
                div7.Visible = False
            End If
        End If
        If mid = 23 Then
            If Not IsPostBack Then
                div1.Visible = False
                div2.Visible = False
                down1_d.Visible = False
                down2_d.Visible = False
                down3_d.Visible = False
                div3.Visible = False
                div4.Visible = False
                div5.Visible = False
                div6.Visible = False
                div7.Visible = True
            End If
        End If
        If mid = 2 Then
            div4.Visible = False
            div3.Visible = False
            div2.Visible = False
            div5.Visible = False
            div6.Visible = False
            div7.Visible = False
            Dim usr() As String = Session("user_id").split("!")
            Dim empcode As Integer
            empcode = usr(0)
            Dim user_id_to As String = empcode
            Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
            q_str = "select t.* from SALARY_process_upd t where t.proc_month='" & sal.Rows(0)(0) & "'"
            dt = oh1.ExecuteDataSet(q_str).Tables(0)

            Dim tab As New Table
            tab.Attributes.Add("width", "950px")
            tab.Attributes.Add("align", "center")
            tab.Attributes.Add("border", "2")

            Dim tr2 As New TableRow
            tr2.BackColor = Drawing.Color.DarkRed
            tr2.ForeColor = Drawing.Color.White
            Dim tc3 As New TableCell
            tc3.ColumnSpan = 9
            tc3.Text = "<b><i><font size=3>  PROCESS REPORT OF CURRENT MONTH  </font></i></b>"
            tc3.HorizontalAlign = HorizontalAlign.Center
            tr2.Controls.Add(tc3)
            tab.Controls.Add(tr2)


            Dim tr5 As New TableRow
            Dim tc52 As New TableCell
            tc52.Text = "<font size=3><b>Sl. No</font>"
            tc52.ForeColor = Drawing.Color.DarkRed
            tc52.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc52)

            Dim tc51 As New TableCell
            tc51.Text = "<font size=3><b>Firm</font>"
            tc51.ForeColor = Drawing.Color.DarkRed
            tc51.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc51)

            Dim tc5321 As New TableCell
            tc5321.Text = "<font size=3><b>Consolidation</font>"
            tc5321.ForeColor = Drawing.Color.DarkRed
            tc5321.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc5321)

            Dim tc5321s As New TableCell
            tc5321s.Text = "<font size=3><b>LOP Deduction</font>"
            tc5321s.ForeColor = Drawing.Color.DarkRed
            tc5321s.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc5321s)

            Dim tc5321sq As New TableCell
            tc5321sq.Text = "<font size=3><b>Allowance Merge</font>"
            tc5321sq.ForeColor = Drawing.Color.DarkRed
            tc5321sq.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc5321sq)

            Dim tc5321sq1 As New TableCell
            tc5321sq1.Text = "<font size=3><b>PF Process</font>"
            tc5321sq1.ForeColor = Drawing.Color.DarkRed
            tc5321sq1.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc5321sq1)

            Dim tc5321sq2 As New TableCell
            tc5321sq2.Text = "<font size=3><b>ESI Process</font>"
            tc5321sq2.ForeColor = Drawing.Color.DarkRed
            tc5321sq2.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc5321sq2)

            Dim tc5321sq4 As New TableCell
            tc5321sq4.Text = "<font size=3><b>Accounts Entry</font>"
            tc5321sq4.ForeColor = Drawing.Color.DarkRed
            tc5321sq4.HorizontalAlign = HorizontalAlign.Center
            tr5.Controls.Add(tc5321sq4)

            tab.Controls.Add(tr5)


            Dim dr As DataRow
            Dim count As Integer = 0
            For Each dr In dt.Rows

                count = count + 1
                Dim tr6 As New TableRow

                Dim tc61 As New TableCell
                tc61.Text = "<font size=3><b>" & count & "</font>"
                tc61.ForeColor = Drawing.Color.DarkRed
                tc61.HorizontalAlign = HorizontalAlign.Center
                tr6.Controls.Add(tc61)

                Dim tc63 As New TableCell
                tc63.Text = "<font size=3><b>" & dr(1) & "</font>"
                tc63.ForeColor = Drawing.Color.DarkRed
                tc63.HorizontalAlign = HorizontalAlign.Center
                tr6.Controls.Add(tc63)

                Dim x As String = ""
                Dim x1 As String = ""
                Dim x2 As String = ""
                Dim x3 As String = ""
                Dim x4 As String = ""
                Dim x5 As String = ""
                Dim x6 As String = ""
                Dim col As String = ""
                Dim col1 As String = ""
                Dim col2 As String = ""
                Dim col3 As String = ""
                Dim col4 As String = ""
                Dim col5 As String = ""
                Dim col6 As String = ""
                If dr(2) = 1 Then
                    x = "&#x2714;"
                    col = "#009900"
                Else
                    x = "&#9747;"
                    col = "#ff0000"
                End If

                If dr(3) = 1 Then
                    x1 = "&#x2714;"
                    col1 = "#009900"
                Else
                    x1 = "&#9747;"
                    col1 = "#ff0000"
                End If

                If dr(4) = 1 Then
                    x2 = "&#x2714;"
                    col2 = "#009900"
                Else
                    x2 = "&#9747;"
                    col2 = "#ff0000"
                End If

                If dr(5) = 1 Then
                    x3 = "&#x2714;"
                    col3 = "#009900"
                Else
                    x3 = "&#9747;"
                    col3 = "#ff0000"
                End If

                If dr(6) = 1 Then
                    x4 = "&#x2714;"
                    col4 = "#009900"
                Else
                    x4 = "&#9747;"
                    col4 = "#ff0000"
                End If

                If dr(7) = 1 Then
                    x6 = "&#x2714;"
                    col6 = "#009900"
                Else
                    x6 = "&#9747;"
                    col6 = "#ff0000"
                End If

                Dim tc64 As New TableCell
                tc64.Text = "<font style='color:" & col & ";' size=3><b>" & x & "</font>"
                tc64.HorizontalAlign = HorizontalAlign.Center
                tr6.Controls.Add(tc64)

                Dim tc641 As New TableCell
                tc641.Text = "<font style='color:" & col1 & ";' size=3><b>" & x1 & "</font>"
                tc641.HorizontalAlign = HorizontalAlign.Center
                tr6.Controls.Add(tc641)

                Dim tc642 As New TableCell
                tc642.Text = "<font style='color:" & col2 & ";' size=3><b>" & x2 & "</font>"
                tc642.HorizontalAlign = HorizontalAlign.Center
                tr6.Controls.Add(tc642)

                Dim tc643 As New TableCell
                tc643.Text = "<font style='color:" & col3 & ";' size=3><b>" & x3 & "</font>"
                tc643.HorizontalAlign = HorizontalAlign.Center
                tr6.Controls.Add(tc643)

                Dim tc644 As New TableCell
                tc644.Text = "<font style='color:" & col4 & ";' size=3><b>" & x4 & "</font>"
                tc644.HorizontalAlign = HorizontalAlign.Center
                tr6.Controls.Add(tc644)

                Dim tc646 As New TableCell
                tc646.Text = "<font style='color:" & col6 & ";' size=3><b>" & x6 & "</font>"
                tc646.HorizontalAlign = HorizontalAlign.Center
                tr6.Controls.Add(tc646)

                tr6.BackColor = Drawing.Color.FloralWhite
                tab.Controls.Add(tr6)
            Next

            Me.Pnl_Inbox.Controls.Add(tab)

        End If
        If mid = 3 Then
            div3.Visible = False
            div2.Visible = False
            div4.Visible = False
            div5.Visible = False
            div7.Visible = False
            div6.Visible = False
            If Not IsPostBack Then

                Dim usr() As String = Session("user_id").split("!")
                Dim empcode As Integer
                empcode = usr(0)
                Dim user_id_to As String = empcode
                Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                q_str = "select t.firm_id, t.firm_name, t.consol_allow, t.deduct_lop, t.merge_allow, t.pf, t.esi, t.ledg_entry, to_char(t.proc_month,'MON-YYYY') from SALARY_process_upd t where t.proc_month<>'" & sal.Rows(0)(0) & "' order by to_date(t.proc_month)"
                dt = oh1.ExecuteDataSet(q_str).Tables(0)

                Dim tab As New Table
                tab.Attributes.Add("width", "950px")
                tab.Attributes.Add("align", "center")
                tab.Attributes.Add("border", "2")

                Dim tr2 As New TableRow
                tr2.BackColor = Drawing.Color.DarkRed
                tr2.ForeColor = Drawing.Color.White
                Dim tc3 As New TableCell
                tc3.ColumnSpan = 10
                tc3.Text = "<b><i><font size=3>  PROCESS REPORT UPTO LAST MONTH </font></i></b>"
                tc3.HorizontalAlign = HorizontalAlign.Center
                tr2.Controls.Add(tc3)
                tab.Controls.Add(tr2)


                Dim tr5 As New TableRow
                Dim tc52 As New TableCell
                tc52.Text = "<font size=3><b>Sl. No</font>"
                tc52.ForeColor = Drawing.Color.DarkRed
                tc52.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc52)

                Dim tc51 As New TableCell
                tc51.Text = "<font size=3><b>Firm</font>"
                tc51.ForeColor = Drawing.Color.DarkRed
                tc51.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc51)

                Dim tc51a As New TableCell
                tc51a.Text = "<font size=3><b>Month & Year</font>"
                tc51a.ForeColor = Drawing.Color.DarkRed
                tc51a.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc51a)

                Dim tc5321 As New TableCell
                tc5321.Text = "<font size=3><b>Consolidation</font>"
                tc5321.ForeColor = Drawing.Color.DarkRed
                tc5321.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc5321)

                Dim tc5321s As New TableCell
                tc5321s.Text = "<font size=3><b>LOP Deduction</font>"
                tc5321s.ForeColor = Drawing.Color.DarkRed
                tc5321s.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc5321s)

                Dim tc5321sq As New TableCell
                tc5321sq.Text = "<font size=3><b>Allowance Merge</font>"
                tc5321sq.ForeColor = Drawing.Color.DarkRed
                tc5321sq.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc5321sq)

                Dim tc5321sq1 As New TableCell
                tc5321sq1.Text = "<font size=3><b>PF Process</font>"
                tc5321sq1.ForeColor = Drawing.Color.DarkRed
                tc5321sq1.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc5321sq1)

                Dim tc5321sq2 As New TableCell
                tc5321sq2.Text = "<font size=3><b>ESI Process</font>"
                tc5321sq2.ForeColor = Drawing.Color.DarkRed
                tc5321sq2.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc5321sq2)

                Dim tc5321sq4 As New TableCell
                tc5321sq4.Text = "<font size=3><b>Accounts Entry</font>"
                tc5321sq4.ForeColor = Drawing.Color.DarkRed
                tc5321sq4.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc5321sq4)

                tab.Controls.Add(tr5)

                Dim dr As DataRow
                Dim count As Integer = 0
                For Each dr In dt.Rows

                    count = count + 1
                    Dim tr6 As New TableRow

                    Dim tc61 As New TableCell
                    tc61.Text = "<font size=3><b>" & count & "</font>"
                    tc61.ForeColor = Drawing.Color.DarkRed
                    tc61.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc61)

                    Dim tc63 As New TableCell
                    tc63.Text = "<font size=3><b>" & dr(1) & "</font>"
                    tc63.ForeColor = Drawing.Color.DarkRed
                    tc63.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc63)

                    Dim tc63a As New TableCell
                    tc63a.Text = "<font size=3><b>" & dr(8) & "</font>"
                    tc63a.ForeColor = Drawing.Color.DarkRed
                    tc63a.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc63a)

                    Dim x As String = ""
                    Dim x1 As String = ""
                    Dim x2 As String = ""
                    Dim x3 As String = ""
                    Dim x4 As String = ""
                    Dim x5 As String = ""
                    Dim x6 As String = ""
                    Dim col As String = ""
                    Dim col1 As String = ""
                    Dim col2 As String = ""
                    Dim col3 As String = ""
                    Dim col4 As String = ""
                    Dim col5 As String = ""
                    Dim col6 As String = ""
                    If dr(2) = 1 Then
                        x = "&#x2714;"
                        col = "#009900"
                    Else
                        x = "&#9747;"
                        col = "#ff0000"
                    End If

                    If dr(3) = 1 Then
                        x1 = "&#x2714;"
                        col1 = "#009900"
                    Else
                        x1 = "&#9747;"
                        col1 = "#ff0000"
                    End If

                    If dr(4) = 1 Then
                        x2 = "&#x2714;"
                        col2 = "#009900"
                    Else
                        x2 = "&#9747;"
                        col2 = "#ff0000"
                    End If

                    If dr(5) = 1 Then
                        x3 = "&#x2714;"
                        col3 = "#009900"
                    Else
                        x3 = "&#9747;"
                        col3 = "#ff0000"
                    End If

                    If dr(6) = 1 Then
                        x4 = "&#x2714;"
                        col4 = "#009900"
                    Else
                        x4 = "&#9747;"
                        col4 = "#ff0000"
                    End If

                    If dr(7) = 1 Then
                        x5 = "&#x2714;"
                        col5 = "#009900"
                    Else
                        x5 = "&#9747;"
                        col5 = "#ff0000"
                    End If

                    Dim tc64 As New TableCell
                    tc64.Text = "<font style='color:" & col & ";' size=3><b>" & x & "</font>"
                    tc64.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc64)

                    Dim tc641 As New TableCell
                    tc641.Text = "<font style='color:" & col1 & ";' size=3><b>" & x1 & "</font>"
                    tc641.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc641)

                    Dim tc642 As New TableCell
                    tc642.Text = "<font style='color:" & col2 & ";' size=3><b>" & x2 & "</font>"
                    tc642.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc642)

                    Dim tc643 As New TableCell
                    tc643.Text = "<font style='color:" & col3 & ";' size=3><b>" & x3 & "</font>"
                    tc643.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc643)

                    Dim tc644 As New TableCell
                    tc644.Text = "<font style='color:" & col4 & ";' size=3><b>" & x4 & "</font>"
                    tc644.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc644)

                    Dim tc645 As New TableCell
                    tc645.Text = "<font style='color:" & col5 & ";' size=3><b>" & x5 & "</font>"
                    tc645.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc645)

                    tr6.BackColor = Drawing.Color.FloralWhite
                    tab.Controls.Add(tr6)
                Next
                Me.Pnl_Inbox.Controls.Add(tab)
            End If
        End If
        If mid = 24 Then
            div3.Visible = False
            div2.Visible = False
            div4.Visible = False
            div5.Visible = False
            div7.Visible = False
            div6.Visible = False
            If Not IsPostBack Then

                Dim usr() As String = Session("user_id").split("!")
                Dim empcode As Integer
                empcode = usr(0)
                Dim user_id_to As String = empcode
                Dim jio As DataTable = oh1.ExecuteDataSet("select distinct '1-' || to_char(add_months(to_char(sal_dt), 0), 'MON-YYYY'), to_char(last_day(to_date(sal_dt))) from mactech.m_wage where firm_id =" & Session("firm_id") & "").Tables(0)
                dt1 = oh1.ExecuteDataSet("select query from hrm_report_master where query_id=145 and firm_id=99").Tables(0)
                Dim sp As String = dt1.Rows(0)(0).ToString.Split("$")(2).Replace("frdt", jio.Rows(0)(0))
                sp = sp.Replace("todt", jio.Rows(0)(1))
                dt = oh1.ExecuteDataSet(sp).Tables(0)

                Dim tab As New Table
                tab.Attributes.Add("width", "950px")
                tab.Attributes.Add("align", "center")
                tab.Attributes.Add("border", "2")

                Dim tr2 As New TableRow
                tr2.BackColor = Drawing.Color.DarkRed
                tr2.ForeColor = Drawing.Color.White
                Dim tc3 As New TableCell
                tc3.ColumnSpan = 10
                tc3.Text = "<b><i><font size=3>Basic Pay Variant Employees </font></i></b>"
                tc3.HorizontalAlign = HorizontalAlign.Center
                tr2.Controls.Add(tc3)
                tab.Controls.Add(tr2)


                Dim tr5 As New TableRow
                Dim tc52 As New TableCell
                tc52.Text = "<font size=3><b>Sl. No</font>"
                tc52.ForeColor = Drawing.Color.DarkRed
                tc52.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc52)

                Dim tc51 As New TableCell
                tc51.Text = "<font size=3><b>Emp Code</font>"
                tc51.ForeColor = Drawing.Color.DarkRed
                tc51.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc51)

                Dim tc51a As New TableCell
                tc51a.Text = "<font size=3><b>Emp Name</font>"
                tc51a.ForeColor = Drawing.Color.DarkRed
                tc51a.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc51a)

                Dim tc5321 As New TableCell
                tc5321.Text = "<font size=3><b>Remarks</font>"
                tc5321.ForeColor = Drawing.Color.DarkRed
                tc5321.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc5321)

                Dim tc5321q As New TableCell
                tc5321q.Text = "<font size=3><b>Effective Date</font>"
                tc5321q.ForeColor = Drawing.Color.DarkRed
                tc5321q.HorizontalAlign = HorizontalAlign.Center
                tr5.Controls.Add(tc5321q)

                tab.Controls.Add(tr5)


                Dim dr As DataRow
                Dim count As Integer = 0
                For Each dr In dt.Rows

                    count = count + 1
                    Dim tr6 As New TableRow

                    Dim tc61 As New TableCell
                    tc61.Text = "<font size=3>" & count & "</font>"
                    tc61.ForeColor = Drawing.Color.DarkRed
                    tc61.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc61)

                    Dim tc63 As New TableCell
                    tc63.Text = "<font size=3>" & dr(0) & "</font>"
                    tc63.ForeColor = Drawing.Color.DarkRed
                    tc63.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc63)

                    Dim tc63a As New TableCell
                    tc63a.Text = "<font size=3>" & dr(1) & "</font>"
                    tc63a.ForeColor = Drawing.Color.DarkRed
                    tc63a.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc63a)

                    Dim tc64 As New TableCell
                    tc64.Text = "<font size=3>" & dr(2) & "</font>"
                    tc64.ForeColor = Drawing.Color.DarkRed
                    tc64.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc64)

                    Dim tc64q As New TableCell
                    tc64q.Text = "<font size=3>" & dr(3) & "</font>"
                    tc64q.ForeColor = Drawing.Color.DarkRed
                    tc64q.HorizontalAlign = HorizontalAlign.Center
                    tr6.Controls.Add(tc64q)

                    tab.Controls.Add(tr6)
                Next
                Me.Pnl_Inbox.Controls.Add(tab)
            End If
        End If
    End Sub

    Protected Sub down1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles down1_d.Click
        Dim spd As DataTable = oh1.ExecuteDataSet("select t.query from MACTECH.HRM_REPORT_MASTER t where t.firm_id=8 and t.query_id=7").Tables(0)
        Dim dt3 As DataTable = oh1.ExecuteDataSet(spd.Rows(0)(0)).Tables(0)
        If dt3.Rows.Count > 0 Then
            grid.DataSource = dt3
            grid.DataBind()
            Response.ClearContent()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Salary Data" + " " + DateTime.Now.ToString("MMM-yyyy" + " " + "hh:mm tt") + ".xls"))
            Response.ContentType = "application/ms-excel"
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            grid.AllowPaging = False
            grid.HeaderRow.Style.Add("background-color", "#FFFFFF")
            For i As Integer = 0 To grid.HeaderRow.Cells.Count - 1
                grid.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
            Next
            grid.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.[End]()
        End If
    End Sub
    Protected Sub down2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles down2_d.Click
        Dim spd As DataTable = oh1.ExecuteDataSet("select t.query from MACTECH.HRM_REPORT_MASTER t where t.firm_id=8 and t.query_id=29").Tables(0)
        Dim dt3 As DataTable = oh1.ExecuteDataSet(spd.Rows(0)(0)).Tables(0)
        If dt3.Rows.Count > 0 Then
            grid.DataSource = dt3
            grid.DataBind()
            Response.ClearContent()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Initial Allowance Data" + " " + DateTime.Now.ToString("MMM-yyyy" + " " + "hh:mm tt") + ".xls"))
            Response.ContentType = "application/ms-excel"
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            grid.AllowPaging = False
            grid.HeaderRow.Style.Add("background-color", "#FFFFFF")
            For i As Integer = 0 To grid.HeaderRow.Cells.Count - 1
                grid.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
            Next
            grid.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.[End]()
        End If
    End Sub
    Protected Sub down3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles down3_d.Click
        Dim spd As DataTable = oh1.ExecuteDataSet("select t.query from MACTECH.HRM_REPORT_MASTER t where t.firm_id=8 and t.query_id=11").Tables(0)
        Dim dt3 As DataTable = oh1.ExecuteDataSet(spd.Rows(0)(0)).Tables(0)
        If dt3.Rows.Count > 0 Then
            grid.DataSource = dt3
            grid.DataBind()
            Response.ClearContent()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Final Allowance Data" + " " + DateTime.Now.ToString("MMM-yyyy" + " " + "hh:mm tt") + ".xls"))
            Response.ContentType = "application/ms-excel"
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            grid.AllowPaging = False
            grid.HeaderRow.Style.Add("background-color", "#FFFFFF")
            For i As Integer = 0 To grid.HeaderRow.Cells.Count - 1
                grid.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
            Next
            grid.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.[End]()
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim ops, ops1 As DataTable
        Dim dr As DataRow
        Dim cal_data = eventArgument
        Dim menu() As String = cal_data.ToString.Split("#")
        Try
            If menu(0) = 0 Then
                Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                ops = oh1.ExecuteDataSet("select t.consol_allow,t.deduct_lop,t.merge_allow,t.pf,t.esi,t.ledg_entry from SALARY_PROCESS_UPD t where t.proc_month='" & sal.Rows(0)(0) & "'").Tables(0)
                ops1 = oh1.ExecuteDataSet("select count(*) from m_wage t where t.sal_dt='" & sal.Rows(0)(0) & "' and tds>0 and rec_firm=" & Session("firm_id") & "").Tables(0)
                Dim csw As DataTable = oh1.ExecuteDataSet("select count(*) from SALARY_PROCESS_UPD where ledg_entry=1 and proc_month='" & sal.Rows(0)(0) & "'").Tables(0)
                If csw.Rows(0)(0) > 0 AndAlso (menu(1) = 8 Or menu(1) = 9 Or menu(1) = 10 Or menu(1) = 11 Or menu(1) = 12 Or menu(1) = 13 Or menu(1) = 15) Then
                    CbResult = "EP"
                ElseIf ops.Rows(0)(0) = 0 And menu(1) = 10 Then
                    CbResult = "C"
                ElseIf ops.Rows(0)(1) = 0 And menu(1) = 11 Then
                    CbResult = "D"
                ElseIf ops.Rows(0)(2) = 0 And menu(1) = 12 Then
                    CbResult = "M"
                ElseIf ops.Rows(0)(3) = 0 And menu(1) = 13 Then
                    CbResult = "P"
                ElseIf ops.Rows(0)(4) = 0 And menu(1) = 15 Then
                    CbResult = "ESI"
                ElseIf ops1.Rows(0)(0) = 0 And menu(1) = 11 Then
                    CbResult = "T"
                ElseIf menu(1) = 9 And ops.Rows(0)(0) = 1 Then
                    CbResult = "AC"
                ElseIf menu(1) = 10 And ops.Rows(0)(1) = 1 Then
                    CbResult = "AD"
                ElseIf menu(1) = 11 And ops.Rows(0)(2) = 1 Then
                    CbResult = "AM"
                ElseIf menu(1) = 12 And ops.Rows(0)(3) = 1 Then
                    CbResult = "AP"
                ElseIf menu(1) = 13 And ops.Rows(0)(4) = 1 Then
                    CbResult = "AE"
                ElseIf menu(1) = 15 And ops.Rows(0)(5) = 1 Then
                    CbResult = "AL"
                ElseIf ops.Rows(0)(2) = 1 And menu(1) = 8 Then
                    CbResult = "MR"
                ElseIf ops.Rows(0)(3) = 1 And menu(1) = 8 Then
                    CbResult = "PR"
                ElseIf ops.Rows(0)(4) = 1 And menu(1) = 8 Then
                    CbResult = "ER"
                ElseIf ops.Rows(0)(5) = 1 And menu(1) = 8 Then
                    CbResult = "LR"
                ElseIf menu(1) = 15 And ops.Rows(0)(5) = 0 Then
                    CbResult = "L"
                ElseIf menu(1) = 16 And ops.Rows(0)(3) = 0 Then
                    CbResult = "PFN"
                ElseIf menu(1) = 17 And ops.Rows(0)(3) = 0 Then
                    CbResult = "PFN"
                ElseIf menu(1) = 18 And ops.Rows(0)(4) = 0 Then
                    CbResult = "ESN"
                ElseIf menu(1) = 19 And ops.Rows(0)(4) = 0 Then
                    CbResult = "ESN"
                ElseIf menu(1) = 20 And ops.Rows(0)(0) = 0 Then
                    CbResult = "CNO"
                ElseIf menu(1) = 16 Then
                    Dim cs As DataTable = oh1.ExecuteDataSet("select count(*) from SALARY_PROCESS_UPD where ledg_entry=1 and proc_month='" & sal.Rows(0)(0) & "'").Tables(0)
                    If cs.Rows(0)(0) = 0 Then
                        ops = oh1.ExecuteDataSet("select t.emp_code||'*'||t.name||'*'||nvl(t.p_fund,0)||'*'||nvl(t.e_pf,0) from mactech.m_wage t where t.rec_firm=" & Session("firm_id") & " and nvl(t.p_fund,0)>0 order by t.emp_code").Tables(0)
                        str_tkn.Append("PFYD#")
                        For Each dr In ops.Rows
                            str_tkn.Append(dr(0))
                            str_tkn.Append("!")
                        Next
                    Else
                        str_tkn.Append("EP")
                    End If
                    CbResult = str_tkn.ToString
                ElseIf menu(1) = 17 Then
                    Dim cs As DataTable = oh1.ExecuteDataSet("select count(*) from SALARY_PROCESS_UPD where ledg_entry=1 and proc_month='" & sal.Rows(0)(0) & "'").Tables(0)
                    If cs.Rows(0)(0) = 0 Then
                        ops = oh1.ExecuteDataSet("select t.emp_code||'*'||t.name||'*'||nvl(t.p_fund,0)||'*'||nvl(t.e_pf,0) from mactech.m_wage t where t.rec_firm=" & Session("firm_id") & " and nvl(t.p_fund,0)=0 order by t.emp_code").Tables(0)
                        str_tkn.Append("PFYA#")
                        For Each dr In ops.Rows
                            str_tkn.Append(dr(0))
                            str_tkn.Append("!")
                        Next
                    Else
                        str_tkn.Append("EP")
                    End If
                    CbResult = str_tkn.ToString
                ElseIf menu(1) = 18 Then
                    Dim cs As DataTable = oh1.ExecuteDataSet("select count(*) from SALARY_PROCESS_UPD where ledg_entry=1 and proc_month='" & sal.Rows(0)(0) & "'").Tables(0)
                    If cs.Rows(0)(0) = 0 Then
                        ops = oh1.ExecuteDataSet("select t.emp_code||'*'||t.name||'*'||nvl(t.esi,0)||'*'||nvl(t.e_esi,0) from mactech.m_wage t where t.rec_firm=" & Session("firm_id") & " and nvl(t.esi,0)>0 order by t.emp_code").Tables(0)
                        str_tkn.Append("ESYD#")
                        For Each dr In ops.Rows
                            str_tkn.Append(dr(0))
                            str_tkn.Append("!")
                        Next
                    Else
                        str_tkn.Append("EP")
                    End If
                    CbResult = str_tkn.ToString
                ElseIf menu(1) = 19 Then
                    Dim cs As DataTable = oh1.ExecuteDataSet("select count(*) from SALARY_PROCESS_UPD where ledg_entry=1 and proc_month='" & sal.Rows(0)(0) & "'").Tables(0)
                    If cs.Rows(0)(0) = 0 Then
                        ops = oh1.ExecuteDataSet("select t.emp_code||'*'||t.name||'*'||nvl(t.esi,0)||'*'||nvl(t.e_esi,0) from mactech.m_wage t where t.rec_firm=" & Session("firm_id") & " and nvl(t.esi,0)=0 order by t.emp_code").Tables(0)
                        str_tkn.Append("ESYA#")
                        For Each dr In ops.Rows
                            str_tkn.Append(dr(0))
                            str_tkn.Append("!")
                        Next
                    Else
                        str_tkn.Append("EP")
                    End If
                    CbResult = str_tkn.ToString
                ElseIf menu(1) = 20 Then
                    Dim cs As DataTable = oh1.ExecuteDataSet("select count(*) from SALARY_PROCESS_UPD where ledg_entry=1 and proc_month='" & sal.Rows(0)(0) & "'").Tables(0)
                    If cs.Rows(0)(0) = 0 Then

                    Else
                        str_tkn.Append("EP")
                    End If
                    CbResult = str_tkn.ToString
                End If
                Dim shar As DataTable = oh1.ExecuteDataSet("select emp_name from employee_master where emp_code=" & Session("user_id").ToString.Split("!")(0) & "").Tables(0)
                CbResult = CbResult + "{" + shar.Rows(0)(0).ToString
            ElseIf menu(0) = 8 Then
                ops = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim str() As String = menu(1).ToString.Split("@")
                Dim shar As Integer = -1
                For i As Integer = 0 To str.Length - 1
                    Dim ptr() As String = str(i).ToString.Split("$")
                    Dim op(3) As OracleParameter
                    op(0) = New OracleParameter("emp", OracleType.Number)
                    op(0).Value = ptr(0)
                    op(0).Direction = ParameterDirection.Input
                    op(1) = New OracleParameter("choice", OracleType.Number)
                    op(1).Value = ptr(1)
                    op(1).Direction = ParameterDirection.Input
                    op(2) = New OracleParameter("saldt", OracleType.DateTime)
                    op(2).Value = CDate(ops.Rows(0)(0))
                    op(2).Direction = ParameterDirection.Input
                    op(3) = New OracleParameter("msg", OracleType.VarChar, 500)
                    op(3).Direction = ParameterDirection.Output
                    oh1.ExecuteNonQuery("pf_esi_add_cancel", op)
                    If op(3).Value.ToString.StartsWith("SUCCESSFULLY") Then
                        s = s * 1
                    Else
                        s = s * 0
                    End If
                    shar = ptr(1)
                Next
                If s <> 0 Then
                    CbResult = "Y#" & shar
                Else
                    CbResult = "N#" & shar
                End If
            ElseIf menu(0) = 9 Then
                ops = oh1.ExecuteDataSet("select emp_name from employee_master where emp_code=" & menu(1) & "").Tables(0)
                CbResult = "Y#" & ops.Rows(0)(0)
            ElseIf menu(0) = 10 Then
                Dim ddlVal As String
                ddlVal = menu(1)

                If ddlVal = "1" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.arrear_sal from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.arrear_sal>0 and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString

                ElseIf ddlVal = "2" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.arrear_da from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.arrear_da > 0 and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString

                ElseIf ddlVal = "3" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.oth_add from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.oth_add > 0 and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString

                ElseIf ddlVal = "4" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.remark_add from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.remark_add is not null and s.remark_add<>'0' and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString

                ElseIf ddlVal = "5" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.lic from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.lic> 0 and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString

                ElseIf ddlVal = "6" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.p_tax from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.p_tax> 0 and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString

                ElseIf ddlVal = "7" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.tds from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.tds> 0 and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString

                ElseIf ddlVal = "8" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.oth_ded from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.oth_ded> 0 and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString

                ElseIf ddlVal = "9" Then

                    fgt = oh1.ExecuteDataSet("select e.emp_code || '*' || e.emp_name|| '*'||s.remark_ded from employee_master e,employ_sal_add s where e.emp_code=s.emp_id and s.remark_ded is not null and s.remark_ded<>'0' and e.emp_code in(select emp_code from employ_firm where firm_id=" & Session("firm_id") & ") order by e.emp_code").Tables(0)
                    Dim drw As DataRow

                    For Each drw In fgt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString


                End If
            ElseIf cal_data = 1 Then
                ops = oh1.ExecuteDataSet("select distinct to_char(add_months( to_char(sal_dt),-1)) from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim op(1) As OracleParameter
                op(0) = New OracleParameter("salarydt", OracleType.DateTime)
                op(0).Value = CDate(ops.Rows(0)(0))
                op(0).Direction = ParameterDirection.Input
                op(1) = New OracleParameter("msg", OracleType.VarChar, 500)
                op(1).Direction = ParameterDirection.Output
                oh1.ExecuteNonQuery("salary_process1_macom", op)
                If op(1).Value.ToString.StartsWith("Failed") Or op(1).Value.ToString.StartsWith("Success") Then
                    CbResult = "Y"
                Else
                    CbResult = "N"
                End If
            ElseIf cal_data = 2 Then
                Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim op(1) As OracleParameter
                op(0) = New OracleParameter("frm", OracleType.Number)
                op(0).Value = CInt(Session("firm_id"))
                op(0).Direction = ParameterDirection.Input
                op(1) = New OracleParameter("msg", OracleType.VarChar, 500)
                op(1).Direction = ParameterDirection.Output
                oh1.ExecuteNonQuery("hrm_insert_ta", op)
                If op(1).Value.ToString.StartsWith("SUCCESS") Then
                    oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.consol_allow=1 where t.proc_month='" & sal.Rows(0)(0) & "'")
                    CbResult = "Y"
                Else
                    CbResult = "N"
                End If
            ElseIf cal_data = 3 Then
                ops = oh1.ExecuteDataSet("select distinct '21-'||to_char(add_months( to_char(sal_dt),-1),'MON-YYYY'),'20-'||to_char(add_months( to_char(sal_dt),0),'MON-YYYY') from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim op(3) As OracleParameter
                op(0) = New OracleParameter("frdt", OracleType.DateTime)
                op(0).Value = CDate(ops.Rows(0)(0))
                op(0).Direction = ParameterDirection.Input
                op(1) = New OracleParameter("todt", OracleType.DateTime)
                op(1).Value = CDate(ops.Rows(0)(1))
                op(1).Direction = ParameterDirection.Input
                op(2) = New OracleParameter("FRM", OracleType.Number)
                op(2).Value = CInt(Session("firm_id"))
                op(2).Direction = ParameterDirection.Input
                op(3) = New OracleParameter("flag", OracleType.Number)
                op(3).Direction = ParameterDirection.Output
                oh1.ExecuteNonQuery("LEAVE_AMT_DEDUCT_MACOM_may", op)
                If op(3).Value = 1 Then
                    Dim sale As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                    oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.deduct_lop=2 where t.proc_month='" & sal.Rows(0)(0) & "'")
                    Dim ope(2) As OracleParameter
                    ope(0) = New OracleParameter("sal_month_last_dt", OracleType.DateTime)
                    ope(0).Value = CDate(sale.Rows(0)(0))
                    ope(0).Direction = ParameterDirection.Input
                    ope(1) = New OracleParameter("firmid", OracleType.Number)
                    ope(1).Value = CInt(Session("firm_id"))
                    ope(1).Direction = ParameterDirection.Input
                    ope(2) = New OracleParameter("flag", OracleType.Number)
                    ope(2).Direction = ParameterDirection.Output
                    oh1.ExecuteNonQuery("ALLOWANCE_ARREAR_MACOM", ope)
                    If ope(2).Value = 1 Then
                        oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.deduct_lop=1 where t.proc_month='" & sal.Rows(0)(0) & "'")
                        CbResult = "Y"
                    Else
                        CbResult = "N"
                    End If
                    CbResult = "Y"
                Else
                    CbResult = "N"
                End If
            ElseIf cal_data = 4 Then
                Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim op(1) As OracleParameter
                op(0) = New OracleParameter("FRM", OracleType.Number)
                op(0).Value = CInt(Session("firm_id"))
                op(0).Direction = ParameterDirection.Input
                op(1) = New OracleParameter("flag", OracleType.Number)
                op(1).Direction = ParameterDirection.Output
                oh1.ExecuteNonQuery("M_WAGE_UPDATE1", op)
                If op(1).Value = 1 Then
                    oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.merge_allow=1 where t.proc_month='" & sal.Rows(0)(0) & "'")
                    CbResult = "Y"
                Else
                    CbResult = "N"
                End If
            ElseIf cal_data = 5 Then
                Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim op(1) As OracleParameter
                op(0) = New OracleParameter("FRM", OracleType.Number)
                op(0).Value = CInt(Session("firm_id"))
                op(0).Direction = ParameterDirection.Input
                op(1) = New OracleParameter("flag", OracleType.Number)
                op(1).Direction = ParameterDirection.Output
                oh1.ExecuteNonQuery("Salary_pf_update_macom", op)
                If op(1).Value = 1 Then
                    oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.pf=1 where t.proc_month='" & sal.Rows(0)(0) & "'")
                    CbResult = "Y"
                Else
                    CbResult = "N"
                End If
            ElseIf cal_data = 6 Then
                ops = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim op(2) As OracleParameter
                op(0) = New OracleParameter("FRM", OracleType.Number)
                op(0).Value = CInt(Session("firm_id"))
                op(0).Direction = ParameterDirection.Input
                op(1) = New OracleParameter("saldt", OracleType.DateTime)
                op(1).Value = CDate(ops.Rows(0)(0))
                op(1).Direction = ParameterDirection.Input
                op(2) = New OracleParameter("flag", OracleType.Number)
                op(2).Direction = ParameterDirection.Output
                oh1.ExecuteNonQuery("Salary_Esi_update_macom", op)
                If op(2).Value = 1 Then
                    oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.esi=1 where t.proc_month='" & sal.Rows(0)(0) & "'")
                    CbResult = "Y"
                Else
                    CbResult = "N"
                End If
            ElseIf cal_data = 7 Then
                Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                Dim op(1) As OracleParameter
                op(0) = New OracleParameter("FRM", OracleType.Number)
                op(0).Value = CInt(Session("firm_id"))
                op(0).Direction = ParameterDirection.Input
                op(1) = New OracleParameter("msg", OracleType.VarChar, 500)
                op(1).Direction = ParameterDirection.Output
                oh1.ExecuteNonQuery("HRMSALARYUPDATE", op)
                oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.ledg_entry=3,t.proc_done_by=" & Session("user_id").ToString.Split("!")(0) & " where t.proc_month='" & sal.Rows(0)(0) & "'")
                If op(1).Value.ToString.StartsWith("SUCCESS") Then
                    ops = oh1.ExecuteDataSet("select distinct to_char(sal_dt,'MON YYYY')from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
                    Dim opw(1) As OracleParameter
                    opw(0) = New OracleParameter("mon", OracleType.VarChar, 500)
                    opw(0).Value = ops.Rows(0)(0)
                    opw(0).Direction = ParameterDirection.Input
                    opw(1) = New OracleParameter("frm", OracleType.Number)
                    opw(1).Value = CInt(Session("firm_id"))
                    opw(1).Direction = ParameterDirection.Input
                    oh1.ExecuteNonQuery("SALARY_PROCESS_ENTRIES", opw)
                    oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.ledg_entry=2,t.proc_done_by=" & Session("user_id").ToString.Split("!")(0) & " where t.proc_month='" & sal.Rows(0)(0) & "'")

                    Dim opwa(1) As OracleParameter
                    opwa(0) = New OracleParameter("mon", OracleType.VarChar, 500)
                    opwa(0).Value = ops.Rows(0)(0)
                    opwa(0).Direction = ParameterDirection.Input
                    opwa(1) = New OracleParameter("frm", OracleType.Number)
                    opwa(1).Value = CInt(Session("firm_id"))
                    opwa(1).Direction = ParameterDirection.Input
                    oh1.ExecuteNonQuery("INCENTIVE_PROCESS_ENTRIES", opwa)
                    oh1.ExecuteNonQuery("update SALARY_PROCESS_UPD t set t.ledg_entry=1,t.proc_done_by=" & Session("user_id").ToString.Split("!")(0) & " where t.proc_month='" & sal.Rows(0)(0) & "'")
                    Dim names As DataTable = oh1.ExecuteDataSet("select upper(emp_name) from employee_master where emp_code=" & Session("user_id").ToString.Split("!")(0) & "").Tables(0)
                    CbResult = "Y#" + names.Rows(0)(0)
                Else
                    CbResult = "N"
                End If
            End If
        Catch ex As Exception
            CbResult = "E"
        End Try
    End Sub

    Protected Sub drop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drop.SelectedIndexChanged
        Me.txt_amount.Text = ""
        If drop.SelectedValue = 0 Then
            trowam.Visible = True
            Me.lab.Text = "Rs. 0.00"
            Me.msge.Text = "Please Select Any Employee!!!"
            Me.msge.ForeColor = Drawing.Color.Red
            Me.Button3.Enabled = False
        Else
            trowam.Visible = False
            Dim opd As DataTable = oh1.ExecuteDataSet("select 'Rs. '||to_char(all_amount)||'.00' from incentives_allowances_dtl where emp_code=" & drop.SelectedValue & " and all_id=3").Tables(0)
            Me.lab.Text = opd.Rows(0)(0)
            Me.Button3.Enabled = True
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sal As DataTable = oh1.ExecuteDataSet("select distinct to_char(sal_dt)from m_wage where firm_id=" & Session("firm_id") & "").Tables(0)
        Dim ops As DataTable = oh1.ExecuteDataSet("select t.consol_allow,t.deduct_lop,t.merge_allow,t.pf,t.esi,t.ledg_entry from SALARY_PROCESS_UPD t where t.proc_month='" & sal.Rows(0)(0) & "'").Tables(0)
        If drop.SelectedValue = 0 Then
            trowam.Visible = True
            Me.msge.Text = "Please Select Any Employee!!!"
            Me.msge.ForeColor = Drawing.Color.Red

        ElseIf ops.Rows(0)(1) = 0 Then
            trowam.Visible = True
            Me.msge.Text = "Please Do LOP Deduction First"
            Me.msge.ForeColor = Drawing.Color.Red

        ElseIf Me.txt_amount.Text = "" Or Me.txt_amount.Text = "0" Then
            trowam.Visible = True
            Me.msge.Text = "Amount Must Be Greater Than zero"
            Me.msge.ForeColor = Drawing.Color.Red
        Else
            trowam.Visible = False
            Dim s1 As Integer = oh1.ExecuteNonQuery("update incentives_allowances_dtl set all_amount=" & Me.txt_amount.Text & " where emp_code=" & drop.SelectedValue & " and all_id=3")
            If s1 = 1 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('Successfully Updated');")
                cl_script1.Append("window.open('salary_master.aspx?mid=20','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("alert('Successfully Updated');")
                cl_script1.Append("window.open('salary_master.aspx?mid=20','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.text1.Text = "" Or Me.text2.Text = "" Then
            tr4.Visible = True
            Me.Label2.Text = "Please Select From Date & To Date!!!"
            Me.Label2.ForeColor = Drawing.Color.Red
        ElseIf CDate(Me.text2.Text) < CDate(Me.text1.Text) Then
            tr4.Visible = True
            Me.Label2.Text = "From Date Must Be Less Than To Date"
            Me.Label2.ForeColor = Drawing.Color.Red
        ElseIf (CDate(Me.text2.Text) > CDate(Date.Today)) Or (CDate(Me.text1.Text) > CDate(Date.Today)) Then
            tr4.Visible = True
            Me.Label2.Text = "Cannot Select Future Dates!!!"
            Me.Label2.ForeColor = Drawing.Color.Red
            Me.text2.Text = ""
            Me.text1.Text = ""
        Else
            tr4.Visible = True
            dt1 = oh1.ExecuteDataSet("select query from hrm_report_master where query_id=145 and firm_id=99").Tables(0)
            Dim sp As String = dt1.Rows(0)(0).ToString.Split("$")(1).Replace("fromdt", Me.text1.Text)
            sp = sp.Replace("todt", Me.text2.Text)
            Dim dt3 As DataTable = oh1.ExecuteDataSet(sp).Tables(0)
            If dt3.Rows.Count > 0 Then
                grid.DataSource = dt3
                grid.DataBind()
                Response.ClearContent()
                Response.Buffer = True
                Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Leave Availed Data" + " " + DateTime.Now.ToString("MMM-yyyy" + " " + "hh:mm tt") + ".xls"))
                Response.ContentType = "application/ms-excel"
                Dim sw As New StringWriter()
                Dim htw As New HtmlTextWriter(sw)
                grid.AllowPaging = False
                grid.HeaderRow.Style.Add("background-color", "#FFFFFF")
                For i As Integer = 0 To grid.HeaderRow.Cells.Count - 1
                    grid.HeaderRow.Cells(i).Style.Add("background-color", "#00BFFF")
                Next
                grid.RenderControl(htw)
                Me.Label2.Text = "Successfully Generated"
                Response.Write(sw.ToString())
                Response.[End]()
            Else
                Me.Label2.Text = "No Data Found!"
                Me.Label2.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If Me.rdDelete.Checked = True Then

            Try
                Dim p(2) As OracleParameter

                p(0) = New OracleParameter("Dataa", OracleType.VarChar, 5000)
                p(0).Value = Me.hdnToSendDel.Value

                p(1) = New OracleParameter("Ins", OracleType.Number, 2)
                p(1).Value = Me.hdnDelChange.Value

                p(2) = New OracleParameter("Errmsg", OracleType.VarChar, 400)
                p(2).Direction = ParameterDirection.Output

                oh1.ExecuteNonQuery("HRM_SALINS_DEL_MAC", p)

                cl_sct.Append("         alert('" & p(2).Value & "');")
                cl_sct.Append(" window.open('salary_master.aspx?mid=23','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_sct.ToString, True)

            Catch ex As Exception
            End Try

        Else

            Try
                Dim p(1) As OracleParameter

                p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                p(0).Value = Me.hdnAdd.Value

                p(1) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                p(1).Direction = ParameterDirection.Output

                oh1.ExecuteNonQuery("HRM_SALINS_ADDDED_MAC", p)

                cl_sct.Append("         alert('" & p(1).Value & "');")
                cl_sct.Append(" window.open('salary_master.aspx?mid=23','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_sct.ToString, True)

            Catch ex As Exception
            End Try

        End If
    End Sub
End Class
