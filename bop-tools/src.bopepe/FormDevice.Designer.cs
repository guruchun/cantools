
namespace FcpTools
{
    partial class FormDevice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDevice));
            this.panelBase = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.dgvMeasureItems = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPortInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.portRefresh = new System.Windows.Forms.Button();
            this.btnReadVer = new System.Windows.Forms.Button();
            this.btnReadSN = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPortList = new System.Windows.Forms.ComboBox();
            this.panelMesg = new System.Windows.Forms.Panel();
            this.btnReadMeasure = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chkPeriodic = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.panelBase.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureItems)).BeginInit();
            this.panelSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelMesg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBase
            // 
            this.panelBase.AutoScroll = true;
            this.panelBase.AutoSize = true;
            this.panelBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBase.Controls.Add(this.tableLayoutPanel1);
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase.Location = new System.Drawing.Point(0, 0);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(798, 477);
            this.panelBase.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelPreview, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelSetting, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelMesg, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 477);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.dgvMeasureItems);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreview.Location = new System.Drawing.Point(3, 192);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(792, 282);
            this.panelPreview.TabIndex = 126;
            // 
            // dgvMeasureItems
            // 
            this.dgvMeasureItems.AllowUserToAddRows = false;
            this.dgvMeasureItems.AllowUserToDeleteRows = false;
            this.dgvMeasureItems.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvMeasureItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMeasureItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMeasureItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasureItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.Value,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
            this.dgvMeasureItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeasureItems.Location = new System.Drawing.Point(0, 0);
            this.dgvMeasureItems.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dgvMeasureItems.MultiSelect = false;
            this.dgvMeasureItems.Name = "dgvMeasureItems";
            this.dgvMeasureItems.ReadOnly = true;
            this.dgvMeasureItems.RowHeadersVisible = false;
            this.dgvMeasureItems.RowHeadersWidth = 51;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMeasureItems.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMeasureItems.RowTemplate.Height = 23;
            this.dgvMeasureItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeasureItems.Size = new System.Drawing.Size(792, 282);
            this.dgvMeasureItems.TabIndex = 76;
            // 
            // chk
            // 
            this.chk.HeaderText = " ";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.Width = 20;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Index";
            this.dataGridViewTextBoxColumn17.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 40;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Name";
            this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 60;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn19.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 80;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "Description";
            this.dataGridViewTextBoxColumn20.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 300;
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.groupBox1);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(10, 10);
            this.panelSetting.Margin = new System.Windows.Forms.Padding(10);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(778, 119);
            this.panelSetting.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPortInfo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtVersion);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSerialNum);
            this.groupBox1.Controls.Add(this.portRefresh);
            this.groupBox1.Controls.Add(this.btnReadVer);
            this.groupBox1.Controls.Add(this.btnReadSN);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPortList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 119);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // labelPortInfo
            // 
            this.labelPortInfo.AutoSize = true;
            this.labelPortInfo.Location = new System.Drawing.Point(213, 57);
            this.labelPortInfo.Name = "labelPortInfo";
            this.labelPortInfo.Size = new System.Drawing.Size(85, 15);
            this.labelPortInfo.TabIndex = 137;
            this.labelPortInfo.Text = "port open info";
            this.labelPortInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(348, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(10, 99);
            this.groupBox2.TabIndex = 136;
            this.groupBox2.TabStop = false;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(470, 82);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(127, 23);
            this.txtVersion.TabIndex = 130;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(470, 25);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(50, 23);
            this.txtAddress.TabIndex = 135;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 134;
            this.label5.Text = "Sensor Address:";
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Location = new System.Drawing.Point(470, 53);
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.ReadOnly = true;
            this.txtSerialNum.Size = new System.Drawing.Size(127, 23);
            this.txtSerialNum.TabIndex = 130;
            // 
            // portRefresh
            // 
            this.portRefresh.BackgroundImage = global::FcpTools.Properties.Resources.arrow_refresh_small;
            this.portRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.portRefresh.Location = new System.Drawing.Point(94, 27);
            this.portRefresh.Name = "portRefresh";
            this.portRefresh.Size = new System.Drawing.Size(25, 25);
            this.portRefresh.TabIndex = 118;
            this.portRefresh.UseVisualStyleBackColor = true;
            this.portRefresh.Click += new System.EventHandler(this.portRefresh_Click);
            // 
            // btnReadVer
            // 
            this.btnReadVer.Location = new System.Drawing.Point(603, 80);
            this.btnReadVer.Name = "btnReadVer";
            this.btnReadVer.Size = new System.Drawing.Size(82, 25);
            this.btnReadVer.TabIndex = 77;
            this.btnReadVer.Text = "Read";
            this.btnReadVer.UseVisualStyleBackColor = true;
            this.btnReadVer.Click += new System.EventHandler(this.btnReadVer_Click);
            // 
            // btnReadSN
            // 
            this.btnReadSN.Location = new System.Drawing.Point(603, 52);
            this.btnReadSN.Name = "btnReadSN";
            this.btnReadSN.Size = new System.Drawing.Size(82, 25);
            this.btnReadSN.TabIndex = 77;
            this.btnReadSN.Text = "Read";
            this.btnReadSN.UseVisualStyleBackColor = true;
            this.btnReadSN.Click += new System.EventHandler(this.btnReadSN_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(238, 27);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(82, 25);
            this.btnOpen.TabIndex = 77;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "F/W Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Sensor S/N:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "Serial Port:";
            // 
            // cbPortList
            // 
            this.cbPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortList.FormattingEnabled = true;
            this.cbPortList.Location = new System.Drawing.Point(120, 28);
            this.cbPortList.Name = "cbPortList";
            this.cbPortList.Size = new System.Drawing.Size(110, 23);
            this.cbPortList.TabIndex = 33;
            // 
            // panelMesg
            // 
            this.panelMesg.Controls.Add(this.btnReadMeasure);
            this.panelMesg.Controls.Add(this.label4);
            this.panelMesg.Controls.Add(this.chkPeriodic);
            this.panelMesg.Controls.Add(this.label6);
            this.panelMesg.Controls.Add(this.txtInterval);
            this.panelMesg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMesg.Location = new System.Drawing.Point(3, 142);
            this.panelMesg.Name = "panelMesg";
            this.panelMesg.Size = new System.Drawing.Size(792, 44);
            this.panelMesg.TabIndex = 12;
            // 
            // btnReadMeasure
            // 
            this.btnReadMeasure.Location = new System.Drawing.Point(245, 12);
            this.btnReadMeasure.Name = "btnReadMeasure";
            this.btnReadMeasure.Size = new System.Drawing.Size(82, 25);
            this.btnReadMeasure.TabIndex = 136;
            this.btnReadMeasure.Text = "Read";
            this.btnReadMeasure.UseVisualStyleBackColor = true;
            this.btnReadMeasure.Click += new System.EventHandler(this.btnReadMeasure_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 15);
            this.label4.TabIndex = 77;
            this.label4.Text = "Measurement Values (0xFF = invalid)";
            // 
            // chkPeriodic
            // 
            this.chkPeriodic.AutoSize = true;
            this.chkPeriodic.Location = new System.Drawing.Point(384, 16);
            this.chkPeriodic.Name = "chkPeriodic";
            this.chkPeriodic.Size = new System.Drawing.Size(151, 19);
            this.chkPeriodic.TabIndex = 120;
            this.chkPeriodic.Text = "Monitoring Periodically";
            this.chkPeriodic.UseVisualStyleBackColor = true;
            this.chkPeriodic.CheckedChanged += new System.EventHandler(this.chkPeriodic_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(607, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 131;
            this.label6.Text = "ms";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(554, 14);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(50, 23);
            this.txtInterval.TabIndex = 130;
            this.txtInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInterval_KeyUp);
            // 
            // FormDevice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(798, 477);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panelBase);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDevice";
            this.Text = "Settings && Status";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panelBase.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureItems)).EndInit();
            this.panelSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelMesg.ResumeLayout(false);
            this.panelMesg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPeriodic;
        private System.Windows.Forms.Button portRefresh;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPortList;
        private System.Windows.Forms.Panel panelMesg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.Button btnReadVer;
        private System.Windows.Forms.Button btnReadSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvMeasureItems;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelPortInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReadMeasure;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
    }
}