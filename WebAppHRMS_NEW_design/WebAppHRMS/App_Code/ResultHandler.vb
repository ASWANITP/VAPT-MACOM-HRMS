
Public Class ResultHandler
    Dim transactionNo As Integer
    Dim errStatus As Integer
    Dim errMessage As String
    Public Property transactionid() As Integer
        Get
            Return transactionNo
        End Get
        Set(ByVal value As Integer)
            transactionNo = value
        End Set
    End Property
    Public Property status() As Integer
        Get
            Return errStatus
        End Get
        Set(ByVal value As Integer)
            errStatus = value
        End Set
    End Property
    Public Property message() As String
        Get
            Return errMessage
        End Get
        Set(ByVal value As String)
            errMessage = value
        End Set
    End Property
End Class
