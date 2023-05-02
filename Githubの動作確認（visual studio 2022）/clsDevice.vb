Public Class clsDevice
    Dim rowState As New clsRowState

    ''' <summary>
    ''' 機器・端末情報を取得する
    ''' </summary>
    ''' <param name="systemErrorFlag"></param>
    ''' <param name="userID"></param>
    ''' <param name="userExist"></param>
    ''' <returns></returns>
    Public Function getDevice(ByRef systemErrorFlag As Boolean, ByRef dtDevice As DataTable) As Boolean
        dtDevice.Columns.Add("id")
        dtDevice.Columns.Add("status")
        dtDevice.Columns.Add("admin")
        dtDevice.Columns.Add("device")
        dtDevice.Columns.Add("appendix")
        dtDevice.Columns.Add("delete_flag")

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.getDeviceInfo(systemErrorFlag, dtDevice) Then Exit Try

            '列追加
            dtDevice.Columns.Add("status_flag")
            For Each row As DataRow In dtDevice.Rows
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
    ''' 機器・端末情報を設定する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="dtDevice">ステータステーブル</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function setDevice(ByRef systemErrorFlag As Boolean, ByRef dtDevice As DataTable) As Boolean

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            'If sqlServerConnector.insertStatus(systemErrorFlag, dtDevice) Then Exit Try

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
