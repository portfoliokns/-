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
        dgvStatus = New DataGridView()
        CType(dgvStatus, ComponentModel.ISupportInitialize).BeginInit()
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
        ' dgvStatus
        ' 
        dgvStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStatus.Location = New Point(12, 12)
        dgvStatus.Name = "dgvStatus"
        dgvStatus.RowTemplate.Height = 25
        dgvStatus.Size = New Size(580, 150)
        dgvStatus.TabIndex = 12
        ' 
        ' frmMaster
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(608, 220)
        Controls.Add(dgvStatus)
        Controls.Add(btnClose)
        Controls.Add(btnSave)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmMaster"
        Text = "マスタ登録"
        CType(dgvStatus, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents dgvStatus As DataGridView
End Class
