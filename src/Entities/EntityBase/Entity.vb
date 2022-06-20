Imports XApps
Public Class Entity
    Inherits XBase

    Protected WorldPtr As World
    Protected Position As Vector
    Protected ThetaX As Double
    Protected ThetaY As Double
    Protected MoveSpeed As Double
    Protected TurnSpeed As Double
    Sub New(WorldPointer As World)
        Me.WorldPtr = WorldPointer
        Me.Position = Vector.Zero
        Me.SetUpdateStatus(True)
        Me.SetDrawStatus(True)
    End Sub
    Public Overrides Sub Update(Session As XSession)


        '===Checks===
        ThetaCheck()
    End Sub
    Public Overrides Sub Draw(ByRef g As Graphics)
        ' Dim Font As New Font("Arial", 20)
        ' g.DrawString("X: " & Me.Position.X & " Y: " & Me.Position.Y & " Theta: " & Me.Theta, Font, Brushes.Black, New Point(30, 30))
        '  Font.Dispose()
        g.FillRectangle(Brushes.Black, New Rectangle(Me.Position.X - 5, Me.Position.Y - 5, 10, 10))
        g.DrawLine(Pens.Black, CInt(Me.Position.X), CInt(Me.Position.Y),
                   CInt((Me.Position.X + Math.Cos(Me.ThetaX) * 20)),
                   CInt((Me.Position.Y + Math.Sin(Me.ThetaX) * 20)))
    End Sub
    '==========================================
    Public Sub MoveForward()
        Me.Position.X += GetProjectedParallellDisplacementX()
        Me.Position.Y += GetProjectedParallellDisplacementY()
    End Sub
    Public Sub MoveBackward()
        Me.Position.X -= GetProjectedParallellDisplacementX()
        Me.Position.Y -= GetProjectedParallellDisplacementY()
    End Sub
    Public Sub MoveLeft()
        Me.Position.X -= GetProjectedPerpendicularDisplacementX()
        Me.Position.Y -= GetProjectedPerpendicularDisplacementY()
    End Sub
    Public Sub MoveRight()
        Me.Position.X += GetProjectedPerpendicularDisplacementX()
        Me.Position.Y += GetProjectedPerpendicularDisplacementY()
    End Sub
    Public Sub TurnLeft()
        Me.ThetaX -= Me.TurnSpeed
    End Sub
    Public Sub TurnRight()
        Me.ThetaX += Me.TurnSpeed
    End Sub
    Public Sub TurnUp()
        Me.ThetaY += Me.TurnSpeed
    End Sub
    Public Sub TurnDown()
        Me.ThetaY -= Me.TurnSpeed
    End Sub
    '----------------------------------
    Public Function CollisionOccuringForward()
        Dim ProjectedPositionX As Double = Me.Position.X + GetProjectedParallellDisplacementX() * 2
        Dim ProjectedPositionY As Double = Me.Position.Y + GetProjectedParallellDisplacementY() * 2
        If Me.WorldPtr.GetMaze.GetCellAtPoint(ProjectedPositionX, ProjectedPositionY) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function CollisionOccuringBackward()
        Dim ProjectedPositionX As Double = Me.Position.X - GetProjectedParallellDisplacementX() * 2
        Dim ProjectedPositionY As Double = Me.Position.Y - GetProjectedParallellDisplacementY() * 2
        If Me.WorldPtr.GetMaze.GetCellAtPoint(ProjectedPositionX, ProjectedPositionY) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function CollisionOccuringLeft()
        Dim ProjectedPositionX As Double = Me.Position.X - GetProjectedPerpendicularDisplacementX() * 2
        Dim ProjectedPositionY As Double = Me.Position.Y - GetProjectedPerpendicularDisplacementY() * 2
        If Me.WorldPtr.GetMaze.GetCellAtPoint(ProjectedPositionX, ProjectedPositionY) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function CollisionOccuringRight()
        Dim ProjectedPositionX As Double = Me.Position.X + GetProjectedPerpendicularDisplacementX() * 2
        Dim ProjectedPositionY As Double = Me.Position.Y + GetProjectedPerpendicularDisplacementY() * 2
        If Me.WorldPtr.GetMaze.GetCellAtPoint(ProjectedPositionX, ProjectedPositionY) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '----------------------------------
    Protected Function GetProjectedParallellDisplacementX() As Double
        Return Math.Cos(Me.ThetaX) * Me.MoveSpeed
    End Function
    Protected Function GetProjectedParallellDisplacementY() As Double
        Return Math.Sin(Me.ThetaX) * Me.MoveSpeed
    End Function
    Protected Function GetProjectedPerpendicularDisplacementX() As Double
        Return Math.Cos(Me.ThetaX + Math.PI / 2) * Me.MoveSpeed / 2
    End Function
    Protected Function GetProjectedPerpendicularDisplacementY() As Double
        Return Math.Sin(Me.ThetaX + Math.PI / 2) * Me.MoveSpeed / 2
    End Function
    '==========================================
    Private Sub ThetaCheck()
        If Me.ThetaX < 0 Then
            Me.ThetaX += 2 * Math.PI
        ElseIf Me.ThetaX > 2 * Math.PI Then
            Me.ThetaX -= 2 * Math.PI
        End If
    End Sub
    Protected Sub BoundCheck(Bounds As Rectangle)
        If Me.Position.X < 0 Then
            Me.Position.X = 0
        End If
        If Me.Position.X > Bounds.Width Then
            Me.Position.X = Bounds.Width
        End If
        If Me.Position.Y < 0 Then
            Me.Position.Y = 0
        End If
        If Me.Position.Y > Bounds.Height Then
            Me.Position.Y = Bounds.Height
        End If
    End Sub
    '==========================================
    Public Sub SetX(val As Double)
        Me.Position.X = val
    End Sub
    Public Sub SetY(val As Double)
        Me.Position.Y = val
    End Sub
    Public Sub SetTheta(val As Double)
        Me.ThetaX = val
    End Sub
    Public Sub SetMoveSpeed(val As Double)
        Me.MoveSpeed = val
    End Sub
    Public Sub SetTurnSpeed(val As Double)
        Me.TurnSpeed = val
    End Sub
    Public Function GetX() As Double
        Return Me.Position.X
    End Function
    Public Function GetY() As Double
        Return Me.Position.Y
    End Function
    Public Function GetThetaX() As Double
        Return Me.ThetaX
    End Function
    Public Function GetThetaY() As Double
        Return Me.ThetaY
    End Function
    Public Function GetMoveSpeed() As Double
        Return Me.MoveSpeed
    End Function
    Public Function GetTurnSpeed() As Double
        Return Me.TurnSpeed
    End Function

End Class
