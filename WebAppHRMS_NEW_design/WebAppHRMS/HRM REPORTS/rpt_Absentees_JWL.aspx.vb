Imports System.Data.OracleClient
Imports System.Data
Partial Class HRM_Reports_rpt_Absentees_JWL_32bc0f2c2022
    Inherits System.Web.UI.Page
    Dim CSETTINGS As New customSettings.reportSettings
    Dim TABLE As New Table
    Dim DTABLE As New DataTable
    Dim OHELPER As New helper.oracle.OracleHelper
    Dim DROW As DataRow
    Dim FromDt, ToDt As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim FromStr() As String = (Request.QueryString("from_dt")).ToString.Split("/")
        FromDt = Format(CDate(FromStr(1) + "/" + FromStr(0) + "/" + FromStr(2)), "dd-MMM-yyyy")
        Dim ToStr() As String = (Request.QueryString("to_dt")).ToString.Split("/")
        ToDt = Format(CDate(ToStr(1) + "/" + ToStr(0) + "/" + ToStr(2)), "dd-MMM-yyyy")
      
        Dim QUERY As String = "select substr(em.emp_name, 0, 13),substr(pm.post_name, 0, 12),substr(bm.branch_name, 0, 12),td.training_from,substr(tp.product_name, 0, 12),substr(td.venue, 0, 12),substr(td.trainer, 0, 11),substr(decode(tpd.status, '17', tpd.comments, 'Not Informed'), 0, 15) as Informed,em.emp_code from training_participant_dtl tpd,employee_master  em,post_mst   pm,branch_master  bm,training_dtl td,training_products  tp where td.training_id > 0  and to_date(td.training_from) between '" & FromDt & "' and '" & ToDt & "' and tpd.status in ('17', '18') and tpd.participant_id = em.emp_code and tp.category_id=6 and tpd.post_id = pm.post_id and tpd.branch_id = bm.branch_id and tpd.training_id = td.training_id and td.product_type = tp.product_type and exists (select a.emp_code from hrm_tour_dtl a where a.emp_code = tpd.participant_id and a.tour_id = 2 and a.training_normal = 1 and (a.recom_person is null or a.reject_reason ='NOT ATTEND TRAINING') and to_date(a.from_dt) >= to_date('" & FromDt & "') and to_date(a.to_dt) <= to_date('" & ToDt & "')) order by em.emp_name"
        DTABLE = OHELPER.ExecuteDataSet(QUERY).Tables(0)
        CSETTINGS.RTHeading("ABSENTEES LIST FROM '" & FromDt & "' TO '" & ToDt & "'", TABLE, Session("firm_name"), Session("branch_id"), Session("branch_name"), 20)
        CSETTINGS.RTLine(TABLE, 20)
        Dim ROW_1 As New TableRow
        Dim CELL_11, CELL_12, CELL_13, CELL_14, CELL_15, CELL_16, CELL_17, CELL_18, CELL_19, CELL_20, CELL_31 As New TableCell
        With CSETTINGS
            .RTData(ROW_1, CELL_11, 4, 1, "CENTER", "SlNo", 2)
            .RTData(ROW_1, CELL_31, 3, 1, "CENTER", "EMPCODE", 2)
            .RTData(ROW_1, CELL_12, 13, 2, "CENTER", "NAME", 2)
            .RTData(ROW_1, CELL_13, 11, 2, "CENTER", "POST", 2)
            .RTData(ROW_1, CELL_14, 12, 2, "CENTER", "BRANCH", 2)
            .RTData(ROW_1, CELL_15, 8, 1, "CENTER", "TRAINING&nbsp;DATE", 2)
            .RTData(ROW_1, CELL_16, 11, 2, "CENTER", "PRODUCT&nbsp;NAME", 2)
            .RTData(ROW_1, CELL_17, 9, 2, "CENTER", "VENUE", 2)
            .RTData(ROW_1, CELL_18, 14, 3, "CENTER", "TRAINER", 2)
            .RTData(ROW_1, CELL_19, 14, 2, "CENTER", "REMARKS", 2)
        End With
        CSETTINGS.RTEmptyLine(TABLE)
        TABLE.Controls.Add(ROW_1)
        Dim LineColor As String = "fff7ff"
        Dim COUNT As Integer = 0
        For Each DROW In DTABLE.Rows
            Dim Informed As String
            Dim NotInformed As String
            If (DROW(7).Equals(DBNull.Value)) Then
                Informed = "N/A"
            Else
                Informed = DROW(7).ToString()
            End If
            If (DROW(8).Equals(DBNull.Value)) Then
                NotInformed = "N/A"
            Else
                NotInformed = DROW(8).ToString()
            End If
            COUNT = COUNT + 1
            Dim ROW_2 As New TableRow
            Dim CELL_21, CELL_22, CELL_23, CELL_24, CELL_25, CELL_26, CELL_27, CELL_28, CELL_29, CELL_30, CELL_32 As New TableCell
            CSETTINGS.RTEmptyLine(TABLE)
            If LineColor = "fff7ff" Then
                LineColor = "#eef9ff"
            Else
                LineColor = "fff7ff"
            End If
            ROW_2.Attributes.Add("BGCOLOR", LineColor)
            With CSETTINGS
                .RTData(ROW_2, CELL_21, 4, 1, "CENTER", COUNT)
                .RTData(ROW_2, CELL_32, 3, 1, "LEFT", DROW(8))
                .RTData(ROW_2, CELL_22, 13, 2, "LEFT", DROW(0))
                .RTData(ROW_2, CELL_23, 11, 2, "LEFT", DROW(1))
                .RTData(ROW_2, CELL_24, 12, 2, "LEFT", DROW(2))
                .RTData(ROW_2, CELL_25, 8, 1, "LEFT", Format(DROW(3), "dd/MMM/yyyy"))
                .RTData(ROW_2, CELL_26, 11, 2, "LEFT", DROW(4))
                .RTData(ROW_2, CELL_27, 9, 2, "LEFT", DROW(5))
                .RTData(ROW_2, CELL_28, 14, 3, "LEFT", DROW(6))
                .RTData(ROW_2, CELL_29, 14, 2, "LEFT", Informed)
            End With
            TABLE.Controls.Add(ROW_2)
        Next
        Panel1.Controls.Add(TABLE)
    End Sub
End Class
