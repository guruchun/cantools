namespace FcpTools
{
    public partial class PopSerialPort
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.cbSpeed = new System.Windows.Forms.ComboBox();
            this.labelSpd = new System.Windows.Forms.Label();
            this.labelDb = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.labelStops = new System.Windows.Forms.Label();
            this.labelFlow = new System.Windows.Forms.Label();
            this.labelParity = new System.Windows.Forms.Label();
            this.cbFlowControl = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.cbDataBits, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.cbSpeed, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelSpd, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelDb, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.cbStopBits, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.cbParity, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.labelStops, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.labelFlow, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.labelParity, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.cbFlowControl, 1, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 8);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.22751F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.16402F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.80451F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(300, 189);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // cbDataBits
            // 
            this.cbDataBits.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(102, 30);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(116, 20);
            this.cbDataBits.TabIndex = 104;
            // 
            // cbSpeed
            // 
            this.cbSpeed.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeed.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSpeed.FormattingEnabled = true;
            this.cbSpeed.Location = new System.Drawing.Point(102, 3);
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.Size = new System.Drawing.Size(116, 20);
            this.cbSpeed.TabIndex = 103;
            // 
            // labelSpd
            // 
            this.labelSpd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSpd.Location = new System.Drawing.Point(7, 0);
            this.labelSpd.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelSpd.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelSpd.Name = "labelSpd";
            this.labelSpd.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.labelSpd.Size = new System.Drawing.Size(89, 16);
            this.labelSpd.TabIndex = 19;
            this.labelSpd.Text = "Baud rate:";
            this.labelSpd.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelDb
            // 
            this.labelDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDb.Location = new System.Drawing.Point(7, 27);
            this.labelDb.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelDb.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelDb.Name = "labelDb";
            this.labelDb.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.labelDb.Size = new System.Drawing.Size(89, 16);
            this.labelDb.TabIndex = 0;
            this.labelDb.Text = "Data bits:";
            this.labelDb.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Controls.Add(this.okButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(102, 149);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(195, 37);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(3, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 21);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(96, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 21);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cbStopBits
            // 
            this.cbStopBits.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(102, 57);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(116, 20);
            this.cbStopBits.TabIndex = 106;
            // 
            // cbParity
            // 
            this.cbParity.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(102, 82);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(116, 20);
            this.cbParity.TabIndex = 105;
            // 
            // labelStops
            // 
            this.labelStops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStops.Location = new System.Drawing.Point(7, 54);
            this.labelStops.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelStops.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelStops.Name = "labelStops";
            this.labelStops.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.labelStops.Size = new System.Drawing.Size(89, 16);
            this.labelStops.TabIndex = 22;
            this.labelStops.Text = "Stop bit:";
            this.labelStops.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelFlow
            // 
            this.labelFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFlow.Location = new System.Drawing.Point(7, 106);
            this.labelFlow.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelFlow.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelFlow.Name = "labelFlow";
            this.labelFlow.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.labelFlow.Size = new System.Drawing.Size(89, 16);
            this.labelFlow.TabIndex = 22;
            this.labelFlow.Text = "Flow control:";
            this.labelFlow.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelParity
            // 
            this.labelParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelParity.Location = new System.Drawing.Point(7, 79);
            this.labelParity.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelParity.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelParity.Name = "labelParity";
            this.labelParity.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.labelParity.Size = new System.Drawing.Size(89, 16);
            this.labelParity.TabIndex = 21;
            this.labelParity.Text = "Parity:";
            this.labelParity.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbFlowControl
            // 
            this.cbFlowControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFlowControl.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbFlowControl.FormattingEnabled = true;
            this.cbFlowControl.Location = new System.Drawing.Point(102, 109);
            this.cbFlowControl.Name = "cbFlowControl";
            this.cbFlowControl.Size = new System.Drawing.Size(116, 20);
            this.cbFlowControl.TabIndex = 107;
            // 
            // PopSerialPort
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 205);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopSerialPort";
            this.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Port Settings";
            this.Load += new System.EventHandler(this.PopSerialPort_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelSpd;
        private System.Windows.Forms.Label labelDb;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.Label labelStops;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label labelFlow;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox cbFlowControl;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.ComboBox cbSpeed;
    }
}
