Public Class frmMain

    Private _userID As String
    Public WriteOnly Property UserID() As String
        Set(ByVal value As String)
            _userID = value
        End Set
    End Property

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim systemErrorFlag As Boolean = False
        Dim isAdmin As Boolean

        Try
            '権限
            Dim userInfo As New clsUserInfo
            If userInfo.checkAddmin(systemErrorFlag, _userID, isAdmin) Then Exit Try

            If isAdmin Then
                btnAddAccount.Enabled = True
                btnAddAccount.Visible = True
            Else
                btnAddAccount.Enabled = False
                btnAddAccount.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try
    End Sub

    Private Sub btnAddAccount_Click(sender As Object, e As EventArgs) Handles btnAddAccount.Click
        Dim AddAccount As New frmAddAccount
        AddAccount.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

End Class