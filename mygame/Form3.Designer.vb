<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gameover = New System.Windows.Forms.PictureBox()
        CType(Me.gameover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gameover
        '
        Me.gameover.Image = Global.mygame.My.Resources.Resources.download__6_
        Me.gameover.Location = New System.Drawing.Point(-1, -1)
        Me.gameover.Name = "gameover"
        Me.gameover.Size = New System.Drawing.Size(802, 453)
        Me.gameover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.gameover.TabIndex = 0
        Me.gameover.TabStop = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.gameover)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.gameover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gameover As PictureBox
End Class
