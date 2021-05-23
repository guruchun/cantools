namespace FcpSims
{
    partial class FormStart
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ApplyTcmCount = new System.Windows.Forms.Button();
            this.ApplyTCM = new System.Windows.Forms.Button();
            this.dgvTcmList = new System.Windows.Forms.DataGridView();
            this.tcmAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcmTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtTcmDelay = new System.Windows.Forms.TextBox();
            this.TxtTcmInterval = new System.Windows.Forms.TextBox();
            this.StartTCM = new System.Windows.Forms.Button();
            this.ConfigTCM = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TcmPort = new System.Windows.Forms.ComboBox();
            this.TxtTcmCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TcmMode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Inerter = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TxtInvDelay = new System.Windows.Forms.TextBox();
            this.TxtInvInterval = new System.Windows.Forms.TextBox();
            this.StartINV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ConfigINV = new System.Windows.Forms.Button();
            this.dgvInverter = new System.Windows.Forms.DataGridView();
            this.invReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvPort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InvSimMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnRefreshPort = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTcmList)).BeginInit();
            this.Inerter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInverter)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 755);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.Inerter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 714);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.ApplyTcmCount);
            this.groupBox1.Controls.Add(this.ApplyTCM);
            this.groupBox1.Controls.Add(this.dgvTcmList);
            this.groupBox1.Controls.Add(this.TxtTcmDelay);
            this.groupBox1.Controls.Add(this.TxtTcmInterval);
            this.groupBox1.Controls.Add(this.StartTCM);
            this.groupBox1.Controls.Add(this.ConfigTCM);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.TcmPort);
            this.groupBox1.Controls.Add(this.TxtTcmCount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TcmMode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(20, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 343);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TC Module";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(168, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(406, 21);
            this.textBox2.TabIndex = 140;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 12);
            this.label11.TabIndex = 139;
            this.label11.Text = "Modbus Map:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(48, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 163);
            this.pictureBox1.TabIndex = 138;
            this.pictureBox1.TabStop = false;
            // 
            // ApplyTcmCount
            // 
            this.ApplyTcmCount.Image = global::FcpSims.Properties.Resources.bullet_go;
            this.ApplyTcmCount.Location = new System.Drawing.Point(296, 90);
            this.ApplyTcmCount.Name = "ApplyTcmCount";
            this.ApplyTcmCount.Size = new System.Drawing.Size(29, 23);
            this.ApplyTcmCount.TabIndex = 137;
            this.ApplyTcmCount.UseVisualStyleBackColor = true;
            // 
            // ApplyTCM
            // 
            this.ApplyTCM.Location = new System.Drawing.Point(603, 90);
            this.ApplyTCM.Name = "ApplyTCM";
            this.ApplyTCM.Size = new System.Drawing.Size(115, 33);
            this.ApplyTCM.TabIndex = 136;
            this.ApplyTCM.Text = "Apply";
            this.ApplyTCM.UseVisualStyleBackColor = true;
            // 
            // dgvTcmList
            // 
            this.dgvTcmList.AllowUserToAddRows = false;
            this.dgvTcmList.AllowUserToDeleteRows = false;
            this.dgvTcmList.AllowUserToResizeRows = false;
            this.dgvTcmList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTcmList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTcmList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTcmList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTcmList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTcmList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tcmAddr,
            this.tcmTag});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTcmList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTcmList.Location = new System.Drawing.Point(371, 153);
            this.dgvTcmList.Name = "dgvTcmList";
            this.dgvTcmList.RowHeadersVisible = false;
            this.dgvTcmList.RowTemplate.Height = 23;
            this.dgvTcmList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTcmList.Size = new System.Drawing.Size(347, 163);
            this.dgvTcmList.TabIndex = 135;
            // 
            // tcmAddr
            // 
            this.tcmAddr.HeaderText = "Address";
            this.tcmAddr.Name = "tcmAddr";
            this.tcmAddr.ReadOnly = true;
            // 
            // tcmTag
            // 
            this.tcmTag.HeaderText = "Tag";
            this.tcmTag.Name = "tcmTag";
            // 
            // TxtTcmDelay
            // 
            this.TxtTcmDelay.Location = new System.Drawing.Point(475, 60);
            this.TxtTcmDelay.Name = "TxtTcmDelay";
            this.TxtTcmDelay.Size = new System.Drawing.Size(100, 21);
            this.TxtTcmDelay.TabIndex = 20;
            // 
            // TxtTcmInterval
            // 
            this.TxtTcmInterval.Location = new System.Drawing.Point(475, 32);
            this.TxtTcmInterval.Name = "TxtTcmInterval";
            this.TxtTcmInterval.Size = new System.Drawing.Size(100, 21);
            this.TxtTcmInterval.TabIndex = 19;
            // 
            // StartTCM
            // 
            this.StartTCM.Location = new System.Drawing.Point(603, 30);
            this.StartTCM.Name = "StartTCM";
            this.StartTCM.Size = new System.Drawing.Size(115, 51);
            this.StartTCM.TabIndex = 9;
            this.StartTCM.Text = "Start";
            this.StartTCM.UseVisualStyleBackColor = true;
            // 
            // ConfigTCM
            // 
            this.ConfigTCM.Image = global::FcpSims.Properties.Resources.cog;
            this.ConfigTCM.Location = new System.Drawing.Point(296, 60);
            this.ConfigTCM.Name = "ConfigTCM";
            this.ConfigTCM.Size = new System.Drawing.Size(29, 23);
            this.ConfigTCM.TabIndex = 18;
            this.ConfigTCM.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "  No. of TCM:";
            // 
            // TcmPort
            // 
            this.TcmPort.BackColor = System.Drawing.SystemColors.Window;
            this.TcmPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TcmPort.FormattingEnabled = true;
            this.TcmPort.Location = new System.Drawing.Point(169, 61);
            this.TcmPort.Name = "TcmPort";
            this.TcmPort.Size = new System.Drawing.Size(121, 20);
            this.TcmPort.TabIndex = 17;
            // 
            // TxtTcmCount
            // 
            this.TxtTcmCount.Location = new System.Drawing.Point(169, 90);
            this.TxtTcmCount.Name = "TxtTcmCount";
            this.TxtTcmCount.Size = new System.Drawing.Size(121, 21);
            this.TxtTcmCount.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(358, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Response Delay:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Serial Port: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "Polling Interval:";
            // 
            // TcmMode
            // 
            this.TcmMode.BackColor = System.Drawing.SystemColors.Window;
            this.TcmMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TcmMode.FormattingEnabled = true;
            this.TcmMode.Location = new System.Drawing.Point(169, 32);
            this.TcmMode.Name = "TcmMode";
            this.TcmMode.Size = new System.Drawing.Size(156, 20);
            this.TcmMode.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(83, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "Run Mode:";
            // 
            // Inerter
            // 
            this.Inerter.Controls.Add(this.textBox1);
            this.Inerter.Controls.Add(this.TxtInvDelay);
            this.Inerter.Controls.Add(this.TxtInvInterval);
            this.Inerter.Controls.Add(this.StartINV);
            this.Inerter.Controls.Add(this.button1);
            this.Inerter.Controls.Add(this.ConfigINV);
            this.Inerter.Controls.Add(this.dgvInverter);
            this.Inerter.Controls.Add(this.InvPort);
            this.Inerter.Controls.Add(this.label5);
            this.Inerter.Controls.Add(this.label1);
            this.Inerter.Controls.Add(this.label3);
            this.Inerter.Controls.Add(this.label4);
            this.Inerter.Controls.Add(this.InvSimMode);
            this.Inerter.Controls.Add(this.label2);
            this.Inerter.Location = new System.Drawing.Point(20, 4);
            this.Inerter.Name = "Inerter";
            this.Inerter.Size = new System.Drawing.Size(753, 269);
            this.Inerter.TabIndex = 1;
            this.Inerter.TabStop = false;
            this.Inerter.Text = "Inverter";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(406, 21);
            this.textBox1.TabIndex = 11;
            // 
            // TxtInvDelay
            // 
            this.TxtInvDelay.Location = new System.Drawing.Point(475, 45);
            this.TxtInvDelay.Name = "TxtInvDelay";
            this.TxtInvDelay.Size = new System.Drawing.Size(100, 21);
            this.TxtInvDelay.TabIndex = 11;
            // 
            // TxtInvInterval
            // 
            this.TxtInvInterval.Location = new System.Drawing.Point(475, 17);
            this.TxtInvInterval.Name = "TxtInvInterval";
            this.TxtInvInterval.Size = new System.Drawing.Size(100, 21);
            this.TxtInvInterval.TabIndex = 10;
            // 
            // StartINV
            // 
            this.StartINV.Location = new System.Drawing.Point(603, 17);
            this.StartINV.Name = "StartINV";
            this.StartINV.Size = new System.Drawing.Size(115, 49);
            this.StartINV.TabIndex = 9;
            this.StartINV.Text = "Start";
            this.StartINV.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 33);
            this.button1.TabIndex = 136;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ConfigINV
            // 
            this.ConfigINV.Image = global::FcpSims.Properties.Resources.cog;
            this.ConfigINV.Location = new System.Drawing.Point(296, 45);
            this.ConfigINV.Name = "ConfigINV";
            this.ConfigINV.Size = new System.Drawing.Size(29, 23);
            this.ConfigINV.TabIndex = 6;
            this.ConfigINV.UseVisualStyleBackColor = true;
            // 
            // dgvInverter
            // 
            this.dgvInverter.AllowUserToAddRows = false;
            this.dgvInverter.AllowUserToDeleteRows = false;
            this.dgvInverter.AllowUserToResizeRows = false;
            this.dgvInverter.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInverter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInverter.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInverter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInverter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInverter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invReg,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInverter.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInverter.Location = new System.Drawing.Point(371, 118);
            this.dgvInverter.Name = "dgvInverter";
            this.dgvInverter.RowHeadersVisible = false;
            this.dgvInverter.RowTemplate.Height = 23;
            this.dgvInverter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInverter.Size = new System.Drawing.Size(347, 133);
            this.dgvInverter.TabIndex = 135;
            // 
            // invReg
            // 
            this.invReg.HeaderText = "Register";
            this.invReg.Name = "invReg";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Address";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // InvPort
            // 
            this.InvPort.BackColor = System.Drawing.SystemColors.Window;
            this.InvPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InvPort.FormattingEnabled = true;
            this.InvPort.Location = new System.Drawing.Point(169, 46);
            this.InvPort.Name = "InvPort";
            this.InvPort.Size = new System.Drawing.Size(121, 20);
            this.InvPort.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Response Delay:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Modbus Map:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Serial Port: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Polling Interval:";
            // 
            // InvSimMode
            // 
            this.InvSimMode.BackColor = System.Drawing.SystemColors.Window;
            this.InvSimMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InvSimMode.FormattingEnabled = true;
            this.InvSimMode.Items.AddRange(new object[] {
            "Server(Slave)",
            "Client(Master)"});
            this.InvSimMode.Location = new System.Drawing.Point(169, 17);
            this.InvSimMode.Name = "InvSimMode";
            this.InvSimMode.Size = new System.Drawing.Size(156, 20);
            this.InvSimMode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Run Mode:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.BtnRefreshPort);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(794, 29);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // BtnRefreshPort
            // 
            this.BtnRefreshPort.Image = global::FcpSims.Properties.Resources.arrow_refresh_small;
            this.BtnRefreshPort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshPort.Location = new System.Drawing.Point(3, 3);
            this.BtnRefreshPort.Name = "BtnRefreshPort";
            this.BtnRefreshPort.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnRefreshPort.Size = new System.Drawing.Size(146, 23);
            this.BtnRefreshPort.TabIndex = 2;
            this.BtnRefreshPort.Text = "Refresh Ports";
            this.BtnRefreshPort.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 755);
            this.panel1.TabIndex = 1;
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 755);
            this.Controls.Add(this.panel1);
            this.Name = "FormStart";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTcmList)).EndInit();
            this.Inerter.ResumeLayout(false);
            this.Inerter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInverter)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtTcmDelay;
        private System.Windows.Forms.TextBox TxtTcmInterval;
        private System.Windows.Forms.Button StartTCM;
        private System.Windows.Forms.Button ConfigTCM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox TcmPort;
        private System.Windows.Forms.TextBox TxtTcmCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox TcmMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox Inerter;
        private System.Windows.Forms.TextBox TxtInvDelay;
        private System.Windows.Forms.TextBox TxtInvInterval;
        private System.Windows.Forms.Button StartINV;
        private System.Windows.Forms.Button ConfigINV;
        private System.Windows.Forms.ComboBox InvPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox InvSimMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button BtnRefreshPort;
        private System.Windows.Forms.Button ApplyTcmCount;
        private System.Windows.Forms.Button ApplyTCM;
        private System.Windows.Forms.DataGridView dgvTcmList;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcmAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcmTag;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvInverter;
        private System.Windows.Forms.DataGridViewTextBoxColumn invReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}