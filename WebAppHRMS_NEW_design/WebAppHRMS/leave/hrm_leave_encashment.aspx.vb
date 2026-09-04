Imports System.Data
Imports System.Data.OracleClient
Partial Class ENCASHMENT_hrm_leave_encashment_c4572ebc2057
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "EARNED LEAVE ENCASHMENT FORM AS ON '31/DEC/2013'"
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        dt1 = oh.ExecuteDataSet("select a.parmtr_value from general_parameter a where a.module_id=33 and a.parmtr_id=35").Tables(0)
        dt = oh.ExecuteDataSet("select a.earned_leave,a.encash_leave from hrm_earned_leave a,employee_master b where a.emp_id=b.emp_code and b.status_id in (1,10) and a.earned_leave>5 and a.salary is null and a.emp_id=" & User(0) & " and a.earned_year=" & dt1.Rows(0)(0) & "").Tables(0)
        'dt = oh.ExecuteDataSet("select a.earned_leave,a.encash_leave from hrm_earned_leave a,employee_master b where a.emp_id=b.emp_code and b.status_id in (1,10) and a.earned_leave>5 and a.salary is null and a.emp_id=" & User(0) & "").Tables(0)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0) > 24 Then
                Me.txt_earned.Text = 24
                Me.txt_leave.Text = 24 - 5
                Me.txt_carry.Text = 12
            Else
                If dt.Rows(0)(0) > 12 Then
                    Me.txt_carry.Text = 12
                Else
                    Me.txt_carry.Text = dt.Rows(0)(0)
                End If
                Me.txt_earned.Text = dt.Rows(0)(0)
                Me.txt_leave.Text = Me.txt_earned.Text - 5
            End If
            'Me.txt_leave.Text = dt.Rows(0)(1)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Have No Leave Encashment/Updated Once...!!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_earned.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
    End Sub

    Protected Sub btn_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        If Me.txt_encash.Text = "" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Enter The Number of Leave to Encashment...!!!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Me.txt_encash.Focus()
        Else
            Dim p(2) As OracleParameter
            p(0) = New OracleParameter("userId", OracleType.Number, 10)
            p(0).Value = User(0)

            p(1) = New OracleParameter("encash", OracleType.Number, 10)
            p(1).Value = Me.txt_encash.Text

            p(2) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            p(2).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_leave_encashment", p)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" + p(2).Value + "');")
            cl_script1.Append("         window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub
End Class
