Public Class clsRevokeCounter
    Private revokeThreshold As Integer = System.Environment.GetEnvironmentVariable("DEV_REVOKE_THRESHOLD")

    ''' <summary>
    ''' リボークカウントを加算する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function addRevokeCount(ByRef systemErrorFlag As Boolean, ByRef userID As String) As Boolean

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.addCountAndRevoke(systemErrorFlag, userID, revokeThreshold) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
