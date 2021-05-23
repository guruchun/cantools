using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FcpTools
{
    public partial class ControlPnIDTagView : UserControl
    {
        [Category("TextBox_Text"), Description("컨트롤 TextBox에 들어갈 Text 속성입니다.")]
        public string TextBox_Text
        {
            get
            {
                return this.txtbox.Text;
            }
            set
            {
                this.txtbox.Text = value;
            }
        }

        [Category("TextBox_Tag"), Description("컨트롤 TextBox에 사용할 Tag에 속성입니다.")]
        public object TextBox_Tag
        {
            get
            {
                return this.txtbox.Tag;
            }
            set
            {
                this.txtbox.Tag = value;
            }
        }

        [Category("TextBox_Width"), Description("컨트롤 TextBox에 사용할 Width 속성입니다.")]
        public int TextBox_Width
        {
            get
            {
                return this.txtbox.Width;
            }
            set
            {
                this.txtbox.Width = value;
            }
        }

        [Category("TextBox_Height"), Description("컨트롤 TextBox에 사용할 Height 속성입니다.")]
        public int TextBox_Height
        {
            get
            {
                return this.txtbox.Height;
            }
            set
            {
                this.txtbox.Height = value;
            }
        }

        [Category("TextBox_BgColor"), Description("컨트롤 TextBox에 사용할 BackGroundColor 속성입니다.")]
        public Color TextBox_BgColor
        {
            get
            {
                return this.txtbox.BackColor;
            }
            set
            {
                this.txtbox.BackColor = value;
            }
        }
        [Category("TextBox_ForeColor"), Description("컨트롤 TextBox에 사용할 ForeColor 속성입니다.")]
        public Color TextBox_ForeColor
        {
            get
            {
                return this.txtbox.ForeColor;
            }
            set
            {
                this.txtbox.ForeColor = value;
            }
        }
        
        [Category("Label_Text"), Description("컨트롤 Label에 들어갈 Text 속성입니다.")]
        public string Label_Text
        {
            get
            {
                return this.label.Text;
            }
            set
            {
                this.label.Text = value;
            }
        }
        [Category("Label_BgColor"), Description("컨트롤 Label에 사용할 BackGroundColor 속성입니다.")]
        public Color Label_BgColor
        {
            get
            {
                return this.txtbox.BackColor;
            }
            set
            {
                this.txtbox.BackColor = value;
            }
        }
        [Category("Label_ForeColor"), Description("컨트롤 Label에 사용할 ForeColor 속성입니다.")]
        public Color Label_ForeColor
        {
            get
            {
                return this.txtbox.ForeColor;
            }
            set
            {
                this.txtbox.ForeColor = value;
            }
        }
        [Category("MoveLock"), Description("해당 컨트롤의 이동 할 것인지 정합니다.")]
        public bool Moved { get; set; }

        [Category("TextBox"), Description("해당 컨트롤의 포함된 텍스트 박스 입니다.")]
        public TextBox textBox {
            get
            {
                return this.txtbox;
            }
            set
            {
                this.txtbox = value;
            }
        }

        [Category("Title"), Description("해당 컨트롤의 포함된 제목 라벨 입니다.")]
        public Label title
        {
            get
            {
                return this.label;
            }
            set
            {
                this.label = value;
            }
        }

        public ControlPnIDTagView()
        {
            InitializeComponent();
        }

        private void ControlPnIDTagView_Load(object sender, EventArgs e)
        {

        }
    }
}
