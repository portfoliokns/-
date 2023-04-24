Public Class frmMaster
    ''' <summary>
    ''' フォームの初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim systemErrorFlag As String = False

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


    Private Function setDesign(ByRef systemErrorFlag As Boolean, ByRef dtStatus As DataTable) As Boolean

        Try
            'データテーブル設定
            dgvStatus.DataSource = dtStatus

            'デザイン設定
            dgvStatus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgvStatus.Columns("id").Width = 0
            dgvStatus.Columns("status").Width = 100
            dgvStatus.Columns("display_number").Width = 80
            dgvStatus.Columns("comment").Width = 350

            dgvStatus.Columns("id").Visible = False
            dgvStatus.Columns("id").ReadOnly = True

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

End Class