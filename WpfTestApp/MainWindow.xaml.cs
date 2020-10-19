using System;
using System.Windows;
using WpfTestApp.Repositories;
using WpfTestApp.ViewModels;
using WpfTestApp.Views;

namespace WpfTestApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var repository = new AssortmentRepository();
            assortmentGrid.ItemsSource = repository.GetAll();
        }

        private void OnClickRefresh(object sender, RoutedEventArgs e)
        {
            var repository = new AssortmentRepository();
            assortmentGrid.ItemsSource = repository.GetAll();
        }

        private void OnClickCreate(object sender, RoutedEventArgs e)
        {
            var repository = new AssortmentRepository();
            try
            {
                var item = new Item
                {
                    Code = Convert.ToInt32(code.Text),
                    Tekla = tekla.Text,
                    IdProfileType = Convert.ToInt32(idProfileType.Text),
                    Profile = profile.Text,
                    IsShortA = Convert.ToBoolean(isShortA.Text),
                    Price = Convert.ToInt32(price.Text),
                    DefaultLength = defaultLength.Text,
                    DefaultWidth = defaultWidth.Text,
                    BigCode = bigCode.Text,
                    Standard = standard.Text,
                    Weight = Convert.ToDouble(weight.Text)
                };
                repository.Create(item);
            }
            catch (Exception)
            {
                MessageBox.Show("Data is incorrect");
            }
            finally
            {
                assortmentGrid.ItemsSource = repository.GetAll();
            }
        }

        private void OnClickSave(object sender, RoutedEventArgs e)
        {
            var repository = new AssortmentRepository();
            var item = (Item)assortmentGrid.SelectedItem;
            repository.Update(item);
            assortmentGrid.ItemsSource = repository.GetAll();
        }

        private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            var repository = new AssortmentRepository();
            var item = (Item)assortmentGrid.SelectedItem;
            repository.Delete(item.Id);
            assortmentGrid.ItemsSource = repository.GetAll();
        }

        private void OnDoubleClick(object sender, RoutedEventArgs e)
        {
            var item = assortmentGrid.SelectedValue as Item;       
            PriceView view = new PriceView();
            view.ViewModel = new PriceViewModel
            {
                Id = item.Id,
                Price = item.Price
            };
            view.Show();



        }
    }
}
