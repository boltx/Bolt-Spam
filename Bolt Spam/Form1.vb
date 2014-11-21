Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("Please register an account or login in to your account, otherwise you may not login.", vbExclamation, "Error") '' Giving user a msg that they cannot leave the text boxes blank.
        Else
            If TextBox1.Text = My.Settings.Username And TextBox2.Text = My.Settings.Password Then
                Timer1.Start()

            Else
                MsgBox("The information you entered does not match our records.", vbExclamation, "Error") '' The user has put in their wrong login information.

            End If
        End If
    End Sub

    Private Sub SavedDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavedDetailsToolStripMenuItem.Click
        MsgBox("Username: " + My.Settings.username + " Password: " + My.Settings.password, vbInformation, "Last Saved Details") '' This will show the user the last time they used the remember me funcion to get into Bolt Spam.
        If CheckBox1.Checked = True Then
        Else
            My.Settings.Check = False
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label5.Text = "Logging you in and opening e-mail ports."
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 100 Then
            Form3.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionToolStripMenuItem.Click
        MsgBox("Version: v1.1r1")
    End Sub
End Class