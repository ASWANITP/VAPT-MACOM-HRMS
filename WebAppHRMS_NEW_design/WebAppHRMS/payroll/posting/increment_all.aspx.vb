Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_increment_136df50e2144
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim res As String
    Dim tot As Integer


    Dim str, str1 As String
    Dim sql, sql1 As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable

    Sub basic_pay()
        Dim dg As DataTable
        dg = oh.ExecuteDataSet("select payment_id||'!'||designation_id,designation from designation_master order by designation").Tables(0)
        Me.cmb_pay.DataSource = dg
        Me.cmb_pay.DataTextField = dg.Columns(1).ColumnName
        Me.cmb_pay.DataValueField = dg.Columns(0).ColumnName
        Me.cmb_pay.DataBind()
    End Sub
    Sub pay_dtl()
        '-------------Changed for add amount Krishnadas-------------------------------------------------------------------------
        Me.cmb_basic.Items.Clear()
        Dim qp() As String
        qp = Me.cmb_pay.SelectedValue.Split("!")
        Dim sql = "select 'NOT IN THE LIST AND WANT TO ENTER..?', -1, -1  from dual union all select to_char(basic_pay),increment_amt,period from pay_scale where payment_id=" & qp(0) & " order by 1 desc"
        Dim pay As New DataTable
        pay = oh.ExecuteDataSet(sql).Tables(0)
        Dim i As Integer = 1
        Dim j As Integer = 2
        Dim l As Integer = pay.Rows.Count

        Dim pay_dtl(900) As Integer
        Dim pay_str(10) As String
        pay_str(0) = pay.Rows(0)(0)
        Me.cmb_basic.Items.Add(pay_str(0))

        If l > 1 Then
            pay_dtl(0) = pay.Rows(1)(0)
            Me.cmb_basic.Items.Add(pay_dtl(0))
            While (l > 1 And j > 1)
                'Dim str As String = pay.Rows(i)(0)
                'pay_dtl(j) = pay.Rows(i)(0)
                Dim k = pay.Rows(i)(2)
                While k > 0
                    pay_dtl(j) = pay_dtl(j - 1) + CInt(pay.Rows(i)(1))
                    Me.cmb_basic.Items.Add(pay_dtl(j))
                    k = k - 1
                    j = j + 1
                End While
                l = l - 1
                i = i + 1
                If i < pay.Rows.Count Then
                    pay_dtl(j) = pay.Rows(i)(0)
                    Me.cmb_basic.Items.Add(pay_dtl(j))
                    j = j + 1
                End If
            End While
        End If

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cs As String = "var cont_name;cont_name='" & Me.cmb_employee.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        tot = 0
        Me.cmb_employee.Attributes.Add("onchange", "fill1()")
        Me.cmb_pay.Attributes.Add("onchange", "fill2()")
        Me.cmb_basic.Attributes.Add("onchange", "fill3()")
        Me.txt_effdt.Attributes.Add("onchange", "chk4()")

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
        Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
        Dim fid As Integer = Session("firm_id")
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select count(*) from form_accessibility  where form_id=823 and emp_id=" & usr(0) & "").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Response.Redirect("../../show_err.aspx")
        End If
        If Session("access_id") = 33 Then
            If Not IsPostBack Then
                Me.hid_basic.Value = " "
                Me.txt_effdt.Text = Format(Date.Now, "dd/MMM/yyyy")
                sql = "select 'SELECT EMPLOYEE', 0 emp_code  from dual union select e.emp_code || '--------' || e.emp_name, e.emp_code  from employee_master e,employ_firm f where e.emp_code=f.emp_code and e.status_id = 1   and e.emp_code > 9999 and f.firm_id=" & fid & "   and e.shift_id not in (4, 5) order by emp_code"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                If (dt.Rows.Count < 1) Then
                    Me.cmb_employee.Items.Add("No Employee Waiting ")
                Else
                    Me.cmb_employee.DataSource = dt
                    Me.cmb_employee.DataTextField = dt.Columns(0).ColumnName
                    Me.cmb_employee.DataValueField = dt.Columns(1).ColumnName
                    Me.cmb_employee.DataBind()
                End If
                basic_pay()
                pay_dtl()
            End If
            Me.cmb_employee.Attributes.Add("onchange", "fill1()")
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../../home.aspx")
    End Sub

    'Protected Sub cmb_basic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim df() As String
    '    df = Me.cmb_pay.SelectedValue.Split("!")
    '    If Me.cmb_basic.Items.Count > 0 Then
    '        If df(0) <> 14 Then
    '            dt4 = oh.ExecuteDataSet("select value from da_index where to_dt is NULL").Tables(0)
    '            Dim sal As Decimal
    '            sal = CDec(Me.cmb_basic.SelectedValue) + CDec(dt4.Rows(0)(0))
    '            Me.txt_totalsal.Text = sal
    '        Else
    '            Me.txt_totalsal.Text = CDec(Me.cmb_basic.SelectedValue)
    '        End If
    '    End If
    'End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim oh As New Helper.Oracle.OracleHelper
        'Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim amnt As Integer
        Dim op(9) As OracleParameter
        Dim frd As Integer = Session("firm_id")
        Dim usr() As String = Me.Session("user_id").ToString.Split("!")
        Dim enterBy As String = usr(0)
        If Me.cmb_basic.SelectedValue = "NOT IN THE LIST AND WANT TO ENTER..?" Then
            If Me.txt_amount.Text = "" Then
                Dim msgbx As New System.Text.StringBuilder
                msgbx.Append("         alert('PLEASE ENTER AMOUNT');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                Exit Sub
            End If
        End If

        If Me.text_remark.Text = "" Then

            Dim msgbx As New System.Text.StringBuilder
            msgbx.Append("         alert('PLEASE ENTER THE REMARK');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
            Exit Sub
        End If

        If Me.cmb_employee.SelectedValue = 0 Then
            Dim msgbx As New System.Text.StringBuilder
            msgbx.Append("         alert('PLEASE SELECT EMPLOYEE');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
            Exit Sub
        End If


        If Me.txt_effdt.Text <> "" And Me.cmb_employee.SelectedValue <> 0 Then
            'If Me.txt_amount.Text <> "" Or Me.txt_amount.Text <> Nothing Then
            Dim sd() As String = Me.cmb_pay.SelectedValue.Split("!")
            op(0) = New OracleParameter("empcode", OracleType.Number, 10)
            op(0).Value = Me.cmb_employee.SelectedValue
            op(0).Direction = ParameterDirection.Input

            op(1) = New OracleParameter("payid", OracleType.Number, 5)
            op(1).Value = sd(0)
            op(1).Direction = ParameterDirection.Input

            op(2) = New OracleParameter("basic", OracleType.Number, 5)
            If Me.hid_basic.Value > 0 Then
                amnt = Me.hid_basic.Value
            Else
                amnt = CInt(txt_amount.Text)
            End If
            op(2).Value = amnt
            op(2).Direction = ParameterDirection.Input

            op(3) = New OracleParameter("eff_dt", OracleType.DateTime, 12)
            op(3).Value = Me.txt_effdt.Text
            op(3).Direction = ParameterDirection.Input

            op(4) = New OracleParameter("remark", OracleType.VarChar, 25)
            op(4).Value = Me.text_remark.Text
            op(4).Direction = ParameterDirection.Input

            op(5) = New OracleParameter("usrid", OracleType.VarChar, 25)
            op(5).Value = Session("user_id")
            op(5).Direction = ParameterDirection.Input
            Dim df() As String
            Dim da As Decimal
            df = Me.cmb_pay.SelectedValue.Split("!")
            If Me.cmb_basic.Items.Count > 0 Then
                If df(0) <> 14 Then
                    dt4 = oh.ExecuteDataSet("select value from da_index where to_dt is NULL and firm_id=" & frd & "").Tables(0)

                    da = CDec(dt4.Rows(0)(0))

                Else
                    da = 0
                End If
            End If
            op(6) = New OracleParameter("EnterBy", OracleType.Number, 25)
            op(6).Value = enterBy

            op(9) = New OracleParameter("Approved_By", OracleType.Number, 25)
            op(9).Value = 0

            op(7) = New OracleParameter("fl", OracleType.Number, 5)
            op(7).Value = 2

            op(8) = New OracleParameter("update_flag", OracleType.Number)
            op(8).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("EMPLOY_SAL_INCREMENT_MACOM", op)


            Dim cl_script0 As New System.Text.StringBuilder
            'cl_script0.Append("         alert(' Sucessfully Confirmed ');")
            'Dim script1 As New System.Text.StringBuilder
            If op(8).Value = 1 Then

                cl_script0.Append("        alert('Requested Successfully');")
                'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                cl_script0.Append("       window.open('increment_report.aspx?name=" & Me.txt_name.Value & "&post=" & Me.txt_post.Value & "&cbasic=" & Me.txt_basic.Value & "&firm=" & Me.txt_firm.Value & "&des=" & Me.txt_designtn.Value & "&dep=" & Me.txt_deptmnt.Value & "&brn=" & Me.txt_branch.Value & "&jod=" & Me.txt_joindt.Value & "&efdt=" & Me.txt_effdt.Text & "&ecode=" & Me.cmb_employee.SelectedValue & "&remark=" & Me.text_remark.Text & "&pbasic=" & amnt & "&da=" & da & "');")
                cl_script0.Append("       window.open('increment_all.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

            Else
                cl_script0.Append("        alert('Sorry,An Error Occured!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)


            End If

        Else
            Dim msgbx As New System.Text.StringBuilder
            msgbx.Append("         alert('PLEASE FILL ALL FIELD PROPERLY');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
            Exit Sub
        End If
    End Sub

    Protected Sub cmd_report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_report.Click
        Dim frd As Integer = Session("firm_id")
        Dim df() As String
        Dim da, amnt As Decimal
        If Me.cmb_employee.SelectedValue = 0 Then
            Dim msgbx As New System.Text.StringBuilder
            msgbx.Append("         alert('PLEASE SELECT EMPLOYEE');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
        End If
        df = Me.cmb_pay.SelectedValue.Split("!")
        If Me.cmb_basic.Items.Count > 0 Then
            If df(0) <> 14 Then
                dt4 = oh.ExecuteDataSet("select value from da_index where to_dt is NULL  and firm_id=" & frd & "").Tables(0)

                da = CDec(dt4.Rows(0)(0))

            Else
                da = 0
            End If
        End If
        Dim cl_script1 As New System.Text.StringBuilder
        If Me.cmb_basic.Text <> "NOT IN THE LIST AND WANT TO ENTER..?" Then
            amnt = Me.cmb_basic.Text
        Else
            If Me.txt_amount.Text = "" Then
                amnt = 0
            Else
                amnt = Me.txt_amount.Text

            End If
        End If
        sql = "select nvl(approve_remarks,'-') from employ_promotion_dtl where emp_code=" & Me.cmb_employee.SelectedValue & " and to_dt is null"
        dt4 = oh.ExecuteDataSet(sql).Tables(0)
        Dim aj As String = ""
        If Me.text_remark.Text <> "" Then
            aj = Me.text_remark.Text
        Else
            aj = dt4.Rows(0)(0)
        End If
        cl_script1.Append("window.open('increment_report.aspx?name=" & Me.txt_name.Value & "&post=" & Me.txt_post.Value & "&cbasic=" & Me.txt_basic.Value & "&firm=" & Me.txt_firm.Value & "&des=" & Me.txt_designtn.Value & "&dep=" & Me.txt_deptmnt.Value & "&brn=" & Me.txt_branch.Value & "&jod=" & Me.txt_joindt.Value & "&efdt=" & Me.txt_effdt.Text & "&ecode=" & Me.cmb_employee.SelectedValue & "&pbasic=" & amnt & "&remark=" & aj & "&da=" & da & "');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    End Sub

    'Protected Sub txt_effdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim dt As New DataTable
    '    dt = oh.ExecuteDataSet("select from_dt from employ_promotion_dtl where to_dt is NULL and status_id in (1,7,11) and emp_code=" & Me.cmb_employee.SelectedValue).Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        If dt.Rows(0)(0) >= CDate(Me.txt_effdt.Text) Then
    '            Dim msgbx As New System.Text.StringBuilder
    '            msgbx.Append("         alert('Check the Date entered  **** Last Promoted date is " & dt.Rows(0)(0) & "');")
    '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
    '            Me.txt_effdt.Text = ""
    '        End If
    '    End If
    'End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        '-------------Changed for enter amount-------------------------------------------------------------------------
        Dim in_data = eventArgument.Split("@")
        Dim st As New StringBuilder
        Dim st1 As New StringBuilder
        Dim frd As Integer = Session("firm_id")
        If in_data(0) = 1 Then
            Try
                '                     0              1          2               3                     4               5                                  6                                                                               7
                str1 = "select emp_name||'*'||c.post_name||'*'||b.designation||'*'||d.dep_name||'*'||e.branch_name||'*'||to_char(a.join_dt)||'*'||case when et.deputation_id=0 or et.deputation_id is null then f1.firm_abbr else f2.firm_abbr end||'*'||a.basic_pay from employee_master a,designation_master b,post_mst c,department_mst d,branch e,firm_view f1,firm_view f2 full outer join employ_transfer_dtl et on ( et.deputation_id=f2.firm_id)  where et.emp_code=a.emp_code and a.designation_id=b.designation_id and a.post_id=c.post_id   and a.firm_id=f1.firm_id and a.department_id=d.dep_id and a.branch_id=e.branch_id and a.emp_code=" & in_data(1) & " and et.to_dt is NULL and et.status_id=8 "  'ht.emp_code and ht.sr_number=

                dt1 = oh.ExecuteDataSet(str1).Tables(0)

                If dt1.Rows.Count > 0 Then

                    st.Append(dt1.Rows(0)(0))
                    st.Append("@")
                    st.Append("!")
                Else
                    st.Append("$")
                    st.Append("@")
                    st.Append("!")
                End If
                st.Append("^")
                st.Append("1")
            Catch ex As Exception
            Finally

            End Try
            res = st.ToString
        End If


        If in_data(0) = 2 Then
            Dim qp() As String
            qp = in_data(1).Split("!")
            Dim sql = "select 'NOT IN THE LIST AND WANT TO ENTER..?', -1, -1  from dual union all select to_char(basic_pay),increment_amt,period from pay_scale where payment_id=" & qp(0) & " order by 1 desc"
            Dim pay As New DataTable
            pay = oh.ExecuteDataSet(sql).Tables(0)
            Dim i As Integer = 1
            Dim j As Integer = 2
            Dim l As Integer = pay.Rows.Count
            Dim pay_dtl(900) As Integer
            Dim pay_str(10) As String
            pay_str(0) = pay.Rows(0)(0)
            st1.Append(pay_str(0))
            st1.Append("#")
            If l > 1 Then
                pay_dtl(0) = pay.Rows(1)(0)
                st1.Append(pay_dtl(0))
                st1.Append("#")
                While (l > 1 And j > 1)
                    'Dim str As String = pay.Rows(i)(0)
                    'pay_dtl(j) = pay.Rows(i)(0)
                    Dim k = pay.Rows(i)(2)
                    While k > 0
                        pay_dtl(j) = pay_dtl(j - 1) + CInt(pay.Rows(i)(1))
                        st1.Append(pay_dtl(j))
                        st1.Append("#")
                        k = k - 1
                        j = j + 1
                    End While
                    l = l - 1
                    i = i + 1
                    If i < pay.Rows.Count Then
                        pay_dtl(j) = pay.Rows(i)(0)
                        st1.Append(pay_dtl(j))
                        st1.Append("#")
                        j = j + 1
                    End If
                End While
            End If
            st1.Append("^")
            st1.Append("2")
            res = st1.ToString

        End If


        If in_data(0) = 3 Then
            Dim df() As String
            df = in_data(1).Split("!")
            Dim tsal As Integer
            If Me.cmb_basic.Items.Count > 0 Then
                If df(0) <> 14 Then
                    dt4 = oh.ExecuteDataSet("select value from da_index where to_dt is NULL  and firm_id=" & frd & "").Tables(0)
                    Dim sal As Decimal
                    sal = CDec(in_data(2)) + CDec(dt4.Rows(0)(0))
                    tsal = sal
                Else
                    tsal = CDec(in_data(2))
                End If
            End If
            st1.Append(tsal)
            st1.Append("^")
            st1.Append("3")
            res = st1.ToString
        End If
        If in_data(0) = 4 Then
            Dim dt As New DataTable
            dt = oh.ExecuteDataSet("select from_dt from employ_promotion_dtl where to_dt is NULL and status_id in (1,7,11) and emp_code=" & in_data(2)).Tables(0)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0) >= CDate(in_data(1)) Then
                    'Dim msgbx As New System.Text.StringBuilder
                    'msgbx.Append("         alert('Check the Date entered  **** Last Promoted date is " & dt.Rows(0)(0) & "');")
                    'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                    'Me.txt_effdt.Text = ""
                    st.Append("1~Check the Date entered  **** Last Promoted date is " & dt.Rows(0)(0) & "")
                Else
                    st.Append("2~hai")
                End If

                st.Append("^")
                st.Append("4")
                res = st.ToString
            End If
        End If
        If in_data(0) = 5 Then
            Dim df() As String
            df = in_data(1).Split("!")
            Dim tsal As Integer
            If Me.cmb_basic.Items.Count > 0 Then
                If df(0) <> 14 Then
                    dt4 = oh.ExecuteDataSet("select value from da_index where to_dt is NULL  and firm_id=" & frd & "").Tables(0)
                    Dim sal As Decimal
                    sal = CDec(in_data(2)) + CDec(dt4.Rows(0)(0))
                    tsal = sal
                Else
                    tsal = CDec(in_data(2))
                End If
            End If
            Me.txt_totalsal.Text = tsal
            tot = tsal
            st1.Append(tsal)
            st1.Append("^")
            st1.Append("3")
            res = st1.ToString
        End If
    End Sub


End Class
