Imports System.Data
Imports System.Data.OracleClient
Partial Class LOP_to_Personal_Account_LOP_Remove_d7419c009593
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim res As String
    Dim dt, dt1, dt2, dt3 As DataTable
    Dim userall() As String
    Dim us As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LOP TO PERSONAL ACCOUNT - REMOVE"
        userall = Session("user_id").ToString.Split("!")
        us = userall(0)
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.cmb_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        Me.cmb_emp.Attributes.Add("onchange", "ClassOnChange()")
        Dim fid As Integer = Session("Firm_id")
        dt3 = oh.ExecuteDataSet("select count(*) from form_accessibility f where f.form_id=732 and f.emp_id=" & us & " ").Tables(0)
        If dt3.Rows(0)(0) = 1 Then
            If Not IsPostBack Then
                Dim dt As DataTable = oh.ExecuteDataSet("select 0, '---SELECT---' as emp_code  from dual  union  select distinct e.emp_code, e.emp_code || ' - ' || e.emp_name  from employee_master e, employ_leave_dtl em, employ_firm f  where e.emp_code = f.emp_code  and f.firm_id = " & Session("firm_id") & "  and e.emp_code > 9999  and e.emp_code = em.emp_code  and em.leave_process_id = 8  and em.leave_id = 4  order by emp_code").Tables(0)
                Me.cmb_emp.DataSource = dt
                Me.cmb_emp.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_emp.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_emp.DataBind()
                'leavefill()
            End If
        Else
            Me.Server.Transfer("~/show_err.aspx")
        End If
    End Sub



    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim i As Integer = user(0)
        Dim param(2) As OracleParameter
        param(0) = New OracleParameter("userid", OracleType.Number)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = i

        'param(1) = New OracleParameter("leaveseq", OracleType.Number)
        'param(1).Direction = ParameterDirection.Input
        'param(1).Value = Me.cmb_leave.SelectedValue

        param(1) = New OracleParameter("Datas", OracleType.VarChar)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.Hidden4.Value


        param(2) = New OracleParameter("flag", OracleType.Number)
        param(2).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("loppersonalac_rem", param)
        Dim script1 As New System.Text.StringBuilder
        If param(2).Value = 1 Then
            script1.Append("        alert('Successfully Updated');")
            script1.Append("window.open('../home.aspx','_self');")
            ' leavefill()
        Else
            script1.Append("        alert('Sorry,Error in Editing');")
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
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


                dt = oh.ExecuteDataSet("select -1 as manu_id, '---Select MANUAL NAME---' as manu_name from dual union all select b.manu_id,b.manu_name from manual_new b order by manu_id").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "2"
                'If str(1) = "1" Then
                'dt2 = oh.ExecuteDataSet("select em.emp_code || '*' || em.emp_name || '*' || dm.designation || '*' || p.post_name || '*' || dp.dep_name from employee_master  em, designation_master dm, post_mst   p, department_mst dp where em.designation_id = dm.designation_id  and em.post_id = p.post_id and em.status_id = 1 and not exists (select m.emp_code from hrm_manual_send m where em.emp_code=m.emp_code and m.manu_id=" & str(1) & ") and em.department_id = dp.dep_id  and em.join_dt between to_date('" & str(2) & "') and to_date('" & str(3) & "') order by em.emp_code").Tables(0)
                dt2 = oh.ExecuteDataSet("select distinct e.emp_code || '*' || e.leave_frdate || '*' ||  e.leave_todate as frdate  from employ_leave_dtl e  where e.leave_id = 4  and e.leave_process_id = 8  and e.emp_code = '" & str(1) & "'  order by frdate").Tables(0)
                Dim dr As DataRow

                For Each dr In dt2.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                res = str_tkn.ToString


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


End Class
