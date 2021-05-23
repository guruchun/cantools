using System;
using System.Windows.Forms;
//using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.Docking;

namespace FcpForms {
    public partial class FormHelp : DockContent
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        public void showHelp(string contentPath)
        {
            if (contentPath.StartsWith("http"))
                this.web.Navigate(new Uri(contentPath));
            else
            {
                // TODO offline file rendering
                // read .md file
                // rendering .md to HTML
                // pass over the HTML to web browser control
            }
        }

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // DOOSAN network's redmine manual page
            if (e.Url.ToString().Contains("10.120")) {
                //*[@id="content"]
                HtmlElement elm = web.Document.GetElementById("content");

                //*[@id="content"]/div[2] --> <div class="wiki wiki-page">
                if (elm != null) {
                    HtmlElementCollection elmc = elm.GetElementsByTagName("div");
                    foreach(HtmlElement el in elmc)
                    {
                        if (el.GetAttribute("className") == "wiki wiki-page")
                        {
                            web.Document.Body.InnerHtml = el.InnerHtml;
                        }
                    }
                }
            }
            // internet github doosan-public's manual page
            else if (e.Url.ToString().Contains("github")) {
                // only diplay <div#readme>
                HtmlElement elm = web.Document.GetElementById("readme");
                if (elm != null) {
                    web.Document.Body.InnerHtml = elm.InnerHtml;
                }

                // TODO github markdown CSS 스타일 추가 필요
            }

            // 페이지의 일부만 잘라 왔으므로 레이아웃을 위해 Margin 설정
            web.Document.Body.Style = @"
		            min-width: 200px;
		            max-width: 980px;
		            padding: 32px;
                    padding-top: 16px;
                ";

            if (this.IsHidden)
                this.Show();
        }
    }
}
