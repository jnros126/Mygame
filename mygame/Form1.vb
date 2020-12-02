Public Class MyGame
    Dim direction As Integer
    Dim score As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        follow(redghost)
        Label2.Text = score
    End Sub
    Sub Move(p As PictureBox, x As Integer, y As Integer)
        p.Location = New Point(p.Location.X + x, p.Location.Y + y)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Left, Keys.A
                MoveTo(Pacman, -5, 0)
                If direction <> 2 Then
                    Pacman.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone)
                    direction = 2
                End If
            Case Keys.Right, Keys.D
                MoveTo(Pacman, 5, 0)
                If direction <> 3 Then
                    Pacman.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                    direction = 3
                End If
            Case Keys.Up, Keys.W
                MoveTo(Pacman, 0, -5)
                If direction <> 1 Then
                    Pacman.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
                    direction = 1
                End If
            Case Keys.Down, Keys.S
                MoveTo(Pacman, 0, 5)
                If direction <> 4 Then
                    Pacman.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    direction = 4
                End If
            Case Keys.Space
                Bullet.Location = Pacman.Location
                Timer2.Enabled = True
                Bullet.Visible = True
            Case Keys.R
            Case Keys.L
            Case Else

        End Select
    End Sub
    Dim r As New Random()
    Sub RandomMove(p As PictureBox)
        Dim xdir As Integer = r.Next(-20, 21)
        Dim ydir As Integer = r.Next(-20, 21)

        MoveTo(p, xdir, ydir)
    End Sub

    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(Pacman.Location)
        headstart = headstart + 1
        If headstart > 20 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X > Pacman.Location.X Then
            x = -5
        Else
            x = 5
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < Pacman.Location.Y Then
            y = 5
        Else
            y = -5
        End If
        MoveTo(p, x, y)
    End Sub
    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
                Return col
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        If p.Name = "Pacman" And Collision(p, "dot", other) Then
            score = score + 1
            If score = 33 Then
                Form2.ShowDialog()
                Me.BackColor = Color.Green
            End If
            other.visible = False
        End If
        Return
        If Collision(p, "redghost", other) Then
            Form3.ShowDialog()
            Me.BackColor = Color.Red
        End If
        other.visible = False
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If direction < 0 Then
            MoveTo(Bullet, -5, 0)
        End If
        If direction > 0 Then
            MoveTo(Bullet, 5, 0)
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        RandomMove(redghost)
    End Sub

End Class
