Imports system.data
Imports System.Data.OracleClient

Partial Class Check_HR_FIRM_CHANG_bcdf99557071

    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim userAll() As String
    Dim usercode As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As DataTable
    Dim sql, b, cbResult As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddHours(-1))
        Response.Cache.SetNoStore()

        userAll = Me.Session("user_id").ToString.Split("!")
        usercode = userAll(0)
        sql = "select count(*) from form_accessibility t where t.emp_id=" & userAll(0) & " and t.form_id=616"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        Dim f As Integer
        f = CInt(dt.Rows(0)(0))
        If f > 0 Then
            '--//--------- Script Registrations ----------//--
            Dim script_val As String
            script_val = "var header_txt;header_txt='" & Me.Cmb_Firm.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "header_txt", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)

            Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)

            '--//---------- Declaring Functions ----------//--
            Me.Txt_Empcode.Attributes.Add("onkeyup", "IsNumericCheck('Txt_Empcode')")
            Me.Cmb_Firm.Attributes.Add("Onchange", "FirmOnchange()")
            If Not IsPostBack() Then
                Dim user1 As String = Me.Session("user_id")
                Dim empcode = user1.Split("!")
                dt2 = oh.ExecuteDataSet("select -1,'-------Select Firm--------' as firm from dual union all select t.firm_id,t.firm_abbr from firm_master t order by firm").Tables(0)
                Me.Cmb_Firm.DataSource = dt2
                Me.Cmb_Firm.DataValueField = dt2.Columns(0).ColumnName
                Me.Cmb_Firm.DataTextField = dt2.Columns(1).ColumnName
                Me.Cmb_Firm.DataBind()
            End If

        Else
            Me.Response.Redirect("../show_err.aspx")
            Exit Sub
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return cbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim EmpCode As String = eventArgument.ToString
        'CustID+""+TotAmt+""+Discount+""+SaleDtl
        Try


            Dim sql As String = "select t.emp_code||'~'||       a.EMP_NAME||'~'||       b.BRANCH_ID||'~'||       b.BRANCH_NAME||'~'||       t.firm_id||'~'||       c.firm_abbr||'~'||       a.POST_ID||'~'||       d.post_name||'~'||       e.designation_id||'~'||       e.designation||'~'||       to_char(a.JOIN_DT)  from employ_firm        t,       emp_master         a,       branch_dtl_new     b,       firm_master        c,       post_mst           d,       designation_master e where t.emp_code = a.emp_code and a.STATUS_ID=1 and a.BRANCH_ID = b.BRANCH_ID   and t.firm_id = c.firm_id   and d.post_id = a.POST_ID   and t.emp_code = '" & EmpCode & "'   and e.designation_id = a.DESIGNATION_ID"
            dt2 = oh.ExecuteDataSet(sql).Tables(0)
            If dt2.Rows.Count > 0 Then
                cbResult = dt2.Rows(0)(0).ToString
            Else
                cbResult = ""
            End If


        Catch ex As Exception
            cbResult = ex.Message.ToString
        End Try
    End Sub

    Protected Sub Butn_Chage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Butn_Chage.Click
        Try
            Dim params(2) As OracleParameter
            params(0) = New OracleParameter("empcode", OracleType.VarChar, 20)
            params(0).Value = Me.HiddenEmp.Value
            params(0).Direction = ParameterDirection.Input

            params(1) = New OracleParameter("firmid", OracleType.Number, 10)
            params(1).Value = Me.HiddenFirm.Value
            params(1).Direction = ParameterDirection.Input

            params(2) = New OracleParameter("ReturnMessage", OracleType.VarChar, 500)
            params(2).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("EMP_FIRM_CHANGE_STP", params)

            Dim message As String = params(2).Value.ToString
            Dim script1 As New StringBuilder
            script1.Append("         alert('" & message & "');")
            script1.Append("window.open('HR_FIRM_CHANG.aspx','_self');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)


        Catch ex As Exception
            cbResult = ex.Message.ToString

        End Try
    End Sub
End Class
