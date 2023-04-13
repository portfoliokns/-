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
            btnAdd.Enabled = False
        Else
            txtPassword.PasswordChar = "*"
            lblRePassword.Visible = True
            txtRePassword.Visible = True
            txtRePassword.Text = ""
            btnAdd.Enabled = True
            txtRePassword.Focus()
        End If
    End Sub

    ''' <summary>
    ''' 登録ボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim systemErrorFlag As Boolean = False
        Dim userID As String = txtUserID.Text
        Dim password As String = txtPassword.Text
        Dim rePassword As String = txtRePassword.Text

        Try
            '入力済チェック
            Dim emptyCheck As Boolean
            If checkEmpty(systemErrorFlag, userID, password, rePassword, emptyCheck) Then Exit Try
            If Not emptyCheck Then
                MessageBox.Show("ユーザーID、パスワード、パスワード（再）は必ず入力してください。")
                txtUserID.Focus()
                Exit Try
            End If

            'パスワードの一致確認
            Dim matchCheck As Boolean
            If checkPasswordMatch(systemErrorFlag, password, rePassword, matchCheck) Then Exit Try
            If Not matchCheck Then
                MessageBox.Show("パスワードが一致しません。もう一度入力しなおしてください。")
                txtPassword.Focus()
                Exit Try
            End If

            'ユーザーIDの登録状況を確認
            Dim UserInfo As New clsUserInfo
            Dim userExist As Boolean
            If UserInfo.checkUserExist(systemErrorFlag, userID, userExist) Then Exit Try
            If userExist Then
                MessageBox.Show("ユーザーIDがすでに登録されています。他のユーザーIDで登録し直してください。")
                txtUserID.Focus()
                Exit Try
            End If

            'SQLServer側に登録
            If UserInfo.createUserInfo(systemErrorFlag, userID, password) Then Exit Try
            MessageBox.Show("新しいアカウントを登録しました。パスワードは忘れないようにしてください。")
            Me.Close()

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
    ''' テキストフォーム空入力のチェック
    ''' </summary>
    ''' <param name="systemErrorflag"></param>
    ''' <param name="userID">ユーザーID</param>
    ''' <param name="password">パスワード</param>
    ''' <param name="rePassword">パスワード（再）</param>
    ''' <param name="checkResult">チェックの結果</param>
    ''' <returns>システムエラーフラグ</returns>
    Private Function checkEmpty(ByRef systemErrorflag As Boolean, ByRef userID As String, ByRef password As String, ByRef rePassword As String, ByRef checkResult As Boolean)
        checkResult = False
        Try

            If Not String.IsNullOrEmpty(userID) AndAlso Not String.IsNullOrEmpty(password) AndAlso Not String.IsNullOrEmpty(rePassword) Then checkResult = True

        Catch ex As Exception
            systemErrorflag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorflag
    End Function



    ''' <summary>
    ''' パスワードの重複チェック
    ''' </summary>
    ''' <param name="systemErrorflag">システムエラーフラグ</param>
    ''' <param name="password">パスワード</param>
    ''' <param name="rePassword">パスワード（再）</param>
    ''' <param name="checkResult">チェックの結果</param>
    ''' <returns>システムエラーフラグ</returns>
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