using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _028_ADO.NET_with_WindowsForms.Data;

namespace _028_ADO.NET_with_WindowsForms.DAL
{
    class StoreDAL
    {
        //string _connectionString = @"Server=(localdb)\MSSQLLocalDB; Initial Catalog=ETrade; Integrated Security=true;";
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

        public List<Store> GetList()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "select Id, Name, Location from Stores";
            SqlCommand command = new SqlCommand(sql, _connection);
            SqlDataReader reader = command.ExecuteReader();
            Store store;
            List<Store> stores = new List<Store>();
            while (reader.Read())
            {
                store = new Store()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Location = reader["Location"].ToString()
                };
                stores.Add(store);
            }
            reader.Close();
            CloseConnection();
            return stores;
        }

        public Store GetById(int id)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "select Id, Name, Location from Stores where Id = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Store store = null;
            if (reader.Read())
            {
                store = new Store()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Location = reader["Location"].ToString()
                };
            }
            reader.Close();
            CloseConnection();
            return store;
        }

        public void Add(Store store)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "insert into Stores (Name, Location) values (@name, @location)";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@name", store.Name);
            command.Parameters.AddWithValue("@location", store.Location);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void Update(Store store)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "update Stores set Name = @name, Location = @location where Id = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@name", store.Name);
            command.Parameters.AddWithValue("@location", store.Location);
            command.Parameters.AddWithValue("@id", store.Id);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void Delete(int id)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "delete from Stores where Id = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public DataTable GetStoreDataTable()
        {
            _connection = new SqlConnection(_connectionString);
            string sql = "";
            sql += "select Id, Name + ' - ' + Location as NameAndLocation from Stores";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
