Imports XApps
Public Class Ray
    Private Origin As Vector
    Private StepValue As Double
    Private Theta As Double
    Private Length As Double
    Private CellHit As Integer 'Cell

    Sub New(OriginIn As Vector)
        Me.Origin = OriginIn
        Me.StepValue = 0
        Me.Theta = 0
    End Sub
    Public Sub Fire(StepValue As Double, Theta As Double, Maze As Maze)
        Dim Target As New Vector(Me.Origin.X, Me.Origin.Y)
        Me.StepValue = StepValue
        Me.Theta = Theta

        'View Distance Accountability 

        Dim dx As Double = Math.Cos(Me.Theta) * StepValue
        Dim dy As Double = Math.Sin(Me.Theta) * StepValue
        While True
            Target.X += dx
            Target.Y += dy
            Dim CellHitValue As Integer = Maze.GetCellAtPoint(Target.X, Target.Y)
            If CellHitValue <> 0 Then
                Me.CellHit = CellHitValue
                Exit While
            Else
                Me.Length += Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2))
            End If
        End While
    End Sub
    Public Function GetLength() As Double
        Return Me.Length
    End Function
    Public Sub SetLength(val As Double)
        Me.Length = val
    End Sub
    Public Function GetTheta() As Double
        Return Me.Theta
    End Function
    Public Function GetCellHit() As Integer
        Return Me.CellHit
    End Function
End Class
