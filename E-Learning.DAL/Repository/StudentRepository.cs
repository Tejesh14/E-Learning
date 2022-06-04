using E_Learning.DAL.Models;
using E_Learning.DAL.Interface;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;

namespace E_Learning.DAL.Repositories
{
    public class StudentRepository : ILearnRepository<Student>
    {
        private string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string Add(Student data)
        {
            var query = $"INSERT INTO STUDENTS (Id, Name, Email, DateOfBirth, ContactNumber, Age, FathersName, MothersName, Address, Username) VALUES ('{Guid.NewGuid().ToString()}', '{data.Name}', '{data.Email}', '{data.DateOfBirth}', '{data.ContactNumber}', {data.Age}, '{data.FathersName}', '{data.MothersName}', '{data.Address}', '{data.Username}');";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var res = connection.Execute(query);
                if (res > 0)
                    return "Data entered successfully";
                else
                    return "Insertion failure!!!";
            }
        }

        public string Delete(string id)
        {
            var query = $"DELETE FROM STUDENTS WHERE Id = '{id}';";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var res = connection.Execute(query);
                if (res > 0)
                    return "Data deleted successfully";
                else
                    return "Deletion faluire";
            }
        }

        public string Edit(string id, Student data)
        {
            var query = $"UPDATE STUDENTS SET Name='{data.Name}', Email='{data.Email}', DateOfBirth='{data.DateOfBirth}', ContactNumber='{data.ContactNumber}', Age={data.Age}, FathersName='{data.FathersName}', MothersName='{data.MothersName}', Address='{data.Address}', Username='{data.Username}' WHERE Id = '{id}';";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var res = connection.Execute(query);
                if (res > 0)
                    return "Data updated successfully";
                else
                    return "Updation faluire";
            }
        }

        public List<Student> Get()
        {
            string query = "SELECT * FROM STUDENTS";
            List<Student> students = new List<Student>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                students = connection.Query<Student>(query).ToList();
            }

            return students;
        }

        public Student GetByUserName(string username)
        {
            string query = $"SELECT * FROM STUDENTS WHERE Username={username}";
            Student students = new Student();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                students = connection.QueryFirst(query);
            }
            return students;
        }

        public Student Search(string id)
        {
            string query = $"SELECT * FROM STUDENTS WHERE Id='{id}';";
            Student students = new Student();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                students = connection.QueryFirst<Student>(query);
            }
            return students;
        }
    }
}