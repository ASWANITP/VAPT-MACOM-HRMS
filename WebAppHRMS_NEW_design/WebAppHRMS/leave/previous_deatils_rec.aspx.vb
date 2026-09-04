Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_shima_previous_deatils_rec_906e42b25228
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Dim res, str As String
    Dim dt, dt1 As DataTable
    ' Dim res As Integer

    Dim firmid As Integer
    Dim branchid As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Me.Session("user_id") = "" Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append(" alert('Please Login Again and Retry....!! ');")
            cl_script1.Append("    window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            Exit Sub
        End If

        Dim dt As DataTable
        Dim fr As Integer = Me.Session("firm_id")


        Dim User() As String
        User = Session("user_id").ToString.Split("!")

        dt1 = oh.ExecuteDataSet("select t.query from HRM_REPORT_MASTER t where t.query_id=148 and t.firm_id=99").Tables(0)
        Str = dt1.Rows(0)(0).ToString.Split("#")(2)
        Str = Str.Replace("mycode", Request.QueryString("code"))
        Str = Str.Replace("usecode", User(0))
        dt = oh.ExecuteDataSet(Str).Tables(0)


        Me.Text1.Value = dt.Rows(0)(0)
        Me.Text2.Value = dt.Rows(0)(1)
        Me.Text3.Value = dt.Rows(0)(2)

        Me.Text6.Value = dt.Rows(0)(3)
        Me.Text7.Value = dt.Rows(0)(4)

        Me.Text4.Value = dt.Rows(0)(5)
        Me.Text8.Value = dt.Rows(0)(6)

        Me.Text5.Value = dt.Rows(0)(7)
        Me.Text9.Value = dt.Rows(0)(8)

        Me.Text10.Value = dt.Rows(0)(9)

        Me.Text11.Value = dt.Rows(0)(10)

    End Sub
End Class


