''' <summary>
''' リボーク制御基盤
''' </summary>
Public Class clsRevokeController
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

    ''' <summary>
    ''' リボークをリセットする
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <param name="revokeStatus">リボーク状態</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function resetRevokeCount(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef revokeStatus As Boolean) As Boolean

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector

            'リボーク状態を確認
            If sqlServerConnector.checkRevokeStatus(systemErrorFlag, userID, revokeStatus) Then Exit Try

            'リボークされていない場合のみ、カウントをリセット
            If revokeStatus = False Then
                If sqlServerConnector.resetRevokeCount(systemErrorFlag, userID) Then Exit Try
            End If

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
