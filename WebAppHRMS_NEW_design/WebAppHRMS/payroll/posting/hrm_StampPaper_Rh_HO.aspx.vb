Imports System.Data
Imports System.Data.OracleClient
Partial Class Stamp_Paper_Module_hrm_StampPaper_Rh_HO_de296b734260
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim cbResult As String
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), BranchAll(), res, sql, str As String
    Dim UserCode, BranchId, BrId, PostId, ZonalID As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Stamp Paper Updation"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "Stamp Paper Updation"
        'Status
        '-------
        '1 -Received
        '2-Pending
        '3-Reject

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtBranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
       
        dt2 = oh.ExecuteDataSet("select count(f.emp_id) from form_accessibility f where f.form_id=447 and f.emp_id =" & UserCode & "").Tables(0)
        Dim k As Integer = dt2.Rows(0)(0)
        If k = 0 Then
            If Not IsPostBack Then
                Dim cnt As Integer = oh.ExecuteDataSet("select count(*) from emp_stamp z where z.stats = 0 and z.auth_person=" & UserCode).Tables(0).Rows(0)(0)
                If cnt > 0 Then
                    dt1 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct s.emp_code, e.emp_code || '--' || b.BRANCH_NAME ||'--'|| e.join_dt from employee_master e, branch_dtl_new  b, emp_stamp s where e.branch_id = b.BRANCH_ID  and s.emp_code =e.emp_code  and s.auth_person = " & UserCode & " and s.stats = 0 order by ecode").Tables(0)
                    Me.ddlEcode.DataSource = dt1
                    Me.ddlEcode.DataValueField = dt1.Columns(0).ColumnName
                    Me.ddlEcode.DataTextField = dt1.Columns(1).ColumnName
                    Me.ddlEcode.DataBind()
                Else
                    Me.Server.Transfer("show_err.aspx")
                End If
            End If
        Else
            dt1 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as ename from dual union all select distinct s.emp_code, e.emp_code || '--' || b.BRANCH_NAME ||'--'|| e.join_dt from employee_master e, branch_dtl_new  b, emp_stamp s where e.branch_id = b.BRANCH_ID  and s.emp_code =e.emp_code and s.stats = 1 order by ecode").Tables(0)
            Me.ddlEcode.DataSource = dt1
            Me.ddlEcode.DataValueField = dt1.Columns(0).ColumnName
            Me.ddlEcode.DataTextField = dt1.Columns(1).ColumnName
            Me.ddlEcode.DataBind()
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)

        Select Case (x)

            Case "1"

                dt2 = oh.ExecuteDataSet("select e.emp_code||'*'||e.emp_name||'*'||p.post_name||'*'||b.branch_name||'*'||d.dep_name||'*'||to_char(e.join_dt) from employee_master e,branch_dtl_new b,post_mst p,department_mst d where e.branch_id = b.branch_id and e.post_id = p.post_id and e.department_id = d.dep_id and e.status_id = 1 and e.emp_code = " & str(1) & "").Tables(0)
                If dt2.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt2.Rows(0)(0))
                    cbResult = str_tkn.ToString
                End If
        End Select
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim sta As Integer
        dt2 = oh.ExecuteDataSet("select count(f.emp_id) from form_accessibility f where f.form_id=447 and f.emp_id =" & UserCode & "").Tables(0)
        Dim jf As Integer = dt2.Rows(0)(0)
        If jf = 0 Then

            If Me.Chkreject.Checked = False Then
                Me.txtReason.Text = 0
                sta = 0
            Else
                sta = 1
            End If
        Else
            sta = 2
        End If
        Try

            Dim p(4) As OracleParameter

            p(0) = New OracleParameter("EmpNo", OracleType.Number, 6)
            p(0).Value = Me.hdnEcode.Value

            p(1) = New OracleParameter("RecID", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("Stat", OracleType.Number, 2)
            p(2).Value = sta

            p(3) = New OracleParameter("Res", OracleType.VarChar, 500)
            p(3).Value = Me.txtReason.Text

            p(4) = New OracleParameter("Errmsg", OracleType.VarChar, 500)
            p(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_StampPap_Rh_OH_proc", p)

            str_tkn.Append("         alert('" & p(4).Value & "');")
            str_tkn.Append(" window.open('hrm_StampPaper_Rh_HO.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
