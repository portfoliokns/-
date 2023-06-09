﻿Public Class clsUserInfo
    ''' <summary>
    ''' ユーザーIDの登録状況を確認する
    ''' </summary>
    ''' <param name="systemErrorFlag"></param>
    ''' <param name="userID"></param>
    ''' <param name="userExist"></param>
    ''' <returns></returns>
    Public Function checkUserExist(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef userExist As Boolean) As Boolean

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.checkUserExist(systemErrorFlag, userID, userExist) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' ユーザー情報を登録する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <param name="password">パスワード</param>
    ''' <param name="adminFlag">管理者フラグ</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function createUserInfo(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String, ByRef adminFlag As Boolean) As Boolean

        Try
            'パスワードのハッシュ化
            Dim cryptoHasher As New clsCryptoHasher
            If cryptoHasher.calcHushPassword(systemErrorFlag, userID, password) Then Exit Try
            password = cryptoHasher.getHushPassword

            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.insertUserInfo(systemErrorFlag, userID, password, adminFlag) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' 管理者権限があるかを確認する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <param name="isAdmin">権限結果</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function checkAddmin(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef isAdmin As Boolean) As Boolean

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.checkAdmin(systemErrorFlag, userID, isAdmin) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
