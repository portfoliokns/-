Public Class clsStatus
    Dim rowState As New clsRowState

    ''' <summary>
    ''' ステータスを取得する
    ''' </summary>
    ''' <param name="systemErrorFlag"></param>
    ''' <param name="userID"></param>
    ''' <param name="userExist"></param>
    ''' <returns></returns>
    Public Function getStatus(ByRef systemErrorFlag As Boolean, ByRef dtStatus As DataTable) As Boolean
        dtStatus.Columns.Add("id")
        dtStatus.Columns.Add("status")
        dtStatus.Columns.Add("display_number")
        dtStatus.Columns.Add("comment")
        dtStatus.Columns.Add("delete_flag")

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.getStatusMaster(systemErrorFlag, dtStatus) Then Exit Try

            '列追加
            dtStatus.Columns.Add("status_flag")
            For Each row As DataRow In dtStatus.Rows
                row("status_flag") = rowState.NoChanged
            Next

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' ステータスを設定する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="dtStatus">ステータステーブル</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function setStatus(ByRef systemErrorFlag As Boolean, ByRef dtStatus As DataTable) As Boolean

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.insertStatus(systemErrorFlag, dtStatus) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
