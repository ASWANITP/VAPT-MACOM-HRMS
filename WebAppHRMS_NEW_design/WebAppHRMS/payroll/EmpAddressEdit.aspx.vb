Imports System.Data
Imports System.Data.OracleClient
Partial Class test_EmpAddressEdit_bc3b5c8c2679
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim oh As New helper.oracle.OracleHelper
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim str, res As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.hidEmpCode.Value = Me.Request.QueryString("empCode")
        ''//-=--===- Common -=-=-==-=//'
        'Dim script_val As String
        'script_val = "var loanno;" & "loanno='" & "" & Me.txtPermHouse.ClientID & "'" & " ; "
        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "val", script_val, True)
        '//-=-=-==-=-=-= Call Server Reg.-=-===-=-=//
        Dim cbref As String = Page.ClientScript.GetCallbackEventReference(Me, "arg", "call_receiver", "context")
        Dim cbscript As String = "function call_server (arg,context) {" & cbref & ";}"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "call_server", cbscript, True)
        '/// =-=-=-=-=-=-=-=-=-=-==End Of Common -====-==-=====-=-=//
    End Sub

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return res
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim cal_data = eventArgument
        Dim str(), dtr() As String
        str = cal_data.ToString.Split("$")
        Dim st As New StringBuilder
        Dim x = str(0)
        Dim i As Integer = 0
        Dim PosID, disID As Integer
        Select Case (x)
            Case "1"
                st.Append("11")
                st.Append("^")
                Dim EmpCount As Integer = oh.ExecuteDataSet("select count(*) from employee_master em,employ_personal_dtl ep where em.emp_code = ep.emp_code and em.emp_code > 9999 and em.emp_code = " & str(1)).Tables(0).Rows(0)(0)
                If EmpCount = 1 Then
                    Dim AddCodes As String = oh.ExecuteDataSet("select ep.perm_add1||'~'||pm.sr_number||'~'||dm.district_id||'~'||dm.state_id||'~'||pm.pin_code||'~'||ep.pres_add1||'~'||pm1.sr_number||'~'||dm1.district_id||'~'||dm1.state_id||'~'||pm1.pin_code from employ_personal_dtl ep left outer join post_master pm on (ep.perm_pin = pm.sr_number) left outer join district_master dm on (pm.district_id = dm.district_id) left outer join post_master pm1 on (ep.pres_pin = pm1.sr_number) left outer join district_master dm1 on (pm1.district_id = dm1.district_id) where ep.emp_code = " & str(1)).Tables(0).Rows(0)(0)
                    dtr = AddCodes.Split("~")
                    Dim StateDt As DataTable = oh.ExecuteDataSet("select sm.state_id||'�'||sm.state_name from state_master sm order by state_name").Tables(0)
                    Dim PermDistrictDt As DataTable = oh.ExecuteDataSet("select dm.district_id||'�'||dm.district_name from district_master dm where dm.state_id = " & dtr(3) & " order by district_name").Tables(0)
                    Dim PermPostDt As DataTable = oh.ExecuteDataSet("select pm.sr_number||'�'||pm.post_office from post_master pm where pm.district_id = " & dtr(2) & " order by pm.post_office").Tables(0)
                    Dim PreDistrictDt As DataTable = oh.ExecuteDataSet("select dm.district_id||'�'||dm.district_name from district_master dm where dm.state_id = " & dtr(8) & " order by district_name").Tables(0)
                    Dim PrePostDt As DataTable = oh.ExecuteDataSet("select pm.sr_number||'�'||pm.post_office from post_master pm where pm.district_id = " & dtr(7) & " order by pm.post_office").Tables(0)
                    st.Append(AddCodes)
                    st.Append("$")
                    If StateDt.Rows.Count > 0 Then
                        For Each dr In StateDt.Rows
                            st.Append(dr(0))
                            st.Append("%")
                        Next
                    End If
                    st.Append("$")
                    If PermDistrictDt.Rows.Count > 0 Then
                        For Each dr In PermDistrictDt.Rows
                            st.Append(dr(0))
                            st.Append("%")
                        Next
                    End If
                    st.Append("$")
                    If PermPostDt.Rows.Count > 0 Then
                        For Each dr In PermPostDt.Rows
                            st.Append(dr(0))
                            st.Append("%")
                        Next
                    End If
                    st.Append("$")
                    If PreDistrictDt.Rows.Count > 0 Then
                        For Each dr In PreDistrictDt.Rows
                            st.Append(dr(0))
                            st.Append("%")
                        Next
                    End If
                    st.Append("$")
                    If PrePostDt.Rows.Count > 0 Then
                        For Each dr In PrePostDt.Rows
                            st.Append(dr(0))
                            st.Append("%")
                        Next
                    End If
                Else
                    st.Append("N")
                End If
            Case "2"
                i = 0
                PosID = 0
                st.Append("12")
                st.Append("^")
                disID = 0
                Dim strDistrict As String = "select dm.district_id||'�'||dm.district_name from district_master dm where dm.state_id = " & str(1) & " order by district_name"
                dt = oh.ExecuteDataSet(strDistrict).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        If i = 0 Then
                            Dim ss() As String = dr(0).split("�")
                            disID = ss(0)
                            i = i + 1
                        End If
                        st.Append(dr(0))
                        st.Append("%")
                    Next
                End If
                st.Append("$")
                i = 0
                Dim strPost As String = "select pm.sr_number||'�'||pm.post_office from post_master pm where pm.district_id = " & disID & " order by pm.post_office"
                dt = oh.ExecuteDataSet(strPost).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        If i = 0 Then
                            Dim ss() As String = dr(0).split("�")
                            PosID = ss(0)
                            i = i + 1
                        End If
                        st.Append(dr(0))
                        st.Append("%")
                    Next
                End If
                st.Append("$")
                Dim PinCode As Integer = oh.ExecuteDataSet("select pin_code from post_master where sr_number = " & PosID & "").Tables(0).Rows(0)(0)
                st.Append(PinCode)
            Case "3"
                i = 0
                PosID = 0
                st.Append("13")
                st.Append("^")
                disID = 0
                Dim strPost As String = "select pm.sr_number||'�'||pm.post_office from post_master pm where pm.district_id = " & str(1) & " order by pm.post_office"
                dt = oh.ExecuteDataSet(strPost).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        If i = 0 Then
                            Dim ss() As String = dr(0).split("�")
                            PosID = ss(0)
                            i = i + 1
                        End If
                        st.Append(dr(0))
                        st.Append("%")
                    Next
                End If
                st.Append("$")
                Dim PinCode As Integer = oh.ExecuteDataSet("select pin_code from post_master where sr_number = " & PosID & "").Tables(0).Rows(0)(0)
                st.Append(PinCode)
            Case "4"
                st.Append("14")
                st.Append("^")
                Dim PinCode As Integer = oh.ExecuteDataSet("select pin_code from post_master where sr_number = " & str(1) & "").Tables(0).Rows(0)(0)
                st.Append(PinCode)
            Case "5"
                i = 0
                PosID = 0
                st.Append("15")
                st.Append("^")
                disID = 0
                Dim strDistrict As String = "select dm.district_id||'�'||dm.district_name from district_master dm where dm.state_id = " & str(1) & " order by district_name"
                dt = oh.ExecuteDataSet(strDistrict).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        If i = 0 Then
                            Dim ss() As String = dr(0).split("�")
                            disID = ss(0)
                            i = i + 1
                        End If
                        st.Append(dr(0))
                        st.Append("%")
                    Next
                End If
                st.Append("$")
                i = 0
                Dim strPost As String = "select pm.sr_number||'�'||pm.post_office from post_master pm where pm.district_id = " & disID & " order by pm.post_office"
                dt = oh.ExecuteDataSet(strPost).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        If i = 0 Then
                            Dim ss() As String = dr(0).split("�")
                            PosID = ss(0)
                            i = i + 1
                        End If
                        st.Append(dr(0))
                        st.Append("%")
                    Next
                End If
                st.Append("$")
                Dim PinCode As Integer = oh.ExecuteDataSet("select pin_code from post_master where sr_number = " & PosID & "").Tables(0).Rows(0)(0)
                st.Append(PinCode)
            Case "6"
                i = 0
                PosID = 0
                st.Append("16")
                st.Append("^")
                disID = 0
                Dim strPost As String = "select pm.sr_number||'�'||pm.post_office from post_master pm where pm.district_id = " & str(1) & " order by pm.post_office"
                dt = oh.ExecuteDataSet(strPost).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        If i = 0 Then
                            Dim ss() As String = dr(0).split("�")
                            PosID = ss(0)
                            i = i + 1
                        End If
                        st.Append(dr(0))
                        st.Append("%")
                    Next
                End If
                st.Append("$")
                Dim PinCode As Integer = oh.ExecuteDataSet("select pin_code from post_master where sr_number = " & PosID & "").Tables(0).Rows(0)(0)
                st.Append(PinCode)
            Case "7"
                st.Append("17")
                st.Append("^")
                Dim PinCode As Integer = oh.ExecuteDataSet("select pin_code from post_master where sr_number = " & str(1) & "").Tables(0).Rows(0)(0)
                st.Append(PinCode)
            Case "8"
                i = 0
                PosID = 0
                st.Append("18")
                st.Append("^")
                disID = 0
                Dim strDistrict As String = "select dm.district_id||'�'||dm.district_name from district_master dm where dm.state_id = " & str(1) & " order by district_name"
                dt = oh.ExecuteDataSet(strDistrict).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        'If i = 0 Then
                        '    Dim ss() As String = dr(0).split("�")
                        '    disID = ss(0)
                        '    i = i + 1
                        'End If
                        st.Append(dr(0))
                        st.Append("%")
                    Next
                End If
                st.Append("$")
                'i = 0
                Dim strPost As String = "select pm.sr_number||'�'||pm.post_office from post_master pm where pm.district_id = " & str(2) & " order by pm.post_office"
                dt = oh.ExecuteDataSet(strPost).Tables(0)
                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows
                        'If i = 0 Then
                        '    Dim ss() As String = dr(0).split("�")
                        '    PosID = ss(0)
                        '    i = i + 1
                        'End If
                        st.Append(dr(0))
                        st.Append("%")
                    Next
                End If
                'st.Append("$")
                'Dim PinCode As Integer = oh.ExecuteDataSet("select pin_code from post_master where sr_number = " & PosID & "").Tables(0).Rows(0)(0)
                'st.Append(PinCode)
        End Select
        res = st.ToString()
    End Sub

End Class
