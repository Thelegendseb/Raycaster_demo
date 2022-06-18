Public Class World
    Private Maze As Maze
    Public Sub New()
        Me.Maze = New Maze(10, 10)
    End Sub
    Public Function GetMaze() As Maze
        Return Me.Maze
    End Function
    Public Function GetBounds() As Rectangle
        Return New Rectangle(0, 0, Me.Maze.GetGrid.GetLength(0) * Me.Maze.GetCellSize,
                             Me.Maze.GetGrid.GetLength(1) * Me.Maze.GetCellSize)
    End Function
End Class
