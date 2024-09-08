namespace PizzaBraz.API.ViewModels.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid CompanyId { get; set; }
    }
}
