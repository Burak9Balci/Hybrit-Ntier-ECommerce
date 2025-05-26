using Newtonsoft.Json;

namespace Project.WebAPI.Models.ShoppingTools
{
    [Serializable]
    public class CartItem
    {
        public CartItem()
        {
            Quantity++;
        }
        [JsonProperty]
        public int ID { get; set; }
        [JsonProperty]
        public string ProductName { get; set; }
        [JsonProperty]
        public short Quantity { get; set; }
        [JsonProperty]
        public decimal UnitPrice { get; set; }
        [JsonProperty]
        public decimal SubTotal {
            get
            {
                return Quantity * UnitPrice;
            }
           
        }

        [JsonProperty("ImagePath")]

        public string ImagePath { get; set; }

        [JsonProperty("CategoryName")]

        public string CategoryName { get; set; }

        [JsonProperty("CategoryId")]

        public int? CategoryId { get; set; }
    }
}
