Imports System.Data.OracleClient
Imports System.Data
Partial Class HRM_Reports_rpt_Absentees01_d9d1a5ef4637
    Inherits System.Web.UI.Page
    Dim CSETTINGS As New customSettings.reportSettings
    Dim TABLE As New Table
    Dim DTABLE As New DataTable
    Dim OHELPER As New helper.oracle.OracleHelper
    Dim DROW As DataRow
    Dim FromDt, ToDt As String
    Dim TrainingId As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FromDt = Request.QueryString("FromDt")
        ToDt = Request.QueryString("ToDt")
        TrainingId = Request.QueryString("TRAINID")
        DTABLE = OHELPER.ExecuteDataSet("select distinct em.emp_name,ta.emp_code,dm.designation,to_date(td.training_from),td.venue,tp.product_name from training_participant_dtl tpd,training_dtl td,employee_master em,designation_mst dm,training_products tp,training_attend ta where td.training_from between '" & FromDt & "' and '" & ToDt & "' and ta.training_id=" & TrainingId & " and td.training_id=ta.training_id and ta.in_time is null and ta.out_time is null and td.training_id=tpd.training_id and ta.emp_code=em.emp_code and tpd.designation_id=dm.designation_id and tpd.participant_id = ta.emp_code and td.product_type=tp.product_type order by ta.emp_code").Tables(0)
        CSETTINGS.RTHeading("ABSENTEES LIST FROM '" & FromDt & "' TO '" & ToDt & "'", TABLE, Session("firm_name"), Session("branch_id"), Session("branch_name"), 20)
        CSETTINGS.RTLine(TABLE, 20)
        Dim ROW_1 As New TableRow
        Dim CELL_11, CELL_12, CELL_13, CELL_14, CELL_15, CELL_16 As New TableCell
        With CSETTINGS
            .RTData(ROW_1, CELL_11, 17, 4, "CENTER", "EMPLOYEE NAME", 2)
            .RTData(ROW_1, CELL_12, 16, 3, "CENTER", "EMPLOYEE CODE", 2)
            .RTData(ROW_1, CELL_13, 18, 4, "CENTER", "DESIGNATION", 2)
            .RTData(ROW_1, CELL_14, 16, 3, "CENTER", "TRAINING DATE", 2)
            .RTData(ROW_1, CELL_15, 17, 3, "CENTER", "VENUE", 2)
            .RTData(ROW_1, CELL_16, 16, 3, "CENTER", "TRAINING TYPE", 2)
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
            CSETTINGS.RTData(ROW_0, CELL_02, 100, 20, "CENTER", "There is No Absentee", 3)
            TABLE.Controls.Add(ROW_0)
            Panel1.Controls.Add(TABLE)
        Else
            Dim LineColor As String = "fff7ff"
            For Each DROW In DTABLE.Rows
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
                    .RTData(ROW_2, CELL_21, 17, 4, "CENTER", DROW(0))
                    .RTData(ROW_2, CELL_22, 16, 3, "CENTER", DROW(1))
                    .RTData(ROW_2, CELL_23, 18, 4, "CENTER", DROW(2))
                    .RTData(ROW_2, CELL_24, 16, 3, "CENTER", Format(DROW(3), "dd/MMM/yyyy"))
                    .RTData(ROW_2, CELL_25, 17, 3, "CENTER", DROW(4))
                    .RTData(ROW_2, CELL_26, 16, 3, "CENTER", DROW(5))
                End With
                TABLE.Controls.Add(ROW_2)
            Next

            Panel1.Controls.Add(TABLE)
        End If
    End Sub
End Class
