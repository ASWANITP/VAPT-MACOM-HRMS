Imports System.Data
Imports System.Data.OracleClient
Partial Class test_leave_sele_a1f2a89c3813
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim dt1 As New DataTable
    Dim dt2 As New DataTable

    Dim fir, BrNo As Integer
    Dim firm, use As String
    Dim fmid As Integer

    Dim str, res As String
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        fir = Session("firm_id")
        firm = Session("firm_name")


        ' ''Session("firm_id") = 8
        ' ''fir = Session("firm_id")
        ' ''Session("firm_name") = "MACOM"




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
        If Not IsPostBack Then
            Dim FirstDay As String
            Dim TodDate As String

            If fir = 28 Or fir = 8 Or fir = 24 Then
                Dim Month_no As String = oh.ExecuteDataSet("select to_char(to_date(SysDate),'mm') from dual").Tables(0).Rows(0)(0)
                If (CInt(Month_no) > 0 And CInt(Month_no) <= 3) Then
                    FirstDay = oh.ExecuteDataSet("select '01/Apr/'|| to_char(to_char(to_date(SysDate),'yyyy') - 1) from dual").Tables(0).Rows(0)(0)
                Else
                    FirstDay = oh.ExecuteDataSet("select '01/Apr/'||to_char(to_date(SysDate),'yyyy') from dual").Tables(0).Rows(0)(0)
                End If
                TodDate = oh.ExecuteDataSet("select to_char(to_date(SysDate),'dd/Mon/yyyy') from dual").Tables(0).Rows(0)(0)
            Else
                FirstDay = oh.ExecuteDataSet("select '01/Jan/'||to_char(to_date(SysDate),'yyyy') from dual").Tables(0).Rows(0)(0)
                TodDate = oh.ExecuteDataSet("select to_char(to_date(SysDate),'dd/Mon/yyyy') from dual").Tables(0).Rows(0)(0)
            End If

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
                Dim EmpCount As Integer = oh.ExecuteDataSet("select count(*) from employee_master where emp_code > 5999 and emp_code = " & str(1)).Tables(0).Rows(0)(0)
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
        'cnfm
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


        'Restrict Leave report of other firm employees. mail from maben 9/16/2019, 4:51 PM
        If Session("firm_id") = 2 Then
            dt1 = oh.ExecuteDataSet("select count(*) from employee_master t,employ_firm f where t.emp_code=f.emp_code and t.emp_code=" & Me.txtEmpCode.Text & " and f.firm_id = " & Session("firm_id") & " ").Tables(0)
            Dim cnt As Integer
            cnt = dt1.Rows(0)(0)
            If cnt = 0 Then
                str_tkn.Append("         alert('You can not view the leave details of this employee...!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                Exit Sub
            End If
        End If


        '--------------- ReqID 14779 starts------------------------------
        Dim dtTable1 As DataTable = oh.ExecuteDataSet("select t.emp_code from employee_master t where t.department_id in (298) and t.post_id in(85,767) and t.firm_id =" & Session("firm_id") & " and t.emp_code=" & user(0) & " ").Tables(0)

        If dtTable1.Rows.Count > 0 Then

            Dim dtTable2 As DataTable = oh.ExecuteDataSet("select m.branch_id from employee_master m where m.emp_code=" & Me.hidEmpCode.Value & " and m.firm_id =" & Session("firm_id") & " ").Tables(0)
            If dtTable2.Rows.Count > 0 Then
                BrNo = dtTable2.Rows(0)(0).ToString
                'Req. 18384
                If BrNo <> 3325 And BrNo <> 3266 Then
                    str_tkn.Append("         alert('You can not view the leave details of this employee...!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)


                Else


                    Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
                End If
            End If
        End If

        '--------------- ReqID 14779 end------------------------------


        'If Me.Session("branch_id") = 0 Then

        '--------------- ReqID 8592 starts------------------------------
        If Session("firm_id") = 8 Or 24 Then

            '---------------------end-------------------------------------

            If user(0) = 32706 Then


                Dim EmpCnt As Integer = oh.ExecuteDataSet("select count (*) from employee_master y where y.emp_code in(select distinct e.emp_code  from hrm_tour_dtl t, employee_master e,employ_firm ef where t.emp_code = e.emp_code and to_date(t.to_dt) >= to_date(sysdate) and e.emp_code = ef.emp_code and ef.firm_id in (2, 4, 8, 24) and t.emp_code in (select em.emp_code from employee_master em, employ_firm ef where em.status_id = 1 and em.emp_code = ef.emp_code and ef.firm_id in (2, 4, 8, 24) and em.emp_code <> 32706 and em.department_id in (4, 517, 490, 285) and em.emp_code not in(14541, 16288, 16585, 18217, 18963, 19038, 25410, 25470, 46111,55244, 55536, 65072, 68794,  89976)) union select  em.emp_code from employee_master em, employ_firm ef  where em.status_id = 1  and em.emp_code = ef.emp_code and em.emp_code in (100175,100183,100196,100158,100156,27381,25738,69592)) and y.firm_id =" & Session("firm_id") & " and y.emp_code=" & Me.txtEmpCode.Text & "").Tables(0).Rows(0)(0)



                If EmpCnt > 0 Then
                    'If dt2.Rows(0)(0) Then
                    Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
                End If
                If Me.txtEmpCode.Text = user(0) Then
                    Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
                End If
                If EmpCnt <= 0 Then
                    str_tkn.Append("         alert('You can not view the leave details of this employee...!');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)



                End If

            Else


                If Me.txtEmpCode.Text <> user(0) Then
                    Dim dhead As String = ""
                    Dim dtTable As DataTable = oh.ExecuteDataSet("select d.dep_head from department_mst d,employee_master t where t.department_id=d.dep_id and t.emp_code=" & Me.txtEmpCode.Text & "").Tables(0)

                    If dtTable.Rows.Count > 0 Then
                        dhead = dtTable.Rows(0)(0).ToString

                    End If

                    If dhead <> user(0) Then
                        Dim hr As String
                        hr = oh.ExecuteDataSet("select t.access_id from employee_master t where t.emp_code=" & user(0) & "").Tables(0).Rows(0)(0)
                        If hr <> 33 Then
                            str_tkn.Append("         alert('You can not enter other Employee Code.. enter Own...!');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                            Exit Sub

                        ElseIf Me.txtEmpCode.Text = 6480 Then
                            Response.Redirect("leave_rpt_contract.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
                        Else
                            Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
                        End If
                    Else
                        Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
                    End If

                Else
                    Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
                End If
            End If



            '--------------- ReqID 8592 starts------------------------------
        Else
            Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
        End If

        '---------------------end-------------------------------------



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
        ' Else
        '--------------- ReqID 8592 starts------------------------------

        'If Me.txtEmpCode.Text <> user(0) Then
        '    Dim dhead As String
        '    dhead = oh.ExecuteDataSet("select d.dep_head from department_mst d,employee_master t where t.department_id=d.dep_id and t.emp_code=" & Me.txtEmpCode.Text & "").Tables(0).Rows(0)(0)
        '    If dhead <> user(0) Then
        '        Dim hr As String
        '        hr = oh.ExecuteDataSet("select t.access_id from employee_master t where t.emp_code=" & user(0) & "").Tables(0).Rows(0)(0)
        '        If hr <> 33 Then
        '            str_tkn.Append("         alert('You can not enter other Employee Code.. enter Own...!');")
        '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        '            Exit Sub
        '        Else
        '    Me.Server.Transfer("leave_rpt.aspx?emp_code=" & Me.hidEmpCode.Value & "&fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
        'End If
        'Else
        '---------------------end-------------------------------------

        '


        '--------------- ReqID 8592 starts------------------------------
        'End If
        ' Else
        'Me.Server.Transfer("leave_rpt.aspx?fdt=" & Me.txtLeaveFrom.Text & "&tdt=" & Me.txtLeaveToDate.Text)
        '---------------------end-------------------------------------

        'End If
        'End If

    End Sub
End Class
