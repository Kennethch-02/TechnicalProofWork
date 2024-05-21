namespace TechnicalProofWork.Models
{
    public class ContactModel
    {
        public string Data { get; set; }
        public string Person_Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool State { get; set; }
        public int ContactType_Id { get; set; }
        public ContactTypeModel ContactType { get; set; }
    }
}
