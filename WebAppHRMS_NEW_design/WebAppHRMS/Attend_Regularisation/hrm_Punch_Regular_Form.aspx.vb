Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_hrm_Punch_Regular_Form_96f032a98813
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.rdb_Indi.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1").Tables(0)
        If dt.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Me.rdb_All.Attributes.Add("onclick", "ALL_LATE()")
        Me.rdb_Indi.Attributes.Add("onclick", "INDI_LATE()")
        Me.rdb_Nonmarking.Attributes.Add("onclick", "NONMARKING()")
    End Sub
End Class
