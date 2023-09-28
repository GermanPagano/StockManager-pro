Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class FormEliminar
    Public formCentralRef As FormCentral
    Private nombreProductoSeleccionado As String = ""

    Private Sub FormEliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llama a la función para cargar los nombres de productos en el ComboBox
        CargarNombresDeProductos()

        ' Verifica si hay una fila seleccionada en el DataGridView1
        If formCentralRef.DataGridView1.SelectedRows.Count > 0 Then
            ' Obtiene el nombre del producto de la fila seleccionada
            nombreProductoSeleccionado = formCentralRef.DataGridView1.SelectedRows(0).Cells("nombre").Value.ToString()

            ' Establece el valor seleccionado en el ComboBox
            ComboBox1.SelectedItem = nombreProductoSeleccionado
        End If
        ' Deshabilitar el botón de maximizar
        Me.MaximizeBox = False

    End Sub


    ' Función para cargar los nombres de los productos disponibles en el ComboBox
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


    ' boton eliminar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtén el nombre del producto seleccionado en el ComboBox
        Dim nombreProducto As String = ComboBox1.SelectedItem.ToString()

        ' Establece la cadena de conexión a la base de datos
        Dim connectionString As String = "Server=127.0.0.1;Database=la_flor;User=root;Password=123456;"

        ' Crea una conexión a la base de datos
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Consulta SQL para actualizar el estado del producto a "disponible = false"
            Dim queryActualizarEstado As String = "UPDATE productos SET disponible = false WHERE nombre = @nombre"

            ' Crea un comando SQL para actualizar el estado
            Using cmdActualizarEstado As New MySqlCommand(queryActualizarEstado, connection)
                cmdActualizarEstado.Parameters.AddWithValue("@nombre", nombreProducto)

                ' Ejecuta la consulta para actualizar el estado del producto
                cmdActualizarEstado.ExecuteNonQuery()
            End Using
        End Using

        ' Llama al método para cargar los datos en el DataGridView en formCentral
        formCentralRef.LoadDataIntoDataGridView()

        ' Cierra el formulario después de actualizar los datos
        Me.Close()
    End Sub








End Class