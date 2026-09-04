Imports system
Imports System.Data
Imports System.Data.OracleClient



Partial Class attendance_newdee_repo_5ef00a631900
    Inherits System.Web.UI.Page
    Dim cat As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        cat = Me.CMB_CAT.SelectedValue
        Dim usr = Session("user_id").ToString.Split("!")
        Dim str_tkn As New StringBuilder
        Dim oh As New Helper.Oracle.OracleHelper
        Dim dt, dt2 As DataTable
        If DateFiller1.fromdate = "" Or DateFiller1.todate = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If CDate(Me.DateFiller1.fromdate) > CDate(Date.Now) Or CDate(Me.DateFiller1.todate) > CDate(Date.Now) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('Future Date Not Allowed');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(Me.DateFiller1.fromdate) > CDate(Me.DateFiller1.todate) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('To Date Not Valid');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else

                    '--------------- ReqID 8592 starts------------------------------
                    If Session("firm_id") = 8 Then
                        '---------------------end-------------------------------------


                        dt = oh.ExecuteDataSet("select count(t.dep_head) from department_mst t where t.dep_head = " & usr(0) & "").Tables(0)
                        dt2 = oh.ExecuteDataSet("select count(t.emp_code) from employee_master t where t.access_id = 33 And t.emp_code = " & usr(0) & "").Tables(0)
                        If (dt.Rows(0)(0) = 1 Or dt2.Rows(0)(0) = 1) Then
                            Server.Transfer("newAll_report.aspx?frdate=" & Me.DateFiller1.fromdate & "&todate=" & Me.DateFiller1.todate & "&category=" & cat)
                        Else
                            str_tkn.Append("         alert('You are not authorized...!');")
                            str_tkn.Append(" window.open('newdee_repo.aspx','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
                        End If

                        '--------------- ReqID 8592 starts------------------------------
                    Else
                        Server.Transfer("newAll_report.aspx?frdate=" & Me.DateFiller1.fromdate & "&todate=" & Me.DateFiller1.todate & "&category=" & cat)
                    End If

                    '---------------------end-------------------------------------


                End If
            End If
        End If
    End Sub
End Class
