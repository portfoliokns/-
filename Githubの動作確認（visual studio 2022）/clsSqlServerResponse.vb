﻿Imports System.Data.SqlClient

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
            SQL &= String.Format("SELECT CASE WHEN EXISTS ")
            SQL &= String.Format("( ")
            SQL &= String.Format("  SELECT 1 ")
            SQL &= String.Format("  FROM USERINFO ")
            SQL &= String.Format("  WHERE user_id = @userID AND password = @password ")
            SQL &= String.Format("  HAVING COUNT(*) = 1 ")
            SQL &= String.Format(") ")
            SQL &= String.Format("THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS IsAuthenticated")

            Dim cd As New SqlCommand(SQL, cn)
            cd.Parameters.AddWithValue("@userID", userID)
            cd.Parameters.AddWithValue("@password", password)

            Dim dr As SqlDataReader = cd.ExecuteReader

            While dr.Read
                isAuthenticated = dr("IsAuthenticated")
            End While

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
