Public Class frmMaster
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
            If dgvStatus.Rows(rowIndex).Cells("changed_flag").Value Is DBNull.Value Then
                dgvStatus.Rows(rowIndex).Cells("changed_flag").Value = True
            End If
            If Convert.ToBoolean(dgvStatus.Rows(rowIndex).Cells("changed_flag").Value) = False Then
                dgvStatus.Rows(rowIndex).Cells("changed_flag").Value = True
            End If

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
            If Me.setDataTable(systemErrorFlag, dtStatus) Then Exit Try

            'データ登録
            Dim status As New clsStatus
            If status.setStatus(systemErrorFlag, dtStatus) Then Exit Try
            MessageBox.Show("保存が完了しました")

            '表示データを設定
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


    Private Function setDataGridView(ByRef systemErrorFlag As Boolean) As Boolean
        Dim dtStatus As New DataTable("dtStatus")
        dtStatus.Columns.Add("id")
        dtStatus.Columns.Add("status")
        dtStatus.Columns.Add("display_number")
        dtStatus.Columns.Add("comment")

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

            '■デザイン設定
            '列幅設定
            dgvStatus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgvStatus.Columns("id").Width = 0
            dgvStatus.Columns("status").Width = 100
            dgvStatus.Columns("display_number").Width = 80
            dgvStatus.Columns("comment").Width = 350
            dgvStatus.Columns("changed_flag").Width = 0

            '操作不可
            dgvStatus.Columns("id").Visible = False
            dgvStatus.Columns("changed_flag").Visible = False
            dgvStatus.Columns("id").ReadOnly = True
            dgvStatus.Columns("changed_flag").ReadOnly = True

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
                '入力していない行は、テーブルに設定しない
                If row.Cells("changed_flag").Value = False Then Continue For

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

                '入力していない行は、チェックしない
                If row.Cells("changed_flag").Value = False Then Continue For

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