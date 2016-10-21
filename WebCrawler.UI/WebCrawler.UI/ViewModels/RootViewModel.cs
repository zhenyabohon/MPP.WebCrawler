using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WebCrawler.UI.ViewModels
{

    public class UrlViewModel
    {
        public int Level { get; set; }

        public string Url { get; set; }

        public ObservableCollection<UrlViewModel> Urls { get; set; }

        public UrlViewModel()
        {
            Urls = new ObservableCollection<UrlViewModel>();
        }
    }
}
