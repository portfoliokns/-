Public Class frmMaster
    Dim rowState As New clsRowState

    ''' <summary>
    ''' フォームの初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim systemErrorFlag As String = False

        Try
            '表示データを設定
            If Me.setDataGridView(systemErrorFlag) Then Exit Try

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

    End Sub

    ''' <summary>
    ''' DataGridViewのセル編集後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvStatus_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStatus.CellValueChanged
        Dim systemErrorFlag As String = False

        Try
            'ユーザーが行を編集していない場合、処理を終える
            If e.RowIndex = -1 Then Exit Try

            '■フラグを設定
            Dim rowIndex As Integer = e.RowIndex
            '新規行の場合、アップデートフラグに設定する
            If dgvStatus.Rows(rowIndex).Cells("status_flag").Value Is DBNull.Value Then
                dgvStatus.Rows(rowIndex).Cells("status_flag").Value = rowState.Update
                dgvStatus.Rows(rowIndex).Cells("delete_flag").Value = rowState.NotDelete
            End If
            '既存行の場合、編集フラグにする
            If dgvStatus.Rows(rowIndex).Cells("status_flag").Value = rowState.NoChanged Then
                dgvStatus.Rows(rowIndex).Cells("status_flag").Value = rowState.Edit
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
    Private Sub dgvStatus_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvStatus.CellMouseClick
        If (e.Button = MouseButtons.Right) AndAlso (e.ColumnIndex >= 0 And e.RowIndex >= 0) Then
            dgvStatus.ClearSelection()
            dgvStatus.Rows(e.RowIndex).Selected = True

            '新規追加行の場合、コンテキストメニューを表示しない
            Dim lastRowIndex As Integer = dgvStatus.Rows.Count - 1
            If lastRowIndex = e.RowIndex Then
                tsmiDelete.Enabled = False
                tsmiRestore.Enabled = False
                Exit Sub
            End If

            'コンテキストメニューの表示制御
            Dim deleteStatus As Boolean = dgvStatus.Rows(e.RowIndex).Cells("delete_flag").Value
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
        Dim selectedRowIndex As Integer = dgvStatus.SelectedCells(0).RowIndex
        If selectedRowIndex >= 0 AndAlso selectedRowIndex < dgvStatus.Rows.Count Then
            dgvStatus.Rows(selectedRowIndex).ReadOnly = True
            dgvStatus.Rows(selectedRowIndex).Cells("delete_flag").Value = rowState.Delete
            dgvStatus.Rows(selectedRowIndex).DefaultCellStyle.BackColor = Color.LightGray
            dgvStatus.Rows(selectedRowIndex).Selected = False
        End If
    End Sub

    ''' <summary>
    ''' 復元メニューを選択した時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tsmiRestore_Click(sender As Object, e As EventArgs) Handles tsmiRestore.Click
        Dim selectedRowIndex As Integer = dgvStatus.SelectedCells(0).RowIndex
        If selectedRowIndex >= 0 AndAlso selectedRowIndex < dgvStatus.Rows.Count Then
            dgvStatus.Rows(selectedRowIndex).ReadOnly = False
            dgvStatus.Rows(selectedRowIndex).Cells("delete_flag").Value = rowState.NotDelete
            dgvStatus.Rows(selectedRowIndex).DefaultCellStyle.BackColor = Color.White
            dgvStatus.Rows(selectedRowIndex).Selected = False
        End If
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
            If Me.setDataTable(systemErrorFlag, dtStatus) Then Exit Try

            'データ登録
            Dim status As New clsStatus
            If status.setStatus(systemErrorFlag, dtStatus) Then Exit Try
            MessageBox.Show("保存が完了しました")

            '表示データを再設定
            If Me.setDataGridView(systemErrorFlag) Then Exit Try

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
    ''' データテーブルをDataGridViewへ反映する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <returns>システムエラーフラグ</returns>
    Private Function setDataGridView(ByRef systemErrorFlag As Boolean) As Boolean
        Dim dtStatus As New DataTable("dtStatus")

        Try
            'データ取得
            Dim status As New clsStatus
            If status.getStatus(systemErrorFlag, dtStatus) Then Exit Try

            'デザイン設定
            If Me.setDesign(systemErrorFlag, dtStatus) Then Exit Try

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
            'データテーブル設定
            dgvStatus.DataSource = dtStatus

            '列幅設定
            dgvStatus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgvStatus.Columns("id").Width = 0
            dgvStatus.Columns("status").Width = 100
            dgvStatus.Columns("display_number").Width = 80
            dgvStatus.Columns("comment").Width = 350
            dgvStatus.Columns("delete_flag").Width = 350
            dgvStatus.Columns("status_flag").Width = 0
            dgvStatus.Columns("delete_flag").Width = 0

            '操作不可
            dgvStatus.Columns("id").Visible = False
            dgvStatus.Columns("status_flag").Visible = False
            dgvStatus.Columns("delete_flag").Visible = False
            dgvStatus.Columns("id").ReadOnly = True
            dgvStatus.Columns("status_flag").ReadOnly = True
            dgvStatus.Columns("delete_flag").ReadOnly = True

            '表示テキスト
            dgvStatus.Columns("status").HeaderText = "ステータス"
            dgvStatus.Columns("display_number").HeaderText = "表示順"
            dgvStatus.Columns("comment").HeaderText = "コメント"

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' データテーブルに設定する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="dtStatus">ステータステーブル</param>
    ''' <returns>システムエラーフラグ</returns>
    Private Function setDataTable(ByRef systemErrorFlag As Boolean, ByRef dtStatus As DataTable) As Boolean

        Try
            '列を設定
            For Each col As DataGridViewColumn In dgvStatus.Columns
                dtStatus.Columns.Add(col.Name, col.ValueType)
            Next

            '行を設定
            For Each row As DataGridViewRow In dgvStatus.Rows
                '入力していない行、新規行はチェックしない
                If row.Cells("status_flag").Value = rowState.NoChanged Then Continue For
                If row.Cells("status_flag").Value = rowState.Update _
                    And row.Cells("delete_flag").Value = rowState.Delete Then Continue For
                If row.Cells("status_flag").Value = Nothing Then Continue For

                Dim dataRow As DataRow = dtStatus.NewRow()
                For Each cell As DataGridViewCell In row.Cells
                    dataRow(cell.ColumnIndex) = cell.Value
                Next
                dtStatus.Rows.Add(dataRow)
            Next

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
            For Each row As DataGridViewRow In dgvStatus.Rows
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

                '表示順
                If row.Cells("display_number").Value Is DBNull.Value Then
                    checkErrorFlag = True
                    MessageBox.Show("表示順が空欄です。入力してください。")
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

End Class