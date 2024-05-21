namespace TechnicalProofWork.Models
{
    public class IdTypeModel
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool State { get; set; }
        public int RegexType_Id { get; set; }
        public RegexTypeModel RegexType { get; set; }
    }
}
