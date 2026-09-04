Imports System.Data
Imports System.Data.OracleClient
Partial Class week_off_Change_hrm_weekof_Change_6e54092f5216
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim cbResult As String
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Dim UserAll(), BranchAll(), res As String
    Dim UserCode, BranchId As Integer
    Dim PostID, AreaID, RegionID, ZonalID, DepID, OpHead, HrHead As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn, str_tkn1 As New System.Text.StringBuilder
    Dim IT As New IT.BLL.Common
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Weekly Off Change"
        Dim masterPage As edp = CType(Me.Master, edp)
        masterPage.subtitle = "Weekly Off Change"
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        dt = oh.ExecuteDataSet("select a.post_id,a.branch_id,a.department_id from employee_master a where a.emp_code=" & UserCode & " and a.status_id=1").Tables(0)
        PostID = dt.Rows(0)(0)
        BranchId = dt.Rows(0)(1)
        DepID = dt.Rows(0)(2)

        'Select Count of Operational Heads
        dt3 = oh.ExecuteDataSet("select count(*) from zonal_master z where z.operation_head=" & UserCode & "").Tables(0)
        OpHead = dt3.Rows(0)(0)

        dt4 = oh.ExecuteDataSet("select count(*) from employee_master e where e.status_id=1 and e.branch_id=0 and e.post_id=85 and e.department_id=70 and e.emp_code=" & UserCode & "").Tables(0)
        HrHead = dt4.Rows(0)(0)


        Dim FormID As Integer = 1747
        Dim dtc As New DataTable
        Dim uid As Array = Session("user_id").split("!")

        dtc = IT.CheckAccess(FormID, CInt(uid(0)))
        If dtc.Rows.Count > 0 Then

            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txtDay.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

            dt = oh.ExecuteDataSet("select -1 as brid,'-----Select Branch-----' as branch from dual union all select b.branch_id,b.branch_name from branch_master b where b.BRANCH_ID not in (0,9999) and b.status_id not in (0,2) and b.firm_id=" & Session("firm_id") & "  order by branch").Tables(0)
            Me.ddlBranch.DataSource = dt
            Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
            Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
            Me.ddlBranch.DataBind()

        Else
            If OpHead > 0 Or HrHead > 0 Or UserCode = 10749 Or UserCode = 11636 Or UserCode = 11453 Or UserCode = 11945 Or UserCode = 22247 Then ' Operation Heads or DGM HRM
                Dim script_val As String
                script_val = "var header;" & "header='" & Me.txtDay.ClientID & "';"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

                Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
                Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
                If UserCode = 10749 Then
                    dt = oh.ExecuteDataSet("select -1 as brid,'-----Select Branch-----' as branch from dual union all select b.branch_id,b.branch_name from branch_master b where b.BRANCH_ID not in (0,9999) and b.status_id not in (0,2) and b.status_id=3 order by branch").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                ElseIf OpHead > 0 Then
                    dt4 = oh.ExecuteDataSet("select a.zonal_id from zonal_master a where a.operation_head=" & UserCode & "").Tables(0)
                    If dt4.Rows.Count >= 1 Then
                        For Each dr In dt4.Rows
                            str_tkn1.Append(dr(0))
                            str_tkn1.Append(",")
                        Next
                        str_tkn1.Append("999")
                        Me.hid_zonal.Value = str_tkn1.ToString
                    End If
                    dt = oh.ExecuteDataSet("select -1 as brid,'-----Select Branch-----' as branch from dual union all select b.branch_id,b.branch_name from branch_dtl_new b where b.BRANCH_ID not in (0,9999) and b.status_id not in (0,2) and b.zonal_id  in (" & Me.hid_zonal.Value & ") order by branch").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                Else
                    dt = oh.ExecuteDataSet("select -1 as brid,'-----Select Branch-----' as branch from dual union all select b.branch_id,b.branch_name from branch_master b where b.BRANCH_ID not in (0,9999) and b.status_id not in (0,2) order by branch").Tables(0)
                    Me.ddlBranch.DataSource = dt
                    Me.ddlBranch.DataValueField = dt.Columns(0).ColumnName
                    Me.ddlBranch.DataTextField = dt.Columns(1).ColumnName
                    Me.ddlBranch.DataBind()
                End If
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
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Select Case (x)
            Case "1"
                dt = oh.ExecuteDataSet("select -1 as ecode,'-----Select Employee-----' as emp from dual union all select e.emp_code,e.emp_code||'-->'||e.emp_name from employee_master e where e.emp_code>10000 and e.status_id=1 and e.branch_id=" & str(1) & "").Tables(0)
                res = FillData(res, dt)
                res = res + "@"
            Case "2"
                dt1 = oh.ExecuteDataSet("select distinct e.emp_code||'*'||e.emp_name||'*'||b.branch_name||'*'||p.post_name||'*'||d.dep_name||'*'||decode(s.holiday,1,'SUNDAY',2,'MONDAY',3,'TUESDAY',4,'WEDNESDAY',5,'THURSDAY',6,'FRIDAY',7,'SATURDAY')from employee_master e,branch_master b,post_mst p,department_mst d,hrm_7days_off_day s where e.branch_id=b.branch_id  and e.post_id=p.post_id and e.department_id=d.dep_id and e.emp_code=s.emp_code and e.status_id=1 and s.to_dt is null and s.status=1 and e.emp_code=" & str(1) & "").Tables(0)
                Dim code As String
                code = str(1).ToString()
                Dim ecode As Integer = CInt(code)
                If dt1.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt1.Rows(0)(0))
                    res = str_tkn.ToString
                    '  res = "@" + res
                End If
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
    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            Dim p(4) As OracleParameter
            p(0) = New OracleParameter("Empcode", OracleType.Number, 6)
            p(0).Value = Me.hdnEcode.Value

            p(1) = New OracleParameter("UserId", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("ChDay", OracleType.Number, 2)
            p(2).Value = Me.hdnDay.Value

            p(3) = New OracleParameter("Reason", OracleType.VarChar, 500)
            p(3).Value = Me.txtReason.Text

            p(4) = New OracleParameter("Outmsg", OracleType.VarChar, 500)
            p(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_weekoffchange_proc", p)
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & p(4).Value & "');")
            cl_script1.Append("window.open('hrm_weekof_Change.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Catch ex As Exception
        End Try
    End Sub
End Class
