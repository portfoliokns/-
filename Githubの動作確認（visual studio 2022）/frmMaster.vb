Public Class frmMaster
    ''' <summary>
    ''' フォームの初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim systemErrorFlag As String = False
        Dim dtStatus As DataTable = Nothing

        Try

            'データ取得
            Dim status As New clsStatus
            If status.getStatus(systemErrorFlag, dtStatus) Then Exit Try

            'データ設置


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