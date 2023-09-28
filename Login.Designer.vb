<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Login))
        Button1 = New Button()
        TextBoxUser = New TextBox()
        TextBoxPWD = New TextBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = Color.Gray
        Button1.BackgroundImageLayout = ImageLayout.None
        Button1.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(489, 253)
        Button1.Margin = New Padding(0)
        Button1.Name = "Button1"
        Button1.RightToLeft = RightToLeft.No
        Button1.Size = New Size(123, 40)
        Button1.TabIndex = 0
        Button1.Text = "INGRESAR"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBoxUser
        ' 
        TextBoxUser.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxUser.Location = New Point(202, 155)
        TextBoxUser.Name = "TextBoxUser"
        TextBoxUser.Size = New Size(410, 30)
        TextBoxUser.TabIndex = 1
        ' 
        ' TextBoxPWD
        ' 
        TextBoxPWD.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxPWD.Location = New Point(202, 206)
        TextBoxPWD.Name = "TextBoxPWD"
        TextBoxPWD.PasswordChar = "*"c
        TextBoxPWD.Size = New Size(410, 30)
        TextBoxPWD.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 13.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(202, 107)
        Label1.Name = "Label1"
        Label1.Size = New Size(291, 31)
        Label1.TabIndex = 3
        Label1.Text = "Acceso de administradores"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(67, 141)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(129, 111)
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DimGray
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(722, 453)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Controls.Add(TextBoxPWD)
        Controls.Add(TextBoxUser)
        Controls.Add(Button1)
        Name = "Login"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Acceso"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBoxUser As TextBox
    Friend WithEvents TextBoxPWD As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
