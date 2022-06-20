Imports XApps
Public Class MazeMapper
    Inherits XApp
    Private Player As Player
    Private World As World
    Public Sub New(FormIn As Form)
        MyBase.New(FormIn)
        MeInit()
        WorldInit()
        PlayerInit()
        Me.Session.QueueRelease()
    End Sub
    Private Sub MeInit()
        Me.Session.SetSpeed(100)
        Me.Session.Window.SetClearColor(Color.LightGray)
    End Sub
    Private Sub WorldInit()
        Me.World = New World()
        Me.World.GetMaze.SetCellSize(1)
    End Sub
    Private Sub PlayerInit()
        Me.Player = New Player(New EntityKeybinds, Me.World)
        Me.Player.SetMoveSpeed(0.03)
        Me.Player.SetTurnSpeed(0.03)
        Me.Player.SetX(0.5)
        Me.Player.SetY(0.5)
        Me.Player.SetSightAccuracy(0.01)
        Me.Player.SetViewDensity(200) 'higher than 200?
        Me.Player.SetDepth(10)
        Me.Session.AddObj(Me.Player)
        Me.Session.AddObj(Me.Player.Mapper)
    End Sub
    '=======================
    Public Overrides Sub KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Session.Halt()
            Application.Exit()
        End If
    End Sub
End Class
