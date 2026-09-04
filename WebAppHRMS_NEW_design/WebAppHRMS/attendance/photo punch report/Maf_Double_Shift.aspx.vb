Imports System.Data
Imports System.Data.OracleClient
Partial Class maf_22e172ab7320
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1, dta As New DataTable
    Dim str, res, frm As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Double Shift Employee Report"
        ''''Session("firm_id") = 8
        '//-=--===- Common -=-=-==-=//'
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txtEmpCode.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        ''//-=-=-==-=-=-= Call Server Reg.-=-===-=-=//
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        '-=-==-===-=-=-=== End of Common -=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 

        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        dta = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & User(0) & "").Tables(0)
        'If Not IsPostBack Then
        Dim a As Int32
        a = Session("access_id")
        If Session("access_id") <> 33 Then
            Me.Server.Transfer("../show_err.aspx")
        End If


        frm = Session("firm_id")
        If frm <> 28 Then
            Me.Server.Transfer("../show_err.aspx")
            Exit Sub

        End If
        'End If

        'If Not IsPostBack Then
        '    dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=6025 and s.emp_id=" & dta.Rows(0)(0) & "").Tables(0)
        '    If dt1.Rows(0)(0) < 0 Then


        '        Me.Server.Transfer("../show_err.aspx")
        '    End If
        'End If

        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_fromdt.Text = Me.hdn_sysdate.Value
            Me.txt_todt.Text = Me.hdn_sysdate.Value
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim EmpName As String
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                st.Append("11")
                st.Append("@")
                Dim EmpCount As Integer = oh.ExecuteDataSet("select count(*) from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code > 9999 and e.emp_code = " & str(1)).Tables(0).Rows(0)(0)
                If EmpCount = 1 Then
                    EmpName = oh.ExecuteDataSet("select emp_name from employee_master where emp_code = " & str(1)).Tables(0).Rows(0)(0)
                    st.Append(EmpName)
                Else
                    st.Append("N")
                End If
        End Select
        res = st.ToString()
    End Sub

    Protected Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfirm.Click
        Dim EmpCount As Integer = oh.ExecuteDataSet("select count(*) from employee_master e,employ_firm f where e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.emp_code > 9999 and e.emp_code = " & Me.txtEmpCode.Text).Tables(0).Rows(0)(0)
        If EmpCount <> 0 Then
            Dim user() As String
            user = Session("user_id").ToString.Split("!")
            '--------------- ReqID 8592 starts------------------------------
            If Session("firm_id") = 8 Then
                '---------------------end--------------------------------------------------------------------
                If Me.txtEmpCode.Text = user(0) Then
                    'Me.Server.Transfer("Copy (2) of tds.aspx?empcode=" & Me.txtEmpCode.Text)
                    Me.Server.Transfer("Maf_Double_Shift_Report.aspx?empcode=" & Me.txtEmpCode.Text & "&fromdt=" & Me.txt_fromdt.Text & "&todt=" & Me.txt_todt.Text)
                Else
                    Dim dhead As Integer
                    Dim hr As Integer
                    hr = oh.ExecuteDataSet("select t.access_id  from employee_master t where t.emp_code =" & user(0) & "").Tables(0).Rows(0)(0)
                    dhead = oh.ExecuteDataSet("select d.dep_head from employee_master t,department_mst d where d.dep_id=t.department_id and t.emp_code=" & user(0) & "").Tables(0).Rows(0)(0)
                    If user(0) = dhead Or hr = 33 Then
                        Me.Server.Transfer("Maf_Double_Shift_Report.aspx?empcode=" & Me.txtEmpCode.Text & "&fromdt=" & Me.txt_fromdt.Text & "&todt=" & Me.txt_todt.Text)
                    Else
                        Dim msgbx As New System.Text.StringBuilder
                        msgbx.Append("         alert('You Are Not Authorised To View Others Details. Enter Own Emp Code' );")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
                        Exit Sub
                    End If

                End If
                '--------------- ReqID 8592 starts------------------------------
            Else
                'Me.Server.Transfer("Copy (2) of tds.aspx?empcode=" & Me.txtEmpCode.Text)
                Me.Server.Transfer("Maf_Double_Shift_Report.aspx?empcode=" & Me.txtEmpCode.Text & "&fromdt=" & Me.txt_fromdt.Text & "&todt=" & Me.txt_todt.Text)
            End If

            '---------------------end--------------------------------------------------------------------

        Else
            Dim msgbx As New System.Text.StringBuilder
            msgbx.Append("         alert('PLEASE Check the Employee code' );")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", msgbx.ToString, True)
            Exit Sub
        End If

    End Sub
End Class
