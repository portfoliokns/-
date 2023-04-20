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
        SuspendLayout()
        ' 
        ' btnAddAccount
        ' 
        btnAddAccount.Enabled = False
        btnAddAccount.Location = New Point(187, 12)
        btnAddAccount.Name = "btnAddAccount"
        btnAddAccount.Size = New Size(87, 23)
        btnAddAccount.TabIndex = 0
        btnAddAccount.Text = "アカウント登録"
        btnAddAccount.UseVisualStyleBackColor = True
        btnAddAccount.Visible = False
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(280, 12)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(87, 23)
        btnLogout.TabIndex = 1
        btnLogout.Text = "ログアウト"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnAddMaster
        ' 
        btnAddMaster.Enabled = False
        btnAddMaster.Location = New Point(94, 12)
        btnAddMaster.Name = "btnAddMaster"
        btnAddMaster.Size = New Size(87, 23)
        btnAddMaster.TabIndex = 2
        btnAddMaster.Text = "マスタ登録"
        btnAddMaster.UseVisualStyleBackColor = True
        btnAddMaster.Visible = False
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(377, 450)
        Controls.Add(btnAddMaster)
        Controls.Add(btnLogout)
        Controls.Add(btnAddAccount)
        Name = "frmMain"
        Text = "ログイン成功"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnAddAccount As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnAddMaster As Button
End Class
