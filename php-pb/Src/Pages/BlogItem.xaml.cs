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
                Browser.NavigateToString(Blog.Description);
            }
        }
    }
}