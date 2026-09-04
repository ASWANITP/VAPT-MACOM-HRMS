Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_hrm_Ince_Final_conf_fc888fc27332
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt10 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim str1 As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "INCENTIVE FINAL CONFIRMATION"
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_sre.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Dim ID As Integer = 184
        Dim dt As New DataTable
        dt = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & ID & " and emp_id=" & User(0) & "").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        dt2 = oh.ExecuteDataSet("select t.all_id||'*'||im.all_name||'*'||sum(t.all_amount) from incentives_allowances_dtl t, incentives_allowances_master im where t.all_id = im.all_id and t.status=1 group by t.all_id,im.all_name order by im.all_name").Tables(0)
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
                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")
                    Dim p(2) As OracleParameter

                    p(0) = New OracleParameter("Str", OracleType.VarChar, 10000000)
                    p(0).Value = Dataa

                    p(1) = New OracleParameter("userId", OracleType.Number, 5)
                    p(1).Value = User(0)

                    p(2) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(2).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("hrm_ince_final_conf", p)
                    CbResult = p(2).Value

                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class
