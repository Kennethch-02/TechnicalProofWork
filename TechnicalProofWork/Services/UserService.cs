using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using TechnicalProofWork.Models;
using TechnicalProofWork.Connection;
using Radzen;

namespace TechnicalProofWork.Services
{
    public static class UserService
    {
        public static List<UserModel> getUserList() {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.SP_Get_List_Users, new List<SqlParameter>());

            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                var user = new List<UserModel>();
                if (state.Equals("1"))
                {
                    string json = result.Rows[0]["Data"].ToString();
                    user = JsonConvert.DeserializeObject<List<UserModel>>(json);
                }
                return user;

            }
            else
            {
                return null;
            }

        }
        public static List<UserTypeModel> getUserTypesList() {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Get_List_UserTypes, new List<SqlParameter>());

            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                var user = new List<UserTypeModel>();
                if (state.Equals("1"))
                {
                    string json = result.Rows[0]["Data"].ToString();
                    user = JsonConvert.DeserializeObject<List<UserTypeModel>>(json);
                }
                return user;

            }
            else
            {
                return null;
            }
        }
        #region Update or Insert User
        public static MessageFromBD handleUpdateUser(UserModel user, bool isInsert = false) {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Update_Or_Insert_User, new List<SqlParameter>
            {
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@UserType_Id", user.UserType_Id),
                new SqlParameter("@Person_Id", user.Person_Id),
                new SqlParameter("@State", user.State),
                new SqlParameter("@isInsert", isInsert)
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
            }else
            {
                return new MessageFromBD
                {
                    Message = "Internal Error",
                    State = "2",
                    Severity = NotificationSeverity.Error
                };
            }
        }
        #endregion
    }
}
