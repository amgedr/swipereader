namespace SwipeReader
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.downloadButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.deviceButton = new System.Windows.Forms.Button();
            this.syncButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.devicesDataGridView = new System.Windows.Forms.DataGridView();
            this.ipAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isLaborDeviceColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devicesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recordCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sDKVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataSyncTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.devicesDataGridView)).BeginInit();
            this.devicesContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "displayconfiguration.png");
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SwipeReader";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Image = ((System.Drawing.Image)(resources.GetObject("downloadButton.Image")));
            this.downloadButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.downloadButton.Location = new System.Drawing.Point(100, 439);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(82, 40);
            this.downloadButton.TabIndex = 5;
            this.downloadButton.Text = "Download";
            this.downloadButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTips.SetToolTip(this.downloadButton, "Download the attendance records on the device.");
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Image = ((System.Drawing.Image)(resources.GetObject("connectButton.Image")));
            this.connectButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.connectButton.Location = new System.Drawing.Point(12, 439);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(82, 40);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTips.SetToolTip(this.connectButton, "Connect to the card reader.");
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // deviceButton
            // 
            this.deviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceButton.Image = ((System.Drawing.Image)(resources.GetObject("deviceButton.Image")));
            this.deviceButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deviceButton.Location = new System.Drawing.Point(276, 439);
            this.deviceButton.Name = "deviceButton";
            this.deviceButton.Size = new System.Drawing.Size(82, 40);
            this.deviceButton.TabIndex = 7;
            this.deviceButton.Text = "Device";
            this.deviceButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTips.SetToolTip(this.deviceButton, "Manage the devices");
            this.deviceButton.UseVisualStyleBackColor = true;
            this.deviceButton.Click += new System.EventHandler(this.deviceButton_Click);
            // 
            // syncButton
            // 
            this.syncButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.syncButton.Image = ((System.Drawing.Image)(resources.GetObject("syncButton.Image")));
            this.syncButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.syncButton.Location = new System.Drawing.Point(188, 439);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(82, 40);
            this.syncButton.TabIndex = 6;
            this.syncButton.Text = "Sync";
            this.syncButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTips.SetToolTip(this.syncButton, "Synchronize user accounts with the server");
            this.syncButton.UseVisualStyleBackColor = true;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.settingsButton.Location = new System.Drawing.Point(364, 439);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(82, 40);
            this.settingsButton.TabIndex = 8;
            this.settingsButton.Text = "Settings";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // devicesDataGridView
            // 
            this.devicesDataGridView.AllowUserToAddRows = false;
            this.devicesDataGridView.AllowUserToDeleteRows = false;
            this.devicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ipAddressColumn,
            this.isLaborDeviceColumn,
            this.statusColumn,
            this.locationColumn});
            this.devicesDataGridView.ContextMenuStrip = this.devicesContextMenuStrip;
            this.devicesDataGridView.Location = new System.Drawing.Point(12, 49);
            this.devicesDataGridView.Name = "devicesDataGridView";
            this.devicesDataGridView.ReadOnly = true;
            this.devicesDataGridView.RowHeadersVisible = false;
            this.devicesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.devicesDataGridView.ShowEditingIcon = false;
            this.devicesDataGridView.Size = new System.Drawing.Size(434, 128);
            this.devicesDataGridView.TabIndex = 1;
            this.devicesDataGridView.TabStop = false;
            // 
            // ipAddressColumn
            // 
            this.ipAddressColumn.Frozen = true;
            this.ipAddressColumn.HeaderText = "IP Address";
            this.ipAddressColumn.Name = "ipAddressColumn";
            this.ipAddressColumn.ReadOnly = true;
            this.ipAddressColumn.Width = 90;
            // 
            // isLaborDeviceColumn
            // 
            this.isLaborDeviceColumn.HeaderText = "For Labors";
            this.isLaborDeviceColumn.Name = "isLaborDeviceColumn";
            this.isLaborDeviceColumn.ReadOnly = true;
            this.isLaborDeviceColumn.Width = 75;
            // 
            // statusColumn
            // 
            this.statusColumn.HeaderText = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            this.statusColumn.Width = 240;
            // 
            // locationColumn
            // 
            this.locationColumn.HeaderText = "Location";
            this.locationColumn.Name = "locationColumn";
            this.locationColumn.ReadOnly = true;
            this.locationColumn.Visible = false;
            // 
            // devicesContextMenuStrip
            // 
            this.devicesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordCountToolStripMenuItem,
            this.sDKVersionToolStripMenuItem});
            this.devicesContextMenuStrip.Name = "devicesContextMenuStrip";
            this.devicesContextMenuStrip.Size = new System.Drawing.Size(148, 48);
            // 
            // recordCountToolStripMenuItem
            // 
            this.recordCountToolStripMenuItem.Name = "recordCountToolStripMenuItem";
            this.recordCountToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.recordCountToolStripMenuItem.Text = "Record Count";
            this.recordCountToolStripMenuItem.Click += new System.EventHandler(this.recordCountToolStripMenuItem_Click);
            // 
            // sDKVersionToolStripMenuItem
            // 
            this.sDKVersionToolStripMenuItem.Name = "sDKVersionToolStripMenuItem";
            this.sDKVersionToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.sDKVersionToolStripMenuItem.Text = "SDK Version";
            this.sDKVersionToolStripMenuItem.Click += new System.EventHandler(this.sDKVersionToolStripMenuItem_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(12, 219);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(434, 205);
            this.statusTextBox.TabIndex = 3;
            this.statusTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "SwipeReader";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transactions:";
            // 
            // dataSyncTimer
            // 
            this.dataSyncTimer.Enabled = true;
            this.dataSyncTimer.Interval = 3000;
            this.dataSyncTimer.Tick += new System.EventHandler(this.dataSyncTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 491);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.devicesDataGridView);
            this.Controls.Add(this.deviceButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.syncButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.connectButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SwipeReader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.devicesDataGridView)).EndInit();
            this.devicesContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Button deviceButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView devicesDataGridView;
        private System.Windows.Forms.ContextMenuStrip devicesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem recordCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sDKVersionToolStripMenuItem;
        private System.Windows.Forms.Timer dataSyncTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isLaborDeviceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationColumn;
    }
}

