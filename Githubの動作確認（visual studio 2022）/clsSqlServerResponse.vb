Imports System.Data.SqlClient

Public Class clsSqlServerRespoder

    Public Function getAutenticate(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String, ByRef isAuthenticated As Boolean) As Boolean
        Dim cn As New SqlClient.SqlConnection

        Try

            Dim connectionString As String = ""
            connectionString = "Data Source = localhost\Dev;"
            connectionString = "User ID = test;"
            connectionString = "Password = test;"
            connectionString = "Initial Catalog = test;"

            cn.ConnectionString = connectionString
            cn.Open()

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
            cn.Close()
            cn.Dispose()
        End Try

        Return systemErrorFlag
    End Function

End Class
