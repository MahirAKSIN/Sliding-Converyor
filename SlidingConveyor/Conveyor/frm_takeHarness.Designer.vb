<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_takeHarness
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_takeHarness))
        Me.lbl_select = New System.Windows.Forms.Label()
        Me.cmb_Harness = New System.Windows.Forms.ComboBox()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_select
        '
        Me.lbl_select.AutoSize = True
        Me.lbl_select.BackColor = System.Drawing.Color.Transparent
        Me.lbl_select.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_select.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_select.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_select.Location = New System.Drawing.Point(12, 32)
        Me.lbl_select.Name = "lbl_select"
        Me.lbl_select.Size = New System.Drawing.Size(326, 20)
        Me.lbl_select.TabIndex = 4
        Me.lbl_select.Tag = "lbl"
        Me.lbl_select.Text = "Select the Cable You Want to Process :"
        '
        'cmb_Harness
        '
        Me.cmb_Harness.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Harness.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.cmb_Harness.FormattingEnabled = True
        Me.cmb_Harness.Location = New System.Drawing.Point(29, 78)
        Me.cmb_Harness.Name = "cmb_Harness"
        Me.cmb_Harness.Size = New System.Drawing.Size(290, 39)
        Me.cmb_Harness.TabIndex = 3
        '
        'btn_OK
        '
        Me.btn_OK.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_OK.FlatAppearance.BorderSize = 3
        Me.btn_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_OK.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_OK.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_OK.Location = New System.Drawing.Point(362, 37)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(110, 80)
        Me.btn_OK.TabIndex = 30
        Me.btn_OK.Tag = "btn"
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = False
        '
        'frm_takeHarness
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(497, 148)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.lbl_select)
        Me.Controls.Add(Me.cmb_Harness)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(513, 187)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(513, 187)
        Me.Name = "frm_takeHarness"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frm"
        Me.Text = "Harness Selection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_select As Label
    Friend WithEvents cmb_Harness As ComboBox
    Friend WithEvents btn_OK As Button
End Class
