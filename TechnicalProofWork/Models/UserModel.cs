using System;

namespace TechnicalProofWork.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int UserType_Id { get; set; }
        public string Person_Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool State { get; set; }
        public PersonModel Person { get; set; }
        public List<SoftSkillModel> SoftSkills { get; set; } = new List<SoftSkillModel>();
    }
}
