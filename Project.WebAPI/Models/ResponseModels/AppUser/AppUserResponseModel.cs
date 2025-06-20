﻿namespace Project.WebAPI.Models.ResponseModels.AppUserResponseModels
{
    public class AppUserResponseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public List<string> Roles { get; set; } = new();

    }
}
