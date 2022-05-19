<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Login
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Login))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_Cancel_Login = New System.Windows.Forms.Button()
        Me.btn_OK_Login = New System.Windows.Forms.Button()
        Me.txt_Password = New System.Windows.Forms.TextBox()
        Me.ComboIcon1 = New Conveyor.ComboIcon()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(163, 142)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 25
        Me.PictureBox1.TabStop = False
        '
        'btn_Cancel_Login
        '
        Me.btn_Cancel_Login.BackColor = System.Drawing.Color.Transparent
        Me.btn_Cancel_Login.BackgroundImage = CType(resources.GetObject("btn_Cancel_Login.BackgroundImage"), System.Drawing.Image)
        Me.btn_Cancel_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Cancel_Login.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel_Login.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cancel_Login.FlatAppearance.BorderSize = 0
        Me.btn_Cancel_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Cancel_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cancel_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Cancel_Login.Location = New System.Drawing.Point(536, 139)
        Me.btn_Cancel_Login.Name = "btn_Cancel_Login"
        Me.btn_Cancel_Login.Size = New System.Drawing.Size(50, 50)
        Me.btn_Cancel_Login.TabIndex = 23
        Me.btn_Cancel_Login.UseVisualStyleBackColor = False
        '
        'btn_OK_Login
        '
        Me.btn_OK_Login.BackColor = System.Drawing.Color.Transparent
        Me.btn_OK_Login.BackgroundImage = CType(resources.GetObject("btn_OK_Login.BackgroundImage"), System.Drawing.Image)
        Me.btn_OK_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_OK_Login.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_OK_Login.FlatAppearance.BorderSize = 0
        Me.btn_OK_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen
        Me.btn_OK_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_OK_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_OK_Login.Location = New System.Drawing.Point(469, 139)
        Me.btn_OK_Login.Name = "btn_OK_Login"
        Me.btn_OK_Login.Size = New System.Drawing.Size(50, 50)
        Me.btn_OK_Login.TabIndex = 22
        Me.btn_OK_Login.UseVisualStyleBackColor = False
        '
        'txt_Password
        '
        Me.txt_Password.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txt_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!)
        Me.txt_Password.Location = New System.Drawing.Point(245, 142)
        Me.txt_Password.MaxLength = 10
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.Size = New System.Drawing.Size(210, 47)
        Me.txt_Password.TabIndex = 21
        '
        'ComboIcon1
        '
        Me.ComboIcon1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ComboIcon1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboIcon1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboIcon1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.ComboIcon1.FormattingEnabled = True
        Me.ComboIcon1.Location = New System.Drawing.Point(28, 12)
        Me.ComboIcon1.Name = "ComboIcon1"
        Me.ComboIcon1.Size = New System.Drawing.Size(152, 32)
        Me.ComboIcon1.TabIndex = 26
        '
        'frm_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(808, 226)
        Me.Controls.Add(Me.ComboIcon1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_Cancel_Login)
        Me.Controls.Add(Me.btn_OK_Login)
        Me.Controls.Add(Me.txt_Password)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(824, 265)
        Me.MinimumSize = New System.Drawing.Size(824, 265)
        Me.Name = "frm_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frm"
        Me.Text = "Sliding Conveyor - LOGIN"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_Cancel_Login As Button
    Friend WithEvents btn_OK_Login As Button
    Friend WithEvents txt_Password As TextBox
    Friend WithEvents ComboIcon1 As ComboIcon
End Class
