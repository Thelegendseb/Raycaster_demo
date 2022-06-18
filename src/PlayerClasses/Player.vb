Imports XApps
Public Class Player
    Inherits Entity
    Public Mapper As EntityMapper 'public to allow access from the mappers keybind methods
    Private WorldPtr As World
    Private ViewDensity As Integer
    Private FOV As Double 'In radians
    Private Depth As Double
    Private SightAccuracy As Double

    'allows movement through keypresses
    Sub New(KeyBinds As EntityKeybinds,
            WorldPointer As World)

        MyBase.New()

        Me.ViewDensity = 200
        Me.FOV = 0.75F * Math.PI
        Me.Depth = 8
        Me.SightAccuracy = 0.02

        Me.Mapper = New EntityMapper(Me, KeyBinds)
        Me.WorldPtr = WorldPointer
    End Sub
    Public Overrides Sub Update(Session As XSession)
        MyBase.Update(Session)
        BoundCheck(WorldPtr.GetBounds)
    End Sub
    Public Overrides Sub Draw(ByRef g As Graphics)
        DrawView(g)
    End Sub
    Private Sub DrawView(ByRef g As Graphics)
        Dim Rays() As Ray = GetView()
        Dim ScreenWidth As Integer = g.VisibleClipBounds.Width ' screem width
        Dim ScreenHeight As Integer = g.VisibleClipBounds.Height ' screem height
        Dim RayWidth As Integer = ScreenWidth / Rays.Length

        Dim proj As Single = Me.WorldPtr.GetMaze.GetCellSize / Math.Tan(Me.FOV / 2)
        For i = 0 To Rays.Length - 1
            Dim CurrentRay As Ray = Rays(i)
            Dim CurrentRayLength As Double = CurrentRay.GetLength
            CurrentRayLength *= Math.Cos(Me.Theta - CurrentRay.GetTheta)

            If Not CurrentRayLength <= 0 Then
                Dim RayHeight As Integer = CInt(ScreenHeight * proj / CurrentRayLength)
                If RayHeight > ScreenHeight Then RayHeight = ScreenHeight
                Dim CC As Byte = CByte(XMath.Map(RayHeight, 0, ScreenHeight, 100, 255))
                Dim Col As Color = Color.FromArgb(CC, 0, CC)
                Dim Br As New SolidBrush(Col)
                g.FillRectangle(Br, i * RayWidth, CInt((ScreenHeight / 2) - (RayHeight / 2)),
                                RayWidth, RayHeight)
                Br.Dispose()
            End If
        Next
    End Sub
    Private Function GetView() As Ray()
        Dim Maze As Maze = Me.WorldPtr.GetMaze()
        Dim Rays() As Ray
        Dim Counter As Integer = 0
        For i = -Me.FOV / 2 To Me.FOV / 2 Step Me.FOV / Me.ViewDensity
            ReDim Preserve Rays(Counter)
            Dim Theta As Double = Me.Theta + i
            If Theta < 0 Then Theta += Math.PI * 2
            If Theta > Math.PI * 2 Then Theta -= Math.PI * 2
            Rays(Counter) = New Ray(Me.Position)
            Rays(Counter).Fire(Me.SightAccuracy, Theta, Maze)
            If Rays(Counter).GetLength() > Me.Depth Then
                Rays(Counter).SetLength(0)
            End If
            Counter += 1
        Next
        Return Rays
    End Function
    '======================
    Public Sub Dispose()
        Me.SetDisposeStatus(True)
        Me.Mapper.SetDisposeStatus(True)
    End Sub
    Public Function GetViewDensity() As Integer
        Return Me.ViewDensity
    End Function
    Public Sub SetViewDensity(val As Integer)
        Me.ViewDensity = val
    End Sub
    Public Function GetFOV() As Double
        Return Me.FOV
    End Function
    Public Sub SetFOV(val As Double)
        Me.FOV = val
    End Sub
    Public Function GetDepth() As Double
        Return Me.Depth
    End Function
    Public Sub SetDepth(val As Double)
        Me.Depth = val
    End Sub
    Public Function GetSightAccuracy() As Double
        Return Me.SightAccuracy
    End Function
    Public Sub SetSightAccuracy(val As Double)
        Me.SightAccuracy = val
    End Sub
End Class