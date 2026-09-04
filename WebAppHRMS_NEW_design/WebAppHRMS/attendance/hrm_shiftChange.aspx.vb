Imports System.Data
Imports System.Data.OracleClient
Partial Class Shift_Change_hrm_shiftChange_c4120c359563
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim UserAll(), res, sql, str, frm As String
    Dim UserCode As Integer
    Dim PostID, BranchID, AreaID, RegID As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Dim DesID As Integer
    Dim DepID As Integer
    Dim dept As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ass As DataTable = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & Session("user_id").ToString.Split("!")(0) & " and form_id=2023").Tables(0)
        If ass.Rows(0)(0) = 1 Then
            Server.Transfer("~/payroll/macom shift/hrm_shiftChange2.aspx")
        End If
        '---------70009846
        Dim dept As DataTable = oh.ExecuteDataSet("select count(*)from employee_master t where t.DEPARTMENT_ID in(748,825) and t.emp_code=" & Session("user_id").ToString.Split("!")(0) & " ").Tables(0)
        If dept.Rows(0)(0) = 1 Then
            Response.Redirect("hrm_ShiftChange_Mageeth.aspx")
        End If
        '-----------

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.ddlEmpname.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)

        frm = Me.Session("firm_id")


        CType(Me.Master, WebAppHRMS.edp).Subtitle = "SHIFT CHANGE"

        If Not IsPostBack Then
            dt3 = oh.ExecuteDataSet("select count(*) from department_mst t where t.dep_head=" & UserCode & "").Tables(0)
            If dt3.Rows(0)(0) = 0 Then

                Server.Transfer("../show_err.aspx")

            Else

                dt = oh.ExecuteDataSet("select to_char(to_date(sysdate)) from dual").Tables(0)
                Me.txtDate.Text = dt.Rows(0)(0)
                If (frm = 16) Then

                    dt3 = oh.ExecuteDataSet("select -1 as in_time, '-----Select-----' as sname from dual union all select t.shift_id, t.shift || ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t,time_tab_macare_nw m where t.shift_id=m.shift_id order by in_time").Tables(0)
                    Me.ddlShiftChange.DataSource = dt3
                    Me.ddlShiftChange.DataValueField = dt3.Columns(0).ColumnName
                    Me.ddlShiftChange.DataTextField = dt3.Columns(1).ColumnName
                    Me.ddlShiftChange.DataBind()
                    'Me.ddlShiftChange.Focus()
                Else
                    dt2 = oh.ExecuteDataSet("select -1 as in_time ,'-----Select-----' as sname  from dual union all select t.shift_id, t.shift|| ' --> ' || t.in_time || ' -- ' || t.out_time from time_tab t order by in_time").Tables(0)
                    Me.ddlShiftChange.DataSource = dt2
                    Me.ddlShiftChange.DataValueField = dt2.Columns(0).ColumnName
                    Me.ddlShiftChange.DataTextField = dt2.Columns(1).ColumnName
                    Me.ddlShiftChange.DataBind()
                    'Me.ddlShiftChange.Focus()
                End If

                dt1 = oh.ExecuteDataSet("select -1 as eid,' --------SELECT----------' as  ename from dual union all  select distinct e.emp_code, e.emp_code||'--'||e.emp_name from department_mst d,employee_master e where e.department_id=d.dep_id and e.status_id=1 and d.dep_head= " & UserCode & " and e.emp_code not in " & UserCode & " order by ename").Tables(0)
                Me.ddlEmpname.DataSource = dt1
                Me.ddlEmpname.DataValueField = dt1.Columns(0).ColumnName
                Me.ddlEmpname.DataTextField = dt1.Columns(1).ColumnName
                Me.ddlEmpname.DataBind()
                Me.ddlEmpname.Focus()
            End If
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

                dt2 = oh.ExecuteDataSet("select a.emp_name || ' * ' || c.dep_name || ' * ' || b.post_name || ' * ' || d.designation || ' * ' || e.shift  from employee_master a,post_mst b , department_mst c, designation_mst d,time_tab e where a.post_id = b.post_id and a.department_id = c.dep_id and a.designation_id = d.designation_id and a.shift_id=e.shift_id and a.emp_code = " & str(1) & "").Tables(0)
                str_tkn.Append(dt2.Rows(0)(0))
                cbResult = str_tkn.ToString

            Case "2"

                Dim empid As Integer
                empid = str(1)
                Dim sid As Integer
                sid = str(2)
                Try

                    Dim p(3) As OracleParameter

                    p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
                    p(0).Value = empid

                    p(1) = New OracleParameter("ShID", OracleType.Number, 6)
                    p(1).Value = sid

                    p(2) = New OracleParameter("Uid", OracleType.Number, 8)
                    p(2).Value = UserCode

                    p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("hrm_Shift_Change_head", p)
                    cbResult = p(3).Value
                Catch ex As Exception
                    cbResult = ex.Message

                End Try

        End Select

    End Sub
End Class
