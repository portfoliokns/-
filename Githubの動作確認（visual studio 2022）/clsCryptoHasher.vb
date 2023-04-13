Imports System.Security.Cryptography

Public Class clsCryptoHasher
    Private _getHushPassword As String
    Public ReadOnly Property getHushPassword() As String
        Get
            Return _getHushPassword
        End Get
    End Property
    Private saltSeed As String = System.Environment.GetEnvironmentVariable("DEV_SALT_SEED")
    Private stretchingTimes As Integer = System.Environment.GetEnvironmentVariable("DEV_STRETCHING_TIMES")

    Public Function calcHushPassword(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String) As Boolean

        Try
            'ソルト化
            Dim saltPassword As String = String.Concat(userID, password, saltSeed)

            'ストレッチング
            For stretching = 1 To stretchingTimes
                'ハッシュ化
                If Me.generateHash(systemErrorFlag, saltPassword) Then Exit Try
            Next
            _getHushPassword = saltPassword

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function



    Private Function generateHash(ByRef systemErrorFlag As Boolean, ByRef password As String) As Boolean

        Try
            'パスワードをバイト配列に変換する
            Dim Bytes() As Byte = System.Text.Encoding.UTF8.GetBytes(password)

            'SHA256ハッシュアルゴリズムを使用してハッシュ値を計算する
            Dim sha256 As SHA256 = SHA256.Create()
            Dim hashBytes() As Byte = sha256.ComputeHash(Bytes)

            'ハッシュ値をBase64文字列に変換する
            password = Convert.ToBase64String(hashBytes)

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
