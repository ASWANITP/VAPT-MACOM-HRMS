Imports System.Data
Imports System.Data.OracleClient
Partial Class neft_customer_verify_00_e9f18c947720
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim ch As New WholeHelper.ClsComCtrl
    Dim cas As Integer
    Dim CallBackString, sql_brnch_srt As String
    Dim str As New System.Text.StringBuilder
    Dim Choice As Integer
    Dim DT As New DataTable

    Dim IT As New IT.BLL.Common

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        '=====================================
        ' MODIFY MODULE
        ' Author: Harikrishnan M.
        ' Date  : 13/Dec/2011
        ' Module: HRM NEFT VERIFICATION Module
        '=====================================
        'IF ANY  MODIIFCATION

        '=====================================
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dep_script As String
        Dim dt_brnch_srt As DataTable
        Choice = CInt(Request.QueryString.Get("choice"))
        Me.Hidd_choice.Value = Choice

        Dim FormID As Integer = 385
        Dim uid As Array = Session("user_id").split("!")
        DT = IT.CheckAccess(FormID, CInt(uid(0)))
        If DT.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised To Do This Job');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If


        dep_script = " var invoice ;invoice='" & Me.hdn_sysdate.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "dep", dep_script, True)
        If Choice = 1 Then '' FOR HRM employes
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "NEFT EMPLOYEE-SALARY"
            Me.label1.text = "NEFT VERIFICATION"
        ElseIf Choice = 2 Then '' FOR jewellery
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "NEFT JEWELLERY EMPLOYEE-SALARY"
            Me.label1.text = "NEFT VERIFICATION"
        End If

        Me.hidCase.Value = cas
        If Not IsPostBack Then
            Me.hdn_sysdate.Value = get_brdt(Me.Session("branch_id"), "/")
            If Choice = 1 Then  ' For OTHER SALARY NEFT CONFIRMATION
                sql_brnch_srt = "select -1 branchid, '--Select All --' branchname  from dual  union all  select bm.branch_id branchid, initcap(bm.branch_name) branchname  from Neft_Customer nc,  Branch_Master bm,  M_Wage        mw  where nc.moduleid = 90  and nc.firm_id = " & session("firm_id") & "  and nc.status = 1  and bm.branch_id = mw.branch_id  and mw.emp_code = nc.cust_ref_id  and mw.status_id = 1  and not exists (select nh.emp_code  from hrm_neft_confirmation nh  where nh.emp_code = nc.cust_ref_id)  and not exists (select ev.emp_code  from hrm_employ_verification ev  where ev.status_id = 1  and ev.rec_by = 'BLOCK'  and ev.emp_code = nc.cust_ref_id)  and not exists (select emp_code  from hrm_sd_confirmation h  where h.emp_code = nc.cust_ref_id           and h.given_status = 1) group by bm.branch_id, bm.branch_name order by branchname"
            Else ' For JEWL SALARY NEFT CONFIRMATION
                sql_brnch_srt = "select -1 branchid, '--Select All --' branchname  from dual  union all  select bm.branch_id branchid, initcap(bm.branch_name) branchname  from Neft_Customer nc,  Branch_Master bm,  M_Wage        mw  where nc.moduleid = 90  and nc.firm_id = 24  and nc.status = 1  and bm.branch_id = mw.branch_id  and mw.emp_code = nc.cust_ref_id  and mw.status_id = 1  and not exists (select nh.emp_code  from hrm_neft_confirmation nh  where nh.emp_code = nc.cust_ref_id)  and not exists (select ev.emp_code  from hrm_employ_verification ev  where ev.status_id = 1  and ev.rec_by = 'BLOCK'  and ev.emp_code = nc.cust_ref_id)  and not exists (select emp_code  from hrm_sd_confirmation h  where h.emp_code = nc.cust_ref_id           and h.given_status = 1) group by bm.branch_id, bm.branch_name order by branchname"
            End If
            dt_brnch_srt = oh.ExecuteDataSet(sql_brnch_srt).Tables(0)
            ch.ComboFill(Me.cmb_sort_branch, dt_brnch_srt, 0, 1)
        End If

        Me.cmb_sort_branch.Attributes.Add("onblur", "return cmb_srtBranchChange()")
        Me.txtEmpCode.Attributes.Add("onblur", "return txtEmpcodeOnblur()")

        Me.Check_all.Attributes.Add("onclick", "return checkall_select()")
        Me.cmd_report.Attributes.Add("onclick", "return confirm_CheckNeftData()")

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"

        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)

    End Sub
    Protected Sub cmd_report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_report.Click

        Dim Message As String
        Dim status As Integer
        Dim pr(6) As OracleParameter
        Dim oh As New helper.oracle.OracleHelper
        Try

            pr(0) = New OracleParameter("Neft_Data_All", OracleType.VarChar, 5000)
            pr(0).Value = CStr(Me.Hidd_confirm.Value)
            pr(1) = New OracleParameter("Update_UserId", OracleType.VarChar, 100)
            pr(1).Value = CStr(Session("user_id"))
            pr(2) = New OracleParameter("ErrMsg", OracleType.VarChar, 100)
            pr(2).Direction = ParameterDirection.Output
            pr(3) = New OracleParameter("ErrorStat", OracleType.Number, 10)
            pr(3).Direction = ParameterDirection.Output
            pr(4) = New OracleParameter("ForMonth", OracleType.Number, 3)
            pr(4).Value = CInt(Me.Hidd_sal_month.Value)
            pr(5) = New OracleParameter("ForYear", OracleType.VarChar, 5)
            pr(5).Value = CInt(Me.Hidd_sal_year.Value)
            pr(6) = New OracleParameter("Firm_id", OracleType.Number, 5)
            pr(6).Value = session("firm_id")

            oh.ExecuteNonQuery("Hrm_NeftConfirmation", pr)
            Message = pr(2).Value
            status = pr(3).Value

        Catch ex As Exception
            Message = "Can not Verify,  Error Code Please Check Details!!"
        End Try

        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("         alert('" & Message & "');")
        cl_script1.Append("         window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

    End Sub
    Public Function get_brdt(ByVal br_id As Integer, ByVal DtFmt As String) As String

        Dim sql As String = ""
        If DtFmt.Trim = "-" Then
            sql = "select to_char(to_date(sysdate),'DD-MON-YYYY') from dual"
        End If
        If DtFmt.Trim = "/" Then
            sql = "select to_char(to_date(sysdate),'DD/MM/YYYY') from dual"
        End If
        Dim dtt As New DataTable
        dtt = oh.ExecuteDataSet(sql).Tables(0)
        If dtt.Rows.Count > 0 Then
            Return dtt.Rows(0)(0)
        End If
        Return ""

    End Function

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CallBackString
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim DataString() As String = eventArgument.ToString.Split("^")
        Select Case DataString(0)

            Case 1 ' FOR ALL BRANCH LIST

                Dim dt As New DataTable
                Dim dr As DataRow
                Dim sql1 As String

                If Me.Hidd_choice.Value = 1 Then  'Employee salary 
                    sql1 = "select nc.cust_ref_id,  nc.branch_id || '�' || initcap(bm.branch_name) || '�' ||  initcap(nc.cust_name) || '�' || nc.cust_ref_id || '�' || nc.ifsc_code || '�' ||  nc.beneficiary_account || '�' || initcap(nc.beneficiary_branch) || '�' ||  nc.acc_type || '�' || nc.user_id || '�' || nc.firm_id || '�' ||  nc.bank_id || '�' || mw.emp_code || '�' || initcap(mw.name) || '�' ||  (mw.net_pay + mw.bonus - mw.cutting) || '�' || mw.ta_total || '�' ||  to_char(mw.sal_dt, 'MM') || '�' || to_char(mw.sal_dt, 'YYYY') || '�' ||  to_char(mw.sal_dt, 'Month') as sal_month_0    from Neft_Customer nc, Branch_Master bm, M_Wage mw  where nc.moduleid = 90  and nc.status = 1  and bm.branch_id = mw.branch_id  and mw.emp_code = nc.cust_ref_id  and mw.status_id = 1  and not exists (select nh.emp_code  from hrm_neft_confirmation nh  where nh.emp_code = nc.cust_ref_id)  and not exists (select ev.emp_code  from hrm_employ_verification ev  where ev.status_id = 1  and ev.rec_by <> 'BLOCK'  and ev.emp_code = nc.cust_ref_id)  and not exists (select emp_code  from hrm_sd_confirmation h  where h.emp_code = nc.cust_ref_id  and h.given_status = 1)    and mw.rec_firm =" & session("firm_id") & "  order by bm.branch_name"
                Else ' Jewellery salary.
                    sql1 = "select nc.cust_ref_id,  nc.branch_id || '�' || initcap(bm.branch_name) || '�' ||  initcap(nc.cust_name) || '�' || nc.cust_ref_id || '�' || nc.ifsc_code || '�' ||  nc.beneficiary_account || '�' || initcap(nc.beneficiary_branch) || '�' ||  nc.acc_type || '�' || nc.user_id || '�' || nc.firm_id || '�' ||  nc.bank_id || '�' || mw.emp_code || '�' || initcap(mw.name) || '�' ||  (mw.net_pay + mw.bonus - mw.cutting) || '�' || mw.ta_total || '�' ||  to_char(mw.sal_dt, 'MM') || '�' || to_char(mw.sal_dt, 'YYYY') || '�' ||  to_char(mw.sal_dt, 'Month') as sal_month_0    from Neft_Customer nc, Branch_Master bm, M_Wage mw  where nc.moduleid = 90  and nc.status = 1  and bm.branch_id = mw.branch_id  and mw.emp_code = nc.cust_ref_id  and mw.status_id = 1  and not exists (select nh.emp_code  from hrm_neft_confirmation nh  where nh.emp_code = nc.cust_ref_id)  and not exists (select ev.emp_code  from hrm_employ_verification ev  where ev.status_id = 1  and ev.rec_by <> 'BLOCK'  and ev.emp_code = nc.cust_ref_id)  and not exists (select emp_code  from hrm_sd_confirmation h  where h.emp_code = nc.cust_ref_id  and h.given_status = 1)    and mw.rec_firm = 24  order by bm.branch_name"
                End If

                dt = oh.ExecuteDataSet(sql1).Tables(0)

                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        str.Append(dr(1))
                        str.Append("�")
                    Next
                Else
                    str.Append("�")
                End If

            Case 2 ' FOR SELECTED BRANCH LIST

                Dim dt As New DataTable
                Dim dr As DataRow
                Dim sort_branch As Double
                sort_branch = CDbl(DataString(2))
                Dim sql1 As String
                If Me.Hidd_choice.Value = 1 Then
                    sql1 = "select nc.cust_ref_id,  nc.branch_id || '�' || initcap(bm.branch_name) || '�' ||  initcap(nc.cust_name) || '�' || nc.cust_ref_id || '�' || nc.ifsc_code || '�' ||  nc.beneficiary_account || '�' || initcap(nc.beneficiary_branch) || '�' ||  nc.acc_type || '�' || nc.user_id || '�' || nc.firm_id || '�' ||  nc.bank_id || '�' || mw.emp_code || '�' || initcap(mw.name) || '�' ||  (mw.net_pay + mw.bonus - mw.cutting) || '�' || mw.ta_total || '�' ||  to_char(mw.sal_dt, 'MM') || '�' || to_char(mw.sal_dt, 'YYYY') || '�' ||  to_char(mw.sal_dt, 'Month') as sal_month_0  from Neft_Customer nc, Branch_Master bm, M_Wage mw  where nc.moduleid = 90  and nc.status = 1  and bm.branch_id = mw.branch_id  and mw.emp_code = nc.cust_ref_id  and mw.status_id = 1  and not exists (select nh.emp_code  from hrm_neft_confirmation nh  where nh.emp_code = nc.cust_ref_id)  and not exists (select ev.emp_code  from hrm_employ_verification ev  where ev.status_id = 1  and ev.rec_by <> 'BLOCK'  and ev.emp_code = nc.cust_ref_id)  and not exists (select emp_code  from hrm_sd_confirmation h  where h.emp_code = nc.cust_ref_id  and h.given_status = 1)  and mw.rec_firm =" & session("firm_id") & "  and mw.branch_id = " & sort_branch & " order by bm.branch_name"
                Else
                    sql1 = "select nc.cust_ref_id,  nc.branch_id || '�' || initcap(bm.branch_name) || '�' ||  initcap(nc.cust_name) || '�' || nc.cust_ref_id || '�' || nc.ifsc_code || '�' ||  nc.beneficiary_account || '�' || initcap(nc.beneficiary_branch) || '�' ||  nc.acc_type || '�' || nc.user_id || '�' || nc.firm_id || '�' ||  nc.bank_id || '�' || mw.emp_code || '�' || initcap(mw.name) || '�' ||  (mw.net_pay + mw.bonus - mw.cutting) || '�' || mw.ta_total || '�' ||  to_char(mw.sal_dt, 'MM') || '�' || to_char(mw.sal_dt, 'YYYY') || '�' ||  to_char(mw.sal_dt, 'Month') as sal_month_0  from Neft_Customer nc, Branch_Master bm, M_Wage mw  where nc.moduleid = 90  and nc.status = 1  and bm.branch_id = mw.branch_id  and mw.emp_code = nc.cust_ref_id  and mw.status_id = 1  and not exists (select nh.emp_code  from hrm_neft_confirmation nh  where nh.emp_code = nc.cust_ref_id)  and not exists (select ev.emp_code  from hrm_employ_verification ev  where ev.status_id = 1  and ev.rec_by <> 'BLOCK'  and ev.emp_code = nc.cust_ref_id)  and not exists (select emp_code  from hrm_sd_confirmation h  where h.emp_code = nc.cust_ref_id  and h.given_status = 1)  and mw.rec_firm = 24  and mw.branch_id = " & sort_branch & " order by bm.branch_name"
                End If
                dt = oh.ExecuteDataSet(sql1).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        str.Append(dr(1))
                        str.Append("�")
                    Next
                Else
                    str.Append("�")
                End If

            Case 3 ' FOR SELECTED EMPLOYEE LIST

                Dim dt As New DataTable
                Dim dr As DataRow
                Dim searchEmpCode As Double
                searchEmpCode = CDbl(DataString(2))
                Dim sql1 As String

                If Me.Hidd_choice.Value = 1 Then
                    sql1 = "select nc.cust_ref_id,  nc.branch_id || '�' || initcap(bm.branch_name) || '�' ||  initcap(nc.cust_name) || '�' || nc.cust_ref_id || '�' || nc.ifsc_code || '�' ||  nc.beneficiary_account || '�' || initcap(nc.beneficiary_branch) || '�' ||  nc.acc_type || '�' || nc.user_id || '�' || nc.firm_id || '�' ||  nc.bank_id || '�' || mw.emp_code || '�' || initcap(mw.name) || '�' ||  (mw.net_pay + mw.bonus - mw.cutting) || '�' || mw.ta_total || '�' ||  to_char(mw.sal_dt, 'MM') || '�' || to_char(mw.sal_dt, 'YYYY') || '�' ||  to_char(mw.sal_dt, 'Month') as sal_month_0  from Neft_Customer nc, Branch_Master bm, M_Wage mw  where nc.moduleid = 90  and nc.status = 1  and bm.branch_id = mw.branch_id  and mw.emp_code = nc.cust_ref_id and mw.emp_code = " & searchEmpCode & "  and mw.status_id = 1  and not exists (select nh.emp_code  from hrm_neft_confirmation nh  where nh.emp_code = nc.cust_ref_id)  and not exists (select ev.emp_code  from hrm_employ_verification ev  where ev.status_id = 1  and ev.rec_by <> 'BLOCK'  and ev.emp_code = nc.cust_ref_id)  and not exists (select emp_code  from hrm_sd_confirmation h  where h.emp_code = nc.cust_ref_id  and h.given_status = 1)  and mw.rec_firm =" & session("firm_id") & "  order by bm.branch_name"
                Else
                    sql1 = "select nc.cust_ref_id,  nc.branch_id || '�' || initcap(bm.branch_name) || '�' ||  initcap(nc.cust_name) || '�' || nc.cust_ref_id || '�' || nc.ifsc_code || '�' ||  nc.beneficiary_account || '�' || initcap(nc.beneficiary_branch) || '�' ||  nc.acc_type || '�' || nc.user_id || '�' || nc.firm_id || '�' ||  nc.bank_id || '�' || mw.emp_code || '�' || initcap(mw.name) || '�' ||  (mw.net_pay + mw.bonus - mw.cutting) || '�' || mw.ta_total || '�' ||  to_char(mw.sal_dt, 'MM') || '�' || to_char(mw.sal_dt, 'YYYY') || '�' ||  to_char(mw.sal_dt, 'Month') as sal_month_0  from Neft_Customer nc, Branch_Master bm, M_Wage mw  where nc.moduleid = 90  and nc.status = 1  and bm.branch_id = mw.branch_id  and mw.emp_code = nc.cust_ref_id and mw.emp_code = " & searchEmpCode & "  and mw.status_id = 1  and not exists (select nh.emp_code  from hrm_neft_confirmation nh  where nh.emp_code = nc.cust_ref_id)  and not exists (select ev.emp_code  from hrm_employ_verification ev  where ev.status_id = 1  and ev.rec_by <> 'BLOCK'  and ev.emp_code = nc.cust_ref_id)  and not exists (select emp_code  from hrm_sd_confirmation h  where h.emp_code = nc.cust_ref_id  and h.given_status = 1)  and mw.rec_firm = 24  order by bm.branch_name"
                End If
                dt = oh.ExecuteDataSet(sql1).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        str.Append(dr(1))
                        str.Append("�")
                    Next
                Else
                    str.Append("�")
                End If
        End Select
        CallBackString = str.ToString
    End Sub

End Class
