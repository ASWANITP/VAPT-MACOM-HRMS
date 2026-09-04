Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_HRM_LEAVE_APPLICATION_6af975976451
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim str_tkn As New System.Text.StringBuilder
    Dim dt, dt1 As New DataTable
    Dim CbResult As String = Nothing
    Dim Radio1, Radio2, Radio3 As String
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("firm_id") = 27 Then
            Server.Transfer("~/leave/leave application/leave_apply_report.aspx")
        End If
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "LEAVE APPLICATION FORM"
     
        Dim User() As String
        User = Session("user_id").ToString.Split("!")

        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_Apply.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        If Not IsPostBack Then
            dt = oh.ExecuteDataSet("select h.leave_seq,h.leave_frdate||'/'||h.leave_todate||'/'||decode (h.leave_id,1,'CASUAL',2,'SICK',3,'EARNED',4,'LOP')||'/'||h.leave_days||'/'||h.leave_apply_date from hrm_leave_apply_sanction h where h.emp_code='" & User(0) & "'  and h.status_id in (0,4,5)").Tables(0)
            If dt.Rows.Count > 0 Then
                Me.cmb_Select.DataSource = dt
                Me.cmb_Select.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_Select.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_Select.DataBind()

                dt1 = oh.ExecuteDataSet("select h.leave_seq,to_char(to_date(h.leave_frdate),'DD/MON/yyyy'),to_char(to_date(h.leave_todate),'DD/MON/yyyy'),decode (h.leave_id,1,'CASUAL',2,'SICK',3,'EARNED',4,'LOP'),h.leave_days,to_char(to_date(h.leave_apply_date),'DD/MON/yyyy') from hrm_leave_apply_sanction h where h.emp_code='" & User(0) & "'  and h.leave_seq='" & dt.Rows(0)(0) & "'and h.status_id in (0,4,5)").Tables(0)
                If dt1.Rows.Count > 0 Then
                    Me.txt_From.Text = dt1.Rows(0)(1)
                    Me.txt_To.Text = dt1.Rows(0)(2)
                    Me.txt_Type.Text = dt1.Rows(0)(3)
                    Me.txt_Days.Text = dt1.Rows(0)(4)
                    Me.txt_Apply.Text = dt1.Rows(0)(5)
                End If
            Else
                Dim cl_script As New StringBuilder
                cl_script.Append("   alert('YOU HAVE NO LEAVE FOR SANCTION') ;")
                cl_script.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script.ToString, True)

            End If

        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim Datastr() As String
        Datastr = eventArgument.Split("#")
        Select Case (Datastr(1))
            Case 1
                Dim Instr() As String = Datastr(0).Split("%")
                Dim CODE As String = Instr(0)
                Try
                    Dim sql1 As String
                    sql1 = "select to_char(to_date(h.leave_frdate),'DD/MON/yyyy'),to_char(to_date(h.leave_todate),'DD/MON/yyyy'),decode (h.leave_id,1,'CASUAL',2,'SICK',3,'EARNED',4,'LOP'),h.leave_days,to_char(to_date(h.leave_apply_date),'DD/MON/yyyy') from hrm_leave_apply_sanction h where  h.leave_seq='" & CODE & "'and h.status_id in (0,4)"
                    dt = oh.ExecuteDataSet(sql1).Tables(0)
                Catch ex As Exception
                    str_tkn.Append(ex.Message)
                Finally
                End Try
                If dt.Rows.Count <> 0 Then
                    str_tkn.Append(dt.Rows(0)(0))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(1))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(2))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(3))
                    str_tkn.Append("!")
                    str_tkn.Append(dt.Rows(0)(4))
                End If
                str_tkn.Append("@")
                str_tkn.Append("2")
                CbResult = str_tkn.ToString
        End Select
    End Sub

    Protected Sub cmd_form_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
