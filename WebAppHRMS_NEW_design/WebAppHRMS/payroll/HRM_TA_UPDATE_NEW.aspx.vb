Imports System.Data
Imports System.Data.OracleClient
Partial Class HRM_JEWEL_TA_KRISHNADAS_e8a008a62815
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim CbResult As String = Nothing
    Dim str, pass_data, user() As String
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim branchid, chk1, chk2 As Integer
    Dim chk3, chk4 As Double
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("firm_id") = 8 Then
            Server.Transfer("~/TA/ta_new.aspx")
        End If
        ''REQ ID==10621=====>JEWEL TA APPLICATION=====>14-DEC-2015 KRISHNADAS
        branchid = Session("branch_id")
        If Not IsPostBack Then
            user = Session("user_id").ToString.Split("!")
            Me.hid_sysdate.Value = oh.ExecuteDataSet("select to_char(to_date(sysdate),'yyyy/mm/dd')from dual").Tables(0).Rows(0)(0)
            Me.hid_userid.Value = user(0)
            If branchid <> 0 Then
                dt = oh.ExecuteDataSet("select t.reg_name||', ' from region_master t join branch_master m on  m.region_id=t.reg_id where m.branch_id=" & branchid & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    str = dt.Rows(0)(0).ToString()
                End If
            Else
                str = ""
            End If
            str += Session("branch_name").ToString()
            Me.Lbl_branch.Text = str
            chk1 = oh.ExecuteDataSet("select count(*) from general_parameter t where t.firm_id=1 and t.parmtr_id in (101)").Tables(0).Rows(0)(0)
            chk2 = oh.ExecuteDataSet("select count(*) from general_parameter t where t.firm_id=1 and t.parmtr_id in (102)").Tables(0).Rows(0)(0)
            If chk1 = 1 And chk2 = 1 Then
                chk3 = oh.ExecuteDataSet("select t.parmtr_value from general_parameter t where t.firm_id=1 and t.parmtr_id in (101)").Tables(0).Rows(0)(0)
                chk4 = oh.ExecuteDataSet("select t.parmtr_value from general_parameter t where t.firm_id=1 and t.parmtr_id in (102)").Tables(0).Rows(0)(0)
                Me.hid_bike.Value = chk3
                Me.hid_bus.Value = chk4
            End If
            loadallowance()
        End If
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Me.Chk_map.Attributes.Add("onclick", "chk_add1()")
        Me.cmb_purpose.Attributes.Add("onchange", "purposechange()")
        Me.cmb_mode.Attributes.Add("onchange", "modechange()")
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        '100111%22#1
        Dim Datastr(), empcode() As String
        Datastr = eventArgument.Split("#")
        Dim frm As Integer = Session("firm_id")
        Dim str_tkn As New StringBuilder
        Dim EmpName As String
        Select Case (Datastr(1))
            Case 1
                empcode = Datastr(0).Split("%")
                Dim EmpCount As Integer = oh.ExecuteDataSet("select count(*) from employee_master where emp_code > 9999 and emp_code = " & empcode(0)).Tables(0).Rows(0)(0)
                If EmpCount = 1 Then
                    EmpName = oh.ExecuteDataSet("select emp_name from employee_master where emp_code = " & empcode(0) & "").Tables(0).Rows(0)(0)
                Else
                    EmpName = "NOT FOUND"
                End If
                str_tkn.Append(EmpName)
        End Select
        CbResult = str_tkn.ToString
    End Sub
    Private Sub loadallowance()
        dt3 = oh.ExecuteDataSet("select -1,'-----Select------' from dual union all select t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=1 order by 2").Tables(0)
        Me.cmb_purpose.DataSource = dt3
        Me.cmb_purpose.DataValueField = dt3.Columns(0).ColumnName
        Me.cmb_purpose.DataTextField = dt3.Columns(1).ColumnName
        Me.cmb_purpose.DataBind()
        dt4 = oh.ExecuteDataSet("select -1,'-----Select------' from dual union all select t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=2 order by 2").Tables(0)
        Me.cmb_mode.DataSource = dt4
        Me.cmb_mode.DataValueField = dt4.Columns(0).ColumnName
        Me.cmb_mode.DataTextField = dt4.Columns(1).ColumnName
        Me.cmb_mode.DataBind()
        dt5 = oh.ExecuteDataSet("select -1,'-----Select------' from dual union all select t.status_id,t.description from status_master t where t.module_id=118 and t.option_id=3 order by 1").Tables(0)
        Me.cmb_type.DataSource = dt5
        Me.cmb_type.DataValueField = dt5.Columns(0).ColumnName
        Me.cmb_type.DataTextField = dt5.Columns(1).ColumnName
        Me.cmb_type.DataBind()
    End Sub

    Protected Sub btn_apply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_apply.Click

        'TABLE=hrm_ta_request
        '100111*KRISHNADAS.P*01/Feb/2016*02/Feb/2016*Valapad, Kerala, India*Eravu, Kerala, India*15.3*3**1*0*2*BY BUS*30.6
        '100111*KRISHNADAS.P*01/Feb/2016*02/Feb/2016*Valapad, Kerala, India*Eravu, Kerala, India*15.3*3**1*0*2*BY BUS*30.6


        Dim str, data() As String
        str = Me.hid_real.Value
        data = Me.hid_real.Value.Split("!")
        Dim frm As Integer = Session("firm_id")
        branchid = Session("branch_id")
        Try
            Dim op(4) As OracleParameter
            op(0) = New OracleParameter("details", OracleType.VarChar, 10000)
            If str = String.Empty Or str = "" Then
                str = " "
            End If
            op(0).Value = str
            op(1) = New OracleParameter("status", OracleType.Number)
            op(1).Value = 0
            op(2) = New OracleParameter("user_by", OracleType.VarChar, 50)
            op(2).Value = Session("user_id")
            op(3) = New OracleParameter("Errmsg", OracleType.VarChar, 100)
            op(3).Direction = ParameterDirection.Output
            op(4) = New OracleParameter("Errflag", OracleType.Number, 1)
            op(4).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("hrm_ta_request_apply", op)
            If op(4).Value = 1 Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" + op(3).Value + "');")
                cl_script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('" + op(3).Value + "');")
                cl_script1.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If

        Catch ex As Exception
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Error Occured..');")
            cl_script1.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End Try
    End Sub

    Protected Sub btn_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Response.Redirect("../home.aspx")
    End Sub
End Class
