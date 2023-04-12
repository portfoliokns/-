Public Class clsAuthenticator
    Private _isAuthenticated As Boolean = False
    Public ReadOnly Property IsAuthenticated() As Boolean
        Get
            Return _isAuthenticated
        End Get
    End Property

    Public Function Authenticate(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String) As Boolean

        Try
            'パスワードのハッシュ化
            Dim cryptoHasher As New clsCryptoHasher
            If cryptoHasher.calcHushPassword(systemErrorFlag, userID, password) Then Exit Try
            password = cryptoHasher.getHushPassword

            'SQL接続
            Dim sqlServerResponder As New clsSqlServerResponder
            If sqlServerResponder.getAutenticate(systemErrorFlag, userID, password, _isAuthenticated) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
