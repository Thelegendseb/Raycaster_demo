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
        Dim Grid(,) As Integer = Maze.GetGrid
        Dim CellSize As Double = Maze.GetCellSize

        'View Distance Accountability 

        Dim dx As Double = Math.Cos(Me.Theta) * StepValue
        Dim dy As Double = Math.Sin(Me.Theta) * StepValue
        While True
            Target.X += dx
            Target.Y += dy
            Dim CellHitValue As Integer = StepCellHit(Target.X, Target.Y, Grid, CellSize)
            If CellHitValue <> 0 Then
                Me.CellHit = CellHitValue
                Exit While
            Else
                Me.Length += Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2))
            End If
        End While
    End Sub
    Private Function StepCellHit(x As Double, y As Double, Grid(,) As Integer, CellSize As Double) As Integer 'Cell

        Dim Length_h As Integer = Grid.GetLength(0) * CellSize
        Dim Length_w As Integer = Grid.GetLength(1) * CellSize
        If x > Length_w Or x < 0 Then
            Return 1
        End If
        If y >= Length_h Or y < 0 Then
            Return 1
        End If

        Return Grid(Math.Floor(y / CellSize),
                    Math.Floor(x / CellSize))

    End Function
    Public Function GetLength() As Double
        Return Me.Length
    End Function
    Public Sub SetLength(val As Double)
        Me.Length = val
    End Sub
    Public Function GetTheta() As Double
        Return Me.Theta
    End Function
End Class
