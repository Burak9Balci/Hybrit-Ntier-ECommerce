﻿namespace Project.WebAPI.Models.RequestModels.Category
{
    public class UpdateCategoryRequestModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
