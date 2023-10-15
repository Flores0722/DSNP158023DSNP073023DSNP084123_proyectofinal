Public Class Form1

    ' Dispones de 6 fallos
    ' Letra acertada suma 1 punto.
    ' Texto resuelto suma 50 puntos.
    ' -3 puntos por fallo.

    Dim ahorcado As Ahorcado = New Ahorcado()
    Dim errores As SByte = 0
    Dim palabraObtenida As String = ""
    Dim perdiste As New Perdiste()
    Dim puntos As Int16 = 0
    Dim creditos As Int16 = 0

    Private Sub dibujar()
        PictureBox1.Visible = IIf(errores = 1, True, False)
        PictureBox2.Visible = IIf(errores = 2, True, False)
        PictureBox3.Visible = IIf(errores = 3, True, False)
        PictureBox4.Visible = IIf(errores = 4, True, False)
        PictureBox5.Visible = IIf(errores = 5, True, False)
        PictureBox6.Visible = IIf(errores = 6, True, False)
        txtFallos.Text = errores.ToString
        PictureBox12.Visible = False
        Label5.Visible = False
        If errores = 6 Then
            'perdiste.Show()
            PictureBox12.Visible = True
            Label5.Visible = True
            txtCategoria.Text = ""
            txtFallos.Text = ""
            txtLetra.Text = ""
            txtPalabra.Text = ""

        End If
    End Sub

    Private Sub txtLetra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLetra.KeyDown
        If e.KeyValue < 65 Or e.KeyValue > 90 Then
            Return
        End If

        Dim letra = e.KeyData.ToString
        If palabraObtenida.Contains(letra) Then
            For i = 0 To (palabraObtenida.Length - 1)
                If palabraObtenida.Chars(i) = letra Then
                    txtPalabra.Text = txtPalabra.Text.Remove(i, 1)
                    txtPalabra.Text = txtPalabra.Text.Insert(i, letra)
                End If
            Next
            verificarPalabra()
        Else
            errores += 1
            dibujar()
        End If
        txtLetra.Clear()
        txtLetra.Refresh()
    End Sub

    Private Sub verificarPalabra()
        If txtPalabra.Text = palabraObtenida Then
            Integer.TryParse(lblPuntos.Text, puntos)
            puntos += 1
            lblPuntos.Text = puntos.ToString()

            If puntos >= 5 Then
                Integer.TryParse(Label10.Text, creditos)
                creditos += 5
                Label10.Text = creditos.ToString("C2") ' Actualiza el valor en el Label
                MessageBox.Show("Ganaste $5!!")
            End If

            MessageBox.Show("¡Felicidades, ganaste!")
            txtCategoria.Text = ""
            txtFallos.Text = ""
            txtLetra.Text = ""
            txtPalabra.Text = ""
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs)

        txtCategoria.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        txtPalabra.Visible = True
        txtLetra.Visible = True
        txtFallos.Visible = True
        errores = 0
        dibujar()
        txtCategoria.Text = ahorcado.pedirCategoria()
        palabraObtenida = ahorcado.pedirPalabra().ToString.ToUpper
        Console.WriteLine(palabraObtenida)
        txtPalabra.Text = StrDup(palabraObtenida.Length, "*")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If txtPalabra.Text = palabraObtenida Then
            MessageBox.Show("¡Felicidades, ganaste!")
            lblPuntos.Text += 1
            txtCategoria.Text = ""
            txtFallos.Text = ""
            txtLetra.Text = ""
            txtPalabra.Text = ""
        Else
            MessageBox.Show("Sigue jugando")


        End If


    End Sub




    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        errores = 0
        dibujar()
        txtCategoria.Text = ahorcado.pedirCategoria()
        palabraObtenida = ahorcado.pedirPalabra().ToString.ToUpper
        Console.WriteLine(palabraObtenida)
        txtPalabra.Text = StrDup(palabraObtenida.Length, "*")
        txtLetra.Select()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

        If txtPalabra.Text = palabraObtenida Then
            Integer.TryParse(lblPuntos.Text, puntos)
            puntos += 1
            lblPuntos.Text = puntos.ToString()

            If puntos >= 5 Then
                Integer.TryParse(Label10.Text, creditos)
                creditos += 5
                Label10.Text = creditos.ToString("C2") ' Actualiza el valor en el Label
                MessageBox.Show("Ganaste $5!!")
            End If

            MessageBox.Show("¡Felicidades, ganaste!")
            txtCategoria.Text = ""
            txtFallos.Text = ""
            txtLetra.Text = ""
            txtPalabra.Text = ""
        Else
            MessageBox.Show("Sigue jugando")
        End If

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Dim menu As New Menu()
        menu.Show()
        Me.Close()
    End Sub

End Class
