Imports System.Data
Imports System.Data.OracleClient
Partial Class RajBranchTime_hrm_branch_timechange_06a3c2186712
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=240 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then

            CType(Me.Master, WebAppHRMS.edp).Subtitle = "CHANGE BRANCH TIME"
            'Me.txt_start.Text = " "
            'Me.txt_end.Text = ""
            'Me.txt_effdate.Text = ""
            Dim script_val As String
            script_val = "var header;" & "header='" & Me.txt_start.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
            If Not IsPostBack Then


                dt = oh.ExecuteDataSet("select 0 as brid,' --------SELECT----------' as  bname from dual union select t.old_id as brid ,t.branch_name as bname from before_completion t, branch_time b where t.old_id = b.branch_id  union  select a.branch_id brid, a.branch_name bname from branch_master a, branch_time b where a.branch_id = b.branch_id  and a.branch_id != 0 order by bname").Tables(0)
                Me.ddl_branch.DataSource = dt
                Me.ddl_branch.DataValueField = dt.Columns(0).ColumnName
                Me.ddl_branch.DataTextField = dt.Columns(1).ColumnName
                Me.ddl_branch.DataBind()

                dt = oh.ExecuteDataSet("select -1 as shift_id,' --------SELECT----------' as in_time from dual union all select distinct a.shift_id ,a.in_time||' : '||a.out_time ||' : '||a.shift from time_tab a order by shift_id").Tables(0)
                Me.ddl_changetime.DataSource = dt
                Me.ddl_changetime.DataValueField = dt.Columns(0).ColumnName
                Me.ddl_changetime.DataTextField = dt.Columns(1).ColumnName
                Me.ddl_changetime.DataBind()
            End If

            Me.btnConfirm.Attributes.Add("onclick", "return ConfirmOnClick()")
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Select Case (x)
            Case "1"
                dt = oh.ExecuteDataSet("select t.in_time || ' * ' || t.out_time from branch_time t where t.branch_id =" & str(1)).Tables(0)
                st.Append(dt.Rows(0)(0))
                res = st.ToString
            Case "2"

        End Select
        res = st.ToString()

    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            Dim pr(4) As OracleParameter

            pr(0) = New OracleParameter("Branch", OracleType.Number, 5)
            pr(0).Value = Me.HiddenField1.Value

            pr(1) = New OracleParameter("EntTime", OracleType.Number, 2)
            pr(1).Value = Me.HiddenField2.Value

            pr(2) = New OracleParameter("EffDate", OracleType.VarChar, 15)
            pr(2).Value = Me.txt_effdate.Text

            pr(3) = New OracleParameter("OutMsg", OracleType.VarChar, 200)
            pr(3).Direction = ParameterDirection.Output

            pr(4) = New OracleParameter("Flag", OracleType.Number, 1)
            pr(4).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_branch_timechange_new", pr)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & pr(3).Value & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Catch ex As Exception

        End Try
    End Sub
End Class
