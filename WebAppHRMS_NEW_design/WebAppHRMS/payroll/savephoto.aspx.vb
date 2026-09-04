Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Partial Class savephoto_f2b996462211
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt12, dt13, dt14, dt15 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Public Shared Function GetUniqueFilename(ByVal FileName As String) As String
        Dim count As Integer = 0
        Dim Name As String = ""

        If System.IO.File.Exists(FileName) Then
            Dim f As New System.IO.FileInfo(FileName)
            If Not String.IsNullOrEmpty(f.Extension) Then
                Name = f.FullName.Substring(0, f.FullName.LastIndexOf("."))
            Else
                Name = f.FullName
            End If
            While System.IO.File.Exists(FileName)
                count += 1
                FileName = Name + count.ToString() + f.Extension
            End While
        End If
        Return FileName
    End Function
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        ' dt = oh.ExecuteDataSet("select  replace(REGEXP_replace(a.emp_code||'-'||to_date(a.curr_date)||'-'||r.m_time||'-M_photo','[()./\;:,]',''),chr(10),'') name,a.m_photo from dms.attend_photo a,attend r where  r.emp_code=a.emp_code and r.curr_date=a.curr_date and r.m_time is not null and length(a.m_PHOTO) is not null and r.mc_time is not null and a.curr_date>=to_date(sysdate) and r.branch_id=603 union all select  replace(REGEXP_replace(a.emp_code||'-'||to_date(a.curr_date)||'-'||r.e_time||'-E_photo','[()./\:;,]',''),chr(10),'') name,a.e_photo from dms.attend_photo a,attend r where  r.emp_code=a.emp_code and r.curr_date=a.curr_date  and a.curr_date>=to_date(sysdate) and r.e_time is not null and r.ec_time is not null and length(a.e_PHOTO) is not null and r.branch_id=603").Tables(0)
        ' dt = oh.ExecuteDataSet("select replace(REGEXP_replace(r.emp_code || '-' || to_date(r.curr_date) || '-' ||r.m_time || '-m_photo','[()./\:;,]',''),chr(10),'') name,r.m_photo  from daily_attend r where r.emp_code = r.emp_code      and r.curr_date >= to_date(sysdate)     and r.m_time is not null   and r.branch_id = 603").Tables(0)
        'dt = oh.ExecuteDataSet("select  t.emp_code name,t.m_photo from dms.attend_photo t,bilumon.hrm_emp_ph p,attend_his a where p.emp_code=t.emp_code and t.curr_date=a.CURR_DATE and p.emp_code not in (55563) and  a.EMP_CODE=p.emp_code and a.CURR_DATE=(select max(r.curr_date) from attend_his r where r.M_TIME is not null and r.EMP_CODE=a.EMP_CODE and r.M_TIME not in ('TOUR','COMPEN') )").Tables(0)
        dt = oh.ExecuteDataSet("select t.emp_code||'-'||e.EMP_NAME||'-'||to_char(to_date(t.discont_dt),'dd-mon-yyyy') name,h.photo from employee_resigtermi t,dms.hrm_emp_ph_certi h,emp_master e,branch b,department_mst d where d.dep_id=e.DEPARTMENT_ID and b.BRANCH_ID=e.BRANCH_ID  and e.DEPARTMENT_ID in (180,23,4,178,188,211) and e.EMP_CODE=t.emp_code and h.emp_code=e.EMP_CODE and e.STATUS_ID=3 and t.discont_dt>=to_date('1/mar/2010') and t.emp_code<>10251 and length(h.photo)>0").Tables(0)
        Dim dr As DataRow
        Dim i As Integer
        Dim path1
        For Each dr In dt.Rows
            Dim DirPath As String
            DirPath = "D:\VIGILANCE"
            Dim di As DirectoryInfo = New DirectoryInfo("D:\VIGILANCE")

            If di.Exists Then

            Else
                di.Create()
            End If



            'dir.GetDirectories()
            ' Dim path = Server.MapPath(DirPath)
            'Dim path = Server.("D:\")
            path1 = GetUniqueFilename(DirPath & "\" & dr(0) & ".jpg")

            Dim fs As New IO.FileStream(path1, FileMode.Create)
            Dim blob() As Byte
            blob = CType(dr(1), Byte())
            fs.Write(blob, 0, blob.Length)
            fs.Close()
        Next
    End Sub
End Class
