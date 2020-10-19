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
using System.Windows.Shapes;
using WpfTestApp.Repositories;
using WpfTestApp.ViewModels;

namespace WpfTestApp.Views
{
    public partial class PriceView : Window
    {
        public PriceViewModel ViewModel { get; set; }

        public PriceView()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            price.Text = ViewModel.Price.ToString();
        }

        private void SubtractOne(object sender, RoutedEventArgs e)
        {
            var repository = new PriceRepository();
            price.Text = repository.SubtractOne(ViewModel.Id).ToString();
        }

        private void AddOne(object sender, RoutedEventArgs e)
        {
            var repository = new PriceRepository();
            price.Text = repository.AddOne(ViewModel.Id).ToString();
        }
 
    }
}
