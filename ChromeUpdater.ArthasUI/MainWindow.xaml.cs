using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Arthas.Controls.Metro;
using ChromeUpdater.Services;

namespace ChromeUpdater.ArthasUI
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            //https://www.google.com/chrome/browser/thankyou.html?standalone=1&installdataindex=defaultbrowser&platform=win64&extra=stablechannel
            //https://www.google.com/chrome/thank-you.html?standalone=1&statcb=1&installdataindex=empty&defaultbrowser=0
            var menu = sender as MetroMenuItem;
            if (menu == null) return;
            var header = (string)menu.Header;
            if (header.StartsWith("耍下"))
                System.Diagnostics.Process.Start("https://github.com/shuax");
            else if (header.StartsWith("ONEO"))
                System.Diagnostics.Process.Start("https://github.com/1217950746");
            else if (header.StartsWith("win_stable_x64"))
                //https://www.google.com/chrome/thank-you.html?extra=stablechannel&platform=win64&standalone=1&statcb=1&installdataindex=empty&defaultbrowser=0
                System.Diagnostics.Process.Start("https://www.google.cn/intl/zh-CN/chrome/thank-you.html?standalone=1&statcb=1&installdataindex=empty&defaultbrowser=0&platform=win64");
            else if (header.StartsWith("win_beta_x64"))
                System.Diagnostics.Process.Start("https://www.google.cn/intl/zh-CN/chrome/beta/thank-you.html?standalone=1&statcb=1&installdataindex=empty&defaultbrowser=0&platform=win64");
            else if (header.StartsWith("win_dev_x64"))
                //https://www.google.com/chrome/dev/thank-you.html?extra=devchannel&platform=win64&standalone=1&statcb=1&installdataindex=empty&defaultbrowser=0
                System.Diagnostics.Process.Start("https://www.google.cn/intl/zh-CN/chrome/dev/thank-you.html?installdataindex=empty&platform=win64&standalone=1&statcb=1&defaultbrowser=0");
            else if (header.StartsWith("win_canary_x64"))
                System.Diagnostics.Process.Start("https://www.google.cn/intl/zh-CN/chrome/canary/thank-you.html?installdataindex=empty&platform=win64&standalone=1&statcb=1&defaultbrowser=0");
            else if (header.StartsWith("Debian/Ubuntu"))
                System.Diagnostics.Process.Start("https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb");
            else if (header.StartsWith("Fedora/openSUSE"))
                System.Diagnostics.Process.Start("https://dl.google.com/dl/linux/direct/google-chrome-stable_current_x86_64.rpm");
            else if (header.StartsWith("mac_x64"))
                System.Diagnostics.Process.Start("https://www.google.com/chrome/browser/thankyou.html?platform=mac&statcb=1&extra=stablechannel");

            else if (header.StartsWith("Chromium"))
                //http://commondatastorage.googleapis.com/chromium-browser-continuous/index.html
                System.Diagnostics.Process.Start("http://commondatastorage.googleapis.com/chromium-browser-continuous/index.html");
            else if (header.StartsWith("Chrome首页"))
                //http://commondatastorage.googleapis.com/chromium-browser-continuous/index.html
                System.Diagnostics.Process.Start("https://www.google.com/intl/zh-CN/chrome/");
            else if (header.StartsWith("福建-兮"))
                //http://commondatastorage.googleapis.com/chromium-browser-continuous/index.html
                System.Diagnostics.Process.Start("https://github.com/wpyok500/ChromeUpdater");
            else
                System.Diagnostics.Process.Start("https://github.com/TkYu/ChromeUpdater");
        }

        private void TxtPath_OnButtonClick(object sender, EventArgs e)
        {
            ((ChromeUpdaterCore)DataContext).CmdFolderBrowse.Execute(null);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //init messageservice here
            ServiceManager.Instance.AddService<IMessageService>(new MessageService(this));
        }
    }
}
