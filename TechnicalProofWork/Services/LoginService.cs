using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using TechnicalProofWork.Connection;
using TechnicalProofWork.Models;

namespace TechnicalProofWork.Services
{
    public class LoginService
    {
        public static UserModel Login(string username, string password)
        {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.SP_LoginIn, new List<SqlParameter>
            {
                new SqlParameter("@Name", username),
                new SqlParameter("@Password", password)
            });

            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                var user = new UserModel();
                if (state.Equals("1"))
                {
                    string json = result.Rows[0]["Data"].ToString();
                    user = JsonConvert.DeserializeObject<UserModel>(json);
                }
                return user;

            }
            else
            {
                return null;
            }
        }
    }
}
