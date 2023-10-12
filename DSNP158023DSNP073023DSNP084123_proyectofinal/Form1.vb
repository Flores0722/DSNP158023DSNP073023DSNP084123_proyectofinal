Public Class Form1

    ' Dispones de 6 fallos
    ' Letra acertada suma 1 punto.
    ' Texto resuelto suma 50 puntos.
    ' -3 puntos por fallo.

    Dim ahorcado As Ahorcado = New Ahorcado()
    Dim errores As SByte = 0
    Dim palabraObtenida As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        errores = 0
        dibujar()
        txtCategoria.Text = ahorcado.pedirCategoria()
        palabraObtenida = ahorcado.pedirPalabra().ToString.ToUpper
        Console.WriteLine(palabraObtenida)
        txtPalabra.Text = StrDup(palabraObtenida.Length, "*")
    End Sub
    Private Sub dibujar()
        PictureBox1.Visible = IIf(errores = 1, True, False)
        PictureBox2.Visible = IIf(errores = 2, True, False)
        PictureBox3.Visible = IIf(errores = 3, True, False)
        PictureBox4.Visible = IIf(errores = 4, True, False)
        PictureBox5.Visible = IIf(errores = 5, True, False)
        PictureBox6.Visible = IIf(errores = 6, True, False)
        txtFallos.Text = errores.ToString
        If errores = 6 Then
            MessageBox.Show("¡¡ PERDISTE !!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Else
            errores += 1
            dibujar()
        End If
        txtLetra.Clear()
        txtLetra.Refresh()
    End Sub


End Class
