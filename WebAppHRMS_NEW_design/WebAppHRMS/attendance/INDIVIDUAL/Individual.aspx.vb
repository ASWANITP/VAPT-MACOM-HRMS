Imports System.Data
Imports System.Data.OracleClient
Partial Class Attendence_Report_Present_080605c56196
    Inherits System.Web.UI.Page
    Dim cat, type, id1 As Integer
    Dim sql As String
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            Me.Txt_fdate.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")
            Me.Txt_tdate.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")

            Me.rd_branch.Checked = True
            If (Me.rd_branch.Checked = True) Then
                Me.txt_empcode.Text = ""
                If (Me.Session("branch_id") = 0) Then
                    sql = "SELECT b.branch_id, b.branch_name as branch FROM branch_master b where b.firm_id = " & Session("firm_id") & " UNION ALL SELECT b.branch_id, b.branch_name as branch FROM branch_master b WHERE b.firm_id =8 ORDER BY branch"
                Else
                    sql = "select branch_id,branch_name from branch_master where branch_id=" & Me.Session("branch_id") & "order by branch_name"
                End If
                dt = oh.ExecuteDataSet(sql).Tables(0)
                Me.cmb_branch.DataSource = dt
                Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_branch.DataBind()
            End If
        End If
    End Sub

    Protected Sub rd_branch_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rd_branch.CheckedChanged
        If (Me.rd_branch.Checked = True) Then
            Me.txt_empcode.Text = ""
            If (Me.Session("branch_id") = 0) Then
                sql = "select branch_id,branch_name from branch_master order by branch_name"
            Else
                sql = "select branch_id,branch_name from branch_master where branch_id=" & Me.Session("branch_id") & "order by branch_name"
            End If
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Me.cmb_branch.DataSource = dt
            Me.cmb_branch.DataTextField = dt.Columns(1).ColumnName
            Me.cmb_branch.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_branch.DataBind()
        End If
    End Sub

    Protected Sub rd_ecode_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rd_ecode.CheckedChanged
        Me.cmb_branch.Items.Clear()
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.Txt_fdate.Text = "" Or Me.Txt_tdate.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else
            If CDate(Me.Txt_fdate.Text) > CDate(Me.Txt_tdate.Text) Then
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('To Date Not Valid');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Else
                If CDate(Me.Txt_fdate.Text) > CDate(Date.Now) Or CDate(Me.Txt_tdate.Text) > CDate(Date.Now) Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Future Date Not Allowed');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    If (Me.rd_ecode.Checked = True) Then
                        If Not (Me.txt_empcode.Text = "") Then
                            type = 1
                            id = Me.txt_empcode.Text
                            cat = Me.CMB_CAT.SelectedValue
                            sql = "select firm_id from employ_firm where emp_code=" & id & ""
                            dt = oh.ExecuteDataSet(sql).Tables(0)
                            If dt.Rows(0)(0) = Session("firm_id") Then
                                Server.Transfer("ReportE.aspx?fdate=" & Me.Txt_fdate.Text & "&tdate=" & Me.Txt_tdate.Text & "&category=" & cat & "&type=" & type & "&id=" & id)
                            Else
                                Dim cl_script1 As New System.Text.StringBuilder
                                cl_script1.Append("         alert('You are not authorized');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                            End If

                        Else
                            MsgBox("ENTER EMPLOYEE CODE")
                        End If

                    ElseIf (Me.rd_branch.Checked = True) Then

                        type = 2
                        id = Me.cmb_branch.SelectedValue
                        cat = Me.CMB_CAT.SelectedValue
                        Server.Transfer("ReportE.aspx?fdate=" & Me.Txt_fdate.Text & "&tdate=" & Me.Txt_tdate.Text & "&category=" & cat & "&type=" & type & "&id=" & id)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub cmb_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
