Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Partial Class tour_status_report_tour_new__applied_sattus_b2d206c26631
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim UserAll(), res, sql, str, firm As String
    Dim UserCode, fir, fmid, fmid1 As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.Response.Redirect("rpt_tour_applied_status.aspx?empcode=" & Me.cmb_cod.SelectedValue & "&fromdt=" & Me.txt_from.Text & "&todt=" & Me.txt_to.Text)
        fir = Session("firm_id")
        firm = Session("firm_name")
        Dim edc As String = Me.txt_emp.Text
        Dim enam As String = Me.txt_name.Text
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        dt3 = oh.ExecuteDataSet("select ef.firm_id from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & edc & "").Tables(0)
        fmid1 = dt3.Rows(0)(0)
        dt1 = oh.ExecuteDataSet("select ef.firm_id from employee_master e,employ_firm ef where ef.emp_code=e.emp_code and e.emp_code=" & UserCode & "").Tables(0)
        fmid = dt1.Rows(0)(0)
        'If fmid <> fir Or fmid <> fmid1 Then  ---- as per req id -11832 wef 1-aug-2016
        '    Response.Redirect("../show_err.aspx")
        'End If

        Dim acessid As String
        acessid = acces_chk("tour_new _applied_sattus")
        If acessid = 1 Then
            Response.Redirect("../show_err.aspx")
        End If

        If CDate(Me.txt_todt.Text) < CDate(Me.txt_frdt.Text) Then
            Dim str_tkn As New System.Text.StringBuilder
            str_tkn.Append("         alert(' Please Enter Correct Date ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
            Exit Sub
        Else
            'Me.Response.Redirect("rpt_tour_applied_status.aspx?empcode=" & Me.cmb_cod.SelectedValue & "&fromdt=" & Me.txt_from.Text & "&todt=" & Me.txt_to.Text)
            Me.Response.Redirect("rpt_tour_applied_status.aspx?&edc=" & Me.txt_emp.Text & "&fdt=" & Me.txt_frdt.Text & " &tdt=" & Me.txt_todt.Text & " &enam=" & Me.txt_name.Text & "")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txt_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                dt = oh.ExecuteDataSet("select d.emp_name from employee_master d where d.emp_code=" & str(1) & "").Tables(0)
                If dt.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt.Rows(0)(0))
                    cbResult = str_tkn.ToString
                End If
        End Select

    End Sub
    Function acces_chk(ByVal tp As String)
        Dim tr(2) As OracleParameter
        tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
        tr(0).Direction = ParameterDirection.Input
        tr(0).Value = Me.Session("user_id")
        tr(1) = New OracleParameter("form_nm", OracleType.VarChar, 50)
        tr(1).Direction = ParameterDirection.Input
        tr(1).Value = tp
        tr(2) = New OracleParameter("flag", OracleType.Number, 2)
        tr(2).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("form_acces_chk", tr)
        Dim flg As Integer
        flg = tr(2).Value
        Return flg
    End Function
End Class
