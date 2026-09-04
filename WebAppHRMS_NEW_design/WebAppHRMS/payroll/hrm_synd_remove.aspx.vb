Imports System.Data
Imports System.Data.OracleClient
Partial Class Honey_Payroll_hrm_synd_remove_e39993ae4772
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim res As String
    Dim dt, dt1, dt2 As DataTable
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.Cmb_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        Me.Cmb_emp.Attributes.Add("onchange", "ClassOnChange()")


        Dim user() As String = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select count(e.emp_code) from form_accessibility f,employee_master e where e.emp_code=f.emp_id and e.status_id=1 and f.form_id=732 and e.emp_code=" & user(0) & "").Tables(0)
        If dt.Rows(0)(0) = 1 Then
            dt1 = oh.ExecuteDataSet("select 0, '---SELECT---' as emp_code  from dual  union  select e.emp_code, e.emp_code || '---' || e.emp_name  from employee_master_dtl em,  employee_master     e,  employ_firm         f  where e.emp_code = em.emp_code  and e.status_id =1  and e.emp_code=f.emp_code  and f.firm_id=" & Session("firm_id") & "  and em.bank_accno like '4561%'").Tables(0)
            Me.Cmb_emp.DataSource = dt1
            Me.Cmb_emp.DataTextField = dt1.Columns(1).ColumnName
            Me.Cmb_emp.DataValueField = dt1.Columns(0).ColumnName
            Me.Cmb_emp.DataBind()
        Else
            Server.Transfer("../show_err.aspx")

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

           

            Case "2"
                
                dt2 = oh.ExecuteDataSet("select e.emp_code || '*' || e.emp_name || '*' ||  em.bank_accno from employee_master_dtl em,employee_master e where em.emp_code=e.emp_code and e.emp_code='" & str(1) & "' ").Tables(0)
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

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql1 As String
        Dim script1 As New System.Text.StringBuilder
        Try


            sql1 = "update employee_master_dtl em set em.bank_accno =null where em.emp_code=:code"
            Dim parm_coll1(0) As OracleParameter

            parm_coll1(0) = New OracleParameter
            parm_coll1(0).ParameterName = "code"
            parm_coll1(0).OracleType = OracleType.Number
            parm_coll1(0).Direction = ParameterDirection.Input
            parm_coll1(0).Value = Me.hdn1.Value

           

            oh.ExecuteNonQuery(sql1, parm_coll1)


            script1.Append("        alert('Successfully Removed');")
            script1.Append("window.open('../home.aspx','_self');")
        Catch ex As Exception
            script1.Append("        alert('Sorry,Error in Editing');")
        End Try
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)
    End Sub

   
End Class
