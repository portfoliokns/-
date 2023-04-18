Public Class frmMain

    Private _userID As String
    Public WriteOnly Property UserID() As String
        Set(ByVal value As String)
            _userID = value
        End Set
    End Property

    ''' <summary>
    ''' ロード時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' アカウント登録ボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAddAccount_Click(sender As Object, e As EventArgs) Handles btnAddAccount.Click
        Dim AddAccount As New frmAddAccount
        AddAccount.Show()
    End Sub

    ''' <summary>
    ''' 閉じるボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

End Class