<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddAccount
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
        lblUserID = New Label()
        lblPassword = New Label()
        txtUserID = New TextBox()
        txtPassword = New TextBox()
        btnAdd = New Button()
        btnClose = New Button()
        SuspendLayout()
        ' 
        ' lblUserID
        ' 
        lblUserID.AutoSize = True
        lblUserID.Location = New Point(37, 40)
        lblUserID.Name = "lblUserID"
        lblUserID.Size = New Size(66, 15)
        lblUserID.TabIndex = 0
        lblUserID.Text = "ユーザーID："
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(37, 90)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(63, 15)
        lblPassword.TabIndex = 1
        lblPassword.Text = "パスワード："
        ' 
        ' txtUserID
        ' 
        txtUserID.Location = New Point(119, 37)
        txtUserID.MaxLength = 8
        txtUserID.Name = "txtUserID"
        txtUserID.Size = New Size(100, 23)
        txtUserID.TabIndex = 2
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(119, 87)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(100, 23)
        txtPassword.TabIndex = 3
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(34, 139)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 4
        btnAdd.Text = "登録"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(141, 139)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 5
        btnClose.Text = "閉じる"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' frmAddAccount
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(256, 193)
        Controls.Add(btnClose)
        Controls.Add(btnAdd)
        Controls.Add(txtPassword)
        Controls.Add(txtUserID)
        Controls.Add(lblPassword)
        Controls.Add(lblUserID)
        Name = "frmAddAccount"
        Text = "アカウント登録"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblUserID As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnClose As Button
End Class
