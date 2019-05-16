using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Expression.Interactivity.Core;

namespace ItemsControlPopup
{
    public class MainViewModel : INotifyPropertyChanged
    {
        Random rand = new Random();
        private ObservableCollection<string> names;

        public ObservableCollection<String> Names
        {
            get => names;
            set
            {
                names = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddItem
        {
            get => new ActionCommand(() =>
            {
                var text = String.Concat(Enumerable.Range(0, 10).Select(i => (char)rand.Next()));
                Names.Add($"Test {text}");
            });
        }


        public MainViewModel()
        {
            Names = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
