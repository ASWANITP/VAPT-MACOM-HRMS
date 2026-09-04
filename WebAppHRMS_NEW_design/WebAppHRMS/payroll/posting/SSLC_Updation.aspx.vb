Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_SSLC_Updation_a6f1e0b73524
    Inherits System.Web.UI.Page
    Dim res As String
    Dim oh As New Helper.Oracle.OracleHelper
    Public ss As String
    Protected Sub bttn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttn_Submit.Click
        Try

            Dim oh As New Helper.Oracle.OracleHelper                '
            Dim dd, ds, dt As DataSet
            Dim sql As String
            Try
                '==========================================New Update to check the employee has been already verified or not========================

                ds = oh.ExecuteDataSet("select count(*) as No from employ_personal_dtl where EMP_CODE=" & txt_EmpCode.Text.Trim() & " and Status > 1 and SSLC_NO is not null")
                If (ds.Tables(0).Rows(0)("No").ToString() = "1") Then

                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('Your SSLC Certificate is already Verified ');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                Else
                    '===================================================================================================================================

                    '============================= Test============================================

                    dd = oh.ExecuteDataSet("select count(*) as CNo from employ_personal_dtl where EMP_CODE<> " & txt_EmpCode.Text.Trim() & " And SSLC_NO ='" & txt_SSLC_No.Text.Trim() & "'")
                    If (dd.Tables(0).Rows(0)("CNo") = 0) Then
                        '==============================================================================
                        sql = ""
                        sql = "update  employ_personal_dtl set SSLC_NO='" & txt_SSLC_No.Text.Trim() & "',SSLC_YR=" & DDL_year_Pass.SelectedValue.ToString() & ",SSLC_STATE=" & DDL_State_Pas.SelectedValue & ",STATUS='1' where EMP_CODE=" & txt_EmpCode.Text.Trim() & ""
                        oh.ExecuteNonQuery(sql)
                        '==============================================================================
                        '========================================== Checking Employee code already exists  @=========

                        dt = oh.ExecuteDataSet("select count(*) as No from macdms.Emp_SSLC_Scan_dtls where EMP_CODE=" & txt_EmpCode.Text & "")
                        If (dt.Tables(0).Rows(0)("No") = 0) Then
                            '==========================================================================================
                            '==========================================Insert in Dms table=============================
                            sql = ""
                            sql = "insert into macdms.Emp_SSLC_Scan_dtls (EMP_CODE)values (" & txt_EmpCode.Text & ")"
                            oh.ExecuteNonQuery(sql)
                            '==========================================================================================
                            '========================================= @ ==============================================
                        Else

                        End If
                        '==============================================================================================

                        sql = ""
                        'sql = "update employ_personal_dtl_temp set  SSLC_IMAGE=:BlobParameter where  EMP_CODE=" & Me.txt_EmpCode.Text

                        sql = "update macdms.Emp_SSLC_Scan_dtls set SSLC_IMAGE=:BlobParameter where EMP_CODE=" & Me.txt_EmpCode.Text
                        Dim p(0) As OracleParameter
                        p(0) = New OracleParameter
                        p(0).ParameterName = "BlobParameter"
                        p(0).OracleType = OracleType.Blob
                        p(0).Direction = ParameterDirection.Input
                        p(0).Value = Me.FUploadCert.FileBytes 'Data
                        oh.ExecuteNonQuery(sql, p)

                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert(' Sucessfully Confirmed SSLCNo: " & txt_SSLC_No.Text & "');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

                    ElseIf (dd.Tables(0).Rows(0)("CNo") = 1) Then

                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert(' Duplicate SSLCNo Exists: " & txt_SSLC_No.Text & "');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)

                    End If
                        '====================================== New Update =====================================================
                    End If
                '========================================================================================================
            Catch ex As Exception
                sql = ""
                sql = "update  employ_personal_dtl set SSLC_NO=" & sql & ",SSLC_YR=" & sql & ",SSLC_STATE=" & sql & ",STATUS='0' where EMP_CODE=" & txt_EmpCode.Text.Trim() & ""
                oh.ExecuteNonQuery(sql)
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert(' SSLC Details Updation Failed');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
            End Try
            
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim user() As String = Session("user_id").ToString.Split("!")
            Dim ds As DataSet
            'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Employee SSLC Updation"
            Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
            masterPage.subtitle = "Employee SSLC Updation"
            Dim script_val As String = "var header;" & "header='" & "" & Me.txt_EmpCode.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            txt_EmpCode.Text = user(0)
            ds = oh.ExecuteDataSet("select emp_Name as ename from emp_master where emp_code=" & txt_EmpCode.Text & "")
            txt_Name.Text = ds.Tables(0).Rows(0)(0).ToString()
            If Not IsPostBack Then
                Dim i As Integer
                For i = 1947 To Date.Now.Year
                    DDL_year_Pass.Items.Add(i)
                Next
                statefill()
            End If
            Me.bttn_Submit.Attributes.Add("OnClick", "return Request_Onclick()")
        Catch ex As Exception

        End Try
    End Sub
    
    Sub statefill()
        Dim dt1 As DataTable
        dt1 = oh.ExecuteDataSet("select '---- SELECT-----' as state_name,0 from dual union select upper(state_name), state_id from state_master order by state_name").Tables(0)
        Me.DDL_State_Pas.DataSource = dt1
        Me.DDL_State_Pas.DataTextField = dt1.Columns(0).ColumnName
        Me.DDL_State_Pas.DataValueField = dt1.Columns(1).ColumnName
        Me.DDL_State_Pas.DataBind()
    End Sub

End Class
