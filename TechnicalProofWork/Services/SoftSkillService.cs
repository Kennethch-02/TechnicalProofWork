using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using TechnicalProofWork.Models;
using TechnicalProofWork.Connection;
using Radzen;

namespace TechnicalProofWork.Services
{
    public static class SoftSkillService
    {
        public static List<SoftSkillTypeModel> getTypesList()
        {
            DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Get_List_SoftSkills, new List<SqlParameter>());

            if (result.Rows.Count > 0)
            {
                var message = result.Rows[0]["Message"].ToString();
                var state = result.Rows[0]["State"].ToString();
                var user = new List<SoftSkillTypeModel>();
                if (state.Equals("1"))
                {
                    string json = result.Rows[0]["Data"].ToString();
                    user = JsonConvert.DeserializeObject<List<SoftSkillTypeModel>>(json);
                }
                return user;

            }
            else
            {
                return null;
            }
        }
        public static void HandleUpdateSoftSkill(UserModel user) {

            foreach (var skill in user.SoftSkills) {
                DataTable result = SQLConnection.ExecuteSP(SQLConnection.sp_Update_Or_Insert_UserSoftSkill, new List<SqlParameter>() {
                    new SqlParameter("@SoftSkills_Id", skill.SoftSkill.Id),
                    new SqlParameter("@UserName", user.Name),
                    new SqlParameter("@State", skill.State)
                });
            }
        }
    }
}
