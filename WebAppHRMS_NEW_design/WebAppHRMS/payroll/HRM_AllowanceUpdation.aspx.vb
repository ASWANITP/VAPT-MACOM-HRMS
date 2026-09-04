Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_SECURITY_HRM_AllowanceUpdation_482c3fd51836
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim CbResult As String = Nothing
    Dim str, pass_data As String
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE TA AND ALLOWANCE UPDATION"
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim dt As New DataTable

        ''Krishnadas Permenent TA Updation-Delete Option 

        If Not IsPostBack Then
            If Session("access_id") <> 33 Then
                Server.Transfer("../show_err.aspx")
            Else
                dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
                Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
                Me.txt_date.Text = Me.hdn_sysdate.Value
                loadallowance()
            End If
        End If
            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.txt_amount.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
            Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
            Me.txt_date.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_date')")
        Me.txt_amount.Attributes.Add("onkeyup", "Numberonly('txt_amount')")
        Me.chk_add.Attributes.Add("onclick", "chk_add1()")
        Me.chk_del.Attributes.Add("onclick", "chk_del1()")
        Me.cmb_allowance.Attributes.Add("onchange", "all_select()")
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim Datastr() As String
        Dim allid() As String
        Dim allowance As Integer
        Datastr = eventArgument.Split("#")
        allid = Datastr(0).Split("%")
        Dim frm As Integer = Session("firm_id")
        Select Case (Datastr(1))
            Case 1
                Dim Instr() As String = Datastr(0).Split("%")
                Dim CODE As String = Instr(0)
                Dim dt1 As DataTable = oh.ExecuteDataSet("select a.emp_code|| '!' ||a.emp_name|| '!' ||c.post_name|| '!' ||b.designation|| '!' || d.branch_name from employee_master a,designation_master b,post_mst c,branch_master d where a.post_id=c.post_id and a.designation_id=b.designation_id and a.branch_id=d.branch_id and a.status_id=1 and a.emp_code=" & CODE & "").Tables(0)
                Dim dr As DataRow
                For Each dr In dt1.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("@")
                Next
                CbResult = str_tkn.ToString
            Case 2
                allowance = allid(0)
                dt2 = oh.ExecuteDataSet("select t.emp_code||'*'||m.emp_name||'*'||t.amount from hrm_ta_employees t join employ_firm f on f.emp_code=t.emp_code and f.firm_id= " & frm & " join employee_master m on m.emp_code=t.emp_code  where t.to_date is null and t.all_id= ' " & allowance & " ' order by t.emp_code").Tables(0)
                If dt2.Rows.Count > 0 Then
                    For Each dr In dt2.Rows
                        str_tkn.Append(dr(0))
                        str_tkn.Append("!")
                    Next
                    CbResult = str_tkn.ToString
                Else
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('No Details!!!!');")
                    cl_script0.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                End If
            Case 3
                Dim all_data(), info(), new_info() As String
                Dim allowanceid As Integer

                Dim itr As Integer
                all_data = allid(0).Split("@")
                allowanceid = CInt(all_data(0))
                info = all_data(1).Split("$")
                For itr = 0 To info.Length - 2
                    new_info = info(itr).Split("^")
                    If new_info(3) = "T" Then
                        pass_data += new_info(0) + "*"
                    End If
                Next
                If pass_data <> "" Or pass_data <> Nothing Then
                    Dim op(6) As OracleParameter
                    op(0) = New OracleParameter("allwan", OracleType.Number, 4)
                    op(0).Value = allowanceid
                    op(1) = New OracleParameter("frdt", OracleType.DateTime)
                    op(1).Value = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0).Rows(0)(0)
                    op(2) = New OracleParameter("emcode", OracleType.VarChar, 1500)
                    op(2).Value = pass_data
                    op(3) = New OracleParameter("amt", OracleType.Number, 6)
                    op(3).Value = 0
                    op(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    op(4).Direction = ParameterDirection.Output
                    op(5) = New OracleParameter("userid", OracleType.VarChar, 100)
                    op(5).Value = Session("user_id")
                    op(6) = New OracleParameter("status", OracleType.Number, 1)
                    op(6).Value = 2
                    oh.ExecuteNonQuery("hrm_ta_spa_insertion", op)
                    CbResult = op(4).Value.ToString
                Else
                    CbResult = "No Items Marked To delete"
                End If
        End Select
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim frm As Integer = Session("firm_id")
            Dim e_firm = oh.ExecuteDataSet("select f.firm_id from employ_firm f where f.emp_code=" & Me.txt_code.Text & "").Tables(0).Rows(0)(0)
            If e_firm = frm Then
                Dim op(6) As OracleParameter
                op(0) = New OracleParameter("allwan", OracleType.Number, 4)
                op(0).Value = Me.cmb_allowance.SelectedValue
                op(1) = New OracleParameter("frdt", OracleType.DateTime)
                op(1).Value = Me.txt_date.Text
                op(2) = New OracleParameter("emcode", OracleType.VarChar, 20)
                op(2).Value = Me.txt_code.Text
                op(3) = New OracleParameter("amt", OracleType.Number, 6)
                op(3).Value = Me.txt_amount.Text
                op(4) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                op(4).Direction = ParameterDirection.Output
                op(5) = New OracleParameter("userid", OracleType.VarChar, 100)
                op(5).Value = Session("user_id")
                op(6) = New OracleParameter("status", OracleType.Number, 1)
                op(6).Value = 1
                oh.ExecuteNonQuery("hrm_ta_spa_insertion", op)
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" + op(4).Value + "');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Not A Valid Employee/Other Firm Employee');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If

        Catch ex As Exception
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Not A Valid Employee');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End Try
    End Sub
    Private Sub loadallowance()
        str = "select 0,'------Select------' from dual union all select a.all_id,a.all_name from incentives_allowances_master a order by 2"
        dt1 = oh.ExecuteDataSet(str).Tables(0)
        Me.cmb_allowance.DataSource = dt1
        Me.cmb_allowance.DataValueField = dt1.Columns(0).ColumnName
        Me.cmb_allowance.DataTextField = dt1.Columns(1).ColumnName
        Me.cmb_allowance.DataBind()
    End Sub
End Class
