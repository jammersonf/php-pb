using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using php_pb.Resources;
using php_pb.Src.Classes;
using php_pb.Src.Pages;
using System.Diagnostics;

namespace php_pb
{
    public partial class MainPage : PhoneApplicationPage
    {
        public Blog Blog { get; set; }
        public MainPage()
        {
            InitializeComponent();
            ListBox.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Progress.Visibility = Visibility.Visible;
            BlogService.GetBlogAsync(AtualizarBlog, false);
        }

        private void AtualizarBlog(List<Blog> blog)
        {
            ListBox.ItemsSource = blog;
            Progress.Visibility = Visibility.Collapsed;
            Debug.WriteLine("atualizou a lista...");
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lê o indice selecionado
            int index = (sender as ListBox).SelectedIndex;
            if (index != -1)
            {
                Blog blog = (sender as ListBox).SelectedItem as Blog;
                //salva a notícia selecionada
                this.Blog = blog;
                this.NavigationService.Navigate(new Uri("/Src/Pages/BlogItem.xaml", UriKind.Relative));
                //zera o estado de seleção do listbox, para não dar problemas no voltar
                (sender as ListBox).SelectedIndex = -1;
            }
        }

        //ao sair da página, passa o objeto blog como parametro para a outra tela
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            BlogItem page = e.Content as BlogItem;
            if (page != null)
            {
                //passa o objeto como parametro
                page.Blog = this.Blog;
            }
        }
    }
}