Imports System.Data.SqlClient

''' <summary>
''' SQLServer接続基盤
''' </summary>
Public Class clsSqlServerConnector
    ''' <summary>
    ''' SQLServerへの接続先情報を取得する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="connectionString">接続先情報</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function getConnection(ByRef systemErrorFlag As Boolean, ByRef connectionString As String) As Boolean

        Try
            '接続先情報を取得
            Dim devDataSource As String = System.Environment.GetEnvironmentVariable("DEV_DATA_SOURCE")
            Dim devInitialCatalog As String = System.Environment.GetEnvironmentVariable("DEV_INITIAL_CATALOG")
            Dim devUserID As String = System.Environment.GetEnvironmentVariable("DEV_USER")
            Dim devPassword As String = System.Environment.GetEnvironmentVariable("DEV_PASSWORD")
            Dim devTimeout As String = System.Environment.GetEnvironmentVariable("DEV_TIMEOUT")

            '接続先情報を構築
            connectionString = ""
            connectionString &= String.Format("Data Source = {0};", devDataSource)
            connectionString &= String.Format("Initial Catalog = {0};", devInitialCatalog)
            connectionString &= String.Format("User ID = {0};", devUserID)
            connectionString &= String.Format("Password = {0};", devPassword)
            connectionString &= String.Format("Connect Timeout = {0};", devTimeout)

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        End Try

        Return systemErrorFlag
    End Function

    Private connectionString As String
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
        Dim SQL As String = ""

        Try

            If getConnection(systemErrorFlag, connectionString) Then Exit Try
            cn.ConnectionString = connectionString
            cn.Open()

            SQL = ""
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
        Dim SQL As String = ""

        Try

            If getConnection(systemErrorFlag, connectionString) Then Exit Try
            cn.ConnectionString = connectionString
            cn.Open()

            SQL = ""
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
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <param name="password"></param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function insertUserInfo(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef password As String) As Boolean
        Dim cn As New SqlClient.SqlConnection
        Dim SQL As String = ""
        Dim maxID As Integer

        Try

            If getConnection(systemErrorFlag, connectionString) Then Exit Try
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
            SQL &= String.Format("INSERT INTO UserInfo (id, user_id, password,revoke_count, revoke_flag) ")
            SQL &= String.Format("VALUES (@id, @userID, @password, 0, 'False'); ")

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

    ''' <summary>
    ''' リボークカウントを「１」加算し、閾値に応じてリボーク状態にする
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function addCountAndRevoke(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef revokeCount As Integer) As Boolean
        Dim cn As New SqlClient.SqlConnection
        Dim SQL As String = ""

        Try

            If getConnection(systemErrorFlag, connectionString) Then Exit Try
            cn.ConnectionString = connectionString
            cn.Open()

            SQL = ""
            SQL &= String.Format("BEGIN TRANSACTION; ")
            SQL &= String.Format(" ")
            SQL &= String.Format("UPDATE UserInfo ")
            SQL &= String.Format("SET revoke_count = revoke_count + 1 ")
            SQL &= String.Format("WHERE user_id = @userID; ")
            SQL &= String.Format(" ")
            SQL &= String.Format("UPDATE UserInfo ")
            SQL &= String.Format("SET revoke_flag = 'True' ")
            SQL &= String.Format("WHERE user_id = @userID ")
            SQL &= String.Format("AND ")
            SQL &= String.Format("revoke_count >= @revokeCount; ")
            SQL &= String.Format(" ")
            SQL &= String.Format("COMMIT; ")

            Dim cd As New SqlCommand(SQL, cn)
            cd.Parameters.AddWithValue("@userID", userID)
            cd.Parameters.AddWithValue("@revokeCount", revokeCount)
            cd.ExecuteNonQuery()

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' リボークの状態を確認する
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <param name="revokeStatus">リボーク状態</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function checkRevokeStatus(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef revokeStatus As Boolean) As Boolean
        Dim cn As New SqlClient.SqlConnection
        Dim SQL As String = ""

        Try

            If getConnection(systemErrorFlag, connectionString) Then Exit Try
            cn.ConnectionString = connectionString
            cn.Open()

            SQL = ""
            SQL &= String.Format("SELECT CASE WHEN EXISTS ")
            SQL &= String.Format("( ")
            SQL &= String.Format("  SELECT 1 ")
            SQL &= String.Format("  FROM USERINFO ")
            SQL &= String.Format("  WHERE user_id = @userID ")
            SQL &= String.Format("  AND revoke_flag = 'True' ")
            SQL &= String.Format(") ")
            SQL &= String.Format("THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS revokeStatus")

            Dim cd As New SqlCommand(SQL, cn)
            cd.Parameters.AddWithValue("@userID", userID)

            Dim dr As SqlDataReader = cd.ExecuteReader

            While dr.Read
                revokeStatus = dr("revokeStatus")
            End While

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

    ''' <summary>
    ''' リボークのカウントを「0」にする
    ''' </summary>
    ''' <param name="systemErrorFlag">システムエラーフラグ</param>
    ''' <param name="userID">ユーザーID</param>
    ''' <returns>システムエラーフラグ</returns>
    Public Function resetRevokeCount(ByRef systemErrorFlag As Boolean, ByRef userID As String) As Boolean
        Dim cn As New SqlClient.SqlConnection
        Dim SQL As String = ""

        Try

            If getConnection(systemErrorFlag, connectionString) Then Exit Try
            cn.ConnectionString = connectionString
            cn.Open()

            SQL = ""
            SQL &= String.Format("BEGIN TRANSACTION; ")
            SQL &= String.Format(" ")
            SQL &= String.Format("UPDATE UserInfo ")
            SQL &= String.Format("SET revoke_count = 0 ")
            SQL &= String.Format("WHERE user_id = @userID ")
            SQL &= String.Format("AND revoke_flag = 'False'; ")
            SQL &= String.Format(" ")
            SQL &= String.Format("COMMIT; ")

            Dim cd As New SqlCommand(SQL, cn)
            cd.Parameters.AddWithValue("@userID", userID)
            cd.ExecuteNonQuery()

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function


    Public Function checkAdmin(ByRef systemErrorFlag As Boolean, ByRef userID As String, ByRef isAdmin As Boolean) As Boolean
        Dim cn As New SqlClient.SqlConnection
        Dim SQL As String = ""

        Try

            If getConnection(systemErrorFlag, connectionString) Then Exit Try
            cn.ConnectionString = connectionString
            cn.Open()

            SQL = ""
            SQL &= String.Format("SELECT CASE WHEN EXISTS ")
            SQL &= String.Format("( ")
            SQL &= String.Format("  SELECT 1 ")
            SQL &= String.Format("  FROM USERINFO ")
            SQL &= String.Format("  WHERE user_id = @userID ")
            SQL &= String.Format("  AND admin_flag = 'True' ")
            SQL &= String.Format(") ")
            SQL &= String.Format("THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS isAdmin")

            Dim cd As New SqlCommand(SQL, cn)
            cd.Parameters.AddWithValue("@userID", userID)

            Dim dr As SqlDataReader = cd.ExecuteReader

            While dr.Read
                isAdmin = dr("isAdmin")
            End While

        Catch ex As Exception
            systemErrorFlag = True
            MessageBox.Show("エラーが発生しました： " & ex.Message)
        Finally
        End Try

        Return systemErrorFlag
    End Function

End Class
