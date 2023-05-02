<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        btnAddAccount = New Button()
        btnLogout = New Button()
        btnAddMaster = New Button()
        dgvDevice = New DataGridView()
        btnSave = New Button()
        CType(dgvDevice, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAddAccount
        ' 
        btnAddAccount.Enabled = False
        btnAddAccount.Location = New Point(542, 12)
        btnAddAccount.Name = "btnAddAccount"
        btnAddAccount.Size = New Size(88, 23)
        btnAddAccount.TabIndex = 1
        btnAddAccount.Text = "アカウント登録"
        btnAddAccount.UseVisualStyleBackColor = True
        btnAddAccount.Visible = False
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(635, 12)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(88, 23)
        btnLogout.TabIndex = 2
        btnLogout.Text = "ログアウト"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnAddMaster
        ' 
        btnAddMaster.Enabled = False
        btnAddMaster.Location = New Point(449, 12)
        btnAddMaster.Name = "btnAddMaster"
        btnAddMaster.Size = New Size(88, 23)
        btnAddMaster.TabIndex = 0
        btnAddMaster.Text = "マスタ登録"
        btnAddMaster.UseVisualStyleBackColor = True
        btnAddMaster.Visible = False
        ' 
        ' dgvDevice
        ' 
        dgvDevice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDevice.Location = New Point(12, 41)
        dgvDevice.Name = "dgvDevice"
        dgvDevice.RowTemplate.Height = 25
        dgvDevice.Size = New Size(711, 359)
        dgvDevice.TabIndex = 3
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(635, 415)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(76, 23)
        btnSave.TabIndex = 9
        btnSave.Text = "登録"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(735, 450)
        Controls.Add(btnSave)
        Controls.Add(dgvDevice)
        Controls.Add(btnAddMaster)
        Controls.Add(btnLogout)
        Controls.Add(btnAddAccount)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmMain"
        Text = "管理画面"
        CType(dgvDevice, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnAddAccount As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnAddMaster As Button
    Friend WithEvents dgvDevice As DataGridView
    Friend WithEvents btnSave As Button
End Class
