using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfTestApp.Commands;
using WpfTestApp.Repositories;

namespace WpfTestApp.ViewModels
{
    public class PriceViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      var repository = new PriceRepository();
                      Price = repository.AddOne(Id);
                  }));
            }
        }

        private RelayCommand _subtractCommand;
        public RelayCommand SubtractCommand
        {
            get
            {
                return _subtractCommand ??
                  (_subtractCommand = new RelayCommand(obj =>
                  {
                      var repository = new PriceRepository();
                      Price = repository.SubtractOne(Id);
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
