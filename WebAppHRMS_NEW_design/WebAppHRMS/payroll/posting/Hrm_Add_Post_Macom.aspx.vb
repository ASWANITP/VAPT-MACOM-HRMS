Imports System.Data
Imports System.Data.OracleClient
Partial Class payroll_Posting_Hrm_Add_Post_Macom_f1331c5e1802
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1, dt2, dt4, dt5 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim BranchID, AreaID, RegionID As Integer
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Dim frm As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ID As Integer = 235
        Dim User() As String
        User = Session("user_id").ToString.Split("!")


        dt = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & ID & " and emp_id=" & User(0) & "").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If


        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_EmpCode.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select to_date(sysdate) from dual").Tables(0)
            Me.hdn_sysdate.Value = Format(dt1.Rows(0)(0), "dd/MMM/yyyy")
            Me.txt_Date.Text = Me.hdn_sysdate.Value
        End If
        Me.rdb_Join.Attributes.Add("onclick", "OnClickRadioDate()")
        Me.rdb_Post.Attributes.Add("onclick", "OnClickRadioPost()")
        Me.rdb_Desig.Attributes.Add("onclick", "OnClickRadioDesig()")
        Me.rdb_Dept.Attributes.Add("onclick", "OnClickRadioDep()")
        Me.rdb_Salary.Attributes.Add("onclick", "OnClickRadioSalary()")
        Me.rdb_Cancel.Attributes.Add("onclick", "OnClickRadioCode()")
        Me.rdb_tl.Attributes.Add("onclick", "OnClickRadiotl()")
        Me.rdb_level.Attributes.Add("onclick", "OnClickRadiolvl()")
        Me.txt_Date.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_Date')")
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        frm = Session("Firm_id").ToString
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim CODE As String = Instr(0)
                'Commented..Firm checking not done..

                'dt2 = oh.ExecuteDataSet("select e.emp_name,to_char(to_date(e.join_dt)),p.post_name,d.designation,m.dep_name,e.basic_pay from employee_master e,post_mst p,designation_master d,department_mst m, employ_firm f where e.post_id=p.post_id and e.designation_id=d.designation_id and e.department_id=m.dep_id and e.emp_code=f.emp_code and e.emp_code=" & CODE & " and e.status_id=1 and f.firm_id=" & frm & " ").Tables(0)
                dt2 = oh.ExecuteDataSet("select  e.emp_name, to_char(to_date(e.join_dt)),p.post_name,d.designation,m.dep_name,e.basic_pay,tl.tl_empcode,tl.emp_level from employee_master    e,        post_mst           p,        designation_master d,        department_mst     m,        tl_trsfr_level tl,        employ_firm        f  where e.post_id = p.post_id    and e.designation_id = d.designation_id    and e.department_id = m.dep_id    and e.emp_code = f.emp_code    and tl.emp_code=e.emp_code    and e.emp_code =" & CODE & " and e.status_id = 1 and f.firm_id =" & Session("firm_id") & "and rownum=1").Tables(0)
                Dim dr As DataRow
                For Each dr In dt2.Rows
                    str_tkn.Append(dr(0))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(1))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(2))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(3))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(4))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(5))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(6))
                    str_tkn.Append("!")
                    str_tkn.Append(dr(7))
                    str_tkn.Append("~")

                Next
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = str_tkn.ToString
            Case 2
                If (DataStr(0) = "-33") Then
                    dt = oh.ExecuteDataSet("select 0, '---POST---' as postname from dual union select p.post_id,p.post_name as postname from post_mst p order by  postname").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"
                ElseIf (DataStr(0) = "-44") Then
                    dt = oh.ExecuteDataSet("select 0, '---DESIGNATION---' as desig from dual union select d.designation_id,d.designation as desig from designation_master d order by desig").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"
                ElseIf (DataStr(0) = "-55") Then
                    dt = oh.ExecuteDataSet("select 0, '---DEPARTMENT---' as dep from dual union select d.dep_id,d.dep_name as dep from department_mst d order by dep").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"
                ElseIf (DataStr(0) = "-66") Then
                    dt = oh.ExecuteDataSet("select 0, '---TECHLEAD---' as techlead from dual union select em.emp_code,em.emp_name from employee_master em where post_id=1045").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"
                ElseIf (DataStr(0) = "-77") Then
                    dt = oh.ExecuteDataSet("select 0, '---LEVEL---' as lev from dual union select t.level_id, t.levelr as lev from level_master t order by lev").Tables(0)

                    CbResult = FillData(CbResult, dt)
                    dt.Rows(0)(1) = CbResult
                    CbResult = CbResult + "@"
                End If
            Case 3

                Dim Instr() As String = DataStr(0).Split("%")
                Dim EmpCode As Integer = Instr(0)
                Dim Post As String = Instr(1)
                Dim JoinDate As Date = Instr(2)
                Dim Salary As String = Instr(3)
                Dim Status As Integer = Instr(4)


                Try
                    Dim p(6) As OracleParameter
                    p(0) = New OracleParameter("empcode", OracleType.Number, 6)
                    p(0).Value = EmpCode

                    p(1) = New OracleParameter("Post", OracleType.VarChar, 10)
                    p(1).Value = Post

                    p(2) = New OracleParameter("JoinDate", OracleType.DateTime)
                    p(2).Value = JoinDate

                    p(3) = New OracleParameter("Salary", OracleType.VarChar, 10)
                    p(3).Value = Salary

                    p(4) = New OracleParameter("Status", OracleType.Number, 1)
                    p(4).Value = Status

                    p(5) = New OracleParameter("userId", OracleType.Number, 6)
                    p(5).Value = User(0)

                    p(6) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(6).Direction = ParameterDirection.Output


                    oh.ExecuteNonQuery("HRM_CHANGE_POST_MACOM", p)
                    CbResult = p(6).Value
                Catch ex As Exception
                    CbResult = ex.Message
                End Try
        End Select
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
    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If Me.rdb_Cancel.Checked = False And Me.rdb_Dept.Checked = False And Me.rdb_Desig.Checked = False And Me.rdb_Join.Checked = False And Me.rdb_Post.Checked = False And Me.rdb_Salary.Checked = False Then
    '        Me.txt_EmpCode.Text = ""
    '        Dim cl_script0 As New System.Text.StringBuilder
    '        cl_script0.Append("         alert('Please Verify!!!');")
    '        'cl_script0.Append("window.open('../home.aspx','_self');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    '    ElseIf Me.rdb_Cancel.Checked = False And Me.rdb_Dept.Checked = False And Me.rdb_Desig.Checked = False And Me.rdb_Join.Checked = False And Me.rdb_Post.Checked = False And Me.rdb_Salary.Checked = False And Me.txt_EmpCode.Text = "" Then
    '        Dim cl_script0 As New System.Text.StringBuilder
    '        cl_script0.Append("         alert('Please Verify!!!');")
    '        'cl_script0.Append("window.open('../home.aspx','_self');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    '    Else
    '        Dim User() As String
    '        Dim Status As Integer
    '        User = Session("user_id").ToString.Split("!")
    '        Dim p(6) As OracleParameter
    '        If Me.rdb_Join.Checked = True Then
    '            Status = 1
    '        End If
    '        If Me.rdb_Post.Checked = True Then
    '            Status = 2
    '        End If
    '        If Me.rdb_Desig.Checked = True Then
    '            Status = 3
    '        End If
    '        If Me.rdb_Dept.Checked = True Then
    '            Status = 4
    '        End If
    '        If Me.rdb_Salary.Checked = True Then
    '            Status = 5
    '        End If
    '        If Me.rdb_Cancel.Checked = True Then
    '            Status = 6
    '        End If
    '        p(0) = New OracleParameter("userId", OracleType.Number, 6)
    '        p(0).Value = User(0)

    '        p(1) = New OracleParameter("Status", OracleType.Number, 1)
    '        p(1).Value = Status

    '        p(2) = New OracleParameter("EmpCode", OracleType.Number, 6)
    '        p(2).Value = Me.txt_EmpCode.Text

    '        'If Me.cmb_Select.SelectedValue = "" Then
    '        '    p(3) = New OracleParameter("Post", OracleType.Number, 3)
    '        '    p(3).Value = 0
    '        'Else
    '        p(3) = New OracleParameter("Post", OracleType.VarChar, 3)
    '        p(3).Value = Me.cmb_Select.SelectedValue
    '        'End If

    '        p(4) = New OracleParameter("JoinDate", OracleType.DateTime)
    '        p(4).Value = Me.txt_Date.Text

    '        'If Me.txt_Salary.Text = "" Then
    '        '    p(5) = New OracleParameter("Salary", OracleType.Number, 10)
    '        '    p(5).Value = 0
    '        'Else
    '        p(5) = New OracleParameter("Salary", OracleType.VarChar, 10)
    '        p(5).Value = Me.txt_Salary.Text
    '        'End If

    '        p(6) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
    '        p(6).Direction = ParameterDirection.Output

    '        oh.ExecuteNonQuery("hrm_change_post", p)
    '        Dim cl_script1 As New System.Text.StringBuilder
    '        cl_script1.Append("         alert('" + p(6).Value + "');")
    '        cl_script1.Append("         window.open('../home.aspx','_self');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
    '    End If
    'End Sub
End Class
