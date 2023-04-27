''' <summary>
''' DataGridViewの状態管理クラス
''' </summary>
Public Class clsRowState
    Private Enum _Status
        NoChanged
        Edit
        Update
    End Enum

    Public ReadOnly Property NoChanged() As String
        Get
            Return _Status.NoChanged.ToString
        End Get
    End Property

    Public ReadOnly Property Edit() As String
        Get
            Return _Status.Edit.ToString
        End Get
    End Property

    Public ReadOnly Property Update() As String
        Get
            Return _Status.Update.ToString
        End Get
    End Property

    Public ReadOnly Property NotDelete() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property Delete() As Boolean
        Get
            Return True
        End Get
    End Property

End Class
