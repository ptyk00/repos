using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaj12
{
     public class Model:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _zoom;

        public int Zoom
        {
            get { return _zoom; }
            set { _zoom = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Zoom"));}
        }
    }
}
