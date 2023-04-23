Public Class frmMaster
    ''' <summary>
    ''' フォームの初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim systemErrorFlag As String = False
        Dim dtStatus As New DataTable("dtStatus")

        '列追加
        dtStatus.Columns.Add("id")
        dtStatus.Columns.Add("ステータス")
        dtStatus.Columns.Add("表示順")
        dtStatus.Columns.Add("コメント")

        Try
            'データ取得
            Dim status As New clsStatus
            If status.getStatus(systemErrorFlag, dtStatus) Then Exit Try

            'データ設置
            dgvStatus.DataSource = dtStatus

            'デザイン設定
            dgvStatus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgvStatus.Columns(0).Visible = False
            dgvStatus.Columns(0).ReadOnly = True
            dgvStatus.Columns(1).Width = 100
            dgvStatus.Columns(2).Width = 80
            dgvStatus.Columns(3).Width = 350

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

        Try
            '入力チェック

            'データ登録

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

End Class