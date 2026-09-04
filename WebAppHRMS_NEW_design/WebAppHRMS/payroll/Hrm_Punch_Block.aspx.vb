Imports System.Data
Imports System.Data.OracleClient
Partial Class new_leave_Hrm_Leave_Status_a800cb2b9443
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "PUNCH BLOCK"
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim ID As Integer = 105
        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & ID & " and emp_id=" & User(0) & "").Tables(0)
        If dt1.Rows.Count < 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If



        dt = oh.ExecuteDataSet("select e.emp_code,e.emp_code||'-'||e.emp_name from employee_master e where e.status_id=1 and e.emp_code>10000 order by e.emp_code ").Tables(0)
        If dt.Rows.Count <= 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('No Details To Display !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        Else
            Me.cmb_Select.DataSource = dt
            Me.cmb_Select.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_Select.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_Select.DataBind()
        End If
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.cmb_Select.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                dt2 = oh.ExecuteDataSet("select b.BRANCH_NAME,p.post_name,d.dep_name from employee_master e,post_mst p,department_mst d,branch_dtl_new b where e.branch_id=b.BRANCH_ID and e.post_id=p.post_id and e.department_id=d.dep_id and e.emp_code=" & CODE & "").Tables(0)
                If dt2.Rows.Count > 0 Then
                    Dim dr As DataRow
                    For Each dr In dt2.Rows
                        str_tkn.Append(dr(0))
                        str_tkn.Append("!")
                        str_tkn.Append(dr(1))
                        str_tkn.Append("!")
                        str_tkn.Append(dr(2))
                        str_tkn.Append("~")
                    Next
                    str_tkn.Append("@")
                    str_tkn.Append("2")
                End If
                CbResult = str_tkn.ToString
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim EmpCode As Integer = Instr(0)
                Dim Reason As String = Instr(1)

                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")
                    Dim p(3) As OracleParameter
                    p(0) = New OracleParameter("EmpCode", OracleType.Number, 5)
                    p(0).Value = EmpCode

                    p(1) = New OracleParameter("Reason", OracleType.DateTime)
                    p(1).Value = Reason

                    p(2) = New OracleParameter("UserID", OracleType.DateTime)
                    p(2).Value = User(0)

                    p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("", p)

                    CbResult = p(3).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class
