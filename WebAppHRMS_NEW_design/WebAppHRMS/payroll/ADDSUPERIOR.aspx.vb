Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_ADDSUPERIOR_28f54fb89270
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim dt, dt1 As New DataTable
    Dim CbResult As String = Nothing
    Dim Radio1, Radio2, Radio3 As String
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "ADD SUPERIOR"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "ADD SUPERIOR"
        Dim BranchID As Integer = CInt(Session("branch_id"))
        If BranchID <> 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Pls Login in Head Office!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If

        If Session("access_id") <> 33 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Are Not Authorised To View This Page!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        Me.rbt_Add.Checked = True
        Me.rbt_Add.Attributes.Add("onclick", "OnClickRadioAdd()")
        Me.rbt_Delete.Attributes.Add("onclick", "OnClickRadioDelete()")
        Me.rbt_Edit.Attributes.Add("onclick", "OnClickRadioEdit()")
        Me.cmb_Select.Attributes.Add("onchange", "FillEmployDetails()")
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_Code.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select b.emp_code,b.emp_code || '-' || b.emp_name,b.grade_id from employee_master_dtl a,employee_master b where a.emp_code=b.emp_code and a.superior_id is null and b.branch_id=0 and b.status_id=1 and a.emp_code>10000 order by b.emp_code").Tables(0)
            Me.cmb_Select.DataSource = dt
            Me.cmb_Select.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_Select.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_Select.DataBind()
            dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,b.designation,c.dep_name,d.post_name,b.grade_id from employee_master a,designation_master b,department_mst c,post_mst d where a.designation_id=b.designation_id and a.emp_code='" & dt.Rows(0)(0) & "' and a.department_id=c.dep_id and a.post_id=d.post_id and a.status_id=1 ").Tables(0)
            Me.txt_Code.Text = dt1.Rows(0)(0)
            Me.txt_Name.Text = dt1.Rows(0)(1)
            Me.txt_Desig.Text = dt1.Rows(0)(2)
            Me.txt_Depart.Text = dt1.Rows(0)(3)
            Me.txt_Post.Text = dt1.Rows(0)(4)
            dt = oh.ExecuteDataSet("select a.emp_code,a.emp_code||' - '||a.emp_name ||' - '|| c.dep_name from employee_master a, designation_master b,department_mst c where a.designation_id=b.designation_id and b.grade_id<'" & dt.Rows(0)(2) & "' and a.status_id=1 and a.branch_id=0 and a.emp_code>10000 and a.department_id=c.dep_id order by a.emp_code").Tables(0)
            Me.cmb_Superior.DataSource = dt
            Me.cmb_Superior.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_Superior.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_Superior.DataBind()
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim Datastr() As String
        Datastr = eventArgument.Split("#")
        Select Case (Datastr(1))
            Case 1
                If (Datastr(0) = "-22") Then
                    dt = oh.ExecuteDataSet("select b.emp_code,b.emp_code || '-' || b.emp_name from employee_master_dtl a,employee_master b where a.emp_code=b.emp_code and a.superior_id is null and b.branch_id=0 and b.status_id=1 and a.emp_code>10000 order by b.emp_code").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"
                    '555555555555555555555
                    Try
                        Dim sql1 As String
                        sql1 = "select a.emp_code,a.emp_name,b.designation,c.dep_name,d.post_name,b.grade_id from employee_master a,designation_master b,department_mst c,post_mst d where a.designation_id=b.designation_id and a.emp_code='" & dt.Rows(0)(0) & "' and a.department_id=c.dep_id and a.post_id=d.post_id and a.status_id=1"
                        dt = oh.ExecuteDataSet(sql1).Tables(0)
                    Catch ex As Exception
                        str_tkn.Append(ex.Message)
                    Finally
                    End Try
                    If dt.Rows.Count <> 0 Then
                        str_tkn.Append(dt.Rows(0)(0))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(1))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(2))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(3))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(4))
                    End If
                    str_tkn.Append("@")
                    str_tkn.Append("2")
                    CbResult = CbResult + str_tkn.ToString
                    '555555555555555555555
                ElseIf (Datastr(0) = "-33") Then
                    dt = oh.ExecuteDataSet("select b.emp_code,b.emp_code || '-' || b.emp_name from employee_master_dtl a,employee_master b where a.emp_code=b.emp_code and a.superior_id is not null and b.branch_id=0  and b.status_id=1 and a.emp_code>10000 order by b.emp_code").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"

                    '555555555555555555555
                    Try
                        Dim sql1 As String
                        sql1 = "select a.emp_code,a.emp_name,b.designation,c.dep_name,d.post_name,b.grade_id from employee_master a,designation_master b,department_mst c,post_mst d where a.designation_id=b.designation_id and a.emp_code='" & dt.Rows(0)(0) & "' and a.department_id=c.dep_id and a.post_id=d.post_id and a.status_id=1"
                        dt = oh.ExecuteDataSet(sql1).Tables(0)
                    Catch ex As Exception
                        str_tkn.Append(ex.Message)
                    Finally
                    End Try
                    If dt.Rows.Count <> 0 Then
                        str_tkn.Append(dt.Rows(0)(0))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(1))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(2))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(3))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(4))
                    End If
                    str_tkn.Append("@")
                    str_tkn.Append("2")
                    CbResult = CbResult + str_tkn.ToString
                    '555555555555555555555
                ElseIf (Datastr(0) = "-44") Then
                    dt = oh.ExecuteDataSet("select b.emp_code,b.emp_code || '-' || b.emp_name from employee_master_dtl a,employee_master b where a.emp_code=b.emp_code and a.superior_id is not null and b.branch_id=0  and b.status_id=1 and a.emp_code>10000 order by b.emp_code").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"
                    '555555555555555555555
                    Try
                        Dim sql1 As String
                        sql1 = "select a.emp_code,a.emp_name,b.designation,c.dep_name,d.post_name,b.grade_id from employee_master a,designation_master b,department_mst c,post_mst d where a.designation_id=b.designation_id and a.emp_code='" & dt.Rows(0)(0) & "' and a.department_id=c.dep_id and a.post_id=d.post_id and a.status_id=1"
                        dt = oh.ExecuteDataSet(sql1).Tables(0)
                    Catch ex As Exception
                        str_tkn.Append(ex.Message)
                    Finally
                    End Try
                    If dt.Rows.Count <> 0 Then
                        str_tkn.Append(dt.Rows(0)(0))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(1))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(2))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(3))
                        str_tkn.Append("!")
                        str_tkn.Append(dt.Rows(0)(4))
                    End If
                    str_tkn.Append("@")
                    str_tkn.Append("2")
                    CbResult = CbResult + str_tkn.ToString
                    '555555555555555555555
                End If
            Case 2
                Dim Instr() As String = Datastr(0).Split("%")
                Dim CODE As String = Instr(0)
                Try
                    Dim sql1 As String
                    sql1 = "select a.emp_code,a.emp_name,b.designation,c.dep_name,d.post_name,b.grade_id from employee_master a,designation_master b,department_mst c,post_mst d where a.designation_id=b.designation_id and a.emp_code='" & CODE & "' and a.department_id=c.dep_id and a.post_id=d.post_id and a.status_id=1"
                    dt = oh.ExecuteDataSet(sql1).Tables(0)
                Catch ex As Exception
                    str_tkn.Append(ex.Message)
                Finally
                End Try
                If dt.Rows.Count <> 0 Then
                    str_tkn.Append(dt.Rows(0)(0))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(1))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(2))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(3))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(4))
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                Dim GradeId As Integer = CInt(dt.Rows(0)(5))
                dt = oh.ExecuteDataSet("select a.emp_code,a.emp_code||'-'||a.emp_name||' - '|| c.dep_name from employee_master a, designation_master b,department_mst c where a.designation_id=b.designation_id and b.grade_id<'" & GradeId & "' and a.status_id=1 and a.emp_code>10000 and a.department_id=c.dep_id and a.branch_id=0 order by a.emp_code").Tables(0)
                CbResult = FillData(CbResult, dt)
                CbResult = CbResult + "@"
                CbResult = CbResult + str_tkn.ToString

            Case 3
                Dim Instr() As String = Datastr(0).Split("%")
                Dim EmpCode As String = Instr(0)
                Dim SupCode As Integer = Instr(1)
                Dim Status As Integer = Instr(2)
                Try

                    Dim p(3) As OracleParameter
                    p(0) = New OracleParameter("empcode", OracleType.Number, 5)
                    p(0).Value = EmpCode

                    p(1) = New OracleParameter("superiorid", OracleType.Number, 5)
                    p(1).Value = SupCode

                    p(2) = New OracleParameter("rdb", OracleType.Number, 2)
                    p(2).Value = Status

                    p(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(3).Direction = ParameterDirection.Output
                    oh.ExecuteNonQuery("HRM_ADD_SUPERIOR", p)

                    CbResult = p(3).Value
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
End Class
