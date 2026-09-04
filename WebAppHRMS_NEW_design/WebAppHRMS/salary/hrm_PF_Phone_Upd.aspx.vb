Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_hrm_PF_Phone_Upd_0e3a51387957
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Me.hid_Usr.Value = User(0)
        Me.hid_br.Value = Session("branch_id")
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "PF PHONE NUMBER UPDATION"
        dt = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & "  and a.status_id=1").Tables(0)
        If dt.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        dt1 = oh.ExecuteDataSet("select b.branch_name||'*'||e.emp_code||'*'||e.emp_name||'*'||p.post_name||'*'||to_char(to_date(e.join_dt))|| '*' ||ee.pf_ph_no from employee_master e,post_mst p,branch_master b,employee_master_dtl ee where e.post_id=p.post_id and ee.emp_code=e.emp_code and e.branch_id=b.branch_id and e.emp_code=" & User(0) & "").Tables(0)
        For Each dr In dt1.Rows
            str_tkn.Append(dr(0))
            str_tkn.Append("!")
        Next
        Me.Hidden3.Value = str_tkn.ToString
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.hid_Usr.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select count(e.pf_ph_no) from employee_master_dtl e where e.emp_code=" & User(0) & "").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            oh.ExecuteNonQuery("UPDATE employee_master_dtl a SET a.pf_ph_no=" & Me.txt_Phone.Text & ",a.pf_mob_no=" & Me.txt_mobile.Text & " where a.emp_code=" & User(0) & "")
        Else
            oh.ExecuteNonQuery("UPDATE employee_master_dtl a SET a.pf_mob_no=" & Me.txt_mobile.Text & " where a.emp_code=" & User(0) & "")
        End If
        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("         alert('Successfully Confirmed....!!!!');")
        cl_script0.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        Exit Sub
    End Sub
End Class
