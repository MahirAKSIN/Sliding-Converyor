<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Parameter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Parameter))
        Me.lbl_delayTime = New System.Windows.Forms.Label()
        Me.txt_delaytime = New System.Windows.Forms.TextBox()
        Me.btn_delay = New System.Windows.Forms.Button()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_delayTime
        '
        Me.lbl_delayTime.AutoSize = True
        Me.lbl_delayTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_delayTime.Location = New System.Drawing.Point(12, 50)
        Me.lbl_delayTime.Name = "lbl_delayTime"
        Me.lbl_delayTime.Size = New System.Drawing.Size(132, 25)
        Me.lbl_delayTime.TabIndex = 0
        Me.lbl_delayTime.Tag = "lbl"
        Me.lbl_delayTime.Text = "Delay Time :"
        '
        'txt_delaytime
        '
        Me.txt_delaytime.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_delaytime.Location = New System.Drawing.Point(166, 47)
        Me.txt_delaytime.Name = "txt_delaytime"
        Me.txt_delaytime.Size = New System.Drawing.Size(100, 31)
        Me.txt_delaytime.TabIndex = 1
        '
        'btn_delay
        '
        Me.btn_delay.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_delay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_delay.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_delay.FlatAppearance.BorderSize = 3
        Me.btn_delay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.btn_delay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_delay.Font = New System.Drawing.Font("Palatino Linotype", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_delay.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_delay.Location = New System.Drawing.Point(294, 31)
        Me.btn_delay.Name = "btn_delay"
        Me.btn_delay.Size = New System.Drawing.Size(106, 63)
        Me.btn_delay.TabIndex = 2
        Me.btn_delay.Tag = "btn"
        Me.btn_delay.Text = "SAVE"
        Me.btn_delay.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.Location = New System.Drawing.Point(163, 138)
        Me.btn_exit.MaximumSize = New System.Drawing.Size(75, 23)
        Me.btn_exit.MinimumSize = New System.Drawing.Size(75, 23)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 23)
        Me.btn_exit.TabIndex = 5
        Me.btn_exit.Text = "EXIT"
        Me.btn_exit.UseVisualStyleBackColor = True
        Me.btn_exit.Visible = False
        '
        'frm_Parameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(412, 121)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_delay)
        Me.Controls.Add(Me.txt_delaytime)
        Me.Controls.Add(Me.lbl_delayTime)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(428, 160)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(428, 160)
        Me.Name = "frm_Parameter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frm"
        Me.Text = "Parameter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_delayTime As Label
    Friend WithEvents txt_delaytime As TextBox
    Friend WithEvents btn_delay As Button
    Friend WithEvents btn_exit As Button
End Class
