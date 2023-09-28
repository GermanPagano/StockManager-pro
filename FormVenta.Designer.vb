<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVenta
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormVenta))
        ButtonRegistrarVenta = New Button()
        TextBoxCantidad = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        ComboBox1 = New ComboBox()
        DateTimePicker1 = New DateTimePicker()
        SuspendLayout()
        ' 
        ' ButtonRegistrarVenta
        ' 
        ButtonRegistrarVenta.Location = New Point(195, 314)
        ButtonRegistrarVenta.Name = "ButtonRegistrarVenta"
        ButtonRegistrarVenta.Size = New Size(377, 50)
        ButtonRegistrarVenta.TabIndex = 25
        ButtonRegistrarVenta.Text = "VENDER"
        ButtonRegistrarVenta.UseVisualStyleBackColor = True
        ' 
        ' TextBoxCantidad
        ' 
        TextBoxCantidad.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxCantidad.Location = New Point(192, 170)
        TextBoxCantidad.Name = "TextBoxCantidad"
        TextBoxCantidad.Size = New Size(380, 31)
        TextBoxCantidad.TabIndex = 16
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(327, 144)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 23)
        Label2.TabIndex = 15
        Label2.Text = "CANTIDAD"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(175, 55)
        Label1.Name = "Label1"
        Label1.Size = New Size(420, 31)
        Label1.TabIndex = 14
        Label1.Text = "Selecciona el producto y carga la venta"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(191, 99)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(380, 31)
        ComboBox1.TabIndex = 13
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CalendarFont = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        DateTimePicker1.Location = New Point(191, 241)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(380, 27)
        DateTimePicker1.TabIndex = 26
        ' 
        ' FormVenta
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(800, 441)
        Controls.Add(DateTimePicker1)
        Controls.Add(ButtonRegistrarVenta)
        Controls.Add(TextBoxCantidad)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(ComboBox1)
        Name = "FormVenta"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Venta"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ButtonRegistrarVenta As Button
    Friend WithEvents TextBoxCantidad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
