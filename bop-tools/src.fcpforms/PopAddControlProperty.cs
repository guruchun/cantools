using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FcpForms;
using FcpTools;
using FcpUtils;

namespace FcpTools
{
    public partial class PopAddControlProperty : Form
    {
        public string name { get; set; }
        public string tag { get; set; }
        public string format { get; set; }
        public string text { get; set; }
        public Color bgColor{ get; set; }
        public Color foreColor{ get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int txtboxWidth { get; set; }
        public DataTable MemTable { get; }
        public TextBox Tbox { get; set; }
        public ControlPnIDTagView view { get; set; }

        public PopAddControlProperty()
        {

        }

        public PopAddControlProperty(DataTable memTable)
        {
            InitializeComponent();
            MemTable = memTable;
        }

        public PopAddControlProperty(TextBox tbox, DataTable memTable)
        {
            InitializeComponent();
            Tbox = tbox;
            MemTable = memTable;
        }

        public PopAddControlProperty(ControlPnIDTagView _view, DataTable _memTable)
        {
            InitializeComponent();
            view = _view;
            Tbox = view.textBox;
            MemTable = _memTable;
        }

        private void PopAddControlProperty_Load(object sender, EventArgs e)
        {
            // tbox
            if (Tbox != null && view == null)
            {
                Edit_Initialize(Tbox);
            }
            // view
            else if(Tbox != null && view != null)
            {
                View_Edit_Initialize(view);
            }
            // first
            else if(Tbox == null && view == null)
            {
                ComboBox_Initialize();
                Color_Initialize();
            }
        }

        #region inits
        private void ComboBox_Initialize()
        {
            foreach (DataRow Row in MemTable.Rows)
                cbTag.Items.Add(Row.ItemArray[0].ToString());
        }
        private void Color_Initialize()
        {
            txtBgColor.BackColor = Color.Gray;
            txtForeColor.BackColor = Color.Black;
        }
        private void View_ComboBox_Initalize()
        {
            foreach (DataRow row in MemTable.Rows)
            {
                cbTag.Items.Add(row.ItemArray[0].ToString());
            }
        }
        private void View_Color_Initialize()
        {
            txtBgColor.BackColor = Color.White;
            txtForeColor.BackColor = Color.Black;
        }
        #endregion

        #region Inits Textbox
        private void Edit_Initialize(TextBox tbox)
        {
            txtName.Name = tbox.Name;
            txtName.Text = "0.00";
            foreach (DataRow Row in MemTable.Rows)
                cbTag.Items.Add(Row.ItemArray[0].ToString());
            cbTag.SelectedItem = tbox.Tag;
            txtFormat.Text = "0.##";
            txtBgColor.BackColor = tbox.BackColor;
            txtForeColor.BackColor = tbox.ForeColor;
            txtWidth.Text = tbox.Width.ToString();
            txtHeight.Text = tbox.Height.ToString();
        }
        #endregion

        #region Inits view
        private void View_Edit_Initialize(ControlPnIDTagView _view)
        {
            txtName.Text = _view.title.Text;
            foreach (DataRow Row in MemTable.Rows)
                cbTag.Items.Add(Row.ItemArray[0].ToString());
            cbTag.SelectedItem = _view.TextBox_Tag;
            txtFormat.Text = "0.##";
            txtBgColor.BackColor = _view.BackColor;
            txtForeColor.BackColor = _view.ForeColor;
            txtWidth.Text = _view.Width.ToString();
            txtHeight.Text = _view.Height.ToString();
        }
        #endregion

        #region Btn Click Events
        // Btn Color Picker
        private void btnBgColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if(cd.ShowDialog() == DialogResult.OK)
            {
                bgColor = cd.Color;
                txtBgColor.BackColor = cd.Color;
            }
        }
        private void btnFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if(cd.ShowDialog() == DialogResult.OK)
            {
                foreColor = cd.Color;
                txtForeColor.BackColor = cd.Color;
            }
        }

        // Btn Confirm, Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbTag.SelectedIndex != -1)
                {
                    name = txtName.Text;
                    text = "0.00";
                    tag = cbTag.SelectedItem.ToString();
                    format = txtFormat.Text;
                    width = Convert.ToInt32(txtWidth.Text);
                    height = Convert.ToInt32(txtHeight.Text);
                    bgColor = txtBgColor.BackColor;
                    foreColor = txtForeColor.BackColor;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } 
                else
                {
                    MessageBox.Show("Tag는 필수 입력 란 입니다.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Tbox = null;
                view = null;
            }
        }
        #endregion
    }
}
