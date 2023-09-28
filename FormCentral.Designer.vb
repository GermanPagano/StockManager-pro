<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCentral
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
        components = New ComponentModel.Container()
        ToolTip1 = New ToolTip(components)
        TabControl1 = New TabControl()
        Productos = New TabPage()
        DataGridView1 = New DataGridView()
        PanelHerramientas = New Panel()
        TextBoxBuscar = New TextBox()
        ButtonBuscar = New Button()
        Button3 = New Button()
        ButtonModificar = New Button()
        BtnCargarStock = New Button()
        Ventas = New TabPage()
        Panel3 = New Panel()
        DataGridView2 = New DataGridView()
        Panel1 = New Panel()
        ButtonCancelarVenta = New Button()
        Button2 = New Button()
        TextBoxBuscarVenta = New TextBox()
        ButtonBuscarVenta = New Button()
        Button5 = New Button()
        TabControl1.SuspendLayout()
        Productos.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        PanelHerramientas.SuspendLayout()
        Ventas.SuspendLayout()
        Panel3.SuspendLayout()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(Productos)
        TabControl1.Controls.Add(Ventas)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 0)
        TabControl1.Margin = New Padding(0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1369, 584)
        TabControl1.TabIndex = 0
        ' 
        ' Productos
        ' 
        Productos.BackColor = Color.Transparent
        Productos.Controls.Add(DataGridView1)
        Productos.Controls.Add(PanelHerramientas)
        Productos.Location = New Point(4, 29)
        Productos.Name = "Productos"
        Productos.Padding = New Padding(3)
        Productos.Size = New Size(1361, 551)
        Productos.TabIndex = 0
        Productos.Text = "Productos"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowDrop = True
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(3, 43)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 29
        DataGridView1.Size = New Size(1355, 505)
        DataGridView1.TabIndex = 1
        ' 
        ' PanelHerramientas
        ' 
        PanelHerramientas.BackColor = Color.Gainsboro
        PanelHerramientas.Controls.Add(TextBoxBuscar)
        PanelHerramientas.Controls.Add(ButtonBuscar)
        PanelHerramientas.Controls.Add(Button3)
        PanelHerramientas.Controls.Add(ButtonModificar)
        PanelHerramientas.Controls.Add(BtnCargarStock)
        PanelHerramientas.Dock = DockStyle.Top
        PanelHerramientas.Location = New Point(3, 3)
        PanelHerramientas.Margin = New Padding(0)
        PanelHerramientas.Name = "PanelHerramientas"
        PanelHerramientas.Size = New Size(1355, 40)
        PanelHerramientas.TabIndex = 0
        ' 
        ' TextBoxBuscar
        ' 
        TextBoxBuscar.AutoCompleteMode = AutoCompleteMode.Append
        TextBoxBuscar.Dock = DockStyle.Right
        TextBoxBuscar.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxBuscar.Location = New Point(910, 0)
        TextBoxBuscar.MinimumSize = New Size(0, 40)
        TextBoxBuscar.Name = "TextBoxBuscar"
        TextBoxBuscar.Size = New Size(319, 40)
        TextBoxBuscar.TabIndex = 4
        ' 
        ' ButtonBuscar
        ' 
        ButtonBuscar.Dock = DockStyle.Right
        ButtonBuscar.Location = New Point(1229, 0)
        ButtonBuscar.Name = "ButtonBuscar"
        ButtonBuscar.Size = New Size(126, 40)
        ButtonBuscar.TabIndex = 3
        ButtonBuscar.Text = "Buscar"
        ButtonBuscar.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Dock = DockStyle.Left
        Button3.Location = New Point(252, 0)
        Button3.Name = "Button3"
        Button3.Size = New Size(126, 40)
        Button3.TabIndex = 2
        Button3.Text = "Eliminar"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' ButtonModificar
        ' 
        ButtonModificar.Dock = DockStyle.Left
        ButtonModificar.Location = New Point(126, 0)
        ButtonModificar.Name = "ButtonModificar"
        ButtonModificar.Size = New Size(126, 40)
        ButtonModificar.TabIndex = 1
        ButtonModificar.Text = "Modificar"
        ButtonModificar.UseVisualStyleBackColor = True
        ' 
        ' BtnCargarStock
        ' 
        BtnCargarStock.Dock = DockStyle.Left
        BtnCargarStock.Location = New Point(0, 0)
        BtnCargarStock.Margin = New Padding(0)
        BtnCargarStock.Name = "BtnCargarStock"
        BtnCargarStock.Size = New Size(126, 40)
        BtnCargarStock.TabIndex = 0
        BtnCargarStock.Text = "Cargar"
        BtnCargarStock.UseVisualStyleBackColor = True
        ' 
        ' Ventas
        ' 
        Ventas.Controls.Add(Panel3)
        Ventas.Controls.Add(Panel1)
        Ventas.Location = New Point(4, 29)
        Ventas.Name = "Ventas"
        Ventas.Size = New Size(1361, 551)
        Ventas.TabIndex = 2
        Ventas.Text = "Ventas"
        Ventas.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.RosyBrown
        Panel3.Controls.Add(DataGridView2)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 40)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1361, 511)
        Panel3.TabIndex = 4
        ' 
        ' DataGridView2
        ' 
        DataGridView2.AllowDrop = True
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView2.BackgroundColor = Color.White
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Dock = DockStyle.Fill
        DataGridView2.Location = New Point(0, 0)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.ReadOnly = True
        DataGridView2.RowHeadersWidth = 51
        DataGridView2.RowTemplate.Height = 29
        DataGridView2.Size = New Size(1361, 511)
        DataGridView2.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Gainsboro
        Panel1.Controls.Add(ButtonCancelarVenta)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(TextBoxBuscarVenta)
        Panel1.Controls.Add(ButtonBuscarVenta)
        Panel1.Controls.Add(Button5)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1361, 40)
        Panel1.TabIndex = 3
        ' 
        ' ButtonCancelarVenta
        ' 
        ButtonCancelarVenta.Dock = DockStyle.Left
        ButtonCancelarVenta.Location = New Point(252, 0)
        ButtonCancelarVenta.Margin = New Padding(0)
        ButtonCancelarVenta.Name = "ButtonCancelarVenta"
        ButtonCancelarVenta.Size = New Size(135, 40)
        ButtonCancelarVenta.TabIndex = 6
        ButtonCancelarVenta.Text = "Cancelar Venta"
        ButtonCancelarVenta.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Dock = DockStyle.Left
        Button2.Location = New Point(126, 0)
        Button2.Margin = New Padding(0)
        Button2.Name = "Button2"
        Button2.Size = New Size(126, 40)
        Button2.TabIndex = 5
        Button2.Text = "Eliminar Venta"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBoxBuscarVenta
        ' 
        TextBoxBuscarVenta.AutoCompleteMode = AutoCompleteMode.Append
        TextBoxBuscarVenta.Dock = DockStyle.Right
        TextBoxBuscarVenta.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxBuscarVenta.Location = New Point(916, 0)
        TextBoxBuscarVenta.MinimumSize = New Size(0, 40)
        TextBoxBuscarVenta.Name = "TextBoxBuscarVenta"
        TextBoxBuscarVenta.Size = New Size(319, 40)
        TextBoxBuscarVenta.TabIndex = 4
        ' 
        ' ButtonBuscarVenta
        ' 
        ButtonBuscarVenta.Dock = DockStyle.Right
        ButtonBuscarVenta.Location = New Point(1235, 0)
        ButtonBuscarVenta.Name = "ButtonBuscarVenta"
        ButtonBuscarVenta.Size = New Size(126, 40)
        ButtonBuscarVenta.TabIndex = 3
        ButtonBuscarVenta.Text = "Buscar"
        ButtonBuscarVenta.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Dock = DockStyle.Left
        Button5.Location = New Point(0, 0)
        Button5.Margin = New Padding(0)
        Button5.Name = "Button5"
        Button5.Size = New Size(126, 40)
        Button5.TabIndex = 0
        Button5.Text = "Cargar Venta"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' FormCentral
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1369, 584)
        Controls.Add(TabControl1)
        Name = "FormCentral"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        TabControl1.ResumeLayout(False)
        Productos.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        PanelHerramientas.ResumeLayout(False)
        PanelHerramientas.PerformLayout()
        Ventas.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Productos As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PanelHerramientas As Panel
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents BtnCargarStock As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ButtonModificar As Button
    Friend WithEvents ButtonBuscar As Button
    Friend WithEvents TextBoxBuscar As TextBox
    Friend WithEvents Ventas As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBoxBuscarVenta As TextBox
    Friend WithEvents ButtonBuscarVenta As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents ButtonCancelarVenta As Button
End Class
