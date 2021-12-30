using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF19.Models;

namespace WPF19.ViewModels
{
    class MainWindowVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropChanged([CallerMemberName]string propertName = null) {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }

        private int radius;

        public int Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropChanged();
            }
        }


        private double length;

        public double Length
        {
            get => length;
            set
            {
                length = value;
                OnPropChanged();
            }
        }

        public ICommand CalcCommand { get; }
        private void OnCalcCommandExecute(object obj) {

            Length = MainWindowModel.CalcCircleLeng(Radius);
        }

        private bool CanCalcCommandExecute(object obj)
        {
            return Radius > 0;
        }


        public MainWindowVM() {
            CalcCommand = new RelayCommand(OnCalcCommandExecute, CanCalcCommandExecute);
        }

    }
}
