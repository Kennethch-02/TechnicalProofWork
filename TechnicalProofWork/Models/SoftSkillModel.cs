namespace TechnicalProofWork.Models
{
    public class SoftSkillModel
    {
        public int SoftSkills_Id { get; set; }
        public string User_Name { get; set; }
        public bool State { get; set; }
        public SoftSkillTypeModel SoftSkill { get; set; }
    }
}
