Imports System.IO
Imports System.Data
Imports System.Data.oracleclient
Partial Class Lima_Leave_leave_enquiry_5f2a6a2c2992
    Inherits System.Web.UI.Page

    Dim fnm, sql As String
    Dim oh As New helper.oracle.OracleHelper
    Dim res As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_type.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE ENQUIRY"

        If Session("firm_id") = 2 Then
            Dim cl_script As New StringBuilder
            cl_script.Append("window.open('leave_enquiry_new.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
        Else

            If Me.Session("user_id") <> "" Then
                If Not IsPostBack Then
                    Dim dt As DataTable = oh.ExecuteDataSet("select 0 as leave_seq,'-------Select------'  as leave_frdate from dual union all select  h.leave_seq,to_char(h.leave_frdate,'dd/MON/yyyy')||' -'||to_char(h.leave_todate,'dd/MON/yyyy')||' -'||l.leave_type||' -'||c.reason_name from hrm_leave_apply_sanction h,hrm_category_dtl c,leave_master l where h.category_id=c.category_id and h.reason_id=c.reason_id and h.leave_id=l.leave_id and h.status_id not in(1,2,3) and h.emp_code=" & Me.Session("user_id").ToString.Split("!")(0) & " order by leave_frdate").Tables(0)
                    Me.cmb_leave.DataSource = dt
                    Me.cmb_leave.DataValueField = dt.Columns(0).ColumnName
                    Me.cmb_leave.DataTextField = dt.Columns(1).ColumnName
                    Me.cmb_leave.DataBind()
                End If
            Else          ' added on 13-Aug-2010 as per logs..
                Dim cl_script0 As New StringBuilder
                cl_script0.Append(" alert('Please Login Again and Try Again....!! ');")
                cl_script0.Append("    window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script0.ToString, True)
            End If
        End If

    End Sub

   
    Protected Sub txt_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_confirm.Click
        If Me.hid_leaveseq.Value = 0 Then
            Me.txt_result.Text = "Please select a leave !!!"
            Exit Sub
        End If

        Dim tr(3) As OracleParameter
        Try
            tr(0) = New OracleParameter("empcode", OracleType.Number, 6)
            tr(0).Direction = ParameterDirection.Input
            tr(0).Value = Me.Session("user_id").ToString.Split("!")(0)

            tr(1) = New OracleParameter("leaveseq", OracleType.Number, 12)
            tr(1).Direction = ParameterDirection.Input
            tr(1).Value = Me.hid_leaveseq.Value

            tr(2) = New OracleParameter("flag", OracleType.Number, 2)
            tr(2).Direction = ParameterDirection.Output

            tr(3) = New OracleParameter("msg", OracleType.VarChar, 500)
            tr(3).Direction = ParameterDirection.Output


            oh.ExecuteNonQuery("hrm_leave_enquiry", tr)

            Me.txt_result.Text = tr(3).Value
        Catch ex As Exception

        End Try
    End Sub
End Class
