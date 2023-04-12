Imports System.Security.Cryptography

Public Class clsCryptoHasher
    Private _changedPassword As String
    Public ReadOnly Property ChangePassword() As String
        Get
            Return _changedPassword
        End Get
    End Property

    Public Function generateHash(ByRef systemErrorFlag As Boolean, ByRef password As String) As Boolean

        Try
            'パスワードをバイト配列に変換する
            Dim passwordBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(password)

            'SHA256ハッシュアルゴリズムを使用してハッシュ値を計算する
            Dim sha256 As SHA256 = SHA256.Create()
            Dim hashBytes() As Byte = sha256.ComputeHash(passwordBytes)

            'ハッシュ値をBase64文字列に変換する
            _changedPassword = Convert.ToBase64String(hashBytes)

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
