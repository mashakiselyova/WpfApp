using System.Windows;
using WpfTestApp.ViewModels;

namespace WpfTestApp.Views
{
    public partial class PriceView : Window
    {
        public PriceView(PriceViewModel priceViewModel)
        {
            InitializeComponent();
            DataContext = priceViewModel;
        }
    }
}
