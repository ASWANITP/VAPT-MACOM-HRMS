Imports System.Data
Imports System.Data.OracleClient
Partial Class november_tour_Tour_Br_report_3b2354f96376
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dt4 As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.Txt_fdt.Text = Format(Date.Today, "dd/MMM/yyyy")

            Me.Txt_tdt.Text = Format(Date.Today, "dd/MMM/yyyy")

        End If
    End Sub

    Protected Sub Cmd_Confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select branch_id from employee_master where emp_code=" & sf(0) & " and post_id in(17,18,10,11,12,13,14,15,16,101,149,146,148,90) and status_id=1").Tables(0)
        dt1 = oh.ExecuteDataSet("select area_id from area_master where area_head_id=" & sf(0) & "").Tables(0)
        dt2 = oh.ExecuteDataSet("select division_id from division_master where div_head_id=" & sf(0) & "").Tables(0)
        dt3 = oh.ExecuteDataSet("select zonal_id from zonal_master where head_id=" & sf(0) & "").Tables(0)
        dt4 = oh.ExecuteDataSet("select reg_id from region_master where head_id=" & sf(0) & "").Tables(0)
        Dim pos As Integer
        Dim dtl As String = ""
        Dim dr As DataRow
        If (dt1.Rows.Count = 1) Then
            dtl = dt1.Rows(0)(0)
        Else
            For Each dr In dt1.Rows
                '  pos = dr(0)
                If dtl = "" Then
                    dtl = dr(0)
                Else
                    dtl = dtl & "," & dr(0)
                End If

            Next
        End If

        If (dt2.Rows.Count = 1) Then
            dtl = dt2.Rows(0)(0)
        Else
            For Each dr In dt2.Rows
                '  pos = dr(0)
                If dtl = "" Then
                    dtl = dr(0)
                Else
                    dtl = dtl & "," & dr(0)
                End If

            Next
        End If

        If (dt3.Rows.Count = 1) Then
            dtl = dt3.Rows(0)(0)
        Else
            For Each dr In dt3.Rows
                '  pos = dr(0)
                If dtl = "" Then
                    dtl = dr(0)
                Else
                    dtl = dtl & "," & dr(0)
                End If

            Next
        End If
        If (dt4.Rows.Count = 1) Then
            dtl = dt4.Rows(0)(0)
        Else
            For Each dr In dt4.Rows
                '  pos = dr(0)
                If dtl = "" Then
                    dtl = dr(0)
                Else
                    dtl = dtl & "," & dr(0)
                End If

            Next
        End If
        If dt3.Rows.Count >= 1 Then
            'zm
            pos = 1
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("window.open('tour_Br_report_display.aspx?dtl=" & dtl & "&emp=" & sf(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Else
            If dt2.Rows.Count >= 1 Then
                'dm
                pos = 2
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("window.open('tour_Br_report_display.aspx?dtl=" & dtl & "&emp=" & sf(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            Else
                If dt1.Rows.Count >= 1 Then
                    'am
                    pos = 3
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("window.open('tour_Br_report_display.aspx?dtl=" & dtl & "&emp=" & sf(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

                Else
                    If dt.Rows.Count >= 1 Then
                        'bh
                        pos = 4
                        Dim cl_script1 As New System.Text.StringBuilder
                        cl_script1.Append("window.open('tour_Br_report_display.aspx?dtl=" & dt.Rows(0)(0) & "&emp=" & sf(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                    Else

                        If (dt4.Rows.Count >= 1) Then
                            'rm
                            pos = 0
                            Dim cl_script1 As New System.Text.StringBuilder
                            cl_script1.Append("window.open('tour_Br_report_display.aspx?dtl=" & dtl & "&emp=" & sf(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

                        Else
                            'employ
                            pos = 5
                            Dim cl_script1 As New System.Text.StringBuilder
                            cl_script1.Append("window.open('tour_Br_report_display.aspx?dtl=" & sf(0) & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "&post=" & pos & "','_self');")
                            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                        End If



                    End If

                End If

            End If
        End If


    End Sub
End Class
