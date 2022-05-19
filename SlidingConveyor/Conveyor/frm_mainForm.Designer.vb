<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mainForm))
        Me.btn_conveyorSetup = New System.Windows.Forms.Button()
        Me.btn_monitor = New System.Windows.Forms.Button()
        Me.btn_manuelAdmin = New System.Windows.Forms.Button()
        Me.btn_manuel = New System.Windows.Forms.Button()
        Me.btn_userSetup = New System.Windows.Forms.Button()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_conveyorSetup
        '
        Me.btn_conveyorSetup.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_conveyorSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_conveyorSetup.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_conveyorSetup.FlatAppearance.BorderSize = 3
        Me.btn_conveyorSetup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.btn_conveyorSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_conveyorSetup.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_conveyorSetup.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_conveyorSetup.Location = New System.Drawing.Point(23, 228)
        Me.btn_conveyorSetup.Name = "btn_conveyorSetup"
        Me.btn_conveyorSetup.Size = New System.Drawing.Size(164, 119)
        Me.btn_conveyorSetup.TabIndex = 29
        Me.btn_conveyorSetup.Tag = "btn"
        Me.btn_conveyorSetup.Text = "CONVEYOR SETUP"
        Me.btn_conveyorSetup.UseVisualStyleBackColor = False
        '
        'btn_monitor
        '
        Me.btn_monitor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_monitor.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_monitor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_monitor.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick
        Me.btn_monitor.FlatAppearance.BorderSize = 3
        Me.btn_monitor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick
        Me.btn_monitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_monitor.Font = New System.Drawing.Font("Stencil", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_monitor.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_monitor.Location = New System.Drawing.Point(245, 296)
        Me.btn_monitor.MaximumSize = New System.Drawing.Size(218, 242)
        Me.btn_monitor.MinimumSize = New System.Drawing.Size(218, 242)
        Me.btn_monitor.Name = "btn_monitor"
        Me.btn_monitor.Size = New System.Drawing.Size(218, 242)
        Me.btn_monitor.TabIndex = 28
        Me.btn_monitor.Tag = "btn"
        Me.btn_monitor.Text = "MONITOR"
        Me.btn_monitor.UseVisualStyleBackColor = False
        '
        'btn_manuelAdmin
        '
        Me.btn_manuelAdmin.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_manuelAdmin.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_manuelAdmin.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_manuelAdmin.FlatAppearance.BorderSize = 3
        Me.btn_manuelAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.btn_manuelAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_manuelAdmin.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_manuelAdmin.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_manuelAdmin.Location = New System.Drawing.Point(245, 577)
        Me.btn_manuelAdmin.Name = "btn_manuelAdmin"
        Me.btn_manuelAdmin.Size = New System.Drawing.Size(218, 39)
        Me.btn_manuelAdmin.TabIndex = 30
        Me.btn_manuelAdmin.Tag = "btn"
        Me.btn_manuelAdmin.Text = "MANUEL ADMIN"
        Me.btn_manuelAdmin.UseVisualStyleBackColor = False
        '
        'btn_manuel
        '
        Me.btn_manuel.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_manuel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_manuel.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_manuel.FlatAppearance.BorderSize = 3
        Me.btn_manuel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.btn_manuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_manuel.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_manuel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_manuel.Location = New System.Drawing.Point(23, 362)
        Me.btn_manuel.Name = "btn_manuel"
        Me.btn_manuel.Size = New System.Drawing.Size(164, 119)
        Me.btn_manuel.TabIndex = 31
        Me.btn_manuel.Tag = "btn"
        Me.btn_manuel.Text = "MANUEL SCREEN"
        Me.btn_manuel.UseVisualStyleBackColor = False
        '
        'btn_userSetup
        '
        Me.btn_userSetup.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_userSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_userSetup.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_userSetup.FlatAppearance.BorderSize = 3
        Me.btn_userSetup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.btn_userSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_userSetup.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_userSetup.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_userSetup.Location = New System.Drawing.Point(23, 497)
        Me.btn_userSetup.Name = "btn_userSetup"
        Me.btn_userSetup.Size = New System.Drawing.Size(164, 119)
        Me.btn_userSetup.TabIndex = 32
        Me.btn_userSetup.Tag = "btn"
        Me.btn_userSetup.Text = "USER SETUP"
        Me.btn_userSetup.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exit.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_exit.FlatAppearance.BorderSize = 3
        Me.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_exit.Location = New System.Drawing.Point(512, 497)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(164, 119)
        Me.btn_exit.TabIndex = 33
        Me.btn_exit.Tag = "btn"
        Me.btn_exit.Text = "EXIT"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.Button1.FlatAppearance.BorderSize = 3
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button1.Location = New System.Drawing.Point(512, 228)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 119)
        Me.Button1.TabIndex = 34
        Me.Button1.Tag = "btn"
        Me.Button1.Text = "PARAMETER ADMIN"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.MidnightBlue
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.Button2.FlatAppearance.BorderSize = 3
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button2.Location = New System.Drawing.Point(512, 362)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 119)
        Me.Button2.TabIndex = 35
        Me.Button2.Tag = "btn"
        Me.Button2.Text = "STATISTIC"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(23, 24)
        Me.PictureBox1.MaximumSize = New System.Drawing.Size(653, 180)
        Me.PictureBox1.MinimumSize = New System.Drawing.Size(653, 180)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(653, 180)
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'frm_mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(698, 635)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_userSetup)
        Me.Controls.Add(Me.btn_manuel)
        Me.Controls.Add(Me.btn_manuelAdmin)
        Me.Controls.Add(Me.btn_conveyorSetup)
        Me.Controls.Add(Me.btn_monitor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(714, 674)
        Me.MinimumSize = New System.Drawing.Size(714, 674)
        Me.Name = "frm_mainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frm"
        Me.Text = "Sliding Conveyor - Main Screen"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_conveyorSetup As Button
    Friend WithEvents btn_monitor As Button
    Friend WithEvents btn_manuelAdmin As Button
    Friend WithEvents btn_manuel As Button
    Friend WithEvents btn_userSetup As Button
    Friend WithEvents btn_exit As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
