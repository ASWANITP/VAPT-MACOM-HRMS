Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_TA_SANCTION_ccb619c46944
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim CbResult As String = Nothing
    Dim str, pass_data As String
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("firm_id") = 8 Then
            Server.Transfer("~/TA/ta_aprv.aspx")
        End If
        '--JEWEL REQUEST--------10621-Krishnadas-Dec-2015

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYEE TA AND ALLOWANCE UPDATION"
        Dim User(), Sql As String
        User = Session("user_id").ToString.Split("!")
        Dim script_val As String
        If Not IsPostBack Then
            If Session("access_id") = 33 Then
                loadfirst()
            Else
                Sql = "select count(*) from form_accessibility t where t.form_id=1688 and t.emp_id=" & User(0) & ""
                dt = oh.ExecuteDataSet(Sql).Tables(0)
                If CInt(dt.Rows(0)(0)) <= 0 Then
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('You Are Not Authorised to View This Page !');")
                    cl_script0.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                Else
                    loadfirst()
                End If
            End If
        End If
        Me.hid_details.Value = ""
        script_val = "var loanno;" & "loanno='" & "" & Me.cmb_details.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Me.cmb_details.Attributes.Add("onchange", "all_select()")
        Me.cmb_branch.Attributes.Add("onchange", "branch_change()")
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim frm As Integer = Session("firm_id")
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim Datastr() As String
        Dim allid() As String
        Dim branches
        Datastr = eventArgument.Split("#")
        allid = Datastr(0).Split("%")
        Select Case (Datastr(1))
            Case 1
                Dim Instr() As String = Datastr(0).Split("%")
                Dim CODE As String = Instr(0)
                Dim dt1 As DataTable = oh.ExecuteDataSet("select  t.emp_code||'!'||to_char(t.from_dt)||'!'||to_char(t.to_dt)||'!'||t.source||'!'||t.destination||'!'||s.description||'!'||t.distance||'!'||t.req_amount||'!'||k.description||'!'||x.description||'!'||t.request_id|| '!' ||case when t.sanc_amount is null then t.req_amount else t.sanc_amount end   from hrm_ta_request t  join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & frm & "  join employee_master e on e.emp_code = t.emp_code   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=2)s   on t.mode_id=s.status_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=3)k   on k.status_id=t.type_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=1)x   on x.status_id=t.purpose_id  where t.status_id =4  and t.emp_code=" & allid(0) & " ").Tables(0)
                Dim dr As DataRow
                For Each dr In dt1.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("@")
                Next
                CbResult = str_tkn.ToString
            Case 2
                oh.ExecuteNonQuery("update hrm_ta_request t set t.status_id=3,t.cancel_by=" & User(0) & ",t.cancel_dt=sysdate where t.request_id=" & allid(0) & "")
                Dim dt5 As DataTable = oh.ExecuteDataSet("select  emp_code from  hrm_ta_request where request_id =" & allid(0) & "").Tables(0)
                Dim CODE As String = dt5.Rows(0)(0)
                Dim dt1 As DataTable = oh.ExecuteDataSet("select  t.emp_code||'!'||to_char(t.from_dt)||'!'||to_char(t.to_dt)||'!'||t.source||'!'||t.destination||'!'||s.description||'!'||t.distance||'!'||t.req_amount||'!'||k.description||'!'||x.description||'!'||t.request_id|| '!' ||case when t.sanc_amount is null then t.req_amount else t.sanc_amount end   from hrm_ta_request t  join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & frm & "  join employee_master e on e.emp_code = t.emp_code   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=2)s   on t.mode_id=s.status_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=3)k   on k.status_id=t.type_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=1)x   on x.status_id=t.purpose_id  where t.status_id =4  and t.emp_code=" & CODE & " ").Tables(0)
                Dim dr As DataRow
                For Each dr In dt1.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("@")
                Next
                CbResult = str_tkn.ToString
            Case 3
                branches = allid(0)
                dt1 = oh.ExecuteDataSet("select t.emp_code||'!'||t.emp_code || '--' || e.emp_name from hrm_ta_request t   join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & frm & "   join employee_master e on e.emp_code = t.emp_code and e.branch_id in (" & branches & ")  where t.status_id =4  group by t.emp_code, e.emp_name  order by 1  ").Tables(0)
                If dt1.Rows.Count > 0 Then
                    Dim dr1 As DataRow
                    For Each dr1 In dt1.Rows
                        str_tkn.Append(dr1(0))
                        str_tkn.Append("#")
                    Next
                    str_tkn.Append("$")
                End If
                CbResult = str_tkn.ToString
            Case 4
                If IsNumeric(allid(1)) Then
                    oh.ExecuteNonQuery("update hrm_ta_request t set t.sanc_amount=" & allid(1) & " ,t.SANC_AMOUNT_UPDATED_BY =" & User(0) & " ,t.SANC_AMOUNT_UPD_DT= sysdate  where t.request_id =" & allid(0) & "")
                    Dim dt5 As DataTable = oh.ExecuteDataSet("select  emp_code from  hrm_ta_request where request_id =" & allid(0) & "").Tables(0)
                    Dim CODE As String = dt5.Rows(0)(0)
                    Dim dt1 As DataTable = oh.ExecuteDataSet("select  t.emp_code||'!'||to_char(t.from_dt)||'!'||to_char(t.to_dt)||'!'||t.source||'!'||t.destination||'!'||s.description||'!'||t.distance||'!'||t.req_amount||'!'||k.description||'!'||x.description||'!'||t.request_id|| '!' ||case when t.sanc_amount is null then t.req_amount else t.sanc_amount end   from hrm_ta_request t  join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & frm & "  join employee_master e on e.emp_code = t.emp_code   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=2)s   on t.mode_id=s.status_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=3)k   on k.status_id=t.type_id   join (select t.module_id,t.option_id,t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=1)x   on x.status_id=t.purpose_id  where t.status_id =4  and t.emp_code=" & CODE & " ").Tables(0)
                    Dim dr As DataRow
                    For Each dr In dt1.Rows
                        str_tkn.Append(dr(0))
                        str_tkn.Append("@")
                    Next
                    CbResult = str_tkn.ToString
                Else
                    str_tkn.Append("NOTFOUND")
                End If
                CbResult = str_tkn.ToString
        End Select
    End Sub
    Private Sub loadfirst()
        Dim frm As Integer = Session("firm_id")
        Dim branches
        If frm <> 8 Then
            dt2 = oh.ExecuteDataSet("select -1,'-------Select-------' from dual union all select 0,'ADMINISTRATIVE OFFICE' from dual union all select b.branch_id,b.branch_name from branch_master b where b.firm_id=" & frm & " order by 2").Tables(0)
            Me.cmb_branch.DataSource = dt2
            Me.cmb_branch.DataValueField = dt2.Columns(0).ColumnName
            Me.cmb_branch.DataTextField = dt2.Columns(1).ColumnName
            Me.cmb_branch.DataBind()
        Else
            dt2 = oh.ExecuteDataSet("select -1,'-------Select-------' from dual union all select b.branch_id,b.branch_name from branch_master b where b.firm_id=" & frm & " order by 1").Tables(0)
            Me.cmb_branch.DataSource = dt2
            Me.cmb_branch.DataValueField = dt2.Columns(0).ColumnName
            Me.cmb_branch.DataTextField = dt2.Columns(1).ColumnName
            Me.cmb_branch.DataBind()
        End If
        branches = Me.cmb_branch.SelectedValue
        dt1 = oh.ExecuteDataSet("select 0, '-------Select----------'   from dual").Tables(0)
        Me.cmb_details.DataSource = dt1
        Me.cmb_details.DataValueField = dt1.Columns(0).ColumnName
        Me.cmb_details.DataTextField = dt1.Columns(1).ColumnName
        Me.cmb_details.DataBind()
    End Sub
    Protected Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.ServerClick
        Response.Redirect("../home.aspx")
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str, data() As String
        str = Me.hdnDisplay.Value
        If str = String.Empty Or str = "" Or str = Nothing Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No Items to Confirm..');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Me.cmb_branch.SelectedValue = -1

        Else

            data = Me.hdnDisplay.Value.Split("@")
            Dim frm As Integer = Session("firm_id")
            Dim branchid = Session("branch_id")
            Try
                Dim op(4) As OracleParameter
                op(0) = New OracleParameter("details", OracleType.VarChar, 10000)
                op(0).Value = str
                op(1) = New OracleParameter("status", OracleType.Number)
                op(1).Value = 1
                op(2) = New OracleParameter("user_by", OracleType.VarChar, 50)
                op(2).Value = Session("user_id")
                op(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                op(3).Direction = ParameterDirection.Output
                op(4) = New OracleParameter("Errflag", OracleType.Number, 1)
                op(4).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("hrm_ta_request_apply", op)
                If op(4).Value = 1 Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('" + op(3).Value + "');")
                    cl_script1.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('" + op(3).Value + "');")
                    cl_script1.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If


            Catch ex As Exception
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Error Occured..');")
                cl_script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End Try
        End If
    End Sub
End Class
