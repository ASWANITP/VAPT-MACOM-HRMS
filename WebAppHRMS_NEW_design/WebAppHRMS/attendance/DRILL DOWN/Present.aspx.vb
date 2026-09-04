Imports System.Data
Partial Class Attendence_Report_Present_080605c54949
    Inherits System.Web.UI.Page
    Dim cat As Integer
    Dim dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_fromdt.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        If Not IsPostBack Then
            dt1 = OH.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_fromdt.Text = Me.hdn_sysdate.Value
            Me.txt_todt.Text = Me.hdn_sysdate.Value
        End If
        Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
        Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        cat = Me.CMB_CAT.SelectedValue

        If Me.txt_fromdt.Text = "" Or Me.txt_todt.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If CDate(Me.txt_fromdt.Text) > CDate(Me.txt_todt.Text) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('To Date Not Valid');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(Me.txt_fromdt.Text) > CDate(Date.Now) Or CDate(Me.txt_todt.Text) > CDate(Date.Now) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Future Date Not Allowed');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    Server.Transfer("PresentReportR.aspx?frdate=" & Me.txt_fromdt.Text & "&todate=" & Me.txt_todt.Text & "&category=" & cat)
                End If
            End If
        End If
    End Sub
End Class
