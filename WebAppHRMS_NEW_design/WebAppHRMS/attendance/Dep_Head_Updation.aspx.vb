Imports System.Data
Imports System.Data.OracleClient
Partial Class pl3_Dep_Head_Updation_97e1dc308577
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim dt, dt1 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "DEPARTMENT HEAD UPDATION"
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        Dim id As Integer
        id = Request.QueryString.Get("key")
        dt = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & id & " and emp_id=" & User(0) & "").Tables(0)
        If dt.Rows(0)(0) = 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select 0,'--SELECT--' as depname from dual union select a.department_id,a.department_name as depname from department_major a order by depname").Tables(0)
            Me.cmb_Major.DataSource = dt
            Me.cmb_Major.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_Major.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_Major.DataBind()
            dt1 = oh.ExecuteDataSet("select 0,'--SELECT--' as depname from dual union select a.dep_id,a.dep_name as depname from department_mst a  where a.status=1 and a.major_dep_id=" & Me.cmb_Major.SelectedValue & " order by depname").Tables(0)
            Me.cmb_Sub.DataSource = dt1
            Me.cmb_Sub.DataTextField = dt1.Columns(1).ColumnName
            Me.cmb_Sub.DataValueField = dt1.Columns(0).ColumnName
            Me.cmb_Sub.DataBind()
        End If
        Dim client_name As String
        client_name = "var master_no;" & "master_no='" & "" & Me.txt_DepHead.ClientID & "'" & ";"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", client_name, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim Datastr() As String
        Datastr = eventArgument.Split("#")
        Select Case (Datastr(1))
            Case 1
                Dim Instr() As String = Datastr(0).Split("%")
                Dim DEPID As String = Instr(0)
                dt = oh.ExecuteDataSet("select a.dep_id,a.dep_name,a.dep_head from department_mst a  where a.status=1 and a.major_dep_id=" & DEPID & " order by a.dep_name").Tables(0)
                CbResult = FillData(CbResult, dt)
                CbResult = CbResult + "@"
                Try
                    dt1 = oh.ExecuteDataSet("select b.emp_code ||'-'||b.emp_name from department_mst a,employee_master b where a.dep_head=b.emp_code and a.dep_head=" & dt.Rows(0)(2) & "").Tables(0)
                Catch ex As Exception
                    str_tkn.Append(ex.Message)
                Finally
                End Try
                If dt1.Rows.Count <> 0 Then
                    str_tkn.Append(dt1.Rows(0)(0))
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                'dt = oh.ExecuteDataSet("select 0,'--SELECT--' as depname from dual union select a.dep_id,a.dep_name as depname from department_mst a  where a.status=1 and a.major_dep_id=" & DEPID & " order by depname").Tables(0)
                CbResult = CbResult + str_tkn.ToString
            Case 2
                Dim Instr() As String = Datastr(0).Split("%")
                Dim HEADID As String = Instr(0)
                dt = oh.ExecuteDataSet("select b.emp_code ||'-'||b.emp_name from department_mst a,employee_master b where a.dep_head=b.emp_code and a.dep_id=" & HEADID & "").Tables(0)
                If dt.Rows.Count <> 0 Then
                    str_tkn.Append(dt.Rows(0)(0))
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = str_tkn.ToString
            Case 3
                Dim Instr() As String = Datastr(0).Split("%")
                Dim HEADID As String = Instr(0)
                dt = oh.ExecuteDataSet("select b.emp_code ||'-'||b.emp_name from employee_master b where b.emp_code=" & HEADID & " and b.status_id=1").Tables(0)
                If dt.Rows.Count <> 0 Then
                    str_tkn.Append(dt.Rows(0)(0))
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = str_tkn.ToString
            Case 4
                Dim Instr() As String = Datastr(0).Split("%")
                Dim depid As Integer = Instr(0)
                Dim headid As Integer = Instr(1)
                Try
                    Dim p(2) As OracleParameter
                    p(0) = New OracleParameter("depid", OracleType.Number, 4)
                    p(0).Value = depid

                    p(1) = New OracleParameter("headid", OracleType.Number, 6)
                    p(1).Value = headid

                    p(2) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(2).Direction = ParameterDirection.Output

                    oh.ExecuteNonQuery("hrm_DepHead_Updation", p)
                    CbResult = p(2).Value
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
