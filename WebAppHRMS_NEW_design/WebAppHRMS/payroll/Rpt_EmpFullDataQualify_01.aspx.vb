Imports System.Data
Imports System.Data.OracleClient
Partial Class PayRoll_Rpt_EmpFullData_01_560e82905011
    Inherits System.Web.UI.Page
    Dim CH As New WholeHelper.ClsComCtrl
    Dim IT As New IT.BLL.Common
    Dim RH As New IT.IDAL.ResultHandler
    Dim DT As New DataTable
    Dim cbResult As String
    Dim OH As New helper.oracle.OracleHelper
    Dim StateID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.Master, WebAppHRMS.edp).Subtitle = "EMPLOYE DETAILS - QUALIFICATION WISE"
        Dim FirmID, BranchID As Integer
        FirmID = Session("firm_id")
        BranchID = Session("branch_id")
        If BranchID <> 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You Can Accessible in " & vbNewLine & " Head Office Only!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
            Exit Sub
        End If
        '--//---------- Script Registrations -----------//--
        Dim script_val As String
        script_val = "var header;" & "header='" & Me.cmbQualify.ClientID & "';"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        If Not IsPostBack Then
            DT = QualifyFill()
            CH.ComboFill(cmbQualify, DT, 0, 1)
            DT = StateFill()
            CH.ComboFill(cmbState, DT, 0, 1)
            'DT = GenderFill()
            '  CH.ComboFill(Me.cmbGender, DT, 0, 1)
        End If
    End Sub
    Public Function QualifyFill() As DataTable
        DT = OH.ExecuteDataSet("select -1 as CATEGORY_ID,'-ALL-' from dual union select a.CATEGORY_ID,a.CATEGORY from qualification_category a order by CATEGORY_ID").Tables(0)
        Return DT
    End Function
    Public Function StateFill() As DataTable
        DT = OH.ExecuteDataSet("select -1 as state_id,'-ALL-' as state_name from dual union select state_id,state_name from state_master where state_id in(select distinct state_id from district_master where district_id in(select distinct district_id from branch_master))order by state_name").Tables(0)
        Return DT
    End Function
    'Public Function GenderFill() As DataTable
    '    DT = OH.ExecuteDataSet("select -1 as gender_id,'-ALL-' from dual union select gender_id,gender_name from gender where gender_id>0 order by gender_id").Tables(0)
    '    Return DT
    'End Function
End Class
