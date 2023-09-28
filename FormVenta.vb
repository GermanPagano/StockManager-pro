Imports MySql.Data.MySqlClient

Public Class FormVenta
    ' Declara una variable para almacenar la referencia al formulario FormCentral
    Public formCentralRef As FormCentral
    ' Declaración de la conexión a la base de datos
    Private connection As MySqlConnection


    ' Cadena de conexión a la base de datos
    Private connectionString As String = "Server=127.0.0.1;Database=la_flor;User=root;Password=123456;"

    ' Función que se ejecuta al cargar el formulario
    Private Sub FormVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializa la conexión a la base de datos
        connection = New MySqlConnection(connectionString)

        ' Carga los productos disponibles en el ComboBox
        LoadProductosComboBox()

        ' Establece la fecha predeterminada en el DateTimePicker al momento actual
        DateTimePicker1.Value = DateTime.Now
        ' Establece la propiedad KeyPreview en True para habilitar el manejo de eventos de teclado en el formulario
        Me.KeyPreview = True
        ' Deshabilitar el botón de maximizar
        Me.MaximizeBox = False
    End Sub


    ' Función para cargar los productos disponibles en el ComboBox
    Private Sub LoadProductosComboBox()
        Try
            ' Abre la conexión a la base de datos
            connection.Open()

            ' Define la consulta SQL para obtener los nombres de productos disponibles
            Dim query As String = "SELECT nombre FROM productos WHERE disponible = true"

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                ' Ejecuta la consulta y obtén un lector de datos
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                ' Limpia el ComboBox antes de agregar los nombres
                ComboBox1.Items.Clear()

                ' Agrega los nombres de productos al ComboBox
                While reader.Read()
                    ComboBox1.Items.Add(reader("nombre").ToString())
                End While

                ' Cierra el lector de datos
                reader.Close()
            End Using
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la carga de datos
            MessageBox.Show("Error al cargar los productos: " & ex.Message)
        Finally
            ' Cierra la conexión a la base de datos
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub




    ' Manejador de evento para el botón "Registrar Venta"
    Private Sub ButtonRegistrarVenta_Click(sender As Object, e As EventArgs) Handles ButtonRegistrarVenta.Click
        Try
            ' Obtén los valores ingresados por el usuario
            Dim productoSeleccionado As String = ComboBox1.SelectedItem.ToString()
            Dim cantidadVenta As Integer = Integer.Parse(TextBoxCantidad.Text)

            ' Obtén el id_producto del producto seleccionado
            Dim idProducto As Integer = ObtenerIdProducto(productoSeleccionado)

            ' Obtén el precio unitario del producto seleccionado
            Dim precioUnitario As Decimal = ObtenerPrecioUnitario(connection, productoSeleccionado)

            ' Obtiene la fecha seleccionada por el usuario en el DateTimePicker
            Dim fechaVenta As DateTime = DateTimePicker1.Value

            ' Obtén el stock actual del producto seleccionado
            Dim stockActual As Integer = ObtenerStockActual(idProducto)

            ' Calcular el total de la venta
            Dim totalVenta As Decimal = precioUnitario * cantidadVenta

            ' Verifica si hay suficiente stock para la venta
            If cantidadVenta <= 0 Then
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf cantidadVenta > stockActual Then
                MessageBox.Show("No hay suficiente stock disponible para realizar esta venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                ' Llama a la función para registrar la venta en la base de datos y actualizar el stock
                RegistrarVenta(idProducto, cantidadVenta, totalVenta, precioUnitario, fechaVenta)

                ' Llama a la función para recargar los datos de productos en el formulario FormCentral
                formCentralRef.LoadDataIntoDataGridView()

                ' Una vez que la venta se haya registrado, puedes cerrar este formulario
                Me.Close()

                ' Llama a la función para recargar los datos de ventas en el formulario FormCentral
                formCentralRef.CargarDatosVentas()
            End If
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante el registro de la venta
            MessageBox.Show("Error al registrar la venta: " & ex.Message)
        End Try
    End Sub

    ' Función para obtener el stock actual del producto seleccionado
    Private Function ObtenerStockActual(idProducto As Integer) As Integer
        Dim stockActual As Integer = 0

        ' Define la consulta SQL para obtener el stock actual
        Dim query As String = "SELECT stock FROM productos WHERE id_producto = @id_producto"

        Try
            ' Abre la conexión a la base de datos
            connection.Open()

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                ' Agrega el parámetro para el id_producto
                cmd.Parameters.AddWithValue("@id_producto", idProducto)

                ' Ejecuta la consulta y obtén el resultado
                Dim result As Object = cmd.ExecuteScalar()

                ' Verifica si se encontró un resultado válido
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    stockActual = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la consulta
            MessageBox.Show("Error al obtener el stock actual: " & ex.Message)
        Finally
            ' Cierra la conexión a la base de datos
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try

        Return stockActual
    End Function





    ' Función para obtener el id_producto del producto seleccionado
    Private Function ObtenerIdProducto(nombreProducto As String) As Integer
        Dim idProducto As Integer = -1 ' Valor predeterminado en caso de que no se encuentre

        ' Define la consulta SQL para obtener el id_producto
        Dim query As String = "SELECT id_producto FROM productos WHERE nombre = @nombre"

        Try
            ' Abre la conexión a la base de datos
            connection.Open()

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                ' Agrega el parámetro para el nombre del producto
                cmd.Parameters.AddWithValue("@nombre", nombreProducto)

                ' Ejecuta la consulta y obtén el resultado
                Dim result As Object = cmd.ExecuteScalar()

                ' Verifica si se encontró un resultado válido
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    idProducto = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la consulta
            MessageBox.Show("Error al obtener el id del producto: " & ex.Message)
        Finally
            ' Cierra la conexión a la base de datos
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try

        Return idProducto
    End Function

    ' Función para obtener el precio unitario del producto seleccionado
    Private Function ObtenerPrecioUnitario(connection As MySqlConnection, nombreProducto As String) As Decimal
        Dim precioUnitario As Decimal = 0

        ' Define la consulta SQL para obtener el precio unitario
        Dim query As String = "SELECT precio FROM productos WHERE nombre = @nombre"

        Try
            ' Abre la conexión a la base de datos
            connection.Open()

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                ' Agrega el parámetro para el nombre del producto
                cmd.Parameters.AddWithValue("@nombre", nombreProducto)

                ' Ejecuta la consulta y obtén el resultado
                Dim result As Object = cmd.ExecuteScalar()

                ' Verifica si se encontró un resultado válido
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    precioUnitario = Convert.ToDecimal(result)
                End If
            End Using
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la consulta
            MessageBox.Show("Error al obtener el precio unitario: " & ex.Message)
        Finally
            ' Cierra la conexión a la base de datos
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try

        Return precioUnitario
    End Function



    ' Función para registrar la venta en la base de datos y actualizar el stock
    Private Sub RegistrarVenta(idProducto As Integer, cantidadVenta As Integer, totalVenta As Decimal, precioUnitario As Decimal, fechaVenta As DateTime)
        ' Define la consulta SQL para registrar la venta en la tabla "ventas"
        Dim queryVenta As String = "INSERT INTO ventas (fecha_venta, total_venta, id_producto, cantidad, precio_unitario) VALUES (@fecha_venta, @total_venta, @id_producto, @cantidad, @precio_unitario)"

        ' Define la consulta SQL para actualizar el stock del producto
        Dim queryStock As String = "UPDATE productos SET stock = stock - @cantidad WHERE id_producto = @id_producto"

        Try
            ' Abre la conexión a la base de datos
            connection.Open()

            ' Comienza una transacción
            Dim transaction As MySqlTransaction = connection.BeginTransaction()

            Try
                ' Crea un comando SQL para la inserción de la venta
                Using cmdVenta As New MySqlCommand(queryVenta, connection, transaction)
                    ' Agrega los parámetros para la venta
                    cmdVenta.Parameters.AddWithValue("@fecha_venta", fechaVenta)
                    cmdVenta.Parameters.AddWithValue("@total_venta", totalVenta)
                    cmdVenta.Parameters.AddWithValue("@id_producto", idProducto)
                    cmdVenta.Parameters.AddWithValue("@cantidad", cantidadVenta)
                    cmdVenta.Parameters.AddWithValue("@precio_unitario", precioUnitario)

                    ' Ejecuta la inserción de la venta
                    cmdVenta.ExecuteNonQuery()
                End Using

                ' Crea un comando SQL para la actualización del stock
                Using cmdStock As New MySqlCommand(queryStock, connection, transaction)
                    ' Agrega los parámetros para la actualización del stock
                    cmdStock.Parameters.AddWithValue("@cantidad", cantidadVenta)
                    cmdStock.Parameters.AddWithValue("@id_producto", idProducto)

                    ' Ejecuta la actualización del stock
                    cmdStock.ExecuteNonQuery()
                End Using

                ' Confirma la transacción
                transaction.Commit()

            Catch ex As Exception
                ' En caso de error, revierte la transacción
                transaction.Rollback()
                Throw New Exception("Error al registrar la venta: " & ex.Message)
            End Try
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la conexión
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message)
        Finally
            ' Cierra la conexión a la base de datos
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub


    ' funcion para permitir usar enter
    Private Sub FormVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ' Verifica si se presionó la tecla "Enter" (cuyo código es 13)
        If e.KeyChar = ChrW(13) Then
            ' Verifica si la cantidad es mayor que 0
            If Integer.TryParse(TextBoxCantidad.Text, Nothing) AndAlso Integer.Parse(TextBoxCantidad.Text) > 0 Then
                ' Llama al botón de registrar venta
                ButtonRegistrarVenta.PerformClick()
            Else
                ' Muestra un mensaje indicando que se debe ingresar una cantidad válida
                MessageBox.Show("Indique la cantidad que vendió.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub





End Class


