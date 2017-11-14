namespace SyslogSrv
{
    partial class Filter
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
            this.okButton = new System.Windows.Forms.Button();
            this.groupBoxFind = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wholeText = new System.Windows.Forms.CheckBox();
            this.regularExpression = new System.Windows.Forms.CheckBox();
            this.matchCase = new System.Windows.Forms.CheckBox();
            this.filterText = new System.Windows.Forms.TextBox();
            this.filterProperty = new System.Windows.Forms.ComboBox();
            this.groupBoxFind.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(290, 100);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // groupBoxFind
            // 
            this.groupBoxFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFind.Controls.Add(this.label2);
            this.groupBoxFind.Controls.Add(this.label1);
            this.groupBoxFind.Controls.Add(this.wholeText);
            this.groupBoxFind.Controls.Add(this.regularExpression);
            this.groupBoxFind.Controls.Add(this.matchCase);
            this.groupBoxFind.Controls.Add(this.filterText);
            this.groupBoxFind.Controls.Add(this.filterProperty);
            this.groupBoxFind.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFind.Name = "groupBoxFind";
            this.groupBoxFind.Size = new System.Drawing.Size(353, 82);
            this.groupBoxFind.TabIndex = 0;
            this.groupBoxFind.TabStop = false;
            this.groupBoxFind.Text = "Filter Lines";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "In field:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter:";
            // 
            // wholeText
            // 
            this.wholeText.AutoSize = true;
            this.wholeText.Location = new System.Drawing.Point(258, 47);
            this.wholeText.Name = "wholeText";
            this.wholeText.Size = new System.Drawing.Size(77, 17);
            this.wholeText.TabIndex = 6;
            this.wholeText.Text = "Whole text";
            this.wholeText.UseVisualStyleBackColor = true;
            this.wholeText.CheckedChanged += new System.EventHandler(this.filterText_TextChanged);
            // 
            // regularExpression
            // 
            this.regularExpression.AutoSize = true;
            this.regularExpression.Location = new System.Drawing.Point(132, 47);
            this.regularExpression.Name = "regularExpression";
            this.regularExpression.Size = new System.Drawing.Size(116, 17);
            this.regularExpression.TabIndex = 5;
            this.regularExpression.Text = "Regular expression";
            this.regularExpression.UseVisualStyleBackColor = true;
            this.regularExpression.CheckedChanged += new System.EventHandler(this.regularExpression_CheckedChanged);
            // 
            // matchCase
            // 
            this.matchCase.AutoSize = true;
            this.matchCase.Location = new System.Drawing.Point(258, 21);
            this.matchCase.Name = "matchCase";
            this.matchCase.Size = new System.Drawing.Size(82, 17);
            this.matchCase.TabIndex = 2;
            this.matchCase.Text = "Match case";
            this.matchCase.UseVisualStyleBackColor = true;
            this.matchCase.CheckedChanged += new System.EventHandler(this.filterText_TextChanged);
            // 
            // filterText
            // 
            this.filterText.Location = new System.Drawing.Point(53, 19);
            this.filterText.Name = "filterText";
            this.filterText.Size = new System.Drawing.Size(199, 20);
            this.filterText.TabIndex = 1;
            this.filterText.TextChanged += new System.EventHandler(this.filterText_TextChanged);
            // 
            // filterProperty
            // 
            this.filterProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterProperty.FormattingEnabled = true;
            this.filterProperty.Items.AddRange(new object[] {
            "IP",
            "Facility",
            "Severity",
            "Date",
            "Host",
            "Program",
            "Pid",
            "Message"});
            this.filterProperty.Location = new System.Drawing.Point(53, 45);
            this.filterProperty.Name = "filterProperty";
            this.filterProperty.Size = new System.Drawing.Size(73, 21);
            this.filterProperty.TabIndex = 4;
            this.filterProperty.SelectedIndexChanged += new System.EventHandler(this.filterText_TextChanged);
            // 
            // Filter
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(377, 135);
            this.Controls.Add(this.groupBoxFind);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter";
            this.groupBoxFind.ResumeLayout(false);
            this.groupBoxFind.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBoxFind;
        private System.Windows.Forms.ComboBox filterProperty;
        private System.Windows.Forms.TextBox filterText;
        private System.Windows.Forms.CheckBox matchCase;
        private System.Windows.Forms.CheckBox regularExpression;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox wholeText;
    }
}