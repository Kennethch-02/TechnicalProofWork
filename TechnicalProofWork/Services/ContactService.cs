using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using TechnicalProofWork.Models;
using TechnicalProofWork.Connection;

namespace TechnicalProofWork.Services
{
    public static class ContactService
    {
        public static List<ContactTypeModel> getContactTypes()
        {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Get_List_ContactTypes, new List<SqlParameter>());

            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                var user = new List<ContactTypeModel>();
                if (state.Equals("1"))
                {
                    string json = result.Rows[0]["Data"].ToString();
                    user = JsonConvert.DeserializeObject<List<ContactTypeModel>>(json);
                }
                return user;

            }
            else
            {
                return null;
            }
        }
        public static void HandleUpdateContact(UserModel user) {
            foreach (var contact in user.Person.Contacts)
            {
                    DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Update_Or_Insert_Contact, new List<SqlParameter>()
                    {
                        new SqlParameter("@Person_Id", user.Person_Id),
                        new SqlParameter("@ContactType_Id", contact.ContactType_Id),
                        new SqlParameter("@Data", contact.Data),
                        new SqlParameter("@State", contact.State)
                    });
                }
        }
    }
    
}
