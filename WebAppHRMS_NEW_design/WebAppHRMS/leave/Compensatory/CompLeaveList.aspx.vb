Imports System.Data.OracleClient
Imports System.Data
Imports System.IO

Partial Class CompLeaveList_0ff0a11c8833
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '------VAPT - improper parameter validation---------------------------------------
        Dim paramCount As Integer = Request.QueryString.Count
        If Request.QueryString.Count > 0 Then
            Response.StatusCode = 400
            Response.StatusDescription = "Bad Request"
            Response.End()
        End If
        If Not IsPostBack Then
            'Session("user_id") = "20007!233.444.555.666"
            'Me.DataBind()

            Dim dtacs As New DataTable

            dtacs = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=857 and s.emp_id=" & getuserid() & "").Tables(0)
            If (dtacs.Rows(0)(0) = 0) Then
                Server.Transfer("../../show_err.aspx")

            End If


        End If
    End Sub
    Private Function getfirmId() As Int32
        ' Return 24
        Return Convert.ToInt32(Me.Session("firm_id"))

    End Function
    Private Function getuserid() As String
        Dim user() As String

        user = Session("user_id").ToString.Split("!")
        Return user(0)

    End Function

    Function proccess()

        If Convert.ToDateTime(txtFromdate.Text) < Convert.ToDateTime(txtTodate.Text) Then
            Dim dtResult As New DataTable

            Dim sql As String

            sql = "select ef.firm_id,em.branch_id,cd.comp_id,cm.comp_name,cd.comp_date,cd.emp_code,cd.exp_date,cd.status_id as comp_dtl_sts,ce.state_id,ce.status as c_e_sts,ca.leave_dt,ca.status_id as apprv_sts,ca.sanc_date,ce.rowid" &
    " from hrm_comp_eligible ce " &
    " join hrm_comp_dtl cd on ce.emp_code=cd.emp_code and ce.comp_id=cd.comp_id and ce.comp_dt=cd.comp_date" &
    " join employee_master em on em.emp_code=cd.emp_code" &
    " join employ_firm ef on ef.emp_code=em.emp_code" &
    " left join hrm_comp_mst cm on cm.comp_id=ce.comp_id " &
    " left join hrm_comp_appl ca on ca.emp_code=cd.emp_code and ca.comp_id=cd.comp_id" &
          "   where em.status_id = 1 " &
    " and em.emp_code=" + TxtEmpcode.Text + " and ef.firm_id=" + Convert.ToString(getfirmId()) + " and cd.comp_date between to_date('" + txtFromdate.Text + "') and to_date('" + txtTodate.Text + "')"



            dtResult = getDatatable(sql)
            GrvCompLeave.DataSource = dtResult
            GrvCompLeave.DataBind()

            If dtResult.Rows.Count > 0 Then
                Dim ds As DataTable
                ds = getDatatable("select em.emp_name from emp_master em where em.emp_code=" + TxtEmpcode.Text)
                If ds.Rows.Count = 1 Then
                    LblEmpName.Text = ds.Rows(0)(0).ToString()
                Else
                    LblEmpName.Text = ""
                End If
            Else
                LblEmpName.Text = ""
            End If

        Else

            ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('From Date should be less than To Date');", True)

        End If

    End Function
    Private Function getDatatable(ByVal qry As Object) As DataTable
        Dim dtresults As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        dtresults = oh.ExecuteDataSet(qry).Tables(0)
        Return dtresults
    End Function

    Public Function ProcessLeaveDate(ByVal lvdt As String) As String


        If lvdt = "" Then
            Return ""
        Else
            Return Convert.ToDateTime(lvdt).ToString("dd-MMM-yyyy")
        End If

    End Function
    Public Function ProcessLeaveApproval(ByVal lvaprvl As String) As String

        '0 apl 1 app 2 rec 3 rej
        If lvaprvl = "" Then
            Return "Not applied"
        ElseIf lvaprvl = "0" Then
            Return "Applied"
        ElseIf lvaprvl = "1" Then
            Return "Approved"
        ElseIf lvaprvl = "2" Then
            Return "Recommanded"
        ElseIf lvaprvl = "3" Then
            Return "Rejected"

        End If

    End Function
    Public Function ExtendorNot(ByVal comp_dtl_sts As String, ByVal apprv_sts As String) As String

        '0 apl 1 app 2 rec 3 rej
        'If comp_dtl_sts <> "1" And apprv_sts = "" Then
        'If apprv_sts = "" Then
        If apprv_sts = "" Then
            Return "true"
        Else
            If apprv_sts <> 1 Then
                Return "true"
            Else
                Return "false"

            End If
        End If


    End Function



    Protected Sub ButnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButnExcel.Click

        proccess()
    End Sub


    Protected Sub LnkExtend_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim str As String()
        str = e.CommandArgument.ToString().Split("*")

        hdnCmpid.Value = str(0)
        TxtExtDate.Text = str(1)
        hidCompdt.Value = str(2)

        HdnEmpcode.Value = e.CommandName

        Lblmessage.Text = ""
        ModalPopupExtender12.Show()


    End Sub

    Protected Sub ButSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButSubmit.Click
        Dim pr(4) As OracleParameter

        pr(0) = New OracleParameter("empcode", OracleType.Number, 10)
        pr(0).Value = HdnEmpcode.Value

        pr(1) = New OracleParameter("cmpid", OracleType.Number, 4)
        pr(1).Value = hdnCmpid.Value
        pr(2) = New OracleParameter("extdt", OracleType.DateTime, 50)
        pr(2).Value = Convert.ToDateTime(TxtExtDate.Text)
        pr(3) = New OracleParameter("msg", OracleType.VarChar, 35)
        pr(3).Direction = ParameterDirection.Output

        pr(4) = New OracleParameter("compdt", OracleType.DateTime, 50)
        pr(4).Value = Convert.ToDateTime(hidCompdt.Value)


        oh.ExecuteNonQuery("extend_comp_exp_date", pr)
        Lblmessage.Text = pr(3).Value
        Dim cl_script1 As New System.Text.StringBuilder
        cl_script1.Append("alert('" & pr(3).Value & "');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ModalPopupExtender12.Hide()
        proccess()


    End Sub
End Class
