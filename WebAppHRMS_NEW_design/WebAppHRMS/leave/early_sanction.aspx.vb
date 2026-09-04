Imports System.Data
Imports System.Data.OracleClient
Partial Class punching_early_sanction_832dd8e59886
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    'Dim flag As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        ' sql = "select dep_id from department_mst  where dep_head=" & st2 & ""
        'sql = "select access_id from access_control where description='" & st2 & "'"
        sql = "select nvl(access_id,0) from employee_master where emp_code=" & st2
        dt1 = oh.ExecuteDataSet(sql).Tables(0)
        If dt1.Rows.Count = 0 Or dt1.Rows(0)(0) = 1 Then
            If Not IsPostBack Then
                fill()
                ' sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where emp_code>9999 and emp_code=" & st2 & " order by emp_code"
                ' If Me.cmb_ecode.SelectedItem.Text = "NO EMP TO BE SANCTIONED" Then
                ' Me.cmb_sanc.Items.Clear()
                'Me.cmb_sanc.Items.Add("CAN'T SANCTION")

                'Else
                sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where emp_code>9999 and access_id=1 order by emp_code"
                dt = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_sanc.Text = dt.Rows(0)(0)
                Me.HiddenField3.Value = dt.Rows(0)(1)
                'Me.cmb_sanc.DataSource = dt
                'Me.cmb_sanc.DataTextField = dt.Columns(0).ColumnName
                'Me.cmb_sanc.DataValueField = dt.Columns(1).ColumnName
                'Me.cmb_sanc.DataBind()
            End If

        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

    End Sub

    Sub fill()
        sql = "select '---Select---','0' from dual union select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate,a.emp_code||'*'||a.leave_frdate from early_going_mst a,employee_master b  where a.emp_code=b.emp_code and a.status=8"
        '--sql = "select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate,a.emp_code||'*'||a.leave_frdate from early_going_mst a,employee_master b  where a.emp_code=b.emp_code and a.status=8 order by a.leave_apply_date"
        '--- sql = "select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate||' To '||a.leave_todate,a.emp_code||'*'||a.leave_frdate  from early_going_mst a,employee_master b where a.emp_code=b.emp_code and a.status=8 and b.department_id=" & dt1.Rows(0)(0) & "  order by a.leave_apply_date"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        'If (dt.Rows.Count = 1) Then
        '    Me.cmb_ecode.Items.Clear()
        '    Me.cmb_ecode.Items.Add("NO EMP TO BE SANCTIONED")
        '    'Me.cmb_sanc.Items.Clear()
        '    ' Me.cmb_sanc.Items.Add("CAN'T  SANCTION")
        '    Me.txt_applay_date.Text = Format(Now, "dd/MMM/yyyy")
        '    Me.txt_leave_date.Text = Format(Now, "dd/MMM/yyyy")
        '    Me.txt_name.Text = ""
        '    Me.txt_reason.Text = ""
        '    Me.txt_applay_date.Text = ""
        '    Me.txt_leave_date.Text = ""
        '    Txt_reco_pers.Text = ""
        'Else
        Me.cmb_ecode.DataSource = dt
        Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
        Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
        Me.cmb_ecode.DataBind()
        'If dt.Rows.Count = 1 Then
        '    data_fill()
        'End If
        ' data_fill()
        'End If
    End Sub
    Sub data_fill()
        Dim st As String = Me.cmb_ecode.SelectedValue
        Dim st1(), st2, st3 As String
        st1 = st.Split("*")
        st2 = st1(0)
        st3 = st1(1)
        sql = "select b.emp_name,a.leave_frdate,a.leave_apply_date,a.leave_reason,d.emp_name from early_going_mst a,employee_master b,employee_master d where a.emp_code=b.emp_code and a.emp_code='" & st2 & "' and a.status=8 and d.emp_code=a.recomm_person"
        ' sql = "select b.emp_name,a.leave_frdate,a.leave_apply_date,a.leave_reason,d.emp_name from employ_leave_dtl a,employee_master b,employee_master d where a.leave_id=c.leave_id and a.emp_code=b.emp_code and a.emp_code='" & Me.cmb_ecode.SelectedValue & "' and a.status=8 and d.emp_code=a.recomm_person"
        ' sql = "select b.emp_name,a.leave_frdate,a.leave_apply_date,a.leave_reason from early_going_mst a,employee_master b where  a.emp_code=b.emp_code and a.emp_code=" & st2 & " and b.department_id=" & dt1.Rows(0)(0) & " and a.leave_frdate='" & st3 & "'  and a.status=8"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.txt_name.Text = dt.Rows(0)(0)
        Me.txt_leave_date.Text = dt.Rows(0)(1)
        Me.txt_applay_date.Text = dt.Rows(0)(2)
        Me.txt_reason.Text = dt.Rows(0)(3)
        Me.Txt_reco_pers.Text = dt.Rows(0)(4)
        Me.HiddenField1.Value = Format(dt.Rows(0)(1), "dd/MMM/yyyy")
        Me.HiddenField2.Value = Format(dt.Rows(0)(2), "dd/MMM/yyyy")

    End Sub
    Protected Sub cmd_accept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_accept.Click
        If cmb_ecode.SelectedItem.Text = "---Select---" Then
            Me.txt_name.Text = ""
            Me.txt_reason.Text = ""
            Me.txt_applay_date.Text = ""
            Me.txt_leave_date.Text = ""
            Txt_reco_pers.Text = ""
            'Dim cl_script As New StringBuilder
            'cl_script.Append("   alert('NO EMPLOYEE SELECTED!!!') ;")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
        Else
            If (Me.txt_name.Text = "" Or Me.txt_reason.Text = "" Or Me.txt_applay_date.Text = "" Or Me.txt_leave_date.Text = "" Or Txt_reco_pers.Text = "") Then
                Me.Lbl_msg.Text = "<FONT SIZE=2 ><B> FILL COMPLETE DATA </B></FONT>"
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
                tour(3).Value = CInt(Me.HiddenField3.Value)
                tour(4) = New OracleParameter("id", OracleType.Int32)
                tour(4).Direction = ParameterDirection.Input
                tour(4).Value = 2
                oh.ExecuteNonQuery("early_going_recom", tour)

                Me.Lbl_msg.Text = "<FONT SIZE=4 ><B> SANCTIONED </B></FONT>"
                fill()
                Me.txt_name.Text = ""
                Me.txt_reason.Text = ""
                Me.txt_applay_date.Text = ""
                Me.txt_leave_date.Text = ""
                Txt_reco_pers.Text = ""
                'If dt.Rows.Count = 1 Then
                '    data_fill()
                'End If
            End If
        End If
    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reject.Click
        If cmb_ecode.SelectedItem.Text = "---Select---" Then
            Me.txt_name.Text = ""
            Me.txt_reason.Text = ""
            Me.txt_applay_date.Text = ""
            Me.txt_leave_date.Text = ""
            Txt_reco_pers.Text = ""
            'Dim cl_script As New StringBuilder
            'cl_script.Append("   alert('NO EMPLOYEE SELECTED!!!') ;")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
        Else
            If (Me.txt_name.Text = "" Or Me.txt_reason.Text = "" Or Me.txt_applay_date.Text = "" Or Me.txt_leave_date.Text = "" Or Txt_reco_pers.Text = "") Then
                Me.Lbl_msg.Text = "<FONT SIZE=2 ><B> FILL COMPLETE DATA </B></FONT>"
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
                tour(4).Value = 3
                oh.ExecuteNonQuery("early_going_recom", tour)

                Me.Lbl_msg.Text = "<FONT SIZE=4 ><B> REJECTED </B></FONT>"
                fill()
                Me.txt_name.Text = ""
                Me.txt_reason.Text = ""
                Me.txt_applay_date.Text = ""
                Me.txt_leave_date.Text = ""
                Txt_reco_pers.Text = ""
                'If dt.Rows.Count = 1 Then
                '    data_fill()
                'End If
            End If
        End If
    End Sub

    Protected Sub cmb_ecode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ecode.SelectedIndexChanged
        'data_fill()
        If Not cmb_ecode.SelectedItem.Text = "---Select---" Then
           
            '    Dim cl_script As New StringBuilder
            '    cl_script.Append("   alert('NO EMPLOYEE APPLIED FOR EARLY GOING ') ;")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

            'Else
            data_fill()
            Lbl_msg.Text = ""
        Else
            Me.txt_name.Text = ""
            Me.txt_reason.Text = ""
            Me.txt_applay_date.Text = ""
            Me.txt_leave_date.Text = ""
            Txt_reco_pers.Text = ""
        End If
        'End If
        'Me.txt_name.Text = ""
        'Me.txt_reason.Text = ""
        'Me.txt_applay_date.Text = ""
        'Me.txt_leave_date.Text = ""
        'Txt_reco_pers.Text = ""

    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Server.Transfer("../home.aspx")
    End Sub

End Class
