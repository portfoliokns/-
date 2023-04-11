Public Class frmLoginScreen
    Private Sub frmLoginScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUserID.Text = "U1234567"
        txtPassword.Text = "01234567"
    End Sub

    Private Sub txtUserID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim systemErrorFlag As Boolean = False
        Dim userID As String = txtUserID.Text
        Dim password As String = txtPassword.Text

        Try

            Dim authenticator As New clsAuthenticator
            If authenticator.Authenticate(systemErrorFlag, userID, password) Then Exit Try

            If authenticator.IsAuthenticated Then
                MessageBox.Show("認証に成功しました。ログインします。")
                Me.Hide()
                Dim Main As New frmMain
                Main.ShowDialog()
                Me.Show()
            Else
                MessageBox.Show("ユーザーIDまたはパスワードに誤りがあります。")
            End If

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally

        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

End Class
