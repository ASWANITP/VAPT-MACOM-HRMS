Imports System.IO
Imports System.Data
Imports System.Data.oracleclient
Partial Class leave_enquiry_new_7112549d6127
    Inherits System.Web.UI.Page

    Dim fnm, sql As String
    Dim oh As New helper.oracle.OracleHelper
    Dim res As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt1 As DataTable
        dt1 = oh.ExecuteDataSet("select m.emp_name from employee_master m where m.EMP_CODE=" & Me.Session("user_id").ToString.Split("!")(0) & " ").Tables(0)
        If dt1.Rows.Count > 0 Then
            txtName.Text = dt1.Rows(0)(0) & "  -  " & " [ " & Me.Session("user_id").ToString.Split("!")(0).ToString() & " ] "
        End If
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_type.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE ENQUIRY"
        If Me.Session("user_id") <> "" Then
            If Not IsPostBack Then
                Dim dt As DataTable = oh.ExecuteDataSet("select 0 as leave_seq,'-------Select------'  as leave_frdate from dual union all select  h.leave_seq,to_char(h.leave_frdate,'dd/MON/yyyy')||' -'||to_char(h.leave_todate,'dd/MON/yyyy')||' -'||l.leave_type||' -'||c.reason_name from hrm_leave_apply_sanction h,hrm_category_dtl c,leave_master l where h.category_id=c.category_id and h.reason_id=c.reason_id and h.leave_id=l.leave_id and h.status_id not in(1,2,3) and h.emp_code=" & Me.Session("user_id").ToString.Split("!")(0) & " order by leave_frdate").Tables(0)
                Me.cmb_leave.DataSource = dt
                Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_leave.DataBind()

                dt = oh.ExecuteDataSet("Select 0, '--SELECT--' as leave_desc from dual union Select t.post_type_id,t.post_rule_name from hrm_leave_list_type t").Tables(0)
                Me.cmb_post.DataSource = dt
                Me.cmb_post.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_post.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_post.DataBind()

            End If
        Else          ' added on 13-Aug-2010 as per logs..
            Dim cl_script0 As New StringBuilder
            cl_script0.Append(" alert('Please Login Again and Try Again....!! ');")
            cl_script0.Append("    window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)
        End If

    End Sub


    Protected Sub txt_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_confirm.Click
        If Me.cmb_post.SelectedIndex = 0 Then
            Me.txt_result.Text = "Please select your Post Type !!!"
            Exit Sub
        End If
        If Me.cmb_leave.SelectedIndex = 0 Then
            Me.txt_result.Text = "Please select a Leave !!!"
            Exit Sub
        End If

        Dim tr(6) As OracleParameter
        Try
            tr(0) = New OracleParameter("empcode", OracleType.Number, 6)
            tr(0).Direction = ParameterDirection.Input
            tr(0).Value = Me.Session("user_id").ToString.Split("!")(0)

            tr(1) = New OracleParameter("leaveseq", OracleType.Number, 12)
            tr(1).Direction = ParameterDirection.Input
            tr(1).Value = Me.hid_leaveseq.Value

            tr(2) = New OracleParameter("postid", OracleType.Number)
            tr(2).Direction = ParameterDirection.Input
            tr(2).Value = Me.cmb_post.SelectedValue

            tr(3) = New OracleParameter("firmid", OracleType.Number)
            tr(3).Direction = ParameterDirection.Input
            tr(3).Value = Session("firm_id")

            tr(4) = New OracleParameter("branchno", OracleType.Number)
            tr(4).Direction = ParameterDirection.Input
            tr(4).Value = Session("branch_id")

            tr(5) = New OracleParameter("flag", OracleType.Number, 2)
            tr(5).Direction = ParameterDirection.Output

            tr(6) = New OracleParameter("msg", OracleType.VarChar, 500)
            tr(6).Direction = ParameterDirection.Output


            oh.ExecuteNonQuery("HRM_LEAVE_ENQUIRY_NEW", tr)
            Dim msg As String = tr(6).Value
            If InStr(msg, "*") = 0 Then
                Me.txt_result.Text = msg
            Else
                Dim ar() As String = msg.Split("*")
                Me.txt_result.Text = ar(0) & vbCrLf & ar(1) & vbCrLf & ar(2)
            End If
           
        Catch ex As Exception
            Me.txt_result.Text = ex.Message
        End Try
    End Sub
End Class
