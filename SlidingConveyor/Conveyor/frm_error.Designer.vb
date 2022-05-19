<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_error
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_error))
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.Rtxt_error = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'btn_ok
        '
        Me.btn_ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ok.BackColor = System.Drawing.Color.Gray
        Me.btn_ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_ok.FlatAppearance.BorderSize = 3
        Me.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_ok.ForeColor = System.Drawing.Color.White
        Me.btn_ok.Location = New System.Drawing.Point(833, 545)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(118, 44)
        Me.btn_ok.TabIndex = 3
        Me.btn_ok.Tag = "btn"
        Me.btn_ok.Text = "OK"
        Me.btn_ok.UseVisualStyleBackColor = False
        '
        'Rtxt_error
        '
        Me.Rtxt_error.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rtxt_error.Location = New System.Drawing.Point(12, 12)
        Me.Rtxt_error.Name = "Rtxt_error"
        Me.Rtxt_error.Size = New System.Drawing.Size(939, 527)
        Me.Rtxt_error.TabIndex = 2
        Me.Rtxt_error.Text = ""
        '
        'frm_error
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(964, 600)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.Rtxt_error)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_error"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frm"
        Me.Text = "Conveyor Error Screen "
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_ok As Button
    Friend WithEvents Rtxt_error As RichTextBox
End Class
