using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ObjectLayer
{
    public class Computer : Device
    {
        public Computer()
        {
            
        }
        public static ObservableCollection<Computer> Computers = new ObservableCollection<Computer>();

        
        public static ObservableCollection<Computer> ComputersProperty
        {
            get
            {
                return Computers;
            }
            set
            {
                ComputersProperty = Computers;
            }
        }
        
       void test()
        {
            
        }
    }
}
