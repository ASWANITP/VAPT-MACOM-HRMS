Imports System.Data.OracleClient
Imports System.Data
Imports System.IO
Imports System

Partial Class LeaveList_c56207c69507
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Dim user() As String
            ' user = Session("user_id").ToString.Split("!")
            ' Session("user_id") = "20007!233.444.555.666"
            'Session("user_id") = "22966!233.444.555.666"
            Dim user() As String
            user = Session("user_id").ToString.Split("!")
            Dim dtacs As New DataTable

            dtacs = getDatatable("select count(*) from form_accessibility s where s.form_id=859 and s.emp_id=" & user(0) & "")
            If (dtacs.Rows(0)(0) = 0) Then
                Server.Transfer("../show_err.aspx")

            End If
            Me.txt_empcde.Text = user(0)
            Dim dt1 As New DateTime
            Dim dt2 As New DateTime
            dt1 = DateTime.Today
            dt2 = dt1.AddDays(3)
            Dim cnt As New Long
            cnt = DateDiff(DateInterval.Day, dt1, dt2, Microsoft.VisualBasic.FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)



            proccess()
        End If
    End Sub

    Function proccess()
        Dim dtResult As New DataTable
        Dim user As String
        Dim sql As String
        Dim frmchk As String
        Dim frmrslt As New DataTable


        Dim fid As String = Session("firm_id").ToString

        user = Me.txt_empcde.Text.ToString

        frmchk = "select count(em.emp_code) from employee_master em join employ_firm ef on ef.emp_code=em.emp_code  where em.status_id=1  and ef.firm_id=" & fid & "  and em.emp_code=" & user

        frmrslt = getDatatable(frmchk)

        If Convert.ToInt32(frmrslt.Rows(0)(0)) > 0 Then

            Dim flg As New Integer
            If (RdoRecommendation.Checked) Then
                flg = 2

                sql = "select la.emp_code,la.emp_name,la.leave_frdate,la.leave_todate,la.leave_days,la.leave_reason,la.leave_id,las.status_id from hrm_leave_application la join hrm_leave_apply_sanction las on las.emp_code=la.emp_code and las.leave_frdate=la.leave_frdate and las.leave_todate=la.leave_todate  where las.status_id=0  and la.sanc_code=" & user & "order by la.leave_frdate asc"

            Else
                flg = 1
                sql = "select la.emp_code,la.emp_name,la.leave_frdate,la.leave_todate,la.leave_days,la.leave_reason,la.leave_id,las.status_id from hrm_leave_application la join hrm_leave_apply_sanction las on las.emp_code=la.emp_code and las.leave_frdate=la.leave_frdate and las.leave_todate=la.leave_todate  where (las.status_id=0 or las.status_id=4  or las.status_id=5 ) and la.sanc_code=" & user & "order by la.leave_frdate asc"




            End If

            Dim status As Integer = callLeave_proc(flg)

            If status = 1 Then

                dtResult = getDatatable(sql)
                GrvLeave.DataSource = dtResult
                GrvLeave.DataBind()
                If dtResult.Rows.Count > 0 Then
                    ButnExcel.Enabled = True
                Else
                    ButnExcel.Enabled = False

                End If


            End If
        End If


    End Function
    Private Function getDatatable(ByVal qry As Object) As DataTable
        Dim dtresults As New DataTable
        Dim oh As New Helper.Oracle.OracleHelper
        dtresults = oh.ExecuteDataSet(qry).Tables(0)
        Return dtresults
    End Function
    Function callLeave_proc(ByVal tp As Integer)
        ' Me.cmb_leave.DataSource = Nothing
        ' Me.cmb_leave.Items.Clear()
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        Dim curuser As String
        curuser = Me.txt_empcde.Text.ToString() + "!" + sf(1)

        Dim oh As New Helper.Oracle.OracleHelper
        Dim tr(2) As OracleParameter
        tr(0) = New OracleParameter("usr_id", OracleType.VarChar, 50)
        tr(0).Direction = ParameterDirection.Input
        tr(0).Value = curuser
        tr(1) = New OracleParameter("tpid", OracleType.Number, 1)
        tr(1).Direction = ParameterDirection.Input
        tr(1).Value = tp
        tr(2) = New OracleParameter("flag", OracleType.Number, 2)
        tr(2).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("hrm_leave_access_author_new", tr)
        Dim flg As Integer
        flg = tr(2).Value
        Return flg
    End Function

    'Protected Sub ButSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButSubmit.Click
    'proccess()
    'End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        proccess()
    End Sub

    Protected Sub ButnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButnExcel.Click
        Dim filename As String
        If RdoRecommendation.Checked Then
            filename = "Emp_leave_recomns.xls"
        Else
            filename = "Emp_leave_sanction.xls"
        End If
        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", filename))
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        GrvLeave.AllowPaging = False
        GrvLeave.DataBind()
        'Change the Header Row back to white color
        GrvLeave.HeaderRow.Style.Add("background-color", "#FFFFFF")
        'Applying stlye to gridview header cells
        For i As Integer = 0 To GrvLeave.HeaderRow.Cells.Count - 1
            GrvLeave.HeaderRow.Cells(i).Style.Add("background-color", "#507CD1")
        Next
        Dim j As Integer = 1
        'This loop is used to apply stlye to cells based on particular row
        For Each gvrow As GridViewRow In GrvLeave.Rows
            gvrow.BackColor = Drawing.Color.White
            If j <= GrvLeave.Rows.Count Then
                If j Mod 2 <> 0 Then
                    For k As Integer = 0 To gvrow.Cells.Count - 1
                        gvrow.Cells(k).Style.Add("background-color", "#EFF3FB")
                    Next
                End If
            End If
            j += 1
        Next
        GrvLeave.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()

    End Sub

    Protected Sub RdoRecommendation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdoRecommendation.CheckedChanged
        proccess()
    End Sub
End Class
