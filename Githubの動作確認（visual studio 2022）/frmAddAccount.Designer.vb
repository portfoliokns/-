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
        txtRePassword = New TextBox()
        lblRePassword = New Label()
        ckbPassword = New CheckBox()
        SuspendLayout()
        ' 
        ' lblUserID
        ' 
        lblUserID.AutoSize = True
        lblUserID.Location = New Point(34, 37)
        lblUserID.Name = "lblUserID"
        lblUserID.Size = New Size(66, 15)
        lblUserID.TabIndex = 0
        lblUserID.Text = "ユーザーID："
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(34, 87)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(63, 15)
        lblPassword.TabIndex = 1
        lblPassword.Text = "パスワード："
        ' 
        ' txtUserID
        ' 
        txtUserID.Location = New Point(122, 34)
        txtUserID.MaxLength = 8
        txtUserID.Name = "txtUserID"
        txtUserID.Size = New Size(100, 23)
        txtUserID.TabIndex = 3
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(122, 84)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(100, 23)
        txtPassword.TabIndex = 4
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(41, 216)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 7
        btnAdd.Text = "登録"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(141, 216)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 8
        btnClose.Text = "閉じる"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' txtRePassword
        ' 
        txtRePassword.Location = New Point(122, 131)
        txtRePassword.Name = "txtRePassword"
        txtRePassword.PasswordChar = "*"c
        txtRePassword.Size = New Size(100, 23)
        txtRePassword.TabIndex = 5
        ' 
        ' lblRePassword
        ' 
        lblRePassword.AutoSize = True
        lblRePassword.Location = New Point(34, 134)
        lblRePassword.Name = "lblRePassword"
        lblRePassword.Size = New Size(83, 15)
        lblRePassword.TabIndex = 2
        lblRePassword.Text = "パスワード(再)："
        ' 
        ' ckbPassword
        ' 
        ckbPassword.AutoSize = True
        ckbPassword.Location = New Point(85, 176)
        ckbPassword.Name = "ckbPassword"
        ckbPassword.Size = New Size(103, 19)
        ckbPassword.TabIndex = 6
        ckbPassword.Text = "パスワードを表示"
        ckbPassword.UseVisualStyleBackColor = True
        ' 
        ' frmAddAccount
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(256, 267)
        Controls.Add(ckbPassword)
        Controls.Add(txtRePassword)
        Controls.Add(lblRePassword)
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
    Friend WithEvents txtRePassword As TextBox
    Friend WithEvents lblRePassword As Label
    Friend WithEvents ckbPassword As CheckBox
End Class
