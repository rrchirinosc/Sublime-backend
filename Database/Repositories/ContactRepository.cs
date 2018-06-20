using Dapper;
using Sublime.Database.Pocos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sublime.Database.Repositories
{

    public class ContactRepository
    {
        private IDbConnection Connection { get; set; }
        private const string ConnectionString = "Server=.\\SqlExpress;Database=Sublime;Trusted_Connection=Yes";

        public ContactRepository()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        public IEnumerable<string> Companies
        {
            get
            {
                return Connection.Query<string>("SELECT DISTINCT Name from [Company]");
            }
        }

        public IEnumerable<string> CompanyName(int companyID)
        {
            string companyStr = string.Format("select [Name] from [Company] where [Id]={0}", companyID);
            return Connection.Query<string>(companyStr);
        }

        public IEnumerable<Contact> Contacts
        {
            get
            {
                string sql = "SELECT [Contact].FirstName, [Contact].LastName, [Contact].Phone, [Contact].Email, [Contact].Personalnr, [Company].Name AS CompanyName" +
                                                " FROM [Contact] INNER JOIN [Company] ON [Contact].CompanyId=[Company].Id";
                return Connection.Query<Contact>(sql);
            }
        }

        public async Task<int> NewContactAsync(Contact contact)
        {
            return Connection.Execute("INSERT Contact " +
                "(FirstName, LastName, PersonalNr, Email, Phone, CompanyId)" +
                "VALUES (@FirstName, @LastName, @PersonalNr, @Email, @Phone, " +
                "(SELECT Id FROM Company WHERE Name=@Name))",
                new
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Name = contact.CompanyName,
                    PersonalNr = contact.Personalnr
                });
        }

        public async Task<int> UpdateContactAsync(Contact contact)
        {
            return Connection.Execute("UPDATE Contact " +
                "SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone," +
                "CompanyId=(SELECT Id FROM Company WHERE Name=@Name)" +
                "WHERE PersonalNr=@PersonalNr", 
                new
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Name = contact.CompanyName,
                    PersonalNr = contact.Personalnr
                });
        }
    }
}