Imports System.Data.SqlClient

Public Class clsSqlServerRespoder

    Public Function getAutenticate(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String, ByRef isAuthenticated As Boolean) As Boolean
        Dim cn As New SqlClient.SqlConnection

        Try

            Dim devDataSource As String = System.Environment.GetEnvironmentVariable("DEV_DATA_SOURCE")
            Dim devInitialCatalog As String = System.Environment.GetEnvironmentVariable("DEV_INITIAL_CATALOG")
            Dim devUserID As String = System.Environment.GetEnvironmentVariable("DEV_USER")
            Dim devPassword As String = System.Environment.GetEnvironmentVariable("DEV_PASSWORD")
            Dim devTimeout As String = System.Environment.GetEnvironmentVariable("DEV_TIMEOUT")

            Dim connectionString As String = ""
            connectionString &= String.Format("Data Source = {0};", devDataSource)
            connectionString &= String.Format("Initial Catalog = {0};", devInitialCatalog)
            connectionString &= String.Format("User ID = {0};", devUserID)
            connectionString &= String.Format("Password = {0};", devPassword)
            connectionString &= String.Format("Connect Timeout = {0};", devTimeout)

            cn.ConnectionString = connectionString
            cn.Open()

            Dim SQL As String = ""
            SQL &= String.Format("SELECT COUNT(*) AS COUNT ")
            SQL &= String.Format("FROM UserInfo  ")
            SQL &= String.Format("WHERE user_id = @userID ")
            SQL &= String.Format("AND ")
            SQL &= String.Format("password = @password ")

            Dim cd As New SqlCommand(SQL, cn)
            cd.Parameters.AddWithValue("@userID", userID)
            cd.Parameters.AddWithValue("@password", password)

            Dim dr As SqlDataReader = cd.ExecuteReader

            Dim count As Integer
            While dr.Read
                count = dr("COUNT")
            End While

            If count = 1 Then
                isAuthenticated = True
            Else
                isAuthenticated = False
            End If

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
