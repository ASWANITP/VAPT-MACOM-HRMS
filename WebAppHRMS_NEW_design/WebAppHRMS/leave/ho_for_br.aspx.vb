Imports System.Data
Imports System.Data.OracleClient
Partial Class punching_ho_for_br_634273e19131
    Inherits System.Web.UI.Page
    Dim SQL As String
    Dim OH As New Helper.Oracle.OracleHelper
    Dim dt2 As New DataTable
    Dim dr As DataRow
    Dim A As New Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'SQL = "select branch_id,branch_name from branch_master where status_id=1 and branch_id<>0 order by branch_name"
            'Dim dt1 As New DataTable
            'dt1 = OH.ExecuteDataSet(SQL).Tables(0)
            'Me.cmb_branch.DataSource = dt1
            'Me.cmb_branch.DataTextField = dt1.Columns(1).ColumnName
            'Me.cmb_branch.DataValueField = dt1.Columns(0).ColumnName
            'Me.cmb_branch.DataBind()
            'Me.Label1.Text = ""
            'Me.TD1.Visible = False
            'Me.TD2.Visible = False
            'SQL = "select parmtr_value from general_parameter where module_id=90 and parmtr_id=1"
            'Dim d23 As New DataTable
            'd23 = OH.ExecuteDataSet(SQL).Tables(0)
            'Me.txt_cntd.Text = d23.Rows(0)(0)
            'Me.txt_cnt.Text = 0
            FILL()
        End If
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_hid.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
    End Sub

    Protected Sub cmb_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Label1.Text = ""
        Me.Hidden1.Value = ""
        Me.txt_hid.Text = ""
        Me.Hid_id.Value = ""
        Me.Label1.Text = ""
        'SQL = "select DISTINCT e.emp_code,e.emp_name,e.shift_id from employee_master e,daily_attend d,ATTEND A  where e.status_id=1 and e.branch_id=" & Me.cmb_branch.SelectedValue & " and e.branch_id=d.branch_id and e.emp_code=d.emp_code and e.emp_code>=10000 AND A.EMP_CODE=D.EMP_CODE order by e.emp_code"
        'select e.emp_code,e.emp_name,e.shift_id from employee_master e,daily_attend d where e.status_id=1 and d.branch_id=29 and e.branch_id=d.branch_id and e.emp_code=d.emp_code and e.emp_code>=10000  and m_time is null and to_date(d.curr_date)=to_date(sysdate) order by e.emp_code
        If Me.txt_date.Text = "" And Me.RadioButton1.Checked = False And Me.RadioButton2.Checked = True Then
            Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>SELECT DATE</B></FONT>"
            Exit Sub
        End If
        If Me.RadioButton1.Checked = True Then
            SQL = "select e.emp_code,e.emp_name,e.shift_id from employee_master e,daily_attend d where e.status_id=1 and d.branch_id=" & Me.cmb_branch.SelectedValue & " and e.branch_id=d.branch_id and e.emp_code=d.emp_code and e.emp_code>=10000  and m_time is null and to_date(d.curr_date)=to_date(sysdate) order by e.emp_code"
            dt2 = OH.ExecuteDataSet(SQL).Tables(0)
        ElseIf Me.RadioButton2.Checked = True Then
            SQL = "select e.emp_code,e.emp_name,e.shift_id from employee_master e,attend d where e.status_id=1 and d.branch_id=" & Me.cmb_branch.SelectedValue & " and e.branch_id=d.branch_id and e.emp_code=d.emp_code and e.emp_code>=10000  and e_time is null and to_date(d.curr_date)=to_date('" & Me.txt_date.Text & "') order by e.emp_code"
            dt2 = OH.ExecuteDataSet(SQL).Tables(0)
        Else
            Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>SELECT MORNING OR EVENING</B></FONT>"
        End If

        Me.txt_cnt.Text = dt2.Rows.Count
        Dim cnt As New Integer
        cnt = dt2.Rows.Count
        Dim st As New Integer
        st = 0
        Dim tab As New Table
        tab.Attributes.Add("border", "1")
        tab.Attributes.Add("width", "792px")

        Dim mr As New TableRow
        Dim mc1 As New TableCell
        Dim mc2 As New TableCell
        Dim mc3 As New TableCell
        Dim mc4 As New TableCell
        Dim mc5 As New TableCell
        mc1.Text = "<FONT SIZE=3><B>EMP CODE</B></FONT>"
        mc2.Text = "<FONT SIZE=3><B>EMP NAME</B></FONT>"
        mc3.Text = "<FONT SIZE=3><B>SHIFT</B></FONT>"
        mc4.Text = "<FONT SIZE=3><B>TIME</B></FONT>"
        mc5.Text = "<FONT SIZE=3><B>PUNCHING TIME(Format 24:00:00)</B></FONT>"
        mr.Cells.Add(mc1)
        mr.Cells.Add(mc2)
        mr.Cells.Add(mc3)
        mr.Cells.Add(mc4)
        mr.Cells.Add(mc5)
        tab.Controls.Add(mr)
        Dim anil As Integer = 0

        For Each dr In dt2.Rows

            Dim r As New TableRow
            Dim c1 As New TableCell
            Dim c2 As New TableCell
            Dim c3 As New TableCell
            Dim c4 As New TableCell
            Dim c5 As New TableCell
            Dim a As New TextBox
            Dim a1 As New AjaxControlToolkit.MaskedEditValidator
            Dim a2 As New AjaxControlToolkit.MaskedEditExtender

            a.ID = dr(0)
            a1.ID = anil + 1
            a2.ID = anil + 2
            c1.Text = dr(0)
            c2.Text = dr(1)

            SQL = "SELECT SHIFT,IN_TIME,OUT_TIME FROM TIME_TAB WHERE SHIFT_ID=" & dr(2) & ""
            Dim dt3 As New DataTable
            dt3 = OH.ExecuteDataSet(SQL).Tables(0)
            c3.Text = dt3.Rows(0)(0)
            c4.Text = "" & dt3.Rows(0)(1) & "-" & dt3.Rows(0)(2) & ""

            a.MaxLength = 8
            a.Attributes.Add("Onblur", "return checkid(" & dr(0) & ")")
            a1.ControlExtender = a2.ID
            a1.ControlToValidate = a.ID
            a2.TargetControlID = a.ID
            a2.MaskType = AjaxControlToolkit.MaskedEditType.Time
            a2.Mask = "99:99:99"
            a2.AcceptAMPM = False
            a2.AutoComplete = True
            a2.AutoCompleteValue = "00"
            r.Cells.Add(c1)
            r.Cells.Add(c2)
            r.Cells.Add(c3)
            r.Cells.Add(c4)
            c5.Controls.Add(a)
            c5.Controls.Add(a1)
            c5.Controls.Add(a2)
            r.Cells.Add(c5)


            tab.Controls.Add(r)
            Me.txt_hid.Text = Me.txt_hid.Text & "*" & dr(0)
            anil += 3
        Next
        Me.Panel1.Controls.Add(tab)
    End Sub

   
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Me.RadioButton2.Checked = True Then
                Dim dt As New Date
                dt = Me.txt_date.Text
                dt = Format(dt, "dd/MMM/yyyy")
                If (dt > Date.Now) Then
                    Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>YOU CANNOT SELECT FORWARD DATE</B></FONT>"
                    Exit Sub
                End If
                If Me.RadioButton2.Checked = True And dt = Format(Date.Now, "dd/MMM/yyyy") Then
                    Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>YOU CANNOT MARK TODAY'S ATTENDANCE</B></FONT>"
                    Exit Sub
                End If

            End If
            If Me.RadioButton1.Checked = False And Me.RadioButton2.Checked = False Then
                Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>SELECT MORNING OR EVENING</B></FONT>"
                Exit Sub
            End If
            If Me.txt_date.Text = "" And Me.RadioButton2.Checked = True Then
                Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>SELECT DATE</B></FONT>"
                Exit Sub
            End If
            If Me.txt_cnt.Text = 0 Then
                Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>COULD NOT CONFIRM</B></FONT>"
                Exit Sub
            End If
            Dim op(5) As OracleParameter
            op(0) = New OracleParameter("lst", OracleType.VarChar, 500)
            op(0).Value = Me.Hidden1.Value
            op(1) = New OracleParameter("br_id", OracleType.Number)
            op(1).Value = Me.cmb_branch.SelectedValue
            op(2) = New OracleParameter("flag", OracleType.Number)
            op(2).Direction = ParameterDirection.Output
            op(2).Value = 0
            If Me.RadioButton1.Checked = True Then
                op(3) = New OracleParameter("dt", OracleType.DateTime)
                op(3).Value = Format(Date.Now, "dd/MMM/yyyy")
            Else
                op(3) = New OracleParameter("dt", OracleType.DateTime)
                op(3).Value = Me.txt_date.Text
            End If
            op(4) = New OracleParameter("me", OracleType.Number)
            If Me.RadioButton1.Checked = True Then
                op(4).Value = 1
            Else
                op(4).Value = 2
            End If
            op(5) = New OracleParameter("msg", OracleType.VarChar, 200)
            op(5).Direction = ParameterDirection.Output

            OH.ExecuteNonQuery("ho_punch", op)
            If op(2).Value = 1 Then
                Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>SUCCESSFULLY CONFIRMED</B></FONT>"

            Else
                Me.Label1.Text = "<FONT SIZE=3 COLOR=RED><B>" & op(5).Value & "</B></FONT>"
            End If
            Me.Hidden1.Value = ""
            Me.txt_hid.Text = ""
            Me.txt_date.Text = ""
            Me.Hid_id.Value = ""
            FILL()
        Catch ex As Exception
            Me.Label1.Text = ex.Message
        End Try
    End Sub

    'Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim op(4) As OracleParameter
    '        op(0) = New OracleParameter("lst", OracleType.VarChar, 500)
    '        op(0).Value = Me.Hidden1.Value
    '        op(1) = New OracleParameter("br_id", OracleType.Number)
    '        op(1).Value = Me.cmb_branch.SelectedValue
    '        op(2) = New OracleParameter("flag", OracleType.Number)
    '        op(2).Value = 0
    '        op(3) = New OracleParameter("dt", OracleType.DateTime)
    '        op(3).Value = Me.txt_date.Text
    '        op(4) = New OracleParameter("me", OracleType.Number)
    '        If Me.RadioButton1.Checked = True Then
    '            op(4).Value = 1
    '        Else
    '            op(4).Value = 2
    '        End If

    '        OH.ExecuteNonQuery("ho_punch", op)
    '        If op(2).Value = 1 Then
    '            Me.Label1.Text = "<FONT SIZE=3 ><B>SUCCESSFULLY CONFIRMED</B></FONT>"
    '        Else
    '            Me.Label1.Text = "<FONT SIZE=3 ><B>FAILED</B></FONT>"
    '        End If
    '        Me.Hidden1.Value = ""
    '        Me.txt_hid.Text = ""
    '        Me.txt_date.Text = ""
    '        Me.Hid_id.Value = ""
    '    Catch ex As Exception
    '        Me.Label1.Text = ex.Message
    '    End Try
    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Response.Redirect("../home.aspx")
    End Sub

    Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Label1.Text = ""
        Me.TD1.Visible = False
        Me.TD2.Visible = False
        Me.txt_date.Text = ""
    End Sub

    Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Label1.Text = ""
        Me.TD1.Visible = True
        Me.TD2.Visible = True
        Me.txt_date.Text = ""
        Dim dt, chkdt As New Date
        Dim dt1, cn As New Integer
        If Me.txt_cntd.Text = 0 Then
            SQL = "select sysdate,sysdate-1,sysdate-2,to_char(to_date(sysdate),'d') from dual"
            Dim dt34 As New DataTable
            dt34 = OH.ExecuteDataSet(SQL).Tables(0)
            If dt34.Rows(0)(3) = 1 Then
                Me.txt_date.Text = Format(dt34.Rows(0)(2), "dd/MMM/yyyy")
            Else
                Me.txt_date.Text = Format(dt34.Rows(0)(1), "dd/MMM/yyyy")
            End If
        Else
            SQL = "SELECT SYSDATE-" & Me.txt_cntd.Text & " FROM DUAL"
            Dim D56 As New DataTable
            D56 = OH.ExecuteDataSet(SQL).Tables(0)
            Me.txt_date.Text = Format(D56.Rows(0)(0), "dd/MMM/yyyy")
        End If
    End Sub

    Protected Sub txt_date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.RadioButton2.Checked = False And Me.RadioButton1.Checked = False Then
            Me.Label1.Text = "<font size=3 color=red><b>FIRST SELECT MORNING OR EVENING</b></font>"
            Exit Sub
        End If
        Me.Label1.Text = ""
        Dim dt, chkdt As New Date
        Dim dt1, cn As New Integer
        dt = Me.txt_date.Text
        dt = Format(dt, "dd/MMM/yyyy")
        If dt = Format(Date.Now, "dd/MMM/yyyy") And Me.RadioButton2.Checked = True Then
            Me.txt_date.Text = ""
            Me.Label1.Text = "<font size=3 color=red><b>YOU CANNOT MARK TODAY'S EVENING ATTENDANCE</b></font>"
            Exit Sub
        End If
        If dt > Format(Date.Now, "dd/MMM/yyyy") Then
            Me.txt_date.Text = ""
            Me.Label1.Text = "<font size=3 color=red><b>YOU CANNOT SELECT FORWARD DATE</b></font>"
            Exit Sub
        End If
        If Me.txt_cntd.Text = 0 Then
            dt1 = DateDiff(DateInterval.Day, dt, Date.Now)
            chkdt = Date.Now
            cn = chkdt.DayOfWeek()
            If cn = 1 Then
                dt1 = dt1 - 1
            End If
            If dt1 > 1 Then
                Me.Label1.Text = "<font size=3 color=red><b>" & Me.txt_date.Text & " -YOU CANNOT SELECT THIS DATE</b></font>"
                Me.txt_date.Text = ""
                Exit Sub
            End If
            If dt1 = 0 Then
                Me.Label1.Text = "<font size=3 color=red><b>" & Me.txt_date.Text & " -YOU CANNOT SELECT THIS DATE</b></font>"
                Me.txt_date.Text = ""
                Exit Sub
            End If
        Else
            SQL = "SELECT SYSDATE-" & Me.txt_cntd.Text & " FROM DUAL"
            Dim D56 As New DataTable
            D56 = OH.ExecuteDataSet(SQL).Tables(0)
            If CDate(Me.txt_date.Text) <> CDate(D56.Rows(0)(0)) Then
                Me.txt_date.Text = Format(D56.Rows(0)(0), "dd/MMM/yyyy")
                Me.Label1.Text = "<font size=3 color=red><B>YOU ARE ALLOWED TO PUNCH ON " & Me.txt_date.Text & "....</B></font>"
            End If

        End If
    End Sub
    Sub FILL()
        SQL = "select branch_id,branch_name from branch_master where status_id=1 and branch_id<>0 order by branch_name"
        Dim dt1 As New DataTable
        dt1 = OH.ExecuteDataSet(SQL).Tables(0)
        Me.cmb_branch.DataSource = dt1
        Me.cmb_branch.DataTextField = dt1.Columns(1).ColumnName
        Me.cmb_branch.DataValueField = dt1.Columns(0).ColumnName
        Me.cmb_branch.DataBind()
        Me.Label1.Text = ""
        Me.TD1.Visible = False
        Me.TD2.Visible = False
        SQL = "select parmtr_value from general_parameter where module_id=90 and parmtr_id=1"
        Dim d23 As New DataTable
        d23 = OH.ExecuteDataSet(SQL).Tables(0)
        Me.txt_cntd.Text = d23.Rows(0)(0)
        Me.txt_cnt.Text = 0
    End Sub
End Class
