Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO.Compression
Imports System.IO

Partial Class Service_Record_ad1a4eee3189
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt1, dt2 As DataTable
    Dim report As New ReportDocument
    Dim crSections As Sections
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim aj1 As String = Me.Request.QueryString("emp1")

        Dim aj2 As String = Me.Request.QueryString("emp2")
        Dim dt1 As DataTable
        'Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_code from emp_master where emp_code between " & aj1 & " and " & aj2 & " ").Tables(0)
        If (Session("firm_id") = "9" Or Session("firm_id") = "35") Then
            dt1 = oh.ExecuteDataSet("select em.emp_code    from employee_master em,employ_firm ef where em.emp_code between " & aj1 & " and " & aj2 & "   and em.EMP_CODE = ef.emp_code and ef.firm_id in (35,9)").Tables(0)
        Else
            dt1 = oh.ExecuteDataSet("select em.emp_code    from employee_master em,employ_firm ef where em.emp_code between " & aj1 & " and " & aj2 & "   and em.EMP_CODE = ef.emp_code and ef.firm_id = '" & Session("firm_id") & "'").Tables(0)
        End If
        Dim dr As DataRow
        For Each dr In dt1.Rows




            'dt1 = oh.ExecuteDataSet("select em.emp_name    as Name_of_the_Employee,mw.fat_hus     as Fathers_Husbands_Name, dm.designation as Designation,  mw.basic_pay   as Min_Basic,  mw.vda         as Min_DA,  mw.basic_pay   as Act_Basic,  mw.vda         as Act_DA,  mw.w_days as Tot_attendance,  mw.gross_sal as Gross_wages_payable,  mw.remark_ded as Ded_Emp_Contribution,  mw.oth_ded as Other_Deduction,  mw.tot_dedu as Total_Deduction,  mw.wages_pble as Wages_Paid,  mw.sal_dt as Date_Of_Payment    from employee_master em, m_wage mw, designation_master dm,employ_firm ef,branch_master bm     where    em.emp_code = mw.emp_code and  em.designation_id = dm.designation_id and  em.emp_code = ef.emp_code  and bm.branch_id = em.branch_id and  ef.firm_id = '" & Session("firm_id") & "' and bm.branch_id = '" & Session("branch_id") & "'   order by em.emp_code ").Tables(0)
            dt1 = oh.ExecuteDataSet("select em.emp_name as Name_of_Employee,       ep.father_name as Name_of_Father,       case         when ep.birth_date is not null then          floor(to_number(to_date(sysdate) - to_date(ep.birth_date)) / 360)       end as Age,       ep.perm_add1 as Full_Residential_Address,       decode(ep.sex, 1, 'MALE', 0, 'FEMALE') as Sex,       to_date(em.join_dt) as Date_Of_Entry_To_Service,              decode(ed.discont_dt, null, ' --- ', ed.discont_dt) as Resignation_Date  from employee_master      em,       employ_personal_dtl  ep,              employee_master_dtl  ed        where em.emp_code = ep.emp_code      and em.emp_code = ed.emp_code     and em.emp_code = '" & dr(0) & "' ").Tables(0)

            report.Load(Server.MapPath("ServiceRecordCrystal.rpt"), OpenReportMethod.OpenReportByTempCopy)

            report.Database.Tables("ServiceRecord").SetDataSource(dt1)

            crSections = report.ReportDefinition.Sections
            Dim csect As Section
            Dim rpsub As New ReportDocument
            Dim crsub As SubreportObject
            For Each csect In crSections
                Dim crop As ReportObject
                For Each crop In csect.ReportObjects
                    If crop.Kind = ReportObjectKind.SubreportObject Then
                        crsub = crop
                        rpsub = crsub.OpenSubreport(crsub.SubreportName)

                        If crsub.SubreportName = "Designation" Then
                            ' dt1 = oh.ExecuteDataSet("select t.from_dt as fdt1,case when t.to_dt is not null then (to_date(t.to_dt)-to_date(t.from_dt))+1 else case when t.to_dt is null  then (to_date(sysdate)-to_date(t.from_dt))+1 end end ||' Days ,'||to_char(t.from_dt)||' to ' ||case when t.to_dt is null then to_char(sysdate) else to_char(t.to_dt)end as emp_his,b.BRANCH_NAME||' -- '||dp.dep_name as emp_dtl1,po.post_name as post1,'Gold :'||case when nvl(m.pledge_amt,0)>=10000000 then round(nvl(m.pledge_amt,0)/10000000,2) || ' Crores' else case when nvl(m.pledge_amt,0)>=100000 and nvl(m.pledge_amt,0)<10000000 then round(nvl(m.pledge_amt,0)/100000,2)|| ' Lakhs' else '0'||round(nvl(m.pledge_amt,0)/100000,2)|| ' Lakhs' end end ||' , Deposit :'|| case when nvl(m.deposit_amt,0)>=10000000 then round((nvl(m.deposit_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.deposit_amt,0)>=100000 and nvl(m.deposit_amt,0)<10000000 then round((nvl(m.deposit_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.deposit_amt,0)/100000),2)|| ' Lakhs'  end end||', Hp loan :'|| case when nvl(m.hp_amt,0)>=10000000 then round((nvl(m.hp_amt,0)/10000000),2)|| ' Crore' else case when nvl(m.hp_amt,0)>=100000 and nvl(m.hp_amt,0)<10000000 then round((nvl(m.hp_amt,0)/100000),2)|| ' Lakhs' else '0'|| round((nvl(m.hp_amt,0)/100000),2) || ' Lakhs' end end||', Personalloan :'|| case when nvl(m.pl_amt,0)>=10000000 then round((nvl(m.pl_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.pl_amt,0)>=100000 and nvl(m.pl_amt,0)<10000000 then round((nvl(m.pl_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.pl_amt,0)/100000),2)|| ' Lakhs' end end ||', Businessloan :'||case when nvl(m.bl_amt,0)>=10000000 then round((nvl(m.bl_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.bl_amt,0)>=100000 and nvl(m.bl_amt,0)<10000000 then round((nvl(m.bl_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.bl_amt,0)/100000),2)|| ' Lakhs' end end||', Secloan :'||case when nvl(m.sec_amt,0)>=10000000 then round((nvl(m.sec_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.sec_amt,0)>=100000 and nvl(m.sec_amt,0)<10000000 then round((nvl(m.sec_amt,0)/100000),2)|| ' Lakhs' else round((nvl(m.sec_amt,0)/100000),2)|| ' Lakhs' end end  as amount  from  branch b,employee_master e, employ_transfer_dtl t left outer join month_balance m on (m.branch_id=t.branch_id and to_char(m.tra_dt,'MM/yyyy')=to_char(case when t.to_dt is null then to_date(sysdate) else to_date(t.to_dt) end,'MM/yyyy' ))   left outer join post_mst po on (t.post_id=po.post_id) left outer join department_mst dp on (t.department_id=dp.dep_id)   where e.emp_code= " & Request.QueryString("empid") & " and e.emp_code=t.emp_code and t.branch_id=b.BRANCH_ID and e.emp_type=1 and  t.status_id=8 and e.status_id=1  group by t.to_dt,t.from_dt,b.BRANCH_NAME,po.post_name,dp.dep_name,m.pledge_amt,m.deposit_amt,m.hp_amt,m.pl_amt, m.bl_amt,m.sec_amt union select t.from_dt as fdt1,case when t.to_dt is not null then (to_date(t.to_dt)-to_date(t.from_dt))+1 else case when t.to_dt is null  then (to_date(sysdate)-to_date(t.from_dt))+1 end end ||' Days ,'||to_char(t.from_dt)||' to ' ||case when t.to_dt is null then to_char(sysdate) else to_char(t.to_dt)end as emp_his,b.BRANCH_NAME||' -- '||dp.dep_name as emp_dtl1,po.post_name as post1, 'Gold :'||case when nvl(m.pledge_amt,0)>=10000000 then round(nvl(m.pledge_amt,0)/10000000,2) || ' Crores' else case when nvl(m.pledge_amt,0)>=100000 and nvl(m.pledge_amt,0)<10000000 then round(nvl(m.pledge_amt,0)/100000,2)|| ' Lakhs' else '0'||round(nvl(m.pledge_amt,0)/100000,2)|| ' Lakhs' end end ||' , Deposit :'|| case when nvl(m.deposit_amt,0)>=10000000 then round((nvl(m.deposit_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.deposit_amt,0)>=100000 and nvl(m.deposit_amt,0)<10000000 then round((nvl(m.deposit_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.deposit_amt,0)/100000),2)|| ' Lakhs'  end end||', Hp loan :'|| case when nvl(m.hp_amt,0)>=10000000 then round((nvl(m.hp_amt,0)/10000000),2)|| ' Crore' else case when nvl(m.hp_amt,0)>=100000 and nvl(m.hp_amt,0)<10000000 then round((nvl(m.hp_amt,0)/100000),2)|| ' Lakhs' else '0'|| round((nvl(m.hp_amt,0)/100000),2) || ' Lakhs' end end||', Personalloan :'|| case when nvl(m.pl_amt,0)>=10000000 then round((nvl(m.pl_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.pl_amt,0)>=100000 and nvl(m.pl_amt,0)<10000000 then round((nvl(m.pl_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.pl_amt,0)/100000),2)|| ' Lakhs' end end ||', Businessloan :'||case when nvl(m.bl_amt,0)>=10000000 then round((nvl(m.bl_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.bl_amt,0)>=100000 and nvl(m.bl_amt,0)<10000000 then round((nvl(m.bl_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.bl_amt,0)/100000),2)|| ' Lakhs' end end||', Secloan :'||case when nvl(m.sec_amt,0)>=10000000 then round((nvl(m.sec_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.sec_amt,0)>=100000 and nvl(m.sec_amt,0)<10000000 then round((nvl(m.sec_amt,0)/100000),2)|| ' Lakhs' else round((nvl(m.sec_amt,0)/100000),2)|| ' Lakhs' end end  as amount from  branch b,employee_master e,employ_transfer_dtl t left outer join month_balance m on (m.branch_id=t.branch_id and to_char(m.tra_dt,'MM/yyyy')=to_char(case when t.to_dt is null then to_date(sysdate) else to_date(t.to_dt) end,'MM/yyyy' )) left outer join post_mst po on (t.post_id=po.post_id) left outer join department_mst dp on (t.department_id=dp.dep_id)   where e.emp_code= " & Request.QueryString("empid") & " and e.emp_code=t.emp_code and t.branch_id=b.BRANCH_ID and e.emp_type=2 and  t.status_id=8 and e.status_id=1 group by t.to_dt,t.from_dt,b.BRANCH_NAME,po.post_name,dp.dep_name,m.pledge_amt,m.deposit_amt,m.hp_amt,m.pl_amt, m.bl_amt,m.sec_amt union select t.from_dt as fdt1,case when t.to_dt is not null then (to_date(t.to_dt)-to_date(t.from_dt))+1 else case when t.to_dt is null  then (to_date(sysdate)-to_date(t.from_dt))+1 end end ||' Days ,'||to_char(t.from_dt)||' to ' ||case when t.to_dt is null then to_char(sysdate) else to_char(t.to_dt)end as emp_his,b.BRANCH_NAME||' -- '||dp.dep_name as emp_dtl1,po.post_name as post1, 'Gold :'||case when nvl(m.pledge_amt,0)>=10000000 then round(nvl(m.pledge_amt,0)/10000000,2) || ' Crores' else case when nvl(m.pledge_amt,0)>=100000 and nvl(m.pledge_amt,0)<10000000 then round(nvl(m.pledge_amt,0)/100000,2)|| ' Lakhs' else '0'||round(nvl(m.pledge_amt,0)/100000,2)|| ' Lakhs' end end ||' , Deposit :'|| case when nvl(m.deposit_amt,0)>=10000000 then round((nvl(m.deposit_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.deposit_amt,0)>=100000 and nvl(m.deposit_amt,0)<10000000 then round((nvl(m.deposit_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.deposit_amt,0)/100000),2)|| ' Lakhs'  end end||', Hp loan :'|| case when nvl(m.hp_amt,0)>=10000000 then round((nvl(m.hp_amt,0)/10000000),2)|| ' Crore' else case when nvl(m.hp_amt,0)>=100000 and nvl(m.hp_amt,0)<10000000 then round((nvl(m.hp_amt,0)/100000),2)|| ' Lakhs' else '0'|| round((nvl(m.hp_amt,0)/100000),2) || ' Lakhs' end end||', Personalloan :'|| case when nvl(m.pl_amt,0)>=10000000 then round((nvl(m.pl_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.pl_amt,0)>=100000 and nvl(m.pl_amt,0)<10000000 then round((nvl(m.pl_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.pl_amt,0)/100000),2)|| ' Lakhs' end end ||', Businessloan :'||case when nvl(m.bl_amt,0)>=10000000 then round((nvl(m.bl_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.bl_amt,0)>=100000 and nvl(m.bl_amt,0)<10000000 then round((nvl(m.bl_amt,0)/100000),2)|| ' Lakhs' else '0'||round((nvl(m.bl_amt,0)/100000),2)|| ' Lakhs' end end||', Secloan :'||case when nvl(m.sec_amt,0)>=10000000 then round((nvl(m.sec_amt,0)/10000000),2)|| ' Crores' else case when nvl(m.sec_amt,0)>=100000 and nvl(m.sec_amt,0)<10000000 then round((nvl(m.sec_amt,0)/100000),2)|| ' Lakhs' else round((nvl(m.sec_amt,0)/100000),2)|| ' Lakhs' end end  as amount  from  branch b,employee_master e, employ_transfer_dtl t left outer join month_balance m on (m.branch_id=t.branch_id and to_char(m.tra_dt,'MM/yyyy')=to_char(case when t.to_dt is null then to_date(sysdate) else to_date(t.to_dt) end,'MM/yyyy' )) left outer join post_mst po on (t.post_id=po.post_id) left outer join department_mst dp on (t.department_id=dp.dep_id)   where t.branch_id=b.BRANCH_ID and e.emp_type=2 and e.emp_code in (select ww.emp_code from employee_master_dtl ww where ww.new_empcode is not null and ww.discont_dt is not null and ww.new_empcode= " & Request.QueryString("empid") & " ) and  e.emp_code=t.emp_code and  t.status_id=8 group by t.to_dt,t.from_dt,b.BRANCH_NAME,po.post_name,dp.dep_name ,m.pledge_amt,m.deposit_amt,m.hp_amt,m.pl_amt, m.bl_amt,m.sec_amt order by fdt1").Tables(0)

                            dt2 = oh.ExecuteDataSet("select dm.designation as Desig,             to_date(e.from_dt) as dfdt,       nvl(e.to_dt, to_date(sysdate)) dtdt        from employee_master      em,       employ_personal_dtl  ep,       designation_master   dm,       employee_master_dtl  ed,       employ_promotion_dtl e where em.emp_code = ep.emp_code   and e.designation_id = dm.designation_id   and em.emp_code = ed.emp_code   and e.emp_code = em.emp_code   and em.emp_code = '" & dr(0) & "' order by e.from_dt").Tables(0)
                            rpsub.Database.Tables("DataTable3").SetDataSource(dt2)
                        End If
                        If crsub.SubreportName = "Pay" Then
                            Dim dt16 As DataTable = oh.ExecuteDataSet("select        e.basic_pay as Payy,       case when e.da_flag='F' then 0 else w.value end  as DAa,       to_date(e.from_dt) as pfdt,       nvl(e.to_dt, to_date(sysdate)) ptdt        from employee_master      em,       employ_personal_dtl  ep,       designation_master   dm,       employee_master_dtl  ed,       employ_promotion_dtl e,       da_index               w where em.emp_code = ep.emp_code   and e.designation_id = dm.designation_id   and em.emp_code = ed.emp_code   and e.emp_code = em.emp_code   and  w.to_dt is null   and em.emp_code = '" & dr(0) & "' order by e.from_dt").Tables(0)
                            rpsub.Database.Tables("DataTable6").SetDataSource(dt16)

                        End If

                    End If
                Next

            Next




            report.SetParameterValue("FIRM", Session("firm_name"))

            ' ''export = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            'Dim stream As System.IO.BinaryReader = New BinaryReader(report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
            'Response.Clear()
            'Response.Buffer = True
            'Response.ContentType = "application/pdf"
            'Response.AddHeader("content-disposition", "attachment;filename=ServiceRecord.pdf")
            'Response.AddHeader("content-length", stream.BaseStream.Length.ToString)
            'Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)))
            ' ''Response.BinaryWrite(export.ToArray)
            'Response.End()



            'Me.CrystalReportViewer1.DisplayGroupTree = True

            'Me.CrystalReportViewer1.ReportSource = report
            Try
                Dim DirPath As String
                DirPath = Server.MapPath("~/Payroll/Posting/ServiceRecord")
                Dim di As DirectoryInfo = New DirectoryInfo(DirPath)

                'If di.Exists Then
                '    di.Delete()
                'Else
                di.Create()
                'End If
                Dim ExpOptions As ExportOptions
                Dim DiskFileDestOpts As New DiskFileDestinationOptions
                Dim FormatTypeOpts As New PdfRtfWordFormatOptions
                DiskFileDestOpts.DiskFileName = DirPath & "\" & dr(0) & "servicerecord.pdf"
                ExpOptions = report.ExportOptions
                With ExpOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .DestinationOptions = DiskFileDestOpts
                    .FormatOptions = FormatTypeOpts
                End With
                report.Export()
            Catch Ex As Exception
                MsgBox(Ex.ToString)
            End Try
        Next
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub

    'Protected Sub ids_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ids.Click


    'End Sub
End Class
