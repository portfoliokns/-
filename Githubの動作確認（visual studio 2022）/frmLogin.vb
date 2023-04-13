Public Class frmLogin
    ''' <summary>
    ''' フォームの初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmLoginScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUserID.Text = "U1234567"
        txtPassword.Text = "01234567"
        txtPassword.PasswordChar = "*"
        txtUserID.MaxLength = 8
        ckbPassword.Checked = False
    End Sub

    ''' <summary>
    ''' ユーザーIDのテキストフォーム、キーを押した後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtUserID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' パスワードのテキストフォーム、キーを押した後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' チェックボックス、チェック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ckbPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ckbPassword.CheckedChanged
        If ckbPassword.Checked Then
            txtPassword.PasswordChar = ""
        Else
            txtPassword.PasswordChar = "*"
        End If
    End Sub

    ''' <summary>
    ''' ログインボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim systemErrorFlag As Boolean = False
        Dim userID As String = txtUserID.Text
        Dim password As String = txtPassword.Text

        Try
            '認証処理
            Dim authenticator As New clsAuthenticator
            If authenticator.Authenticate(systemErrorFlag, userID, password) Then Exit Try

            If authenticator.IsAuthenticated Then
                MessageBox.Show("認証に成功しました。ログインします。")
                Me.Hide()
                Dim Main As New frmMain
                Main.ShowDialog()
                Me.Show()
                Me.OnLoad(e)
            Else
                MessageBox.Show("ユーザーIDまたはパスワードに誤りがあります。")
            End If

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally

        End Try

    End Sub

    ''' <summary>
    ''' 閉じるボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

End Class
