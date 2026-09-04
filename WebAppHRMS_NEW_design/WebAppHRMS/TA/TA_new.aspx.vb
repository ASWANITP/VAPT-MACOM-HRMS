Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports System.Data.OleDb
Imports System.Web.Services
Imports System.Web
Imports System.Text
Partial Class TA_TA_new_d8ccc1921082
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim TextB As New TextBox
    Dim str_tkn As New System.Text.StringBuilder
    Dim page5 As Page = CType(HttpContext.Current.Handler, Page)
    Dim ExcelPath, ExcelPaths, fn As String
    Dim dt1, dt2, dt3 As New DataTable
    Dim ds As DataSet
    Dim sum As Double
    Dim km As Integer
    Dim sql As String
    Dim rate As Integer
    Dim fare As Integer
    Dim fr As Integer
    Dim bt As Integer
    Dim res As String
    Dim tota As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sc As String = "var obj_name;obj_name='" & Me.txt_desig.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)

        Dim script_val As String
        script_val = "var empcode;" & "empcode='" & "" & Me.txt_empcode.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str As String
        str = cal_data
        Dim p(3) As OracleParameter
        p(0) = New OracleParameter("type_id", OracleType.VarChar, 1000)
        p(0).Value = "1"
        p(1) = New OracleParameter("cal_data", OracleType.VarChar, 1000)
        p(1).Value = str
        p(2) = New OracleParameter("err_stat", OracleType.Number, 2)
        p(2).Direction = ParameterDirection.Output
        p(3) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
        p(3).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("ta_request_ins", p)
        Dim st As New System.Text.StringBuilder
        st.Append(p(3).Value)
        res = st.ToString()
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Dim a As String
        a = Me.txt_empcode.Text
        Dim rowIndex As String = Convert.ToString(e.CommandArgument)
        Dim id As String = Convert.ToString(grid_view1.DataKeys(rowIndex).Values(0))
        Dim upd As String = a + "~" + id
        Dim p(3) As OracleParameter
        p(0) = New OracleParameter("type_id", OracleType.VarChar, 1000)
        p(0).Value = "8"
        p(1) = New OracleParameter("cal_data", OracleType.VarChar, 1000)
        p(1).Value = upd
        p(2) = New OracleParameter("err_stat", OracleType.Number, 2)
        p(2).Direction = ParameterDirection.Output
        p(3) = New OracleParameter("err_msg", OracleType.VarChar, 1000)
        p(3).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("ta_request_ins", p)
        Dim str_tkn As New System.Text.StringBuilder
        str_tkn.Append(" window.open('TA_new.aspx','_self');")
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As String
        a = Me.txt_empcode.Text
        dt1 = oh.ExecuteDataSet("select em.emp_name,        dep.dep_name,        d.designation,        dst.district_name native_place,        dst.district_name native_dist,        st.state_name native_st,        b.BRANCH_NAME station_brnch,        bs.state_name station_state,        db.district_name station_dst    from employee_master     em,        employee_master_dtl md,        employ_firm         f,        employ_personal_dtl pd,        designation_master  d,        post_master         po,        district_master     dst,        state_master        st,state_master bs,district_master db,        department_mst      dep,        post_mst            pst,        branch_detail b  where em.emp_code = f.emp_code and b.BRANCH_ID=em.branch_id and bs.state_id=b.state_id and db.district_id=b.district_id    and em.emp_code = pd.emp_code    and em.emp_code = md.emp_code    and em.designation_id = d.designation_id    and em.department_id = dep.dep_id    and pd.perm_pin = po.sr_number    and po.district_id = dst.district_id    and dst.state_id = st.state_id    and em.post_id = pst.post_id    and f.firm_id = 8    and em.emp_code = " + a + "").Tables(0)
        Me.txt_empname.Text = dt1.Rows(0)(0).ToString
        Me.txt_depnm.Text = dt1.Rows(0)(1).ToString
        Me.txt_desig.Text = dt1.Rows(0)(2).ToString
        Me.txt_ntvpl.Text = dt1.Rows(0)(3).ToString
        Me.txt_ntvdis.Text = dt1.Rows(0)(4).ToString
        Me.txt_ntvstat.Text = dt1.Rows(0)(5).ToString
        Me.txt_stsbr.Text = dt1.Rows(0)(6).ToString
        Me.txt_stsdis.Text = dt1.Rows(0)(7).ToString
        Me.txt_stsstat.Text = dt1.Rows(0)(8).ToString
        Dim s As String
        s = Me.txt_empcode.Text
        dt3 = oh.ExecuteDataSet("select t.ta_id,t.ta_date,t.district,t.frm_plc,t.to_plc,t.firm,t.km,t.rate,t.fare,t.bata,t.total_ta from ta_macom_ins t where t.emp_code=" + s + " and t.status= 0").Tables(0)
        If Me.dt3.Rows.Count = 0 Then
            Me.div4.Visible = False
        Else
            Dim dataView As DataView = New DataView(dt3)
            grid_view1.DataSource = dataView
            grid_view1.DataBind()
            Me.div4.Visible = True
        End If
    End Sub
End Class
