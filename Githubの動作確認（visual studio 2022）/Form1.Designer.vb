<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoginScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblUserID = New Label()
        lblPassword = New Label()
        txtUserID = New TextBox()
        txtPassword = New TextBox()
        btnLogin = New Button()
        btnClose = New Button()
        SuspendLayout()
        ' 
        ' lblUserID
        ' 
        lblUserID.AutoSize = True
        lblUserID.Location = New Point(120, 47)
        lblUserID.Name = "lblUserID"
        lblUserID.Size = New Size(66, 15)
        lblUserID.TabIndex = 0
        lblUserID.Text = "ユーザーID："
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(120, 104)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(63, 15)
        lblPassword.TabIndex = 1
        lblPassword.Text = "パスワード："
        ' 
        ' txtUserID
        ' 
        txtUserID.Location = New Point(215, 39)
        txtUserID.Name = "txtUserID"
        txtUserID.Size = New Size(100, 23)
        txtUserID.TabIndex = 2
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(215, 101)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(100, 23)
        txtPassword.TabIndex = 3
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(109, 165)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(75, 23)
        btnLogin.TabIndex = 4
        btnLogin.Text = "ログイン"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(230, 165)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 5
        btnClose.Text = "閉じる"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' frmLoginScreen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(407, 230)
        Controls.Add(btnClose)
        Controls.Add(btnLogin)
        Controls.Add(txtPassword)
        Controls.Add(txtUserID)
        Controls.Add(lblPassword)
        Controls.Add(lblUserID)
        Name = "frmLoginScreen"
        Text = "ログイン"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblUserID As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnClose As Button
End Class
