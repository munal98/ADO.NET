using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028_ADO.NET_with_WindowsForms.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int StoreId { get; set; } // select için
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public string StoreNameAndLocation { get; set; }
        public List<int> StoreIds { get; set; } // insert ve update için
    }
}
