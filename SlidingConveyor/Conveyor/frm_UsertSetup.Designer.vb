<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_UsertSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_UsertSetup))
        Me.lbl_level = New System.Windows.Forms.Label()
        Me.lbl_Pass2 = New System.Windows.Forms.Label()
        Me.lbl_Pass1 = New System.Windows.Forms.Label()
        Me.lbl_SaveUser = New System.Windows.Forms.Label()
        Me.lbl_UpdatePass = New System.Windows.Forms.Label()
        Me.lbl_editPass = New System.Windows.Forms.Label()
        Me.lbl_deleteUser = New System.Windows.Forms.Label()
        Me.lbl_addUser = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmb_selectLevel = New System.Windows.Forms.ComboBox()
        Me.btn_New_User = New System.Windows.Forms.Button()
        Me.btn_Edit_User = New System.Windows.Forms.Button()
        Me.txt_Password = New System.Windows.Forms.TextBox()
        Me.txt_Username = New System.Windows.Forms.TextBox()
        Me.btn_Update_User = New System.Windows.Forms.Button()
        Me.btn_Delete_User = New System.Windows.Forms.Button()
        Me.btn_Insert_User = New System.Windows.Forms.Button()
        Me.btn_Exit_UserSetup = New System.Windows.Forms.Button()
        Me.grd_Data_Users = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_Data_Users, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_level
        '
        Me.lbl_level.AutoSize = True
        Me.lbl_level.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_level.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_level.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_level.Location = New System.Drawing.Point(256, 185)
        Me.lbl_level.Name = "lbl_level"
        Me.lbl_level.Size = New System.Drawing.Size(45, 13)
        Me.lbl_level.TabIndex = 99
        Me.lbl_level.Tag = "lbl"
        Me.lbl_level.Text = "LEVEL"
        '
        'lbl_Pass2
        '
        Me.lbl_Pass2.AutoSize = True
        Me.lbl_Pass2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_Pass2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Pass2.Location = New System.Drawing.Point(432, 83)
        Me.lbl_Pass2.Name = "lbl_Pass2"
        Me.lbl_Pass2.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Pass2.TabIndex = 98
        Me.lbl_Pass2.Tag = "lbl"
        Me.lbl_Pass2.Text = "Password"
        '
        'lbl_Pass1
        '
        Me.lbl_Pass1.AutoSize = True
        Me.lbl_Pass1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_Pass1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Pass1.Location = New System.Drawing.Point(302, 83)
        Me.lbl_Pass1.Name = "lbl_Pass1"
        Me.lbl_Pass1.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Pass1.TabIndex = 97
        Me.lbl_Pass1.Tag = "lbl"
        Me.lbl_Pass1.Text = "Password"
        '
        'lbl_SaveUser
        '
        Me.lbl_SaveUser.AutoSize = True
        Me.lbl_SaveUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_SaveUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_SaveUser.Location = New System.Drawing.Point(557, 70)
        Me.lbl_SaveUser.Name = "lbl_SaveUser"
        Me.lbl_SaveUser.Size = New System.Drawing.Size(57, 13)
        Me.lbl_SaveUser.TabIndex = 96
        Me.lbl_SaveUser.Tag = "lbl"
        Me.lbl_SaveUser.Text = "Save User"
        '
        'lbl_UpdatePass
        '
        Me.lbl_UpdatePass.AutoSize = True
        Me.lbl_UpdatePass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_UpdatePass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_UpdatePass.Location = New System.Drawing.Point(432, 70)
        Me.lbl_UpdatePass.Name = "lbl_UpdatePass"
        Me.lbl_UpdatePass.Size = New System.Drawing.Size(67, 13)
        Me.lbl_UpdatePass.TabIndex = 95
        Me.lbl_UpdatePass.Tag = "lbl"
        Me.lbl_UpdatePass.Text = "Update User"
        '
        'lbl_editPass
        '
        Me.lbl_editPass.AutoSize = True
        Me.lbl_editPass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_editPass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_editPass.Location = New System.Drawing.Point(302, 70)
        Me.lbl_editPass.Name = "lbl_editPass"
        Me.lbl_editPass.Size = New System.Drawing.Size(50, 13)
        Me.lbl_editPass.TabIndex = 94
        Me.lbl_editPass.Tag = "lbl"
        Me.lbl_editPass.Text = "Edit User"
        '
        'lbl_deleteUser
        '
        Me.lbl_deleteUser.AutoSize = True
        Me.lbl_deleteUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_deleteUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_deleteUser.Location = New System.Drawing.Point(159, 70)
        Me.lbl_deleteUser.Name = "lbl_deleteUser"
        Me.lbl_deleteUser.Size = New System.Drawing.Size(63, 13)
        Me.lbl_deleteUser.TabIndex = 93
        Me.lbl_deleteUser.Tag = "lbl"
        Me.lbl_deleteUser.Text = "Delete User"
        '
        'lbl_addUser
        '
        Me.lbl_addUser.AutoSize = True
        Me.lbl_addUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_addUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_addUser.Location = New System.Drawing.Point(35, 70)
        Me.lbl_addUser.Name = "lbl_addUser"
        Me.lbl_addUser.Size = New System.Drawing.Size(51, 13)
        Me.lbl_addUser.TabIndex = 92
        Me.lbl_addUser.Tag = "lbl"
        Me.lbl_addUser.Text = "Add User"
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(264, 145)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 26)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 91
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(264, 113)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        '
        'cmb_selectLevel
        '
        Me.cmb_selectLevel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_selectLevel.Enabled = False
        Me.cmb_selectLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmb_selectLevel.FormattingEnabled = True
        Me.cmb_selectLevel.Location = New System.Drawing.Point(317, 177)
        Me.cmb_selectLevel.Name = "cmb_selectLevel"
        Me.cmb_selectLevel.Size = New System.Drawing.Size(273, 28)
        Me.cmb_selectLevel.TabIndex = 82
        '
        'btn_New_User
        '
        Me.btn_New_User.BackgroundImage = CType(resources.GetObject("btn_New_User.BackgroundImage"), System.Drawing.Image)
        Me.btn_New_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_New_User.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_New_User.FlatAppearance.BorderSize = 0
        Me.btn_New_User.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_New_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_New_User.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_New_User.Location = New System.Drawing.Point(32, 12)
        Me.btn_New_User.Name = "btn_New_User"
        Me.btn_New_User.Size = New System.Drawing.Size(55, 55)
        Me.btn_New_User.TabIndex = 83
        Me.btn_New_User.UseVisualStyleBackColor = True
        '
        'btn_Edit_User
        '
        Me.btn_Edit_User.BackgroundImage = CType(resources.GetObject("btn_Edit_User.BackgroundImage"), System.Drawing.Image)
        Me.btn_Edit_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Edit_User.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_User.FlatAppearance.BorderSize = 0
        Me.btn_Edit_User.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_Edit_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Edit_User.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Edit_User.Location = New System.Drawing.Point(305, 12)
        Me.btn_Edit_User.Name = "btn_Edit_User"
        Me.btn_Edit_User.Size = New System.Drawing.Size(55, 55)
        Me.btn_Edit_User.TabIndex = 84
        Me.btn_Edit_User.UseVisualStyleBackColor = True
        '
        'txt_Password
        '
        Me.txt_Password.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txt_Password.Enabled = False
        Me.txt_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txt_Password.Location = New System.Drawing.Point(317, 145)
        Me.txt_Password.MaxLength = 10
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.Size = New System.Drawing.Size(273, 26)
        Me.txt_Password.TabIndex = 81
        '
        'txt_Username
        '
        Me.txt_Username.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Username.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txt_Username.Enabled = False
        Me.txt_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txt_Username.Location = New System.Drawing.Point(317, 113)
        Me.txt_Username.MaxLength = 50
        Me.txt_Username.Name = "txt_Username"
        Me.txt_Username.Size = New System.Drawing.Size(273, 26)
        Me.txt_Username.TabIndex = 80
        '
        'btn_Update_User
        '
        Me.btn_Update_User.BackgroundImage = CType(resources.GetObject("btn_Update_User.BackgroundImage"), System.Drawing.Image)
        Me.btn_Update_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Update_User.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Update_User.FlatAppearance.BorderSize = 0
        Me.btn_Update_User.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_Update_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Update_User.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Update_User.Location = New System.Drawing.Point(450, 12)
        Me.btn_Update_User.Name = "btn_Update_User"
        Me.btn_Update_User.Size = New System.Drawing.Size(55, 55)
        Me.btn_Update_User.TabIndex = 85
        Me.btn_Update_User.UseVisualStyleBackColor = True
        '
        'btn_Delete_User
        '
        Me.btn_Delete_User.BackgroundImage = CType(resources.GetObject("btn_Delete_User.BackgroundImage"), System.Drawing.Image)
        Me.btn_Delete_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Delete_User.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete_User.FlatAppearance.BorderSize = 0
        Me.btn_Delete_User.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_Delete_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Delete_User.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Delete_User.Location = New System.Drawing.Point(162, 12)
        Me.btn_Delete_User.Name = "btn_Delete_User"
        Me.btn_Delete_User.Size = New System.Drawing.Size(55, 55)
        Me.btn_Delete_User.TabIndex = 86
        Me.btn_Delete_User.UseVisualStyleBackColor = True
        '
        'btn_Insert_User
        '
        Me.btn_Insert_User.BackgroundImage = CType(resources.GetObject("btn_Insert_User.BackgroundImage"), System.Drawing.Image)
        Me.btn_Insert_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Insert_User.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Insert_User.FlatAppearance.BorderSize = 0
        Me.btn_Insert_User.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_Insert_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Insert_User.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Insert_User.Location = New System.Drawing.Point(560, 12)
        Me.btn_Insert_User.Name = "btn_Insert_User"
        Me.btn_Insert_User.Size = New System.Drawing.Size(55, 55)
        Me.btn_Insert_User.TabIndex = 88
        Me.btn_Insert_User.UseVisualStyleBackColor = True
        '
        'btn_Exit_UserSetup
        '
        Me.btn_Exit_UserSetup.BackgroundImage = CType(resources.GetObject("btn_Exit_UserSetup.BackgroundImage"), System.Drawing.Image)
        Me.btn_Exit_UserSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Exit_UserSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Exit_UserSetup.FlatAppearance.BorderSize = 0
        Me.btn_Exit_UserSetup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btn_Exit_UserSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit_UserSetup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Exit_UserSetup.Location = New System.Drawing.Point(570, 301)
        Me.btn_Exit_UserSetup.Name = "btn_Exit_UserSetup"
        Me.btn_Exit_UserSetup.Size = New System.Drawing.Size(69, 72)
        Me.btn_Exit_UserSetup.TabIndex = 89
        Me.btn_Exit_UserSetup.UseVisualStyleBackColor = True
        '
        'grd_Data_Users
        '
        Me.grd_Data_Users.AllowUserToAddRows = False
        Me.grd_Data_Users.AllowUserToDeleteRows = False
        Me.grd_Data_Users.AllowUserToResizeColumns = False
        Me.grd_Data_Users.AllowUserToResizeRows = False
        Me.grd_Data_Users.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grd_Data_Users.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.grd_Data_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Data_Users.Cursor = System.Windows.Forms.Cursors.Hand
        Me.grd_Data_Users.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd_Data_Users.Location = New System.Drawing.Point(13, 113)
        Me.grd_Data_Users.MultiSelect = False
        Me.grd_Data_Users.Name = "grd_Data_Users"
        Me.grd_Data_Users.RowHeadersVisible = False
        Me.grd_Data_Users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_Data_Users.Size = New System.Drawing.Size(215, 259)
        Me.grd_Data_Users.TabIndex = 87
        '
        'frm_UsertSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(653, 385)
        Me.Controls.Add(Me.lbl_level)
        Me.Controls.Add(Me.lbl_Pass2)
        Me.Controls.Add(Me.lbl_Pass1)
        Me.Controls.Add(Me.lbl_SaveUser)
        Me.Controls.Add(Me.lbl_UpdatePass)
        Me.Controls.Add(Me.lbl_editPass)
        Me.Controls.Add(Me.lbl_deleteUser)
        Me.Controls.Add(Me.lbl_addUser)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmb_selectLevel)
        Me.Controls.Add(Me.btn_New_User)
        Me.Controls.Add(Me.btn_Edit_User)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.txt_Username)
        Me.Controls.Add(Me.btn_Update_User)
        Me.Controls.Add(Me.btn_Delete_User)
        Me.Controls.Add(Me.btn_Insert_User)
        Me.Controls.Add(Me.btn_Exit_UserSetup)
        Me.Controls.Add(Me.grd_Data_Users)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(669, 424)
        Me.MinimumSize = New System.Drawing.Size(669, 424)
        Me.Name = "frm_UsertSetup"
        Me.Tag = "frm"
        Me.Text = "User Setup"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_Data_Users, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_level As Label
    Friend WithEvents lbl_Pass2 As Label
    Friend WithEvents lbl_Pass1 As Label
    Friend WithEvents lbl_SaveUser As Label
    Friend WithEvents lbl_UpdatePass As Label
    Friend WithEvents lbl_editPass As Label
    Friend WithEvents lbl_deleteUser As Label
    Friend WithEvents lbl_addUser As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cmb_selectLevel As ComboBox
    Friend WithEvents btn_New_User As Button
    Friend WithEvents btn_Edit_User As Button
    Friend WithEvents txt_Password As TextBox
    Friend WithEvents txt_Username As TextBox
    Friend WithEvents btn_Update_User As Button
    Friend WithEvents btn_Delete_User As Button
    Friend WithEvents btn_Insert_User As Button
    Friend WithEvents btn_Exit_UserSetup As Button
    Friend WithEvents grd_Data_Users As DataGridView
End Class
