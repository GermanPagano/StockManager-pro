<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormModificarStock
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormModificarStock))
        ComboBox1 = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label3 = New Label()
        TextBox3 = New TextBox()
        Label4 = New Label()
        TextBox4 = New TextBox()
        Label5 = New Label()
        TextBox5 = New TextBox()
        Label6 = New Label()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(183, 62)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(380, 31)
        ComboBox1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(186, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(375, 31)
        Label1.TabIndex = 1
        Label1.Text = "Selecciona el producto a modificar"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(282, 107)
        Label2.Name = "Label2"
        Label2.Size = New Size(183, 23)
        Label2.TabIndex = 2
        Label2.Text = "MODIFICAR NOMBRE"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.Location = New Point(184, 133)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(380, 31)
        TextBox1.TabIndex = 3
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox2.Location = New Point(184, 205)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(380, 31)
        TextBox2.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(263, 179)
        Label3.Name = "Label3"
        Label3.Size = New Size(221, 23)
        Label3.TabIndex = 4
        Label3.Text = "MODIFICAR DESCRIPCION"
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox3.Location = New Point(184, 274)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(380, 31)
        TextBox3.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(277, 248)
        Label4.Name = "Label4"
        Label4.Size = New Size(204, 23)
        Label4.TabIndex = 6
        Label4.Text = "MODIFICAR CATEGORIA"
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox4.Location = New Point(184, 345)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(380, 31)
        TextBox4.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(286, 319)
        Label5.Name = "Label5"
        Label5.Size = New Size(169, 23)
        Label5.TabIndex = 8
        Label5.Text = "MODIFICAR PRECIO"
        ' 
        ' TextBox5
        ' 
        TextBox5.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox5.Location = New Point(184, 419)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(380, 31)
        TextBox5.TabIndex = 11
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(286, 393)
        Label6.Name = "Label6"
        Label6.Size = New Size(164, 23)
        Label6.TabIndex = 10
        Label6.Text = "MODIFICAR STOCK"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(186, 470)
        Button1.Name = "Button1"
        Button1.Size = New Size(377, 50)
        Button1.TabIndex = 12
        Button1.Text = "ACTUALIZAR"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' FormModificarStock
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(782, 556)
        Controls.Add(Button1)
        Controls.Add(TextBox5)
        Controls.Add(Label6)
        Controls.Add(TextBox4)
        Controls.Add(Label5)
        Controls.Add(TextBox3)
        Controls.Add(Label4)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(ComboBox1)
        Name = "FormModificarStock"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "ACTUALIZAR"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
End Class
