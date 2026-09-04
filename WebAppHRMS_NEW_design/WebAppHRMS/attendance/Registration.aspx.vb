Imports System.Data
Imports System.Data.OracleClient

Partial Class Registration_137483614248
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("branch_id") <> 0 Then
            Server.Transfer("../show_err.aspx")
        End If
        Dim oh As New Helper.Oracle.OracleHelper
        Dim dt As New DataTable
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select shift_id,shift from time_tab").Tables(0)
            Me.cmb_shift.DataSource = dt
            Me.cmb_shift.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_shift.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_shift.DataBind()
            If Not IsPostBack Then
                Me.txt_joindt.Text = Format(Date.Today, "dd/MMM/yyyy")
            End If

            Dim dt1 As New DataTable
            dt1 = oh.ExecuteDataSet("select branch_id,branch_name from branch_master order by branch_name").Tables(0)
            Me.cmb_branch.DataSource = dt1
            Me.cmb_branch.DataTextField = dt1.Columns(1).ColumnName
            Me.cmb_branch.DataValueField = dt1.Columns(0).ColumnName
            Me.cmb_branch.DataBind()


            Dim dt2 As New DataTable
            dt2 = oh.ExecuteDataSet("select designation,designation_id from designation_mst order by designation").Tables(0)
            Me.cmb_desg.DataSource = dt2
            Me.cmb_desg.DataTextField = dt2.Columns(0).ColumnName
            Me.cmb_desg.DataValueField = dt2.Columns(1).ColumnName
            Me.cmb_desg.DataBind()

            Dim dt3 As New DataTable
            dt3 = oh.ExecuteDataSet("select dep_id,dep_name from department_mst order by dep_name").Tables(0)
            Me.cmb_dept.DataSource = dt3
            Me.cmb_dept.DataTextField = dt3.Columns(1).ColumnName
            Me.cmb_dept.DataValueField = dt3.Columns(0).ColumnName
            Me.cmb_dept.DataBind()

            Dim dt4 As New DataTable
            dt4 = oh.ExecuteDataSet("select firm_id,firm_abbr from firm_master").Tables(0)
            Me.cmb_firm.DataSource = dt4
            Me.cmb_firm.DataTextField = dt4.Columns(1).ColumnName
            Me.cmb_firm.DataValueField = dt4.Columns(0).ColumnName
            Me.cmb_firm.DataBind()
        End If


    End Sub

    Protected Sub btn_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        Dim ob As New Helper.Oracle.OracleHelper
        Dim op(8) As OracleParameter

        op(0) = New OracleParameter("empcode", OracleType.Number, 5)
        op(0).Value = CInt(Me.txt_id.Text)
        op(0).Direction = ParameterDirection.Input

        op(1) = New OracleParameter("emp_name", OracleType.VarChar, 40)
        op(1).Value = Me.txt_name.Text
        op(1).Direction = ParameterDirection.Input

        op(2) = New OracleParameter("designation_id", OracleType.Number, 3)
        op(2).Value = Me.cmb_desg.SelectedValue
        op(2).Direction = ParameterDirection.Input

        op(3) = New OracleParameter("department_id", OracleType.Number, 3)
        op(3).Value = Me.cmb_dept.SelectedValue
        op(3).Direction = ParameterDirection.Input


        op(4) = New OracleParameter("branch_id", OracleType.Number, 4)
        op(4).Value = Me.cmb_branch.SelectedValue
        op(4).Direction = ParameterDirection.Input

        op(5) = New OracleParameter("dt_join", OracleType.DateTime, 8)
        op(5).Value = Me.txt_joindt.Text
        op(5).Direction = ParameterDirection.Input

        op(6) = New OracleParameter("firm_id", OracleType.Number, 3)
        op(6).Value = Me.cmb_firm.SelectedValue
        op(6).Direction = ParameterDirection.Input

        op(7) = New OracleParameter("shift_id", OracleType.Number, 2)
        op(7).Value = Me.cmb_shift.SelectedValue
        op(7).Direction = ParameterDirection.Input

        op(8) = New OracleParameter("error", OracleType.Number, 2)
        op(8).Direction = ParameterDirection.Output
        ob.ExecuteNonQuery("add_registration", op)
        Dim st As Integer = op(8).Value

        If st = 1 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Updated');")
            cl_script0.Append("window.open('../home.aspx','_self')")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
        Else
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You have already added the Employee.');")
            cl_script0.Append("         alert('For Any Changes Take EDIT EMPLOYEE.');")
            cl_script0.Append("window.open('../home.aspx','_self')")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)


        End If

        

    End Sub

    Protected Sub cmb_desg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_desg.SelectedIndexChanged

    End Sub

    Protected Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Server.Transfer("../home.aspx")
    End Sub
End Class
