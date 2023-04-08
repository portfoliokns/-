Public Class clsAuthenticator
    Private _isAuthenticated As Boolean = False
    Public ReadOnly Property IsAuthenticated() As Boolean
        Get
            Return _isAuthenticated
        End Get
    End Property

    Public Sub Authenticate(ByRef userID As String, ByRef password As String)
        Dim sqlServerResponse As New clsSqlServerResponse
        _isAuthenticated = True
    End Sub

End Class
