Public Class Form2

    Private Sub HuraButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HuraButton3.Click
        Try
            OpenFileDialog1.ShowDialog()
            Dim r3 As IO.StreamReader
            r3 = New IO.StreamReader(OpenFileDialog1.FileName)
            While (r3.Peek() > -1)
                ListBox1.Items.Add(r3.ReadLine)
            End While
            r3.Close()
        Catch ex As Exception
            MsgBox("Lütfen geçerli bir txt dosyası seçin!", 16, "Dikkat !")
        End Try
        
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            ListBox1.SelectedIndex += 1
            HuraTextBox2.Text = ListBox1.SelectedItem
            WebBrowser1.Navigate(HuraTextBox1.Text & HuraTextBox2.Text)
            Timer1.Stop()
            If ListBox1.SelectedIndex.ToString = ListBox1.Items.Count.ToString - 1 Then
                Timer1.Stop()
            End If
        Catch ex As Exception
            Timer1.Stop()
        End Try
        
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If HuraButton1.Text = "Durdur" Then
            If HuraTextBox1.Text = "Link" Or HuraTextBox1.Text = "" Then
            Else
                TextBox1.Text = WebBrowser1.DocumentTitle
                If TextBox1.Text.Contains("404") Or TextBox1.Text.Contains("Sorry") Or TextBox1.Text.Contains("401") Or TextBox1.Text.Contains("Hata") Or TextBox1.Text.Contains("Not") Or TextBox1.Text.Contains("Found") Or TextBox1.Text.Contains("File") Or TextBox1.Text.Contains("Error") Or TextBox1.Text.Contains("görüntülenemiyor") Or TextBox1.Text.Contains("Bu") Or TextBox1.Text.Contains("Forbidden") Or TextBox1.Text.Contains("403") Or TextBox1.Text.Contains("Özür") Or TextBox1.Text.Contains("501") Then

                    Timer1.Start()
                Else
                    Timer1.Stop()
                    Timer2.Start()
                End If

            End If
        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub HuraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HuraButton1.Click
        If HuraButton1.Text = "Durdur" Then
            Timer1.Stop()
            HuraButton1.Text = "Başlat"
        Else
            If HuraTextBox1.Text = "" Then
                MsgBox("Lütfen site girin", MsgBoxStyle.Critical, "Dikkat !")
            Else
                Timer1.Start()
                HuraButton1.Text = "Durdur"
            End If
        End If
        
    End Sub

    Private Sub HuraButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HuraButton2.Click
        Try
            HuraTextBox1.Text = Clipboard.GetText

        Catch ex As Exception
            MsgBox("Yapıştırma işlemi başarısız.", 16, "Dikkat")
        End Try
    End Sub

    Private Sub HuraTextBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles HuraTextBox1.MouseClick
        HuraTextBox1.Text = ""
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Stop()
    End Sub

    Private Sub HuraButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WebBrowser1.Navigate("https://tinypng.com/")
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        ListBox2.Items.Add(HuraTextBox1.Text & ListBox1.SelectedItem)
        Timer2.Stop()
        Timer1.Start()

    End Sub

    Private Sub HuraButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HuraButton5.Click
        ListBox2.Items.Clear()
    End Sub

    Private Sub HuraButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HuraButton6.Click
        Try
            WebBrowser1.Navigate(ListBox2.SelectedItem)
        Catch ex As Exception
            MsgBox("Bir link seçin !!")
        End Try

    End Sub

    Private Sub HuraButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
End Class