Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports System.IO



Public Class FormCentral

    ' Declaración de la conexión a la base de datos
    Private connection As MySqlConnection


    ' funcion que se ejecuta al cargar el form 
    Private Sub FormCentral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializa la conexión a la base de datos
        InitializeDatabaseConnection()

        ' Carga los datos de la tabla "productos" en el DataGridView
        LoadDataIntoDataGridView()

    End Sub

    ' funcion que inicializa la conexion a la db
    Private Sub InitializeDatabaseConnection()
        ' Configura la cadena de conexión a la base de datos MySQL
        Dim connectionString As String = "Server=127.0.0.1;Database=la_flor;User=root;Password=123456;"

        ' Crea una instancia de la conexión a la base de datos
        connection = New MySqlConnection(connectionString)
    End Sub



    ' TAB PRODUCTOS

    ' funcion que lee los datos de la tabla Productos de mi DB 
    Public Sub LoadDataIntoDataGridView()
        Try
            ' Abre la conexión a la base de datos (si no está abierta)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' Consulta SQL para seleccionar los registros de la tabla "productos" donde "disponible" sea true
            Dim query As String = "SELECT * FROM productos WHERE disponible = true"

            ' Crea un adaptador de datos y un conjunto de datos para almacenar los resultados
            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim dataSet As New DataSet()

            ' Llena el conjunto de datos con los resultados de la consulta
            adapter.Fill(dataSet, "productos")

            ' Asigna el conjunto de datos como origen de datos del DataGridView
            DataGridView1.DataSource = dataSet.Tables("productos")
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la carga de datos
            MessageBox.Show("Error al cargar los datos: " & ex.Message)
        Finally
            ' Cierra la conexión a la base de datos
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    ' funcion para identificar productos con bajo stock


    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        ' Verifica si la celda actual es de la columna "stock" (reemplaza "NombreDeTuColumnaStock" con el nombre real de la columna)
        If e.ColumnIndex = DataGridView1.Columns("stock").Index AndAlso e.RowIndex >= 0 Then
            ' Obtiene el valor de la celda actual
            Dim cellValue As Integer = CInt(e.Value)

            ' Obtiene el valor de la columna "stockminimo" para la misma fila
            Dim stockMinimo As Integer = CInt(DataGridView1.Rows(e.RowIndex).Cells("stock_minimo").Value)

            ' Compara el valor del stock con el stock mínimo
            If cellValue <= stockMinimo Then
                ' Si el stock es igual o menor al mínimo, establece el formato de fuente en rojo
                e.CellStyle.ForeColor = Color.Red
            Else
                ' Si el stock es mayor que el mínimo, restablece el formato de fuente a su valor predeterminado
                e.CellStyle.ForeColor = DataGridView1.DefaultCellStyle.ForeColor
            End If
        End If
    End Sub








    ' Boton CARGAR STOCK
    Private Sub BtnCargarStock_Click(sender As Object, e As EventArgs) Handles BtnCargarStock.Click
        ' Crea una instancia del formulario FormCargarStock
        Dim formCargarStock As New FormCargarStock()

        ' Establece la referencia al formulario FormCentral
        formCargarStock.formCentralRef = Me

        ' Muestra el formulario
        formCargarStock.Show()
    End Sub


    ' Boton MODIFICAR STOCK
    Private Sub ButtonModificar_Click(sender As Object, e As EventArgs) Handles ButtonModificar.Click
        ' Crea una instancia del formulario FormCargarStock
        Dim formModificarStock As New FormModificarStock()

        ' Establece la referencia al formulario FormCentral
        formModificarStock.formCentralRef = Me

        ' Muestra el formulario
        formModificarStock.Show()
    End Sub


    ' Boton ELIMINAR STOCK
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Crea una instancia del formulario FormEliminar
        Dim formEliminarStock As New FormEliminar()

        ' Establece la referencia al formulario FormCentral
        formEliminarStock.formCentralRef = Me

        ' Muestra el formulario
        formEliminarStock.Show()
    End Sub


    ' Función para buscar productos y mostrar resultados en el DataGridView
    Private Sub SearchAndDisplayResults(criterio As String)
        Try
            ' Abre la conexión a la base de datos (si no está abierta)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' Intenta convertir el criterio de búsqueda en un número entero
            Dim productoID As Integer
            Dim isNumeric As Boolean = Integer.TryParse(criterio, productoID)

            ' Construye la consulta SQL para buscar productos por ID o criterio en varios campos
            Dim query As String = "SELECT * FROM productos WHERE (id_producto = @productoID OR LOWER(nombre) LIKE @criterio OR LOWER(categoria) LIKE @criterio OR LOWER(disponible) LIKE @criterio)"

            ' Agrega el carácter '%' al inicio y al final del criterio para buscar coincidencias parciales
            criterio = $"%{criterio.ToLower()}%"

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                ' Agrega el parámetro para el criterio de búsqueda
                cmd.Parameters.AddWithValue("@criterio", criterio.ToLower())

                ' Agrega el parámetro para el ID de producto (si es un número válido)
                If isNumeric Then
                    cmd.Parameters.AddWithValue("@productoID", productoID)
                Else
                    ' Si el criterio no es un número válido, asigna -1 como valor para evitar la búsqueda por ID
                    cmd.Parameters.AddWithValue("@productoID", -1)
                End If

                ' Crea un adaptador de datos y un conjunto de datos para almacenar los resultados
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dataSet As New DataSet()

                ' Llena el conjunto de datos con los resultados de la consulta
                adapter.Fill(dataSet, "productos")

                ' Asigna el conjunto de datos como origen de datos del DataGridView
                DataGridView1.DataSource = dataSet.Tables("productos")

                ' Si no se encontraron coincidencias, muestra un mensaje
                If DataGridView1.RowCount = 0 Then
                    MessageBox.Show("No se encontraron coincidencias en el stock.")
                End If
            End Using
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la búsqueda
            MessageBox.Show("Error al buscar productos: " & ex.Message)
        Finally
            ' Cierra la conexión a la base de datos
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    ' Manejador de evento para el botón de búsqueda
    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        ' Obtén el criterio de búsqueda ingresado por el usuario
        Dim criterio As String = TextBoxBuscar.Text.Trim()

        ' Verifica si se ha ingresado un criterio de búsqueda
        If Not String.IsNullOrEmpty(criterio) Then
            ' Realiza la búsqueda en la base de datos en todos los campos relevantes
            SearchAndDisplayResults(criterio)

            ' Limpia el contenido del TextBox de búsqueda
            TextBoxBuscar.Text = ""
        Else
            ' Si el campo de búsqueda está vacío, carga todos los productos nuevamente
            LoadDataIntoDataGridView()
        End If
    End Sub



    ' Maneja el evento KeyDown del TextBox de búsqueda
    Private Sub TextBoxBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxBuscar.KeyDown
        ' Verifica si se presionó la tecla Enter (código de tecla 13)
        If e.KeyCode = Keys.Enter Then
            ' Evita que se emita el sonido de alerta cuando se presiona Enter
            e.SuppressKeyPress = True

            ' Obtén el criterio de búsqueda ingresado por el usuario
            Dim criterio As String = TextBoxBuscar.Text.Trim()

            ' Verifica si se ha ingresado un criterio de búsqueda
            If Not String.IsNullOrEmpty(criterio) Then
                ' Realiza la búsqueda en la base de datos en todos los campos relevantes
                SearchAndDisplayResults(criterio)

                ' Limpia el contenido del TextBox de búsqueda
                TextBoxBuscar.Text = ""
            Else
                ' Si el campo de búsqueda está vacío, carga todos los productos nuevamente
                LoadDataIntoDataGridView()
            End If
        End If
    End Sub


    '----------------------------------------------------------------------------------------

    ' TAB VENTAS
    Public Sub CargarDatosVentas()
        Try

            ' Define la consulta SQL para obtener los datos de ventas
            Dim query As String = "SELECT * FROM ventas"

            ' Crea un adaptador de datos
            Dim adapter As New MySqlDataAdapter(query, connection)

            ' Crea un DataSet para almacenar los datos
            Dim dataset As New DataSet()

            ' Llena el DataSet con los datos de la consulta
            adapter.Fill(dataset, "Ventas")

            ' Enlaza el DataGridView con los datos del DataSet
            DataGridView2.DataSource = dataset.Tables("Ventas")
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la carga de datos
            MessageBox.Show("Error al cargar los datos de ventas: " & ex.Message)
        Finally

        End Try
    End Sub

    'funcion que carga los datos de las ventas en el momento que se pone a la vista
    Private Sub TabPageVentas_Enter(sender As Object, e As EventArgs) Handles Ventas.Enter
        ' Llama a la función para cargar los datos de ventas cuando se selecciona la pestaña de Ventas
        CargarDatosVentas()
    End Sub


    ' boton para cargar una nueva venta
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Crea una instancia del formulario FormVenta
        Dim formVenta As New FormVenta()

        ' Establece la referencia al formulario FormCentral
        formVenta.formCentralRef = Me

        ' Muestra el formulario de venta
        formVenta.Show()
    End Sub


    ' boton eliminar venta
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Verifica si hay alguna fila seleccionada en el DataGridView de ventas
        If DataGridView2.SelectedRows.Count > 0 Then
            ' Obtiene el ID de venta seleccionado (asumiendo que la primera columna contiene el ID)
            Dim ventaId As Integer = CInt(DataGridView2.SelectedRows(0).Cells(0).Value)

            ' Pregunta al usuario para confirmar la eliminación
            Dim confirmResult As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta venta?", "Confirmar eliminación", MessageBoxButtons.YesNo)

            ' Si el usuario confirma, procede a eliminar la venta
            If confirmResult = DialogResult.Yes Then
                Try
                    ' Abre la conexión a la base de datos (si no está abierta)
                    If connection.State = ConnectionState.Closed Then
                        connection.Open()
                    End If

                    ' Define la consulta SQL para eliminar la venta por ID
                    Dim queryDelete As String = "DELETE FROM ventas WHERE id_venta = @ventaId"

                    ' Crea un comando SQL
                    Using cmdDelete As New MySqlCommand(queryDelete, connection)
                        ' Agrega el parámetro para el ID de venta
                        cmdDelete.Parameters.AddWithValue("@ventaId", ventaId)

                        ' Ejecuta la consulta para eliminar la venta
                        cmdDelete.ExecuteNonQuery()
                    End Using

                    ' Restablece el valor autoincremental del ID de venta
                    Dim queryResetAutoIncrement As String = $"ALTER TABLE ventas AUTO_INCREMENT = {ventaId}"

                    ' Crea un comando SQL para restablecer el valor autoincremental
                    Using cmdResetAutoIncrement As New MySqlCommand(queryResetAutoIncrement, connection)
                        ' Ejecuta la consulta para restablecer el valor autoincremental
                        cmdResetAutoIncrement.ExecuteNonQuery()
                    End Using

                    ' Actualiza el DataGridView de ventas para reflejar los cambios
                    CargarDatosVentas()

                Catch ex As Exception
                    ' Maneja cualquier error que ocurra durante la eliminación
                    MessageBox.Show("Error al eliminar la venta: " & ex.Message)
                Finally
                    ' Cierra la conexión a la base de datos
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End If
        Else
            ' Si no hay filas seleccionadas, muestra un mensaje de advertencia
            MessageBox.Show("Seleccione una venta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    ' Botón de búsqueda de ventas
    Private Sub ButtonBuscarVenta_Click(sender As Object, e As EventArgs) Handles ButtonBuscarVenta.Click
        ' Obtén el término de búsqueda ingresado por el usuario
        Dim searchTerm As String = TextBoxBuscarVenta.Text.Trim()

        ' Verifica si el término de búsqueda está vacío
        If String.IsNullOrEmpty(searchTerm) Then
            ' Si el término está vacío, carga todas las ventas sin realizar la búsqueda
            CargarDatosVentas()
        Else
            ' Intenta convertir el término de búsqueda en un número de venta o número de producto válido
            Dim ventaID As Integer
            If Integer.TryParse(searchTerm, ventaID) Then
                ' Si es un número válido, busca ventas por ID de venta o ID de producto
                BuscarVentasPorIDVenta(ventaID)
            Else
                ' Si no es un número válido, muestra un mensaje de error
                MessageBox.Show("Ingrese un número de venta o número de producto válido.")
            End If
        End If
    End Sub


    ' Función para buscar ventas por ID de venta o ID de producto
    Private Sub BuscarVentasPorIDVenta(ventaID As Integer)
        Try
            ' Abre la conexión a la base de datos
            connection.Open()

            ' Define la consulta SQL para buscar ventas por ID de venta o ID de producto
            Dim query As String = "SELECT * FROM ventas WHERE id_venta = @ventaID OR id_producto = @ventaID"

            ' Crea un adaptador de datos para llenar el DataGridView con los resultados de la consulta
            Dim adapter As New MySqlDataAdapter(query, connection)

            ' Crea un objeto DataTable para almacenar los resultados de la consulta
            Dim dt As New DataTable()

            ' Agrega el parámetro para el ID de venta o ID de producto
            adapter.SelectCommand.Parameters.AddWithValue("@ventaID", ventaID)

            ' Llena el DataTable con los resultados de la consulta
            adapter.Fill(dt)

            ' Enlaza el DataGridView con el DataTable para mostrar los resultados
            DataGridView2.DataSource = dt
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la búsqueda
            MessageBox.Show("Error al buscar ventas por número de venta o número de producto: " & ex.Message)
        Finally
            ' Cierra la conexión a la base de datos
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub


    ' Manejador de evento KeyDown para el TextBoxBuscarVenta
    Private Sub TextBoxBuscarVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxBuscarVenta.KeyDown
        ' Verifica si se presionó la tecla Enter
        If e.KeyCode = Keys.Enter Then
            ' Realiza la búsqueda al presionar Enter
            ButtonBuscarVenta.PerformClick()

            ' Limpia el contenido del TextBox después de la búsqueda
            TextBoxBuscarVenta.Clear()

            ' Evita que se procese el carácter Enter adicionalmente
            e.SuppressKeyPress = True
        End If
    End Sub


    ' boton cancelar venta y reestablecer stock
    Private Sub ButtonCancelarVenta_Click(sender As Object, e As EventArgs) Handles ButtonCancelarVenta.Click
        ' Verifica si hay alguna fila seleccionada en el DataGridView de ventas
        If DataGridView2.SelectedRows.Count > 0 Then
            ' Obtiene el valor de la celda de ID de venta seleccionada (asumiendo que la primera columna contiene el ID)
            Dim ventaIdCellValue As Object = DataGridView2.SelectedRows(0).Cells(0).Value

            ' Verifica si la celda contiene un valor no nulo
            If ventaIdCellValue IsNot DBNull.Value Then
                ' Convierte el valor de la celda a Integer
                Dim ventaId As Integer = CInt(ventaIdCellValue)

                ' Pregunta al usuario para confirmar la cancelación de la venta
                Dim confirmResult As DialogResult = MessageBox.Show("¿Estás seguro de que deseas cancelar esta venta?", "Confirmar cancelación", MessageBoxButtons.YesNo)

                ' Si el usuario confirma, procede a cancelar la venta
                If confirmResult = DialogResult.Yes Then
                    Try
                        ' Abre la conexión a la base de datos (si no está abierta)
                        If connection.State = ConnectionState.Closed Then
                            connection.Open()
                        End If

                        ' Obtiene la cantidad y el ID de producto de la venta a cancelar
                        Dim cantidadVenta As Integer
                        Dim productoId As Integer

                        ' Define la consulta SQL para obtener la cantidad y el ID de producto
                        Dim queryInfo As String = "SELECT cantidad, id_producto FROM ventas WHERE id_venta = @ventaId"

                        ' Crea un comando SQL para obtener la información de la venta a cancelar
                        Using cmdInfo As New MySqlCommand(queryInfo, connection)
                            cmdInfo.Parameters.AddWithValue("@ventaId", ventaId)
                            Dim reader As MySqlDataReader = cmdInfo.ExecuteReader()
                            If reader.Read() Then
                                cantidadVenta = CInt(reader("cantidad"))
                                productoId = CInt(reader("id_producto"))
                            End If
                            reader.Close()
                        End Using

                        ' Elimina la venta de la tabla de ventas
                        Dim deleteQuery As String = "DELETE FROM ventas WHERE id_venta = @ventaId"
                        Using cmdDelete As New MySqlCommand(deleteQuery, connection)
                            cmdDelete.Parameters.AddWithValue("@ventaId", ventaId)
                            cmdDelete.ExecuteNonQuery()
                        End Using

                        ' Restablece el valor autoincremental del ID de venta usando el valor de ventaId
                        Dim resetAutoIncrementQuery As String = $"ALTER TABLE ventas AUTO_INCREMENT = {ventaId}"
                        Using cmdResetAutoIncrement As New MySqlCommand(resetAutoIncrementQuery, connection)
                            cmdResetAutoIncrement.ExecuteNonQuery()
                        End Using

                        ' Restaura la cantidad de productos en la tabla de productos
                        Dim updateQuery As String = "UPDATE productos SET stock = stock + @cantidadVenta WHERE id_producto = @productoId"
                        Using cmdUpdate As New MySqlCommand(updateQuery, connection)
                            cmdUpdate.Parameters.AddWithValue("@cantidadVenta", cantidadVenta)
                            cmdUpdate.Parameters.AddWithValue("@productoId", productoId)
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        ' Actualiza el DataGridView de ventas para reflejar los cambios
                        CargarDatosVentas()
                        LoadDataIntoDataGridView()

                        ' Muestra un mensaje de éxito
                        MessageBox.Show("Venta cancelada correctamente, se reintegro al stock")
                    Catch ex As Exception
                        ' Maneja cualquier error que ocurra durante la cancelación de la venta
                        MessageBox.Show("Error al cancelar la venta: " & ex.Message)
                    Finally
                        ' Cierra la conexión a la base de datos
                        If connection.State = ConnectionState.Open Then
                            connection.Close()
                        End If
                    End Try
                End If
            Else
                ' Si la celda contiene un valor nulo, muestra un mensaje de advertencia
                MessageBox.Show("La venta seleccionada no tiene un ID válido para cancelar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ' Si no hay filas seleccionadas, muestra un mensaje de advertencia
            MessageBox.Show("Seleccione una venta para cancelar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub




End Class
