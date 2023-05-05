using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CredentialManagerDb.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		public AccountRepository()
		{
		}

        public List<AccountModel> GetListAccount()
        {
            var query = "SELECT * FROM Account ";
            var listAccount = new List<AccountModel>();
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                using var commandConnection = new SqlCommand(query, connection);
                connection.Open();
                using var reader = commandConnection.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleRow);
                
                while(reader?.Read() == true)
                {
                    var account = new AccountModel()
                    {
                        Id = reader.GetInt32("id_account"),
                        Username = reader.GetString("username"),
                        Password = reader.GetString("password"),
                        DateOfCreation = reader.GetDateTime(reader.GetTimeSpan("date_of_creation"))
                    };

                    listAccount.Add(account);
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex);
            }

            return listAccount;
        }

        public bool InsertAccount(Account account)
        {
            var query = "INSERT INTO Account VALUES (@username,@passwors,@date_of_creation)";
            var user = account.GetUser();
            var insertDoneOrNot = false;

            var valuesToAddInDb = new Dictionary<string, object>()
        {
            { "@username", user.GetUsername() },
            { "@password", user.GetPassword()},
            { "@date_of_creation", account.DateOfCreation()}
        };

            try
            {
                using var connection = new SqlConnection(ConnectionString);
                using var commmand = new SqlCommand(query, connection);
                connection.Open();
                var res = valuesToAddInDb.Select(x => new SqlParameter(x.Key, x.Value)).ToArray();
                commmand.Parameters.AddRange(res);
                commmand.ExecuteNonQuery();

                insertDoneOrNot = true;
                return insertDoneOrNot;
            }
            catch(SqlException sqlExc)
            {
                Console.WriteLine(sqlExc.Message);
                return insertDoneOrNot;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return insertDoneOrNot;
            }
        }
    }
}

