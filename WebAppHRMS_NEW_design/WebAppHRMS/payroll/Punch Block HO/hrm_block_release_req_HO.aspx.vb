Imports System.Data
Imports System.Data.OracleClient
Partial Class Block_Release_Request_hrm_block_release_request_a3860c5e9779
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Punch Block Release Request - HO"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "Punch Block Release Request - HO"
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        dt = oh.ExecuteDataSet("select e.branch_id from employee_master e where e.emp_code = " & UserCode & "").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txtDate.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If
       

    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim x = str(0)
        Select Case (x)
            Case "1"
                dt = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea from dual union all select bm.block_id, bm.block_reason from block_master_1 bm, attend eb where eb.block like '%,' || bm.block_id || ',%' and eb.emp_code = " & UserCode & " and bm.block_id not in (102) and to_date(eb.CURR_DATE) = '" & str(1) & "' and bm.block_id not in (select r.block_id from hrm_punchblock_release_req r where r.block_id=bm.block_id and r.req_dt=to_date(eb.CURR_DATE) and r.req_by = eb.emp_code) and to_date(eb.curr_date) >= '10/Aug/2011' and to_date(eb.curr_date) > (select to_date('21-' || to_char(sysdate - 29, 'mon') || '-' ||  to_char(sysdate - 29, 'yyyy'))  from dual)").Tables(0)
                'dt = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea from dual union all select bm.block_id, bm.block_reason from block_master_1 bm, attend eb where eb.block like '%,' || bm.block_id || ',%' and eb.emp_code = " & UserCode & " and bm.block_id not in (102) and to_date(eb.CURR_DATE) = '" & str(1) & "' and to_date(eb.curr_date) >= (select to_date('25-'||to_char(sysdate-25,'mon')||'-'||to_char(sysdate,'yyyy'))  from dual)").Tables(0)
                res = FillData(res, dt)
                res = res + "@"
        End Select
    End Sub
    Public Function FillData(ByVal cbResult As String, ByVal DT As DataTable) As String
        For n As Integer = 0 To DT.Rows.Count - 1
            cbResult += DT.Rows(n)(0).ToString
            cbResult += "$"
            cbResult += DT.Rows(n)(1).ToString
            If n < DT.Rows.Count - 1 Then
                cbResult += "*"
            End If
        Next
        Return cbResult
    End Function

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Try
            Dim p(3) As OracleParameter

            p(0) = New OracleParameter("Dataa", OracleType.VarChar, 5000)
            p(0).Value = Me.hdnAddId.Value

            p(1) = New OracleParameter("UserId", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("ReqDate", OracleType.VarChar, 15)
            p(2).Value = Me.txtDate.Text

            p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(3).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_punchblock_rel_req_proc", p)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(3).Value & "');")
            cl_script1.Append("window.open('hrm_block_release_req_HO.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Catch ex As Exception
        End Try

    End Sub
End Class
