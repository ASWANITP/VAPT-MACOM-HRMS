Imports System.Data
Imports System.Data.OracleClient
Partial Class Regularisation_Regularisation_Approval_242ed0d59417
    Inherits System.Web.UI.Page
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dts, dtts As New DataTable
    Dim us, res, sql, str As String

    Dim strResult As New System.Text.StringBuilder
    Dim str_tkn As New System.Text.StringBuilder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)

        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select t.emp_id from FORM_ACCESSIBILITY t where t.form_id=5212 and t.emp_id=" & User(0) & "").Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dt As DataTable = oh.ExecuteDataSet("select 0 ecode, '-----------SELECT-----------' as emp from dual union select e.emp_code,e.emp_code || '-' || s.emp_name from TBL_REGULARISATION e,employee_master s,employ_firm f where e.emp_code=s.emp_code and e.emp_code=f.emp_code and e.status=3 order by ecode").Tables(0)
                If dt.Rows.Count >= 1 Then
                    Me.drpdwn_employee.DataSource = dt
                    Me.drpdwn_employee.DataTextField = dt.Columns(1).ColumnName
                    Me.drpdwn_employee.DataValueField = dt.Columns(0).ColumnName
                    Me.drpdwn_employee.DataBind()
                Else
                    Dim cl_script1 As New System.Text.StringBuilder
                    cl_script1.Append("         alert('No Data Found!!!!');")
                    cl_script1.Append("window.open('Regularisation_Approval.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
                End If

            Else
                Me.Server.Transfer("../show_err.aspx")
            End If
        End If
    End Sub

    Protected Sub drpdwn_employee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpdwn_employee.SelectedIndexChanged


        dt1 = oh.ExecuteDataSet("select '--------SELECT---------'as dt from dual union select trim(t.apply_dt) from tbl_regularisation t where t.emp_code=" & Me.drpdwn_employee.SelectedValue & " and t.status=3").Tables(0)


        If dt1.Rows.Count >= 1 Then
            Me.Ddldate.DataSource = dt1
            Me.Ddldate.DataValueField = dt1.Columns(0).ColumnName
            Me.Ddldate.DataBind()
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No Data Found!!!!');")
            cl_script1.Append("window.open('Regularisation_Approval.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub

    Protected Sub btn_dwnlod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_dwnlod.Click
        Dim s1d As String = "select h.name1,h.data from  TBL_REGULARISATION h where h.emp_code=" & Me.drpdwn_employee.SelectedValue & " and to_date(h.apply_dt)='" & Me.Ddldate.SelectedValue & "'"
        dt1 = oh.ExecuteDataSet(s1d).Tables(0)
        'Dim dr As OracleDataReader = oh.ExecuteReader(s1d)

        'If dr.Read() Then
        '    Response.Clear()
        '    Response.Buffer = True

        '    Response.AddHeader("content-disposition", "attachment;filename=" & dr("name1").ToString())
        '    Response.Charset = ""
        '    Response.Cache.SetCacheability(HttpCacheability.NoCache)
        '    Response.BinaryWrite(CType(dr("data"), Byte()))
        '    Response.[End]()
        'End If

        If Not (IsDBNull(dt1.Rows(0)(1))) Then


            'Dim imgURLtoDownload As String = "img/" + dt1.Rows(0)(1).ToString()
            Dim imgURLtoDownload As String = "img.pdf/"
            Dim bl() As Byte
            bl = CType(dt1.Rows(0)(1), Byte())
            Response.ClearContent()
            Response.ClearHeaders()

            Response.ClearHeaders()
            Response.ClearContent()
            Response.ContentType = "application/octet-stream"
            Response.ContentEncoding = Encoding.UTF8
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + imgURLtoDownload)
            Response.AppendHeader("Content-Length", CStr(bl.Length))
            Response.OutputStream.Write(bl, 0, bl.Length)
            Response.Flush()
            Response.End()

        Else
            Response.Write("<script language=javascript>alert('No docs Available');</script>")
        End If


    End Sub

    Protected Sub btn_recommend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_recommend.Click
        If Me.drpdwn_employee.SelectedIndex = -1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Employee');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf Me.Ddldate.SelectedIndex = -1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Select Date');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        ElseIf Me.txt_recom_reason.Text = "" Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('Please Enter Reason');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        Else

            Try


                Dim User() As String = Session("user_id").ToString.Split("!")
                Dim UserId As Integer = User(0)


                ''''new
                Dim sq178 As String = "UPDATE attend h set h.pay_id=:payid where h.curr_date=:appdate1 and h.emp_code=:code"
                Dim prrr(2) As OracleParameter


                prrr(0) = New OracleParameter
                prrr(0).ParameterName = "code"
                prrr(0).OracleType = OracleType.Number
                prrr(0).Direction = ParameterDirection.Input
                prrr(0).Value = Me.drpdwn_employee.SelectedValue

                prrr(1) = New OracleParameter
                prrr(1).ParameterName = "appdate1"
                prrr(1).OracleType = OracleType.DateTime
                prrr(1).Direction = ParameterDirection.Input
                prrr(1).Value = Me.Ddldate.SelectedValue

                dtts = oh.ExecuteDataSet("select r.mreg,r.evngreg from tbl_regularisation r where r.emp_code=" & Me.drpdwn_employee.SelectedValue & " and to_date(r.apply_dt)='" & Me.Ddldate.SelectedValue & "'").Tables(0)
                If dtts.Rows(0)(0) = 1 Then

                    prrr(2) = New OracleParameter
                    prrr(2).ParameterName = "payid"
                    prrr(2).OracleType = OracleType.Number
                    prrr(2).Direction = ParameterDirection.Input
                    prrr(2).Value = 50
                End If

                If dtts.Rows(0)(1) = 1 Then

                    prrr(2) = New OracleParameter
                    prrr(2).ParameterName = "payid"
                    prrr(2).OracleType = OracleType.Number
                    prrr(2).Direction = ParameterDirection.Input
                    prrr(2).Value = 51
                End If

                If dtts.Rows(0)(0) = 1 And dtts.Rows(0)(1) = 1 Then

                    prrr(2) = New OracleParameter
                    prrr(2).ParameterName = "payid"
                    prrr(2).OracleType = OracleType.Number
                    prrr(2).Direction = ParameterDirection.Input
                    prrr(2).Value = 52
                End If


                oh.ExecuteNonQuery(sq178, prrr)
                ''''''


                Dim sq17 As String = "UPDATE tbl_regularisation h set h.app_person= :appcode,h.status=:status,h.app_remarks=:remarks,h.app_date=:appdt,h.pay_id=:payid where h.apply_dt=:appdate1 and h.emp_code=:code"
                Dim prr(6) As OracleParameter

                prr(0) = New OracleParameter
                prr(0).ParameterName = "code"
                prr(0).OracleType = OracleType.Number
                prr(0).Direction = ParameterDirection.Input
                prr(0).Value = Me.drpdwn_employee.SelectedValue


                prr(1) = New OracleParameter
                prr(1).ParameterName = "remarks"
                prr(1).OracleType = OracleType.VarChar
                prr(1).Direction = ParameterDirection.Input
                prr(1).Value = Me.txt_recom_reason.Text

                prr(2) = New OracleParameter
                prr(2).ParameterName = "status"
                prr(2).OracleType = OracleType.VarChar
                prr(2).Direction = ParameterDirection.Input
                prr(2).Value = 1

                prr(3) = New OracleParameter
                prr(3).ParameterName = "appdt"
                prr(3).OracleType = OracleType.DateTime
                prr(3).Direction = ParameterDirection.Input
                prr(3).Value = Format(Now.Date, "dd/MMM/yyyy")

                prr(4) = New OracleParameter
                prr(4).ParameterName = "appcode"
                prr(4).OracleType = OracleType.Number
                prr(4).Direction = ParameterDirection.Input
                prr(4).Value = UserId

                prr(5) = New OracleParameter
                prr(5).ParameterName = "appdate1"
                prr(5).OracleType = OracleType.DateTime
                prr(5).Direction = ParameterDirection.Input
                prr(5).Value = Me.Ddldate.SelectedValue

                dts = oh.ExecuteDataSet("select r.mreg,r.evngreg from tbl_regularisation r where r.emp_code=" & Me.drpdwn_employee.SelectedValue & " and to_date(r.apply_dt)='" & Me.Ddldate.SelectedValue & "'").Tables(0)
                If dts.Rows(0)(0) = 1 Then

                    prr(6) = New OracleParameter
                    prr(6).ParameterName = "payid"
                    prr(6).OracleType = OracleType.Number
                    prr(6).Direction = ParameterDirection.Input
                    prr(6).Value = 50
                End If

                If dts.Rows(0)(1) = 1 Then

                    prr(6) = New OracleParameter
                    prr(6).ParameterName = "payid"
                    prr(6).OracleType = OracleType.Number
                    prr(6).Direction = ParameterDirection.Input
                    prr(6).Value = 51
                End If

                If dts.Rows(0)(0) = 1 And dts.Rows(0)(1) = 1 Then

                    prr(6) = New OracleParameter
                    prr(6).ParameterName = "payid"
                    prr(6).OracleType = OracleType.Number
                    prr(6).Direction = ParameterDirection.Input
                    prr(6).Value = 52
                End If

                If oh.ExecuteNonQuery(sq17, prr) Then


                    Dim cl_scrip1 As New StringBuilder
                    cl_scrip1.Append("   alert('Approved Successfully') ;")
                    cl_scrip1.Append("window.open('Regularisation_Approval.aspx','_self');")
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                    Me.btn_reject.Enabled = False
                End If


                Me.txt_recom_reason.Text = ""

                Me.TextBox2.Text = ""
                Me.TextBox3.Text = ""
                Me.TextBox4.Text = ""
                Me.TextBox4.Text = ""
                Me.TextBox5.Text = ""




            Catch ex As Exception
                Dim cl_script11 As New System.Text.StringBuilder
                cl_script11.Append("        alert('Please try later');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script11.ToString, True)
            End Try
        End If

    End Sub

    Protected Sub btn_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reject.Click
        Try


            Dim User() As String = Session("user_id").ToString.Split("!")
            Dim UserId As Integer = User(0)

            Dim sq17 As String = "UPDATE tbl_regularisation h set h.rej_pers= :rejcode,h.status=:status,h.rej_reas=:remarks,h.rej_dt=:rejdt where h.apply_dt=:appdate1 and h.emp_code=:code"
            Dim prr(5) As OracleParameter

            prr(0) = New OracleParameter
            prr(0).ParameterName = "code"
            prr(0).OracleType = OracleType.Number
            prr(0).Direction = ParameterDirection.Input
            prr(0).Value = Me.drpdwn_employee.SelectedValue


            prr(1) = New OracleParameter
            prr(1).ParameterName = "remarks"
            prr(1).OracleType = OracleType.VarChar
            prr(1).Direction = ParameterDirection.Input
            prr(1).Value = Me.txt_recom_reason.Text

            prr(2) = New OracleParameter
            prr(2).ParameterName = "status"
            prr(2).OracleType = OracleType.VarChar
            prr(2).Direction = ParameterDirection.Input
            prr(2).Value = 2

            prr(3) = New OracleParameter
            prr(3).ParameterName = "rejdt"
            prr(3).OracleType = OracleType.DateTime
            prr(3).Direction = ParameterDirection.Input
            prr(3).Value = Format(Now.Date, "dd/MMM/yyyy")

            prr(4) = New OracleParameter
            prr(4).ParameterName = "rejcode"
            prr(4).OracleType = OracleType.Number
            prr(4).Direction = ParameterDirection.Input
            prr(4).Value = UserId

            prr(5) = New OracleParameter
            prr(5).ParameterName = "appdate1"
            prr(5).OracleType = OracleType.DateTime
            prr(5).Direction = ParameterDirection.Input
            prr(5).Value = Me.Ddldate.SelectedValue

            If oh.ExecuteNonQuery(sq17, prr) Then


                Dim cl_scrip1 As New StringBuilder
                cl_scrip1.Append("   alert('Application Successfully Rejected') ;")
                cl_scrip1.Append("window.open('Regularisation_Approval.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_scrip1.ToString, True)
                Me.btn_reject.Enabled = False
            End If


            Me.txt_recom_reason.Text = ""

            Me.TextBox2.Text = ""
            Me.TextBox3.Text = ""
            Me.TextBox4.Text = ""
            Me.TextBox4.Text = ""
            Me.TextBox5.Text = ""




        Catch ex As Exception

        End Try
    End Sub



    Protected Sub Ddldate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ddldate.SelectedIndexChanged

        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User(0)
        dt1 = oh.ExecuteDataSet("select t.emp_code, e.emp_name, a.m_time, a.e_time,g.emp_name from tbl_regularisation t, employee_master e, attend a,employee_master g where t.emp_code = e.emp_code and t.emp_code = a.emp_code and to_date(t.apply_dt) = to_date(a.curr_date) and g.emp_code=t.rec_person and t.status = 3 and to_date(t.apply_dt) = '" & Me.Ddldate.SelectedValue & "' and t.emp_code = " & Me.drpdwn_employee.SelectedValue & "").Tables(0)

        If dt1.Rows.Count >= 1 Then
            Me.TextBox2.Text = dt1.Rows(0)(0)
            Me.TextBox3.Text = dt1.Rows(0)(1)
            Me.TextBox4.Text = dt1.Rows(0)(2)
            Me.TextBox5.Text = dt1.Rows(0)(3)
            Me.Txtrec.Text = dt1.Rows(0)(4)
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No Data Found!!!!');")
            cl_script1.Append("window.open('Regularisation_Approval.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub
End Class



