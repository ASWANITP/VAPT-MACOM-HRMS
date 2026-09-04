
Imports System.Data
Imports System.Data.OracleClient

Partial Class macom_shift_change_School_Holiday_4dda2a571831
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str, str1, str2, branch As String
    Dim dt, dt1, dt2 As New DataTable
    Dim i, n, d As Integer
    Dim dr1 As DataRow
    Dim sf() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "DECLARE A STATE HOLIDAY"
        Dim cs As String = "var cont_name;cont_name='" & Me.txt_dt.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Me.btn_submit.Attributes.Add("onclick", "return  btn_onclick()")
        Me.txt_dt.Attributes.Add("onkeyup", "return  date_enter()")
        'If (Not IsPostBack) Then
        '    If Me.Session("access_id") = 33 Then
        '        state_fill()
        '    Else
        '        Me.Server.Transfer("show_err.aspx")
        '    End If
        'End If

        state_fill()
        sf = Session("user_id").ToString.Split("!")
        branch = Me.Session("branch_id").ToString()
    End Sub
    Private Function getfirmId() As Int32
        Return Convert.ToInt32(Me.Session("firm_id"))

    End Function
    Sub state_fill()
        str = "select distinct (a.state_id) as id ,b.state_name as name from branch_master a ,state_master b where a.state_id=b.state_id and a.firm_id=" + getfirmId().ToString() + " order by name"
        dt = oh.ExecuteDataSet(str).Tables(0)
        Me.DDL_state.DataSource = dt
        Me.DDL_state.DataValueField = dt.Columns(0).ColumnName
        Me.DDL_state.DataTextField = dt.Columns(1).ColumnName
        Me.DDL_state.DataBind()
        past_holidays()
    End Sub
    Sub past_holidays()
        ListBox_date.Items.Clear()
        dt1 = oh.ExecuteDataSet("select distinct hol_day as Holidays from school_holiday where state_id=" & Me.DDL_state.SelectedValue & " order by hol_day").Tables(0)
        Me.ListBox_date.Style.Add("height", "" & dt1.Rows.Count * 19 & "px")
        If (dt1.Rows.Count > 0) Then
            For Each dr1 In dt1.Rows
                ListBox_date.Items.Add(Format(CDate(dr1(0).ToString), "dd-MMM-yyyy"))
            Next
        End If
    End Sub
    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        Try
            Dim parm_coll1(4) As OracleParameter
            parm_coll1(0) = New OracleParameter("s_id", OracleType.VarChar, 10)
            parm_coll1(0).Value = Me.DDL_state.SelectedValue
            parm_coll1(0).Direction = ParameterDirection.Input
            parm_coll1(1) = New OracleParameter("dt", OracleType.DateTime)
            parm_coll1(1).Value = CDate(Me.txt_dt.Text)
            parm_coll1(1).Direction = ParameterDirection.Input
            parm_coll1(2) = New OracleParameter("ErrorMsg", OracleType.Number)
            parm_coll1(2).Direction = ParameterDirection.Output
            parm_coll1(3) = New OracleParameter("firmid", OracleType.Number)
            parm_coll1(3).Value = CInt(Me.Session("firm_id"))
            parm_coll1(3).Direction = ParameterDirection.Input
            parm_coll1(4) = New OracleParameter("branch", OracleType.Number)
            parm_coll1(4).Value = Me.Session("branch_id")
            parm_coll1(4).Direction = ParameterDirection.Input
            oh.ExecuteNonQuery("HRM_ADD_COMMON_HOLIDAY_SCHOOL", parm_coll1)
            Dim cl_script0 As New System.Text.StringBuilder
            If (parm_coll1(2).Value = 0) Then
                cl_script0.Append("         alert(' Error. Try again !');")
            Else
                cl_script0.Append("         alert(' Holiday Updated');")
                cl_script0.Append("         window.open('School_Holiday.aspx','_self');")
            End If
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub DDL_state_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDL_state.SelectedIndexChanged
        past_holidays()
    End Sub
End Class

