Imports System.Net.Mail
Imports System.IO
Public Class Form3

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = False
        Timer1.Start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim MyMailMessage As New MailMessage()

            MyMailMessage.From = New MailAddress(TextBox1.Text)
            MyMailMessage.To.Add(TextBox4.Text)
            MyMailMessage.Subject = TextBox5.Text
            MyMailMessage.Body = (TextBox6.Text)
            Dim SMTP As New SmtpClient(ComboBox1.Text)
            SMTP.Port = ComboBox2.Text
            SMTP.EnableSsl = ComboBox3.Text
            SMTP.Credentials = New System.Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
            SMTP.Send(MyMailMessage)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Interval = TextBox3.Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFile()
    End Sub

    Public Sub OpenFile()

        Dim oReader As StreamReader

        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.CheckPathExists = True
        OpenFileDialog1.DefaultExt = "txt"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt"
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Title = "Import a 'spam message'"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            oReader = New StreamReader(OpenFileDialog1.FileName, True)
            TextBox6.Text = oReader.ReadToEnd
        End If

    End Sub
End Class