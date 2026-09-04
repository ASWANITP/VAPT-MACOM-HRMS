Imports System.Data
Imports System.Data.OracleClient
Partial Class Salary_Individ_Ho_statement_sal_individ_HO_select_dcb5317a7224
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New DataTable
    Dim str, str1 As String
    Dim dr, dr1 As DataRow
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Salary Statement Of Head Office:Employee Type Selection"
        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_yr.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        If Not IsPostBack Then
            If Me.Session("access_id") <> 33 Then
                Me.Server.Transfer("../show_err.aspx")
            Else
                Dim mon As String
                mon = oh.ExecuteDataSet("select distinct to_char(to_date(t.sal_dt),'mm') from m_wage t").Tables(0).Rows(0)(0).ToString()
                Me.Cmb_month.SelectedValue = mon
                Dim year As Integer
                year = oh.ExecuteDataSet("select to_number(to_char(sysdate,'YYYY'))from dual").Tables(0).Rows(0)(0).ToString()
                Me.Txt_yr.Text = year
                Me.Radio_Permanant.Checked = True
            End If
        End If


    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        
        If Me.Radio_Permanant.Checked = True Then
            If Me.Txt_yr.Text = "" Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('YEAR can not be Null') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            Else
                Dim curr_year = oh.ExecuteDataSet("select to_number(to_char(sysdate,'YYYY'))from dual").Tables(0).Rows(0)(0).ToString()
                If CInt(Me.Txt_yr.Text) > CInt(curr_year) Then
                    Dim cl_script As New StringBuilder
                    cl_script.Append("   alert('Future Dates Not Allowed') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                    Exit Sub
                Else
                    Dim dat As String = "1" + "/" + Me.Cmb_month.SelectedValue + "/" + Me.Txt_yr.Text
                    Dim lastdate = DateSerial(Me.Txt_yr.Text, Me.Cmb_month.SelectedValue + 1, 0)

                    Me.Server.Transfer("sal_indivi_HO_all_report.aspx?emptype=" & 1 & "&date_in=" & lastdate)
                End If

            End If
        ElseIf Me.Radio_Outsource.Checked = True Then
            If Me.Txt_yr.Text = "" Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('YEAR can not be Null') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            Else
                Dim curr_year = oh.ExecuteDataSet("select to_number(to_char(sysdate,'YYYY'))from dual").Tables(0).Rows(0)(0).ToString()
                If CInt(Me.Txt_yr.Text) > CInt(curr_year) Then
                    Dim cl_script As New StringBuilder
                    cl_script.Append("   alert('Future Dates Not Allowed') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                    Exit Sub
                Else
                    Dim dat As String = "1" + "/" + Me.Cmb_month.SelectedValue + "/" + Me.Txt_yr.Text
                    Dim lastdate = DateSerial(Me.Txt_yr.Text, Me.Cmb_month.SelectedValue + 1, 0)

                    Me.Server.Transfer("sal_indivi_HO_all_report.aspx?emptype=" & 2 & "&date_in=" & lastdate)
                End If
            End If

        ElseIf Me.Radio_all.Checked = True Then
            If Me.Txt_yr.Text = "" Then
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('YEAR can not be Null') ;")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                Exit Sub
            Else
                Dim curr_year = oh.ExecuteDataSet("select to_number(to_char(sysdate,'YYYY'))from dual").Tables(0).Rows(0)(0).ToString()
                If CInt(Me.Txt_yr.Text) > CInt(curr_year) Then
                    Dim cl_script As New StringBuilder
                    cl_script.Append("   alert('Future Dates Not Allowed') ;")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
                    Exit Sub
                Else
                    Dim dat As String = "1" + "/" + Me.Cmb_month.SelectedValue + "/" + Me.Txt_yr.Text
                    Dim lastdate = DateSerial(Me.Txt_yr.Text, Me.Cmb_month.SelectedValue + 1, 0)

                    Me.Server.Transfer("sal_indivi_HO_all_report.aspx?emptype=" & 3 & "&date_in=" & lastdate)
                End If
            End If
        End If
    End Sub
End Class