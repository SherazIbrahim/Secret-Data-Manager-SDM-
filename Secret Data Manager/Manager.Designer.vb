<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Manager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manager))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateDirectoryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddDirectoryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.ForeColor = System.Drawing.Color.Green
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(884, 451)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.StateImageList = Me.ImageList1
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "default-png-image-44513.png")
        Me.ImageList1.Images.SetKeyName(1, "folder_PNG8752.png")
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UseToolStripMenuItem, Me.BackToolStripMenuItem, Me.OpenToolStripMenuItem2, Me.CreateDirectoryToolStripMenuItem1, Me.AddDirectoryToolStripMenuItem1, Me.AddFileToolStripMenuItem, Me.DeleteToolStripMenuItem1, Me.HomeToolStripMenuItem, Me.CloseToolStripMenuItem2})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(160, 202)
        '
        'UseToolStripMenuItem
        '
        Me.UseToolStripMenuItem.Name = "UseToolStripMenuItem"
        Me.UseToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.UseToolStripMenuItem.Text = "Use"
        '
        'BackToolStripMenuItem
        '
        Me.BackToolStripMenuItem.Name = "BackToolStripMenuItem"
        Me.BackToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.BackToolStripMenuItem.Text = "Back"
        '
        'OpenToolStripMenuItem2
        '
        Me.OpenToolStripMenuItem2.Name = "OpenToolStripMenuItem2"
        Me.OpenToolStripMenuItem2.Size = New System.Drawing.Size(159, 22)
        Me.OpenToolStripMenuItem2.Text = "Open"
        '
        'CreateDirectoryToolStripMenuItem1
        '
        Me.CreateDirectoryToolStripMenuItem1.Name = "CreateDirectoryToolStripMenuItem1"
        Me.CreateDirectoryToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.CreateDirectoryToolStripMenuItem1.Text = "Create Directory"
        '
        'AddDirectoryToolStripMenuItem1
        '
        Me.AddDirectoryToolStripMenuItem1.Name = "AddDirectoryToolStripMenuItem1"
        Me.AddDirectoryToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.AddDirectoryToolStripMenuItem1.Text = "Add Directory"
        '
        'AddFileToolStripMenuItem
        '
        Me.AddFileToolStripMenuItem.Name = "AddFileToolStripMenuItem"
        Me.AddFileToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AddFileToolStripMenuItem.Text = "Add File"
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.DeleteToolStripMenuItem1.Text = "Delete"
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.HomeToolStripMenuItem.Text = "Home"
        '
        'CloseToolStripMenuItem2
        '
        Me.CloseToolStripMenuItem2.Name = "CloseToolStripMenuItem2"
        Me.CloseToolStripMenuItem2.Size = New System.Drawing.Size(159, 22)
        Me.CloseToolStripMenuItem2.Text = "Close"
        '
        'Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Blue
        Me.ClientSize = New System.Drawing.Size(884, 451)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListView1)
        Me.ForeColor = System.Drawing.Color.Green
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Manager"
        Me.Text = "Secure Your Secrets "
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents UseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents CreateDirectoryToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AddDirectoryToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AddFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem2 As ToolStripMenuItem
End Class
