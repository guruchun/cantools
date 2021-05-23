namespace FcpSims
{
    partial class FormInverter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBase = new System.Windows.Forms.Panel();
            this.tableLayoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LbMenu = new System.Windows.Forms.Label();
            this.BtnRefreshPort = new System.Windows.Forms.Button();
            this.CbPortList = new System.Windows.Forms.ComboBox();
            this.BtnConfigPort = new System.Windows.Forms.Button();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnRequest = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DgvSysData = new System.Windows.Forms.DataGridView();
            this.panelBase.SuspendLayout();
            this.tableLayoutBase.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSysData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBase
            // 
            this.panelBase.AutoScroll = true;
            this.panelBase.AutoSize = true;
            this.panelBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBase.Controls.Add(this.tableLayoutBase);
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase.Location = new System.Drawing.Point(0, 0);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(971, 577);
            this.panelBase.TabIndex = 9;
            // 
            // tableLayoutBase
            // 
            this.tableLayoutBase.ColumnCount = 1;
            this.tableLayoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBase.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutBase.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBase.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutBase.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBase.Name = "tableLayoutBase";
            this.tableLayoutBase.RowCount = 2;
            this.tableLayoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBase.Size = new System.Drawing.Size(971, 577);
            this.tableLayoutBase.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.LbMenu);
            this.flowLayoutPanel1.Controls.Add(this.BtnRefreshPort);
            this.flowLayoutPanel1.Controls.Add(this.CbPortList);
            this.flowLayoutPanel1.Controls.Add(this.BtnConfigPort);
            this.flowLayoutPanel1.Controls.Add(this.BtnOpen);
            this.flowLayoutPanel1.Controls.Add(this.BtnRequest);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(965, 29);
            this.flowLayoutPanel1.TabIndex = 81;
            // 
            // LbMenu
            // 
            this.LbMenu.AutoSize = true;
            this.LbMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbMenu.Location = new System.Drawing.Point(3, 0);
            this.LbMenu.Name = "LbMenu";
            this.LbMenu.Size = new System.Drawing.Size(121, 29);
            this.LbMenu.TabIndex = 121;
            this.LbMenu.Text = "Serial Port (RS-485):";
            this.LbMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnRefreshPort
            // 
            this.BtnRefreshPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnRefreshPort.Image = global::FcpSims.Properties.Resources.arrow_refresh_small;
            this.BtnRefreshPort.Location = new System.Drawing.Point(130, 3);
            this.BtnRefreshPort.Name = "BtnRefreshPort";
            this.BtnRefreshPort.Size = new System.Drawing.Size(29, 23);
            this.BtnRefreshPort.TabIndex = 124;
            this.BtnRefreshPort.UseVisualStyleBackColor = true;
            this.BtnRefreshPort.Click += new System.EventHandler(this.BtnRefreshPort_Click);
            // 
            // CbPortList
            // 
            this.CbPortList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPortList.FormattingEnabled = true;
            this.CbPortList.Location = new System.Drawing.Point(165, 4);
            this.CbPortList.Name = "CbPortList";
            this.CbPortList.Size = new System.Drawing.Size(114, 20);
            this.CbPortList.TabIndex = 120;
            // 
            // BtnConfigPort
            // 
            this.BtnConfigPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnConfigPort.Image = global::FcpSims.Properties.Resources.cog;
            this.BtnConfigPort.Location = new System.Drawing.Point(285, 3);
            this.BtnConfigPort.Name = "BtnConfigPort";
            this.BtnConfigPort.Size = new System.Drawing.Size(29, 23);
            this.BtnConfigPort.TabIndex = 123;
            this.BtnConfigPort.UseVisualStyleBackColor = true;
            this.BtnConfigPort.Click += new System.EventHandler(this.BtnConfigPort_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(320, 3);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(110, 23);
            this.BtnOpen.TabIndex = 122;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnRequest
            // 
            this.BtnRequest.Location = new System.Drawing.Point(436, 3);
            this.BtnRequest.Name = "BtnRequest";
            this.BtnRequest.Size = new System.Drawing.Size(75, 23);
            this.BtnRequest.TabIndex = 125;
            this.BtnRequest.Text = "Request";
            this.BtnRequest.UseVisualStyleBackColor = true;
            this.BtnRequest.Click += new System.EventHandler(this.btn_Request_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DgvSysData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 536);
            this.panel1.TabIndex = 82;
            // 
            // DgvSysData
            // 
            this.DgvSysData.AllowUserToAddRows = false;
            this.DgvSysData.AllowUserToDeleteRows = false;
            this.DgvSysData.AllowUserToResizeRows = false;
            this.DgvSysData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvSysData.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DgvSysData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvSysData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DgvSysData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSysData.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvSysData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSysData.Location = new System.Drawing.Point(0, 0);
            this.DgvSysData.Name = "DgvSysData";
            this.DgvSysData.ReadOnly = true;
            this.DgvSysData.RowHeadersVisible = false;
            this.DgvSysData.RowTemplate.Height = 23;
            this.DgvSysData.Size = new System.Drawing.Size(965, 536);
            this.DgvSysData.TabIndex = 79;
            // 
            // FormInverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 577);
            this.Controls.Add(this.panelBase);
            this.Name = "FormInverter";
            this.Text = "Inverter";
            this.Load += new System.EventHandler(this.FormInverter_Load);
            this.panelBase.ResumeLayout(false);
            this.tableLayoutBase.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSysData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBase;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label LbMenu;
        private System.Windows.Forms.Button BtnRefreshPort;
        private System.Windows.Forms.Button BtnConfigPort;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.ComboBox CbPortList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvSysData;
        private System.Windows.Forms.Button BtnRequest;
    }
}