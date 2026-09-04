Imports System.Data
Imports System.Data.OracleClient

Partial Class HRM_Employee_ContactList_4349d0b35322
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Private Function MaskEmail(rawEmail As String) As String
        If String.IsNullOrEmpty(rawEmail) Then Return rawEmail
        Dim atIndex As Integer = rawEmail.IndexOf("@"c)
        If atIndex > 0 Then
            Dim firstChar As String = rawEmail.Substring(0, 1)
            Dim domainPart As String = rawEmail.Substring(atIndex)
            Return firstChar & "*****" & domainPart
        End If
        Return rawEmail
    End Function

    Private Function MaskPhone(rawPhone As String) As String
        If String.IsNullOrEmpty(rawPhone) OrElse rawPhone.Length < 4 Then Return rawPhone
        Return New String("X"c, rawPhone.Length - 4) & rawPhone.Substring(rawPhone.Length - 4)
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sql As String

        If Me.Request.QueryString("rdb") = 1 Then

            sql = "select t.emp_code,t.emp_name,d.dep_name,ds.designation,p.post_name,case when pers.emp_email is null then '-' else pers.emp_email end EMAIL,case when pers.cont_phone is null then   '-'   else pers.cont_phone  end||'/'|| case when pers.res_phone is null then '-' else pers.res_phone end MOBNO from employee_master t join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & Session("firm_id") & " join department_mst d on d.dep_id = t.department_id join designation_master ds on ds.designation_id =t.designation_id join post_mst p on p.post_id = t.post_id join employ_personal_dtl pers on pers.emp_code = t.emp_code where t.status_id=1 and t.emp_code =" & Me.Request.QueryString("code") & " order by 1"

        ElseIf Me.Request.QueryString("rdb") = 2 Then

            sql = "select t.emp_code,t.emp_name,d.dep_name,ds.designation,p.post_name,case when pers.emp_email is null then '-' else pers.emp_email end EMAIL,case when pers.cont_phone is null then   '-'   else pers.cont_phone  end||'/'|| case when pers.res_phone is null then '-' else pers.res_phone end MOBNO from employee_master t join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & Session("firm_id") & " join department_mst d on d.dep_id = t.department_id join designation_master ds on ds.designation_id =t.designation_id join post_mst p on p.post_id = t.post_id join employ_personal_dtl pers on pers.emp_code = t.emp_code where t.status_id=1 and (t.emp_name like upper('" & Me.Request.QueryString("name") & "%') or t.emp_name like '" & Me.Request.QueryString("name") & "%') order by 1"
        Else

            sql = "select t.emp_code,t.emp_name,d.dep_name,ds.designation,p.post_name,case when pers.emp_email is null then '-' else pers.emp_email end EMAIL,case when pers.cont_phone is null then   '-'   else pers.cont_phone  end||'/'|| case when pers.res_phone is null then '-' else pers.res_phone end MOBNO from employee_master t join employ_firm f on f.emp_code = t.emp_code and f.firm_id =" & Session("firm_id") & " join department_mst d on d.dep_id = t.department_id join designation_master ds on ds.designation_id =t.designation_id join post_mst p on p.post_id = t.post_id join employ_personal_dtl pers on pers.emp_code = t.emp_code where t.status_id=1 order by 1"

        End If

        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)

        Dim line1 As New TableRow
        Dim line11 As New TableCell
        line11.ColumnSpan = 7
        line11.Text = "<hr align=center width=100% >"
        line1.Controls.Add(line11)

        Dim assettab As New Table
        assettab.Attributes.Add("width", "100%")

        Dim ta1 As New TableRow
        Dim ta11 As New TableCell
        ta11.ColumnSpan = 7
        ta1.Attributes.Add("bgcolor", "lightgrey") 'gold
        ta1.Attributes.Add("bordercolor", "black")
        ta11.Text = "<font size=4.5><b>" & Session("firm_name") & "</b></font>"
        ta11.ForeColor = Drawing.Color.Black 'Red
        ta11.HorizontalAlign = HorizontalAlign.Center
        ta1.Controls.Add(ta11)

        assettab.Controls.Add(ta1)

       
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#F5F5F5")


        Dim ta3 As New TableRow
        ta3.Attributes.Add("bgcolor", "#F5F5F5")
        ta3.ForeColor = Drawing.Color.Black 'Maroon
        ta3.Width = 7
        Dim ta31, ta32, ta33 As New TableCell
        ta31.ColumnSpan = 2
        ta32.ColumnSpan = 3
        ta33.ColumnSpan = 2
        ta31.Text = "<font size=3.5><b>Date :" & Format(Today, "dd/MM/yyyy") & " </b></font>"
        ta32.Text = "<font size=3><b>EMPLOYEE CONTACT LIST DETAILS&nbsp;</b></font>"

        ta33.Text = "<font size=3.5><b>Time :" & Format(TimeOfDay, "hh:mm:ss tt") & " </b></font>"
        ta31.HorizontalAlign = HorizontalAlign.Left
        ta32.HorizontalAlign = HorizontalAlign.Center
        ta33.HorizontalAlign = HorizontalAlign.Right
        ta3.Controls.Add(ta31)
        ta3.Controls.Add(ta32)
        ta3.Controls.Add(ta33)
        assettab.Controls.Add(ta3)

        '---------------------------------------------------------------------------------
        Dim lin2101 As New TableRow
        lin2101.Width = 10
        Dim lin21011 As New TableCell
        lin21011.ColumnSpan = 10
        lin21011.Text = "<hr align=center width=100% >"
        lin2101.Controls.Add(lin21011)
        assettab.Controls.Add(lin2101)

        Dim lm4 As New TableRow
        lm4.Width = 7
        Dim lm41, lm42, lm43, lm44, lm45, lm46, lm47, lm48, lm49, lm50 As New TableCell
        lm41.ColumnSpan = 1
        lm41.Text = "<font size=2><b> EMPLOYEE CODE </b></font>"
        lm41.HorizontalAlign = HorizontalAlign.Left

        lm42.ColumnSpan = 1
        lm42.Text = "<font size=2><b> EMPLOYEE NAME </b></font>"
        lm42.HorizontalAlign = HorizontalAlign.Left


        lm43.ColumnSpan = 1
        lm43.Text = "<font size=2><b> DEPARTMENT NAME </b></font>"
        lm43.HorizontalAlign = HorizontalAlign.Left

        lm44.ColumnSpan = 1
        lm44.Text = "<font size=2><b> DESIGNATION </b></font>"
        lm44.HorizontalAlign = HorizontalAlign.Left

        lm45.ColumnSpan = 1
        lm45.Text = "<font size=2><b> POST NAME </b></font>"
        lm45.HorizontalAlign = HorizontalAlign.Left

        lm46.ColumnSpan = 1
        lm46.Text = "<font size=2><b> EMAIL ID</b></font>"
        lm46.HorizontalAlign = HorizontalAlign.Left

        lm47.ColumnSpan = 1
        lm47.Text = "<font size=2><b> MOBILE NUMBER </b></font>"
        lm47.HorizontalAlign = HorizontalAlign.Left

       


        lm4.Controls.Add(lm41)
        lm4.Controls.Add(lm42)
        lm4.Controls.Add(lm43)
        lm4.Controls.Add(lm44)
        lm4.Controls.Add(lm45)
        lm4.Controls.Add(lm46)
        lm4.Controls.Add(lm47)
      
        assettab.Controls.Add(lm4)

        Dim lin21 As New TableRow
        lin21.Width = 7
        Dim lin211 As New TableCell
        lin211.ColumnSpan = 7
        lin211.Text = "<hr align=center width=100% >"
        lin21.Controls.Add(lin211)
        assettab.Controls.Add(lin21)


        '------------------------------------------------------------------------------------------
        Dim dr As DataRow
        Dim cnt As Integer = 0
        Dim total As Integer = 0
        Dim itemid As Integer = 0
        Dim itemtot As Integer = 0
        Dim itemqun As Integer = 0
        Dim st As Integer = 0
        Dim colors As String = "#F5F5F5"

        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows

                Dim lm5 As New TableRow
                lm5.Width = 7
                Dim lm51, lm52, lm53, lm54, lm55, lm56, lm57, lm58, lm59, lm60 As New TableCell
                lm5.Font.Size = 8
                lm51.ColumnSpan = 1
                lm51.HorizontalAlign = HorizontalAlign.Left
                lm51.Text = "<font size=2>" & dr(0) & " </font>"
                lm5.Controls.Add(lm51)

                lm52.ColumnSpan = 1
                lm52.HorizontalAlign = HorizontalAlign.Left
                lm52.Text = "<font size=2>" & dr(1) & " </font>"
                lm5.Controls.Add(lm52)


                lm53.ColumnSpan = 1
                lm53.HorizontalAlign = HorizontalAlign.Left
                lm53.Text = "<font size=2>" & dr(2) & " </font>"
                lm5.Controls.Add(lm53)

                lm54.ColumnSpan = 1
                lm54.HorizontalAlign = HorizontalAlign.Left
                lm54.Text = "<font size=2>" & dr(3) & " </font>"
                lm5.Controls.Add(lm54)
                assettab.Controls.Add(lm5)


                lm55.ColumnSpan = 1
                lm55.HorizontalAlign = HorizontalAlign.Left
                lm55.Text = "<font size=2>" & dr(4) & " </font>"
                lm5.Controls.Add(lm55)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)


                lm56.ColumnSpan = 1
                lm56.HorizontalAlign = HorizontalAlign.Left
                Dim email As String = MaskEmail(dr(5).ToString())
                lm56.Text = "<font size=2>" & email & " </font>"
                'lm56.Text = "<font size=2>" & dr(5) & " </font>"
                lm5.Controls.Add(lm56)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)



                lm57.ColumnSpan = 1
                lm57.HorizontalAlign = HorizontalAlign.Left
                Dim phones As String = dr(6).ToString()
                Dim maskedPhones As String = String.Join("/", phones.Split("/"c).Select(Function(p) MaskPhone(p.Trim())))
                lm57.Text = "<font size=2>" & maskedPhones & " </font>"
                'lm57.Text = "<font size=2>" & dr(6) & " </font>"
                lm5.Controls.Add(lm57)
                lm5.Attributes.Add("bgcolor", colors)
                assettab.Controls.Add(lm5)

                cnt += 1
            Next
        End If


        Dim lin301 As New TableRow
        lin301.Width = 7
        Dim lin3011 As New TableCell
        lin3011.ColumnSpan = 7
        lin3011.Text = "<hr align=center width=100% >"
        lin301.Controls.Add(lin3011)
        assettab.Controls.Add(lin301)


        Dim reg20 As New TableRow
        'reg20.Width = 7
        ' reg20.BackColor = Drawing.Color.Maroon
        Dim reg201 As New TableCell
        reg201.ColumnSpan = 7
        reg201.HorizontalAlign = HorizontalAlign.Left
        reg201.Text = "<font size=3 color=black ><b>TOTAL : " & cnt & "&nbsp;&nbsp;  </b></font>"
        reg20.Controls.Add(reg201)
        assettab.Controls.Add(reg20)

        Dim lin20 As New TableRow
        'lin20.Width = 7
        Dim lin201 As New TableCell
        lin201.ColumnSpan = 7
        lin201.Text = "<hr align=center width=100% >"
        lin20.Controls.Add(lin201)
        assettab.Controls.Add(lin20)



        Me.Panel1.Controls.Add(assettab)
    End Sub

    Protected Sub btn_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Response.Redirect("EmployeeList_Search.aspx")
    End Sub
End Class
