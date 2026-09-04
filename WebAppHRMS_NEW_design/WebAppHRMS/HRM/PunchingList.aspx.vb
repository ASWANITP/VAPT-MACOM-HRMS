Imports System.Data.OracleClient
Imports System.Data
Partial Class HRM_PunchingList_c0bdebd64254
    Inherits System.Web.UI.Page
    Implements Web.UI.ICallbackEventHandler
    Dim CSETTINGS As New customSettings.reportSettings
    Dim TABLE As New Table
    Dim DTABLE As New DataTable
    Dim dt As New DataTable
    Dim OHELPER As New Helper.Oracle.OracleHelper
    Dim DROW As DataRow
    Dim str_tkn As New System.Text.StringBuilder
    Dim CbResult As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "FromServer", "context", True)
        Dim cbscript As String = "function ToServer (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "ToServer", cbscript, True)
        Dim TrainId As Integer = Request.QueryString("TrainId")
        Dim QUERY As String = "select distinct tpd.participant_id as EMPLOYEECODE,em.emp_name,td.from_time,td.to_time PARTICIPANTNAME from training_participant_dtl tpd,training_dtl td,employee_master em where td.training_id=" & TrainId & " and td.training_id>0 and td.training_id=tpd.training_id and to_date(sysdate) between td.training_from and td.training_to and em.emp_code=tpd.participant_id and tpd.status in ('3','11') order by em.emp_name"
        DTABLE = OHELPER.ExecuteDataSet(QUERY).Tables(0)
        CSETTINGS.RTHeading("EMPLOYEE PUNCHING LIST", TABLE, Session("firm_name"), Session("branch_id"), Session("branch_name"), 30)
        CSETTINGS.RTLine(TABLE, 30)
        Dim ROW_1 As New TableRow
        Dim CELL_11, CELL_12, CELL_13, CELL_14, CELL_15, CELL_16 As New TableCell
        With CSETTINGS
            .RTData(ROW_1, CELL_11, 5, 5, "CENTER", "SLNO", 2)
            .RTData(ROW_1, CELL_12, 5, 5, "CENTER", "EMPLOYEE&nbsp;CODE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", 2)
            .RTData(ROW_1, CELL_13, 25, 5, "LEFT", "PARTICIPANT NAME", 2)
            .RTData(ROW_1, CELL_14, 5, 5, "CENTER", "&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;TIME&nbsp;&nbsp;&nbsp;&nbsp;", 2)
            .RTData(ROW_1, CELL_15, 5, 5, "CENTER", "&nbsp;&nbsp;&nbsp;&nbsp;TO&nbsp;TIME&nbsp;&nbsp;&nbsp;&nbsp;", 2)
            .RTData(ROW_1, CELL_16, 25, 5, "LEFT", "ABSENT REASON", 2)
        End With
        CSETTINGS.RTEmptyLine(TABLE)
        TABLE.Controls.Add(ROW_1)
        If DTABLE.Rows.Count = 0 Then
            Dim ROW_0 As New TableRow
            Dim CELL_01, CELL_02 As New TableCell
            CSETTINGS.RTEmptyLine(TABLE)
            CSETTINGS.RTEmptyLine(TABLE)
            CSETTINGS.RTEmptyLine(TABLE)
            CSETTINGS.RTEmptyLine(TABLE)
            CSETTINGS.RTEmptyLine(TABLE)
            CSETTINGS.RTData(ROW_0, CELL_02, 100, 30, "CENTER", "Today There is no Employee To Punch", 3)
            TABLE.Controls.Add(ROW_0)
            Panel1.Controls.Add(TABLE)
        Else
            Dim LineColor As String = "fff7ff"
            Dim COUNT As Integer = 0
            For Each DROW In DTABLE.Rows
                COUNT = COUNT + 1
                Dim ROW_2 As New TableRow
                Dim CELL_21, CELL_22, CELL_23, CELL_24, CELL_25, CELL_26 As New TableCell
                CSETTINGS.RTEmptyLine(TABLE)
                If LineColor = "fff7ff" Then
                    LineColor = "#eef9ff"
                Else
                    LineColor = "fff7ff"
                End If
                ROW_2.Attributes.Add("BGCOLOR", LineColor)
                With CSETTINGS
                    .RTData(ROW_2, CELL_21, 5, 5, "CENTER", COUNT)
                    .RTData(ROW_2, CELL_22, 5, 5, "CENTER", DROW(0))
                    .RTData(ROW_2, CELL_23, 25, 5, "LEFT", "<a href=javascript:PunchingPage(" & DROW(0) & ")><font color=blue>" & DROW(1) & "")

                    .RTData(ROW_2, CELL_24, 5, 5, "CENTER", DROW(2))
                    .RTData(ROW_2, CELL_25, 5, 5, "CENTER", DROW(3))

                    .RTData(ROW_2, CELL_26, 25, 5, "LEFT", "If absent (Not Informed)" & "<a href=javascript:AbsenteePage(" & DROW(0) & "," & TrainId & ")>" & "<font color=blue> Click Me" & "")
                End With
                TABLE.Controls.Add(ROW_2)
            Next
            Panel1.Controls.Add(TABLE)
        End If
    End Sub
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return CbResult
    End Function
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim DataStr() As String
        DataStr = eventArgument.Split("#")
        Select Case (DataStr(1))
            Case 1
                Dim Instr() As String = DataStr(0).Split("%")
                Dim EmpCode As String = Instr(0)
                Dim TrainId As String = Instr(1)
                OHELPER.ExecuteNonQuery("update training_participant_dtl tpd set tpd.comments='Nil',tpd.status=18 where tpd.participant_id=" & EmpCode & " and tpd.training_id=" & TrainId & "")
                CbResult = "Successfully Confirmed"
        End Select
    End Sub
End Class

