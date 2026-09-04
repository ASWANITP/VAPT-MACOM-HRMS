Imports System.Data
Imports System.Data.OracleClient
Partial Class test_leave_sele_33ff34cf4895
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim dt1 As New DataTable
    Dim fir As Integer
    Dim firm, use As String
    Dim fmid As Integer
    Dim str, res As String
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        fir = Session("firm_id")
        firm = Session("firm_name")


        'Session("firm_id") = 8
        'fir = Session("firm_id")
        'Session("firm_name") = "MACOM"




        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        use = user(0)
        'MODIFIED THIS PAGE CODE REVIEW..SERVER ERROR
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Employees Leave Report"
        '//-=--===- Common -=-=-==-=//'
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txtEmpCode.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        '//-=-=-==-=-=-= Call Server Reg.-=-===-=-=//
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)

        Dim nam = oh.ExecuteDataSet("select emp_name from employee_master where emp_code = " & user(0) & "").Tables(0).Rows(0)(0)
        Dim firmc = oh.ExecuteDataSet("select count(t.dep_head) from department_mst t where t.firm_id=" & fir & " and t.dep_head=" & user(0) & "").Tables(0).Rows(0)(0)
        'Dim dept = oh.ExecuteDataSet("select d.dep_head from department_mst d,employee_master t where t.department_id=d.dep_id and t.emp_code=" & user(0) & "").Tables(0).Rows(0)(0)
        If firmc = 0 Then
            Me.txtEmpCode.Text = user(0)
            Me.txtEmpName.Text = nam
            Me.hidEmpCode.Value = user(0)
            Me.txtEmpCode.ReadOnly = True
            Me.txtEmpName.ReadOnly = True
        End If


        If Not IsPostBack Then
            Dim FirstDay As String = oh.ExecuteDataSet("select '01/Jan/'||to_char(to_date(SysDate),'yyyy') from dual").Tables(0).Rows(0)(0)
            Dim TodDate As String = oh.ExecuteDataSet("select to_char(to_date(SysDate),'dd/Mon/yyyy') from dual").Tables(0).Rows(0)(0)
            Me.txtLeaveFrom.Text = FirstDay
            Me.txtLeaveToDate.Text = TodDate
            Me.hidLeaveFrom.Value = FirstDay
            Me.hidLeaveTo.Value = TodDate
            '//-=-=-==-===-=End..!!-=-=-==-=-=-=-===--// 

        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str(), Maxdate As String
        Dim oldCnt, oldCode As Integer
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                st.Append("11")
                st.Append("@")
                oldCnt = oh.ExecuteDataSet("select count(*) from employee_master_dtl where new_empcode = " & str(1)).Tables(0).Rows(0)(0)
                If oldCnt = 1 Then
                    oldCode = oh.ExecuteDataSet("select emp_code from employee_master_dtl where new_empcode = " & str(1)).Tables(0).Rows(0)(0)
                Else
                    oldCode = 0
                End If
                Dim EmpCount As Integer = oh.ExecuteDataSet("select count(*) from employee_master where emp_code > 9999 and emp_code = " & str(1)).Tables(0).Rows(0)(0)
                If EmpCount = 1 Then
                    Dim EmpName As String = oh.ExecuteDataSet("select emp_name from employee_master where emp_code = " & str(1) & "").Tables(0).Rows(0)(0)
                    st.Append(EmpName)
                    Dim LevCnt As Integer = oh.ExecuteDataSet("select count(*) from employ_leave_dtl el where emp_code in  (" & str(1) & "," & oldCode & ") and (el.leave_frdate >= to_date('01/Jan/'||to_char(to_date(SysDate),'yyyy')) or el.leave_todate >= to_date('01/Jan/'||to_char(to_date(SysDate),'yyyy'))) and el.leave_process_id <> 0").Tables(0).Rows(0)(0)
                    If LevCnt > 0 Then
                        Maxdate = oh.ExecuteDataSet("select to_char(max(el.leave_todate),'dd/Mon/yyyy') from employ_leave_dtl el where emp_code in  (" & str(1) & "," & oldCode & ") and (el.leave_frdate >= to_date('01/Jan/'||to_char(to_date(SysDate),'yyyy')) or el.leave_todate >= to_date('01/Jan/'||to_char(to_date(SysDate),'yyyy'))) and el.leave_process_id <> 0").Tables(0).Rows(0)(0)
                    Else
                        Maxdate = Format(Date.Today, "dd/MMM/yyyy")
                    End If
                    If LevCnt = 0 Then
                        st.Append("*$")
                    Else
                        st.Append("*")
                        st.Append(Maxdate)
                    End If
                Else
                    st.Append("N")
                End If
        End Select
        res = st.ToString()
    End Sub
    Protected Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfirm.Click

        Dim user() As String
        user = Session("user_id").ToString.Split("!")

        dt1 = oh.ExecuteDataSet("select count(*) from employee_master t where t.emp_code=" & Me.txtEmpCode.Text & "").Tables(0)
        fmid = dt1.Rows(0)(0)
        If fmid = 0 Then

            str_tkn.Append("         alert('Invalid Employee Code...!');")
            ''str_tkn.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Exit Sub
        End If


        If Me.Session("branch_id") = 0 Then



            If Me.txtEmpCode.Text <> User(0) Then
                Dim dhead As String
                dhead = oh.ExecuteDataSet("select d.dep_head from department_mst d,employee_master t where t.department_id=d.dep_id and t.emp_code=" & Me.txtEmpCode.Text & "").Tables(0).Rows(0)(0)
                If dhead <> user(0) Then
                    str_tkn.Append("         alert('You can not enter other Employee Code.. enter Own...!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                    Exit Sub
                Else
                    Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
                End If
            Else
                Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
            End If


            'dt1 = oh.ExecuteDataSet("select ef.firm_id from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & Me.txtEmpCode.Text & "").Tables(0)
            'fmid = dt1.Rows(0)(0)
            'If fmid <> fir Then
            '    str_tkn.Append("         alert('Invalid Employee Code...!');")
            '    str_tkn.Append(" window.open('../Home.aspx','_self');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            '    Exit Sub
            'End If

            'If Me.Session("branch_id") = 0 Then
            'Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
        Else
            If Me.txtEmpCode.Text <> user(0) Then
                Dim dhead As String
                dhead = oh.ExecuteDataSet("select d.dep_head from department_mst d,employee_master t where t.department_id=d.dep_id and t.emp_code=" & Me.txtEmpCode.Text & "").Tables(0).Rows(0)(0)
                If dhead <> user(0) Then
                    str_tkn.Append("         alert('You can not enter other Employee Code.. enter Own...!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                    Exit Sub
                Else
                    Me.Server.Transfer("leave_rpt.aspx?fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)

                End If
            Else
                Me.Server.Transfer("leave_rpt.aspx?fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
            End If
        End If
    End Sub
End Class
