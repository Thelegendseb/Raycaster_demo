Imports XApps
Public Class EntityMapper
    Inherits XBase
    'Maps inputs to entity method calls
    Private EntityPtr As Entity
    Public Bindings As EntityKeybinds
    Sub New(EntityIn As Entity, BindingsIn As EntityKeybinds)
        Me.Bindings = BindingsIn
        Me.EntityPtr = EntityIn
        Me.SetUpdateStatus(True)
    End Sub
    Public Overrides Sub Update(Session As XSession)
        If Session.KeyManager.IsDown(Me.Bindings.GetForward) Then
            Me.EntityPtr.MoveForward()
        End If
        If Session.KeyManager.IsDown(Me.Bindings.GetBackward) Then
            Me.EntityPtr.MoveBackward()
        End If
        If Session.KeyManager.IsDown(Me.Bindings.GetLeft) Then
            Me.EntityPtr.MoveLeft()
        End If
        If Session.KeyManager.IsDown(Me.Bindings.GetRight) Then
            Me.EntityPtr.MoveRight()
        End If
        If Session.KeyManager.IsDown(Me.Bindings.GetTurnLeft) Then
            Me.EntityPtr.TurnLeft()
        End If
        If Session.KeyManager.IsDown(Me.Bindings.GetTurnRight) Then
            Me.EntityPtr.TurnRight()
        End If
    End Sub
    Public Overrides Sub Draw(ByRef g As Graphics)

    End Sub
End Class
