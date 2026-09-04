Imports System.Data
Imports System.Data.OracleClient
Partial Class STORES_Outward_Mail_Rpt_4b1ab1d41556
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim User() As String = Session("user_id").ToString.Split("!")
            Dim id As Integer
            id = 1414
            Dim dt1, dts As New DataTable
            dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & id & " and emp_id=" & User(0) & "").Tables(0)
            If dt1.Rows(0)(0) <= 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('You Are Not Authorised !!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                Exit Sub
            End If

            Me.txt_frdt.Text = oh.ExecuteDataSet("select to_char(to_date(sysdate),'DD-MON-YYYY') from dual").Tables(0).Rows(0)(0)
            Me.txt_todt.Text = oh.ExecuteDataSet("select to_char(to_date(sysdate),'DD-MON-YYYY') from dual").Tables(0).Rows(0)(0)
        End If

        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_frdt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

    End Sub

    Protected Sub cmd_rpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_rpt.Click
        Dim today_date As String
        today_date = oh.ExecuteDataSet("select to_char(to_date(sysdate),'DD-MON-YYYY') from dual").Tables(0).Rows(0)(0)
        If (Me.txt_frdt.Text = "" Or Me.txt_todt.Text = "") Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "alert('You Should Enter Valid From and To Dates');", True)
            Exit Sub
        End If

        If (CDate(Me.txt_frdt.Text) > CDate(Me.txt_todt.Text)) Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "alert('From Date cannot be greater than To Date');", True)
            Exit Sub
        ElseIf ((CDate(Me.txt_frdt.Text) > CDate(today_date)) Or (CDate(Me.txt_frdt.Text) > CDate(Me.txt_todt.Text))) Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MyScript", "alert('You Should not Enter Future Date');", True)
            Exit Sub
        End If

        Me.Server.Transfer("Employees_3DaysLate_RptCode.aspx?frdt=" & Me.txt_frdt.Text & "&todt=" & Me.txt_todt.Text & "")
    End Sub
End Class
