using _028_ADO.NET_with_WindowsForms.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028_ADO.NET_with_WindowsForms.DAL
{
    class CategoryDAL
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

        public List<Category> GetList()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "select Id, Name from Categories";
            SqlCommand command = new SqlCommand(sql, _connection);
            SqlDataReader reader = command.ExecuteReader();
            Category category;
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                category = new Category()
                {
                    Id = Convert.ToInt32(reader["Id"]), 
                    Name = reader["Name"].ToString()
                };
                categories.Add(category);
            }
            reader.Close();
            CloseConnection();
            return categories;
        }

        public void Add(Category category)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "insert into Categories (Name) values (@name)";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@name", category.Name);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void Update(Category category)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "update Categories set Name = @name where Id = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@name", category.Name);
            command.Parameters.AddWithValue("@id", category.Id);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void Delete(int id)
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
            string sql = "delete from Categories where Id = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
