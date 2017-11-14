namespace SyslogSrv
{
    partial class Configuration
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
            this.label1 = new System.Windows.Forms.Label();
            this.scrollBackLines = new System.Windows.Forms.TextBox();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.maxTcpClients = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcpPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.udpPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.enableTCP = new System.Windows.Forms.CheckBox();
            this.enableUDP = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "History lines:";
            // 
            // scrollBackLines
            // 
            this.scrollBackLines.Location = new System.Drawing.Point(120, 12);
            this.scrollBackLines.MaxLength = 4;
            this.scrollBackLines.Name = "scrollBackLines";
            this.scrollBackLines.Size = new System.Drawing.Size(40, 20);
            this.scrollBackLines.TabIndex = 0;
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.Location = new System.Drawing.Point(66, 121);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 2;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(147, 121);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // maxTcpClients
            // 
            this.maxTcpClients.Location = new System.Drawing.Point(120, 38);
            this.maxTcpClients.MaxLength = 2;
            this.maxTcpClients.Name = "maxTcpClients";
            this.maxTcpClients.Size = new System.Drawing.Size(20, 20);
            this.maxTcpClients.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max TCP clients:";
            // 
            // tcpPort
            // 
            this.tcpPort.Location = new System.Drawing.Point(120, 64);
            this.tcpPort.MaxLength = 4;
            this.tcpPort.Name = "tcpPort";
            this.tcpPort.Size = new System.Drawing.Size(40, 20);
            this.tcpPort.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TCP Port:";
            // 
            // udpPort
            // 
            this.udpPort.Location = new System.Drawing.Point(120, 90);
            this.udpPort.MaxLength = 4;
            this.udpPort.Name = "udpPort";
            this.udpPort.Size = new System.Drawing.Size(40, 20);
            this.udpPort.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "UDP Port:";
            // 
            // enableTCP
            // 
            this.enableTCP.AutoSize = true;
            this.enableTCP.Location = new System.Drawing.Point(166, 67);
            this.enableTCP.Name = "enableTCP";
            this.enableTCP.Size = new System.Drawing.Size(58, 17);
            this.enableTCP.TabIndex = 9;
            this.enableTCP.Text = "enable";
            this.enableTCP.UseVisualStyleBackColor = true;
            this.enableTCP.CheckedChanged += new System.EventHandler(this.enableTCP_CheckedChanged);
            // 
            // enableUDP
            // 
            this.enableUDP.AutoSize = true;
            this.enableUDP.Location = new System.Drawing.Point(166, 93);
            this.enableUDP.Name = "enableUDP";
            this.enableUDP.Size = new System.Drawing.Size(58, 17);
            this.enableUDP.TabIndex = 10;
            this.enableUDP.Text = "enable";
            this.enableUDP.UseVisualStyleBackColor = true;
            this.enableUDP.CheckedChanged += new System.EventHandler(this.enableUDP_CheckedChanged);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 156);
            this.Controls.Add(this.enableUDP);
            this.Controls.Add(this.enableTCP);
            this.Controls.Add(this.udpPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tcpPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxTcpClients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.scrollBackLines);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Configuration";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scrollBackLines;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.TextBox maxTcpClients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tcpPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox udpPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox enableTCP;
        private System.Windows.Forms.CheckBox enableUDP;
    }
}