Imports system.data
Imports system.data.oracleclient
Partial Class tour_recomment_aa4fe9a24056
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Shared st As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        dt2 = oh.ExecuteDataSet("select b.dep_head||'------'||a.emp_name,b.dep_head from employee_master a,department_mst b where b.dep_head= " & sf(0) & " and a.emp_code=b.dep_head ").Tables(0)
        If (dt2.Rows.Count <= 0) Then
            Response.Redirect("../show_err.aspx")
        End If
        If Not IsPostBack Then
            data_fill()
        End If
        Me.cmd_exit.Attributes.Add("onclick", "exit()")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_done.Click
        If (Me.Txt_from_date.Text = "" And Me.Txt_to_date.Text = "") Then
            Me.lbl_msg.Text = "NO TOUR IS FOUND FOR RECOMMENTATION !"
        Else
            If (Me.rd_app.Checked = True Or Me.rd_rej.Checked = True) Then
                ' Dim sr() As String
                'sr = Me.cmb_tour.SelectedValue.ToString.Split("&")
                If (Me.Txt_code.Text = "") Then
                    Me.lbl_msg.Text = "NO TOUR IS FOUND FOR RECOMMENTATION !"
                    clear()
                Else
                    clear()
                    Me.lbl_msg.Text = " TOUR Recommentation for  * " & Me.cmb_tour.SelectedItem.Text & " *  is  " & Me.HiddenField1.Value & " !"
                    fills()
                End If
            Else
                Me.lbl_msg.Text = "NO DECISIONS ! "
            End If
        End If
    End Sub
    Sub fills()
        Dim sd As Date = CDate(Me.Txt_from_date.Text)
        Dim sttr As String = Format(sd, "dd/MMM/yyyy")
        Dim sd1 As Date = CDate(Me.Txt_date_to.Text)
        Dim sttr1 As String = Format(sd1, "dd/MMM/yyyy")
        Dim sql1 As String = "update tour_master set remarks='" & Me.HiddenField1.Value & "',recomment_by='" & st & "',tour_status='1' where remarks is null and emp_code='" & Me.Txt_code.Text & "'and from_date= to_date('" & sttr & "') and to_date= to_date('" & sttr1 & "')"
        oh.ExecuteNonQuery(sql1)
        clear()
        Me.Txt_recomment.Text = ""
        data_fill()
    End Sub
    Sub data_fill()
        Dim log() As String
        log = Session("user_id").ToString.Split("!")
        sql = "select a.emp_code||'------'||b.emp_name|| ' | '||a.from_date|| ' TO ' ||a.to_date,a.emp_code||'&'||a.from_date from tour_master a,employee_master b,department_mst c where a.emp_code=b.emp_code and a.remarks is null and c.dep_id=b.department_id and c.dep_head='" & log(0) & "' order by a.apply_date asc"
        dt = oh.ExecuteDataSet(sql).Tables(0)
        If (dt.Rows.Count = 0) Then
            Me.cmb_tour.SelectedItem.Text = "NO TOUR APPLICATION EXIST !"
            If (Me.cmb_tour.SelectedItem.Text = "NO TOUR APPLICATION EXIST !") Then
                clear1()
            End If
            clear()
            clear1()
        Else
            Me.cmb_tour.DataSource = dt
            Me.cmb_tour.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_tour.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_tour.DataBind()
            fill()
        End If
    End Sub
    Sub clear()
        Me.rd_app.Checked = False
        Me.rd_rej.Checked = False
    End Sub
    Sub clear1()
        Me.Txt_code.Text = ""
        Me.Txt_name.Text = ""
        Me.Tx_tdesignation.Text = ""
        Me.Txt_branch.Text = ""
        Me.Txt_from_date.Text = ""
        Me.Txt_date_to.Text = ""
        Me.Txt_time_from.Text = ""
        Me.Txt_to_date.Text = ""
        Me.Txt_advance.Text = ""
        Me.Txt_place.Text = ""
        Me.Txt_purpose.Text = ""
        Me.Txt_recomment.Text = ""
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_tour.SelectedIndexChanged

        fill()
        Me.rd_app.Checked = False
        Me.rd_rej.Checked = False
    End Sub
    Sub fill()
        Dim sr() As String
        sr = Me.cmb_tour.SelectedValue.ToString.Split("&")
        dt1 = oh.ExecuteDataSet("select a.emp_code,a.emp_name,b.designation,c.branch_name,d.from_date,d.to_date,d.from_time,d.to_time,nvl(d.advance_rs,0),d.tour_place,d.tour_purpose from employee_master a,designation_master b,branch_master c,tour_master d where a.emp_code='" & sr(0) & " 'and d.from_date='" & sr(1) & "' and d.remarks is null and d.designation_id=b.designation_id and a.branch_id=c.branch_id and a.emp_code=d.emp_code").Tables(0)
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")
        dt2 = oh.ExecuteDataSet("select b.dep_head||'------'||a.emp_name,b.dep_head from employee_master a,department_mst b where b.dep_head= " & sf(0) & " and a.emp_code=b.dep_head ").Tables(0)
        Me.Txt_code.Text = dt1.Rows(0)(0)
        Me.Txt_name.Text = dt1.Rows(0)(1)
        Me.Tx_tdesignation.Text = dt1.Rows(0)(2)
        Me.Txt_branch.Text = dt1.Rows(0)(3)
        Me.Txt_from_date.Text = dt1.Rows(0)(4)
        Me.Txt_date_to.Text = dt1.Rows(0)(5)
        Me.Txt_time_from.Text = dt1.Rows(0)(6)
        Me.Txt_to_date.Text = dt1.Rows(0)(7)
        Me.Txt_advance.Text = dt1.Rows(0)(8)
        Me.Txt_place.Text = dt1.Rows(0)(9)
        Me.Txt_purpose.Text = dt1.Rows(0)(10)
        Me.Txt_recomment.Text = dt2.Rows(0)(0)
        st = dt2.Rows(0)(1)
       

    End Sub
    Protected Sub approved_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rd_app.CheckedChanged
        Me.HiddenField1.Value = "Approved"
        If (Me.rd_app.Checked = True) Then
            Me.lbl_msg.Text = ""
        End If
    End Sub
    Protected Sub reject_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rd_rej.CheckedChanged
        Me.HiddenField1.Value = "Rejected"
        If (Me.rd_rej.Checked = True) Then
            Me.lbl_msg.Text = ""
        End If
    End Sub
    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Server.Transfer("../home.aspx")
    End Sub
End Class
