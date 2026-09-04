Imports System.Data
Imports system.data.oracleclient
Partial Class employ_expqual_9411ca966601
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim sql As String

    Sub designation_fill()
        Dim sql As String
        sql = "select a.designation,a.designation_id from designation_master a order by a.designation"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_des.DataSource = dt
            Me.cmb_des.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_des.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_des.DataBind()
        End If
    End Sub

    Sub qual_fill()
        Dim sql As String
        sql = "select category,category_id from qualification_category order by category"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_qual.DataSource = dt
            Me.cmb_qual.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_qual.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_qual.DataBind()
        End If
    End Sub
    Sub state_fill()
        Dim sql As String
        sql = "select state_name,state_id from state_master order by state_name"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_state.DataSource = dt
            Me.cmb_state.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_state.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_state.DataBind()
        End If
    End Sub
    Sub dis_fill()
        Dim sql As String
        sql = "select district_name,district_id from district_master order by district_name"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_dis.DataSource = dt
            Me.cmb_dis.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_dis.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_dis.DataBind()
        End If
    End Sub
    Sub dist_fill()
        Dim sql As String
        sql = "select a.district_name,a.district_id from district_master a where a.state_id=" & Me.cmb_state.SelectedValue & " order by a.district_name"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.cmb_dis.DataSource = dt
            Me.cmb_dis.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_dis.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_dis.DataBind()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script_val2 As String
        script_val2 = "var sal;" & "sal='" & "" & Me.txt_exp.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val2, True)
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_qual.Checked = False And Me.chk_exp.Checked = False And Me.chk_des.Checked = False) Then

            Me.cmb_qual.Visible = False
            Me.cmb_des.Visible = False
            Me.cmb_dis.Visible = False
            Me.cmb_state.Visible = False
            Me.txt_exp.Visible = False
        End If
        

    End Sub




    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim sa, di, ex, qu, des As Integer
        '1
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = True And Me.chk_exp.Checked = True And Me.chk_qual.Checked = True And Me.chk_des.Checked = True) Then
            sa = 1
            di = 1
            ex = 1
            qu = 1
            des = 1



        End If
        '2
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = True And Me.chk_exp.Checked = True And Me.chk_qual.Checked = True And Me.chk_des.Checked = False) Then
            sa = 1
            di = 1
            ex = 1
            qu = 1
            des = 0
        End If
        '3
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = True And Me.chk_exp.Checked = True And Me.chk_qual.Checked = False And Me.chk_des.Checked = True) Then
            sa = 1
            di = 1
            ex = 1
            qu = 0
            des = 1
        End If
        '4
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = True And Me.chk_exp.Checked = True And Me.chk_qual.Checked = False And Me.chk_des.Checked = False) Then
            sa = 1
            di = 1
            ex = 1
            qu = 0
            des = 0
        End If
        '5
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = True And Me.chk_exp.Checked = False And Me.chk_qual.Checked = True And Me.chk_des.Checked = True) Then
            sa = 1
            di = 1
            ex = 0
            qu = 1
            des = 1
        End If
        '6
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = True And Me.chk_exp.Checked = False And Me.chk_qual.Checked = True And Me.chk_des.Checked = False) Then
            sa = 1
            di = 1
            ex = 0
            qu = 1
            des = 0
        End If
        '7
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = True And Me.chk_exp.Checked = False And Me.chk_qual.Checked = False And Me.chk_des.Checked = True) Then
            sa = 1
            di = 1
            ex = 0
            qu = 0
            des = 1
        End If
        '8
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = True And Me.chk_exp.Checked = False And Me.chk_qual.Checked = False And Me.chk_des.Checked = False) Then
            sa = 1
            di = 1
            ex = 0
            qu = 0
            des = 0
        End If
        '9
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = False And Me.chk_exp.Checked = True And Me.chk_qual.Checked = True And Me.chk_des.Checked = True) Then
            sa = 1
            di = 0
            ex = 1
            qu = 1
            des = 1
        End If
        '10
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = False And Me.chk_exp.Checked = True And Me.chk_qual.Checked = True And Me.chk_des.Checked = False) Then
            sa = 1
            di = 0
            ex = 1
            qu = 1
            des = 0
        End If
        '11
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = False And Me.chk_exp.Checked = True And Me.chk_qual.Checked = False And Me.chk_des.Checked = True) Then
            sa = 1
            di = 0
            ex = 1
            qu = 0
            des = 1
        End If
        '12
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = False And Me.chk_exp.Checked = True And Me.chk_qual.Checked = False And Me.chk_des.Checked = False) Then
            sa = 1
            di = 0
            ex = 1
            qu = 0
            des = 0
        End If
        '13
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = False And Me.chk_exp.Checked = False And Me.chk_qual.Checked = True And Me.chk_des.Checked = True) Then
            sa = 1
            di = 0
            ex = 0
            qu = 1
            des = 1
        End If
        '14
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = False And Me.chk_exp.Checked = False And Me.chk_qual.Checked = True And Me.chk_des.Checked = False) Then
            sa = 1
            di = 0
            ex = 0
            qu = 1
            des = 0
        End If
        '15
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = False And Me.chk_exp.Checked = False And Me.chk_qual.Checked = False And Me.chk_des.Checked = True) Then
            sa = 1
            di = 0
            ex = 0
            qu = 0
            des = 1
        End If
        '16
        If (Me.chk_state.Checked = True And Me.chk_dis.Checked = False And Me.chk_exp.Checked = False And Me.chk_qual.Checked = False And Me.chk_des.Checked = False) Then
            sa = 1
            di = 0
            ex = 0
            qu = 0
            des = 0
        End If
        '17
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = True And Me.chk_exp.Checked = True And Me.chk_qual.Checked = True And Me.chk_des.Checked = True) Then
            sa = 0
            di = 1
            ex = 1
            qu = 1
            des = 1
        End If
        '18
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = True And Me.chk_exp.Checked = True And Me.chk_qual.Checked = True And Me.chk_des.Checked = False) Then
            sa = 0
            di = 1
            ex = 1
            qu = 1
            des = 0
        End If
        '19
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = True And Me.chk_exp.Checked = True And Me.chk_qual.Checked = False And Me.chk_des.Checked = True) Then
            sa = 0
            di = 1
            ex = 1
            qu = 0
            des = 1
        End If
        '20
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = True And Me.chk_exp.Checked = True And Me.chk_qual.Checked = False And Me.chk_des.Checked = False) Then
            sa = 0
            di = 1
            ex = 1
            qu = 0
            des = 0
        End If
        '21
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = True And Me.chk_exp.Checked = False And Me.chk_qual.Checked = True And Me.chk_des.Checked = True) Then
            sa = 0
            di = 1
            ex = 0
            qu = 1
            des = 1
        End If
        '22
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = True And Me.chk_exp.Checked = False And Me.chk_qual.Checked = True And Me.chk_des.Checked = False) Then
            sa = 0
            di = 1
            ex = 0
            qu = 1
            des = 0
        End If
        '23
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = True And Me.chk_exp.Checked = False And Me.chk_qual.Checked = False And Me.chk_des.Checked = True) Then
            sa = 0
            di = 1
            ex = 0
            qu = 0
            des = 1
        End If
        '24
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = True And Me.chk_exp.Checked = False And Me.chk_qual.Checked = False And Me.chk_des.Checked = False) Then
            sa = 0
            di = 1
            ex = 0
            qu = 0
            des = 0
        End If
        '25
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_exp.Checked = True And Me.chk_qual.Checked = True And Me.chk_des.Checked = True) Then
            sa = 0
            di = 0
            ex = 1
            qu = 1
            des = 1
        End If
        '26
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_exp.Checked = True And Me.chk_qual.Checked = True And Me.chk_des.Checked = False) Then
            sa = 0
            di = 0
            ex = 1
            qu = 1
            des = 0
        End If
        '27
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_exp.Checked = True And Me.chk_qual.Checked = False And Me.chk_des.Checked = True) Then
            sa = 0
            di = 0
            ex = 1
            qu = 0
            des = 1
        End If
        '28
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_exp.Checked = True And Me.chk_qual.Checked = False And Me.chk_des.Checked = False) Then
            sa = 0
            di = 0
            ex = 1
            qu = 0
            des = 0
        End If
        '29
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_exp.Checked = False And Me.chk_qual.Checked = True And Me.chk_des.Checked = True) Then
            sa = 0
            di = 0
            ex = 0
            qu = 1
            des = 1
        End If
        '30
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_exp.Checked = False And Me.chk_qual.Checked = True And Me.chk_des.Checked = False) Then
            sa = 0
            di = 0
            ex = 0
            qu = 1
            des = 0
        End If
        '31
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_exp.Checked = False And Me.chk_qual.Checked = False And Me.chk_des.Checked = True) Then
            sa = 0
            di = 0
            ex = 0
            qu = 0
            des = 1
        End If
        '32
        If (Me.chk_state.Checked = False And Me.chk_dis.Checked = False And Me.chk_exp.Checked = False And Me.chk_qual.Checked = False And Me.chk_des.Checked = False) Then
            sa = 0
            di = 0
            ex = 0
            qu = 0
            des = 0
        End If





        Me.Server.Transfer("employ_expqual_report_display.aspx?s=" & sa & "&d=" & di & "&e=" & ex & "&q=" & qu & "&ds=" & des & "&sta=" & Me.cmb_state.SelectedValue & "&dis=" & Me.cmb_dis.SelectedValue & "&exp=" & Me.txt_exp.Text & "&qual=" & Me.cmb_qual.SelectedValue & "&des=" & Me.cmb_des.SelectedValue)
    End Sub

    Protected Sub chk_all_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_all.CheckedChanged
        If (Me.chk_all.Checked = True) Then
            Me.chk_dis.Checked = True
            Me.chk_state.Checked = True
            Me.chk_des.Checked = True
            Me.chk_qual.Checked = True
            Me.chk_exp.Checked = True
            Me.cmb_dis.Visible = True
            Me.cmb_des.Visible = True
            Me.cmb_qual.Visible = True
            Me.txt_exp.Visible = True
            Me.cmb_state.Visible = True

            state_fill()
            designation_fill()
            qual_fill()
            dist_fill()
        Else
            Me.chk_dis.Checked = False
            Me.chk_state.Checked = False
            Me.chk_des.Checked = False
            Me.chk_qual.Checked = False
            Me.chk_exp.Checked = False
            Me.txt_exp.Visible = False
            Me.cmb_dis.Visible = False
            Me.cmb_des.Visible = False
            Me.cmb_qual.Visible = False
            Me.cmb_state.Visible = False
        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Server.Transfer("../home.aspx")
    End Sub

    Protected Sub chk_des_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_des.CheckedChanged
        If (Me.chk_des.Checked = True) Then
            Me.cmb_des.Visible = True
            designation_fill()
        Else
            Me.cmb_des.Visible = False
            Me.chk_all.Checked = False
        End If
    End Sub

    Protected Sub chk_dis_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_dis.CheckedChanged
        If (Me.chk_dis.Checked = True) Then
            Me.cmb_dis.Visible = True
            dis_fill()
        Else
            Me.cmb_dis.Visible = False
            Me.chk_all.Checked = False
        End If
    End Sub

    Protected Sub chk_exp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_exp.CheckedChanged
        If (Me.chk_exp.Checked = True) Then
            Me.txt_exp.Visible = True
        Else
            Me.txt_exp.Visible = False
            Me.chk_all.Checked = False
        End If
    End Sub

    Protected Sub chk_qual_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_qual.CheckedChanged
        If (Me.chk_qual.Checked = True) Then
            Me.cmb_qual.Visible = True
            qual_fill()
        Else
            Me.cmb_qual.Visible = False
            Me.chk_all.Checked = False
        End If
    End Sub

    Protected Sub chk_state_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_state.CheckedChanged
        If (Me.chk_state.Checked = True) Then
            Me.cmb_state.Visible = True
            state_fill()
            If (Me.chk_dis.Checked = True) Then
                dist_fill()
            End If
        Else
            Me.cmb_state.Visible = False
            Me.chk_all.Checked = False
            dis_fill()
        End If
    End Sub

    Protected Sub cmb_state_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_state.SelectedIndexChanged
        If (Me.chk_state.Checked = True) Then
            Dim sql As String
            sql = "select a.district_name,a.district_id from district_master a where a.state_id=" & Me.cmb_state.SelectedValue & " order by a.district_name"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Me.cmb_dis.DataSource = dt
                Me.cmb_dis.DataTextField = dt.Columns(0).ColumnName
                Me.cmb_dis.DataValueField = dt.Columns(1).ColumnName
                Me.cmb_dis.DataBind()
            End If
        End If

    End Sub
End Class
