Imports MySql.Data.MySqlClient

Public Class FormModificarStock
    Friend formCentralRef As FormCentral
    Private nombreProductoSeleccionado As String = ""


    ' Función al cargar el formulario
    Private Sub FormModificarStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llama a la función para cargar los nombres de productos en el ComboBox
        CargarNombresDeProductos()

        ' Verifica si hay una fila seleccionada en el DataGridView1
        If formCentralRef.DataGridView1.SelectedRows.Count > 0 Then
            ' Obtiene el nombre del producto de la fila seleccionada
            nombreProductoSeleccionado = formCentralRef.DataGridView1.SelectedRows(0).Cells("nombre").Value.ToString()

            ' Llama a la función para cargar los datos del producto en los campos
            CargarDatosDelProducto(nombreProductoSeleccionado)
        End If
        ' Deshabilitar el botón de maximizar
        Me.MaximizeBox = False
    End Sub

    ' Función para cargar los nombres de los productos en el ComboBox
    Private Sub CargarNombresDeProductos()
        ' Establece la cadena de conexión a la base de datos
        Dim connectionString As String = "Server=127.0.0.1;Database=la_flor;User=root;Password=123456;"

        ' Crea una conexión a la base de datos
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Define la consulta SQL para obtener los nombres de productos disponibles
            Dim query As String = "SELECT nombre FROM productos WHERE disponible = true"

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                ' Ejecuta la consulta y obtén un lector de datos
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                ' Limpia el ComboBox antes de agregar los nombres
                ComboBox1.Items.Clear()

                ' Agrega los nombres al ComboBox
                While reader.Read()
                    ComboBox1.Items.Add(reader("nombre").ToString())
                End While

                ' Cierra el lector de datos
                reader.Close()
            End Using
        End Using
    End Sub


    ' Evento al seleccionar un nombre en el ComboBox
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Obtén el nombre seleccionado en el ComboBox
        Dim nombreSeleccionado As String = ComboBox1.SelectedItem.ToString()

        ' Llama a la función para cargar los datos del producto en los campos
        CargarDatosDelProducto(nombreSeleccionado)
    End Sub

    ' Función para cargar los datos del producto en los campos
    Private Sub CargarDatosDelProducto(nombreProducto As String)
        ' Establece la cadena de conexión a la base de datos
        Dim connectionString As String = "Server=127.0.0.1;Database=la_flor;User=root;Password=123456;"

        ' Crea una conexión a la base de datos
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Define la consulta SQL para obtener los datos del producto
            Dim query As String = "SELECT nombre, descripcion, categoria, precio, stock FROM productos WHERE nombre = @nombre"

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                ' Agrega el parámetro para el nombre del producto
                cmd.Parameters.AddWithValue("@nombre", nombreProducto)

                ' Ejecuta la consulta y obtén un lector de datos
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                ' Verifica si se encontraron datos y carga los campos
                If reader.Read() Then
                    TextBox1.Text = reader("nombre").ToString()
                    TextBox2.Text = reader("descripcion").ToString()
                    TextBox3.Text = reader("categoria").ToString()
                    TextBox4.Text = reader("precio").ToString()
                    TextBox5.Text = reader("stock").ToString()
                End If

                ' Cierra el lector de datos
                reader.Close()
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtener los nuevos valores ingresados por el usuario desde los TextBox
        Dim nuevoNombre As String = TextBox1.Text
        Dim nuevaDescripcion As String = TextBox2.Text
        Dim nuevaCategoria As String = TextBox3.Text
        Dim nuevoPrecio As Decimal = Decimal.Parse(TextBox4.Text)
        Dim nuevoStock As Integer = Integer.Parse(TextBox5.Text)

        ' Llama a una función o método para realizar la actualización en la base de datos
        ActualizarDatosEnBaseDeDatos(nuevoNombre, nuevaDescripcion, nuevaCategoria, nuevoPrecio, nuevoStock)

        ' Cierra el formulario después de actualizar los datos
        Me.Close()
    End Sub


    ' funcion para actualizar la base de datos y el grid view

    Private Sub ActualizarDatosEnBaseDeDatos(nuevoNombre As String, nuevaDescripcion As String, nuevaCategoria As String, nuevoPrecio As Decimal, nuevoStock As Integer)
        ' Establece la cadena de conexión a la base de datos
        Dim connectionString As String = "Server=127.0.0.1;Database=la_flor;User=root;Password=123456;"

        ' Crea una conexión a la base de datos
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Define la consulta SQL para actualizar los datos en la base de datos
            Dim query As String = ""

            ' Verifica si nombreProductoSeleccionado no es una cadena vacía (se seleccionó desde DataGridView)
            If Not String.IsNullOrEmpty(nombreProductoSeleccionado) Then
                query = "UPDATE productos SET nombre = @nuevoNombre, descripcion = @nuevaDescripcion, categoria = @nuevaCategoria, precio = @nuevoPrecio, stock = @nuevoStock WHERE nombre = @nombreAnterior"
            Else
                ' Si es una cadena vacía, significa que se seleccionó desde ComboBox
                query = "UPDATE productos SET descripcion = @nuevaDescripcion, categoria = @nuevaCategoria, precio = @nuevoPrecio, stock = @nuevoStock WHERE nombre = @nuevoNombre"
            End If

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                ' Agrega los parámetros con los nuevos valores
                cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre)
                cmd.Parameters.AddWithValue("@nuevaDescripcion", nuevaDescripcion)
                cmd.Parameters.AddWithValue("@nuevaCategoria", nuevaCategoria)
                cmd.Parameters.AddWithValue("@nuevoPrecio", nuevoPrecio)
                cmd.Parameters.AddWithValue("@nuevoStock", nuevoStock)

                ' Verifica si nombreProductoSeleccionado no es una cadena vacía (se seleccionó desde DataGridView)
                If Not String.IsNullOrEmpty(nombreProductoSeleccionado) Then
                    ' Agrega un parámetro adicional para identificar el producto que se va a actualizar (por nombre)
                    cmd.Parameters.AddWithValue("@nombreAnterior", nombreProductoSeleccionado)
                Else
                    ' Si es una cadena vacía, significa que se seleccionó desde ComboBox
                    cmd.Parameters.AddWithValue("@nombreAnterior", nuevoNombre)
                End If

                ' Ejecuta la consulta de actualización
                cmd.ExecuteNonQuery()
            End Using

            ' Llama al método para cargar los datos en el DataGridView en formCentral
            formCentralRef.LoadDataIntoDataGridView()
        End Using
    End Sub





End Class

