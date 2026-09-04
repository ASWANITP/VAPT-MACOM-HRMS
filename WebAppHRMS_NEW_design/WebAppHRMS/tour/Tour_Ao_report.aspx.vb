Imports System.Data
Imports System.Data.OracleClient
Partial Class Tour_Ao_report_f615ae3d2844
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.Txt_fdt.Text = Format(Date.Today, "dd/MMM/yyyy")

            Me.Txt_tdt.Text = Format(Date.Today, "dd/MMM/yyyy")

        End If
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Dim sf() As String
        Dim pos As Integer = 0
        sf = Session("user_id").ToString.Split("!")
        If (Session("branch_id") = 0) Then
            dt2 = oh.ExecuteDataSet("select emp_code from employee_master  where department_id=154 and emp_code=" & sf(0) & " and status_id=1").Tables(0)
            If dt2.Rows.Count = 1 Then

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('tour_Drilldown1.aspx?dtl=" & sf(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


            Else




                dt = oh.ExecuteDataSet("select dep_id from department_mst where dep_head=" & sf(0) & "").Tables(0)
                If dt.Rows.Count = 0 Then
                    pos = 1

                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("window.open('tour_ao_rpt.aspx?dtl=" & sf(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    pos = 2
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("window.open('tour_ao_rpt.aspx?dtl=" & dt.Rows(0)(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)


                End If



            End If

        End If


    End Sub
End Class
