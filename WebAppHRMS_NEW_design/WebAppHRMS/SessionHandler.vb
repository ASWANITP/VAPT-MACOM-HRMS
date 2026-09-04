
Public Class SessionHandler
    Dim Helper As New Helper.Oracle.OracleHelper

    Public Class HrmsLoginSessionResponse
        Public Property sessionid As String
        Public Property empCode As String
        Public Property message As String
        Public Property status As String
    End Class

    Public Class HrmsLoginControlRequest
        Public Property flag As String
        Public Property session As String
        Public Property empCode As String
    End Class

#Region "Quickpay Login register"
    Public Function HrmsLoginControl(ByVal request As HrmsLoginControlRequest) As HrmsLoginSessionResponse


        Dim HrmsLoginSessionResponse As New HrmsLoginSessionResponse()



        Dim sql As String = ""

        If request.flag = "1" Then
            ' /// Check with session id
            sql = "select count(*) from tbl_hrms_login_session t " &
              "where t.empCode='" & request.empCode & "' " &
              "and t.session_id='" & request.session & "'" &
              "and t.logout_dt is null and t.status='1'"

            Dim dt As DataTable = Helper.ExecuteDataSet(sql).Tables(0)

            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0).ToString() = "1" Then
                    HrmsLoginSessionResponse.status = "SUCCESS"
                    HrmsLoginSessionResponse.message = "SESSION IS LIVE"
                Else
                    HrmsLoginSessionResponse.status = "SUCCESS"
                    HrmsLoginSessionResponse.message = "NO LIVE SESSION"
                End If
            End If

        ElseIf request.flag = "2" Then
            ' /// create a session
            sql = "UPDATE tbl_hrms_login_session T Set T.STATUS='2'," &
                "t.LOGOUT_DT=sysdate " &
                " WHERE T.empCode ='" & request.empCode & "' and t.status='1'"
            Helper.ExecuteNonQuery(sql) ' /// update the status to expired.

            sql = "insert into tbl_hrms_login_session " &
              "(empCode,session_id,login_dt,status) values " &
              "('" & request.empCode & "','" & request.session & "',sysdate,'1')"

            Dim res As Integer = Helper.ExecuteNonQuery(sql)
            If res = 1 Then
                HrmsLoginSessionResponse.status = "SUCCESS"
                HrmsLoginSessionResponse.message = "SESSION CREATED SUCCESSFULLY"
                HrmsLoginSessionResponse.sessionid = request.session
                HrmsLoginSessionResponse.empCode = request.empCode
            Else
                HrmsLoginSessionResponse.status = "FAIL"
                HrmsLoginSessionResponse.message = "SESSION CREATION FAILED"
            End If

        ElseIf request.flag = "3" Then
            ' /// update logout time
            sql = "UPDATE tbl_hrms_login_session T " &
              "SET T.LOGOUT_DT=SYSDATE " &
              "WHERE T.session_id='" & request.session & "' " &
              "AND T.empCode='" & request.empCode & "'"

            Dim res As Integer = Helper.ExecuteNonQuery(sql)
            HrmsLoginSessionResponse.status = "SUCCESS"
            HrmsLoginSessionResponse.message = "LOGOUT TIME UPDATED SUCCESSFULLY"

        Else
            HrmsLoginSessionResponse.status = "FAIL"
            HrmsLoginSessionResponse.message = "INVALID FLAG"
        End If


        Return HrmsLoginSessionResponse

    End Function
#End Region


End Class
