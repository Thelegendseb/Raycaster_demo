Public Class EntityKeybinds
    'exclusive to EntityMapper
    Private Forward As Keys
    Private Backward As Keys
    Private Left As Keys
    Private Right As Keys
    Private TurnLeft As Keys
    Private TurnRight As Keys
    Sub New() 'Defualt Bindings
        Me.Forward = Keys.W
        Me.Backward = Keys.S
        Me.Left = Keys.A
        Me.Right = Keys.D
        Me.TurnLeft = Keys.Left
        Me.TurnRight = Keys.Right
    End Sub
    Sub New(ByVal Forward As Keys,
            ByVal Backward As Keys,
            ByVal Left As Keys,
            ByVal Right As Keys,
            ByVal TurnLeft As Keys,
            ByVal TurnRight As Keys)
        Me.Forward = Forward
        Me.Backward = Backward
        Me.Left = Left
        Me.Right = Right
        Me.TurnLeft = TurnLeft
        Me.TurnRight = TurnRight
    End Sub
    '================================
    Public Sub SetForward(ByVal Key As Keys)
        Me.Forward = Key
    End Sub
    Public Sub SetBackward(ByVal Key As Keys)
        Me.Backward = Key
    End Sub
    Public Sub SetLeft(ByVal Key As Keys)
        Me.Left = Key
    End Sub
    Public Sub SetRight(ByVal Key As Keys)
        Me.Right = Key
    End Sub
    Public Sub SetTurnLeft(ByVal Key As Keys)
        Me.TurnLeft = Key
    End Sub
    Public Sub SetTurnRight(ByVal Key As Keys)
        Me.TurnRight = Key
    End Sub
    Public Function GetForward() As Keys
        Return Me.Forward
    End Function
    Public Function GetBackward() As Keys
        Return Me.Backward
    End Function
    Public Function GetLeft() As Keys
        Return Me.Left
    End Function
    Public Function GetRight() As Keys
        Return Me.Right
    End Function
    Public Function GetTurnLeft() As Keys
        Return Me.TurnLeft
    End Function
    Public Function GetTurnRight() As Keys
        Return Me.TurnRight
    End Function
End Class
