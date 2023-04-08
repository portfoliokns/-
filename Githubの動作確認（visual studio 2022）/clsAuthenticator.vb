Public Class clsAuthenticator
    Private _isAuthenticated As Boolean = False
    Private _userID As String
    Private _password As String
    Public ReadOnly Property IsAuthenticated() As Boolean
        Get
            Return _isAuthenticated
        End Get
    End Property
    Public Sub Authenticate(ByRef userID As String, ByRef password As String)
        _userID = userID
        _password = password

        _isAuthenticated = True
    End Sub

End Class
