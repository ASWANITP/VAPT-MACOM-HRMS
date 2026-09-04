Imports System.Data
Imports System.Data.OracleClient
Partial Class Attendence_Report_Present_080605c55145
    Inherits System.Web.UI.Page
    Dim cat As Integer
    Dim usr() As String
    Dim oh As New Helper.Oracle.OracleHelper

    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim RegionID, BranchID, AreaID As Integer
    Dim RH As New WholeHelper.ClsRepCtrl

    Dim tb As New Table
    Dim BrID As Integer
    Dim BranchName As String
    Dim dr As DataRow
    Dim count As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            usr = Me.Session("user_id").ToString.Split("!")
            'If Session("branch_id") = 0 Then
            Me.Txt_frdate.Text = Format(Date.Today, "dd/MMM/yyyy")
            'Else

            '   Dim dt44 As DataTable = oh.ExecuteDataSet("select post_id from employee_master where post_id  in (199,112,200,197,136,141,28,195,173) and status_id=1 and emp_code=" & usr(0) & "").Tables(0)
            '  If dt44.Rows.Count > 0 Then
            ' Me.Txt_frdate.Text = Format(Date.Today, "dd/MMM/yyyy")
            'Else
            '    Server.Transfer("../../show_err.aspx")
            'End If


            ' End If

        End If

    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.Rdb_con.Checked = True Then
            usr = Me.Session("user_id").ToString.Split("!")
            Dim dt44 As DataTable = oh.ExecuteDataSet("select post_id,branch_id,department_id from employee_master where  status_id=1 and emp_code=" & usr(0) & "").Tables(0)

            If dt44.Rows(0)(0) = 173 Or dt44.Rows(0)(0) = 195 Or dt44.Rows(0)(0) = 28 Or dt44.Rows(0)(0) = 199 Or dt44.Rows(0)(0) = 200 Then
                '  Dim dt33 As DataTable = oh.ExecuteDataSet("select  nvl(z.zonal_id,0) from zonal_master z where z.head_id=" & usr(0) & " union select nvl(z.zonal_id,0) from zonal_master z where z.hr_head=" & usr(0) & " union select nvl(z.zonal_id,0) from zonal_master z where z.zonal_head=" & usr(0) & " ").Tables(0)
                If Me.Txt_frdate.Text = "" Then
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('Please Select Date');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                Else
                    If CDate(Me.Txt_frdate.Text) > CDate(Date.Now) Then
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("         alert('Future Date Not Allowed');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else
                        cat = 1
                        Server.Transfer("PresentReportR.aspx?frdate=" & Me.Txt_frdate.Text & "&cat=" & cat)

                    End If
                End If


            Else
                If dt44.Rows(0)(0) = 136 Or dt44.Rows(0)(0) = 197 Then

                    If Me.Txt_frdate.Text = "" Then
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("         alert('Please Select Date');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else
                        If CDate(Me.Txt_frdate.Text) > CDate(Date.Now) Then
                            Dim cl_script1 As New System.Text.StringBuilder
                            cl_script1.Append("         alert('Future Date Not Allowed');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        Else
                            cat = 2
                            Server.Transfer("PresentReportA.aspx?fdate=" & Me.Txt_frdate.Text & "&cat=" & cat)

                        End If
                    End If


                Else
                    If dt44.Rows(0)(1) = 0 And (dt44.Rows(0)(2) = 154 Or Me.Session("acess_id") = 33) Then


                        If Me.Txt_frdate.Text = "" Then
                            Dim cl_script1 As New System.Text.StringBuilder
                            cl_script1.Append("         alert('Please Select Date');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        Else
                            If CDate(Me.Txt_frdate.Text) > CDate(Date.Now) Then
                                Dim cl_script1 As New System.Text.StringBuilder
                                cl_script1.Append("         alert('Future Date Not Allowed');")
                                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                            Else
                                cat = 0
                                Server.Transfer("PresentReportR.aspx?frdate=" & Me.Txt_frdate.Text & "&cat=" & cat)

                            End If
                        End If
                    Else
                        Server.Transfer("../../show_err.aspx")
                    End If
                End If


            End If

        End If
        '---------------------------------------

        '---------------------------------------
        '----------------------------------------
        '-----------------------------------------








        If Me.Rdb_sht.Checked = True Then

            '    dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
            '    BranchName = dt.Rows(0)(0)
            '    Dim User() As String = Session("user_id").ToString.Split("!")
            '    Dim UserId As Integer = User(0)
            '    If Me.Rdb_sht.Checked = True Then
            '        dt = oh.ExecuteDataSet("select post_id,branch_id from employee_master where emp_code=" & UserId & " and status_id=1 and post_id in (28,200,195,199)").Tables(0)
            '        If dt.Rows.Count > 0 Then
            '            BranchID = dt.Rows(0)(1)
            '            dt = oh.ExecuteDataSet("select region_id from view_branch where branch_id=" & BranchID & "").Tables(0)
            '            If dt.Rows.Count > 0 Then
            '                RegionID = dt.Rows(0)(0)
            '                Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch3.aspx?id=" & RegionID & "")
            '            End If
            '        Else
            '            dt = oh.ExecuteDataSet("select post_id,branch_id from employee_master where emp_code=" & UserId & " and status_id=1 and post_id in (197,134,136,141)").Tables(0)
            '            If dt.Rows.Count > 0 Then
            '                BranchID = dt.Rows(0)(1)
            '                dt = oh.ExecuteDataSet("select area_id from view_branch where branch_id=" & BranchID & "").Tables(0)
            '                If dt.Rows.Count > 0 Then
            '                    AreaID = dt.Rows(0)(0)
            '                    'Dim id As Integer = AreaID
            '                    Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch4.aspx?id=" & AreaID & "")
            '                Else
            '                    Dim cl_script0 As New System.Text.StringBuilder
            '                    cl_script0.Append("         alert('No Details to Display !!!!');")
            '                    cl_script0.Append("window.open('../home.aspx','_self');")
            '                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            '                End If
            '            Else
            '                Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch1.aspx")
            '            End If
            '        End If
            '    End If

            'End If
            dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id=" & BrID & "").Tables(0)
            BranchName = dt.Rows(0)(0)
            Dim User() As String = Session("user_id").ToString.Split("!")
            Dim UserId As Integer = User(0)
            'If Me.Rdb_BH.Checked = True Then
            dt = oh.ExecuteDataSet("select post_id,branch_id from employee_master where emp_code=" & UserId & " and status_id=1 and post_id in (200,199)").Tables(0)
            'dt = oh.ExecuteDataSet("select post_id,b.zonal_id from employee_master a,zonal_master b where b.hr_head=" & UserId & " and a.status_id = 1 and a.post_id in (200, 195, 199) and a.emp_code=b.hr_head").Tables(0)
            If dt.Rows.Count > 0 Then
                BranchID = dt.Rows(0)(1)
                ' dt = oh.ExecuteDataSet("select distinct(region_id) from view_branch where zone_id=" & BranchID & "").Tables(0)
                dt = oh.ExecuteDataSet("select distinct(region_id) from view_branch where branch_id=" & BranchID & "").Tables(0)
                If dt.Rows.Count > 0 Then
                    'For Each dr In dt.Rows
                    '    str_tkn.Append(dr(0))
                    '    str_tkn.Append(",")
                    'Next
                    'str_tkn.Append("9999")
                    'Me.hid_area.Value = str_tkn.ToString
                    RegionID = dt.Rows(0)(0)
                    'Dim id As Integer = RegionID
                    Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch3.aspx?id=" & RegionID & "")
                End If
                'Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch2.aspx?id=" & BranchID & "")
            Else
                dt = oh.ExecuteDataSet("select post_id,branch_id from employee_master where emp_code=" & UserId & " and status_id=1 and post_id in (197,134,136)").Tables(0)
                If dt.Rows.Count > 0 Then
                    BranchID = dt.Rows(0)(1)
                    dt = oh.ExecuteDataSet("select area_id from view_branch where branch_id=" & BranchID & "").Tables(0)
                    If dt.Rows.Count > 0 Then
                        AreaID = dt.Rows(0)(0)
                        'Dim id As Integer = AreaID
                        Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch4.aspx?id=" & AreaID & "")
                    Else

                        Dim cl_script0 As New System.Text.StringBuilder
                        cl_script0.Append("         alert('No Details to Display !!!!');")
                        cl_script0.Append("window.open('../../home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)

                    End If
                Else
                    dt = oh.ExecuteDataSet("select zonal_id,head_id from zonal_master where head_id=" & UserId & " ").Tables(0)
                    If dt.Rows.Count > 0 Then
                        Dim ZoneID As Integer = dt.Rows(0)(0)
                        Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch2.aspx?id=" & ZoneID & "")
                    Else
                        dt = oh.ExecuteDataSet("select zonal_id,hr_head from zonal_master where hr_head=" & UserId & " ").Tables(0)
                        If dt.Rows.Count > 0 Then
                            Dim ZoneID As Integer = dt.Rows(0)(0)
                            Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch2.aspx?id=" & ZoneID & "")
                        Else
                            Me.Response.Redirect("HRM_RPT_BH_ABH_NotPunch1.aspx")
                        End If
                    End If
                End If
            End If
        End If
        'End If
    End Sub

    Protected Sub Rdb_con_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdb_con.CheckedChanged
        If Me.Rdb_con.Checked = False Then
            Me.Rdb_sht.Checked = True
            Me.Txt_frdate.Visible = False
            Me.lbl1.Visible = False
            Me.Rdb_con.Checked = False
        End If
        If Me.Rdb_con.Checked = True Then
            Me.Txt_frdate.Visible = True
            Me.lbl1.Visible = True
            Me.Rdb_sht.Checked = False
        End If
    End Sub

    Protected Sub Rdb_sht_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdb_sht.CheckedChanged
        If Me.Rdb_sht.Checked = False Then
            Me.Rdb_con.Checked = True
            Me.Rdb_sht.Checked = False
            Me.Txt_frdate.Visible = True
            Me.lbl1.Visible = True
        End If
        If Me.Rdb_sht.Checked = True Then
            Me.Rdb_con.Checked = False
            Me.Txt_frdate.Visible = False
            Me.lbl1.Visible = False
        End If
    End Sub
End Class
