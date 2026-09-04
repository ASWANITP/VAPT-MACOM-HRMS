Imports System.Data
Imports System.Data.OracleClient
Partial Class LFC_Cash_Balance_ea0da2792020
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim sql As String
    Dim sql1 As String
    Dim sql2 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fromdate As String = (Request.QueryString.Get("fromdt"))
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.TxtSafe11.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        If Session("branch_id") = 0 Then
            Dim usr() As String
            usr = Session("user_id").ToString.Split("!")
            Dim sql As String = "select emp_id from form_accessibility where emp_id=" & usr(0) & " and form_id=130"
            Dim dt11 As New DataTable
            dt11 = oh.ExecuteDataSet(sql).Tables(0)
            If dt11.Rows.Count = 0 Then
                Dim hsrt_str As New StringBuilder
                hsrt_str.Append("alert('You are not authorised Person');")
                hsrt_str.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ret_v", hsrt_str.ToString, True)
            End If
            sql = "select a.firm_id,b.firm_abbr,sum(decode(type,'D',amount,amount*-1))as balance from dtl_transaction a,firm_master b where a.firm_id=b.firm_id and  account_no=33000 and branch_id=0 group by a.firm_id,b.firm_abbr having sum(decode(type,'D',amount,amount*-1))<0"
            dt11 = oh.ExecuteDataSet(sql).Tables(0)
            If dt11.Rows.Count > 0 Then
                Dim i As Integer
                Dim fmStr As String = ""
                For i = 0 To dt11.Rows.Count - 1
                    If fmStr = "" Then
                        fmStr = fmStr + dt11.Rows(i)(1)
                    Else
                        fmStr = fmStr + "," + dt11.Rows(i)(1)
                    End If
                Next
                fmStr = fmStr + "Have Credit Balance Please Rectify and try again"
                Dim hsrt_str As New StringBuilder
                hsrt_str.Append("alert('" & fmStr & "');")
                hsrt_str.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ret_v", hsrt_str.ToString, True)
            End If
        End If
        Me.TxtSafe11.Attributes.Add("onkeyup", "safe11()")
        Me.TxtSafe21.Attributes.Add("onkeyup", "safe21()")
        Me.TxtSafe31.Attributes.Add("onkeyup", "safe31()")
        Me.TxtSafe41.Attributes.Add("onkeyup", "safe41()")
        Me.TxtSafe51.Attributes.Add("onkeyup", "safe51()")
        Me.TxtSafe61.Attributes.Add("onkeyup", "safe61()")
        Me.TxtSafe71.Attributes.Add("onkeyup", "safe71()")
        Me.TxtSafe81.Attributes.Add("onkeyup", "safe81()")
        Me.TxtSafe91.Attributes.Add("onkeyup", "safe91()")
        Me.TxtChangeRs.Attributes.Add("onkeyup", "Change()")
        Me.TxtLateCash.Attributes.Add("onkeyup", " LateCash()")
        Me.TxtChangeRs.Attributes.Add("onkeyup", " CoinChange()")
        Me.TxtChangeRs.Attributes.Add("onfocusout", "FixNumber('TxtChangeRs')")
        Me.TxtLateCash.Attributes.Add("onfocusout", " FixNumber('TxtLateCash')")
        Me.TxtCashbalance.Attributes.Add("onfocusout", " FixNumber('TxtCashbalance')")
        Me.TxtChangeRs.Attributes.Add("onkeyPress", "return isNumberKey1(event)")
        Me.TxtLateCash.Attributes.Add("onkeyPress", "return isNumberKey1(event)")
        'Me.TxtUserID.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe11.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe21.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe31.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe41.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe51.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe61.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe71.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe81.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtSafe91.Attributes.Add("onkeyPress", "return isNumberKey(event)")
        Me.TxtCashbalance.Attributes.Add("onkeyPress", "return Numberonlycash()")
    End Sub
    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        sql1 = "select a.emp_code from employee_master a,post_mst b where a.emp_code='" & User(0) & "' and b.post_id in(10,198,1,235,234,264,251,252,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,45,261,262,271,308,319) and a.status_id=1 and a.post_id=b.post_id"
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        If dt1.Rows.Count > 0 Then
            If Me.rdb_Yes.Checked = False And Me.rdb_No.Checked = False Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('Please Verify Burglary Alarm Working or Not....!!!!');")
                cl_script0.Append("window.open('Cash Balance.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                Exit Sub
            Else
                CallProc()
            End If
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to Confirm/Update....!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
    End Sub
    Sub CallProc()
        Dim fromdate As String = (Request.QueryString.Get("fromdt"))
        Dim p(18) As OracleParameter
        p(0) = New OracleParameter("brid", OracleType.Number, 10)
        p(0).Value = Session("branch_id")

        p(1) = New OracleParameter("safe1000", OracleType.Number, 5)
        p(1).Value = Me.TxtSafe11.Text

        p(2) = New OracleParameter("safe500", OracleType.Number, 5)
        p(2).Value = Me.TxtSafe21.Text

        p(3) = New OracleParameter("safe100", OracleType.Number, 5)
        p(3).Value = Me.TxtSafe31.Text

        p(4) = New OracleParameter("safe50", OracleType.Number, 5)
        p(4).Value = Me.TxtSafe41.Text

        p(5) = New OracleParameter("safe20", OracleType.Number, 5)
        p(5).Value = Me.TxtSafe51.Text

        p(6) = New OracleParameter("safe10", OracleType.Number, 5)
        p(6).Value = Me.TxtSafe61.Text

        p(7) = New OracleParameter("safe5", OracleType.Number, 5)
        p(7).Value = Me.TxtSafe71.Text

        p(8) = New OracleParameter("safe2", OracleType.Number, 5)
        p(8).Value = Me.TxtSafe81.Text

        p(9) = New OracleParameter("safe1", OracleType.Number, 5)
        p(9).Value = Me.TxtSafe91.Text

        p(10) = New OracleParameter("safelate_cash", OracleType.Number, 20)
        p(10).Value = Me.TxtLateCash.Text

        p(11) = New OracleParameter("safetotal", OracleType.Number, 20)
        p(11).Value = Me.TxtSafeTot.Value

        p(12) = New OracleParameter("userId", OracleType.VarChar, 30)
        p(12).Value = Session("user_id")

        p(13) = New OracleParameter("autherId", OracleType.VarChar, 30)
        p(13).Value = Session("user_id")

        p(14) = New OracleParameter("coinamt", OracleType.Number, 20)
        p(14).Value = Me.TxtChangeRs.Text

        p(15) = New OracleParameter("balance", OracleType.Number, 30)
        p(15).Value = Me.TxtCashbalance.Text
        If Me.rdb_Yes.Checked = True Then
            Dim Bur As String = "Y"
            p(16) = New OracleParameter("burglary", OracleType.VarChar, 2)
            p(16).Value = Bur
        ElseIf Me.rdb_No.Checked = True Then
            Dim Bur As String = "N"
            p(16) = New OracleParameter("burglary", OracleType.VarChar, 2)
            p(16).Value = Bur
        ElseIf Me.rdb_Yes.Checked = False And Me.rdb_Yes.Checked = False Then
            Dim Bur As String = ""
            p(16) = New OracleParameter("burglary", OracleType.VarChar, 2)
            p(16).Value = Bur
        End If
        p(17) = New OracleParameter("TDate", OracleType.DateTime)
        p(17).Value = fromdate

        p(18) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
        p(18).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("PUNCH_BR_CASHPOSITION", p)
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("         alert('" + p(18).Value + "');")
        cl_script1.Append("         window.open('hrm_Punch_request.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    End Sub
End Class
