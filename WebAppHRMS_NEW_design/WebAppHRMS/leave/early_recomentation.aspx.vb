Imports System.Data
Imports System.Data.OracleClient
Partial Class punching_early_recomentation_f01ebbd37283
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim dt1 As New DataTable
    'Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
    '    'dt = oh.ExecuteDataSet("select a.cust_name||'||'||a.cust_id||'||'||b.Pledge_no||'||'||b.loan_amt,a.cust_id,b.spurious_id from spurious_customer a,spurious_gold_detail b where a.cust_id=b.cust_id AND B.STATUS_ID=2 and b.spurious_id not in(select spurious_id from police_case_detail )").Tables(0)
    '    'Me.DropDownList1.DataSource = dt
    '    'Me.DropDownList1.DataTextField = dt.Columns(0).ColumnName
    '    'Me.DropDownList1.DataValueField = dt.Columns(1).ColumnName
    '    'Me.DropDownList1.DataBind()
    '    'If dt.Rows.Count > 0 Then
    '    '    Me.hdn.Value = dt.Rows(0)(2)
    '    'End If
    '    data_fill()
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        If Me.Session("branch_id") = 0 Then
            sql = "select dep_id from department_mst where dep_head=" & st2 & ""
            dt1 = oh.ExecuteDataSet(sql).Tables(0)
            If dt1.Rows.Count > 0 Then
                If Not IsPostBack Then
                    fill()
                    ' sel()
                    'If Me.cmb_ecode.SelectedItem.Text = "NO EMP TO BE RECOMMENDED" Then
                    '    'Me.cmb_sanc.Items.Clear()
                    '    'Me.cmb_sanc.Items.Add("CAN'T  RECOMMEND")
                    'Else


                    sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where emp_code>9999 and emp_code=" & st2 & "  order by emp_code"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    Me.cmb_sanc.Text = dt.Rows(0)(0)
                    Me.HiddenField3.Value = dt.Rows(0)(1)
                    'Me.cmb_sanc.DataSource = dt
                    'Me.cmb_sanc.DataTextField = dt.Columns(0).ColumnName
                    'Me.cmb_sanc.DataValueField = dt.Columns(1).ColumnName
                    'Me.cmb_sanc.DataBind()
                    'End If
                End If
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        Else
            sql = "select access_id from employee_master where emp_code=" & st2 & ""
            dt1 = oh.ExecuteDataSet(sql).Tables(0)
            If dt1.Rows(0)(0) = 51 Then
                If dt1.Rows.Count > 0 Then
                    If Not IsPostBack Then
                        brfill()
                        'If Me.cmb_ecode.SelectedItem.Text = "NO EMP TO BE RECOMMENDED" Then
                        '    Me.cmb_sanc.Items.Add("CAN'T  RECOMMEND")
                        'Else
                        ' sel()
                        sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where emp_code>9999 and emp_code=" & st2 & " AND branch_id=" & Me.Session("branch_id") & " order by emp_code"
                        dt = oh.ExecuteDataSet(sql).Tables(0)
                        If dt.Rows.Count > 0 Then
                            Me.cmb_sanc.Text = dt.Rows(0)(0)
                            Me.HiddenField3.Value = dt.Rows(0)(1)
                            'Me.cmb_sanc.DataSource = dt
                            'Me.cmb_sanc.DataTextField = dt.Columns(0).ColumnName
                            'Me.cmb_sanc.DataValueField = dt.Columns(1).ColumnName
                            'Me.cmb_sanc.DataBind()
                            'End If
                        Else
                            Me.Server.Transfer("../show_err.aspx")
                        End If
                    End If
                    Else
                        Me.Server.Transfer("../show_err.aspx")
                    End If
                Else
                    Me.Server.Transfer("../show_err.aspx")
                End If
        End If
    End Sub

    Sub fill()
        'sql = "select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate||' To '||a.leave_todate,a.emp_code||'*'||a.leave_frdate  from employ_leave_dtl a,employee_master b where a.emp_code=b.emp_code and a.status=0 and b.department_id=" & dt1.Rows(0)(0) & "  order by a.leave_apply_date"
        'sql1 = "select Select from dual join select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate||' To '||a.leave_todate as ---Select---from early_going_mst a,employee_master b where a.emp_code=b.emp_code and a.status=7 and b.department_id=" & dt1.Rows(0)(0) & "  order by a.leave_apply_date"
        sql = "select '---Select---','0' from dual union select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate||' To '||a.leave_todate,a.emp_code||'*'||a.leave_frdate  from early_going_mst a,employee_master b where a.emp_code=b.emp_code and a.status=7 and b.department_id=" & dt1.Rows(0)(0) & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)
        'If (dt.Rows.Count = 1) Then
        'Me.cmb_ecode.Items.Clear()
        'Me.cmb_ecode.Items.Add("NO EMP TO BE RECOMMENDED")
        ''Me.cmb_sanc.Items.Clear()
        ''Me.cmb_sanc.Items.Add("CAN'T  RECOMMEND")
        'Me.txt_applay_date.Text = Format(Now, "dd/MMM/yyyy")
        'Me.txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        'Me.txt_name.Text = ""
        'Me.txt_reason.Text = ""
        'Me.txt_applay_date.Text = ""
        'Me.txt_leave_date.Text = ""

        'ElseIf (dt.Rows.Count = 1) Then
        '    Me.txt_applay_date.Text = Format(Now, "dd/MMM/yyyy")
        '    Me.txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        '    Me.cmb_ecode.DataSource = dt
        '    Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        '    Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
        '    Me.cmb_ecode.DataBind()
        '    data_fill()
        'Else
        'Me.txt_applay_date.Text = Format(Now, "dd/MMM/yyyy")
        'Me.txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        'Dim li As New ListItem
        'li.Text = "Select"
        'li.Value = 0



        'Me.cmb_ecode.Items.Add = "Select"
        'Me.cmb_ecode.DataValueField = 0


        Me.cmb_ecode.DataSource = dt
        Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_ecode.DataBind()


        'Me.cmb_ecode.DataSource = dt1
        'Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        'Me.cmb_ecode.DataValueField = 0
        'Me.cmb_ecode.DataBind()



        'Me.cmb_ecode.Items.Insert(0, li)
        'Me.cmb_ecode.DataBind()
        'data_fill()
        'If dt.Rows.Count = 1 Then
        '    sel()
        'End If

        ' End If
    End Sub
    Sub brfill()
        'sql = "select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate||' To '||a.leave_todate,a.emp_code||'*'||a.leave_frdate  from employ_leave_dtl a,employee_master b where a.emp_code=b.emp_code and a.status=0 and b.department_id=" & dt1.Rows(0)(0) & "  order by a.leave_apply_date"
        sql = "select '---Select---','0' from dual union select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate||' To '||a.leave_todate,a.emp_code||'*'||a.leave_frdate  from early_going_mst a,employee_master b where a.emp_code=b.emp_code and a.status=7 and b.branch_id=" & Me.Session("branch_id") & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)
        'If (dt.Rows.Count = 1) Then
        'Me.cmb_ecode.Items.Clear()
        'Me.cmb_ecode.Items.Add("NO EMP TO BE RECOMMENDED")
        '' Me.cmb_sanc.Items.Clear()
        '' Me.cmb_sanc.Items.Add("CAN'T  RECOMMEND")
        'Me.txt_applay_date.Text = Format(Now, "dd/MMM/yyyy")
        'Me.txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        'Me.txt_name.Text = ""
        'Me.txt_reason.Text = ""
        'Me.txt_applay_date.Text = ""
        'Me.txt_leave_date.Text = ""

        'ElseIf (dt.Rows.Count = 1) Then
        '    Me.txt_applay_date.Text = Format(Now, "dd/MMM/yyyy")
        '    Me.txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        '    Me.cmb_ecode.DataSource = dt
        '    Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        '    Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
        '    Me.cmb_ecode.DataBind()
        '    data_fill()
        ' Else
        'Me.txt_applay_date.Text = Format(Now, "dd/MMM/yyyy")
        'Me.txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        'Me.cmb_ecode.Items.Add("---Select---")
        Me.cmb_ecode.DataSource = dt
        Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_ecode.DataBind()
        'data_fill()
        'If dt.Rows.Count = 1 Then
        '    sel()
        'End If
        'End If
    End Sub
    Sub data_fill()
        Dim st As String = Me.cmb_ecode.SelectedValue
        Dim st1(), st2, st3 As String
        st1 = st.Split("*")
        st2 = st1(0)
        st3 = st1(1)

        sql = "select b.emp_name,a.leave_frdate,a.leave_apply_date,a.leave_reason from early_going_mst a,employee_master b where  a.emp_code=b.emp_code and a.emp_code=" & st2 & " and b.department_id=" & dt1.Rows(0)(0) & " and a.leave_frdate='" & st3 & "'  and a.status=7"
        dt = oh.ExecuteDataSet(sql).Tables(0)

        Me.txt_name.Text = dt.Rows(0)(0)
        Me.txt_leave_date.Text = dt.Rows(0)(1)
        Me.txt_applay_date.Text = dt.Rows(0)(2)
        Me.txt_reason.Text = dt.Rows(0)(3)
        Me.HiddenField1.Value = Format(dt.Rows(0)(1), "dd/MMM/yyyy")
        Me.HiddenField2.Value = Format(dt.Rows(0)(2), "dd/MMM/yyyy")

    End Sub
    Sub brdata_fill()
        Dim st As String = Me.cmb_ecode.SelectedValue
        Dim st1(), st2, st3 As String
        st1 = st.Split("*")
        st2 = st1(0)
        st3 = st1(1)

        sql = "select b.emp_name,a.leave_frdate,a.leave_apply_date,a.leave_reason from early_going_mst a,employee_master b where  a.emp_code=b.emp_code and a.emp_code=" & st2 & " and b.branch_id=" & Me.Session("branch_id") & " and a.leave_frdate='" & st3 & "'  and a.status=7"
        'sql = "select b.emp_name,a.leave_frdate,a.emp_code||'----'||||'   |    '||||' To '||a.leave_todate,a.emp_code||'*'||a.leave_frdate  from early_going_mst a,employee_master b where a.emp_code=b.emp_code and a.status=7 and b.branch_id=" & Me.Session("branch_id") & ""
        dt = oh.ExecuteDataSet(sql).Tables(0)

        Me.txt_name.Text = dt.Rows(0)(0)
        Me.txt_leave_date.Text = dt.Rows(0)(1)
        Me.txt_applay_date.Text = dt.Rows(0)(2)
        Me.txt_reason.Text = dt.Rows(0)(3)

        Me.HiddenField1.Value = Format(dt.Rows(0)(1), "dd/MMM/yyyy")
        Me.HiddenField2.Value = Format(dt.Rows(0)(2), "dd/MMM/yyyy")

    End Sub


    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If cmb_ecode.SelectedItem.Text = "---Select---" Then
            Me.txt_name.Text = ""
            Me.txt_reason.Text = ""
            Me.txt_applay_date.Text = ""
            Me.txt_leave_date.Text = ""

        Else

            If (Me.txt_name.Text = "" Or Me.txt_reason.Text = "" Or Me.txt_applay_date.Text = "" Or Me.txt_leave_date.Text = "") Then
                Me.Lbl_msg.Text = "<FONT SIZE=4 ><B>  FILL COMPLETE DATA </B></FONT>"
            Else

                Dim tour(4) As OracleParameter
                Dim st As String = Me.cmb_ecode.SelectedValue
                ' Dim st10 As String = Me.cmb_sanc.SelectedValue
                Dim st1(), st2, st3 As String
                st1 = st.Split("*")
                st2 = st1(0)
                st3 = st1(1)

                'Me.HiddenField1.Value = Format(Me.HiddenField1.Value, "dd/MMM/yyyy")
                'Me.HiddenField2.Value = Format(Me.HiddenField2.Value, "dd/MMM/yyyy")
                tour(0) = New OracleParameter("emp_id", OracleType.Number, 8)
                tour(0).Direction = ParameterDirection.Input
                tour(0).Value = st2
                tour(1) = New OracleParameter("from_date", OracleType.DateTime)
                tour(1).Direction = ParameterDirection.Input
                tour(1).Value = CDate(Me.HiddenField1.Value)
                tour(2) = New OracleParameter("applay_date", OracleType.DateTime)
                tour(2).Direction = ParameterDirection.Input
                tour(2).Value = CDate(Me.HiddenField2.Value)
                tour(3) = New OracleParameter("recom_pers", OracleType.Number, 5)
                tour(3).Direction = ParameterDirection.Input
                tour(3).Value = Me.HiddenField3.Value
                tour(4) = New OracleParameter("id", OracleType.Int32)
                tour(4).Direction = ParameterDirection.Input
                tour(4).Value = 0
                oh.ExecuteNonQuery("early_going_recom", tour)
                Me.Lbl_msg.Text = "<FONT SIZE=4 ><B>RECOMMENDED </B></FONT>"
                If Me.Session("branch_id") = 0 Then
                    fill()
                Else
                    brfill()
                End If

                Me.txt_name.Text = ""
                Me.txt_reason.Text = ""
                Me.txt_applay_date.Text = ""
                Me.txt_leave_date.Text = ""
                ' sel()
                'If dt.Rows.Count = 1 Then
                '    sel()
                'End If
            End If
        End If
    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reject.Click
        If cmb_ecode.SelectedItem.Text = "---Select---" Then
            'Dim cl_script As New StringBuilder
            'cl_script.Append("   alert('NO EMPLOYEE APPLIED FOR EARLY GOING ') ;")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Me.txt_name.Text = ""
            Me.txt_reason.Text = ""
            Me.txt_applay_date.Text = ""
            Me.txt_leave_date.Text = ""
        Else
            If (Me.txt_name.Text = "" Or Me.txt_reason.Text = "" Or Me.txt_applay_date.Text = "" Or Me.txt_leave_date.Text = "") Then
                Me.Lbl_msg.Text = "<FONT SIZE=4 ><B>  FILL COMPLETE DATA </B></FONT>"
            Else
                Dim tour(4) As OracleParameter
                Dim st As String = Me.cmb_ecode.SelectedValue
                Dim st1(), st2, st3 As String
                st1 = st.Split("*")
                st2 = st1(0)
                st3 = st1(1)

                tour(0) = New OracleParameter("emp_id", OracleType.Number, 8)
                tour(0).Direction = ParameterDirection.Input
                tour(0).Value = st2
                tour(1) = New OracleParameter("from_date", OracleType.DateTime)
                tour(1).Direction = ParameterDirection.Input
                tour(1).Value = CDate(Me.HiddenField1.Value)
                tour(2) = New OracleParameter("applay_date", OracleType.DateTime)
                tour(2).Direction = ParameterDirection.Input
                tour(2).Value = CDate(Me.HiddenField2.Value)
                tour(3) = New OracleParameter("recom_pers", OracleType.Number, 5)
                tour(3).Direction = ParameterDirection.Input
                tour(3).Value = CInt(Me.HiddenField3.Value)
                tour(4) = New OracleParameter("id", OracleType.Int32)
                tour(4).Direction = ParameterDirection.Input
                tour(4).Value = 1
                oh.ExecuteNonQuery("early_going_recom", tour)

                Me.Lbl_msg.Text = "<FONT SIZE=4 ><B>REJECTED </B></FONT>"
                If Me.Session("branch_id") = 0 Then
                    fill()
                Else
                    brfill()
                End If

                Me.txt_name.Text = ""
                Me.txt_reason.Text = ""
                Me.txt_applay_date.Text = ""
                Me.txt_leave_date.Text = ""
                'If dt.Rows.Count = 1 Then
                '    sel()
                'End If
                'sel()
            End If
        End If
    End Sub


    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Server.Transfer("..\home.aspx")
    End Sub


  
    Protected Sub cmb_ecode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ecode.SelectedIndexChanged
        sel()
    End Sub
    Sub sel()
        If cmb_ecode.SelectedItem.Text = "---Select---" Then
            'Dim cl_script As New StringBuilder
            'cl_script.Append("   alert('NO EMPLOYEE APPLIED FOR EARLY GOING ') ;")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
            Me.txt_name.Text = ""
            Me.txt_reason.Text = ""
            Me.txt_applay_date.Text = ""
            Me.txt_leave_date.Text = ""
        Else
            If Not Me.Session("branch_id") = 0 Then
                brdata_fill()
                Lbl_msg.Text = ""
            Else
                data_fill()
                Lbl_msg.Text = ""
            End If
        End If
        'Me.txt_name.Text = ""
        'Me.txt_reason.Text = ""
        'Me.txt_applay_date.Text = ""
        'Me.txt_leave_date.Text = ""
    End Sub
End Class
