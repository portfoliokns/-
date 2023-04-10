Imports System.Data.SqlClient

Public Class clsSqlServerRespoder

    Public Function getAutenticate(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String, ByRef isAuthenticated As Boolean) As Boolean
        Dim cn As New SqlClient.SqlConnection

        Try

            Dim dataSource As String = System.Environment.GetEnvironmentVariable("DEV_DATA_SOURCE")
            Dim initialCatalog As String = System.Environment.GetEnvironmentVariable("DEV_INITIAL_CATALOG")
            Dim sqlUserID As String = System.Environment.GetEnvironmentVariable("DEV_USER")
            Dim sqpPass As String = System.Environment.GetEnvironmentVariable("DEV_PASSWORD")

            Dim connectionString As String = ""
            connectionString &= String.Format("Data Source = {0};", dataSource)
            connectionString &= String.Format("Initial Catalog = {0};", initialCatalog)
            connectionString &= String.Format("User ID = {0};", sqlUserID)
            connectionString &= String.Format("Password = {0};", sqpPass)
            connectionString &= String.Format("Connect Timeout = {0};", 30)

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
