Imports System.Data
Imports System.Data.OracleClient
Partial Class Transfer_Branch_Change_hrm_transBranchChange_0fe5d1481819
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode, PostID, AreaID, RegionID, ZonalID, DepID As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fid As Integer = Session("firm_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Transfer Branch/Date Change"

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtEcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)



        dt = oh.ExecuteDataSet("select * from form_accessibility where FORM_ID=1307 and EMP_ID=" & UserCode & "").Tables(0)
        If dt.Rows.Count <= 0 Then
            Me.Server.Transfer("../show_err.aspx")
        Else

            dt1 = oh.ExecuteDataSet("select -1,'Select' from dual union all select  branch_id,branch_name  from branch_master where firm_id = " & fid & "").Tables(0)
            Me.ddlBranch.DataSource = dt1
            Me.ddlBranch.DataValueField = dt1.Columns(0).ColumnName
            Me.ddlBranch.DataTextField = dt1.Columns(1).ColumnName
            Me.ddlBranch.DataBind()

        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim fid As Integer = Session("firm_id")
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)

        Select Case (x)

            Case "1"
                dt1 = oh.ExecuteDataSet("select count(*) from emp_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & fid & " and e.emp_code= " & str(1) & "").Tables(0)
                If dt1.Rows(0)(0) = 1 Then
                    dt = oh.ExecuteDataSet("select a.emp_name || ' * ' || c.dep_name || ' * ' || d.designation ||'* '|| e.branch_name||'*'||p.post_name||'*'||to_char(a.join_dt) from employee_master a,department_mst c, designation_mst d,branch_dtl_new e,post_mst p where  a.department_id = c.dep_id and a.designation_id = d.designation_id and a.post_id=p.post_id and a.branch_id = e.branch_id and a.status_id = 1 and a.emp_code =" & str(1) & "").Tables(0)
                    If dt.Rows.Count = 0 Then
                        str_tkn.Append("NULL")
                    Else
                        str_tkn.Append(dt.Rows(0)(0))
                        cbResult = str_tkn.ToString
                    End If
                Else
                    str_tkn.Append("         alert('Please Select Valid Emp Code Invalid FIRM');")
                    'str_tkn.Append(" window.open('hrm_PenaltyLeave.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                End If
        End Select
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        If Me.rdBranch.Checked = True Then
            Me.txtDate.Text = 0
        Else
            Me.hdnBranch.Value = 0
        End If
        Try

            Dim p(4) As OracleParameter

            p(0) = New OracleParameter("EmpNo", OracleType.Number, 6)
            p(0).Value = Me.txtEcode.Text

            p(1) = New OracleParameter("Branch", OracleType.Number, 6)
            p(1).Value = Me.hdnBranch.Value

            p(2) = New OracleParameter("CDate", OracleType.VarChar, 15)
            p(2).Value = Me.txtDate.Text

            p(3) = New OracleParameter("ChangeBy", OracleType.Number, 6)
            p(3).Value = UserCode

            p(4) = New OracleParameter("Errmsg", OracleType.VarChar, 500)
            p(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_traBranchChange_proc", p)

            str_tkn.Append("         alert('" & p(4).Value & "');")
            str_tkn.Append(" window.open('hrm_transBranchChange.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception

        End Try
    End Sub

  
End Class
