Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_SSLC_Verification_613d0fe47962
    Inherits System.Web.UI.Page
    Dim cbresult As String
    Dim res As String
    Dim oh As New Helper.Oracle.OracleHelper
    Public ss, c As String
    Dim a As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                verifyareamanager()
                BindData()
                Dim i As Integer
                For i = 1947 To Date.Now.Year
                    DDL_year_Pass.Items.Add(i)
                Next
                statefill()
            End If
            Me.bttn_Reject.Attributes.Add("OnClick", "return bttnReject_onclick()")
            Me.bttn_Approve.Attributes.Add("OnClick", "return  Request_Onclick()")

            Dim script_val As String = "var header;" & "header='" & "" & Me.txt_emp_code.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            ' Dim ds As DataSet
            'ds = oh.ExecuteDataSet("Select ")

        Catch ex As Exception

        End Try
    End Sub
    Sub statefill()
        '============================================ Filling the State ==================================================
        Dim dt1 As DataTable
        dt1 = oh.ExecuteDataSet("select '---- SELECT-----' as state_name,0 from dual union select upper(state_name), state_id from state_master order by state_name").Tables(0)
        Me.DDL_State_Pas.DataSource = dt1
        Me.DDL_State_Pas.DataTextField = dt1.Columns(0).ColumnName
        Me.DDL_State_Pas.DataValueField = dt1.Columns(1).ColumnName
        Me.DDL_State_Pas.DataBind()
    End Sub
    Sub verifyareamanager()
        Try
            Dim user() As String = Session("user_id").ToString.Split("!")
            Dim a, b As String
            a = user(0)
            Dim oh As New Helper.Oracle.OracleHelper
            Dim ds As DataSet
            Dim isaccess As Boolean = False
            '==================== Checking whether the user code belongs to Area Head ========================================================
            'ds = oh.ExecuteDataSet("select count(*) as Pid from emp_master where EMP_CODE=" & user(0) & "and POST_ID in(136,141,134,131,197)")

            ds = oh.ExecuteDataSet("select count(*) as Pid from emp_master where EMP_CODE=" & user(0) & "and POST_ID in(136)")
            If (ds.Tables(0).Rows(0)(0) = 1) Then
                b = "Area Manager"
                c = "2"
                isaccess = True
                'MsgBox(b)
                GoTo 1
                '==================== Checking whether the user code belongs to Region Head ======================================================
            ElseIf (ds.Tables(0).Rows(0)(0) = 0) Then
                ds.Clear()
                'ds = oh.ExecuteDataSet("select count(*) as Pid from emp_master where EMP_CODE=" & user(0) & "and POST_ID in(189,316,349,195,232,173)")
                'ds = oh.ExecuteDataSet("select count(*) as Pid from emp_master where EMP_CODE=" & user(0) & "and POST_ID in(289,376,349,195,232,173)")
                ds = oh.ExecuteDataSet("select count(*) as Pid from emp_master where EMP_CODE=" & user(0) & "and POST_ID in(199)")

                If (ds.Tables(0).Rows(0)(0) = 1) Then
                    b = "Region Head"
                    c = "1"
                    isaccess = True
                    'MsgBox(b)
                    GoTo 1
                    '=================================== Department Head ===========================================================================

                ElseIf (ds.Tables(0).Rows(0)(0) = 0) Then
                    ds.Clear()
                    ds = oh.ExecuteDataSet("select count(*) as Pid from department_mst  where dep_head=" & user(0) & "")
                    If (ds.Tables(0).Rows(0)(0) > 0) Then
                        b = "Department Head"
                        c = "3"
                        isaccess = True
                        'MsgBox(b)
                        GoTo 1
                        '=================================== Suspense Head ===========================================================================
                    ElseIf (ds.Tables(0).Rows(0)(0) = 0) Then
                        ds.Clear()
                        ds = oh.ExecuteDataSet("select count(*) as Pid from department_mst WHERE dep_id in(254,20,160) and suspense_head =" & user(0) & "")
                        If (ds.Tables(0).Rows(0)(0) > 0) Then
                            b = "Suspense"
                            c = "6"
                            isaccess = True
                            'MsgBox(b)
                            GoTo 1
                            '================================== Employee =====================================================================
                        ElseIf (ds.Tables(0).Rows(0)(0) = 0) Then
                            b = "Employee"
                            c = "5"
                            isaccess = False
                            'MsgBox(b)
                        End If

                        GoTo 1
                    End If
                End If

            End If

            '========================= Redirecting the page as per the user rights.===========================================================
1:
            Session("RH") = ""
            Session("RH") = c
            If (isaccess = False) Then

                Response.Redirect("~/show_err.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindData()
        Try
            Dim ds As New DataSet
            Dim a As String
            Dim user() As String = Session("user_id").ToString.Split("!")
            a = user(0)

            '============================================== Clear Values from Pending Approvals ===========================================
            DDLPendApprov.Items.Clear()
            txt_emp_code.Text = ""
            txt_Name.Text = ""
            txt_Remarks.Text = ""
            txt_SSLC_No.Text = ""
            DDL_State_Pas.SelectedIndex = 0
            DDL_year_Pass.SelectedIndex = 0

            '============================================== RH verification of AH ====(change emp_code as -1 if needed)====================================================
            If (Session("RH") = 1) Then
                'ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code, emp_code||'-'||emp_name||'-'||SSLC_NO  as PENDING from employ_personal_dtl_temp where emp_code in(select emp_code from emp_master where post_id not in (289,376,349,195,232,173)and post_id in(136,141,134,131,197)and Status_id=1) and status=1")
                ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code,emp_code||'-'||emp_name||'-'||SSLC_No as PENDING from employ_personal_dtl where status=1 and emp_code in (select emp_code from emp_master where status_id=1 and post_id in(136,141,134,197,131)and branch_id in(select branch_id from branch_detail where reg_id in(select reg_id from branch_detail where branch_id in(select branch_id from emp_master where emp_code= " & a & "))))")

                '======= New Update to Display msg if no pending ================
                If (ds.Tables(0).Rows.Count = 1) Then
                    Dim cl_script0 As New System.Text.StringBuilder

                    cl_script0.Append("alert('No Employees Pending for approval...');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                End If
                '================================================================

                GoTo 2
                '=========================================== AH Verification of Employees ======================================
            ElseIf (Session("RH") = 2) Then
                'ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code, emp_code||'-'||emp_name||'-'||SSLC_NO  as PENDING  from employ_personal_dtl_temp where emp_code in(select emp_code from emp_master where post_id not in (289,376,349,195,232,173)and post_id not in(136,141,134,131,197)and Status_id=1) and status=1")
                ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code,emp_code||'-'||emp_name||'-'||SSLC_No as PENDING from employ_personal_dtl where status=1 and emp_code in (select emp_code from emp_master where status_id=1 and branch_id>0 and post_id not in (289,376,349,195,232,173,199)and post_id not in(136,141,134,131,197)and branch_id in(select branch_id from branch_detail where area_id in(select area_id from branch_detail where branch_id in(select branch_id from emp_master where emp_code=" & a & "))))")

                '======= New Update to Display msg if no pending ================
                If (ds.Tables(0).Rows.Count = 1) Then
                    Dim cl_script0 As New System.Text.StringBuilder

                    cl_script0.Append("alert('No Employees Pending for approval...');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                End If
                '================================================================

                GoTo 2
                '=========================================== Department Head Verification of HO Employees====================================
            ElseIf (Session("RH") = 3) Then
                'ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code, emp_code||'-'||emp_name||'-'||SSLC_NO  as PENDING  from employ_personal_dtl_temp where emp_code in(select emp_code from emp_master where post_id not in (289,376,349,195,232,173)and post_id not in(136,141,134,131,197)and Status_id=1) and status=1")
                'ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code,emp_code||'-'||emp_name||'-'||SSLC_No as PENDING from employ_personal_dtl_temp where status=1 and emp_code in (select emp_code from emp_master where status_id=1 and branch_id>0 and post_id not in (289,376,349,195,232,173,199)and post_id not in(136,141,134,131,197)and branch_id in(select branch_id from branch_detail where area_id in(select area_id from branch_detail where branch_id in(select branch_id from emp_master where emp_code=" & a & "))))")
                ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code, emp_code||'-'||emp_name||'-'||SSLC_NO  as PENDING from employ_personal_dtl where status=1 and  emp_code in (select t.emp_code from emp_master t,department_mst a where t.department_id=a.dep_id and a.dep_head=" & user(0) & " and t.status_id=1 and a.dep_id not in (254,20,160)))")

                '======= New Update to Display msg if no pending ================
                If (ds.Tables(0).Rows.Count = 1) Then
                    Dim cl_script0 As New System.Text.StringBuilder

                    cl_script0.Append("alert('No Employees Pending for approval...');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                End If
                '================================================================

                GoTo 2
                '=========================================== modified to approve IT harware and support ====================================
            ElseIf (Session("RH") = 6) Then
                'ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code, emp_code||'-'||emp_name||'-'||SSLC_NO  as PENDING  from employ_personal_dtl_temp where emp_code in(select emp_code from emp_master where post_id not in (289,376,349,195,232,173)and post_id not in(136,141,134,131,197)and Status_id=1) and status=1")
                'ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code,emp_code||'-'||emp_name||'-'||SSLC_No as PENDING from employ_personal_dtl_temp where status=1 and emp_code in (select emp_code from emp_master where status_id=1 and branch_id>0 and post_id not in (289,376,349,195,232,173,199)and post_id not in(136,141,134,131,197)and branch_id in(select branch_id from branch_detail where area_id in(select area_id from branch_detail where branch_id in(select branch_id from emp_master where emp_code=" & a & "))))")
                ds = oh.ExecuteDataSet("select 0 as Emp_code,'-------Select One----------' as PENDING from dual union all select emp_code as Emp_code, emp_code||'-'||emp_name||'-'||SSLC_NO  as PENDING from employ_personal_dtl where status=1 and  emp_code in (select t.emp_code from emp_master t,department_mst a where t.department_id=a.dep_id and t.status_id=1 and  a.dep_id in (254,20,160))")
                '======= New Update to Display msg if no pending ================
                If (ds.Tables(0).Rows.Count = 1) Then
                    Dim cl_script0 As New System.Text.StringBuilder

                    cl_script0.Append("alert('No Employees Pending for approval...');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                End If
                '================================================================

                GoTo 2



            End If
            '============================================================================================================================
            '*' ds = oh.ExecuteDataSet("Select EMPCODE ||'-'|| EMPNAME ||'-'||SSLC_NO ||'-'||SSLC_YR from employ_personal_dtl_temp where ")
            'ds = oh.ExecuteDataSet("select -1 as Emp_code,'-------Select One----------' as PENDING from dual union all  select EMP_CODE  ,EMP_CODE ||'-'|| EMP_NAME ||'-'||SSLC_NO ||'-'||SSLC_YR  from employ_personal_dtl_temp where Emp_code in(select emp_code from emp_master where branch_id in (select Branch_id from branch_dtl_new t where t.area_id in (select w.area_id from branch_dtl_new w where w.BRANCH_ID in (select n.BRANCH_ID from emp_master n where n.EMP_CODE=" & a & "))) and Status= 1)")
2:
            DDLPendApprov.DataSource = ds.Tables(0)
            DDLPendApprov.DataTextField = "PENDING"
            DDLPendApprov.DataValueField = "Emp_code"
            DDLPendApprov.DataBind()

            'BindData(c)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DDLPendApprov_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Dim dt, dts As New DataSet
            ss = DDLPendApprov.SelectedValue.ToString()
            txt_emp_code.Text = ss.ToString()
            dt = oh.ExecuteDataSet("select EMP_NAME as Name,SSLC_NO as SSLCNO,SSLC_YR As SYear,SSLC_State as State from employ_personal_dtl where EMP_CODE=" & ss & "")
            Session("Cert_EMP_CODE") = txt_emp_code.Text.ToString()
            txt_Name.Text = dt.Tables(0).Rows(0)("Name").ToString()
            txt_SSLC_No.Text = dt.Tables(0).Rows(0)("SSLCNO").ToString()
            DDL_year_Pass.SelectedValue = dt.Tables(0).Rows(0)("SYEAR")
            DDL_State_Pas.SelectedValue = dt.Tables(0).Rows(0)("State")

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub bttn_Approve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttn_Approve.Click
        Try
            'Dim data() As String = eventArgument.Split("!")
            Dim user() As String = Session("user_id").ToString.Split("!")

            Dim da As New DataSet
            Dim sql As String

            Dim oh As New Helper.Oracle.OracleHelper

            sql = "update employ_personal_dtl set Status=2,VERIFIED_BY=" & user(0) & " , VERIFIED_DT= Sysdate , REMARKS='" & txt_Remarks.Text & "' where EMP_CODE=" & txt_emp_code.Text & ""
            oh.ExecuteNonQuery(sql)
            a = 1
            BindData()
            Dim cl_script0 As New System.Text.StringBuilder

            cl_script0.Append("alert(' The SSLC No is Approved Successfully...');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

            'sql = "update employ_personal_dtl_temp set Status=9,VERIFIED_BY=" & user(0) & " , VERIFIED_DT= Sysdate , REMARKS='" & Data(1) & "' where EMP_CODE=" & Data(2) & ""
            'oh.ExecuteNonQuery(sql)
            'a = 2



        Catch ex As Exception

            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("alert(' The SSLC No : " & txt_SSLC_No.Text & " Verification Failed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        Finally
            'BindData()
        End Try



    End Sub

    Protected Sub bttn_Reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttn_Reject.Click
        Try
            'Dim data() As String = eventArgument.Split("!")
            Dim user() As String = Session("user_id").ToString.Split("!")

            Dim da As New DataSet
            Dim sql As String

            Dim oh As New Helper.Oracle.OracleHelper

            sql = "update employ_personal_dtl set Status=9,VERIFIED_BY=" & user(0) & " , VERIFIED_DT= Sysdate , REMARKS='" & txt_Remarks.Text & "' where EMP_CODE=" & txt_emp_code.Text & ""
            oh.ExecuteNonQuery(sql)
            a = 1
            BindData()
            Dim cl_script0 As New System.Text.StringBuilder

            cl_script0.Append("alert(' The SSLC No is Rejected Successfully...');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

            'sql = "update employ_personal_dtl_temp set Status=9,VERIFIED_BY=" & user(0) & " , VERIFIED_DT= Sysdate , REMARKS='" & Data(1) & "' where EMP_CODE=" & Data(2) & ""
            'oh.ExecuteNonQuery(sql)
            'a = 2



        Catch ex As Exception

            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("alert(' The SSLC No : " & txt_SSLC_No.Text & " Verification Failed');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        Finally
            'BindData()
        End Try
    End Sub
End Class
