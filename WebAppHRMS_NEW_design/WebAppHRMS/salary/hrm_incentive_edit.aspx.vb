Imports System.Data
Imports System.Data.OracleClient
Partial Class Incentive_Edit_hrm_incentive_edit_363618856837
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim PostID, BranchID, AreaID, RegID As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=184 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "Incentive Change"
            Dim script_val As String
            script_val = "var header;" & "header='" & Me.ddlIncentive.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

            If Not IsPostBack Then

                dt = oh.ExecuteDataSet("select -1 as Insid,' --------SELECT----------' as  Insname from dual union all select distinct t.all_id, t.all_name from incentives_allowances_master t, incentives_allowances_dtl i where t.all_id=i.all_id and i.status_id is null order by Insname").Tables(0)
                Me.ddlIncentive.DataSource = dt
                Me.ddlIncentive.DataValueField = dt.Columns(0).ColumnName
                Me.ddlIncentive.DataTextField = dt.Columns(1).ColumnName
                Me.ddlIncentive.DataBind()

            End If
            Me.ddlIncentive.Attributes.Add("onchange", "ClassOnChange()")

        Else
            Me.Server.Transfer("../show_err.aspx")
        End If

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

                dt2 = oh.ExecuteDataSet("select i.emp_code || '*' || e.emp_name || '*' || i.all_amount from incentives_allowances_master t, incentives_allowances_dtl i ,employee_master e where t.all_id=i.all_id and e.emp_code=i.emp_code and t.all_id=" & str(1) & " and i.rec_firm= " & Me.Session("firm_id") & " order by e.emp_code").Tables(0)
                Dim dr As DataRow

                For Each dr In dt2.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                Next
                str_tkn.Append("@")
                cbResult = str_tkn.ToString

            Case "2"

                Dim Instr() As String = str(1).Split("%")
                Dim Dataa As String = Instr(0)
                Dim InsID As Integer = Instr(1)

                Try

                    Dim p(2) As OracleParameter

                    p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                    p(0).Value = Dataa

                    p(1) = New OracleParameter("InsID", OracleType.Number, 6)
                    p(1).Value = InsID

                    p(2) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(2).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("hrm_Incentive_Edit", p)
                    cbResult = p(2).Value
                Catch ex As Exception
                    cbResult = ex.Message

                End Try

            Case "3"
                'Dim Instr() As String = str(1).Split("!")
                'Dim inid As Integer = Instr(0)
                'Dim eid As Integer = Instr(1)

                Try

                    Dim p(1) As OracleParameter

                    p(0) = New OracleParameter("Dataa", OracleType.VarChar, 2000)
                    p(0).Value = str(1)
                    p(1) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(1).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("hrm_Incentive_Delete", p)
                    cbResult = p(1).Value
                Catch ex As Exception
                    cbResult = ex.Message

                End Try



        End Select
    End Sub
End Class
