Imports System.Data
Imports System.Data.OracleClient
Partial Class Compulsary_Leave_hrm_CompulsaryLeave_12b9105a2174
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        '--------------------------------------------------------------
        If Session("firm_id") = 8 Then
            Me.Server.Transfer("hrm_CompulsaryLeave_macom.aspx")
        End If
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtBranch.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "COMPULSORY LEAVE"

        If Not IsPostBack Then
            Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=174 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
            If acce = 0 Then
                Me.Server.Transfer("../show_err.aspx")
            End If
            Me.txtDate.Text = Format(Now.Date, "dd/MMM/yyyy")
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
                'Added on 09-03-2017 for RqstID = 12732
                'dt = oh.ExecuteDataSet("select e.emp_name|| '*' ||b.BRANCH_NAME || '*' || p.post_name || '*' || d.designation from employee_master e,post_mst p,designation_master d,branch_dtl_new b where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.designation_id=d.designation_id and e.status_id =1 and e.emp_code=" & str(1) & "").Tables(0)
                If Session("firm_id") = 24 Then
                    dt = oh.ExecuteDataSet("select e.emp_name|| '*' ||b.BRANCH_NAME || '*' || p.post_name || '*' || d.designation from employee_master e,post_mst_jwell p,designation_master d,branch_dtl_new b,employ_firm ef where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.designation_id=d.designation_id and e.status_id =1 and e.emp_code=" & str(1) & "  and ef.firm_id=" & Session("firm_id") & "  and ef.emp_code=e.emp_code").Tables(0)
                Else
                    dt = oh.ExecuteDataSet("select e.emp_name|| '*' ||b.BRANCH_NAME || '*' || p.post_name || '*' || d.designation from employee_master e,post_mst p,designation_master d,branch_dtl_new b,employ_firm ef where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.designation_id=d.designation_id and e.status_id =1 and e.emp_code=" & str(1) & "  and ef.firm_id=" & Session("firm_id") & "  and ef.emp_code=e.emp_code").Tables(0)
                End If
                If dt.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt.Rows(0)(0))
                    cbResult = str_tkn.ToString
                End If
        End Select

    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim stat As Integer
        Dim mreg As Integer = 0
        Dim ereg As Integer = 0
        Dim lop As Integer = 0
        stat = Me.cmb_type.SelectedValue
        If stat = 4 Then
            If Me.chkMor.Checked = True Then
                mreg = 1
            Else
                mreg = 0
            End If
            If Me.chkEve.Checked = True Then
                ereg = 1
            Else
                ereg = 0
            End If
            If mreg = 0 And ereg = 0 Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('Please Select Morning / Evening') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If
        If stat = 1 Then
            If Me.chk_lop1.Checked = True Then
                lop = 1
            ElseIf Me.chk_lop2.Checked = True Then
                lop = 2
            Else
                lop = 0
            End If
            If lop = 0 Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('Please Select LOP') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            End If
        End If


        Try
            Dim p(8) As OracleParameter

            p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
            p(0).Value = Me.txtEcode.Text

            p(1) = New OracleParameter("UserID", OracleType.Number, 6)
            p(1).Value = UserCode

            p(2) = New OracleParameter("Ldate", OracleType.DateTime)
            p(2).Value = CDate(Me.txtDate.Text)

            p(3) = New OracleParameter("Sta", OracleType.Number, 2)
            p(3).Value = stat

            p(4) = New OracleParameter("mregn", OracleType.Number, 1)
            p(4).Value = mreg

            p(5) = New OracleParameter("eregn", OracleType.Number, 1)
            p(5).Value = ereg

            p(6) = New OracleParameter("lop", OracleType.Number, 1)
            p(6).Value = lop

            p(7) = New OracleParameter("remarks", OracleType.VarChar, 75)
            p(7).Value = Me.txt_remarks.Value

            p(8) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(8).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_CompulsaryLeave_Proc", p)
            str_tkn.Append("         alert('" & p(8).Value & "');")
            str_tkn.Append(" window.open('hrm_CompulsaryLeave.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Catch ex As Exception
        End Try

    End Sub
End Class
