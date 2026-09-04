Imports System.Data.OracleClient
Imports System.Data
Imports Microsoft.VisualBasic

Public Class passwdClass
    Public Function getRoles(ByVal userId As Integer, ByVal passWord As String) As String
        Dim oh1 As New Helper.Oracle.OracleHelper
        Dim result As String
        Dim PassHash = oh1.ExecuteDataSet("select dbms_obfuscation_toolkit.md5(input => UTL_RAW.cast_to_raw('" & userId & "'||'raju'||'" & passWord & "')) from dual").Tables(0).Rows(0)(0)
        Dim parm_coll(5) As OracleParameter
        Try
            parm_coll(0) = New OracleParameter("empid", OracleType.Number, 6)
            parm_coll(0).Value = userId
            parm_coll(0).Direction = ParameterDirection.Input
            parm_coll(1) = New OracleParameter("passwd", OracleType.Raw, 16)
            parm_coll(1).Value = PassHash
            parm_coll(1).Direction = ParameterDirection.Input
            parm_coll(2) = New OracleParameter("accessid", OracleType.Number, 4)
            parm_coll(2).Direction = ParameterDirection.Output
            parm_coll(3) = New OracleParameter("roleid", OracleType.Number, 1)
            parm_coll(3).Direction = ParameterDirection.Output
            parm_coll(4) = New OracleParameter("emp_br", OracleType.Number, 5)
            parm_coll(4).Direction = ParameterDirection.Output
            parm_coll(5) = New OracleParameter("passwd_flg", OracleType.Number, 1)
            parm_coll(5).Direction = ParameterDirection.Output
            oh1.ExecuteNonQuery("get_access_level", parm_coll)
            result = (parm_coll(2).Value).ToString() + "-" + (parm_coll(5).Value).ToString() + "-" + (parm_coll(4).Value.ToString) + "-" + (parm_coll(3).Value.ToString)
        Catch ex As Exception
            result = "Error"
        End Try
        Return result
    End Function
    'Public Function getRoles(ByVal userId As Integer, ByVal passWord As String) As String
    '    Dim oh1 As New Helper.Oracle.OracleHelper
    '    Dim result As String
    '    Dim parm_coll(5) As OracleParameter
    '    Try
    '        parm_coll(0) = New OracleParameter("empid", OracleType.Number, 5)
    '        parm_coll(0).Value = userId
    '        parm_coll(0).Direction = ParameterDirection.Input
    '        parm_coll(1) = New OracleParameter("passwd", OracleType.VarChar, 20)
    '        parm_coll(1).Value = passWord
    '        parm_coll(1).Direction = ParameterDirection.Input
    '        parm_coll(2) = New OracleParameter("accessid", OracleType.Number, 4)
    '        parm_coll(2).Direction = ParameterDirection.Output
    '        parm_coll(3) = New OracleParameter("roleid", OracleType.Number, 1)
    '        parm_coll(3).Direction = ParameterDirection.Output
    '        parm_coll(4) = New OracleParameter("emp_br", OracleType.Number, 5)
    '        parm_coll(4).Direction = ParameterDirection.Output
    '        parm_coll(5) = New OracleParameter("passwd_flg", OracleType.Number, 1)
    '        parm_coll(5).Direction = ParameterDirection.Output
    '        oh1.ExecuteNonQuery("get_roles", parm_coll)
    '        result = (parm_coll(2).Value).ToString() + "-" + (parm_coll(5).Value).ToString() + "-" + (parm_coll(4).Value.ToString) + "-" + (parm_coll(3).Value.ToString)
    '    Catch ex As Exception
    '        result = "Error"
    '    End Try
    '    Return result
    'End Function
    Public Function password_chek(ByVal usid As Integer, ByVal passwd As String) As Integer
        Dim logdat As Integer
        Dim oh As New Helper.Oracle.OracleHelper
        Dim dt As New DataTable
        ' dt = oh.ExecuteDataSet("select count(*)   from employee_masters where emp_code=" & usid & " and password=dbms_obfuscation_toolkit.md5(input => UTL_RAW.cast_to_raw('" & usid & "'||'raju'||'" & passwd & "')) and status_id=1").Tables(0)
        dt = oh.ExecuteDataSet("select count(*)   from employee_master where emp_code=" & usid & " and password=dbms_obfuscation_toolkit.md5(input => UTL_RAW.cast_to_raw('" & usid & "'||'raju'||'" & passwd & "')) and status_id=1").Tables(0)
        logdat = dt.Rows(0)(0)
        Return logdat
    End Function
    Public Function change_password(ByVal userID As Integer, ByVal oldPasswd As String, ByVal newpass As String) As String
        Dim oh As New Helper.Oracle.OracleHelper
        Dim oldHash = oh.ExecuteDataSet("select dbms_obfuscation_toolkit.md5(input => UTL_RAW.cast_to_raw('" & userID & "'||'raju'||'" & oldPasswd & "')) from dual").Tables(0).Rows(0)(0)
        Dim newHash = oh.ExecuteDataSet("select dbms_obfuscation_toolkit.md5(input => UTL_RAW.cast_to_raw('" & userID & "'||'raju'||'" & newpass & "')) from dual").Tables(0).Rows(0)(0)
        Dim op(3) As OracleParameter
        op(0) = New OracleParameter("user_nm", OracleType.Number, 6)
        op(0).Value = userID
        op(0).Direction = ParameterDirection.Input
        op(1) = New OracleParameter("oldpass", OracleType.Raw, 32)
        op(1).Value = oldHash
        op(1).Direction = ParameterDirection.Input
        op(2) = New OracleParameter("newpass", OracleType.Raw, 32)
        op(2).Value = newHash
        op(2).Direction = ParameterDirection.Input
        op(3) = New OracleParameter("msg", OracleType.VarChar, 500)
        op(3).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("change_passwd", op)
        Dim result As String = op(3).Value
        Return result
    End Function
    Public Function reset_password(ByVal userID As Integer, ByVal itStaff As String) As String
        Dim oh As New Helper.Oracle.OracleHelper
        Dim oldHash = oh.ExecuteDataSet("select dbms_obfuscation_toolkit.md5(input => UTL_RAW.cast_to_raw('" & userID & "'||'raju'||'qqqq')) from dual").Tables(0).Rows(0)(0)
        Dim newHash = oh.ExecuteDataSet("select dbms_obfuscation_toolkit.md5(input => UTL_RAW.cast_to_raw('" & userID & "'||'raju'||'soft1234')) from dual").Tables(0).Rows(0)(0)
        Dim op(3) As OracleParameter
        op(0) = New OracleParameter("user_nm", OracleType.Number, 6)
        op(0).Value = userID
        op(0).Direction = ParameterDirection.Input
        op(1) = New OracleParameter("oldpass", OracleType.Raw, 32)
        op(1).Value = oldHash
        op(1).Direction = ParameterDirection.Input
        op(2) = New OracleParameter("newpass", OracleType.Raw, 32)
        op(2).Value = newHash
        op(2).Direction = ParameterDirection.Input
        op(3) = New OracleParameter("msg", OracleType.VarChar, 500)
        op(3).Direction = ParameterDirection.Output
        oh.ExecuteNonQuery("change_passwd", op)
        Dim result As String = op(3).Value
        Return result
    End Function
End Class
