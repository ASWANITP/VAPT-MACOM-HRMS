Imports System.Data
Imports System.Data.OracleClient
Imports System.Web
Imports System.Net
Imports System.IO
Partial Class Employee_Punching_Movement_Recommend_Macom_33cdcf156868
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2, dt3, dtj, ceo, depp, dtr, dta, dap As New DataTable
    Dim sf(), frm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frm = Session("firm_id")
        If frm = 27 Then
            Response.Redirect("Movement_Recommend_Mafarm.aspx")
            Exit Sub
        End If

        Dim cs As String = "var cont_name;cont_name='" & Me.Txt_purp.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "var", cs, True)
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim dep1 As String = " "
        Dim fid As Integer = Session("firm_id")
        Dim s As String = "select s.post_id from employee_master s where s.emp_code=" & User(0) & " "
        dta = oh.ExecuteDataSet("select s.post_id from employee_master s where s.emp_code=" & User(0) & "").Tables(0)
        If Not IsPostBack Then
            dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=6000 and s.emp_id=" & dta.Rows(0)(0) & "").Tables(0)

            'dt1 = oh.ExecuteDataSet("select count(*) from mactech.tbl_movement_mst t where t.rec_usr=" & User(0) & " and t.status_id=0").Tables(0)
            If dt1.Rows(0)(0) > 0 Then
                Dim str As String = "select '----SELECT----', '0' as empcode from dual union select e.emp_code || '-----' || e.emp_name || '-----' || to_char(a.reqst_dt)|| '-----' ||a.exit_time|| '-----' ||a.mov_id, e.emp_code || '-----' || e.emp_name || '*' || d.dep_name || '*' || ds.designation || '*' || p.post_name || '*' || b.branch_name || '*' || to_char(a.reqst_dt) || '*' || a.exit_time || '*' || a.entry_time  || '*' ||a.place || '*' || a.purpose || '*' || a.mov_type  from TBL_MOVEMENT_MST a, employee_master e, department_mst d, designation_master ds, post_mst p, branch b where a.emp_code = e.emp_code and to_date(a.reqst_dt)=to_date(sysdate) and a.status_id = 0 and e.department_id = d.dep_id and e.designation_id = ds.designation_id and e.post_id = p.post_id and e.branch_id = b.BRANCH_ID   and a.rec_usr =" & User(0) & ""

                dt = oh.ExecuteDataSet(str).Tables(0)
                If dt.Rows.Count > 0 Then
                    cmb_emp.DataSource = dt
                    cmb_emp.DataValueField = dt.Columns(1).ColumnName
                    cmb_emp.DataTextField = dt.Columns(0).ColumnName
                    cmb_emp.DataBind()
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('No Data Found!!!!');")
                    cl_script1.Append(" window.open('Movement_Recommend_Macom.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If
            Else
                ' Me.Server.Transfer("../show_err.aspx")
                Response.Redirect("~/show_err.aspx")

            End If
        End If
        Me.Text_RJTRSN.Visible = False
        Me.New_Reject.Visible = False
        Me.Label1.Visible = False
    End Sub

    Protected Sub cmb_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_emp.SelectedIndexChanged
        Dim arr As Array
        arr = Me.cmb_emp.SelectedValue.Split("*")
        Me.Txt_emp.Value = arr(0)
        Me.Txt_dep.Value = arr(1)
        Me.Txt_des.Value = arr(2)
        Me.Txt_post.Value = arr(3)
        Me.Txt_br.Value = arr(4)
        Me.Txt_fdt.Text = arr(5)
        Me.Txt_From.Text = arr(6)
        Me.Txt_To.Text = arr(7)
        Me.Textplace.Value = arr(8)
        Me.Txt_purp.Text = arr(9)

        If (arr(10) = 1) Then
            Me.Txt_movtype.Value = "PERSONAL"
        ElseIf (arr(10) = 2) Then
            Me.Txt_movtype.Value = "OFFICIAL"
        End If


        'Me.Txt_movtype.Value = arr(10)


    End Sub

    Protected Sub cmd_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_reject.Click
        Me.Text_RJTRSN.Visible = True
        Me.New_Reject.Visible = True
        Me.Label1.Visible = True
        Me.cmd_reject.Visible = False
        Me.cmd_confirm.Enabled = False

    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click

        Me.New_Reject.Enabled = False
        Dim sf() As String
        sf = Session("user_id").ToString.Split("!")

        Dim dt2 As DataTable
        dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
        Dim arr, arr1 As Array

        arr = Me.cmb_emp.SelectedValue.Split("*")
        arr1 = arr(0).split("-----")
        Dim dts As String = arr(6)
        Dim tr() As String = cmb_emp.SelectedItem.ToString.Split("-")

        Dim script1 As New System.Text.StringBuilder
        Try

            Dim sq178 As String = "UPDATE mactech.tbl_movement_mst el set el.recommend_by=:san_emp_code,el.reccomend_dt=:recdt,el.status_id=:stat where el.emp_code=:code and to_char(el.reqst_dt)=:go_dt and el.mov_id=:movid"
            'and to_char(el.exit_time)=:exi and to_char(el.entry_time)=:entr 
            'and  to_char(e1.exit_time)=" + Me.Txt_To.Text
            Dim prrr(5) As OracleParameter

            prrr(0) = New OracleParameter
            prrr(0).ParameterName = "code"
            prrr(0).OracleType = OracleType.Number
            prrr(0).Direction = ParameterDirection.Input
            prrr(0).Value = arr1(0)

            prrr(1) = New OracleParameter
            prrr(1).ParameterName = "san_emp_code"
            prrr(1).OracleType = OracleType.Number
            prrr(1).Direction = ParameterDirection.Input
            prrr(1).Value = sf(0)

            prrr(2) = New OracleParameter
            prrr(2).ParameterName = "go_dt"
            prrr(2).OracleType = OracleType.DateTime
            prrr(2).Direction = ParameterDirection.Input
            prrr(2).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")


            prrr(3) = New OracleParameter
            prrr(3).ParameterName = "recdt"
            prrr(3).OracleType = OracleType.DateTime
            prrr(3).Direction = ParameterDirection.Input
            prrr(3).Value = Format(Now.Date, "dd/MMM/yyyy")



            prrr(4) = New OracleParameter
            prrr(4).ParameterName = "stat"
            prrr(4).OracleType = OracleType.Number
            prrr(4).Direction = ParameterDirection.Input
            prrr(4).Value = 1

            prrr(5) = New OracleParameter
            prrr(5).ParameterName = "movid"
            prrr(5).OracleType = OracleType.Number
            prrr(5).Direction = ParameterDirection.Input
            prrr(5).Value = tr(22)

            'prrr(6) = New OracleParameter
            'prrr(6).ParameterName = "entr"
            'prrr(6).OracleType = OracleType.VarChar
            'prrr(6).Direction = ParameterDirection.Input
            'prrr(6).Value = Me.Txt_To.Text


            If oh.ExecuteNonQuery(sq178, prrr) Then


                Dim cl_scrip1 As New StringBuilder



                cl_scrip1.Append("   alert('Recommended Successfully') ;")
                cl_scrip1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                'Me.btn_reject.Enabled = False
            End If


            Me.Txt_emp.Value = ""
            Me.Txt_dep.Value = ""
            Me.Txt_des.Value = ""
            Me.Txt_br.Value = ""
            Me.Txt_fdt.Text = ""
            Me.Txt_From.Text = ""
            Me.Txt_post.Value = ""
            Me.Txt_purp.Text = ""
            Me.Txt_To.Text = ""
            Me.Textplace.Value = ""

            Me.Txt_movtype.Value = " "

        Catch ex As Exception

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("                        alert('Error. please check the values entered.');")
            'cl_script1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            'Response.Write(ex.ToString)






        End Try

    End Sub



    Protected Sub New_Reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles New_Reject.Click
        'Me.cmd_confirm.Enabled = False
        If (Text_RJTRSN.Text = "") Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Rejected Reason..!!');")
            cl_script1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else

            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")

            Dim dt2 As DataTable
            dt2 = oh.ExecuteDataSet("select sysdate from dual").Tables(0)
            Dim arr, arr1 As Array

            arr = Me.cmb_emp.SelectedValue.Split("*")
            arr1 = arr(0).split("-----")

            Dim tr() As String = cmb_emp.SelectedItem.ToString.Split("-")


            Dim script1 As New System.Text.StringBuilder
            Try


                'Dim sq17 As String = "UPDATE tbl_regularisation h set h.app_person= :appcode,h.status=:status,h.app_remarks=:remarks,h.app_date=:appdt,h.pay_id=:payid where h.apply_dt=:appdate1 and h.emp_code=:code"

                Dim sq178 As String = "UPDATE mactech.tbl_movement_mst el set el.recommend_by=:rej_emp_code,el.reccomend_dt=:recdt,el.rej_reason=:rejrea,el.status_id=:stat,el.tot_time = 0  where el.emp_code=:code and to_char(el.reqst_dt)=:go_dt and el.mov_id=:movid"
                Dim prrr(6) As OracleParameter

                prrr(0) = New OracleParameter
                prrr(0).ParameterName = "code"
                prrr(0).OracleType = OracleType.Number
                prrr(0).Direction = ParameterDirection.Input
                prrr(0).Value = arr1(0)

                prrr(1) = New OracleParameter
                prrr(1).ParameterName = "rej_emp_code"
                prrr(1).OracleType = OracleType.Number
                prrr(1).Direction = ParameterDirection.Input
                prrr(1).Value = sf(0)

                prrr(2) = New OracleParameter
                prrr(2).ParameterName = "go_dt"
                prrr(2).OracleType = OracleType.DateTime
                prrr(2).Direction = ParameterDirection.Input
                prrr(2).Value = Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy")


                prrr(3) = New OracleParameter
                prrr(3).ParameterName = "rejrea"
                prrr(3).OracleType = OracleType.VarChar
                prrr(3).Direction = ParameterDirection.Input
                prrr(3).Value = Me.Text_RJTRSN.Text



                prrr(4) = New OracleParameter
                prrr(4).ParameterName = "stat"
                prrr(4).OracleType = OracleType.Number
                prrr(4).Direction = ParameterDirection.Input
                prrr(4).Value = 3

                prrr(5) = New OracleParameter
                prrr(5).ParameterName = "recdt"
                prrr(5).OracleType = OracleType.DateTime
                prrr(5).Direction = ParameterDirection.Input
                prrr(5).Value = Format(Now.Date, "dd/MMM/yyyy")

                prrr(6) = New OracleParameter
                prrr(6).ParameterName = "movid"
                prrr(6).OracleType = OracleType.Number
                prrr(6).Direction = ParameterDirection.Input
                prrr(6).Value = tr(22)



                'prrr(6) = New OracleParameter
                'prrr(6).ParameterName = "mov_id"
                'prrr(6).OracleType = OracleType.Number
                'prrr(6).Direction = ParameterDirection.Input
                'prrr(6).Value = arr(11)





                If oh.ExecuteNonQuery(sq178, prrr) Then

                    'Dim wgate As DataTable = oh.ExecuteDataSet("select query from hrm_report_master where query_id=165 and firm_id=99").Tables(0)

                    'If wgate.Rows.Count > 0 Then
                    '    Dim ResponseString = ""
                    '    Dim reqstring As String = ""
                    '    Dim responseS As HttpWebResponse = Nothing
                    '    Dim hima As String = "select to_char(to_date('" & Format(CDate(Me.Txt_fdt.Text), "dd/MMM/yyyy") & "'),'dd-mm-yyyy')from dual"
                    '    dap = oh.ExecuteDataSet(hima).Tables(0)
                    '    Try
                    '        Dim request As HttpWebRequest
                    '        reqstring = wgate.Rows(0)(0).ToString.Split("@")(0).Replace("mycode", arr1(0))
                    '        reqstring = reqstring.Replace("myreqdate", dap.Rows(0)(0))
                    '        reqstring = reqstring.Replace("myextime", arr(6))
                    '        reqstring = reqstring.Replace("myentime", arr(7))
                    '        request = WebRequest.Create(reqstring)
                    '        request.Accept = "application/json" '"application/xml";
                    '        request.Method = "GET"
                    '        request.ContentType = "application/json"
                    '        responseS = CType(request.GetResponse(), HttpWebResponse)
                    '        Dim responseStream As New StreamReader(responseS.GetResponseStream())
                    '        ResponseString = responseStream.ReadToEnd
                    '    Catch ex As WebException
                    '        responseS = CType(ex.Response, HttpWebResponse)
                    '        ResponseString = "Some error occured: " & responseS.StatusCode.ToString()
                    '        ResponseString = ResponseString & ex.Status.ToString()
                    '    End Try
                    'End If

                    Dim cl_scrip1 As New StringBuilder
                    cl_scrip1.Append("   alert('Rejected Successfully') ;")
                    cl_scrip1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                    'Me.btn_reject.Enabled = False
                End If


                Me.Txt_emp.Value = ""
                Me.Txt_dep.Value = ""
                Me.Txt_des.Value = ""
                Me.Txt_br.Value = ""
                Me.Txt_fdt.Text = ""
                Me.Txt_From.Text = ""
                Me.Txt_post.Value = ""
                Me.Txt_purp.Text = ""
                Me.Txt_To.Text = ""
                Me.Textplace.Value = ""
                Me.Text_RJTRSN.Text = ""



            Catch ex As Exception

                Dim cl_script1 As New System.Text.StringBuilder
                cl_script1.Append("                        alert('Error. please check the values entered..');")
                'cl_script1.Append("window.open('Movement_Recommend_Macom.aspx','_self');")

                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

            End Try

        End If
    End Sub

    Protected Sub Cmd_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Response.Redirect("~/home.aspx")
    End Sub
End Class

