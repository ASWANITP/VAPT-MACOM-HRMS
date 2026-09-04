Imports System.Data
Imports System.Data.OracleClient
Partial Class nov2010_Transfer_cancel_8880928d7527
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim res As String
    Dim dt, dt1, dt12, dt13, dt14, dt15 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dr As DataRow
    Dim str, str1, sql3 As String
    Dim resMsg As String
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim SrlNO As Integer = CInt(eventArgument)
        Dim cal_data = eventArgument
        Dim dis As Integer = cal_data
        Dim st As New StringBuilder
        Try
            '                     0              1          2               3                     4               5                                  6                                                                               7
            ' str1 = "select e.emp_code||' --- '||e.emp_name||'*'||d.dep_name||'*'||ds.designation||'*'||p.post_name||'*'||b.branch_name,e.emp_code from employee_master e,department_mst d,designation_master ds,post_mst p,branch_master b where e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=b.branch_id and e.emp_code= union select e.emp_code||' --- '||e.emp_name||'*'||d.dep_name||'*'||ds.designation||'*'||p.post_name||'*'||bc.branch_name||'(N.O.B)',e.emp_code from employee_master e,department_mst d,designation_master ds,post_mst p,before_completion bc where e.department_id=d.dep_id and e.designation_id=ds.designation_id and e.post_id=p.post_id and e.branch_id=bc.old_id and bc.branch_id is null and e.emp_code=" & SrlNO & "" 'ht.emp_code and ht.sr_number=
            str1 = "select e.emp_code||'*'||e.emp_name||'*'||ds.designation||'*'||dp.dep_name||'*'||p.post_name||'*'||b.branch_name||'*'||to_char(r.from_dt)||'*'||p1.post_name||'*'||b1.BRANCH_NAME||'*'||dp1.dep_name from employee_master e,designation_master ds,department_mst dp,branch b,post_mst p,employ_transfer_dtl r,branch b1,post_mst p1,department_mst dp1 where e.emp_code=" & SrlNO & " and e.status_id=1 and e.post_id=p.post_id and e.department_id=dp.dep_id and r.emp_code=e.emp_code and r.to_dt is null and r.status_id=8  and ds.designation_id=e.designation_id and e.branch_id=b.branch_id and r.post_id=p1.post_id and r.branch_id=b1.BRANCH_ID and r.department_id=dp1.dep_id"
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
        Catch ex As Exception
        Finally

        End Try

        res = st.ToString
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_empcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
        Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)
        Dim sf = Session("user_id").ToString.Split("!")
        sql3 = "select count(*) from form_accessibility where emp_id=" & sf(0) & " and form_id=805"
        dt = oh.ExecuteDataSet(sql3).Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Server.Transfer("../show_err.aspx")
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim strr = Session("user_id").ToString.Split(CChar("!"))
        'Dim punch As Integer
        Dim p(2) As OracleParameter
        p(0) = New OracleParameter("empid", OracleType.Number, 7)
        p(0).Value = Me.Txt_empcode.Text
        p(1) = New OracleParameter("msg", OracleType.VarChar, 1000)
        p(1).Direction = ParameterDirection.Output
        p(2) = New OracleParameter("userid", OracleType.Number, 7)
        p(2).Value = strr(0)
        oh.ExecuteNonQuery("hrm_transfer_cancel", p)
        resMsg = p(1).Value

        Dim cl_script9 As New StringBuilder
        cl_script9.Append(" alert('" & resMsg & "');")
        cl_script9.Append("       window.open('Transfer_cancel.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)
    End Sub

End Class
