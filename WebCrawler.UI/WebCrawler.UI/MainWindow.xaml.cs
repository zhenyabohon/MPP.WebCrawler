using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WebCrawler.Core.Interfaces;
using WebCrawler.Core.Models;
using WebCrawler.Core.Services;
using WebCrawler.UI.ViewModels;

namespace WebCrawler.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private void treeView_Loaded(object sender, RoutedEventArgs e)
        {
            ISimpleWebCrawler crawler = new SimpleWebCrawler(1);
            //CrawlResult res = crawler.PerformCrawlingAsync(new[] { "http://localhost/" }).Result;

            treeView.DataContext = Conv(new List<UrlModel>());
            
        }

        private List<UrlViewModel> Conv(List<UrlModel> models)
        {
            List<UrlViewModel> result = new List<UrlViewModel>();
            //foreach (var model in models)
            //{
            //    result.Add(new UrlViewModel()
            //    {
            //        Level = model.Level,
            //        Url = model.Url,
            //        Urls = new ObservableCollection<UrlViewModel>(Conv(model.InnerUrls.ToList()))
            //    });
            //}
            result.Add(new UrlViewModel()
            {
                Level = 4,
                Url= "gg"
            });
            return result;
        }

    }
}
