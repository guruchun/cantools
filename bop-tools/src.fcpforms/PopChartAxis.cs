using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FcpTools;

namespace FcpTools
{
    public partial class PopChartAxis : Form
    {
        public double axisY_Max { get; set; }
        public double axisY_Min { get; set; }

        public double getAxisY_Max { get; set; }
        public double getAxisY_Min { get; set; }

        public PopChartAxis()
        {
            InitializeComponent();
        }

        private void PopChartAxis_Load(object sender, EventArgs e)
        {
            textBox_AxisYMax.Text = getAxisY_Max.ToString();
            textBox_AxisYMin.Text = getAxisY_Min.ToString();

            textBox_AxisYMax.Focus();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(textBox_AxisYMax.Text) <= double.Parse(textBox_AxisYMin.Text))
                {
                    MessageBox.Show("Min 값은 Max값보다 커야 합니다!");
                    return;
                }

                this.axisY_Max = double.Parse(this.textBox_AxisYMax.Text);
                this.axisY_Min = double.Parse(this.textBox_AxisYMin.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("값에는 반드시 숫자를 넣어 주세요.");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
