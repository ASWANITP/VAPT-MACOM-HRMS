Imports System.Data
Imports System.Data.OracleClient
Partial Class Employee_Punching_movement_cancel_macom_6182b3b24403
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sf(), frm As String
    Dim dt, dt1, dt2 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frm = Session("firm_id")
        If frm = 27 Then
            Response.Redirect("Movement_Cancel_Mafarm.aspx")
            Exit Sub
        End If
        Dim sc As String = "var cont_name;cont_name='" & Me.txt_name.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var2", sc, True)
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        If Not IsPostBack Then
            'If dt1.Rows(0)(0) > 0 Then
            dt2 = oh.ExecuteDataSet("select '----------SELECT MOVEMENT----------' from dual union select a.emp_name || '-----' || decode(a.mov_type, 1, 'Personal', 2, 'Official')|| '-----' ||a.exit_time|| '-----' ||a.entry_time||'-----' || a.mov_id from TBL_MOVEMENT_MST a where to_date(a.reqst_dt) = to_date(sysdate)   and a.status_id =0 and a.emp_code = " & User(0) & "").Tables(0)
            If dt2.Rows.Count > 0 Then
                cmb_emp.DataSource = dt2
                cmb_emp.DataValueField = dt2.Columns(0).ColumnName
                'cmb_emp.DataTextField = dt2.Columns(0).ColumnName
                cmb_emp.DataBind()
            Else
                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("         alert('No Data Found!!!!');")
                cl_script1.Append(" window.open('movement_cancel_macom.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            End If

        End If
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim script1 As New System.Text.StringBuilder
        Dim arr, arr1 As Array

        arr = Me.cmb_emp.SelectedValue.Split("*")
        arr1 = arr(0).split("-----")
        Dim tr() As String = cmb_emp.SelectedItem.ToString.Split("-")

        Dim movement_cancel(6) As OracleParameter
        movement_cancel(0) = New OracleParameter("empcd", OracleType.Number)
        movement_cancel(0).Direction = ParameterDirection.Input
        movement_cancel(0).Value = Me.txt_code.Value


        movement_cancel(1) = New OracleParameter("exittime", OracleType.VarChar, 10)
        movement_cancel(1).Direction = ParameterDirection.Input
        movement_cancel(1).Value = Me.txt_exit.Value

        movement_cancel(2) = New OracleParameter("entrytime", OracleType.VarChar, 10)
        movement_cancel(2).Direction = ParameterDirection.Input
        movement_cancel(2).Value = Me.txt_entry.Value


        movement_cancel(3) = New OracleParameter("movtype", OracleType.Number)
        movement_cancel(3).Direction = ParameterDirection.Input
        If Me.txt_type.Value = "Personal" Then
            movement_cancel(3).Value = 1
        Else
            movement_cancel(3).Value = 2
        End If



        movement_cancel(4) = New OracleParameter("reqt_dt", OracleType.DateTime, 150)
        movement_cancel(4).Direction = ParameterDirection.Input
        'movement_cancel(3).Value = Format(CDate(Me.txt_appl_dt.Value), "mm-dd-yyyy")
        movement_cancel(4).Value = Me.txt_appl_dt.Value

        movement_cancel(5) = New OracleParameter
        movement_cancel(5).ParameterName = "movid"
        movement_cancel(5).OracleType = OracleType.Number
        movement_cancel(5).Direction = ParameterDirection.Input
        movement_cancel(5).Value = tr(20)

        movement_cancel(6) = New OracleParameter("msg", OracleType.VarChar, 3000)
        movement_cancel(6).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("HRM_MOVEMENT_CANCEL", movement_cancel)

        Dim message As String
        message = movement_cancel(6).Value
        script1.Append("                        alert('" & message & "');")
        script1.Append("window.open('movement_cancel_macom.aspx','_self');")
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

    End Sub

    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_emp.SelectedIndexChanged
        Dim dt As New DataTable
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim StrArr() As String
        Dim tr() As String = cmb_emp.SelectedItem.ToString.Split("-")



        dt = oh.ExecuteDataSet("select h.emp_code || '*' || h.emp_name || '*' || decode(h.mov_type, 1, 'Personal', 2, 'Official') || '*' || h.reqst_dt|| '*' ||h.exit_time|| '*' ||h.entry_time|| '*' ||h.mov_id from mactech.tbl_movement_mst h where h.emp_code = " & User(0) & " and to_date(h.reqst_dt) = to_date(sysdate) and h.status_id =0 and h.mov_id=" & tr(20) & "order by reqst_dt").Tables(0)
        StrArr = dt.Rows(0)(0).split("*")

        Try
            Me.txt_code.Value = StrArr(0).ToString()
            Me.txt_name.Value = StrArr(1).ToString()
            Me.txt_type.Value = StrArr(2).ToString()
            Me.txt_appl_dt.Value = StrArr(3).ToString()
            Me.txt_exit.Value = StrArr(4).ToString()
            Me.txt_entry.Value = StrArr(5).ToString()

        Catch ex As Exception
        Finally
            dt.Dispose()
        End Try

    End Sub

End Class








