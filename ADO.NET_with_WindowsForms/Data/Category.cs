using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028_ADO.NET_with_WindowsForms.Data
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
            
        }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
