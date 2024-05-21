using System.Data;
using System.Data.SqlClient;

namespace TechnicalProofWork.Connection
{
    public static class SQLConnection
    {
        #region Stored Procedures
        public static string SP_LoginIn = "sp_LogIn_User";
        public static string SP_Get_List_Users = "sp_Get_List_Users";
        public static string sp_Get_List_UserTypes = "sp_Get_List_UserTypes";
        public static string sp_Get_List_SoftSkills = "sp_Get_List_SoftSkills";
        public static string sp_Update_Or_Insert_User = "sp_Update_Or_Insert_User";
        public static string sp_Get_List_ContactTypes = "sp_Get_List_ContactTypes";
        public static string sp_Update_Or_Insert_Contact = "sp_Update_Or_Insert_Contact";
        public static string sp_Update_Or_Insert_UserSoftSkill = "sp_Update_Or_Insert_UserSoftSkill";
        public static string sp_Get_List_Persons = "sp_Get_List_Persons";
        public static string sp_Update_Or_Insert_Person = "sp_Update_Or_Insert_Person";
        public static string sp_Get_List_IdTypes = "sp_Get_List_IdTypes";
        #endregion

        public static string Connection = "Server=KCASTILLOH-PC;Database=TechnicalProofWork;Trusted_Connection=True;";
        public static DataTable ExecuteSP(string SPName, List<SqlParameter> parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SPName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
