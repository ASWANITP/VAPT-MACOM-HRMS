Imports System.Data
Imports System.Data.OracleClient
Partial Class Deepak_Leave_re_c0cfaa653048
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim dt1 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim st As String = Me.Session("user_id")
        Dim st1(), st2, st3 As String
        st1 = st.Split("!")
        st2 = st1(0)
        st3 = st1(1)
        Me.Lbl_msg.Text = "<marquee><font>This module For Recommendation of a applied leave.select employee And confirm or reject it</font></marquee>"
        If Me.Session("branch_id") = 0 Then

            sql = "select dep_id from department_mst  where dep_head=" & st2 & ""
            dt1 = oh.ExecuteDataSet(sql).Tables(0)
            If dt1.Rows.Count > 0 Then
                If Not IsPostBack Then
                    fill()
                    sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where emp_code>9999 and emp_code=" & st2 & " order by emp_code"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    Me.cmb_sanc.DataSource = dt
                    Me.cmb_sanc.DataTextField = dt.Columns(0).ColumnName
                    Me.cmb_sanc.DataValueField = dt.Columns(1).ColumnName
                    Me.cmb_sanc.DataBind()
                    Me.txt_rec.Text = Me.cmb_sanc.SelectedItem.Text
                End If
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        Else
            sql = "select access_id from employee_master where emp_code=" & st2 & ""
            Dim dt56 As New DataTable
            dt56 = oh.ExecuteDataSet(sql).Tables(0)
            If dt56.Rows(0)(0) = 51 Then
                If Not IsPostBack Then
                    brfill()
                    sql = "select emp_code||' -- '||emp_name,emp_code from employee_master where emp_code>9999 and emp_code=" & st2 & " order by emp_code"
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    Me.cmb_sanc.DataSource = dt
                    Me.cmb_sanc.DataTextField = dt.Columns(0).ColumnName
                    Me.cmb_sanc.DataValueField = dt.Columns(1).ColumnName
                    Me.cmb_sanc.DataBind()
                    Me.txt_rec.Text = Me.cmb_sanc.SelectedItem.Text
                End If
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If

        End If

    End Sub

   
    Sub fill()
        sql = "select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate||' To '||a.leave_todate,a.emp_code||'*'||a.leave_frdate  from employ_leave_dtl a,employee_master b where a.emp_code=b.emp_code and a.status=0 and b.department_id=" & dt1.Rows(0)(0) & "  order by a.leave_apply_date"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If (dt.Rows.Count = 0) Then
            Me.cmb_ecode.Items.Clear()
            Me.cmb_ecode.Items.Add("NO LEAVES TO BE RECOMMENDED")
            Me.Txt_name.Text = ""
            Me.Txt_dura.Text = ""
            Me.Txt_ap_dt.Text = ""
            Me.Txt_lv_typ.Text = ""
            Me.Txt_reson.Text = ""
        Else
            Me.cmb_ecode.DataSource = dt
            Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_ecode.DataBind()
            data_fill()
        End If
    End Sub
    Sub data_fill()
        Dim st As String = Me.cmb_ecode.SelectedValue
        Dim st1(), st2, st3 As String
        st1 = st.Split("*")
        st2 = st1(0)
        st3 = st1(1)

        sql = "select b.emp_name,c.leave_type,a.leave_frdate,a.leave_todate,a.leave_days,a.leave_apply_date,a.leave_reason from employ_leave_dtl a,employee_master b,leave_master c where a.leave_id=c.leave_id and a.emp_code=b.emp_code and a.emp_code=" & st2 & " and b.department_id=" & dt1.Rows(0)(0) & " and a.leave_frdate='" & st3 & "'  and a.status not in(1,2,3,4,5)"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.Txt_name.Text = dt.Rows(0)(0)
        Me.Txt_dura.Text = dt.Rows(0)(4)
        Me.Txt_ap_dt.Text = dt.Rows(0)(5)
        Me.Txt_lv_typ.Text = dt.Rows(0)(1)
        Me.Txt_reson.Text = dt.Rows(0)(6)

        Me.HiddenField1.Value = Format(dt.Rows(0)(2), "dd/MMM/yyyy")
        Me.HiddenField2.Value = Format(dt.Rows(0)(3), "dd/MMM/yyyy")

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.Txt_name.Text = "" Then
            Me.Lbl_msg.Text = "<font size=3 color=red><b>NO SELECTION</b></font>"
        Else
            Dim tour(4) As OracleParameter
            Dim st As String = Me.cmb_ecode.SelectedValue
            Dim st1(), st2, st3 As String
            st1 = st.Split("*")
            st2 = st1(0)
            st3 = st1(1)
            'Me.HiddenField1.Value = Format(Me.HiddenField1.Value, "dd/MMM/yyyy")
            'Me.HiddenField2.Value = Format(Me.HiddenField2.Value, "dd/MMM/yyyy")
            tour(0) = New OracleParameter("emp_id", OracleType.Int32)
            tour(0).Direction = ParameterDirection.Input
            tour(0).Value = st2
            tour(1) = New OracleParameter("from_date", OracleType.DateTime)
            tour(1).Direction = ParameterDirection.Input
            tour(1).Value = CDate(Me.HiddenField1.Value)
            tour(2) = New OracleParameter("to_date", OracleType.DateTime)
            tour(2).Direction = ParameterDirection.Input
            tour(2).Value = CDate(Me.HiddenField2.Value)
            tour(3) = New OracleParameter("recom_pers", OracleType.Int32)
            tour(3).Direction = ParameterDirection.Input
            tour(3).Value = CInt(Me.cmb_sanc.SelectedValue)
            tour(4) = New OracleParameter("id", OracleType.Int32)
            tour(4).Direction = ParameterDirection.Input
            tour(4).Value = 0
            oh.ExecuteNonQuery("leave_recomnd", tour)

            Me.Lbl_msg.Text = "<FONT SIZE=3 ><B>" & st2 & "---- LEAVE RECOMMENDED </B></FONT>"

            If Me.Session("branch_id") = 0 Then
                fill()
            Else
                brfill()
            End If

        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.Session("branch_id") = 0 Then
            data_fill()
        Else
            brdata_fill()
        End If

    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.Txt_name.Text = "" Then
            Me.Lbl_msg.Text = "<font size=3 color=red><b>NO SELECTION</b></font>"
        Else
            Dim tour(4) As OracleParameter
            Dim st As String = Me.cmb_ecode.SelectedValue
            Dim st1(), st2, st3 As String
            st1 = st.Split("*")
            st2 = st1(0)
            st3 = st1(1)

            tour(0) = New OracleParameter("emp_id", OracleType.Int32)
            tour(0).Direction = ParameterDirection.Input
            tour(0).Value = st2
            tour(1) = New OracleParameter("from_date", OracleType.DateTime)
            tour(1).Direction = ParameterDirection.Input
            tour(1).Value = CDate(Me.HiddenField1.Value)
            tour(2) = New OracleParameter("to_date", OracleType.DateTime)
            tour(2).Direction = ParameterDirection.Input
            tour(2).Value = CDate(Me.HiddenField2.Value)
            tour(3) = New OracleParameter("recom_pers", OracleType.Int32)
            tour(3).Direction = ParameterDirection.Input
            tour(3).Value = CInt(Me.cmb_sanc.SelectedValue)
            tour(4) = New OracleParameter("id", OracleType.Int32)
            tour(4).Direction = ParameterDirection.Input
            tour(4).Value = 1
            oh.ExecuteNonQuery("leave_recomnd", tour)

            Me.Lbl_msg.Text = "<FONT SIZE=3 ><B>" & st2 & "---- LEAVE REJECTED </B></FONT>"
            If Me.Session("branch_id") = 0 Then
                fill()
            Else
                brfill()
            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("../home.aspx")
    End Sub
    Sub brfill()
        sql = "select a.emp_code||'----'||b.emp_name||'   |    '||a.leave_frdate||' To '||a.leave_todate,a.emp_code||'*'||a.leave_frdate  from employ_leave_dtl a,employee_master b where a.emp_code=b.emp_code and a.status=0 and b.branch_id=" & Me.Session("branch_id") & "  order by a.leave_apply_date"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If (dt.Rows.Count = 0) Then
            Me.cmb_ecode.Items.Clear()
            Me.cmb_ecode.Items.Add("NO LEAVES TO BE RECOMMENDED")
            Me.Txt_name.Text = ""
            Me.Txt_dura.Text = ""
            Me.Txt_ap_dt.Text = ""
            Me.Txt_lv_typ.Text = ""
            Me.Txt_reson.Text = ""
        Else
            Me.cmb_ecode.DataSource = dt
            Me.cmb_ecode.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_ecode.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_ecode.DataBind()
            brdata_fill()
        End If
    End Sub
    Sub brdata_fill()
        Dim st As String = Me.cmb_ecode.SelectedValue
        Dim st1(), st2, st3 As String
        st1 = st.Split("*")
        st2 = st1(0)
        st3 = st1(1)

        sql = "select b.emp_name,c.leave_type,a.leave_frdate,a.leave_todate,a.leave_days,a.leave_apply_date,a.leave_reason from employ_leave_dtl a,employee_master b,leave_master c where a.leave_id=c.leave_id and a.emp_code=b.emp_code and a.emp_code=" & st2 & " and b.branch_id=" & Me.Session("branch_id") & " and a.leave_frdate='" & st3 & "'  and a.status not in(1,2,3,4,5)"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Me.Txt_name.Text = dt.Rows(0)(0)
        Me.Txt_dura.Text = dt.Rows(0)(4)
        Me.Txt_ap_dt.Text = dt.Rows(0)(5)
        Me.Txt_lv_typ.Text = dt.Rows(0)(1)
        Me.Txt_reson.Text = dt.Rows(0)(6)

        Me.HiddenField1.Value = Format(dt.Rows(0)(2), "dd/MMM/yyyy")
        Me.HiddenField2.Value = Format(dt.Rows(0)(3), "dd/MMM/yyyy")

    End Sub
End Class
