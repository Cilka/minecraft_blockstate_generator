using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockstateCreator
{
    [Serializable]
  public  class Cache :INotifyPropertyChanged 
    {

        public string ReferenceLocation { get; set; }
        public string ModId { get; set; }
        public bool BatchMode { get; set; }
        public bool ItemOnly { get; set; }
        [field:NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
