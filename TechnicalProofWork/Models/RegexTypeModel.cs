namespace TechnicalProofWork.Models
{
    public class RegexTypeModel
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public string Regex { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool State { get; set; }
    }
}
