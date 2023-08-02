using _028_ADO.NET_with_WindowsForms.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace _028_ADO.NET_with_WindowsForms.DAL
{
    public class ProductDAL // DAL: Data Access Layer, DAO: Data Access Object. CRUD (create, read, update, delete) veritabanı işlemleri yapılan katman
    {
        //string _connectionString = @"Server=(localdb)\MSSQLLocalDB; Initial Catalog=ETrade; User Id=sa; Password=sa;"; // SQL Server Authentication
        //string _connectionString = @"Server=(localdb)\MSSQLLocalDB; Initial Catalog=ETrade; Integrated Security=true;"; // Windows Authentication
        string _connectionString = @"Server=.\SQLEXPRESS; Initial Catalog=ETrade; Integrated Security=true;";
        SqlConnection _connection;

        void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        public List<Product> GetListWithReader() // kullanılması gereken yol!
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "";
            sql += "select p.Id, p.Name, p.UnitPrice, p.StockAmount from Products p order by p.Name";
            SqlCommand command = new SqlCommand(sql, _connection);
            SqlDataReader reader = command.ExecuteReader();
            Product product;
            List<Product> products = new List<Product>();
            while (reader.Read()) // veritabanından data kümesi çektik
            {
                product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]), // reader[0] olarak da ulaşılabilir
                    Name = reader["Name"].ToString(), // reader[1] olarak da ulaşılabilir
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]), // reader[2] olarak da ulaşılabilir
                    StockAmount = Convert.ToInt32(reader["StockAmount"]) // reader[3] olarak da ulaşılabilir
                };
                products.Add(product);
            }
            reader.Close();
            CloseConnection();
            return products;
        }

        public List<Product> GetListWithReader(int categoryId) // overloaded method
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "";
            sql += "select p.Id, p.Name, p.UnitPrice, p.StockAmount, p.CategoryId, c.Name as CategoryName ";
            sql += "from Products p, Categories c where p.CategoryId = c.Id and p.CategoryId = " + categoryId + " order by c.Name, p.Name";
            SqlCommand command = new SqlCommand(sql, _connection);
            SqlDataReader reader = command.ExecuteReader();
            Product product;
            List<Product> products = new List<Product>();
            while (reader.Read()) // veritabanından data kümesi çektik
            {
                product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]), // reader[0] olarak da ulaşılabilir
                    Name = reader["Name"].ToString(), // reader[1] olarak da ulaşılabilir
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]), // reader[2] olarak da ulaşılabilir
                    StockAmount = Convert.ToInt32(reader["StockAmount"]), // reader[3] olarak da ulaşılabilir
                    CategoryId = Convert.ToInt32(reader["CategoryId"]), // reader[4] olarak da ulaşılabilir
                    CategoryName = reader["CategoryName"].ToString() // reader[5] olarak da ulaşılabilir
                };
                products.Add(product);
            }
            reader.Close();
            CloseConnection();
            return products;
        }

        public DataTable GetDataTableWithDataAdapter()
        {
            _connection = new SqlConnection(_connectionString);
            string sql = "";
            sql += "select p.Id, p.Name, p.UnitPrice, p.StockAmount, p.CategoryId, c.Name as CategoryName ";
            sql += "from Products p, Categories c where p.CategoryId = c.Id order by c.Name, p.Name";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetDataTableWithReader()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "";
            sql += "select p.Id, p.Name, p.UnitPrice, p.StockAmount, p.CategoryId, c.Name as CategoryName ";
            sql += "from Products p, Categories c where p.CategoryId = c.Id order by c.Name, p.Name";
            SqlCommand command = new SqlCommand(sql, _connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            CloseConnection();
            return dataTable;
        }

        public DataSet GetDataSetWithDataAdapter()
        {
            _connection = new SqlConnection(_connectionString);
            string sql = "";
            sql += "select p.Id, p.Name, p.UnitPrice, p.StockAmount, p.CategoryId, c.Name as CategoryName ";
            sql += "from Products p, Categories c where p.CategoryId = c.Id order by c.Name, p.Name";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
        }

        public Product GetById(int id)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            //string sql = "select Name, UnitPrice, StockAmount, CategoryId from Products where Id = " + id;
            string sql = "select Name, UnitPrice, StockAmount, CategoryId from Products where Id = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Product product = null;
            if (reader.Read()) // veritabanından tek bir data çektik
            {
                product = new Product()
                {
                    Name = reader["Name"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    CategoryId = Convert.ToInt32(reader["CategoryId"])
                };
                product.StoreIds = new List<int>();
                reader.Close();
                command.Parameters.Clear();
                sql = "select StoreId from ProductsStores where ProductId = " + id;
                command.CommandText = sql;
                reader = command.ExecuteReader();
                while (reader.Read()) // veritabanından data kümesi çektik
                {
                    product.StoreIds.Add(Convert.ToInt32(reader["StoreId"]));
                }
            }
            reader.Close();
            CloseConnection();
            return product;
        }

        public int GetCountByCategoryId(int categoryId)
        {
            int result = 0;
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "select COUNT(*) from Products where CategoryId = @categoryId";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                result = Convert.ToInt32(reader[0]);
            }
            reader.Close();
            CloseConnection();
            return result;
        }

        public int GetCountByStoreId(int storeId)
        {
            int result = 0;
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "select COUNT(*) from ProductsStores where StoreId = @storeId";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@storeId", storeId);
            result = Convert.ToInt32(command.ExecuteScalar());
            CloseConnection();
            return result;
        }

        public void Add(Product product)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            //string sql = "insert into Products values (@name, @unitPrice, @stockAmount, @categoryId)";
            string sql = "insert into Products (Name, UnitPrice, StockAmount, CategoryId) values (@name, @unitPrice, @stockAmount, @categoryId)";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@categoryId", product.CategoryId);
            command.ExecuteNonQuery();
            sql = "select @@IDENTITY";
            command.CommandText = sql;
            command.Parameters.Clear();
            int productId = Convert.ToInt32(command.ExecuteScalar());
            foreach (var storeId in product.StoreIds)
            {
                sql = "insert into ProductsStores (ProductId, StoreId) values (" + productId + ", " + storeId + ")";
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void Update(Product product)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            // aşağıdaki ilk comment'li sql SQL Injection'a sebep olabilir! doğru yol ikinci comment'siz SQL
            //string sql = "update Products set Name = '" + product.Name + "', UnitPrice = " + product.UnitPrice +
            //             ", StockAmount = " + product.StockAmount + ", CategoryId = " + product.CategoryId +
            //             " where Id = " + product.Id;
            string sql = "update Products set Name = @name, UnitPrice = @unitPrice, StockAmount = @stockAmount, CategoryId = @categoryId where Id = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@categoryId", product.CategoryId);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            sql = "delete from ProductsStores where ProductId = " + product.Id;
            command.CommandText = sql;
            command.ExecuteNonQuery();
            foreach (var storeId in product.StoreIds)
            {
                sql = "insert into ProductsStores (ProductId, StoreId) values (" + product.Id + ", " + storeId + ")";
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void Delete(int id)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "delete from ProductsStores where ProductId = " + id;
            SqlCommand command = new SqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            sql = "delete from Products where Id = @id";
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public List<Product> GetProductList(int categoryId, List<int> storeIdList, string name)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string storeIds = "";
            string sql = "";
            sql += "select p.Id, p.Name, p.UnitPrice, p.StockAmount, p.CategoryId, c.Name as CategoryName, ";
            sql += "s.Id as StoreId, s.Name as StoreName, s.Location as StoreLocation ";
            sql += "from Products p, ProductsStores ps, Stores s, Categories c where p.Id = ps.ProductId and s.Id = ps.StoreId ";
            sql += "and p.CategoryId = c.Id ";
            if (categoryId != 0)
            {
                sql += "and p.CategoryId = " + categoryId + " ";
            }
            if (storeIdList != null && storeIdList.Count > 0)
            {
                foreach (var id in storeIdList)
                {
                    storeIds += id + ", ";
                }
                storeIds = storeIds.Trim(new char[] { ',', ' ' });
                sql += "and ps.StoreId in (" + storeIds + ") ";
            }
            if (!String.IsNullOrWhiteSpace(name))
            {
                sql += "and LOWER(p.Name) like '%" + name.Trim().ToLower() + "%' ";
            }
            sql += "order by c.Name, p.Name";
            SqlCommand command = new SqlCommand(sql, _connection);
            SqlDataReader reader = command.ExecuteReader();
            Product product;
            List<Product> products = new List<Product>();
            while (reader.Read()) // veritabanından data kümesi çektik
            {
                product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]), // reader[0] olarak da ulaşılabilir
                    Name = reader["Name"].ToString(), // reader[1] olarak da ulaşılabilir
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]), // reader[2] olarak da ulaşılabilir
                    StockAmount = Convert.ToInt32(reader["StockAmount"]), // reader[3] olarak da ulaşılabilir
                    CategoryId = Convert.ToInt32(reader["CategoryId"]), // reader[4] olarak da ulaşılabilir
                    CategoryName = reader["CategoryName"].ToString(), // reader[5] olarak da ulaşılabilir
                    StoreId = Convert.ToInt32(reader["StoreId"]), // reader[6] olarak da ulaşılabilir
                    StoreName = reader["StoreName"].ToString(), // reader[7] olarak da ulaşılabilir
                    StoreLocation = reader["StoreLocation"].ToString(), // reader[8] olarak da ulaşılabilir
                    StoreNameAndLocation = reader["StoreName"].ToString() + " - " + reader["StoreLocation"].ToString()
                };
                products.Add(product);
            }
            reader.Close();
            CloseConnection();
            return products;
        }
    }
}
