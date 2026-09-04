Imports System.Data
Imports System.Data.OracleClient
Partial Class april2010_tour_display_fbfee0d87167
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dr As DataRow
    Dim str, str1 As String
    Dim res As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If

        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.Txt_rec.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim user As Array
        user = Session("user_id").ToString.Split("!")
        Me.Hidtt.Value = user(0)
        '   Me.cmd_serach.Attributes.Add("onclick", "fill1()")
        ' Me.cmb_tour.Attributes.Add("onchange", "fill()")
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)



    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        'Dim SrlNO As Integer = CInt(eventArgument)
        Dim cal_data = eventArgument
        Dim str() As String
        Dim dr As DataRow
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        If str(0) = 1 Then
            Try
                '                     0              1          2               3                     4               5                                  6                                                                               7
                str1 = "select em.emp_name from employee_master em where  em.emp_code =" & str(1) & " and em.status_id=1 "
                dt1 = oh.ExecuteDataSet(str1).Tables(0)
                If dt1.Rows.Count > 0 Then

                    st.Append(dt1.Rows(0)(0))
                    st.Append("@")
                    st.Append("1")
                Else
                    st.Append("#")
                    st.Append("@")
                    st.Append("1")
                End If
            Catch ex As Exception
            Finally

            End Try
        End If

        If str(0) = 2 Then
            Dim p(2) As OracleParameter
            p(0) = New OracleParameter("srno", OracleType.Number, 15)
            p(0).Value = str(1)
            p(1) = New OracleParameter("rec", OracleType.VarChar, 10000)
            p(1).Direction = ParameterDirection.Output
            p(2) = New OracleParameter("sac", OracleType.VarChar, 10000)
            p(2).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_compen_display_1", p)
            st.Append(p(1).Value)
            st.Append("^")
            st.Append(p(2).Value)
            st.Append("@")
            st.Append("2")
        End If
        res = st.ToString
    End Sub
End Class
