using FcpForms;
using FcpTools.Properties;
using FcpUtils;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace FcpTools
{
    public partial class MainForm : Form
    {
        //private bool m_bSaveLayout = true;
        private FormHelp m_help;

        private List<FormLog> m_viewLogs = new List<FormLog>();
        private static readonly ILog log = LogManager.GetLogger("Console");

        string[] formList;

        public MainForm()
        {
            log.Debug("initialize main form");
            InitializeComponent();
            log.Debug("main form components ok");
            InitializeLogView();
            log.Debug("main form layout ok");
            InitializeAppData();
            log.Debug("main form data initialized, start child forms");
            CreateDocuments();
            log.Debug("initialize main form -> OK");
        }

        #region Methods
        public DockPanel GetDockingPanel()
        {
            return dockPanel;
        }

        public void ShowHelp(string helpPage)
        {
            // help window is not valid --> create it
            if (m_help == null || m_help.IsDisposed) {
                m_help = new FormHelp();
                m_help.Show(dockPanel, new Rectangle(200, 200, 800, 600));
            }

            // get help page
            string pagePath = ConfigInfo.GetSettings().Properties["Help.Location"];
            if (ConfigInfo.GetSettings().Properties["Help.Source"] == "Online") {
                if (pagePath.Contains("10.120"))
                    pagePath += "bop-tool-epe-" + helpPage;   // FCP Redmine 서버에서 관리되는 Manual은 page naming이 다르다.
                else
                    pagePath += helpPage + ".md";
            } else {
                // TODO rendering local .md file to HTML (file://....)
            }

            // open a help page in the browser
            m_help.showHelp(pagePath);
        }

        private void InitializeLogView()
        {
            try {
                List<KeyValueType<string, string>> logs = ConfigInfo.GetSettings().LogViews;
                for (int i = 0; i < logs.Count; i++)
                    m_viewLogs.Add(new FormLog(logs[i].Key, logs[i].Value));
            }
            catch (Exception e) {
                log.Debug("can't initialize docking windows, " + e.Message);
            }
        }

        private void InitializeAppData()
        {
            ToolConfig cfg = ConfigInfo.GetSettings();

            // load tag initial values
            //SystemData.LoadTagValues(Application.StartupPath + "\\" + cfg.Properties["DataStore.InitialTags"]);
        }

        // TODO create more LRUs
        private void CreateDocuments()
        {
            try {
                formList = new string[] { "Device", "Chart" };

                int formCount = 0;
                DockContent temp;
                foreach (string f in formList) {
                    temp = CreateNewDocument(f);
                    if (temp == null)
                        continue;

                    temp.Show(dockPanel, DockState.Document);
                    //if (formCount % 2 == 0)
                    //    temp.Show(dockPanel, DockState.Document);
                    //else
                    //    temp.Show(dockPanel.Panes[0], DockAlignment.Right, 0.6);

                    formCount++;
                }

                // log view
                foreach (var f in m_viewLogs)
                    f.Show(dockPanel, DockState.DockBottom);
            }
            catch (Exception ex) {
                log.Error("fail to create doucment forms, " + ex.Message);
            }
        }

        private DockContent CreateNewDocument(String docName)
        {
            DockContent tempDoc;
            tempDoc = (DockContent)FindDocument(docName);
            if (tempDoc != null) {
                // already existed
                // TODO activated
                return (DockContent)tempDoc;
            }

            // create new doucment
            switch (docName) {
                case "Device":
                    tempDoc = new FormDevice();
                    break;
                case "Chart":
                    tempDoc = new FormChart();
                    break;
                default:
                    log.Error("not implemented form " + docName);
                    break;
            }

            // set HelpRequested handler
            if (tempDoc != null)
                tempDoc.HelpRequested += MainForm_HelpRequested;

            return tempDoc;
        }

        private IDockContent FindDocument(string text)
        {
            foreach (IDockContent content in dockPanel.Documents)
                if (content.DockHandler.TabText == text)
                    return content;

            return null;
        }

        #endregion

        #region Event Handlers


        //private IDockContent GetDockContent(string persistString)
        //{
        //    DeserializeDockContent deserializeDockContent = new DeserializeDockContent(GetDockContent);

        //    this.dockPanel.LoadFromXml("aa.xml", deserializeDockContent);

        //    switch (persistString)
        //    {
        //        case "FcpTools.FormSampler":
        //            return (DockContent)FindDocument(persistString);
        //    }
        //    return null;
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            try {
                //this.Text += " " + Application.ProductVersion;
                Version ver = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
                //this.Text += String.Format(" {0}.{1}.{2}", ver.Major, ver.Minor, ver.Revision);
                this.Text += String.Format(" {0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
                
                this.Width = int.Parse(ConfigInfo.GetSettings().Properties["Layout.Width"]);
                this.Height = int.Parse(ConfigInfo.GetSettings().Properties["Layout.Height"]);

                // create logfile directory
                string logPath = Application.StartupPath + "\\log";
                if (!Directory.Exists(logPath))
                    Directory.CreateDirectory(logPath);


                // 2020.10.27 sungjun DockBar
                foreach(Form str in Application.OpenForms)
                {
                    if (!(str is DockContent))
                        continue;
                    
                    if(((DockContent)str).DockState == DockState.Document)
                    {
                        ToolStripButton btn = new ToolStripButton();
                        btn.Image = str.Icon.ToBitmap();
                        btn.Name = str.Text;
                        btn.Text = str.Text;
                        btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                        toolStripDockBar.Items.Add(btn);
                    }
                }
            }
            catch (Exception ex) {
                log.Error("failed to initialize Main Form, " + ex.Message);
            }
        }



        // 2020.10.27 sungjun DockBar
        private void toolStripDockBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripButton btn = e.ClickedItem as ToolStripButton;

            DockContent tempDoc;
            tempDoc = (DockContent)FindDocument(btn.Text);

            if (tempDoc == null)
            {
                DockContent temp = CreateToolBarDocument(btn.Text);
                temp.Show(dockPanel, DockState.Document);
            }
            else
            {
                if (tempDoc.VisibleState != DockState.DockBottom)
                {
                    tempDoc.Hide();
                }
            }
        }

        private DockContent CreateToolBarDocument(String docName)
        {
            DockContent tempDoc;
            tempDoc = (DockContent)FindDocument(docName);
            if (tempDoc != null)
            {
                return (DockContent)tempDoc;
            }

            switch (docName)
            {
                case "Chart":
                    tempDoc = new FormChart();
                    break;
                case "Device":
                    tempDoc = new FormDevice();
                    break;
                default:
                    log.Error("not implemented form " + docName);
                    break;
            }
            if (tempDoc != null)
                tempDoc.HelpRequested += MainForm_HelpRequested;

            return tempDoc;
        }

        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpPage = null;
            if (sender is FormChart)
            {
                helpPage = "chart";
            }
            else if(sender is FormDevice)
            {
                helpPage = "device";
            }
            else
            {
                helpPage = "README";
            }

            if (String.IsNullOrEmpty(helpPage)) {
                log.Error("not defined help page for " + sender.GetType().Name);
                return;
            }

            ShowHelp(helpPage);
        }
        #endregion

    }
}