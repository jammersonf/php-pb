using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using php_pb.Src.Classes;

namespace php_pb.Src.Pages
{
    public partial class BlogItem : PhoneApplicationPage
    {
        public Blog Blog { get; set; }
        public BlogItem()
        {
            InitializeComponent();
            Browser.Navigated += Browser_Navigate;
            Browser.LoadCompleted += Browser_LoadCompleted;
        }

        private void Browser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            //exibe o browser
            Browser.Visibility = System.Windows.Visibility.Visible;
            //esconde o progress
            Progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Browser_Navigate(object sender, NavigationEventArgs e)
        {
            Progress.Visibility = System.Windows.Visibility.Visible;

            Browser.Visibility = System.Windows.Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Blog != null)
            {
                tTitle.Text = Blog.Title;
                Browser.NavigateToString(
                    "<html><head> <link href='/assets/colors-dark.css' rel='stylesheet'>"+
                        "<link href='/assets/fancybox/jquery.fancybox.css' rel='stylesheet'>"+
                        "<link href='/assets/style.css' rel='stylesheet'>"+
                        "<script type='text/javascript' src='http://w.sharethis.com/button/buttons.js'></script>"+
                        "<script>(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){"+
                          "(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),"+
                          "m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)"+
                          "})(window,document,'script','//www.google-analytics.com/analytics.js','ga');"+
                          "ga('create', 'UA-28634448-2', 'php-pb.net');"+
                          "ga('send', 'pageview');</script>"+
                     "<script src='/assets/jquery.min.js'></script>"+
                     "<script src='/assets/jquery.mobilemenu.min.js'></script>"+
                     "<script src='/assets/jquery.fancybox.pack.js'></script>"+
                    "</head><body style='background-color:#ccc'>"+
                    Blog.Description+
                    "</body></html>"
                    );
            }
        }
    }
}