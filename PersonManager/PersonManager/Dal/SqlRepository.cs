using PersonManager.Models;
using PersonManager.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PersonManager.Dal
{
    internal class SqlRepository : IRepository
    {
        private readonly string cs = 
            ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public void AddPerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture,
                });
            var id = new SqlParameter(
                nameof(Person.IDPerson), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            person.IDPerson = (int)id.Value;
        }

        public void DeletePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
            cmd.ExecuteNonQuery();
        }

        public IList<Person> GetPeople()
        {
            IList<Person> list = new List<Person>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadPerson(dr));
            }
            return list;
        }

        public Person getPerson(int idPerson)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), idPerson);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadPerson(dr);
            }
            throw new ArgumentException("Wrong ID");
        }

        private Person ReadPerson(SqlDataReader dr) => new Person
        {
            IDPerson = (int)dr[nameof(Person.IDPerson)],
            Age = (int)dr[nameof(Person.Age)],
            FirstName = dr[nameof(Person.FirstName)].ToString(),
            LastName = dr[nameof(Person.LastName)].ToString(),
            Email = dr[nameof(Person.Email)].ToString(),
            Picture = ImageUtils.ByteArrayFromReader(dr, nameof(Person.Picture))
        };

        public void UpdatePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture,
                });
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
            cmd.ExecuteNonQuery();
        }
    }
}
