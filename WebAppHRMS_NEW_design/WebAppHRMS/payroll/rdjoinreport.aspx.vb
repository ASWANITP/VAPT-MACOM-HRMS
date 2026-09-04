Imports System.Data
Imports System.Data.OracleClient
Partial Class RD_Deduction_rdjoinreport_921d23061250
    Inherits System.Web.UI.Page
    'Dim oh As New Helper.Oracle.OracleHelper
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str As String
    ' Dim i As Integer = 0
    Dim total As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tab1 As New Table
        'tab1.Attributes.Add("border", "1")
        tab1.Attributes.Add("width", "100%")
        Dim tabr1 As New TableRow
        tabr1.Width = 9
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        Dim tabc1 As New TableCell
        tabc1.HorizontalAlign = HorizontalAlign.Center
        tabc1.Text = "<b><font size=4>" & Session("firm_name") & " </font></b>"
        tabc1.ColumnSpan = 9
        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        Dim sheader As New TableRow
        sheader.Width = 9
        sheader.BackColor = Drawing.Color.LightGray
        Dim sheadercell1 As New TableCell
        sheadercell1.ColumnSpan = 9
        sheadercell1.HorizontalAlign = HorizontalAlign.Center
        sheadercell1.Text = "<b><font size=2>Branch ID=" & Session("branch_id") & " ,Branch Name=" & Session("branch_name") & "</font></b>"
        sheader.Controls.Add(sheadercell1)
        tab1.Controls.Add(sheader)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 9
        tabr2.ForeColor = Drawing.Color.Maroon
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.HorizontalAlign = HorizontalAlign.Center
        tabc2.Text = "<b><font size=2> Employee Details Those Have RD Deduction <font></b>"
        tabc2.ColumnSpan = 9
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)

        Dim ecoder As New TableRow
        ecoder.Width = 9
        Dim ec1 As New TableCell
        ec1.ColumnSpan = 9
        ec1.HorizontalAlign = HorizontalAlign.Center
        ec1.Text = "<b><font size=2>Employee Code" & Me.Request.QueryString("EmpFrom") & "To Employee Code" & Me.Request.QueryString("EmpTo") & "</font></b> "
        ecoder.Controls.Add(ec1)
        tab1.Controls.Add(ecoder)

        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 9
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3, tabcc, tabcc4 As New TableCell

        tabcc3.ColumnSpan = 2
        tabcc3.HorizontalAlign = HorizontalAlign.Left
        tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Date.Now, "dd/MMM/yyyy") & " </font></b>"
        tabrr3.Controls.Add(tabcc3)


        tabcc.ColumnSpan = 5
        tabcc.HorizontalAlign = HorizontalAlign.Center
        ' tabcc.Text = " "
        tabrr3.Controls.Add(tabcc)



        tabcc4.HorizontalAlign = HorizontalAlign.Right
        tabcc4.ColumnSpan = 2
        tabcc4.Text = "<b><font size=2.5>DATE: " & Format(Date.Now, "hh:mm:ss tt") & " </font></b>"
        tabrr3.Controls.Add(tabcc4)

        tab1.Controls.Add(tabrr3)

        Dim tabline As New TableRow
        tabline.Width = 9
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 9
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)

        '5th row

        Dim tabr5 As New TableRow
        tabr5.Width = 9
        tabr5.ForeColor = Drawing.Color.DarkSlateGray
        Dim tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10 As New TableCell

        tabr5c2.ColumnSpan = 1
        tabr5c3.ColumnSpan = 1
        tabr5c4.ColumnSpan = 1
        tabr5c5.ColumnSpan = 1
        tabr5c6.ColumnSpan = 1
        tabr5c7.ColumnSpan = 1
        tabr5c8.ColumnSpan = 1
        tabr5c9.ColumnSpan = 1
        tabr5c10.ColumnSpan = 1

        tabr5c2.Text = "<font size=2><b>EMP CODE</b></font>"
        tabr5c3.Text = "<font size=2><b>EMP NAME and ADDRESS</b></font>"
        tabr5c4.Text = "<font size=2><b>D.O.J</b></font>"
        tabr5c5.Text = "<font size=2><b>DESIG</b></font>"
        tabr5c6.Text = "<font size=2><b>BRANCH</b></font>"
        tabr5c7.Text = "<font size=2><b>DEPARTMENT</b></font>"
        tabr5c8.Text = "<font size=2><b>DEP. AMOUNT</b></font>"
        tabr5c9.Text = "<font size=2><b>RD AMT</b></font>"
        tabr5c10.Text = "<font size=2><b>NO.INST</b></font>"


        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Left
        tabr5c8.HorizontalAlign = HorizontalAlign.Left
        tabr5c9.HorizontalAlign = HorizontalAlign.Left
        tabr5c10.HorizontalAlign = HorizontalAlign.Left



        
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c8)
        tabr5.Controls.Add(tabr5c9)
        tabr5.Controls.Add(tabr5c10)

        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 9
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 9
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)


        

        '////////////////////////////////////////query////////////////////
        '             ---0------   -----1-----  ----2 ----  ----3 -----   ---4-----------  ---5--------   ------6---- ---7---    -----8-----   -----9-------   ---10----  ---11---------------------   ----12----   -----------13
        str = "select em.emp_code,em.emp_name,ep.pres_add1,pm.post_office,dm.district_name,sm.state_name,pm.pin_code,em.join_dt,dm.designation,bm.branch_name,dp.dep_name,em.paid_amt as DEPOSIT_AMT,m.rdded_amt,case when m.rdded_amt=511 then round((15000-em.paid_amt)/m.rdded_amt)+1 else round((15000-em.paid_amt)/m.rdded_amt) end as no_Inst from m_wage m,employee_master em,employ_personal_dtl ep,post_master pm,district_master dm,state_master sm,branch_master bm,department_mst dp,designation_master dm,employ_firm f where em.emp_code=m.emp_code and em.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id=sm.state_id and m.branch_id=bm.branch_id and m.designation_id=dm.designation_id and m.department_id=dp.dep_id and em.emp_code>=" & Me.Request.QueryString("EmpFrom") & " and em.emp_code<=" & Me.Request.QueryString("EmpTo") & " and m.rdded_amt>0 and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " union select em.emp_code,em.emp_name,ep.pres_add1,pm.post_office,dm.district_name,sm.state_name,pm.pin_code,em.join_dt,dm.designation,bc.branch_name,dp.dep_name,em.paid_amt as DEPOSIT_AMT,m.rdded_amt,case when m.rdded_amt=511 then round((15000-em.paid_amt)/m.rdded_amt)+1 else round((15000-em.paid_amt)/m.rdded_amt) end as no_Inst from m_wage m,employee_master em,employ_personal_dtl ep,post_master pm,district_master dm,state_master sm,before_completion bc,department_mst dp,designation_master dm,employ_firm f where em.emp_code=m.emp_code and em.emp_code=ep.emp_code and ep.pres_pin=pm.sr_number and pm.district_id=dm.district_id and dm.state_id=sm.state_id and m.branch_id=bc.old_id and bc.branch_id is null and em.designation_id=dm.designation_id and em.department_id=dp.dep_id and em.emp_code>=" & Me.Request.QueryString("EmpFrom") & " and em.emp_code<=" & Me.Request.QueryString("EmpTo") & " and m.rdded_amt>0 and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " order by emp_code"
        dt = oh.ExecuteDataSet(str).Tables(0)
        '/////////////////////////////////////////////////////////////////

        For Each dr In dt.Rows
            total += 1


            Dim tabr6 As New TableRow
            tabr6.Width = 9

            Dim tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10 As New TableCell

            tabr6c2.ColumnSpan = 1
            tabr6c3.ColumnSpan = 1
            tabr6c4.ColumnSpan = 1
            tabr6c5.ColumnSpan = 1
            tabr6c6.ColumnSpan = 1
            tabr6c7.ColumnSpan = 1
            tabr6c8.ColumnSpan = 1
            tabr6c9.ColumnSpan = 1
            tabr6c10.ColumnSpan = 1


            tabr6c2.HorizontalAlign = HorizontalAlign.Left
            tabr6c3.HorizontalAlign = HorizontalAlign.Left
            tabr6c4.HorizontalAlign = HorizontalAlign.Left
            tabr6c5.HorizontalAlign = HorizontalAlign.Left
            tabr6c6.HorizontalAlign = HorizontalAlign.Left
            tabr6c7.HorizontalAlign = HorizontalAlign.Left
            tabr6c8.HorizontalAlign = HorizontalAlign.Right
            tabr6c9.HorizontalAlign = HorizontalAlign.Right
            tabr6c10.HorizontalAlign = HorizontalAlign.Right



            'ecode
            tabr6c2.Text = "<font size=2>" & dr(0) & "</font>"
            'name& addrss
            tabr6c3.Text = "<font size=2>" & dr(1) & "<br/>" & dr(2) & "<br/>" & dr(3) & " &nbsp;(PO)<br/>" & dr(4) & "<br/>" & dr(5) & " <br/>PIN:&nbsp;" & dr(6) & "</font>"
            'joindate
            tabr6c4.Text = "<font size=2>" & Format(dr(7), "dd/MMM/yyyy") & "</font>"

            tabr6c5.Text = "<font size=2>" & dr(8) & "</font>"
            tabr6c6.Text = "<font size=2>" & dr(9) & "</font>"
            tabr6c7.Text = "<font size=2>" & dr(10) & "</font>"
            'deposited
            tabr6c8.Text = "<font size=2>" & dr(11) & "</font>"
            'RD Amount
            tabr6c9.Text = "<font size=2>" & dr(12) & "</font>"
            ' No of Inst
            tabr6c10.Text = "<font size=2>" & dr(13) & "</font>"



            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c7)
            tabr6.Controls.Add(tabr6c8)
            tabr6.Controls.Add(tabr6c9)
            tabr6.Controls.Add(tabr6c10)

            tab1.Controls.Add(tabr6)
            Dim tabline25 As New TableRow
            tabline25.Width = 9
            Dim tabcellline235 As New TableCell
            tabcellline235.ColumnSpan = 9
            tabcellline235.Text = "<hr>"
            tabline25.Controls.Add(tabcellline235)
            tab1.Controls.Add(tabline25)
            
        Next

        Dim tabline23 As New TableRow
        tabline23.Width = 9
        Dim tabcellline233 As New TableCell
        tabcellline233.ColumnSpan = 9
        tabcellline233.HorizontalAlign = HorizontalAlign.Left
        tabcellline233.Text = "<b><font size=2>Total:" & total & "</font></b>"
        tabline23.Controls.Add(tabcellline233)
        tab1.Controls.Add(tabline23)

        Pan_JoinRD.Controls.Add(tab1)
    End Sub
End Class
