Imports MySql.Data.MySqlClient

Public Class Login

    ' Declaración de la conexión a la base de datos
    Private connection As MySqlConnection
    ' función al cargar el formulario
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' estilos para el formulario 
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 1
        Button1.FlatAppearance.BorderColor = Color.White
        Button1.BackColor = Color.Transparent

        ' Inicializa la conexión a la base de datos
        InitializeDatabaseConnection()
    End Sub

    Private Sub InitializeDatabaseConnection()
        ' Configura la cadena de conexión a la base de datos MySQL
        Dim connectionString As String = "Server=127.0.0.1;Database=la_flor;User=root;Password=123456;"

        ' Crea una instancia de la conexión a la base de datos
        connection = New MySqlConnection(connectionString)
    End Sub

    ' funcion para conectar a la base de datos
    Private Sub ConectarBaseDeDatos()
        Try
            ' Abre la conexión a la base de datos (si no está abierta)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la conexión
            MessageBox.Show("Error al conectar a la base de datos: " & ex.Message)
        End Try
    End Sub

    ' funcion para desconectarse de la base de datos
    Private Sub DesconectarBaseDeDatos()
        ' Cierra la conexión a la base de datos (si está abierta)
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    ' funcion para autenticar el usuario
    Private Function VerificarCredenciales(username As String, password As String) As Boolean
        ' Consulta SQL para verificar las credenciales
        Dim query As String = "SELECT COUNT(*) FROM usuarios WHERE username = @username AND password = @password"

        Try
            ' Abre la conexión a la base de datos
            ConectarBaseDeDatos()

            ' Crea un comando SQL
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)

                ' Ejecuta la consulta y obtiene el resultado
                Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                ' Si el resultado es 1, significa que las credenciales son válidas
                Return result = 1
            End Using
        Catch ex As Exception
            ' Maneja cualquier error que ocurra durante la verificación
            MessageBox.Show("Error al verificar las credenciales: " & ex.Message)
            Return False
        Finally
            ' Cierra la conexión a la base de datos
            DesconectarBaseDeDatos()
        End Try
    End Function


    ' funcion del boton Ingresar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtiene los valores ingresados por el usuario
        Dim username As String = TextBoxUser.Text
        Dim password As String = TextBoxPWD.Text

        ' borro los valores de los input
        TextBoxUser.Clear()
        TextBoxPWD.Clear()


        ' Verifica las credenciales le paso como argumento los valores obtenidos
        If VerificarCredenciales(username, password) Then
            ' Las credenciales son válidas, puedes permitir el acceso al usuario

            ' Abre el formulario FormCentral
            Dim formCentral As New FormCentral()
            formCentral.Show()

            ' Cierra el formulario de inicio de sesión
            Me.Hide()

        Else
            ' Las credenciales son incorrectas, muestra un mensaje de error
            MessageBox.Show("Usuario o contraseña incorrectos")
        End If
    End Sub


    ' evento keydown de tecla enter para llamar a la funcion ingresar( boton1 ) 
    Private Sub TextBoxPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Presionaron Enter, activa el evento del botón "Ingresar"
            Button1.PerformClick()
        End If
    End Sub

End Class


