Imports System.Data
Imports System.Data.OracleClient
Partial Class new_view_punch_report_37f555f65187
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim ft, ft1, sta, sta1, br1, mydrop As New DataTable
    Dim dr As DataRow
    Dim str, str1, sql, sql1 As String
    Dim codes As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsPostBack Then
                If Session("access_id") <> 33 Then
                    'Server.Transfer("tasplitindi.aspx")
                    'Me.Server.Transfer("TAsplitindi.aspx")
                    Response.Redirect("TAsplitindi.aspx")

                End If
            End If
            Me.rt1.Visible = False
            Me.rt2.Visible = False
            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")
            '============
            ft = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=75 and t.firm_id=99").Tables(0)
            Dim st As String = ft.Rows(0)(0).ToString.Split("#")(1)
            mydrop = oh.ExecuteDataSet(st).Tables(0)
            Me.DropDownList2.DataSource = mydrop
            Me.DropDownList2.DataTextField = mydrop.Columns(0).ColumnName
            Me.DropDownList2.DataValueField = mydrop.Columns(1).ColumnName
            Me.DropDownList2.DataBind()
            '============
            'ft1 = oh.ExecuteDataSet(st).Tables(0)
            'If (ft1.Rows(0)(0) = 0) Then
            '    Server.Transfer("../../show_err.aspx")
            'End If

            Me.Txt_fdt.Text = Format(Date.Today, "dd/MMM/yyyy")
            Me.Txt_tdt.Text = Format(Date.Today, "dd/MMM/yyyy")
            'Dim st1 As String = vysh(1).Split("@")(3)
            'st1 = st1.Replace("myfirm", Session("firm_id"))
            'sta = oh.ExecuteDataSet(st1).Tables(0)
            'Me.cmb_state.DataSource = sta
            'Me.cmb_state.DataTextField = sta.Columns(0).ColumnName
            'Me.cmb_state.DataValueField = sta.Columns(1).ColumnName
            'Me.cmb_state.DataBind()

            'Dim st2 As String = vysh(1).Split("@")(4).Replace("mystid", Me.cmb_state.SelectedValue)
            'st2 = st2.Replace("myfirm", Session("firm_id"))
            'sta1 = oh.ExecuteDataSet(st2).Tables(0)
            'Me.cmb_branch.DataSource = sta1
            'Me.cmb_branch.DataTextField = sta1.Columns(0).ColumnName
            'Me.cmb_branch.DataValueField = sta1.Columns(1).ColumnName
            'Me.cmb_branch.DataBind()
        End If

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim cl_script9 As New StringBuilder
        If (CDate(Me.Txt_fdt.Text) > CDate(Format(Date.Today, "dd/MMM/yyyy"))) Then

            cl_script9.Append(" alert('Future date is not allowed in From Date!! ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)
            Exit Sub
        End If
        If (CDate(Me.Txt_tdt.Text) > CDate(Format(Date.Today, "dd/MMM/yyyy"))) Then

            cl_script9.Append(" alert('Future date is not allowed in TO Date!! ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)
            Exit Sub
        End If

        If (CDate(Me.Txt_fdt.Text) > CDate(Me.Txt_tdt.Text)) Then

            cl_script9.Append(" alert('check date entered ,From date is greater than To date !! ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)

            Exit Sub
        End If

        'If (Me.cmb_branch.SelectedValue = "") AndAlso Me.CheckBox2.Checked = True Then

        '    cl_script9.Append(" alert('No Branch is selected !! ');")
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)
        '    Exit Sub
        'Else
        If (Me.DropDownList2.SelectedValue = "0") AndAlso Me.CheckBox1.Checked = True Then

            cl_script9.Append(" alert('Select Any Employee');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)
            Exit Sub
        Else
            If Me.CheckBox1.Checked = True Then
                codes = Me.DropDownList2.SelectedValue
                Server.Transfer("tasplitindi.aspx?ecode=" & codes & "")
            ElseIf Me.CheckBox2.Checked = True Then
                codes = 0
                Server.Transfer("tasplitindi.aspx?fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&ecode=" & codes & "")
            End If
        End If
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.CheckBox2.Checked = False
            Me.rt2.Visible = False
            Me.rt1.Visible = False
            Me.Tr1.Visible = True
        Else
            Me.CheckBox2.Checked = True
            Me.rt2.Visible = True
            Me.rt1.Visible = True
            Me.Tr1.Visible = False
        End If
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Me.CheckBox1.Checked = False
            Me.Tr1.Visible = False
            Me.rt2.Visible = True
            Me.rt1.Visible = True
        Else
            Me.CheckBox1.Checked = True
            Me.Tr1.Visible = True
            Me.rt2.Visible = False
            Me.rt1.Visible = False
        End If
    End Sub
End Class
