Public Class frmLoginScreen
    Private Sub frmLoginScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim userID As String = txtUserID.Text
        Dim password As String = txtPassword.Text
        Dim userCheck As Boolean = authenticator.IsAuthenticated

        Dim authenticator As New clsAuthenticator
        authenticator.Authenticate(userID, password)
        userCheck = authenticator.IsAuthenticated

        If userCheck = True Then
            MessageBox.Show("認証に成功しました。ログインします。")
        Else
            MessageBox.Show("ユーザーIDまたはパスワードに誤りがあります。")
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
End Class
