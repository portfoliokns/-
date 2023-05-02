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

            '表示データを設定
            If Me.setDataGridView(systemErrorFlag) Then Exit Try

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
    ''' ログアウトボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 保存ボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim systemErrorFlag As Boolean = False

        Try


        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' データテーブルをDataGridViewへ反映する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <returns>システムエラーフラグ</returns>
    Private Function setDataGridView(ByRef systemErrorFlag As Boolean) As Boolean
        Dim dtDevice As New DataTable("dtDevice")

        Try
            'データ取得
            Dim device As New clsDevice
            If device.getDevice(systemErrorFlag, dtDevice) Then Exit Try

            'デザイン設定
            If Me.setDesign(systemErrorFlag, dtDevice) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' デザインを設定する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="dtStatus">ステータステーブル</param>
    ''' <returns>システムエラーフラグ</returns>
    Private Function setDesign(ByRef systemErrorFlag As Boolean, ByRef dtStatus As DataTable) As Boolean

        Try
            ''データテーブル設定
            'dgvStatus.DataSource = dtStatus

            ''列幅設定
            'dgvStatus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            'dgvStatus.Columns("id").Width = 0
            'dgvStatus.Columns("status").Width = 100
            'dgvStatus.Columns("display_number").Width = 80
            'dgvStatus.Columns("comment").Width = 350
            'dgvStatus.Columns("delete_flag").Width = 350
            'dgvStatus.Columns("status_flag").Width = 0
            'dgvStatus.Columns("delete_flag").Width = 0

            ''操作不可
            'dgvStatus.Columns("id").Visible = False
            'dgvStatus.Columns("status_flag").Visible = False
            'dgvStatus.Columns("delete_flag").Visible = False
            'dgvStatus.Columns("id").ReadOnly = True
            'dgvStatus.Columns("status_flag").ReadOnly = True
            'dgvStatus.Columns("delete_flag").ReadOnly = True

            ''表示テキスト
            'dgvStatus.Columns("status").HeaderText = "ステータス"
            'dgvStatus.Columns("display_number").HeaderText = "表示順"
            'dgvStatus.Columns("comment").HeaderText = "コメント"

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class