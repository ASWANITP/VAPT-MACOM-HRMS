Imports System.Data
Imports System.Data.OracleClient
Partial Class disciplinary_Default_4163af6f5212
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper


    Dim dt1, dt2, dt3, dt4, dt5 As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            Dim empcode As Int32 = Request.QueryString.Get("Emp_ID")
            Dim sts As Int32 = Request.QueryString.Get("Stat")
            If sts = 1 Then

                Dim sd As String = "select t.showattachment,e.emp_code, t.showcauseattachname from DISCIPLINARY_DTL t, employee_master e where t.emp_code=e.emp_code and t.emp_code=" & empcode & ""

                dt2 = oh.ExecuteDataSet(sd).Tables(0)
            Else
                Dim sd As String = "select t.attachment,e.emp_code, t.SHOWCAUSERPLYATTACHNAME from DISCIPLINARY_DTL t, employee_master e where t.emp_code=e.emp_code and t.emp_code=" & empcode & ""
                dt2 = oh.ExecuteDataSet(sd).Tables(0)
            End If


            If Not (IsDBNull(dt2.Rows(0)(0))) Then

                Dim imgURLtoDownload As String = dt2.Rows(0)(2).ToString()
                Dim bl() As Byte
                bl = CType(dt2.Rows(0)(0), Byte())
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
        Catch
            Response.Write("<script language=javascript>alert('No docs Available');</script>")
        End Try


    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If Me.CheckBox1.checked = True Then
    '        Dim sd As String = "select t.showattachment,e.emp_code, t.SHOWCAUSERPLYATTACHNAME from DISCIPLINARY_DTL t, employee_master e where t.emp_code=e.emp_code and t.emp_code=" & Me.TextBox1.Text & ""
    '        dt2 = oh.ExecuteDataSet(sd).Tables(0)


    '        'prr(1).Parameters.AddWithValue("id", Gridallemp.SelectedRow.Cells(1).Text)

    '        'Dim dr As OracleDataReader = oh.ExecuteReader()
    '        Dim dr As OracleDataReader = oh.ExecuteReader(sd)
    '        'Dim type As String = dt1.Rows(0)(0).Split(".")
    '        If dr.Read() Then
    '            Response.Clear()
    '            Response.Buffer = True
    '            'Response.ContentType = dr("type").ToString()
    '            Response.AddHeader("content-disposition", "attachment;filename=" & dr("SHOWCAUSEATTACHNAME").ToString())
    '            Response.Charset = ""
    '            Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '            Response.BinaryWrite(CType(dr("attachment"), Byte()))
    '            Response.[End]()
    '        End If
    '    End If
    '    If Me.CheckBox2.Checked = True Then
    '        Dim sd As String = "select t.showattachment,e.emp_code, t.SHOWCAUSERPLYATTACHNAME from DISCIPLINARY_DTL t, employee_master e where t.emp_code=e.emp_code and t.emp_code=" & Me.TextBox1.Text & ""

    '        dt2 = oh.ExecuteDataSet(sd).Tables(0)


    '        'prr(1).Parameters.AddWithValue("id", Gridallemp.SelectedRow.Cells(1).Text)

    '        'Dim dr As OracleDataReader = oh.ExecuteReader()
    '        Dim dr As OracleDataReader = oh.ExecuteReader(sd)
    '        'Dim type As String = dt1.Rows(0)(0).Split(".")
    '        If dr.Read() Then
    '            Response.Clear()
    '            Response.Buffer = True
    '            'Response.ContentType = dr("type").ToString()
    '            Response.AddHeader("content-disposition", "attachment;filename=" & dr("SHOWCAUSERPLYATTACHNAME").ToString())
    '            Response.Charset = ""
    '            Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '            Response.BinaryWrite(CType(dr("showattachment"), Byte()))
    '            Response.[End]()
    '        End If
    '    End If
    'End Sub




End Class