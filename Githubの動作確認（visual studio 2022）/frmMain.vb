Public Class frmMain

    Private _userID As String
    Public WriteOnly Property UserID() As String
        Set(ByVal value As String)
            _userID = value
        End Set
    End Property

    Dim rowState As New clsRowState

    ''' <summary>
    ''' ロード時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim systemErrorFlag As Boolean = False
        Dim isAdmin As Boolean

        Try
            '権限制御
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
    ''' DataGridViewのセル編集後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvDevice_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDevice.CellValueChanged
        Dim systemErrorFlag As String = False

        Try
            'ユーザーが行を編集していない場合、処理を終える
            If e.RowIndex = -1 Then Exit Try

            '■フラグを設定
            Dim rowIndex As Integer = e.RowIndex
            '新規行の場合、アップデートフラグに設定する
            If dgvDevice.Rows(rowIndex).Cells("status_flag").Value Is DBNull.Value Then
                dgvDevice.Rows(rowIndex).Cells("status_flag").Value = rowState.Update
                dgvDevice.Rows(rowIndex).Cells("delete_flag").Value = rowState.NotDelete
            End If
            '既存行の場合、編集フラグにする
            If dgvDevice.Rows(rowIndex).Cells("status_flag").Value = rowState.NoChanged Then
                dgvDevice.Rows(rowIndex).Cells("status_flag").Value = rowState.Edit
            End If

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' 右クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvDevice_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDevice.CellMouseClick
        If (e.Button = MouseButtons.Right) AndAlso (e.ColumnIndex >= 0 And e.RowIndex >= 0) Then
            dgvDevice.ClearSelection()
            dgvDevice.Rows(e.RowIndex).Selected = True

            '新規追加行の場合、コンテキストメニューを表示しない
            Dim lastRowIndex As Integer = dgvDevice.Rows.Count - 1
            If lastRowIndex = e.RowIndex Then
                tsmiDelete.Enabled = False
                tsmiRestore.Enabled = False
                Exit Sub
            End If

            'コンテキストメニューの表示制御
            Dim deleteStatus As Boolean = dgvDevice.Rows(e.RowIndex).Cells("delete_flag").Value
            If deleteStatus Then
                tsmiDelete.Enabled = False
                tsmiRestore.Enabled = True
            Else
                tsmiDelete.Enabled = True
                tsmiRestore.Enabled = False
            End If
            ctmClickMenu.Show(System.Windows.Forms.Cursor.Position)

        End If
    End Sub

    ''' <summary>
    ''' 削除メニューを選択した時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsmiDelete_Click(sender As Object, e As EventArgs) Handles tsmiDelete.Click
        Dim systemErrorFlag As String = False

        Try
            '行の状態を変更
            If Me.changeRowState(systemErrorFlag, True, rowState.Delete, Color.LightGray) Then Exit Try

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

    End Sub

    ''' <summary>
    ''' 復元メニューを選択した時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsmiRestore_Click(sender As Object, e As EventArgs) Handles tsmiRestore.Click
        Dim systemErrorFlag As String = False

        Try
            '行の状態を変更
            If Me.changeRowState(systemErrorFlag, False, rowState.NotDelete, Color.White) Then Exit Try

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

    End Sub

    ''' <summary>
    ''' 保存ボタン、クリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim systemErrorFlag As String = False
        Dim checkErrorFlag As String = False

        Dim dtStatus As New DataTable("dtStatus")

        Try
            '空欄チェック
            If Me.checkEmpty(systemErrorFlag, checkErrorFlag) Then Exit Try
            If checkErrorFlag Then Exit Try

            'データテーブルを設定
            'If Me.setDataTable(systemErrorFlag, dtStatus) Then Exit Try

            'データ登録
            Dim device As New clsDevice
            'If device.setDevice(systemErrorFlag, dtStatus) Then Exit Try
            MessageBox.Show("保存が完了しました")

            '表示データを再設定
            If Me.setDataGridView(systemErrorFlag) Then Exit Try

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
    ''' <param name="dtDevice">機器・端末テーブル</param>
    ''' <returns>システムエラーフラグ</returns>
    Private Function setDesign(ByRef systemErrorFlag As Boolean, ByRef dtDevice As DataTable) As Boolean

        Try
            'データテーブル設定
            dgvDevice.DataSource = dtDevice

            '列幅設定
            dgvDevice.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgvDevice.Columns("id").Width = 0
            dgvDevice.Columns("status").Width = 100
            dgvDevice.Columns("admin").Width = 120
            dgvDevice.Columns("device").Width = 120
            dgvDevice.Columns("appendix").Width = 250
            dgvDevice.Columns("delete_flag").Width = 0
            dgvDevice.Columns("status_flag").Width = 0

            '操作不可
            'dgvDevice.Columns("id").Visible = False
            'dgvDevice.Columns("delete_flag").Visible = False
            'dgvDevice.Columns("status_flag").Visible = False
            dgvDevice.Columns("id").ReadOnly = True
            dgvDevice.Columns("delete_flag").ReadOnly = True
            dgvDevice.Columns("status_flag").ReadOnly = True

            '表示テキスト
            dgvDevice.Columns("status").HeaderText = "ステータス"
            dgvDevice.Columns("admin").HeaderText = "管理者・使用者"
            dgvDevice.Columns("device").HeaderText = "機器・端末情報"
            dgvDevice.Columns("appendix").HeaderText = "補足事項"

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' 空欄をチェックする
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="checkErrorFlag">チェックフラグ</param>
    ''' <returns>システムエラーフラグ</returns>
    Private Function checkEmpty(ByRef systemErrorFlag As Boolean, ByRef checkErrorFlag As Boolean) As Boolean

        Try
            For Each row As DataGridViewRow In dgvDevice.Rows
                '入力していない行、削除する行、新規行はチェックしない
                If row.Cells("status_flag").Value = rowState.NoChanged Then Continue For
                If row.Cells("delete_flag").Value = rowState.Delete Then Continue For
                If row.Cells("status_flag").Value = Nothing Then Continue For

                'ステータス
                If row.Cells("status").Value Is DBNull.Value Then
                    checkErrorFlag = True
                    MessageBox.Show("ステータスが空欄です。入力してください。")
                    Exit Try
                End If

                '管理者・使用者
                If row.Cells("admin").Value Is DBNull.Value Then
                    checkErrorFlag = True
                    MessageBox.Show("管理者・使用者が空欄です。入力してください。")
                    Exit Try
                End If

                '表示順
                If row.Cells("device").Value Is DBNull.Value Then
                    checkErrorFlag = True
                    MessageBox.Show("機器・端末が空欄です。入力してください。")
                    Exit Try
                End If
            Next

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' 行の状態を変更する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="read">ReadOnly状態：Boolean型</param>
    ''' <param name="delete_flag">delete_flagの状態</param>
    ''' <param name="color">色の指定</param>
    ''' <returns></returns>
    Private Function changeRowState(ByRef systemErrorFlag As Boolean, ByRef read As Boolean, ByRef delete_flag As Boolean, ByRef color As Color) As Boolean

        Try
            Dim selectedRowIndex As Integer = dgvDevice.SelectedCells(0).RowIndex
            dgvDevice.Rows(selectedRowIndex).ReadOnly = read
            dgvDevice.Rows(selectedRowIndex).Cells("delete_flag").Value = delete_flag
            dgvDevice.Rows(selectedRowIndex).DefaultCellStyle.BackColor = color
            dgvDevice.Rows(selectedRowIndex).Selected = False

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class