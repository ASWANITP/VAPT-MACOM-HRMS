Imports System.Data
Imports System.Data.OracleClient
Partial Class Account_No_Add_hrm_BankAccountAdd_996b8a538607
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CType(Me.Master, WebAppHRMS.edp).Subtitle = "Account Number Add/Change"
            UserAll = Me.Session("user_id").ToString.Split("!")
            UserCode = UserAll(0)
            Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=184 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
            If acce > 0 Then

                'Dim data As DataTable = getDatatable("select em.emp_code,em.emp_name||'-'||em.emp_code as textdata from emp_pnb_data epd join employee_master em on epd.emp_code=em.emp_code where epd.status_id=1  and epd.acc_typ=1 and em.firm_id=" + getfirmId().ToString() + " order by em.emp_code")
                'Dim data As DataTable = getDatatable("select t.status_id as emp_code,t.description as textdata from status_master t where t.module_id=111 and t.option_id=1 order by t.order_by")
                Dim data As DataTable = getDatatable("select t.bank_id as emp_code,t.bank_name as textdata from firm_bank_master t where t.firm_id=" + getfirmId().ToString() + " order by t.bank_name")
                DDLEmpcode.DataSource = data
                DDLEmpcode.DataBind()
            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        End If
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.txtEcode.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)
    End Sub
    Private Function getDatatable(ByVal qry As Object) As DataTable
        Dim dtresults As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        dtresults = oh.ExecuteDataSet(qry).Tables(0)
        Return dtresults
    End Function
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult

        Return cbResult

    End Function
    Private Function getfirmId() As Int32
        'Return 24
        'Return 24
        Dim fid As Int32

        fid = Convert.ToInt32(Me.Session("firm_id"))
        Return fid
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)

        Select Case (x)

            Case "1"

                dt = oh.ExecuteDataSet("select a.emp_name || '*' || c.dep_name || '*' || d.designation || '*' || e.branch_name || '*' || b.bank_accno || '*' || a.branch_id || '*' || nvl(sm.bank_id,0)|| '*' || nvl(sm.bank_name,'not updated'),nvl(sm.bank_id,0),nvl(sm.bank_name,'not updated') from employee_master     a join employee_master_dtl b on b.emp_code=a.emp_code join department_mst c on c.dep_id=a.department_id join designation_master  d on d.designation_id=a.designation_id join branch_master e on e.branch_id=a.branch_id left join firm_bank_master sm on sm.bank_id = b.bank_ac_typ and sm.firm_id = " + getfirmId().ToString() + " where(a.status_id = 1) and a.emp_code =" & str(1) & "").Tables(0)
                If dt.Rows.Count = 0 Then
                    str_tkn.Append("NULL")
                Else
                    str_tkn.Append(dt.Rows(0)(0))
                    cbResult = str_tkn.ToString
                End If

               


            Case "2"

                Dim empid As Integer
                empid = str(1)
                Dim acc As String
                acc = str(2)
                Dim actp As Integer = str(3)
                Try



                    Dim p(3) As OracleParameter

                    p(0) = New OracleParameter("EmpID", OracleType.Number, 6)
                    p(0).Value = empid

                    p(1) = New OracleParameter("Acc", OracleType.Number, 15)
                    p(1).Value = acc

                    p(2) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
                    p(2).Direction = ParameterDirection.Output

                    p(3) = New OracleParameter("Acctp", OracleType.Number, 15)
                    p(3).Value = actp


                    oh.ExecuteNonQuery("hrm_Account_Add", p)
                    cbResult = p(2).Value
                Catch ex As Exception
                    cbResult = ex.Message

                End Try


        End Select
    End Sub

    Protected Sub DDLEmpcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLEmpcode.SelectedIndexChanged

        dt = oh.ExecuteDataSet("select a.emp_name || '*' || c.dep_name || '*' || d.designation || '*' || e.branch_name || '*' || b.bank_accno || '*' || a.branch_id || '*' || nvl(sm.status_id,0)|| '*' || nvl(sm.description,'not updated'),nvl(sm.status_id,0),nvl(sm.description,'not updated') from employee_master     a join employee_master_dtl b on b.emp_code=a.emp_code join department_mst c on c.dep_id=a.department_id join designation_master  d on d.designation_id=a.designation_id join branch_master e on e.branch_id=a.branch_id left join status_master sm on sm.status_id=b.bank_ac_typ and sm.module_id=111 and sm.option_id=1 where(a.status_id = 1) and a.emp_code =" & Me.txtEcode.Text.ToString & "").Tables(0)
        If dt.Rows.Count = 0 Then
            str_tkn.Append("NULL")
        Else
            str_tkn.Append(dt.Rows(0)(0))
            cbResult = str_tkn.ToString
        End If


    End Sub
   
End Class
