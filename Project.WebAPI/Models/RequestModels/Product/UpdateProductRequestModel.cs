namespace Project.WebAPI.Models.RequestModels.Product
{
    public class UpdateProductRequestModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string? CategoryName { get; set; }
        public short? Stock { get; set; }
        public int? CategoryID { get; set; }
        public string? ImagePath { get; set; }
    }
}
