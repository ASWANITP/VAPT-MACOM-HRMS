Imports System.Data
Imports System.Data.OracleClient
Partial Class Block_Release_For_Accounts_hrm_Acc_block_release_req_c94a88221945
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

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Punch Block Release Request"

        '======STATUS========
        ' 0--Applied
        ' 1--Sanctioned
        ' 2--Rejected
        ' 3--Cancel
        ' 4--AM Recommended
        ' 5--RM Recommended
        ' 6--RH Recommended
        '10--Acc Block Applied
        '11--Acc Block Sanctioned
        '12--Acc Block Rejected
        '13--Acc Block Recommended
        ' ====================

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtDate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

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

                dt = oh.ExecuteDataSet("select -1 as bid, '------Select------' as blockrea from dual union all select bm.block_id, bm.block_reason from block_master_1 bm, attend eb where eb.block like '%,' || bm.block_id || ',%' and eb.emp_code = " & UserCode & " and bm.block_id not in (select r.block_id from hrm_punchblock_release_req r where r.block_id = bm.block_id and r.req_by = eb.EMP_CODE and r.req_dt = eb.CURR_DATE and r.status not in(2)) and bm.block_id in (252, 269, 268) and to_date(eb.curr_date) = '" & str(1) & " ' and to_date(eb.curr_date) >= (select to_date('19-' || to_char(sysdate - 19, 'mon') || '-' || to_char(sysdate - 19, 'yyyy')) from dual)").Tables(0)
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

    Protected Sub btnconfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconfirm.Click
        Try
            Dim p(4) As OracleParameter

            p(0) = New OracleParameter("Empcode", OracleType.Number, 6)
            p(0).Value = UserCode

            p(1) = New OracleParameter("Blockid", OracleType.Number, 6)
            p(1).Value = Me.hdnBlock.Value

            p(2) = New OracleParameter("Blockdt", OracleType.VarChar, 15)
            p(2).Value = Me.txtDate.Text

            p(3) = New OracleParameter("BlockRes", OracleType.VarChar, 500)
            p(3).Value = Me.txtReason.Text

            p(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_blockRelAcc_rel_req_proc", p)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(4).Value & "');")
            cl_script1.Append("window.open('hrm_Acc_block_release_req.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Catch ex As Exception
        End Try
    End Sub
End Class
