namespace TechnicalProofWork.Models
{
    public class PersonModel
    {
        public string Id { get; set; }
        public int IdType_Id { get; set; }
        public IdTypeModel IdType { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string FullName { get; set; }
        public List<ContactModel> Contacts { get; set; } = new List<ContactModel>();
    }
}
