Imports System.Data
Imports System.Data.OracleClient
Partial Class RD_and_change_bank_rd_change_bank_05dfcc851708
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim str, str1, str2 As String
    Dim dr As DataRow
    Dim res As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Settle Salary And Incentives To Another Branch"
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code from punch_access where emp_code=" & sf(0) & " and status_id=1").Tables(0)
        If dt1.Rows.Count > 0 Then

            Dim script_val As String
            script_val = "var loanno;" & "loanno='" & "" & Me.Txt_EmpCode.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Me.Txt_EmpCode.Attributes.Add("Onchange", "fill1()")
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "sub_call_receiver", "context")
            Dim cbscript As String = "function sub_call_server(arg,context) { " & cbref & "; } "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "sub_call_server", cbscript, True)

            If Not IsPostBack Then
                str2 = "select branch_id,branch_name from branch_master order by branch_name"
                dt2 = oh.ExecuteDataSet(str2).Tables(0)
                Cmb_Branch.DataSource = dt2
                Cmb_Branch.DataTextField = dt2.Columns(1).ColumnName
                Cmb_Branch.DataValueField = dt2.Columns(0).ColumnName
                Cmb_Branch.DataBind()

            End If
        Else
            Server.Transfer("../show_err.aspx")
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim dis As Integer = cal_data
        Dim st As New StringBuilder

        Dim s As Integer = oh.ExecuteDataSet("select count(emp_code) from hrm_employ_verification where emp_code=" & dis & "").Tables(0).Rows(0)(0)
        If s = 1 Then
            Dim sid As Integer = oh.ExecuteDataSet("select nvl(status_id,10) from hrm_employ_verification where emp_code=" & dis & "").Tables(0).Rows(0)(0)
            If sid = 1 Then
                'Dim cl_script As New StringBuilder
                'cl_script.Append(" alert('This Employees Salary/Incentives Cannot Be Transferred!!! ');")
                ''cl_script.Append("       window.open('../home.aspx','_self');")
                'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                st.Append("$1")
                st.Append("@")
                st.Append("!")
                res = st.ToString
            ElseIf sid = 10 Then
                'Dim cl_script1 As New StringBuilder
                'cl_script1.Append(" alert('Please Contact EDP!!! ');")
                ''cl_script.Append("       window.open('../home.aspx','_self');")
                'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
                st.Append("$2")
                st.Append("@")
                st.Append("!")
                res = st.ToString
            ElseIf sid = 0 Then
                Try
                    'str1 = "select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name ||'*'||bm.branch_name||'*'||pm.post_name from employee_master em,employee_master_dtl ed,designation_master dm,department_mst dp,branch_master bm,post_mst pm where em.emp_code=ed.emp_code and em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.branch_id=bm.branch_id and em.post_id=pm.post_id and em.emp_code>9999 and em.emp_code=" & dis & " union select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name||'*'||bc.branch_name||'*'||pm.post_name from employee_master em,employee_master_dtl ed,designation_master dm,department_mst dp,before_completion bc,post_mst pm where em.emp_code=ed.emp_code and em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.branch_id=bc.old_id and bc.branch_id is null and em.post_id=pm.post_id and em.emp_code>9999 and em.emp_code=" & dis & " union select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||'-----'||'*'||bm.branch_name||'*'||'-----' from employee_master em,employee_master_dtl ed,designation_master dm,branch_master bm,post_mst pm where em.emp_code=ed.emp_code and em.designation_id=dm.designation_id and em.department_id=0 and em.branch_id=bm.branch_id and em.post_id=0 and em.emp_code>9999 and em.emp_code=" & dis & ""
                    str1 = "select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name ||'*'||bm.branch_name||'*'||pm.post_name||'*'||(nvl(s.net_pay,0)+nvl(s.bonus,0)-nvl(s.cutting,0))||'*'||sum(nvl(ad.all_amount,0)) from employee_master em left outer join salari s on(em.emp_code=s.emp_id) left outer join incentives_allowances_dtl ad on(em.emp_code=ad.emp_code),designation_master dm,department_mst dp,branch_master bm,post_mst pm where em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.branch_id=bm.branch_id and em.post_id=pm.post_id and em.emp_code>9999 and em.emp_code=" & dis & " group by em.emp_code,em.emp_name,dm.designation,dp.dep_name,bm.branch_name,pm.post_name,s.net_pay,s.bonus,s.cutting union select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name||'*'||bc.branch_name||'*'||pm.post_name||'*'||(nvl(s.net_pay,0)+nvl(s.bonus,0)-nvl(s.cutting,0))||'*'||sum(nvl(ad.all_amount,0)) from employee_master em left outer join salari s on(em.emp_code=s.emp_id) left outer join incentives_allowances_dtl ad on(em.emp_code=ad.emp_code),designation_master dm,department_mst dp,before_completion bc,post_mst pm where em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.branch_id=bc.old_id and bc.branch_id is null and em.post_id=pm.post_id and  em.emp_code>9999 and em.emp_code=" & dis & " group by em.emp_code,em.emp_name,dm.designation,dp.dep_name,bc.branch_name,pm.post_name,s.net_pay,s.bonus,s.cutting union select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||'-----'||'*'||bm.branch_name||'*'||'-----'||'*'||(nvl(s.net_pay,0)+nvl(s.bonus,0)-nvl(s.cutting,0))||'*'||sum(nvl(ad.all_amount,0)) from employee_master em left outer join salari s on(em.emp_code=s.emp_id) left outer join incentives_allowances_dtl ad on(em.emp_code=ad.emp_code),designation_master dm,branch_master bm,post_mst pm where em.designation_id=dm.designation_id and em.department_id=0 and em.branch_id=bm.branch_id and em.post_id=0 and em.emp_code>9999 and em.emp_code=" & dis & " group by em.emp_code,em.emp_name,dm.designation,bm.branch_name,pm.post_name,s.net_pay,s.net_pay,s.bonus,s.cutting"
                    dt1 = oh.ExecuteDataSet(str1).Tables(0)

                Catch ex As Exception
                Finally

                End Try
                If dt1.Rows.Count > 0 Then

                    st.Append(dt1.Rows(0)(0))
                    st.Append("@")
                    st.Append("!")
                Else
                    st.Append("$")
                    st.Append("@")
                    st.Append("!")
                End If
                res = st.ToString
            End If
        ElseIf s = 0 Then
            Try
                'str1 = "select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name ||'*'||bm.branch_name||'*'||pm.post_name from employee_master em,employee_master_dtl ed,designation_master dm,department_mst dp,branch_master bm,post_mst pm where em.emp_code=ed.emp_code and em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.branch_id=bm.branch_id and em.post_id=pm.post_id and em.emp_code>9999 and em.emp_code=" & dis & " union select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name||'*'||bc.branch_name||'*'||pm.post_name from employee_master em,employee_master_dtl ed,designation_master dm,department_mst dp,before_completion bc,post_mst pm where em.emp_code=ed.emp_code and em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.branch_id=bc.old_id and bc.branch_id is null and em.post_id=pm.post_id and em.emp_code>9999 and em.emp_code=" & dis & " union select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||'-----'||'*'||bm.branch_name||'*'||'-----' from employee_master em,employee_master_dtl ed,designation_master dm,branch_master bm,post_mst pm where em.emp_code=ed.emp_code and em.designation_id=dm.designation_id and em.department_id=0 and em.branch_id=bm.branch_id and em.post_id=0 and em.emp_code>9999 and em.emp_code=" & dis & ""
                str1 = "select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name ||'*'||bm.branch_name||'*'||pm.post_name||'*'||(nvl(s.net_pay,0)+nvl(s.bonus,0)-nvl(s.cutting,0))||'*'||sum(nvl(ad.all_amount,0)) from employee_master em left outer join salari s on(em.emp_code=s.emp_id) left outer join incentives_allowances_dtl ad on(em.emp_code=ad.emp_code),designation_master dm,department_mst dp,branch_master bm,post_mst pm where em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.branch_id=bm.branch_id and em.post_id=pm.post_id and em.emp_code>9999 and em.emp_code=" & dis & " group by em.emp_code,em.emp_name,dm.designation,dp.dep_name,bm.branch_name,pm.post_name,s.net_pay,s.net_pay,s.bonus,s.cutting union select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name||'*'||bc.branch_name||'*'||pm.post_name||'*'||(nvl(s.net_pay,0)+nvl(s.bonus,0)-nvl(s.cutting,0))||'*'||sum(nvl(ad.all_amount,0)) from employee_master em left outer join salari s on(em.emp_code=s.emp_id) left outer join incentives_allowances_dtl ad on(em.emp_code=ad.emp_code),designation_master dm,department_mst dp,before_completion bc,post_mst pm where em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.branch_id=bc.old_id and bc.branch_id is null and em.post_id=pm.post_id and  em.emp_code>9999 and em.emp_code=" & dis & " group by em.emp_code,em.emp_name,dm.designation,dp.dep_name,bc.branch_name,pm.post_name,s.net_pay,s.net_pay,s.bonus,s.cutting union select em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||'-----'||'*'||bm.branch_name||'*'||'-----'||'*'||(nvl(s.net_pay,0)+nvl(s.bonus,0)-nvl(s.cutting,0))||'*'||sum(nvl(ad.all_amount,0)) from employee_master em left outer join salari s on(em.emp_code=s.emp_id) left outer join incentives_allowances_dtl ad on(em.emp_code=ad.emp_code),designation_master dm,branch_master bm,post_mst pm where em.designation_id=dm.designation_id and em.department_id=0 and em.branch_id=bm.branch_id and em.post_id=0 and em.emp_code>9999 and em.emp_code=" & dis & " group by em.emp_code,em.emp_name,dm.designation,bm.branch_name,pm.post_name,s.net_pay,s.net_pay,s.bonus,s.cutting"
                dt1 = oh.ExecuteDataSet(str1).Tables(0)

            Catch ex As Exception
            Finally

            End Try
            If dt1.Rows.Count > 0 Then

                st.Append(dt1.Rows(0)(0))
                st.Append("@")
                st.Append("!")
            Else
                st.Append("$")
                st.Append("@")
                st.Append("!")
            End If
            res = st.ToString
        End If

        '                 0              1          2               3                     4               5                                  6                                                                               7

    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Try
            Dim para(3) As OracleParameter

            para(0) = New OracleParameter("empcode", OracleType.Number, 5)
            para(0).Value = Me.Txt_EmpCode.Text
            para(0).Direction = ParameterDirection.Input

            para(1) = New OracleParameter("verifybranch", OracleType.Number)
            para(1).Value = Me.Cmb_Branch.SelectedValue
            para(1).Direction = ParameterDirection.Input

            para(2) = New OracleParameter("flag", OracleType.Number, 1)
            para(2).Direction = ParameterDirection.Output

            para(3) = New OracleParameter("outMsg", OracleType.VarChar, 120)
            para(3).Direction = ParameterDirection.Output

            oh.ExecuteDataSet("hrm_sal_ta_debit_advise", para)

            Dim cl_scriptq As New StringBuilder
            cl_scriptq.Append(" alert('" & para(3).Value & "!!! ');")
            'cl_script.Append("       window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptq.ToString, True)



            'If para(2).Value = 1 Then
            '    Dim cl_scriptq As New StringBuilder
            '    cl_scriptq.Append(" alert('Successfully Inserted!!! ');")
            '    'cl_script.Append("       window.open('../home.aspx','_self');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptq.ToString, True)

            'ElseIf para(2).Value = 2 Then
            '    Dim cl_scriptw As New StringBuilder
            '    cl_scriptw.Append(" alert('Successfully Updated !!! ');")
            '    ' cl_script1.Append("       window.open('../home.aspx','_self');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scriptw.ToString, True)

            '    'ElseIf para(4).Value = 3 Then
            '    '    Dim cl_scripta As New StringBuilder
            '    '    cl_scripta.Append(" alert('You Have No Authority!!! ');")
            '    '    cl_scripta.Append("       window.open('../home.aspx','_self');")
            '    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scripta.ToString, True)

            '    '        'ElseIf para(7).Value = 4 Then
            '    '        '    Dim cl_script3 As New StringBuilder
            '    '        '    cl_script3.Append(" alert('This Item Already made Tally.So Cannot Insert or Update!!! ');")
            '    '        '    'cl_script3.Append("       window.open('../home.aspx','_self');")
            '    '        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script3.ToString, True)
            '    '        '    'MsgBox("hai")
            '    '        '    'fill()

            'ElseIf para(2).Value = 0 Then
            '    Dim cl_script4 As New StringBuilder
            '    cl_script4.Append(" alert('Some Problems may have occured!!! ');")
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script4.ToString, True)

            'End If
        Catch ex As Exception
            Dim cl_script5 As New StringBuilder
            cl_script5.Append("   alert('" & ex.ToString & " ') ;")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script5.ToString, True)

        Finally
        End Try
    End Sub
End Class
