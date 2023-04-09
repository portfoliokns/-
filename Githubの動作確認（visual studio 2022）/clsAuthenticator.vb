Public Class clsAuthenticator
    Private _isAuthenticated As Boolean = False
    Public ReadOnly Property IsAuthenticated() As Boolean
        Get
            Return _isAuthenticated
        End Get
    End Property

    Public Sub Authenticate(ByRef userID As String, ByRef password As String)

        Try
            Dim sqlServerResponse As New clsSqlServerResponse

            _isAuthenticated = True
        Catch ex As Exception
        Finally
        End Try

    End Sub

End Class
