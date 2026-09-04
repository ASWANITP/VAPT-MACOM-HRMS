Imports System.Data
Imports System.Data.OracleClient
Partial Class _7DaysWorking_hrm_Seven_AM_Recomm_e05ab3dc8499
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt10 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim str_tkn1 As New System.Text.StringBuilder
    Dim str As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Dim ZoneID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "SEVEN DAYS OFF AM RECOMMENDATION"
        Dim masterPage As edp = CType(Me.Master, edp)
        masterPage.subtitle = "SEVEN DAYS OFF AM RECOMMENDATION"
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select a.post_id,a.branch_id from employee_master a where a.emp_code=" & User(0) & " and a.status_id=1 and a.post_id in (136,197,28,199,245,247)").Tables(0)
            Dim POSTID As Integer = dt.Rows(0)(0)
            If dt.Rows.Count >= 1 Then
                If POSTID = 136 Or POSTID = 199 Then
                    BranchID = dt.Rows(0)(1)
                    dt = oh.ExecuteDataSet("select area_id,reg_id from branch_dtl_new where branch_id=" & BranchID & "").Tables(0)
                    If dt.Rows.Count > 0 Then
                        If Not IsPostBack Then
                            AreaID = dt.Rows(0)(0)
                            RegionID = dt.Rows(0)(1)
                            dt = oh.ExecuteDataSet("select 0, '--Code--Name' as empname from dual union select a.emp_code,a.emp_code||'-'||c.emp_name  as empname from hrm_7days_off_day a,employee_master c,branch_dtl_new b where a.emp_code=c.emp_code and a.branch_id=b.branch_id and b.area_id=" & dt.Rows(0)(0) & " and a.status=2 order by empname").Tables(0)
                            If dt.Rows.Count <= 1 Then
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('No Employees for Sanction !!!!');")
                                cl_script0.Append("window.open('../home.aspx','_self');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            Else
                                Me.cmb_Select.DataSource = dt
                                Me.cmb_Select.DataTextField = dt.Columns(1).ColumnName
                                Me.cmb_Select.DataValueField = dt.Columns(0).ColumnName
                                Me.cmb_Select.DataBind()
                            End If
                        End If
                    End If
                ElseIf POSTID = 28 Or POSTID = 199 Or POSTID = 245 Or POSTID = 247 Then
                    BranchID = dt.Rows(0)(1)
                    dt = oh.ExecuteDataSet("select area_id,reg_id from branch_dtl_new where branch_id=" & BranchID & "").Tables(0)
                    If dt.Rows.Count > 0 Then
                        If Not IsPostBack Then
                            AreaID = dt.Rows(0)(0)
                            RegionID = dt.Rows(0)(1)
                            dt = oh.ExecuteDataSet("select 0, '--Code--Name' as empname from dual union select a.emp_code,a.emp_code||'-'||c.emp_name  as empname from hrm_7days_off_day a,employee_master c,branch_dtl_new b where a.emp_code=c.emp_code and a.branch_id=b.branch_id and b.reg_id=" & dt.Rows(0)(1) & " and a.status=2 order by empname").Tables(0)
                            If dt.Rows.Count <= 1 Then
                                Dim cl_script0 As New System.Text.StringBuilder
                                cl_script0.Append("         alert('No Employees for Sanction !!!!');")
                                cl_script0.Append("window.open('../home.aspx','_self');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                            Else
                                Me.cmb_Select.DataSource = dt
                                Me.cmb_Select.DataTextField = dt.Columns(1).ColumnName
                                Me.cmb_Select.DataValueField = dt.Columns(0).ColumnName
                                Me.cmb_Select.DataBind()
                            End If
                        End If
                    End If

                Else
                    Dim cl_script0 As New System.Text.StringBuilder
                    cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
                    cl_script0.Append("window.open('../home.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                End If
            End If
            '    dt4 = oh.ExecuteDataSet("select a.emp_code from employee_master a where a.emp_code=" & User(0) & " and a.designation_id in (65,29) and a.department_id in (169,44) and a.status_id=1").Tables(0)
            '    If dt4.Rows.Count >= 1 Then
            '        dt = oh.ExecuteDataSet("select 0, '--Code--Name' as empname from dual union select a.emp_code,a.emp_code||'-'||c.emp_name  as empname from hrm_7days_off_credit a,employee_master c where a.emp_code=c.emp_code and a.status=2 order by empname").Tables(0)
            '        If dt.Rows.Count <= 1 Then
            '            Dim cl_script0 As New System.Text.StringBuilder
            '            cl_script0.Append("         alert('No Details for Recommendation!!!!');")
            '            cl_script0.Append("window.open('../home.aspx','_self');")
            '            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            '        Else
            '            Me.cmb_Select.DataSource = dt
            '            Me.cmb_Select.DataTextField = dt.Columns(1).ColumnName
            '            Me.cmb_Select.DataValueField = dt.Columns(0).ColumnName
            '            Me.cmb_Select.DataBind()
            '        End If
            '    Else
            '        Dim cl_script0 As New System.Text.StringBuilder
            '        cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            '        cl_script0.Append("window.open('../home.aspx','_self');")
            '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            '    End If
            dt3 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.txt_date.Text = Format(dt3.Rows(0)(0), "dd/MMM/yyyy")
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
                dt = oh.ExecuteDataSet("select a.emp_code|| '*' ||c.emp_name|| '*' ||b.BRANCH_NAME|| '*' ||to_date(a.from_dt)|| '*' ||b.branch_id|| '*' ||a.holiday from hrm_7days_off_day a, branch_dtl_new b,employee_master c where a.emp_code=c.emp_code and a.branch_id=b.BRANCH_ID and a.status=2 and a.emp_code=" & CODE & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    Dim dr1 As DataRow
                    For Each dr1 In dt.Rows
                        str_tkn.Append(dr1(0))
                        str_tkn.Append("!")
                    Next
                    str_tkn.Append("@")
                    str_tkn.Append("2")
                End If
                CbResult = str_tkn.ToString
            Case 2
                Dim Instr() As String = DataStr(0).Split("%")
                Dim Dataa As String = Instr(0)
                Dim Code As Integer = Instr(1)
                Dim Status As Integer = Instr(2)
                Try
                    Dim User() As String
                    User = Session("user_id").ToString.Split("!")
                    Dim p(3) As OracleParameter

                    p(0) = New OracleParameter("Dataa", OracleType.VarChar, 10000000)
                    p(0).Value = Dataa

                    p(1) = New OracleParameter("userId", OracleType.Number, 6)
                    p(1).Value = User(0)

                    p(2) = New OracleParameter("Status", OracleType.Number, 1)
                    p(2).Value = Status

                    p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("hrm_Seven_AM_Recomm", p)
                    CbResult = p(3).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
    End Sub
End Class
