namespace Project.WebAPI.Models.RequestModels.AppUser
{
    public class UpdateUserRequestModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
