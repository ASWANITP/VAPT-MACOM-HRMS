Imports System.Data
Imports System.Data.OracleClient
Partial Class Holiday_Change_hrm_holodayChange_f727a9fc6124
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim cbResult As String
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim UserAll(), res, sql, str As String
    Dim UserCode As Integer
    Dim st As New StringBuilder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        Dim acce As Integer = oh.ExecuteDataSet("select count(*) from form_accessibility t where form_id=174 and emp_id=" & UserCode).Tables(0).Rows(0)(0)
        If acce > 0 Then
            Dim script_val As String
            script_val = "var header;" & "header='" & Me.ddlState.ClientID & "';"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)

            Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
            Dim cbscript As String = "function callserver (arg,context) {" & cbref & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "callserver", cbscript, True)

            If Not IsPostBack Then

                dt1 = oh.ExecuteDataSet("select -1 as Zonal_id,' --------SELECT----------' as  Zonal_name from dual union select z.Zonal_id, Z.Zonal_name from Zonal_master z order by zonal_name").Tables(0)
                Me.ddlZone.DataSource = dt1
                Me.ddlZone.DataValueField = dt1.Columns(0).ColumnName
                Me.ddlZone.DataTextField = dt1.Columns(1).ColumnName
                Me.ddlZone.DataBind()
                Me.ddlZone.Focus()
            End If
            Me.btnDelete.Attributes.Add("onclick", "return ConfirmOnClick()")
        Else
            Me.Server.Transfer("../show_err.aspx")
        End If
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim cal_data = eventArgument
        Dim str() As String
        str = cal_data.ToString.Split("$")
        Dim x = str(0)
        Select Case (x)

            Case "1" 'District

                dt = oh.ExecuteDataSet("select ' 15-Aug-1947' as holiday ,' --- Select HoliDay ---' as HolShow,to_date(' 15-Aug-1947') as hol_day from dual union all select distinct to_char(c.hol_day,'DD-Mon-YYYY') as holiday,to_char(c.hol_day,'DD-Mon-YYYY') as HolShow,to_date(c.hol_day) from common_holiday c where c.hol_day>to_date(sysdate) and c.district_id= " & str(1) & " order by hol_day").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "2" 'Branch

                dt = oh.ExecuteDataSet("select ' 15-Aug-1947' as holiday ,' --- Select HoliDay ---' as HolShow,to_date('15-Aug-1947') as holday from dual union all select distinct to_char(c.hol_day,'DD-Mon-YYYY') as holiday,to_char(c.hol_day,'DD-Mon-YYYY') as HolShow ,to_date(c.hol_day) from common_holiday c where c.hol_day>to_date(sysdate) and c.branch_id= " & str(1) & " order by holday").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "3" 'State

                dt = oh.ExecuteDataSet("select ' 15-Aug-1947' as holiday ,' --- Select HoliDay ---' as HolShow,to_date(' 15-Aug-1947') as holday from dual union all select distinct to_char(c.hol_day,'DD-Mon-YYYY') as holiday,to_char(c.hol_day,'DD-Mon-YYYY') as HolShow,to_date(c.hol_day) from common_holiday c where c.hol_day>to_date(sysdate) and c.state_id= " & str(1) & " order by holday").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "4" 'Zonal

                dt = oh.ExecuteDataSet("select ' 15-Aug-1947' as holiday ,' --- Select HoliDay ---' as HolShow,to_date(' 15-Aug-1947') as holday from dual union all select distinct to_char(c.hol_day,'DD-Mon-YYYY') as holiday,to_char(c.hol_day,'DD-Mon-YYYY') as HolShow,to_date(c.hol_day) from common_holiday c ,branch_detail b where c.hol_day>to_date(sysdate) and c.branch_id=b.BRANCH_ID and b.zonal_id = " & str(1) & "  order by holday").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "5" 'Region

                dt = oh.ExecuteDataSet("select ' 15-Aug-1947' as holiday ,' --- Select HoliDay ---' as HolShow,to_date(' 15-Aug-1947') as holday from dual union all select distinct to_char(c.hol_day,'DD-Mon-YYYY') as holiday,to_char(c.hol_day,'DD-Mon-YYYY') as HolShow,to_date(c.hol_day) from common_holiday c ,branch_detail b where c.hol_day>to_date(sysdate) and c.branch_id=b.BRANCH_ID and b.reg_id = " & str(1) & " order by holday").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "6" 'Area

                dt = oh.ExecuteDataSet("select ' 15-Aug-1947' as holiday ,' --- Select HoliDay ---' as HolShow,to_date(' 15-Aug-1947') as holday from dual union all select distinct to_char(c.hol_day,'DD-Mon-YYYY') as holiday,to_char(c.hol_day,'DD-Mon-YYYY') as HolShow ,to_date(c.hol_day) from common_holiday c ,branch_detail b where c.hol_day>to_date(sysdate) and c.branch_id=b.BRANCH_ID and b.area_id = " & str(1) & "  order by holday").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "8" 'Region

                dt = oh.ExecuteDataSet("select 0 as reg_id,'--SELECT--' as  reg_name from dual union all select r.reg_id, r.reg_name from region_master r order by reg_name").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "9" 'Area

                dt = oh.ExecuteDataSet("select -1 as area_id,' --------SELECT----------' as  area_name from dual union select t.area_id, t.area_name from area_master t order by area_name").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "10" 'State

                dt = oh.ExecuteDataSet("select -1 as state_id,' --------SELECT----------' as  state_name from dual union select t.state_id, t.state_name from state_master t order by state_name").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "11" 'District

                dt = oh.ExecuteDataSet("select -1 as district_id,' --------SELECT----------' as  district_name from dual union select t.district_id, t.district_name from district_master t order by district_name").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

            Case "12" 'Branch

                dt = oh.ExecuteDataSet("select -1 as branch_id,' --------SELECT----------' as  branch_name from dual union select t.branch_id, t.branch_name from branch_master t order by branch_name").Tables(0)
                res = FillData(res, dt)
                res = res + "@"

        End Select
    End Sub
    Public Function FillData(ByVal cbResult As String, ByVal DT As DataTable) As String
        For n As Integer = 0 To DT.Rows.Count - 1
            cbResult += DT.Rows(n)(0).ToString
            cbResult += "$"
            cbResult += DT.Rows(n)(1).ToString
            If n < DT.Rows.Count - 1 Then
                cbResult += "*"
            End If
        Next
        Return cbResult
    End Function

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim fla As Integer

        If Me.rdZone.Checked = True Then 'Zone

            fla = 1
           
        ElseIf Me.rdRegion.Checked = True Then 'Region

            fla = 2

        ElseIf Me.rdArea.Checked = True Then 'Area

            fla = 3

        ElseIf Me.rdState.Checked = True Then 'State

            fla = 4

        ElseIf Me.rdDistrict.Checked = True Then 'District

            fla = 5

        ElseIf Me.rdBranch.Checked = True Then 'Branch

            fla = 6
           
        Else

            fla = 7

        End If

        Try
            Dim pr(3) As OracleParameter

            pr(0) = New OracleParameter("hid", OracleType.Number, 8)
            pr(0).Value = Me.Hidden2.Value

            pr(1) = New OracleParameter("flg", OracleType.Number, 2)
            pr(1).Value = fla

            pr(2) = New OracleParameter("holiday", OracleType.VarChar, 15)
            pr(2).Value = Me.Hidden3.Value

            pr(3) = New OracleParameter("msg", OracleType.VarChar, 500)
            pr(3).Direction = ParameterDirection.Output

            oh.ExecuteNonQuery("hrm_BranchHoliday_Delete", pr)

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('" & pr(3).Value & "');")
            cl_script1.Append("window.open('hrm_holodayChange.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)

        Catch ex As Exception
        End Try

    End Sub
End Class
