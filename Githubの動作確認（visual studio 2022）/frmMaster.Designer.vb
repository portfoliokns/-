<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaster
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnClose = New Button()
        btnSave = New Button()
        DataGridView1 = New DataGridView()
        Status = New DataGridViewTextBoxColumn()
        DisplayNum = New DataGridViewTextBoxColumn()
        Comment = New DataGridViewTextBoxColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(494, 182)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 11
        btnClose.Text = "閉じる"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(394, 182)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 10
        btnSave.Text = "保存"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Status, DisplayNum, Comment})
        DataGridView1.Location = New Point(12, 12)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(580, 150)
        DataGridView1.TabIndex = 12
        ' 
        ' Status
        ' 
        Status.HeaderText = "ステータス"
        Status.Name = "Status"
        ' 
        ' DisplayNum
        ' 
        DisplayNum.HeaderText = "表示番号"
        DisplayNum.Name = "DisplayNum"
        DisplayNum.Width = 80
        ' 
        ' Comment
        ' 
        Comment.HeaderText = "コメント"
        Comment.Name = "Comment"
        Comment.Width = 300
        ' 
        ' frmMaster
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(608, 220)
        Controls.Add(DataGridView1)
        Controls.Add(btnClose)
        Controls.Add(btnSave)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmMaster"
        Text = "マスタ登録"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents DisplayNum As DataGridViewTextBoxColumn
    Friend WithEvents Comment As DataGridViewTextBoxColumn
End Class
