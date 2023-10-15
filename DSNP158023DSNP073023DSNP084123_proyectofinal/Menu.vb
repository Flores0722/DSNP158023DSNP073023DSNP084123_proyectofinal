Imports DSNP158023DSNP073023DSNP084123_proyectofinal.Form1
Public Class Menu

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim form As New Form1()
        form.Show()

        If form.Visible = True Then
            Me.Hide()
        End If
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class