using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028_ADO.NET_with_WindowsForms.Data
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public string NameAndLocation
        {
            get { return Name + " - " + Location; }
        }
    }
}
