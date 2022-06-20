Public Class Maze
    Private Grid(,) As Integer 'Cell
    Private CellSize As Double = 1.0
    Sub New(WidthIn As Integer, HeightIn As Integer)
        Me.Grid = GetGrid()
    End Sub
    Public Function GetGrid() As Integer(,) 'Cell(,)
        'Return Me.Grid
        Return {{0, 0, 0, 1, 4, 0, 3},
                {1, 2, 0, 0, 0, 0, 4},
                {0, 0, 0, 0, 0, 2, 0},
                {1, 0, 3, 0, 1, 0, 0},
                {1, 4, 1, 0, 0, 0, 0},
                {0, 0, 0, 0, 2, 0, 2},
                {0, 2, 3, 0, 4, 0, 4}}
    End Function
    Public Function GetCellAtPoint(x As Double, y As Double)
        Dim Length_h As Integer = Me.Grid.GetLength(0) * Me.CellSize
        Dim Length_w As Integer = Me.Grid.GetLength(1) * Me.CellSize
        If x > Length_w Or x < 0 Then
            Return 1
        End If
        If y >= Length_h Or y < 0 Then
            Return 1
        End If

        Return Me.Grid(Math.Floor(y / Me.CellSize),
                    Math.Floor(x / Me.CellSize))
    End Function
    Public Function GetCellSize() As Double
        Return Me.CellSize
    End Function
    Public Sub SetCellSize(val As Double)
        Me.CellSize = val
    End Sub
End Class
