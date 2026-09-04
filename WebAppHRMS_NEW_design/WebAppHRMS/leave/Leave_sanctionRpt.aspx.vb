Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_Leave_sanctionRpt_4dc274f75500
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim sql As String
    Dim res As Integer
    Dim dt1 As DataTable
    Dim sd As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dt As DataTable
            dt = oh.ExecuteDataSet("select 0,'Leave' from dual union select 1,'Other Leave' from dual").Tables(0)
            Me.ddrlv.DataSource = dt
            Me.ddrlv.DataTextField = dt.Columns(1).ColumnName
            Me.ddrlv.DataValueField = dt.Columns(0).ColumnName
            Me.ddrlv.DataBind()
        End If
    End Sub
    Protected Sub cmdRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRpt.Click
        If Me.rdbAuth.Checked = True Then
            res = 1
        Else
            res = 2
        End If
        Server.Transfer("leave_auth_view.aspx?&opt=" & res & "&id=" & Me.ddrlv.SelectedValue)
    End Sub


    Protected Sub cmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim cl_script As New StringBuilder
        cl_script.Append("window.open('../home.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)
    End Sub
End Class
