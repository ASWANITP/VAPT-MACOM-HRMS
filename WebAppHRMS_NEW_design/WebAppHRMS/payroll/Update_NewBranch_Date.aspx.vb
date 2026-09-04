Imports System.Data
Imports System.Data.OracleClient
Partial Class EXTRAFORMS_Update_NewBranch_Date_f1df9c845687
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim CbResult As String = Nothing
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CType(Me.Master, WebAppHRMS.edp).Subtitle = "NEW BRANCH DATE UPDATION"
        Dim masterPage As WebAppHRMS.edp = CType(Me.Master, WebAppHRMS.edp)
        masterPage.subtitle = "NEW BRANCH DATE UPDATION"
        Dim BranchID As Integer = CInt(Session("branch_id"))
        If BranchID <> 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('Please Login in Head Office!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
        '---------Script Registration--------'
        Dim script_val As String
        script_val = "var loanno;" & "loanno='" & "" & Me.txt_Date.ClientID & "'" & " ; "
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        '--------------------------------------'
        '/--- For Call Back ---//
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)

        Me.lblDate.Text = "Tendative"
        Me.rbt_Tendative.Checked = True
        Me.rbt_Confirmation.Attributes.Add("onclick", "OnClickRadioConfirm()")
        Me.rbt_Tendative.Attributes.Add("onclick", "OnClickRadioTendative()")
        Me.txt_Date.Attributes.Add("onkeyup", "OnkeyUpChqDate('txt_Date')")
        If Not IsPostBack Then
            sql = "select count(a.branch_name)from before_completion a where a.old_id<0 and a.branch_id is null"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            If dt.Rows(0)(0) = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('No Branches for Updation....!!!!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
                Exit Sub
            End If
            If Me.rbt_Tendative.Checked = True Then
                dt = oh.ExecuteDataSet("select a.old_id,a.branch_name from before_completion a where a.old_id<0 and a.branch_id is null and a.tendative_dt is null and a.confirm_dt is null order by a.branch_name").Tables(0)
                Me.cmb_Branch.DataSource = dt
                Me.cmb_Branch.DataTextField = dt.Columns(1).ColumnName
                Me.cmb_Branch.DataValueField = dt.Columns(0).ColumnName
                Me.cmb_Branch.DataBind()
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
                If (Datastr(0) = "-11") Then
                    dt = oh.ExecuteDataSet("select a.old_id,a.branch_name from before_completion a where a.old_id<0 and a.branch_id is null and a.tendative_dt is null and a.confirm_dt is null order by a.branch_name").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"
                ElseIf (Datastr(0) = "-22") Then
                    dt = oh.ExecuteDataSet("select a.old_id,a.branch_name from before_completion a where a.old_id<0 and a.branch_id is null and a.tendative_dt is not null and a.confirm_dt is null order by a.branch_name").Tables(0)
                    CbResult = FillData(CbResult, dt)
                    CbResult = CbResult + "@"
                End If
            Case 2
                ' EffDate+"%"+OldId+"%"+Status  #  2
                Dim Instr() As String = Datastr(0).Split("%")
                Dim EffDate As String = Instr(0)
                Dim OldId As Integer = Instr(1)
                Dim Status As Integer = Instr(2)
                'If OldId = "" Then
                '    CbResult = "No Branch to Update...!!!"
                'End IfFormat(Date.Today, "dd/MMM/yyyy")
                Try
                    If (Status = 1) Then
                        oh.ExecuteNonQuery("UPDATE before_completion t SET t.tendative_dt='" & EffDate & "' where t.old_id=" & OldId & "")
                        CbResult = "Successfully Updated...!!!"
                    Else
                        oh.ExecuteNonQuery("UPDATE before_completion t set t.confirm_dt='" & EffDate & "' where t.old_id=" & OldId & "")
                        CbResult = "Successfully Updated...!!!"
                    End If
                Catch ex As Exception
                    CbResult = ex.Message
                End Try

        End Select
    End Sub
    Public Function FillData(ByVal cbResult As String, ByVal DT As DataTable) As String
        For n As Integer = 0 To DT.Rows.Count - 1
            cbResult += DT.Rows(n)(0).ToString
            cbResult += "$"
            cbResult += DT.Rows(n)(1).ToString
            If n < DT.Rows.Count - 1 Then
                cbResult += "█"
            End If
        Next
        Return cbResult
    End Function
End Class
