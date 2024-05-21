using Newtonsoft.Json;
using Radzen;
using System.Data;
using System.Data.SqlClient;
using TechnicalProofWork.Connection;
using TechnicalProofWork.Models;

namespace TechnicalProofWork.Services
{
    public static class PersonService
    {
        public static PersonModel getPersonById(string id) {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Get_List_Persons, new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            });
            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                var user = new PersonModel();
                if (state.Equals("1"))
                {
                    string json = result.Rows[0]["Data"].ToString();
                    user = JsonConvert.DeserializeObject<PersonModel>(json);
                }
                return user;
            }
            else
            {
                return null;
            }
        }
        public static List<PersonModel> getPersonList()
        {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Get_List_Persons, new List<SqlParameter>());
            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                var user = new List<PersonModel>();
                if (state.Equals("1"))
                {
                    string json = result.Rows[0]["Data"].ToString();
                    user = JsonConvert.DeserializeObject<List<PersonModel>>(json);
                }
                return user;
            }
            else
            {
                return null;
            }
        }
        public static List<IdTypeModel> getIdTypes()
        {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Get_List_IdTypes, new List<SqlParameter>());
            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                var idtypes = new List<IdTypeModel>();
                if (state.Equals("1"))
                {
                    string json = result.Rows[0]["Data"].ToString();
                    idtypes = JsonConvert.DeserializeObject<List<IdTypeModel>>(json);
                }
                return idtypes;
            }
            else
            {
                return null;
            }
        }

        public static MessageFromBD HandleUpdatePerson(PersonModel person)
        {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Update_Or_Insert_Person, new List<SqlParameter>
            {
                new SqlParameter("@Id", person.Id),
                new SqlParameter("@IdType_Id", person.IdType_Id),
                new SqlParameter("@Name", person.Name),
                new SqlParameter("@FirstLastName", person.FirstLastName),
                new SqlParameter("@SecondLastName", person.SecondLastName)
            });
            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                if (state.Equals("1"))
                {
                    return new MessageFromBD
                    {
                        Message = message,
                        State = state,
                        Severity = NotificationSeverity.Success
                    };
                }
                else if (state.Equals("2"))
                {
                    return new MessageFromBD
                    {
                        Message = message,
                        State = state,
                        Severity = NotificationSeverity.Warning
                    };
                }
                else
                {
                    return new MessageFromBD
                    {
                        Message = message,
                        State = state,
                        Severity = NotificationSeverity.Error
                    };
                }
            }
            else
            {
                return new MessageFromBD
                {
                    Message = "Internal Error",
                    State = "2",
                    Severity = NotificationSeverity.Error
                };
            }
        }
    }
}
