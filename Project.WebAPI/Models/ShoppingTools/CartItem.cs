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
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("ProductName")]
        public string ProductName { get; set; }
        [JsonProperty("Quantity")]
        public short Quantity { get; set; }
        [JsonProperty("UnitPrice")]
        public decimal UnitPrice { get; set; }
        [JsonProperty("SubTotal")]
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
