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
                btnAddMaster.Enabled = True
                btnAddAccount.Enabled = True
                btnAddMaster.Visible = True
                btnAddAccount.Visible = True
            Else
                btnAddMaster.Enabled = False
                btnAddAccount.Enabled = False
                btnAddMaster.Visible = False
                btnAddAccount.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' マスタ登録ボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAddMaster_Click(sender As Object, e As EventArgs) Handles btnAddMaster.Click
        Dim AddMaster As New frmMaster
        AddMaster.Show()
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