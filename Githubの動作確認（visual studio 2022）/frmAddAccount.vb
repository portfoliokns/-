Public Class frmAddAccount
    ''' <summary>
    ''' フォームの初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAddAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"
        txtRePassword.PasswordChar = "*"
    End Sub

    ''' <summary>
    ''' ユーザーIDのテキストフォーム、キーを押した後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtUserID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' パスワードのテキストフォーム、キーを押した後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' パスワード(再)のテキストフォーム、キーを押した後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtRePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRePassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
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
            lblRePassword.Visible = False
            txtRePassword.Visible = False
        Else
            txtPassword.PasswordChar = "*"
            lblRePassword.Visible = True
            txtRePassword.Visible = True
            txtRePassword.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' 登録ボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim systemErrorFlag As Boolean = False
        Dim userId As String = txtUserID.Text
        Dim password As String = txtPassword.Text
        Dim rePassword As String = txtRePassword.Text

        Try
            'パスワードの一致確認
            Dim passwordCheck As String
            If checkPasswordMatch(systemErrorFlag, password, rePassword, passwordCheck) Then Exit Try

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
        Me.Close()
    End Sub

    ''' <summary>
    ''' パスワードの重複チェック
    ''' </summary>
    ''' <param name="systemErrorflag">システムエラーフラグ</param>
    ''' <param name="password">パスワード</param>
    ''' <param name="rePassword">パスワード（再）</param>
    ''' <param name="checkResult">チェックの結果</param>
    ''' <returns></returns>
    Private Function checkPasswordMatch(ByRef systemErrorflag As Boolean, ByRef password As String, ByRef rePassword As String, ByRef checkResult As Boolean)
        checkResult = False
        Try

            If password = rePassword Then checkResult = True

        Catch ex As Exception
            systemErrorflag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorflag
    End Function

End Class