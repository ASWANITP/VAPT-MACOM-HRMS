Imports System.Data
Imports System.Data.OracleClient
Partial Class Auction_Listed_pledges_448d588b1453
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim CbResult As String = Nothing
    Dim dt, dt1 As New DataTable
    Dim a1 As Integer = 0
    Dim s As Integer = 1
    Dim dr As DataRow
    Dim str_tkn As New System.Text.StringBuilder
    Dim sql, sf() As String
    Dim total1, total2, total3, total4, total5, total6, total7, total8, total9, total10, total11, total12, total13, total14, total15, total16, total17, total18, total19, total20, total21, total22, total23, total24, total25, total26, total27, total28, total29 As String
    Dim date1 As Date
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        If Me.Session("user_id") = "" Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append(" alert('Please Login Again and Retry....!! ');")
            cl_script1.Append("    window.open('../main.aspx?key=75872','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            Exit Sub
        End If
        dt1 = oh.ExecuteDataSet("select count(*)  from othleave_sanction_authority t  where (erly_recby = " & Session("user_id").ToString.Split("!")(0) & " or early_sancby = " & Session("user_id").ToString.Split("!")(0) & ")").Tables(0)
        If dt1.Rows(0)(0) = 0 Then
            Server.Transfer("~/show_err.aspx")
        End If
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Me.drop_auth.Attributes.Add("onchange", "fill_data()")
        If Not IsPostBack Then
            sql = "select '---Select---',0 from dual union all select 'Recommendation',1 from dual union all select 'Sanction',2 from dual"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Me.drop_auth.DataSource = dt
            Me.drop_auth.DataTextField = dt.Columns(0).ColumnName
            Me.drop_auth.DataValueField = dt.Columns(1).ColumnName
            Me.drop_auth.DataBind()
        End If
    End Sub
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim menu() As String = cal_data.ToString.Split("$")
        If Me.Session("user_id") = "" Then
            CbResult = "L"
        Else
            sf = Session("user_id").ToString.Split("!")
            Try
                If menu(0) = 1 Then
                    If menu(1) = 1 Then
                        a1 = 1
                        sql = "select e.emp_code || '*' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (0)  and t.emp_id = a.emp_code  and t.erly_recby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID"
                    Else
                        a1 = 2
                        sql = "select e.emp_code || '*' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (4,5,6)  and t.emp_id = a.emp_code  and t.early_sancby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID union select e.emp_code || '*' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.going_dt) || '*' || a.reason from othleave_sanction_authority t, hrm_earlygoing_appl a,employee_master e,department_mst d,designation_master ds,post_mst p,branch b where a.emp_code = e.emp_code  and a.status in (0)  and t.emp_id = a.emp_code  and t.early_sancby = " & sf(0) & "  and e.department_id = d.dep_id  and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id=b.BRANCH_ID and t.erly_recby=0"
                    End If
                    dt = oh.ExecuteDataSet(sql).Tables(0)
                    Dim drw As DataRow
                    For Each drw In dt.Rows
                        str_tkn.Append(drw(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    CbResult = str_tkn.ToString + a1.ToString
                ElseIf menu(0) = 2 Then
                    If menu(2) = "APP" Then
                        Dim str() As String = menu(1).ToString.Split("#")
                        sf = Session("user_id").ToString.Split("!")
                        For i As Integer = 0 To str.Length - 2
                            Dim ptr() As String = str(i).ToString.Split("^")
                            Dim parameter(4) As OracleParameter

                            parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
                            parameter(0).Direction = ParameterDirection.Input
                            parameter(0).Value = ptr(0)

                            parameter(1) = New OracleParameter("go_date", OracleType.DateTime, 150)
                            parameter(1).Direction = ParameterDirection.Input
                            parameter(1).Value = Format(CDate(ptr(1)), "dd/MMM/yyyy")

                            parameter(2) = New OracleParameter("rec_san_emp_code", OracleType.Number, 150)
                            parameter(2).Direction = ParameterDirection.Input
                            parameter(2).Value = sf(0)

                            parameter(3) = New OracleParameter("btn_type", OracleType.Number, 150)
                            parameter(3).Direction = ParameterDirection.Input
                            parameter(3).Value = 1

                            parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
                            parameter(4).Direction = ParameterDirection.Output

                            oh.ExecuteNonQuery("hrm_earlygoing_san", parameter)
                            Dim name As DataTable = oh.ExecuteDataSet("select emp_name from employee_master where emp_code=" & ptr(0) & "").Tables(0)
                            If Not parameter(4).Value.ToString.StartsWith("Block") And Not parameter(4).Value.ToString.StartsWith("Sanctioned") And Not parameter(4).Value.ToString.StartsWith("Recommended") And Not parameter(4).Value.ToString.StartsWith("Sanction") And Not parameter(4).Value.ToString.StartsWith("Reccomentation") And Not parameter(4).Value.ToString.StartsWith("Reccomended") And Not parameter(4).Value.ToString.StartsWith("Cancelled") Then
                                str_tkn.Append("0~")
                                str_tkn.Append(ptr(0) + " " + "(" + name.Rows(0)(0) + ")")
                                str_tkn.Append("~" + parameter(4).Value.ToString + "#")
                            Else
                                str_tkn.Append("1~")
                                str_tkn.Append(ptr(0) + " " + "(" + name.Rows(0)(0) + ")")
                                str_tkn.Append("~" + parameter(4).Value.ToString + "#")
                            End If
                        Next
                        CbResult = str_tkn.ToString + "@APP"
                    ElseIf menu(2) = "REC" Then
                        Dim str() As String = menu(1).ToString.Split("#")
                        sf = Session("user_id").ToString.Split("!")
                        For i As Integer = 0 To str.Length - 2
                            Dim ptr() As String = str(i).ToString.Split("^")
                            Dim parameter(4) As OracleParameter

                            parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
                            parameter(0).Direction = ParameterDirection.Input
                            parameter(0).Value = ptr(0)

                            parameter(1) = New OracleParameter("go_date", OracleType.DateTime, 150)
                            parameter(1).Direction = ParameterDirection.Input
                            parameter(1).Value = Format(CDate(ptr(1)), "dd/MMM/yyyy")

                            parameter(2) = New OracleParameter("rec_san_emp_code", OracleType.Number, 150)
                            parameter(2).Direction = ParameterDirection.Input
                            parameter(2).Value = sf(0)

                            parameter(3) = New OracleParameter("btn_type", OracleType.Number, 150)
                            parameter(3).Direction = ParameterDirection.Input
                            parameter(3).Value = 4

                            parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
                            parameter(4).Direction = ParameterDirection.Output

                            oh.ExecuteNonQuery("hrm_earlygoing_san", parameter)
                            Dim name As DataTable = oh.ExecuteDataSet("select emp_name from employee_master where emp_code=" & ptr(0) & "").Tables(0)
                            If Not parameter(4).Value.ToString.StartsWith("Block") And Not parameter(4).Value.ToString.StartsWith("Sanctioned") And Not parameter(4).Value.ToString.StartsWith("Recommended") And Not parameter(4).Value.ToString.StartsWith("Sanction") And Not parameter(4).Value.ToString.StartsWith("Reccomentation") And Not parameter(4).Value.ToString.StartsWith("Reccomended") And Not parameter(4).Value.ToString.StartsWith("Cancelled") Then
                                str_tkn.Append("0~")
                                str_tkn.Append(ptr(0) + " " + "(" + name.Rows(0)(0) + ")")
                                str_tkn.Append("~" + parameter(4).Value.ToString + "#")
                            Else
                                str_tkn.Append("1~")
                                str_tkn.Append(ptr(0) + " " + "(" + name.Rows(0)(0) + ")")
                                str_tkn.Append("~" + parameter(4).Value.ToString + "#")
                            End If
                        Next
                        CbResult = str_tkn.ToString + "@REC"
                    ElseIf menu(2) = "REJ" Then
                        Dim str() As String = menu(1).ToString.Split("#")
                        sf = Session("user_id").ToString.Split("!")
                        For i As Integer = 0 To str.Length - 2
                            Dim ptr() As String = str(i).ToString.Split("^")
                            Dim parameter(4) As OracleParameter

                            parameter(0) = New OracleParameter("emp_id", OracleType.Number, 150)
                            parameter(0).Direction = ParameterDirection.Input
                            parameter(0).Value = ptr(0)

                            parameter(1) = New OracleParameter("go_date", OracleType.DateTime, 150)
                            parameter(1).Direction = ParameterDirection.Input
                            parameter(1).Value = Format(CDate(ptr(1)), "dd/MMM/yyyy")

                            parameter(2) = New OracleParameter("rec_san_emp_code", OracleType.Number, 150)
                            parameter(2).Direction = ParameterDirection.Input
                            parameter(2).Value = sf(0)

                            parameter(3) = New OracleParameter("btn_type", OracleType.Number, 150)
                            parameter(3).Direction = ParameterDirection.Input
                            parameter(3).Value = 2

                            parameter(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
                            parameter(4).Direction = ParameterDirection.Output

                            oh.ExecuteNonQuery("hrm_earlygoing_san", parameter)
                            Dim name As DataTable = oh.ExecuteDataSet("select emp_name from employee_master where emp_code=" & ptr(0) & "").Tables(0)
                            If Not parameter(4).Value.ToString.StartsWith("Block") And Not parameter(4).Value.ToString.StartsWith("Sanctioned") And Not parameter(4).Value.ToString.StartsWith("Recommended") And Not parameter(4).Value.ToString.StartsWith("Sanction") And Not parameter(4).Value.ToString.StartsWith("Reccomentation") And Not parameter(4).Value.ToString.StartsWith("Reccomended") And Not parameter(4).Value.ToString.StartsWith("Cancelled") Then
                                str_tkn.Append("0~")
                                str_tkn.Append(ptr(0) + " " + "(" + name.Rows(0)(0) + ")")
                                str_tkn.Append("~" + parameter(4).Value.ToString + "#")
                            Else
                                str_tkn.Append("1~")
                                str_tkn.Append(ptr(0) + " " + "(" + name.Rows(0)(0) + ")")
                                str_tkn.Append("~" + parameter(4).Value.ToString + "#")
                            End If
                        Next
                        CbResult = str_tkn.ToString + "@REJ"
                    End If
                End If
            Catch ex As Exception
                CbResult = "E"
            End Try
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function

    Protected Sub b1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles b1.Click
        Dim cl_script1 As New StringBuilder
        cl_script1.Append("    window.open('../../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
    End Sub
End Class
