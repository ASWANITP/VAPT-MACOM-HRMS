Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_hrm_HO_Attend_Req_9ae765538976
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim str1 As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.hid_sre.Value = User(0)
        Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "INDIVIDUAL ATTENDANCE REGULARISATION APPROVAL"
        Dim ID As Integer = 211
        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & ID & " and emp_id=" & User(0) & "").Tables(0)
        If dt1.Rows.Count < 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        If Session("branch_id") <> 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        ''*************************
        ''dt = oh.ExecuteDataSet("select d.m_branch, d.curr_date from daily_attend d where (to_date(d.curr_date), d.emp_code) in (select to_date(curr_date), da.emp_code from ATTENDANCE da, time_tab tt where(da.EMP_CODE > 10000) and da.shift_id = tt.shift_id and da.shift_id = tt.shift_id And da.m_time > tt.in_time and da.BRANCH_ID = 0 and da.M_BRANCH = 0 union all select to_date(curr_date), da.emp_code from ATTENDANCE da, branch_time bt1 where(to_date(da.curr_date) = to_date(sysdate)) and da.EMP_CODE > 10000 and bt1.branch_id = da.M_BRANCH And da.m_time > bt1.in_time and da.BRANCH_ID = 0 and da.M_BRANCH <> 0 union all select to_date(curr_date), da.emp_code from ATTENDANCE da,branch_time bt1 where da.EMP_CODE > 10000 and bt1.branch_id = da.M_BRANCH And da.m_time > bt1.in_time and da.BRANCH_ID <> 0) having count(d.m_branch) >0  group by d.m_branch, d.curr_date").Tables(0)
        ''If dt.Rows.Count > 0 Then
        ''    For Each dr In dt.Rows
        ''        str1.Append(dr(0))
        ''        str1.Append(",")
        ''    Next
        ''    str1.Append("9999999")
        ''    Me.hid_branch.Value = str_tkn.ToString
        ''    dt1 = oh.ExecuteDataSet("select a.branch_id from branch_dtl_new a where a.branch_id=" & Session("branch_id") & " and a.branch_id in (" & Me.hid_branch.Value & ")").Tables(0)
        ''    If dt1.Rows.Count < 0 Then
        ''        Dim cl_script0 As New System.Text.StringBuilder
        ''        cl_script0.Append("         alert('You Are Not Authorised!!!!');")
        ''        cl_script0.Append("window.open('../home.aspx','_self');")
        ''        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        ''    End If
        ''End If
        ''**************************
        dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' || d.m_time || '*' ||b.in_time || '*' ||r.requested_dt || '*' || r.remarks from daily_attend d,time_tab b,employee_master e,hrm_anytimepunching_reg r where d.emp_code = e.emp_code  and r.branch_id = d.m_branch  and r.not_punch is null and d.m_shift = b.shift_id and d.m_time > b.in_time and e.emp_code > 10000 and d.m_branch = 0 and d.emp_code = r.requested_by and r.status_id = 0 and (to_date(d.curr_date) = to_date(sysdate) or to_date(d.curr_date) = to_date(sysdate-1)) order by d.emp_code").Tables(0)
        If dt2.Rows.Count > 0 Then
            For Each dr In dt2.Rows
                str_tkn.Append(dr(0))
                str_tkn.Append("!")
            Next
            Me.Hidden3.Value = str_tkn.ToString
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('No Details!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_sre.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim Dataa As String = Instr(0)
                Dim UserID As Integer = Instr(1)
                Dim BrID As Integer = Instr(2)
                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")
                    Dim p(3) As OracleParameter

                    p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                    p(0).Value = Dataa

                    p(1) = New OracleParameter("userId", OracleType.Number, 5)
                    p(1).Value = User(0)

                    p(2) = New OracleParameter("BrID", OracleType.Number, 4)
                    p(2).Value = BrID

                    p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("HRM_HO_ATTEND_APPROVAL", p)
                    CbResult = p(3).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class
