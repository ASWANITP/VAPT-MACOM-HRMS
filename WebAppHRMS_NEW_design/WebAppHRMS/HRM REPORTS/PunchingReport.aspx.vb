
Partial Class HRM_Reports_PunchingReport_c60fae561597
    Inherits System.Web.UI.Page
    Dim tb As New Table
    Dim dr As Data.DataRow
    Dim dt As New Data.DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Dim oh As New helper.oracle.OracleHelper
            Dim sql As String = ""
            If Request.QueryString("case") = 1 Then
                sql = "select a.emp_code,b.emp_name,c.zonal_name,c.REG_NAME,c.DIV_NAME,c.AREA_NAME,c.BRANCH_NAME,d.category_name Training_Type,e.training_from || ' To ' || e.training_to as Training_Dte,a.in_time,a.out_time,case when a.in_time is null and a.out_time is null then 'Absent' else 'Present' End as STATUS,e.venue,' ' from TRAINING_ATTEND a,employee_master b,branch_detail c,training_category d,training_dtl e,EXAMINATION_DTL f  where e.training_id=" & Request.QueryString("Trid") & " and a.emp_code=b.emp_code and c.BRANCH_ID=b.branch_id and d.category_id=e.product_type and e.training_id=a.training_id"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            Else
                sql = "select a.emp_code,b.emp_name,c.zonal_name,c.REG_NAME,c.DIV_NAME,c.AREA_NAME,c.BRANCH_NAME,d.product_name Training_Type,e.training_from || ' To ' || e.training_to as Training_Dte,a.in_time,a.out_time,case when a.in_time is null and a.out_time is null then 'Absent' else 'Present' End as STATUS,e.venue,' ' from TRAINING_ATTEND a,employee_master b,branch_detail c,training_products d,training_dtl e where a.emp_code=b.emp_code and c.BRANCH_ID=b.branch_id and d.product_type=e.product_type and e.training_id=a.training_id"
                dt = oh.ExecuteDataSet(sql).Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                Head_print()
                Data_print()
                Panel1.Controls.Add(tb)
            Else
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('No Data for Display!');")
                cl_script0.Append("window.open('../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            End If
        End If
    End Sub
    Public Sub Head_print()
        tb.Font.Name = "Courier New"
        tb.Attributes.Add("border", "0")

        Dim tr01 As New TableRow
        Dim tr01_01 As New TableCell
        tr01_01.ColumnSpan = 15
        tr01_01.Attributes.Add("width", "100%")
        tr01_01.Text = "<b><font size=4> " & Session("firm_name") & " </b>"
        tr01_01.HorizontalAlign = HorizontalAlign.Center
        tr01.Controls.Add(tr01_01)
        tb.Controls.Add(tr01)

        Dim tr04 As New TableRow
        Dim tr04_01, tr04_02 As New TableCell

        tr04_01.ColumnSpan = 7
        tr04_01.Attributes.Add("width", "50%")
        tr04_01.Text = " Date: " + Format(Date.Now, "dd-MMM-yyyy") + " "
        tr04_01.HorizontalAlign = HorizontalAlign.Left
        tr04.Controls.Add(tr04_01)

        tr04_02.ColumnSpan = 8
        tr04_02.Attributes.Add("width", "50%")
        tr04_02.Text = "Time:" + Format(Date.Now, "hh :mm :ss") + " "
        tr04_02.HorizontalAlign = HorizontalAlign.Right
        tr04.Controls.Add(tr04_02)

        tb.Controls.Add(tr04)

        Dim tr06 As New TableRow
        Dim tr06_01 As New TableCell
        tr06_01.ColumnSpan = 15
        tr06_01.Attributes.Add("width", "100%")
        tr06_01.Text = "<b>&nbsp;</b>"
        tr06.Controls.Add(tr06_01)
        tb.Controls.Add(tr06)

        Dim tr05 As New TableRow
        Dim tr05_01 As New TableCell
        tr05_01.ColumnSpan = 15
        tr05_01.Attributes.Add("width", "100%")
        If Request.QueryString("case") = 1 Then
            tr05_01.Text = "PUNCHING REPORT TRAINING WISE"
        Else
            tr05_01.Text = "PUNCHING REPORT EMPLOYEE WISE"
        End If
        tr05.Controls.Add(tr05_01)
        tb.Controls.Add(tr05)

        Dim tr07 As New TableRow
        Dim tr07_01 As New TableCell
        tr07_01.ColumnSpan = 15
        tr07_01.Attributes.Add("width", "100%")
        tr07_01.Text = "<b><hr></b>"
        tr07.Controls.Add(tr07_01)
        tb.Controls.Add(tr07)

        Dim tr08 As New TableRow
        Dim tr08_01, tr08_02, tr08_03, tr08_04, tr08_05, tr08_06, tr08_07 As New TableCell
        Dim tr08_08, tr08_09, tr08_10, tr08_11, tr08_12, tr08_13, tr08_131, tr08_132 As New TableCell
        tr08_01.Text = "SRLNO"
        tr08_02.Text = "Emp.Code"
        tr08_03.Text = "Emp.Name"
        tr08_04.Text = "Zone"
        tr08_05.Text = "Region"
        tr08_06.Text = "Division"
        tr08_07.Text = "Area"

        tr08_08.Text = "Branch"
        tr08_09.Text = "Training_Type"
        tr08_10.Text = "Training_Dte"
        tr08_11.Text = "InTime"
        tr08_12.Text = "OutTime"
        tr08_13.Text = "Status"
        tr08_131.Text = "Venue"
        tr08_132.Text = "Mark(%)"
        tr08.Font.Bold = True

        tr08_01.ColumnSpan = 1
        tr08_02.ColumnSpan = 1
        tr08_03.ColumnSpan = 1
        tr08_04.ColumnSpan = 1
        tr08_05.ColumnSpan = 1
        tr08_06.ColumnSpan = 1
        tr08_07.ColumnSpan = 1

        tr08_08.ColumnSpan = 1
        tr08_09.ColumnSpan = 1
        tr08_10.ColumnSpan = 1
        tr08_11.ColumnSpan = 1
        tr08_12.ColumnSpan = 1
        tr08_13.ColumnSpan = 1
        tr08_13.ColumnSpan = 1
        tr08_131.ColumnSpan = 1
        tr08_132.ColumnSpan = 1


        'tr08_01.Attributes.Add("width", "35%")
        'tr08_02.Attributes.Add("width", "10%")
        'tr08_03.Attributes.Add("width", "10%")
        'tr08_04.Attributes.Add("width", "10%")
        'tr08_05.Attributes.Add("width", "20%")
        'tr08_06.Attributes.Add("width", "5%")
        'tr08_07.Attributes.Add("width", "5%")




        tr08_01.HorizontalAlign = HorizontalAlign.Center
        tr08_02.HorizontalAlign = HorizontalAlign.Left
        tr08_03.HorizontalAlign = HorizontalAlign.Left
        tr08_04.HorizontalAlign = HorizontalAlign.Left
        tr08_05.HorizontalAlign = HorizontalAlign.Left
        tr08_06.HorizontalAlign = HorizontalAlign.Right
        tr08_07.HorizontalAlign = HorizontalAlign.Left

        tr08_08.HorizontalAlign = HorizontalAlign.Left
        tr08_09.HorizontalAlign = HorizontalAlign.Left
        tr08_10.HorizontalAlign = HorizontalAlign.Center
        tr08_11.HorizontalAlign = HorizontalAlign.Center
        tr08_12.HorizontalAlign = HorizontalAlign.Center
        tr08_13.HorizontalAlign = HorizontalAlign.Center
        tr08_131.HorizontalAlign = HorizontalAlign.Center
        tr08_132.HorizontalAlign = HorizontalAlign.Center


        tr08.Controls.Add(tr08_01)
        tr08.Controls.Add(tr08_02)
        tr08.Controls.Add(tr08_03)
        tr08.Controls.Add(tr08_04)
        tr08.Controls.Add(tr08_05)
        tr08.Controls.Add(tr08_06)
        tr08.Controls.Add(tr08_07)

        tr08.Controls.Add(tr08_08)
        tr08.Controls.Add(tr08_09)
        tr08.Controls.Add(tr08_10)
        tr08.Controls.Add(tr08_11)
        tr08.Controls.Add(tr08_12)
        tr08.Controls.Add(tr08_13)
        tr08.Controls.Add(tr08_131)
        tr08.Controls.Add(tr08_132)

        tb.Controls.Add(tr08)
        Dim tr09 As New TableRow
        Dim tr09_01 As New TableCell
        tr09_01.ColumnSpan = 15
        tr09_01.Attributes.Add("width", "100%")
        tr09_01.Text = "<b><hr></b>"
        tr09.Controls.Add(tr09_01)
        tb.Controls.Add(tr09)
    End Sub
    Public Sub Data_print()
        Dim colors As String = "fff7ff"
        Dim slno = 0
        For Each dr In dt.Rows
            If (colors.Equals("fff7ff")) Then
                colors = "#eef9ff"
            Else
                colors = "fff7ff"
            End If

            slno = slno + 1
            Dim tr010 As New TableRow
            tr010.Attributes.Add("bgcolor", colors)
            Dim tr010_01, tr010_02, tr010_03, tr010_04, tr010_05, tr010_06, tr010_07, tr010_08, tr010_09 As New TableCell

            Dim trs11, trs12, trs13, trs14, trs141, trs142 As New TableCell

            tr010_01.ColumnSpan = 1
            tr010_08.ColumnSpan = 1
            tr010_09.ColumnSpan = 1
            tr010_02.ColumnSpan = 1
            tr010_03.ColumnSpan = 1
            tr010_04.ColumnSpan = 1
            tr010_05.ColumnSpan = 1
            tr010_06.ColumnSpan = 1
            tr010_07.ColumnSpan = 1

            trs11.ColumnSpan = 1
            trs12.ColumnSpan = 1
            trs13.ColumnSpan = 1
            trs14.ColumnSpan = 1
            trs141.ColumnSpan = 1
            trs142.ColumnSpan = 1


            ' tr010_01.Attributes.Add("width", "5%")
            'tr010_08.Attributes.Add("width", "15%")
            'tr010_09.Attributes.Add("width", "15%")
            'tr010_02.Attributes.Add("width", "10%")
            'tr010_03.Attributes.Add("width", "10%")
            'tr010_04.Attributes.Add("width", "10%")
            'tr010_05.Attributes.Add("width", "20%")
            'tr010_06.Attributes.Add("width", "5%")
            'tr010_07.Attributes.Add("width", "5%")



            tr010_01.Text = "<small>" & slno & "</small>"
            tr010_08.Text = "<small>" & dr(0) & "</small>"
            tr010_09.Text = "<small>" & dr(1) & "</small>"
            tr010_02.Text = "<small>" & dr(2) & "</small>"
            tr010_03.Text = "<small>" & dr(3) & "</small>"
            tr010_04.Text = "<small>" & dr(4) & "</small>"
            tr010_05.Text = "<small>" & dr(5) & "</small>"
            tr010_06.Text = "<small>" & dr(6) & "</small>"
            tr010_07.Text = "<small>" & dr(7) & "</small>"



            trs11.Text = "<small>" & dr(8) & "</small>"
            trs12.Text = "<small>" & dr(9) & "</small>"
            trs13.Text = "<small>" & dr(10) & "</small>"
            trs14.Text = "<small>" & dr(11) & "</small>"
            trs141.Text = "<small>" & dr(12) & "</small>"
            trs142.Text = "<small>" & dr(13) & "</small>"


            tr010_01.HorizontalAlign = HorizontalAlign.Left
            tr010_08.HorizontalAlign = HorizontalAlign.Left
            tr010_09.HorizontalAlign = HorizontalAlign.Left
            tr010_02.HorizontalAlign = HorizontalAlign.Left
            tr010_03.HorizontalAlign = HorizontalAlign.Left
            tr010_04.HorizontalAlign = HorizontalAlign.Left
            tr010_05.HorizontalAlign = HorizontalAlign.Left
            tr010_06.HorizontalAlign = HorizontalAlign.Left
            tr010_07.HorizontalAlign = HorizontalAlign.Left

            trs11.HorizontalAlign = HorizontalAlign.Left
            trs12.HorizontalAlign = HorizontalAlign.Left
            trs13.HorizontalAlign = HorizontalAlign.Center
            trs14.HorizontalAlign = HorizontalAlign.Center
            trs141.HorizontalAlign = HorizontalAlign.Center
            trs142.HorizontalAlign = HorizontalAlign.Center

            tr010.Controls.Add(tr010_01)
            tr010.Controls.Add(tr010_08)
            tr010.Controls.Add(tr010_09)
            tr010.Controls.Add(tr010_02)
            tr010.Controls.Add(tr010_03)
            tr010.Controls.Add(tr010_04)
            tr010.Controls.Add(tr010_05)
            tr010.Controls.Add(tr010_06)
            tr010.Controls.Add(tr010_07)

            tr010.Controls.Add(trs11)
            tr010.Controls.Add(trs12)
            tr010.Controls.Add(trs13)
            tr010.Controls.Add(trs14)
            tr010.Controls.Add(trs141)
            tr010.Controls.Add(trs142)

            tb.Controls.Add(tr010)

            'tot_training += 1
            'tot_participant += dr(5)
        Next
        Dim tr011 As New TableRow
        Dim tr011_01 As New TableCell
        tr011_01.ColumnSpan = 15
        tr011_01.Attributes.Add("width", "100%")
        tr011_01.Text = "<b><hr></b>"
        tr011.Controls.Add(tr011_01)
        tb.Controls.Add(tr011)

        'Dim tr012 As New TableRow
        'Dim tr012_01, tr012_02, tr012_03, tr012_04 As New TableCell
        'tr012.Font.Bold = True
        'tr012_01.ColumnSpan = 4
        'tr012_01.Attributes.Add("width", "20%")
        'tr012_01.Text = "TOTAL"
        'tr012_01.HorizontalAlign = HorizontalAlign.Left
        'tr012.Controls.Add(tr012_01)

        'tr012_02.ColumnSpan = 2
        'tr012_02.Attributes.Add("width", "15%")
        'tr012_02.Text = tot_training
        'tr012_02.HorizontalAlign = HorizontalAlign.Left
        'tr012.Controls.Add(tr012_02)

        'tr012_03.ColumnSpan = 8
        'tr012_03.Attributes.Add("width", "55%")
        'tr012_03.Text = tot_participant
        'tr012_03.HorizontalAlign = HorizontalAlign.Right
        'tr012.Controls.Add(tr012_03)

        'tr012_04.ColumnSpan = 1
        'tr012_04.Attributes.Add("width", "5%")
        'tr012_04.Text = " "
        'tr012.Controls.Add(tr012_04)
        'tb.Controls.Add(tr012)

        Dim tr013 As New TableRow
        Dim tr013_01 As New TableCell
        tr013_01.ColumnSpan = 15
        tr013_01.Attributes.Add("width", "100%")
        tr013_01.Text = "<b><hr></b>"
        tr013.Controls.Add(tr013_01)
        tb.Controls.Add(tr013)

    End Sub
End Class
