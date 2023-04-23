Public Class clsStatus
    ''' <summary>
    ''' 状況情報を取得する
    ''' </summary>
    ''' <param name="systemErrorFlag"></param>
    ''' <param name="userID"></param>
    ''' <param name="userExist"></param>
    ''' <returns></returns>
    Public Function getStatus(ByRef systemErrorFlag As Boolean, ByRef dtStatus As DataTable) As Boolean

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.getStatusMaster(systemErrorFlag, dtStatus) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    '''' <summary>
    '''' ユーザー情報を登録する
    '''' </summary>
    '''' <param name="systemErrorFlag">システムエラーフラグ</param>
    '''' <param name="userID">ユーザーID</param>
    '''' <param name="password">パスワード</param>
    '''' <param name="adminFlag">管理者フラグ</param>
    '''' <returns>システムエラーフラグ</returns>
    'Public Function createUserInfo(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String, ByRef adminFlag As Boolean) As Boolean

    '    Try

    '        ''SQL接続
    '        'Dim sqlServerConnector As New clsSqlServerConnector
    '        'If sqlServerConnector.insertUserInfo(systemErrorFlag, userID, password, adminFlag) Then Exit Try

    '    Catch ex As Exception
    '        systemErrorFlag = True
    '        MessageBox.Show("エラーが発生しました： " & ex.Message)
    '    Finally
    '    End Try

    '    Return systemErrorFlag
    'End Function

End Class
