namespace TechnicalProofWork.Models
{
    public class MenuModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public List<MenuModel> SubMenu { get; set; } = new List<MenuModel>();
        public bool IsOpen { get; set; }
    }

}
