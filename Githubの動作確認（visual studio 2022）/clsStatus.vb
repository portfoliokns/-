Public Class clsStatus
    ''' <summary>
    ''' 状況情報を取得する
    ''' </summary>
    ''' <param name="systemErrorFlag"></param>
    ''' <param name="userID"></param>
    ''' <param name="userExist"></param>
    ''' <returns></returns>
    Public Function getStatus(ByRef systemErrorFlag As Boolean, ByRef dtStatus As DataTable) As Boolean

        Try
            'SQL接続
            Dim sqlServerConnector As New clsSqlServerConnector
            If sqlServerConnector.getStatusMaster(systemErrorFlag, dtStatus) Then Exit Try

            '列追加
            dtStatus.Columns.Add("changed_flag")
            For Each row As DataRow In dtStatus.Rows
                row("changed_flag") = False
            Next

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function


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
