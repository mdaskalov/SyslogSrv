namespace SyslogSrv
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSetDataGridView = new System.Windows.Forms.DataGridView();
            this.ipColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facilityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.severityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.severityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskbarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.taskbarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startTaskBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTaskBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreTaskBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitTaskBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileWatcher = new System.IO.FileSystemWatcher();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineSetDataGridView)).BeginInit();
            this.viewMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logLineBindingSource)).BeginInit();
            this.taskbarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 543);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(965, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Ready.";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(965, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.toolStripComboBox1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.startToolStripMenuItem.Text = "&Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.stopToolStripMenuItem.Text = "S&top";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(110, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lineSetDataGridView
            // 
            this.lineSetDataGridView.AllowUserToAddRows = false;
            this.lineSetDataGridView.AllowUserToDeleteRows = false;
            this.lineSetDataGridView.AllowUserToResizeRows = false;
            this.lineSetDataGridView.AutoGenerateColumns = false;
            this.lineSetDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lineSetDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lineSetDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.lineSetDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.lineSetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lineSetDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ipColumn,
            this.facilityColumn,
            this.severityColumn,
            this.dateColumn,
            this.hostColumn,
            this.programColumn,
            this.pidColumn,
            this.messageColumn});
            this.lineSetDataGridView.ContextMenuStrip = this.viewMenu;
            this.lineSetDataGridView.DataSource = this.logLineBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lineSetDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.lineSetDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineSetDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lineSetDataGridView.Location = new System.Drawing.Point(0, 24);
            this.lineSetDataGridView.Name = "lineSetDataGridView";
            this.lineSetDataGridView.ReadOnly = true;
            this.lineSetDataGridView.RowHeadersVisible = false;
            this.lineSetDataGridView.RowTemplate.Height = 16;
            this.lineSetDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lineSetDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lineSetDataGridView.Size = new System.Drawing.Size(965, 519);
            this.lineSetDataGridView.TabIndex = 0;
            // 
            // ipColumn
            // 
            this.ipColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ipColumn.DataPropertyName = "IP";
            this.ipColumn.HeaderText = "IP";
            this.ipColumn.Name = "ipColumn";
            this.ipColumn.ReadOnly = true;
            this.ipColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ipColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ipColumn.Visible = false;
            // 
            // facilityColumn
            // 
            this.facilityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.facilityColumn.DataPropertyName = "Facility";
            this.facilityColumn.HeaderText = "Facility";
            this.facilityColumn.Name = "facilityColumn";
            this.facilityColumn.ReadOnly = true;
            this.facilityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.facilityColumn.Visible = false;
            // 
            // severityColumn
            // 
            this.severityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.severityColumn.DataPropertyName = "Severity";
            this.severityColumn.HeaderText = "Severity";
            this.severityColumn.Name = "severityColumn";
            this.severityColumn.ReadOnly = true;
            this.severityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.severityColumn.Visible = false;
            // 
            // dateColumn
            // 
            this.dateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateColumn.DataPropertyName = "Date";
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            this.dateColumn.ReadOnly = true;
            this.dateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dateColumn.Visible = false;
            // 
            // hostColumn
            // 
            this.hostColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.hostColumn.DataPropertyName = "Host";
            this.hostColumn.HeaderText = "Host";
            this.hostColumn.Name = "hostColumn";
            this.hostColumn.ReadOnly = true;
            this.hostColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.hostColumn.Visible = false;
            // 
            // programColumn
            // 
            this.programColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.programColumn.DataPropertyName = "Program";
            this.programColumn.HeaderText = "Program";
            this.programColumn.Name = "programColumn";
            this.programColumn.ReadOnly = true;
            this.programColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.programColumn.Visible = false;
            // 
            // pidColumn
            // 
            this.pidColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pidColumn.DataPropertyName = "Pid";
            this.pidColumn.HeaderText = "Pid";
            this.pidColumn.Name = "pidColumn";
            this.pidColumn.ReadOnly = true;
            this.pidColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pidColumn.Visible = false;
            // 
            // messageColumn
            // 
            this.messageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.messageColumn.DataPropertyName = "Message";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.messageColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.messageColumn.HeaderText = "Message";
            this.messageColumn.Name = "messageColumn";
            this.messageColumn.ReadOnly = true;
            this.messageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.messageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // viewMenu
            // 
            this.viewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.toolStripSeparator1,
            this.ipToolStripMenuItem,
            this.facilityToolStripMenuItem,
            this.severityToolStripMenuItem,
            this.dateToolStripMenuItem,
            this.hostToolStripMenuItem,
            this.programToolStripMenuItem,
            this.pidToolStripMenuItem,
            this.toolStripSeparator2,
            this.filterToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.lockToolStripMenuItem});
            this.viewMenu.Name = "contextMenuStrip1";
            this.viewMenu.ShowCheckMargin = true;
            this.viewMenu.ShowImageMargin = false;
            this.viewMenu.Size = new System.Drawing.Size(150, 248);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // ipToolStripMenuItem
            // 
            this.ipToolStripMenuItem.CheckOnClick = true;
            this.ipToolStripMenuItem.Name = "ipToolStripMenuItem";
            this.ipToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.ipToolStripMenuItem.Text = "IP";
            this.ipToolStripMenuItem.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // facilityToolStripMenuItem
            // 
            this.facilityToolStripMenuItem.CheckOnClick = true;
            this.facilityToolStripMenuItem.Name = "facilityToolStripMenuItem";
            this.facilityToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.facilityToolStripMenuItem.Text = "Facility";
            this.facilityToolStripMenuItem.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // severityToolStripMenuItem
            // 
            this.severityToolStripMenuItem.CheckOnClick = true;
            this.severityToolStripMenuItem.Name = "severityToolStripMenuItem";
            this.severityToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.severityToolStripMenuItem.Text = "Severity";
            this.severityToolStripMenuItem.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.CheckOnClick = true;
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.dateToolStripMenuItem.Text = "Date";
            this.dateToolStripMenuItem.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // hostToolStripMenuItem
            // 
            this.hostToolStripMenuItem.CheckOnClick = true;
            this.hostToolStripMenuItem.Name = "hostToolStripMenuItem";
            this.hostToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.hostToolStripMenuItem.Text = "Host";
            this.hostToolStripMenuItem.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.CheckOnClick = true;
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.programToolStripMenuItem.Text = "Program";
            this.programToolStripMenuItem.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // pidToolStripMenuItem
            // 
            this.pidToolStripMenuItem.CheckOnClick = true;
            this.pidToolStripMenuItem.Name = "pidToolStripMenuItem";
            this.pidToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.pidToolStripMenuItem.Text = "Pid";
            this.pidToolStripMenuItem.Click += new System.EventHandler(this.viewMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(146, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(146, 6);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.CheckOnClick = true;
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.lockToolStripMenuItem.Text = "Lock";
            // 
            // logLineBindingSource
            // 
            this.logLineBindingSource.DataSource = typeof(SyslogSrv.LogLine);
            // 
            // taskbarIcon
            // 
            this.taskbarIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.taskbarIcon.BalloonTipText = "Here we go...";
            this.taskbarIcon.BalloonTipTitle = "Syslog Server";
            this.taskbarIcon.ContextMenuStrip = this.taskbarMenu;
            this.taskbarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskbarIcon.Icon")));
            this.taskbarIcon.Text = "Syslog Server";
            this.taskbarIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.taskbarIcon_MouseDoubleClick);
            // 
            // taskbarMenu
            // 
            this.taskbarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTaskBarMenuItem,
            this.stopTaskBarMenuItem,
            this.toolStripSeparator5,
            this.restoreTaskBarMenuItem,
            this.toolStripSeparator6,
            this.exitTaskBarMenuItem});
            this.taskbarMenu.Name = "taskbarMenu";
            this.taskbarMenu.ShowImageMargin = false;
            this.taskbarMenu.Size = new System.Drawing.Size(99, 104);
            // 
            // startTaskBarMenuItem
            // 
            this.startTaskBarMenuItem.Name = "startTaskBarMenuItem";
            this.startTaskBarMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startTaskBarMenuItem.Text = "Start";
            this.startTaskBarMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopTaskBarMenuItem
            // 
            this.stopTaskBarMenuItem.Enabled = false;
            this.stopTaskBarMenuItem.Name = "stopTaskBarMenuItem";
            this.stopTaskBarMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopTaskBarMenuItem.Text = "Stop";
            this.stopTaskBarMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(95, 6);
            // 
            // restoreTaskBarMenuItem
            // 
            this.restoreTaskBarMenuItem.Name = "restoreTaskBarMenuItem";
            this.restoreTaskBarMenuItem.Size = new System.Drawing.Size(98, 22);
            this.restoreTaskBarMenuItem.Text = "Restore";
            this.restoreTaskBarMenuItem.Click += new System.EventHandler(this.restoreTaskBarMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(95, 6);
            // 
            // exitTaskBarMenuItem
            // 
            this.exitTaskBarMenuItem.Name = "exitTaskBarMenuItem";
            this.exitTaskBarMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitTaskBarMenuItem.Text = "Exit";
            this.exitTaskBarMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fileWatcher
            // 
            this.fileWatcher.EnableRaisingEvents = true;
            this.fileWatcher.IncludeSubdirectories = true;
            this.fileWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileWatcher.SynchronizingObject = this;
            // 
            // fileDialog
            // 
            this.fileDialog.DefaultExt = "log";
            this.fileDialog.Filter = "LOG files|*.log|All files|*.*";
            this.fileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.fileDialog_FileOk);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 565);
            this.Controls.Add(this.lineSetDataGridView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "MainWindow";
            this.Text = "Syslog Server";
            this.Resize += new System.EventHandler(this.mainWindow_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineSetDataGridView)).EndInit();
            this.viewMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logLineBindingSource)).EndInit();
            this.taskbarMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripComboBox1;
        private System.Windows.Forms.DataGridView lineSetDataGridView;
        private System.Windows.Forms.ContextMenuStrip viewMenu;
        private System.Windows.Forms.ToolStripMenuItem severityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pidToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ipToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon taskbarIcon;
        private System.Windows.Forms.ContextMenuStrip taskbarMenu;
        private System.Windows.Forms.ToolStripMenuItem startTaskBarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTaskBarMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem restoreTaskBarMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem exitTaskBarMenuItem;
        private System.Windows.Forms.BindingSource logLineBindingSource;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.IO.FileSystemWatcher fileWatcher;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facilityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn severityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn programColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pidColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageColumn;
    }
}

