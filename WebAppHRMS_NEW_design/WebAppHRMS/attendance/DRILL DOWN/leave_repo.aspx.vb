Imports System.Data.OracleClient
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class leaverepo_9ff5ab3a4581
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim s, a, ses As String
    Dim dt, dt1, dt2 As DataTable
    Dim rep As New ReportDocument
    Dim brid As String
    Dim str_tkn As New StringBuilder

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            Dim from As String = Request.QueryString.Get("FromDt")
            Dim tod As String = Request.QueryString.Get("ToDt")
            Dim per As Integer = CInt(Request.QueryString.Get("per"))

            Dim ff As Integer = Session("firm_id")
            Dim firm As String = Session("firm_name")
            Dim usr() As String = Me.Session("user_id").ToString.Split("!")

            dt = oh.ExecuteDataSet("select t.EMPCODE as EMPCODE,t.emp_name as EMP_NAME,t.LEAVE_TYPE as LEAVE_TYPE,to_char(t.FROM_DATE,'dd-MON-yyyy') as FROM_DATE ,case when to_date(t.TO_DATE) > to_date('" & tod & "') then           to_char('" & tod & "')          else           to_char(t.TO_DATE,'dd-MON-yyyy')           end           as TO_DATE ,           case           when to_date(t.TO_DATE) > to_date('" & tod & "') then            to_date('" & tod & "') - to_date(t.FROM_DATE)           else            t.leave_days             end             as LEAVE_DAYS,    t.REASON as REASON        from EMP_LVS t where t.firm_id=" & ff & " and t.FROM_DATE between to_date('" & from & "') and                to_date('" & tod & "')                and t.EMPCODE in          ( select e.EMPCODE            from EMP_LVS e             where             e.firm_id=" & ff & " and e.EMPCODE=t.EMPCODE and e.FROM_DATE between to_date('" & from & "') and                to_date('" & tod & "')               group by e.EMPCODE               having sum(case          when to_date(e.TO_DATE) > to_date('" & tod & "') then            to_date('" & tod & "') - to_date(e.FROM_DATE)          else           e.leave_days        end) > " & per & " )").Tables(0)

            If dt.Rows.Count = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert('Record Not Found!');")
                cl_script0.Append("window.open('../../home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Else
                rep.Load(Server.MapPath("leave_rep_period.rpt"), OpenReportMethod.OpenReportByTempCopy)
                rep.Database.Tables("LEAVE_TAB").SetDataSource(dt)
                rep.SetParameterValue("user", usr(0))
                rep.SetParameterValue("fid", ff)
                rep.SetParameterValue("fname", firm)
                rep.SetParameterValue("fromdt", from)
                rep.SetParameterValue("todt", tod)
                rep.SetParameterValue("period", per)
                Me.CrystalReportViewer1.ReportSource = rep

            End If


        Catch ex As Exception
            rep.Close()
            rep.Dispose()
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        '    Dim from As String = Request.QueryString.Get("FromDt")
        '    Dim tod As String = Request.QueryString.Get("ToDt")
        '    Dim per As Integer = CInt(Request.QueryString.Get("per"))

        '    Dim ff As Integer = Session("firm_id")
        '    Dim firm As String = Session("firm_name")
        '    Dim usr() As String = Me.Session("user_id").ToString.Split("!")

        '    dt = oh.ExecuteDataSet("select t.EMPCODE as EMPCODE,t.emp_name as EMP_NAME,t.LEAVE_TYPE as LEAVE_TYPE,t.FROM_DATE as FROM_DATE ,case when to_date(t.TO_DATE) > to_date('" & tod & "') then           to_date('" & tod & "')          else           t.TO_DATE           end           as TO_DATE ,           case           when to_date(t.TO_DATE) > to_date('" & tod & "') then            to_date('" & tod & "') - to_date(t.FROM_DATE)           else            t.leave_days             end             as LEAVE_DAYS,    t.REASON as REASON        from EMP_LVS t where t.firm_id=" & ff & " and t.FROM_DATE between to_date('" & from & "') and                to_date('" & tod & "')                and t.EMPCODE in          ( select e.EMPCODE            from EMP_LVS e             where             e.firm_id=" & ff & " and e.EMPCODE=t.EMPCODE and e.FROM_DATE between to_date('" & from & "') and                to_date('" & tod & "')               group by e.EMPCODE               having sum(case          when to_date(e.TO_DATE) > to_date('" & tod & "') then            to_date('" & tod & "') - to_date(e.FROM_DATE)          else           e.leave_days        end) > " & per & " )").Tables(0)

        '    If dt.Rows.Count = 0 Then
        '        Dim cl_script0 As New System.Text.StringBuilder
        '        cl_script0.Append("         alert('Record Not Found!');")
        '        cl_script0.Append("window.open('../../home.aspx','_self');")
        '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        '    Else
        '        rep.Load(Server.MapPath("leave_rep_period.rpt"), OpenReportMethod.OpenReportByTempCopy)
        '        rep.Database.Tables("LEAVE_TAB").SetDataSource(dt)
        '        rep.SetParameterValue("user", usr(0))
        '        rep.SetParameterValue("fid", ff)
        '        rep.SetParameterValue("fname", firm)
        '        rep.SetParameterValue("fromdt", from)
        '        rep.SetParameterValue("todt", tod)
        '        rep.SetParameterValue("period", per)
        '        Me.CrystalReportViewer1.ReportSource = rep

        '    End If


        'Catch ex As Exception
        '    rep.Close()
        '    rep.Dispose()
        'End Try

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rep.Close()
        rep.Dispose()
    End Sub
    'Sub new_metho()
    '    Dim from As String = Request.QueryString.Get("FromDt")
    '    Dim tod As String = Request.QueryString.Get("ToDt")
    '    Dim per As Integer = CInt(Request.QueryString.Get("per"))

    '    Dim ff As Integer = Session("firm_id")
    '    Dim firm As String = Session("firm_name")
    '    Dim usr() As String = Me.Session("user_id").ToString.Split("!")

    '    dt = oh.ExecuteDataSet("select t.EMPCODE as EMPCODE,t.emp_name as EMP_NAME,t.LEAVE_TYPE as LEAVE_TYPE,t.FROM_DATE as FROM_DATE ,case when to_date(t.TO_DATE) > to_date('" & tod & "') then           to_date('" & tod & "')          else           t.TO_DATE           end           as TO_DATE ,           case           when to_date(t.TO_DATE) > to_date('" & tod & "') then            to_date('" & tod & "') - to_date(t.FROM_DATE)           else            t.leave_days             end             as LEAVE_DAYS,    t.REASON as REASON        from EMP_LVS t where t.firm_id=" & ff & " and t.FROM_DATE between to_date('" & from & "') and                to_date('" & tod & "')                and t.EMPCODE in          ( select e.EMPCODE            from EMP_LVS e             where             e.firm_id=" & ff & " and e.EMPCODE=t.EMPCODE and e.FROM_DATE between to_date('" & from & "') and                to_date('" & tod & "')               group by e.EMPCODE               having sum(case          when to_date(e.TO_DATE) > to_date('" & tod & "') then            to_date('" & tod & "') - to_date(e.FROM_DATE)          else           e.leave_days        end) > " & per & " )").Tables(0)

    '    If dt.Rows.Count = 0 Then
    '        Dim cl_script0 As New System.Text.StringBuilder
    '        cl_script0.Append("         alert('Record Not Found!');")
    '        cl_script0.Append("window.open('../../home.aspx','_self');")
    '        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
    '    Else
    '        rep.Load(Server.MapPath("leave_rep_period.rpt"), OpenReportMethod.OpenReportByTempCopy)
    '        rep.Database.Tables("LEAVE_TAB").SetDataSource(dt)
    '        rep.SetParameterValue("user", usr(0))
    '        rep.SetParameterValue("fid", ff)
    '        rep.SetParameterValue("fname", firm)
    '        rep.SetParameterValue("fromdt", from)
    '        rep.SetParameterValue("todt", tod)
    '        rep.SetParameterValue("period", per)
    '        Me.CrystalReportViewer1.ReportSource = rep

    '    End If
    'End Sub
End Class
