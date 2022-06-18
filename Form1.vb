Imports XApps
Public Class Form1
    Private App As XApp
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.CenterToScreen()
        Me.App = New MazeMapper(Me)
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.App.Run()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        Me.App.Halt()
    End Sub
End Class
