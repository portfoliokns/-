Public Class frmAddAccount
    Private Sub frmAddAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"
        txtRePassword.PasswordChar = "*"
    End Sub

    Private Sub txtUserID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub txtRePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRePassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub ckbPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ckbPassword.CheckedChanged
        txtRePassword.Text = ""
        If ckbPassword.Checked Then
            txtPassword.PasswordChar = ""
            lblRePassword.Visible = False
            txtRePassword.Visible = False
        Else
            txtPassword.PasswordChar = "*"
            lblRePassword.Visible = True
            txtRePassword.Visible = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class