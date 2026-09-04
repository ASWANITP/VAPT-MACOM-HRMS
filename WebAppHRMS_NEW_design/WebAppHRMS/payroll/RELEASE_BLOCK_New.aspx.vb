Imports System.Data
Imports System.Data.OracleClient
Partial Class RELEASE_BLOCK_New_cb83f1319890
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim str, str1, res, str2, str3 As String
    Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable
    Dim oh As New helper.oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "Punch Block Releasing Form..!!'"

        Dim cs As String = "var cont_name;cont_name='" & Me.lst_emp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)

        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server(arg,context) { " & cbref & "; } "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)

        If Not IsPostBack Then
            Dim sf = Session("user_id").ToString.Split("!")
            dt = oh.ExecuteDataSet("select count(*) from form_accessibility where emp_id=" & sf(0) & " and form_id=106").Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Server.Transfer("../show_err.aspx")
            Else
                Me.Txt_dt.Text = Format(Date.Now, "dd/MMM/yyyy")
                dt = oh.ExecuteDataSet("select 0 as Block_Id,' -- Select Block Name -- ' as Block_Reason from dual union all select a.block_id as Block_Id,a.block_reason as Block_Reason from block_master_1 a order by Block_Reason").Tables(0)
                Me.cmb_block.DataSource = dt
                Me.cmb_block.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_block.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_block.DataBind()

                str2 = "select -1,' -- Select Employee -- ' as emp_name from dual union all select cm.emp_code,cm.emp_code||' : '||cm.emp_name as emp_name from employee_master cm,attend a where cm.status_id = 1 and a.emp_code = cm.emp_code and a.curr_date = to_date('" & Me.Txt_dt.Text & "') and a.block like '%,'||" & Me.cmb_block.SelectedValue & "||',%' order by emp_name"
                dt6 = oh.ExecuteDataSet(str2).Tables(0)
                Me.cmb_emp.DataSource = dt6
                Me.cmb_emp.DataTextField = dt6.Columns(1).ColumnName
                Me.cmb_emp.DataValueField = dt6.Columns(0).ColumnName
                Me.cmb_emp.DataBind()
                Me.Hidden2.Value = ""
                ' Me.cmd_insert.Attributes.Add("onclick", "listadd()")
                Me.cmb_block.Attributes.Add("onchange", "fill()")
            End If
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim in_data = eventArgument.Split("@")
        Dim st As New StringBuilder
        Dim dr As DataRow
        Try
            'dt1 = oh.ExecuteDataSet("select -1||'*'||' -Select Employee- ' as emp_name from dual union all select cm.emp_code||'*'||cm.emp_code||'-'||cm.emp_name||'- ('||get_emp_block(a.block)||')' as dtl from employee_master cm,attend a where cm.status_id=1  and a.emp_code=cm.emp_code and to_date(a.curr_date)=to_date('" & in_data(2) & "') and cm.shift_id not in (4,5) and a.gun_status=" & in_data(1) & " order by emp_name").Tables(0)
            str3 = "select -1||'*'||' -Select Employee- ' as emp_name from dual union all select cm.emp_code||'*'||cm.emp_code||'-'||cm.emp_name as emp_name from employee_master cm,attend a where cm.status_id = 1 and a.emp_code = cm.emp_code and a.curr_date = to_date('" & in_data(2) & "') and a.block like '%,'||" & in_data(1) & "||',%' order by emp_name"
            dt1 = oh.ExecuteDataSet(str3).Tables(0)
            If dt1.Rows.Count > 0 Then
                For Each dr In dt1.Rows
                    st.Append(dr(0))
                    st.Append("!")
                Next
            End If
            st.Append("^")
            st.Append("2")
        Catch ex As Exception
        End Try
        res = st.ToString
    End Sub
    Protected Sub Cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_confirm.Click
        Dim usr = Me.Session("user_id").ToString.Split("!")
        Dim param(4) As OracleParameter

        param(0) = New OracleParameter("BlockDate", OracleType.DateTime)
        param(0).Direction = ParameterDirection.Input
        param(0).Value = CDate(Me.Txt_dt.Text)
        param(1) = New OracleParameter("Emps", OracleType.VarChar, 5000)
        param(1).Direction = ParameterDirection.Input
        param(1).Value = Me.Hidden2.Value
        param(2) = New OracleParameter("RlsedBy", OracleType.Number, 7)
        param(2).Direction = ParameterDirection.Input
        param(2).Value = usr(0)
        param(3) = New OracleParameter("blk", OracleType.Number)
        param(3).Direction = ParameterDirection.Input
        param(3).Value = Me.cmb_block.SelectedValue
        param(4) = New OracleParameter("err_msg", OracleType.VarChar, 5000)
        param(4).Direction = ParameterDirection.Output

        oh.ExecuteNonQuery("hrm_block_release_temp", param)

        Dim cl_script0 As New System.Text.StringBuilder
        cl_script0.Append("         alert(' " & param(4).Value & " ');")
        cl_script0.Append("       window.open('RELEASE_BLOCK_New.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        'Server.Transfer("RELEASE_BLOCK.aspx")
    End Sub
    ' Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    ' Server.Transfer("block_punch_select.aspx")
    ' End Sub
End Class
