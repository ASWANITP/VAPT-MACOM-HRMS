Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_SECURITY_hrm_Add_Post_528746864699
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt3, dt4, dt5 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim d1, d2 As String


    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dt3 = oh.ExecuteDataSet("select '---SELECT---', 0 from dual union all select ms.discipline_name,ms.discipline_id from HRM_DISCIPLINARY_MASTER ms").Tables(0)
            Me.DropDownList1.DataSource = dt3
            Me.DropDownList1.DataValueField = dt3.Columns(1).ColumnName
            Me.DropDownList1.DataTextField = dt3.Columns(0).ColumnName
            Me.DropDownList1.DataBind()
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        
    End Sub
    Public Function FillData(ByVal cbResult As String, ByVal DT As DataTable) As String
        For n As Integer = 0 To DT.Rows.Count - 1
            cbResult += DT.Rows(n)(0).ToString
            cbResult += "$"
            cbResult += DT.Rows(n)(1).ToString
            If n < DT.Rows.Count - 1 Then
                cbResult += "*"
            End If
        Next
        Return cbResult
    End Function

  
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
       

        d1 = Me.TextBox1.Text
        d2 = Me.TextBox2.Text
        If IsDBNull(d1) Or d1 = "" Then

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please  select from date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script1.ToString, True)

        ElseIf IsDBNull(d2) Or d2 = "" Then

            Dim cl_script1, cl_script9 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please select to date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script1", cl_script1.ToString, True)

         


        Else
            Server.Transfer("wholerep.aspx?discipline_id=" & Me.DropDownList1.SelectedValue & "&occuredfrmdt=" & Me.TextBox1.Text & "" & "&occuredtodt=" & d2 & "")

            Exit Sub
        End If

    End Sub






    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("../home.aspx")
    End Sub

  
End Class
