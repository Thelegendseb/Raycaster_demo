Public Class Maze
    Private Grid(,) As Integer 'Cell
    Private CellSize As Double = 1.0
    Sub New(WidthIn As Integer, HeightIn As Integer)

    End Sub
    Public Function GetGrid() As Integer(,) 'Cell(,)
        'Return Me.Grid

        Return {{0, 0, 0, 1, 0, 0, 0},
                {0, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 1, 0},
                 {1, 0, 0, 0, 1, 0, 0},
                 {1, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0}}
    End Function
    Public Function GetCellSize() As Double
        Return Me.CellSize
    End Function
    Public Sub SetCellSize(val As Double)
        Me.CellSize = val
    End Sub
End Class
