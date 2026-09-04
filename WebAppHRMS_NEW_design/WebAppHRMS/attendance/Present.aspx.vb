Imports System.Data
Imports System.Data.OracleClient
Partial Class Attendence_Report_Present_080605c54795
    Inherits System.Web.UI.Page
    Dim cat As Integer
    Dim usr() As String
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            usr = Me.Session("user_id").ToString.Split("!")
            If Session("branch_id") = 0 Then
                Me.Txt_frdate.Text = Format(Date.Today, "dd/MMM/yyyy")
            Else
                If Session("branch_id") <> 0 Then
                    Dim dt44 As DataTable = oh.ExecuteDataSet("select emp_code from employee_master where post_id  in (199,112,200,197,136,141,28,195,173) and status_id=1 and emp_code=" & usr(0) & "").Tables(0)
                    If dt44.Rows.Count > 0 Then
                        Me.Txt_frdate.Text = Format(Date.Today, "dd/MMM/yyyy")
                    Else
                        Server.Transfer("../show_err.aspx")
                    End If
                End If

            End If

        End If

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.Txt_frdate.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If CDate(Me.Txt_frdate.Text) > CDate(Date.Now) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Future Date Not Allowed');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                
                Server.Transfer("PresentReportR.aspx?frdate=" & Me.Txt_frdate.Text & "&category=" & cat)

            End If
        End If
    End Sub
End Class
