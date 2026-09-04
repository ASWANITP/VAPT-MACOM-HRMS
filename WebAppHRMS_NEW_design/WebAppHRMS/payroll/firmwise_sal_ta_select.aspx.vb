Imports System.Data
Imports System.Data.OracleClient
Partial Class Firmwise_Salary_TA_firmwise_sal_ta_select_0ceb5ab79495
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Firmwise Report of Salary And TA Received by Employees"

        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.Cmb_Firm.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)

        If Not IsPostBack Then

            'str = "select 0,' SELECT ALL FIRMS..' as firm_abbr from dual union select firm_id,firm_abbr as firm_abbr from firm_master where firm_id>0 order by firm_abbr"
            str = "select fm.firm_id, fm.firm_abbr as firm_abbr  from firm_master fm  where fm.firm_id > 0  and fm.firm_id=" & Session("firm_id") & "  order by firm_abbr"
            dt = oh.ExecuteDataSet(str).Tables(0)
            Me.Cmb_Firm.DataSource = dt
            Me.Cmb_Firm.DataTextField = dt.Columns(1).ColumnName
            Me.Cmb_Firm.DataValueField = dt.Columns(0).ColumnName
            Me.Cmb_Firm.DataBind()

        End If



    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim acess As Integer
        '--------------- ReqID 8592 starts------------------------------
        If Session("firm_id") = 8 Then
            '---------------------end--------------------------------------------------------------------
            acess = oh.ExecuteDataSet("select t.access_id from employee_master t where t.emp_code=" & user(0) & "").Tables(0).Rows(0)(0)
            If acess = 33 Then

                Me.Server.Transfer("firmwise_sal_ta_rpt.aspx?item=" & Me.Hid_Type.Value & "&firm=" & Me.Cmb_Firm.SelectedValue)
            Else
                Dim str_tkn As New StringBuilder
                str_tkn.Append("            alert('You Are Not Authorised...!')")
                Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "Script", str_tkn.ToString, True)
                Exit Sub
            End If

            '--------------- ReqID 8592 starts------------------------------
        Else
            Me.Server.Transfer("firmwise_sal_ta_rpt.aspx?item=" & Me.Hid_Type.Value & "&firm=" & Me.Cmb_Firm.SelectedValue)
        End If

        '---------------------end--------------------------------------------------------------------

    End Sub
End Class
