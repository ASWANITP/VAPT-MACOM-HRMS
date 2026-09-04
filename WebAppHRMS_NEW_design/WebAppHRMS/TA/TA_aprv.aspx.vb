Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Data.OleDb
Imports System.Web.Services
Imports System.Web
Imports System.Text
Imports System.Configuration
Partial Class TA_TA_aprv_7af713d18717
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim dt1, dt2, dm As New DataTable
    Dim str_tkn As New System.Text.StringBuilder
    Dim ds As DataSet
    Dim data As DataView
    Dim s As String
    Dim res As String
    Dim usr As String
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
           usr = Me.Session("user_id").ToString.Split("!")(0)
        dt2 = oh.ExecuteDataSet("select count(t.emp_code) from employee_master t where t.access_id = 33 And t.emp_code = " + usr + "").Tables(0)
        If (dt2.Rows(0)(0) > 0) Then
            Dim sc As String = "var obj_name;obj_name='" & Me.drp_empl.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
            Me.Div3.Visible = False
            Dim script_val As String
            script_val = "var empcode;" & "empcode='" & "" & Me.drp_empl.ClientID & "'" & " ; "
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
            If Not IsPostBack Then
                Me.dropdown_fill()
            End If
        Else
            Dim str_tkn As New System.Text.StringBuilder
            str_tkn.Append("         alert('You are not allowed to approve ta');")
            str_tkn.Append(" window.open('../Home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        End If
              End Sub
    Protected Sub drp_empl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drp_empl.SelectedIndexChanged
        Me.Grid_view1.Visible = True
        Dim a As String
        a = Me.drp_empl.SelectedItem.Value.ToString()
        dm = oh.ExecuteDataSet("select t.ta_id,t.ta_date,t.district,t.frm_plc,t.to_plc,t.firm,t.km,t.rate,t.fare,t.bata,t.rec_amnt,t.remark from ta_macom_ins t where t.emp_code=" + a + " and t.status = 4").Tables(0)
        Dim dataView As DataView = New DataView(dm)
        Grid_view1.DataSource = dataView
        Grid_view1.DataBind()
        Me.buttons.Visible = True
           End Sub
    Protected Sub dropdown_fill()
        dt1 = oh.ExecuteDataSet("select '-1' as ccode,'----SELECT EMPLOYEE----' as ctxt from(dual) union all select distinct t.emp_code,t.emp_code from ta_macom_ins t where t.status = 4").Tables(0)
        drp_empl.DataSource = dt1
        drp_empl.DataTextField = dt1.Columns(1).ColumnName
        drp_empl.DataValueField = dt1.Columns(0).ColumnName
        drp_empl.DataBind()
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Dim msg As String
        msg = ""
        Return msg
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str As String
        str = cal_data
        Dim p(3) As OracleParameter
        p(0) = New OracleParameter("type_id", OracleType.VarChar, 1000)
        p(0).Value = "7"
        p(1) = New OracleParameter("cal_data", OracleType.VarChar, 1000)
        p(1).Value = str
        p(2) = New OracleParameter("err_stat", OracleType.Number, 2)
        p(2).Direction = ParameterDirection.Output
        p(3) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
        p(3).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("ta_request_ins", p)       
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Me.Div3.Visible = True
        Dim a As String
        a = Me.drp_empl.SelectedItem.Value.ToString()
        Dim rowIndex As String = Convert.ToString(e.CommandArgument)
        Dim id As String = Convert.ToString(Grid_view1.DataKeys(rowIndex).Values(0))
        dt1 = oh.ExecuteDataSet("select ta_id,ta_date,district,frm_plc,to_plc,firm,km,rate,fare,bata,rec_amnt from ta_macom_ins where ta_id = '" + id + "' and emp_code = " + a + "").Tables(0)
        Me.txt_slno.Text = dt1.Rows(0)(0).ToString
        Me.txt_date.Text = dt1.Rows(0)(1).ToString
        Me.txt_nmdis.Text = dt1.Rows(0)(2).ToString
        Me.txt_frmpl.Text = dt1.Rows(0)(3).ToString
        Me.txt_topl.Text = dt1.Rows(0)(4).ToString
        Me.txt_firm.Text = dt1.Rows(0)(5).ToString
        Me.txt_km.Text = dt1.Rows(0)(6).ToString
        Me.txt_rate.Text = dt1.Rows(0)(7).ToString
        Me.txt_fare.Text = dt1.Rows(0)(8).ToString
        Me.txt_bata.Text = dt1.Rows(0)(9).ToString
        Me.txt_totta.Text = dt1.Rows(0)(10).ToString
    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Me.Div3.Visible = True
        Dim a As String
        a = Me.drp_empl.SelectedItem.Value.ToString()
        Dim rowIndex As String = Convert.ToString(e.CommandArgument)
        Dim id As String = Convert.ToString(Grid_view1.DataKeys(rowIndex).Values(0))
        dt1 = oh.ExecuteDataSet("select ta_id,ta_date,district,frm_plc,to_plc,firm,km,rate,fare,bata,total_ta from ta_macom_ins where ta_id = '" + id + "' and emp_code = " + a + "").Tables(0)
        Me.txt_slno.Text = dt1.Rows(0)(0).ToString
        Me.txt_date.Text = dt1.Rows(0)(1).ToString
        Me.txt_nmdis.Text = dt1.Rows(0)(2).ToString
        Me.txt_frmpl.Text = dt1.Rows(0)(3).ToString
        Me.txt_topl.Text = dt1.Rows(0)(4).ToString
        Me.txt_firm.Text = dt1.Rows(0)(5).ToString
        Me.txt_km.Text = dt1.Rows(0)(6).ToString
        Me.txt_rate.Text = dt1.Rows(0)(7).ToString
        Me.txt_fare.Text = dt1.Rows(0)(8).ToString
        Me.txt_bata.Text = dt1.Rows(0)(9).ToString
        Me.txt_totta.Text = dt1.Rows(0)(10).ToString
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim p(3) As OracleParameter
        If (Grid_view1.Rows.Count > 0) Then
            For Each gvr As GridViewRow In Grid_view1.Rows
                Dim upd As String
                upd = Me.drp_empl.SelectedItem.Value.ToString() + "~" + gvr.Cells(0).Text + "~" + gvr.Cells(10).Text
                p(0) = New OracleParameter("type_id", OracleType.VarChar, 1000)
                p(0).Value = "3"
                p(1) = New OracleParameter("cal_data", OracleType.VarChar, 1000)
                p(1).Value = upd
                p(2) = New OracleParameter("err_stat", OracleType.Number, 2)
                p(2).Direction = ParameterDirection.Output
                p(3) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
                p(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("ta_request_ins", p)
            Next
            Dim str_tkn As New System.Text.StringBuilder
            str_tkn.Append("         alert('" & p(3).Value & "');")
            str_tkn.Append(" window.open('TA_aprv.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        Else
            For Each gvr As GridViewRow In GridView2.Rows
                Dim upd As String
                upd = Me.drp_empl.SelectedItem.Value.ToString() + "~" + gvr.Cells(0).Text + "~" + gvr.Cells(10).Text
                p(0) = New OracleParameter("type_id", OracleType.VarChar, 1000)
                p(0).Value = "3"
                p(1) = New OracleParameter("cal_data", OracleType.VarChar, 1000)
                p(1).Value = upd
                p(2) = New OracleParameter("err_stat", OracleType.Number, 2)
                p(2).Direction = ParameterDirection.Output
                p(3) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
                p(3).Direction = ParameterDirection.Output
                oh.ExecuteNonQuery("ta_request_ins", p)
            Next
            Dim str_tkn As New System.Text.StringBuilder
            str_tkn.Append("         alert('" & p(3).Value & "');")
            str_tkn.Append(" window.open('TA_aprv.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)
        End If
    End Sub
    Protected Sub bt1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt1.ServerClick
        Me.Grid_view1.Visible = False
        dm = Nothing
        Grid_view1.DataSource = dm
        Grid_view1.DataBind()
        Dim dter As DataTable = oh.ExecuteDataSet("select t.ta_id,t.ta_date,t.district,t.frm_plc,t.to_plc,t.firm,t.km,t.rate,t.fare,t.bata,t.total_ta,t.remark from ta_macom_ins t where t.emp_code=" + Me.drp_empl.SelectedItem.Value.ToString() + " and t.status = 4 ").Tables(0)
        GridView2.DataSource = dter
        GridView2.DataBind()
    End Sub
    Protected Sub btn_ext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ext.Click
        Response.Redirect("~/Home.aspx", True)
    End Sub
    Protected Sub btn_cnfrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cnfrm.Click
        Dim p(3) As OracleParameter
        For Each gvr As GridViewRow In Grid_view1.Rows
            Dim upd As String
            upd = Me.drp_empl.SelectedItem.Value.ToString() + "~" + gvr.Cells(0).Text
            p(0) = New OracleParameter("type_id", OracleType.VarChar, 1000)
            p(0).Value = "4"
            p(1) = New OracleParameter("cal_data", OracleType.VarChar, 1000)
            p(1).Value = upd
            p(2) = New OracleParameter("err_stat", OracleType.Number, 2)
            p(2).Direction = ParameterDirection.Output
            p(3) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
            p(3).Direction = ParameterDirection.Output
            oh.ExecuteNonQuery("ta_request_ins", p)
            'str_tkn.Append("         alert('" & p(3).Value & "');")
        Next
        Dim str_tkn As New System.Text.StringBuilder
        str_tkn.Append("         alert('" & p(3).Value & "');")
        str_tkn.Append(" window.open('TA_aprv.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)

        dt1 = oh.ExecuteDataSet("select '-1' as ccode,'----SELECT EMPLOYEE----' as ctxt from(dual) union all select distinct t.emp_code,t.emp_code from ta_macom_ins t where t.status = 0").Tables(0)
        drp_empl.DataSource = dt1
        drp_empl.DataTextField = dt1.Columns(1).ColumnName
        drp_empl.DataValueField = dt1.Columns(0).ColumnName
        drp_empl.DataBind()
        Me.Grid_view1.Visible = False
        Me.buttons.Visible = False
    End Sub
End Class
