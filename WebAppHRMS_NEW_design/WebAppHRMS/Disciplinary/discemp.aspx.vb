Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_SECURITY_hrm_Add_Post_528746865453
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt4, dt5 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usr() As String = Session("user_id").Split("!")
        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility  where form_id=5195 and emp_id=" & usr(0) & "").Tables(0)
        Dim access As Integer = dt1.Rows(0)(0)
        If Session("access_id") = 33 Or access > 0 Then
            If Not IsPostBack Then
                dt1 = oh.ExecuteDataSet("select '---SELECT---', 0 b from dual union all select to_char(ms.emp_code||'~'||ms.emp_name),ms.emp_code from employee_MASTER ms,employ_firm fm where ms.emp_code=fm.emp_code and fm.firm_id=8 order by 1").Tables(0)
                'Dim access As Integer = dt1.Rows(0)(0)
                Me.DropDownList1emp.DataSource = dt1
                Me.DropDownList1emp.DataValueField = dt1.Columns(1).ColumnName
                Me.DropDownList1emp.DataTextField = dt1.Columns(0).ColumnName
                Me.DropDownList1emp.DataBind()

            End If
        Else
            Response.Redirect("../../show_err.aspx")
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.DropDownList1emp.SelectedValue = 0 Then

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please select employee');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script1.ToString, True)

        Else


            Server.Transfer("emprep.aspx?code=" & Me.DropDownList1emp.SelectedValue & "")
        End If
    End Sub


   
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("../home.aspx")
    End Sub
End Class
