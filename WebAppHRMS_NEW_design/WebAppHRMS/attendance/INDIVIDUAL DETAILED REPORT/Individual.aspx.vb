Imports System.Data
Imports System.Data.OracleClient

Partial Class Attendence_Report_Present_080605c52897
    Inherits System.Web.UI.Page
    Dim cat, type, id, dp As Integer
    Dim sql, dps As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not IsPostBack() Then

            Me.Txt_fdate.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")
            Me.Txt_tdate.Text = Format(CDate(Date.Today), "dd/MMM/yyyy")

            Me.rd_branch.Checked = True
            Me.DropDownList1.Visible = False


            If (Me.rd_branch.Checked = True) Then
                Me.txt_empcode.Text = ""
                If (Me.Session("branch_id") = 0) Then
                    'sql = "select branch_id,branch_name from branch_master order by branch_name"
                    sql = "select -1 branch_id, '------select---------' branch_id         from dual       union all       select bm.branch_id,              bm.branch_id || '---- ' || bm.branch_name               from branch_master bm"
                Else
                    'sql = "select branch_id,branch_name from branch_master where branch_id=" & Me.Session("branch_id") & "order by branch_name"
                    sql = "select -1 branch_id, '------select---------' branch_id   from dual union all select bm.branch_id, bm.branch_id || '---- ' || bm.branch_name  from branch_master bm where branch_id = " & Me.Session("branch_id") & " "
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
                'sql = "select branch_id,branch_name from branch_master order by branch_name"
                sql = "select -1 branch_id, '------select---------' branch_id         from dual       union all       select bm.branch_id,              bm.branch_id || '---- ' || bm.branch_name               from branch_master bm"
            Else
                'sql = "select branch_id,branch_name from branch_master where branch_id=" & Me.Session("branch_id") & "order by branch_name"
                sql = "select -1 branch_id, '------select---------' branch_id   from dual union all select bm.branch_id, bm.branch_id || '---- ' || bm.branch_name  from branch_master bm where branch_id = " & Me.Session("branch_id") & " "
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
                            Server.Transfer("ReportE.aspx?fdate=" & Me.Txt_fdate.Text & "&tdate=" & Me.Txt_tdate.Text & "&category=" & cat & "&type=" & type & "&id=" & id)
                        Else
                            MsgBox("ENTER EMPLOYEE CODE")
                        End If

                    ElseIf (Me.rd_branch.Checked = True) Then

                        type = 2



                        id = Me.cmb_branch.SelectedValue
                        If id = 0 Then
                            dp = Me.DropDownList1.SelectedValue
                        End If




                        cat = Me.CMB_CAT.SelectedValue
                        Server.Transfer("ReportE.aspx?fdate=" & Me.Txt_fdate.Text & "&tdate=" & Me.Txt_tdate.Text & "&category=" & cat & "&type=" & type & "&id=" & id & "&dp=" & dp)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub cmb_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_branch.SelectedIndexChanged

        If Me.cmb_branch.SelectedValue = 0 Then

            Me.DropDownList1.Visible = True

            sql = "select d.dep_id, d.dep_name  from department_mst d where d.status = 1"

            dt1 = oh.ExecuteDataSet(sql).Tables(0)

            Me.DropDownList1.DataSource = dt1
            Me.DropDownList1.DataTextField = dt1.Columns(1).ColumnName
            Me.DropDownList1.DataValueField = dt1.Columns(0).ColumnName
            Me.DropDownList1.DataBind()



        Else
            Me.DropDownList1.Visible = False





        End If
    End Sub

    
End Class
