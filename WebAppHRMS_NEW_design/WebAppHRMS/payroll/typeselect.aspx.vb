Imports System.Data
Imports System.Data.OracleClient
Partial Class EmpResAppTerSusReport_typeselect_b1f9342c6488
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.Oraclehelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserCode, PostId As Integer
    Dim str, str1, str2, UsrId(), UsrAll As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "Report of Resigned,Appointed,Terminated or Suspended Employees"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "Report of Resigned,Appointed,Terminated or Suspended Employees"
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Txt_FromDate.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
        If Not IsPostBack Then
            Me.UsrAll = Me.Session("user_id")
            Me.UsrId = Me.UsrAll.Split("!")
            Me.UserCode = Me.UsrId(0)
            Me.PostId = oh.ExecuteDataSet("select nvl(post_id,0) from employee_master where emp_code = " & Me.UserCode).Tables(0).Rows(0)(0)
            If (Me.Session("access_id") = 33) Or (Me.PostId = 195) Then
                Me.Cmb_Designation.Enabled = False
                Me.Cmb_Firm.Enabled = False
                Me.Check_Designation.Checked = False
                Me.Check_Firm.Checked = False
                Me.Cmd_Clear.Disabled = True
                str = "select firm_id,firm_abbr from firm_master where firm_id>0 and firm_id=" & Session("firm_id") & " order by firm_id"
                dt = oh.ExecuteDataSet(str).Tables(0)
                Me.Cmb_Firm.DataSource = dt
                Me.Cmb_Firm.DataValueField = dt.Columns(0).ColumnName
                Me.Cmb_Firm.DataTextField = dt.Columns(1).ColumnName
                Me.Cmb_Firm.DataBind()

                str1 = "select designation_id,designation from designation_master order by designation"
                dt1 = oh.ExecuteDataSet(str1).Tables(0)
                Me.Cmb_Designation.DataSource = dt1
                Me.Cmb_Designation.DataValueField = dt1.Columns(0).ColumnName
                Me.Cmb_Designation.DataTextField = dt1.Columns(1).ColumnName
                Me.Cmb_Designation.DataBind()
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        End If
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Me.Server.Transfer("empstatusreport.aspx?firm=" & Me.Hid_Firm.Value & "&designation=" & Me.Hid_designation.Value & "&status=" & Me.Hid_Status.Value & "&jointype=" & Me.Hid_joinType.Value & "&emptype=" & Me.Hid_EmpType.Value & "&date_type=" & Me.Hid_DateType.Value & "&fromdate=" & Me.Txt_FromDate.Text & "&todate=" & Me.Txt_ToDate.Text)
    End Sub

End Class
