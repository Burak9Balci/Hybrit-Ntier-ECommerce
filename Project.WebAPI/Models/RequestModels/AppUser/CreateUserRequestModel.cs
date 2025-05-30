namespace Project.WebAPI.Models.RequestModels.AppUser
{
    public class CreateUserRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
