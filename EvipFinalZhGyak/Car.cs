using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvipFinalZhGyak
{
    public class Car
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public string Description
        {
            get
            {
                return $"{Name}, {Price} Ft/nap ({Type})";
            }
        }

        public Car(string name, string type, int price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
    }
}
