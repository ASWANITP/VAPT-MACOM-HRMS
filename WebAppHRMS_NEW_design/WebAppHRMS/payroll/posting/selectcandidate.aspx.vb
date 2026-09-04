Imports System.Data
Imports System.Data.OracleClient

Partial Class SELECTCANTIDATE_selectcandidate_a6fe50a72941
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt4, dt7 As New DataTable
    Dim sql, sql1, sql2, sql3, sql7 As String
    Dim max, temp As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                Me.Txt_Date.Text = Format(Date.Today, "dd/MMM/yyyy")
                loa()
            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
        Dim script_val As String = "var disb ; disb='" & Me.cmd_confirm.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "gl4aa", script_val, True)
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        'MsgBox(hid_data_sent.Value)
        'Dim dat As String = hid_data_sent.Value.ToString
        'Dim arr As Array
        ' arr = hid_data_sent.Value.Split("!")
        dt = oh.ExecuteDataSet("select a.appln_no,a.appln_name,b.interview_by from appln_pers_dtl a,appln_interview_dtl b where a.appln_no=b.appln_no and to_date(b.interview_dt)='" & Me.Txt_Date.Text & "'").Tables(0)

        If dt.Rows.Count = 0 Then

            Dim tb2 As New Table
            tb2.Attributes.Add("width", "100%")
            tb2.Attributes.Add("border", "")

            tb2.Attributes.Add("align", "center")

            Dim tr2 As New TableRow
            tr2.BackColor = Drawing.Color.Cornsilk
            Dim tc12 As New TableCell
            tc12.ColumnSpan = 8
            tc12.HorizontalAlign = HorizontalAlign.Center
            tc12.Text = "<font size=4><b>NO CANDIDATES EXIST. CONTACT HRM FOR LIST ! ...</b></font>"
            tr2.Cells.Add(tc12)

            tb2.Controls.Add(tr2)
            Me.Panel1.Controls.Add(tb2)


        Else
            
            Dim parameter(2) As OracleParameter
            parameter(0) = New OracleParameter("hid_data", OracleType.VarChar, 150)
            parameter(0).Direction = ParameterDirection.Input
            parameter(0).Value = hid_data_sent.Value
            parameter(1) = New OracleParameter("hid_data1", OracleType.VarChar, 150)
            parameter(1).Direction = ParameterDirection.Input
            parameter(1).Value = Hid_max1.Value
            parameter(2) = New OracleParameter("hid_data2", OracleType.VarChar, 150)
            parameter(2).Direction = ParameterDirection.Input
            parameter(2).Value = Hid_max2.Value
            oh.ExecuteNonQuery("testinsert", parameter)
            Server.Transfer("selectcandidate.aspx")
        End If
    End Sub

    Protected Sub Txt_Date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Date.TextChanged
        'dt = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where status_id =1 and shift_id  in (4,5,9,6,2,1) order by emp_name").Tables(0)
        ' dt = oh.ExecuteDataSet("select emp_name,emp_code from employee_master where status_id =1 and shift_id  in (4,5,9,6,2,1) order by emp_name").Tables(0)
        'dt = oh.ExecuteDataSet("select a.item_name,a.item_code,a.item_number,a.status,b.max_qty from store_item_master a,store_branch_max b where b.branch_id=" & Session("branch_id") & " and a.item_number=b.item_number order by a.item_name").Tables(0)
        loa()
    End Sub

    Sub loa()
        dt = oh.ExecuteDataSet("select a.appln_no,a.appln_name,b.interview_by from appln_pers_dtl a,appln_interview_dtl b where a.appln_no=b.appln_no and to_date(b.interview_dt)='" & Me.Txt_Date.Text & "'").Tables(0)
        If dt.Rows.Count = 0 Then
            ' Server.Transfer("../show_err.aspx")
            '  Response.Write("<font size=5><b>NO CANDIDATES EXIST CONTACT HRM FOR LIST...</b></font>")

            Dim tb2 As New Table
            tb2.Attributes.Add("width", "90%")
            tb2.Attributes.Add("border", "")

            tb2.Attributes.Add("align", "center")

            Dim tr2 As New TableRow
            tr2.BackColor = Drawing.Color.Cornsilk
            Dim tc12 As New TableCell
            tc12.ColumnSpan = 8
            tc12.HorizontalAlign = HorizontalAlign.Center
            tc12.Text = "<font size=4><b>NO CANDIDATES EXIST. CONTACT HRM FOR LIST...</b></font>"
            tr2.Cells.Add(tc12)

            tb2.Controls.Add(tr2)
            Me.Panel1.Controls.Add(tb2)

            Exit Sub
        End If
        Dim tb As New Table
        tb.Attributes.Add("width", "100%")
        tb.Attributes.Add("border", "1")

        tb.Attributes.Add("align", "center")

        Dim tr1 As New TableRow
        tr1.BackColor = Drawing.Color.Salmon
        Dim tc1 As New TableCell
        tc1.ColumnSpan = 1
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.Text = "<font size=3><b>APPLICATION NO</b></font>"
        tr1.Cells.Add(tc1)

        Dim tc2 As New TableCell
        tc2.ColumnSpan = 8
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc2.Text = "<font size=3><b>NAME</b></font>"
        tr1.Cells.Add(tc2)

        Dim tc3 As New TableCell
        tc3.ColumnSpan = 12
        tc3.HorizontalAlign = HorizontalAlign.Center
        tc3.Text = "<font size=3><b>INTERVIEWED BY</b></font>"
        tr1.Cells.Add(tc3)

        Dim tc4 As New TableCell
        tc4.ColumnSpan = 1
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc4.Text = "<font size=3><b>CLEARED</b></font>"
        tr1.Cells.Add(tc4)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tc5 As New TableCell
        tc5.ColumnSpan = 1
        tc5.HorizontalAlign = HorizontalAlign.Center
        tc5.Text = "<font size=3><b>PENDING</b></font>"
        tr1.Cells.Add(tc5)


        Dim tc6 As New TableCell
        tc6.ColumnSpan = 1
        tc6.HorizontalAlign = HorizontalAlign.Center
        tc6.Text = "<font size=3><b>REJECTED</b></font>"
        tr1.Cells.Add(tc6)




        '''''''''''''''''''''''''''''''''''
        tb.Controls.Add(tr1)
        Dim dr As DataRow
        Dim n As Integer = 0
        Dim x As Integer = 0
        Dim y As Integer = 0
        ' Dim arr As Array
        '     Me.hid_maxqty.Value = ""
        Dim str As String
        max = 0
        temp = 0
        Dim color As Integer = 0
        For Each dr In dt.Rows
            'temp = dr(0)
            'If temp > max Then
            '    max = temp
            'End If
            ' Me.hid_maxqty.Value = Me.hid_maxqty.Value & "!" & dr(2) & "~" & dr(4)
            n += 1
            x += 1
            y += 1

            Dim tr2 As New TableRow

            If (color = 0) Then
                tr2.BackColor = Drawing.Color.WhiteSmoke
                color = 1
            Else
                tr2.BackColor = Drawing.Color.Snow
                color = 0
            End If
            tr2.Attributes.Add("height", "25px")

            Dim tc8 As New TableCell
            tc8.ColumnSpan = 1
            tc8.HorizontalAlign = HorizontalAlign.Center
            tc8.Text = dr(0)
            tc8.ForeColor = Drawing.Color.Black
            tr2.Cells.Add(tc8)

            Dim tc9 As New TableCell
            tc9.ColumnSpan = 8
            tc9.HorizontalAlign = HorizontalAlign.Center
            tc9.Text = dr(1)
            tc9.ForeColor = Drawing.Color.Blue
            tr2.Cells.Add(tc9)

            Dim tc10 As New TableCell
            tc10.ColumnSpan = 12
            tc10.HorizontalAlign = HorizontalAlign.Center
            Dim dt As DataTable = oh.ExecuteDataSet("select emp_name from employee_master where emp_code=" & dr(2) & "").Tables(0)
            tc10.Text = "<font size=3 color=black>&nbsp&nbsp" & dr(2) & "-" & dt.Rows(0)(0) & " </font>"
            ' tc10.Text = dt.Rows(0)(0)
            tr2.Cells.Add(tc10)

            str = ""
            ' str = "<input type=checkbox onclick=show_txt(" & dr(0) & ") id=chk_" & dr(0) & " />"
            str = "<input type=checkbox onclick=ch1(" & dr(0) & ") id='chk_" & dr(0) & "' name='txt_" & n & "' />"
            Dim tc11 As New TableCell
            tc11.ColumnSpan = 1
            tc11.HorizontalAlign = HorizontalAlign.Center
            tc11.Text = str
            tr2.Cells.Add(tc11)

            ''''''''''''''''''''''''''''''''''''
            str = ""
            ' str = "<input type=checkbox onclick=show_txt(" & dr(0) & ") id=chk_" & dr(0) & " />"
            str = "<input type=checkbox onclick=ch2(" & dr(0) & ") id='chk1_" & dr(0) & "' name='txt1_" & n & "' />"
            Dim tc12 As New TableCell
            tc12.ColumnSpan = 1
            tc12.HorizontalAlign = HorizontalAlign.Center
            tc12.Text = str
            tr2.Cells.Add(tc12)

            str = ""
            ' str = "<input type=checkbox onclick=show_txt(" & dr(0) & ") id=chk_" & dr(0) & " />"
            str = "<input type=checkbox onclick=ch3(" & dr(0) & ") id='chk2_" & dr(0) & "' name='txt2_" & n & "' />"
            Dim tc13 As New TableCell
            tc13.ColumnSpan = 1
            tc13.HorizontalAlign = HorizontalAlign.Center
            tc13.Text = str
            tr2.Cells.Add(tc13)
            ''''''''''''''''''''


            tb.Controls.Add(tr2)

        Next
        'Me.hid_max.Value = max & "!" & dt1.Rows(0)(0) & "!" & dt1.Rows(0)(1) & "!" & dt1.Rows(0)(2)
        Me.hid_max.Value = n

        Me.Panel1.Controls.Add(tb)
        '  End If
      
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("../../home.aspx")
    End Sub
End Class
