<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_main
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
        Me.Rtxt_Info = New System.Windows.Forms.RichTextBox()
        Me.btn_Run = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Rtxt_Info
        '
        Me.Rtxt_Info.Location = New System.Drawing.Point(12, 12)
        Me.Rtxt_Info.Name = "Rtxt_Info"
        Me.Rtxt_Info.ReadOnly = True
        Me.Rtxt_Info.Size = New System.Drawing.Size(737, 187)
        Me.Rtxt_Info.TabIndex = 7
        Me.Rtxt_Info.Text = ""
        '
        'btn_Run
        '
        Me.btn_Run.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_Run.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Run.FlatAppearance.BorderSize = 3
        Me.btn_Run.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime
        Me.btn_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Run.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_Run.ForeColor = System.Drawing.Color.Maroon
        Me.btn_Run.Location = New System.Drawing.Point(587, 205)
        Me.btn_Run.Name = "btn_Run"
        Me.btn_Run.Size = New System.Drawing.Size(162, 43)
        Me.btn_Run.TabIndex = 6
        Me.btn_Run.Tag = "btn"
        Me.btn_Run.Text = "Run New Version"
        Me.btn_Run.UseVisualStyleBackColor = False
        Me.btn_Run.Visible = False
        '
        'frm_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 261)
        Me.Controls.Add(Me.Rtxt_Info)
        Me.Controls.Add(Me.btn_Run)
        Me.Name = "frm_main"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Rtxt_Info As RichTextBox
    Friend WithEvents btn_Run As Button
End Class
