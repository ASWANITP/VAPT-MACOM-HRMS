Imports System.Data
Imports System.Data.OracleClient
Partial Class new_approve_resign_7506ce352995
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim brhd, dtfill, chkuser, depbr, depbr1, empz, depbr2, reldt, hh, hhpst, hhdep, hhmd, depbrs, hhrea, hdh, dt1, dt2, dt3, dt As DataTable
    Dim branchheadg As Integer
    Dim branchheadl As Integer
    Dim lap As Integer
    Dim brch As Integer
    Dim gsm As Integer
    Dim mia As Integer
    Dim mds As Integer
    Dim mdm As Integer
    Dim alls() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ip As String = Me.Context.Request.UserHostAddress
        Dim fid As Integer = Session("firm_id")
        Dim usrs() As String
        usrs = Me.Session("user_id").ToString.Split("!")
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
            alls = dt.Rows(0)(0).ToString.Split("$")
            hhpst = oh.ExecuteDataSet(alls(5).Replace("mycode", usrs(0))).Tables(0)
            hhdep = oh.ExecuteDataSet(alls(6).Replace("mycode", usrs(0))).Tables(0)


            If hhpst.Rows(0)(0) = 0 AndAlso hhdep.Rows(0)(0) = 0 Then
                Me.Server.Transfer("../../show_err.aspx")
            Else
                Dim qurys As String = ""
                If hhpst.Rows(0)(0) > 0 Then
                    qurys = alls(7).Replace("mycode", usrs(0))
                Else
                    qurys = alls(8).Replace("mycode", usrs(0))
                End If
                hh = oh.ExecuteDataSet(qurys).Tables(0)
                Me.drop.DataSource = hh
                Me.drop.DataTextField = hh.Columns(0).ColumnName
                Me.drop.DataValueField = hh.Columns(1).ColumnName
                Me.drop.DataBind()
            End If
        End If
    End Sub
    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        If Me.drop.SelectedValue = -1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Select any Employee');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
        Dim usrs() As String
        usrs = Me.Session("user_id").ToString.Split("!")
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        hhpst = oh.ExecuteDataSet(alls(5).Replace("mycode", usrs(0))).Tables(0)
        hhdep = oh.ExecuteDataSet(alls(6).Replace("mycode", usrs(0))).Tables(0)

        If hhpst.Rows(0)(0) > 0 Then
            hhrea = oh.ExecuteDataSet(alls(9).Replace("mycode", Me.drop.SelectedValue)).Tables(0)
            Dim up As String
            up = alls(10).Replace("mycode", Me.drop.SelectedValue)
            oh.ExecuteNonQuery(up)
            If hhrea.Rows(0)(0) = 1 Then
                Dim up1 As String
                up1 = alls(11).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            ElseIf hhrea.Rows(0)(0) = 2 Then
                Dim up1 As String
                up1 = alls(12).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            ElseIf hhrea.Rows(0)(0) = 3 Then
                Dim up1 As String
                up1 = alls(13).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            ElseIf hhrea.Rows(0)(0) = 4 Then
                Dim up1 As String
                up1 = alls(14).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            ElseIf hhrea.Rows(0)(0) = 5 Then
                Dim up1 As String
                up1 = alls(15).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            End If
            Dim qurys = alls(16).Replace("mycode", usrs(0))
            hh = oh.ExecuteDataSet(qurys).Tables(0)
            Me.drop.DataSource = hh
            Me.drop.DataTextField = hh.Columns(0).ColumnName
            Me.drop.DataValueField = hh.Columns(1).ColumnName
            Me.drop.DataBind()
            Me.Txt_rdt.Text = ""
            Me.Txt_rea.Text = ""
            Me.lbl_name.Text = ""
            Me.lbl_code.Text = ""

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Successfully recommended by Tech Lead..');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        ElseIf hhdep.Rows(0)(0) > 0 Then
            hhrea = oh.ExecuteDataSet(alls(17).Replace("mycode", Me.drop.SelectedValue)).Tables(0)
            Dim up As String
            up = alls(18).Replace("mycode", Me.drop.SelectedValue)
            oh.ExecuteNonQuery(up)
            If hhrea.Rows(0)(0) = 1 Then
                Dim up1 As String
                up1 = alls(19).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            ElseIf hhrea.Rows(0)(0) = 2 Then
                Dim up1 As String
                up1 = alls(20).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            ElseIf hhrea.Rows(0)(0) = 3 Then
                Dim up1 As String
                up1 = alls(21).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            ElseIf hhrea.Rows(0)(0) = 4 Then
                Dim up1 As String
                up1 = alls(22).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            ElseIf hhrea.Rows(0)(0) = 5 Then
                Dim up1 As String
                up1 = alls(23).Replace("mycode", Me.drop.SelectedValue)
                oh.ExecuteNonQuery(up1)
            End If
            Dim qurys = alls(24).Replace("mycode", usrs(0))
            hh = oh.ExecuteDataSet(qurys).Tables(0)
            Me.drop.DataSource = hh
            Me.drop.DataTextField = hh.Columns(0).ColumnName
            Me.drop.DataValueField = hh.Columns(1).ColumnName
            Me.drop.DataBind()
            Me.Txt_rdt.Text = ""
            Me.Txt_rea.Text = ""
            Me.lbl_name.Text = ""
            Me.lbl_code.Text = ""
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Successfully recommended by Department Head..');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub

    Protected Sub drop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drop.SelectedIndexChanged
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        If Me.drop.SelectedValue = -1 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Select any Employee');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If
        Dim usr() As String
        usr = Me.Session("user_id").ToString.Split("!")
        empz = oh.ExecuteDataSet(alls(25).Replace("mycode", Me.drop.SelectedValue)).Tables(0)
        Me.lbl_name.Text = empz.Rows(0)(0)
        Me.lbl_code.Text = empz.Rows(0)(1)
        depbr = oh.ExecuteDataSet(alls(26).Replace("mycode", Me.drop.SelectedValue)).Tables(0)
        depbr1 = oh.ExecuteDataSet(alls(27).Replace("mycode", Me.drop.SelectedValue)).Tables(0)
        depbr2 = oh.ExecuteDataSet(alls(28).Replace("mycode", Me.drop.SelectedValue)).Tables(0)
        If depbr.Rows.Count > 0 Then
            Me.Txt_rdt.Text = Format(CDate(depbr.Rows(0)(0)), "dd/MMM/yyyy")
            Me.Txt_rea.Text = depbr.Rows(0)(1)
        ElseIf depbr1.Rows.Count > 0 Then
            Me.Txt_rdt.Text = depbr1.Rows(0)(0)
            Me.Txt_rea.Text = depbr1.Rows(0)(1)
        ElseIf depbr2.Rows.Count > 0 Then
            Me.Txt_rdt.Text = depbr2.Rows(0)(0)
            Me.Txt_rea.Text = depbr2.Rows(0)(1)
        End If
    End Sub

    Protected Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Dim usrs() As String
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        usrs = Me.Session("user_id").ToString.Split("!")
        Dim qurys = alls(29).Replace("mycode", usrs(0))
        hh = oh.ExecuteDataSet(qurys).Tables(0)
        Me.drop.DataSource = hh
        Me.drop.DataTextField = hh.Columns(0).ColumnName
        Me.drop.DataValueField = hh.Columns(1).ColumnName
        Me.drop.DataBind()
    End Sub

    Protected Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Dim usrs() As String
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        usrs = Me.Session("user_id").ToString.Split("!")
        Dim qurys = alls(30).Replace("mycode", usrs(0))
        hdh = oh.ExecuteDataSet(qurys).Tables(0)
        Me.drop.DataSource = hdh
        Me.drop.DataTextField = hdh.Columns(0).ColumnName
        Me.drop.DataValueField = hdh.Columns(1).ColumnName
        Me.drop.DataBind()
    End Sub

    Protected Sub cmd_att_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_att.ServerClick
        dt = oh.ExecuteDataSet("select t.query from hrm_report_master t where t.query_id=121 and t.firm_id=99").Tables(0)
        alls = dt.Rows(0)(0).ToString.Split("$")
        Dim dt6 As DataTable = oh.ExecuteDataSet(alls(31).Replace("mycode", Me.drop.SelectedValue)).Tables(0)
        If dt6.Rows(0)(0) = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            Dim c1_script2 As New System.Text.StringBuilder
            cl_script1.Append("        alert('No Resignation Letter Attached');")
            c1_script2.Append("  (only jpg allowed);")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        Else
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("        alert('Verify Resignation Letter');")
            cl_script1.Append("window.open('resign_attach.aspx?empid=" & Me.drop.SelectedValue & "');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
        End If
    End Sub
End Class
