<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Statistics
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Statistics))
        Me.grd_statistic = New System.Windows.Forms.DataGridView()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_FinishDate = New System.Windows.Forms.DateTimePicker()
        Me.cmb_type = New System.Windows.Forms.ComboBox()
        Me.btn_Filter = New System.Windows.Forms.Button()
        Me.btn_ExportToExcel = New System.Windows.Forms.Button()
        Me.lbl_StartedDate = New System.Windows.Forms.Label()
        Me.lbl_FinishedDate = New System.Windows.Forms.Label()
        Me.lbl_Type = New System.Windows.Forms.Label()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        CType(Me.grd_statistic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grd_statistic
        '
        Me.grd_statistic.AllowUserToAddRows = False
        Me.grd_statistic.AllowUserToDeleteRows = False
        Me.grd_statistic.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.grd_statistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_statistic.Location = New System.Drawing.Point(25, 26)
        Me.grd_statistic.MultiSelect = False
        Me.grd_statistic.Name = "grd_statistic"
        Me.grd_statistic.ReadOnly = True
        Me.grd_statistic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_statistic.Size = New System.Drawing.Size(661, 368)
        Me.grd_statistic.TabIndex = 0
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_StartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtp_StartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_StartDate.Location = New System.Drawing.Point(833, 19)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(121, 29)
        Me.dtp_StartDate.TabIndex = 1
        '
        'dtp_FinishDate
        '
        Me.dtp_FinishDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_FinishDate.CustomFormat = "yyyy-MM-dd"
        Me.dtp_FinishDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.dtp_FinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_FinishDate.Location = New System.Drawing.Point(833, 54)
        Me.dtp_FinishDate.Name = "dtp_FinishDate"
        Me.dtp_FinishDate.Size = New System.Drawing.Size(121, 29)
        Me.dtp_FinishDate.TabIndex = 2
        '
        'cmb_type
        '
        Me.cmb_type.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.cmb_type.FormattingEnabled = True
        Me.cmb_type.Items.AddRange(New Object() {"Select Item", "Operator", "System", "Production"})
        Me.cmb_type.Location = New System.Drawing.Point(833, 89)
        Me.cmb_type.Name = "cmb_type"
        Me.cmb_type.Size = New System.Drawing.Size(121, 32)
        Me.cmb_type.TabIndex = 3
        '
        'btn_Filter
        '
        Me.btn_Filter.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_Filter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Filter.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_Filter.FlatAppearance.BorderSize = 3
        Me.btn_Filter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.btn_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Filter.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_Filter.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_Filter.Location = New System.Drawing.Point(844, 154)
        Me.btn_Filter.Name = "btn_Filter"
        Me.btn_Filter.Size = New System.Drawing.Size(110, 50)
        Me.btn_Filter.TabIndex = 4
        Me.btn_Filter.Tag = "btn"
        Me.btn_Filter.Text = "FILTER"
        Me.btn_Filter.UseVisualStyleBackColor = False
        '
        'btn_ExportToExcel
        '
        Me.btn_ExportToExcel.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_ExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ExportToExcel.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_ExportToExcel.FlatAppearance.BorderSize = 3
        Me.btn_ExportToExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed
        Me.btn_ExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ExportToExcel.Font = New System.Drawing.Font("Palatino Linotype", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_ExportToExcel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_ExportToExcel.Location = New System.Drawing.Point(703, 154)
        Me.btn_ExportToExcel.Name = "btn_ExportToExcel"
        Me.btn_ExportToExcel.Size = New System.Drawing.Size(110, 50)
        Me.btn_ExportToExcel.TabIndex = 6
        Me.btn_ExportToExcel.Tag = "btn"
        Me.btn_ExportToExcel.Text = "EXCEL"
        Me.btn_ExportToExcel.UseVisualStyleBackColor = False
        '
        'lbl_StartedDate
        '
        Me.lbl_StartedDate.AutoSize = True
        Me.lbl_StartedDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_StartedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lbl_StartedDate.Location = New System.Drawing.Point(696, 28)
        Me.lbl_StartedDate.Name = "lbl_StartedDate"
        Me.lbl_StartedDate.Size = New System.Drawing.Size(109, 20)
        Me.lbl_StartedDate.TabIndex = 7
        Me.lbl_StartedDate.Tag = "lbl"
        Me.lbl_StartedDate.Text = "Started Date :"
        '
        'lbl_FinishedDate
        '
        Me.lbl_FinishedDate.AutoSize = True
        Me.lbl_FinishedDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_FinishedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_FinishedDate.Location = New System.Drawing.Point(689, 61)
        Me.lbl_FinishedDate.Name = "lbl_FinishedDate"
        Me.lbl_FinishedDate.Size = New System.Drawing.Size(116, 20)
        Me.lbl_FinishedDate.TabIndex = 8
        Me.lbl_FinishedDate.Tag = "lbl"
        Me.lbl_FinishedDate.Text = "Finished Date :"
        '
        'lbl_Type
        '
        Me.lbl_Type.AutoSize = True
        Me.lbl_Type.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_Type.Location = New System.Drawing.Point(754, 94)
        Me.lbl_Type.Name = "lbl_Type"
        Me.lbl_Type.Size = New System.Drawing.Size(51, 20)
        Me.lbl_Type.TabIndex = 9
        Me.lbl_Type.Tag = "lbl"
        Me.lbl_Type.Text = "Type :"
        '
        'btn_Exit
        '
        Me.btn_Exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Exit.BackColor = System.Drawing.Color.MidnightBlue
        Me.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Exit.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btn_Exit.FlatAppearance.BorderSize = 3
        Me.btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.btn_Exit.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_Exit.Location = New System.Drawing.Point(844, 344)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(110, 50)
        Me.btn_Exit.TabIndex = 34
        Me.btn_Exit.Tag = "btn"
        Me.btn_Exit.Text = "EXIT"
        Me.btn_Exit.UseVisualStyleBackColor = False
        '
        'frm_Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(994, 417)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.lbl_Type)
        Me.Controls.Add(Me.lbl_FinishedDate)
        Me.Controls.Add(Me.lbl_StartedDate)
        Me.Controls.Add(Me.btn_ExportToExcel)
        Me.Controls.Add(Me.btn_Filter)
        Me.Controls.Add(Me.cmb_type)
        Me.Controls.Add(Me.dtp_FinishDate)
        Me.Controls.Add(Me.dtp_StartDate)
        Me.Controls.Add(Me.grd_statistic)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1010, 456)
        Me.MinimumSize = New System.Drawing.Size(1010, 456)
        Me.Name = "frm_Statistics"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frm"
        Me.Text = "Statistics"
        CType(Me.grd_statistic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grd_statistic As DataGridView
    Friend WithEvents dtp_StartDate As DateTimePicker
    Friend WithEvents dtp_FinishDate As DateTimePicker
    Friend WithEvents cmb_type As ComboBox
    Friend WithEvents btn_Filter As Button
    Friend WithEvents btn_ExportToExcel As Button
    Friend WithEvents lbl_StartedDate As Label
    Friend WithEvents lbl_FinishedDate As Label
    Friend WithEvents lbl_Type As Label
    Friend WithEvents btn_Exit As Button
    Friend WithEvents SFD As SaveFileDialog
End Class
