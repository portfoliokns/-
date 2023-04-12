Public Class clsAuthenticator
    Private _isAuthenticated As Boolean = False
    Public ReadOnly Property IsAuthenticated() As Boolean
        Get
            Return _isAuthenticated
        End Get
    End Property

    Public Function Authenticate(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String) As Boolean

        Try

            Dim cryptoHasher As New clsCryptoHasher
            If cryptoHasher.generateHash(systemErrorFlag, password) Then Exit Try

            Dim sqlServerResponse As New clsSqlServerRespoder
            If sqlServerResponse.getAutenticate(systemErrorFlag, userID, password, _isAuthenticated) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
