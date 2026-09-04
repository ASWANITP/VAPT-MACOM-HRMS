Imports System.Data
Imports System.Data.OracleClient
Partial Class AnyTimePunching_New_Reports_hrm_Rpt_Attend_Exception_829a651c6771
    Inherits System.Web.UI.Page
    Dim dt1 As New DataTable
    Dim OH As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_fromdt.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Me.txt_fromdt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_fromdt')")
        Me.txt_todt.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_todt')")
        Me.rdb_AllLate.Attributes.Add("onclick", "OnClickAllLate()")
        Me.rdb_Indiv_Late.Attributes.Add("onclick", "OnClickIndividual()")
        If Not IsPostBack Then
            dt1 = OH.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_fromdt.Text = Me.hdn_sysdate.Value
            Me.txt_todt.Text = Me.hdn_sysdate.Value
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fstr() As String = Me.txt_fromdt.Text.Split("/")
        Dim frm_str As String = fstr(1) & "/" & fstr(0) & "/" & fstr(2)
        Dim tstr() As String = Me.txt_todt.Text.Split("/")
        Dim to_str As String = tstr(1) & "/" & tstr(0) & "/" & tstr(2)
        If Me.txt_count.Text = "" Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Please Enter Count..!!!!');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
        If Me.rdb_Indiv_Late.Checked = True Then
            If Me.rdb_Branch.Checked = False And Me.rdb_Code.Checked = False Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('Please Verify Branch Wise Or Code Wise..!!!!');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                Exit Sub
            ElseIf Me.rdb_Branch.Checked = True Then
                Dim Status As Integer = 3
                Me.Response.Redirect("hrm_Rpt_Attend_Exception1.aspx?fromdt=" & Format(CDate(frm_str), "dd/MMM/yyyy") & "&todt=" & Format(CDate(to_str), "dd/MMM/yyyy") & "&Status=" & Status & "&Count=" & Me.txt_count.Text)
            ElseIf Me.rdb_Code.Checked = True Then
                Dim Status As Integer = 2
                Me.Response.Redirect("hrm_Rpt_Attend_Exception1.aspx?fromdt=" & Format(CDate(frm_str), "dd/MMM/yyyy") & "&todt=" & Format(CDate(to_str), "dd/MMM/yyyy") & "&Status=" & Status & "&Count=" & Me.txt_count.Text)
            End If
        End If
        If Me.rdb_AllLate.Checked = True Then
            Dim Status As Integer = 1
            Me.Response.Redirect("hrm_Rpt_Attend_Exception1.aspx?fromdt=" & Format(CDate(frm_str), "dd/MMM/yyyy") & "&todt=" & Format(CDate(to_str), "dd/MMM/yyyy") & "&Status=" & Status & "&Count=" & Me.txt_count.Text)
        End If
    End Sub
End Class
