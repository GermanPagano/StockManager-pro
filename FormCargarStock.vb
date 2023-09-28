Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports MySql.Data.MySqlClient

Public Class FormCargarStock

    ' referencia al formulario principal
    Public formCentralRef As FormCentral

    Private Sub FormCargarStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Deshabilitar el botón de maximizar
        Me.MaximizeBox = False
    End Sub

    ' evento de click del boton para cargar stock
    Private Sub ButtonConfirmarStock_Click(sender As Object, e As EventArgs) Handles ButtonConfirmarStock.Click
        ' Obtener los valores de los TextBox
        Dim nombre As String = TextBoxNombre.Text
        Dim descripcion As String = TextBoxDescripcion.Text
        Dim categoria As String = TextBoxCategoria.Text
        Dim precio As Decimal = Decimal.Parse(TextBoxPrecio.Text) ' Convertir a decimal
        Dim stock As Integer = Integer.Parse(TextBoxStock.Text) ' Convertir a entero
        Dim stockMIN As Integer = Integer.Parse(TextBoxStockMinimo.Text) ' Convertir a entero

        ' Llamar a una función o método para insertar los datos en la base de datos
        InsertarDatosEnBaseDeDatos(nombre, descripcion, categoria, precio, stock, stockMIN)

        ' Cerrar el formulario después de agregar los datos
        Me.Close()
    End Sub

    ' funcion para insertar los datos de los input en la DB
    Private Sub InsertarDatosEnBaseDeDatos(nombre As String, descripcion As String, categoria As String, precio As Decimal, stock As Integer, stockMIN As Integer)
        Dim connectionString As String = "Server=127.0.0.1;Database=la_flor;User=root;Password=123456;"

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Verificar si el producto ya existe en la base de datos
            Dim existeProducto As Boolean = VerificarExistenciaProducto(nombre, connection)

            If existeProducto Then
                MessageBox.Show("El producto ya existe en la base de datos.", "Producto Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ' El producto no existe, procede con la inserción
                Dim query As String = "INSERT INTO productos (nombre, descripcion, categoria, precio, stock, stock_minimo) VALUES (@nombre, @descripcion, @categoria, @precio, @stock, @stock_minimo)"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)
                    cmd.Parameters.AddWithValue("@categoria", categoria)
                    cmd.Parameters.AddWithValue("@precio", precio)
                    cmd.Parameters.AddWithValue("@stock", stock)
                    cmd.Parameters.AddWithValue("@stock_minimo", stockMIN)

                    cmd.ExecuteNonQuery()
                End Using

                ' Llama al método para cargar los datos en el DataGridView en formCentral
                formCentralRef.LoadDataIntoDataGridView()
            End If
        End Using
    End Sub

    ' funcion para evitar que se ingresen dos productos con el mismo nombre
    Private Function VerificarExistenciaProducto(nombre As String, connection As MySqlConnection) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM productos WHERE nombre = @nombre"

        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@nombre", nombre)

            Dim resultado As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            Return resultado > 0
        End Using
    End Function

    ' Evento KeyDown de tecla Enter para llamar a la función ingresar (botón1)
    Private Sub TextBoxStock_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxStockMinimo.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Presionaron Enter, activa el evento del botón "Ingresar"
            ButtonConfirmarStock.PerformClick()
        End If
    End Sub


End Class
