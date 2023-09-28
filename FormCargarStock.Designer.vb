<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCargarStock
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormCargarStock))
        Label1 = New Label()
        TextBoxNombre = New TextBox()
        TextBoxDescripcion = New TextBox()
        Label2 = New Label()
        TextBoxCategoria = New TextBox()
        Label3 = New Label()
        TextBoxPrecio = New TextBox()
        Label4 = New Label()
        TextBoxStock = New TextBox()
        Label5 = New Label()
        ButtonConfirmarStock = New Button()
        TextBoxStockMinimo = New TextBox()
        Label6 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(332, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(82, 23)
        Label1.TabIndex = 0
        Label1.Text = "NOMBRE"
        ' 
        ' TextBoxNombre
        ' 
        TextBoxNombre.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxNombre.Location = New Point(237, 52)
        TextBoxNombre.Name = "TextBoxNombre"
        TextBoxNombre.Size = New Size(274, 30)
        TextBoxNombre.TabIndex = 1
        ' 
        ' TextBoxDescripcion
        ' 
        TextBoxDescripcion.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxDescripcion.Location = New Point(237, 121)
        TextBoxDescripcion.Name = "TextBoxDescripcion"
        TextBoxDescripcion.Size = New Size(274, 30)
        TextBoxDescripcion.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(313, 95)
        Label2.Name = "Label2"
        Label2.Size = New Size(119, 23)
        Label2.TabIndex = 2
        Label2.Text = "DESCRIPCION"
        ' 
        ' TextBoxCategoria
        ' 
        TextBoxCategoria.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxCategoria.Location = New Point(237, 186)
        TextBoxCategoria.Name = "TextBoxCategoria"
        TextBoxCategoria.Size = New Size(274, 30)
        TextBoxCategoria.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(322, 160)
        Label3.Name = "Label3"
        Label3.Size = New Size(101, 23)
        Label3.TabIndex = 4
        Label3.Text = "CATEGORIA"
        ' 
        ' TextBoxPrecio
        ' 
        TextBoxPrecio.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxPrecio.Location = New Point(237, 253)
        TextBoxPrecio.Name = "TextBoxPrecio"
        TextBoxPrecio.Size = New Size(274, 30)
        TextBoxPrecio.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(340, 227)
        Label4.Name = "Label4"
        Label4.Size = New Size(69, 23)
        Label4.TabIndex = 6
        Label4.Text = "PRECIO"
        ' 
        ' TextBoxStock
        ' 
        TextBoxStock.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxStock.Location = New Point(237, 316)
        TextBoxStock.Name = "TextBoxStock"
        TextBoxStock.Size = New Size(274, 30)
        TextBoxStock.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(346, 290)
        Label5.Name = "Label5"
        Label5.Size = New Size(61, 23)
        Label5.TabIndex = 8
        Label5.Text = "STOCK"
        ' 
        ' ButtonConfirmarStock
        ' 
        ButtonConfirmarStock.BackColor = Color.Transparent
        ButtonConfirmarStock.Location = New Point(237, 431)
        ButtonConfirmarStock.Name = "ButtonConfirmarStock"
        ButtonConfirmarStock.Size = New Size(274, 49)
        ButtonConfirmarStock.TabIndex = 10
        ButtonConfirmarStock.Text = "Confirmar"
        ButtonConfirmarStock.UseVisualStyleBackColor = False
        ' 
        ' TextBoxStockMinimo
        ' 
        TextBoxStockMinimo.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        TextBoxStockMinimo.Location = New Point(237, 381)
        TextBoxStockMinimo.Name = "TextBoxStockMinimo"
        TextBoxStockMinimo.Size = New Size(274, 30)
        TextBoxStockMinimo.TabIndex = 12
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(307, 354)
        Label6.Name = "Label6"
        Label6.Size = New Size(139, 23)
        Label6.TabIndex = 11
        Label6.Text = "STOCK MINIMO "
        ' 
        ' FormCargarStock
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(782, 506)
        Controls.Add(TextBoxStockMinimo)
        Controls.Add(Label6)
        Controls.Add(ButtonConfirmarStock)
        Controls.Add(TextBoxStock)
        Controls.Add(Label5)
        Controls.Add(TextBoxPrecio)
        Controls.Add(Label4)
        Controls.Add(TextBoxCategoria)
        Controls.Add(Label3)
        Controls.Add(TextBoxDescripcion)
        Controls.Add(Label2)
        Controls.Add(TextBoxNombre)
        Controls.Add(Label1)
        Name = "FormCargarStock"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Cargar Stock"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxNombre As TextBox
    Friend WithEvents TextBoxDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxCategoria As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxPrecio As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxStock As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonConfirmarStock As Button
    Friend WithEvents TextBoxStockMinimo As TextBox
    Friend WithEvents Label6 As Label
End Class
