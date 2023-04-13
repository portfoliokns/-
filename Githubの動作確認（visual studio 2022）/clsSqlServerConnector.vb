Imports System.Data.SqlClient

''' <summary>
''' SQLServer接続基盤
''' </summary>
Public Class clsSqlServerConnector

    ''' <summary>
    ''' 認証結果を問い合わせる
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <param name="password">パスワード</param>
    ''' <param name="isAuthenticated">認証結果</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function getAuthentication(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String, ByRef isAuthenticated As Boolean) As Boolean
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
            SQL &= String.Format("THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS isAuthenticated")

            Dim cd As New SqlCommand(SQL, cn)
            cd.Parameters.AddWithValue("@userID", userID)
            cd.Parameters.AddWithValue("@password", password)

            Dim dr As SqlDataReader = cd.ExecuteReader

            While dr.Read
                isAuthenticated = dr("isAuthenticated")
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

    ''' <summary>
    ''' ユーザーIDの登録状況を問い合わせる
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <param name="isExist">存在結果</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function checkUserExist(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef isExist As Boolean) As Boolean
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
            SQL &= String.Format("  WHERE user_id = @userID ")
            SQL &= String.Format("  HAVING COUNT(*) = 1 ")
            SQL &= String.Format(") ")
            SQL &= String.Format("THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS isExist")

            Dim cd As New SqlCommand(SQL, cn)
            cd.Parameters.AddWithValue("@userID", userID)

            Dim dr As SqlDataReader = cd.ExecuteReader

            While dr.Read
                isExist = dr("isExist")
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

    ''' <summary>
    ''' ユーザー情報を登録する
    ''' </summary>
    ''' <param name="systemErrorFlag"></param>
    ''' <param name="userID"></param>
    ''' <param name="isExist"></param>
    ''' <returns></returns>
    Public Function insertUserInfo(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String) As Boolean
        Dim cn As New SqlClient.SqlConnection
        Dim SQL As String = ""
        Dim maxID As Integer

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

            SQL = ""
            SQL &= String.Format("SELECT MAX(id) AS maxID ")
            SQL &= String.Format("FROM UserInfo; ")

            Dim cdSelect As New SqlCommand(SQL, cn)
            Dim dr As SqlDataReader = cdSelect.ExecuteReader

            While dr.Read
                maxID = dr("maxID")
            End While

            cn.Close()

            cn.Open()

            SQL = ""
            SQL &= String.Format("INSERT INTO UserInfo (id, user_id, password) ")
            SQL &= String.Format("VALUES (@id, @userID, @password); ")

            Dim cdInsert As New SqlCommand(SQL, cn)
            cdInsert.Parameters.AddWithValue("@id", maxID + 1)
            cdInsert.Parameters.AddWithValue("@userID", userID)
            cdInsert.Parameters.AddWithValue("@password", password)
            cdInsert.ExecuteNonQuery()

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
