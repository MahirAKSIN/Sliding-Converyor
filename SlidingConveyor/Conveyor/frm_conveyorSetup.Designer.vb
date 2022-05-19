<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_conveyorSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_conveyorSetup))
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.grd_production = New System.Windows.Forms.DataGridView()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.txt_critical = New System.Windows.Forms.TextBox()
        Me.txt_ProcessTime = New System.Windows.Forms.TextBox()
        Me.txt_quantity = New System.Windows.Forms.TextBox()
        Me.txt_harness = New System.Windows.Forms.TextBox()
        Me.lbl_critical = New System.Windows.Forms.Label()
        Me.lbl_quantity = New System.Windows.Forms.Label()
        Me.lbl_ProcessTime = New System.Windows.Forms.Label()
        Me.lbl_Harness = New System.Windows.Forms.Label()
        CType(Me.grd_production, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_delete
        '
        Me.btn_delete.BackgroundImage = CType(resources.GetObject("btn_delete.BackgroundImage"), System.Drawing.Image)
        Me.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_delete.Location = New System.Drawing.Point(604, 199)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(75, 75)
        Me.btn_delete.TabIndex = 25
        Me.btn_delete.Tag = "btn"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_update
        '
        Me.btn_update.BackgroundImage = CType(resources.GetObject("btn_update.BackgroundImage"), System.Drawing.Image)
        Me.btn_update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_update.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_update.Location = New System.Drawing.Point(502, 199)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(75, 75)
        Me.btn_update.TabIndex = 24
        Me.btn_update.Tag = "btn"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'grd_production
        '
        Me.grd_production.AllowUserToAddRows = False
        Me.grd_production.AllowUserToDeleteRows = False
        Me.grd_production.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.grd_production.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_production.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd_production.Location = New System.Drawing.Point(12, 14)
        Me.grd_production.MultiSelect = False
        Me.grd_production.Name = "grd_production"
        Me.grd_production.ReadOnly = True
        Me.grd_production.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_production.Size = New System.Drawing.Size(386, 260)
        Me.grd_production.TabIndex = 23
        '
        'btn_exit
        '
        Me.btn_exit.BackgroundImage = CType(resources.GetObject("btn_exit.BackgroundImage"), System.Drawing.Image)
        Me.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_exit.Location = New System.Drawing.Point(720, 199)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 75)
        Me.btn_exit.TabIndex = 22
        Me.btn_exit.Tag = "btn"
        Me.btn_exit.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.BackgroundImage = CType(resources.GetObject("btn_save.BackgroundImage"), System.Drawing.Image)
        Me.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue
        Me.btn_save.FlatAppearance.BorderSize = 2
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_save.Location = New System.Drawing.Point(409, 199)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 75)
        Me.btn_save.TabIndex = 21
        Me.btn_save.Tag = "btn"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'txt_critical
        '
        Me.txt_critical.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_critical.Location = New System.Drawing.Point(718, 128)
        Me.txt_critical.Name = "txt_critical"
        Me.txt_critical.Size = New System.Drawing.Size(77, 26)
        Me.txt_critical.TabIndex = 20
        '
        'txt_ProcessTime
        '
        Me.txt_ProcessTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_ProcessTime.Location = New System.Drawing.Point(718, 91)
        Me.txt_ProcessTime.Name = "txt_ProcessTime"
        Me.txt_ProcessTime.Size = New System.Drawing.Size(77, 26)
        Me.txt_ProcessTime.TabIndex = 19
        '
        'txt_quantity
        '
        Me.txt_quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_quantity.Location = New System.Drawing.Point(718, 48)
        Me.txt_quantity.Name = "txt_quantity"
        Me.txt_quantity.Size = New System.Drawing.Size(77, 26)
        Me.txt_quantity.TabIndex = 18
        '
        'txt_harness
        '
        Me.txt_harness.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_harness.Location = New System.Drawing.Point(626, 11)
        Me.txt_harness.Name = "txt_harness"
        Me.txt_harness.Size = New System.Drawing.Size(169, 26)
        Me.txt_harness.TabIndex = 17
        '
        'lbl_critical
        '
        Me.lbl_critical.AutoSize = True
        Me.lbl_critical.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_critical.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_critical.Location = New System.Drawing.Point(405, 131)
        Me.lbl_critical.Name = "lbl_critical"
        Me.lbl_critical.Size = New System.Drawing.Size(197, 20)
        Me.lbl_critical.TabIndex = 16
        Me.lbl_critical.Tag = "lbl"
        Me.lbl_critical.Text = "Critical Time (second)  :"
        '
        'lbl_quantity
        '
        Me.lbl_quantity.AutoSize = True
        Me.lbl_quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_quantity.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_quantity.Location = New System.Drawing.Point(405, 51)
        Me.lbl_quantity.Name = "lbl_quantity"
        Me.lbl_quantity.Size = New System.Drawing.Size(261, 20)
        Me.lbl_quantity.TabIndex = 15
        Me.lbl_quantity.Tag = "lbl"
        Me.lbl_quantity.Text = "Expected Completion Quantity :"
        '
        'lbl_ProcessTime
        '
        Me.lbl_ProcessTime.AutoSize = True
        Me.lbl_ProcessTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_ProcessTime.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_ProcessTime.Location = New System.Drawing.Point(405, 94)
        Me.lbl_ProcessTime.Name = "lbl_ProcessTime"
        Me.lbl_ProcessTime.Size = New System.Drawing.Size(307, 20)
        Me.lbl_ProcessTime.TabIndex = 14
        Me.lbl_ProcessTime.Tag = "lbl"
        Me.lbl_ProcessTime.Text = "Expected Completion Time (second) :"
        '
        'lbl_Harness
        '
        Me.lbl_Harness.AutoSize = True
        Me.lbl_Harness.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_Harness.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_Harness.Location = New System.Drawing.Point(405, 14)
        Me.lbl_Harness.Name = "lbl_Harness"
        Me.lbl_Harness.Size = New System.Drawing.Size(86, 20)
        Me.lbl_Harness.TabIndex = 13
        Me.lbl_Harness.Tag = "lbl"
        Me.lbl_Harness.Text = "Harness :"
        '
        'frm_conveyorSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(807, 286)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.grd_production)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.txt_critical)
        Me.Controls.Add(Me.txt_ProcessTime)
        Me.Controls.Add(Me.txt_quantity)
        Me.Controls.Add(Me.txt_harness)
        Me.Controls.Add(Me.lbl_critical)
        Me.Controls.Add(Me.lbl_quantity)
        Me.Controls.Add(Me.lbl_ProcessTime)
        Me.Controls.Add(Me.lbl_Harness)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(823, 325)
        Me.MinimumSize = New System.Drawing.Size(823, 325)
        Me.Name = "frm_conveyorSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frm"
        Me.Text = "Conveyor Setup"
        CType(Me.grd_production, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_delete As Button
    Friend WithEvents btn_update As Button
    Friend WithEvents grd_production As DataGridView
    Friend WithEvents btn_exit As Button
    Friend WithEvents btn_save As Button
    Friend WithEvents txt_critical As TextBox
    Friend WithEvents txt_ProcessTime As TextBox
    Friend WithEvents txt_quantity As TextBox
    Friend WithEvents txt_harness As TextBox
    Friend WithEvents lbl_critical As Label
    Friend WithEvents lbl_quantity As Label
    Friend WithEvents lbl_ProcessTime As Label
    Friend WithEvents lbl_Harness As Label
End Class
