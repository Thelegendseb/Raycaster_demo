Imports XApps
Public Class Entity
    Inherits XBase
    Protected Position As Vector
    Protected Theta As Double
    Protected MoveSpeed As Double
    Protected TurnSpeed As Double
    Sub New()
        Position = Vector.Zero
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
                   CInt((Me.Position.X + Math.Cos(Me.Theta) * 20)),
                   CInt((Me.Position.Y + Math.Sin(Me.Theta) * 20)))
    End Sub
    '==========================================
    Public Sub MoveForward()
        Me.Position.X += Math.Cos(Me.Theta) * Me.MoveSpeed
        Me.Position.Y += Math.Sin(Me.Theta) * Me.MoveSpeed
    End Sub
    Public Sub MoveBackward()
        Me.Position.X -= Math.Cos(Me.Theta) * Me.MoveSpeed
        Me.Position.Y -= Math.Sin(Me.Theta) * Me.MoveSpeed
    End Sub
    Public Sub MoveLeft()
        Me.Position.X -= Math.Cos(Me.Theta + Math.PI / 2) * Me.MoveSpeed / 2
        Me.Position.Y -= Math.Sin(Me.Theta + Math.PI / 2) * Me.MoveSpeed / 2
    End Sub
    Public Sub MoveRight()
        Me.Position.X += Math.Cos(Me.Theta + Math.PI / 2) * Me.MoveSpeed / 2
        Me.Position.Y += Math.Sin(Me.Theta + Math.PI / 2) * Me.MoveSpeed / 2
    End Sub
    Public Sub TurnLeft()
        Me.Theta -= Me.TurnSpeed
    End Sub
    Public Sub TurnRight()
        Me.Theta += Me.TurnSpeed
    End Sub
    '==========================================
    Private Sub ThetaCheck()
        If Me.Theta < 0 Then
            Me.Theta += 2 * Math.PI
        ElseIf Me.Theta > 2 * Math.PI Then
            Me.Theta -= 2 * Math.PI
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
        Me.Theta = val
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
    Public Function GetTheta() As Double
        Return Me.Theta
    End Function
    Public Function GetMoveSpeed() As Double
        Return Me.MoveSpeed
    End Function
    Public Function GetTurnSpeed() As Double
        Return Me.TurnSpeed
    End Function

End Class
