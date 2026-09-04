Imports System.Data
Imports System.Data.OracleClient
Partial Class WeeklyOff_hrm_WeekoffImmedchange_cancel_487a6e2f9687
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim cbResult As String
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Dim UserAll(), BranchAll(), res, sql, str As String
    Dim UserCode, BranchId, BrId, PostId, AreaID, RegId As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtEcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Weekly Off Immediate Assigned Cancel"
        Dim masterPage As edp = CType(Me.Master, edp)
        masterPage.subtitle = "Weekly Off Immediate Assigned Cancel"

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)


        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select a.post_id,a.branch_id,a.department_id from employee_master a where a.emp_code=" & UserCode & " and a.status_id=1").Tables(0)
            PostId = dt.Rows(0)(0)
            BranchId = dt.Rows(0)(1)
            dt1 = oh.ExecuteDataSet("select v.area_id,v.reg_id from branch_dtl_new v where branch_id=" & BranchId & "").Tables(0)
            AreaID = dt1.Rows(0)(0)
            RegId = dt1.Rows(0)(1)

            If PostId = 136 Or PostId = 197 Then 'AH or AM 
                dt2 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where s.emp_code=e.emp_code and e.branch_id = b.BRANCH_ID and s.to_dt is null and s.status=1 and s.am_approv_dt=to_date(sysdate) and e.status_id = 1 and b.area_id = " & AreaID & " order by emane").Tables(0)
                Me.ddlEcode.DataSource = dt2
                Me.ddlEcode.DataValueField = dt2.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt2.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
            ElseIf PostId = 199 Then 'RM
                dt2 = oh.ExecuteDataSet("select -1 as ecode, '-----Select-----' as emane from dual union all select e.emp_code,b.BRANCH_NAME || '-->' || e.emp_name || '-->' || e.emp_code from employee_master e, branch_dtl_new b,hrm_7days_off_day s where s.emp_code=e.emp_code and e.branch_id = b.BRANCH_ID and s.to_dt is null and s.status=1 and s.am_approv_dt=to_date(sysdate) and e.status_id = 1 and b.reg_id = " & RegId & " order by emane").Tables(0)
                Me.ddlEcode.DataSource = dt2
                Me.ddlEcode.DataValueField = dt2.Columns(0).ColumnName
                Me.ddlEcode.DataTextField = dt2.Columns(1).ColumnName
                Me.ddlEcode.DataBind()
            Else

                Me.Server.Transfer("../show_err.aspx")
            End If
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String

        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                dt4 = oh.ExecuteDataSet("select distinct e.emp_code || '*' || e.emp_name || '*' || b.BRANCH_NAME || '*' ||p.post_name || '*' || decode(s.holiday,1,'Sunday',2,'Monday',3,'Tuesday',4,'Wednesday',5,'Thursday',6,'Friday',7,'Saturday') || '*' ||decode((select h.holiday from hrm_7days_off_day h where s.emp_code = h.emp_code and h.to_dt is not null and h.am_approv_dt = to_date(sysdate) and h.status = 3),1,'Sunday',2,'Monday',3,'Tuesday',4,'Wednesday',5,'Thursday',6,'Friday',7,'Saturday') from employee_master e, branch_dtl_new b, post_mst p, hrm_7days_off_day s where e.emp_code = s.emp_code and e.branch_id = b.BRANCH_ID and e.post_id = p.post_id and s.am_approv_dt = to_date(sysdate) and s.status = 1 and s.to_dt is null and e.status_id = 1 and e.emp_code =" & str(1) & "").Tables(0)
                If dt4.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                    res = str_tkn.ToString
                Else
                    str_tkn.Append(dt4.Rows(0)(0))
                    res = str_tkn.ToString
                End If
        End Select
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            Dim p(2) As OracleParameter

            p(0) = New OracleParameter("Empcode", OracleType.Number, 6)
            p(0).Value = Me.hdnEcode.Value

            p(1) = New OracleParameter("UserId", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(2).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_weekofchang_Cancel_proc", p)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(2).Value & "');")
            cl_script1.Append("window.open('hrm_WeekoffImmedchange_cancel.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Catch ex As Exception
        End Try
    End Sub
End Class
